using System;
using System.ComponentModel;

namespace HalconDotNet
{
    [Serializable]
    public class HXLDCont : HXLD
    {
        /// <summary>Create an uninitialized iconic object</summary>
        public HXLDCont()
          : base(HObjectBase.UNDEF, false)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HXLDCont(IntPtr key)
          : this(key, true)
        {
            this.AssertObjectClass();
            GC.KeepAlive((object)this);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HXLDCont(IntPtr key, bool copy)
          : base(key, copy)
        {
            this.AssertObjectClass();
            GC.KeepAlive((object)this);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HXLDCont(HObject obj)
          : base(obj)
        {
            this.AssertObjectClass();
            GC.KeepAlive((object)this);
        }

        private void AssertObjectClass()
        {
            HalconAPI.AssertObjectClass(this.key, "xld_cont");
        }

        /// <summary>Returns the iconic object(s) at the specified index</summary>
        public HXLDCont this[HTuple index]
        {
            get
            {
                return this.SelectObj(index);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int LoadNew(IntPtr proc, int parIndex, int err, out HXLDCont obj)
        {
            obj = new HXLDCont(HObjectBase.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        /// <summary>
        ///   Generate XLD contours from regions.
        ///   Modified instance represents: Resulting contours.
        /// </summary>
        /// <param name="regions">Input regions.</param>
        /// <param name="mode">Mode of contour generation. Default: "border"</param>
        public HXLDCont(HRegion regions, string mode)
        {
            IntPtr proc = HalconAPI.PreCall(70);
            HalconAPI.Store(proc, 1, (HObjectBase)regions);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)regions);
        }

        /// <summary>
        ///   Generate an XLD contour from a polygon (given as tuples).
        ///   Modified instance represents: Resulting contour.
        /// </summary>
        /// <param name="row">Row coordinates of the polygon. Default: [0,1,2,2,2]</param>
        /// <param name="col">Column coordinates of the polygon. Default: [0,0,0,1,2]</param>
        public HXLDCont(HTuple row, HTuple col)
        {
            IntPtr proc = HalconAPI.PreCall(72);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, col);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(col);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Compute the union of cotangential contours.
        ///   Instance represents: Input XLD contours.
        /// </summary>
        /// <param name="fitClippingLength">Length of the part of a contour to skip for the determination of tangents. Default: 0.0</param>
        /// <param name="fitLength">Length of the part of a contour to use for the determination of tangents. Default: 30.0</param>
        /// <param name="maxTangAngle">Maximum angle difference between two contours' tangents. Default: 0.78539816</param>
        /// <param name="maxDist">Maximum distance of the contours' end points. Default: 25.0</param>
        /// <param name="maxDistPerp">Maximum distance of the contours' end points perpendicular to their tangents. Default: 10.0</param>
        /// <param name="maxOverlap">Maximum overlap of two contours. Default: 2.0</param>
        /// <param name="mode">Mode describing the treatment of the contours' attributes. Default: "attr_forget"</param>
        /// <returns>Output XLD contours.</returns>
        public HXLDCont UnionCotangentialContoursXld(
          double fitClippingLength,
          HTuple fitLength,
          double maxTangAngle,
          double maxDist,
          double maxDistPerp,
          double maxOverlap,
          string mode)
        {
            IntPtr proc = HalconAPI.PreCall(0);
            this.Store(proc, 1);
            HalconAPI.StoreD(proc, 0, fitClippingLength);
            HalconAPI.Store(proc, 1, fitLength);
            HalconAPI.StoreD(proc, 2, maxTangAngle);
            HalconAPI.StoreD(proc, 3, maxDist);
            HalconAPI.StoreD(proc, 4, maxDistPerp);
            HalconAPI.StoreD(proc, 5, maxOverlap);
            HalconAPI.StoreS(proc, 6, mode);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(fitLength);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Compute the union of cotangential contours.
        ///   Instance represents: Input XLD contours.
        /// </summary>
        /// <param name="fitClippingLength">Length of the part of a contour to skip for the determination of tangents. Default: 0.0</param>
        /// <param name="fitLength">Length of the part of a contour to use for the determination of tangents. Default: 30.0</param>
        /// <param name="maxTangAngle">Maximum angle difference between two contours' tangents. Default: 0.78539816</param>
        /// <param name="maxDist">Maximum distance of the contours' end points. Default: 25.0</param>
        /// <param name="maxDistPerp">Maximum distance of the contours' end points perpendicular to their tangents. Default: 10.0</param>
        /// <param name="maxOverlap">Maximum overlap of two contours. Default: 2.0</param>
        /// <param name="mode">Mode describing the treatment of the contours' attributes. Default: "attr_forget"</param>
        /// <returns>Output XLD contours.</returns>
        public HXLDCont UnionCotangentialContoursXld(
          double fitClippingLength,
          double fitLength,
          double maxTangAngle,
          double maxDist,
          double maxDistPerp,
          double maxOverlap,
          string mode)
        {
            IntPtr proc = HalconAPI.PreCall(0);
            this.Store(proc, 1);
            HalconAPI.StoreD(proc, 0, fitClippingLength);
            HalconAPI.StoreD(proc, 1, fitLength);
            HalconAPI.StoreD(proc, 2, maxTangAngle);
            HalconAPI.StoreD(proc, 3, maxDist);
            HalconAPI.StoreD(proc, 4, maxDistPerp);
            HalconAPI.StoreD(proc, 5, maxOverlap);
            HalconAPI.StoreS(proc, 6, mode);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Transform a contour in polar coordinates back to Cartesian coordinates
        ///   Instance represents: Input contour.
        /// </summary>
        /// <param name="row">Row coordinate of the center of the arc. Default: 256</param>
        /// <param name="column">Column coordinate of the center of the arc. Default: 256</param>
        /// <param name="angleStart">Angle of the ray to map the column coordinate 0 of PolarContour to. Default: 0.0</param>
        /// <param name="angleEnd">Angle of the ray to map the column coordinate $WidthIn-1$ of PolarContour to. Default: 6.2831853</param>
        /// <param name="radiusStart">Radius of the circle to map the row coordinate 0 of PolarContour to. Default: 0</param>
        /// <param name="radiusEnd">Radius of the circle to map the row coordinate $HeightIn-1$ of PolarContour to. Default: 100</param>
        /// <param name="widthIn">Width of the virtual input image. Default: 512</param>
        /// <param name="heightIn">Height of the virtual input image. Default: 512</param>
        /// <param name="width">Width of the virtual output image. Default: 512</param>
        /// <param name="height">Height of the virtual output image. Default: 512</param>
        /// <returns>Output contour.</returns>
        public HXLDCont PolarTransContourXldInv(
          HTuple row,
          HTuple column,
          double angleStart,
          double angleEnd,
          HTuple radiusStart,
          HTuple radiusEnd,
          int widthIn,
          int heightIn,
          int width,
          int height)
        {
            IntPtr proc = HalconAPI.PreCall(1);
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
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.UnpinTuple(radiusStart);
            HalconAPI.UnpinTuple(radiusEnd);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Transform a contour in polar coordinates back to Cartesian coordinates
        ///   Instance represents: Input contour.
        /// </summary>
        /// <param name="row">Row coordinate of the center of the arc. Default: 256</param>
        /// <param name="column">Column coordinate of the center of the arc. Default: 256</param>
        /// <param name="angleStart">Angle of the ray to map the column coordinate 0 of PolarContour to. Default: 0.0</param>
        /// <param name="angleEnd">Angle of the ray to map the column coordinate $WidthIn-1$ of PolarContour to. Default: 6.2831853</param>
        /// <param name="radiusStart">Radius of the circle to map the row coordinate 0 of PolarContour to. Default: 0</param>
        /// <param name="radiusEnd">Radius of the circle to map the row coordinate $HeightIn-1$ of PolarContour to. Default: 100</param>
        /// <param name="widthIn">Width of the virtual input image. Default: 512</param>
        /// <param name="heightIn">Height of the virtual input image. Default: 512</param>
        /// <param name="width">Width of the virtual output image. Default: 512</param>
        /// <param name="height">Height of the virtual output image. Default: 512</param>
        /// <returns>Output contour.</returns>
        public HXLDCont PolarTransContourXldInv(
          double row,
          double column,
          double angleStart,
          double angleEnd,
          double radiusStart,
          double radiusEnd,
          int widthIn,
          int heightIn,
          int width,
          int height)
        {
            IntPtr proc = HalconAPI.PreCall(1);
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
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Transform a contour in an annular arc to polar coordinates.
        ///   Instance represents: Input contour.
        /// </summary>
        /// <param name="row">Row coordinate of the center of the arc. Default: 256</param>
        /// <param name="column">Column coordinate of the center of the arc. Default: 256</param>
        /// <param name="angleStart">Angle of the ray to be mapped to the column coordinate 0 of PolarTransContour. Default: 0.0</param>
        /// <param name="angleEnd">Angle of the ray to be mapped to the column coordinate $Width-1$ of PolarTransContour to. Default: 6.2831853</param>
        /// <param name="radiusStart">Radius of the circle to be mapped to the row coordinate 0 of PolarTransContour. Default: 0</param>
        /// <param name="radiusEnd">Radius of the circle to be mapped to the row coordinate $Height-1$ of PolarTransContour. Default: 100</param>
        /// <param name="width">Width of the virtual output image. Default: 512</param>
        /// <param name="height">Height of the virtual output image. Default: 512</param>
        /// <returns>Output contour.</returns>
        public HXLDCont PolarTransContourXld(
          HTuple row,
          HTuple column,
          double angleStart,
          double angleEnd,
          HTuple radiusStart,
          HTuple radiusEnd,
          int width,
          int height)
        {
            IntPtr proc = HalconAPI.PreCall(2);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, column);
            HalconAPI.StoreD(proc, 2, angleStart);
            HalconAPI.StoreD(proc, 3, angleEnd);
            HalconAPI.Store(proc, 4, radiusStart);
            HalconAPI.Store(proc, 5, radiusEnd);
            HalconAPI.StoreI(proc, 6, width);
            HalconAPI.StoreI(proc, 7, height);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.UnpinTuple(radiusStart);
            HalconAPI.UnpinTuple(radiusEnd);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Transform a contour in an annular arc to polar coordinates.
        ///   Instance represents: Input contour.
        /// </summary>
        /// <param name="row">Row coordinate of the center of the arc. Default: 256</param>
        /// <param name="column">Column coordinate of the center of the arc. Default: 256</param>
        /// <param name="angleStart">Angle of the ray to be mapped to the column coordinate 0 of PolarTransContour. Default: 0.0</param>
        /// <param name="angleEnd">Angle of the ray to be mapped to the column coordinate $Width-1$ of PolarTransContour to. Default: 6.2831853</param>
        /// <param name="radiusStart">Radius of the circle to be mapped to the row coordinate 0 of PolarTransContour. Default: 0</param>
        /// <param name="radiusEnd">Radius of the circle to be mapped to the row coordinate $Height-1$ of PolarTransContour. Default: 100</param>
        /// <param name="width">Width of the virtual output image. Default: 512</param>
        /// <param name="height">Height of the virtual output image. Default: 512</param>
        /// <returns>Output contour.</returns>
        public HXLDCont PolarTransContourXld(
          double row,
          double column,
          double angleStart,
          double angleEnd,
          double radiusStart,
          double radiusEnd,
          int width,
          int height)
        {
            IntPtr proc = HalconAPI.PreCall(2);
            this.Store(proc, 1);
            HalconAPI.StoreD(proc, 0, row);
            HalconAPI.StoreD(proc, 1, column);
            HalconAPI.StoreD(proc, 2, angleStart);
            HalconAPI.StoreD(proc, 3, angleEnd);
            HalconAPI.StoreD(proc, 4, radiusStart);
            HalconAPI.StoreD(proc, 5, radiusEnd);
            HalconAPI.StoreI(proc, 6, width);
            HalconAPI.StoreI(proc, 7, height);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Transform a NURBS curve into an XLD contour.
        ///   Modified instance represents: The contour that approximates the NURBS curve.
        /// </summary>
        /// <param name="rows">Row coordinates of the control polygon.</param>
        /// <param name="cols">Column coordinates of the control polygon.</param>
        /// <param name="knots">The knot vector $u$. Default: "auto"</param>
        /// <param name="weights">The weight vector $w$. Default: "auto"</param>
        /// <param name="degree">The degree $p$ of the NURBS curve. Default: 3</param>
        /// <param name="maxError">Maximum distance between the NURBS curve and its approximation. Default: 1.0</param>
        /// <param name="maxDistance">Maximum distance between two subsequent Contour points. Default: 5.0</param>
        public void GenContourNurbsXld(
          HTuple rows,
          HTuple cols,
          HTuple knots,
          HTuple weights,
          int degree,
          HTuple maxError,
          HTuple maxDistance)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(4);
            HalconAPI.Store(proc, 0, rows);
            HalconAPI.Store(proc, 1, cols);
            HalconAPI.Store(proc, 2, knots);
            HalconAPI.Store(proc, 3, weights);
            HalconAPI.StoreI(proc, 4, degree);
            HalconAPI.Store(proc, 5, maxError);
            HalconAPI.Store(proc, 6, maxDistance);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(rows);
            HalconAPI.UnpinTuple(cols);
            HalconAPI.UnpinTuple(knots);
            HalconAPI.UnpinTuple(weights);
            HalconAPI.UnpinTuple(maxError);
            HalconAPI.UnpinTuple(maxDistance);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Transform a NURBS curve into an XLD contour.
        ///   Modified instance represents: The contour that approximates the NURBS curve.
        /// </summary>
        /// <param name="rows">Row coordinates of the control polygon.</param>
        /// <param name="cols">Column coordinates of the control polygon.</param>
        /// <param name="knots">The knot vector $u$. Default: "auto"</param>
        /// <param name="weights">The weight vector $w$. Default: "auto"</param>
        /// <param name="degree">The degree $p$ of the NURBS curve. Default: 3</param>
        /// <param name="maxError">Maximum distance between the NURBS curve and its approximation. Default: 1.0</param>
        /// <param name="maxDistance">Maximum distance between two subsequent Contour points. Default: 5.0</param>
        public void GenContourNurbsXld(
          HTuple rows,
          HTuple cols,
          string knots,
          string weights,
          int degree,
          double maxError,
          double maxDistance)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(4);
            HalconAPI.Store(proc, 0, rows);
            HalconAPI.Store(proc, 1, cols);
            HalconAPI.StoreS(proc, 2, knots);
            HalconAPI.StoreS(proc, 3, weights);
            HalconAPI.StoreI(proc, 4, degree);
            HalconAPI.StoreD(proc, 5, maxError);
            HalconAPI.StoreD(proc, 6, maxDistance);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(rows);
            HalconAPI.UnpinTuple(cols);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Compute the union of closed contours.
        ///   Instance represents: Contours enclosing the first region.
        /// </summary>
        /// <param name="contours2">Contours enclosing the second region.</param>
        /// <returns>Contours enclosing the union.</returns>
        public HXLDCont Union2ClosedContoursXld(HXLDCont contours2)
        {
            IntPtr proc = HalconAPI.PreCall(6);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)contours2);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contours2);
            return hxldCont;
        }

        /// <summary>
        ///   Compute the symmetric difference of closed contours.
        ///   Instance represents: Contours enclosing the first region.
        /// </summary>
        /// <param name="contours2">Contours enclosing the second region.</param>
        /// <returns>Contours enclosing the symmetric difference.</returns>
        public HXLDCont SymmDifferenceClosedContoursXld(HXLDCont contours2)
        {
            IntPtr proc = HalconAPI.PreCall(8);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)contours2);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contours2);
            return hxldCont;
        }

        /// <summary>
        ///   Compute the difference of closed contours.
        ///   Instance represents: Contours enclosing the region from which the second region is subtracted.
        /// </summary>
        /// <param name="sub">Contours enclosing the region that is subtracted from the first region.</param>
        /// <returns>Contours enclosing the difference.</returns>
        public HXLDCont DifferenceClosedContoursXld(HXLDCont sub)
        {
            IntPtr proc = HalconAPI.PreCall(10);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)sub);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)sub);
            return hxldCont;
        }

