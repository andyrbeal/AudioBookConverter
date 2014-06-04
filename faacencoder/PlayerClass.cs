using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using Microsoft.DirectX.DirectSound;
//using Microsoft.DirectX;
using Yeti.WMFSdk;
using Yeti.MMedia;

namespace AudioBookConverter {
	class PlayerClass {

		private AutoResetEvent BufferNotificationEvent;
		protected SecondaryBuffer sound;
		protected Notify BufferNotify;
		protected Thread DataTransferThread;
		private string file;
		private AudioBookConverterMain Parent;


		public PlayerClass (AudioBookConverterMain Caller, string filename) {
			if (GetSourceExt(filename) != "mp3") return;
			file = filename;
			Parent = Caller;
			Microsoft.DirectX.DirectSound.WaveFormat format = new Microsoft.DirectX.DirectSound.WaveFormat(); 
			
				WmaStream wmastr = new WmaStream(filename);
				format.BlockAlign = wmastr.Format.nBlockAlign;
				format.Channels = wmastr.Format.nChannels;
				format.SamplesPerSecond = wmastr.Format.nSamplesPerSec;
				format.BitsPerSample = wmastr.Format.wBitsPerSample;
				format.AverageBytesPerSecond = format.BlockAlign * format.SamplesPerSecond;
				wmastr.Dispose();
	
			BufferDescription desc = new BufferDescription(format);
			desc.ControlPan = true;
			desc.GlobalFocus = true;
			desc.BufferBytes = 262144;
			desc.ControlPositionNotify = true;
			desc.CanGetCurrentPosition = true;
			desc.ControlVolume = true;
			desc.StickyFocus = true;
			desc.LocateInSoftware = true;
			desc.ControlEffects = false;
			desc.LocateInHardware = false;
			desc.Control3D = false;
			//MemoryStream bufferstream = new MemoryStream(262144);

			Device device = new Device();
			device.SetCooperativeLevel(Parent,CooperativeLevel.Priority);

			sound = new SecondaryBuffer(desc, device);
			sound.SetCurrentPosition(1);
			sound.Volume = 0;
			sound.Pan = 0;
			
			BufferNotificationEvent = new AutoResetEvent(false);
			BufferNotify = new Notify(sound);

			BufferPositionNotify[] BufferPositions = new BufferPositionNotify[2];

			BufferPositions[0].Offset = 0;
			BufferPositions[0].EventNotifyHandle = BufferNotificationEvent.Handle;
			BufferPositions[1].Offset = (desc.BufferBytes / 2);
			BufferPositions[1].EventNotifyHandle = BufferNotificationEvent.Handle;


			BufferNotify.SetNotificationPositions(BufferPositions);

			DataTransferThread = new Thread(new ThreadStart(WMDataFill));
			//if (GetSourceExt(filename) =="mp4") DataTransferThread = new Thread(new ThreadStart(FaadDataFill));
			//if (GetSourceExt(filename) =="flac") DataTransferThread = new Thread(new ThreadStart(FlacDataFill));
			//if (GetSourceExt(filename) =="ogg") DataTransferThread = new Thread(new ThreadStart(OggDataFill));
			DataTransferThread.Name = "BufferFill";
			DataTransferThread.Priority = ThreadPriority.Highest;
			DataTransferThread.Start();


		}
		private void WMDataFill () {
			//int bufferwriteoffset = 0;
			using (WmaStream str = new WmaStream(file)) {
				
				byte[] buffer = new byte[131072];

				int firstread = str.Read(buffer, 0, buffer.Length);
				sound.Write(0, buffer, LockFlag.None);
				//firstread = str.Read(buffer, 0, buffer.Length);
				//sound.Write(131072, buffer, LockFlag.None);

				try {
					int count = 0;
					int read;
					while ((read = str.Read(buffer, 0, buffer.Length)) > 0) {
						BufferNotificationEvent.WaitOne();
						if (sound.PlayPosition < 131071) {
							sound.Write(131072, buffer, LockFlag.None);

						}
						else { 
							sound.Write(0, buffer, LockFlag.None);

						}
						count++;
					    
					}
				
				}
				finally {
					str.Close();
					str.Dispose();
				}

				BufferNotificationEvent.WaitOne();
				End();


			}
		}
		

		private string GetSourceExt (string filename) {
			string[] mp3types = { ".mp3", ".wma" };
			
			if (mp3types.Contains(Path.GetExtension(filename).ToLower())) return "mp3";
			
			return null;


		}
		public void play () {
			if (sound == null) return;
			sound.Play(0, BufferPlayFlags.Looping);
			Parent.PlayerUpdate = 1;

		}
		public void Pause () {
			if (sound == null) return;
			sound.Stop();
			Parent.PlayerUpdate = 2;
		}
		public void Stop () {
			if (sound == null||sound.Disposed) return;
			
			sound.Stop();
			sound.Dispose();
			DataTransferThread.Abort();
			Parent.PlayerUpdate = 0;
		}
		public void End () {
			if (sound == null) return;
			sound.Stop();
			sound.Dispose();
			
			DataTransferThread.Abort();
			
		}



	}
}
