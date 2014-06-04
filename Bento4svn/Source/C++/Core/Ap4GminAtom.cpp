/*****************************************************************
|
|    AP4 - gmin Atoms 
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
#include "Ap4GminAtom.h"
#include "Ap4AtomFactory.h"
#include "Ap4Utils.h"
#include "Ap4Types.h"

/*----------------------------------------------------------------------
|   AP4_GminAtom::Create
+---------------------------------------------------------------------*/
AP4_GminAtom*
AP4_GminAtom::Create(AP4_Size size, AP4_ByteStream& stream)
{
    AP4_UI32 version;
    AP4_UI32 flags;
    if (AP4_FAILED(AP4_Atom::ReadFullHeader(stream, version, flags))) return NULL;
    if (version != 0) return NULL;
    return new AP4_GminAtom(size, version, flags, stream);
}

/*----------------------------------------------------------------------
|   AP4_GminAtom::AP4_GminAtom
+---------------------------------------------------------------------*/
AP4_GminAtom::AP4_GminAtom(AP4_UI16 graphics_mode, AP4_UI16 red, AP4_UI16 green, AP4_UI16 blue, AP4_UI16 balance) :
    AP4_Atom(AP4_ATOM_TYPE_GMIN, AP4_FULL_ATOM_HEADER_SIZE+12, 0, 0),
    m_GraphicsMode(graphics_mode)
{     
    m_OpColorRed = red;
    m_OpColorGreen = green;
    m_OpColorBlue = blue;
    m_Balance = balance;
    m_Reserved = 0;
}

/*----------------------------------------------------------------------
|   AP4_GminAtom::AP4_GminAtom
+---------------------------------------------------------------------*/
AP4_GminAtom::AP4_GminAtom(AP4_UI32        size, 
                           AP4_UI32        version,
                           AP4_UI32        flags,
                           AP4_ByteStream& stream) :
    AP4_Atom(AP4_ATOM_TYPE_GMIN, size, version, flags)
{
    stream.ReadUI16(m_GraphicsMode);
    stream.ReadUI16(m_OpColorRed);
    stream.ReadUI16(m_OpColorGreen);
    stream.ReadUI16(m_OpColorBlue);
    stream.ReadUI16(m_Balance);
    stream.ReadUI16(m_Reserved);

}

/*----------------------------------------------------------------------
|   AP4_GminAtom::WriteFields
+---------------------------------------------------------------------*/
AP4_Result
AP4_GminAtom::WriteFields(AP4_ByteStream& stream)
{
    AP4_Result result;

    // graphics mode
    result = stream.WriteUI16(m_GraphicsMode);
    if (AP4_FAILED(result)) return result;

    // op color red
    result = stream.WriteUI16(m_OpColorRed);
    if (AP4_FAILED(result)) return result;

    // op color Green
    result = stream.WriteUI16(m_OpColorGreen);
    if (AP4_FAILED(result)) return result;

    // op color blue
    result = stream.WriteUI16(m_OpColorBlue);
    if (AP4_FAILED(result)) return result;

    // color balance
    result = stream.WriteUI16(m_Balance);
    if (AP4_FAILED(result)) return result;

    //Reserved bytes
    result = stream.WriteUI16(m_Reserved);
    if (AP4_FAILED(result)) return result;

    return AP4_SUCCESS;
}

/*----------------------------------------------------------------------
|   AP4_GminAtom::InspectFields
+---------------------------------------------------------------------*/
AP4_Result
AP4_GminAtom::InspectFields(AP4_AtomInspector& inspector)
{
    inspector.AddField("graphics_mode", m_GraphicsMode);
    inspector.AddField("op_color_red", m_OpColorRed);
    inspector.AddField("op_color_green", m_OpColorGreen);
    inspector.AddField("op_color_blue", m_OpColorBlue);
    inspector.AddField("color_balance", m_Balance);


    return AP4_SUCCESS;
}
