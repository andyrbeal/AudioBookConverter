/*****************************************************************
|
|    AP4 - Synthetic Sample Table2
|
|    Copyright 2002-2008 Axiomatic Systems, LLC
|
|
|    This file is part of Bento4/AP4 (MP4 Atom Processing Library).
|
|    Unless you have obtained Bento4 under a difference license,
|    this version of Bento4 is Bento4|GPL.
|    Bento4|GPL is free software; you can redistribute it and/or modify
|    it under the terms of the GNU General Public License as published by
|    the Free Software Foundation; either version 2, or (at your option)
|    any later version.
|
|    Bento4|GPL is distributed in the hope that it will be useful,
|    but WITHOUT ANY WARRANTY; without even the implied warranty of
|    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
|    GNU General Public License for more details.
|
|    You should have received a copy of the GNU General Public License
|    along with Bento4|GPL; see the file COPYING.  If not, write to the
|    Free Software Foundation, 59 Temple Place - Suite 330, Boston, MA
|    02111-1307, USA.
|
 ****************************************************************/

/*----------------------------------------------------------------------
|   includes
+---------------------------------------------------------------------*/
#include "Ap4Types.h"
#include "Ap4Atom.h"
#include "Ap4SyntheticSampleTable2.h"
#include "Ap4Sample.h"

/*----------------------------------------------------------------------
|   AP4_SyntheticSampleTable::AP4_SyntheticSampleTable()
+---------------------------------------------------------------------*/
AP4_SyntheticSampleTable2::AP4_SyntheticSampleTable2(AP4_ByteStream* data) :
    m_ChunkSize(AP4_SYNTHETIC_SAMPLE_TABLE2_DEFAULT_CHUNK_SIZE)
{
	m_FileStorage = data;
}

/*----------------------------------------------------------------------
|   AP4_SyntheticSampleTable::~AP4_SyntheticSampleTable()
+---------------------------------------------------------------------*/
AP4_SyntheticSampleTable2::~AP4_SyntheticSampleTable2()
{
    m_SampleDescriptions.DeleteReferences();
}

/*----------------------------------------------------------------------
|   AP4_SyntheticSampleTable::GetSample
+---------------------------------------------------------------------*/
AP4_Result
AP4_SyntheticSampleTable2::GetSample(AP4_Ordinal sample_index, AP4_Sample& sample)
{
    if (sample_index >= m_Samples.ItemCount()) return AP4_ERROR_OUT_OF_RANGE;
	
    sample = m_Samples[sample_index];
	AP4_Size sample_size = sample.GetSize();
	AP4_Position sample_position = sample.GetOffset();
	AP4_Ordinal sample_desc_index = sample.GetDescriptionIndex();
	AP4_UI64 sample_dts = sample.GetDts();
	AP4_UI32 sample_cts = sample.GetCts();
	bool sample_sync = sample.IsSync();
	

	m_FileStorage->Seek(sample_position);
	
	AP4_DataBuffer* sample_buffer = new AP4_DataBuffer(sample_size);

	//m_FileStorage->Read(sample_buffer,sample_size);
	//AP4_MemoryByteStream* sample_data = new AP4_MemoryByteStream(sample_size);
	m_FileStorage->Read(sample_buffer,sample_size);
	AP4_Sample realsample(true,sample_buffer,sample_position,sample_size,sample_desc_index,sample_dts,sample_cts,sample_sync);

	sample = realsample;
    return AP4_SUCCESS;
}

/*----------------------------------------------------------------------
|   AP4_SyntheticSampleTable::GetSampleCount
+---------------------------------------------------------------------*/
AP4_Cardinal 
AP4_SyntheticSampleTable2::GetSampleCount()
{
    return m_Samples.ItemCount();
}

