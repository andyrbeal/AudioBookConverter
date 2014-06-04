#include "StdAfx.h"
#include "AACParser.h"


#define ADTS_HEADER_SIZE 7

#define ADTS_SYNC_MASK     0xFFF6 /* 12 sync bits plus 2 layer bits */
#define ADTS_SYNC_PATTERN  0xFFF0 /* 12 sync bits=1 layer=0         */

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

AACParser::AACParser(AP4_UI08* aacframe)
{

	m_SampleFreqIndex = ( aacframe[2] & 0x3C) >> 2;
	m_ChannelCount = ((aacframe[2] & 0x01) << 2) | ((aacframe[3] & 0xC0) >> 6);
	m_SampleRate = AdtsSamplingFrequencyTable[m_SampleFreqIndex];
	m_AACObjectType  = ( aacframe[2] & 0xC0) >> 6;
	
	m_FrameSize = ((unsigned int)(aacframe[3] & 0x03) << 11) |
                    ((unsigned int)(aacframe[4]       ) <<  3) |
                    ((unsigned int)(aacframe[5] & 0xE0) >>  5);
	m_FrameSize -= 7;

	
aacframe += 7;
m_FrameData = new AP4_BitStream();
m_FrameData->WriteBytes(aacframe ,m_FrameSize);

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
				m_DecoderSpecificInfo.SetData(decinfo,2);

}
AACParser::~AACParser() {
delete m_FrameData;


}

