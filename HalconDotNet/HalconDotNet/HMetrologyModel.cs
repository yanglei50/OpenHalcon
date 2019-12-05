// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HMetrologyModel
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a metrology model.</summary>
    [Serializable]
    public class HMetrologyModel : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HMetrologyModel(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HMetrologyModel obj)
        {
            obj = new HMetrologyModel(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HMetrologyModel[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HMetrologyModel[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HMetrologyModel(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Read a metrology model from a file.
        ///   Modified instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public HMetrologyModel(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(798);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create the data structure that is needed to measure geometric shapes.
        ///   Modified instance represents: Handle of the metrology model.
        /// </summary>
        public HMetrologyModel()
        {
            IntPtr proc = HalconAPI.PreCall(820);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeMetrologyModel();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HMetrologyModel(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeMetrologyModel(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeMetrologyModel().Serialize(stream);
        }

        public static HMetrologyModel Deserialize(Stream stream)
        {
            HMetrologyModel hmetrologyModel = new HMetrologyModel();
            hmetrologyModel.DeserializeMetrologyModel(HSerializedItem.Deserialize(stream));
            return hmetrologyModel;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HMetrologyModel Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeMetrologyModel();
            HMetrologyModel hmetrologyModel = new HMetrologyModel();
            hmetrologyModel.DeserializeMetrologyModel(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hmetrologyModel;
        }

        /// <summary>
        ///   Query the model contour of a metrology object in image coordinates.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="index">Index of the metrology object. Default: "all"</param>
        /// <param name="resolution">Distance between neighboring contour points. Default: 1.5</param>
        /// <returns>Model contour.</returns>
        public HXLDCont GetMetrologyObjectModelContour(HTuple index, double resolution)
        {
            IntPtr proc = HalconAPI.PreCall(788);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, index);
            HalconAPI.StoreD(proc, 2, resolution);
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
        ///   Query the model contour of a metrology object in image coordinates.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="index">Index of the metrology object. Default: "all"</param>
        /// <param name="resolution">Distance between neighboring contour points. Default: 1.5</param>
        /// <returns>Model contour.</returns>
        public HXLDCont GetMetrologyObjectModelContour(int index, double resolution)
        {
            IntPtr proc = HalconAPI.PreCall(788);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, index);
            HalconAPI.StoreD(proc, 2, resolution);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Query the result contour of a metrology object.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="index">Index of the metrology object. Default: "all"</param>
        /// <param name="instance">Instance of the metrology object. Default: "all"</param>
        /// <param name="resolution">Distance between neighboring contour points. Default: 1.5</param>
        /// <returns>Result contour for the given metrology object.</returns>
        public HXLDCont GetMetrologyObjectResultContour(
          HTuple index,
          HTuple instance,
          double resolution)
        {
            IntPtr proc = HalconAPI.PreCall(789);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, index);
            HalconAPI.Store(proc, 2, instance);
            HalconAPI.StoreD(proc, 3, resolution);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HalconAPI.UnpinTuple(instance);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Query the result contour of a metrology object.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="index">Index of the metrology object. Default: "all"</param>
        /// <param name="instance">Instance of the metrology object. Default: "all"</param>
        /// <param name="resolution">Distance between neighboring contour points. Default: 1.5</param>
        /// <returns>Result contour for the given metrology object.</returns>
        public HXLDCont GetMetrologyObjectResultContour(
          int index,
          int instance,
          double resolution)
        {
            IntPtr proc = HalconAPI.PreCall(789);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, index);
            HalconAPI.StoreI(proc, 2, instance);
            HalconAPI.StoreD(proc, 3, resolution);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Alignment of a metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="row">Row coordinate of the alignment. Default: 0</param>
        /// <param name="column">Column coordinate of the alignment. Default: 0</param>
        /// <param name="angle">Rotation angle of the alignment. Default: 0</param>
        public void AlignMetrologyModel(HTuple row, HTuple column, HTuple angle)
        {
            IntPtr proc = HalconAPI.PreCall(790);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, row);
            HalconAPI.Store(proc, 2, column);
            HalconAPI.Store(proc, 3, angle);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.UnpinTuple(angle);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Alignment of a metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="row">Row coordinate of the alignment. Default: 0</param>
        /// <param name="column">Column coordinate of the alignment. Default: 0</param>
        /// <param name="angle">Rotation angle of the alignment. Default: 0</param>
        public void AlignMetrologyModel(double row, double column, double angle)
        {
            IntPtr proc = HalconAPI.PreCall(790);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, row);
            HalconAPI.StoreD(proc, 2, column);
            HalconAPI.StoreD(proc, 3, angle);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Add a metrology object to a metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="shape">Type of the metrology object to be added. Default: "circle"</param>
        /// <param name="shapeParam">Parameters of the metrology object to be added.</param>
        /// <param name="measureLength1">Half length of the measure regions perpendicular to the boundary. Default: 20.0</param>
        /// <param name="measureLength2">Half length of the measure regions tangetial to the boundary. Default: 5.0</param>
        /// <param name="measureSigma">Sigma of the Gaussian function for the smoothing. Default: 1.0</param>
        /// <param name="measureThreshold">Minimum edge amplitude. Default: 30.0</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <returns>Index of the created metrology object.</returns>
        public int AddMetrologyObjectGeneric(
          HTuple shape,
          HTuple shapeParam,
          HTuple measureLength1,
          HTuple measureLength2,
          HTuple measureSigma,
          HTuple measureThreshold,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(791);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, shape);
            HalconAPI.Store(proc, 2, shapeParam);
            HalconAPI.Store(proc, 3, measureLength1);
            HalconAPI.Store(proc, 4, measureLength2);
            HalconAPI.Store(proc, 5, measureSigma);
            HalconAPI.Store(proc, 6, measureThreshold);
            HalconAPI.Store(proc, 7, genParamName);
            HalconAPI.Store(proc, 8, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(shape);
            HalconAPI.UnpinTuple(shapeParam);
            HalconAPI.UnpinTuple(measureLength1);
            HalconAPI.UnpinTuple(measureLength2);
            HalconAPI.UnpinTuple(measureSigma);
            HalconAPI.UnpinTuple(measureThreshold);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Add a metrology object to a metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="shape">Type of the metrology object to be added. Default: "circle"</param>
        /// <param name="shapeParam">Parameters of the metrology object to be added.</param>
        /// <param name="measureLength1">Half length of the measure regions perpendicular to the boundary. Default: 20.0</param>
        /// <param name="measureLength2">Half length of the measure regions tangetial to the boundary. Default: 5.0</param>
        /// <param name="measureSigma">Sigma of the Gaussian function for the smoothing. Default: 1.0</param>
        /// <param name="measureThreshold">Minimum edge amplitude. Default: 30.0</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <returns>Index of the created metrology object.</returns>
        public int AddMetrologyObjectGeneric(
          string shape,
          HTuple shapeParam,
          double measureLength1,
          double measureLength2,
          double measureSigma,
          double measureThreshold,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(791);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, shape);
            HalconAPI.Store(proc, 2, shapeParam);
            HalconAPI.StoreD(proc, 3, measureLength1);
            HalconAPI.StoreD(proc, 4, measureLength2);
            HalconAPI.StoreD(proc, 5, measureSigma);
            HalconAPI.StoreD(proc, 6, measureThreshold);
            HalconAPI.Store(proc, 7, genParamName);
            HalconAPI.Store(proc, 8, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(shapeParam);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Get parameters that are valid for the entire metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="genParamName">Name of the generic parameter. Default: "camera_param"</param>
        /// <returns>Value of the generic parameter.</returns>
        public HTuple GetMetrologyModelParam(string genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(792);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Set parameters that are valid for the entire metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="genParamName">Name of the generic parameter. Default: "camera_param"</param>
        /// <param name="genParamValue">Value of the generic parameter. Default: []</param>
        public void SetMetrologyModelParam(string genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(793);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set parameters that are valid for the entire metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="genParamName">Name of the generic parameter. Default: "camera_param"</param>
        /// <param name="genParamValue">Value of the generic parameter. Default: []</param>
        public void SetMetrologyModelParam(string genParamName, string genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(793);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.StoreS(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Deserialize a serialized metrology model.
        ///   Modified instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeMetrologyModel(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(794);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize a metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeMetrologyModel()
        {
            IntPtr proc = HalconAPI.PreCall(795);
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
        ///   Transform metrology objects of a metrology model, e.g. for alignment.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="index">Index of the metrology objects. Default: "all"</param>
        /// <param name="row">Translation in row direction.</param>
        /// <param name="column">Translation in column direction.</param>
        /// <param name="phi">Rotation angle.</param>
        /// <param name="mode">Mode of the transformation. Default: "absolute"</param>
        public void TransformMetrologyObject(
          HTuple index,
          HTuple row,
          HTuple column,
          HTuple phi,
          HTuple mode)
        {
            IntPtr proc = HalconAPI.PreCall(796);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, index);
            HalconAPI.Store(proc, 2, row);
            HalconAPI.Store(proc, 3, column);
            HalconAPI.Store(proc, 4, phi);
            HalconAPI.Store(proc, 5, mode);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.UnpinTuple(phi);
            HalconAPI.UnpinTuple(mode);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Transform metrology objects of a metrology model, e.g. for alignment.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="index">Index of the metrology objects. Default: "all"</param>
        /// <param name="row">Translation in row direction.</param>
        /// <param name="column">Translation in column direction.</param>
        /// <param name="phi">Rotation angle.</param>
        /// <param name="mode">Mode of the transformation. Default: "absolute"</param>
        public void TransformMetrologyObject(
          string index,
          double row,
          double column,
          double phi,
          string mode)
        {
            IntPtr proc = HalconAPI.PreCall(796);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, index);
            HalconAPI.StoreD(proc, 2, row);
            HalconAPI.StoreD(proc, 3, column);
            HalconAPI.StoreD(proc, 4, phi);
            HalconAPI.StoreS(proc, 5, mode);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write a metrology model to a file.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void WriteMetrologyModel(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(797);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Read a metrology model from a file.
        ///   Modified instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void ReadMetrologyModel(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(798);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Copy a metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="index">Index of the metrology objects. Default: "all"</param>
        /// <returns>Handle of the copied metrology model.</returns>
        public int CopyMetrologyModel(HTuple index)
        {
            IntPtr proc = HalconAPI.PreCall(799);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, index);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Copy a metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="index">Index of the metrology objects. Default: "all"</param>
        /// <returns>Handle of the copied metrology model.</returns>
        public int CopyMetrologyModel(string index)
        {
            IntPtr proc = HalconAPI.PreCall(799);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, index);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Copy metrology metrology objects of a metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="index">Index of the metrology objects. Default: "all"</param>
        /// <returns>Indices of the copied metrology objects.</returns>
        public HTuple CopyMetrologyObject(HTuple index)
        {
            IntPtr proc = HalconAPI.PreCall(800);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, index);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Copy metrology metrology objects of a metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="index">Index of the metrology objects. Default: "all"</param>
        /// <returns>Indices of the copied metrology objects.</returns>
        public int CopyMetrologyObject(string index)
        {
            IntPtr proc = HalconAPI.PreCall(800);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, index);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Get the number of instances of the metrology objects of a metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="index">Index of the metrology objects. Default: 0</param>
        /// <returns>Number of Instances of the metrology objects.</returns>
        public HTuple GetMetrologyObjectNumInstances(HTuple index)
        {
            IntPtr proc = HalconAPI.PreCall(801);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, index);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Get the number of instances of the metrology objects of a metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="index">Index of the metrology objects. Default: 0</param>
        /// <returns>Number of Instances of the metrology objects.</returns>
        public double GetMetrologyObjectNumInstances(int index)
        {
            IntPtr proc = HalconAPI.PreCall(801);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, index);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Get the results of the measurement of a metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="index">Index of the metrology object. Default: "all"</param>
        /// <param name="instance">Instance of the metrology object. Default: "all"</param>
        /// <param name="genParamName">Name of the generic parameter. Default: "result_type"</param>
        /// <param name="genParamValue">Value of the generic parameter. Default: "all_param"</param>
        /// <returns>Result values.</returns>
        public HTuple GetMetrologyObjectResult(
          HTuple index,
          HTuple instance,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(802);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, index);
            HalconAPI.Store(proc, 2, instance);
            HalconAPI.Store(proc, 3, genParamName);
            HalconAPI.Store(proc, 4, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HalconAPI.UnpinTuple(instance);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Get the results of the measurement of a metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="index">Index of the metrology object. Default: "all"</param>
        /// <param name="instance">Instance of the metrology object. Default: "all"</param>
        /// <param name="genParamName">Name of the generic parameter. Default: "result_type"</param>
        /// <param name="genParamValue">Value of the generic parameter. Default: "all_param"</param>
        /// <returns>Result values.</returns>
        public HTuple GetMetrologyObjectResult(
          int index,
          int instance,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(802);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, index);
            HalconAPI.StoreI(proc, 2, instance);
            HalconAPI.Store(proc, 3, genParamName);
            HalconAPI.Store(proc, 4, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Get the measure regions and the results of the edge location for the metrology objects of a metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="index">Index of the metrology objects. Default: "all"</param>
        /// <param name="transition">Select light/dark or dark/light edges. Default: "all"</param>
        /// <param name="row">Row coordinates of the measured edges.</param>
        /// <param name="column">Column coordinates of the measured edges.</param>
        /// <returns>Rectangular XLD Contours of measure regions.</returns>
        public HXLDCont GetMetrologyObjectMeasures(
          HTuple index,
          string transition,
          out HTuple row,
          out HTuple column)
        {
            IntPtr proc = HalconAPI.PreCall(803);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, index);
            HalconAPI.StoreS(proc, 2, transition);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HXLDCont hxldCont;
            int err2 = HXLDCont.LoadNew(proc, 1, err1, out hxldCont);
            int err3 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err2, out row);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err3, out column);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Get the measure regions and the results of the edge location for the metrology objects of a metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="index">Index of the metrology objects. Default: "all"</param>
        /// <param name="transition">Select light/dark or dark/light edges. Default: "all"</param>
        /// <param name="row">Row coordinates of the measured edges.</param>
        /// <param name="column">Column coordinates of the measured edges.</param>
        /// <returns>Rectangular XLD Contours of measure regions.</returns>
        public HXLDCont GetMetrologyObjectMeasures(
          string index,
          string transition,
          out HTuple row,
          out HTuple column)
        {
            IntPtr proc = HalconAPI.PreCall(803);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, index);
            HalconAPI.StoreS(proc, 2, transition);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int err2 = HXLDCont.LoadNew(proc, 1, err1, out hxldCont);
            int err3 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err2, out row);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err3, out column);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Measure and fit the geometric shapes of all metrology objects of a metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="image">Input image.</param>
        public void ApplyMetrologyModel(HImage image)
        {
            IntPtr proc = HalconAPI.PreCall(804);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Get the indices of the metrology objects of a metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <returns>Indices of the metrology objects.</returns>
        public HTuple GetMetrologyObjectIndices()
        {
            IntPtr proc = HalconAPI.PreCall(805);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Reset all fuzzy parameters and fuzzy functions of a metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="index">Index of the metrology objects. Default: "all"</param>
        public void ResetMetrologyObjectFuzzyParam(HTuple index)
        {
            IntPtr proc = HalconAPI.PreCall(806);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, index);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Reset all fuzzy parameters and fuzzy functions of a metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="index">Index of the metrology objects. Default: "all"</param>
        public void ResetMetrologyObjectFuzzyParam(string index)
        {
            IntPtr proc = HalconAPI.PreCall(806);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, index);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Reset all parameters of a metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="index">Index of the metrology objects. Default: "all"</param>
        public void ResetMetrologyObjectParam(HTuple index)
        {
            IntPtr proc = HalconAPI.PreCall(807);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, index);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Reset all parameters of a metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="index">Index of the metrology objects. Default: "all"</param>
        public void ResetMetrologyObjectParam(string index)
        {
            IntPtr proc = HalconAPI.PreCall(807);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, index);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Get a fuzzy parameter of a metroloy model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="index">Index of the metrology objects. Default: 0</param>
        /// <param name="genParamName">Names of the generic parameters. Default: "fuzzy_thresh"</param>
        /// <returns>Values of the generic parameters.</returns>
        public HTuple GetMetrologyObjectFuzzyParam(HTuple index, HTuple genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(808);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, index);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HalconAPI.UnpinTuple(genParamName);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Get a fuzzy parameter of a metroloy model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="index">Index of the metrology objects. Default: 0</param>
        /// <param name="genParamName">Names of the generic parameters. Default: "fuzzy_thresh"</param>
        /// <returns>Values of the generic parameters.</returns>
        public HTuple GetMetrologyObjectFuzzyParam(string index, HTuple genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(808);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, index);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Get one or several parameters of a metroloy model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="index">Index of the metrology objects. Default: "all"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: "num_measures"</param>
        /// <returns>Values of the generic parameters.</returns>
        public HTuple GetMetrologyObjectParam(HTuple index, HTuple genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(809);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, index);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HalconAPI.UnpinTuple(genParamName);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Get one or several parameters of a metroloy model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="index">Index of the metrology objects. Default: "all"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: "num_measures"</param>
        /// <returns>Values of the generic parameters.</returns>
        public HTuple GetMetrologyObjectParam(string index, HTuple genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(809);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, index);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Set fuzzy parameters or fuzzy functions for a metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="index">Index of the metrology objects. Default: "all"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: "fuzzy_thresh"</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: 0.5</param>
        public void SetMetrologyObjectFuzzyParam(
          HTuple index,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(810);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, index);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set fuzzy parameters or fuzzy functions for a metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="index">Index of the metrology objects. Default: "all"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: "fuzzy_thresh"</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: 0.5</param>
        public void SetMetrologyObjectFuzzyParam(
          string index,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(810);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, index);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set parameters for the metrology objects of a metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="index">Index of the metrology objects. Default: "all"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: "num_instances"</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: 1</param>
        public void SetMetrologyObjectParam(HTuple index, HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(811);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, index);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set parameters for the metrology objects of a metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="index">Index of the metrology objects. Default: "all"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: "num_instances"</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: 1</param>
        public void SetMetrologyObjectParam(string index, HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(811);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, index);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Add a rectangle to a metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="row">Row (or Y) coordinate of the center of the rectangle.</param>
        /// <param name="column">Column (or X) coordinate of the center of the rectangle.</param>
        /// <param name="phi">Orientation of the main axis [rad].</param>
        /// <param name="length1">Length of the larger half edge of the rectangle.</param>
        /// <param name="length2">Length of the smaller half edge of the rectangle.</param>
        /// <param name="measureLength1">Half length of the measure regions perpendicular to the boundary. Default: 20.0</param>
        /// <param name="measureLength2">Half length of the measure regions tangetial to the boundary. Default: 5.0</param>
        /// <param name="measureSigma">Sigma of the Gaussian function for the smoothing. Default: 1.0</param>
        /// <param name="measureThreshold">Minimum edge amplitude. Default: 30.0</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <returns>Index of the created metrology object.</returns>
        public int AddMetrologyObjectRectangle2Measure(
          HTuple row,
          HTuple column,
          HTuple phi,
          HTuple length1,
          HTuple length2,
          HTuple measureLength1,
          HTuple measureLength2,
          HTuple measureSigma,
          HTuple measureThreshold,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(812);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, row);
            HalconAPI.Store(proc, 2, column);
            HalconAPI.Store(proc, 3, phi);
            HalconAPI.Store(proc, 4, length1);
            HalconAPI.Store(proc, 5, length2);
            HalconAPI.Store(proc, 6, measureLength1);
            HalconAPI.Store(proc, 7, measureLength2);
            HalconAPI.Store(proc, 8, measureSigma);
            HalconAPI.Store(proc, 9, measureThreshold);
            HalconAPI.Store(proc, 10, genParamName);
            HalconAPI.Store(proc, 11, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.UnpinTuple(phi);
            HalconAPI.UnpinTuple(length1);
            HalconAPI.UnpinTuple(length2);
            HalconAPI.UnpinTuple(measureLength1);
            HalconAPI.UnpinTuple(measureLength2);
            HalconAPI.UnpinTuple(measureSigma);
            HalconAPI.UnpinTuple(measureThreshold);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Add a rectangle to a metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="row">Row (or Y) coordinate of the center of the rectangle.</param>
        /// <param name="column">Column (or X) coordinate of the center of the rectangle.</param>
        /// <param name="phi">Orientation of the main axis [rad].</param>
        /// <param name="length1">Length of the larger half edge of the rectangle.</param>
        /// <param name="length2">Length of the smaller half edge of the rectangle.</param>
        /// <param name="measureLength1">Half length of the measure regions perpendicular to the boundary. Default: 20.0</param>
        /// <param name="measureLength2">Half length of the measure regions tangetial to the boundary. Default: 5.0</param>
        /// <param name="measureSigma">Sigma of the Gaussian function for the smoothing. Default: 1.0</param>
        /// <param name="measureThreshold">Minimum edge amplitude. Default: 30.0</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <returns>Index of the created metrology object.</returns>
        public int AddMetrologyObjectRectangle2Measure(
          double row,
          double column,
          double phi,
          double length1,
          double length2,
          double measureLength1,
          double measureLength2,
          double measureSigma,
          double measureThreshold,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(812);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, row);
            HalconAPI.StoreD(proc, 2, column);
            HalconAPI.StoreD(proc, 3, phi);
            HalconAPI.StoreD(proc, 4, length1);
            HalconAPI.StoreD(proc, 5, length2);
            HalconAPI.StoreD(proc, 6, measureLength1);
            HalconAPI.StoreD(proc, 7, measureLength2);
            HalconAPI.StoreD(proc, 8, measureSigma);
            HalconAPI.StoreD(proc, 9, measureThreshold);
            HalconAPI.Store(proc, 10, genParamName);
            HalconAPI.Store(proc, 11, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Add a line to a metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="rowBegin">Row (or Y) coordinate of the start of the line.</param>
        /// <param name="columnBegin">Column (or X) coordinate of the start of the line.</param>
        /// <param name="rowEnd">Row (or Y) coordinate of the end of the line.</param>
        /// <param name="columnEnd">Column (or X) coordinate of the end of the line.</param>
        /// <param name="measureLength1">Half length of the measure regions perpendicular to the boundary. Default: 20.0</param>
        /// <param name="measureLength2">Half length of the measure regions tangetial to the boundary. Default: 5.0</param>
        /// <param name="measureSigma">Sigma of the Gaussian function for the smoothing. Default: 1.0</param>
        /// <param name="measureThreshold">Minimum edge amplitude. Default: 30.0</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <returns>Index of the created metrology object.</returns>
        public int AddMetrologyObjectLineMeasure(
          HTuple rowBegin,
          HTuple columnBegin,
          HTuple rowEnd,
          HTuple columnEnd,
          HTuple measureLength1,
          HTuple measureLength2,
          HTuple measureSigma,
          HTuple measureThreshold,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(813);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, rowBegin);
            HalconAPI.Store(proc, 2, columnBegin);
            HalconAPI.Store(proc, 3, rowEnd);
            HalconAPI.Store(proc, 4, columnEnd);
            HalconAPI.Store(proc, 5, measureLength1);
            HalconAPI.Store(proc, 6, measureLength2);
            HalconAPI.Store(proc, 7, measureSigma);
            HalconAPI.Store(proc, 8, measureThreshold);
            HalconAPI.Store(proc, 9, genParamName);
            HalconAPI.Store(proc, 10, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(rowBegin);
            HalconAPI.UnpinTuple(columnBegin);
            HalconAPI.UnpinTuple(rowEnd);
            HalconAPI.UnpinTuple(columnEnd);
            HalconAPI.UnpinTuple(measureLength1);
            HalconAPI.UnpinTuple(measureLength2);
            HalconAPI.UnpinTuple(measureSigma);
            HalconAPI.UnpinTuple(measureThreshold);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Add a line to a metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="rowBegin">Row (or Y) coordinate of the start of the line.</param>
        /// <param name="columnBegin">Column (or X) coordinate of the start of the line.</param>
        /// <param name="rowEnd">Row (or Y) coordinate of the end of the line.</param>
        /// <param name="columnEnd">Column (or X) coordinate of the end of the line.</param>
        /// <param name="measureLength1">Half length of the measure regions perpendicular to the boundary. Default: 20.0</param>
        /// <param name="measureLength2">Half length of the measure regions tangetial to the boundary. Default: 5.0</param>
        /// <param name="measureSigma">Sigma of the Gaussian function for the smoothing. Default: 1.0</param>
        /// <param name="measureThreshold">Minimum edge amplitude. Default: 30.0</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <returns>Index of the created metrology object.</returns>
        public int AddMetrologyObjectLineMeasure(
          double rowBegin,
          double columnBegin,
          double rowEnd,
          double columnEnd,
          double measureLength1,
          double measureLength2,
          double measureSigma,
          double measureThreshold,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(813);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, rowBegin);
            HalconAPI.StoreD(proc, 2, columnBegin);
            HalconAPI.StoreD(proc, 3, rowEnd);
            HalconAPI.StoreD(proc, 4, columnEnd);
            HalconAPI.StoreD(proc, 5, measureLength1);
            HalconAPI.StoreD(proc, 6, measureLength2);
            HalconAPI.StoreD(proc, 7, measureSigma);
            HalconAPI.StoreD(proc, 8, measureThreshold);
            HalconAPI.Store(proc, 9, genParamName);
            HalconAPI.Store(proc, 10, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Add an ellipse or an elliptic arc to a metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="row">Row (or Y) coordinate of the center of the ellipse.</param>
        /// <param name="column">Column (or X) coordinate of the center of the ellipse.</param>
        /// <param name="phi">Orientation of the main axis [rad].</param>
        /// <param name="radius1">Length of the larger half axis.</param>
        /// <param name="radius2">Length of the smaller half axis.</param>
        /// <param name="measureLength1">Half length of the measure regions perpendicular to the boundary. Default: 20.0</param>
        /// <param name="measureLength2">Half length of the measure regions tangetial to the boundary. Default: 5.0</param>
        /// <param name="measureSigma">Sigma of the Gaussian function for the smoothing. Default: 1.0</param>
        /// <param name="measureThreshold">Minimum edge amplitude. Default: 30.0</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <returns>Index of the created metrology object.</returns>
        public int AddMetrologyObjectEllipseMeasure(
          HTuple row,
          HTuple column,
          HTuple phi,
          HTuple radius1,
          HTuple radius2,
          HTuple measureLength1,
          HTuple measureLength2,
          HTuple measureSigma,
          HTuple measureThreshold,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(814);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, row);
            HalconAPI.Store(proc, 2, column);
            HalconAPI.Store(proc, 3, phi);
            HalconAPI.Store(proc, 4, radius1);
            HalconAPI.Store(proc, 5, radius2);
            HalconAPI.Store(proc, 6, measureLength1);
            HalconAPI.Store(proc, 7, measureLength2);
            HalconAPI.Store(proc, 8, measureSigma);
            HalconAPI.Store(proc, 9, measureThreshold);
            HalconAPI.Store(proc, 10, genParamName);
            HalconAPI.Store(proc, 11, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.UnpinTuple(phi);
            HalconAPI.UnpinTuple(radius1);
            HalconAPI.UnpinTuple(radius2);
            HalconAPI.UnpinTuple(measureLength1);
            HalconAPI.UnpinTuple(measureLength2);
            HalconAPI.UnpinTuple(measureSigma);
            HalconAPI.UnpinTuple(measureThreshold);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Add an ellipse or an elliptic arc to a metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="row">Row (or Y) coordinate of the center of the ellipse.</param>
        /// <param name="column">Column (or X) coordinate of the center of the ellipse.</param>
        /// <param name="phi">Orientation of the main axis [rad].</param>
        /// <param name="radius1">Length of the larger half axis.</param>
        /// <param name="radius2">Length of the smaller half axis.</param>
        /// <param name="measureLength1">Half length of the measure regions perpendicular to the boundary. Default: 20.0</param>
        /// <param name="measureLength2">Half length of the measure regions tangetial to the boundary. Default: 5.0</param>
        /// <param name="measureSigma">Sigma of the Gaussian function for the smoothing. Default: 1.0</param>
        /// <param name="measureThreshold">Minimum edge amplitude. Default: 30.0</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <returns>Index of the created metrology object.</returns>
        public int AddMetrologyObjectEllipseMeasure(
          double row,
          double column,
          double phi,
          double radius1,
          double radius2,
          double measureLength1,
          double measureLength2,
          double measureSigma,
          double measureThreshold,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(814);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, row);
            HalconAPI.StoreD(proc, 2, column);
            HalconAPI.StoreD(proc, 3, phi);
            HalconAPI.StoreD(proc, 4, radius1);
            HalconAPI.StoreD(proc, 5, radius2);
            HalconAPI.StoreD(proc, 6, measureLength1);
            HalconAPI.StoreD(proc, 7, measureLength2);
            HalconAPI.StoreD(proc, 8, measureSigma);
            HalconAPI.StoreD(proc, 9, measureThreshold);
            HalconAPI.Store(proc, 10, genParamName);
            HalconAPI.Store(proc, 11, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Add a circle or a circular arc to a metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="row">Row coordinate (or Y) of the center of the circle or circular arc.</param>
        /// <param name="column">Column (or X) coordinate of the center of the circle or circular arc.</param>
        /// <param name="radius">Radius of the circle or circular arc.</param>
        /// <param name="measureLength1">Half length of the measure regions perpendicular to the boundary. Default: 20.0</param>
        /// <param name="measureLength2">Half length of the measure regions tangetial to the boundary. Default: 5.0</param>
        /// <param name="measureSigma">Sigma of the Gaussian function for the smoothing. Default: 1.0</param>
        /// <param name="measureThreshold">Minimum edge amplitude. Default: 30.0</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <returns>Index of the created metrology object.</returns>
        public int AddMetrologyObjectCircleMeasure(
          HTuple row,
          HTuple column,
          HTuple radius,
          HTuple measureLength1,
          HTuple measureLength2,
          HTuple measureSigma,
          HTuple measureThreshold,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(815);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, row);
            HalconAPI.Store(proc, 2, column);
            HalconAPI.Store(proc, 3, radius);
            HalconAPI.Store(proc, 4, measureLength1);
            HalconAPI.Store(proc, 5, measureLength2);
            HalconAPI.Store(proc, 6, measureSigma);
            HalconAPI.Store(proc, 7, measureThreshold);
            HalconAPI.Store(proc, 8, genParamName);
            HalconAPI.Store(proc, 9, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.UnpinTuple(radius);
            HalconAPI.UnpinTuple(measureLength1);
            HalconAPI.UnpinTuple(measureLength2);
            HalconAPI.UnpinTuple(measureSigma);
            HalconAPI.UnpinTuple(measureThreshold);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Add a circle or a circular arc to a metrology model.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="row">Row coordinate (or Y) of the center of the circle or circular arc.</param>
        /// <param name="column">Column (or X) coordinate of the center of the circle or circular arc.</param>
        /// <param name="radius">Radius of the circle or circular arc.</param>
        /// <param name="measureLength1">Half length of the measure regions perpendicular to the boundary. Default: 20.0</param>
        /// <param name="measureLength2">Half length of the measure regions tangetial to the boundary. Default: 5.0</param>
        /// <param name="measureSigma">Sigma of the Gaussian function for the smoothing. Default: 1.0</param>
        /// <param name="measureThreshold">Minimum edge amplitude. Default: 30.0</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <returns>Index of the created metrology object.</returns>
        public int AddMetrologyObjectCircleMeasure(
          double row,
          double column,
          double radius,
          double measureLength1,
          double measureLength2,
          double measureSigma,
          double measureThreshold,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(815);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, row);
            HalconAPI.StoreD(proc, 2, column);
            HalconAPI.StoreD(proc, 3, radius);
            HalconAPI.StoreD(proc, 4, measureLength1);
            HalconAPI.StoreD(proc, 5, measureLength2);
            HalconAPI.StoreD(proc, 6, measureSigma);
            HalconAPI.StoreD(proc, 7, measureThreshold);
            HalconAPI.Store(proc, 8, genParamName);
            HalconAPI.Store(proc, 9, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Delete metrology objects and free the allocated memory.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="index">Index of the metrology objects. Default: "all"</param>
        public void ClearMetrologyObject(HTuple index)
        {
            IntPtr proc = HalconAPI.PreCall(818);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, index);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Delete metrology objects and free the allocated memory.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="index">Index of the metrology objects. Default: "all"</param>
        public void ClearMetrologyObject(string index)
        {
            IntPtr proc = HalconAPI.PreCall(818);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, index);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set the size of the image of metrology objects.
        ///   Instance represents: Handle of the metrology model.
        /// </summary>
        /// <param name="width">Width of the image to be processed. Default: 640</param>
        /// <param name="height">Height of the image to be processed. Default: 480</param>
        public void SetMetrologyModelImageSize(int width, int height)
        {
            IntPtr proc = HalconAPI.PreCall(819);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, width);
            HalconAPI.StoreI(proc, 2, height);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create the data structure that is needed to measure geometric shapes.
        ///   Modified instance represents: Handle of the metrology model.
        /// </summary>
        public void CreateMetrologyModel()
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(820);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(817);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
