// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HBarCode
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a bar code reader.</summary>
    [Serializable]
    public class HBarCode : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HBarCode()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HBarCode(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HBarCode obj)
        {
            obj = new HBarCode(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HBarCode[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HBarCode[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HBarCode(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Read a bar code model from a file and create a new model.
        ///   Modified instance represents: Handle of the bar code model.
        /// </summary>
        /// <param name="fileName">Name of the bar code model file. Default: "bar_code_model.bcm"</param>
        public HBarCode(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1988);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a model of a bar code reader.
        ///   Modified instance represents: Handle for using and accessing the bar code model.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the bar code model. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the bar code model. Default: []</param>
        public HBarCode(HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(2001);
            HalconAPI.Store(proc, 0, genParamName);
            HalconAPI.Store(proc, 1, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a model of a bar code reader.
        ///   Modified instance represents: Handle for using and accessing the bar code model.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the bar code model. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the bar code model. Default: []</param>
        public HBarCode(string genParamName, double genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(2001);
            HalconAPI.StoreS(proc, 0, genParamName);
            HalconAPI.StoreD(proc, 1, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeBarCodeModel();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HBarCode(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeBarCodeModel(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeBarCodeModel().Serialize(stream);
        }

        public static HBarCode Deserialize(Stream stream)
        {
            HBarCode hbarCode = new HBarCode();
            hbarCode.DeserializeBarCodeModel(HSerializedItem.Deserialize(stream));
            return hbarCode;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HBarCode Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeBarCodeModel();
            HBarCode hbarCode = new HBarCode();
            hbarCode.DeserializeBarCodeModel(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hbarCode;
        }

        /// <summary>
        ///   Deserialize a bar code model.
        ///   Modified instance represents: Handle of the bar code model.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeBarCodeModel(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1986);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize a bar code model.
        ///   Instance represents: Handle of the bar code model.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeBarCodeModel()
        {
            IntPtr proc = HalconAPI.PreCall(1987);
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
        ///   Read a bar code model from a file and create a new model.
        ///   Modified instance represents: Handle of the bar code model.
        /// </summary>
        /// <param name="fileName">Name of the bar code model file. Default: "bar_code_model.bcm"</param>
        public void ReadBarCodeModel(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1988);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write a bar code model to a file.
        ///   Instance represents: Handle of the bar code model.
        /// </summary>
        /// <param name="fileName">Name of the bar code model file. Default: "bar_code_model.bcm"</param>
        public void WriteBarCodeModel(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1989);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Access iconic objects that were created during the search or decoding of bar code symbols.
        ///   Instance represents: Handle of the bar code model.
        /// </summary>
        /// <param name="candidateHandle">Indicating the bar code results respectively candidates for which the data is required. Default: "all"</param>
        /// <param name="objectName">Name of the iconic object to return. Default: "candidate_regions"</param>
        /// <returns>Objects that are created as intermediate results during the detection or evaluation of bar codes.</returns>
        public HObject GetBarCodeObject(HTuple candidateHandle, string objectName)
        {
            IntPtr proc = HalconAPI.PreCall(1990);
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
        ///   Access iconic objects that were created during the search or decoding of bar code symbols.
        ///   Instance represents: Handle of the bar code model.
        /// </summary>
        /// <param name="candidateHandle">Indicating the bar code results respectively candidates for which the data is required. Default: "all"</param>
        /// <param name="objectName">Name of the iconic object to return. Default: "candidate_regions"</param>
        /// <returns>Objects that are created as intermediate results during the detection or evaluation of bar codes.</returns>
        public HObject GetBarCodeObject(string candidateHandle, string objectName)
        {
            IntPtr proc = HalconAPI.PreCall(1990);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, candidateHandle);
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
        ///   Get the alphanumerical results that were accumulated during the decoding of bar code symbols.
        ///   Instance represents: Handle of the bar code model.
        /// </summary>
        /// <param name="candidateHandle">Indicating the bar code results respectively candidates for which the data is required. Default: "all"</param>
        /// <param name="resultName">Names of the resulting data to return. Default: "decoded_types"</param>
        /// <returns>List with the results.</returns>
        public HTuple GetBarCodeResult(HTuple candidateHandle, string resultName)
        {
            IntPtr proc = HalconAPI.PreCall(1991);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, candidateHandle);
            HalconAPI.StoreS(proc, 2, resultName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(candidateHandle);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Get the alphanumerical results that were accumulated during the decoding of bar code symbols.
        ///   Instance represents: Handle of the bar code model.
        /// </summary>
        /// <param name="candidateHandle">Indicating the bar code results respectively candidates for which the data is required. Default: "all"</param>
        /// <param name="resultName">Names of the resulting data to return. Default: "decoded_types"</param>
        /// <returns>List with the results.</returns>
        public HTuple GetBarCodeResult(string candidateHandle, string resultName)
        {
            IntPtr proc = HalconAPI.PreCall(1991);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, candidateHandle);
            HalconAPI.StoreS(proc, 2, resultName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Decode bar code symbols within a rectangle.
        ///   Instance represents: Handle of the bar code model.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="codeType">Type of the searched bar code. Default: "EAN-13"</param>
        /// <param name="row">Row index of the center. Default: 50.0</param>
        /// <param name="column">Column index of the center. Default: 100.0</param>
        /// <param name="phi">Orientation of rectangle in radians. Default: 0.0</param>
        /// <param name="length1">Half of the length of the rectangle along the reading direction of the bar code. Default: 200.0</param>
        /// <param name="length2">Half of the length of the rectangle perpendicular to the reading direction of the bar code. Default: 100.0</param>
        /// <returns>Data strings of all successfully decoded bar codes.</returns>
        public HTuple DecodeBarCodeRectangle2(
          HImage image,
          HTuple codeType,
          HTuple row,
          HTuple column,
          HTuple phi,
          HTuple length1,
          HTuple length2)
        {
            IntPtr proc = HalconAPI.PreCall(1992);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 1, codeType);
            HalconAPI.Store(proc, 2, row);
            HalconAPI.Store(proc, 3, column);
            HalconAPI.Store(proc, 4, phi);
            HalconAPI.Store(proc, 5, length1);
            HalconAPI.Store(proc, 6, length2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(codeType);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.UnpinTuple(phi);
            HalconAPI.UnpinTuple(length1);
            HalconAPI.UnpinTuple(length2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Decode bar code symbols within a rectangle.
        ///   Instance represents: Handle of the bar code model.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="codeType">Type of the searched bar code. Default: "EAN-13"</param>
        /// <param name="row">Row index of the center. Default: 50.0</param>
        /// <param name="column">Column index of the center. Default: 100.0</param>
        /// <param name="phi">Orientation of rectangle in radians. Default: 0.0</param>
        /// <param name="length1">Half of the length of the rectangle along the reading direction of the bar code. Default: 200.0</param>
        /// <param name="length2">Half of the length of the rectangle perpendicular to the reading direction of the bar code. Default: 100.0</param>
        /// <returns>Data strings of all successfully decoded bar codes.</returns>
        public string DecodeBarCodeRectangle2(
          HImage image,
          string codeType,
          double row,
          double column,
          double phi,
          double length1,
          double length2)
        {
            IntPtr proc = HalconAPI.PreCall(1992);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreS(proc, 1, codeType);
            HalconAPI.StoreD(proc, 2, row);
            HalconAPI.StoreD(proc, 3, column);
            HalconAPI.StoreD(proc, 4, phi);
            HalconAPI.StoreD(proc, 5, length1);
            HalconAPI.StoreD(proc, 6, length2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            string stringValue;
            int procResult = HalconAPI.LoadS(proc, 0, err, out stringValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return stringValue;
        }

        /// <summary>
        ///   Detect and read bar code symbols in an image.
        ///   Instance represents: Handle of the bar code model.
        /// </summary>
        /// <param name="image">Input image. If the image has a reduced domain, the barcode search is reduced to that domain. This usually reduces the runtime of the operator. However, if the barcode is not fully inside the domain, the barcode cannot be decoded correctly.</param>
        /// <param name="codeType">Type of the searched bar code. Default: "auto"</param>
        /// <param name="decodedDataStrings">Data strings of all successfully decoded bar codes.</param>
        /// <returns>Regions of the successfully decoded bar code symbols.</returns>
        public HRegion FindBarCode(HImage image, HTuple codeType, out HTuple decodedDataStrings)
        {
            IntPtr proc = HalconAPI.PreCall(1993);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 1, codeType);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(codeType);
            HRegion hregion;
            int err2 = HRegion.LoadNew(proc, 1, err1, out hregion);
            int procResult = HTuple.LoadNew(proc, 0, err2, out decodedDataStrings);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return hregion;
        }

        /// <summary>
        ///   Detect and read bar code symbols in an image.
        ///   Instance represents: Handle of the bar code model.
        /// </summary>
        /// <param name="image">Input image. If the image has a reduced domain, the barcode search is reduced to that domain. This usually reduces the runtime of the operator. However, if the barcode is not fully inside the domain, the barcode cannot be decoded correctly.</param>
        /// <param name="codeType">Type of the searched bar code. Default: "auto"</param>
        /// <param name="decodedDataStrings">Data strings of all successfully decoded bar codes.</param>
        /// <returns>Regions of the successfully decoded bar code symbols.</returns>
        public HRegion FindBarCode(HImage image, string codeType, out string decodedDataStrings)
        {
            IntPtr proc = HalconAPI.PreCall(1993);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreS(proc, 1, codeType);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            int err1 = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int err2 = HRegion.LoadNew(proc, 1, err1, out hregion);
            int procResult = HalconAPI.LoadS(proc, 0, err2, out decodedDataStrings);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return hregion;
        }

        /// <summary>
        ///   Get the names of the parameters that can be used in set_bar_code* and get_bar_code* operators for a given bar code model
        ///   Instance represents: Handle of the bar code model.
        /// </summary>
        /// <param name="properties">Properties of the parameters. Default: "trained_general"</param>
        /// <returns>Names of the generic parameters.</returns>
        public HTuple QueryBarCodeParams(string properties)
        {
            IntPtr proc = HalconAPI.PreCall(1994);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, properties);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Get parameters that are used by the bar code reader when processing a specific bar code type.
        ///   Instance represents: Handle of the bar code model.
        /// </summary>
        /// <param name="codeTypes">Names of the bar code types for which parameters should be queried. Default: "EAN-13"</param>
        /// <param name="genParamName">Names of the generic parameters that are to be queried for the bar code model. Default: "check_char"</param>
        /// <returns>Values of the generic parameters.</returns>
        public HTuple GetBarCodeParamSpecific(HTuple codeTypes, HTuple genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(1995);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, codeTypes);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(codeTypes);
            HalconAPI.UnpinTuple(genParamName);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Get parameters that are used by the bar code reader when processing a specific bar code type.
        ///   Instance represents: Handle of the bar code model.
        /// </summary>
        /// <param name="codeTypes">Names of the bar code types for which parameters should be queried. Default: "EAN-13"</param>
        /// <param name="genParamName">Names of the generic parameters that are to be queried for the bar code model. Default: "check_char"</param>
        /// <returns>Values of the generic parameters.</returns>
        public HTuple GetBarCodeParamSpecific(string codeTypes, string genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(1995);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, codeTypes);
            HalconAPI.StoreS(proc, 2, genParamName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Get one or several parameters that describe the bar code model.
        ///   Instance represents: Handle of the bar code model.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters that are to be queried for the bar code model. Default: "element_size_min"</param>
        /// <returns>Values of the generic parameters.</returns>
        public HTuple GetBarCodeParam(HTuple genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(1996);
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
        ///   Get one or several parameters that describe the bar code model.
        ///   Instance represents: Handle of the bar code model.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters that are to be queried for the bar code model. Default: "element_size_min"</param>
        /// <returns>Values of the generic parameters.</returns>
        public HTuple GetBarCodeParam(string genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(1996);
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
        ///   Set selected parameters of the bar code model for selected bar code types
        ///   Instance represents: Handle of the bar code model.
        /// </summary>
        /// <param name="codeTypes">Names of the bar code types for which parameters should be set. Default: "EAN-13"</param>
        /// <param name="genParamName">Names of the generic parameters that shall be adjusted for finding and decoding bar codes. Default: "check_char"</param>
        /// <param name="genParamValue">Values of the generic parameters that are adjusted for finding and decoding bar codes. Default: "absent"</param>
        public void SetBarCodeParamSpecific(
          HTuple codeTypes,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1997);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, codeTypes);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(codeTypes);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set selected parameters of the bar code model for selected bar code types
        ///   Instance represents: Handle of the bar code model.
        /// </summary>
        /// <param name="codeTypes">Names of the bar code types for which parameters should be set. Default: "EAN-13"</param>
        /// <param name="genParamName">Names of the generic parameters that shall be adjusted for finding and decoding bar codes. Default: "check_char"</param>
        /// <param name="genParamValue">Values of the generic parameters that are adjusted for finding and decoding bar codes. Default: "absent"</param>
        public void SetBarCodeParamSpecific(
          string codeTypes,
          string genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1997);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, codeTypes);
            HalconAPI.StoreS(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set selected parameters of the bar code model.
        ///   Instance represents: Handle of the bar code model.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters that shall be adjusted for finding and decoding bar codes. Default: "element_size_min"</param>
        /// <param name="genParamValue">Values of the generic parameters that are adjusted for finding and decoding bar codes. Default: 8</param>
        public void SetBarCodeParam(HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1998);
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
        ///   Set selected parameters of the bar code model.
        ///   Instance represents: Handle of the bar code model.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters that shall be adjusted for finding and decoding bar codes. Default: "element_size_min"</param>
        /// <param name="genParamValue">Values of the generic parameters that are adjusted for finding and decoding bar codes. Default: 8</param>
        public void SetBarCodeParam(string genParamName, double genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1998);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.StoreD(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a model of a bar code reader.
        ///   Modified instance represents: Handle for using and accessing the bar code model.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the bar code model. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the bar code model. Default: []</param>
        public void CreateBarCodeModel(HTuple genParamName, HTuple genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(2001);
            HalconAPI.Store(proc, 0, genParamName);
            HalconAPI.Store(proc, 1, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a model of a bar code reader.
        ///   Modified instance represents: Handle for using and accessing the bar code model.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the bar code model. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the bar code model. Default: []</param>
        public void CreateBarCodeModel(string genParamName, double genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(2001);
            HalconAPI.StoreS(proc, 0, genParamName);
            HalconAPI.StoreD(proc, 1, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(2000);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
