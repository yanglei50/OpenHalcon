// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HXLDPara
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;

namespace HalconDotNet
{
    /// <summary>Represents an instance of an XLD parallel object(-array).</summary>
    [Serializable]
    public class HXLDPara : HXLD
    {
        /// <summary>Create an uninitialized iconic object</summary>
        public HXLDPara()
          : base(HObjectBase.UNDEF, false)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HXLDPara(IntPtr key)
          : this(key, true)
        {
            this.AssertObjectClass();
            GC.KeepAlive((object)this);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HXLDPara(IntPtr key, bool copy)
          : base(key, copy)
        {
            this.AssertObjectClass();
            GC.KeepAlive((object)this);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HXLDPara(HObject obj)
          : base(obj)
        {
            this.AssertObjectClass();
            GC.KeepAlive((object)this);
        }

        private void AssertObjectClass()
        {
            HalconAPI.AssertObjectClass(this.key, "xld_para");
        }

        /// <summary>Returns the iconic object(s) at the specified index</summary>
        public HXLDPara this[HTuple index]
        {
            get
            {
                return this.SelectObj(index);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int LoadNew(IntPtr proc, int parIndex, int err, out HXLDPara obj)
        {
            obj = new HXLDPara(HObjectBase.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        /// <summary>
        ///   Extract parallel XLD polygons enclosing a homogeneous area.
        ///   Instance represents: Input XLD parallels.
        /// </summary>
        /// <param name="image">Corresponding gray value image.</param>
        /// <param name="extParallels">Extended XLD parallels.</param>
        /// <param name="quality">Minimum quality factor (measure of parallelism). Default: 0.4</param>
        /// <param name="minGray">Minimum mean gray value. Default: 160</param>
        /// <param name="maxGray">Maximum mean gray value. Default: 220</param>
        /// <param name="maxStandard">Maximum allowed standard deviation. Default: 10.0</param>
        /// <returns>Modified XLD parallels.</returns>
        public HXLDModPara ModParallelsXld(
          HImage image,
          out HXLDExtPara extParallels,
          HTuple quality,
          int minGray,
          int maxGray,
          HTuple maxStandard)
        {
            IntPtr proc = HalconAPI.PreCall(39);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, quality);
            HalconAPI.StoreI(proc, 1, minGray);
            HalconAPI.StoreI(proc, 2, maxGray);
            HalconAPI.Store(proc, 3, maxStandard);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(quality);
            HalconAPI.UnpinTuple(maxStandard);
            HXLDModPara hxldModPara;
            int err2 = HXLDModPara.LoadNew(proc, 1, err1, out hxldModPara);
            int procResult = HXLDExtPara.LoadNew(proc, 2, err2, out extParallels);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return hxldModPara;
        }

        /// <summary>
        ///   Extract parallel XLD polygons enclosing a homogeneous area.
        ///   Instance represents: Input XLD parallels.
        /// </summary>
        /// <param name="image">Corresponding gray value image.</param>
        /// <param name="extParallels">Extended XLD parallels.</param>
        /// <param name="quality">Minimum quality factor (measure of parallelism). Default: 0.4</param>
        /// <param name="minGray">Minimum mean gray value. Default: 160</param>
        /// <param name="maxGray">Maximum mean gray value. Default: 220</param>
        /// <param name="maxStandard">Maximum allowed standard deviation. Default: 10.0</param>
        /// <returns>Modified XLD parallels.</returns>
        public HXLDModPara ModParallelsXld(
          HImage image,
          out HXLDExtPara extParallels,
          double quality,
          int minGray,
          int maxGray,
          double maxStandard)
        {
            IntPtr proc = HalconAPI.PreCall(39);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.StoreD(proc, 0, quality);
            HalconAPI.StoreI(proc, 1, minGray);
            HalconAPI.StoreI(proc, 2, maxGray);
            HalconAPI.StoreD(proc, 3, maxStandard);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HXLDModPara hxldModPara;
            int err2 = HXLDModPara.LoadNew(proc, 1, err1, out hxldModPara);
            int procResult = HXLDExtPara.LoadNew(proc, 2, err2, out extParallels);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return hxldModPara;
        }

        /// <summary>
        ///   Return information about the gray values of the area enclosed by XLD parallels.
        ///   Instance represents: Input XLD Parallels.
        /// </summary>
        /// <param name="image">Corresponding gray value image.</param>
        /// <param name="qualityMin">Minimum quality factor.</param>
        /// <param name="qualityMax">Maximum quality factor.</param>
        /// <param name="grayMin">Minimum mean gray value.</param>
        /// <param name="grayMax">Maximum mean gray value.</param>
        /// <param name="standardMin">Minimum standard deviation.</param>
        /// <param name="standardMax">Maximum standard deviation.</param>
        public void InfoParallelsXld(
          HImage image,
          out double qualityMin,
          out double qualityMax,
          out int grayMin,
          out int grayMax,
          out double standardMin,
          out double standardMax)
        {
            IntPtr proc = HalconAPI.PreCall(40);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out qualityMin);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out qualityMax);
            int err4 = HalconAPI.LoadI(proc, 2, err3, out grayMin);
            int err5 = HalconAPI.LoadI(proc, 3, err4, out grayMax);
            int err6 = HalconAPI.LoadD(proc, 4, err5, out standardMin);
            int procResult = HalconAPI.LoadD(proc, 5, err6, out standardMax);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Calculate the difference of two object tuples.
        ///   Instance represents: Object tuple 1.
        /// </summary>
        /// <param name="objectsSub">Object tuple 2.</param>
        /// <returns>Objects from Objects that are not part of ObjectsSub.</returns>
        public HXLDPara ObjDiff(HXLDPara objectsSub)
        {
            IntPtr proc = HalconAPI.PreCall(573);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objectsSub);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDPara hxldPara;
            int procResult = HXLDPara.LoadNew(proc, 1, err, out hxldPara);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectsSub);
            return hxldPara;
        }

        /// <summary>
        ///   Copy an iconic object in the HALCON database.
        ///   Instance represents: Objects to be copied.
        /// </summary>
        /// <param name="index">Starting index of the objects to be copied. Default: 1</param>
        /// <param name="numObj">Number of objects to be copied or -1. Default: 1</param>
        /// <returns>Copied objects.</returns>
        public HXLDPara CopyObj(int index, int numObj)
        {
            IntPtr proc = HalconAPI.PreCall(583);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.StoreI(proc, 1, numObj);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDPara hxldPara;
            int procResult = HXLDPara.LoadNew(proc, 1, err, out hxldPara);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldPara;
        }

        /// <summary>
        ///   Concatenate two iconic object tuples.
        ///   Instance represents: Object tuple 1.
        /// </summary>
        /// <param name="objects2">Object tuple 2.</param>
        /// <returns>Concatenated objects.</returns>
        public HXLDPara ConcatObj(HXLDPara objects2)
        {
            IntPtr proc = HalconAPI.PreCall(584);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objects2);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDPara hxldPara;
            int procResult = HXLDPara.LoadNew(proc, 1, err, out hxldPara);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objects2);
            return hxldPara;
        }

