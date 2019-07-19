// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HMeasure
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a tool to measure distances.</summary>
    [Serializable]
    public class HMeasure : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HMeasure()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HMeasure(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HMeasure obj)
        {
            obj = new HMeasure(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HMeasure[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HMeasure[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HMeasure(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Prepare the extraction of straight edges perpendicular to an annular arc.
        ///   Modified instance represents: Measure object handle.
        /// </summary>
        /// <param name="centerRow">Row coordinate of the center of the arc. Default: 100.0</param>
        /// <param name="centerCol">Column coordinate of the center of the arc. Default: 100.0</param>
        /// <param name="radius">Radius of the arc. Default: 50.0</param>
        /// <param name="angleStart">Start angle of the arc in radians. Default: 0.0</param>
        /// <param name="angleExtent">Angular extent of the arc in radians. Default: 6.28318</param>
        /// <param name="annulusRadius">Radius (half width) of the annulus. Default: 10.0</param>
        /// <param name="width">Width of the image to be processed subsequently. Default: 512</param>
        /// <param name="height">Height of the image to be processed subsequently. Default: 512</param>
        /// <param name="interpolation">Type of interpolation to be used. Default: "nearest_neighbor"</param>
        public HMeasure(
          HTuple centerRow,
          HTuple centerCol,
          HTuple radius,
          HTuple angleStart,
          HTuple angleExtent,
          HTuple annulusRadius,
          int width,
          int height,
          string interpolation)
        {
            IntPtr proc = HalconAPI.PreCall(838);
            HalconAPI.Store(proc, 0, centerRow);
            HalconAPI.Store(proc, 1, centerCol);
            HalconAPI.Store(proc, 2, radius);
            HalconAPI.Store(proc, 3, angleStart);
            HalconAPI.Store(proc, 4, angleExtent);
            HalconAPI.Store(proc, 5, annulusRadius);
            HalconAPI.StoreI(proc, 6, width);
            HalconAPI.StoreI(proc, 7, height);
            HalconAPI.StoreS(proc, 8, interpolation);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(centerRow);
            HalconAPI.UnpinTuple(centerCol);
            HalconAPI.UnpinTuple(radius);
            HalconAPI.UnpinTuple(angleStart);
            HalconAPI.UnpinTuple(angleExtent);
            HalconAPI.UnpinTuple(annulusRadius);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Prepare the extraction of straight edges perpendicular to an annular arc.
        ///   Modified instance represents: Measure object handle.
        /// </summary>
        /// <param name="centerRow">Row coordinate of the center of the arc. Default: 100.0</param>
        /// <param name="centerCol">Column coordinate of the center of the arc. Default: 100.0</param>
        /// <param name="radius">Radius of the arc. Default: 50.0</param>
        /// <param name="angleStart">Start angle of the arc in radians. Default: 0.0</param>
        /// <param name="angleExtent">Angular extent of the arc in radians. Default: 6.28318</param>
        /// <param name="annulusRadius">Radius (half width) of the annulus. Default: 10.0</param>
        /// <param name="width">Width of the image to be processed subsequently. Default: 512</param>
        /// <param name="height">Height of the image to be processed subsequently. Default: 512</param>
        /// <param name="interpolation">Type of interpolation to be used. Default: "nearest_neighbor"</param>
        public HMeasure(
          double centerRow,
          double centerCol,
          double radius,
          double angleStart,
          double angleExtent,
          double annulusRadius,
          int width,
          int height,
          string interpolation)
        {
            IntPtr proc = HalconAPI.PreCall(838);
            HalconAPI.StoreD(proc, 0, centerRow);
            HalconAPI.StoreD(proc, 1, centerCol);
            HalconAPI.StoreD(proc, 2, radius);
            HalconAPI.StoreD(proc, 3, angleStart);
            HalconAPI.StoreD(proc, 4, angleExtent);
            HalconAPI.StoreD(proc, 5, annulusRadius);
            HalconAPI.StoreI(proc, 6, width);
            HalconAPI.StoreI(proc, 7, height);
            HalconAPI.StoreS(proc, 8, interpolation);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Prepare the extraction of straight edges perpendicular to a rectangle.
        ///   Modified instance represents: Measure object handle.
        /// </summary>
        /// <param name="row">Row coordinate of the center of the rectangle. Default: 300.0</param>
        /// <param name="column">Column coordinate of the center of the rectangle. Default: 200.0</param>
        /// <param name="phi">Angle of longitudinal axis of the rectangle to horizontal (radians). Default: 0.0</param>
        /// <param name="length1">Half width of the rectangle. Default: 100.0</param>
        /// <param name="length2">Half height of the rectangle. Default: 20.0</param>
        /// <param name="width">Width of the image to be processed subsequently. Default: 512</param>
        /// <param name="height">Height of the image to be processed subsequently. Default: 512</param>
        /// <param name="interpolation">Type of interpolation to be used. Default: "nearest_neighbor"</param>
        public HMeasure(
          HTuple row,
          HTuple column,
          HTuple phi,
          HTuple length1,
          HTuple length2,
          int width,
          int height,
          string interpolation)
        {
            IntPtr proc = HalconAPI.PreCall(839);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, column);
            HalconAPI.Store(proc, 2, phi);
            HalconAPI.Store(proc, 3, length1);
            HalconAPI.Store(proc, 4, length2);
            HalconAPI.StoreI(proc, 5, width);
            HalconAPI.StoreI(proc, 6, height);
            HalconAPI.StoreS(proc, 7, interpolation);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.UnpinTuple(phi);
            HalconAPI.UnpinTuple(length1);
            HalconAPI.UnpinTuple(length2);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Prepare the extraction of straight edges perpendicular to a rectangle.
        ///   Modified instance represents: Measure object handle.
        /// </summary>
        /// <param name="row">Row coordinate of the center of the rectangle. Default: 300.0</param>
        /// <param name="column">Column coordinate of the center of the rectangle. Default: 200.0</param>
        /// <param name="phi">Angle of longitudinal axis of the rectangle to horizontal (radians). Default: 0.0</param>
        /// <param name="length1">Half width of the rectangle. Default: 100.0</param>
        /// <param name="length2">Half height of the rectangle. Default: 20.0</param>
        /// <param name="width">Width of the image to be processed subsequently. Default: 512</param>
        /// <param name="height">Height of the image to be processed subsequently. Default: 512</param>
        /// <param name="interpolation">Type of interpolation to be used. Default: "nearest_neighbor"</param>
        public HMeasure(
          double row,
          double column,
          double phi,
          double length1,
          double length2,
          int width,
          int height,
          string interpolation)
        {
            IntPtr proc = HalconAPI.PreCall(839);
            HalconAPI.StoreD(proc, 0, row);
            HalconAPI.StoreD(proc, 1, column);
            HalconAPI.StoreD(proc, 2, phi);
            HalconAPI.StoreD(proc, 3, length1);
            HalconAPI.StoreD(proc, 4, length2);
            HalconAPI.StoreI(proc, 5, width);
            HalconAPI.StoreI(proc, 6, height);
            HalconAPI.StoreS(proc, 7, interpolation);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeMeasure();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HMeasure(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeMeasure(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeMeasure().Serialize(stream);
        }

        public static HMeasure Deserialize(Stream stream)
        {
            HMeasure hmeasure = new HMeasure();
            hmeasure.DeserializeMeasure(HSerializedItem.Deserialize(stream));
            return hmeasure;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HMeasure Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeMeasure();
            HMeasure hmeasure = new HMeasure();
            hmeasure.DeserializeMeasure(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hmeasure;
        }

        /// <summary>
        ///   Serialize a measure object.
        ///   Instance represents: Measure object handle.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeMeasure()
        {
            IntPtr proc = HalconAPI.PreCall(821);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HSerializedItem hserializedItem;
            int procResult = HSerializedItem.LoadNew(proc, 0, err, out hserializedItem);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hserializedItem;
        }

        /// <summary>
        ///   Deserialize a serialized measure object.
        ///   Modified instance represents: Measure object handle.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeMeasure(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(822);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Write a measure object to a file.
        ///   Instance represents: Measure object handle.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void WriteMeasure(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(823);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Read a measure object from a file.
        ///   Modified instance represents: Measure object handle.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void ReadMeasure(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(824);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Extracting points with a particular gray value along a rectangle or an annular arc.
        ///   Instance represents: Measure object handle.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="sigma">Sigma of gaussian smoothing. Default: 1.0</param>
        /// <param name="threshold">Threshold. Default: 128.0</param>
        /// <param name="select">Selection of points. Default: "all"</param>
        /// <param name="rowThresh">Row coordinates of points with threshold value.</param>
        /// <param name="columnThresh">Column coordinates of points with threshold value.</param>
        /// <param name="distance">Distance between consecutive points.</param>
        public void MeasureThresh(
          HImage image,
          double sigma,
          double threshold,
          string select,
          out HTuple rowThresh,
          out HTuple columnThresh,
          out HTuple distance)
        {
            IntPtr proc = HalconAPI.PreCall(825);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 1, sigma);
            HalconAPI.StoreD(proc, 2, threshold);
            HalconAPI.StoreS(proc, 3, select);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out rowThresh);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out columnThresh);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out distance);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Extract a gray value profile perpendicular to a rectangle or annular arc.
        ///   Instance represents: Measure object handle.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <returns>Gray value profile.</returns>
        public HTuple MeasureProjection(HImage image)
        {
            IntPtr proc = HalconAPI.PreCall(828);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
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
        ///   Reset a fuzzy function.
        ///   Instance represents: Measure object handle.
        /// </summary>
        /// <param name="setType">Selection of the fuzzy set. Default: "contrast"</param>
        public void ResetFuzzyMeasure(string setType)
        {
            IntPtr proc = HalconAPI.PreCall(829);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, setType);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Specify a normalized fuzzy function for edge pairs.
        ///   Instance represents: Measure object handle.
        /// </summary>
        /// <param name="pairSize">Favored width of edge pairs. Default: 10.0</param>
        /// <param name="setType">Selection of the fuzzy set. Default: "size_abs_diff"</param>
        /// <param name="function">Fuzzy function.</param>
        public void SetFuzzyMeasureNormPair(HTuple pairSize, string setType, HFunction1D function)
        {
            IntPtr proc = HalconAPI.PreCall(830);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, pairSize);
            HalconAPI.StoreS(proc, 2, setType);
            HalconAPI.Store(proc, 3, (HData)function);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(pairSize);
            HalconAPI.UnpinTuple((HTuple)((HData)function));
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Specify a normalized fuzzy function for edge pairs.
        ///   Instance represents: Measure object handle.
        /// </summary>
        /// <param name="pairSize">Favored width of edge pairs. Default: 10.0</param>
        /// <param name="setType">Selection of the fuzzy set. Default: "size_abs_diff"</param>
        /// <param name="function">Fuzzy function.</param>
        public void SetFuzzyMeasureNormPair(double pairSize, string setType, HFunction1D function)
        {
            IntPtr proc = HalconAPI.PreCall(830);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, pairSize);
            HalconAPI.StoreS(proc, 2, setType);
            HalconAPI.Store(proc, 3, (HData)function);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)function));
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Specify a fuzzy function.
        ///   Instance represents: Measure object handle.
        /// </summary>
        /// <param name="setType">Selection of the fuzzy set. Default: "contrast"</param>
        /// <param name="function">Fuzzy function.</param>
        public void SetFuzzyMeasure(string setType, HFunction1D function)
        {
            IntPtr proc = HalconAPI.PreCall(831);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, setType);
            HalconAPI.Store(proc, 2, (HData)function);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)function));
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Extract straight edge pairs perpendicular to a rectangle or an annular arc.
        ///   Instance represents: Measure object handle.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="sigma">Sigma of Gaussian smoothing. Default: 1.0</param>
        /// <param name="ampThresh">Minimum edge amplitude. Default: 30.0</param>
        /// <param name="fuzzyThresh">Minimum fuzzy value. Default: 0.5</param>
        /// <param name="transition">Select the first gray value transition of the edge pairs. Default: "all"</param>
        /// <param name="pairing">Constraint of pairing. Default: "no_restriction"</param>
        /// <param name="numPairs">Number of edge pairs. Default: 10</param>
        /// <param name="rowEdgeFirst">Row coordinate of the first edge.</param>
        /// <param name="columnEdgeFirst">Column coordinate of the first edge.</param>
        /// <param name="amplitudeFirst">Edge amplitude of the first edge (with sign).</param>
        /// <param name="rowEdgeSecond">Row coordinate of the second edge.</param>
        /// <param name="columnEdgeSecond">Column coordinate of the second edge.</param>
        /// <param name="amplitudeSecond">Edge amplitude of the second edge (with sign).</param>
        /// <param name="rowPairCenter">Row coordinate of the center of the edge pair.</param>
        /// <param name="columnPairCenter">Column coordinate of the center of the edge pair.</param>
        /// <param name="fuzzyScore">Fuzzy evaluation of the edge pair.</param>
        /// <param name="intraDistance">Distance between the edges of the edge pair.</param>
        public void FuzzyMeasurePairing(
          HImage image,
          double sigma,
          double ampThresh,
          double fuzzyThresh,
          string transition,
          string pairing,
          int numPairs,
          out HTuple rowEdgeFirst,
          out HTuple columnEdgeFirst,
          out HTuple amplitudeFirst,
          out HTuple rowEdgeSecond,
          out HTuple columnEdgeSecond,
          out HTuple amplitudeSecond,
          out HTuple rowPairCenter,
          out HTuple columnPairCenter,
          out HTuple fuzzyScore,
          out HTuple intraDistance)
        {
            IntPtr proc = HalconAPI.PreCall(832);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 1, sigma);
            HalconAPI.StoreD(proc, 2, ampThresh);
            HalconAPI.StoreD(proc, 3, fuzzyThresh);
            HalconAPI.StoreS(proc, 4, transition);
            HalconAPI.StoreS(proc, 5, pairing);
            HalconAPI.StoreI(proc, 6, numPairs);
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
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out rowEdgeFirst);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out columnEdgeFirst);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out amplitudeFirst);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out rowEdgeSecond);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out columnEdgeSecond);
            int err7 = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, err6, out amplitudeSecond);
            int err8 = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, err7, out rowPairCenter);
            int err9 = HTuple.LoadNew(proc, 7, HTupleType.DOUBLE, err8, out columnPairCenter);
            int err10 = HTuple.LoadNew(proc, 8, HTupleType.DOUBLE, err9, out fuzzyScore);
            int procResult = HTuple.LoadNew(proc, 9, HTupleType.DOUBLE, err10, out intraDistance);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Extract straight edge pairs perpendicular to a rectangle or an annular arc.
        ///   Instance represents: Measure object handle.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="sigma">Sigma of Gaussian smoothing. Default: 1.0</param>
        /// <param name="ampThresh">Minimum edge amplitude. Default: 30.0</param>
        /// <param name="fuzzyThresh">Minimum fuzzy value. Default: 0.5</param>
        /// <param name="transition">Select the first gray value transition of the edge pairs. Default: "all"</param>
        /// <param name="rowEdgeFirst">Row coordinate of the first edge point.</param>
        /// <param name="columnEdgeFirst">Column coordinate of the first edge point.</param>
        /// <param name="amplitudeFirst">Edge amplitude of the first edge (with sign).</param>
        /// <param name="rowEdgeSecond">Row coordinate of the second edge point.</param>
        /// <param name="columnEdgeSecond">Column coordinate of the second edge point.</param>
        /// <param name="amplitudeSecond">Edge amplitude of the second edge (with sign).</param>
        /// <param name="rowEdgeCenter">Row coordinate of the center of the edge pair.</param>
        /// <param name="columnEdgeCenter">Column coordinate of the center of the edge pair.</param>
        /// <param name="fuzzyScore">Fuzzy evaluation of the edge pair.</param>
        /// <param name="intraDistance">Distance between edges of an edge pair.</param>
        /// <param name="interDistance">Distance between consecutive edge pairs.</param>
        public void FuzzyMeasurePairs(
          HImage image,
          double sigma,
          double ampThresh,
          double fuzzyThresh,
          string transition,
          out HTuple rowEdgeFirst,
          out HTuple columnEdgeFirst,
          out HTuple amplitudeFirst,
          out HTuple rowEdgeSecond,
          out HTuple columnEdgeSecond,
          out HTuple amplitudeSecond,
          out HTuple rowEdgeCenter,
          out HTuple columnEdgeCenter,
          out HTuple fuzzyScore,
          out HTuple intraDistance,
          out HTuple interDistance)
        {
            IntPtr proc = HalconAPI.PreCall(833);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 1, sigma);
            HalconAPI.StoreD(proc, 2, ampThresh);
            HalconAPI.StoreD(proc, 3, fuzzyThresh);
            HalconAPI.StoreS(proc, 4, transition);
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
            HalconAPI.InitOCT(proc, 10);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out rowEdgeFirst);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out columnEdgeFirst);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out amplitudeFirst);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out rowEdgeSecond);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out columnEdgeSecond);
            int err7 = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, err6, out amplitudeSecond);
            int err8 = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, err7, out rowEdgeCenter);
            int err9 = HTuple.LoadNew(proc, 7, HTupleType.DOUBLE, err8, out columnEdgeCenter);
            int err10 = HTuple.LoadNew(proc, 8, HTupleType.DOUBLE, err9, out fuzzyScore);
            int err11 = HTuple.LoadNew(proc, 9, HTupleType.DOUBLE, err10, out intraDistance);
            int procResult = HTuple.LoadNew(proc, 10, HTupleType.DOUBLE, err11, out interDistance);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Extract straight edges perpendicular to a rectangle or an annular arc.
        ///   Instance represents: Measure object handle.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="sigma">Sigma of Gaussian smoothing. Default: 1.0</param>
        /// <param name="ampThresh">Minimum edge amplitude. Default: 30.0</param>
        /// <param name="fuzzyThresh">Minimum fuzzy value. Default: 0.5</param>
        /// <param name="transition">Select light/dark or dark/light edges. Default: "all"</param>
        /// <param name="rowEdge">Row coordinate of the edge point.</param>
        /// <param name="columnEdge">Column coordinate of the edge point.</param>
        /// <param name="amplitude">Edge amplitude of the edge (with sign).</param>
        /// <param name="fuzzyScore">Fuzzy evaluation of the edges.</param>
        /// <param name="distance">Distance between consecutive edges.</param>
        public void FuzzyMeasurePos(
          HImage image,
          double sigma,
          double ampThresh,
          double fuzzyThresh,
          string transition,
          out HTuple rowEdge,
          out HTuple columnEdge,
          out HTuple amplitude,
          out HTuple fuzzyScore,
          out HTuple distance)
        {
            IntPtr proc = HalconAPI.PreCall(834);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 1, sigma);
            HalconAPI.StoreD(proc, 2, ampThresh);
            HalconAPI.StoreD(proc, 3, fuzzyThresh);
            HalconAPI.StoreS(proc, 4, transition);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out rowEdge);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out columnEdge);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out amplitude);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out fuzzyScore);
            int procResult = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out distance);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Extract straight edge pairs perpendicular to a rectangle or annular arc.
        ///   Instance represents: Measure object handle.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="sigma">Sigma of gaussian smoothing. Default: 1.0</param>
        /// <param name="threshold">Minimum edge amplitude. Default: 30.0</param>
        /// <param name="transition">Type of gray value transition that determines how edges are grouped to edge pairs. Default: "all"</param>
        /// <param name="select">Selection of edge pairs. Default: "all"</param>
        /// <param name="rowEdgeFirst">Row coordinate of the center of the first edge.</param>
        /// <param name="columnEdgeFirst">Column coordinate of the center of the first edge.</param>
        /// <param name="amplitudeFirst">Edge amplitude of the first edge (with sign).</param>
        /// <param name="rowEdgeSecond">Row coordinate of the center of the second edge.</param>
        /// <param name="columnEdgeSecond">Column coordinate of the center of the second edge.</param>
        /// <param name="amplitudeSecond">Edge amplitude of the second edge (with sign).</param>
        /// <param name="intraDistance">Distance between edges of an edge pair.</param>
        /// <param name="interDistance">Distance between consecutive edge pairs.</param>
        public void MeasurePairs(
          HImage image,
          double sigma,
          double threshold,
          string transition,
          string select,
          out HTuple rowEdgeFirst,
          out HTuple columnEdgeFirst,
          out HTuple amplitudeFirst,
          out HTuple rowEdgeSecond,
          out HTuple columnEdgeSecond,
          out HTuple amplitudeSecond,
          out HTuple intraDistance,
          out HTuple interDistance)
        {
            IntPtr proc = HalconAPI.PreCall(835);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 1, sigma);
            HalconAPI.StoreD(proc, 2, threshold);
            HalconAPI.StoreS(proc, 3, transition);
            HalconAPI.StoreS(proc, 4, select);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            HalconAPI.InitOCT(proc, 6);
            HalconAPI.InitOCT(proc, 7);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out rowEdgeFirst);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out columnEdgeFirst);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out amplitudeFirst);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out rowEdgeSecond);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out columnEdgeSecond);
            int err7 = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, err6, out amplitudeSecond);
            int err8 = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, err7, out intraDistance);
            int procResult = HTuple.LoadNew(proc, 7, HTupleType.DOUBLE, err8, out interDistance);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Extract straight edges perpendicular to a rectangle or annular arc.
        ///   Instance represents: Measure object handle.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="sigma">Sigma of gaussian smoothing. Default: 1.0</param>
        /// <param name="threshold">Minimum edge amplitude. Default: 30.0</param>
        /// <param name="transition">Light/dark or dark/light edge. Default: "all"</param>
        /// <param name="select">Selection of end points. Default: "all"</param>
        /// <param name="rowEdge">Row coordinate of the center of the edge.</param>
        /// <param name="columnEdge">Column coordinate of the center of the edge.</param>
        /// <param name="amplitude">Edge amplitude of the edge (with sign).</param>
        /// <param name="distance">Distance between consecutive edges.</param>
        public void MeasurePos(
          HImage image,
          double sigma,
          double threshold,
          string transition,
          string select,
          out HTuple rowEdge,
          out HTuple columnEdge,
          out HTuple amplitude,
          out HTuple distance)
        {
            IntPtr proc = HalconAPI.PreCall(836);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 1, sigma);
            HalconAPI.StoreD(proc, 2, threshold);
            HalconAPI.StoreS(proc, 3, transition);
            HalconAPI.StoreS(proc, 4, select);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out rowEdge);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out columnEdge);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out amplitude);
            int procResult = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out distance);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Translate a measure object.
        ///   Instance represents: Measure object handle.
        /// </summary>
        /// <param name="row">Row coordinate of the new reference point. Default: 50.0</param>
        /// <param name="column">Column coordinate of the new reference point. Default: 100.0</param>
        public void TranslateMeasure(HTuple row, HTuple column)
        {
            IntPtr proc = HalconAPI.PreCall(837);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, row);
            HalconAPI.Store(proc, 2, column);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Translate a measure object.
        ///   Instance represents: Measure object handle.
        /// </summary>
        /// <param name="row">Row coordinate of the new reference point. Default: 50.0</param>
        /// <param name="column">Column coordinate of the new reference point. Default: 100.0</param>
        public void TranslateMeasure(double row, double column)
        {
            IntPtr proc = HalconAPI.PreCall(837);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, row);
            HalconAPI.StoreD(proc, 2, column);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Prepare the extraction of straight edges perpendicular to an annular arc.
        ///   Modified instance represents: Measure object handle.
        /// </summary>
        /// <param name="centerRow">Row coordinate of the center of the arc. Default: 100.0</param>
        /// <param name="centerCol">Column coordinate of the center of the arc. Default: 100.0</param>
        /// <param name="radius">Radius of the arc. Default: 50.0</param>
        /// <param name="angleStart">Start angle of the arc in radians. Default: 0.0</param>
        /// <param name="angleExtent">Angular extent of the arc in radians. Default: 6.28318</param>
        /// <param name="annulusRadius">Radius (half width) of the annulus. Default: 10.0</param>
        /// <param name="width">Width of the image to be processed subsequently. Default: 512</param>
        /// <param name="height">Height of the image to be processed subsequently. Default: 512</param>
        /// <param name="interpolation">Type of interpolation to be used. Default: "nearest_neighbor"</param>
        public void GenMeasureArc(
          HTuple centerRow,
          HTuple centerCol,
          HTuple radius,
          HTuple angleStart,
          HTuple angleExtent,
          HTuple annulusRadius,
          int width,
          int height,
          string interpolation)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(838);
            HalconAPI.Store(proc, 0, centerRow);
            HalconAPI.Store(proc, 1, centerCol);
            HalconAPI.Store(proc, 2, radius);
            HalconAPI.Store(proc, 3, angleStart);
            HalconAPI.Store(proc, 4, angleExtent);
            HalconAPI.Store(proc, 5, annulusRadius);
            HalconAPI.StoreI(proc, 6, width);
            HalconAPI.StoreI(proc, 7, height);
            HalconAPI.StoreS(proc, 8, interpolation);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(centerRow);
            HalconAPI.UnpinTuple(centerCol);
            HalconAPI.UnpinTuple(radius);
            HalconAPI.UnpinTuple(angleStart);
            HalconAPI.UnpinTuple(angleExtent);
            HalconAPI.UnpinTuple(annulusRadius);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Prepare the extraction of straight edges perpendicular to an annular arc.
        ///   Modified instance represents: Measure object handle.
        /// </summary>
        /// <param name="centerRow">Row coordinate of the center of the arc. Default: 100.0</param>
        /// <param name="centerCol">Column coordinate of the center of the arc. Default: 100.0</param>
        /// <param name="radius">Radius of the arc. Default: 50.0</param>
        /// <param name="angleStart">Start angle of the arc in radians. Default: 0.0</param>
        /// <param name="angleExtent">Angular extent of the arc in radians. Default: 6.28318</param>
        /// <param name="annulusRadius">Radius (half width) of the annulus. Default: 10.0</param>
        /// <param name="width">Width of the image to be processed subsequently. Default: 512</param>
        /// <param name="height">Height of the image to be processed subsequently. Default: 512</param>
        /// <param name="interpolation">Type of interpolation to be used. Default: "nearest_neighbor"</param>
        public void GenMeasureArc(
          double centerRow,
          double centerCol,
          double radius,
          double angleStart,
          double angleExtent,
          double annulusRadius,
          int width,
          int height,
          string interpolation)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(838);
            HalconAPI.StoreD(proc, 0, centerRow);
            HalconAPI.StoreD(proc, 1, centerCol);
            HalconAPI.StoreD(proc, 2, radius);
            HalconAPI.StoreD(proc, 3, angleStart);
            HalconAPI.StoreD(proc, 4, angleExtent);
            HalconAPI.StoreD(proc, 5, annulusRadius);
            HalconAPI.StoreI(proc, 6, width);
            HalconAPI.StoreI(proc, 7, height);
            HalconAPI.StoreS(proc, 8, interpolation);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Prepare the extraction of straight edges perpendicular to a rectangle.
        ///   Modified instance represents: Measure object handle.
        /// </summary>
        /// <param name="row">Row coordinate of the center of the rectangle. Default: 300.0</param>
        /// <param name="column">Column coordinate of the center of the rectangle. Default: 200.0</param>
        /// <param name="phi">Angle of longitudinal axis of the rectangle to horizontal (radians). Default: 0.0</param>
        /// <param name="length1">Half width of the rectangle. Default: 100.0</param>
        /// <param name="length2">Half height of the rectangle. Default: 20.0</param>
        /// <param name="width">Width of the image to be processed subsequently. Default: 512</param>
        /// <param name="height">Height of the image to be processed subsequently. Default: 512</param>
        /// <param name="interpolation">Type of interpolation to be used. Default: "nearest_neighbor"</param>
        public void GenMeasureRectangle2(
          HTuple row,
          HTuple column,
          HTuple phi,
          HTuple length1,
          HTuple length2,
          int width,
          int height,
          string interpolation)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(839);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, column);
            HalconAPI.Store(proc, 2, phi);
            HalconAPI.Store(proc, 3, length1);
            HalconAPI.Store(proc, 4, length2);
            HalconAPI.StoreI(proc, 5, width);
            HalconAPI.StoreI(proc, 6, height);
            HalconAPI.StoreS(proc, 7, interpolation);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.UnpinTuple(phi);
            HalconAPI.UnpinTuple(length1);
            HalconAPI.UnpinTuple(length2);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Prepare the extraction of straight edges perpendicular to a rectangle.
        ///   Modified instance represents: Measure object handle.
        /// </summary>
        /// <param name="row">Row coordinate of the center of the rectangle. Default: 300.0</param>
        /// <param name="column">Column coordinate of the center of the rectangle. Default: 200.0</param>
        /// <param name="phi">Angle of longitudinal axis of the rectangle to horizontal (radians). Default: 0.0</param>
        /// <param name="length1">Half width of the rectangle. Default: 100.0</param>
        /// <param name="length2">Half height of the rectangle. Default: 20.0</param>
        /// <param name="width">Width of the image to be processed subsequently. Default: 512</param>
        /// <param name="height">Height of the image to be processed subsequently. Default: 512</param>
        /// <param name="interpolation">Type of interpolation to be used. Default: "nearest_neighbor"</param>
        public void GenMeasureRectangle2(
          double row,
          double column,
          double phi,
          double length1,
          double length2,
          int width,
          int height,
          string interpolation)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(839);
            HalconAPI.StoreD(proc, 0, row);
            HalconAPI.StoreD(proc, 1, column);
            HalconAPI.StoreD(proc, 2, phi);
            HalconAPI.StoreD(proc, 3, length1);
            HalconAPI.StoreD(proc, 4, length2);
            HalconAPI.StoreI(proc, 5, width);
            HalconAPI.StoreI(proc, 6, height);
            HalconAPI.StoreS(proc, 7, interpolation);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(827);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
