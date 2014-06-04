#include "stdafx.h"

void aac2mp4(unsigned char infile, unsigned char outfile, array<System::Byte> decoderspec )
{
    AP4_Result result;

       
    // open the input
    AP4_ByteStream* input;
    try {
        input = new AP4_FileByteStream(infile, AP4_FileByteStream::STREAM_MODE_READ);
    } catch (AP4_Exception&) {
        AP4_Debug("ERROR: cannot open input (%s)\n", argv[1]);
        return 1;
    }

    // open the output
    AP4_ByteStream* output = new AP4_FileByteStream(
        outfile,
        AP4_FileByteStream::STREAM_MODE_WRITE);
    
    // create a sample table
    AP4_SyntheticSampleTable* sample_table = new AP4_SyntheticSampleTable();

    // create an ADTS parser
    AP4_AdtsParser parser;
    bool           initialized = false;
    unsigned int   sample_description_index = 0;

    // read from the input, feed, and get AAC frames
    AP4_UI32     sample_rate = 0;
    AP4_Cardinal sample_count = 0;
    bool eos = false;
    for(;;) {
        // try to get a frame
        AP4_AacFrame frame;
        result = parser.FindFrame(frame);
        if (AP4_SUCCEEDED(result)) {
            AP4_Debug("AAC frame [%06d]: size = %d, %d kHz, %d ch\n",
                       sample_count,
                       frame.m_Info.m_FrameLength,
                       frame.m_Info.m_SamplingFrequency,
                       frame.m_Info.m_ChannelConfiguration);
            if (!initialized) {
                initialized = true;

                // create a sample description for our samples
                AP4_DataBuffer dsi;
                unsigned char aac_dsi[2] = decoderspec;
                dsi.SetData(aac_dsi, 2);
                AP4_MpegAudioSampleDescription* sample_description = 
                    new AP4_MpegAudioSampleDescription(
                    AP4_OTI_MPEG4_AUDIO,   // object type
                    frame.m_Info.m_SamplingFrequency,
                    16,                    // sample size
                    frame.m_Info.m_ChannelConfiguration,
                    &dsi,                  // decoder info
                    6144,                  // buffer size
                    128000,                // max bitrate
                    128000);               // average bitrate
                sample_description_index = sample_table->AddSampleDescription(sample_description);
                sample_rate = frame.m_Info.m_SamplingFrequency;
            }

            AP4_MemoryByteStream* sample_data = new AP4_MemoryByteStream(frame.m_Info.m_FrameLength);
            frame.m_Source->ReadBytes(sample_data->UseData(), frame.m_Info.m_FrameLength);
            unsigned int dts = sample_count*1024;
            sample_table->AddSample(*sample_data, 0, frame.m_Info.m_FrameLength, sample_description_index, dts, dts, true);
            sample_data->Release();
            sample_count++;
        } else {
            if (eos) break;
        }

        // read some data and feed the parser
        AP4_UI08 input_buffer[4096];
        AP4_Size bytes_read = 0;
        AP4_Size to_read = parser.GetBytesFree();
        if (to_read) {
            if (to_read > sizeof(input_buffer)) to_read = sizeof(input_buffer);
            result = input->ReadPartial(input_buffer, to_read, bytes_read);
            if (AP4_SUCCEEDED(result)) {
                AP4_Size to_feed = bytes_read;
                result = parser.Feed(input_buffer, &to_feed);
                if (AP4_FAILED(result)) {
                    AP4_Debug("ERROR: parser.Feed() failed (%d)\n", result);
                    return 1;
                }
            } else {
                if (result == AP4_ERROR_EOS) {
                    eos = true;
                }
            }
        }
   }

    // create an audio track
    AP4_Track* track = new AP4_Track(AP4_Track::TYPE_AUDIO, 
                                     sample_table, 
                                     0,     // track id
                                     sample_rate,       // movie time scale
                                     sample_count*1024, // track duration              
                                     sample_rate,       // media time scale
                                     sample_count*1024, // media duration
                                     "eng", // language
                                     0, 0); // width, height

    // create a movie
    AP4_Movie* movie = new AP4_Movie();

    // add the track to the movie
    movie->AddTrack(track);

    // create a multimedia file
    AP4_File* file = new AP4_File(movie);

    // set the file type
    AP4_UI32 compatible_brands[2] = {
        AP4_FILE_BRAND_ISOM,
        AP4_FILE_BRAND_MP42
    };
    file->SetFileType(AP4_FILE_BRAND_M4A_, 0, compatible_brands, 2);

    // create a writer to write the file
    AP4_FileWriter* writer = new AP4_FileWriter(*file);

    // write the file to the output
    writer->Write(*output);

    delete writer;
    delete file;
    delete output;
    
   // return 0;
}