        /// <summary>
        ///   Select objects from an object tuple.
        ///   Instance represents: Input objects.
        /// </summary>
        /// <param name="index">Indices of the objects to be selected. Default: 1</param>
        /// <returns>Selected objects.</returns>
        public HXLDPara SelectObj(HTuple index)
        {
            IntPtr proc = HalconAPI.PreCall(587);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HXLDPara hxldPara;
            int procResult = HXLDPara.LoadNew(proc, 1, err, out hxldPara);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldPara;
        }

        /// <summary>
        ///   Select objects from an object tuple.
        ///   Instance represents: Input objects.
        /// </summary>
        /// <param name="index">Indices of the objects to be selected. Default: 1</param>
        /// <returns>Selected objects.</returns>
        public HXLDPara SelectObj(int index)
        {
            IntPtr proc = HalconAPI.PreCall(587);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDPara hxldPara;
            int procResult = HXLDPara.LoadNew(proc, 1, err, out hxldPara);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldPara;
        }

        /// <summary>
        ///   Compare iconic objects regarding equality.
        ///   Instance represents: Reference objects.
        /// </summary>
        /// <param name="objects2">Test objects.</param>
        /// <param name="epsilon">Maximum allowed difference between two gray values or  coordinates etc. Default: 0.0</param>
        /// <returns>Boolean result value.</returns>
        public int CompareObj(HXLDPara objects2, HTuple epsilon)
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
        public int CompareObj(HXLDPara objects2, double epsilon)
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
        ///   Compare image objects regarding equality.
        ///   Instance represents: Test objects.
        /// </summary>
        /// <param name="objects2">Comparative objects.</param>
        /// <returns>boolean result value.</returns>
        public int TestEqualObj(HXLDPara objects2)
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
        ///   Compute the mapping between the distorted image and the rectified image based upon the points of a regular grid.
        ///   Instance represents: Input contours.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="meshes">Output contours.</param>
        /// <param name="gridSpacing">Distance of the grid points in the rectified image.</param>
        /// <param name="rotation">Rotation to be applied to the point grid. Default: "auto"</param>
        /// <param name="row">Row coordinates of the grid points.</param>
        /// <param name="column">Column coordinates of the grid points.</param>
        /// <param name="mapType">Type of mapping. Default: "bilinear"</param>
        /// <returns>Image containing the mapping data.</returns>
        public HImage GenGridRectificationMap(
          HImage image,
          out HXLDPara meshes,
          int gridSpacing,
          HTuple rotation,
          HTuple row,
          HTuple column,
          string mapType)
        {
            IntPtr proc = HalconAPI.PreCall(1159);
            this.Store(proc, 2);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreI(proc, 0, gridSpacing);
            HalconAPI.Store(proc, 1, rotation);
            HalconAPI.Store(proc, 2, row);
            HalconAPI.Store(proc, 3, column);
            HalconAPI.StoreS(proc, 4, mapType);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(rotation);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HImage himage;
            int err2 = HImage.LoadNew(proc, 1, err1, out himage);
            int procResult = HXLDPara.LoadNew(proc, 2, err2, out meshes);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return himage;
        }

