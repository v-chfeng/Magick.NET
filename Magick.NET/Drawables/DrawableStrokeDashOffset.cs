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

using ImageMagick.Drawables;

namespace ImageMagick
{
  ///<summary>
  /// Specifies the offset into the dash pattern to start the dash.
  ///</summary>
  public sealed class DrawableStrokeDashOffset : IDrawable
  {
    void IDrawable.Draw(IDrawingWand wand)
    {
      if (wand != null)
        wand.StrokeDashOffset(Offset);
    }

    ///<summary>
    /// Creates a new DrawableStrokeDashOffset instance.
    ///</summary>
    ///<param name="offset">The dash offset.</param>
    public DrawableStrokeDashOffset(double offset)
    {
      Offset = offset;
    }

    ///<summary>
    /// The dash offset.
    ///</summary>
    public double Offset
    {
      get;
      set;
    }
  }
}