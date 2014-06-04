#pragma once
#include "Ap4Types.h"
#include "Ap4BitStream.h"
#include "Ap4DataBuffer.h"

extern const unsigned long AP4_AdtsSamplingFrequencyTable[16];
class AACParser
{
public:
	AACParser(AP4_UI08* aacframe);
	~AACParser();

	

	unsigned int m_SampleRate;
	unsigned int m_ChannelCount;
	unsigned int m_AACObjectType;
	unsigned int m_SampleFreqIndex;
	unsigned int m_FrameSize;
	AP4_DataBuffer m_DecoderSpecificInfo;
	AP4_BitStream* m_FrameData;
};