        /// <summary>
        ///   Intersect closed contours.
        ///   Instance represents: Contours enclosing the first region to be intersected.
        /// </summary>
        /// <param name="contours2">Contours enclosing the second region to be intersected.</param>
        /// <returns>Contours enclosing the intersection.</returns>
        public HXLDCont IntersectionClosedContoursXld(HXLDCont contours2)
        {
            IntPtr proc = HalconAPI.PreCall(12);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)contours2);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contours2);
            return hxldCont;
        }

        /// <summary>
        ///   Compute the union of contours that belong to the same circle.
        ///   Instance represents: Contours to be merged.
        /// </summary>
        /// <param name="maxArcAngleDiff">Maximum angular distance of two circular arcs. Default: 0.5</param>
        /// <param name="maxArcOverlap">Maximum overlap of two circular arcs. Default: 0.1</param>
        /// <param name="maxTangentAngle">Maximum angle between the connecting line and the tangents of circular arcs. Default: 0.2</param>
        /// <param name="maxDist">Maximum length of the gap between two circular arcs in pixels. Default: 30</param>
        /// <param name="maxRadiusDiff">Maximum radius difference of the circles fitted to two arcs. Default: 10</param>
        /// <param name="maxCenterDist">Maximum center distance of the circles fitted to two arcs. Default: 10</param>
        /// <param name="mergeSmallContours">Determine whether small contours without fitted circles should also be merged. Default: "true"</param>
        /// <param name="iterations">Number of iterations. Default: 1</param>
        /// <returns>Merged contours.</returns>
        public HXLDCont UnionCocircularContoursXld(
          HTuple maxArcAngleDiff,
          HTuple maxArcOverlap,
          HTuple maxTangentAngle,
          HTuple maxDist,
          HTuple maxRadiusDiff,
          HTuple maxCenterDist,
          string mergeSmallContours,
          int iterations)
        {
            IntPtr proc = HalconAPI.PreCall(13);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, maxArcAngleDiff);
            HalconAPI.Store(proc, 1, maxArcOverlap);
            HalconAPI.Store(proc, 2, maxTangentAngle);
            HalconAPI.Store(proc, 3, maxDist);
            HalconAPI.Store(proc, 4, maxRadiusDiff);
            HalconAPI.Store(proc, 5, maxCenterDist);
            HalconAPI.StoreS(proc, 6, mergeSmallContours);
            HalconAPI.StoreI(proc, 7, iterations);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(maxArcAngleDiff);
            HalconAPI.UnpinTuple(maxArcOverlap);
            HalconAPI.UnpinTuple(maxTangentAngle);
            HalconAPI.UnpinTuple(maxDist);
            HalconAPI.UnpinTuple(maxRadiusDiff);
            HalconAPI.UnpinTuple(maxCenterDist);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Compute the union of contours that belong to the same circle.
        ///   Instance represents: Contours to be merged.
        /// </summary>
        /// <param name="maxArcAngleDiff">Maximum angular distance of two circular arcs. Default: 0.5</param>
        /// <param name="maxArcOverlap">Maximum overlap of two circular arcs. Default: 0.1</param>
        /// <param name="maxTangentAngle">Maximum angle between the connecting line and the tangents of circular arcs. Default: 0.2</param>
        /// <param name="maxDist">Maximum length of the gap between two circular arcs in pixels. Default: 30</param>
        /// <param name="maxRadiusDiff">Maximum radius difference of the circles fitted to two arcs. Default: 10</param>
        /// <param name="maxCenterDist">Maximum center distance of the circles fitted to two arcs. Default: 10</param>
        /// <param name="mergeSmallContours">Determine whether small contours without fitted circles should also be merged. Default: "true"</param>
        /// <param name="iterations">Number of iterations. Default: 1</param>
        /// <returns>Merged contours.</returns>
        public HXLDCont UnionCocircularContoursXld(
          double maxArcAngleDiff,
          double maxArcOverlap,
          double maxTangentAngle,
          double maxDist,
          double maxRadiusDiff,
          double maxCenterDist,
          string mergeSmallContours,
          int iterations)
        {
            IntPtr proc = HalconAPI.PreCall(13);
            this.Store(proc, 1);
            HalconAPI.StoreD(proc, 0, maxArcAngleDiff);
            HalconAPI.StoreD(proc, 1, maxArcOverlap);
            HalconAPI.StoreD(proc, 2, maxTangentAngle);
            HalconAPI.StoreD(proc, 3, maxDist);
            HalconAPI.StoreD(proc, 4, maxRadiusDiff);
            HalconAPI.StoreD(proc, 5, maxCenterDist);
            HalconAPI.StoreS(proc, 6, mergeSmallContours);
            HalconAPI.StoreI(proc, 7, iterations);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Crop an XLD contour.
        ///   Instance represents: Input contours.
        /// </summary>
        /// <param name="row1">Upper border of the cropping rectangle. Default: 0</param>
        /// <param name="col1">Left border of the cropping rectangle. Default: 0</param>
        /// <param name="row2">Lower border of the cropping rectangle. Default: 512</param>
        /// <param name="col2">Right border of the cropping rectangle. Default: 512</param>
        /// <param name="closeContours">Should closed contours produce closed output contours? Default: "true"</param>
        /// <returns>Output contours.</returns>
        public HXLDCont CropContoursXld(
          HTuple row1,
          HTuple col1,
          HTuple row2,
          HTuple col2,
          string closeContours)
        {
            IntPtr proc = HalconAPI.PreCall(14);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, row1);
            HalconAPI.Store(proc, 1, col1);
            HalconAPI.Store(proc, 2, row2);
            HalconAPI.Store(proc, 3, col2);
            HalconAPI.StoreS(proc, 4, closeContours);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row1);
            HalconAPI.UnpinTuple(col1);
            HalconAPI.UnpinTuple(row2);
            HalconAPI.UnpinTuple(col2);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Crop an XLD contour.
        ///   Instance represents: Input contours.
        /// </summary>
        /// <param name="row1">Upper border of the cropping rectangle. Default: 0</param>
        /// <param name="col1">Left border of the cropping rectangle. Default: 0</param>
        /// <param name="row2">Lower border of the cropping rectangle. Default: 512</param>
        /// <param name="col2">Right border of the cropping rectangle. Default: 512</param>
        /// <param name="closeContours">Should closed contours produce closed output contours? Default: "true"</param>
        /// <returns>Output contours.</returns>
        public HXLDCont CropContoursXld(
          double row1,
          double col1,
          double row2,
          double col2,
          string closeContours)
        {
            IntPtr proc = HalconAPI.PreCall(14);
            this.Store(proc, 1);
            HalconAPI.StoreD(proc, 0, row1);
            HalconAPI.StoreD(proc, 1, col1);
            HalconAPI.StoreD(proc, 2, row2);
            HalconAPI.StoreD(proc, 3, col2);
            HalconAPI.StoreS(proc, 4, closeContours);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Generate one XLD contour in the shape of a cross for each input point.
        ///   Modified instance represents: Generated XLD contours.
        /// </summary>
        /// <param name="row">Row coordinates of the input points.</param>
        /// <param name="col">Column coordinates of the input points.</param>
        /// <param name="size">Length of the cross bars. Default: 6.0</param>
        /// <param name="angle">Orientation of the crosses. Default: 0.785398</param>
        public void GenCrossContourXld(HTuple row, HTuple col, HTuple size, double angle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(15);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, col);
            HalconAPI.Store(proc, 2, size);
            HalconAPI.StoreD(proc, 3, angle);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(col);
            HalconAPI.UnpinTuple(size);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Generate one XLD contour in the shape of a cross for each input point.
        ///   Modified instance represents: Generated XLD contours.
        /// </summary>
        /// <param name="row">Row coordinates of the input points.</param>
        /// <param name="col">Column coordinates of the input points.</param>
        /// <param name="size">Length of the cross bars. Default: 6.0</param>
        /// <param name="angle">Orientation of the crosses. Default: 0.785398</param>
        public void GenCrossContourXld(double row, double col, double size, double angle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(15);
            HalconAPI.StoreD(proc, 0, row);
            HalconAPI.StoreD(proc, 1, col);
            HalconAPI.StoreD(proc, 2, size);
            HalconAPI.StoreD(proc, 3, angle);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Sort contours with respect to their relative position.
        ///   Instance represents: Contours to be sorted.
        /// </summary>
        /// <param name="sortMode">Kind of sorting. Default: "upper_left"</param>
        /// <param name="order">Increasing or decreasing sorting order. Default: "true"</param>
        /// <param name="rowOrCol">Sorting first with respect to row, then to column. Default: "row"</param>
        /// <returns>Sorted contours.</returns>
        public HXLDCont SortContoursXld(string sortMode, string order, string rowOrCol)
        {
            IntPtr proc = HalconAPI.PreCall(16);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, sortMode);
            HalconAPI.StoreS(proc, 1, order);
            HalconAPI.StoreS(proc, 2, rowOrCol);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Merge XLD contours from successive line scan images.
        ///   Instance represents: Current input contours.
        /// </summary>
        /// <param name="prevConts">Merged contours from the previous iteration.</param>
        /// <param name="prevMergedConts">Contours from the previous iteration which could not be merged with the current ones.</param>
        /// <param name="imageHeight">Height of the line scan images. Default: 512</param>
        /// <param name="margin">Maximum distance of contours from the image border. Default: 0.0</param>
        /// <param name="mergeBorder">Image line of the current image, which touches the previous image. Default: "top"</param>
        /// <param name="maxImagesCont">Maximum number of images covered by one contour. Default: 3</param>
        /// <returns>Current contours, merged with old ones where applicable.</returns>
        public HXLDCont MergeContLineScanXld(
          HXLDCont prevConts,
          out HXLDCont prevMergedConts,
          int imageHeight,
          HTuple margin,
          string mergeBorder,
          int maxImagesCont)
        {
            IntPtr proc = HalconAPI.PreCall(17);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)prevConts);
            HalconAPI.StoreI(proc, 0, imageHeight);
            HalconAPI.Store(proc, 1, margin);
            HalconAPI.StoreS(proc, 2, mergeBorder);
            HalconAPI.StoreI(proc, 3, maxImagesCont);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(margin);
            HXLDCont hxldCont;
            int err2 = HXLDCont.LoadNew(proc, 1, err1, out hxldCont);
            int procResult = HXLDCont.LoadNew(proc, 2, err2, out prevMergedConts);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)prevConts);
            return hxldCont;
        }

        /// <summary>
        ///   Merge XLD contours from successive line scan images.
        ///   Instance represents: Current input contours.
        /// </summary>
        /// <param name="prevConts">Merged contours from the previous iteration.</param>
        /// <param name="prevMergedConts">Contours from the previous iteration which could not be merged with the current ones.</param>
        /// <param name="imageHeight">Height of the line scan images. Default: 512</param>
        /// <param name="margin">Maximum distance of contours from the image border. Default: 0.0</param>
        /// <param name="mergeBorder">Image line of the current image, which touches the previous image. Default: "top"</param>
        /// <param name="maxImagesCont">Maximum number of images covered by one contour. Default: 3</param>
        /// <returns>Current contours, merged with old ones where applicable.</returns>
        public HXLDCont MergeContLineScanXld(
          HXLDCont prevConts,
          out HXLDCont prevMergedConts,
          int imageHeight,
          double margin,
          string mergeBorder,
          int maxImagesCont)
        {
            IntPtr proc = HalconAPI.PreCall(17);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)prevConts);
            HalconAPI.StoreI(proc, 0, imageHeight);
            HalconAPI.StoreD(proc, 1, margin);
            HalconAPI.StoreS(proc, 2, mergeBorder);
            HalconAPI.StoreI(proc, 3, maxImagesCont);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int err2 = HXLDCont.LoadNew(proc, 1, err1, out hxldCont);
            int procResult = HXLDCont.LoadNew(proc, 2, err2, out prevMergedConts);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)prevConts);
            return hxldCont;
        }

        /// <summary>
        ///   Read XLD contours to a file in ARC/INFO generate format.
        ///   Modified instance represents: Read XLD contours.
        /// </summary>
        /// <param name="fileName">Name of the ARC/INFO file.</param>
        public void ReadContourXldArcInfo(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(20);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write XLD contours to a file in ARC/INFO generate format.
        ///   Instance represents: XLD contours to be written.
        /// </summary>
        /// <param name="fileName">Name of the ARC/INFO file.</param>
        public void WriteContourXldArcInfo(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(21);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Compute the parallel contour of an XLD contour.
        ///   Instance represents: Contours to be transformed.
        /// </summary>
        /// <param name="mode">Mode, with which the direction information is computed. Default: "regression_normal"</param>
        /// <param name="distance">Distance of the parallel contour. Default: 1</param>
        /// <returns>Parallel contours.</returns>
        public HXLDCont GenParallelContourXld(string mode, HTuple distance)
        {
            IntPtr proc = HalconAPI.PreCall(23);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.Store(proc, 1, distance);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(distance);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Compute the parallel contour of an XLD contour.
        ///   Instance represents: Contours to be transformed.
        /// </summary>
        /// <param name="mode">Mode, with which the direction information is computed. Default: "regression_normal"</param>
        /// <param name="distance">Distance of the parallel contour. Default: 1</param>
        /// <returns>Parallel contours.</returns>
        public HXLDCont GenParallelContourXld(string mode, double distance)
        {
            IntPtr proc = HalconAPI.PreCall(23);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.StoreD(proc, 1, distance);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Create an XLD contour in the shape of a rectangle.
        ///   Modified instance represents: Rectangle contour.
        /// </summary>
        /// <param name="row">Row coordinate of the center of the rectangle. Default: 300.0</param>
        /// <param name="column">Column coordinate of the center of the rectangle. Default: 200.0</param>
        /// <param name="phi">Orientation of the main axis of the rectangle [rad]. Default: 0.0</param>
        /// <param name="length1">First radius (half length) of the rectangle. Default: 100.5</param>
        /// <param name="length2">Second radius (half width) of the rectangle. Default: 20.5</param>
        public void GenRectangle2ContourXld(
          HTuple row,
          HTuple column,
          HTuple phi,
          HTuple length1,
          HTuple length2)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(24);
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
        ///   Create an XLD contour in the shape of a rectangle.
        ///   Modified instance represents: Rectangle contour.
        /// </summary>
        /// <param name="row">Row coordinate of the center of the rectangle. Default: 300.0</param>
        /// <param name="column">Column coordinate of the center of the rectangle. Default: 200.0</param>
        /// <param name="phi">Orientation of the main axis of the rectangle [rad]. Default: 0.0</param>
        /// <param name="length1">First radius (half length) of the rectangle. Default: 100.5</param>
        /// <param name="length2">Second radius (half width) of the rectangle. Default: 20.5</param>
        public void GenRectangle2ContourXld(
          double row,
          double column,
          double phi,
          double length1,
          double length2)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(24);
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
        ///   Compute the distances of all contour points to a rectangle.
        ///   Instance represents: Input contour.
        /// </summary>
        /// <param name="clippingEndPoints">Number of points at the beginning and the end of the contours to be ignored for the computation of distances. Default: 0</param>
        /// <param name="row">Row coordinate of the center of the rectangle.</param>
        /// <param name="column">Column coordinate of the center of the rectangle.</param>
        /// <param name="phi">Orientation of the main axis of the rectangle [rad].</param>
        /// <param name="length1">First radius (half length) of the rectangle.</param>
        /// <param name="length2">Second radius (half width) of the rectangle.</param>
        /// <returns>Distances of the contour points to the rectangle.</returns>
        public HTuple DistRectangle2ContourPointsXld(
          int clippingEndPoints,
          double row,
          double column,
          double phi,
          double length1,
          double length2)
        {
            IntPtr proc = HalconAPI.PreCall(25);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, clippingEndPoints);
            HalconAPI.StoreD(proc, 1, row);
            HalconAPI.StoreD(proc, 2, column);
            HalconAPI.StoreD(proc, 3, phi);
            HalconAPI.StoreD(proc, 4, length1);
            HalconAPI.StoreD(proc, 5, length2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Fit rectangles to XLD contours.
        ///   Instance represents: Input contours.
        /// </summary>
        /// <param name="algorithm">Algorithm for fitting the rectangles. Default: "regression"</param>
        /// <param name="maxNumPoints">Maximum number of contour points used for the computation (-1 for all points). Default: -1</param>
        /// <param name="maxClosureDist">Maximum distance between the end points of a contour to be considered as closed. Default: 0.0</param>
        /// <param name="clippingEndPoints">Number of points at the beginning and at the end of the contours to be ignored for the fitting. Default: 0</param>
        /// <param name="iterations">Maximum number of iterations (not used for 'regression'). Default: 3</param>
        /// <param name="clippingFactor">Clipping factor for the elimination of outliers (typical: 1.0 for 'huber' and 2.0 for 'tukey'). Default: 2.0</param>
        /// <param name="row">Row coordinate of the center of the rectangle.</param>
        /// <param name="column">Column coordinate of the center of the rectangle.</param>
        /// <param name="phi">Orientation of the main axis of the rectangle [rad].</param>
        /// <param name="length1">First radius (half length) of the rectangle.</param>
        /// <param name="length2">Second radius (half width) of the rectangle.</param>
        /// <param name="pointOrder">Point order of the contour.</param>
        public void FitRectangle2ContourXld(
          string algorithm,
          int maxNumPoints,
          double maxClosureDist,
          int clippingEndPoints,
          int iterations,
          double clippingFactor,
          out HTuple row,
          out HTuple column,
          out HTuple phi,
          out HTuple length1,
          out HTuple length2,
          out HTuple pointOrder)
        {
            IntPtr proc = HalconAPI.PreCall(26);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, algorithm);
            HalconAPI.StoreI(proc, 1, maxNumPoints);
            HalconAPI.StoreD(proc, 2, maxClosureDist);
            HalconAPI.StoreI(proc, 3, clippingEndPoints);
            HalconAPI.StoreI(proc, 4, iterations);
            HalconAPI.StoreD(proc, 5, clippingFactor);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out column);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out phi);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out length1);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out length2);
            int procResult = HTuple.LoadNew(proc, 5, err6, out pointOrder);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Fit rectangles to XLD contours.
        ///   Instance represents: Input contours.
        /// </summary>
        /// <param name="algorithm">Algorithm for fitting the rectangles. Default: "regression"</param>
        /// <param name="maxNumPoints">Maximum number of contour points used for the computation (-1 for all points). Default: -1</param>
        /// <param name="maxClosureDist">Maximum distance between the end points of a contour to be considered as closed. Default: 0.0</param>
        /// <param name="clippingEndPoints">Number of points at the beginning and at the end of the contours to be ignored for the fitting. Default: 0</param>
        /// <param name="iterations">Maximum number of iterations (not used for 'regression'). Default: 3</param>
        /// <param name="clippingFactor">Clipping factor for the elimination of outliers (typical: 1.0 for 'huber' and 2.0 for 'tukey'). Default: 2.0</param>
        /// <param name="row">Row coordinate of the center of the rectangle.</param>
        /// <param name="column">Column coordinate of the center of the rectangle.</param>
        /// <param name="phi">Orientation of the main axis of the rectangle [rad].</param>
        /// <param name="length1">First radius (half length) of the rectangle.</param>
        /// <param name="length2">Second radius (half width) of the rectangle.</param>
        /// <param name="pointOrder">Point order of the contour.</param>
        public void FitRectangle2ContourXld(
          string algorithm,
          int maxNumPoints,
          double maxClosureDist,
          int clippingEndPoints,
          int iterations,
          double clippingFactor,
          out double row,
          out double column,
          out double phi,
          out double length1,
          out double length2,
          out string pointOrder)
        {
            IntPtr proc = HalconAPI.PreCall(26);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, algorithm);
            HalconAPI.StoreI(proc, 1, maxNumPoints);
            HalconAPI.StoreD(proc, 2, maxClosureDist);
            HalconAPI.StoreI(proc, 3, clippingEndPoints);
            HalconAPI.StoreI(proc, 4, iterations);
            HalconAPI.StoreD(proc, 5, clippingFactor);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out row);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out column);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out phi);
            int err5 = HalconAPI.LoadD(proc, 3, err4, out length1);
            int err6 = HalconAPI.LoadD(proc, 4, err5, out length2);
            int procResult = HalconAPI.LoadS(proc, 5, err6, out pointOrder);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Segment XLD contour parts whose local attributes fulfill given  conditions.
        ///   Instance represents: Contour to be segmented.
        /// </summary>
        /// <param name="attribute">Contour attributes to be checked. Default: "distance"</param>
        /// <param name="operation">Linkage type of the individual attributes. Default: "and"</param>
        /// <param name="min">Lower limits of the attribute values. Default: 150.0</param>
        /// <param name="max">Upper limits of the attribute values. Default: 99999.0</param>
        /// <returns>Segmented contour parts.</returns>
        public HXLDCont SegmentContourAttribXld(
          HTuple attribute,
          string operation,
          HTuple min,
          HTuple max)
        {
            IntPtr proc = HalconAPI.PreCall(27);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, attribute);
            HalconAPI.StoreS(proc, 1, operation);
            HalconAPI.Store(proc, 2, min);
            HalconAPI.Store(proc, 3, max);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(attribute);
            HalconAPI.UnpinTuple(min);
            HalconAPI.UnpinTuple(max);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Segment XLD contour parts whose local attributes fulfill given  conditions.
        ///   Instance represents: Contour to be segmented.
        /// </summary>
        /// <param name="attribute">Contour attributes to be checked. Default: "distance"</param>
        /// <param name="operation">Linkage type of the individual attributes. Default: "and"</param>
        /// <param name="min">Lower limits of the attribute values. Default: 150.0</param>
        /// <param name="max">Upper limits of the attribute values. Default: 99999.0</param>
        /// <returns>Segmented contour parts.</returns>
        public HXLDCont SegmentContourAttribXld(
          string attribute,
          string operation,
          double min,
          double max)
        {
            IntPtr proc = HalconAPI.PreCall(27);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, attribute);
            HalconAPI.StoreS(proc, 1, operation);
            HalconAPI.StoreD(proc, 2, min);
            HalconAPI.StoreD(proc, 3, max);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Segment XLD contours into line segments and circular or elliptic arcs.
        ///   Instance represents: Contours to be segmented.
        /// </summary>
        /// <param name="mode">Mode for the segmentation of the contours. Default: "lines_circles"</param>
        /// <param name="smoothCont">Number of points used for smoothing the contours. Default: 5</param>
        /// <param name="maxLineDist1">Maximum distance between a contour and the approximating line (first iteration). Default: 4.0</param>
        /// <param name="maxLineDist2">Maximum distance between a contour and the approximating line (second iteration). Default: 2.0</param>
        /// <returns>Segmented contours.</returns>
        public HXLDCont SegmentContoursXld(
          string mode,
          int smoothCont,
          double maxLineDist1,
          double maxLineDist2)
        {
            IntPtr proc = HalconAPI.PreCall(28);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.StoreI(proc, 1, smoothCont);
            HalconAPI.StoreD(proc, 2, maxLineDist1);
            HalconAPI.StoreD(proc, 3, maxLineDist2);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Approximate XLD contours by circles.
        ///   Instance represents: Input contours.
        /// </summary>
        /// <param name="algorithm">Algorithm for the fitting of circles. Default: "algebraic"</param>
        /// <param name="maxNumPoints">Maximum number of contour points used for the computation (-1 for all points). Default: -1</param>
        /// <param name="maxClosureDist">Maximum distance between the end points of a contour to be considered as 'closed'. Default: 0.0</param>
        /// <param name="clippingEndPoints">Number of points at the beginning and at the end of the contours to be ignored for the fitting. Default: 0</param>
        /// <param name="iterations">Maximum number of iterations for the robust weighted fitting. Default: 3</param>
        /// <param name="clippingFactor">Clipping factor for the elimination of outliers (typical: 1.0 for Huber and 2.0 for Tukey). Default: 2.0</param>
        /// <param name="row">Row coordinate of the center of the circle.</param>
        /// <param name="column">Column coordinate of the center of the circle.</param>
        /// <param name="radius">Radius of circle.</param>
        /// <param name="startPhi">Angle of the start point [rad].</param>
        /// <param name="endPhi">Angle of the end point [rad].</param>
        /// <param name="pointOrder">Point order along the boundary.</param>
        public void FitCircleContourXld(
          string algorithm,
          int maxNumPoints,
          double maxClosureDist,
          int clippingEndPoints,
          int iterations,
          double clippingFactor,
          out HTuple row,
          out HTuple column,
          out HTuple radius,
          out HTuple startPhi,
          out HTuple endPhi,
          out HTuple pointOrder)
        {
            IntPtr proc = HalconAPI.PreCall(29);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, algorithm);
            HalconAPI.StoreI(proc, 1, maxNumPoints);
            HalconAPI.StoreD(proc, 2, maxClosureDist);
            HalconAPI.StoreI(proc, 3, clippingEndPoints);
            HalconAPI.StoreI(proc, 4, iterations);
            HalconAPI.StoreD(proc, 5, clippingFactor);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out column);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out radius);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out startPhi);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out endPhi);
            int procResult = HTuple.LoadNew(proc, 5, err6, out pointOrder);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Approximate XLD contours by circles.
        ///   Instance represents: Input contours.
        /// </summary>
        /// <param name="algorithm">Algorithm for the fitting of circles. Default: "algebraic"</param>
        /// <param name="maxNumPoints">Maximum number of contour points used for the computation (-1 for all points). Default: -1</param>
        /// <param name="maxClosureDist">Maximum distance between the end points of a contour to be considered as 'closed'. Default: 0.0</param>
        /// <param name="clippingEndPoints">Number of points at the beginning and at the end of the contours to be ignored for the fitting. Default: 0</param>
        /// <param name="iterations">Maximum number of iterations for the robust weighted fitting. Default: 3</param>
        /// <param name="clippingFactor">Clipping factor for the elimination of outliers (typical: 1.0 for Huber and 2.0 for Tukey). Default: 2.0</param>
        /// <param name="row">Row coordinate of the center of the circle.</param>
        /// <param name="column">Column coordinate of the center of the circle.</param>
        /// <param name="radius">Radius of circle.</param>
        /// <param name="startPhi">Angle of the start point [rad].</param>
        /// <param name="endPhi">Angle of the end point [rad].</param>
        /// <param name="pointOrder">Point order along the boundary.</param>
        public void FitCircleContourXld(
          string algorithm,
          int maxNumPoints,
          double maxClosureDist,
          int clippingEndPoints,
          int iterations,
          double clippingFactor,
          out double row,
          out double column,
          out double radius,
          out double startPhi,
          out double endPhi,
          out string pointOrder)
        {
            IntPtr proc = HalconAPI.PreCall(29);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, algorithm);
            HalconAPI.StoreI(proc, 1, maxNumPoints);
            HalconAPI.StoreD(proc, 2, maxClosureDist);
            HalconAPI.StoreI(proc, 3, clippingEndPoints);
            HalconAPI.StoreI(proc, 4, iterations);
            HalconAPI.StoreD(proc, 5, clippingFactor);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out row);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out column);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out radius);
            int err5 = HalconAPI.LoadD(proc, 3, err4, out startPhi);
            int err6 = HalconAPI.LoadD(proc, 4, err5, out endPhi);
            int procResult = HalconAPI.LoadS(proc, 5, err6, out pointOrder);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Approximate XLD contours by line segments.
        ///   Instance represents: Input contours.
        /// </summary>
        /// <param name="algorithm">Algorithm for the fitting of lines. Default: "tukey"</param>
        /// <param name="maxNumPoints">Maximum number of contour points used for the computation (-1 for all points). Default: -1</param>
        /// <param name="clippingEndPoints">Number of points at the beginning and at the end of the contours to be ignored for the fitting. Default: 0</param>
        /// <param name="iterations">Maximum number of iterations (unused for 'regression'). Default: 5</param>
        /// <param name="clippingFactor">Clipping factor for the elimination of outliers (typical: 1.0 for 'huber' and 'drop' and 2.0 for  'tukey'). Default: 2.0</param>
        /// <param name="rowBegin">Row coordinates of the starting points of the line segments.</param>
        /// <param name="colBegin">Column coordinates of the starting points of the line segments.</param>
        /// <param name="rowEnd">Row coordinates of the end points of the line segments.</param>
        /// <param name="colEnd">Column coordinates of the end points of the line segments.</param>
        /// <param name="nr">Line parameter: Row coordinate of the normal vector</param>
        /// <param name="nc">Line parameter: Column coordinate of the normal vector</param>
        /// <param name="dist">Line parameter: Distance of the line from the origin</param>
        public void FitLineContourXld(
          string algorithm,
          int maxNumPoints,
          int clippingEndPoints,
          int iterations,
          double clippingFactor,
          out HTuple rowBegin,
          out HTuple colBegin,
          out HTuple rowEnd,
          out HTuple colEnd,
          out HTuple nr,
          out HTuple nc,
          out HTuple dist)
        {
            IntPtr proc = HalconAPI.PreCall(30);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, algorithm);
            HalconAPI.StoreI(proc, 1, maxNumPoints);
            HalconAPI.StoreI(proc, 2, clippingEndPoints);
            HalconAPI.StoreI(proc, 3, iterations);
            HalconAPI.StoreD(proc, 4, clippingFactor);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            HalconAPI.InitOCT(proc, 6);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out rowBegin);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out colBegin);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out rowEnd);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out colEnd);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out nr);
            int err7 = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, err6, out nc);
            int procResult = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, err7, out dist);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Approximate XLD contours by line segments.
        ///   Instance represents: Input contours.
        /// </summary>
        /// <param name="algorithm">Algorithm for the fitting of lines. Default: "tukey"</param>
        /// <param name="maxNumPoints">Maximum number of contour points used for the computation (-1 for all points). Default: -1</param>
        /// <param name="clippingEndPoints">Number of points at the beginning and at the end of the contours to be ignored for the fitting. Default: 0</param>
        /// <param name="iterations">Maximum number of iterations (unused for 'regression'). Default: 5</param>
        /// <param name="clippingFactor">Clipping factor for the elimination of outliers (typical: 1.0 for 'huber' and 'drop' and 2.0 for  'tukey'). Default: 2.0</param>
        /// <param name="rowBegin">Row coordinates of the starting points of the line segments.</param>
        /// <param name="colBegin">Column coordinates of the starting points of the line segments.</param>
        /// <param name="rowEnd">Row coordinates of the end points of the line segments.</param>
        /// <param name="colEnd">Column coordinates of the end points of the line segments.</param>
        /// <param name="nr">Line parameter: Row coordinate of the normal vector</param>
        /// <param name="nc">Line parameter: Column coordinate of the normal vector</param>
        /// <param name="dist">Line parameter: Distance of the line from the origin</param>
        public void FitLineContourXld(
          string algorithm,
          int maxNumPoints,
          int clippingEndPoints,
          int iterations,
          double clippingFactor,
          out double rowBegin,
          out double colBegin,
          out double rowEnd,
          out double colEnd,
          out double nr,
          out double nc,
          out double dist)
        {
            IntPtr proc = HalconAPI.PreCall(30);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, algorithm);
            HalconAPI.StoreI(proc, 1, maxNumPoints);
            HalconAPI.StoreI(proc, 2, clippingEndPoints);
            HalconAPI.StoreI(proc, 3, iterations);
            HalconAPI.StoreD(proc, 4, clippingFactor);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            HalconAPI.InitOCT(proc, 6);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out rowBegin);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out colBegin);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out rowEnd);
            int err5 = HalconAPI.LoadD(proc, 3, err4, out colEnd);
            int err6 = HalconAPI.LoadD(proc, 4, err5, out nr);
            int err7 = HalconAPI.LoadD(proc, 5, err6, out nc);
            int procResult = HalconAPI.LoadD(proc, 6, err7, out dist);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Compute the distances of all contour points to an ellipse.
        ///   Instance represents: Input contours.
        /// </summary>
        /// <param name="distanceMode">Mode for unsigned or signed distance values. Default: "unsigned"</param>
        /// <param name="clippingEndPoints">Number of points at the beginning and the end of the contours to be ignored for the computation of distances. Default: 0</param>
        /// <param name="row">Row coordinate of the center of the ellipse.</param>
        /// <param name="column">Column coordinate of the center of the ellipse.</param>
        /// <param name="phi">Orientation of the main axis in radian.</param>
        /// <param name="radius1">Length of the larger half axis.</param>
        /// <param name="radius2">Length of the smaller half axis.</param>
        /// <returns>Distances of the contour points to the ellipse.</returns>
        public HTuple DistEllipseContourPointsXld(
          string distanceMode,
          int clippingEndPoints,
          double row,
          double column,
          double phi,
          double radius1,
          double radius2)
        {
            IntPtr proc = HalconAPI.PreCall(31);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, distanceMode);
            HalconAPI.StoreI(proc, 1, clippingEndPoints);
            HalconAPI.StoreD(proc, 2, row);
            HalconAPI.StoreD(proc, 3, column);
            HalconAPI.StoreD(proc, 4, phi);
            HalconAPI.StoreD(proc, 5, radius1);
            HalconAPI.StoreD(proc, 6, radius2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the distance of contours to an ellipse.
        ///   Instance represents: Input contours.
        /// </summary>
        /// <param name="mode">Method for the determination of the distances. Default: "geometric"</param>
        /// <param name="maxNumPoints">Maximum number of contour points used for the computation (-1 for all points). Default: -1</param>
        /// <param name="clippingEndPoints">Number of points at the beginning and the end of the contours to be ignored for the computation of distances. Default: 0</param>
        /// <param name="row">Row coordinate of the center of the ellipse.</param>
        /// <param name="column">Column coordinate of the center of the ellipse.</param>
        /// <param name="phi">Orientation of the main axis in radian.</param>
        /// <param name="radius1">Length of the larger half axis.</param>
        /// <param name="radius2">Length of the smaller half axis.</param>
        /// <param name="minDist">Minimum distance.</param>
        /// <param name="maxDist">Maximum distance.</param>
        /// <param name="avgDist">Mean distance.</param>
        /// <param name="sigmaDist">Standard deviation of the distance.</param>
        public void DistEllipseContourXld(
          string mode,
          int maxNumPoints,
          int clippingEndPoints,
          double row,
          double column,
          double phi,
          double radius1,
          double radius2,
          out HTuple minDist,
          out HTuple maxDist,
          out HTuple avgDist,
          out HTuple sigmaDist)
        {
            IntPtr proc = HalconAPI.PreCall(32);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.StoreI(proc, 1, maxNumPoints);
            HalconAPI.StoreI(proc, 2, clippingEndPoints);
            HalconAPI.StoreD(proc, 3, row);
            HalconAPI.StoreD(proc, 4, column);
            HalconAPI.StoreD(proc, 5, phi);
            HalconAPI.StoreD(proc, 6, radius1);
            HalconAPI.StoreD(proc, 7, radius2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out minDist);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out maxDist);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out avgDist);
            int procResult = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out sigmaDist);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Compute the distance of contours to an ellipse.
        ///   Instance represents: Input contours.
        /// </summary>
        /// <param name="mode">Method for the determination of the distances. Default: "geometric"</param>
        /// <param name="maxNumPoints">Maximum number of contour points used for the computation (-1 for all points). Default: -1</param>
        /// <param name="clippingEndPoints">Number of points at the beginning and the end of the contours to be ignored for the computation of distances. Default: 0</param>
        /// <param name="row">Row coordinate of the center of the ellipse.</param>
        /// <param name="column">Column coordinate of the center of the ellipse.</param>
        /// <param name="phi">Orientation of the main axis in radian.</param>
        /// <param name="radius1">Length of the larger half axis.</param>
        /// <param name="radius2">Length of the smaller half axis.</param>
        /// <param name="minDist">Minimum distance.</param>
        /// <param name="maxDist">Maximum distance.</param>
        /// <param name="avgDist">Mean distance.</param>
        /// <param name="sigmaDist">Standard deviation of the distance.</param>
        public void DistEllipseContourXld(
          string mode,
          int maxNumPoints,
          int clippingEndPoints,
          double row,
          double column,
          double phi,
          double radius1,
          double radius2,
          out double minDist,
          out double maxDist,
          out double avgDist,
          out double sigmaDist)
        {
            IntPtr proc = HalconAPI.PreCall(32);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.StoreI(proc, 1, maxNumPoints);
            HalconAPI.StoreI(proc, 2, clippingEndPoints);
            HalconAPI.StoreD(proc, 3, row);
            HalconAPI.StoreD(proc, 4, column);
            HalconAPI.StoreD(proc, 5, phi);
            HalconAPI.StoreD(proc, 6, radius1);
            HalconAPI.StoreD(proc, 7, radius2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out minDist);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out maxDist);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out avgDist);
            int procResult = HalconAPI.LoadD(proc, 3, err4, out sigmaDist);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Approximate XLD contours by ellipses or elliptic arcs.
        ///   Instance represents: Input contours.
        /// </summary>
        /// <param name="algorithm">Algorithm for the fitting of ellipses. Default: "fitzgibbon"</param>
        /// <param name="maxNumPoints">Maximum number of contour points used for the computation (-1 for all points). Default: -1</param>
        /// <param name="maxClosureDist">Maximum distance between the end points of a contour to be considered as 'closed'. Default: 0.0</param>
        /// <param name="clippingEndPoints">Number of points at the beginning and at the end of the contours to be ignored for the fitting. Default: 0</param>
        /// <param name="vossTabSize">Number of circular segments used for the Voss approach. Default: 200</param>
        /// <param name="iterations">Maximum number of iterations for the robust weighted fitting. Default: 3</param>
        /// <param name="clippingFactor">Clipping factor for the elimination of outliers (typical: 1.0 for '*huber' and 2.0 for '*tukey'). Default: 2.0</param>
        /// <param name="row">Row coordinate of the center of the ellipse.</param>
        /// <param name="column">Column coordinate of the center of the ellipse.</param>
        /// <param name="phi">Orientation of the main axis [rad].</param>
        /// <param name="radius1">Length of the larger half axis.</param>
        /// <param name="radius2">Length of the smaller half axis.</param>
        /// <param name="startPhi">Angle of the start point [rad].</param>
        /// <param name="endPhi">Angle of the end point [rad].</param>
        /// <param name="pointOrder">point order along the boundary.</param>
        public void FitEllipseContourXld(
          string algorithm,
          int maxNumPoints,
          double maxClosureDist,
          int clippingEndPoints,
          int vossTabSize,
          int iterations,
          double clippingFactor,
          out HTuple row,
          out HTuple column,
          out HTuple phi,
          out HTuple radius1,
          out HTuple radius2,
          out HTuple startPhi,
          out HTuple endPhi,
          out HTuple pointOrder)
        {
            IntPtr proc = HalconAPI.PreCall(33);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, algorithm);
            HalconAPI.StoreI(proc, 1, maxNumPoints);
            HalconAPI.StoreD(proc, 2, maxClosureDist);
            HalconAPI.StoreI(proc, 3, clippingEndPoints);
            HalconAPI.StoreI(proc, 4, vossTabSize);
            HalconAPI.StoreI(proc, 5, iterations);
            HalconAPI.StoreD(proc, 6, clippingFactor);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            HalconAPI.InitOCT(proc, 6);
            HalconAPI.InitOCT(proc, 7);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out column);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out phi);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out radius1);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out radius2);
            int err7 = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, err6, out startPhi);
            int err8 = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, err7, out endPhi);
            int procResult = HTuple.LoadNew(proc, 7, err8, out pointOrder);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Approximate XLD contours by ellipses or elliptic arcs.
        ///   Instance represents: Input contours.
        /// </summary>
        /// <param name="algorithm">Algorithm for the fitting of ellipses. Default: "fitzgibbon"</param>
        /// <param name="maxNumPoints">Maximum number of contour points used for the computation (-1 for all points). Default: -1</param>
        /// <param name="maxClosureDist">Maximum distance between the end points of a contour to be considered as 'closed'. Default: 0.0</param>
        /// <param name="clippingEndPoints">Number of points at the beginning and at the end of the contours to be ignored for the fitting. Default: 0</param>
        /// <param name="vossTabSize">Number of circular segments used for the Voss approach. Default: 200</param>
        /// <param name="iterations">Maximum number of iterations for the robust weighted fitting. Default: 3</param>
        /// <param name="clippingFactor">Clipping factor for the elimination of outliers (typical: 1.0 for '*huber' and 2.0 for '*tukey'). Default: 2.0</param>
        /// <param name="row">Row coordinate of the center of the ellipse.</param>
        /// <param name="column">Column coordinate of the center of the ellipse.</param>
        /// <param name="phi">Orientation of the main axis [rad].</param>
        /// <param name="radius1">Length of the larger half axis.</param>
        /// <param name="radius2">Length of the smaller half axis.</param>
        /// <param name="startPhi">Angle of the start point [rad].</param>
        /// <param name="endPhi">Angle of the end point [rad].</param>
        /// <param name="pointOrder">point order along the boundary.</param>
        public void FitEllipseContourXld(
          string algorithm,
          int maxNumPoints,
          double maxClosureDist,
          int clippingEndPoints,
          int vossTabSize,
          int iterations,
          double clippingFactor,
          out double row,
          out double column,
          out double phi,
          out double radius1,
          out double radius2,
          out double startPhi,
          out double endPhi,
          out string pointOrder)
        {
            IntPtr proc = HalconAPI.PreCall(33);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, algorithm);
            HalconAPI.StoreI(proc, 1, maxNumPoints);
            HalconAPI.StoreD(proc, 2, maxClosureDist);
            HalconAPI.StoreI(proc, 3, clippingEndPoints);
            HalconAPI.StoreI(proc, 4, vossTabSize);
            HalconAPI.StoreI(proc, 5, iterations);
            HalconAPI.StoreD(proc, 6, clippingFactor);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            HalconAPI.InitOCT(proc, 6);
            HalconAPI.InitOCT(proc, 7);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out row);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out column);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out phi);
            int err5 = HalconAPI.LoadD(proc, 3, err4, out radius1);
            int err6 = HalconAPI.LoadD(proc, 4, err5, out radius2);
            int err7 = HalconAPI.LoadD(proc, 5, err6, out startPhi);
            int err8 = HalconAPI.LoadD(proc, 6, err7, out endPhi);
            int procResult = HalconAPI.LoadS(proc, 7, err8, out pointOrder);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create XLD contours corresponding to circles or circular arcs.
        ///   Modified instance represents: Resulting contours.
        /// </summary>
        /// <param name="row">Row coordinate of the center of the circles or circular arcs. Default: 200.0</param>
        /// <param name="column">Column coordinate of the center of the circles or circular arcs. Default: 200.0</param>
        /// <param name="radius">Radius of the circles or circular arcs. Default: 100.0</param>
        /// <param name="startPhi">Angle of the start points of the circles or circular arcs [rad]. Default: 0.0</param>
        /// <param name="endPhi">Angle of the end points of the circles or circular arcs [rad]. Default: 6.28318</param>
        /// <param name="pointOrder">Point order along the circles or circular arcs. Default: "positive"</param>
        /// <param name="resolution">Distance between neighboring contour points. Default: 1.0</param>
        public void GenCircleContourXld(
          HTuple row,
          HTuple column,
          HTuple radius,
          HTuple startPhi,
          HTuple endPhi,
          HTuple pointOrder,
          double resolution)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(34);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, column);
            HalconAPI.Store(proc, 2, radius);
            HalconAPI.Store(proc, 3, startPhi);
            HalconAPI.Store(proc, 4, endPhi);
            HalconAPI.Store(proc, 5, pointOrder);
            HalconAPI.StoreD(proc, 6, resolution);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.UnpinTuple(radius);
            HalconAPI.UnpinTuple(startPhi);
            HalconAPI.UnpinTuple(endPhi);
            HalconAPI.UnpinTuple(pointOrder);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create XLD contours corresponding to circles or circular arcs.
        ///   Modified instance represents: Resulting contours.
        /// </summary>
        /// <param name="row">Row coordinate of the center of the circles or circular arcs. Default: 200.0</param>
        /// <param name="column">Column coordinate of the center of the circles or circular arcs. Default: 200.0</param>
        /// <param name="radius">Radius of the circles or circular arcs. Default: 100.0</param>
        /// <param name="startPhi">Angle of the start points of the circles or circular arcs [rad]. Default: 0.0</param>
        /// <param name="endPhi">Angle of the end points of the circles or circular arcs [rad]. Default: 6.28318</param>
        /// <param name="pointOrder">Point order along the circles or circular arcs. Default: "positive"</param>
        /// <param name="resolution">Distance between neighboring contour points. Default: 1.0</param>
        public void GenCircleContourXld(
          double row,
          double column,
          double radius,
          double startPhi,
          double endPhi,
          string pointOrder,
          double resolution)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(34);
            HalconAPI.StoreD(proc, 0, row);
            HalconAPI.StoreD(proc, 1, column);
            HalconAPI.StoreD(proc, 2, radius);
            HalconAPI.StoreD(proc, 3, startPhi);
            HalconAPI.StoreD(proc, 4, endPhi);
            HalconAPI.StoreS(proc, 5, pointOrder);
            HalconAPI.StoreD(proc, 6, resolution);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create an XLD contour that corresponds to an elliptic arc.
        ///   Modified instance represents: Resulting contour.
        /// </summary>
        /// <param name="row">Row coordinate of the center of the ellipse. Default: 200.0</param>
        /// <param name="column">Column coordinate of the center of the ellipse. Default: 200.0</param>
        /// <param name="phi">Orientation of the main axis [rad]. Default: 0.0</param>
        /// <param name="radius1">Length of the larger half axis. Default: 100.0</param>
        /// <param name="radius2">Length of the smaller half axis. Default: 50.0</param>
        /// <param name="startPhi">Angle of the start point on the smallest surrounding circle  [rad]. Default: 0.0</param>
        /// <param name="endPhi">Angle of the end point on the smallest surrounding circle  [rad]. Default: 6.28318</param>
        /// <param name="pointOrder">point order along the boundary. Default: "positive"</param>
        /// <param name="resolution">Resolution: Maximum distance between neighboring contour points. Default: 1.5</param>
        public void GenEllipseContourXld(
          HTuple row,
          HTuple column,
          HTuple phi,
          HTuple radius1,
          HTuple radius2,
          HTuple startPhi,
          HTuple endPhi,
          HTuple pointOrder,
          double resolution)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(35);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, column);
            HalconAPI.Store(proc, 2, phi);
            HalconAPI.Store(proc, 3, radius1);
            HalconAPI.Store(proc, 4, radius2);
            HalconAPI.Store(proc, 5, startPhi);
            HalconAPI.Store(proc, 6, endPhi);
            HalconAPI.Store(proc, 7, pointOrder);
            HalconAPI.StoreD(proc, 8, resolution);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.UnpinTuple(phi);
            HalconAPI.UnpinTuple(radius1);
            HalconAPI.UnpinTuple(radius2);
            HalconAPI.UnpinTuple(startPhi);
            HalconAPI.UnpinTuple(endPhi);
            HalconAPI.UnpinTuple(pointOrder);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create an XLD contour that corresponds to an elliptic arc.
        ///   Modified instance represents: Resulting contour.
        /// </summary>
        /// <param name="row">Row coordinate of the center of the ellipse. Default: 200.0</param>
        /// <param name="column">Column coordinate of the center of the ellipse. Default: 200.0</param>
        /// <param name="phi">Orientation of the main axis [rad]. Default: 0.0</param>
        /// <param name="radius1">Length of the larger half axis. Default: 100.0</param>
        /// <param name="radius2">Length of the smaller half axis. Default: 50.0</param>
        /// <param name="startPhi">Angle of the start point on the smallest surrounding circle  [rad]. Default: 0.0</param>
        /// <param name="endPhi">Angle of the end point on the smallest surrounding circle  [rad]. Default: 6.28318</param>
        /// <param name="pointOrder">point order along the boundary. Default: "positive"</param>
        /// <param name="resolution">Resolution: Maximum distance between neighboring contour points. Default: 1.5</param>
        public void GenEllipseContourXld(
          double row,
          double column,
          double phi,
          double radius1,
          double radius2,
          double startPhi,
          double endPhi,
          string pointOrder,
          double resolution)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(35);
            HalconAPI.StoreD(proc, 0, row);
            HalconAPI.StoreD(proc, 1, column);
            HalconAPI.StoreD(proc, 2, phi);
            HalconAPI.StoreD(proc, 3, radius1);
            HalconAPI.StoreD(proc, 4, radius2);
            HalconAPI.StoreD(proc, 5, startPhi);
            HalconAPI.StoreD(proc, 6, endPhi);
            HalconAPI.StoreS(proc, 7, pointOrder);
            HalconAPI.StoreD(proc, 8, resolution);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Add noise to XLD contours.
        ///   Instance represents: Original contours.
        /// </summary>
        /// <param name="numRegrPoints">Number of points used to calculate the regression line. Default: 5</param>
        /// <param name="amp">Maximum amplitude of the added noise (equally distributed in [-Amp,Amp]). Default: 1.0</param>
        /// <returns>Noisy contours.</returns>
        public HXLDCont AddNoiseWhiteContourXld(int numRegrPoints, double amp)
        {
            IntPtr proc = HalconAPI.PreCall(36);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, numRegrPoints);
            HalconAPI.StoreD(proc, 1, amp);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Approximate XLD contours by polygons.
        ///   Instance represents: Contours to be approximated.
        /// </summary>
        /// <param name="type">Type of approximation. Default: "ramer"</param>
        /// <param name="alpha">Threshold for the approximation. Default: 2.0</param>
        /// <returns>Approximating polygons.</returns>
        public HXLDPoly GenPolygonsXld(string type, HTuple alpha)
        {
            IntPtr proc = HalconAPI.PreCall(45);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, type);
            HalconAPI.Store(proc, 1, alpha);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(alpha);
            HXLDPoly hxldPoly;
            int procResult = HXLDPoly.LoadNew(proc, 1, err, out hxldPoly);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldPoly;
        }

        /// <summary>
        ///   Approximate XLD contours by polygons.
        ///   Instance represents: Contours to be approximated.
        /// </summary>
        /// <param name="type">Type of approximation. Default: "ramer"</param>
        /// <param name="alpha">Threshold for the approximation. Default: 2.0</param>
        /// <returns>Approximating polygons.</returns>
        public HXLDPoly GenPolygonsXld(string type, double alpha)
        {
            IntPtr proc = HalconAPI.PreCall(45);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, type);
            HalconAPI.StoreD(proc, 1, alpha);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDPoly hxldPoly;
            int procResult = HXLDPoly.LoadNew(proc, 1, err, out hxldPoly);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldPoly;
        }

        /// <summary>
        ///   Apply a projective transformation to an XLD contour.
        ///   Instance represents: Input contours.
        /// </summary>
        /// <param name="homMat2D">Homogeneous projective transformation matrix.</param>
        /// <returns>Output contours.</returns>
        public HXLDCont ProjectiveTransContourXld(HHomMat2D homMat2D)
        {
            IntPtr proc = HalconAPI.PreCall(47);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HData)homMat2D);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)homMat2D));
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Apply an arbitrary affine 2D transformation to XLD contours.
        ///   Instance represents: Input XLD contours.
        /// </summary>
        /// <param name="homMat2D">Input transformation matrix.</param>
        /// <returns>Transformed XLD contours.</returns>
        public HXLDCont AffineTransContourXld(HHomMat2D homMat2D)
        {
            IntPtr proc = HalconAPI.PreCall(49);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HData)homMat2D);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)homMat2D));
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Close an XLD contour.
        ///   Instance represents: Contours to be closed.
        /// </summary>
        /// <returns>Closed contours.</returns>
        public HXLDCont CloseContoursXld()
        {
            IntPtr proc = HalconAPI.PreCall(50);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Clip the end points of an XLD contour.
        ///   Instance represents: Input contour
        /// </summary>
        /// <param name="mode">Clipping mode. Default: "num_points"</param>
        /// <param name="length">Clipping length in unit pixels (Mode $=$ 'length') or number (Mode $=$ 'num_points') Default: 3</param>
        /// <returns>Clipped contour</returns>
        public HXLDCont ClipEndPointsContoursXld(string mode, HTuple length)
        {
            IntPtr proc = HalconAPI.PreCall(51);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.Store(proc, 1, length);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(length);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Clip the end points of an XLD contour.
        ///   Instance represents: Input contour
        /// </summary>
        /// <param name="mode">Clipping mode. Default: "num_points"</param>
        /// <param name="length">Clipping length in unit pixels (Mode $=$ 'length') or number (Mode $=$ 'num_points') Default: 3</param>
        /// <returns>Clipped contour</returns>
        public HXLDCont ClipEndPointsContoursXld(string mode, double length)
        {
            IntPtr proc = HalconAPI.PreCall(51);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.StoreD(proc, 1, length);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Clip an XLD contour.
        ///   Instance represents: Contours to be clipped.
        /// </summary>
        /// <param name="row1">Row coordinate of the upper left corner of the clip rectangle. Default: 0</param>
        /// <param name="column1">Column coordinate of the upper left corner of the clip rectangle. Default: 0</param>
        /// <param name="row2">Row coordinate of the lower right corner of the clip rectangle. Default: 512</param>
        /// <param name="column2">Column coordinate of the lower right corner of the clip rectangle. Default: 512</param>
        /// <returns>Clipped contours.</returns>
        public HXLDCont ClipContoursXld(int row1, int column1, int row2, int column2)
        {
            IntPtr proc = HalconAPI.PreCall(52);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, row1);
            HalconAPI.StoreI(proc, 1, column1);
            HalconAPI.StoreI(proc, 2, row2);
            HalconAPI.StoreI(proc, 3, column2);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Select XLD contours with a local maximum of gray values.
        ///   Instance represents: XLD contours to be examined.
        /// </summary>
        /// <param name="image">Corresponding gray value image.</param>
        /// <param name="minPercent">Minimum percentage of maximum points. Default: 70</param>
        /// <param name="minDiff">Minimum amount by which the gray value at the maximum must be larger than in the profile. Default: 15</param>
        /// <param name="distance">Maximum width of profile used to check for maxima. Default: 4</param>
        /// <returns>Selected contours.</returns>
        public HXLDCont LocalMaxContoursXld(
          HImage image,
          HTuple minPercent,
          int minDiff,
          int distance)
        {
            IntPtr proc = HalconAPI.PreCall(53);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.Store(proc, 0, minPercent);
            HalconAPI.StoreI(proc, 1, minDiff);
            HalconAPI.StoreI(proc, 2, distance);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(minPercent);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return hxldCont;
        }

        /// <summary>
        ///   Select XLD contours with a local maximum of gray values.
        ///   Instance represents: XLD contours to be examined.
        /// </summary>
        /// <param name="image">Corresponding gray value image.</param>
        /// <param name="minPercent">Minimum percentage of maximum points. Default: 70</param>
        /// <param name="minDiff">Minimum amount by which the gray value at the maximum must be larger than in the profile. Default: 15</param>
        /// <param name="distance">Maximum width of profile used to check for maxima. Default: 4</param>
        /// <returns>Selected contours.</returns>
        public HXLDCont LocalMaxContoursXld(
          HImage image,
          int minPercent,
          int minDiff,
          int distance)
        {
            IntPtr proc = HalconAPI.PreCall(53);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)image);
            HalconAPI.StoreI(proc, 0, minPercent);
            HalconAPI.StoreI(proc, 1, minDiff);
            HalconAPI.StoreI(proc, 2, distance);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return hxldCont;
        }

        /// <summary>
        ///   Compute the union of neighboring straight contours that have a similar  distance from a given line.
        ///   Instance represents: Input XLD contours.
        /// </summary>
        /// <param name="selectedContours">Output XLD contours.</param>
        /// <param name="refLineStartRow">y coordinate of the starting point of the reference line. Default: 0</param>
        /// <param name="refLineStartColumn">x coordinate of the starting point of the reference line. Default: 0</param>
        /// <param name="refLineEndRow">y coordinate of the endpoint of the reference line. Default: 0</param>
        /// <param name="refLineEndColumn">x coordinate of the endpoint of the reference line. Default: 0</param>
        /// <param name="width">Maximum distance. Default: 1</param>
        /// <param name="maxWidth">Maximum Width between two minimas. Default: 1</param>
        /// <param name="filterSize">Size of Smoothfilter Default: 1</param>
        /// <param name="histoValues">Output Values of Histogram.</param>
        /// <returns>Output XLD contours.</returns>
        public HXLDCont UnionStraightContoursHistoXld(
          out HXLDCont selectedContours,
          int refLineStartRow,
          int refLineStartColumn,
          int refLineEndRow,
          int refLineEndColumn,
          int width,
          int maxWidth,
          int filterSize,
          out HTuple histoValues)
        {
            IntPtr proc = HalconAPI.PreCall(54);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, refLineStartRow);
            HalconAPI.StoreI(proc, 1, refLineStartColumn);
            HalconAPI.StoreI(proc, 2, refLineEndRow);
            HalconAPI.StoreI(proc, 3, refLineEndColumn);
            HalconAPI.StoreI(proc, 4, width);
            HalconAPI.StoreI(proc, 5, maxWidth);
            HalconAPI.StoreI(proc, 6, filterSize);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 0);
            int err1 = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int err2 = HXLDCont.LoadNew(proc, 1, err1, out hxldCont);
            int err3 = HXLDCont.LoadNew(proc, 2, err2, out selectedContours);
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err3, out histoValues);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Compute the union of neighboring straight contours that have a similar  direction.
        ///   Instance represents: Input XLD contours.
        /// </summary>
        /// <param name="maxDist">Maximum distance of the contours' endpoints. Default: 5.0</param>
        /// <param name="maxDiff">Maximum difference in direction. Default: 0.5</param>
        /// <param name="percent">Weighting factor for the two selection criteria. Default: 50.0</param>
        /// <param name="mode">Should parallel contours be taken into account? Default: "noparallel"</param>
        /// <param name="iterations">Number of iterations or 'maximum'. Default: "maximum"</param>
        /// <returns>Output XLD contours.</returns>
        public HXLDCont UnionStraightContoursXld(
          double maxDist,
          double maxDiff,
          double percent,
          string mode,
          HTuple iterations)
        {
            IntPtr proc = HalconAPI.PreCall(55);
            this.Store(proc, 1);
            HalconAPI.StoreD(proc, 0, maxDist);
            HalconAPI.StoreD(proc, 1, maxDiff);
            HalconAPI.StoreD(proc, 2, percent);
            HalconAPI.StoreS(proc, 3, mode);
            HalconAPI.Store(proc, 4, iterations);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(iterations);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Compute the union of neighboring straight contours that have a similar  direction.
        ///   Instance represents: Input XLD contours.
        /// </summary>
        /// <param name="maxDist">Maximum distance of the contours' endpoints. Default: 5.0</param>
        /// <param name="maxDiff">Maximum difference in direction. Default: 0.5</param>
        /// <param name="percent">Weighting factor for the two selection criteria. Default: 50.0</param>
        /// <param name="mode">Should parallel contours be taken into account? Default: "noparallel"</param>
        /// <param name="iterations">Number of iterations or 'maximum'. Default: "maximum"</param>
        /// <returns>Output XLD contours.</returns>
        public HXLDCont UnionStraightContoursXld(
          double maxDist,
          double maxDiff,
          double percent,
          string mode,
          string iterations)
        {
            IntPtr proc = HalconAPI.PreCall(55);
            this.Store(proc, 1);
            HalconAPI.StoreD(proc, 0, maxDist);
            HalconAPI.StoreD(proc, 1, maxDiff);
            HalconAPI.StoreD(proc, 2, percent);
            HalconAPI.StoreS(proc, 3, mode);
            HalconAPI.StoreS(proc, 4, iterations);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Compute the union of collinear contours  (operator with extended functionality).
        ///   Instance represents: Input XLD contours.
        /// </summary>
        /// <param name="maxDistAbs">Maximum distance of the contours' end points in the direction of the reference regression line. Default: 10.0</param>
        /// <param name="maxDistRel">Maximum distance of the contours' end points in the direction of the reference regression line in relation to the length of the contour which is to be elongated. Default: 1.0</param>
        /// <param name="maxShift">Maximum distance of the contour from the reference regression line (i.e., perpendicular to the line). Default: 2.0</param>
        /// <param name="maxAngle">Maximum angle difference between the two contours. Default: 0.1</param>
        /// <param name="maxOverlap">Maximum range of the overlap. Default: 0.0</param>
        /// <param name="maxRegrError">Maximum regression error of the resulting contours (NOT USED).  Default: -1.0</param>
        /// <param name="maxCosts">Threshold for reducing the total costs of unification. Default: 1.0</param>
        /// <param name="weightDist">Influence of the distance in the line direction on the total costs. Default: 1.0</param>
        /// <param name="weightShift">Influence of the distance from the regression line on the total costs. Default: 1.0</param>
        /// <param name="weightAngle">Influence of the angle difference on the total costs. Default: 1.0</param>
        /// <param name="weightLink">Influence of the line disturbance by the linking segment (overlap and angle difference) on the total costs. Default: 1.0</param>
        /// <param name="weightRegr">Influence of the regression error on the total costs (NOT USED). Default: 0.0</param>
        /// <param name="mode">Mode describing the treatment of the contours' attributes Default: "attr_keep"</param>
        /// <returns>Output XLD contours.</returns>
        public HXLDCont UnionCollinearContoursExtXld(
          double maxDistAbs,
          double maxDistRel,
          double maxShift,
          double maxAngle,
          double maxOverlap,
          double maxRegrError,
          double maxCosts,
          double weightDist,
          double weightShift,
          double weightAngle,
          double weightLink,
          double weightRegr,
          string mode)
        {
            IntPtr proc = HalconAPI.PreCall(56);
            this.Store(proc, 1);
            HalconAPI.StoreD(proc, 0, maxDistAbs);
            HalconAPI.StoreD(proc, 1, maxDistRel);
            HalconAPI.StoreD(proc, 2, maxShift);
            HalconAPI.StoreD(proc, 3, maxAngle);
            HalconAPI.StoreD(proc, 4, maxOverlap);
            HalconAPI.StoreD(proc, 5, maxRegrError);
            HalconAPI.StoreD(proc, 6, maxCosts);
            HalconAPI.StoreD(proc, 7, weightDist);
            HalconAPI.StoreD(proc, 8, weightShift);
            HalconAPI.StoreD(proc, 9, weightAngle);
            HalconAPI.StoreD(proc, 10, weightLink);
            HalconAPI.StoreD(proc, 11, weightRegr);
            HalconAPI.StoreS(proc, 12, mode);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Unite approximately collinear contours.
        ///   Instance represents: Input XLD contours.
        /// </summary>
        /// <param name="maxDistAbs">Maximum length of the gap between two contours, measured along the regression line of the reference contour. Default: 10.0</param>
        /// <param name="maxDistRel">Maximum length of the gap between two contours, relative to the length of the reference contour, both measured along the regression line of the reference contour. Default: 1.0</param>
        /// <param name="maxShift">Maximum distance of the second contour from the regression line of the reference contour. Default: 2.0</param>
        /// <param name="maxAngle">Maximum angle between the regression lines of two contours. Default: 0.1</param>
        /// <param name="mode">Mode that defines the treatment of contour attributes, i.e., if the contour attributes are kept or discarded. Default: "attr_keep"</param>
        /// <returns>Output XLD contours.</returns>
        public HXLDCont UnionCollinearContoursXld(
          double maxDistAbs,
          double maxDistRel,
          double maxShift,
          double maxAngle,
          string mode)
        {
            IntPtr proc = HalconAPI.PreCall(57);
            this.Store(proc, 1);
            HalconAPI.StoreD(proc, 0, maxDistAbs);
            HalconAPI.StoreD(proc, 1, maxDistRel);
            HalconAPI.StoreD(proc, 2, maxShift);
            HalconAPI.StoreD(proc, 3, maxAngle);
            HalconAPI.StoreS(proc, 4, mode);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Compute the union of contours whose end points are close together.
        ///   Instance represents: Input XLD contours.
        /// </summary>
        /// <param name="maxDistAbs">Maximum distance of the contours' end points. Default: 10.0</param>
        /// <param name="maxDistRel">Maximum distance of the contours' end points in relation to the length of the longer contour. Default: 1.0</param>
        /// <param name="mode">Mode describing the treatment of the contours' attributes. Default: "attr_keep"</param>
        /// <returns>Output XLD contours.</returns>
        public HXLDCont UnionAdjacentContoursXld(
          double maxDistAbs,
          double maxDistRel,
          string mode)
        {
            IntPtr proc = HalconAPI.PreCall(58);
            this.Store(proc, 1);
            HalconAPI.StoreD(proc, 0, maxDistAbs);
            HalconAPI.StoreD(proc, 1, maxDistRel);
            HalconAPI.StoreS(proc, 2, mode);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Select XLD contours according to several features.
        ///   Instance represents: Input XLD contours.
        /// </summary>
        /// <param name="feature">Feature to select contours with. Default: "contour_length"</param>
        /// <param name="min1">Lower threshold. Default: 0.5</param>
        /// <param name="max1">Upper threshold. Default: 200.0</param>
        /// <param name="min2">Lower threshold. Default: -0.5</param>
        /// <param name="max2">Upper threshold. Default: 0.5</param>
        /// <returns>Output XLD contours.</returns>
        public HXLDCont SelectContoursXld(
          string feature,
          double min1,
          double max1,
          double min2,
          double max2)
        {
            IntPtr proc = HalconAPI.PreCall(59);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, feature);
            HalconAPI.StoreD(proc, 1, min1);
            HalconAPI.StoreD(proc, 2, max1);
            HalconAPI.StoreD(proc, 3, min2);
            HalconAPI.StoreD(proc, 4, max2);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Return XLD contour parameters.
        ///   Instance represents: Input XLD contours.
        /// </summary>
        /// <param name="nx">X-coordinate of the normal vector of the regression line.</param>
        /// <param name="ny">Y-coordinate of the normal vector of the regression line.</param>
        /// <param name="dist">Distance of the regression line from the origin.</param>
        /// <param name="fpx">X-coordinate of the projection of the start point of the contour onto the regression line.</param>
        /// <param name="fpy">Y-coordinate of the projection of the start point of the contour onto the regression line.</param>
        /// <param name="lpx">X-coordinate of the projection of the end point of the contour onto the regression line.</param>
        /// <param name="lpy">Y-coordinate of the projection of the end point of the contour onto the regression line.</param>
        /// <param name="mean">Mean distance of the contour points from the regression line.</param>
        /// <param name="deviation">Standard deviation of the distances from the regression line.</param>
        /// <returns>Number of contour points.</returns>
        public HTuple GetRegressParamsXld(
          out HTuple nx,
          out HTuple ny,
          out HTuple dist,
          out HTuple fpx,
          out HTuple fpy,
          out HTuple lpx,
          out HTuple lpy,
          out HTuple mean,
          out HTuple deviation)
        {
            IntPtr proc = HalconAPI.PreCall(60);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            HalconAPI.InitOCT(proc, 6);
            HalconAPI.InitOCT(proc, 7);
            HalconAPI.InitOCT(proc, 8);
            HalconAPI.InitOCT(proc, 9);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out nx);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out ny);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out dist);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out fpx);
            int err7 = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, err6, out fpy);
            int err8 = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, err7, out lpx);
            int err9 = HTuple.LoadNew(proc, 7, HTupleType.DOUBLE, err8, out lpy);
            int err10 = HTuple.LoadNew(proc, 8, HTupleType.DOUBLE, err9, out mean);
            int procResult = HTuple.LoadNew(proc, 9, HTupleType.DOUBLE, err10, out deviation);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Calculate the parameters of a regression line to an XLD contour.
        ///   Instance represents: Input XLD contours.
        /// </summary>
        /// <param name="mode">Type of outlier treatment. Default: "no"</param>
        /// <param name="iterations">Number of iterations for the outlier treatment. Default: 1</param>
        /// <returns>Resulting XLD contours.</returns>
        public HXLDCont RegressContoursXld(string mode, int iterations)
        {
            IntPtr proc = HalconAPI.PreCall(61);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.StoreI(proc, 1, iterations);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Calculate the direction of an XLD contour for each contour point.
        ///   Instance represents: Input contour.
        /// </summary>
        /// <param name="angleMode">Return type of the angles. Default: "abs"</param>
        /// <param name="calcMode">Method for computing the angles. Default: "range"</param>
        /// <param name="lookaround">Number of points to take into account. Default: 3</param>
        /// <returns>Direction of the tangent to the contour points.</returns>
        public HTuple GetContourAngleXld(string angleMode, string calcMode, int lookaround)
        {
            IntPtr proc = HalconAPI.PreCall(62);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, angleMode);
            HalconAPI.StoreS(proc, 1, calcMode);
            HalconAPI.StoreI(proc, 2, lookaround);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Smooth an XLD contour.
        ///   Instance represents: Contour to be smoothed.
        /// </summary>
        /// <param name="numRegrPoints">Number of points used to calculate the regression line. Default: 5</param>
        /// <returns>Smoothed contour.</returns>
        public HXLDCont SmoothContoursXld(int numRegrPoints)
        {
            IntPtr proc = HalconAPI.PreCall(63);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, numRegrPoints);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Return the number of points in an XLD contour.
        ///   Instance represents: Input XLD contour.
        /// </summary>
        /// <returns>Number of contour points.</returns>
        public HTuple ContourPointNumXld()
        {
            IntPtr proc = HalconAPI.PreCall(64);
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
        ///   Return the names of the defined global attributes of an XLD contour.
        ///   Instance represents: Input contour.
        /// </summary>
        /// <returns>List of the defined global contour attributes.</returns>
        public HTuple QueryContourGlobalAttribsXld()
        {
            IntPtr proc = HalconAPI.PreCall(65);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Return global attributes values of an XLD contour.
        ///   Instance represents: Input XLD contour.
        /// </summary>
        /// <param name="name">Name of the attribute. Default: "regr_norm_row"</param>
        /// <returns>Attribute values.</returns>
        public HTuple GetContourGlobalAttribXld(HTuple name)
        {
            IntPtr proc = HalconAPI.PreCall(66);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, name);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(name);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Return global attributes values of an XLD contour.
        ///   Instance represents: Input XLD contour.
        /// </summary>
        /// <param name="name">Name of the attribute. Default: "regr_norm_row"</param>
        /// <returns>Attribute values.</returns>
        public HTuple GetContourGlobalAttribXld(string name)
        {
            IntPtr proc = HalconAPI.PreCall(66);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, name);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Return the names of the defined attributes of an XLD contour.
        ///   Instance represents: Input contour.
        /// </summary>
        /// <returns>List of the defined contour attributes.</returns>
        public HTuple QueryContourAttribsXld()
        {
            IntPtr proc = HalconAPI.PreCall(67);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Return point attribute values of an XLD contour.
        ///   Instance represents: Input XLD contour.
        /// </summary>
        /// <param name="name">Name of the attribute. Default: "angle"</param>
        /// <returns>Attribute values.</returns>
        public HTuple GetContourAttribXld(string name)
        {
            IntPtr proc = HalconAPI.PreCall(68);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, name);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Return the coordinates of an XLD contour.
        ///   Instance represents: Input XLD contour.
        /// </summary>
        /// <param name="row">Row coordinate of the contour's points.</param>
        /// <param name="col">Column coordinate of the contour's points.</param>
        public void GetContourXld(out HTuple row, out HTuple col)
        {
            IntPtr proc = HalconAPI.PreCall(69);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out col);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Generate an XLD contour with rounded corners from a polygon (given as tuples).
        ///   Modified instance represents: Resulting contour.
        /// </summary>
        /// <param name="row">Row coordinates of the polygon. Default: [20,80,80,20,20]</param>
        /// <param name="col">Column coordinates of the polygon. Default: [20,20,80,80,20]</param>
        /// <param name="radius">Radii of the rounded corners. Default: [20,20,20,20,20]</param>
        /// <param name="samplingInterval">Distance of the samples. Default: 1.0</param>
        public void GenContourPolygonRoundedXld(
          HTuple row,
          HTuple col,
          HTuple radius,
          HTuple samplingInterval)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(71);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, col);
            HalconAPI.Store(proc, 2, radius);
            HalconAPI.Store(proc, 3, samplingInterval);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(col);
            HalconAPI.UnpinTuple(radius);
            HalconAPI.UnpinTuple(samplingInterval);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Generate an XLD contour with rounded corners from a polygon (given as tuples).
        ///   Modified instance represents: Resulting contour.
        /// </summary>
        /// <param name="row">Row coordinates of the polygon. Default: [20,80,80,20,20]</param>
        /// <param name="col">Column coordinates of the polygon. Default: [20,20,80,80,20]</param>
        /// <param name="radius">Radii of the rounded corners. Default: [20,20,20,20,20]</param>
        /// <param name="samplingInterval">Distance of the samples. Default: 1.0</param>
        public void GenContourPolygonRoundedXld(
          HTuple row,
          HTuple col,
          HTuple radius,
          double samplingInterval)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(71);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, col);
            HalconAPI.Store(proc, 2, radius);
            HalconAPI.StoreD(proc, 3, samplingInterval);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(col);
            HalconAPI.UnpinTuple(radius);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Generate an XLD contour from a polygon (given as tuples).
        ///   Modified instance represents: Resulting contour.
        /// </summary>
        /// <param name="row">Row coordinates of the polygon. Default: [0,1,2,2,2]</param>
        /// <param name="col">Column coordinates of the polygon. Default: [0,0,0,1,2]</param>
        public void GenContourPolygonXld(HTuple row, HTuple col)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(72);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, col);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(col);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Calculate the difference of two object tuples.
        ///   Instance represents: Object tuple 1.
        /// </summary>
        /// <param name="objectsSub">Object tuple 2.</param>
        /// <returns>Objects from Objects that are not part of ObjectsSub.</returns>
        public HXLDCont ObjDiff(HXLDCont objectsSub)
        {
            IntPtr proc = HalconAPI.PreCall(573);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objectsSub);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectsSub);
            return hxldCont;
        }

        /// <summary>
        ///   Copy an iconic object in the HALCON database.
        ///   Instance represents: Objects to be copied.
        /// </summary>
        /// <param name="index">Starting index of the objects to be copied. Default: 1</param>
        /// <param name="numObj">Number of objects to be copied or -1. Default: 1</param>
        /// <returns>Copied objects.</returns>
        public HXLDCont CopyObj(int index, int numObj)
        {
            IntPtr proc = HalconAPI.PreCall(583);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.StoreI(proc, 1, numObj);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Concatenate two iconic object tuples.
        ///   Instance represents: Object tuple 1.
        /// </summary>
        /// <param name="objects2">Object tuple 2.</param>
        /// <returns>Concatenated objects.</returns>
        public HXLDCont ConcatObj(HXLDCont objects2)
        {
            IntPtr proc = HalconAPI.PreCall(584);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objects2);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objects2);
            return hxldCont;
        }

        /// <summary>
        ///   Select objects from an object tuple.
        ///   Instance represents: Input objects.
        /// </summary>
        /// <param name="index">Indices of the objects to be selected. Default: 1</param>
        /// <returns>Selected objects.</returns>
        public HXLDCont SelectObj(HTuple index)
        {
            IntPtr proc = HalconAPI.PreCall(587);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Select objects from an object tuple.
        ///   Instance represents: Input objects.
        /// </summary>
        /// <param name="index">Indices of the objects to be selected. Default: 1</param>
        /// <returns>Selected objects.</returns>
        public HXLDCont SelectObj(int index)
        {
            IntPtr proc = HalconAPI.PreCall(587);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Compare iconic objects regarding equality.
        ///   Instance represents: Reference objects.
        /// </summary>
        /// <param name="objects2">Test objects.</param>
        /// <param name="epsilon">Maximum allowed difference between two gray values or  coordinates etc. Default: 0.0</param>
        /// <returns>Boolean result value.</returns>
        public int CompareObj(HXLDCont objects2, HTuple epsilon)
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
        public int CompareObj(HXLDCont objects2, double epsilon)
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
        public int TestEqualObj(HXLDCont objects2)
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
        ///   Create a region from an XLD contour.
        ///   Instance represents: Input contour(s).
        /// </summary>
        /// <param name="mode">Fill mode of the region(s). Default: "filled"</param>
        /// <returns>Created region(s).</returns>
        public HRegion GenRegionContourXld(string mode)
        {
            IntPtr proc = HalconAPI.PreCall(597);
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
        ///   Prepare an anisotropically scaled shape model for matching from XLD contours.
        ///   Instance represents: Input contours that will be used to create the model.
        /// </summary>
        /// <param name="numLevels">Maximum number of pyramid levels. Default: "auto"</param>
        /// <param name="angleStart">Smallest rotation of the pattern. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="angleStep">Step length of the angles (resolution). Default: "auto"</param>
        /// <param name="scaleRMin">Minimum scale of the pattern in the row direction. Default: 0.9</param>
        /// <param name="scaleRMax">Maximum scale of the pattern in the row direction. Default: 1.1</param>
        /// <param name="scaleRStep">Scale step length (resolution) in the row direction. Default: "auto"</param>
        /// <param name="scaleCMin">Minimum scale of the pattern in the column direction. Default: 0.9</param>
        /// <param name="scaleCMax">Maximum scale of the pattern in the column direction. Default: 1.1</param>
        /// <param name="scaleCStep">Scale step length (resolution) in the column direction. Default: "auto"</param>
        /// <param name="optimization">Kind of optimization and optionally method used for generating the model. Default: "auto"</param>
        /// <param name="metric">Match metric. Default: "ignore_local_polarity"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: 5</param>
        /// <returns>Handle of the model.</returns>
        public HShapeModel CreateAnisoShapeModelXld(
          HTuple numLevels,
          double angleStart,
          double angleExtent,
          HTuple angleStep,
          double scaleRMin,
          double scaleRMax,
          HTuple scaleRStep,
          double scaleCMin,
          double scaleCMax,
          HTuple scaleCStep,
          HTuple optimization,
          string metric,
          int minContrast)
        {
            IntPtr proc = HalconAPI.PreCall(935);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, numLevels);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.Store(proc, 3, angleStep);
            HalconAPI.StoreD(proc, 4, scaleRMin);
            HalconAPI.StoreD(proc, 5, scaleRMax);
            HalconAPI.Store(proc, 6, scaleRStep);
            HalconAPI.StoreD(proc, 7, scaleCMin);
            HalconAPI.StoreD(proc, 8, scaleCMax);
            HalconAPI.Store(proc, 9, scaleCStep);
            HalconAPI.Store(proc, 10, optimization);
            HalconAPI.StoreS(proc, 11, metric);
            HalconAPI.StoreI(proc, 12, minContrast);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(numLevels);
            HalconAPI.UnpinTuple(angleStep);
            HalconAPI.UnpinTuple(scaleRStep);
            HalconAPI.UnpinTuple(scaleCStep);
            HalconAPI.UnpinTuple(optimization);
            HShapeModel hshapeModel;
            int procResult = HShapeModel.LoadNew(proc, 0, err, out hshapeModel);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hshapeModel;
        }

        /// <summary>
        ///   Prepare an anisotropically scaled shape model for matching from XLD contours.
        ///   Instance represents: Input contours that will be used to create the model.
        /// </summary>
        /// <param name="numLevels">Maximum number of pyramid levels. Default: "auto"</param>
        /// <param name="angleStart">Smallest rotation of the pattern. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="angleStep">Step length of the angles (resolution). Default: "auto"</param>
        /// <param name="scaleRMin">Minimum scale of the pattern in the row direction. Default: 0.9</param>
        /// <param name="scaleRMax">Maximum scale of the pattern in the row direction. Default: 1.1</param>
        /// <param name="scaleRStep">Scale step length (resolution) in the row direction. Default: "auto"</param>
        /// <param name="scaleCMin">Minimum scale of the pattern in the column direction. Default: 0.9</param>
        /// <param name="scaleCMax">Maximum scale of the pattern in the column direction. Default: 1.1</param>
        /// <param name="scaleCStep">Scale step length (resolution) in the column direction. Default: "auto"</param>
        /// <param name="optimization">Kind of optimization and optionally method used for generating the model. Default: "auto"</param>
        /// <param name="metric">Match metric. Default: "ignore_local_polarity"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: 5</param>
        /// <returns>Handle of the model.</returns>
        public HShapeModel CreateAnisoShapeModelXld(
          int numLevels,
          double angleStart,
          double angleExtent,
          double angleStep,
          double scaleRMin,
          double scaleRMax,
          double scaleRStep,
          double scaleCMin,
          double scaleCMax,
          double scaleCStep,
          string optimization,
          string metric,
          int minContrast)
        {
            IntPtr proc = HalconAPI.PreCall(935);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, numLevels);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.StoreD(proc, 3, angleStep);
            HalconAPI.StoreD(proc, 4, scaleRMin);
            HalconAPI.StoreD(proc, 5, scaleRMax);
            HalconAPI.StoreD(proc, 6, scaleRStep);
            HalconAPI.StoreD(proc, 7, scaleCMin);
            HalconAPI.StoreD(proc, 8, scaleCMax);
            HalconAPI.StoreD(proc, 9, scaleCStep);
            HalconAPI.StoreS(proc, 10, optimization);
            HalconAPI.StoreS(proc, 11, metric);
            HalconAPI.StoreI(proc, 12, minContrast);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HShapeModel hshapeModel;
            int procResult = HShapeModel.LoadNew(proc, 0, err, out hshapeModel);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hshapeModel;
        }

        /// <summary>
        ///   Prepare an isotropically scaled shape model for matching from XLD contours.
        ///   Instance represents: Input contours that will be used to create the model.
        /// </summary>
        /// <param name="numLevels">Maximum number of pyramid levels. Default: "auto"</param>
        /// <param name="angleStart">Smallest rotation of the pattern. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="angleStep">Step length of the angles (resolution). Default: "auto"</param>
        /// <param name="scaleMin">Minimum scale of the pattern. Default: 0.9</param>
        /// <param name="scaleMax">Maximum scale of the pattern. Default: 1.1</param>
        /// <param name="scaleStep">Scale step length (resolution). Default: "auto"</param>
        /// <param name="optimization">Kind of optimization and optionally method used for generating the model. Default: "auto"</param>
        /// <param name="metric">Match metric. Default: "ignore_local_polarity"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: 5</param>
        /// <returns>Handle of the model.</returns>
        public HShapeModel CreateScaledShapeModelXld(
          HTuple numLevels,
          double angleStart,
          double angleExtent,
          HTuple angleStep,
          double scaleMin,
          double scaleMax,
          HTuple scaleStep,
          HTuple optimization,
          string metric,
          int minContrast)
        {
            IntPtr proc = HalconAPI.PreCall(936);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, numLevels);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.Store(proc, 3, angleStep);
            HalconAPI.StoreD(proc, 4, scaleMin);
            HalconAPI.StoreD(proc, 5, scaleMax);
            HalconAPI.Store(proc, 6, scaleStep);
            HalconAPI.Store(proc, 7, optimization);
            HalconAPI.StoreS(proc, 8, metric);
            HalconAPI.StoreI(proc, 9, minContrast);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(numLevels);
            HalconAPI.UnpinTuple(angleStep);
            HalconAPI.UnpinTuple(scaleStep);
            HalconAPI.UnpinTuple(optimization);
            HShapeModel hshapeModel;
            int procResult = HShapeModel.LoadNew(proc, 0, err, out hshapeModel);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hshapeModel;
        }

        /// <summary>
        ///   Prepare an isotropically scaled shape model for matching from XLD contours.
        ///   Instance represents: Input contours that will be used to create the model.
        /// </summary>
        /// <param name="numLevels">Maximum number of pyramid levels. Default: "auto"</param>
        /// <param name="angleStart">Smallest rotation of the pattern. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="angleStep">Step length of the angles (resolution). Default: "auto"</param>
        /// <param name="scaleMin">Minimum scale of the pattern. Default: 0.9</param>
        /// <param name="scaleMax">Maximum scale of the pattern. Default: 1.1</param>
        /// <param name="scaleStep">Scale step length (resolution). Default: "auto"</param>
        /// <param name="optimization">Kind of optimization and optionally method used for generating the model. Default: "auto"</param>
        /// <param name="metric">Match metric. Default: "ignore_local_polarity"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: 5</param>
        /// <returns>Handle of the model.</returns>
        public HShapeModel CreateScaledShapeModelXld(
          int numLevels,
          double angleStart,
          double angleExtent,
          double angleStep,
          double scaleMin,
          double scaleMax,
          double scaleStep,
          string optimization,
          string metric,
          int minContrast)
        {
            IntPtr proc = HalconAPI.PreCall(936);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, numLevels);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.StoreD(proc, 3, angleStep);
            HalconAPI.StoreD(proc, 4, scaleMin);
            HalconAPI.StoreD(proc, 5, scaleMax);
            HalconAPI.StoreD(proc, 6, scaleStep);
            HalconAPI.StoreS(proc, 7, optimization);
            HalconAPI.StoreS(proc, 8, metric);
            HalconAPI.StoreI(proc, 9, minContrast);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HShapeModel hshapeModel;
            int procResult = HShapeModel.LoadNew(proc, 0, err, out hshapeModel);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hshapeModel;
        }

        /// <summary>
        ///   Prepare a shape model for matching from XLD contours.
        ///   Instance represents: Input contours that will be used to create the model.
        /// </summary>
        /// <param name="numLevels">Maximum number of pyramid levels. Default: "auto"</param>
        /// <param name="angleStart">Smallest rotation of the pattern. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="angleStep">Step length of the angles (resolution). Default: "auto"</param>
        /// <param name="optimization">Kind of optimization and optionally method used for generating the model. Default: "auto"</param>
        /// <param name="metric">Match metric. Default: "ignore_local_polarity"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: 5</param>
        /// <returns>Handle of the model.</returns>
        public HShapeModel CreateShapeModelXld(
          HTuple numLevels,
          double angleStart,
          double angleExtent,
          HTuple angleStep,
          HTuple optimization,
          string metric,
          int minContrast)
        {
            IntPtr proc = HalconAPI.PreCall(937);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, numLevels);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.Store(proc, 3, angleStep);
            HalconAPI.Store(proc, 4, optimization);
            HalconAPI.StoreS(proc, 5, metric);
            HalconAPI.StoreI(proc, 6, minContrast);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(numLevels);
            HalconAPI.UnpinTuple(angleStep);
            HalconAPI.UnpinTuple(optimization);
            HShapeModel hshapeModel;
            int procResult = HShapeModel.LoadNew(proc, 0, err, out hshapeModel);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hshapeModel;
        }

        /// <summary>
        ///   Prepare a shape model for matching from XLD contours.
        ///   Instance represents: Input contours that will be used to create the model.
        /// </summary>
        /// <param name="numLevels">Maximum number of pyramid levels. Default: "auto"</param>
        /// <param name="angleStart">Smallest rotation of the pattern. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="angleStep">Step length of the angles (resolution). Default: "auto"</param>
        /// <param name="optimization">Kind of optimization and optionally method used for generating the model. Default: "auto"</param>
        /// <param name="metric">Match metric. Default: "ignore_local_polarity"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: 5</param>
        /// <returns>Handle of the model.</returns>
        public HShapeModel CreateShapeModelXld(
          int numLevels,
          double angleStart,
          double angleExtent,
          double angleStep,
          string optimization,
          string metric,
          int minContrast)
        {
            IntPtr proc = HalconAPI.PreCall(937);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, numLevels);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.StoreD(proc, 3, angleStep);
            HalconAPI.StoreS(proc, 4, optimization);
            HalconAPI.StoreS(proc, 5, metric);
            HalconAPI.StoreI(proc, 6, minContrast);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HShapeModel hshapeModel;
            int procResult = HShapeModel.LoadNew(proc, 0, err, out hshapeModel);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hshapeModel;
        }

        /// <summary>
        ///   Prepare a deformable model for local deformable matching from XLD contours.
        ///   Instance represents: Input contours that will be used to create the model.
        /// </summary>
        /// <param name="numLevels">Maximum number of pyramid levels. Default: "auto"</param>
        /// <param name="angleStart">This parameter is not used. Default: []</param>
        /// <param name="angleExtent">This parameter is not used. Default: []</param>
        /// <param name="angleStep">Step length of the angles (resolution). Default: "auto"</param>
        /// <param name="scaleRMin">Minimum scale of the pattern in row direction. Default: 1.0</param>
        /// <param name="scaleRMax">This parameter is not used. Default: []</param>
        /// <param name="scaleRStep">Scale step length (resolution) in row direction. Default: "auto"</param>
        /// <param name="scaleCMin">Minimum scale of the pattern in column direction. Default: 1.0</param>
        /// <param name="scaleCMax">This parameter is not used. Default: []</param>
        /// <param name="scaleCStep">Scale step length (resolution) in column direction. Default: "auto"</param>
        /// <param name="optimization">Kind of optimization used for generating the model. Default: "auto"</param>
        /// <param name="metric">Match metric. Default: "ignore_local_polarity"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: 5</param>
        /// <param name="genParamName">The generic parameter names. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <returns>Handle of the model.</returns>
        public HDeformableModel CreateLocalDeformableModelXld(
          HTuple numLevels,
          HTuple angleStart,
          HTuple angleExtent,
          HTuple angleStep,
          double scaleRMin,
          HTuple scaleRMax,
          HTuple scaleRStep,
          double scaleCMin,
          HTuple scaleCMax,
          HTuple scaleCStep,
          HTuple optimization,
          string metric,
          int minContrast,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(975);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, numLevels);
            HalconAPI.Store(proc, 1, angleStart);
            HalconAPI.Store(proc, 2, angleExtent);
            HalconAPI.Store(proc, 3, angleStep);
            HalconAPI.StoreD(proc, 4, scaleRMin);
            HalconAPI.Store(proc, 5, scaleRMax);
            HalconAPI.Store(proc, 6, scaleRStep);
            HalconAPI.StoreD(proc, 7, scaleCMin);
            HalconAPI.Store(proc, 8, scaleCMax);
            HalconAPI.Store(proc, 9, scaleCStep);
            HalconAPI.Store(proc, 10, optimization);
            HalconAPI.StoreS(proc, 11, metric);
            HalconAPI.StoreI(proc, 12, minContrast);
            HalconAPI.Store(proc, 13, genParamName);
            HalconAPI.Store(proc, 14, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(numLevels);
            HalconAPI.UnpinTuple(angleStart);
            HalconAPI.UnpinTuple(angleExtent);
            HalconAPI.UnpinTuple(angleStep);
            HalconAPI.UnpinTuple(scaleRMax);
            HalconAPI.UnpinTuple(scaleRStep);
            HalconAPI.UnpinTuple(scaleCMax);
            HalconAPI.UnpinTuple(scaleCStep);
            HalconAPI.UnpinTuple(optimization);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HDeformableModel hdeformableModel;
            int procResult = HDeformableModel.LoadNew(proc, 0, err, out hdeformableModel);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hdeformableModel;
        }

        /// <summary>
        ///   Prepare a deformable model for local deformable matching from XLD contours.
        ///   Instance represents: Input contours that will be used to create the model.
        /// </summary>
        /// <param name="numLevels">Maximum number of pyramid levels. Default: "auto"</param>
        /// <param name="angleStart">This parameter is not used. Default: []</param>
        /// <param name="angleExtent">This parameter is not used. Default: []</param>
        /// <param name="angleStep">Step length of the angles (resolution). Default: "auto"</param>
        /// <param name="scaleRMin">Minimum scale of the pattern in row direction. Default: 1.0</param>
        /// <param name="scaleRMax">This parameter is not used. Default: []</param>
        /// <param name="scaleRStep">Scale step length (resolution) in row direction. Default: "auto"</param>
        /// <param name="scaleCMin">Minimum scale of the pattern in column direction. Default: 1.0</param>
        /// <param name="scaleCMax">This parameter is not used. Default: []</param>
        /// <param name="scaleCStep">Scale step length (resolution) in column direction. Default: "auto"</param>
        /// <param name="optimization">Kind of optimization used for generating the model. Default: "auto"</param>
        /// <param name="metric">Match metric. Default: "ignore_local_polarity"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: 5</param>
        /// <param name="genParamName">The generic parameter names. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <returns>Handle of the model.</returns>
        public HDeformableModel CreateLocalDeformableModelXld(
          int numLevels,
          HTuple angleStart,
          HTuple angleExtent,
          double angleStep,
          double scaleRMin,
          HTuple scaleRMax,
          double scaleRStep,
          double scaleCMin,
          HTuple scaleCMax,
          double scaleCStep,
          string optimization,
          string metric,
          int minContrast,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(975);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, numLevels);
            HalconAPI.Store(proc, 1, angleStart);
            HalconAPI.Store(proc, 2, angleExtent);
            HalconAPI.StoreD(proc, 3, angleStep);
            HalconAPI.StoreD(proc, 4, scaleRMin);
            HalconAPI.Store(proc, 5, scaleRMax);
            HalconAPI.StoreD(proc, 6, scaleRStep);
            HalconAPI.StoreD(proc, 7, scaleCMin);
            HalconAPI.Store(proc, 8, scaleCMax);
            HalconAPI.StoreD(proc, 9, scaleCStep);
            HalconAPI.StoreS(proc, 10, optimization);
            HalconAPI.StoreS(proc, 11, metric);
            HalconAPI.StoreI(proc, 12, minContrast);
            HalconAPI.Store(proc, 13, genParamName);
            HalconAPI.Store(proc, 14, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(angleStart);
            HalconAPI.UnpinTuple(angleExtent);
            HalconAPI.UnpinTuple(scaleRMax);
            HalconAPI.UnpinTuple(scaleCMax);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HDeformableModel hdeformableModel;
            int procResult = HDeformableModel.LoadNew(proc, 0, err, out hdeformableModel);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hdeformableModel;
        }

        /// <summary>
        ///   Prepare a deformable model for planar calibrated matching from XLD contours.
        ///   Instance represents: Input contours that will be used to create the model.
        /// </summary>
        /// <param name="camParam">The parameters of the internal orientation of the camera.</param>
        /// <param name="referencePose">The reference pose of the object.</param>
        /// <param name="numLevels">Maximum number of pyramid levels. Default: "auto"</param>
        /// <param name="angleStart">This parameter is not used. Default: []</param>
        /// <param name="angleExtent">This parameter is not used. Default: []</param>
        /// <param name="angleStep">Step length of the angles (resolution). Default: "auto"</param>
        /// <param name="scaleRMin">Minimum scale of the pattern in row direction. Default: 1.0</param>
        /// <param name="scaleRMax">This parameter is not used. Default: []</param>
        /// <param name="scaleRStep">Scale step length (resolution) in row direction. Default: "auto"</param>
        /// <param name="scaleCMin">Minimum scale of the pattern in column direction. Default: 1.0</param>
        /// <param name="scaleCMax">This parameter is not used. Default: []</param>
        /// <param name="scaleCStep">Scale step length (resolution) in the column direction. Default: "auto"</param>
        /// <param name="optimization">Kind of optimization used for generating the model. Default: "auto"</param>
        /// <param name="metric">Match metric. Default: "ignore_local_polarity"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: 5</param>
        /// <param name="genParamName">The generic parameter names. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameter. Default: []</param>
        /// <returns>Handle of the model.</returns>
        public HDeformableModel CreatePlanarCalibDeformableModelXld(
          HCamPar camParam,
          HPose referencePose,
          HTuple numLevels,
          HTuple angleStart,
          HTuple angleExtent,
          HTuple angleStep,
          double scaleRMin,
          HTuple scaleRMax,
          HTuple scaleRStep,
          double scaleCMin,
          HTuple scaleCMax,
          HTuple scaleCStep,
          HTuple optimization,
          string metric,
          int minContrast,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(976);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HData)camParam);
            HalconAPI.Store(proc, 1, (HData)referencePose);
            HalconAPI.Store(proc, 2, numLevels);
            HalconAPI.Store(proc, 3, angleStart);
            HalconAPI.Store(proc, 4, angleExtent);
            HalconAPI.Store(proc, 5, angleStep);
            HalconAPI.StoreD(proc, 6, scaleRMin);
            HalconAPI.Store(proc, 7, scaleRMax);
            HalconAPI.Store(proc, 8, scaleRStep);
            HalconAPI.StoreD(proc, 9, scaleCMin);
            HalconAPI.Store(proc, 10, scaleCMax);
            HalconAPI.Store(proc, 11, scaleCStep);
            HalconAPI.Store(proc, 12, optimization);
            HalconAPI.StoreS(proc, 13, metric);
            HalconAPI.StoreI(proc, 14, minContrast);
            HalconAPI.Store(proc, 15, genParamName);
            HalconAPI.Store(proc, 16, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
            HalconAPI.UnpinTuple((HTuple)((HData)referencePose));
            HalconAPI.UnpinTuple(numLevels);
            HalconAPI.UnpinTuple(angleStart);
            HalconAPI.UnpinTuple(angleExtent);
            HalconAPI.UnpinTuple(angleStep);
            HalconAPI.UnpinTuple(scaleRMax);
            HalconAPI.UnpinTuple(scaleRStep);
            HalconAPI.UnpinTuple(scaleCMax);
            HalconAPI.UnpinTuple(scaleCStep);
            HalconAPI.UnpinTuple(optimization);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HDeformableModel hdeformableModel;
            int procResult = HDeformableModel.LoadNew(proc, 0, err, out hdeformableModel);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hdeformableModel;
        }

        /// <summary>
        ///   Prepare a deformable model for planar calibrated matching from XLD contours.
        ///   Instance represents: Input contours that will be used to create the model.
        /// </summary>
        /// <param name="camParam">The parameters of the internal orientation of the camera.</param>
        /// <param name="referencePose">The reference pose of the object.</param>
        /// <param name="numLevels">Maximum number of pyramid levels. Default: "auto"</param>
        /// <param name="angleStart">This parameter is not used. Default: []</param>
        /// <param name="angleExtent">This parameter is not used. Default: []</param>
        /// <param name="angleStep">Step length of the angles (resolution). Default: "auto"</param>
        /// <param name="scaleRMin">Minimum scale of the pattern in row direction. Default: 1.0</param>
        /// <param name="scaleRMax">This parameter is not used. Default: []</param>
        /// <param name="scaleRStep">Scale step length (resolution) in row direction. Default: "auto"</param>
        /// <param name="scaleCMin">Minimum scale of the pattern in column direction. Default: 1.0</param>
        /// <param name="scaleCMax">This parameter is not used. Default: []</param>
        /// <param name="scaleCStep">Scale step length (resolution) in the column direction. Default: "auto"</param>
        /// <param name="optimization">Kind of optimization used for generating the model. Default: "auto"</param>
        /// <param name="metric">Match metric. Default: "ignore_local_polarity"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: 5</param>
        /// <param name="genParamName">The generic parameter names. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameter. Default: []</param>
        /// <returns>Handle of the model.</returns>
        public HDeformableModel CreatePlanarCalibDeformableModelXld(
          HCamPar camParam,
          HPose referencePose,
          int numLevels,
          HTuple angleStart,
          HTuple angleExtent,
          double angleStep,
          double scaleRMin,
          HTuple scaleRMax,
          double scaleRStep,
          double scaleCMin,
          HTuple scaleCMax,
          double scaleCStep,
          string optimization,
          string metric,
          int minContrast,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(976);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HData)camParam);
            HalconAPI.Store(proc, 1, (HData)referencePose);
            HalconAPI.StoreI(proc, 2, numLevels);
            HalconAPI.Store(proc, 3, angleStart);
            HalconAPI.Store(proc, 4, angleExtent);
            HalconAPI.StoreD(proc, 5, angleStep);
            HalconAPI.StoreD(proc, 6, scaleRMin);
            HalconAPI.Store(proc, 7, scaleRMax);
            HalconAPI.StoreD(proc, 8, scaleRStep);
            HalconAPI.StoreD(proc, 9, scaleCMin);
            HalconAPI.Store(proc, 10, scaleCMax);
            HalconAPI.StoreD(proc, 11, scaleCStep);
            HalconAPI.StoreS(proc, 12, optimization);
            HalconAPI.StoreS(proc, 13, metric);
            HalconAPI.StoreI(proc, 14, minContrast);
            HalconAPI.Store(proc, 15, genParamName);
            HalconAPI.Store(proc, 16, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
            HalconAPI.UnpinTuple((HTuple)((HData)referencePose));
            HalconAPI.UnpinTuple(angleStart);
            HalconAPI.UnpinTuple(angleExtent);
            HalconAPI.UnpinTuple(scaleRMax);
            HalconAPI.UnpinTuple(scaleCMax);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HDeformableModel hdeformableModel;
            int procResult = HDeformableModel.LoadNew(proc, 0, err, out hdeformableModel);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hdeformableModel;
        }

        /// <summary>
        ///   Prepare a deformable model for planar uncalibrated matching from XLD contours.
        ///   Instance represents: Input contours that will be used to create the model.
        /// </summary>
        /// <param name="numLevels">Maximum number of pyramid levels. Default: "auto"</param>
        /// <param name="angleStart">This parameter is not used. Default: []</param>
        /// <param name="angleExtent">This parameter is not used. Default: []</param>
        /// <param name="angleStep">Step length of the angles (resolution). Default: "auto"</param>
        /// <param name="scaleRMin">Minimum scale of the pattern in row direction. Default: 1.0</param>
        /// <param name="scaleRMax">This parameter is not used. Default: []</param>
        /// <param name="scaleRStep">Scale step length (resolution) in row direction. Default: "auto"</param>
        /// <param name="scaleCMin">Minimum scale of the pattern in column direction. Default: 1.0</param>
        /// <param name="scaleCMax">This parameter is not used. Default: []</param>
        /// <param name="scaleCStep">Scale step length (resolution) in the column direction. Default: "auto"</param>
        /// <param name="optimization">Kind of optimization used for generating the model. Default: "auto"</param>
        /// <param name="metric">Match metric. Default: "ignore_local_polarity"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: 5</param>
        /// <param name="genParamName">The generic parameter names. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <returns>Handle of the model.</returns>
        public HDeformableModel CreatePlanarUncalibDeformableModelXld(
          HTuple numLevels,
          HTuple angleStart,
          HTuple angleExtent,
          HTuple angleStep,
          double scaleRMin,
          HTuple scaleRMax,
          HTuple scaleRStep,
          double scaleCMin,
          HTuple scaleCMax,
          HTuple scaleCStep,
          HTuple optimization,
          string metric,
          int minContrast,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(977);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, numLevels);
            HalconAPI.Store(proc, 1, angleStart);
            HalconAPI.Store(proc, 2, angleExtent);
            HalconAPI.Store(proc, 3, angleStep);
            HalconAPI.StoreD(proc, 4, scaleRMin);
            HalconAPI.Store(proc, 5, scaleRMax);
            HalconAPI.Store(proc, 6, scaleRStep);
            HalconAPI.StoreD(proc, 7, scaleCMin);
            HalconAPI.Store(proc, 8, scaleCMax);
            HalconAPI.Store(proc, 9, scaleCStep);
            HalconAPI.Store(proc, 10, optimization);
            HalconAPI.StoreS(proc, 11, metric);
            HalconAPI.StoreI(proc, 12, minContrast);
            HalconAPI.Store(proc, 13, genParamName);
            HalconAPI.Store(proc, 14, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(numLevels);
            HalconAPI.UnpinTuple(angleStart);
            HalconAPI.UnpinTuple(angleExtent);
            HalconAPI.UnpinTuple(angleStep);
            HalconAPI.UnpinTuple(scaleRMax);
            HalconAPI.UnpinTuple(scaleRStep);
            HalconAPI.UnpinTuple(scaleCMax);
            HalconAPI.UnpinTuple(scaleCStep);
            HalconAPI.UnpinTuple(optimization);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HDeformableModel hdeformableModel;
            int procResult = HDeformableModel.LoadNew(proc, 0, err, out hdeformableModel);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hdeformableModel;
        }

        /// <summary>
        ///   Prepare a deformable model for planar uncalibrated matching from XLD contours.
        ///   Instance represents: Input contours that will be used to create the model.
        /// </summary>
        /// <param name="numLevels">Maximum number of pyramid levels. Default: "auto"</param>
        /// <param name="angleStart">This parameter is not used. Default: []</param>
        /// <param name="angleExtent">This parameter is not used. Default: []</param>
        /// <param name="angleStep">Step length of the angles (resolution). Default: "auto"</param>
        /// <param name="scaleRMin">Minimum scale of the pattern in row direction. Default: 1.0</param>
        /// <param name="scaleRMax">This parameter is not used. Default: []</param>
        /// <param name="scaleRStep">Scale step length (resolution) in row direction. Default: "auto"</param>
        /// <param name="scaleCMin">Minimum scale of the pattern in column direction. Default: 1.0</param>
        /// <param name="scaleCMax">This parameter is not used. Default: []</param>
        /// <param name="scaleCStep">Scale step length (resolution) in the column direction. Default: "auto"</param>
        /// <param name="optimization">Kind of optimization used for generating the model. Default: "auto"</param>
        /// <param name="metric">Match metric. Default: "ignore_local_polarity"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: 5</param>
        /// <param name="genParamName">The generic parameter names. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <returns>Handle of the model.</returns>
        public HDeformableModel CreatePlanarUncalibDeformableModelXld(
          int numLevels,
          HTuple angleStart,
          HTuple angleExtent,
          double angleStep,
          double scaleRMin,
          HTuple scaleRMax,
          double scaleRStep,
          double scaleCMin,
          HTuple scaleCMax,
          double scaleCStep,
          string optimization,
          string metric,
          int minContrast,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(977);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, numLevels);
            HalconAPI.Store(proc, 1, angleStart);
            HalconAPI.Store(proc, 2, angleExtent);
            HalconAPI.StoreD(proc, 3, angleStep);
            HalconAPI.StoreD(proc, 4, scaleRMin);
            HalconAPI.Store(proc, 5, scaleRMax);
            HalconAPI.StoreD(proc, 6, scaleRStep);
            HalconAPI.StoreD(proc, 7, scaleCMin);
            HalconAPI.Store(proc, 8, scaleCMax);
            HalconAPI.StoreD(proc, 9, scaleCStep);
            HalconAPI.StoreS(proc, 10, optimization);
            HalconAPI.StoreS(proc, 11, metric);
            HalconAPI.StoreI(proc, 12, minContrast);
            HalconAPI.Store(proc, 13, genParamName);
            HalconAPI.Store(proc, 14, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(angleStart);
            HalconAPI.UnpinTuple(angleExtent);
            HalconAPI.UnpinTuple(scaleRMax);
            HalconAPI.UnpinTuple(scaleCMax);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HDeformableModel hdeformableModel;
            int procResult = HDeformableModel.LoadNew(proc, 0, err, out hdeformableModel);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hdeformableModel;
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
          out HXLDCont meshes,
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
            int procResult = HXLDCont.LoadNew(proc, 2, err2, out meshes);
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
          out HXLDCont meshes,
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
            int procResult = HXLDCont.LoadNew(proc, 2, err2, out meshes);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return himage;
        }

        /// <summary>
        ///   Interactive modification of a NURBS curve using interpolation.
        ///   Modified instance represents: Contour of the modified curve.
        /// </summary>
        /// <param name="windowHandle">Window handle.</param>
        /// <param name="rotate">Enable rotation? Default: "true"</param>
        /// <param name="move">Enable moving? Default: "true"</param>
        /// <param name="scale">Enable scaling? Default: "true"</param>
        /// <param name="keepRatio">Keep ratio while scaling? Default: "true"</param>
        /// <param name="edit">Enable editing? Default: "true"</param>
        /// <param name="degree">The degree $p$ of the NURBS curve. Reasonable values are 3 to 5. Default: 3</param>
        /// <param name="rowsIn">Row coordinates of the input interpolation points.</param>
        /// <param name="colsIn">Column coordinates of the input interpolation points.</param>
        /// <param name="tangentsIn">Input tangents.</param>
        /// <param name="controlRows">Row coordinates of the control polygon.</param>
        /// <param name="controlCols">Column coordinates of the control polygon.</param>
        /// <param name="knots">Knot vector.</param>
        /// <param name="rows">Row coordinates of the points specified by the user.</param>
        /// <param name="cols">Column coordinates of the points specified by the user.</param>
        /// <param name="tangents">Tangents specified by the user.</param>
        public void DrawNurbsInterpMod(
          HWindow windowHandle,
          string rotate,
          string move,
          string scale,
          string keepRatio,
          string edit,
          int degree,
          HTuple rowsIn,
          HTuple colsIn,
          HTuple tangentsIn,
          out HTuple controlRows,
          out HTuple controlCols,
          out HTuple knots,
          out HTuple rows,
          out HTuple cols,
          out HTuple tangents)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1318);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            HalconAPI.StoreS(proc, 1, rotate);
            HalconAPI.StoreS(proc, 2, move);
            HalconAPI.StoreS(proc, 3, scale);
            HalconAPI.StoreS(proc, 4, keepRatio);
            HalconAPI.StoreS(proc, 5, edit);
            HalconAPI.StoreI(proc, 6, degree);
            HalconAPI.Store(proc, 7, rowsIn);
            HalconAPI.Store(proc, 8, colsIn);
            HalconAPI.Store(proc, 9, tangentsIn);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(rowsIn);
            HalconAPI.UnpinTuple(colsIn);
            HalconAPI.UnpinTuple(tangentsIn);
            int err2 = this.Load(proc, 1, err1);
            int err3 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err2, out controlRows);
            int err4 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err3, out controlCols);
            int err5 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err4, out knots);
            int err6 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err5, out rows);
            int err7 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err6, out cols);
            int procResult = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, err7, out tangents);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)windowHandle);
        }

        /// <summary>
        ///   Interactive drawing of a NURBS curve using interpolation.
        ///   Modified instance represents: Contour of the curve.
        /// </summary>
        /// <param name="windowHandle">Window handle.</param>
        /// <param name="rotate">Enable rotation? Default: "true"</param>
        /// <param name="move">Enable moving? Default: "true"</param>
        /// <param name="scale">Enable scaling? Default: "true"</param>
        /// <param name="keepRatio">Keep ratio while scaling? Default: "true"</param>
        /// <param name="degree">The degree $p$ of the NURBS curve. Reasonable values are 3 to 5. Default: 3</param>
        /// <param name="controlRows">Row coordinates of the control polygon.</param>
        /// <param name="controlCols">Column coordinates of the control polygon.</param>
        /// <param name="knots">Knot vector.</param>
        /// <param name="rows">Row coordinates of the points specified by the user.</param>
        /// <param name="cols">Column coordinates of the points specified by the user.</param>
        /// <param name="tangents">Tangents specified by the user.</param>
        public void DrawNurbsInterp(
          HWindow windowHandle,
          string rotate,
          string move,
          string scale,
          string keepRatio,
          int degree,
          out HTuple controlRows,
          out HTuple controlCols,
          out HTuple knots,
          out HTuple rows,
          out HTuple cols,
          out HTuple tangents)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1319);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            HalconAPI.StoreS(proc, 1, rotate);
            HalconAPI.StoreS(proc, 2, move);
            HalconAPI.StoreS(proc, 3, scale);
            HalconAPI.StoreS(proc, 4, keepRatio);
            HalconAPI.StoreI(proc, 5, degree);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = this.Load(proc, 1, err1);
            int err3 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err2, out controlRows);
            int err4 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err3, out controlCols);
            int err5 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err4, out knots);
            int err6 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err5, out rows);
            int err7 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err6, out cols);
            int procResult = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, err7, out tangents);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)windowHandle);
        }

        /// <summary>
        ///   Interactive modification of a NURBS curve.
        ///   Modified instance represents: Contour of the modified curve.
        /// </summary>
        /// <param name="windowHandle">Window handle.</param>
        /// <param name="rotate">Enable rotation? Default: "true"</param>
        /// <param name="move">Enable moving? Default: "true"</param>
        /// <param name="scale">Enable scaling? Default: "true"</param>
        /// <param name="keepRatio">Keep ratio while scaling? Default: "true"</param>
        /// <param name="edit">Enable editing? Default: "true"</param>
        /// <param name="degree">The degree $p$ of the NURBS curve. Reasonable values are 3 to 25. Default: 3</param>
        /// <param name="rowsIn">Row coordinates of the input control polygon.</param>
        /// <param name="colsIn">Column coordinates of the input control polygon.</param>
        /// <param name="weightsIn">Input weight vector.</param>
        /// <param name="rows">Row coordinates of the control polygon.</param>
        /// <param name="cols">Columns coordinates of the control polygon.</param>
        /// <param name="weights">Weight vector.</param>
        public void DrawNurbsMod(
          HWindow windowHandle,
          string rotate,
          string move,
          string scale,
          string keepRatio,
          string edit,
          int degree,
          HTuple rowsIn,
          HTuple colsIn,
          HTuple weightsIn,
          out HTuple rows,
          out HTuple cols,
          out HTuple weights)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1320);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            HalconAPI.StoreS(proc, 1, rotate);
            HalconAPI.StoreS(proc, 2, move);
            HalconAPI.StoreS(proc, 3, scale);
            HalconAPI.StoreS(proc, 4, keepRatio);
            HalconAPI.StoreS(proc, 5, edit);
            HalconAPI.StoreI(proc, 6, degree);
            HalconAPI.Store(proc, 7, rowsIn);
            HalconAPI.Store(proc, 8, colsIn);
            HalconAPI.Store(proc, 9, weightsIn);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(rowsIn);
            HalconAPI.UnpinTuple(colsIn);
            HalconAPI.UnpinTuple(weightsIn);
            int err2 = this.Load(proc, 1, err1);
            int err3 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err2, out rows);
            int err4 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err3, out cols);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err4, out weights);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)windowHandle);
        }

        /// <summary>
        ///   Interactive drawing of a NURBS curve.
        ///   Modified instance represents: Contour approximating the NURBS curve.
        /// </summary>
        /// <param name="windowHandle">Window handle.</param>
        /// <param name="rotate">Enable rotation? Default: "true"</param>
        /// <param name="move">Enable moving? Default: "true"</param>
        /// <param name="scale">Enable scaling? Default: "true"</param>
        /// <param name="keepRatio">Keep ratio while scaling? Default: "true"</param>
        /// <param name="degree">The degree $p$ of the NURBS curve. Reasonable values are 3 to 25. Default: 3</param>
        /// <param name="rows">Row coordinates of the control polygon.</param>
        /// <param name="cols">Columns coordinates of the control polygon.</param>
        /// <param name="weights">Weight vector.</param>
        public void DrawNurbs(
          HWindow windowHandle,
          string rotate,
          string move,
          string scale,
          string keepRatio,
          int degree,
          out HTuple rows,
          out HTuple cols,
          out HTuple weights)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1321);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            HalconAPI.StoreS(proc, 1, rotate);
            HalconAPI.StoreS(proc, 2, move);
            HalconAPI.StoreS(proc, 3, scale);
            HalconAPI.StoreS(proc, 4, keepRatio);
            HalconAPI.StoreI(proc, 5, degree);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = this.Load(proc, 1, err1);
            int err3 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err2, out rows);
            int err4 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err3, out cols);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err4, out weights);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)windowHandle);
        }

        /// <summary>
        ///   Interactive modification of a contour.
        ///   Instance represents: Input contour.
        /// </summary>
        /// <param name="windowHandle">Window handle.</param>
        /// <param name="rotate">Enable rotation? Default: "true"</param>
        /// <param name="move">Enable moving? Default: "true"</param>
        /// <param name="scale">Enable scaling? Default: "true"</param>
        /// <param name="keepRatio">Keep ratio while scaling? Default: "true"</param>
        /// <param name="edit">Enable editing? Default: "true"</param>
        /// <returns>Modified contour.</returns>
        public HXLDCont DrawXldMod(
          HWindow windowHandle,
          string rotate,
          string move,
          string scale,
          string keepRatio,
          string edit)
        {
            IntPtr proc = HalconAPI.PreCall(1322);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            HalconAPI.StoreS(proc, 1, rotate);
            HalconAPI.StoreS(proc, 2, move);
            HalconAPI.StoreS(proc, 3, scale);
            HalconAPI.StoreS(proc, 4, keepRatio);
            HalconAPI.StoreS(proc, 5, edit);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)windowHandle);
            return hxldCont;
        }

        /// <summary>
        ///   Interactive drawing of a contour.
        ///   Modified instance represents: Modified contour.
        /// </summary>
        /// <param name="windowHandle">Window handle.</param>
        /// <param name="rotate">Enable rotation? Default: "true"</param>
        /// <param name="move">Enable moving? Default: "true"</param>
        /// <param name="scale">Enable scaling? Default: "true"</param>
        /// <param name="keepRatio">Keep ratio while scaling? Default: "true"</param>
        public void DrawXld(
          HWindow windowHandle,
          string rotate,
          string move,
          string scale,
          string keepRatio)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1323);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            HalconAPI.StoreS(proc, 1, rotate);
            HalconAPI.StoreS(proc, 2, move);
            HalconAPI.StoreS(proc, 3, scale);
            HalconAPI.StoreS(proc, 4, keepRatio);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)windowHandle);
        }

        /// <summary>
        ///   Calculate the pointwise distance from one contour to another.
        ///   Instance represents: Contours for whose points the distances are calculated.
        /// </summary>
        /// <param name="contourTo">Contours to which the distances are calculated to.</param>
        /// <param name="mode">Compute the distance to points ('point_to_point') or to entire segments ('point_to_segment'). Default: "point_to_point"</param>
        /// <returns>Copy of ContourFrom containing the distances as an attribute.</returns>
        public HXLDCont DistanceContoursXld(HXLDCont contourTo, string mode)
        {
            IntPtr proc = HalconAPI.PreCall(1361);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)contourTo);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contourTo);
            return hxldCont;
        }

        /// <summary>
        ///   Calculate the minimum distance between two contours.
        ///   Instance represents: First input contour.
        /// </summary>
        /// <param name="contour2">Second input contour.</param>
        /// <param name="mode">Distance calculation mode. Default: "fast_point_to_segment"</param>
        /// <returns>Minimum distance between the two contours.</returns>
        public HTuple DistanceCcMin(HXLDCont contour2, string mode)
        {
            IntPtr proc = HalconAPI.PreCall(1362);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)contour2);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contour2);
            return tuple;
        }

        /// <summary>
        ///   Calculate the distance between two contours.
        ///   Instance represents: First input contour.
        /// </summary>
        /// <param name="contour2">Second input contour.</param>
        /// <param name="mode">Distance calculation mode. Default: "point_to_point"</param>
        /// <param name="distanceMin">Minimum distance between both contours.</param>
        /// <param name="distanceMax">Maximum distance between both contours.</param>
        public void DistanceCc(
          HXLDCont contour2,
          string mode,
          out HTuple distanceMin,
          out HTuple distanceMax)
        {
            IntPtr proc = HalconAPI.PreCall(1363);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)contour2);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out distanceMin);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out distanceMax);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contour2);
        }

        /// <summary>
        ///   Calculate the distance between two contours.
        ///   Instance represents: First input contour.
        /// </summary>
        /// <param name="contour2">Second input contour.</param>
        /// <param name="mode">Distance calculation mode. Default: "point_to_point"</param>
        /// <param name="distanceMin">Minimum distance between both contours.</param>
        /// <param name="distanceMax">Maximum distance between both contours.</param>
        public void DistanceCc(
          HXLDCont contour2,
          string mode,
          out double distanceMin,
          out double distanceMax)
        {
            IntPtr proc = HalconAPI.PreCall(1363);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)contour2);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out distanceMin);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out distanceMax);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contour2);
        }

        /// <summary>
        ///   Calculate the distance between a line segment and one contour.
        ///   Instance represents: Input contour.
        /// </summary>
        /// <param name="row1">Row coordinate of the first point of the line segment.</param>
        /// <param name="column1">Column coordinate of the first point of the line segment.</param>
        /// <param name="row2">Row coordinate of the second point of the line segment.</param>
        /// <param name="column2">Column coordinate of the second point of the line segment.</param>
        /// <param name="distanceMin">Minimum distance between the line segment and the contour.</param>
        /// <param name="distanceMax">Maximum distance between the line segment and the contour.</param>
        public void DistanceSc(
          HTuple row1,
          HTuple column1,
          HTuple row2,
          HTuple column2,
          out HTuple distanceMin,
          out HTuple distanceMax)
        {
            IntPtr proc = HalconAPI.PreCall(1364);
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
        ///   Calculate the distance between a line segment and one contour.
        ///   Instance represents: Input contour.
        /// </summary>
        /// <param name="row1">Row coordinate of the first point of the line segment.</param>
        /// <param name="column1">Column coordinate of the first point of the line segment.</param>
        /// <param name="row2">Row coordinate of the second point of the line segment.</param>
        /// <param name="column2">Column coordinate of the second point of the line segment.</param>
        /// <param name="distanceMin">Minimum distance between the line segment and the contour.</param>
        /// <param name="distanceMax">Maximum distance between the line segment and the contour.</param>
        public void DistanceSc(
          double row1,
          double column1,
          double row2,
          double column2,
          out double distanceMin,
          out double distanceMax)
        {
            IntPtr proc = HalconAPI.PreCall(1364);
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
        ///   Calculate the distance between a line and one contour.
        ///   Instance represents: Input contour.
        /// </summary>
        /// <param name="row1">Row coordinate of the first point of the line.</param>
        /// <param name="column1">Column coordinate of the first point of the line.</param>
        /// <param name="row2">Row coordinate of the second point of the line.</param>
        /// <param name="column2">Column coordinate of the second point of the line.</param>
        /// <param name="distanceMin">Minimum distance between the line and the contour.</param>
        /// <param name="distanceMax">Maximum distance between the line and the contour.</param>
        public void DistanceLc(
          HTuple row1,
          HTuple column1,
          HTuple row2,
          HTuple column2,
          out HTuple distanceMin,
          out HTuple distanceMax)
        {
            IntPtr proc = HalconAPI.PreCall(1365);
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
        ///   Calculate the distance between a line and one contour.
        ///   Instance represents: Input contour.
        /// </summary>
        /// <param name="row1">Row coordinate of the first point of the line.</param>
        /// <param name="column1">Column coordinate of the first point of the line.</param>
        /// <param name="row2">Row coordinate of the second point of the line.</param>
        /// <param name="column2">Column coordinate of the second point of the line.</param>
        /// <param name="distanceMin">Minimum distance between the line and the contour.</param>
        /// <param name="distanceMax">Maximum distance between the line and the contour.</param>
        public void DistanceLc(
          double row1,
          double column1,
          double row2,
          double column2,
          out double distanceMin,
          out double distanceMax)
        {
            IntPtr proc = HalconAPI.PreCall(1365);
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
        ///   Calculate the distance between a point and one contour.
        ///   Instance represents: Input contour.
        /// </summary>
        /// <param name="row">Row coordinate of the point.</param>
        /// <param name="column">Column coordinate of the point.</param>
        /// <param name="distanceMin">Minimum distance between the point and the contour.</param>
        /// <param name="distanceMax">Maximum distance between the point and the contour.</param>
        public void DistancePc(
          HTuple row,
          HTuple column,
          out HTuple distanceMin,
          out HTuple distanceMax)
        {
            IntPtr proc = HalconAPI.PreCall(1366);
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
        ///   Calculate the distance between a point and one contour.
        ///   Instance represents: Input contour.
        /// </summary>
        /// <param name="row">Row coordinate of the point.</param>
        /// <param name="column">Column coordinate of the point.</param>
        /// <param name="distanceMin">Minimum distance between the point and the contour.</param>
        /// <param name="distanceMax">Maximum distance between the point and the contour.</param>
        public void DistancePc(
          double row,
          double column,
          out double distanceMin,
          out double distanceMax)
        {
            IntPtr proc = HalconAPI.PreCall(1366);
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
        ///   Read XLD contours from a DXF file.
        ///   Modified instance represents: Read XLD contours.
        /// </summary>
        /// <param name="fileName">Name of the DXF file.</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the DXF input. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the DXF input. Default: []</param>
        /// <returns>Status information.</returns>
        public HTuple ReadContourXldDxf(
          string fileName,
          HTuple genParamName,
          HTuple genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1636);
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
        ///   Read XLD contours from a DXF file.
        ///   Modified instance represents: Read XLD contours.
        /// </summary>
        /// <param name="fileName">Name of the DXF file.</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the DXF input. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the DXF input. Default: []</param>
        /// <returns>Status information.</returns>
        public string ReadContourXldDxf(string fileName, string genParamName, double genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1636);
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
        ///   Write XLD contours to a file in DXF format.
        ///   Instance represents: XLD contours to be written.
        /// </summary>
        /// <param name="fileName">Name of the DXF file.</param>
        public void WriteContourXldDxf(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1637);
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
        public HXLDCont SelectXldPoint(HTuple row, HTuple column)
        {
            IntPtr proc = HalconAPI.PreCall(1676);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, column);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Choose all contours or polygons containing a given point.
        ///   Instance represents: Contours or polygons to be examined.
        /// </summary>
        /// <param name="row">Line coordinate of the test point. Default: 100.0</param>
        /// <param name="column">Column coordinate of the test point. Default: 100.0</param>
        /// <returns>All contours or polygons containing the test point.</returns>
        public HXLDCont SelectXldPoint(double row, double column)
        {
            IntPtr proc = HalconAPI.PreCall(1676);
            this.Store(proc, 1);
            HalconAPI.StoreD(proc, 0, row);
            HalconAPI.StoreD(proc, 1, column);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
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
        public HXLDCont SelectShapeXld(
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
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
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
        public HXLDCont SelectShapeXld(
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
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Transform the shape of contours or polygons.
        ///   Instance represents: Contours or polygons to be transformed.
        /// </summary>
        /// <param name="type">Type of transformation. Default: "convex"</param>
        /// <returns>Transformed contours respectively polygons.</returns>
        public HXLDCont ShapeTransXld(string type)
        {
            IntPtr proc = HalconAPI.PreCall(1689);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, type);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Calibrate the radial distortion.
        ///   Instance represents: Contours that are available for the calibration.
        /// </summary>
        /// <param name="width">Width of the images from which the contours were extracted. Default: 640</param>
        /// <param name="height">Height of the images from which the contours were extracted. Default: 480</param>
        /// <param name="inlierThreshold">Threshold for the classification of outliers. Default: 0.05</param>
        /// <param name="randSeed">Seed value for the random number generator. Default: 42</param>
        /// <param name="distortionModel">Determines the distortion model. Default: "division"</param>
        /// <param name="distortionCenter">Determines how the distortion center will be estimated. Default: "variable"</param>
        /// <param name="principalPointVar">Controls the deviation of the distortion center from the image center; larger values allow larger deviations from the image center; 0 switches the penalty term off. Default: 0.0</param>
        /// <param name="cameraParam">Internal camera parameters.</param>
        /// <returns>Contours that were used for the calibration</returns>
        public HXLDCont RadialDistortionSelfCalibration(
          int width,
          int height,
          double inlierThreshold,
          int randSeed,
          string distortionModel,
          string distortionCenter,
          double principalPointVar,
          out HCamPar cameraParam)
        {
            IntPtr proc = HalconAPI.PreCall(1904);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, width);
            HalconAPI.StoreI(proc, 1, height);
            HalconAPI.StoreD(proc, 2, inlierThreshold);
            HalconAPI.StoreI(proc, 3, randSeed);
            HalconAPI.StoreS(proc, 4, distortionModel);
            HalconAPI.StoreS(proc, 5, distortionCenter);
            HalconAPI.StoreD(proc, 6, principalPointVar);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            int err1 = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int err2 = HXLDCont.LoadNew(proc, 1, err1, out hxldCont);
            int procResult = HCamPar.LoadNew(proc, 0, err2, out cameraParam);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Transform an XLD contour into the plane z=0 of a world coordinate system.
        ///   Instance represents: Input XLD contours to be transformed in image coordinates.
        /// </summary>
        /// <param name="cameraParam">Internal camera parameters.</param>
        /// <param name="worldPose">3D pose of the world coordinate system in camera coordinates.</param>
        /// <param name="scale">Scale or dimension Default: "m"</param>
        /// <returns>Transformed XLD contours in world coordinates.</returns>
        public HXLDCont ContourToWorldPlaneXld(
          HTuple cameraParam,
          HPose worldPose,
          HTuple scale)
        {
            IntPtr proc = HalconAPI.PreCall(1915);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, cameraParam);
            HalconAPI.Store(proc, 1, (HData)worldPose);
            HalconAPI.Store(proc, 2, scale);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(cameraParam);
            HalconAPI.UnpinTuple((HTuple)((HData)worldPose));
            HalconAPI.UnpinTuple(scale);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Transform an XLD contour into the plane z=0 of a world coordinate system.
        ///   Instance represents: Input XLD contours to be transformed in image coordinates.
        /// </summary>
        /// <param name="cameraParam">Internal camera parameters.</param>
        /// <param name="worldPose">3D pose of the world coordinate system in camera coordinates.</param>
        /// <param name="scale">Scale or dimension Default: "m"</param>
        /// <returns>Transformed XLD contours in world coordinates.</returns>
        public HXLDCont ContourToWorldPlaneXld(
          HTuple cameraParam,
          HPose worldPose,
          string scale)
        {
            IntPtr proc = HalconAPI.PreCall(1915);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, cameraParam);
            HalconAPI.Store(proc, 1, (HData)worldPose);
            HalconAPI.StoreS(proc, 2, scale);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(cameraParam);
            HalconAPI.UnpinTuple((HTuple)((HData)worldPose));
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Change the radial distortion of contours.
        ///   Instance represents: Original contours.
        /// </summary>
        /// <param name="camParamIn">Internal camera parameter for Contours.</param>
        /// <param name="camParamOut">Internal camera parameter for ContoursRectified.</param>
        /// <returns>Resulting contours with modified radial distortion.</returns>
        public HXLDCont ChangeRadialDistortionContoursXld(
          HCamPar camParamIn,
          HCamPar camParamOut)
        {
            IntPtr proc = HalconAPI.PreCall(1922);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HData)camParamIn);
            HalconAPI.Store(proc, 1, (HData)camParamOut);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)camParamIn));
            HalconAPI.UnpinTuple((HTuple)((HData)camParamOut));
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Calculate the minimum distance between two contours and the points used for  the calculation.
        ///   Instance represents: First input contour.
        /// </summary>
        /// <param name="contour2">Second input contour.</param>
        /// <param name="mode">Distance calculation mode. Default: "fast_point_to_segment"</param>
        /// <param name="row1">Row coordinate of the point on Contour1.</param>
        /// <param name="column1">Column coordinate of the point on Contour1.</param>
        /// <param name="row2">Row coordinate of the point on Contour2.</param>
        /// <param name="column2">Column coordinate of the point on Contour2.</param>
        /// <returns>Minimum distance between the two contours.</returns>
        public HTuple DistanceCcMinPoints(
          HXLDCont contour2,
          string mode,
          out HTuple row1,
          out HTuple column1,
          out HTuple row2,
          out HTuple column2)
        {
            IntPtr proc = HalconAPI.PreCall(2111);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)contour2);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out row1);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out column1);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out row2);
            int procResult = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out column2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contour2);
            return tuple;
        }

        /// <summary>
        ///   Calculate the minimum distance between two contours and the points used for  the calculation.
        ///   Instance represents: First input contour.
        /// </summary>
        /// <param name="contour2">Second input contour.</param>
        /// <param name="mode">Distance calculation mode. Default: "fast_point_to_segment"</param>
        /// <param name="row1">Row coordinate of the point on Contour1.</param>
        /// <param name="column1">Column coordinate of the point on Contour1.</param>
        /// <param name="row2">Row coordinate of the point on Contour2.</param>
        /// <param name="column2">Column coordinate of the point on Contour2.</param>
        /// <returns>Minimum distance between the two contours.</returns>
        public double DistanceCcMinPoints(
          HXLDCont contour2,
          string mode,
          out double row1,
          out double column1,
          out double row2,
          out double column2)
        {
            IntPtr proc = HalconAPI.PreCall(2111);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)contour2);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out row1);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out column1);
            int err5 = HalconAPI.LoadD(proc, 3, err4, out row2);
            int procResult = HalconAPI.LoadD(proc, 4, err5, out column2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contour2);
            return doubleValue;
        }

        /// <summary>
        ///   Insert objects into an iconic object tuple.
        ///   Instance represents: Input object tuple.
        /// </summary>
        /// <param name="objectsInsert">Object tuple to insert.</param>
        /// <param name="index">Index to insert objects.</param>
        /// <returns>Extended object tuple.</returns>
        public HXLDCont InsertObj(HXLDCont objectsInsert, int index)
        {
            IntPtr proc = HalconAPI.PreCall(2121);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objectsInsert);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectsInsert);
            return hxldCont;
        }

        /// <summary>
        ///   Remove objects from an iconic object tuple.
        ///   Instance represents: Input object tuple.
        /// </summary>
        /// <param name="index">Indices of the objects to be removed.</param>
        /// <returns>Remaining object tuple.</returns>
        public HXLDCont RemoveObj(HTuple index)
        {
            IntPtr proc = HalconAPI.PreCall(2124);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Remove objects from an iconic object tuple.
        ///   Instance represents: Input object tuple.
        /// </summary>
        /// <param name="index">Indices of the objects to be removed.</param>
        /// <returns>Remaining object tuple.</returns>
        public HXLDCont RemoveObj(int index)
        {
            IntPtr proc = HalconAPI.PreCall(2124);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Replaces one or more elements of an iconic object tuple.
        ///   Instance represents: Iconic Input Object.
        /// </summary>
        /// <param name="objectsReplace">Element(s) to replace.</param>
        /// <param name="index">Index/Indices of elements to be replaced.</param>
        /// <returns>Tuple with replaced elements.</returns>
        public HXLDCont ReplaceObj(HXLDCont objectsReplace, HTuple index)
        {
            IntPtr proc = HalconAPI.PreCall(2125);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objectsReplace);
            HalconAPI.Store(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectsReplace);
            return hxldCont;
        }

        /// <summary>
        ///   Replaces one or more elements of an iconic object tuple.
        ///   Instance represents: Iconic Input Object.
        /// </summary>
        /// <param name="objectsReplace">Element(s) to replace.</param>
        /// <param name="index">Index/Indices of elements to be replaced.</param>
        /// <returns>Tuple with replaced elements.</returns>
        public HXLDCont ReplaceObj(HXLDCont objectsReplace, int index)
        {
            IntPtr proc = HalconAPI.PreCall(2125);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objectsReplace);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectsReplace);
            return hxldCont;
        }
    }
}