        /// <summary>
        ///   Compute the mapping between the distorted image and the rectified image based upon the points of a regular grid.
        ///   Instance represents: Input contours.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="meshes">Output contours.</param>
        /// <param name="gridSpacing">Distance of the grid points in the rectified image.</param>
        /// <param name="rotation">Rotation to be applied to the point grid. Default: "auto"</param>
        /// <param name="row">Row coordinates of the grid points.</param>
        /// <param name="column">Column coordinates of the grid points.</param>
        /// <param name="mapType">Type of mapping. Default: "bilinear"</param>
        /// <returns>Image containing the mapping data.</returns>
        public HImage GenGridRectificationMap(
          HImage image,
          out HXLDPara meshes,
          int gridSpacing,
          string rotation,
          HTuple row,
          HTuple column,
          string mapType)
        {
            IntPtr proc = HalconAPI.PreCall(1159);
            this.Store(proc, 2);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreI(proc, 0, gridSpacing);
            HalconAPI.StoreS(proc, 1, rotation);
            HalconAPI.Store(proc, 2, row);
            HalconAPI.Store(proc, 3, column);
            HalconAPI.StoreS(proc, 4, mapType);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HImage himage;
            int err2 = HImage.LoadNew(proc, 1, err1, out himage);
            int procResult = HXLDPara.LoadNew(proc, 2, err2, out meshes);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return himage;
        }

        /// <summary>
        ///   Choose all contours or polygons containing a given point.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="row">Line coordinate of the test point. Default: 100.0</param>
        /// <param name="column">Column coordinate of the test point. Default: 100.0</param>
        /// <returns>All contours or polygons containing the test point.</returns>
        public HXLDPara SelectXldPoint(HTuple row, HTuple column)
        {
            IntPtr proc = HalconAPI.PreCall(1676);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, column);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HXLDPara hxldPara;
            int procResult = HXLDPara.LoadNew(proc, 1, err, out hxldPara);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldPara;
        }

        /// <summary>
        ///   Choose all contours or polygons containing a given point.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="row">Line coordinate of the test point. Default: 100.0</param>
        /// <param name="column">Column coordinate of the test point. Default: 100.0</param>
        /// <returns>All contours or polygons containing the test point.</returns>
        public HXLDPara SelectXldPoint(double row, double column)
        {
            IntPtr proc = HalconAPI.PreCall(1676);
            this.Store(proc, 1);
            HalconAPI.StoreD(proc, 0, row);
            HalconAPI.StoreD(proc, 1, column);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDPara hxldPara;
            int procResult = HXLDPara.LoadNew(proc, 1, err, out hxldPara);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldPara;
        }

        /// <summary>
        ///   Select contours or polygons using shape features.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="features">Shape features to be checked. Default: "area"</param>
        /// <param name="operation">Operation type between the individual features. Default: "and"</param>
        /// <param name="min">Lower limits of the features or 'min'. Default: 150.0</param>
        /// <param name="max">Upper limits of the features or 'max'. Default: 99999.0</param>
        /// <returns>Contours or polygons fulfilling the condition(s).</returns>
        public HXLDPara SelectShapeXld(
          HTuple features,
          string operation,
          HTuple min,
          HTuple max)
        {
            IntPtr proc = HalconAPI.PreCall(1678);
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
            HXLDPara hxldPara;
            int procResult = HXLDPara.LoadNew(proc, 1, err, out hxldPara);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldPara;
        }