/*----------------------------------------------------------------------
|   AP4_SyntheticSampleTable::GetSampleChunkPosition
+---------------------------------------------------------------------*/
AP4_Result   
AP4_SyntheticSampleTable2::GetSampleChunkPosition(
    AP4_Ordinal  sample_index, 
    AP4_Ordinal& chunk_index,
    AP4_Ordinal& position_in_chunk)
{
    // default values
    chunk_index       = 0;
    position_in_chunk = 0;
    
    // check parameters
    if (sample_index >= m_Samples.ItemCount()) return AP4_ERROR_OUT_OF_RANGE;
    if (m_ChunkSize == 0) return AP4_ERROR_INVALID_STATE;
    
    // compute in which chunk this sample falls
    chunk_index       = sample_index/m_ChunkSize;
    position_in_chunk = sample_index%m_ChunkSize;
    
    return AP4_SUCCESS;
}

/*----------------------------------------------------------------------
|   AP4_SyntheticSampleTable::GetSampleDescriptionCount
+---------------------------------------------------------------------*/
AP4_Cardinal 
AP4_SyntheticSampleTable2::GetSampleDescriptionCount()
{
    return m_SampleDescriptions.ItemCount();
}

/*----------------------------------------------------------------------
|   AP4_SyntheticSampleTable::GetSampleDescription
+---------------------------------------------------------------------*/
AP4_SampleDescription* 
AP4_SyntheticSampleTable2::GetSampleDescription(AP4_Ordinal index)
{
    SampleDescriptionHolder* holder;
    if (AP4_SUCCEEDED(m_SampleDescriptions.Get(index, holder))) {
        return holder->m_SampleDescription;
    } else {
        return NULL;
    }
}

/*----------------------------------------------------------------------
|   AP4_SyntheticSampleTable::AddSampleDescription
+---------------------------------------------------------------------*/
AP4_Result 
AP4_SyntheticSampleTable2::AddSampleDescription(AP4_SampleDescription* description,
                                               bool                   transfer_ownership)
{
    return m_SampleDescriptions.Add(new SampleDescriptionHolder(description, transfer_ownership));
}

/*----------------------------------------------------------------------
|   AP4_SyntheticSampleTable::AddSample
+---------------------------------------------------------------------*/
AP4_Result 
AP4_SyntheticSampleTable2::AddSample(AP4_ByteStream& data_stream,
                                    AP4_Position    offset,
                                    AP4_Size        size,
                                    AP4_Ordinal     description_index,
                                    AP4_UI64        cts,
                                    AP4_UI64        dts,
                                    bool            sync)
{
	AP4_DataBuffer* empty_sample_buffer = new AP4_DataBuffer();
	AP4_LargeSize file_storage_size;
	m_FileStorage->GetSize(file_storage_size);
	m_FileStorage->Seek(file_storage_size);
	m_FileStorage->
		Write(data_stream,size);

    AP4_Sample sample(true, empty_sample_buffer, offset, size, description_index, dts, (AP4_UI32)(cts-dts), sync);
    return m_Samples.Append(sample);
}

/*----------------------------------------------------------------------
|   AP4_SyntheticSampleTable::GetSampleIndexForTimeStamp
+---------------------------------------------------------------------*/
AP4_Result 
AP4_SyntheticSampleTable2::GetSampleIndexForTimeStamp(AP4_UI64     /* ts */, 
                                                     AP4_Ordinal& /* index */)
{
    return AP4_ERROR_NOT_SUPPORTED;
}

/*----------------------------------------------------------------------
|   AP4_SyntheticSampleTable::GetNearestSyncSampleIndex
+---------------------------------------------------------------------*/
AP4_Ordinal  
AP4_SyntheticSampleTable2::GetNearestSyncSampleIndex(AP4_Ordinal sample_index, bool before)
{
    if (before) {
        for (int i=sample_index; i>=0; i--) {
            if (m_Samples[i].IsSync()) return i;
        }
        // not found?
        return 0;
    } else {
        AP4_Cardinal entry_count = m_Samples.ItemCount();
        for (unsigned int i=sample_index; i<entry_count; i++) {
            if (m_Samples[i].IsSync()) return i;
        }
        // not found?
        return m_Samples.ItemCount();
    }
}