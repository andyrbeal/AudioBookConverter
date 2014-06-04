// This is the main DLL file.

#include "stdafx.h"
#include "Bento-Sharp.h"
#include <vcclr.h>
#include <string.h>

namespace BentoSharp {
	const unsigned long  
AdtsSamplingFrequencyTable[16] =
{
    96000,
    88200,
    64000,
    48000,
    44100,
    32000,
    24000,
    22050,
    16000,
    12000,
    11025,
    8000,
    7350,
    0,      /* Reserved */
    0,      /* Reserved */
    0       /* Escape code */
};
	public ref class Bento4Writer
	{
	public:

	Bento4Writer (String^ outfile, String^ tempfile) {

		IntPtr outfileansiPtr = Marshal::StringToHGlobalAnsi(outfile);
		const char* poutfile = static_cast<char*>(outfileansiPtr.ToPointer());
		m_OutFile = new AP4_FileByteStream(poutfile, AP4_FileByteStream::STREAM_MODE_WRITE);
		

		IntPtr tempfileansiPtr = Marshal::StringToHGlobalAnsi(tempfile);
		const char* ptempfile = static_cast<char*>(tempfileansiPtr.ToPointer());
		m_SampleFile = new AP4_FileByteStream(ptempfile, AP4_FileByteStream::STREAM_MODE_READ_WRITE);
		//AP4_FileByteStream::Create(ptempfile, AP4_FileByteStream::STREAM_MODE_READ_WRITE, m_SampleFile);

		m_Movie =  new AP4_Movie(600);
		sample_table = new AP4_SyntheticSampleTable();

		}

	void Write (array<System::Byte>^ aacframe, int frames) {



		pin_ptr <System::Byte> pinaacdata = &aacframe[0];
		int current_frame =1;
		int frame_offset =0;
		while (current_frame <= frames) {
		unsigned int frame_length = ((unsigned int)(pinaacdata[frame_offset + 3] & 0x03) << 11) |
                    ((unsigned int)(pinaacdata[frame_offset + 4]       ) <<  3) |
                    ((unsigned int)(pinaacdata[frame_offset + 5] & 0xE0) >>  5);

		pin_ptr <System::Byte> pinframe = &aacframe[frame_offset];

		if (!m_Track1Initialized) {
			m_Track1Initialized = true;
		
		m_SampleFreqIndex = ( pinframe[2] & 0x3C) >> 2;
		m_ChannelCount = ((pinframe[2] & 0x01) << 2) | ((pinframe[3] & 0xC0) >> 6);
		m_SampleRate = AdtsSamplingFrequencyTable[m_SampleFreqIndex];
		m_AACObjectType  = ( pinframe[2] & 0xC0) >> 6;
	
		m_AACObjectType = 2;
		unsigned short info = (m_AACObjectType & 0x1F);
				info = info << 4;
				info = info | (m_SampleFreqIndex & 0x0F);
				info = info << 4;
				info = info | (m_ChannelCount & 0x0F);
				info = info << 3;
		unsigned char* decinfo = new unsigned char[2];
				decinfo[0] = (info >> 8) & 0xFF;
				decinfo[1] = (info & 0xFF);
				m_DecoderSpecificInfo = new AP4_DataBuffer(2);
				m_DecoderSpecificInfo->SetData(decinfo,2);

			AP4_MpegAudioSampleDescription* sample_description = 
                    new AP4_MpegAudioSampleDescription(
                    AP4_OTI_MPEG4_AUDIO,   // object type
                    m_SampleRate,
                    16,                    // sample size
                    m_ChannelCount,
                    m_DecoderSpecificInfo,                  // decoder info
                    6144,                  // buffer size
                    128000,                // max bitrate
                    128000);               // average bitrate
                m_Track1_sample_description_index = sample_table->AddSampleDescription(sample_description);
		}
    
		pinframe +=7;
		m_SampleFile->Write(pinframe,frame_length-7);

		//AP4_Position filepos;
		//m_SampleFile->Tell(filepos);

	
		AP4_UI64 dts = m_SampleCount*1024;
			//dts += frame.m_Info.m_FrameLength;
           sample_table->AddSample(*m_SampleFile, m_Offset, frame_length-7, m_Track1_sample_description_index, dts, dts, true);

            m_SampleCount++;
			m_Offset +=(frame_length-7);
			//delete aac_frame;
		
			frame_offset += frame_length;
			current_frame++;
		}
	}
	
	void WriteChapters(array<String^>^ chapter_titles, array<UInt64>^ chapter_times, unsigned int total_chapters){
    
	
	//Initialize chapter sample table and description
	m_Track2Initialized = true;
	chapter_table = new AP4_SyntheticSampleTable();
	AP4_TextSampleDescription* chaptersample_description = 
                    new AP4_TextSampleDescription(
					4,7,65535,65535,65535,0,0,0,0,0,0,0,0,0);
	unsigned int chapdescindex = chapter_table->AddSampleDescription(chaptersample_description);
	
	int chapoffset = 0;

	for (unsigned int x=0;x < total_chapters;x++){
		int datsize = chapter_titles[x]->Length;

		IntPtr titlePtr = Marshal::StringToHGlobalAnsi(chapter_titles[x]);
		const char* ptitle = static_cast<char*>(titlePtr.ToPointer());


		AP4_ByteStream* datastream = new AP4_MemoryByteStream(datsize+2);
		datastream->WriteUI16(datsize);
		datastream->WriteString(ptitle);
		datsize += 2;
		AP4_UI32 moovscale = m_Movie->GetTimeScale();
		AP4_UI64 dtime = (chapter_times[x]*moovscale)/1000;

		chapter_table->AddSample(*datastream,0,datsize,chapdescindex,dtime,dtime,false);
		
		
	}//end chapter loop


	
	}
	
	void AssignChapterReference(unsigned int chaptertrack, unsigned int datatrack){
	
		//always assigned datatrack =1   fix later
	AP4_TrakAtom* trackatom = m_Track1->GetTrakAtom();
	AP4_ContainerAtom* trefcontainer = new AP4_ContainerAtom(AP4_ATOM_TYPE_TREF);
	AP4_TrefTypeAtom* chapatom = new AP4_TrefTypeAtom(AP4_ATOM_TYPE_CHAP);
	chapatom->AddTrackId(chaptertrack);

	trefcontainer->AddChild(chapatom);
	trackatom->AddChild(trefcontainer,1);
	
	
	}

	void Save (){
	m_Track1 = new AP4_Track(AP4_Track::TYPE_AUDIO, 
                                     sample_table, 
                                     1,     // track id
                                     600,       // movie time scale
                                     m_SampleCount*1024*(600/(double)m_SampleRate), // track duration              
                                     m_SampleRate,       // media time scale
                                     m_SampleCount*1024, // media duration
                                     "eng", // language
                                     0, 0); // width, height
    // add the track to the movie
    m_Movie->AddTrack(m_Track1);
	// if we have a track2 init'd add it also.
	if (m_Track2Initialized) { 
	m_Track2 = new AP4_Track(AP4_Track::TYPE_QTCHAP, 
                                     chapter_table, 
                                     2,     // track id
                                     m_Track1->GetMovieTimeScale(),       // movie time scale
                                     m_Track1->GetDuration(), // track duration              
                                     m_Track1->GetMovieTimeScale(),       // media time scale
                                     m_Track1->GetDuration(), // media duration
                                     "eng", // language
                                     0, 0); // width, height
	 m_Movie->AddTrack(m_Track2);

	 AssignChapterReference(2,1);
	}
   // create a multimedia file
    AP4_File* file = new AP4_File(m_Movie);

    // set the file type
    AP4_UI32 compatible_brands[2] = {
        AP4_FILE_BRAND_MP42,
        AP4_FILE_BRAND_MP41
    };
    file->SetFileType(AP4_FILE_BRAND_MP42, 1, compatible_brands, 2);

    // create a writer to write the file
    AP4_FileWriter::Write(*file, *m_OutFile);
    delete file;
    delete m_OutFile;

	}
	~Bento4Writer(void){
	//delete m_OutFile;
	delete m_SampleFile;
	//delete m_Movie;
	//delete sample_table;
	//delete chapter_table;
	//delete m_Track1;
	//delete m_Track2;

	}

	private:
	AP4_ByteStream* m_OutFile;
	AP4_ByteStream* m_SampleFile;
	AP4_Movie* m_Movie;
	AP4_SyntheticSampleTable* sample_table;
	AP4_SyntheticSampleTable* chapter_table;
	AP4_Track* m_Track1;
	AP4_Track* m_Track2;
	AP4_UI64 m_Offset;
	AP4_UI64 m_SampleCount;
	AP4_UI32 m_SampleRate;
	unsigned int m_ChannelCount;
	unsigned int m_AACObjectType;
	unsigned int m_SampleFreqIndex;
	AP4_DataBuffer* m_DecoderSpecificInfo;
	unsigned int m_Track1_sample_description_index;
	bool m_Track1Initialized;
	bool m_Track2Initialized;
	};




	
}