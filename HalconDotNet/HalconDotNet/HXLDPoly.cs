// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HXLDPoly
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;

namespace HalconDotNet
{
    /// <summary>Represents an instance of an XLD polygon object(-array).</summary>
    [Serializable]
    public class HXLDPoly : HXLD
    {
        /// <summary>Create an uninitialized iconic object</summary>
        public HXLDPoly()
          : base(HObjectBase.UNDEF, false)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HXLDPoly(IntPtr key)
          : this(key, true)
        {
            this.AssertObjectClass();
            GC.KeepAlive((object)this);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HXLDPoly(IntPtr key, bool copy)
          : base(key, copy)
        {
            this.AssertObjectClass();
            GC.KeepAlive((object)this);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HXLDPoly(HObject obj)
          : base(obj)
        {
            this.AssertObjectClass();
            GC.KeepAlive((object)this);
        }

        private void AssertObjectClass()
        {
            HalconAPI.AssertObjectClass(this.key, "xld_poly");
        }

        /// <summary>Returns the iconic object(s) at the specified index</summary>
        public HXLDPoly this[HTuple index]
        {
            get
            {
                return this.SelectObj(index);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int LoadNew(IntPtr proc, int parIndex, int err, out HXLDPoly obj)
        {
            obj = new HXLDPoly(HObjectBase.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        /// <summary>
        ///   Compute the union of closed polygons.
        ///   Instance represents: Polygons enclosing the first region.
        /// </summary>
        /// <param name="polygons2">Polygons enclosing the second region.</param>
        /// <returns>Polygons enclosing the union.</returns>
        public HXLDPoly Union2ClosedPolygonsXld(HXLDPoly polygons2)
        {
            IntPtr proc = HalconAPI.PreCall(5);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)polygons2);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDPoly hxldPoly;
            int procResult = HXLDPoly.LoadNew(proc, 1, err, out hxldPoly);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)polygons2);
            return hxldPoly;
        }

        /// <summary>
        ///   Compute the symmetric difference of closed polygons.
        ///   Instance represents: Polygons enclosing the first region.
        /// </summary>
        /// <param name="polygons2">Polygons enclosing the second region.</param>
        /// <returns>Polygons enclosing the symmetric difference.</returns>
        public HXLDPoly SymmDifferenceClosedPolygonsXld(HXLDPoly polygons2)
        {
            IntPtr proc = HalconAPI.PreCall(7);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)polygons2);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDPoly hxldPoly;
            int procResult = HXLDPoly.LoadNew(proc, 1, err, out hxldPoly);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)polygons2);
            return hxldPoly;
        }

        /// <summary>
        ///   Compute the difference of closed polygons.
        ///   Instance represents: Polygons enclosing the region from which the second region is subtracted.
        /// </summary>
        /// <param name="sub">Polygons enclosing the region that is subtracted from the first region.</param>
        /// <returns>Polygons enclosing the difference.</returns>
        public HXLDPoly DifferenceClosedPolygonsXld(HXLDPoly sub)
        {
            IntPtr proc = HalconAPI.PreCall(9);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)sub);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDPoly hxldPoly;
            int procResult = HXLDPoly.LoadNew(proc, 1, err, out hxldPoly);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)sub);
            return hxldPoly;
        }

        /// <summary>
        ///   Intersect closed polygons.
        ///   Instance represents: Polygons enclosing the first region to be intersected.
        /// </summary>
        /// <param name="polygons2">Polygons enclosing the second region to be intersected.</param>
        /// <returns>Polygons enclosing the intersection.</returns>
        public HXLDPoly IntersectionClosedPolygonsXld(HXLDPoly polygons2)
        {
            IntPtr proc = HalconAPI.PreCall(11);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)polygons2);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDPoly hxldPoly;
            int procResult = HXLDPoly.LoadNew(proc, 1, err, out hxldPoly);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)polygons2);
            return hxldPoly;
        }

        /// <summary>
        ///   Read XLD polygons from a file in ARC/INFO generate format.
        ///   Modified instance represents: Read XLD polygons.
        /// </summary>
        /// <param name="fileName">Name of the ARC/INFO file.</param>
        public void ReadPolygonXldArcInfo(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(18);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write XLD polygons to a file in ARC/INFO generate format.
        ///   Instance represents: XLD polygons to be written.
        /// </summary>
        /// <param name="fileName">Name of the ARC/INFO file.</param>
        public void WritePolygonXldArcInfo(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(19);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Combine road hypotheses from two resolution levels.
        ///   Instance represents: XLD polygons to be examined.
        /// </summary>
        /// <param name="modParallels">Modified parallels obtained from EdgePolygons.</param>
        /// <param name="extParallels">Extended parallels obtained from EdgePolygons.</param>
        /// <param name="centerLines">Road-center-line polygons to be examined.</param>
        /// <param name="maxAngleParallel">Maximum angle between two parallel line segments. Default: 0.523598775598</param>
        /// <param name="maxAngleColinear">Maximum angle between two collinear line segments. Default: 0.261799387799</param>
        /// <param name="maxDistanceParallel">Maximum distance between two parallel line segments. Default: 40</param>
        /// <param name="maxDistanceColinear">Maximum distance between two collinear line segments. Default: 40</param>
        /// <returns>Roadsides found.</returns>
        public HXLDPoly CombineRoadsXld(
          HXLDModPara modParallels,
          HXLDExtPara extParallels,
          HXLDPoly centerLines,
          HTuple maxAngleParallel,
          HTuple maxAngleColinear,
          HTuple maxDistanceParallel,
          HTuple maxDistanceColinear)
        {
            IntPtr proc = HalconAPI.PreCall(37);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)modParallels);
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
            GC.KeepAlive((object)modParallels);
            GC.KeepAlive((object)extParallels);
            GC.KeepAlive((object)centerLines);
            return hxldPoly;
        }

        /// <summary>
        ///   Combine road hypotheses from two resolution levels.
        ///   Instance represents: XLD polygons to be examined.
        /// </summary>
        /// <param name="modParallels">Modified parallels obtained from EdgePolygons.</param>
        /// <param name="extParallels">Extended parallels obtained from EdgePolygons.</param>
        /// <param name="centerLines">Road-center-line polygons to be examined.</param>
        /// <param name="maxAngleParallel">Maximum angle between two parallel line segments. Default: 0.523598775598</param>
        /// <param name="maxAngleColinear">Maximum angle between two collinear line segments. Default: 0.261799387799</param>
        /// <param name="maxDistanceParallel">Maximum distance between two parallel line segments. Default: 40</param>
        /// <param name="maxDistanceColinear">Maximum distance between two collinear line segments. Default: 40</param>
        /// <returns>Roadsides found.</returns>
        public HXLDPoly CombineRoadsXld(
          HXLDModPara modParallels,
          HXLDExtPara extParallels,
          HXLDPoly centerLines,
          double maxAngleParallel,
          double maxAngleColinear,
          double maxDistanceParallel,
          double maxDistanceColinear)
        {
            IntPtr proc = HalconAPI.PreCall(37);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)modParallels);
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
            GC.KeepAlive((object)modParallels);
            GC.KeepAlive((object)extParallels);
            GC.KeepAlive((object)centerLines);
            return hxldPoly;
        }

        /// <summary>
        ///   Extract parallel XLD polygons.
        ///   Instance represents: Input polygons.
        /// </summary>
        /// <param name="len">Minimum length of the individual polygon segments. Default: 10.0</param>
        /// <param name="dist">Maximum distance between the polygon segments. Default: 30.0</param>
        /// <param name="alpha">Maximum angle difference of the polygon segments. Default: 0.15</param>
        /// <param name="merge">Should adjacent parallel relations be merged? Default: "true"</param>
        /// <returns>Parallel polygons.</returns>
        public HXLDPara GenParallelsXld(HTuple len, HTuple dist, HTuple alpha, string merge)
        {
            IntPtr proc = HalconAPI.PreCall(42);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, len);
            HalconAPI.Store(proc, 1, dist);
            HalconAPI.Store(proc, 2, alpha);
            HalconAPI.StoreS(proc, 3, merge);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(len);
            HalconAPI.UnpinTuple(dist);
            HalconAPI.UnpinTuple(alpha);
            HXLDPara hxldPara;
            int procResult = HXLDPara.LoadNew(proc, 1, err, out hxldPara);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldPara;
        }

        /// <summary>
        ///   Extract parallel XLD polygons.
        ///   Instance represents: Input polygons.
        /// </summary>
        /// <param name="len">Minimum length of the individual polygon segments. Default: 10.0</param>
        /// <param name="dist">Maximum distance between the polygon segments. Default: 30.0</param>
        /// <param name="alpha">Maximum angle difference of the polygon segments. Default: 0.15</param>
        /// <param name="merge">Should adjacent parallel relations be merged? Default: "true"</param>
        /// <returns>Parallel polygons.</returns>
        public HXLDPara GenParallelsXld(double len, double dist, double alpha, string merge)
        {
            IntPtr proc = HalconAPI.PreCall(42);
            this.Store(proc, 1);
            HalconAPI.StoreD(proc, 0, len);
            HalconAPI.StoreD(proc, 1, dist);
            HalconAPI.StoreD(proc, 2, alpha);
            HalconAPI.StoreS(proc, 3, merge);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDPara hxldPara;
            int procResult = HXLDPara.LoadNew(proc, 1, err, out hxldPara);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldPara;
        }

        /// <summary>
        ///   Return an XLD polygon's data (as lines).
        ///   Instance represents: Input XLD polygons.
        /// </summary>
        /// <param name="beginRow">Row coordinates of the lines' start points.</param>
        /// <param name="beginCol">Column coordinates of the lines' start points.</param>
        /// <param name="endRow">Column coordinates of the lines' end points.</param>
        /// <param name="endCol">Column coordinates of the lines' end points.</param>
        /// <param name="length">Lengths of the line segments.</param>
        /// <param name="phi">Angles of the line segments.</param>
        public void GetLinesXld(
          out HTuple beginRow,
          out HTuple beginCol,
          out HTuple endRow,
          out HTuple endCol,
          out HTuple length,
          out HTuple phi)
        {
            IntPtr proc = HalconAPI.PreCall(43);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out beginRow);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out beginCol);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out endRow);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out endCol);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out length);
            int procResult = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, err6, out phi);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Return an XLD polygon's data.
        ///   Instance represents: Input XLD polygon.
        /// </summary>
        /// <param name="row">Row coordinates of the polygons' points.</param>
        /// <param name="col">Column coordinates of the polygons' points.</param>
        /// <param name="length">Lengths of the line segments.</param>
        /// <param name="phi">Angles of the line segments.</param>
        public void GetPolygonXld(out HTuple row, out HTuple col, out HTuple length, out HTuple phi)
        {
            IntPtr proc = HalconAPI.PreCall(44);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out col);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out length);
            int procResult = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out phi);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Split XLD contours at dominant points.
        ///   Instance represents: Polygons for which the corresponding contours are to be split.
        /// </summary>
        /// <param name="mode">Mode for the splitting of the contours. Default: "polygon"</param>
        /// <param name="weight">Weight for the sensitiveness. Default: 1</param>
        /// <param name="smooth">Width of the smoothing mask. Default: 5</param>
        /// <returns>Split contours.</returns>
        public HXLDCont SplitContoursXld(string mode, int weight, int smooth)
        {
            IntPtr proc = HalconAPI.PreCall(46);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.StoreI(proc, 1, weight);
            HalconAPI.StoreI(proc, 2, smooth);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Apply an arbitrary affine transformation to XLD polygons.
        ///   Instance represents: Input XLD polygons.
        /// </summary>
        /// <param name="homMat2D">Input transformation matrix.</param>
        /// <returns>Transformed XLD polygons.</returns>
        public HXLDPoly AffineTransPolygonXld(HHomMat2D homMat2D)
        {
            IntPtr proc = HalconAPI.PreCall(48);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HData)homMat2D);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)homMat2D));
            HXLDPoly hxldPoly;
            int procResult = HXLDPoly.LoadNew(proc, 1, err, out hxldPoly);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldPoly;
        }

        /// <summary>
        ///   Calculate the difference of two object tuples.
        ///   Instance represents: Object tuple 1.
        /// </summary>
        /// <param name="objectsSub">Object tuple 2.</param>
        /// <returns>Objects from Objects that are not part of ObjectsSub.</returns>
        public HXLDPoly ObjDiff(HXLDPoly objectsSub)
        {
            IntPtr proc = HalconAPI.PreCall(573);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objectsSub);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDPoly hxldPoly;
            int procResult = HXLDPoly.LoadNew(proc, 1, err, out hxldPoly);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectsSub);
            return hxldPoly;
        }

        /// <summary>
        ///   Copy an iconic object in the HALCON database.
        ///   Instance represents: Objects to be copied.
        /// </summary>
        /// <param name="index">Starting index of the objects to be copied. Default: 1</param>
        /// <param name="numObj">Number of objects to be copied or -1. Default: 1</param>
        /// <returns>Copied objects.</returns>
        public HXLDPoly CopyObj(int index, int numObj)
        {
            IntPtr proc = HalconAPI.PreCall(583);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.StoreI(proc, 1, numObj);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDPoly hxldPoly;
            int procResult = HXLDPoly.LoadNew(proc, 1, err, out hxldPoly);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldPoly;
        }

        /// <summary>
        ///   Concatenate two iconic object tuples.
        ///   Instance represents: Object tuple 1.
        /// </summary>
        /// <param name="objects2">Object tuple 2.</param>
        /// <returns>Concatenated objects.</returns>
        public HXLDPoly ConcatObj(HXLDPoly objects2)
        {
            IntPtr proc = HalconAPI.PreCall(584);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objects2);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDPoly hxldPoly;
            int procResult = HXLDPoly.LoadNew(proc, 1, err, out hxldPoly);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objects2);
            return hxldPoly;
        }

        /// <summary>
        ///   Select objects from an object tuple.
        ///   Instance represents: Input objects.
        /// </summary>
        /// <param name="index">Indices of the objects to be selected. Default: 1</param>
        /// <returns>Selected objects.</returns>
        public HXLDPoly SelectObj(HTuple index)
        {
            IntPtr proc = HalconAPI.PreCall(587);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HXLDPoly hxldPoly;
            int procResult = HXLDPoly.LoadNew(proc, 1, err, out hxldPoly);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldPoly;
        }

        /// <summary>
        ///   Select objects from an object tuple.
        ///   Instance represents: Input objects.
        /// </summary>
        /// <param name="index">Indices of the objects to be selected. Default: 1</param>
        /// <returns>Selected objects.</returns>
        public HXLDPoly SelectObj(int index)
        {
            IntPtr proc = HalconAPI.PreCall(587);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDPoly hxldPoly;
            int procResult = HXLDPoly.LoadNew(proc, 1, err, out hxldPoly);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldPoly;
        }

        /// <summary>
        ///   Compare iconic objects regarding equality.
        ///   Instance represents: Reference objects.
        /// </summary>
        /// <param name="objects2">Test objects.</param>
        /// <param name="epsilon">Maximum allowed difference between two gray values or  coordinates etc. Default: 0.0</param>
        /// <returns>Boolean result value.</returns>
        public int CompareObj(HXLDPoly objects2, HTuple epsilon)
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
        public int CompareObj(HXLDPoly objects2, double epsilon)
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
        public int TestEqualObj(HXLDPoly objects2)
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
        ///   Create a region from an XLD polygon.
        ///   Instance represents: Input polygon(s).
        /// </summary>
        /// <param name="mode">Fill mode of the region(s). Default: "filled"</param>
        /// <returns>Created region(s).</returns>
        public HRegion GenRegionPolygonXld(string mode)
        {
            IntPtr proc = HalconAPI.PreCall(596);
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
          out HXLDPoly meshes,
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
            int procResult = HXLDPoly.LoadNew(proc, 2, err2, out meshes);
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
          out HXLDPoly meshes,
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
            int procResult = HXLDPoly.LoadNew(proc, 2, err2, out meshes);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return himage;
        }

        /// <summary>
        ///   Read XLD polygons from a DXF file.
        ///   Modified instance represents: Read XLD polygons.
        /// </summary>
        /// <param name="fileName">Name of the DXF file.</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the DXF input. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the DXF input. Default: []</param>
        /// <returns>Status information.</returns>
        public HTuple ReadPolygonXldDxf(
          string fileName,
          HTuple genParamName,
          HTuple genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1634);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.Store(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int err2 = this.Load(proc, 1, err1);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err2, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Read XLD polygons from a DXF file.
        ///   Modified instance represents: Read XLD polygons.
        /// </summary>
        /// <param name="fileName">Name of the DXF file.</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the DXF input. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the DXF input. Default: []</param>
        /// <returns>Status information.</returns>
        public string ReadPolygonXldDxf(string fileName, string genParamName, double genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1634);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.StoreD(proc, 2, genParamValue);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = this.Load(proc, 1, err1);
            string stringValue;
            int procResult = HalconAPI.LoadS(proc, 0, err2, out stringValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return stringValue;
        }

        /// <summary>
        ///   Write XLD polygons to a file in DXF format.
        ///   Instance represents: XLD polygons to be written.
        /// </summary>
        /// <param name="fileName">Name of the DXF file.</param>
        public void WritePolygonXldDxf(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1635);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Choose all contours or polygons containing a given point.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="row">Line coordinate of the test point. Default: 100.0</param>
        /// <param name="column">Column coordinate of the test point. Default: 100.0</param>
        /// <returns>All contours or polygons containing the test point.</returns>
        public HXLDPoly SelectXldPoint(HTuple row, HTuple column)
        {
            IntPtr proc = HalconAPI.PreCall(1676);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, column);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HXLDPoly hxldPoly;
            int procResult = HXLDPoly.LoadNew(proc, 1, err, out hxldPoly);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldPoly;
        }

        /// <summary>
        ///   Choose all contours or polygons containing a given point.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="row">Line coordinate of the test point. Default: 100.0</param>
        /// <param name="column">Column coordinate of the test point. Default: 100.0</param>
        /// <returns>All contours or polygons containing the test point.</returns>
        public HXLDPoly SelectXldPoint(double row, double column)
        {
            IntPtr proc = HalconAPI.PreCall(1676);
            this.Store(proc, 1);
            HalconAPI.StoreD(proc, 0, row);
            HalconAPI.StoreD(proc, 1, column);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDPoly hxldPoly;
            int procResult = HXLDPoly.LoadNew(proc, 1, err, out hxldPoly);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldPoly;
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
        public HXLDPoly SelectShapeXld(
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
            HXLDPoly hxldPoly;
            int procResult = HXLDPoly.LoadNew(proc, 1, err, out hxldPoly);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldPoly;
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
        public HXLDPoly SelectShapeXld(
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
            HXLDPoly hxldPoly;
            int procResult = HXLDPoly.LoadNew(proc, 1, err, out hxldPoly);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldPoly;
        }

        /// <summary>
        ///   Transform the shape of contours or polygons.
        ///   Instance represents: Contours or polygons to be transformed.
        /// </summary>
        /// <param name="type">Type of transformation. Default: "convex"</param>
        /// <returns>Transformed contours respectively polygons.</returns>
        public HXLDPoly ShapeTransXld(string type)
        {
            IntPtr proc = HalconAPI.PreCall(1689);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, type);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDPoly hxldPoly;
            int procResult = HXLDPoly.LoadNew(proc, 1, err, out hxldPoly);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldPoly;
        }

        /// <summary>
        ///   Insert objects into an iconic object tuple.
        ///   Instance represents: Input object tuple.
        /// </summary>
        /// <param name="objectsInsert">Object tuple to insert.</param>
        /// <param name="index">Index to insert objects.</param>
        /// <returns>Extended object tuple.</returns>
        public HXLDPoly InsertObj(HXLDPoly objectsInsert, int index)
        {
            IntPtr proc = HalconAPI.PreCall(2121);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objectsInsert);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDPoly hxldPoly;
            int procResult = HXLDPoly.LoadNew(proc, 1, err, out hxldPoly);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectsInsert);
            return hxldPoly;
        }

        /// <summary>
        ///   Remove objects from an iconic object tuple.
        ///   Instance represents: Input object tuple.
        /// </summary>
        /// <param name="index">Indices of the objects to be removed.</param>
        /// <returns>Remaining object tuple.</returns>
        public HXLDPoly RemoveObj(HTuple index)
        {
            IntPtr proc = HalconAPI.PreCall(2124);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HXLDPoly hxldPoly;
            int procResult = HXLDPoly.LoadNew(proc, 1, err, out hxldPoly);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldPoly;
        }

        /// <summary>
        ///   Remove objects from an iconic object tuple.
        ///   Instance represents: Input object tuple.
        /// </summary>
        /// <param name="index">Indices of the objects to be removed.</param>
        /// <returns>Remaining object tuple.</returns>
        public HXLDPoly RemoveObj(int index)
        {
            IntPtr proc = HalconAPI.PreCall(2124);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDPoly hxldPoly;
            int procResult = HXLDPoly.LoadNew(proc, 1, err, out hxldPoly);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldPoly;
        }

        /// <summary>
        ///   Replaces one or more elements of an iconic object tuple.
        ///   Instance represents: Iconic Input Object.
        /// </summary>
        /// <param name="objectsReplace">Element(s) to replace.</param>
        /// <param name="index">Index/Indices of elements to be replaced.</param>
        /// <returns>Tuple with replaced elements.</returns>
        public HXLDPoly ReplaceObj(HXLDPoly objectsReplace, HTuple index)
        {
            IntPtr proc = HalconAPI.PreCall(2125);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objectsReplace);
            HalconAPI.Store(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HXLDPoly hxldPoly;
            int procResult = HXLDPoly.LoadNew(proc, 1, err, out hxldPoly);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectsReplace);
            return hxldPoly;
        }

        /// <summary>
        ///   Replaces one or more elements of an iconic object tuple.
        ///   Instance represents: Iconic Input Object.
        /// </summary>
        /// <param name="objectsReplace">Element(s) to replace.</param>
        /// <param name="index">Index/Indices of elements to be replaced.</param>
        /// <returns>Tuple with replaced elements.</returns>
        public HXLDPoly ReplaceObj(HXLDPoly objectsReplace, int index)
        {
            IntPtr proc = HalconAPI.PreCall(2125);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objectsReplace);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDPoly hxldPoly;
            int procResult = HXLDPoly.LoadNew(proc, 1, err, out hxldPoly);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectsReplace);
            return hxldPoly;
        }
    }
}
