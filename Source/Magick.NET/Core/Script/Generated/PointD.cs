//=================================================================================================
// Copyright 2013-2016 Dirk Lemstra <https://magick.codeplex.com/>
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
// <auto-generated/>

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml;

#if Q8
using QuantumType = System.Byte;
#elif Q16
using QuantumType = System.UInt16;
#elif Q16HDRI
using QuantumType = System.Single;
#else
#error Not implemented!
#endif

namespace ImageMagick
{
  public sealed partial class MagickScript
  {
    private PointD CreatePointD(XmlElement element)
    {
      Hashtable arguments = new Hashtable();
      foreach (XmlAttribute attribute in element.Attributes)
      {
        if (attribute.Name == "value")
          arguments["value"] = Variables.GetValue<String>(attribute);
        else if (attribute.Name == "x")
          arguments["x"] = Variables.GetValue<double>(attribute);
        else if (attribute.Name == "xy")
          arguments["xy"] = Variables.GetValue<double>(attribute);
        else if (attribute.Name == "y")
          arguments["y"] = Variables.GetValue<double>(attribute);
      }
      if (OnlyContains(arguments, "value"))
        return new PointD((String)arguments["value"]);
      else if (OnlyContains(arguments, "x", "y"))
        return new PointD((double)arguments["x"], (double)arguments["y"]);
      else if (OnlyContains(arguments, "xy"))
        return new PointD((double)arguments["xy"]);
      else
        throw new ArgumentException("Invalid argument combination for 'pointD', allowed combinations are: [value] [x, y] [xy]");
    }
    private Collection<PointD> CreatePointDs(XmlElement element)
    {
      Collection<PointD> collection = new Collection<PointD>();
      foreach (XmlElement elem in element.SelectNodes("*"))
      {
        collection.Add(CreatePointD(elem));
      }
      return collection;
    }
  }
}