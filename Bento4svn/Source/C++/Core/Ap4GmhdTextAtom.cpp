/*****************************************************************
|
|    AP4 - text (gmhd) Atoms 
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
#include "Ap4GmhdTextAtom.h"
#include "Ap4AtomFactory.h"
#include "Ap4Utils.h"
#include "Ap4Types.h"

/*----------------------------------------------------------------------
|   AP4_GmhdTextAtom::Create
+---------------------------------------------------------------------*/
AP4_GmhdTextAtom*
AP4_GmhdTextAtom::Create(AP4_Size size, AP4_ByteStream& stream)
{
    return new AP4_GmhdTextAtom(size, stream);
}

/*----------------------------------------------------------------------
|   AP4_GmhdTextAtom::AP4_GmhdTextAtom
+---------------------------------------------------------------------*/
AP4_GmhdTextAtom::AP4_GmhdTextAtom() :
    AP4_Atom(AP4_ATOM_TYPE_TEXT, AP4_ATOM_HEADER_SIZE+36)
    
{     
	m_TextData[0] = 0x00010000;
	m_TextData[1] = 0x00000000;
	m_TextData[2] = 0x00000000;
	m_TextData[3] = 0x00000000;
	m_TextData[4] = 0x00010000;
	m_TextData[5] = 0x00000000;
	m_TextData[6] = 0x00000000;
	m_TextData[7] = 0x00000000;
	m_TextData[8] = 0x40000000;
 

}

/*----------------------------------------------------------------------
|   AP4_GmhdTextAtom::AP4_GmhdTextAtom
+---------------------------------------------------------------------*/
AP4_GmhdTextAtom::AP4_GmhdTextAtom(AP4_UI32        size, AP4_ByteStream& stream) :
    AP4_Atom(AP4_ATOM_TYPE_TEXT, size)
{
	
	for (int x=0;x<9;x++){
    stream.ReadUI32(m_TextData[x]);
	}

}

/*----------------------------------------------------------------------
|   AP4_GmhdTextAtom::WriteFields
+---------------------------------------------------------------------*/
AP4_Result
AP4_GmhdTextAtom::WriteFields(AP4_ByteStream& stream)
{
    AP4_Result result;

	result = stream.Write(m_TextData, sizeof(m_TextData));
    if (AP4_FAILED(result)) return result;


    return AP4_SUCCESS;
}

/*----------------------------------------------------------------------
|   AP4_GmhdTextAtom::InspectFields
+---------------------------------------------------------------------*/
AP4_Result
AP4_GmhdTextAtom::InspectFields(AP4_AtomInspector& inspector)
{
    char formatted[9];
    AP4_FormatString(formatted, sizeof(formatted), "%08x,%08x,%08x,%08x,%08x,%08x,%08x,%08x,%08x",
													m_TextData[0], m_TextData[1], m_TextData[2],
													m_TextData[3], m_TextData[4], m_TextData[5],
													m_TextData[6], m_TextData[7], m_TextData[8]);
    inspector.AddField("text_data", formatted);


    return AP4_SUCCESS;
}
