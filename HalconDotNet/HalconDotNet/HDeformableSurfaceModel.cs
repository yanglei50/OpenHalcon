// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HDeformableSurfaceModel
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a deformable surface model.</summary>
    [Serializable]
    public class HDeformableSurfaceModel : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HDeformableSurfaceModel()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HDeformableSurfaceModel(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(
          IntPtr proc,
          int parIndex,
          int err,
          out HDeformableSurfaceModel obj)
        {
            obj = new HDeformableSurfaceModel(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(
          IntPtr proc,
          int parIndex,
          int err,
          out HDeformableSurfaceModel[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HDeformableSurfaceModel[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HDeformableSurfaceModel(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Read a deformable surface model from a file.
        ///   Modified instance represents: Handle of the read deformable surface model.
        /// </summary>
        /// <param name="fileName">Name of the file to read.</param>
        public HDeformableSurfaceModel(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1024);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create the data structure needed to perform deformable surface-based matching.
        ///   Modified instance represents: Handle of the deformable surface model.
        /// </summary>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <param name="relSamplingDistance">Sampling distance relative to the object's diameter Default: 0.05</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        public HDeformableSurfaceModel(
          HObjectModel3D objectModel3D,
          double relSamplingDistance,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1031);
            HalconAPI.Store(proc, 0, (HTool)objectModel3D);
            HalconAPI.StoreD(proc, 1, relSamplingDistance);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D);
        }

        /// <summary>
        ///   Create the data structure needed to perform deformable surface-based matching.
        ///   Modified instance represents: Handle of the deformable surface model.
        /// </summary>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <param name="relSamplingDistance">Sampling distance relative to the object's diameter Default: 0.05</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        public HDeformableSurfaceModel(
          HObjectModel3D objectModel3D,
          double relSamplingDistance,
          string genParamName,
          string genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1031);
            HalconAPI.Store(proc, 0, (HTool)objectModel3D);
            HalconAPI.StoreD(proc, 1, relSamplingDistance);
            HalconAPI.StoreS(proc, 2, genParamName);
            HalconAPI.StoreS(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeDeformableSurfaceModel();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HDeformableSurfaceModel(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeDeformableSurfaceModel(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeDeformableSurfaceModel().Serialize(stream);
        }

        public static HDeformableSurfaceModel Deserialize(Stream stream)
        {
            HDeformableSurfaceModel hdeformableSurfaceModel = new HDeformableSurfaceModel();
            hdeformableSurfaceModel.DeserializeDeformableSurfaceModel(HSerializedItem.Deserialize(stream));
            return hdeformableSurfaceModel;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HDeformableSurfaceModel Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeDeformableSurfaceModel();
            HDeformableSurfaceModel hdeformableSurfaceModel = new HDeformableSurfaceModel();
            hdeformableSurfaceModel.DeserializeDeformableSurfaceModel(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hdeformableSurfaceModel;
        }

        /// <summary>
        ///   Deserialize a deformable surface model.
        ///   Modified instance represents: Handle of the deformable surface model.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeDeformableSurfaceModel(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1022);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize a deformable surface_model.
        ///   Instance represents: Handle of the deformable surface model.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeDeformableSurfaceModel()
        {
            IntPtr proc = HalconAPI.PreCall(1023);
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
        ///   Read a deformable surface model from a file.
        ///   Modified instance represents: Handle of the read deformable surface model.
        /// </summary>
        /// <param name="fileName">Name of the file to read.</param>
        public void ReadDeformableSurfaceModel(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1024);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write a deformable surface model to a file.
        ///   Instance represents: Handle of the deformable surface model to write.
        /// </summary>
        /// <param name="fileName">File name to write to.</param>
        public void WriteDeformableSurfaceModel(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1025);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Refine the position and deformation of a deformable surface model in a 3D scene.
        ///   Instance represents: Handle of the deformable surface model.
        /// </summary>
        /// <param name="objectModel3D">Handle of the 3D object model containing the scene.</param>
        /// <param name="relSamplingDistance">Relative sampling distance of the scene. Default: 0.05</param>
        /// <param name="initialDeformationObjectModel3D">Initial deformation of the 3D object model</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="deformableSurfaceMatchingResult">Handle of the matching result.</param>
        /// <returns>Score of the refined model.</returns>
        public HTuple RefineDeformableSurfaceModel(
          HObjectModel3D objectModel3D,
          double relSamplingDistance,
          HObjectModel3D initialDeformationObjectModel3D,
          HTuple genParamName,
          HTuple genParamValue,
          out HDeformableSurfaceMatchingResult[] deformableSurfaceMatchingResult)
        {
            IntPtr proc = HalconAPI.PreCall(1026);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)objectModel3D);
            HalconAPI.StoreD(proc, 2, relSamplingDistance);
            HalconAPI.Store(proc, 3, (HTool)initialDeformationObjectModel3D);
            HalconAPI.Store(proc, 4, genParamName);
            HalconAPI.Store(proc, 5, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int procResult = HDeformableSurfaceMatchingResult.LoadNew(proc, 1, err2, out deformableSurfaceMatchingResult);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D);
            GC.KeepAlive((object)initialDeformationObjectModel3D);
            return tuple;
        }

        /// <summary>
        ///   Refine the position and deformation of a deformable surface model in a 3D scene.
        ///   Instance represents: Handle of the deformable surface model.
        /// </summary>
        /// <param name="objectModel3D">Handle of the 3D object model containing the scene.</param>
        /// <param name="relSamplingDistance">Relative sampling distance of the scene. Default: 0.05</param>
        /// <param name="initialDeformationObjectModel3D">Initial deformation of the 3D object model</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="deformableSurfaceMatchingResult">Handle of the matching result.</param>
        /// <returns>Score of the refined model.</returns>
        public double RefineDeformableSurfaceModel(
          HObjectModel3D objectModel3D,
          double relSamplingDistance,
          HObjectModel3D initialDeformationObjectModel3D,
          string genParamName,
          string genParamValue,
          out HDeformableSurfaceMatchingResult deformableSurfaceMatchingResult)
        {
            IntPtr proc = HalconAPI.PreCall(1026);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)objectModel3D);
            HalconAPI.StoreD(proc, 2, relSamplingDistance);
            HalconAPI.Store(proc, 3, (HTool)initialDeformationObjectModel3D);
            HalconAPI.StoreS(proc, 4, genParamName);
            HalconAPI.StoreS(proc, 5, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int procResult = HDeformableSurfaceMatchingResult.LoadNew(proc, 1, err2, out deformableSurfaceMatchingResult);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D);
            GC.KeepAlive((object)initialDeformationObjectModel3D);
            return doubleValue;
        }

        /// <summary>
        ///   Find the best match of a deformable surface model in a 3D scene.
        ///   Instance represents: Handle of the deformable surface model.
        /// </summary>
        /// <param name="objectModel3D">Handle of the 3D object model containing the scene.</param>
        /// <param name="relSamplingDistance">Scene sampling distance relative to the diameter of the surface model. Default: 0.05</param>
        /// <param name="minScore">Minimum score of the returned match. Default: 0</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="deformableSurfaceMatchingResult">Handle of the matching result.</param>
        /// <returns>Score of the found instances of the surface model.</returns>
        public HTuple FindDeformableSurfaceModel(
          HObjectModel3D objectModel3D,
          double relSamplingDistance,
          HTuple minScore,
          HTuple genParamName,
          HTuple genParamValue,
          out HDeformableSurfaceMatchingResult[] deformableSurfaceMatchingResult)
        {
            IntPtr proc = HalconAPI.PreCall(1027);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)objectModel3D);
            HalconAPI.StoreD(proc, 2, relSamplingDistance);
            HalconAPI.Store(proc, 3, minScore);
            HalconAPI.Store(proc, 4, genParamName);
            HalconAPI.Store(proc, 5, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(minScore);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int procResult = HDeformableSurfaceMatchingResult.LoadNew(proc, 1, err2, out deformableSurfaceMatchingResult);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D);
            return tuple;
        }

        /// <summary>
        ///   Find the best match of a deformable surface model in a 3D scene.
        ///   Instance represents: Handle of the deformable surface model.
        /// </summary>
        /// <param name="objectModel3D">Handle of the 3D object model containing the scene.</param>
        /// <param name="relSamplingDistance">Scene sampling distance relative to the diameter of the surface model. Default: 0.05</param>
        /// <param name="minScore">Minimum score of the returned match. Default: 0</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="deformableSurfaceMatchingResult">Handle of the matching result.</param>
        /// <returns>Score of the found instances of the surface model.</returns>
        public double FindDeformableSurfaceModel(
          HObjectModel3D objectModel3D,
          double relSamplingDistance,
          double minScore,
          HTuple genParamName,
          HTuple genParamValue,
          out HDeformableSurfaceMatchingResult deformableSurfaceMatchingResult)
        {
            IntPtr proc = HalconAPI.PreCall(1027);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)objectModel3D);
            HalconAPI.StoreD(proc, 2, relSamplingDistance);
            HalconAPI.StoreD(proc, 3, minScore);
            HalconAPI.Store(proc, 4, genParamName);
            HalconAPI.Store(proc, 5, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int procResult = HDeformableSurfaceMatchingResult.LoadNew(proc, 1, err2, out deformableSurfaceMatchingResult);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D);
            return doubleValue;
        }

        /// <summary>
        ///   Return the parameters and properties of a deformable surface model.
        ///   Instance represents: Handle of the deformable surface model.
        /// </summary>
        /// <param name="genParamName">Name of the parameter. Default: "sampled_model"</param>
        /// <returns>Value of the parameter.</returns>
        public HTuple GetDeformableSurfaceModelParam(HTuple genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(1028);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, genParamName);
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
        ///   Return the parameters and properties of a deformable surface model.
        ///   Instance represents: Handle of the deformable surface model.
        /// </summary>
        /// <param name="genParamName">Name of the parameter. Default: "sampled_model"</param>
        /// <returns>Value of the parameter.</returns>
        public HTuple GetDeformableSurfaceModelParam(string genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(1028);
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
        ///   Add a reference point to a deformable surface model.
        ///   Instance represents: Handle of the deformable surface model.
        /// </summary>
        /// <param name="referencePointX">x-coordinates of a reference point.</param>
        /// <param name="referencePointY">x-coordinates of a reference point.</param>
        /// <param name="referencePointZ">x-coordinates of a reference point.</param>
        /// <returns>Index of the new reference point.</returns>
        public HTuple AddDeformableSurfaceModelReferencePoint(
          HTuple referencePointX,
          HTuple referencePointY,
          HTuple referencePointZ)
        {
            IntPtr proc = HalconAPI.PreCall(1029);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, referencePointX);
            HalconAPI.Store(proc, 2, referencePointY);
            HalconAPI.Store(proc, 3, referencePointZ);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(referencePointX);
            HalconAPI.UnpinTuple(referencePointY);
            HalconAPI.UnpinTuple(referencePointZ);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Add a reference point to a deformable surface model.
        ///   Instance represents: Handle of the deformable surface model.
        /// </summary>
        /// <param name="referencePointX">x-coordinates of a reference point.</param>
        /// <param name="referencePointY">x-coordinates of a reference point.</param>
        /// <param name="referencePointZ">x-coordinates of a reference point.</param>
        /// <returns>Index of the new reference point.</returns>
        public int AddDeformableSurfaceModelReferencePoint(
          double referencePointX,
          double referencePointY,
          double referencePointZ)
        {
            IntPtr proc = HalconAPI.PreCall(1029);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, referencePointX);
            HalconAPI.StoreD(proc, 2, referencePointY);
            HalconAPI.StoreD(proc, 3, referencePointZ);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Add a sample deformation to a deformable surface model
        ///   Instance represents: Handle of the deformable surface model.
        /// </summary>
        /// <param name="objectModel3D">Handle of the deformed 3D object model.</param>
        public void AddDeformableSurfaceModelSample(HObjectModel3D[] objectModel3D)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])objectModel3D);
            IntPtr proc = HalconAPI.PreCall(1030);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, htuple);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D);
        }

        /// <summary>
        ///   Add a sample deformation to a deformable surface model
        ///   Instance represents: Handle of the deformable surface model.
        /// </summary>
        /// <param name="objectModel3D">Handle of the deformed 3D object model.</param>
        public void AddDeformableSurfaceModelSample(HObjectModel3D objectModel3D)
        {
            IntPtr proc = HalconAPI.PreCall(1030);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)objectModel3D);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D);
        }

        /// <summary>
        ///   Create the data structure needed to perform deformable surface-based matching.
        ///   Modified instance represents: Handle of the deformable surface model.
        /// </summary>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <param name="relSamplingDistance">Sampling distance relative to the object's diameter Default: 0.05</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        public void CreateDeformableSurfaceModel(
          HObjectModel3D objectModel3D,
          double relSamplingDistance,
          HTuple genParamName,
          HTuple genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1031);
            HalconAPI.Store(proc, 0, (HTool)objectModel3D);
            HalconAPI.StoreD(proc, 1, relSamplingDistance);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D);
        }

        /// <summary>
        ///   Create the data structure needed to perform deformable surface-based matching.
        ///   Modified instance represents: Handle of the deformable surface model.
        /// </summary>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <param name="relSamplingDistance">Sampling distance relative to the object's diameter Default: 0.05</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        public void CreateDeformableSurfaceModel(
          HObjectModel3D objectModel3D,
          double relSamplingDistance,
          string genParamName,
          string genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1031);
            HalconAPI.Store(proc, 0, (HTool)objectModel3D);
            HalconAPI.StoreD(proc, 1, relSamplingDistance);
            HalconAPI.StoreS(proc, 2, genParamName);
            HalconAPI.StoreS(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(1021);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
