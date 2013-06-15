﻿//=================================================================================================
// Copyright 2013 Dirk Lemstra <http://magick.codeplex.com/>
//
// Licensed under the ImageMagick License (the "License"); you may not use this file except in 
// compliance with the License. You may obtain a copy of the License at
//
//   http://www.imagemagick.org/script/license.php
//
// Unless required by applicable law or agreed to in writing, software distributed under the
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either
// express or implied. See the License for the specific language governing permissions and
// limitations under the License.
//=================================================================================================
using System.CodeDom.Compiler;
using System.Linq;
using System.Reflection;

namespace Magick.NET.FileGenerator
{
	//==============================================================================================
	internal abstract class ConstructorCodeGenerator : CodeGenerator
	{
		//===========================================================================================
		private ConstructorInfo[] _Constructors;
		//===========================================================================================
		private ConstructorInfo[] Constructors
		{
			get
			{
				if (_Constructors == null)
					_Constructors = MagickNET.GetConstructors(ClassName).ToArray();

				return _Constructors;
			}
		}
		//===========================================================================================
		private string TypeName
		{
			get
			{
				return MagickNET.GetTypeName(Constructors[0]);
			}
		}
		//===========================================================================================
		protected abstract string ClassName
		{
			get;
		}
		//===========================================================================================
		protected virtual bool WriteEnumerable
		{
			get
			{
				return true;
			}
		}
		//===========================================================================================
		public void WriteCode(IndentedTextWriter writer)
		{
			writer.Write(TypeName);
			writer.Write(" MagickScript::Create");
			writer.Write(ClassName);
			writer.WriteLine("(XmlElement^ element)");
			writer.WriteLine("{");
			writer.Indent++;
			WriteMethod(writer, Constructors);
			writer.Indent--;
			writer.WriteLine("}");

			if (!WriteEnumerable)
				return;

			writer.Write("Collection<");
			writer.Write(TypeName);
			writer.Write(">^  MagickScript::Create");
			writer.Write(ClassName);
			writer.WriteLine("s(XmlElement^ element)");
			writer.WriteLine("{");
			writer.Indent++;
			writer.Write("Collection<");
			writer.Write(TypeName);
			writer.Write(">^ collection = gcnew Collection<");
			writer.Write(TypeName);
			writer.WriteLine(">();");
			writer.WriteLine("for each (XmlElement^ elem in element->SelectNodes(\"*\"))");
			writer.WriteLine("{");
			writer.Indent++;
			writer.Write("collection->Add(Create");
			writer.Write(TypeName.Replace("^", ""));
			writer.WriteLine("(elem));");
			writer.Indent--;
			writer.WriteLine("}");
			writer.WriteLine("return collection;");
			writer.Indent--;
			writer.WriteLine("}");
		}
		//===========================================================================================
		public void WriteHeader(IndentedTextWriter writer)
		{
			writer.Write("static ");
			writer.Write(TypeName);
			writer.Write(" Create");
			writer.Write(ClassName);
			writer.WriteLine("(XmlElement^ element);");

			if (!WriteEnumerable)
				return;

			writer.Write("static Collection<");
			writer.Write(TypeName);
			writer.Write(">^ Create");
			writer.Write(ClassName);
			writer.WriteLine("s(XmlElement^ element);");
		}
		//===========================================================================================
		public virtual void WriteIncludes(IndentedTextWriter writer)
		{
		}
		//===========================================================================================
	}
	//==============================================================================================
}