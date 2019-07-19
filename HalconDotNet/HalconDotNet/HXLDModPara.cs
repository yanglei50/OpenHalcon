// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HXLDModPara
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;

namespace HalconDotNet
{
    /// <summary>Represents an instance of an XLD modified parallel object(-array).</summary>
    [Serializable]
    public class HXLDModPara : HXLD
    {
        /// <summary>Create an uninitialized iconic object</summary>
        public HXLDModPara()
          : base(HObjectBase.UNDEF, false)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HXLDModPara(IntPtr key)
          : this(key, true)
        {
            this.AssertObjectClass();
            GC.KeepAlive((object)this);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HXLDModPara(IntPtr key, bool copy)
          : base(key, copy)
        {
            this.AssertObjectClass();
            GC.KeepAlive((object)this);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HXLDModPara(HObject obj)
          : base(obj)
        {
            this.AssertObjectClass();
            GC.KeepAlive((object)this);
        }

        private void AssertObjectClass()
        {
            HalconAPI.AssertObjectClass(this.key, "xld_mod_para");
        }

        /// <summary>Returns the iconic object(s) at the specified index</summary>
        public HXLDModPara this[HTuple index]
        {
            get
            {
                return this.SelectObj(index);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int LoadNew(IntPtr proc, int parIndex, int err, out HXLDModPara obj)
        {
            obj = new HXLDModPara(HObjectBase.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        /// <summary>
        ///   Combine road hypotheses from two resolution levels.
        ///   Instance represents: Modified parallels obtained from EdgePolygons.
        /// </summary>
        /// <param name="edgePolygons">XLD polygons to be examined.</param>
        /// <param name="extParallels">Extended parallels obtained from EdgePolygons.</param>
        /// <param name="centerLines">Road-center-line polygons to be examined.</param>
        /// <param name="maxAngleParallel">Maximum angle between two parallel line segments. Default: 0.523598775598</param>
        /// <param name="maxAngleColinear">Maximum angle between two collinear line segments. Default: 0.261799387799</param>
        /// <param name="maxDistanceParallel">Maximum distance between two parallel line segments. Default: 40</param>
        /// <param name="maxDistanceColinear">Maximum distance between two collinear line segments. Default: 40</param>
        /// <returns>Roadsides found.</returns>
        public HXLDPoly CombineRoadsXld(
          HXLDPoly edgePolygons,
          HXLDExtPara extParallels,
          HXLDPoly centerLines,
          HTuple maxAngleParallel,
          HTuple maxAngleColinear,
          HTuple maxDistanceParallel,
          HTuple maxDistanceColinear)
        {
            IntPtr proc = HalconAPI.PreCall(37);
            this.Store(proc, 2);
            HalconAPI.Store(proc, 1, (HObjectBase)edgePolygons);
            HalconAPI.Store(proc, 3, (HObjectBase)extParallels);
            HalconAPI.Store(proc, 4, (HObjectBase)centerLines);
            HalconAPI.Store(proc, 0, maxAngleParallel);
            HalconAPI.Store(proc, 1, maxAngleColinear);
            HalconAPI.Store(proc, 2, maxDistanceParallel);
            HalconAPI.Store(proc, 3, maxDistanceColinear);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(maxAngleParallel);
            HalconAPI.UnpinTuple(maxAngleColinear);
            HalconAPI.UnpinTuple(maxDistanceParallel);
            HalconAPI.UnpinTuple(maxDistanceColinear);
            HXLDPoly hxldPoly;
            int procResult = HXLDPoly.LoadNew(proc, 1, err, out hxldPoly);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)edgePolygons);
            GC.KeepAlive((object)extParallels);
            GC.KeepAlive((object)centerLines);
            return hxldPoly;
        }

        /// <summary>
        ///   Combine road hypotheses from two resolution levels.
        ///   Instance represents: Modified parallels obtained from EdgePolygons.
        /// </summary>
        /// <param name="edgePolygons">XLD polygons to be examined.</param>
        /// <param name="extParallels">Extended parallels obtained from EdgePolygons.</param>
        /// <param name="centerLines">Road-center-line polygons to be examined.</param>
        /// <param name="maxAngleParallel">Maximum angle between two parallel line segments. Default: 0.523598775598</param>
        /// <param name="maxAngleColinear">Maximum angle between two collinear line segments. Default: 0.261799387799</param>
        /// <param name="maxDistanceParallel">Maximum distance between two parallel line segments. Default: 40</param>
        /// <param name="maxDistanceColinear">Maximum distance between two collinear line segments. Default: 40</param>
        /// <returns>Roadsides found.</returns>
        public HXLDPoly CombineRoadsXld(
          HXLDPoly edgePolygons,
          HXLDExtPara extParallels,
          HXLDPoly centerLines,
          double maxAngleParallel,
          double maxAngleColinear,
          double maxDistanceParallel,
          double maxDistanceColinear)
        {
            IntPtr proc = HalconAPI.PreCall(37);
            this.Store(proc, 2);
            HalconAPI.Store(proc, 1, (HObjectBase)edgePolygons);
            HalconAPI.Store(proc, 3, (HObjectBase)extParallels);
            HalconAPI.Store(proc, 4, (HObjectBase)centerLines);
            HalconAPI.StoreD(proc, 0, maxAngleParallel);
            HalconAPI.StoreD(proc, 1, maxAngleColinear);
            HalconAPI.StoreD(proc, 2, maxDistanceParallel);
            HalconAPI.StoreD(proc, 3, maxDistanceColinear);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDPoly hxldPoly;
            int procResult = HXLDPoly.LoadNew(proc, 1, err, out hxldPoly);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)edgePolygons);
            GC.KeepAlive((object)extParallels);
            GC.KeepAlive((object)centerLines);
            return hxldPoly;
        }

        /// <summary>
        ///   Calculate the difference of two object tuples.
        ///   Instance represents: Object tuple 1.
        /// </summary>
        /// <param name="objectsSub">Object tuple 2.</param>
        /// <returns>Objects from Objects that are not part of ObjectsSub.</returns>
        public HXLDModPara ObjDiff(HXLDModPara objectsSub)
        {
            IntPtr proc = HalconAPI.PreCall(573);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objectsSub);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDModPara hxldModPara;
            int procResult = HXLDModPara.LoadNew(proc, 1, err, out hxldModPara);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectsSub);
            return hxldModPara;
        }

