/*****************************************************************
|
|    AP4 - hdlr Atoms 
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

#ifndef _AP4_HDLR_ATOM_H_
#define _AP4_HDLR_ATOM_H_

/*----------------------------------------------------------------------
|   includes
+---------------------------------------------------------------------*/
#include "Ap4Atom.h"
#include "Ap4String.h"

/*----------------------------------------------------------------------
|   class references
+---------------------------------------------------------------------*/
class AP4_ByteStream;

/*----------------------------------------------------------------------
|   constants
+---------------------------------------------------------------------*/
const AP4_UI32 AP4_HANDLER_TYPE_SOUN = AP4_ATOM_TYPE('s','o','u','n');
const AP4_UI32 AP4_HANDLER_TYPE_VIDE = AP4_ATOM_TYPE('v','i','d','e');
const AP4_UI32 AP4_HANDLER_TYPE_HINT = AP4_ATOM_TYPE('h','i','n','t');
const AP4_UI32 AP4_HANDLER_TYPE_MDIR = AP4_ATOM_TYPE('m','d','i','r');
const AP4_UI32 AP4_HANDLER_TYPE_TEXT = AP4_ATOM_TYPE('t','e','x','t');
const AP4_UI32 AP4_HANDLER_TYPE_TX3G = AP4_ATOM_TYPE('t','x','3','g');
const AP4_UI32 AP4_HANDLER_TYPE_JPEG = AP4_ATOM_TYPE('j','p','e','g');
const AP4_UI32 AP4_HANDLER_TYPE_ODSM = AP4_ATOM_TYPE('o','d','s','m');
const AP4_UI32 AP4_HANDLER_TYPE_SDSM = AP4_ATOM_TYPE('s','d','s','m');
const AP4_UI32 AP4_HANDLER_TYPE_ALIS = AP4_ATOM_TYPE('a','l','i','s');
const AP4_UI32 AP4_HANDLER_TYPE_QTCHAP = AP4_ATOM_TYPE('q','q','q','t');
const AP4_UI32 AP4_HANDLER_CLASS_DHLR = AP4_ATOM_TYPE('d','h','l','r');
const AP4_UI32 AP4_HANDLER_CLASS_MHLR = AP4_ATOM_TYPE('m','h','l','r');
const AP4_UI32 AP4_HANDLER_VENDOR_ID_APPL = AP4_ATOM_TYPE('a','p','p','l');
const AP4_UI32 AP4_HANDLER_VENDOR_ID_APP2 = AP4_ATOM_TYPE('a','p','p','2');

/*----------------------------------------------------------------------
|   AP4_HdlrAtom
+---------------------------------------------------------------------*/
class AP4_HdlrAtom : public AP4_Atom
{
public:
    // class methods
    static AP4_HdlrAtom* Create(AP4_Size size, AP4_ByteStream& stream);

    // methods
    AP4_HdlrAtom(AP4_UI32 hdlr_type, const char* hdlr_name);
	AP4_HdlrAtom(AP4_UI32 hdlr_type, const char* hdlr_name, AP4_UI32 hdlr_class, AP4_UI32 hdlr_vendor);
    virtual AP4_Result InspectFields(AP4_AtomInspector& inspector);
    virtual AP4_Result WriteFields(AP4_ByteStream& stream);

    AP4_UI32   GetHandlerType() { return m_HandlerType; }
    AP4_String GetHandlerName() { return m_HandlerName; }
	AP4_UI32   GetHandlerClass() { return m_HandlerClass; }
	AP4_UI32   GetVendorID() { return m_VendorID; }

private:
    // methods
    AP4_HdlrAtom(AP4_UI32        size, 
                 AP4_UI32        version,
                 AP4_UI32        flags,
                 AP4_ByteStream& stream);

    // members
	AP4_UI32   m_HandlerClass;
	AP4_UI32   m_HandlerType;
    AP4_UI32   m_VendorID;
	AP4_UI32   m_ComponentFlags;
	AP4_UI32   m_ComponentFlagsMask;
    AP4_String m_HandlerName;
};

#endif // _AP4_HDLR_ATOM_H_