        /// <summary>
        ///   Select contours or polygons using shape features.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="features">Shape features to be checked. Default: "area"</param>
        /// <param name="operation">Operation type between the individual features. Default: "and"</param>
        /// <param name="min">Lower limits of the features or 'min'. Default: 150.0</param>
        /// <param name="max">Upper limits of the features or 'max'. Default: 99999.0</param>
        /// <returns>Contours or polygons fulfilling the condition(s).</returns>
        public HXLDPara SelectShapeXld(
          string features,
          string operation,
          double min,
          double max)
        {
            IntPtr proc = HalconAPI.PreCall(1678);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, features);
            HalconAPI.StoreS(proc, 1, operation);
            HalconAPI.StoreD(proc, 2, min);
            HalconAPI.StoreD(proc, 3, max);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDPara hxldPara;
            int procResult = HXLDPara.LoadNew(proc, 1, err, out hxldPara);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldPara;
        }

        /// <summary>
        ///   Transform the shape of contours or polygons.
        ///   Instance represents: Contours or polygons to be transformed.
        /// </summary>
        /// <param name="type">Type of transformation. Default: "convex"</param>
        /// <returns>Transformed contours respectively polygons.</returns>
        public HXLDPara ShapeTransXld(string type)
        {
            IntPtr proc = HalconAPI.PreCall(1689);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, type);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDPara hxldPara;
            int procResult = HXLDPara.LoadNew(proc, 1, err, out hxldPara);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldPara;
        }

        /// <summary>
        ///   Insert objects into an iconic object tuple.
        ///   Instance represents: Input object tuple.
        /// </summary>
        /// <param name="objectsInsert">Object tuple to insert.</param>
        /// <param name="index">Index to insert objects.</param>
        /// <returns>Extended object tuple.</returns>
        public HXLDPara InsertObj(HXLDPara objectsInsert, int index)
        {
            IntPtr proc = HalconAPI.PreCall(2121);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objectsInsert);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDPara hxldPara;
            int procResult = HXLDPara.LoadNew(proc, 1, err, out hxldPara);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectsInsert);
            return hxldPara;
        }

        /// <summary>
        ///   Remove objects from an iconic object tuple.
        ///   Instance represents: Input object tuple.
        /// </summary>
        /// <param name="index">Indices of the objects to be removed.</param>
        /// <returns>Remaining object tuple.</returns>
        public HXLDPara RemoveObj(HTuple index)
        {
            IntPtr proc = HalconAPI.PreCall(2124);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HXLDPara hxldPara;
            int procResult = HXLDPara.LoadNew(proc, 1, err, out hxldPara);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldPara;
        }

        /// <summary>
        ///   Remove objects from an iconic object tuple.
        ///   Instance represents: Input object tuple.
        /// </summary>
        /// <param name="index">Indices of the objects to be removed.</param>
        /// <returns>Remaining object tuple.</returns>
        public HXLDPara RemoveObj(int index)
        {
            IntPtr proc = HalconAPI.PreCall(2124);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDPara hxldPara;
            int procResult = HXLDPara.LoadNew(proc, 1, err, out hxldPara);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldPara;
        }

        /// <summary>
        ///   Replaces one or more elements of an iconic object tuple.
        ///   Instance represents: Iconic Input Object.
        /// </summary>
        /// <param name="objectsReplace">Element(s) to replace.</param>
        /// <param name="index">Index/Indices of elements to be replaced.</param>
        /// <returns>Tuple with replaced elements.</returns>
        public HXLDPara ReplaceObj(HXLDPara objectsReplace, HTuple index)
        {
            IntPtr proc = HalconAPI.PreCall(2125);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objectsReplace);
            HalconAPI.Store(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HXLDPara hxldPara;
            int procResult = HXLDPara.LoadNew(proc, 1, err, out hxldPara);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectsReplace);
            return hxldPara;
        }

        /// <summary>
        ///   Replaces one or more elements of an iconic object tuple.
        ///   Instance represents: Iconic Input Object.
        /// </summary>
        /// <param name="objectsReplace">Element(s) to replace.</param>
        /// <param name="index">Index/Indices of elements to be replaced.</param>
        /// <returns>Tuple with replaced elements.</returns>
        public HXLDPara ReplaceObj(HXLDPara objectsReplace, int index)
        {
            IntPtr proc = HalconAPI.PreCall(2125);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objectsReplace);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDPara hxldPara;
            int procResult = HXLDPara.LoadNew(proc, 1, err, out hxldPara);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectsReplace);
            return hxldPara;
        }
    }
}
