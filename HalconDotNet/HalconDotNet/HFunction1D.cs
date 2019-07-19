// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HFunction1D
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a 1d function.</summary>
    public class HFunction1D : HData
    {
        /// <summary>Create an uninitialized instance.</summary>
        public HFunction1D()
        {
        }

        internal HFunction1D(HData data)
          : base(data)
        {
        }

        internal static int LoadNew(
          IntPtr proc,
          int parIndex,
          HTupleType type,
          int err,
          out HFunction1D obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HFunction1D(new HData(tuple));
            return err;
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HFunction1D obj)
        {
            return HFunction1D.LoadNew(proc, parIndex, HTupleType.MIXED, err, out obj);
        }

        /// <summary>
        ///   Create a function from a sequence of y-values.
        ///   Modified instance represents: Created function.
        /// </summary>
        /// <param name="YValues">X value for function points.</param>
        public HFunction1D(HTuple YValues)
        {
            IntPtr proc = HalconAPI.PreCall(1399);
            HalconAPI.Store(proc, 0, YValues);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(YValues);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a function from a sequence of y-values.
        ///   Modified instance represents: Created function.
        /// </summary>
        /// <param name="YValues">X value for function points.</param>
        public HFunction1D(double YValues)
        {
            IntPtr proc = HalconAPI.PreCall(1399);
            HalconAPI.StoreD(proc, 0, YValues);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a function from a set of (x,y) pairs.
        ///   Modified instance represents: Created function.
        /// </summary>
        /// <param name="XValues">X value for function points.</param>
        /// <param name="YValues">Y-value for function points.</param>
        public HFunction1D(HTuple XValues, HTuple YValues)
        {
            IntPtr proc = HalconAPI.PreCall(1400);
            HalconAPI.Store(proc, 0, XValues);
            HalconAPI.Store(proc, 1, YValues);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(XValues);
            HalconAPI.UnpinTuple(YValues);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a function from a set of (x,y) pairs.
        ///   Modified instance represents: Created function.
        /// </summary>
        /// <param name="XValues">X value for function points.</param>
        /// <param name="YValues">Y-value for function points.</param>
        public HFunction1D(double XValues, double YValues)
        {
            IntPtr proc = HalconAPI.PreCall(1400);
            HalconAPI.StoreD(proc, 0, XValues);
            HalconAPI.StoreD(proc, 1, YValues);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>Adds a constant offset to the function's Y values</summary>
        public static HFunction1D operator +(HFunction1D function, double add)
        {
            return function.ScaleYFunct1d(1.0, add);
        }

        /// <summary>Adds a constant offset to the function's Y values</summary>
        public static HFunction1D operator +(double add, HFunction1D function)
        {
            return function.ScaleYFunct1d(1.0, add);
        }

        /// <summary>Subtracts a constant offset from the function's Y values</summary>
        public static HFunction1D operator -(HFunction1D function, double sub)
        {
            return function.ScaleYFunct1d(1.0, -sub);
        }

        /// <summary>Negates the Y values of the function</summary>
        public static HFunction1D operator -(HFunction1D function)
        {
            return function.NegateFunct1d();
        }

        /// <summary>Scales the function's Y values</summary>
        public static HFunction1D operator *(HFunction1D function, double factor)
        {
            return function.ScaleYFunct1d(factor, 0.0);
        }

        /// <summary>Scales the function's Y values</summary>
        public static HFunction1D operator *(double factor, HFunction1D function)
        {
            return function.ScaleYFunct1d(factor, 0.0);
        }

        /// <summary>Scales the function's Y values</summary>
        public static HFunction1D operator /(HFunction1D function, double divisor)
        {
            return function.ScaleYFunct1d(1.0 / divisor, 0.0);
        }

        /// <summary>Composes two functions (not a pointwise multiplication)</summary>
        public static HFunction1D operator *(HFunction1D function1, HFunction1D function2)
        {
            return function1.ComposeFunct1d(function2, "constant");
        }

        /// <summary>Calculates the inverse of the function</summary>
        public static HFunction1D operator !(HFunction1D function)
        {
            return function.InvertFunct1d();
        }

        /// <summary>
        ///   Plot a function using gnuplot.
        ///   Instance represents: Function to be plotted.
        /// </summary>
        /// <param name="gnuplotFileID">Identifier for the gnuplot output stream.</param>
        public void GnuplotPlotFunct1d(HGnuplot gnuplotFileID)
        {
            IntPtr proc = HalconAPI.PreCall(1295);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)gnuplotFileID);
            int procResult = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)gnuplotFileID);
        }

        /// <summary>
        ///   Compose two functions.
        ///   Instance represents: Input function 1.
        /// </summary>
        /// <param name="function2">Input function 2.</param>
        /// <param name="border">Border treatment for the input functions. Default: "constant"</param>
        /// <returns>Composed function.</returns>
        public HFunction1D ComposeFunct1d(HFunction1D function2, string border)
        {
            IntPtr proc = HalconAPI.PreCall(1377);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)function2);
            HalconAPI.StoreS(proc, 2, border);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)function2));
            HFunction1D hfunction1D;
            int procResult = HFunction1D.LoadNew(proc, 0, err, out hfunction1D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hfunction1D;
        }

        /// <summary>
        ///   Calculate the inverse of a function.
        ///   Instance represents: Input function.
        /// </summary>
        /// <returns>Inverse of the input function.</returns>
        public HFunction1D InvertFunct1d()
        {
            IntPtr proc = HalconAPI.PreCall(1378);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HFunction1D hfunction1D;
            int procResult = HFunction1D.LoadNew(proc, 0, err, out hfunction1D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hfunction1D;
        }

        /// <summary>
        ///   Calculate the derivatives of a function.
        ///   Instance represents: Input function
        /// </summary>
        /// <param name="mode">Type of derivative Default: "first"</param>
        /// <returns>Derivative of the input function</returns>
        public HFunction1D DerivateFunct1d(string mode)
        {
            IntPtr proc = HalconAPI.PreCall(1379);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, mode);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HFunction1D hfunction1D;
            int procResult = HFunction1D.LoadNew(proc, 0, err, out hfunction1D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hfunction1D;
        }

        /// <summary>
        ///   Calculate the local minimum and maximum points of a function.
        ///   Instance represents: Input function
        /// </summary>
        /// <param name="mode">Handling of plateaus Default: "strict_min_max"</param>
        /// <param name="interpolation">Interpolation of the input function Default: "true"</param>
        /// <param name="min">Minimum points of the input function</param>
        /// <param name="max">Maximum points of the input function</param>
        public void LocalMinMaxFunct1d(
          string mode,
          string interpolation,
          out HTuple min,
          out HTuple max)
        {
            IntPtr proc = HalconAPI.PreCall(1380);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, mode);
            HalconAPI.StoreS(proc, 2, interpolation);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out min);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out max);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Calculate the zero crossings of a function.
        ///   Instance represents: Input function
        /// </summary>
        /// <returns>Zero crossings of the input function</returns>
        public HTuple ZeroCrossingsFunct1d()
        {
            IntPtr proc = HalconAPI.PreCall(1381);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Multiplication and addition of the y values.
        ///   Instance represents: Input function.
        /// </summary>
        /// <param name="mult">Factor for scaling of the y values. Default: 2.0</param>
        /// <param name="add">Constant which is added to the y values. Default: 0.0</param>
        /// <returns>Transformed function.</returns>
        public HFunction1D ScaleYFunct1d(double mult, double add)
        {
            IntPtr proc = HalconAPI.PreCall(1382);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, mult);
            HalconAPI.StoreD(proc, 2, add);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HFunction1D hfunction1D;
            int procResult = HFunction1D.LoadNew(proc, 0, err, out hfunction1D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hfunction1D;
        }

        /// <summary>
        ///   Negation of the y values.
        ///   Instance represents: Input function.
        /// </summary>
        /// <returns>Function with the negated y values.</returns>
        public HFunction1D NegateFunct1d()
        {
            IntPtr proc = HalconAPI.PreCall(1383);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HFunction1D hfunction1D;
            int procResult = HFunction1D.LoadNew(proc, 0, err, out hfunction1D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hfunction1D;
        }

        /// <summary>
        ///   Absolute value of the y values.
        ///   Instance represents: Input function.
        /// </summary>
        /// <returns>Function with the absolute values of the y values.</returns>
        public HFunction1D AbsFunct1d()
        {
            IntPtr proc = HalconAPI.PreCall(1384);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HFunction1D hfunction1D;
            int procResult = HFunction1D.LoadNew(proc, 0, err, out hfunction1D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hfunction1D;
        }

        /// <summary>
        ///   Return the value of a function at an arbitrary position.
        ///   Instance represents: Input function.
        /// </summary>
        /// <param name="x">X coordinate at which the function should be evaluated.</param>
        /// <param name="border">Border treatment for the input function. Default: "constant"</param>
        /// <returns>Y value at the given x value.</returns>
        public HTuple GetYValueFunct1d(HTuple x, string border)
        {
            IntPtr proc = HalconAPI.PreCall(1385);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, x);
            HalconAPI.StoreS(proc, 2, border);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(x);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Return the value of a function at an arbitrary position.
        ///   Instance represents: Input function.
        /// </summary>
        /// <param name="x">X coordinate at which the function should be evaluated.</param>
        /// <param name="border">Border treatment for the input function. Default: "constant"</param>
        /// <returns>Y value at the given x value.</returns>
        public double GetYValueFunct1d(double x, string border)
        {
            IntPtr proc = HalconAPI.PreCall(1385);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, x);
            HalconAPI.StoreS(proc, 2, border);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Access a function value using the index of the control points.
        ///   Instance represents: Input function.
        /// </summary>
        /// <param name="index">Index of the control points.</param>
        /// <param name="x">X value at the given control points.</param>
        /// <param name="y">Y value at the given control points.</param>
        public void GetPairFunct1d(HTuple index, out HTuple x, out HTuple y)
        {
            IntPtr proc = HalconAPI.PreCall(1386);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, index);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(index);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out x);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out y);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Access a function value using the index of the control points.
        ///   Instance represents: Input function.
        /// </summary>
        /// <param name="index">Index of the control points.</param>
        /// <param name="x">X value at the given control points.</param>
        /// <param name="y">Y value at the given control points.</param>
        public void GetPairFunct1d(int index, out double x, out double y)
        {
            IntPtr proc = HalconAPI.PreCall(1386);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, index);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            int err2 = HalconAPI.LoadD(proc, 0, err1, out x);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out y);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Number of control points of the function.
        ///   Instance represents: Input function.
        /// </summary>
        /// <returns>Number of control points.</returns>
        public int NumPointsFunct1d()
        {
            IntPtr proc = HalconAPI.PreCall(1387);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Smallest and largest y value of the function.
        ///   Instance represents: Input function.
        /// </summary>
        /// <param name="YMin">Smallest y value.</param>
        /// <param name="YMax">Largest y value.</param>
        public void YRangeFunct1d(out double YMin, out double YMax)
        {
            IntPtr proc = HalconAPI.PreCall(1388);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            int err2 = HalconAPI.LoadD(proc, 0, err1, out YMin);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out YMax);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Smallest and largest x value of the function.
        ///   Instance represents: Input function.
        /// </summary>
        /// <param name="XMin">Smallest x value.</param>
        /// <param name="XMax">Largest x value.</param>
        public void XRangeFunct1d(out double XMin, out double XMax)
        {
            IntPtr proc = HalconAPI.PreCall(1389);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            int err2 = HalconAPI.LoadD(proc, 0, err1, out XMin);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out XMax);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Access to the x/y values of a function.
        ///   Instance represents: Input function.
        /// </summary>
        /// <param name="XValues">X values of the function.</param>
        /// <param name="YValues">Y values of the function.</param>
        public void Funct1dToPairs(out HTuple XValues, out HTuple YValues)
        {
            IntPtr proc = HalconAPI.PreCall(1390);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            int err2 = HTuple.LoadNew(proc, 0, err1, out XValues);
            int procResult = HTuple.LoadNew(proc, 1, err2, out YValues);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Sample a function equidistantly in an interval.
        ///   Instance represents: Input function.
        /// </summary>
        /// <param name="XMin">Minimum x value of the output function.</param>
        /// <param name="XMax">Maximum x value of the output function.</param>
        /// <param name="XDist">Distance of the samples.</param>
        /// <param name="border">Border treatment for the input function. Default: "constant"</param>
        /// <returns>Sampled function.</returns>
        public HFunction1D SampleFunct1d(
          HTuple XMin,
          HTuple XMax,
          HTuple XDist,
          string border)
        {
            IntPtr proc = HalconAPI.PreCall(1391);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, XMin);
            HalconAPI.Store(proc, 2, XMax);
            HalconAPI.Store(proc, 3, XDist);
            HalconAPI.StoreS(proc, 4, border);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(XMin);
            HalconAPI.UnpinTuple(XMax);
            HalconAPI.UnpinTuple(XDist);
            HFunction1D hfunction1D;
            int procResult = HFunction1D.LoadNew(proc, 0, err, out hfunction1D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hfunction1D;
        }

        /// <summary>
        ///   Sample a function equidistantly in an interval.
        ///   Instance represents: Input function.
        /// </summary>
        /// <param name="XMin">Minimum x value of the output function.</param>
        /// <param name="XMax">Maximum x value of the output function.</param>
        /// <param name="XDist">Distance of the samples.</param>
        /// <param name="border">Border treatment for the input function. Default: "constant"</param>
        /// <returns>Sampled function.</returns>
        public HFunction1D SampleFunct1d(
          double XMin,
          double XMax,
          double XDist,
          string border)
        {
            IntPtr proc = HalconAPI.PreCall(1391);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, XMin);
            HalconAPI.StoreD(proc, 2, XMax);
            HalconAPI.StoreD(proc, 3, XDist);
            HalconAPI.StoreS(proc, 4, border);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HFunction1D hfunction1D;
            int procResult = HFunction1D.LoadNew(proc, 0, err, out hfunction1D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hfunction1D;
        }

        /// <summary>
        ///   Transform a function using given transformation parameters.
        ///   Instance represents: Input function.
        /// </summary>
        /// <param name="paramsVal">Transformation parameters between the functions.</param>
        /// <returns>Transformed function.</returns>
        public HFunction1D TransformFunct1d(HTuple paramsVal)
        {
            IntPtr proc = HalconAPI.PreCall(1392);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, paramsVal);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(paramsVal);
            HFunction1D hfunction1D;
            int procResult = HFunction1D.LoadNew(proc, 0, err, out hfunction1D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hfunction1D;
        }

        /// <summary>
        ///   Calculate transformation parameters between two functions.
        ///   Instance represents: Function 1.
        /// </summary>
        /// <param name="function2">Function 2.</param>
        /// <param name="border">Border treatment for function 2. Default: "constant"</param>
        /// <param name="paramsConst">Values of the parameters to remain constant. Default: [1.0,0.0,1.0,0.0]</param>
        /// <param name="useParams">Should a parameter be adapted for it? Default: ["true","true","true","true"]</param>
        /// <param name="chiSquare">Quadratic error of the output function.</param>
        /// <param name="covar">Covariance Matrix of the transformation parameters.</param>
        /// <returns>Transformation parameters between the functions.</returns>
        public HTuple MatchFunct1dTrans(
          HFunction1D function2,
          string border,
          HTuple paramsConst,
          HTuple useParams,
          out double chiSquare,
          out HTuple covar)
        {
            IntPtr proc = HalconAPI.PreCall(1393);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)function2);
            HalconAPI.StoreS(proc, 2, border);
            HalconAPI.Store(proc, 3, paramsConst);
            HalconAPI.Store(proc, 4, useParams);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)function2));
            HalconAPI.UnpinTuple(paramsConst);
            HalconAPI.UnpinTuple(useParams);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out chiSquare);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out covar);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the distance of two functions.
        ///   Instance represents: Input function 1.
        /// </summary>
        /// <param name="function2">Input function 2.</param>
        /// <param name="mode">Modes of invariants. Default: "length"</param>
        /// <param name="sigma">Variance of the optional smoothing with a Gaussian filter. Default: 0.0</param>
        /// <returns>Distance of the functions.</returns>
        public HTuple DistanceFunct1d(HFunction1D function2, HTuple mode, HTuple sigma)
        {
            IntPtr proc = HalconAPI.PreCall(1394);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)function2);
            HalconAPI.Store(proc, 2, mode);
            HalconAPI.Store(proc, 3, sigma);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)function2));
            HalconAPI.UnpinTuple(mode);
            HalconAPI.UnpinTuple(sigma);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the distance of two functions.
        ///   Instance represents: Input function 1.
        /// </summary>
        /// <param name="function2">Input function 2.</param>
        /// <param name="mode">Modes of invariants. Default: "length"</param>
        /// <param name="sigma">Variance of the optional smoothing with a Gaussian filter. Default: 0.0</param>
        /// <returns>Distance of the functions.</returns>
        public HTuple DistanceFunct1d(HFunction1D function2, string mode, double sigma)
        {
            IntPtr proc = HalconAPI.PreCall(1394);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)function2);
            HalconAPI.StoreS(proc, 2, mode);
            HalconAPI.StoreD(proc, 3, sigma);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)function2));
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Smooth an equidistant 1D function with a Gaussian function.
        ///   Instance represents: Function to be smoothed.
        /// </summary>
        /// <param name="sigma">Sigma of the Gaussian function for the smoothing. Default: 2.0</param>
        /// <returns>Smoothed function.</returns>
        public HFunction1D SmoothFunct1dGauss(double sigma)
        {
            IntPtr proc = HalconAPI.PreCall(1395);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, sigma);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HFunction1D hfunction1D;
            int procResult = HFunction1D.LoadNew(proc, 0, err, out hfunction1D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hfunction1D;
        }

        /// <summary>
        ///   Compute the positive and negative areas of a function.
        ///   Instance represents: Input function.
        /// </summary>
        /// <param name="negative">Area under the negative part of the function.</param>
        /// <returns>Area under the positive part of the function.</returns>
        public double IntegrateFunct1d(out HTuple negative)
        {
            IntPtr proc = HalconAPI.PreCall(1396);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out negative);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Read a function from a file.
        ///   Modified instance represents: Function from the file.
        /// </summary>
        /// <param name="fileName">Name of the file to be read.</param>
        public void ReadFunct1d(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1397);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write a function to a file.
        ///   Instance represents: Function to be written.
        /// </summary>
        /// <param name="fileName">Name of the file to be written.</param>
        public void WriteFunct1d(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1398);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a function from a sequence of y-values.
        ///   Modified instance represents: Created function.
        /// </summary>
        /// <param name="YValues">X value for function points.</param>
        public void CreateFunct1dArray(HTuple YValues)
        {
            IntPtr proc = HalconAPI.PreCall(1399);
            HalconAPI.Store(proc, 0, YValues);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(YValues);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a function from a sequence of y-values.
        ///   Modified instance represents: Created function.
        /// </summary>
        /// <param name="YValues">X value for function points.</param>
        public void CreateFunct1dArray(double YValues)
        {
            IntPtr proc = HalconAPI.PreCall(1399);
            HalconAPI.StoreD(proc, 0, YValues);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a function from a set of (x,y) pairs.
        ///   Modified instance represents: Created function.
        /// </summary>
        /// <param name="XValues">X value for function points.</param>
        /// <param name="YValues">Y-value for function points.</param>
        public void CreateFunct1dPairs(HTuple XValues, HTuple YValues)
        {
            IntPtr proc = HalconAPI.PreCall(1400);
            HalconAPI.Store(proc, 0, XValues);
            HalconAPI.Store(proc, 1, YValues);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(XValues);
            HalconAPI.UnpinTuple(YValues);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a function from a set of (x,y) pairs.
        ///   Modified instance represents: Created function.
        /// </summary>
        /// <param name="XValues">X value for function points.</param>
        /// <param name="YValues">Y-value for function points.</param>
        public void CreateFunct1dPairs(double XValues, double YValues)
        {
            IntPtr proc = HalconAPI.PreCall(1400);
            HalconAPI.StoreD(proc, 0, XValues);
            HalconAPI.StoreD(proc, 1, YValues);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Smooth an equidistant 1D function by averaging its values.
        ///   Instance represents: 1D function.
        /// </summary>
        /// <param name="smoothSize">Size of the averaging mask. Default: 9</param>
        /// <param name="iterations">Number of iterations for the smoothing. Default: 3</param>
        /// <returns>Smoothed function.</returns>
        public HFunction1D SmoothFunct1dMean(int smoothSize, int iterations)
        {
            IntPtr proc = HalconAPI.PreCall(1401);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, smoothSize);
            HalconAPI.StoreI(proc, 2, iterations);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HFunction1D hfunction1D;
            int procResult = HFunction1D.LoadNew(proc, 0, err, out hfunction1D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hfunction1D;
        }
    }
}
