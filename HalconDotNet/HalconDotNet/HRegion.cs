using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization;
//using System.Drawing.Point;
namespace HalconDotNet
{
    /// <summary>Represents an instance of a region object(-array).</summary>
    [Serializable]
    public class HRegion : HObject, ISerializable, ICloneable
    {
        /// <summary>Create an uninitialized iconic object</summary>
        public HRegion()
          : base(HObjectBase.UNDEF, false)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HRegion(IntPtr key)
          : this(key, true)
        {
            this.AssertObjectClass();
            GC.KeepAlive((object)this);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HRegion(IntPtr key, bool copy)
          : base(key, copy)
        {
            this.AssertObjectClass();
            GC.KeepAlive((object)this);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HRegion(HObject obj)
          : base(obj)
        {
            this.AssertObjectClass();
            GC.KeepAlive((object)this);
        }

        private void AssertObjectClass()
        {
            HalconAPI.AssertObjectClass(this.key, "region");
        }

        /// <summary>Returns the iconic object(s) at the specified index</summary>
        public HRegion this[HTuple index]
        {
            get
            {
                return this.SelectObj(index);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int LoadNew(IntPtr proc, int parIndex, int err, out HRegion obj)
        {
            obj = new HRegion(HObjectBase.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        /// <summary>
        ///   Create a rectangle parallel to the coordinate axes.
        ///   Modified instance represents: Created rectangle.
        /// </summary>
        /// <param name="row1">Line of upper left corner point. Default: 30.0</param>
        /// <param name="column1">Column of upper left corner point. Default: 20.0</param>
        /// <param name="row2">Line of lower right corner point. Default: 100.0</param>
        /// <param name="column2">Column of lower right corner point. Default: 200.0</param>
        public HRegion(HTuple row1, HTuple column1, HTuple row2, HTuple column2)
        {
            IntPtr proc = HalconAPI.PreCall(603);
            HalconAPI.Store(proc, 0, row1);
            HalconAPI.Store(proc, 1, column1);
            HalconAPI.Store(proc, 2, row2);
            HalconAPI.Store(proc, 3, column2);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row1);
            HalconAPI.UnpinTuple(column1);
            HalconAPI.UnpinTuple(row2);
            HalconAPI.UnpinTuple(column2);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a rectangle parallel to the coordinate axes.
        ///   Modified instance represents: Created rectangle.
        /// </summary>
        /// <param name="row1">Line of upper left corner point. Default: 30.0</param>
        /// <param name="column1">Column of upper left corner point. Default: 20.0</param>
        /// <param name="row2">Line of lower right corner point. Default: 100.0</param>
        /// <param name="column2">Column of lower right corner point. Default: 200.0</param>
        public HRegion(double row1, double column1, double row2, double column2)
        {
            IntPtr proc = HalconAPI.PreCall(603);
            HalconAPI.StoreD(proc, 0, row1);
            HalconAPI.StoreD(proc, 1, column1);
            HalconAPI.StoreD(proc, 2, row2);
            HalconAPI.StoreD(proc, 3, column2);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create an ellipse sector.
        ///   Modified instance represents: Created ellipse(s).
        /// </summary>
        /// <param name="row">Line index of center. Default: 200.0</param>
        /// <param name="column">Column index of center. Default: 200.0</param>
        /// <param name="phi">Orientation of the longer radius (Radius1). Default: 0.0</param>
        /// <param name="radius1">Longer radius. Default: 100.0</param>
        /// <param name="radius2">Shorter radius. Default: 60.0</param>
        /// <param name="startAngle">Start angle of the sector. Default: 0.0</param>
        /// <param name="endAngle">End angle of the sector. Default: 3.14159</param>
        public HRegion(
          HTuple row,
          HTuple column,
          HTuple phi,
          HTuple radius1,
          HTuple radius2,
          HTuple startAngle,
          HTuple endAngle)
        {
            IntPtr proc = HalconAPI.PreCall(608);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, column);
            HalconAPI.Store(proc, 2, phi);
            HalconAPI.Store(proc, 3, radius1);
            HalconAPI.Store(proc, 4, radius2);
            HalconAPI.Store(proc, 5, startAngle);
            HalconAPI.Store(proc, 6, endAngle);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.UnpinTuple(phi);
            HalconAPI.UnpinTuple(radius1);
            HalconAPI.UnpinTuple(radius2);
            HalconAPI.UnpinTuple(startAngle);
            HalconAPI.UnpinTuple(endAngle);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create an ellipse sector.
        ///   Modified instance represents: Created ellipse(s).
        /// </summary>
        /// <param name="row">Line index of center. Default: 200.0</param>
        /// <param name="column">Column index of center. Default: 200.0</param>
        /// <param name="phi">Orientation of the longer radius (Radius1). Default: 0.0</param>
        /// <param name="radius1">Longer radius. Default: 100.0</param>
        /// <param name="radius2">Shorter radius. Default: 60.0</param>
        /// <param name="startAngle">Start angle of the sector. Default: 0.0</param>
        /// <param name="endAngle">End angle of the sector. Default: 3.14159</param>
        public HRegion(
          double row,
          double column,
          double phi,
          double radius1,
          double radius2,
          double startAngle,
          double endAngle)
        {
            IntPtr proc = HalconAPI.PreCall(608);
            HalconAPI.StoreD(proc, 0, row);
            HalconAPI.StoreD(proc, 1, column);
            HalconAPI.StoreD(proc, 2, phi);
            HalconAPI.StoreD(proc, 3, radius1);
            HalconAPI.StoreD(proc, 4, radius2);
            HalconAPI.StoreD(proc, 5, startAngle);
            HalconAPI.StoreD(proc, 6, endAngle);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a circle sector.
        ///   Modified instance represents: Generated circle sector.
        /// </summary>
        /// <param name="row">Line index of center. Default: 200.0</param>
        /// <param name="column">Column index of center. Default: 200.0</param>
        /// <param name="radius">Radius of circle. Default: 100.5</param>
        /// <param name="startAngle">Start angle of the circle sector. Default: 0.0</param>
        /// <param name="endAngle">End angle of the circle sector. Default: 3.14159</param>
        public HRegion(HTuple row, HTuple column, HTuple radius, HTuple startAngle, HTuple endAngle)
        {
            IntPtr proc = HalconAPI.PreCall(610);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, column);
            HalconAPI.Store(proc, 2, radius);
            HalconAPI.Store(proc, 3, startAngle);
            HalconAPI.Store(proc, 4, endAngle);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.UnpinTuple(radius);
            HalconAPI.UnpinTuple(startAngle);
            HalconAPI.UnpinTuple(endAngle);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a circle sector.
        ///   Modified instance represents: Generated circle sector.
        /// </summary>
        /// <param name="row">Line index of center. Default: 200.0</param>
        /// <param name="column">Column index of center. Default: 200.0</param>
        /// <param name="radius">Radius of circle. Default: 100.5</param>
        /// <param name="startAngle">Start angle of the circle sector. Default: 0.0</param>
        /// <param name="endAngle">End angle of the circle sector. Default: 3.14159</param>
        public HRegion(double row, double column, double radius, double startAngle, double endAngle)
        {
            IntPtr proc = HalconAPI.PreCall(610);
            HalconAPI.StoreD(proc, 0, row);
            HalconAPI.StoreD(proc, 1, column);
            HalconAPI.StoreD(proc, 2, radius);
            HalconAPI.StoreD(proc, 3, startAngle);
            HalconAPI.StoreD(proc, 4, endAngle);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a circle.
        ///   Modified instance represents: Generated circle.
        /// </summary>
        /// <param name="row">Line index of center. Default: 200.0</param>
        /// <param name="column">Column index of center. Default: 200.0</param>
        /// <param name="radius">Radius of circle. Default: 100.5</param>
        public HRegion(HTuple row, HTuple column, HTuple radius)
        {
            IntPtr proc = HalconAPI.PreCall(611);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, column);
            HalconAPI.Store(proc, 2, radius);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.UnpinTuple(radius);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a circle.
        ///   Modified instance represents: Generated circle.
        /// </summary>
        /// <param name="row">Line index of center. Default: 200.0</param>
        /// <param name="column">Column index of center. Default: 200.0</param>
        /// <param name="radius">Radius of circle. Default: 100.5</param>
        public HRegion(double row, double column, double radius)
        {
            IntPtr proc = HalconAPI.PreCall(611);
            HalconAPI.StoreD(proc, 0, row);
            HalconAPI.StoreD(proc, 1, column);
            HalconAPI.StoreD(proc, 2, radius);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeRegion();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HRegion(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeRegion(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public new void Serialize(Stream stream)
        {
            this.SerializeRegion().Serialize(stream);
        }

        public static HRegion Deserialize(Stream stream)
        {
            HRegion hregion = new HRegion();
            hregion.DeserializeRegion(HSerializedItem.Deserialize(stream));
            return hregion;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HRegion Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeRegion();
            HRegion hregion = new HRegion();
            hregion.DeserializeRegion(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hregion;
        }

        /// <summary>Returns the intersection of regions</summary>
        public static HRegion operator &(HRegion region1, HRegion region2)
        {
            return region1.Intersection(region2);
        }

        /// <summary>Returns the union of regions</summary>
        public static HRegion operator |(HRegion region1, HRegion region2)
        {
            return region1.Union2(region2);
        }

        /// <summary>Returns the difference of regions</summary>
        public static HRegion operator /(HRegion region1, HRegion region2)
        {
            return region1.Difference(region2);
        }

        /// <summary>
        ///   Returns the recomplement of the region. Note that the result
        ///   is not necessarily finite, so you might wish to intersect the
        ///   result with the image domain you are interested in.
        /// </summary>
        public static HRegion operator !(HRegion region)
        {
            return region.Complement();
        }

        /// <summary>
        ///   Returns the intersection of the region and the image domain.
        ///   In particular, the result will not exceed the image bounds.
        /// </summary>
        public static HRegion operator &(HRegion region, HImage image)
        {
            return region.Intersection(image.GetDomain());
        }

        /// <summary>Test if one region is a subset of the other</summary>
        public static bool operator <=(HRegion region1, HRegion region2)
        {
            int num1 = region1.CountObj();
            int num2 = region2.CountObj();
            if (num1 == 1 && num2 == 1)
                return (int)(region1 / region2).Area == 0;
            return false;
        }

        /// <summary>Test if one region is a subset of the other</summary>
        public static bool operator >=(HRegion region1, HRegion region2)
        {
            return region2 <= region1;
        }

        /// <summary>Returns the Minkowski addition of regions</summary>
        public static HRegion operator +(HRegion region1, HRegion region2)
        {
            return region1.MinkowskiAdd1(region2, 1);
        }

        /// <summary>Returns the Minkowski subtraction of regions</summary>
        public static HRegion operator -(HRegion region1, HRegion region2)
        {
            return region1.MinkowskiSub1(region2, 1);
        }

        /// <summary>Dilates the region by the specified radius</summary>
        public static HRegion operator +(HRegion region, double radius)
        {
            return region.DilationCircle(radius);
        }

        /// <summary>Dilates the region by the specified radius</summary>
        public static HRegion operator +(double radius, HRegion region)
        {
            return region.DilationCircle(radius);
        }

        /// <summary>Erodes the region by the specified radius</summary>
        public static HRegion operator -(HRegion region, double radius)
        {
            return region.ErosionCircle(radius);
        }

        /// <summary>Translates the region</summary>
        public static HRegion operator +(HRegion region, Point p)
        {
            return region.MoveRegion(p.Y, p.X);
        }

        /// <summary>Zooms the region</summary>
        public static HRegion operator *(HRegion region, double factor)
        {
            return region.ZoomRegion(factor, factor);
        }

        /// <summary>Zooms the region</summary>
        public static HRegion operator *(double factor, HRegion region)
        {
            return region.ZoomRegion(factor, factor);
        }

        /// <summary>Transposes the region</summary>
        public static HRegion operator -(HRegion region)
        {
            return region.TransposeRegion(0, 0);
        }

        /// <summary>Converts an XLD contour to a filled region</summary>
        public static implicit operator HRegion(HXLDCont xld)
        {
            return xld.GenRegionContourXld("filled");
        }

        /// <summary>Converts an XLD polygon to a filled region</summary>
        public static implicit operator HRegion(HXLDPoly xld)
        {
            return xld.GenRegionPolygonXld("filled");
        }

        /// <summary>Returns an XLD contour representing the region border</summary>
        public static implicit operator HXLDCont(HRegion region)
        {
            return region.GenContourRegionXld("border");
        }

        /// <summary>The area of the region</summary>
        public HTuple Area
        {
            get
            {
                HTuple row;
                HTuple column;
                return this.AreaCenter(out row, out column);
            }
        }

        /// <summary>The center row of the region</summary>
        public HTuple Row
        {
            get
            {
                HTuple row;
                HTuple column;
                this.AreaCenter(out row, out column);
                return row;
            }
        }

        /// <summary>The center column of the region</summary>
        public HTuple Column
        {
            get
            {
                HTuple row;
                HTuple column;
                this.AreaCenter(out row, out column);
                return column;
            }
        }

        /// <summary>
        ///   Generate XLD contours from regions.
        ///   Instance represents: Input regions.
        /// </summary>
        /// <param name="mode">Mode of contour generation. Default: "border"</param>
        /// <returns>Resulting contours.</returns>
        public HXLDCont GenContourRegionXld(string mode)
        {
            IntPtr proc = HalconAPI.PreCall(70);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Convert a skeleton into XLD contours.
        ///   Instance represents: Skeleton of which the contours are to be determined.
        /// </summary>
        /// <param name="length">Minimum number of points a contour has to have. Default: 1</param>
        /// <param name="mode">Contour filter mode. Default: "filter"</param>
        /// <returns>Resulting contours.</returns>
        public HXLDCont GenContoursSkeletonXld(int length, string mode)
        {
            IntPtr proc = HalconAPI.PreCall(73);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, length);
            HalconAPI.StoreS(proc, 1, mode);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Receive regions over a socket connection.
        ///   Modified instance represents: Received regions.
        /// </summary>
        /// <param name="socket">Socket number.</param>
        public void ReceiveRegion(HSocket socket)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(327);
            HalconAPI.Store(proc, 0, (HTool)socket);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)socket);
        }

        /// <summary>
        ///   Send regions over a socket connection.
        ///   Instance represents: Regions to be sent.
        /// </summary>
        /// <param name="socket">Socket number.</param>
        public void SendRegion(HSocket socket)
        {
            IntPtr proc = HalconAPI.PreCall(328);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)socket);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)socket);
        }

        /// <summary>
        ///   Create a model to perform 3D-measurements using the sheet-of-light technique.
        ///   Instance represents: Region of the images containing the profiles to be processed. If the provided region is not rectangular, its smallest enclosing rectangle will be used.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the sheet-of-light model. Default: "min_gray"</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the sheet-of-light model. Default: 50</param>
        /// <returns>Handle for using and accessing the sheet-of-light model.</returns>
        public HSheetOfLightModel CreateSheetOfLightModel(
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(391);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, genParamName);
            HalconAPI.Store(proc, 1, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HSheetOfLightModel hsheetOfLightModel;
            int procResult = HSheetOfLightModel.LoadNew(proc, 0, err, out hsheetOfLightModel);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hsheetOfLightModel;
        }

        /// <summary>
        ///   Create a model to perform 3D-measurements using the sheet-of-light technique.
        ///   Instance represents: Region of the images containing the profiles to be processed. If the provided region is not rectangular, its smallest enclosing rectangle will be used.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the sheet-of-light model. Default: "min_gray"</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the sheet-of-light model. Default: 50</param>
        /// <returns>Handle for using and accessing the sheet-of-light model.</returns>
        public HSheetOfLightModel CreateSheetOfLightModel(
          string genParamName,
          int genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(391);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, genParamName);
            HalconAPI.StoreI(proc, 1, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HSheetOfLightModel hsheetOfLightModel;
            int procResult = HSheetOfLightModel.LoadNew(proc, 0, err, out hsheetOfLightModel);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hsheetOfLightModel;
        }

        /// <summary>
        ///   Selects characters from a given region.
        ///   Instance represents: Region of text lines in which to select the characters.
        /// </summary>
        /// <param name="dotPrint">Should dot print characters be detected? Default: "false"</param>
        /// <param name="strokeWidth">Stroke width of a character. Default: "medium"</param>
        /// <param name="charWidth">Width of a character. Default: 25</param>
        /// <param name="charHeight">Height of a character. Default: 25</param>
        /// <param name="punctuation">Add punctuation? Default: "false"</param>
        /// <param name="diacriticMarks">Exist diacritic marks? Default: "false"</param>
        /// <param name="partitionMethod">Method to partition neighbored characters. Default: "none"</param>
        /// <param name="partitionLines">Should lines be partitioned? Default: "false"</param>
        /// <param name="fragmentDistance">Distance of fragments. Default: "medium"</param>
        /// <param name="connectFragments">Connect fragments? Default: "false"</param>
        /// <param name="clutterSizeMax">Maximum size of clutter. Default: 0</param>
        /// <param name="stopAfter">Stop execution after this step. Default: "completion"</param>
        /// <returns>Selected characters.</returns>
        public HRegion SelectCharacters(
          string dotPrint,
          string strokeWidth,
          HTuple charWidth,
          HTuple charHeight,
          string punctuation,
          string diacriticMarks,
          string partitionMethod,
          string partitionLines,
          string fragmentDistance,
          string connectFragments,
          int clutterSizeMax,
          string stopAfter)
        {
            IntPtr proc = HalconAPI.PreCall(424);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, dotPrint);
            HalconAPI.StoreS(proc, 1, strokeWidth);
            HalconAPI.Store(proc, 2, charWidth);
            HalconAPI.Store(proc, 3, charHeight);
            HalconAPI.StoreS(proc, 4, punctuation);
            HalconAPI.StoreS(proc, 5, diacriticMarks);
            HalconAPI.StoreS(proc, 6, partitionMethod);
            HalconAPI.StoreS(proc, 7, partitionLines);
            HalconAPI.StoreS(proc, 8, fragmentDistance);
            HalconAPI.StoreS(proc, 9, connectFragments);
            HalconAPI.StoreI(proc, 10, clutterSizeMax);
            HalconAPI.StoreS(proc, 11, stopAfter);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(charWidth);
            HalconAPI.UnpinTuple(charHeight);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Segments characters in a given region of an image.
        ///   Instance represents: Area in the image where the text lines are located.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="regionForeground">Region of characters.</param>
        /// <param name="method">Method to segment the characters. Default: "local_auto_shape"</param>
        /// <param name="eliminateLines">Eliminate horizontal and vertical lines? Default: "false"</param>
        /// <param name="dotPrint">Should dot print characters be detected? Default: "false"</param>
        /// <param name="strokeWidth">Stroke width of a character. Default: "medium"</param>
        /// <param name="charWidth">Width of a character. Default: 25</param>
        /// <param name="charHeight">Height of a character. Default: 25</param>
        /// <param name="thresholdOffset">Value to adjust the segmentation. Default: 0</param>
        /// <param name="contrast">Minimum gray value difference between text and background. Default: 10</param>
        /// <param name="usedThreshold">Threshold used to segment the characters.</param>
        /// <returns>Image used for the segmentation.</returns>
        public HImage SegmentCharacters(
          HImage image,
          out HRegion regionForeground,
          string method,
          string eliminateLines,
          string dotPrint,
          string strokeWidth,
          HTuple charWidth,
          HTuple charHeight,
          int thresholdOffset,
          int contrast,
          out HTuple usedThreshold)
        {
            IntPtr proc = HalconAPI.PreCall(425);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.StoreS(proc, 0, method);
            HalconAPI.StoreS(proc, 1, eliminateLines);
            HalconAPI.StoreS(proc, 2, dotPrint);
            HalconAPI.StoreS(proc, 3, strokeWidth);
            HalconAPI.Store(proc, 4, charWidth);
            HalconAPI.Store(proc, 5, charHeight);
            HalconAPI.StoreI(proc, 6, thresholdOffset);
            HalconAPI.StoreI(proc, 7, contrast);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 0);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(charWidth);
            HalconAPI.UnpinTuple(charHeight);
            HImage himage;
            int err2 = HImage.LoadNew(proc, 1, err1, out himage);
            int err3 = HRegion.LoadNew(proc, 2, err2, out regionForeground);
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err3, out usedThreshold);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return himage;
        }

        /// <summary>
        ///   Segments characters in a given region of an image.
        ///   Instance represents: Area in the image where the text lines are located.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="regionForeground">Region of characters.</param>
        /// <param name="method">Method to segment the characters. Default: "local_auto_shape"</param>
        /// <param name="eliminateLines">Eliminate horizontal and vertical lines? Default: "false"</param>
        /// <param name="dotPrint">Should dot print characters be detected? Default: "false"</param>
        /// <param name="strokeWidth">Stroke width of a character. Default: "medium"</param>
        /// <param name="charWidth">Width of a character. Default: 25</param>
        /// <param name="charHeight">Height of a character. Default: 25</param>
        /// <param name="thresholdOffset">Value to adjust the segmentation. Default: 0</param>
        /// <param name="contrast">Minimum gray value difference between text and background. Default: 10</param>
        /// <param name="usedThreshold">Threshold used to segment the characters.</param>
        /// <returns>Image used for the segmentation.</returns>
        public HImage SegmentCharacters(
          HImage image,
          out HRegion regionForeground,
          string method,
          string eliminateLines,
          string dotPrint,
          string strokeWidth,
          HTuple charWidth,
          HTuple charHeight,
          int thresholdOffset,
          int contrast,
          out int usedThreshold)
        {
            IntPtr proc = HalconAPI.PreCall(425);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.StoreS(proc, 0, method);
            HalconAPI.StoreS(proc, 1, eliminateLines);
            HalconAPI.StoreS(proc, 2, dotPrint);
            HalconAPI.StoreS(proc, 3, strokeWidth);
            HalconAPI.Store(proc, 4, charWidth);
            HalconAPI.Store(proc, 5, charHeight);
            HalconAPI.StoreI(proc, 6, thresholdOffset);
            HalconAPI.StoreI(proc, 7, contrast);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 0);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(charWidth);
            HalconAPI.UnpinTuple(charHeight);
            HImage himage;
            int err2 = HImage.LoadNew(proc, 1, err1, out himage);
            int err3 = HRegion.LoadNew(proc, 2, err2, out regionForeground);
            int procResult = HalconAPI.LoadI(proc, 0, err3, out usedThreshold);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return himage;
        }

        /// <summary>
        ///   Determines the slant of characters of a text line or paragraph.
        ///   Instance represents: Area of text lines.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="charHeight">Height of the text lines. Default: 25</param>
        /// <param name="slantFrom">Minimum slant of the characters Default: -0.523599</param>
        /// <param name="slantTo">Maximum slant of the characters Default: 0.523599</param>
        /// <returns>Calculated slant of the characters in the region</returns>
        public HTuple TextLineSlant(
          HImage image,
          int charHeight,
          double slantFrom,
          double slantTo)
        {
            IntPtr proc = HalconAPI.PreCall(426);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.StoreI(proc, 0, charHeight);
            HalconAPI.StoreD(proc, 1, slantFrom);
            HalconAPI.StoreD(proc, 2, slantTo);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Determines the orientation of a text line or paragraph.
        ///   Instance represents: Area of text lines.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="charHeight">Height of the text lines. Default: 25</param>
        /// <param name="orientationFrom">Minimum rotation of the text lines. Default: -0.523599</param>
        /// <param name="orientationTo">Maximum rotation of the text lines. Default: 0.523599</param>
        /// <returns>Calculated rotation angle of the text lines.</returns>
        public HTuple TextLineOrientation(
          HImage image,
          int charHeight,
          double orientationFrom,
          double orientationTo)
        {
            IntPtr proc = HalconAPI.PreCall(427);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.StoreI(proc, 0, charHeight);
            HalconAPI.StoreD(proc, 1, orientationFrom);
            HalconAPI.StoreD(proc, 2, orientationTo);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Construct classes for class_ndim_norm.
        ///   Instance represents: Foreground pixels to be trained.
        /// </summary>
        /// <param name="background">Background pixels to be trained (rejection class).</param>
        /// <param name="image">Multi-channel training image.</param>
        /// <param name="metric">Metric to be used. Default: "euclid"</param>
        /// <param name="distance">Maximum cluster radius. Default: 10.0</param>
        /// <param name="minNumberPercent">The ratio of the number of pixels in a cluster to the total number of pixels (in percent) must be larger than MinNumberPercent (otherwise the cluster is not output). Default: 0.01</param>
        /// <param name="center">Coordinates of all cluster centers.</param>
        /// <param name="quality">Overlap of the rejection class with the classified objects (1: no overlap).</param>
        /// <returns>Cluster radii or half edge lengths.</returns>
        public HTuple LearnNdimNorm(
          HRegion background,
          HImage image,
          string metric,
          HTuple distance,
          HTuple minNumberPercent,
          out HTuple center,
          out double quality)
        {
            IntPtr proc = HalconAPI.PreCall(437);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)background);
            HalconAPI.Store(proc, 3, (HObjectBase)image);
            HalconAPI.StoreS(proc, 0, metric);
            HalconAPI.Store(proc, 1, distance);
            HalconAPI.Store(proc, 2, minNumberPercent);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(distance);
            HalconAPI.UnpinTuple(minNumberPercent);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out center);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out quality);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)background);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Construct classes for class_ndim_norm.
        ///   Instance represents: Foreground pixels to be trained.
        /// </summary>
        /// <param name="background">Background pixels to be trained (rejection class).</param>
        /// <param name="image">Multi-channel training image.</param>
        /// <param name="metric">Metric to be used. Default: "euclid"</param>
        /// <param name="distance">Maximum cluster radius. Default: 10.0</param>
        /// <param name="minNumberPercent">The ratio of the number of pixels in a cluster to the total number of pixels (in percent) must be larger than MinNumberPercent (otherwise the cluster is not output). Default: 0.01</param>
        /// <param name="center">Coordinates of all cluster centers.</param>
        /// <param name="quality">Overlap of the rejection class with the classified objects (1: no overlap).</param>
        /// <returns>Cluster radii or half edge lengths.</returns>
        public HTuple LearnNdimNorm(
          HRegion background,
          HImage image,
          string metric,
          double distance,
          double minNumberPercent,
          out HTuple center,
          out double quality)
        {
            IntPtr proc = HalconAPI.PreCall(437);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)background);
            HalconAPI.Store(proc, 3, (HObjectBase)image);
            HalconAPI.StoreS(proc, 0, metric);
            HalconAPI.StoreD(proc, 1, distance);
            HalconAPI.StoreD(proc, 2, minNumberPercent);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out center);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out quality);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)background);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Train a classificator using a multi-channel image.
        ///   Instance represents: Foreground pixels to be trained.
        /// </summary>
        /// <param name="background">Background pixels to be trained (rejection class).</param>
        /// <param name="multiChannelImage">Multi-channel training image.</param>
        /// <param name="classifHandle">Handle of the classifier.</param>
        public void LearnNdimBox(HRegion background, HImage multiChannelImage, HClassBox classifHandle)
        {
            IntPtr proc = HalconAPI.PreCall(438);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)background);
            HalconAPI.Store(proc, 3, (HObjectBase)multiChannelImage);
            HalconAPI.Store(proc, 0, (HTool)classifHandle);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)background);
            GC.KeepAlive((object)multiChannelImage);
            GC.KeepAlive((object)classifHandle);
        }

        /// <summary>
        ///   Transform a region in polar coordinates back to cartesian coordinates.
        ///   Instance represents: Input region.
        /// </summary>
        /// <param name="row">Row coordinate of the center of the arc. Default: 256</param>
        /// <param name="column">Column coordinate of the center of the arc. Default: 256</param>
        /// <param name="angleStart">Angle of the ray to map the column coordinate 0 of PolarRegion to. Default: 0.0</param>
        /// <param name="angleEnd">Angle of the ray to map the column coordinate $WidthIn-1$ of PolarRegion to. Default: 6.2831853</param>
        /// <param name="radiusStart">Radius of the circle to map the row coordinate 0 of PolarRegion to. Default: 0</param>
        /// <param name="radiusEnd">Radius of the circle to map the row coordinate $HeightIn-1$ of PolarRegion to. Default: 100</param>
        /// <param name="widthIn">Width of the virtual input image. Default: 512</param>
        /// <param name="heightIn">Height of the virtual input image. Default: 512</param>
        /// <param name="width">Width of the virtual output image. Default: 512</param>
        /// <param name="height">Height of the virtual output image. Default: 512</param>
        /// <param name="interpolation">Interpolation method for the transformation. Default: "nearest_neighbor"</param>
        /// <returns>Output region.</returns>
        public HRegion PolarTransRegionInv(
          HTuple row,
          HTuple column,
          double angleStart,
          double angleEnd,
          HTuple radiusStart,
          HTuple radiusEnd,
          int widthIn,
          int heightIn,
          int width,
          int height,
          string interpolation)
        {
            IntPtr proc = HalconAPI.PreCall(475);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, column);
            HalconAPI.StoreD(proc, 2, angleStart);
            HalconAPI.StoreD(proc, 3, angleEnd);
            HalconAPI.Store(proc, 4, radiusStart);
            HalconAPI.Store(proc, 5, radiusEnd);
            HalconAPI.StoreI(proc, 6, widthIn);
            HalconAPI.StoreI(proc, 7, heightIn);
            HalconAPI.StoreI(proc, 8, width);
            HalconAPI.StoreI(proc, 9, height);
            HalconAPI.StoreS(proc, 10, interpolation);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.UnpinTuple(radiusStart);
            HalconAPI.UnpinTuple(radiusEnd);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Transform a region in polar coordinates back to cartesian coordinates.
        ///   Instance represents: Input region.
        /// </summary>
        /// <param name="row">Row coordinate of the center of the arc. Default: 256</param>
        /// <param name="column">Column coordinate of the center of the arc. Default: 256</param>
        /// <param name="angleStart">Angle of the ray to map the column coordinate 0 of PolarRegion to. Default: 0.0</param>
        /// <param name="angleEnd">Angle of the ray to map the column coordinate $WidthIn-1$ of PolarRegion to. Default: 6.2831853</param>
        /// <param name="radiusStart">Radius of the circle to map the row coordinate 0 of PolarRegion to. Default: 0</param>
        /// <param name="radiusEnd">Radius of the circle to map the row coordinate $HeightIn-1$ of PolarRegion to. Default: 100</param>
        /// <param name="widthIn">Width of the virtual input image. Default: 512</param>
        /// <param name="heightIn">Height of the virtual input image. Default: 512</param>
        /// <param name="width">Width of the virtual output image. Default: 512</param>
        /// <param name="height">Height of the virtual output image. Default: 512</param>
        /// <param name="interpolation">Interpolation method for the transformation. Default: "nearest_neighbor"</param>
        /// <returns>Output region.</returns>
        public HRegion PolarTransRegionInv(
          double row,
          double column,
          double angleStart,
          double angleEnd,
          double radiusStart,
          double radiusEnd,
          int widthIn,
          int heightIn,
          int width,
          int height,
          string interpolation)
        {
            IntPtr proc = HalconAPI.PreCall(475);
            this.Store(proc, 1);
            HalconAPI.StoreD(proc, 0, row);
            HalconAPI.StoreD(proc, 1, column);
            HalconAPI.StoreD(proc, 2, angleStart);
            HalconAPI.StoreD(proc, 3, angleEnd);
            HalconAPI.StoreD(proc, 4, radiusStart);
            HalconAPI.StoreD(proc, 5, radiusEnd);
            HalconAPI.StoreI(proc, 6, widthIn);
            HalconAPI.StoreI(proc, 7, heightIn);
            HalconAPI.StoreI(proc, 8, width);
            HalconAPI.StoreI(proc, 9, height);
            HalconAPI.StoreS(proc, 10, interpolation);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Transform a region within an annular arc to polar coordinates.
        ///   Instance represents: Input region.
        /// </summary>
        /// <param name="row">Row coordinate of the center of the arc. Default: 256</param>
        /// <param name="column">Column coordinate of the center of the arc. Default: 256</param>
        /// <param name="angleStart">Angle of the ray to be mapped to column coordinate 0 of PolarTransRegion. Default: 0.0</param>
        /// <param name="angleEnd">Angle of the ray to be mapped to column coordinate $Width-1$ of PolarTransRegion. Default: 6.2831853</param>
        /// <param name="radiusStart">Radius of the circle to be mapped to row coordinate 0 of PolarTransRegion. Default: 0</param>
        /// <param name="radiusEnd">Radius of the circle to be mapped to row coordinate $Height-1$ of PolarTransRegion. Default: 100</param>
        /// <param name="width">Width of the virtual output image. Default: 512</param>
        /// <param name="height">Height of the virtual output image. Default: 512</param>
        /// <param name="interpolation">Interpolation method for the transformation. Default: "nearest_neighbor"</param>
        /// <returns>Output region.</returns>
        public HRegion PolarTransRegion(
          HTuple row,
          HTuple column,
          double angleStart,
          double angleEnd,
          HTuple radiusStart,
          HTuple radiusEnd,
          int width,
          int height,
          string interpolation)
        {
            IntPtr proc = HalconAPI.PreCall(476);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, column);
            HalconAPI.StoreD(proc, 2, angleStart);
            HalconAPI.StoreD(proc, 3, angleEnd);
            HalconAPI.Store(proc, 4, radiusStart);
            HalconAPI.Store(proc, 5, radiusEnd);
            HalconAPI.StoreI(proc, 6, width);
            HalconAPI.StoreI(proc, 7, height);
            HalconAPI.StoreS(proc, 8, interpolation);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.UnpinTuple(radiusStart);
            HalconAPI.UnpinTuple(radiusEnd);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Transform a region within an annular arc to polar coordinates.
        ///   Instance represents: Input region.
        /// </summary>
        /// <param name="row">Row coordinate of the center of the arc. Default: 256</param>
        /// <param name="column">Column coordinate of the center of the arc. Default: 256</param>
        /// <param name="angleStart">Angle of the ray to be mapped to column coordinate 0 of PolarTransRegion. Default: 0.0</param>
        /// <param name="angleEnd">Angle of the ray to be mapped to column coordinate $Width-1$ of PolarTransRegion. Default: 6.2831853</param>
        /// <param name="radiusStart">Radius of the circle to be mapped to row coordinate 0 of PolarTransRegion. Default: 0</param>
        /// <param name="radiusEnd">Radius of the circle to be mapped to row coordinate $Height-1$ of PolarTransRegion. Default: 100</param>
        /// <param name="width">Width of the virtual output image. Default: 512</param>
        /// <param name="height">Height of the virtual output image. Default: 512</param>
        /// <param name="interpolation">Interpolation method for the transformation. Default: "nearest_neighbor"</param>
        /// <returns>Output region.</returns>
        public HRegion PolarTransRegion(
          double row,
          double column,
          double angleStart,
          double angleEnd,
          double radiusStart,
          double radiusEnd,
          int width,
          int height,
          string interpolation)
        {
            IntPtr proc = HalconAPI.PreCall(476);
            this.Store(proc, 1);
            HalconAPI.StoreD(proc, 0, row);
            HalconAPI.StoreD(proc, 1, column);
            HalconAPI.StoreD(proc, 2, angleStart);
            HalconAPI.StoreD(proc, 3, angleEnd);
            HalconAPI.StoreD(proc, 4, radiusStart);
            HalconAPI.StoreD(proc, 5, radiusEnd);
            HalconAPI.StoreI(proc, 6, width);
            HalconAPI.StoreI(proc, 7, height);
            HalconAPI.StoreS(proc, 8, interpolation);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Merge regions from line scan images.
        ///   Instance represents: Current input regions.
        /// </summary>
        /// <param name="prevRegions">Merged regions from the previous iteration.</param>
        /// <param name="prevMergedRegions">Regions from the previous iteration which could not be merged with the current ones.</param>
        /// <param name="imageHeight">Height of the line scan images. Default: 512</param>
        /// <param name="mergeBorder">Image line of the current image, which touches the previous image. Default: "top"</param>
        /// <param name="maxImagesRegion">Maximum number of images for a single region. Default: 3</param>
        /// <returns>Current regions, merged with old ones where applicable.</returns>
        public HRegion MergeRegionsLineScan(
          HRegion prevRegions,
          out HRegion prevMergedRegions,
          int imageHeight,
          string mergeBorder,
          int maxImagesRegion)
        {
            IntPtr proc = HalconAPI.PreCall(477);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)prevRegions);
            HalconAPI.StoreI(proc, 0, imageHeight);
            HalconAPI.StoreS(proc, 1, mergeBorder);
            HalconAPI.StoreI(proc, 2, maxImagesRegion);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int err2 = HRegion.LoadNew(proc, 1, err1, out hregion);
            int procResult = HRegion.LoadNew(proc, 2, err2, out prevMergedRegions);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)prevRegions);
            return hregion;
        }

        /// <summary>
        ///   Partition a region into rectangles of approximately equal size.
        ///   Instance represents: Region to be partitioned.
        /// </summary>
        /// <param name="width">Width of the individual rectangles.</param>
        /// <param name="height">Height of the individual rectangles.</param>
        /// <returns>Partitioned region.</returns>
        public HRegion PartitionRectangle(double width, double height)
        {
            IntPtr proc = HalconAPI.PreCall(478);
            this.Store(proc, 1);
            HalconAPI.StoreD(proc, 0, width);
            HalconAPI.StoreD(proc, 1, height);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Partition a region horizontally at positions of small vertical extent.
        ///   Instance represents: Region to be partitioned.
        /// </summary>
        /// <param name="distance">Approximate width of the resulting region parts.</param>
        /// <param name="percent">Maximum percental shift of the split position. Default: 20</param>
        /// <returns>Partitioned region.</returns>
        public HRegion PartitionDynamic(double distance, double percent)
        {
            IntPtr proc = HalconAPI.PreCall(479);
            this.Store(proc, 1);
            HalconAPI.StoreD(proc, 0, distance);
            HalconAPI.StoreD(proc, 1, percent);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Convert regions to a label image.
        ///   Instance represents: Regions to be converted.
        /// </summary>
        /// <param name="type">Pixel type of the result image. Default: "int2"</param>
        /// <param name="width">Width of the image to be generated. Default: 512</param>
        /// <param name="height">Height of the image to be generated. Default: 512</param>
        /// <returns>Result image of dimension Width * Height containing the converted regions.</returns>
        public HImage RegionToLabel(string type, int width, int height)
        {
            IntPtr proc = HalconAPI.PreCall(480);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, type);
            HalconAPI.StoreI(proc, 1, width);
            HalconAPI.StoreI(proc, 2, height);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>
        ///   Convert a region into a binary byte-image.
        ///   Instance represents: Regions to be converted.
        /// </summary>
        /// <param name="foregroundGray">Gray value in which the regions are displayed. Default: 255</param>
        /// <param name="backgroundGray">Gray value in which the background is displayed. Default: 0</param>
        /// <param name="width">Width of the image to be generated. Default: 512</param>
        /// <param name="height">Height of the image to be generated. Default: 512</param>
        /// <returns>Result image of dimension Width * Height containing the converted regions.</returns>
        public HImage RegionToBin(int foregroundGray, int backgroundGray, int width, int height)
        {
            IntPtr proc = HalconAPI.PreCall(481);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, foregroundGray);
            HalconAPI.StoreI(proc, 1, backgroundGray);
            HalconAPI.StoreI(proc, 2, width);
            HalconAPI.StoreI(proc, 3, height);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>
        ///   Return the union of two regions.
        ///   Instance represents: Region for which the union with all regions in Region2 is to be computed.
        /// </summary>
        /// <param name="region2">Regions which should be added to Region1.</param>
        /// <returns>Resulting regions.</returns>
        public HRegion Union2(HRegion region2)
        {
            IntPtr proc = HalconAPI.PreCall(482);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)region2);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)region2);
            return hregion;
        }

        /// <summary>
        ///   Return the union of all input regions.
        ///   Instance represents: Regions of which the union is to be computed.
        /// </summary>
        /// <returns>Union of all input regions.</returns>
        public HRegion Union1()
        {
            IntPtr proc = HalconAPI.PreCall(483);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Compute the closest-point transformation of a region.
        ///   Instance represents: Region for which the distance to the border is computed.
        /// </summary>
        /// <param name="closestPoints">Image containing the coordinates of the closest points.</param>
        /// <param name="metric">Type of metric to be used for the closest-point transformation. Default: "city-block"</param>
        /// <param name="foreground">Compute the distance for pixels inside (true) or outside (false) the input region. Default: "true"</param>
        /// <param name="closestPointMode">Mode in which the coordinates of the closest points are returned. Default: "absolute"</param>
        /// <param name="width">Width of the output images. Default: 640</param>
        /// <param name="height">Height of the output images. Default: 480</param>
        /// <returns>Image containing the distance information.</returns>
        public HImage ClosestPointTransform(
          out HImage closestPoints,
          string metric,
          string foreground,
          string closestPointMode,
          int width,
          int height)
        {
            IntPtr proc = HalconAPI.PreCall(484);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, metric);
            HalconAPI.StoreS(proc, 1, foreground);
            HalconAPI.StoreS(proc, 2, closestPointMode);
            HalconAPI.StoreI(proc, 3, width);
            HalconAPI.StoreI(proc, 4, height);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HImage himage;
            int err2 = HImage.LoadNew(proc, 1, err1, out himage);
            int procResult = HImage.LoadNew(proc, 2, err2, out closestPoints);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>
        ///   Compute the distance transformation of a region.
        ///   Instance represents: Region for which the distance to the border is computed.
        /// </summary>
        /// <param name="metric">Type of metric to be used for the distance transformation. Default: "city-block"</param>
        /// <param name="foreground">Compute the distance for pixels inside (true) or outside (false) the input region. Default: "true"</param>
        /// <param name="width">Width of the output image. Default: 640</param>
        /// <param name="height">Height of the output image. Default: 480</param>
        /// <returns>Image containing the distance information.</returns>
        public HImage DistanceTransform(string metric, string foreground, int width, int height)
        {
            IntPtr proc = HalconAPI.PreCall(485);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, metric);
            HalconAPI.StoreS(proc, 1, foreground);
            HalconAPI.StoreI(proc, 2, width);
            HalconAPI.StoreI(proc, 3, height);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>
        ///   Compute the skeleton of a region.
        ///   Instance represents: Region to be thinned.
        /// </summary>
        /// <returns>Resulting skeleton.</returns>
        public HRegion Skeleton()
        {
            IntPtr proc = HalconAPI.PreCall(486);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Apply a projective transformation to a region.
        ///   Instance represents: Input regions.
        /// </summary>
        /// <param name="homMat2D">Homogeneous projective transformation matrix.</param>
        /// <param name="interpolation">Interpolation method for the transformation. Default: "bilinear"</param>
        /// <returns>Output regions.</returns>
        public HRegion ProjectiveTransRegion(HHomMat2D homMat2D, string interpolation)
        {
            IntPtr proc = HalconAPI.PreCall(487);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HData)homMat2D);
            HalconAPI.StoreS(proc, 1, interpolation);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)homMat2D));
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Apply an arbitrary affine 2D transformation to regions.
        ///   Instance represents: Region(s) to be rotated and scaled.
        /// </summary>
        /// <param name="homMat2D">Input transformation matrix.</param>
        /// <param name="interpolate">Should the transformation be done using interpolation? Default: "nearest_neighbor"</param>
        /// <returns>Transformed output region(s).</returns>
        public HRegion AffineTransRegion(HHomMat2D homMat2D, string interpolate)
        {
            IntPtr proc = HalconAPI.PreCall(488);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HData)homMat2D);
            HalconAPI.StoreS(proc, 1, interpolate);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)homMat2D));
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Reflect a region about an axis.
        ///   Instance represents: Region(s) to be reflected.
        /// </summary>
        /// <param name="mode">Axis of symmetry. Default: "row"</param>
        /// <param name="widthHeight">Twice the coordinate of the axis of symmetry. Default: 512</param>
        /// <returns>Reflected region(s).</returns>
        public HRegion MirrorRegion(string mode, int widthHeight)
        {
            IntPtr proc = HalconAPI.PreCall(489);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.StoreI(proc, 1, widthHeight);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Zoom a region.
        ///   Instance represents: Region(s) to be zoomed.
        /// </summary>
        /// <param name="scaleWidth">Scale factor in x-direction. Default: 2.0</param>
        /// <param name="scaleHeight">Scale factor in y-direction. Default: 2.0</param>
        /// <returns>Zoomed region(s).</returns>
        public HRegion ZoomRegion(double scaleWidth, double scaleHeight)
        {
            IntPtr proc = HalconAPI.PreCall(490);
            this.Store(proc, 1);
            HalconAPI.StoreD(proc, 0, scaleWidth);
            HalconAPI.StoreD(proc, 1, scaleHeight);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Translate a region.
        ///   Instance represents: Region(s) to be moved.
        /// </summary>
        /// <param name="row">Row coordinate of the vector by which the region is to be moved. Default: 30</param>
        /// <param name="column">Row coordinate of the vector by which the region is to be moved. Default: 30</param>
        /// <returns>Translated region(s).</returns>
        public HRegion MoveRegion(int row, int column)
        {
            IntPtr proc = HalconAPI.PreCall(491);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, row);
            HalconAPI.StoreI(proc, 1, column);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Find junctions and end points in a skeleton.
        ///   Instance represents: Input skeletons.
        /// </summary>
        /// <param name="juncPoints">Extracted junctions.</param>
        /// <returns>Extracted end points.</returns>
        public HRegion JunctionsSkeleton(out HRegion juncPoints)
        {
            IntPtr proc = HalconAPI.PreCall(492);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int err2 = HRegion.LoadNew(proc, 1, err1, out hregion);
            int procResult = HRegion.LoadNew(proc, 2, err2, out juncPoints);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Calculate the intersection of two regions.
        ///   Instance represents: Regions to be intersected with all regions in Region2.
        /// </summary>
        /// <param name="region2">Regions with which Region1 is intersected.</param>
        /// <returns>Result of the intersection.</returns>
        public HRegion Intersection(HRegion region2)
        {
            IntPtr proc = HalconAPI.PreCall(493);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)region2);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)region2);
            return hregion;
        }

        /// <summary>
        ///   Partition the image plane using given regions.
        ///   Instance represents: Regions for which the separating lines are to be determined.
        /// </summary>
        /// <param name="mode">Mode of operation. Default: "mixed"</param>
        /// <returns>Output region containing the separating lines.</returns>
        public HRegion Interjacent(string mode)
        {
            IntPtr proc = HalconAPI.PreCall(494);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Fill up holes in regions.
        ///   Instance represents: Input regions containing holes.
        /// </summary>
        /// <returns>Regions without holes.</returns>
        public HRegion FillUp()
        {
            IntPtr proc = HalconAPI.PreCall(495);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Fill up holes in regions having given shape features.
        ///   Instance represents: Input region(s).
        /// </summary>
        /// <param name="feature">Shape feature used. Default: "area"</param>
        /// <param name="min">Minimum value for Feature. Default: 1.0</param>
        /// <param name="max">Maximum value for Feature. Default: 100.0</param>
        /// <returns>Output region(s) with filled holes.</returns>
        public HRegion FillUpShape(string feature, HTuple min, HTuple max)
        {
            IntPtr proc = HalconAPI.PreCall(496);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, feature);
            HalconAPI.Store(proc, 1, min);
            HalconAPI.Store(proc, 2, max);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(min);
            HalconAPI.UnpinTuple(max);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Fill up holes in regions having given shape features.
        ///   Instance represents: Input region(s).
        /// </summary>
        /// <param name="feature">Shape feature used. Default: "area"</param>
        /// <param name="min">Minimum value for Feature. Default: 1.0</param>
        /// <param name="max">Maximum value for Feature. Default: 100.0</param>
        /// <returns>Output region(s) with filled holes.</returns>
        public HRegion FillUpShape(string feature, double min, double max)
        {
            IntPtr proc = HalconAPI.PreCall(496);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, feature);
            HalconAPI.StoreD(proc, 1, min);
            HalconAPI.StoreD(proc, 2, max);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Fill gaps between regions or split overlapping regions.
        ///   Instance represents: Regions for which the gaps are to be closed, or which are to be separated.
        /// </summary>
        /// <param name="forbiddenArea">Regions in which no expansion takes place.</param>
        /// <param name="iterations">Number of iterations. Default: "maximal"</param>
        /// <param name="mode">Expansion mode. Default: "image"</param>
        /// <returns>Expanded or separated regions.</returns>
        public HRegion ExpandRegion(HRegion forbiddenArea, HTuple iterations, string mode)
        {
            IntPtr proc = HalconAPI.PreCall(497);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)forbiddenArea);
            HalconAPI.Store(proc, 0, iterations);
            HalconAPI.StoreS(proc, 1, mode);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(iterations);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)forbiddenArea);
            return hregion;
        }

        /// <summary>
        ///   Fill gaps between regions or split overlapping regions.
        ///   Instance represents: Regions for which the gaps are to be closed, or which are to be separated.
        /// </summary>
        /// <param name="forbiddenArea">Regions in which no expansion takes place.</param>
        /// <param name="iterations">Number of iterations. Default: "maximal"</param>
        /// <param name="mode">Expansion mode. Default: "image"</param>
        /// <returns>Expanded or separated regions.</returns>
        public HRegion ExpandRegion(HRegion forbiddenArea, int iterations, string mode)
        {
            IntPtr proc = HalconAPI.PreCall(497);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)forbiddenArea);
            HalconAPI.StoreI(proc, 0, iterations);
            HalconAPI.StoreS(proc, 1, mode);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)forbiddenArea);
            return hregion;
        }

        /// <summary>
        ///   Clip a region relative to its smallest surrounding rectangle.
        ///   Instance represents: Regions to be clipped.
        /// </summary>
        /// <param name="top">Number of rows clipped at the top. Default: 1</param>
        /// <param name="bottom">Number of rows clipped at the bottom. Default: 1</param>
        /// <param name="left">Number of columns clipped at the left. Default: 1</param>
        /// <param name="right">Number of columns clipped at the right. Default: 1</param>
        /// <returns>Clipped regions.</returns>
        public HRegion ClipRegionRel(int top, int bottom, int left, int right)
        {
            IntPtr proc = HalconAPI.PreCall(498);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, top);
            HalconAPI.StoreI(proc, 1, bottom);
            HalconAPI.StoreI(proc, 2, left);
            HalconAPI.StoreI(proc, 3, right);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Clip a region to a rectangle.
        ///   Instance represents: Region to be clipped.
        /// </summary>
        /// <param name="row1">Row coordinate of the upper left corner of the rectangle. Default: 0</param>
        /// <param name="column1">Column coordinate of the upper left corner of the rectangle. Default: 0</param>
        /// <param name="row2">Row coordinate of the lower right corner of the rectangle. Default: 256</param>
        /// <param name="column2">Column coordinate of the lower right corner of the rectangle. Default: 256</param>
        /// <returns>Clipped regions.</returns>
        public HRegion ClipRegion(int row1, int column1, int row2, int column2)
        {
            IntPtr proc = HalconAPI.PreCall(499);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, row1);
            HalconAPI.StoreI(proc, 1, column1);
            HalconAPI.StoreI(proc, 2, row2);
            HalconAPI.StoreI(proc, 3, column2);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Rank operator for regions.
        ///   Instance represents: Region(s) to be transformed.
        /// </summary>
        /// <param name="width">Width of the filter mask. Default: 15</param>
        /// <param name="height">Height of the filter mask. Default: 15</param>
        /// <param name="number">Minimum number of points lying within the filter mask. Default: 70</param>
        /// <returns>Resulting region(s).</returns>
        public HRegion RankRegion(int width, int height, int number)
        {
            IntPtr proc = HalconAPI.PreCall(500);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, width);
            HalconAPI.StoreI(proc, 1, height);
            HalconAPI.StoreI(proc, 2, number);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Compute connected components of a region.
        ///   Instance represents: Input region.
        /// </summary>
        /// <returns>Connected components.</returns>
        public HRegion Connection()
        {
            IntPtr proc = HalconAPI.PreCall(501);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Calculate the symmetric difference of two regions.
        ///   Instance represents: Input region 1.
        /// </summary>
        /// <param name="region2">Input region 2.</param>
        /// <returns>Resulting region.</returns>
        public HRegion SymmDifference(HRegion region2)
        {
            IntPtr proc = HalconAPI.PreCall(502);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)region2);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)region2);
            return hregion;
        }

        /// <summary>
        ///   Calculate the difference of two regions.
        ///   Instance represents: Regions to be processed.
        /// </summary>
        /// <param name="sub">The union of these regions is subtracted from Region.</param>
        /// <returns>Resulting region.</returns>
        public HRegion Difference(HRegion sub)
        {
            IntPtr proc = HalconAPI.PreCall(503);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)sub);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)sub);
            return hregion;
        }

        /// <summary>
        ///   Return the complement of a region.
        ///   Instance represents: Input region(s).
        /// </summary>
        /// <returns>Complemented regions.</returns>
        public HRegion Complement()
        {
            IntPtr proc = HalconAPI.PreCall(504);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Determine the connected components of the background of given regions.
        ///   Instance represents: Input regions.
        /// </summary>
        /// <returns>Connected components of the background.</returns>
        public HRegion BackgroundSeg()
        {
            IntPtr proc = HalconAPI.PreCall(505);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Generate a region having a given Hamming distance.
        ///   Instance represents: Region to be modified.
        /// </summary>
        /// <param name="width">Width of the region to be changed. Default: 100</param>
        /// <param name="height">Height of the region to be changed. Default: 100</param>
        /// <param name="distance">Hamming distance between the old and new regions. Default: 1000</param>
        /// <returns>Regions having the required Hamming distance.</returns>
        public HRegion HammingChangeRegion(int width, int height, int distance)
        {
            IntPtr proc = HalconAPI.PreCall(506);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, width);
            HalconAPI.StoreI(proc, 1, height);
            HalconAPI.StoreI(proc, 2, distance);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Remove noise from a region.
        ///   Instance represents: Regions to be modified.
        /// </summary>
        /// <param name="type">Mode of noise removal. Default: "n_4"</param>
        /// <returns>Less noisy regions.</returns>
        public HRegion RemoveNoiseRegion(string type)
        {
            IntPtr proc = HalconAPI.PreCall(507);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, type);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Transform the shape of a region.
        ///   Instance represents: Regions to be transformed.
        /// </summary>
        /// <param name="type">Type of transformation. Default: "convex"</param>
        /// <returns>Transformed regions.</returns>
        public HRegion ShapeTrans(string type)
        {
            IntPtr proc = HalconAPI.PreCall(508);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, type);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Fill gaps between regions (depending on gray value or color) or split overlapping regions.
        ///   Instance represents: Regions for which the gaps are to be closed, or which are to be separated.
        /// </summary>
        /// <param name="image">Image (possibly multi-channel) for gray value or color comparison.</param>
        /// <param name="forbiddenArea">Regions in which no expansion takes place.</param>
        /// <param name="iterations">Number of iterations. Default: "maximal"</param>
        /// <param name="mode">Expansion mode. Default: "image"</param>
        /// <param name="threshold">Maximum difference between the gray value or color at the region's border and a candidate for expansion. Default: 32</param>
        /// <returns>Expanded or separated regions.</returns>
        public HRegion ExpandGray(
          HImage image,
          HRegion forbiddenArea,
          HTuple iterations,
          string mode,
          HTuple threshold)
        {
            IntPtr proc = HalconAPI.PreCall(509);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 3, (HObjectBase)forbiddenArea);
            HalconAPI.Store(proc, 0, iterations);
            HalconAPI.StoreS(proc, 1, mode);
            HalconAPI.Store(proc, 2, threshold);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(iterations);
            HalconAPI.UnpinTuple(threshold);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)forbiddenArea);
            return hregion;
        }

        /// <summary>
        ///   Fill gaps between regions (depending on gray value or color) or split overlapping regions.
        ///   Instance represents: Regions for which the gaps are to be closed, or which are to be separated.
        /// </summary>
        /// <param name="image">Image (possibly multi-channel) for gray value or color comparison.</param>
        /// <param name="forbiddenArea">Regions in which no expansion takes place.</param>
        /// <param name="iterations">Number of iterations. Default: "maximal"</param>
        /// <param name="mode">Expansion mode. Default: "image"</param>
        /// <param name="threshold">Maximum difference between the gray value or color at the region's border and a candidate for expansion. Default: 32</param>
        /// <returns>Expanded or separated regions.</returns>
        public HRegion ExpandGray(
          HImage image,
          HRegion forbiddenArea,
          string iterations,
          string mode,
          int threshold)
        {
            IntPtr proc = HalconAPI.PreCall(509);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 3, (HObjectBase)forbiddenArea);
            HalconAPI.StoreS(proc, 0, iterations);
            HalconAPI.StoreS(proc, 1, mode);
            HalconAPI.StoreI(proc, 2, threshold);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)forbiddenArea);
            return hregion;
        }

        /// <summary>
        ///   Fill gaps between regions (depending on gray value or color) or split overlapping regions.
        ///   Instance represents: Regions for which the gaps are to be closed, or which are to be separated.
        /// </summary>
        /// <param name="image">Image (possibly multi-channel) for gray value or color comparison.</param>
        /// <param name="forbiddenArea">Regions in which no expansion takes place.</param>
        /// <param name="iterations">Number of iterations. Default: "maximal"</param>
        /// <param name="mode">Expansion mode. Default: "image"</param>
        /// <param name="refGray">Reference gray value or color for comparison. Default: 128</param>
        /// <param name="threshold">Maximum difference between the reference gray value or color and a candidate for expansion. Default: 32</param>
        /// <returns>Expanded or separated regions.</returns>
        public HRegion ExpandGrayRef(
          HImage image,
          HRegion forbiddenArea,
          HTuple iterations,
          string mode,
          HTuple refGray,
          HTuple threshold)
        {
            IntPtr proc = HalconAPI.PreCall(510);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 3, (HObjectBase)forbiddenArea);
            HalconAPI.Store(proc, 0, iterations);
            HalconAPI.StoreS(proc, 1, mode);
            HalconAPI.Store(proc, 2, refGray);
            HalconAPI.Store(proc, 3, threshold);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(iterations);
            HalconAPI.UnpinTuple(refGray);
            HalconAPI.UnpinTuple(threshold);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)forbiddenArea);
            return hregion;
        }

        /// <summary>
        ///   Fill gaps between regions (depending on gray value or color) or split overlapping regions.
        ///   Instance represents: Regions for which the gaps are to be closed, or which are to be separated.
        /// </summary>
        /// <param name="image">Image (possibly multi-channel) for gray value or color comparison.</param>
        /// <param name="forbiddenArea">Regions in which no expansion takes place.</param>
        /// <param name="iterations">Number of iterations. Default: "maximal"</param>
        /// <param name="mode">Expansion mode. Default: "image"</param>
        /// <param name="refGray">Reference gray value or color for comparison. Default: 128</param>
        /// <param name="threshold">Maximum difference between the reference gray value or color and a candidate for expansion. Default: 32</param>
        /// <returns>Expanded or separated regions.</returns>
        public HRegion ExpandGrayRef(
          HImage image,
          HRegion forbiddenArea,
          string iterations,
          string mode,
          int refGray,
          int threshold)
        {
            IntPtr proc = HalconAPI.PreCall(510);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 3, (HObjectBase)forbiddenArea);
            HalconAPI.StoreS(proc, 0, iterations);
            HalconAPI.StoreS(proc, 1, mode);
            HalconAPI.StoreI(proc, 2, refGray);
            HalconAPI.StoreI(proc, 3, threshold);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)forbiddenArea);
            return hregion;
        }

        /// <summary>
        ///   Split lines represented by one pixel wide, non-branching lines.
        ///   Instance represents: Input lines (represented by 1 pixel wide, non-branching regions).
        /// </summary>
        /// <param name="maxDistance">Maximum distance of the line points to the line segment connecting both end points. Default: 3</param>
        /// <param name="beginRow">Row coordinates of the start points of the output lines.</param>
        /// <param name="beginCol">Column coordinates of the start points of the output lines.</param>
        /// <param name="endRow">Row coordinates of the end points of the output lines.</param>
        /// <param name="endCol">Column coordinates of the end points of the output lines.</param>
        public void SplitSkeletonLines(
          int maxDistance,
          out HTuple beginRow,
          out HTuple beginCol,
          out HTuple endRow,
          out HTuple endCol)
        {
            IntPtr proc = HalconAPI.PreCall(511);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, maxDistance);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out beginRow);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out beginCol);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, err3, out endRow);
            int procResult = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, err4, out endCol);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Split lines represented by one pixel wide, non-branching regions.
        ///   Instance represents: Input lines (represented by 1 pixel wide, non-branching regions).
        /// </summary>
        /// <param name="maxDistance">Maximum distance of the line points to the line segment connecting both end points. Default: 3</param>
        /// <returns>Split lines.</returns>
        public HRegion SplitSkeletonRegion(int maxDistance)
        {
            IntPtr proc = HalconAPI.PreCall(512);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, maxDistance);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Convert a histogram into a region.
        ///   Modified instance represents: Region containing the histogram.
        /// </summary>
        /// <param name="histogram">Input histogram.</param>
        /// <param name="row">Row coordinate of the center of the histogram. Default: 255</param>
        /// <param name="column">Column coordinate of the center of the histogram. Default: 255</param>
        /// <param name="scale">Scale factor for the histogram. Default: 1</param>
        public void GenRegionHisto(HTuple histogram, int row, int column, int scale)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(513);
            HalconAPI.Store(proc, 0, histogram);
            HalconAPI.StoreI(proc, 1, row);
            HalconAPI.StoreI(proc, 2, column);
            HalconAPI.StoreI(proc, 3, scale);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(histogram);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Eliminate runs of a given length.
        ///   Instance represents: Region to be clipped.
        /// </summary>
        /// <param name="elimShorter">All runs which are shorter are eliminated. Default: 3</param>
        /// <param name="elimLonger">All runs which are longer are eliminated. Default: 1000</param>
        /// <returns>Clipped regions.</returns>
        public HRegion EliminateRuns(int elimShorter, int elimLonger)
        {
            IntPtr proc = HalconAPI.PreCall(514);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, elimShorter);
            HalconAPI.StoreI(proc, 1, elimLonger);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Calculate the difference of two object tuples.
        ///   Instance represents: Object tuple 1.
        /// </summary>
        /// <param name="objectsSub">Object tuple 2.</param>
        /// <returns>Objects from Objects that are not part of ObjectsSub.</returns>
        public HRegion ObjDiff(HRegion objectsSub)
        {
            IntPtr proc = HalconAPI.PreCall(573);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objectsSub);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectsSub);
            return hregion;
        }

        /// <summary>
        ///   Paint regions into an image.
        ///   Instance represents: Regions to be painted into the input image.
        /// </summary>
        /// <param name="image">Image in which the regions are to be painted.</param>
        /// <param name="grayval">Desired gray values of the regions. Default: 255.0</param>
        /// <param name="type">Paint regions filled or as boundaries. Default: "fill"</param>
        /// <returns>Image containing the result.</returns>
        public HImage PaintRegion(HImage image, HTuple grayval, string type)
        {
            IntPtr proc = HalconAPI.PreCall(576);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, grayval);
            HalconAPI.StoreS(proc, 1, type);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(grayval);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return himage;
        }

        /// <summary>
        ///   Paint regions into an image.
        ///   Instance represents: Regions to be painted into the input image.
        /// </summary>
        /// <param name="image">Image in which the regions are to be painted.</param>
        /// <param name="grayval">Desired gray values of the regions. Default: 255.0</param>
        /// <param name="type">Paint regions filled or as boundaries. Default: "fill"</param>
        /// <returns>Image containing the result.</returns>
        public HImage PaintRegion(HImage image, double grayval, string type)
        {
            IntPtr proc = HalconAPI.PreCall(576);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.StoreD(proc, 0, grayval);
            HalconAPI.StoreS(proc, 1, type);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return himage;
        }

        /// <summary>
        ///   Overpaint regions in an image.
        ///   Instance represents: Regions to be painted into the input image.
        /// </summary>
        /// <param name="image">Image in which the regions are to be painted.</param>
        /// <param name="grayval">Desired gray values of the regions. Default: 255.0</param>
        /// <param name="type">Paint regions filled or as boundaries. Default: "fill"</param>
        public void OverpaintRegion(HImage image, HTuple grayval, string type)
        {
            IntPtr proc = HalconAPI.PreCall(577);
            this.Store(proc, 2);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 0, grayval);
            HalconAPI.StoreS(proc, 1, type);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(grayval);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Overpaint regions in an image.
        ///   Instance represents: Regions to be painted into the input image.
        /// </summary>
        /// <param name="image">Image in which the regions are to be painted.</param>
        /// <param name="grayval">Desired gray values of the regions. Default: 255.0</param>
        /// <param name="type">Paint regions filled or as boundaries. Default: "fill"</param>
        public void OverpaintRegion(HImage image, double grayval, string type)
        {
            IntPtr proc = HalconAPI.PreCall(577);
            this.Store(proc, 2);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 0, grayval);
            HalconAPI.StoreS(proc, 1, type);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Copy an iconic object in the HALCON database.
        ///   Instance represents: Objects to be copied.
        /// </summary>
        /// <param name="index">Starting index of the objects to be copied. Default: 1</param>
        /// <param name="numObj">Number of objects to be copied or -1. Default: 1</param>
        /// <returns>Copied objects.</returns>
        public HRegion CopyObj(int index, int numObj)
        {
            IntPtr proc = HalconAPI.PreCall(583);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.StoreI(proc, 1, numObj);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Concatenate two iconic object tuples.
        ///   Instance represents: Object tuple 1.
        /// </summary>
        /// <param name="objects2">Object tuple 2.</param>
        /// <returns>Concatenated objects.</returns>
        public HRegion ConcatObj(HRegion objects2)
        {
            IntPtr proc = HalconAPI.PreCall(584);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objects2);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objects2);
            return hregion;
        }

        /// <summary>
        ///   Select objects from an object tuple.
        ///   Instance represents: Input objects.
        /// </summary>
        /// <param name="index">Indices of the objects to be selected. Default: 1</param>
        /// <returns>Selected objects.</returns>
        public HRegion SelectObj(HTuple index)
        {
            IntPtr proc = HalconAPI.PreCall(587);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Select objects from an object tuple.
        ///   Instance represents: Input objects.
        /// </summary>
        /// <param name="index">Indices of the objects to be selected. Default: 1</param>
        /// <returns>Selected objects.</returns>
        public HRegion SelectObj(int index)
        {
            IntPtr proc = HalconAPI.PreCall(587);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Compare iconic objects regarding equality.
        ///   Instance represents: Reference objects.
        /// </summary>
        /// <param name="objects2">Test objects.</param>
        /// <param name="epsilon">Maximum allowed difference between two gray values or  coordinates etc. Default: 0.0</param>
        /// <returns>Boolean result value.</returns>
        public int CompareObj(HRegion objects2, HTuple epsilon)
        {
            IntPtr proc = HalconAPI.PreCall(588);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objects2);
            HalconAPI.Store(proc, 0, epsilon);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(epsilon);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objects2);
            return intValue;
        }

        /// <summary>
        ///   Compare iconic objects regarding equality.
        ///   Instance represents: Reference objects.
        /// </summary>
        /// <param name="objects2">Test objects.</param>
        /// <param name="epsilon">Maximum allowed difference between two gray values or  coordinates etc. Default: 0.0</param>
        /// <returns>Boolean result value.</returns>
        public int CompareObj(HRegion objects2, double epsilon)
        {
            IntPtr proc = HalconAPI.PreCall(588);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objects2);
            HalconAPI.StoreD(proc, 0, epsilon);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objects2);
            return intValue;
        }

        /// <summary>
        ///   Test whether a region is contained in another region.
        ///   Instance represents: Test region.
        /// </summary>
        /// <param name="region2">Region for comparison.</param>
        /// <returns>Is Region1 contained in Region2?</returns>
        public HTuple TestSubsetRegion(HRegion region2)
        {
            IntPtr proc = HalconAPI.PreCall(589);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)region2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)region2);
            return tuple;
        }

        /// <summary>
        ///   Test whether the regions of two objects are identical.
        ///   Instance represents: Test regions.
        /// </summary>
        /// <param name="regions2">Comparative regions.</param>
        /// <returns>boolean result value.</returns>
        public int TestEqualRegion(HRegion regions2)
        {
            IntPtr proc = HalconAPI.PreCall(590);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)regions2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)regions2);
            return intValue;
        }

        /// <summary>
        ///   Compare image objects regarding equality.
        ///   Instance represents: Test objects.
        /// </summary>
        /// <param name="objects2">Comparative objects.</param>
        /// <returns>boolean result value.</returns>
        public int TestEqualObj(HRegion objects2)
        {
            IntPtr proc = HalconAPI.PreCall(591);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objects2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objects2);
            return intValue;
        }

        /// <summary>
        ///   Store a polygon as a "filled" region.
        ///   Modified instance represents: Created region.
        /// </summary>
        /// <param name="rows">Line indices of the base points of the region contour. Default: 100</param>
        /// <param name="columns">Column indices of the base points of the region contour. Default: 100</param>
        public void GenRegionPolygonFilled(HTuple rows, HTuple columns)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(598);
            HalconAPI.Store(proc, 0, rows);
            HalconAPI.Store(proc, 1, columns);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(rows);
            HalconAPI.UnpinTuple(columns);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Store a polygon as a region.
        ///   Modified instance represents: Created region.
        /// </summary>
        /// <param name="rows">Line indices of the base points of the region contour. Default: 100</param>
        /// <param name="columns">Colum indices of the base points of the region contour. Default: 100</param>
        public void GenRegionPolygon(HTuple rows, HTuple columns)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(599);
            HalconAPI.Store(proc, 0, rows);
            HalconAPI.Store(proc, 1, columns);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(rows);
            HalconAPI.UnpinTuple(columns);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Store individual pixels as image region.
        ///   Modified instance represents: Created region.
        /// </summary>
        /// <param name="rows">Lines of the pixels in the region. Default: 100</param>
        /// <param name="columns">Columns of the pixels in the region. Default: 100</param>
        public void GenRegionPoints(HTuple rows, HTuple columns)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(600);
            HalconAPI.Store(proc, 0, rows);
            HalconAPI.Store(proc, 1, columns);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(rows);
            HalconAPI.UnpinTuple(columns);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Store individual pixels as image region.
        ///   Modified instance represents: Created region.
        /// </summary>
        /// <param name="rows">Lines of the pixels in the region. Default: 100</param>
        /// <param name="columns">Columns of the pixels in the region. Default: 100</param>
        public void GenRegionPoints(int rows, int columns)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(600);
            HalconAPI.StoreI(proc, 0, rows);
            HalconAPI.StoreI(proc, 1, columns);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a region from a runlength coding.
        ///   Modified instance represents: Created region.
        /// </summary>
        /// <param name="row">Lines of the runs. Default: 100</param>
        /// <param name="columnBegin">Columns of the starting points of the runs. Default: 50</param>
        /// <param name="columnEnd">Columns of the ending points of the runs. Default: 200</param>
        public void GenRegionRuns(HTuple row, HTuple columnBegin, HTuple columnEnd)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(601);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, columnBegin);
            HalconAPI.Store(proc, 2, columnEnd);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(columnBegin);
            HalconAPI.UnpinTuple(columnEnd);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a region from a runlength coding.
        ///   Modified instance represents: Created region.
        /// </summary>
        /// <param name="row">Lines of the runs. Default: 100</param>
        /// <param name="columnBegin">Columns of the starting points of the runs. Default: 50</param>
        /// <param name="columnEnd">Columns of the ending points of the runs. Default: 200</param>
        public void GenRegionRuns(int row, int columnBegin, int columnEnd)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(601);
            HalconAPI.StoreI(proc, 0, row);
            HalconAPI.StoreI(proc, 1, columnBegin);
            HalconAPI.StoreI(proc, 2, columnEnd);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a rectangle of any orientation.
        ///   Modified instance represents: Created rectangle.
        /// </summary>
        /// <param name="row">Line index of the center. Default: 300.0</param>
        /// <param name="column">Column index of the center. Default: 200.0</param>
        /// <param name="phi">Angle of longitudinal axis to the horizontal (in radians). Default: 0.0</param>
        /// <param name="length1">Half width. Default: 100.0</param>
        /// <param name="length2">Half height. Default: 20.0</param>
        public void GenRectangle2(
          HTuple row,
          HTuple column,
          HTuple phi,
          HTuple length1,
          HTuple length2)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(602);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, column);
            HalconAPI.Store(proc, 2, phi);
            HalconAPI.Store(proc, 3, length1);
            HalconAPI.Store(proc, 4, length2);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.UnpinTuple(phi);
            HalconAPI.UnpinTuple(length1);
            HalconAPI.UnpinTuple(length2);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a rectangle of any orientation.
        ///   Modified instance represents: Created rectangle.
        /// </summary>
        /// <param name="row">Line index of the center. Default: 300.0</param>
        /// <param name="column">Column index of the center. Default: 200.0</param>
        /// <param name="phi">Angle of longitudinal axis to the horizontal (in radians). Default: 0.0</param>
        /// <param name="length1">Half width. Default: 100.0</param>
        /// <param name="length2">Half height. Default: 20.0</param>
        public void GenRectangle2(
          double row,
          double column,
          double phi,
          double length1,
          double length2)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(602);
            HalconAPI.StoreD(proc, 0, row);
            HalconAPI.StoreD(proc, 1, column);
            HalconAPI.StoreD(proc, 2, phi);
            HalconAPI.StoreD(proc, 3, length1);
            HalconAPI.StoreD(proc, 4, length2);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a rectangle parallel to the coordinate axes.
        ///   Modified instance represents: Created rectangle.
        /// </summary>
        /// <param name="row1">Line of upper left corner point. Default: 30.0</param>
        /// <param name="column1">Column of upper left corner point. Default: 20.0</param>
        /// <param name="row2">Line of lower right corner point. Default: 100.0</param>
        /// <param name="column2">Column of lower right corner point. Default: 200.0</param>
        public void GenRectangle1(HTuple row1, HTuple column1, HTuple row2, HTuple column2)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(603);
            HalconAPI.Store(proc, 0, row1);
            HalconAPI.Store(proc, 1, column1);
            HalconAPI.Store(proc, 2, row2);
            HalconAPI.Store(proc, 3, column2);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row1);
            HalconAPI.UnpinTuple(column1);
            HalconAPI.UnpinTuple(row2);
            HalconAPI.UnpinTuple(column2);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a rectangle parallel to the coordinate axes.
        ///   Modified instance represents: Created rectangle.
        /// </summary>
        /// <param name="row1">Line of upper left corner point. Default: 30.0</param>
        /// <param name="column1">Column of upper left corner point. Default: 20.0</param>
        /// <param name="row2">Line of lower right corner point. Default: 100.0</param>
        /// <param name="column2">Column of lower right corner point. Default: 200.0</param>
        public void GenRectangle1(double row1, double column1, double row2, double column2)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(603);
            HalconAPI.StoreD(proc, 0, row1);
            HalconAPI.StoreD(proc, 1, column1);
            HalconAPI.StoreD(proc, 2, row2);
            HalconAPI.StoreD(proc, 3, column2);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a random region.
        ///   Modified instance represents: Created random region with expansion Width x Height.
        /// </summary>
        /// <param name="width">Maximum horizontal expansion of random region. Default: 128</param>
        /// <param name="height">Maximum vertical expansion of random region. Default: 128</param>
        public void GenRandomRegion(int width, int height)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(604);
            HalconAPI.StoreI(proc, 0, width);
            HalconAPI.StoreI(proc, 1, height);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create an ellipse sector.
        ///   Modified instance represents: Created ellipse(s).
        /// </summary>
        /// <param name="row">Line index of center. Default: 200.0</param>
        /// <param name="column">Column index of center. Default: 200.0</param>
        /// <param name="phi">Orientation of the longer radius (Radius1). Default: 0.0</param>
        /// <param name="radius1">Longer radius. Default: 100.0</param>
        /// <param name="radius2">Shorter radius. Default: 60.0</param>
        /// <param name="startAngle">Start angle of the sector. Default: 0.0</param>
        /// <param name="endAngle">End angle of the sector. Default: 3.14159</param>
        public void GenEllipseSector(
          HTuple row,
          HTuple column,
          HTuple phi,
          HTuple radius1,
          HTuple radius2,
          HTuple startAngle,
          HTuple endAngle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(608);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, column);
            HalconAPI.Store(proc, 2, phi);
            HalconAPI.Store(proc, 3, radius1);
            HalconAPI.Store(proc, 4, radius2);
            HalconAPI.Store(proc, 5, startAngle);
            HalconAPI.Store(proc, 6, endAngle);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.UnpinTuple(phi);
            HalconAPI.UnpinTuple(radius1);
            HalconAPI.UnpinTuple(radius2);
            HalconAPI.UnpinTuple(startAngle);
            HalconAPI.UnpinTuple(endAngle);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create an ellipse sector.
        ///   Modified instance represents: Created ellipse(s).
        /// </summary>
        /// <param name="row">Line index of center. Default: 200.0</param>
        /// <param name="column">Column index of center. Default: 200.0</param>
        /// <param name="phi">Orientation of the longer radius (Radius1). Default: 0.0</param>
        /// <param name="radius1">Longer radius. Default: 100.0</param>
        /// <param name="radius2">Shorter radius. Default: 60.0</param>
        /// <param name="startAngle">Start angle of the sector. Default: 0.0</param>
        /// <param name="endAngle">End angle of the sector. Default: 3.14159</param>
        public void GenEllipseSector(
          double row,
          double column,
          double phi,
          double radius1,
          double radius2,
          double startAngle,
          double endAngle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(608);
            HalconAPI.StoreD(proc, 0, row);
            HalconAPI.StoreD(proc, 1, column);
            HalconAPI.StoreD(proc, 2, phi);
            HalconAPI.StoreD(proc, 3, radius1);
            HalconAPI.StoreD(proc, 4, radius2);
            HalconAPI.StoreD(proc, 5, startAngle);
            HalconAPI.StoreD(proc, 6, endAngle);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create an ellipse.
        ///   Modified instance represents: Created ellipse(s).
        /// </summary>
        /// <param name="row">Line index of center. Default: 200.0</param>
        /// <param name="column">Column index of center. Default: 200.0</param>
        /// <param name="phi">Orientation of the longer radius (Radius1). Default: 0.0</param>
        /// <param name="radius1">Longer radius. Default: 100.0</param>
        /// <param name="radius2">Shorter radius. Default: 60.0</param>
        public void GenEllipse(HTuple row, HTuple column, HTuple phi, HTuple radius1, HTuple radius2)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(609);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, column);
            HalconAPI.Store(proc, 2, phi);
            HalconAPI.Store(proc, 3, radius1);
            HalconAPI.Store(proc, 4, radius2);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.UnpinTuple(phi);
            HalconAPI.UnpinTuple(radius1);
            HalconAPI.UnpinTuple(radius2);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create an ellipse.
        ///   Modified instance represents: Created ellipse(s).
        /// </summary>
        /// <param name="row">Line index of center. Default: 200.0</param>
        /// <param name="column">Column index of center. Default: 200.0</param>
        /// <param name="phi">Orientation of the longer radius (Radius1). Default: 0.0</param>
        /// <param name="radius1">Longer radius. Default: 100.0</param>
        /// <param name="radius2">Shorter radius. Default: 60.0</param>
        public void GenEllipse(double row, double column, double phi, double radius1, double radius2)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(609);
            HalconAPI.StoreD(proc, 0, row);
            HalconAPI.StoreD(proc, 1, column);
            HalconAPI.StoreD(proc, 2, phi);
            HalconAPI.StoreD(proc, 3, radius1);
            HalconAPI.StoreD(proc, 4, radius2);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a circle sector.
        ///   Modified instance represents: Generated circle sector.
        /// </summary>
        /// <param name="row">Line index of center. Default: 200.0</param>
        /// <param name="column">Column index of center. Default: 200.0</param>
        /// <param name="radius">Radius of circle. Default: 100.5</param>
        /// <param name="startAngle">Start angle of the circle sector. Default: 0.0</param>
        /// <param name="endAngle">End angle of the circle sector. Default: 3.14159</param>
        public void GenCircleSector(
          HTuple row,
          HTuple column,
          HTuple radius,
          HTuple startAngle,
          HTuple endAngle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(610);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, column);
            HalconAPI.Store(proc, 2, radius);
            HalconAPI.Store(proc, 3, startAngle);
            HalconAPI.Store(proc, 4, endAngle);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.UnpinTuple(radius);
            HalconAPI.UnpinTuple(startAngle);
            HalconAPI.UnpinTuple(endAngle);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a circle sector.
        ///   Modified instance represents: Generated circle sector.
        /// </summary>
        /// <param name="row">Line index of center. Default: 200.0</param>
        /// <param name="column">Column index of center. Default: 200.0</param>
        /// <param name="radius">Radius of circle. Default: 100.5</param>
        /// <param name="startAngle">Start angle of the circle sector. Default: 0.0</param>
        /// <param name="endAngle">End angle of the circle sector. Default: 3.14159</param>
        public void GenCircleSector(
          double row,
          double column,
          double radius,
          double startAngle,
          double endAngle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(610);
            HalconAPI.StoreD(proc, 0, row);
            HalconAPI.StoreD(proc, 1, column);
            HalconAPI.StoreD(proc, 2, radius);
            HalconAPI.StoreD(proc, 3, startAngle);
            HalconAPI.StoreD(proc, 4, endAngle);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a circle.
        ///   Modified instance represents: Generated circle.
        /// </summary>
        /// <param name="row">Line index of center. Default: 200.0</param>
        /// <param name="column">Column index of center. Default: 200.0</param>
        /// <param name="radius">Radius of circle. Default: 100.5</param>
        public void GenCircle(HTuple row, HTuple column, HTuple radius)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(611);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, column);
            HalconAPI.Store(proc, 2, radius);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.UnpinTuple(radius);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a circle.
        ///   Modified instance represents: Generated circle.
        /// </summary>
        /// <param name="row">Line index of center. Default: 200.0</param>
        /// <param name="column">Column index of center. Default: 200.0</param>
        /// <param name="radius">Radius of circle. Default: 100.5</param>
        public void GenCircle(double row, double column, double radius)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(611);
            HalconAPI.StoreD(proc, 0, row);
            HalconAPI.StoreD(proc, 1, column);
            HalconAPI.StoreD(proc, 2, radius);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a checkered region.
        ///   Modified instance represents: Created checkerboard region.
        /// </summary>
        /// <param name="widthRegion">Largest occurring $x$ value of the region. Default: 511</param>
        /// <param name="heightRegion">Largest occurring $y$ value of the region. Default: 511</param>
        /// <param name="widthPattern">Width of a field of the checkerboard. Default: 64</param>
        /// <param name="heightPattern">Height of a field of the checkerboard. Default: 64</param>
        public void GenCheckerRegion(
          int widthRegion,
          int heightRegion,
          int widthPattern,
          int heightPattern)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(612);
            HalconAPI.StoreI(proc, 0, widthRegion);
            HalconAPI.StoreI(proc, 1, heightRegion);
            HalconAPI.StoreI(proc, 2, widthPattern);
            HalconAPI.StoreI(proc, 3, heightPattern);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a region from lines or pixels.
        ///   Modified instance represents: Created lines/pixel region.
        /// </summary>
        /// <param name="rowSteps">Step width in line direction or zero. Default: 10</param>
        /// <param name="columnSteps">Step width in column direction or zero. Default: 10</param>
        /// <param name="type">Type of created pattern. Default: "lines"</param>
        /// <param name="width">Maximum width of pattern. Default: 512</param>
        /// <param name="height">Maximum height of pattern. Default: 512</param>
        public void GenGridRegion(
          HTuple rowSteps,
          HTuple columnSteps,
          string type,
          int width,
          int height)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(613);
            HalconAPI.Store(proc, 0, rowSteps);
            HalconAPI.Store(proc, 1, columnSteps);
            HalconAPI.StoreS(proc, 2, type);
            HalconAPI.StoreI(proc, 3, width);
            HalconAPI.StoreI(proc, 4, height);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(rowSteps);
            HalconAPI.UnpinTuple(columnSteps);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a region from lines or pixels.
        ///   Modified instance represents: Created lines/pixel region.
        /// </summary>
        /// <param name="rowSteps">Step width in line direction or zero. Default: 10</param>
        /// <param name="columnSteps">Step width in column direction or zero. Default: 10</param>
        /// <param name="type">Type of created pattern. Default: "lines"</param>
        /// <param name="width">Maximum width of pattern. Default: 512</param>
        /// <param name="height">Maximum height of pattern. Default: 512</param>
        public void GenGridRegion(int rowSteps, int columnSteps, string type, int width, int height)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(613);
            HalconAPI.StoreI(proc, 0, rowSteps);
            HalconAPI.StoreI(proc, 1, columnSteps);
            HalconAPI.StoreS(proc, 2, type);
            HalconAPI.StoreI(proc, 3, width);
            HalconAPI.StoreI(proc, 4, height);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create random regions like circles, rectangles and ellipses.
        ///   Modified instance represents: Created regions.
        /// </summary>
        /// <param name="type">Type of regions to be created. Default: "circle"</param>
        /// <param name="widthMin">Minimum width of the region. Default: 10.0</param>
        /// <param name="widthMax">Maximum width of the region. Default: 20.0</param>
        /// <param name="heightMin">Minimum height of the region. Default: 10.0</param>
        /// <param name="heightMax">Maximum height of the region. Default: 30.0</param>
        /// <param name="phiMin">Minimum rotation angle of the region. Default: -0.7854</param>
        /// <param name="phiMax">Maximum rotation angle of the region. Default: 0.7854</param>
        /// <param name="numRegions">Number of regions. Default: 100</param>
        /// <param name="width">Maximum horizontal expansion. Default: 512</param>
        /// <param name="height">Maximum vertical expansion. Default: 512</param>
        public void GenRandomRegions(
          string type,
          HTuple widthMin,
          HTuple widthMax,
          HTuple heightMin,
          HTuple heightMax,
          HTuple phiMin,
          HTuple phiMax,
          int numRegions,
          int width,
          int height)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(614);
            HalconAPI.StoreS(proc, 0, type);
            HalconAPI.Store(proc, 1, widthMin);
            HalconAPI.Store(proc, 2, widthMax);
            HalconAPI.Store(proc, 3, heightMin);
            HalconAPI.Store(proc, 4, heightMax);
            HalconAPI.Store(proc, 5, phiMin);
            HalconAPI.Store(proc, 6, phiMax);
            HalconAPI.StoreI(proc, 7, numRegions);
            HalconAPI.StoreI(proc, 8, width);
            HalconAPI.StoreI(proc, 9, height);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(widthMin);
            HalconAPI.UnpinTuple(widthMax);
            HalconAPI.UnpinTuple(heightMin);
            HalconAPI.UnpinTuple(heightMax);
            HalconAPI.UnpinTuple(phiMin);
            HalconAPI.UnpinTuple(phiMax);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create random regions like circles, rectangles and ellipses.
        ///   Modified instance represents: Created regions.
        /// </summary>
        /// <param name="type">Type of regions to be created. Default: "circle"</param>
        /// <param name="widthMin">Minimum width of the region. Default: 10.0</param>
        /// <param name="widthMax">Maximum width of the region. Default: 20.0</param>
        /// <param name="heightMin">Minimum height of the region. Default: 10.0</param>
        /// <param name="heightMax">Maximum height of the region. Default: 30.0</param>
        /// <param name="phiMin">Minimum rotation angle of the region. Default: -0.7854</param>
        /// <param name="phiMax">Maximum rotation angle of the region. Default: 0.7854</param>
        /// <param name="numRegions">Number of regions. Default: 100</param>
        /// <param name="width">Maximum horizontal expansion. Default: 512</param>
        /// <param name="height">Maximum vertical expansion. Default: 512</param>
        public void GenRandomRegions(
          string type,
          double widthMin,
          double widthMax,
          double heightMin,
          double heightMax,
          double phiMin,
          double phiMax,
          int numRegions,
          int width,
          int height)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(614);
            HalconAPI.StoreS(proc, 0, type);
            HalconAPI.StoreD(proc, 1, widthMin);
            HalconAPI.StoreD(proc, 2, widthMax);
            HalconAPI.StoreD(proc, 3, heightMin);
            HalconAPI.StoreD(proc, 4, heightMax);
            HalconAPI.StoreD(proc, 5, phiMin);
            HalconAPI.StoreD(proc, 6, phiMax);
            HalconAPI.StoreI(proc, 7, numRegions);
            HalconAPI.StoreI(proc, 8, width);
            HalconAPI.StoreI(proc, 9, height);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Store input lines described in Hesse normal form as regions.
        ///   Modified instance represents: Created regions (one for every line), clipped to maximum image format.
        /// </summary>
        /// <param name="orientation">Orientation of the normal vector in radians. Default: 0.0</param>
        /// <param name="distance">Distance from the line to the coordinate origin (0.0). Default: 200</param>
        public void GenRegionHline(HTuple orientation, HTuple distance)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(615);
            HalconAPI.Store(proc, 0, orientation);
            HalconAPI.Store(proc, 1, distance);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(orientation);
            HalconAPI.UnpinTuple(distance);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Store input lines described in Hesse normal form as regions.
        ///   Modified instance represents: Created regions (one for every line), clipped to maximum image format.
        /// </summary>
        /// <param name="orientation">Orientation of the normal vector in radians. Default: 0.0</param>
        /// <param name="distance">Distance from the line to the coordinate origin (0.0). Default: 200</param>
        public void GenRegionHline(double orientation, double distance)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(615);
            HalconAPI.StoreD(proc, 0, orientation);
            HalconAPI.StoreD(proc, 1, distance);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Store input lines as regions.
        ///   Modified instance represents: Created regions.
        /// </summary>
        /// <param name="beginRow">Line coordinates of the starting points of the input lines. Default: 100</param>
        /// <param name="beginCol">Column coordinates of the starting points of the input lines. Default: 50</param>
        /// <param name="endRow">Line coordinates of the ending points of the input lines. Default: 150</param>
        /// <param name="endCol">Column coordinates of the ending points of the input lines. Default: 250</param>
        public void GenRegionLine(HTuple beginRow, HTuple beginCol, HTuple endRow, HTuple endCol)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(616);
            HalconAPI.Store(proc, 0, beginRow);
            HalconAPI.Store(proc, 1, beginCol);
            HalconAPI.Store(proc, 2, endRow);
            HalconAPI.Store(proc, 3, endCol);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(beginRow);
            HalconAPI.UnpinTuple(beginCol);
            HalconAPI.UnpinTuple(endRow);
            HalconAPI.UnpinTuple(endCol);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Store input lines as regions.
        ///   Modified instance represents: Created regions.
        /// </summary>
        /// <param name="beginRow">Line coordinates of the starting points of the input lines. Default: 100</param>
        /// <param name="beginCol">Column coordinates of the starting points of the input lines. Default: 50</param>
        /// <param name="endRow">Line coordinates of the ending points of the input lines. Default: 150</param>
        /// <param name="endCol">Column coordinates of the ending points of the input lines. Default: 250</param>
        public void GenRegionLine(int beginRow, int beginCol, int endRow, int endCol)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(616);
            HalconAPI.StoreI(proc, 0, beginRow);
            HalconAPI.StoreI(proc, 1, beginCol);
            HalconAPI.StoreI(proc, 2, endRow);
            HalconAPI.StoreI(proc, 3, endCol);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create an empty region.
        ///   Modified instance represents: Empty region (no pixels).
        /// </summary>
        public void GenEmptyRegion()
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(618);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Access the thickness of a region along the main axis.
        ///   Instance represents: Region to be analysed.
        /// </summary>
        /// <param name="histogramm">Histogram of the thickness of the region along its main axis.</param>
        /// <returns>Thickness of the region along its main axis.</returns>
        public HTuple GetRegionThickness(out HTuple histogramm)
        {
            IntPtr proc = HalconAPI.PreCall(631);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out histogramm);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Polygon approximation of a region.
        ///   Instance represents: Region to be approximated.
        /// </summary>
        /// <param name="tolerance">Maximum distance between the polygon and the edge of the region. Default: 5.0</param>
        /// <param name="rows">Line numbers of the base points of the contour.</param>
        /// <param name="columns">Column numbers of the base points of the contour.</param>
        public void GetRegionPolygon(HTuple tolerance, out HTuple rows, out HTuple columns)
        {
            IntPtr proc = HalconAPI.PreCall(632);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, tolerance);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(tolerance);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out rows);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out columns);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Polygon approximation of a region.
        ///   Instance represents: Region to be approximated.
        /// </summary>
        /// <param name="tolerance">Maximum distance between the polygon and the edge of the region. Default: 5.0</param>
        /// <param name="rows">Line numbers of the base points of the contour.</param>
        /// <param name="columns">Column numbers of the base points of the contour.</param>
        public void GetRegionPolygon(double tolerance, out HTuple rows, out HTuple columns)
        {
            IntPtr proc = HalconAPI.PreCall(632);
            this.Store(proc, 1);
            HalconAPI.StoreD(proc, 0, tolerance);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out rows);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out columns);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Access the pixels of a region.
        ///   Instance represents: This region is accessed.
        /// </summary>
        /// <param name="rows">Line numbers of the pixels in the region</param>
        /// <param name="columns">Column numbers of the pixels in the region.</param>
        public void GetRegionPoints(out HTuple rows, out HTuple columns)
        {
            IntPtr proc = HalconAPI.PreCall(633);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out rows);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out columns);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Access the contour of an object.
        ///   Instance represents: Output region.
        /// </summary>
        /// <param name="rows">Line numbers of the contour pixels.</param>
        /// <param name="columns">Column numbers of the contour pixels.</param>
        public void GetRegionContour(out HTuple rows, out HTuple columns)
        {
            IntPtr proc = HalconAPI.PreCall(634);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out rows);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out columns);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Access the runlength coding of a region.
        ///   Instance represents: Output region.
        /// </summary>
        /// <param name="row">Line numbers of the chords.</param>
        /// <param name="columnBegin">Column numbers of the starting points of the chords.</param>
        /// <param name="columnEnd">Column numbers of the ending points of the chords.</param>
        public void GetRegionRuns(out HTuple row, out HTuple columnBegin, out HTuple columnEnd)
        {
            IntPtr proc = HalconAPI.PreCall(635);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out row);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out columnBegin);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, err3, out columnEnd);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Contour of an object as chain code.
        ///   Instance represents: Region to be transformed.
        /// </summary>
        /// <param name="row">Line of starting point.</param>
        /// <param name="column">Column of starting point.</param>
        /// <param name="chain">Direction code of the contour (from starting point).</param>
        public void GetRegionChain(out int row, out int column, out HTuple chain)
        {
            IntPtr proc = HalconAPI.PreCall(636);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadI(proc, 0, err1, out row);
            int err3 = HalconAPI.LoadI(proc, 1, err2, out column);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, err3, out chain);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Access convex hull as contour.
        ///   Instance represents: Output region.
        /// </summary>
        /// <param name="rows">Line numbers of contour pixels.</param>
        /// <param name="columns">Column numbers of the contour pixels.</param>
        public void GetRegionConvex(out HTuple rows, out HTuple columns)
        {
            IntPtr proc = HalconAPI.PreCall(637);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out rows);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out columns);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Classify a related group of characters with an OCR classifier.
        ///   Instance represents: Characters to be recognized.
        /// </summary>
        /// <param name="image">Gray values of the characters.</param>
        /// <param name="OCRHandle">Handle of the OCR classifier.</param>
        /// <param name="expression">Expression describing the allowed word structure.</param>
        /// <param name="numAlternatives">Number of classes per character considered for the internal word correction. Default: 3</param>
        /// <param name="numCorrections">Maximum number of corrected characters. Default: 2</param>
        /// <param name="confidence">Confidence of the class of the characters.</param>
        /// <param name="word">Word text after classification and correction.</param>
        /// <param name="score">Measure of similarity between corrected word and uncorrected classification results.</param>
        /// <returns>Result of classifying the characters with the k-NN.</returns>
        public HTuple DoOcrWordKnn(
          HImage image,
          HOCRKnn OCRHandle,
          string expression,
          int numAlternatives,
          int numCorrections,
          out HTuple confidence,
          out string word,
          out double score)
        {
            IntPtr proc = HalconAPI.PreCall(647);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)OCRHandle);
            HalconAPI.StoreS(proc, 1, expression);
            HalconAPI.StoreI(proc, 2, numAlternatives);
            HalconAPI.StoreI(proc, 3, numCorrections);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out confidence);
            int err4 = HalconAPI.LoadS(proc, 2, err3, out word);
            int procResult = HalconAPI.LoadD(proc, 3, err4, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)OCRHandle);
            return tuple;
        }

        /// <summary>
        ///   Classify a related group of characters with an OCR classifier.
        ///   Instance represents: Characters to be recognized.
        /// </summary>
        /// <param name="image">Gray values of the characters.</param>
        /// <param name="OCRHandle">Handle of the OCR classifier.</param>
        /// <param name="expression">Expression describing the allowed word structure.</param>
        /// <param name="numAlternatives">Number of classes per character considered for the internal word correction. Default: 3</param>
        /// <param name="numCorrections">Maximum number of corrected characters. Default: 2</param>
        /// <param name="confidence">Confidence of the class of the characters.</param>
        /// <param name="word">Word text after classification and correction.</param>
        /// <param name="score">Measure of similarity between corrected word and uncorrected classification results.</param>
        /// <returns>Result of classifying the characters with the k-NN.</returns>
        public string DoOcrWordKnn(
          HImage image,
          HOCRKnn OCRHandle,
          string expression,
          int numAlternatives,
          int numCorrections,
          out double confidence,
          out string word,
          out double score)
        {
            IntPtr proc = HalconAPI.PreCall(647);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)OCRHandle);
            HalconAPI.StoreS(proc, 1, expression);
            HalconAPI.StoreI(proc, 2, numAlternatives);
            HalconAPI.StoreI(proc, 3, numCorrections);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            string stringValue;
            int err2 = HalconAPI.LoadS(proc, 0, err1, out stringValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out confidence);
            int err4 = HalconAPI.LoadS(proc, 2, err3, out word);
            int procResult = HalconAPI.LoadD(proc, 3, err4, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)OCRHandle);
            return stringValue;
        }

        /// <summary>
        ///   Classify multiple characters with an k-NN classifier.
        ///   Instance represents: Characters to be recognized.
        /// </summary>
        /// <param name="image">Gray values of the characters.</param>
        /// <param name="OCRHandle">Handle of the k-NN classifier.</param>
        /// <param name="confidence">Confidence of the class of the characters.</param>
        /// <returns>Result of classifying the characters with the k-NN.</returns>
        public HTuple DoOcrMultiClassKnn(HImage image, HOCRKnn OCRHandle, out HTuple confidence)
        {
            IntPtr proc = HalconAPI.PreCall(658);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)OCRHandle);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out confidence);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)OCRHandle);
            return tuple;
        }

        /// <summary>
        ///   Classify multiple characters with an k-NN classifier.
        ///   Instance represents: Characters to be recognized.
        /// </summary>
        /// <param name="image">Gray values of the characters.</param>
        /// <param name="OCRHandle">Handle of the k-NN classifier.</param>
        /// <param name="confidence">Confidence of the class of the characters.</param>
        /// <returns>Result of classifying the characters with the k-NN.</returns>
        public string DoOcrMultiClassKnn(HImage image, HOCRKnn OCRHandle, out double confidence)
        {
            IntPtr proc = HalconAPI.PreCall(658);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)OCRHandle);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            string stringValue;
            int err2 = HalconAPI.LoadS(proc, 0, err1, out stringValue);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out confidence);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)OCRHandle);
            return stringValue;
        }

        /// <summary>
        ///   Classify a single character with an OCR classifier.
        ///   Instance represents: Character to be recognized.
        /// </summary>
        /// <param name="image">Gray values of the character.</param>
        /// <param name="OCRHandle">Handle of the k-NN classifier.</param>
        /// <param name="numClasses">Number of maximal classes to determine. Default: 1</param>
        /// <param name="numNeighbors">Number of neighbors to consider. Default: 1</param>
        /// <param name="confidence">Confidence(s) of the class(es) of the character.</param>
        /// <returns>Results of classifying the character with the k-NN.</returns>
        public HTuple DoOcrSingleClassKnn(
          HImage image,
          HOCRKnn OCRHandle,
          HTuple numClasses,
          HTuple numNeighbors,
          out HTuple confidence)
        {
            IntPtr proc = HalconAPI.PreCall(659);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)OCRHandle);
            HalconAPI.Store(proc, 1, numClasses);
            HalconAPI.Store(proc, 2, numNeighbors);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(numClasses);
            HalconAPI.UnpinTuple(numNeighbors);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out confidence);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)OCRHandle);
            return tuple;
        }

        /// <summary>
        ///   Classify a single character with an OCR classifier.
        ///   Instance represents: Character to be recognized.
        /// </summary>
        /// <param name="image">Gray values of the character.</param>
        /// <param name="OCRHandle">Handle of the k-NN classifier.</param>
        /// <param name="numClasses">Number of maximal classes to determine. Default: 1</param>
        /// <param name="numNeighbors">Number of neighbors to consider. Default: 1</param>
        /// <param name="confidence">Confidence(s) of the class(es) of the character.</param>
        /// <returns>Results of classifying the character with the k-NN.</returns>
        public string DoOcrSingleClassKnn(
          HImage image,
          HOCRKnn OCRHandle,
          HTuple numClasses,
          HTuple numNeighbors,
          out double confidence)
        {
            IntPtr proc = HalconAPI.PreCall(659);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)OCRHandle);
            HalconAPI.Store(proc, 1, numClasses);
            HalconAPI.Store(proc, 2, numNeighbors);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(numClasses);
            HalconAPI.UnpinTuple(numNeighbors);
            string stringValue;
            int err2 = HalconAPI.LoadS(proc, 0, err1, out stringValue);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out confidence);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)OCRHandle);
            return stringValue;
        }

        /// <summary>
        ///   Classify a related group of characters with an OCR classifier.
        ///   Instance represents: Characters to be recognized.
        /// </summary>
        /// <param name="image">Gray values of the characters.</param>
        /// <param name="OCRHandle">Handle of the OCR classifier.</param>
        /// <param name="expression">Expression describing the allowed word structure.</param>
        /// <param name="numAlternatives">Number of classes per character considered for the internal word correction. Default: 3</param>
        /// <param name="numCorrections">Maximum number of corrected characters. Default: 2</param>
        /// <param name="word">Word text after classification and correction.</param>
        /// <param name="score">Measure of similarity between corrected word and uncorrected classification results.</param>
        /// <returns>Result of classifying the characters with the SVM.</returns>
        public HTuple DoOcrWordSvm(
          HImage image,
          HOCRSvm OCRHandle,
          string expression,
          int numAlternatives,
          int numCorrections,
          out string word,
          out double score)
        {
            IntPtr proc = HalconAPI.PreCall(679);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)OCRHandle);
            HalconAPI.StoreS(proc, 1, expression);
            HalconAPI.StoreI(proc, 2, numAlternatives);
            HalconAPI.StoreI(proc, 3, numCorrections);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int err3 = HalconAPI.LoadS(proc, 1, err2, out word);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)OCRHandle);
            return tuple;
        }

        /// <summary>
        ///   Classify multiple characters with an SVM-based OCR classifier.
        ///   Instance represents: Characters to be recognized.
        /// </summary>
        /// <param name="image">Gray values of the characters.</param>
        /// <param name="OCRHandle">Handle of the OCR classifier.</param>
        /// <returns>Result of classifying the characters with the SVM.</returns>
        public HTuple DoOcrMultiClassSvm(HImage image, HOCRSvm OCRHandle)
        {
            IntPtr proc = HalconAPI.PreCall(680);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)OCRHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)OCRHandle);
            return tuple;
        }

        /// <summary>
        ///   Classify a single character with an SVM-based OCR classifier.
        ///   Instance represents: Character to be recognized.
        /// </summary>
        /// <param name="image">Gray values of the character.</param>
        /// <param name="OCRHandle">Handle of the OCR classifier.</param>
        /// <param name="num">Number of best classes to determine. Default: 1</param>
        /// <returns>Result of classifying the character with the SVM.</returns>
        public HTuple DoOcrSingleClassSvm(HImage image, HOCRSvm OCRHandle, HTuple num)
        {
            IntPtr proc = HalconAPI.PreCall(681);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)OCRHandle);
            HalconAPI.Store(proc, 1, num);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(num);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)OCRHandle);
            return tuple;
        }

        /// <summary>
        ///   Classify a related group of characters with an OCR classifier.
        ///   Instance represents: Characters to be recognized.
        /// </summary>
        /// <param name="image">Gray values of the characters.</param>
        /// <param name="OCRHandle">Handle of the OCR classifier.</param>
        /// <param name="expression">Expression describing the allowed word structure.</param>
        /// <param name="numAlternatives">Number of classes per character considered for the internal word correction. Default: 3</param>
        /// <param name="numCorrections">Maximum number of corrected characters. Default: 2</param>
        /// <param name="confidence">Confidence of the class of the characters.</param>
        /// <param name="word">Word text after classification and correction.</param>
        /// <param name="score">Measure of similarity between corrected word and uncorrected classification results.</param>
        /// <returns>Result of classifying the characters with the MLP.</returns>
        public HTuple DoOcrWordMlp(
          HImage image,
          HOCRMlp OCRHandle,
          string expression,
          int numAlternatives,
          int numCorrections,
          out HTuple confidence,
          out string word,
          out double score)
        {
            IntPtr proc = HalconAPI.PreCall(697);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)OCRHandle);
            HalconAPI.StoreS(proc, 1, expression);
            HalconAPI.StoreI(proc, 2, numAlternatives);
            HalconAPI.StoreI(proc, 3, numCorrections);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out confidence);
            int err4 = HalconAPI.LoadS(proc, 2, err3, out word);
            int procResult = HalconAPI.LoadD(proc, 3, err4, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)OCRHandle);
            return tuple;
        }

        /// <summary>
        ///   Classify a related group of characters with an OCR classifier.
        ///   Instance represents: Characters to be recognized.
        /// </summary>
        /// <param name="image">Gray values of the characters.</param>
        /// <param name="OCRHandle">Handle of the OCR classifier.</param>
        /// <param name="expression">Expression describing the allowed word structure.</param>
        /// <param name="numAlternatives">Number of classes per character considered for the internal word correction. Default: 3</param>
        /// <param name="numCorrections">Maximum number of corrected characters. Default: 2</param>
        /// <param name="confidence">Confidence of the class of the characters.</param>
        /// <param name="word">Word text after classification and correction.</param>
        /// <param name="score">Measure of similarity between corrected word and uncorrected classification results.</param>
        /// <returns>Result of classifying the characters with the MLP.</returns>
        public string DoOcrWordMlp(
          HImage image,
          HOCRMlp OCRHandle,
          string expression,
          int numAlternatives,
          int numCorrections,
          out double confidence,
          out string word,
          out double score)
        {
            IntPtr proc = HalconAPI.PreCall(697);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)OCRHandle);
            HalconAPI.StoreS(proc, 1, expression);
            HalconAPI.StoreI(proc, 2, numAlternatives);
            HalconAPI.StoreI(proc, 3, numCorrections);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            string stringValue;
            int err2 = HalconAPI.LoadS(proc, 0, err1, out stringValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out confidence);
            int err4 = HalconAPI.LoadS(proc, 2, err3, out word);
            int procResult = HalconAPI.LoadD(proc, 3, err4, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)OCRHandle);
            return stringValue;
        }

        /// <summary>
        ///   Classify multiple characters with an OCR classifier.
        ///   Instance represents: Characters to be recognized.
        /// </summary>
        /// <param name="image">Gray values of the characters.</param>
        /// <param name="OCRHandle">Handle of the OCR classifier.</param>
        /// <param name="confidence">Confidence of the class of the characters.</param>
        /// <returns>Result of classifying the characters with the MLP.</returns>
        public HTuple DoOcrMultiClassMlp(HImage image, HOCRMlp OCRHandle, out HTuple confidence)
        {
            IntPtr proc = HalconAPI.PreCall(698);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)OCRHandle);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out confidence);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)OCRHandle);
            return tuple;
        }

        /// <summary>
        ///   Classify multiple characters with an OCR classifier.
        ///   Instance represents: Characters to be recognized.
        /// </summary>
        /// <param name="image">Gray values of the characters.</param>
        /// <param name="OCRHandle">Handle of the OCR classifier.</param>
        /// <param name="confidence">Confidence of the class of the characters.</param>
        /// <returns>Result of classifying the characters with the MLP.</returns>
        public string DoOcrMultiClassMlp(HImage image, HOCRMlp OCRHandle, out double confidence)
        {
            IntPtr proc = HalconAPI.PreCall(698);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)OCRHandle);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            string stringValue;
            int err2 = HalconAPI.LoadS(proc, 0, err1, out stringValue);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out confidence);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)OCRHandle);
            return stringValue;
        }

        /// <summary>
        ///   Classify a single character with an OCR classifier.
        ///   Instance represents: Character to be recognized.
        /// </summary>
        /// <param name="image">Gray values of the character.</param>
        /// <param name="OCRHandle">Handle of the OCR classifier.</param>
        /// <param name="num">Number of best classes to determine. Default: 1</param>
        /// <param name="confidence">Confidence(s) of the class(es) of the character.</param>
        /// <returns>Result of classifying the character with the MLP.</returns>
        public HTuple DoOcrSingleClassMlp(
          HImage image,
          HOCRMlp OCRHandle,
          HTuple num,
          out HTuple confidence)
        {
            IntPtr proc = HalconAPI.PreCall(699);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)OCRHandle);
            HalconAPI.Store(proc, 1, num);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(num);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out confidence);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)OCRHandle);
            return tuple;
        }

        /// <summary>
        ///   Classify a single character with an OCR classifier.
        ///   Instance represents: Character to be recognized.
        /// </summary>
        /// <param name="image">Gray values of the character.</param>
        /// <param name="OCRHandle">Handle of the OCR classifier.</param>
        /// <param name="num">Number of best classes to determine. Default: 1</param>
        /// <param name="confidence">Confidence(s) of the class(es) of the character.</param>
        /// <returns>Result of classifying the character with the MLP.</returns>
        public string DoOcrSingleClassMlp(
          HImage image,
          HOCRMlp OCRHandle,
          HTuple num,
          out double confidence)
        {
            IntPtr proc = HalconAPI.PreCall(699);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)OCRHandle);
            HalconAPI.Store(proc, 1, num);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(num);
            string stringValue;
            int err2 = HalconAPI.LoadS(proc, 0, err1, out stringValue);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out confidence);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)OCRHandle);
            return stringValue;
        }

        /// <summary>
        ///   Classify one character.
        ///   Instance represents: Character to be recognized.
        /// </summary>
        /// <param name="image">Gray values of the characters.</param>
        /// <param name="ocrHandle">ID of the OCR classifier.</param>
        /// <param name="confidences">Confidence values of the characters.</param>
        /// <returns>Classes (names) of the characters.</returns>
        public HTuple DoOcrSingle(HImage image, HOCRBox ocrHandle, out HTuple confidences)
        {
            IntPtr proc = HalconAPI.PreCall(713);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)ocrHandle);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out confidences);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)ocrHandle);
            return tuple;
        }

        /// <summary>
        ///   Classify characters.
        ///   Instance represents: Characters to be recognized.
        /// </summary>
        /// <param name="image">Gray values for the characters.</param>
        /// <param name="ocrHandle">ID of the OCR classifier.</param>
        /// <param name="confidence">Confidence values of the characters.</param>
        /// <returns>Class (name) of the characters.</returns>
        public HTuple DoOcrMulti(HImage image, HOCRBox ocrHandle, out HTuple confidence)
        {
            IntPtr proc = HalconAPI.PreCall(714);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)ocrHandle);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out confidence);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)ocrHandle);
            return tuple;
        }

        /// <summary>
        ///   Classify characters.
        ///   Instance represents: Characters to be recognized.
        /// </summary>
        /// <param name="image">Gray values for the characters.</param>
        /// <param name="ocrHandle">ID of the OCR classifier.</param>
        /// <param name="confidence">Confidence values of the characters.</param>
        /// <returns>Class (name) of the characters.</returns>
        public string DoOcrMulti(HImage image, HOCRBox ocrHandle, out double confidence)
        {
            IntPtr proc = HalconAPI.PreCall(714);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)ocrHandle);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            string stringValue;
            int err2 = HalconAPI.LoadS(proc, 0, err1, out stringValue);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out confidence);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)ocrHandle);
            return stringValue;
        }

        /// <summary>
        ///   Train an OCR classifier by the input of regions.
        ///   Instance represents: Characters to be trained.
        /// </summary>
        /// <param name="image">Gray values for the characters.</param>
        /// <param name="ocrHandle">ID of the desired OCR-classifier.</param>
        /// <param name="classVal">Class (name) of the characters. Default: "a"</param>
        /// <returns>Average confidence during a re-classification of the trained characters.</returns>
        public double TraindOcrClassBox(HImage image, HOCRBox ocrHandle, HTuple classVal)
        {
            IntPtr proc = HalconAPI.PreCall(717);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)ocrHandle);
            HalconAPI.Store(proc, 1, classVal);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(classVal);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)ocrHandle);
            return doubleValue;
        }

        /// <summary>
        ///   Train an OCR classifier by the input of regions.
        ///   Instance represents: Characters to be trained.
        /// </summary>
        /// <param name="image">Gray values for the characters.</param>
        /// <param name="ocrHandle">ID of the desired OCR-classifier.</param>
        /// <param name="classVal">Class (name) of the characters. Default: "a"</param>
        /// <returns>Average confidence during a re-classification of the trained characters.</returns>
        public double TraindOcrClassBox(HImage image, HOCRBox ocrHandle, string classVal)
        {
            IntPtr proc = HalconAPI.PreCall(717);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)ocrHandle);
            HalconAPI.StoreS(proc, 1, classVal);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)ocrHandle);
            return doubleValue;
        }

        /// <summary>Protection of training data.</summary>
        /// <param name="trainingFile">Names of the training files. Default: ""</param>
        /// <param name="password">Passwords for protecting the training files.</param>
        /// <param name="trainingFileProtected">Names of the protected training files.</param>
        public static void ProtectOcrTrainf(
          string trainingFile,
          HTuple password,
          string trainingFileProtected)
        {
            IntPtr proc = HalconAPI.PreCall(719);
            HalconAPI.StoreS(proc, 0, trainingFile);
            HalconAPI.Store(proc, 1, password);
            HalconAPI.StoreS(proc, 2, trainingFileProtected);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(password);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Protection of training data.</summary>
        /// <param name="trainingFile">Names of the training files. Default: ""</param>
        /// <param name="password">Passwords for protecting the training files.</param>
        /// <param name="trainingFileProtected">Names of the protected training files.</param>
        public static void ProtectOcrTrainf(
          string trainingFile,
          string password,
          string trainingFileProtected)
        {
            IntPtr proc = HalconAPI.PreCall(719);
            HalconAPI.StoreS(proc, 0, trainingFile);
            HalconAPI.StoreS(proc, 1, password);
            HalconAPI.StoreS(proc, 2, trainingFileProtected);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>
        ///   Storing of training characters into a file.
        ///   Instance represents: Characters to be trained.
        /// </summary>
        /// <param name="image">Gray values of the characters.</param>
        /// <param name="classVal">Class (name) of the characters.</param>
        /// <param name="trainingFile">Name of the training file. Default: "train_ocr"</param>
        public void WriteOcrTrainf(HImage image, HTuple classVal, string trainingFile)
        {
            IntPtr proc = HalconAPI.PreCall(720);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, classVal);
            HalconAPI.StoreS(proc, 1, trainingFile);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(classVal);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Storing of training characters into a file.
        ///   Instance represents: Characters to be trained.
        /// </summary>
        /// <param name="image">Gray values of the characters.</param>
        /// <param name="classVal">Class (name) of the characters.</param>
        /// <param name="trainingFile">Name of the training file. Default: "train_ocr"</param>
        public void WriteOcrTrainf(HImage image, string classVal, string trainingFile)
        {
            IntPtr proc = HalconAPI.PreCall(720);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.StoreS(proc, 0, classVal);
            HalconAPI.StoreS(proc, 1, trainingFile);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Sorting of regions with respect to their relative position.
        ///   Instance represents: Regions to be sorted.
        /// </summary>
        /// <param name="sortMode">Kind of sorting. Default: "first_point"</param>
        /// <param name="order">Increasing or decreasing sorting order. Default: "true"</param>
        /// <param name="rowOrCol">Sorting first with respect to row, then to column. Default: "row"</param>
        /// <returns>Sorted regions.</returns>
        public HRegion SortRegion(string sortMode, string order, string rowOrCol)
        {
            IntPtr proc = HalconAPI.PreCall(723);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, sortMode);
            HalconAPI.StoreS(proc, 1, order);
            HalconAPI.StoreS(proc, 2, rowOrCol);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Test an OCR classifier.
        ///   Instance represents: Characters to be tested.
        /// </summary>
        /// <param name="image">Gray values for the characters.</param>
        /// <param name="ocrHandle">ID of the desired OCR-classifier.</param>
        /// <param name="classVal">Class (name) of the characters. Default: "a"</param>
        /// <returns>Confidence for the character to belong to the class.</returns>
        public HTuple TestdOcrClassBox(HImage image, HOCRBox ocrHandle, HTuple classVal)
        {
            IntPtr proc = HalconAPI.PreCall(725);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)ocrHandle);
            HalconAPI.Store(proc, 1, classVal);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(classVal);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)ocrHandle);
            return tuple;
        }

        /// <summary>
        ///   Test an OCR classifier.
        ///   Instance represents: Characters to be tested.
        /// </summary>
        /// <param name="image">Gray values for the characters.</param>
        /// <param name="ocrHandle">ID of the desired OCR-classifier.</param>
        /// <param name="classVal">Class (name) of the characters. Default: "a"</param>
        /// <returns>Confidence for the character to belong to the class.</returns>
        public double TestdOcrClassBox(HImage image, HOCRBox ocrHandle, string classVal)
        {
            IntPtr proc = HalconAPI.PreCall(725);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)ocrHandle);
            HalconAPI.StoreS(proc, 1, classVal);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)ocrHandle);
            return doubleValue;
        }

        /// <summary>
        ///   Add characters to a training file.
        ///   Instance represents: Characters to be trained.
        /// </summary>
        /// <param name="image">Gray values of the characters.</param>
        /// <param name="classVal">Class (name) of the characters.</param>
        /// <param name="trainingFile">Name of the training file. Default: "train_ocr"</param>
        public void AppendOcrTrainf(HImage image, HTuple classVal, string trainingFile)
        {
            IntPtr proc = HalconAPI.PreCall(730);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, classVal);
            HalconAPI.StoreS(proc, 1, trainingFile);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(classVal);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Add characters to a training file.
        ///   Instance represents: Characters to be trained.
        /// </summary>
        /// <param name="image">Gray values of the characters.</param>
        /// <param name="classVal">Class (name) of the characters.</param>
        /// <param name="trainingFile">Name of the training file. Default: "train_ocr"</param>
        public void AppendOcrTrainf(HImage image, string classVal, string trainingFile)
        {
            IntPtr proc = HalconAPI.PreCall(730);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.StoreS(proc, 0, classVal);
            HalconAPI.StoreS(proc, 1, trainingFile);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Prune the branches of a region.
        ///   Instance represents: Regions to be processed.
        /// </summary>
        /// <param name="length">Length of the branches to be removed. Default: 2</param>
        /// <returns>Result of the pruning operation.</returns>
        public HRegion Pruning(int length)
        {
            IntPtr proc = HalconAPI.PreCall(735);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, length);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Reduce a region to its boundary.
        ///   Instance represents: Regions for which the boundary is to be computed.
        /// </summary>
        /// <param name="boundaryType">Boundary type. Default: "inner"</param>
        /// <returns>Resulting boundaries.</returns>
        public HRegion Boundary(string boundaryType)
        {
            IntPtr proc = HalconAPI.PreCall(736);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, boundaryType);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Perform a closing after an opening with multiple structuring elements.
        ///   Instance represents: Regions to be processed.
        /// </summary>
        /// <param name="structElements">Structuring elements.</param>
        /// <returns>Fitted regions.</returns>
        public HRegion Fitting(HRegion structElements)
        {
            IntPtr proc = HalconAPI.PreCall(737);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)structElements);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)structElements);
            return hregion;
        }

        /// <summary>
        ///   Generate standard structuring elements.
        ///   Modified instance represents: Generated structuring elements.
        /// </summary>
        /// <param name="type">Type of structuring element to generate. Default: "noise"</param>
        /// <param name="row">Row coordinate of the reference point. Default: 1</param>
        /// <param name="column">Column coordinate of the reference point. Default: 1</param>
        public void GenStructElements(string type, int row, int column)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(738);
            HalconAPI.StoreS(proc, 0, type);
            HalconAPI.StoreI(proc, 1, row);
            HalconAPI.StoreI(proc, 2, column);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Reflect a region about a point.
        ///   Instance represents: Region to be reflected.
        /// </summary>
        /// <param name="row">Row coordinate of the reference point. Default: 0</param>
        /// <param name="column">Column coordinate of the reference point. Default: 0</param>
        /// <returns>Transposed region.</returns>
        public HRegion TransposeRegion(int row, int column)
        {
            IntPtr proc = HalconAPI.PreCall(739);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, row);
            HalconAPI.StoreI(proc, 1, column);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Remove the result of a hit-or-miss operation from a region (sequential).
        ///   Instance represents: Regions to be processed.
        /// </summary>
        /// <param name="golayElement">Structuring element from the Golay alphabet. Default: "l"</param>
        /// <param name="iterations">Number of iterations. For 'f', 'f2', 'h' and 'i' the only useful value is 1. Default: 20</param>
        /// <returns>Result of the thinning operator.</returns>
        public HRegion ThinningSeq(string golayElement, HTuple iterations)
        {
            IntPtr proc = HalconAPI.PreCall(740);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, golayElement);
            HalconAPI.Store(proc, 1, iterations);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(iterations);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Remove the result of a hit-or-miss operation from a region (sequential).
        ///   Instance represents: Regions to be processed.
        /// </summary>
        /// <param name="golayElement">Structuring element from the Golay alphabet. Default: "l"</param>
        /// <param name="iterations">Number of iterations. For 'f', 'f2', 'h' and 'i' the only useful value is 1. Default: 20</param>
        /// <returns>Result of the thinning operator.</returns>
        public HRegion ThinningSeq(string golayElement, int iterations)
        {
            IntPtr proc = HalconAPI.PreCall(740);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, golayElement);
            HalconAPI.StoreI(proc, 1, iterations);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Remove the result of a hit-or-miss operation from a region (using a Golay structuring element).
        ///   Instance represents: Regions to be processed.
        /// </summary>
        /// <param name="golayElement">Structuring element from the Golay alphabet. Default: "h"</param>
        /// <param name="rotation">Rotation of the Golay element. Depending on the element, not all rotations are valid. Default: 0</param>
        /// <returns>Result of the thinning operator.</returns>
        public HRegion ThinningGolay(string golayElement, int rotation)
        {
            IntPtr proc = HalconAPI.PreCall(741);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, golayElement);
            HalconAPI.StoreI(proc, 1, rotation);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Remove the result of a hit-or-miss operation from a region.
        ///   Instance represents: Regions to be processed.
        /// </summary>
        /// <param name="structElement1">Structuring element for the foreground.</param>
        /// <param name="structElement2">Structuring element for the background.</param>
        /// <param name="row">Row coordinate of the reference point. Default: 0</param>
        /// <param name="column">Column coordinate of the reference point. Default: 0</param>
        /// <param name="iterations">Number of iterations. Default: 1</param>
        /// <returns>Result of the thinning operator.</returns>
        public HRegion Thinning(
          HRegion structElement1,
          HRegion structElement2,
          int row,
          int column,
          int iterations)
        {
            IntPtr proc = HalconAPI.PreCall(742);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)structElement1);
            HalconAPI.Store(proc, 3, (HObjectBase)structElement2);
            HalconAPI.StoreI(proc, 0, row);
            HalconAPI.StoreI(proc, 1, column);
            HalconAPI.StoreI(proc, 2, iterations);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)structElement1);
            GC.KeepAlive((object)structElement2);
            return hregion;
        }

        /// <summary>
        ///   Add the result of a hit-or-miss operation to a region (sequential).
        ///   Instance represents: Regions to be processed.
        /// </summary>
        /// <param name="golayElement">Structuring element from the Golay alphabet. Default: "h"</param>
        /// <param name="iterations">Number of iterations. Default: 1</param>
        /// <returns>Result of the thickening operator.</returns>
        public HRegion ThickeningSeq(string golayElement, int iterations)
        {
            IntPtr proc = HalconAPI.PreCall(743);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, golayElement);
            HalconAPI.StoreI(proc, 1, iterations);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Add the result of a hit-or-miss operation to a region (using a Golay structuring element).
        ///   Instance represents: Regions to be processed.
        /// </summary>
        /// <param name="golayElement">Structuring element from the Golay alphabet. Default: "h"</param>
        /// <param name="rotation">Rotation of the Golay element. Depending on the element, not all rotations are valid. Default: 0</param>
        /// <returns>Result of the thickening operator.</returns>
        public HRegion ThickeningGolay(string golayElement, int rotation)
        {
            IntPtr proc = HalconAPI.PreCall(744);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, golayElement);
            HalconAPI.StoreI(proc, 1, rotation);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Add the result of a hit-or-miss operation to a region.
        ///   Instance represents: Regions to be processed.
        /// </summary>
        /// <param name="structElement1">Structuring element for the foreground.</param>
        /// <param name="structElement2">Structuring element for the background.</param>
        /// <param name="row">Row coordinate of the reference point. Default: 16</param>
        /// <param name="column">Column coordinate of the reference point. Default: 16</param>
        /// <param name="iterations">Number of iterations. Default: 1</param>
        /// <returns>Result of the thickening operator.</returns>
        public HRegion Thickening(
          HRegion structElement1,
          HRegion structElement2,
          int row,
          int column,
          int iterations)
        {
            IntPtr proc = HalconAPI.PreCall(745);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)structElement1);
            HalconAPI.Store(proc, 3, (HObjectBase)structElement2);
            HalconAPI.StoreI(proc, 0, row);
            HalconAPI.StoreI(proc, 1, column);
            HalconAPI.StoreI(proc, 2, iterations);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)structElement1);
            GC.KeepAlive((object)structElement2);
            return hregion;
        }

        /// <summary>
        ///   Hit-or-miss operation for regions using the Golay alphabet (sequential).
        ///   Instance represents: Regions to be processed.
        /// </summary>
        /// <param name="golayElement">Structuring element from the Golay alphabet. Default: "h"</param>
        /// <returns>Result of the hit-or-miss operation.</returns>
        public HRegion HitOrMissSeq(string golayElement)
        {
            IntPtr proc = HalconAPI.PreCall(746);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, golayElement);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Hit-or-miss operation for regions using the Golay alphabet.
        ///   Instance represents: Regions to be processed.
        /// </summary>
        /// <param name="golayElement">Structuring element from the Golay alphabet. Default: "h"</param>
        /// <param name="rotation">Rotation of the Golay element. Depending on the element, not all rotations are valid. Default: 0</param>
        /// <returns>Result of the hit-or-miss operation.</returns>
        public HRegion HitOrMissGolay(string golayElement, int rotation)
        {
            IntPtr proc = HalconAPI.PreCall(747);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, golayElement);
            HalconAPI.StoreI(proc, 1, rotation);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Hit-or-miss operation for regions.
        ///   Instance represents: Regions to be processed.
        /// </summary>
        /// <param name="structElement1">Erosion mask for the input regions.</param>
        /// <param name="structElement2">Erosion mask for the complements of the input regions.</param>
        /// <param name="row">Row coordinate of the reference point. Default: 16</param>
        /// <param name="column">Column coordinate of the reference point. Default: 16</param>
        /// <returns>Result of the hit-or-miss operation.</returns>
        public HRegion HitOrMiss(
          HRegion structElement1,
          HRegion structElement2,
          int row,
          int column)
        {
            IntPtr proc = HalconAPI.PreCall(748);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)structElement1);
            HalconAPI.Store(proc, 3, (HObjectBase)structElement2);
            HalconAPI.StoreI(proc, 0, row);
            HalconAPI.StoreI(proc, 1, column);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)structElement1);
            GC.KeepAlive((object)structElement2);
            return hregion;
        }

        /// <summary>
        ///   Generate the structuring elements of the Golay alphabet.
        ///   Modified instance represents: Structuring element for the foreground.
        /// </summary>
        /// <param name="golayElement">Name of the structuring element. Default: "l"</param>
        /// <param name="rotation">Rotation of the Golay element. Depending on the element, not all rotations are valid. Default: 0</param>
        /// <param name="row">Row coordinate of the reference point. Default: 16</param>
        /// <param name="column">Column coordinate of the reference point. Default: 16</param>
        /// <returns>Structuring element for the background.</returns>
        public HRegion GolayElements(string golayElement, int rotation, int row, int column)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(749);
            HalconAPI.StoreS(proc, 0, golayElement);
            HalconAPI.StoreI(proc, 1, rotation);
            HalconAPI.StoreI(proc, 2, row);
            HalconAPI.StoreI(proc, 3, column);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = this.Load(proc, 1, err1);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 2, err2, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Thinning of a region.
        ///   Instance represents: Regions to be thinned.
        /// </summary>
        /// <param name="iterations1">Number of iterations for the sequential thinning with the element 'l' of the Golay alphabet. Default: 100</param>
        /// <param name="iterations2">Number of iterations for the sequential thinning with the element 'e' of the Golay alphabet. Default: 1</param>
        /// <returns>Result of the skiz operator.</returns>
        public HRegion MorphSkiz(HTuple iterations1, HTuple iterations2)
        {
            IntPtr proc = HalconAPI.PreCall(750);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, iterations1);
            HalconAPI.Store(proc, 1, iterations2);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(iterations1);
            HalconAPI.UnpinTuple(iterations2);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Thinning of a region.
        ///   Instance represents: Regions to be thinned.
        /// </summary>
        /// <param name="iterations1">Number of iterations for the sequential thinning with the element 'l' of the Golay alphabet. Default: 100</param>
        /// <param name="iterations2">Number of iterations for the sequential thinning with the element 'e' of the Golay alphabet. Default: 1</param>
        /// <returns>Result of the skiz operator.</returns>
        public HRegion MorphSkiz(int iterations1, int iterations2)
        {
            IntPtr proc = HalconAPI.PreCall(750);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, iterations1);
            HalconAPI.StoreI(proc, 1, iterations2);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Compute the morphological skeleton of a region.
        ///   Instance represents: Regions to be processed.
        /// </summary>
        /// <returns>Resulting morphological skeleton.</returns>
        public HRegion MorphSkeleton()
        {
            IntPtr proc = HalconAPI.PreCall(751);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Compute the union of bottom_hat and top_hat.
        ///   Instance represents: Regions to be processed.
        /// </summary>
        /// <param name="structElement">Structuring element (position-invariant).</param>
        /// <returns>Union of top hat and bottom hat.</returns>
        public HRegion MorphHat(HRegion structElement)
        {
            IntPtr proc = HalconAPI.PreCall(752);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)structElement);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)structElement);
            return hregion;
        }

        /// <summary>
        ///   Compute the bottom hat of regions.
        ///   Instance represents: Regions to be processed.
        /// </summary>
        /// <param name="structElement">Structuring element (position independent).</param>
        /// <returns>Result of the bottom hat operator.</returns>
        public HRegion BottomHat(HRegion structElement)
        {
            IntPtr proc = HalconAPI.PreCall(753);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)structElement);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)structElement);
            return hregion;
        }

        /// <summary>
        ///   Compute the top hat of regions.
        ///   Instance represents: Regions to be processed.
        /// </summary>
        /// <param name="structElement">Structuring element (position independent).</param>
        /// <returns>Result of the top hat operator.</returns>
        public HRegion TopHat(HRegion structElement)
        {
            IntPtr proc = HalconAPI.PreCall(754);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)structElement);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)structElement);
            return hregion;
        }

        /// <summary>
        ///   Erode a region (using a reference point).
        ///   Instance represents: Regions to be eroded.
        /// </summary>
        /// <param name="structElement">Structuring element.</param>
        /// <param name="row">Row coordinate of the reference point. Default: 0</param>
        /// <param name="column">Column coordinate of the reference point. Default: 0</param>
        /// <param name="iterations">Number of iterations. Default: 1</param>
        /// <returns>Eroded regions.</returns>
        public HRegion MinkowskiSub2(
          HRegion structElement,
          int row,
          int column,
          int iterations)
        {
            IntPtr proc = HalconAPI.PreCall(755);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)structElement);
            HalconAPI.StoreI(proc, 0, row);
            HalconAPI.StoreI(proc, 1, column);
            HalconAPI.StoreI(proc, 2, iterations);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)structElement);
            return hregion;
        }

        /// <summary>
        ///   Erode a region.
        ///   Instance represents: Regions to be eroded.
        /// </summary>
        /// <param name="structElement">Structuring element.</param>
        /// <param name="iterations">Number of iterations. Default: 1</param>
        /// <returns>Eroded regions.</returns>
        public HRegion MinkowskiSub1(HRegion structElement, int iterations)
        {
            IntPtr proc = HalconAPI.PreCall(756);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)structElement);
            HalconAPI.StoreI(proc, 0, iterations);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)structElement);
            return hregion;
        }

        /// <summary>
        ///   Dilate a region (using a reference point).
        ///   Instance represents: Regions to be dilated.
        /// </summary>
        /// <param name="structElement">Structuring element.</param>
        /// <param name="row">Row coordinate of the reference point.</param>
        /// <param name="column">Column coordinate of the reference point.</param>
        /// <param name="iterations">Number of iterations. Default: 1</param>
        /// <returns>Dilated regions.</returns>
        public HRegion MinkowskiAdd2(
          HRegion structElement,
          int row,
          int column,
          int iterations)
        {
            IntPtr proc = HalconAPI.PreCall(757);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)structElement);
            HalconAPI.StoreI(proc, 0, row);
            HalconAPI.StoreI(proc, 1, column);
            HalconAPI.StoreI(proc, 2, iterations);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)structElement);
            return hregion;
        }

        /// <summary>
        ///   Perform a Minkowski addition on a region.
        ///   Instance represents: Regions to be dilated.
        /// </summary>
        /// <param name="structElement">Structuring element.</param>
        /// <param name="iterations">Number of iterations. Default: 1</param>
        /// <returns>Dilated regions.</returns>
        public HRegion MinkowskiAdd1(HRegion structElement, int iterations)
        {
            IntPtr proc = HalconAPI.PreCall(758);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)structElement);
            HalconAPI.StoreI(proc, 0, iterations);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)structElement);
            return hregion;
        }

        /// <summary>
        ///   Close a region with a rectangular structuring element.
        ///   Instance represents: Regions to be closed.
        /// </summary>
        /// <param name="width">Width of the structuring rectangle. Default: 10</param>
        /// <param name="height">Height of the structuring rectangle. Default: 10</param>
        /// <returns>Closed regions.</returns>
        public HRegion ClosingRectangle1(int width, int height)
        {
            IntPtr proc = HalconAPI.PreCall(759);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, width);
            HalconAPI.StoreI(proc, 1, height);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Close a region with an element from the Golay alphabet.
        ///   Instance represents: Regions to be closed.
        /// </summary>
        /// <param name="golayElement">Structuring element from the Golay alphabet. Default: "h"</param>
        /// <param name="rotation">Rotation of the Golay element. Depending on the element, not all rotations are valid. Default: 0</param>
        /// <returns>Closed regions.</returns>
        public HRegion ClosingGolay(string golayElement, int rotation)
        {
            IntPtr proc = HalconAPI.PreCall(760);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, golayElement);
            HalconAPI.StoreI(proc, 1, rotation);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Close a region with a circular structuring element.
        ///   Instance represents: Regions to be closed.
        /// </summary>
        /// <param name="radius">Radius of the circular structuring element. Default: 3.5</param>
        /// <returns>Closed regions.</returns>
        public HRegion ClosingCircle(HTuple radius)
        {
            IntPtr proc = HalconAPI.PreCall(761);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, radius);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(radius);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Close a region with a circular structuring element.
        ///   Instance represents: Regions to be closed.
        /// </summary>
        /// <param name="radius">Radius of the circular structuring element. Default: 3.5</param>
        /// <returns>Closed regions.</returns>
        public HRegion ClosingCircle(double radius)
        {
            IntPtr proc = HalconAPI.PreCall(761);
            this.Store(proc, 1);
            HalconAPI.StoreD(proc, 0, radius);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Close a region.
        ///   Instance represents: Regions to be closed.
        /// </summary>
        /// <param name="structElement">Structuring element (position-invariant).</param>
        /// <returns>Closed regions.</returns>
        public HRegion Closing(HRegion structElement)
        {
            IntPtr proc = HalconAPI.PreCall(762);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)structElement);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)structElement);
            return hregion;
        }

        /// <summary>
        ///   Separate overlapping regions.
        ///   Instance represents: Regions to be opened.
        /// </summary>
        /// <param name="structElement">Structuring element (position-invariant).</param>
        /// <returns>Opened regions.</returns>
        public HRegion OpeningSeg(HRegion structElement)
        {
            IntPtr proc = HalconAPI.PreCall(763);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)structElement);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)structElement);
            return hregion;
        }

        /// <summary>
        ///   Open a region with an element from the Golay alphabet.
        ///   Instance represents: Regions to be opened.
        /// </summary>
        /// <param name="golayElement">Structuring element from the Golay alphabet. Default: "h"</param>
        /// <param name="rotation">Rotation of the Golay element. Depending on the element, not all rotations are valid. Default: 0</param>
        /// <returns>Opened regions.</returns>
        public HRegion OpeningGolay(string golayElement, int rotation)
        {
            IntPtr proc = HalconAPI.PreCall(764);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, golayElement);
            HalconAPI.StoreI(proc, 1, rotation);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Open a region with a rectangular structuring element.
        ///   Instance represents: Regions to be opened.
        /// </summary>
        /// <param name="width">Width of the structuring rectangle. Default: 10</param>
        /// <param name="height">Height of the structuring rectangle. Default: 10</param>
        /// <returns>Opened regions.</returns>
        public HRegion OpeningRectangle1(int width, int height)
        {
            IntPtr proc = HalconAPI.PreCall(765);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, width);
            HalconAPI.StoreI(proc, 1, height);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Open a region with a circular structuring element.
        ///   Instance represents: Regions to be opened.
        /// </summary>
        /// <param name="radius">Radius of the circular structuring element. Default: 3.5</param>
        /// <returns>Opened regions.</returns>
        public HRegion OpeningCircle(HTuple radius)
        {
            IntPtr proc = HalconAPI.PreCall(766);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, radius);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(radius);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Open a region with a circular structuring element.
        ///   Instance represents: Regions to be opened.
        /// </summary>
        /// <param name="radius">Radius of the circular structuring element. Default: 3.5</param>
        /// <returns>Opened regions.</returns>
        public HRegion OpeningCircle(double radius)
        {
            IntPtr proc = HalconAPI.PreCall(766);
            this.Store(proc, 1);
            HalconAPI.StoreD(proc, 0, radius);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Open a region.
        ///   Instance represents: Regions to be opened.
        /// </summary>
        /// <param name="structElement">Structuring element (position-invariant).</param>
        /// <returns>Opened regions.</returns>
        public HRegion Opening(HRegion structElement)
        {
            IntPtr proc = HalconAPI.PreCall(767);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)structElement);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)structElement);
            return hregion;
        }

        /// <summary>
        ///   Erode a region sequentially.
        ///   Instance represents: Regions to be eroded.
        /// </summary>
        /// <param name="golayElement">Structuring element from the Golay alphabet. Default: "h"</param>
        /// <param name="iterations">Number of iterations. Default: 1</param>
        /// <returns>Eroded regions.</returns>
        public HRegion ErosionSeq(string golayElement, int iterations)
        {
            IntPtr proc = HalconAPI.PreCall(768);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, golayElement);
            HalconAPI.StoreI(proc, 1, iterations);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Erode a region with an element from the Golay alphabet.
        ///   Instance represents: Regions to be eroded.
        /// </summary>
        /// <param name="golayElement">Structuring element from the Golay alphabet. Default: "h"</param>
        /// <param name="iterations">Number of iterations. Default: 1</param>
        /// <param name="rotation">Rotation of the Golay element. Depending on the element, not all rotations are valid. Default: 0</param>
        /// <returns>Eroded regions.</returns>
        public HRegion ErosionGolay(string golayElement, int iterations, int rotation)
        {
            IntPtr proc = HalconAPI.PreCall(769);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, golayElement);
            HalconAPI.StoreI(proc, 1, iterations);
            HalconAPI.StoreI(proc, 2, rotation);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Erode a region with a rectangular structuring element.
        ///   Instance represents: Regions to be eroded.
        /// </summary>
        /// <param name="width">Width of the structuring rectangle. Default: 11</param>
        /// <param name="height">Height of the structuring rectangle. Default: 11</param>
        /// <returns>Eroded regions.</returns>
        public HRegion ErosionRectangle1(int width, int height)
        {
            IntPtr proc = HalconAPI.PreCall(770);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, width);
            HalconAPI.StoreI(proc, 1, height);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Erode a region with a circular structuring element.
        ///   Instance represents: Regions to be eroded.
        /// </summary>
        /// <param name="radius">Radius of the circular structuring element. Default: 3.5</param>
        /// <returns>Eroded regions.</returns>
        public HRegion ErosionCircle(HTuple radius)
        {
            IntPtr proc = HalconAPI.PreCall(771);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, radius);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(radius);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Erode a region with a circular structuring element.
        ///   Instance represents: Regions to be eroded.
        /// </summary>
        /// <param name="radius">Radius of the circular structuring element. Default: 3.5</param>
        /// <returns>Eroded regions.</returns>
        public HRegion ErosionCircle(double radius)
        {
            IntPtr proc = HalconAPI.PreCall(771);
            this.Store(proc, 1);
            HalconAPI.StoreD(proc, 0, radius);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Erode a region (using a reference point).
        ///   Instance represents: Regions to be eroded.
        /// </summary>
        /// <param name="structElement">Structuring element.</param>
        /// <param name="row">Row coordinate of the reference point. Default: 0</param>
        /// <param name="column">Column coordinate of the reference point. Default: 0</param>
        /// <param name="iterations">Number of iterations. Default: 1</param>
        /// <returns>Eroded regions.</returns>
        public HRegion Erosion2(HRegion structElement, int row, int column, int iterations)
        {
            IntPtr proc = HalconAPI.PreCall(772);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)structElement);
            HalconAPI.StoreI(proc, 0, row);
            HalconAPI.StoreI(proc, 1, column);
            HalconAPI.StoreI(proc, 2, iterations);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)structElement);
            return hregion;
        }

        /// <summary>
        ///   Erode a region.
        ///   Instance represents: Regions to be eroded.
        /// </summary>
        /// <param name="structElement">Structuring element.</param>
        /// <param name="iterations">Number of iterations. Default: 1</param>
        /// <returns>Eroded regions.</returns>
        public HRegion Erosion1(HRegion structElement, int iterations)
        {
            IntPtr proc = HalconAPI.PreCall(773);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)structElement);
            HalconAPI.StoreI(proc, 0, iterations);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)structElement);
            return hregion;
        }

        /// <summary>
        ///   Dilate a region sequentially.
        ///   Instance represents: Regions to be dilated.
        /// </summary>
        /// <param name="golayElement">Structuring element from the Golay alphabet. Default: "h"</param>
        /// <param name="iterations">Number of iterations. Default: 1</param>
        /// <returns>Dilated regions.</returns>
        public HRegion DilationSeq(string golayElement, int iterations)
        {
            IntPtr proc = HalconAPI.PreCall(774);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, golayElement);
            HalconAPI.StoreI(proc, 1, iterations);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Dilate a region with an element from the Golay alphabet.
        ///   Instance represents: Regions to be dilated.
        /// </summary>
        /// <param name="golayElement">Structuring element from the Golay alphabet. Default: "h"</param>
        /// <param name="iterations">Number of iterations. Default: 1</param>
        /// <param name="rotation">Rotation of the Golay element. Depending on the element, not all rotations are valid. Default: 0</param>
        /// <returns>Dilated regions.</returns>
        public HRegion DilationGolay(string golayElement, int iterations, int rotation)
        {
            IntPtr proc = HalconAPI.PreCall(775);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, golayElement);
            HalconAPI.StoreI(proc, 1, iterations);
            HalconAPI.StoreI(proc, 2, rotation);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Dilate a region with a rectangular structuring element.
        ///   Instance represents: Regions to be dilated.
        /// </summary>
        /// <param name="width">Width of the structuring rectangle. Default: 11</param>
        /// <param name="height">Height of the structuring rectangle. Default: 11</param>
        /// <returns>Dilated regions.</returns>
        public HRegion DilationRectangle1(int width, int height)
        {
            IntPtr proc = HalconAPI.PreCall(776);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, width);
            HalconAPI.StoreI(proc, 1, height);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Dilate a region with a circular structuring element.
        ///   Instance represents: Regions to be dilated.
        /// </summary>
        /// <param name="radius">Radius of the circular structuring element. Default: 3.5</param>
        /// <returns>Dilated regions.</returns>
        public HRegion DilationCircle(HTuple radius)
        {
            IntPtr proc = HalconAPI.PreCall(777);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, radius);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(radius);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Dilate a region with a circular structuring element.
        ///   Instance represents: Regions to be dilated.
        /// </summary>
        /// <param name="radius">Radius of the circular structuring element. Default: 3.5</param>
        /// <returns>Dilated regions.</returns>
        public HRegion DilationCircle(double radius)
        {
            IntPtr proc = HalconAPI.PreCall(777);
            this.Store(proc, 1);
            HalconAPI.StoreD(proc, 0, radius);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Dilate a region (using a reference point).
        ///   Instance represents: Regions to be dilated.
        /// </summary>
        /// <param name="structElement">Structuring element.</param>
        /// <param name="row">Row coordinate of the reference point. Default: 0</param>
        /// <param name="column">Column coordinate of the reference point. Default: 0</param>
        /// <param name="iterations">Number of iterations. Default: 1</param>
        /// <returns>Dilated regions.</returns>
        public HRegion Dilation2(HRegion structElement, int row, int column, int iterations)
        {
            IntPtr proc = HalconAPI.PreCall(778);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)structElement);
            HalconAPI.StoreI(proc, 0, row);
            HalconAPI.StoreI(proc, 1, column);
            HalconAPI.StoreI(proc, 2, iterations);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)structElement);
            return hregion;
        }

        /// <summary>
        ///   Dilate a region.
        ///   Instance represents: Regions to be dilated.
        /// </summary>
        /// <param name="structElement">Structuring element.</param>
        /// <param name="iterations">Number of iterations. Default: 1</param>
        /// <returns>Dilated regions.</returns>
        public HRegion Dilation1(HRegion structElement, int iterations)
        {
            IntPtr proc = HalconAPI.PreCall(779);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)structElement);
            HalconAPI.StoreI(proc, 0, iterations);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)structElement);
            return hregion;
        }

        /// <summary>
        ///   Add gray values to regions.
        ///   Instance represents: Input regions (without pixel values).
        /// </summary>
        /// <param name="image">Input image with pixel values for regions.</param>
        /// <returns>Output image(s) with regions and pixel values (one image per input region).</returns>
        public HImage AddChannels(HImage image)
        {
            IntPtr proc = HalconAPI.PreCall(1144);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return himage;
        }

        /// <summary>
        ///   Centres of circles for a specific radius.
        ///   Instance represents: Binary edge image in which the circles are to be detected.
        /// </summary>
        /// <param name="radius">Radius of the circle to be searched in the image. Default: 12</param>
        /// <param name="percent">Indicates the percentage (approximately) of the (ideal) circle which must be present in the edge image RegionIn. Default: 60</param>
        /// <param name="mode">The modus defines the position of the circle in question: 0 - the radius is equivalent to the outer border of the set pixels. 1 - the radius is equivalent to the centres of the circle lines´ pixels. 2 - both 0 and 1 (a little more fuzzy, but more reliable in contrast to circles set slightly differently, necessitates 50  </param>
        /// <returns>Centres of those circles which are included in the edge image by Percent percent.</returns>
        public HRegion HoughCircles(HTuple radius, HTuple percent, HTuple mode)
        {
            IntPtr proc = HalconAPI.PreCall(1149);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, radius);
            HalconAPI.Store(proc, 1, percent);
            HalconAPI.Store(proc, 2, mode);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(radius);
            HalconAPI.UnpinTuple(percent);
            HalconAPI.UnpinTuple(mode);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Centres of circles for a specific radius.
        ///   Instance represents: Binary edge image in which the circles are to be detected.
        /// </summary>
        /// <param name="radius">Radius of the circle to be searched in the image. Default: 12</param>
        /// <param name="percent">Indicates the percentage (approximately) of the (ideal) circle which must be present in the edge image RegionIn. Default: 60</param>
        /// <param name="mode">The modus defines the position of the circle in question: 0 - the radius is equivalent to the outer border of the set pixels. 1 - the radius is equivalent to the centres of the circle lines´ pixels. 2 - both 0 and 1 (a little more fuzzy, but more reliable in contrast to circles set slightly differently, necessitates 50  </param>
        /// <returns>Centres of those circles which are included in the edge image by Percent percent.</returns>
        public HRegion HoughCircles(int radius, int percent, int mode)
        {
            IntPtr proc = HalconAPI.PreCall(1149);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, radius);
            HalconAPI.StoreI(proc, 1, percent);
            HalconAPI.StoreI(proc, 2, mode);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Return the Hough-Transform for circles with a given radius.
        ///   Instance represents: Binary edge image in which the circles are to be detected.
        /// </summary>
        /// <param name="radius">Radius of the circle to be searched in the image. Default: 12</param>
        /// <returns>Hough transform for circles with a given radius.</returns>
        public HImage HoughCircleTrans(HTuple radius)
        {
            IntPtr proc = HalconAPI.PreCall(1150);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, radius);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(radius);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>
        ///   Return the Hough-Transform for circles with a given radius.
        ///   Instance represents: Binary edge image in which the circles are to be detected.
        /// </summary>
        /// <param name="radius">Radius of the circle to be searched in the image. Default: 12</param>
        /// <returns>Hough transform for circles with a given radius.</returns>
        public HImage HoughCircleTrans(int radius)
        {
            IntPtr proc = HalconAPI.PreCall(1150);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, radius);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>
        ///   Detect lines in edge images with the help of the Hough transform and returns it in HNF.
        ///   Instance represents: Binary edge image in which the lines are to be detected.
        /// </summary>
        /// <param name="angleResolution">Adjusting the resolution in the angle area. Default: 4</param>
        /// <param name="threshold">Threshold value in the Hough image. Default: 100</param>
        /// <param name="angleGap">Minimal distance of two maxima in the Hough image (direction: angle). Default: 5</param>
        /// <param name="distGap">Minimal distance of two maxima in the Hough image (direction: distance). Default: 5</param>
        /// <param name="dist">Distance of the detected lines from the origin.</param>
        /// <returns>Angles (in radians) of the detected lines' normal vectors.</returns>
        public HTuple HoughLines(
          int angleResolution,
          int threshold,
          int angleGap,
          int distGap,
          out HTuple dist)
        {
            IntPtr proc = HalconAPI.PreCall(1153);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, angleResolution);
            HalconAPI.StoreI(proc, 1, threshold);
            HalconAPI.StoreI(proc, 2, angleGap);
            HalconAPI.StoreI(proc, 3, distGap);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out dist);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Produce the Hough transform for lines within regions.
        ///   Instance represents: Binary edge image in which lines are to be detected.
        /// </summary>
        /// <param name="angleResolution">Adjusting the resolution in the angle area. Default: 4</param>
        /// <returns>Hough transform for lines.</returns>
        public HImage HoughLineTrans(int angleResolution)
        {
            IntPtr proc = HalconAPI.PreCall(1154);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, angleResolution);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>
        ///   Select those lines from a set of lines (in HNF) which fit best into a region.
        ///   Instance represents: Region in which the lines are to be matched.
        /// </summary>
        /// <param name="angleIn">Angles (in radians) of the normal vectors of the input lines.</param>
        /// <param name="distIn">Distances of the input lines form the origin.</param>
        /// <param name="lineWidth">Widths of the lines. Default: 7</param>
        /// <param name="thresh">Threshold value for the number of line points in the region. Default: 100</param>
        /// <param name="angleOut">Angles (in radians) of the normal vectors of the selected lines.</param>
        /// <param name="distOut">Distances of the selected lines from the origin.</param>
        /// <returns>Region array containing the matched lines.</returns>
        public HRegion SelectMatchingLines(
          HTuple angleIn,
          HTuple distIn,
          int lineWidth,
          int thresh,
          out HTuple angleOut,
          out HTuple distOut)
        {
            IntPtr proc = HalconAPI.PreCall(1155);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, angleIn);
            HalconAPI.Store(proc, 1, distIn);
            HalconAPI.StoreI(proc, 2, lineWidth);
            HalconAPI.StoreI(proc, 3, thresh);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(angleIn);
            HalconAPI.UnpinTuple(distIn);
            HRegion hregion;
            int err2 = HRegion.LoadNew(proc, 1, err1, out hregion);
            int err3 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err2, out angleOut);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err3, out distOut);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Select those lines from a set of lines (in HNF) which fit best into a region.
        ///   Instance represents: Region in which the lines are to be matched.
        /// </summary>
        /// <param name="angleIn">Angles (in radians) of the normal vectors of the input lines.</param>
        /// <param name="distIn">Distances of the input lines form the origin.</param>
        /// <param name="lineWidth">Widths of the lines. Default: 7</param>
        /// <param name="thresh">Threshold value for the number of line points in the region. Default: 100</param>
        /// <param name="angleOut">Angles (in radians) of the normal vectors of the selected lines.</param>
        /// <param name="distOut">Distances of the selected lines from the origin.</param>
        /// <returns>Region array containing the matched lines.</returns>
        public HRegion SelectMatchingLines(
          double angleIn,
          double distIn,
          int lineWidth,
          int thresh,
          out double angleOut,
          out double distOut)
        {
            IntPtr proc = HalconAPI.PreCall(1155);
            this.Store(proc, 1);
            HalconAPI.StoreD(proc, 0, angleIn);
            HalconAPI.StoreD(proc, 1, distIn);
            HalconAPI.StoreI(proc, 2, lineWidth);
            HalconAPI.StoreI(proc, 3, thresh);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int err2 = HRegion.LoadNew(proc, 1, err1, out hregion);
            int err3 = HalconAPI.LoadD(proc, 0, err2, out angleOut);
            int procResult = HalconAPI.LoadD(proc, 1, err3, out distOut);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Query the icon for region output
        ///   Modified instance represents: Icon for the regions center of gravity.
        /// </summary>
        /// <param name="windowHandle">Window handle.</param>
        public void GetIcon(HWindow windowHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1260);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)windowHandle);
        }

        /// <summary>
        ///   Icon definition for region output.
        ///   Instance represents: Icon for center of gravity.
        /// </summary>
        /// <param name="windowHandle">Window handle.</param>
        public void SetIcon(HWindow windowHandle)
        {
            IntPtr proc = HalconAPI.PreCall(1261);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)windowHandle);
        }

        /// <summary>
        ///   Displays regions in a window.
        ///   Instance represents: Regions to display.
        /// </summary>
        /// <param name="windowHandle">Window handle.</param>
        public void DispRegion(HWindow windowHandle)
        {
            IntPtr proc = HalconAPI.PreCall(1262);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)windowHandle);
        }

        /// <summary>
        ///   Interactive movement of a region with restriction of positions.
        ///   Instance represents: Regions to move.
        /// </summary>
        /// <param name="maskRegion">Points on which it is allowed for a region to move.</param>
        /// <param name="windowHandle">Window handle.</param>
        /// <param name="row">Row index of the reference point. Default: 100</param>
        /// <param name="column">Column index of the reference point. Default: 100</param>
        /// <returns>Moved regions.</returns>
        public HRegion DragRegion3(
          HRegion maskRegion,
          HWindow windowHandle,
          int row,
          int column)
        {
            IntPtr proc = HalconAPI.PreCall(1315);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)maskRegion);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            HalconAPI.StoreI(proc, 1, row);
            HalconAPI.StoreI(proc, 2, column);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)maskRegion);
            GC.KeepAlive((object)windowHandle);
            return hregion;
        }

        /// <summary>
        ///   Interactive movement of a region with fixpoint specification.
        ///   Instance represents: Regions to move.
        /// </summary>
        /// <param name="windowHandle">Window handle.</param>
        /// <param name="row">Row index of the reference point. Default: 100</param>
        /// <param name="column">Column index of the reference point. Default: 100</param>
        /// <returns>Moved regions.</returns>
        public HRegion DragRegion2(HWindow windowHandle, int row, int column)
        {
            IntPtr proc = HalconAPI.PreCall(1316);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            HalconAPI.StoreI(proc, 1, row);
            HalconAPI.StoreI(proc, 2, column);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)windowHandle);
            return hregion;
        }

        /// <summary>
        ///   Interactive moving of a region.
        ///   Instance represents: Regions to move.
        /// </summary>
        /// <param name="windowHandle">Window handle.</param>
        /// <returns>Moved Regions.</returns>
        public HRegion DragRegion1(HWindow windowHandle)
        {
            IntPtr proc = HalconAPI.PreCall(1317);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)windowHandle);
            return hregion;
        }

        /// <summary>
        ///   Interactive drawing of a closed region.
        ///   Modified instance represents: Interactive created region.
        /// </summary>
        /// <param name="windowHandle">Window handle.</param>
        public void DrawRegion(HWindow windowHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1336);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)windowHandle);
        }

        /// <summary>
        ///   Interactive drawing of a polygon row.
        ///   Modified instance represents: Region, which encompasses all painted points.
        /// </summary>
        /// <param name="windowHandle">Window handle.</param>
        public void DrawPolygon(HWindow windowHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1337);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)windowHandle);
        }

        /// <summary>
        ///   Calculate the distance between a line segment and one region.
        ///   Instance represents: Input region.
        /// </summary>
        /// <param name="row1">Row coordinate of the first point of the line segment.</param>
        /// <param name="column1">Column coordinate of the first point of the line segment.</param>
        /// <param name="row2">Row coordinate of the second point of the line segment.</param>
        /// <param name="column2">Column coordinate of the second point of the line segment.</param>
        /// <param name="distanceMin">Minimum distance between the line segment and the region.</param>
        /// <param name="distanceMax">Maximum distance between the line segment and the region.</param>
        public void DistanceSr(
          HTuple row1,
          HTuple column1,
          HTuple row2,
          HTuple column2,
          out HTuple distanceMin,
          out HTuple distanceMax)
        {
            IntPtr proc = HalconAPI.PreCall(1367);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, row1);
            HalconAPI.Store(proc, 1, column1);
            HalconAPI.Store(proc, 2, row2);
            HalconAPI.Store(proc, 3, column2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row1);
            HalconAPI.UnpinTuple(column1);
            HalconAPI.UnpinTuple(row2);
            HalconAPI.UnpinTuple(column2);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out distanceMin);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out distanceMax);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Calculate the distance between a line segment and one region.
        ///   Instance represents: Input region.
        /// </summary>
        /// <param name="row1">Row coordinate of the first point of the line segment.</param>
        /// <param name="column1">Column coordinate of the first point of the line segment.</param>
        /// <param name="row2">Row coordinate of the second point of the line segment.</param>
        /// <param name="column2">Column coordinate of the second point of the line segment.</param>
        /// <param name="distanceMin">Minimum distance between the line segment and the region.</param>
        /// <param name="distanceMax">Maximum distance between the line segment and the region.</param>
        public void DistanceSr(
          double row1,
          double column1,
          double row2,
          double column2,
          out double distanceMin,
          out double distanceMax)
        {
            IntPtr proc = HalconAPI.PreCall(1367);
            this.Store(proc, 1);
            HalconAPI.StoreD(proc, 0, row1);
            HalconAPI.StoreD(proc, 1, column1);
            HalconAPI.StoreD(proc, 2, row2);
            HalconAPI.StoreD(proc, 3, column2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out distanceMin);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out distanceMax);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Calculate the distance between a line and a region.
        ///   Instance represents: Input region.
        /// </summary>
        /// <param name="row1">Row coordinate of the first point of the line.</param>
        /// <param name="column1">Column coordinate of the first point of the line.</param>
        /// <param name="row2">Row coordinate of the second point of the line.</param>
        /// <param name="column2">Column coordinate of the second point of the line.</param>
        /// <param name="distanceMin">Minimum distance between the line and the region</param>
        /// <param name="distanceMax">Maximum distance between the line and the region</param>
        public void DistanceLr(
          HTuple row1,
          HTuple column1,
          HTuple row2,
          HTuple column2,
          out HTuple distanceMin,
          out HTuple distanceMax)
        {
            IntPtr proc = HalconAPI.PreCall(1368);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, row1);
            HalconAPI.Store(proc, 1, column1);
            HalconAPI.Store(proc, 2, row2);
            HalconAPI.Store(proc, 3, column2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row1);
            HalconAPI.UnpinTuple(column1);
            HalconAPI.UnpinTuple(row2);
            HalconAPI.UnpinTuple(column2);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out distanceMin);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out distanceMax);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Calculate the distance between a line and a region.
        ///   Instance represents: Input region.
        /// </summary>
        /// <param name="row1">Row coordinate of the first point of the line.</param>
        /// <param name="column1">Column coordinate of the first point of the line.</param>
        /// <param name="row2">Row coordinate of the second point of the line.</param>
        /// <param name="column2">Column coordinate of the second point of the line.</param>
        /// <param name="distanceMin">Minimum distance between the line and the region</param>
        /// <param name="distanceMax">Maximum distance between the line and the region</param>
        public void DistanceLr(
          double row1,
          double column1,
          double row2,
          double column2,
          out double distanceMin,
          out double distanceMax)
        {
            IntPtr proc = HalconAPI.PreCall(1368);
            this.Store(proc, 1);
            HalconAPI.StoreD(proc, 0, row1);
            HalconAPI.StoreD(proc, 1, column1);
            HalconAPI.StoreD(proc, 2, row2);
            HalconAPI.StoreD(proc, 3, column2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out distanceMin);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out distanceMax);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Calculate the distance between a point and a region.
        ///   Instance represents: Input region.
        /// </summary>
        /// <param name="row">Row coordinate of the point.</param>
        /// <param name="column">Column coordinate of the point.</param>
        /// <param name="distanceMin">Minimum distance between the point and the region.</param>
        /// <param name="distanceMax">Maximum distance between the point and the region.</param>
        public void DistancePr(
          HTuple row,
          HTuple column,
          out HTuple distanceMin,
          out HTuple distanceMax)
        {
            IntPtr proc = HalconAPI.PreCall(1369);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, column);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out distanceMin);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out distanceMax);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Calculate the distance between a point and a region.
        ///   Instance represents: Input region.
        /// </summary>
        /// <param name="row">Row coordinate of the point.</param>
        /// <param name="column">Column coordinate of the point.</param>
        /// <param name="distanceMin">Minimum distance between the point and the region.</param>
        /// <param name="distanceMax">Maximum distance between the point and the region.</param>
        public void DistancePr(
          double row,
          double column,
          out double distanceMin,
          out double distanceMax)
        {
            IntPtr proc = HalconAPI.PreCall(1369);
            this.Store(proc, 1);
            HalconAPI.StoreD(proc, 0, row);
            HalconAPI.StoreD(proc, 1, column);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out distanceMin);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out distanceMax);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Determine the noise distribution of an image.
        ///   Instance represents: Region from which the noise distribution is to be estimated.
        /// </summary>
        /// <param name="image">Corresponding image.</param>
        /// <param name="filterSize">Size of the mean filter. Default: 21</param>
        /// <returns>Noise distribution of all input regions.</returns>
        public HTuple NoiseDistributionMean(HImage image, int filterSize)
        {
            IntPtr proc = HalconAPI.PreCall(1440);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.StoreI(proc, 0, filterSize);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Determine the fuzzy entropy of regions.
        ///   Instance represents: Regions for which the fuzzy entropy is to be calculated.
        /// </summary>
        /// <param name="image">Input image containing the fuzzy membership values.</param>
        /// <param name="apar">Start of the fuzzy function. Default: 0</param>
        /// <param name="cpar">End of the fuzzy function. Default: 255</param>
        /// <returns>Fuzzy entropy of a region.</returns>
        public HTuple FuzzyEntropy(HImage image, int apar, int cpar)
        {
            IntPtr proc = HalconAPI.PreCall(1457);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.StoreI(proc, 0, apar);
            HalconAPI.StoreI(proc, 1, cpar);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Calculate the fuzzy perimeter of a region.
        ///   Instance represents: Regions for which the fuzzy perimeter is to be calculated.
        /// </summary>
        /// <param name="image">Input image containing the fuzzy membership values.</param>
        /// <param name="apar">Start of the fuzzy function. Default: 0</param>
        /// <param name="cpar">End of the fuzzy function. Default: 255</param>
        /// <returns>Fuzzy perimeter of a region.</returns>
        public HTuple FuzzyPerimeter(HImage image, int apar, int cpar)
        {
            IntPtr proc = HalconAPI.PreCall(1458);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.StoreI(proc, 0, apar);
            HalconAPI.StoreI(proc, 1, cpar);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Paint regions with their average gray value.
        ///   Instance represents: Input regions.
        /// </summary>
        /// <param name="image">original gray-value image.</param>
        /// <returns>Result image with painted regions.</returns>
        public HImage RegionToMean(HImage image)
        {
            IntPtr proc = HalconAPI.PreCall(1476);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return himage;
        }

        /// <summary>
        ///   Close edge gaps using the edge amplitude image.
        ///   Instance represents: Region containing one pixel thick edges.
        /// </summary>
        /// <param name="gradient">Edge amplitude (gradient) image.</param>
        /// <param name="minAmplitude">Minimum edge amplitude. Default: 16</param>
        /// <param name="maxGapLength">Maximal number of points by which edges are extended. Default: 3</param>
        /// <returns>Region containing closed edges.</returns>
        public HRegion CloseEdgesLength(HImage gradient, int minAmplitude, int maxGapLength)
        {
            IntPtr proc = HalconAPI.PreCall(1573);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)gradient);
            HalconAPI.StoreI(proc, 0, minAmplitude);
            HalconAPI.StoreI(proc, 1, maxGapLength);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)gradient);
            return hregion;
        }

        /// <summary>
        ///   Close edge gaps using the edge amplitude image.
        ///   Instance represents: Region containing one pixel thick edges.
        /// </summary>
        /// <param name="edgeImage">Edge amplitude (gradient) image.</param>
        /// <param name="minAmplitude">Minimum edge amplitude. Default: 16</param>
        /// <returns>Region containing closed edges.</returns>
        public HRegion CloseEdges(HImage edgeImage, int minAmplitude)
        {
            IntPtr proc = HalconAPI.PreCall(1574);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)edgeImage);
            HalconAPI.StoreI(proc, 0, minAmplitude);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)edgeImage);
            return hregion;
        }

        /// <summary>
        ///   Deserialize a serialized region.
        ///   Modified instance represents: Region.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeRegion(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1652);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize a region.
        ///   Instance represents: Region.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeRegion()
        {
            IntPtr proc = HalconAPI.PreCall(1653);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HSerializedItem hserializedItem;
            int procResult = HSerializedItem.LoadNew(proc, 0, err, out hserializedItem);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hserializedItem;
        }

        /// <summary>
        ///   Write regions to a file.
        ///   Instance represents: Region of the images which are returned.
        /// </summary>
        /// <param name="fileName">Name of region file. Default: "region.hobj"</param>
        public void WriteRegion(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1654);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Read binary images or HALCON regions.
        ///   Modified instance represents: Read region.
        /// </summary>
        /// <param name="fileName">Name of the region to be read.</param>
        public void ReadRegion(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1657);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Geometric moments of regions.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="PSI2">Moment of 2nd order.</param>
        /// <param name="PSI3">Moment of 2nd order.</param>
        /// <param name="PSI4">Moment of 2nd order.</param>
        /// <returns>Moment of 2nd order.</returns>
        public HTuple MomentsRegionCentralInvar(
          out HTuple PSI2,
          out HTuple PSI3,
          out HTuple PSI4)
        {
            IntPtr proc = HalconAPI.PreCall(1694);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out PSI2);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out PSI3);
            int procResult = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out PSI4);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Geometric moments of regions.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="PSI2">Moment of 2nd order.</param>
        /// <param name="PSI3">Moment of 2nd order.</param>
        /// <param name="PSI4">Moment of 2nd order.</param>
        /// <returns>Moment of 2nd order.</returns>
        public double MomentsRegionCentralInvar(out double PSI2, out double PSI3, out double PSI4)
        {
            IntPtr proc = HalconAPI.PreCall(1694);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out PSI2);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out PSI3);
            int procResult = HalconAPI.LoadD(proc, 3, err4, out PSI4);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Geometric moments of regions.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="i2">Moment of 2nd order.</param>
        /// <param name="i3">Moment of 2nd order.</param>
        /// <param name="i4">Moment of 3rd order.</param>
        /// <returns>Moment of 2nd order.</returns>
        public HTuple MomentsRegionCentral(out HTuple i2, out HTuple i3, out HTuple i4)
        {
            IntPtr proc = HalconAPI.PreCall(1695);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out i2);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out i3);
            int procResult = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out i4);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Geometric moments of regions.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="i2">Moment of 2nd order.</param>
        /// <param name="i3">Moment of 2nd order.</param>
        /// <param name="i4">Moment of 3rd order.</param>
        /// <returns>Moment of 2nd order.</returns>
        public double MomentsRegionCentral(out double i2, out double i3, out double i4)
        {
            IntPtr proc = HalconAPI.PreCall(1695);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out i2);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out i3);
            int procResult = HalconAPI.LoadD(proc, 3, err4, out i4);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Geometric moments of regions.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="m12">Moment of 3rd order (column-dependent).</param>
        /// <param name="m03">Moment of 3rd order (column-dependent).</param>
        /// <param name="m30">Moment of 3rd order (line-dependent).</param>
        /// <returns>Moment of 3rd order (line-dependent).</returns>
        public HTuple MomentsRegion3rdInvar(out HTuple m12, out HTuple m03, out HTuple m30)
        {
            IntPtr proc = HalconAPI.PreCall(1696);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out m12);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out m03);
            int procResult = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out m30);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Geometric moments of regions.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="m12">Moment of 3rd order (column-dependent).</param>
        /// <param name="m03">Moment of 3rd order (column-dependent).</param>
        /// <param name="m30">Moment of 3rd order (line-dependent).</param>
        /// <returns>Moment of 3rd order (line-dependent).</returns>
        public double MomentsRegion3rdInvar(out double m12, out double m03, out double m30)
        {
            IntPtr proc = HalconAPI.PreCall(1696);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out m12);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out m03);
            int procResult = HalconAPI.LoadD(proc, 3, err4, out m30);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Geometric moments of regions.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="m12">Moment of 3rd order (column-dependent).</param>
        /// <param name="m03">Moment of 3rd order (column-dependent).</param>
        /// <param name="m30">Moment of 3rd order (line-dependent).</param>
        /// <returns>Moment of 3rd order (line-dependent).</returns>
        public HTuple MomentsRegion3rd(out HTuple m12, out HTuple m03, out HTuple m30)
        {
            IntPtr proc = HalconAPI.PreCall(1697);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out m12);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out m03);
            int procResult = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out m30);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Geometric moments of regions.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="m12">Moment of 3rd order (column-dependent).</param>
        /// <param name="m03">Moment of 3rd order (column-dependent).</param>
        /// <param name="m30">Moment of 3rd order (line-dependent).</param>
        /// <returns>Moment of 3rd order (line-dependent).</returns>
        public double MomentsRegion3rd(out double m12, out double m03, out double m30)
        {
            IntPtr proc = HalconAPI.PreCall(1697);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out m12);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out m03);
            int procResult = HalconAPI.LoadD(proc, 3, err4, out m30);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Smallest surrounding rectangle with any orientation.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="row">Line index of the center.</param>
        /// <param name="column">Column index of the center.</param>
        /// <param name="phi">Orientation of the surrounding rectangle (arc measure)</param>
        /// <param name="length1">First radius (half length) of the surrounding rectangle.</param>
        /// <param name="length2">Second radius (half width) of the surrounding rectangle.</param>
        public void SmallestRectangle2(
          out HTuple row,
          out HTuple column,
          out HTuple phi,
          out HTuple length1,
          out HTuple length2)
        {
            IntPtr proc = HalconAPI.PreCall(1698);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out column);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out phi);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out length1);
            int procResult = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out length2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Smallest surrounding rectangle with any orientation.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="row">Line index of the center.</param>
        /// <param name="column">Column index of the center.</param>
        /// <param name="phi">Orientation of the surrounding rectangle (arc measure)</param>
        /// <param name="length1">First radius (half length) of the surrounding rectangle.</param>
        /// <param name="length2">Second radius (half width) of the surrounding rectangle.</param>
        public void SmallestRectangle2(
          out double row,
          out double column,
          out double phi,
          out double length1,
          out double length2)
        {
            IntPtr proc = HalconAPI.PreCall(1698);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out row);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out column);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out phi);
            int err5 = HalconAPI.LoadD(proc, 3, err4, out length1);
            int procResult = HalconAPI.LoadD(proc, 4, err5, out length2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Surrounding rectangle parallel to the coordinate axes.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="row1">Line index of upper left corner point.</param>
        /// <param name="column1">Column index of upper left corner point.</param>
        /// <param name="row2">Line index of lower right corner point.</param>
        /// <param name="column2">Column index of lower right corner point.</param>
        public void SmallestRectangle1(
          out HTuple row1,
          out HTuple column1,
          out HTuple row2,
          out HTuple column2)
        {
            IntPtr proc = HalconAPI.PreCall(1699);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out row1);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out column1);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, err3, out row2);
            int procResult = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, err4, out column2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Surrounding rectangle parallel to the coordinate axes.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="row1">Line index of upper left corner point.</param>
        /// <param name="column1">Column index of upper left corner point.</param>
        /// <param name="row2">Line index of lower right corner point.</param>
        /// <param name="column2">Column index of lower right corner point.</param>
        public void SmallestRectangle1(out int row1, out int column1, out int row2, out int column2)
        {
            IntPtr proc = HalconAPI.PreCall(1699);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadI(proc, 0, err1, out row1);
            int err3 = HalconAPI.LoadI(proc, 1, err2, out column1);
            int err4 = HalconAPI.LoadI(proc, 2, err3, out row2);
            int procResult = HalconAPI.LoadI(proc, 3, err4, out column2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Smallest surrounding circle of a region.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="row">Line index of the center.</param>
        /// <param name="column">Column index of the center.</param>
        /// <param name="radius">Radius of the surrounding circle.</param>
        public void SmallestCircle(out HTuple row, out HTuple column, out HTuple radius)
        {
            IntPtr proc = HalconAPI.PreCall(1700);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out column);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out radius);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Smallest surrounding circle of a region.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="row">Line index of the center.</param>
        /// <param name="column">Column index of the center.</param>
        /// <param name="radius">Radius of the surrounding circle.</param>
        public void SmallestCircle(out double row, out double column, out double radius)
        {
            IntPtr proc = HalconAPI.PreCall(1700);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out row);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out column);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out radius);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Choose regions having a certain relation to each other.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="pattern">Region compared to Regions.</param>
        /// <param name="feature">Shape features to be checked. Default: "covers"</param>
        /// <param name="min">Lower border of feature. Default: 50.0</param>
        /// <param name="max">Upper border of the feature. Default: 100.0</param>
        /// <returns>Regions fulfilling the condition.</returns>
        public HRegion SelectShapeProto(
          HRegion pattern,
          HTuple feature,
          HTuple min,
          HTuple max)
        {
            IntPtr proc = HalconAPI.PreCall(1701);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)pattern);
            HalconAPI.Store(proc, 0, feature);
            HalconAPI.Store(proc, 1, min);
            HalconAPI.Store(proc, 2, max);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(feature);
            HalconAPI.UnpinTuple(min);
            HalconAPI.UnpinTuple(max);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)pattern);
            return hregion;
        }

        /// <summary>
        ///   Choose regions having a certain relation to each other.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="pattern">Region compared to Regions.</param>
        /// <param name="feature">Shape features to be checked. Default: "covers"</param>
        /// <param name="min">Lower border of feature. Default: 50.0</param>
        /// <param name="max">Upper border of the feature. Default: 100.0</param>
        /// <returns>Regions fulfilling the condition.</returns>
        public HRegion SelectShapeProto(
          HRegion pattern,
          string feature,
          double min,
          double max)
        {
            IntPtr proc = HalconAPI.PreCall(1701);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)pattern);
            HalconAPI.StoreS(proc, 0, feature);
            HalconAPI.StoreD(proc, 1, min);
            HalconAPI.StoreD(proc, 2, max);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)pattern);
            return hregion;
        }

        /// <summary>
        ///   Calculate shape features of regions.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="features">Shape features to be calculated. Default: "area"</param>
        /// <returns>The calculated features.</returns>
        public HTuple RegionFeatures(HTuple features)
        {
            IntPtr proc = HalconAPI.PreCall(1702);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, features);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(features);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Calculate shape features of regions.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="features">Shape features to be calculated. Default: "area"</param>
        /// <returns>The calculated features.</returns>
        public double RegionFeatures(string features)
        {
            IntPtr proc = HalconAPI.PreCall(1702);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, features);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Choose regions with the aid of shape features.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="features">Shape features to be checked. Default: "area"</param>
        /// <param name="operation">Linkage type of the individual features. Default: "and"</param>
        /// <param name="min">Lower limits of the features or 'min'. Default: 150.0</param>
        /// <param name="max">Upper limits of the features or 'max'. Default: 99999.0</param>
        /// <returns>Regions fulfilling the condition.</returns>
        public HRegion SelectShape(HTuple features, string operation, HTuple min, HTuple max)
        {
            IntPtr proc = HalconAPI.PreCall(1703);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, features);
            HalconAPI.StoreS(proc, 1, operation);
            HalconAPI.Store(proc, 2, min);
            HalconAPI.Store(proc, 3, max);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(features);
            HalconAPI.UnpinTuple(min);
            HalconAPI.UnpinTuple(max);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Choose regions with the aid of shape features.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="features">Shape features to be checked. Default: "area"</param>
        /// <param name="operation">Linkage type of the individual features. Default: "and"</param>
        /// <param name="min">Lower limits of the features or 'min'. Default: 150.0</param>
        /// <param name="max">Upper limits of the features or 'max'. Default: 99999.0</param>
        /// <returns>Regions fulfilling the condition.</returns>
        public HRegion SelectShape(string features, string operation, double min, double max)
        {
            IntPtr proc = HalconAPI.PreCall(1703);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, features);
            HalconAPI.StoreS(proc, 1, operation);
            HalconAPI.StoreD(proc, 2, min);
            HalconAPI.StoreD(proc, 3, max);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Characteristic values for runlength coding of regions.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="KFactor">Storing factor in relation to a square.</param>
        /// <param name="LFactor">Mean number of runs per line.</param>
        /// <param name="meanLength">Mean length of runs.</param>
        /// <param name="bytes">Number of bytes necessary for coding the region.</param>
        /// <returns>Number of runs.</returns>
        public HTuple RunlengthFeatures(
          out HTuple KFactor,
          out HTuple LFactor,
          out HTuple meanLength,
          out HTuple bytes)
        {
            IntPtr proc = HalconAPI.PreCall(1704);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out KFactor);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out LFactor);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out meanLength);
            int procResult = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, err5, out bytes);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Characteristic values for runlength coding of regions.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="KFactor">Storing factor in relation to a square.</param>
        /// <param name="LFactor">Mean number of runs per line.</param>
        /// <param name="meanLength">Mean length of runs.</param>
        /// <param name="bytes">Number of bytes necessary for coding the region.</param>
        /// <returns>Number of runs.</returns>
        public int RunlengthFeatures(
          out double KFactor,
          out double LFactor,
          out double meanLength,
          out int bytes)
        {
            IntPtr proc = HalconAPI.PreCall(1704);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            int intValue;
            int err2 = HalconAPI.LoadI(proc, 0, err1, out intValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out KFactor);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out LFactor);
            int err5 = HalconAPI.LoadD(proc, 3, err4, out meanLength);
            int procResult = HalconAPI.LoadI(proc, 4, err5, out bytes);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Search direct neighbors.
        ///   Instance represents: Starting regions.
        /// </summary>
        /// <param name="regions2">Comparative regions.</param>
        /// <param name="maxDistance">Maximal distance of regions. Default: 1</param>
        /// <param name="regionIndex2">Indices of the found regions from Regions2.</param>
        /// <returns>Indices of the found regions from Regions1.</returns>
        public HTuple FindNeighbors(HRegion regions2, int maxDistance, out HTuple regionIndex2)
        {
            IntPtr proc = HalconAPI.PreCall(1705);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)regions2);
            HalconAPI.StoreI(proc, 0, maxDistance);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out regionIndex2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)regions2);
            return tuple;
        }

        /// <summary>
        ///   Geometric moments of regions.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="PHI2">Moment of 2nd order.</param>
        /// <returns>Moment of 2nd order.</returns>
        public HTuple MomentsRegion2ndRelInvar(out HTuple PHI2)
        {
            IntPtr proc = HalconAPI.PreCall(1706);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out PHI2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Geometric moments of regions.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="PHI2">Moment of 2nd order.</param>
        /// <returns>Moment of 2nd order.</returns>
        public double MomentsRegion2ndRelInvar(out double PHI2)
        {
            IntPtr proc = HalconAPI.PreCall(1706);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out PHI2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Geometric moments of regions.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="m20">Moment of 2nd order (line-dependent).</param>
        /// <param name="m02">Moment of 2nd order (column-dependent).</param>
        /// <returns>Product of inertia of the axes through the center parallel to the coordinate axes.</returns>
        public HTuple MomentsRegion2ndInvar(out HTuple m20, out HTuple m02)
        {
            IntPtr proc = HalconAPI.PreCall(1707);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out m20);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out m02);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Geometric moments of regions.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="m20">Moment of 2nd order (line-dependent).</param>
        /// <param name="m02">Moment of 2nd order (column-dependent).</param>
        /// <returns>Product of inertia of the axes through the center parallel to the coordinate axes.</returns>
        public double MomentsRegion2ndInvar(out double m20, out double m02)
        {
            IntPtr proc = HalconAPI.PreCall(1707);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out m20);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out m02);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Calculate the geometric moments of regions.
        ///   Instance represents: Input regions.
        /// </summary>
        /// <param name="m20">Moment of 2nd order (row-dependent).</param>
        /// <param name="m02">Moment of 2nd order (column-dependent).</param>
        /// <param name="ia">Length of the major axis of the input region.</param>
        /// <param name="ib">Length of the minor axis of the input region.</param>
        /// <returns>Product of inertia of the axes through the center parallel to the coordinate axes.</returns>
        public HTuple MomentsRegion2nd(
          out HTuple m20,
          out HTuple m02,
          out HTuple ia,
          out HTuple ib)
        {
            IntPtr proc = HalconAPI.PreCall(1708);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out m20);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out m02);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out ia);
            int procResult = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out ib);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Calculate the geometric moments of regions.
        ///   Instance represents: Input regions.
        /// </summary>
        /// <param name="m20">Moment of 2nd order (row-dependent).</param>
        /// <param name="m02">Moment of 2nd order (column-dependent).</param>
        /// <param name="ia">Length of the major axis of the input region.</param>
        /// <param name="ib">Length of the minor axis of the input region.</param>
        /// <returns>Product of inertia of the axes through the center parallel to the coordinate axes.</returns>
        public double MomentsRegion2nd(out double m20, out double m02, out double ia, out double ib)
        {
            IntPtr proc = HalconAPI.PreCall(1708);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out m20);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out m02);
            int err5 = HalconAPI.LoadD(proc, 3, err4, out ia);
            int procResult = HalconAPI.LoadD(proc, 4, err5, out ib);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Minimum distance between the contour pixels of two regions each.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="regions2">Regions to be examined.</param>
        /// <param name="row1">Line index on contour in Regions1.</param>
        /// <param name="column1">Column index on contour in Regions1.</param>
        /// <param name="row2">Line index on contour in Regions2.</param>
        /// <param name="column2">Column index on contour in Regions2.</param>
        /// <returns>Minimum distance between contours of the regions.</returns>
        public HTuple DistanceRrMin(
          HRegion regions2,
          out HTuple row1,
          out HTuple column1,
          out HTuple row2,
          out HTuple column2)
        {
            IntPtr proc = HalconAPI.PreCall(1709);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)regions2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out row1);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, err3, out column1);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, err4, out row2);
            int procResult = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, err5, out column2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)regions2);
            return tuple;
        }

        /// <summary>
        ///   Minimum distance between the contour pixels of two regions each.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="regions2">Regions to be examined.</param>
        /// <param name="row1">Line index on contour in Regions1.</param>
        /// <param name="column1">Column index on contour in Regions1.</param>
        /// <param name="row2">Line index on contour in Regions2.</param>
        /// <param name="column2">Column index on contour in Regions2.</param>
        /// <returns>Minimum distance between contours of the regions.</returns>
        public double DistanceRrMin(
          HRegion regions2,
          out int row1,
          out int column1,
          out int row2,
          out int column2)
        {
            IntPtr proc = HalconAPI.PreCall(1709);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)regions2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadI(proc, 1, err2, out row1);
            int err4 = HalconAPI.LoadI(proc, 2, err3, out column1);
            int err5 = HalconAPI.LoadI(proc, 3, err4, out row2);
            int procResult = HalconAPI.LoadI(proc, 4, err5, out column2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)regions2);
            return doubleValue;
        }

        /// <summary>
        ///   Minimum distance between two regions with the help of dilation.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="regions2">Regions to be examined.</param>
        /// <returns>Minimum distances of the regions.</returns>
        public HTuple DistanceRrMinDil(HRegion regions2)
        {
            IntPtr proc = HalconAPI.PreCall(1710);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)regions2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)regions2);
            return tuple;
        }

        /// <summary>
        ///   Maximal distance between two boundary points of a region.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="row1">Row index of the first extreme point.</param>
        /// <param name="column1">Column index of the first extreme point.</param>
        /// <param name="row2">Row index of the second extreme point.</param>
        /// <param name="column2">Column index of the second extreme point.</param>
        /// <param name="diameter">Distance of the two extreme points.</param>
        public void DiameterRegion(
          out HTuple row1,
          out HTuple column1,
          out HTuple row2,
          out HTuple column2,
          out HTuple diameter)
        {
            IntPtr proc = HalconAPI.PreCall(1711);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out row1);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out column1);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, err3, out row2);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, err4, out column2);
            int procResult = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out diameter);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Maximal distance between two boundary points of a region.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="row1">Row index of the first extreme point.</param>
        /// <param name="column1">Column index of the first extreme point.</param>
        /// <param name="row2">Row index of the second extreme point.</param>
        /// <param name="column2">Column index of the second extreme point.</param>
        /// <param name="diameter">Distance of the two extreme points.</param>
        public void DiameterRegion(
          out int row1,
          out int column1,
          out int row2,
          out int column2,
          out double diameter)
        {
            IntPtr proc = HalconAPI.PreCall(1711);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadI(proc, 0, err1, out row1);
            int err3 = HalconAPI.LoadI(proc, 1, err2, out column1);
            int err4 = HalconAPI.LoadI(proc, 2, err3, out row2);
            int err5 = HalconAPI.LoadI(proc, 3, err4, out column2);
            int procResult = HalconAPI.LoadD(proc, 4, err5, out diameter);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Test if the region contains a given point.
        ///   Instance represents: Region(s) to be examined.
        /// </summary>
        /// <param name="row">Row index of the test pixel(s). Default: 100</param>
        /// <param name="column">Column index of the test pixel(s). Default: 100</param>
        /// <returns>Boolean result value.</returns>
        public int TestRegionPoint(HTuple row, HTuple column)
        {
            IntPtr proc = HalconAPI.PreCall(1712);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, column);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Test if the region contains a given point.
        ///   Instance represents: Region(s) to be examined.
        /// </summary>
        /// <param name="row">Row index of the test pixel(s). Default: 100</param>
        /// <param name="column">Column index of the test pixel(s). Default: 100</param>
        /// <returns>Boolean result value.</returns>
        public int TestRegionPoint(int row, int column)
        {
            IntPtr proc = HalconAPI.PreCall(1712);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, row);
            HalconAPI.StoreI(proc, 1, column);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Index of all regions containing a given pixel.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="row">Line index of the test pixel. Default: 100</param>
        /// <param name="column">Column index of the test pixel. Default: 100</param>
        /// <returns>Index of the regions containing the test pixel.</returns>
        public HTuple GetRegionIndex(int row, int column)
        {
            IntPtr proc = HalconAPI.PreCall(1713);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, row);
            HalconAPI.StoreI(proc, 1, column);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Choose all regions containing a given pixel.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="row">Line index of the test pixel. Default: 100</param>
        /// <param name="column">Column index of the test pixel. Default: 100</param>
        /// <returns>All regions containing the test pixel.</returns>
        public HRegion SelectRegionPoint(int row, int column)
        {
            IntPtr proc = HalconAPI.PreCall(1714);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, row);
            HalconAPI.StoreI(proc, 1, column);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Select regions of a given shape.
        ///   Instance represents: Input regions to be selected.
        /// </summary>
        /// <param name="shape">Shape features to be checked. Default: "max_area"</param>
        /// <param name="percent">Similarity measure. Default: 70.0</param>
        /// <returns>Regions with desired shape.</returns>
        public HRegion SelectShapeStd(string shape, double percent)
        {
            IntPtr proc = HalconAPI.PreCall(1715);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, shape);
            HalconAPI.StoreD(proc, 1, percent);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Hamming distance between two regions using normalization.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="regions2">Comparative regions.</param>
        /// <param name="norm">Type of normalization. Default: "center"</param>
        /// <param name="similarity">Similarity of two regions.</param>
        /// <returns>Hamming distance of two regions.</returns>
        public HTuple HammingDistanceNorm(HRegion regions2, HTuple norm, out HTuple similarity)
        {
            IntPtr proc = HalconAPI.PreCall(1716);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)regions2);
            HalconAPI.Store(proc, 0, norm);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(norm);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out similarity);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)regions2);
            return tuple;
        }

        /// <summary>
        ///   Hamming distance between two regions using normalization.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="regions2">Comparative regions.</param>
        /// <param name="norm">Type of normalization. Default: "center"</param>
        /// <param name="similarity">Similarity of two regions.</param>
        /// <returns>Hamming distance of two regions.</returns>
        public int HammingDistanceNorm(HRegion regions2, string norm, out double similarity)
        {
            IntPtr proc = HalconAPI.PreCall(1716);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)regions2);
            HalconAPI.StoreS(proc, 0, norm);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int intValue;
            int err2 = HalconAPI.LoadI(proc, 0, err1, out intValue);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out similarity);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)regions2);
            return intValue;
        }

        /// <summary>
        ///   Hamming distance between two regions.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="regions2">Comparative regions.</param>
        /// <param name="similarity">Similarity of two regions.</param>
        /// <returns>Hamming distance of two regions.</returns>
        public HTuple HammingDistance(HRegion regions2, out HTuple similarity)
        {
            IntPtr proc = HalconAPI.PreCall(1717);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)regions2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out similarity);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)regions2);
            return tuple;
        }

        /// <summary>
        ///   Hamming distance between two regions.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="regions2">Comparative regions.</param>
        /// <param name="similarity">Similarity of two regions.</param>
        /// <returns>Hamming distance of two regions.</returns>
        public int HammingDistance(HRegion regions2, out double similarity)
        {
            IntPtr proc = HalconAPI.PreCall(1717);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)regions2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int intValue;
            int err2 = HalconAPI.LoadI(proc, 0, err1, out intValue);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out similarity);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)regions2);
            return intValue;
        }

        /// <summary>
        ///   Shape features derived from the ellipse parameters.
        ///   Instance represents: Region(s) to be examined.
        /// </summary>
        /// <param name="bulkiness">Calculated shape feature.</param>
        /// <param name="structureFactor">Calculated shape feature.</param>
        /// <returns>Shape feature (in case of a circle = 1.0).</returns>
        public HTuple Eccentricity(out HTuple bulkiness, out HTuple structureFactor)
        {
            IntPtr proc = HalconAPI.PreCall(1718);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out bulkiness);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out structureFactor);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Shape features derived from the ellipse parameters.
        ///   Instance represents: Region(s) to be examined.
        /// </summary>
        /// <param name="bulkiness">Calculated shape feature.</param>
        /// <param name="structureFactor">Calculated shape feature.</param>
        /// <returns>Shape feature (in case of a circle = 1.0).</returns>
        public double Eccentricity(out double bulkiness, out double structureFactor)
        {
            IntPtr proc = HalconAPI.PreCall(1718);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out bulkiness);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out structureFactor);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Calculate the Euler number.
        ///   Instance represents: Region(s) to be examined.
        /// </summary>
        /// <returns>Calculated Euler number.</returns>
        public HTuple EulerNumber()
        {
            IntPtr proc = HalconAPI.PreCall(1719);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Orientation of a region.
        ///   Instance represents: Region(s) to be examined.
        /// </summary>
        /// <returns>Orientation of region (arc measure).</returns>
        public HTuple OrientationRegion()
        {
            IntPtr proc = HalconAPI.PreCall(1720);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Calculate the parameters of the equivalent ellipse.
        ///   Instance represents: Input regions.
        /// </summary>
        /// <param name="rb">Secondary radius (normalized to the area).</param>
        /// <param name="phi">Angle between main radius and x-axis in radians.</param>
        /// <returns>Main radius (normalized to the area).</returns>
        public HTuple EllipticAxis(out HTuple rb, out HTuple phi)
        {
            IntPtr proc = HalconAPI.PreCall(1721);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out rb);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out phi);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Calculate the parameters of the equivalent ellipse.
        ///   Instance represents: Input regions.
        /// </summary>
        /// <param name="rb">Secondary radius (normalized to the area).</param>
        /// <param name="phi">Angle between main radius and x-axis in radians.</param>
        /// <returns>Main radius (normalized to the area).</returns>
        public double EllipticAxis(out double rb, out double phi)
        {
            IntPtr proc = HalconAPI.PreCall(1721);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out rb);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out phi);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Pose relation of regions.
        ///   Instance represents: Starting regions
        /// </summary>
        /// <param name="regions2">Comparative regions</param>
        /// <param name="direction">Desired neighboring relation. Default: "left"</param>
        /// <param name="regionIndex2">Indices in the input tuples (Regions1 or ParRef{Regions2}), respectively.</param>
        /// <returns>Indices in the input tuples (Regions1 or ParRef{Regions2}), respectively.</returns>
        public HTuple SelectRegionSpatial(
          HRegion regions2,
          string direction,
          out HTuple regionIndex2)
        {
            IntPtr proc = HalconAPI.PreCall(1722);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)regions2);
            HalconAPI.StoreS(proc, 0, direction);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out regionIndex2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)regions2);
            return tuple;
        }

        /// <summary>
        ///   Pose relation of regions with regard to
        ///   Instance represents: Starting regions.
        /// </summary>
        /// <param name="regions2">Comparative regions.</param>
        /// <param name="percent">Percentage of the area of the comparative region which must be located left/right or  Default: 50</param>
        /// <param name="regionIndex2">Indices of the regions in the tuple of the input regions which fulfill the pose relation.</param>
        /// <param name="relation1">Horizontal pose relation in which RegionIndex2[n] stands with RegionIndex1[n].</param>
        /// <param name="relation2">Vertical pose relation in which RegionIndex2[n] stands with RegionIndex1[n].</param>
        /// <returns>Indices of the regions in the tuple of the input regions which fulfill the pose relation.</returns>
        public HTuple SpatialRelation(
          HRegion regions2,
          int percent,
          out HTuple regionIndex2,
          out HTuple relation1,
          out HTuple relation2)
        {
            IntPtr proc = HalconAPI.PreCall(1723);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)regions2);
            HalconAPI.StoreI(proc, 0, percent);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out regionIndex2);
            int err4 = HTuple.LoadNew(proc, 2, err3, out relation1);
            int procResult = HTuple.LoadNew(proc, 3, err4, out relation2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)regions2);
            return tuple;
        }

        /// <summary>
        ///   Shape factor for the convexity of a region.
        ///   Instance represents: Region(s) to be examined.
        /// </summary>
        /// <returns>Convexity of the input region(s).</returns>
        public HTuple Convexity()
        {
            IntPtr proc = HalconAPI.PreCall(1724);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Contour length of a region.
        ///   Instance represents: Region(s) to be examined.
        /// </summary>
        /// <returns>Contour length of the input region(s).</returns>
        public HTuple Contlength()
        {
            IntPtr proc = HalconAPI.PreCall(1725);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Number of connection components and holes
        ///   Instance represents: Region(s) to be examined.
        /// </summary>
        /// <param name="numHoles">Number of holes of a region.</param>
        /// <returns>Number of connection components of a region.</returns>
        public HTuple ConnectAndHoles(out HTuple numHoles)
        {
            IntPtr proc = HalconAPI.PreCall(1726);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out numHoles);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Number of connection components and holes
        ///   Instance represents: Region(s) to be examined.
        /// </summary>
        /// <param name="numHoles">Number of holes of a region.</param>
        /// <returns>Number of connection components of a region.</returns>
        public int ConnectAndHoles(out int numHoles)
        {
            IntPtr proc = HalconAPI.PreCall(1726);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int intValue;
            int err2 = HalconAPI.LoadI(proc, 0, err1, out intValue);
            int procResult = HalconAPI.LoadI(proc, 1, err2, out numHoles);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Shape factor for the rectangularity of a region.
        ///   Instance represents: Region(s) to be examined.
        /// </summary>
        /// <returns>Rectangularity of the input region(s).</returns>
        public HTuple Rectangularity()
        {
            IntPtr proc = HalconAPI.PreCall(1727);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Shape factor for the compactness of a region.
        ///   Instance represents: Region(s) to be examined.
        /// </summary>
        /// <returns>Compactness of the input region(s).</returns>
        public HTuple Compactness()
        {
            IntPtr proc = HalconAPI.PreCall(1728);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Shape factor for the circularity (similarity to a circle) of a region.
        ///   Instance represents: Region(s) to be examined.
        /// </summary>
        /// <returns>Circularity of the input region(s).</returns>
        public HTuple Circularity()
        {
            IntPtr proc = HalconAPI.PreCall(1729);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the area of holes of regions.
        ///   Instance represents: Region(s) to be examined.
        /// </summary>
        /// <returns>Area(s) of holes of the region(s).</returns>
        public HTuple AreaHoles()
        {
            IntPtr proc = HalconAPI.PreCall(1730);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Area and center of regions.
        ///   Instance represents: Region(s) to be examined.
        /// </summary>
        /// <param name="row">Line index of the center.</param>
        /// <param name="column">Column index of the center.</param>
        /// <returns>Area of the region.</returns>
        public HTuple AreaCenter(out HTuple row, out HTuple column)
        {
            IntPtr proc = HalconAPI.PreCall(1731);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out row);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out column);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Area and center of regions.
        ///   Instance represents: Region(s) to be examined.
        /// </summary>
        /// <param name="row">Line index of the center.</param>
        /// <param name="column">Column index of the center.</param>
        /// <returns>Area of the region.</returns>
        public int AreaCenter(out double row, out double column)
        {
            IntPtr proc = HalconAPI.PreCall(1731);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            int intValue;
            int err2 = HalconAPI.LoadI(proc, 0, err1, out intValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out row);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out column);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Distribution of runs needed for runlength encoding of a region.
        ///   Instance represents: Region to be examined.
        /// </summary>
        /// <param name="background">Length distribution of the background.</param>
        /// <returns>Length distribution of the region (foreground).</returns>
        public HTuple RunlengthDistribution(out HTuple background)
        {
            IntPtr proc = HalconAPI.PreCall(1732);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out background);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Shape factors from contour.
        ///   Instance represents: Region(s) to be examined.
        /// </summary>
        /// <param name="sigma">Standard deviation of Distance.</param>
        /// <param name="roundness">Shape factor for roundness.</param>
        /// <param name="sides">Number of polygon sides.</param>
        /// <returns>Mean distance from the center.</returns>
        public HTuple Roundness(out HTuple sigma, out HTuple roundness, out HTuple sides)
        {
            IntPtr proc = HalconAPI.PreCall(1733);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out sigma);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out roundness);
            int procResult = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out sides);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Shape factors from contour.
        ///   Instance represents: Region(s) to be examined.
        /// </summary>
        /// <param name="sigma">Standard deviation of Distance.</param>
        /// <param name="roundness">Shape factor for roundness.</param>
        /// <param name="sides">Number of polygon sides.</param>
        /// <returns>Mean distance from the center.</returns>
        public double Roundness(out double sigma, out double roundness, out double sides)
        {
            IntPtr proc = HalconAPI.PreCall(1733);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out sigma);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out roundness);
            int procResult = HalconAPI.LoadD(proc, 3, err4, out sides);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Largest inner rectangle of a region.
        ///   Instance represents: Region to be examined.
        /// </summary>
        /// <param name="row1">Row coordinate of the upper left corner point.</param>
        /// <param name="column1">Column coordinate of the upper left corner point.</param>
        /// <param name="row2">Row coordinate of the lower right corner point.</param>
        /// <param name="column2">Column coordinate of the lower right corner point.</param>
        public void InnerRectangle1(
          out HTuple row1,
          out HTuple column1,
          out HTuple row2,
          out HTuple column2)
        {
            IntPtr proc = HalconAPI.PreCall(1734);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out row1);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out column1);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, err3, out row2);
            int procResult = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, err4, out column2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Largest inner rectangle of a region.
        ///   Instance represents: Region to be examined.
        /// </summary>
        /// <param name="row1">Row coordinate of the upper left corner point.</param>
        /// <param name="column1">Column coordinate of the upper left corner point.</param>
        /// <param name="row2">Row coordinate of the lower right corner point.</param>
        /// <param name="column2">Column coordinate of the lower right corner point.</param>
        public void InnerRectangle1(out int row1, out int column1, out int row2, out int column2)
        {
            IntPtr proc = HalconAPI.PreCall(1734);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadI(proc, 0, err1, out row1);
            int err3 = HalconAPI.LoadI(proc, 1, err2, out column1);
            int err4 = HalconAPI.LoadI(proc, 2, err3, out row2);
            int procResult = HalconAPI.LoadI(proc, 3, err4, out column2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Largest inner circle of a region.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="row">Line index of the center.</param>
        /// <param name="column">Column index of the center.</param>
        /// <param name="radius">Radius of the inner circle.</param>
        public void InnerCircle(out HTuple row, out HTuple column, out HTuple radius)
        {
            IntPtr proc = HalconAPI.PreCall(1735);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out column);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out radius);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Largest inner circle of a region.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="row">Line index of the center.</param>
        /// <param name="column">Column index of the center.</param>
        /// <param name="radius">Radius of the inner circle.</param>
        public void InnerCircle(out double row, out double column, out double radius)
        {
            IntPtr proc = HalconAPI.PreCall(1735);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out row);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out column);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out radius);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Calculate gray value moments and approximation by a first order surface (plane).
        ///   Instance represents: Regions to be checked.
        /// </summary>
        /// <param name="image">Corresponding gray values.</param>
        /// <param name="algorithm">Algorithm for the fitting. Default: "regression"</param>
        /// <param name="iterations">Maximum number of iterations (unused for 'regression'). Default: 5</param>
        /// <param name="clippingFactor">Clipping factor for the elimination of outliers. Default: 2.0</param>
        /// <param name="beta">Parameter Beta of the approximating surface.</param>
        /// <param name="gamma">Parameter Gamma of the approximating surface.</param>
        /// <returns>Parameter Alpha of the approximating surface.</returns>
        public HTuple FitSurfaceFirstOrder(
          HImage image,
          string algorithm,
          int iterations,
          double clippingFactor,
          out HTuple beta,
          out HTuple gamma)
        {
            IntPtr proc = HalconAPI.PreCall(1743);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.StoreS(proc, 0, algorithm);
            HalconAPI.StoreI(proc, 1, iterations);
            HalconAPI.StoreD(proc, 2, clippingFactor);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out beta);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out gamma);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Calculate gray value moments and approximation by a first order surface (plane).
        ///   Instance represents: Regions to be checked.
        /// </summary>
        /// <param name="image">Corresponding gray values.</param>
        /// <param name="algorithm">Algorithm for the fitting. Default: "regression"</param>
        /// <param name="iterations">Maximum number of iterations (unused for 'regression'). Default: 5</param>
        /// <param name="clippingFactor">Clipping factor for the elimination of outliers. Default: 2.0</param>
        /// <param name="beta">Parameter Beta of the approximating surface.</param>
        /// <param name="gamma">Parameter Gamma of the approximating surface.</param>
        /// <returns>Parameter Alpha of the approximating surface.</returns>
        public double FitSurfaceFirstOrder(
          HImage image,
          string algorithm,
          int iterations,
          double clippingFactor,
          out double beta,
          out double gamma)
        {
            IntPtr proc = HalconAPI.PreCall(1743);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.StoreS(proc, 0, algorithm);
            HalconAPI.StoreI(proc, 1, iterations);
            HalconAPI.StoreD(proc, 2, clippingFactor);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out beta);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out gamma);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return doubleValue;
        }

        /// <summary>
        ///   Calculate gray value moments and approximation by a second order surface.
        ///   Instance represents: Regions to be checked.
        /// </summary>
        /// <param name="image">Corresponding gray values.</param>
        /// <param name="algorithm">Algorithm for the fitting. Default: "regression"</param>
        /// <param name="iterations">Maximum number of iterations (unused for 'regression'). Default: 5</param>
        /// <param name="clippingFactor">Clipping factor for the elimination of outliers. Default: 2.0</param>
        /// <param name="beta">Parameter Beta of the approximating surface.</param>
        /// <param name="gamma">Parameter Gamma of the approximating surface.</param>
        /// <param name="delta">Parameter Delta of the approximating surface.</param>
        /// <param name="epsilon">Parameter Epsilon of the approximating surface.</param>
        /// <param name="zeta">Parameter Zeta of the approximating surface.</param>
        /// <returns>Parameter Alpha of the approximating surface.</returns>
        public HTuple FitSurfaceSecondOrder(
          HImage image,
          string algorithm,
          int iterations,
          double clippingFactor,
          out HTuple beta,
          out HTuple gamma,
          out HTuple delta,
          out HTuple epsilon,
          out HTuple zeta)
        {
            IntPtr proc = HalconAPI.PreCall(1744);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.StoreS(proc, 0, algorithm);
            HalconAPI.StoreI(proc, 1, iterations);
            HalconAPI.StoreD(proc, 2, clippingFactor);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out beta);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out gamma);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out delta);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out epsilon);
            int procResult = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, err6, out zeta);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Calculate gray value moments and approximation by a second order surface.
        ///   Instance represents: Regions to be checked.
        /// </summary>
        /// <param name="image">Corresponding gray values.</param>
        /// <param name="algorithm">Algorithm for the fitting. Default: "regression"</param>
        /// <param name="iterations">Maximum number of iterations (unused for 'regression'). Default: 5</param>
        /// <param name="clippingFactor">Clipping factor for the elimination of outliers. Default: 2.0</param>
        /// <param name="beta">Parameter Beta of the approximating surface.</param>
        /// <param name="gamma">Parameter Gamma of the approximating surface.</param>
        /// <param name="delta">Parameter Delta of the approximating surface.</param>
        /// <param name="epsilon">Parameter Epsilon of the approximating surface.</param>
        /// <param name="zeta">Parameter Zeta of the approximating surface.</param>
        /// <returns>Parameter Alpha of the approximating surface.</returns>
        public double FitSurfaceSecondOrder(
          HImage image,
          string algorithm,
          int iterations,
          double clippingFactor,
          out double beta,
          out double gamma,
          out double delta,
          out double epsilon,
          out double zeta)
        {
            IntPtr proc = HalconAPI.PreCall(1744);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.StoreS(proc, 0, algorithm);
            HalconAPI.StoreI(proc, 1, iterations);
            HalconAPI.StoreD(proc, 2, clippingFactor);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out beta);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out gamma);
            int err5 = HalconAPI.LoadD(proc, 3, err4, out delta);
            int err6 = HalconAPI.LoadD(proc, 4, err5, out epsilon);
            int procResult = HalconAPI.LoadD(proc, 5, err6, out zeta);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return doubleValue;
        }

        /// <summary>
        ///   Determine a histogram of features along all threshold values.
        ///   Instance represents: Region in which the features are to be examined.
        /// </summary>
        /// <param name="image">Gray value image.</param>
        /// <param name="feature">Feature to be examined. Default: "convexity"</param>
        /// <param name="row">Row of the pixel which the region must contain. Default: 256</param>
        /// <param name="column">Column of the pixel which the region must contain. Default: 256</param>
        /// <param name="relativeHisto">Relative distribution of the feature.</param>
        /// <returns>Absolute distribution of the feature.</returns>
        public HTuple ShapeHistoPoint(
          HImage image,
          string feature,
          int row,
          int column,
          out HTuple relativeHisto)
        {
            IntPtr proc = HalconAPI.PreCall(1747);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.StoreS(proc, 0, feature);
            HalconAPI.StoreI(proc, 1, row);
            HalconAPI.StoreI(proc, 2, column);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out relativeHisto);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Determine a histogram of features along all threshold values.
        ///   Instance represents: Region in which the features are to be examined.
        /// </summary>
        /// <param name="image">Gray value image.</param>
        /// <param name="feature">Feature to be examined. Default: "connected_components"</param>
        /// <param name="relativeHisto">Relative distribution of the feature.</param>
        /// <returns>Absolute distribution of the feature.</returns>
        public HTuple ShapeHistoAll(HImage image, string feature, out HTuple relativeHisto)
        {
            IntPtr proc = HalconAPI.PreCall(1748);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.StoreS(proc, 0, feature);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out relativeHisto);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Calculates gray value features for a set of regions.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="image">Gray value image.</param>
        /// <param name="features">Names of the features. Default: "mean"</param>
        /// <returns>Value sof the features.</returns>
        public HTuple GrayFeatures(HImage image, HTuple features)
        {
            IntPtr proc = HalconAPI.PreCall(1749);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, features);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(features);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Calculates gray value features for a set of regions.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="image">Gray value image.</param>
        /// <param name="features">Names of the features. Default: "mean"</param>
        /// <returns>Value sof the features.</returns>
        public double GrayFeatures(HImage image, string features)
        {
            IntPtr proc = HalconAPI.PreCall(1749);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.StoreS(proc, 0, features);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return doubleValue;
        }

        /// <summary>
        ///   Select regions based on gray value features.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="image">Gray value image.</param>
        /// <param name="features">Names of the features. Default: "mean"</param>
        /// <param name="operation">Logical connection of features. Default: "and"</param>
        /// <param name="min">Lower limit(s) of features. Default: 128.0</param>
        /// <param name="max">Upper limit(s) of features. Default: 255.0</param>
        /// <returns>Regions having features within the limits.</returns>
        public HRegion SelectGray(
          HImage image,
          HTuple features,
          string operation,
          HTuple min,
          HTuple max)
        {
            IntPtr proc = HalconAPI.PreCall(1750);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, features);
            HalconAPI.StoreS(proc, 1, operation);
            HalconAPI.Store(proc, 2, min);
            HalconAPI.Store(proc, 3, max);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(features);
            HalconAPI.UnpinTuple(min);
            HalconAPI.UnpinTuple(max);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return hregion;
        }

        /// <summary>
        ///   Select regions based on gray value features.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="image">Gray value image.</param>
        /// <param name="features">Names of the features. Default: "mean"</param>
        /// <param name="operation">Logical connection of features. Default: "and"</param>
        /// <param name="min">Lower limit(s) of features. Default: 128.0</param>
        /// <param name="max">Upper limit(s) of features. Default: 255.0</param>
        /// <returns>Regions having features within the limits.</returns>
        public HRegion SelectGray(
          HImage image,
          string features,
          string operation,
          double min,
          double max)
        {
            IntPtr proc = HalconAPI.PreCall(1750);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.StoreS(proc, 0, features);
            HalconAPI.StoreS(proc, 1, operation);
            HalconAPI.StoreD(proc, 2, min);
            HalconAPI.StoreD(proc, 3, max);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return hregion;
        }

        /// <summary>
        ///   Determine the minimum and maximum gray values within regions.
        ///   Instance represents: Regions, the features of which are to be calculated.
        /// </summary>
        /// <param name="image">Gray value image.</param>
        /// <param name="percent">Percentage below (above) the absolute maximum (minimum). Default: 0</param>
        /// <param name="min">"Minimum" gray value.</param>
        /// <param name="max">"Maximum" gray value.</param>
        /// <param name="range">Difference between Max and Min.</param>
        public void MinMaxGray(
          HImage image,
          HTuple percent,
          out HTuple min,
          out HTuple max,
          out HTuple range)
        {
            IntPtr proc = HalconAPI.PreCall(1751);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, percent);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(percent);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out min);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out max);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out range);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Determine the minimum and maximum gray values within regions.
        ///   Instance represents: Regions, the features of which are to be calculated.
        /// </summary>
        /// <param name="image">Gray value image.</param>
        /// <param name="percent">Percentage below (above) the absolute maximum (minimum). Default: 0</param>
        /// <param name="min">"Minimum" gray value.</param>
        /// <param name="max">"Maximum" gray value.</param>
        /// <param name="range">Difference between Max and Min.</param>
        public void MinMaxGray(
          HImage image,
          double percent,
          out double min,
          out double max,
          out double range)
        {
            IntPtr proc = HalconAPI.PreCall(1751);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.StoreD(proc, 0, percent);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out min);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out max);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out range);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Calculate the mean and deviation of gray values.
        ///   Instance represents: Regions in which the features are calculated.
        /// </summary>
        /// <param name="image">Gray value image.</param>
        /// <param name="deviation">Deviation of gray values within a region.</param>
        /// <returns>Mean gray value of a region.</returns>
        public HTuple Intensity(HImage image, out HTuple deviation)
        {
            IntPtr proc = HalconAPI.PreCall(1752);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out deviation);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Calculate the mean and deviation of gray values.
        ///   Instance represents: Regions in which the features are calculated.
        /// </summary>
        /// <param name="image">Gray value image.</param>
        /// <param name="deviation">Deviation of gray values within a region.</param>
        /// <returns>Mean gray value of a region.</returns>
        public double Intensity(HImage image, out double deviation)
        {
            IntPtr proc = HalconAPI.PreCall(1752);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out deviation);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return doubleValue;
        }

        /// <summary>
        ///   Calculate the gray value distribution of a single channel image within a certain gray value range.
        ///   Instance represents: Region in which the histogram is to be calculated.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="min">Minimum gray value. Default: 0</param>
        /// <param name="max">Maximum gray value. Default: 255</param>
        /// <param name="numBins">Number of bins. Default: 256</param>
        /// <param name="binSize">Bin size.</param>
        /// <returns>Histogram to be calculated.</returns>
        public HTuple GrayHistoRange(
          HImage image,
          HTuple min,
          HTuple max,
          int numBins,
          out double binSize)
        {
            IntPtr proc = HalconAPI.PreCall(1753);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, min);
            HalconAPI.Store(proc, 1, max);
            HalconAPI.StoreI(proc, 2, numBins);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(min);
            HalconAPI.UnpinTuple(max);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out tuple);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out binSize);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Calculate the gray value distribution of a single channel image within a certain gray value range.
        ///   Instance represents: Region in which the histogram is to be calculated.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="min">Minimum gray value. Default: 0</param>
        /// <param name="max">Maximum gray value. Default: 255</param>
        /// <param name="numBins">Number of bins. Default: 256</param>
        /// <param name="binSize">Bin size.</param>
        /// <returns>Histogram to be calculated.</returns>
        public int GrayHistoRange(
          HImage image,
          double min,
          double max,
          int numBins,
          out double binSize)
        {
            IntPtr proc = HalconAPI.PreCall(1753);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.StoreD(proc, 0, min);
            HalconAPI.StoreD(proc, 1, max);
            HalconAPI.StoreI(proc, 2, numBins);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int intValue;
            int err2 = HalconAPI.LoadI(proc, 0, err1, out intValue);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out binSize);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return intValue;
        }

        /// <summary>
        ///   Calculate the histogram of two-channel gray value images.
        ///   Instance represents: Region in which the histogram is to be calculated.
        /// </summary>
        /// <param name="imageCol">Channel 1.</param>
        /// <param name="imageRow">Channel 2.</param>
        /// <returns>Histogram to be calculated.</returns>
        public HImage Histo2dim(HImage imageCol, HImage imageRow)
        {
            IntPtr proc = HalconAPI.PreCall(1754);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)imageCol);
            HalconAPI.Store(proc, 3, (HObjectBase)imageRow);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)imageCol);
            GC.KeepAlive((object)imageRow);
            return himage;
        }

        /// <summary>
        ///   Calculate the gray value distribution.
        ///   Instance represents: Region in which the histogram is to be calculated.
        /// </summary>
        /// <param name="image">Image the gray value distribution of which is to be calculated.</param>
        /// <param name="quantization">Quantization of the gray values. Default: 1.0</param>
        /// <returns>Absolute frequencies of the gray values.</returns>
        public HTuple GrayHistoAbs(HImage image, HTuple quantization)
        {
            IntPtr proc = HalconAPI.PreCall(1755);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, quantization);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(quantization);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Calculate the gray value distribution.
        ///   Instance represents: Region in which the histogram is to be calculated.
        /// </summary>
        /// <param name="image">Image the gray value distribution of which is to be calculated.</param>
        /// <param name="quantization">Quantization of the gray values. Default: 1.0</param>
        /// <returns>Absolute frequencies of the gray values.</returns>
        public HTuple GrayHistoAbs(HImage image, double quantization)
        {
            IntPtr proc = HalconAPI.PreCall(1755);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.StoreD(proc, 0, quantization);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Calculate the gray value distribution.
        ///   Instance represents: Region in which the histogram is to be calculated.
        /// </summary>
        /// <param name="image">Image the gray value distribution of which is to be calculated.</param>
        /// <param name="relativeHisto">Frequencies, normalized to the area of the region.</param>
        /// <returns>Absolute frequencies of the gray values.</returns>
        public HTuple GrayHisto(HImage image, out HTuple relativeHisto)
        {
            IntPtr proc = HalconAPI.PreCall(1756);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out relativeHisto);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Determine the entropy and anisotropy of images.
        ///   Instance represents: Regions where the features are to be determined.
        /// </summary>
        /// <param name="image">Gray value image.</param>
        /// <param name="anisotropy">Measure of the symmetry of gray value distribution.</param>
        /// <returns>Information content (entropy) of the gray values.</returns>
        public HTuple EntropyGray(HImage image, out HTuple anisotropy)
        {
            IntPtr proc = HalconAPI.PreCall(1757);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out anisotropy);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Determine the entropy and anisotropy of images.
        ///   Instance represents: Regions where the features are to be determined.
        /// </summary>
        /// <param name="image">Gray value image.</param>
        /// <param name="anisotropy">Measure of the symmetry of gray value distribution.</param>
        /// <returns>Information content (entropy) of the gray values.</returns>
        public double EntropyGray(HImage image, out double anisotropy)
        {
            IntPtr proc = HalconAPI.PreCall(1757);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out anisotropy);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return doubleValue;
        }

        /// <summary>
        ///   Calculate a co-occurrence matrix and derive gray value features thereof.
        ///   Instance represents: Region to be examined.
        /// </summary>
        /// <param name="image">Corresponding gray values.</param>
        /// <param name="ldGray">Number of gray values to be distinguished (2^LdGray@f$2^{LdGray}$). Default: 6</param>
        /// <param name="direction">Direction in which the matrix is to be calculated. Default: 0</param>
        /// <param name="correlation">Correlation of gray values.</param>
        /// <param name="homogeneity">Local homogeneity of gray values.</param>
        /// <param name="contrast">Gray value contrast.</param>
        /// <returns>Gray value energy.</returns>
        public HTuple CoocFeatureImage(
          HImage image,
          int ldGray,
          HTuple direction,
          out HTuple correlation,
          out HTuple homogeneity,
          out HTuple contrast)
        {
            IntPtr proc = HalconAPI.PreCall(1759);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.StoreI(proc, 0, ldGray);
            HalconAPI.Store(proc, 1, direction);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(direction);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out correlation);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out homogeneity);
            int procResult = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out contrast);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Calculate a co-occurrence matrix and derive gray value features thereof.
        ///   Instance represents: Region to be examined.
        /// </summary>
        /// <param name="image">Corresponding gray values.</param>
        /// <param name="ldGray">Number of gray values to be distinguished (2^LdGray@f$2^{LdGray}$). Default: 6</param>
        /// <param name="direction">Direction in which the matrix is to be calculated. Default: 0</param>
        /// <param name="correlation">Correlation of gray values.</param>
        /// <param name="homogeneity">Local homogeneity of gray values.</param>
        /// <param name="contrast">Gray value contrast.</param>
        /// <returns>Gray value energy.</returns>
        public double CoocFeatureImage(
          HImage image,
          int ldGray,
          int direction,
          out double correlation,
          out double homogeneity,
          out double contrast)
        {
            IntPtr proc = HalconAPI.PreCall(1759);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.StoreI(proc, 0, ldGray);
            HalconAPI.StoreI(proc, 1, direction);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out correlation);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out homogeneity);
            int procResult = HalconAPI.LoadD(proc, 3, err4, out contrast);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return doubleValue;
        }

        /// <summary>
        ///   Calculate the co-occurrence matrix of a region in an image.
        ///   Instance represents: Region to be checked.
        /// </summary>
        /// <param name="image">Image providing the gray values.</param>
        /// <param name="ldGray">Number of gray values to be distinguished (2^LdGray@f$2^{LdGray}$). Default: 6</param>
        /// <param name="direction">Direction of neighbor relation. Default: 0</param>
        /// <returns>Co-occurrence matrix (matrices).</returns>
        public HImage GenCoocMatrix(HImage image, int ldGray, int direction)
        {
            IntPtr proc = HalconAPI.PreCall(1760);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.StoreI(proc, 0, ldGray);
            HalconAPI.StoreI(proc, 1, direction);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return himage;
        }

        /// <summary>
        ///   Calculate gray value moments and approximation by a plane.
        ///   Instance represents: Regions to be checked.
        /// </summary>
        /// <param name="image">Corresponding gray values.</param>
        /// <param name="MRow">Mixed moments along a line.</param>
        /// <param name="MCol">Mixed moments along a column.</param>
        /// <param name="alpha">Parameter Alpha of the approximating plane.</param>
        /// <param name="beta">Parameter Beta of the approximating plane.</param>
        /// <param name="mean">Mean gray value.</param>
        public void MomentsGrayPlane(
          HImage image,
          out HTuple MRow,
          out HTuple MCol,
          out HTuple alpha,
          out HTuple beta,
          out HTuple mean)
        {
            IntPtr proc = HalconAPI.PreCall(1761);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out MRow);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out MCol);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out alpha);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out beta);
            int procResult = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out mean);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Calculate gray value moments and approximation by a plane.
        ///   Instance represents: Regions to be checked.
        /// </summary>
        /// <param name="image">Corresponding gray values.</param>
        /// <param name="MRow">Mixed moments along a line.</param>
        /// <param name="MCol">Mixed moments along a column.</param>
        /// <param name="alpha">Parameter Alpha of the approximating plane.</param>
        /// <param name="beta">Parameter Beta of the approximating plane.</param>
        /// <param name="mean">Mean gray value.</param>
        public void MomentsGrayPlane(
          HImage image,
          out double MRow,
          out double MCol,
          out double alpha,
          out double beta,
          out double mean)
        {
            IntPtr proc = HalconAPI.PreCall(1761);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out MRow);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out MCol);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out alpha);
            int err5 = HalconAPI.LoadD(proc, 3, err4, out beta);
            int procResult = HalconAPI.LoadD(proc, 4, err5, out mean);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Calculate the deviation of the gray values from the approximating image plane.
        ///   Instance represents: Regions, of which the plane deviation is to be calculated.
        /// </summary>
        /// <param name="image">Gray value image.</param>
        /// <returns>Deviation of the gray values within a region.</returns>
        public HTuple PlaneDeviation(HImage image)
        {
            IntPtr proc = HalconAPI.PreCall(1762);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Compute the orientation and major axes of a region in a gray value image.
        ///   Instance represents: Region(s) to be examined.
        /// </summary>
        /// <param name="image">Gray value image.</param>
        /// <param name="rb">Minor axis of the region.</param>
        /// <param name="phi">Angle enclosed by the major axis and the x-axis.</param>
        /// <returns>Major axis of the region.</returns>
        public HTuple EllipticAxisGray(HImage image, out HTuple rb, out HTuple phi)
        {
            IntPtr proc = HalconAPI.PreCall(1763);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out rb);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out phi);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Compute the orientation and major axes of a region in a gray value image.
        ///   Instance represents: Region(s) to be examined.
        /// </summary>
        /// <param name="image">Gray value image.</param>
        /// <param name="rb">Minor axis of the region.</param>
        /// <param name="phi">Angle enclosed by the major axis and the x-axis.</param>
        /// <returns>Major axis of the region.</returns>
        public double EllipticAxisGray(HImage image, out double rb, out double phi)
        {
            IntPtr proc = HalconAPI.PreCall(1763);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out rb);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out phi);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return doubleValue;
        }

        /// <summary>
        ///   Compute the area and center of gravity of a region in a gray value image.
        ///   Instance represents: Region(s) to be examined.
        /// </summary>
        /// <param name="image">Gray value image.</param>
        /// <param name="row">Row coordinate of the gray value center of gravity.</param>
        /// <param name="column">Column coordinate of the gray value center of gravity.</param>
        /// <returns>Gray value volume of the region.</returns>
        public HTuple AreaCenterGray(HImage image, out HTuple row, out HTuple column)
        {
            IntPtr proc = HalconAPI.PreCall(1764);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out row);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out column);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Compute the area and center of gravity of a region in a gray value image.
        ///   Instance represents: Region(s) to be examined.
        /// </summary>
        /// <param name="image">Gray value image.</param>
        /// <param name="row">Row coordinate of the gray value center of gravity.</param>
        /// <param name="column">Column coordinate of the gray value center of gravity.</param>
        /// <returns>Gray value volume of the region.</returns>
        public double AreaCenterGray(HImage image, out double row, out double column)
        {
            IntPtr proc = HalconAPI.PreCall(1764);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out row);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out column);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return doubleValue;
        }

        /// <summary>
        ///   Calculate horizontal and vertical gray-value projections.
        ///   Instance represents: Region to be processed.
        /// </summary>
        /// <param name="image">Grayvalues for projections.</param>
        /// <param name="mode">Method to compute the projections. Default: "simple"</param>
        /// <param name="vertProjection">Vertical projection.</param>
        /// <returns>Horizontal projection.</returns>
        public HTuple GrayProjections(HImage image, string mode, out HTuple vertProjection)
        {
            IntPtr proc = HalconAPI.PreCall(1765);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out vertProjection);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Asynchronous grab of images and preprocessed image data from the specified image acquisition device.
        ///   Modified instance represents: Pre-processed image regions.
        /// </summary>
        /// <param name="contours">Pre-processed XLD contours.</param>
        /// <param name="acqHandle">Handle of the acquisition device to be used.</param>
        /// <param name="maxDelay">Maximum tolerated delay between the start of the asynchronous grab and the delivery of the image [ms]. Default: -1.0</param>
        /// <param name="data">Pre-processed control data.</param>
        /// <returns>Grabbed image data.</returns>
        public HImage GrabDataAsync(
          out HXLDCont contours,
          HFramegrabber acqHandle,
          double maxDelay,
          out HTuple data)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(2029);
            HalconAPI.Store(proc, 0, (HTool)acqHandle);
            HalconAPI.StoreD(proc, 1, maxDelay);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 0);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = this.Load(proc, 2, err1);
            HImage himage;
            int err3 = HImage.LoadNew(proc, 1, err2, out himage);
            int err4 = HXLDCont.LoadNew(proc, 3, err3, out contours);
            int procResult = HTuple.LoadNew(proc, 0, err4, out data);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)acqHandle);
            return himage;
        }

        /// <summary>
        ///   Asynchronous grab of images and preprocessed image data from the specified image acquisition device.
        ///   Modified instance represents: Pre-processed image regions.
        /// </summary>
        /// <param name="contours">Pre-processed XLD contours.</param>
        /// <param name="acqHandle">Handle of the acquisition device to be used.</param>
        /// <param name="maxDelay">Maximum tolerated delay between the start of the asynchronous grab and the delivery of the image [ms]. Default: -1.0</param>
        /// <param name="data">Pre-processed control data.</param>
        /// <returns>Grabbed image data.</returns>
        public HImage GrabDataAsync(
          out HXLDCont contours,
          HFramegrabber acqHandle,
          double maxDelay,
          out string data)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(2029);
            HalconAPI.Store(proc, 0, (HTool)acqHandle);
            HalconAPI.StoreD(proc, 1, maxDelay);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 0);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = this.Load(proc, 2, err1);
            HImage himage;
            int err3 = HImage.LoadNew(proc, 1, err2, out himage);
            int err4 = HXLDCont.LoadNew(proc, 3, err3, out contours);
            int procResult = HalconAPI.LoadS(proc, 0, err4, out data);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)acqHandle);
            return himage;
        }

        /// <summary>
        ///   Synchronous grab of images and preprocessed image data from the specified image acquisition device.
        ///   Modified instance represents: Preprocessed image regions.
        /// </summary>
        /// <param name="contours">Preprocessed XLD contours.</param>
        /// <param name="acqHandle">Handle of the acquisition device to be used.</param>
        /// <param name="data">Preprocessed control data.</param>
        /// <returns>Grabbed image data.</returns>
        public HImage GrabData(out HXLDCont contours, HFramegrabber acqHandle, out HTuple data)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(2030);
            HalconAPI.Store(proc, 0, (HTool)acqHandle);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 0);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = this.Load(proc, 2, err1);
            HImage himage;
            int err3 = HImage.LoadNew(proc, 1, err2, out himage);
            int err4 = HXLDCont.LoadNew(proc, 3, err3, out contours);
            int procResult = HTuple.LoadNew(proc, 0, err4, out data);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)acqHandle);
            return himage;
        }

        /// <summary>
        ///   Synchronous grab of images and preprocessed image data from the specified image acquisition device.
        ///   Modified instance represents: Preprocessed image regions.
        /// </summary>
        /// <param name="contours">Preprocessed XLD contours.</param>
        /// <param name="acqHandle">Handle of the acquisition device to be used.</param>
        /// <param name="data">Preprocessed control data.</param>
        /// <returns>Grabbed image data.</returns>
        public HImage GrabData(out HXLDCont contours, HFramegrabber acqHandle, out string data)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(2030);
            HalconAPI.Store(proc, 0, (HTool)acqHandle);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 0);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = this.Load(proc, 2, err1);
            HImage himage;
            int err3 = HImage.LoadNew(proc, 1, err2, out himage);
            int err4 = HXLDCont.LoadNew(proc, 3, err3, out contours);
            int procResult = HalconAPI.LoadS(proc, 0, err4, out data);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)acqHandle);
            return himage;
        }

        /// <summary>
        ///   Classify multiple characters with an CNN-based OCR classifier.
        ///   Instance represents: Characters to be recognized.
        /// </summary>
        /// <param name="image">Gray values of the characters.</param>
        /// <param name="OCRHandle">Handle of the OCR classifier.</param>
        /// <param name="confidence">Confidence of the class of the characters.</param>
        /// <returns>Result of classifying the characters with the CNN.</returns>
        public HTuple DoOcrMultiClassCnn(HImage image, HOCRCnn OCRHandle, out HTuple confidence)
        {
            IntPtr proc = HalconAPI.PreCall(2056);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)OCRHandle);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out confidence);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)OCRHandle);
            return tuple;
        }

        /// <summary>
        ///   Classify multiple characters with an CNN-based OCR classifier.
        ///   Instance represents: Characters to be recognized.
        /// </summary>
        /// <param name="image">Gray values of the characters.</param>
        /// <param name="OCRHandle">Handle of the OCR classifier.</param>
        /// <param name="confidence">Confidence of the class of the characters.</param>
        /// <returns>Result of classifying the characters with the CNN.</returns>
        public string DoOcrMultiClassCnn(HImage image, HOCRCnn OCRHandle, out double confidence)
        {
            IntPtr proc = HalconAPI.PreCall(2056);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)OCRHandle);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            string stringValue;
            int err2 = HalconAPI.LoadS(proc, 0, err1, out stringValue);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out confidence);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)OCRHandle);
            return stringValue;
        }

        /// <summary>
        ///   Classify a single character with an CNN-based OCR classifier.
        ///   Instance represents: Character to be recognized.
        /// </summary>
        /// <param name="image">Gray values of the character.</param>
        /// <param name="OCRHandle">Handle of the OCR classifier.</param>
        /// <param name="num">Number of best classes to determine. Default: 1</param>
        /// <param name="confidence">Confidence(s) of the class(es) of the character.</param>
        /// <returns>Result of classifying the character with the CNN.</returns>
        public HTuple DoOcrSingleClassCnn(
          HImage image,
          HOCRCnn OCRHandle,
          HTuple num,
          out HTuple confidence)
        {
            IntPtr proc = HalconAPI.PreCall(2057);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)OCRHandle);
            HalconAPI.Store(proc, 1, num);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(num);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out confidence);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)OCRHandle);
            return tuple;
        }

        /// <summary>
        ///   Classify a single character with an CNN-based OCR classifier.
        ///   Instance represents: Character to be recognized.
        /// </summary>
        /// <param name="image">Gray values of the character.</param>
        /// <param name="OCRHandle">Handle of the OCR classifier.</param>
        /// <param name="num">Number of best classes to determine. Default: 1</param>
        /// <param name="confidence">Confidence(s) of the class(es) of the character.</param>
        /// <returns>Result of classifying the character with the CNN.</returns>
        public string DoOcrSingleClassCnn(
          HImage image,
          HOCRCnn OCRHandle,
          HTuple num,
          out double confidence)
        {
            IntPtr proc = HalconAPI.PreCall(2057);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)OCRHandle);
            HalconAPI.Store(proc, 1, num);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(num);
            string stringValue;
            int err2 = HalconAPI.LoadS(proc, 0, err1, out stringValue);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out confidence);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)OCRHandle);
            return stringValue;
        }

        /// <summary>
        ///   Classify a related group of characters with an CNN-based OCR classifier.
        ///   Instance represents: Characters to be recognized.
        /// </summary>
        /// <param name="image">Gray values of the characters.</param>
        /// <param name="OCRHandle">Handle of the OCR classifier.</param>
        /// <param name="expression">Expression describing the allowed word structure.</param>
        /// <param name="numAlternatives">Number of classes per character considered for the internal word correction. Default: 3</param>
        /// <param name="numCorrections">Maximum number of corrected characters. Default: 2</param>
        /// <param name="confidence">Confidence of the class of the characters.</param>
        /// <param name="word">Word text after classification and correction.</param>
        /// <param name="score">Measure of similarity between corrected word and uncorrected classification results.</param>
        /// <returns>Result of classifying the characters with the CNN.</returns>
        public HTuple DoOcrWordCnn(
          HImage image,
          HOCRCnn OCRHandle,
          string expression,
          int numAlternatives,
          int numCorrections,
          out HTuple confidence,
          out string word,
          out double score)
        {
            IntPtr proc = HalconAPI.PreCall(2058);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)OCRHandle);
            HalconAPI.StoreS(proc, 1, expression);
            HalconAPI.StoreI(proc, 2, numAlternatives);
            HalconAPI.StoreI(proc, 3, numCorrections);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out confidence);
            int err4 = HalconAPI.LoadS(proc, 2, err3, out word);
            int procResult = HalconAPI.LoadD(proc, 3, err4, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)OCRHandle);
            return tuple;
        }

        /// <summary>
        ///   Classify a related group of characters with an CNN-based OCR classifier.
        ///   Instance represents: Characters to be recognized.
        /// </summary>
        /// <param name="image">Gray values of the characters.</param>
        /// <param name="OCRHandle">Handle of the OCR classifier.</param>
        /// <param name="expression">Expression describing the allowed word structure.</param>
        /// <param name="numAlternatives">Number of classes per character considered for the internal word correction. Default: 3</param>
        /// <param name="numCorrections">Maximum number of corrected characters. Default: 2</param>
        /// <param name="confidence">Confidence of the class of the characters.</param>
        /// <param name="word">Word text after classification and correction.</param>
        /// <param name="score">Measure of similarity between corrected word and uncorrected classification results.</param>
        /// <returns>Result of classifying the characters with the CNN.</returns>
        public string DoOcrWordCnn(
          HImage image,
          HOCRCnn OCRHandle,
          string expression,
          int numAlternatives,
          int numCorrections,
          out double confidence,
          out string word,
          out double score)
        {
            IntPtr proc = HalconAPI.PreCall(2058);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)OCRHandle);
            HalconAPI.StoreS(proc, 1, expression);
            HalconAPI.StoreI(proc, 2, numAlternatives);
            HalconAPI.StoreI(proc, 3, numCorrections);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            string stringValue;
            int err2 = HalconAPI.LoadS(proc, 0, err1, out stringValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out confidence);
            int err4 = HalconAPI.LoadS(proc, 2, err3, out word);
            int procResult = HalconAPI.LoadD(proc, 3, err4, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)OCRHandle);
            return stringValue;
        }

        /// <summary>
        ///   Compute the width, height, and aspect ratio of the surrounding rectangle parallel to the coordinate axes.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="width">Width of the surrounding rectangle of the region.</param>
        /// <param name="ratio">Aspect ratio of the surrounding rectangle of the region.</param>
        /// <returns>Height of the surrounding rectangle of the region.</returns>
        public HTuple HeightWidthRatio(out HTuple width, out HTuple ratio)
        {
            IntPtr proc = HalconAPI.PreCall(2119);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out width);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out ratio);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the width, height, and aspect ratio of the surrounding rectangle parallel to the coordinate axes.
        ///   Instance represents: Regions to be examined.
        /// </summary>
        /// <param name="width">Width of the surrounding rectangle of the region.</param>
        /// <param name="ratio">Aspect ratio of the surrounding rectangle of the region.</param>
        /// <returns>Height of the surrounding rectangle of the region.</returns>
        public int HeightWidthRatio(out int width, out double ratio)
        {
            IntPtr proc = HalconAPI.PreCall(2119);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            int intValue;
            int err2 = HalconAPI.LoadI(proc, 0, err1, out intValue);
            int err3 = HalconAPI.LoadI(proc, 1, err2, out width);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out ratio);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Insert objects into an iconic object tuple.
        ///   Instance represents: Input object tuple.
        /// </summary>
        /// <param name="objectsInsert">Object tuple to insert.</param>
        /// <param name="index">Index to insert objects.</param>
        /// <returns>Extended object tuple.</returns>
        public HRegion InsertObj(HRegion objectsInsert, int index)
        {
            IntPtr proc = HalconAPI.PreCall(2121);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objectsInsert);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectsInsert);
            return hregion;
        }

        /// <summary>
        ///   Remove objects from an iconic object tuple.
        ///   Instance represents: Input object tuple.
        /// </summary>
        /// <param name="index">Indices of the objects to be removed.</param>
        /// <returns>Remaining object tuple.</returns>
        public HRegion RemoveObj(HTuple index)
        {
            IntPtr proc = HalconAPI.PreCall(2124);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Remove objects from an iconic object tuple.
        ///   Instance represents: Input object tuple.
        /// </summary>
        /// <param name="index">Indices of the objects to be removed.</param>
        /// <returns>Remaining object tuple.</returns>
        public HRegion RemoveObj(int index)
        {
            IntPtr proc = HalconAPI.PreCall(2124);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Replaces one or more elements of an iconic object tuple.
        ///   Instance represents: Iconic Input Object.
        /// </summary>
        /// <param name="objectsReplace">Element(s) to replace.</param>
        /// <param name="index">Index/Indices of elements to be replaced.</param>
        /// <returns>Tuple with replaced elements.</returns>
        public HRegion ReplaceObj(HRegion objectsReplace, HTuple index)
        {
            IntPtr proc = HalconAPI.PreCall(2125);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objectsReplace);
            HalconAPI.Store(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectsReplace);
            return hregion;
        }

        /// <summary>
        ///   Replaces one or more elements of an iconic object tuple.
        ///   Instance represents: Iconic Input Object.
        /// </summary>
        /// <param name="objectsReplace">Element(s) to replace.</param>
        /// <param name="index">Index/Indices of elements to be replaced.</param>
        /// <returns>Tuple with replaced elements.</returns>
        public HRegion ReplaceObj(HRegion objectsReplace, int index)
        {
            IntPtr proc = HalconAPI.PreCall(2125);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objectsReplace);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectsReplace);
            return hregion;
        }
    }
}