        /// <summary>
        ///   Copy an iconic object in the HALCON database.
        ///   Instance represents: Objects to be copied.
        /// </summary>
        /// <param name="index">Starting index of the objects to be copied. Default: 1</param>
        /// <param name="numObj">Number of objects to be copied or -1. Default: 1</param>
        /// <returns>Copied objects.</returns>
        public HXLDModPara CopyObj(int index, int numObj)
        {
            IntPtr proc = HalconAPI.PreCall(583);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.StoreI(proc, 1, numObj);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDModPara hxldModPara;
            int procResult = HXLDModPara.LoadNew(proc, 1, err, out hxldModPara);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldModPara;
        }

        /// <summary>
        ///   Concatenate two iconic object tuples.
        ///   Instance represents: Object tuple 1.
        /// </summary>
        /// <param name="objects2">Object tuple 2.</param>
        /// <returns>Concatenated objects.</returns>
        public HXLDModPara ConcatObj(HXLDModPara objects2)
        {
            IntPtr proc = HalconAPI.PreCall(584);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objects2);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDModPara hxldModPara;
            int procResult = HXLDModPara.LoadNew(proc, 1, err, out hxldModPara);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objects2);
            return hxldModPara;
        }

        /// <summary>
        ///   Select objects from an object tuple.
        ///   Instance represents: Input objects.
        /// </summary>
        /// <param name="index">Indices of the objects to be selected. Default: 1</param>
        /// <returns>Selected objects.</returns>
        public HXLDModPara SelectObj(HTuple index)
        {
            IntPtr proc = HalconAPI.PreCall(587);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HXLDModPara hxldModPara;
            int procResult = HXLDModPara.LoadNew(proc, 1, err, out hxldModPara);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldModPara;
        }

        /// <summary>
        ///   Select objects from an object tuple.
        ///   Instance represents: Input objects.
        /// </summary>
        /// <param name="index">Indices of the objects to be selected. Default: 1</param>
        /// <returns>Selected objects.</returns>
        public HXLDModPara SelectObj(int index)
        {
            IntPtr proc = HalconAPI.PreCall(587);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDModPara hxldModPara;
            int procResult = HXLDModPara.LoadNew(proc, 1, err, out hxldModPara);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldModPara;
        }

        /// <summary>
        ///   Compare iconic objects regarding equality.
        ///   Instance represents: Reference objects.
        /// </summary>
        /// <param name="objects2">Test objects.</param>
        /// <param name="epsilon">Maximum allowed difference between two gray values or  coordinates etc. Default: 0.0</param>
        /// <returns>Boolean result value.</returns>
        public int CompareObj(HXLDModPara objects2, HTuple epsilon)
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
        public int CompareObj(HXLDModPara objects2, double epsilon)
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
        public int TestEqualObj(HXLDModPara objects2)
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
          out HXLDModPara meshes,
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
            int procResult = HXLDModPara.LoadNew(proc, 2, err2, out meshes);
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
          out HXLDModPara meshes,
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
            int procResult = HXLDModPara.LoadNew(proc, 2, err2, out meshes);
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
        public HXLDModPara SelectXldPoint(HTuple row, HTuple column)
        {
            IntPtr proc = HalconAPI.PreCall(1676);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, column);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HXLDModPara hxldModPara;
            int procResult = HXLDModPara.LoadNew(proc, 1, err, out hxldModPara);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldModPara;
        }

        /// <summary>
        ///   Choose all contours or polygons containing a given point.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="row">Line coordinate of the test point. Default: 100.0</param>
        /// <param name="column">Column coordinate of the test point. Default: 100.0</param>
        /// <returns>All contours or polygons containing the test point.</returns>
        public HXLDModPara SelectXldPoint(double row, double column)
        {
            IntPtr proc = HalconAPI.PreCall(1676);
            this.Store(proc, 1);
            HalconAPI.StoreD(proc, 0, row);
            HalconAPI.StoreD(proc, 1, column);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDModPara hxldModPara;
            int procResult = HXLDModPara.LoadNew(proc, 1, err, out hxldModPara);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldModPara;
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
        public HXLDModPara SelectShapeXld(
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
            HXLDModPara hxldModPara;
            int procResult = HXLDModPara.LoadNew(proc, 1, err, out hxldModPara);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldModPara;
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
        public HXLDModPara SelectShapeXld(
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
            HXLDModPara hxldModPara;
            int procResult = HXLDModPara.LoadNew(proc, 1, err, out hxldModPara);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldModPara;
        }

        /// <summary>
        ///   Transform the shape of contours or polygons.
        ///   Instance represents: Contours or polygons to be transformed.
        /// </summary>
        /// <param name="type">Type of transformation. Default: "convex"</param>
        /// <returns>Transformed contours respectively polygons.</returns>
        public HXLDModPara ShapeTransXld(string type)
        {
            IntPtr proc = HalconAPI.PreCall(1689);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, type);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDModPara hxldModPara;
            int procResult = HXLDModPara.LoadNew(proc, 1, err, out hxldModPara);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldModPara;
        }

        /// <summary>
        ///   Insert objects into an iconic object tuple.
        ///   Instance represents: Input object tuple.
        /// </summary>
        /// <param name="objectsInsert">Object tuple to insert.</param>
        /// <param name="index">Index to insert objects.</param>
        /// <returns>Extended object tuple.</returns>
        public HXLDModPara InsertObj(HXLDModPara objectsInsert, int index)
        {
            IntPtr proc = HalconAPI.PreCall(2121);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objectsInsert);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDModPara hxldModPara;
            int procResult = HXLDModPara.LoadNew(proc, 1, err, out hxldModPara);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectsInsert);
            return hxldModPara;
        }

        /// <summary>
        ///   Remove objects from an iconic object tuple.
        ///   Instance represents: Input object tuple.
        /// </summary>
        /// <param name="index">Indices of the objects to be removed.</param>
        /// <returns>Remaining object tuple.</returns>
        public HXLDModPara RemoveObj(HTuple index)
        {
            IntPtr proc = HalconAPI.PreCall(2124);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HXLDModPara hxldModPara;
            int procResult = HXLDModPara.LoadNew(proc, 1, err, out hxldModPara);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldModPara;
        }

        /// <summary>
        ///   Remove objects from an iconic object tuple.
        ///   Instance represents: Input object tuple.
        /// </summary>
        /// <param name="index">Indices of the objects to be removed.</param>
        /// <returns>Remaining object tuple.</returns>
        public HXLDModPara RemoveObj(int index)
        {
            IntPtr proc = HalconAPI.PreCall(2124);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDModPara hxldModPara;
            int procResult = HXLDModPara.LoadNew(proc, 1, err, out hxldModPara);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldModPara;
        }

        /// <summary>
        ///   Replaces one or more elements of an iconic object tuple.
        ///   Instance represents: Iconic Input Object.
        /// </summary>
        /// <param name="objectsReplace">Element(s) to replace.</param>
        /// <param name="index">Index/Indices of elements to be replaced.</param>
        /// <returns>Tuple with replaced elements.</returns>
        public HXLDModPara ReplaceObj(HXLDModPara objectsReplace, HTuple index)
        {
            IntPtr proc = HalconAPI.PreCall(2125);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objectsReplace);
            HalconAPI.Store(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HXLDModPara hxldModPara;
            int procResult = HXLDModPara.LoadNew(proc, 1, err, out hxldModPara);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectsReplace);
            return hxldModPara;
        }

        /// <summary>
        ///   Replaces one or more elements of an iconic object tuple.
        ///   Instance represents: Iconic Input Object.
        /// </summary>
        /// <param name="objectsReplace">Element(s) to replace.</param>
        /// <param name="index">Index/Indices of elements to be replaced.</param>
        /// <returns>Tuple with replaced elements.</returns>
        public HXLDModPara ReplaceObj(HXLDModPara objectsReplace, int index)
        {
            IntPtr proc = HalconAPI.PreCall(2125);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objectsReplace);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDModPara hxldModPara;
            int procResult = HXLDModPara.LoadNew(proc, 1, err, out hxldModPara);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectsReplace);
            return hxldModPara;
        }
    }
}
