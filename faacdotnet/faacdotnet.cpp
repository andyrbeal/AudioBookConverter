// This is the main DLL file.

#include "stdafx.h"

#include "faacdotnet.h"
namespace faacdotnet {

	public ref class faac
	{
	private:

		faacEncStruct* encoder;
		faacEncConfiguration* configuration;
		unsigned long* inputsamples;
		unsigned long* maxoutputBytes;

	public: 
		faac (unsigned long sampleRate, unsigned int numChannels){
			/*faacapi = new FAACAPI();*/
			/*decoder = new faacEncHandle();*/
			inputsamples = new unsigned long();
			maxoutputBytes = new unsigned long();
			encoder = new faacEncStruct();
			encoder = faacEncOpen(sampleRate, numChannels, inputsamples, maxoutputBytes);
			configuration = new faacEncConfiguration();
			configuration = faacEncGetCurrentConfiguration(encoder);
			configuration->aacObjectType = 2;
		//	configuration->allowMidside =0;
			configuration->useLfe = 0;
			configuration->outputFormat =1;
			configuration->mpegVersion = 4;
			faacEncSetConfiguration(encoder,configuration);
		}

		~faac(void){
		//delete encoder;
		//delete configuration;
		}


		property long InputSamples{
			long get(){return (long)*inputsamples;}
		}
		property long MaxBytes{
			long get(){return (long)*maxoutputBytes;}
		}

		property int BandWidth {
			int get() {
				return (int)configuration->bandWidth;
			}
			void set(int bandwidth){
				configuration = faacEncGetCurrentConfiguration(encoder);
				configuration->bandWidth = (unsigned int)bandwidth;
				faacEncSetConfiguration(encoder,configuration);
			}
		}
		property long BitRate {
			long get() {
				return (long)configuration->bitRate;
			}
			void set(long brate){
				configuration = faacEncGetCurrentConfiguration(encoder);
				configuration->bitRate = (unsigned long)brate;
				faacEncSetConfiguration(encoder,configuration);
			}
		}
		property int InputFormat {
			int get() {
				return (int)configuration->inputFormat;
			}
			void set(int inputformat) {
				configuration = faacEncGetCurrentConfiguration(encoder);
				configuration->inputFormat = (unsigned int)inputformat;
				faacEncSetConfiguration(encoder,configuration);
			}
		}
		property int UseTNS {
			int get() {
				return (int)configuration->useTns;
			}
			void set(int usetns) {
				configuration = faacEncGetCurrentConfiguration(encoder);
				configuration->useTns = (unsigned int)usetns;
				faacEncSetConfiguration(encoder,configuration);
			}
		}
		property int UseLFE {
			int get() {
				return (int)configuration->useLfe;
			}
			void set(int uselfe) {
				configuration = faacEncGetCurrentConfiguration(encoder);
				configuration->useLfe = (unsigned int)uselfe;
				faacEncSetConfiguration(encoder,configuration);
			}
		}
		property int QuantQual {
			int get() {
				return (int)configuration->quantqual;
			}
			void set(int quantqual) {
				configuration = faacEncGetCurrentConfiguration(encoder);
				configuration->quantqual = (unsigned int)quantqual;
				faacEncSetConfiguration(encoder,configuration);
			}
		}
		property array<System::Byte>^ DecoderSpecInfo {
		
			array<Byte>^ get(){
			array<System::Byte>^ decinfo= gcnew array<System::Byte>(2);
		
			unsigned short info = (encoder->config.aacObjectType & 31);
				info = info << 4;
				info = info | (encoder->sampleRateIdx & 15);
				info = info << 4;
				info = info | (encoder->numChannels & 15);
				info = info << 3;

				decinfo[0] = (info >> 8) & 255;
				decinfo[1] = (info & 255);

			return decinfo;
			}
		}

		int Encode([In] array<short>^ inputbuffer, int samplesinput,[Out] array<System::Byte>^% outputbuffer, [Out] unsigned int% buffersize){
			int result = 0;
			
			outputbuffer = gcnew array<Byte>(*maxoutputBytes);

			pin_ptr<short> pinput=&inputbuffer[0];
			//int32_t * inbuf = pinput; 
			pin_ptr<System::Byte> poutput = &outputbuffer[0];
			unsigned char * outbuf = poutput;
			unsigned int bufsize = (unsigned int)(*maxoutputBytes);
			//unsigned int outputbufferptr = *outputbuffer;
			result = faacEncEncode(encoder, (int32_t *)pinput, samplesinput, outbuf, bufsize);
			buffersize = bufsize;

			return result;

		}
		int Encode([In] array<int>^ inputbuffer, int samplesinput,[Out] array<System::Byte>^% outputbuffer, [Out] unsigned int% buffersize){
			int result = 0;
			
			outputbuffer = gcnew array<Byte>(*maxoutputBytes);

			pin_ptr<int> pinput=&inputbuffer[0];
			//int32_t * inbuf = pinput; 
			pin_ptr<System::Byte> poutput = &outputbuffer[0];
			unsigned char * outbuf = poutput;
			unsigned int bufsize = (unsigned int)(*maxoutputBytes);
			//unsigned int outputbufferptr = *outputbuffer;
			result = faacEncEncode(encoder, (int32_t *)pinput, samplesinput, outbuf, bufsize);
			buffersize = bufsize;

			return result;

		}

		void Close (){
			faacEncClose(encoder);
		}


	};

}

