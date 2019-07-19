// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HDataCode2D
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a 2D data code reader.</summary>
    [Serializable]
    public class HDataCode2D : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HDataCode2D()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HDataCode2D(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HDataCode2D obj)
        {
            obj = new HDataCode2D(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HDataCode2D[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HDataCode2D[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HDataCode2D(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Read a 2D data code model from a file and create a new model.
        ///   Modified instance represents: Handle of the created 2D data code model.
        /// </summary>
        /// <param name="fileName">Name of the 2D data code model file. Default: "data_code_model.dcm"</param>
        public HDataCode2D(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1774);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a model of a 2D data code class.
        ///   Modified instance represents: Handle for using and accessing the 2D data code model.
        /// </summary>
        /// <param name="symbolType">Type of the 2D data code. Default: "Data Matrix ECC 200"</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the 2D data code model. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the 2D data code model. Default: []</param>
        public HDataCode2D(string symbolType, HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1778);
            HalconAPI.StoreS(proc, 0, symbolType);
            HalconAPI.Store(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a model of a 2D data code class.
        ///   Modified instance represents: Handle for using and accessing the 2D data code model.
        /// </summary>
        /// <param name="symbolType">Type of the 2D data code. Default: "Data Matrix ECC 200"</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the 2D data code model. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the 2D data code model. Default: []</param>
        public HDataCode2D(string symbolType, string genParamName, string genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1778);
            HalconAPI.StoreS(proc, 0, symbolType);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.StoreS(proc, 2, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeDataCode2dModel();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HDataCode2D(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeDataCode2dModel(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeDataCode2dModel().Serialize(stream);
        }

        public static HDataCode2D Deserialize(Stream stream)
        {
            HDataCode2D hdataCode2D = new HDataCode2D();
            hdataCode2D.DeserializeDataCode2dModel(HSerializedItem.Deserialize(stream));
            return hdataCode2D;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HDataCode2D Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeDataCode2dModel();
            HDataCode2D hdataCode2D = new HDataCode2D();
            hdataCode2D.DeserializeDataCode2dModel(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hdataCode2D;
        }

        /// <summary>
        ///   Access iconic objects that were created during the search for 2D data code symbols.
        ///   Instance represents: Handle of the 2D data code model.
        /// </summary>
        /// <param name="candidateHandle">Handle of the 2D data code candidate or name of a group of candidates for which the iconic data is requested. Default: "all_candidates"</param>
        /// <param name="objectName">Name of the iconic object to return. Default: "candidate_xld"</param>
        /// <returns>Objects that are created as intermediate results during the detection or evaluation of 2D data codes.</returns>
        public HObject GetDataCode2dObjects(HTuple candidateHandle, string objectName)
        {
            IntPtr proc = HalconAPI.PreCall(1766);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, candidateHandle);
            HalconAPI.StoreS(proc, 2, objectName);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(candidateHandle);
            HObject hobject;
            int procResult = HObject.LoadNew(proc, 1, err, out hobject);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobject;
        }

        /// <summary>
        ///   Access iconic objects that were created during the search for 2D data code symbols.
        ///   Instance represents: Handle of the 2D data code model.
        /// </summary>
        /// <param name="candidateHandle">Handle of the 2D data code candidate or name of a group of candidates for which the iconic data is requested. Default: "all_candidates"</param>
        /// <param name="objectName">Name of the iconic object to return. Default: "candidate_xld"</param>
        /// <returns>Objects that are created as intermediate results during the detection or evaluation of 2D data codes.</returns>
        public HObject GetDataCode2dObjects(int candidateHandle, string objectName)
        {
            IntPtr proc = HalconAPI.PreCall(1766);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, candidateHandle);
            HalconAPI.StoreS(proc, 2, objectName);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HObject hobject;
            int procResult = HObject.LoadNew(proc, 1, err, out hobject);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobject;
        }

        /// <summary>
        ///   Get the alphanumerical results that were accumulated during the search for 2D data code symbols.
        ///   Instance represents: Handle of the 2D data code model.
        /// </summary>
        /// <param name="candidateHandle">Handle of the 2D data code candidate or name of a group of candidates for which the data is required. Default: "all_candidates"</param>
        /// <param name="resultNames">Names of the results of the 2D data code to return. Default: "status"</param>
        /// <returns>List with the results.</returns>
        public HTuple GetDataCode2dResults(HTuple candidateHandle, HTuple resultNames)
        {
            IntPtr proc = HalconAPI.PreCall(1767);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, candidateHandle);
            HalconAPI.Store(proc, 2, resultNames);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(candidateHandle);
            HalconAPI.UnpinTuple(resultNames);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Get the alphanumerical results that were accumulated during the search for 2D data code symbols.
        ///   Instance represents: Handle of the 2D data code model.
        /// </summary>
        /// <param name="candidateHandle">Handle of the 2D data code candidate or name of a group of candidates for which the data is required. Default: "all_candidates"</param>
        /// <param name="resultNames">Names of the results of the 2D data code to return. Default: "status"</param>
        /// <returns>List with the results.</returns>
        public HTuple GetDataCode2dResults(string candidateHandle, string resultNames)
        {
            IntPtr proc = HalconAPI.PreCall(1767);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, candidateHandle);
            HalconAPI.StoreS(proc, 2, resultNames);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Detect and read 2D data code symbols in an image or train the 2D data code model.
        ///   Instance represents: Handle of the 2D data code model.
        /// </summary>
        /// <param name="image">Input image. If the image has a reduced domain, the data code search is reduced to that domain. This usually reduces the runtime of the operator. However, if the datacode is not fully inside the domain, the datacode might not be found correctly. In rare cases, data codes may be found outside the domain. If these results  are undesirable, they have to be subsequently eliminated. </param>
        /// <param name="genParamName">Names of (optional) parameters for controlling the behavior of the operator. Default: []</param>
        /// <param name="genParamValue">Values of the optional generic parameters. Default: []</param>
        /// <param name="resultHandles">Handles of all successfully decoded 2D data code symbols.</param>
        /// <param name="decodedDataStrings">Decoded data strings of all detected 2D data code symbols in the image.</param>
        /// <returns>XLD contours that surround the successfully decoded data code symbols. The order of the contour points reflects the orientation of the detected symbols. The contours begin in the top left corner (see 'orientation' at get_data_code_2d_results) and continue clockwise.  Alignment{left} Figure[1][1][60]{get_data_code_2d_results-xld_qrcode} Order of points of SymbolXLDs Figure Alignment @f$ </returns>
        public HXLDCont FindDataCode2d(
          HImage image,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple resultHandles,
          out HTuple decodedDataStrings)
        {
            IntPtr proc = HalconAPI.PreCall(1768);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HXLDCont hxldCont;
            int err2 = HXLDCont.LoadNew(proc, 1, err1, out hxldCont);
            int err3 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err2, out resultHandles);
            int procResult = HTuple.LoadNew(proc, 1, err3, out decodedDataStrings);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return hxldCont;
        }

        /// <summary>
        ///   Detect and read 2D data code symbols in an image or train the 2D data code model.
        ///   Instance represents: Handle of the 2D data code model.
        /// </summary>
        /// <param name="image">Input image. If the image has a reduced domain, the data code search is reduced to that domain. This usually reduces the runtime of the operator. However, if the datacode is not fully inside the domain, the datacode might not be found correctly. In rare cases, data codes may be found outside the domain. If these results  are undesirable, they have to be subsequently eliminated. </param>
        /// <param name="genParamName">Names of (optional) parameters for controlling the behavior of the operator. Default: []</param>
        /// <param name="genParamValue">Values of the optional generic parameters. Default: []</param>
        /// <param name="resultHandles">Handles of all successfully decoded 2D data code symbols.</param>
        /// <param name="decodedDataStrings">Decoded data strings of all detected 2D data code symbols in the image.</param>
        /// <returns>XLD contours that surround the successfully decoded data code symbols. The order of the contour points reflects the orientation of the detected symbols. The contours begin in the top left corner (see 'orientation' at get_data_code_2d_results) and continue clockwise.  Alignment{left} Figure[1][1][60]{get_data_code_2d_results-xld_qrcode} Order of points of SymbolXLDs Figure Alignment @f$ </returns>
        public HXLDCont FindDataCode2d(
          HImage image,
          string genParamName,
          int genParamValue,
          out int resultHandles,
          out string decodedDataStrings)
        {
            IntPtr proc = HalconAPI.PreCall(1768);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.StoreI(proc, 2, genParamValue);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int err2 = HXLDCont.LoadNew(proc, 1, err1, out hxldCont);
            int err3 = HalconAPI.LoadI(proc, 0, err2, out resultHandles);
            int procResult = HalconAPI.LoadS(proc, 1, err3, out decodedDataStrings);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return hxldCont;
        }

        /// <summary>
        ///   Set selected parameters of the 2D data code model.
        ///   Instance represents: Handle of the 2D data code model.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters that shall be adjusted for the 2D data code. Default: "polarity"</param>
        /// <param name="genParamValue">Values of the generic parameters that are adjusted for the 2D data code. Default: "light_on_dark"</param>
        public void SetDataCode2dParam(HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1769);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set selected parameters of the 2D data code model.
        ///   Instance represents: Handle of the 2D data code model.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters that shall be adjusted for the 2D data code. Default: "polarity"</param>
        /// <param name="genParamValue">Values of the generic parameters that are adjusted for the 2D data code. Default: "light_on_dark"</param>
        public void SetDataCode2dParam(string genParamName, string genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1769);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.StoreS(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Get one or several parameters that describe the 2D data code model.
        ///   Instance represents: Handle of the 2D data code model.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters that are to be queried for the 2D data code model. Default: "contrast_min"</param>
        /// <returns>Values of the generic parameters.</returns>
        public HTuple GetDataCode2dParam(HTuple genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(1770);
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
        ///   Get one or several parameters that describe the 2D data code model.
        ///   Instance represents: Handle of the 2D data code model.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters that are to be queried for the 2D data code model. Default: "contrast_min"</param>
        /// <returns>Values of the generic parameters.</returns>
        public HTuple GetDataCode2dParam(string genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(1770);
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
        ///   Get for a given 2D data code model the names of the generic parameters or objects that can be used in the other 2D data code operators.
        ///   Instance represents: Handle of the 2D data code model.
        /// </summary>
        /// <param name="queryName">Name of the parameter group. Default: "get_result_params"</param>
        /// <returns>List containing the names of the supported generic parameters.</returns>
        public HTuple QueryDataCode2dParams(string queryName)
        {
            IntPtr proc = HalconAPI.PreCall(1771);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, queryName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Deserialize a serialized 2D data code model.
        ///   Modified instance represents: Handle of the 2D data code model.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeDataCode2dModel(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1772);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize a 2D data code model.
        ///   Instance represents: Handle of the 2D data code model.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeDataCode2dModel()
        {
            IntPtr proc = HalconAPI.PreCall(1773);
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
        ///   Read a 2D data code model from a file and create a new model.
        ///   Modified instance represents: Handle of the created 2D data code model.
        /// </summary>
        /// <param name="fileName">Name of the 2D data code model file. Default: "data_code_model.dcm"</param>
        public void ReadDataCode2dModel(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1774);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Writes a 2D data code model into a file.
        ///   Instance represents: Handle of the 2D data code model.
        /// </summary>
        /// <param name="fileName">Name of the 2D data code model file. Default: "data_code_model.dcm"</param>
        public void WriteDataCode2dModel(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1775);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a model of a 2D data code class.
        ///   Modified instance represents: Handle for using and accessing the 2D data code model.
        /// </summary>
        /// <param name="symbolType">Type of the 2D data code. Default: "Data Matrix ECC 200"</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the 2D data code model. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the 2D data code model. Default: []</param>
        public void CreateDataCode2dModel(string symbolType, HTuple genParamName, HTuple genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1778);
            HalconAPI.StoreS(proc, 0, symbolType);
            HalconAPI.Store(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a model of a 2D data code class.
        ///   Modified instance represents: Handle for using and accessing the 2D data code model.
        /// </summary>
        /// <param name="symbolType">Type of the 2D data code. Default: "Data Matrix ECC 200"</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the 2D data code model. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the 2D data code model. Default: []</param>
        public void CreateDataCode2dModel(string symbolType, string genParamName, string genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1778);
            HalconAPI.StoreS(proc, 0, symbolType);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.StoreS(proc, 2, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(1777);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
