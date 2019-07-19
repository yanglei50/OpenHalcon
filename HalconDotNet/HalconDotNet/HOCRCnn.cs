// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HOCRCnn
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
  /// <summary>Represents an instance of a CNN OCR classifier.</summary>
  [Serializable]
  public class HOCRCnn : HTool, ISerializable, ICloneable
  {
    [EditorBrowsable(EditorBrowsableState.Never)]
    public HOCRCnn()
      : base(HTool.UNDEF)
    {
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public HOCRCnn(IntPtr handle)
      : base(handle)
    {
    }

    internal static int LoadNew(IntPtr proc, int parIndex, int err, out HOCRCnn obj)
    {
      obj = new HOCRCnn(HTool.UNDEF);
      return obj.Load(proc, parIndex, err);
    }

    internal static int LoadNew(IntPtr proc, int parIndex, int err, out HOCRCnn[] obj)
    {
      HTuple tuple;
      err = HTuple.LoadNew(proc, parIndex, err, out tuple);
      obj = new HOCRCnn[tuple.Length];
      for (int index = 0; index < tuple.Length; ++index)
        obj[index] = new HOCRCnn(tuple[index].IP);
      return err;
    }

    /// <summary>
    ///   Read an CNN-based OCR classifier from a file.
    ///   Modified instance represents: Handle of the OCR classifier.
    /// </summary>
    /// <param name="fileName">File name. Default: "Universal_Rej.occ"</param>
    public HOCRCnn(string fileName)
    {
      IntPtr proc = HalconAPI.PreCall(2082);
      HalconAPI.StoreS(proc, 0, fileName);
      HalconAPI.InitOCT(proc, 0);
      int err = HalconAPI.CallProcedure(proc);
      int procResult = this.Load(proc, 0, err);
      HalconAPI.PostCall(proc, procResult);
      GC.KeepAlive((object) this);
    }

    void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
    {
      HSerializedItem hserializedItem = this.SerializeOcrClassCnn();
      byte[] numArray = (byte[]) hserializedItem;
      hserializedItem.Dispose();
      info.AddValue("data", (object) numArray, typeof (byte[]));
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public HOCRCnn(SerializationInfo info, StreamingContext context)
    {
      HSerializedItem serializedItemHandle = new HSerializedItem((byte[]) info.GetValue("data", typeof (byte[])));
      this.DeserializeOcrClassCnn(serializedItemHandle);
      serializedItemHandle.Dispose();
    }

    public void Serialize(Stream stream)
    {
      this.SerializeOcrClassCnn().Serialize(stream);
    }

    public static HOCRCnn Deserialize(Stream stream)
    {
      HOCRCnn hocrCnn = new HOCRCnn();
      hocrCnn.DeserializeOcrClassCnn(HSerializedItem.Deserialize(stream));
      return hocrCnn;
    }

    object ICloneable.Clone()
    {
      return (object) this.Clone();
    }

    public HOCRCnn Clone()
    {
      HSerializedItem serializedItemHandle = this.SerializeOcrClassCnn();
      HOCRCnn hocrCnn = new HOCRCnn();
      hocrCnn.DeserializeOcrClassCnn(serializedItemHandle);
      serializedItemHandle.Dispose();
      return hocrCnn;
    }

    /// <summary>
    ///   Deserialize a serialized CNN-based OCR classifier.
    ///   Modified instance represents: Handle of the OCR classifier.
    /// </summary>
    /// <param name="serializedItemHandle">Handle of the serialized item.</param>
    public void DeserializeOcrClassCnn(HSerializedItem serializedItemHandle)
    {
      this.Dispose();
      IntPtr proc = HalconAPI.PreCall(2053);
      HalconAPI.Store(proc, 0, (HTool) serializedItemHandle);
      HalconAPI.InitOCT(proc, 0);
      int err = HalconAPI.CallProcedure(proc);
      int procResult = this.Load(proc, 0, err);
      HalconAPI.PostCall(proc, procResult);
      GC.KeepAlive((object) this);
      GC.KeepAlive((object) serializedItemHandle);
    }

    /// <summary>
    ///   Classify multiple characters with an CNN-based OCR classifier.
    ///   Instance represents: Handle of the OCR classifier.
    /// </summary>
    /// <param name="character">Characters to be recognized.</param>
    /// <param name="image">Gray values of the characters.</param>
    /// <param name="confidence">Confidence of the class of the characters.</param>
    /// <returns>Result of classifying the characters with the CNN.</returns>
    public HTuple DoOcrMultiClassCnn(HRegion character, HImage image, out HTuple confidence)
    {
      IntPtr proc = HalconAPI.PreCall(2056);
      this.Store(proc, 0);
      HalconAPI.Store(proc, 1, (HObjectBase) character);
      HalconAPI.Store(proc, 2, (HObjectBase) image);
      HalconAPI.InitOCT(proc, 0);
      HalconAPI.InitOCT(proc, 1);
      int err1 = HalconAPI.CallProcedure(proc);
      HTuple tuple;
      int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
      int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out confidence);
      HalconAPI.PostCall(proc, procResult);
      GC.KeepAlive((object) this);
      GC.KeepAlive((object) character);
      GC.KeepAlive((object) image);
      return tuple;
    }

    /// <summary>
    ///   Classify multiple characters with an CNN-based OCR classifier.
    ///   Instance represents: Handle of the OCR classifier.
    /// </summary>
    /// <param name="character">Characters to be recognized.</param>
    /// <param name="image">Gray values of the characters.</param>
    /// <param name="confidence">Confidence of the class of the characters.</param>
    /// <returns>Result of classifying the characters with the CNN.</returns>
    public string DoOcrMultiClassCnn(HRegion character, HImage image, out double confidence)
    {
      IntPtr proc = HalconAPI.PreCall(2056);
      this.Store(proc, 0);
      HalconAPI.Store(proc, 1, (HObjectBase) character);
      HalconAPI.Store(proc, 2, (HObjectBase) image);
      HalconAPI.InitOCT(proc, 0);
      HalconAPI.InitOCT(proc, 1);
      int err1 = HalconAPI.CallProcedure(proc);
      string stringValue;
      int err2 = HalconAPI.LoadS(proc, 0, err1, out stringValue);
      int procResult = HalconAPI.LoadD(proc, 1, err2, out confidence);
      HalconAPI.PostCall(proc, procResult);
      GC.KeepAlive((object) this);
      GC.KeepAlive((object) character);
      GC.KeepAlive((object) image);
      return stringValue;
    }

    /// <summary>
    ///   Classify a single character with an CNN-based OCR classifier.
    ///   Instance represents: Handle of the OCR classifier.
    /// </summary>
    /// <param name="character">Character to be recognized.</param>
    /// <param name="image">Gray values of the character.</param>
    /// <param name="num">Number of best classes to determine. Default: 1</param>
    /// <param name="confidence">Confidence(s) of the class(es) of the character.</param>
    /// <returns>Result of classifying the character with the CNN.</returns>
    public HTuple DoOcrSingleClassCnn(
      HRegion character,
      HImage image,
      HTuple num,
      out HTuple confidence)
    {
      IntPtr proc = HalconAPI.PreCall(2057);
      this.Store(proc, 0);
      HalconAPI.Store(proc, 1, (HObjectBase) character);
      HalconAPI.Store(proc, 2, (HObjectBase) image);
      HalconAPI.Store(proc, 1, num);
      HalconAPI.InitOCT(proc, 0);
      HalconAPI.InitOCT(proc, 1);
      int err1 = HalconAPI.CallProcedure(proc);
      HalconAPI.UnpinTuple(num);
      HTuple tuple;
      int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
      int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out confidence);
      HalconAPI.PostCall(proc, procResult);
      GC.KeepAlive((object) this);
      GC.KeepAlive((object) character);
      GC.KeepAlive((object) image);
      return tuple;
    }

    /// <summary>
    ///   Classify a single character with an CNN-based OCR classifier.
    ///   Instance represents: Handle of the OCR classifier.
    /// </summary>
    /// <param name="character">Character to be recognized.</param>
    /// <param name="image">Gray values of the character.</param>
    /// <param name="num">Number of best classes to determine. Default: 1</param>
    /// <param name="confidence">Confidence(s) of the class(es) of the character.</param>
    /// <returns>Result of classifying the character with the CNN.</returns>
    public string DoOcrSingleClassCnn(
      HRegion character,
      HImage image,
      HTuple num,
      out double confidence)
    {
      IntPtr proc = HalconAPI.PreCall(2057);
      this.Store(proc, 0);
      HalconAPI.Store(proc, 1, (HObjectBase) character);
      HalconAPI.Store(proc, 2, (HObjectBase) image);
      HalconAPI.Store(proc, 1, num);
      HalconAPI.InitOCT(proc, 0);
      HalconAPI.InitOCT(proc, 1);
      int err1 = HalconAPI.CallProcedure(proc);
      HalconAPI.UnpinTuple(num);
      string stringValue;
      int err2 = HalconAPI.LoadS(proc, 0, err1, out stringValue);
      int procResult = HalconAPI.LoadD(proc, 1, err2, out confidence);
      HalconAPI.PostCall(proc, procResult);
      GC.KeepAlive((object) this);
      GC.KeepAlive((object) character);
      GC.KeepAlive((object) image);
      return stringValue;
    }

    /// <summary>
    ///   Classify a related group of characters with an CNN-based OCR classifier.
    ///   Instance represents: Handle of the OCR classifier.
    /// </summary>
    /// <param name="character">Characters to be recognized.</param>
    /// <param name="image">Gray values of the characters.</param>
    /// <param name="expression">Expression describing the allowed word structure.</param>
    /// <param name="numAlternatives">Number of classes per character considered for the internal word correction. Default: 3</param>
    /// <param name="numCorrections">Maximum number of corrected characters. Default: 2</param>
    /// <param name="confidence">Confidence of the class of the characters.</param>
    /// <param name="word">Word text after classification and correction.</param>
    /// <param name="score">Measure of similarity between corrected word and uncorrected classification results.</param>
    /// <returns>Result of classifying the characters with the CNN.</returns>
    public HTuple DoOcrWordCnn(
      HRegion character,
      HImage image,
      string expression,
      int numAlternatives,
      int numCorrections,
      out HTuple confidence,
      out string word,
      out double score)
    {
      IntPtr proc = HalconAPI.PreCall(2058);
      this.Store(proc, 0);
      HalconAPI.Store(proc, 1, (HObjectBase) character);
      HalconAPI.Store(proc, 2, (HObjectBase) image);
      HalconAPI.StoreS(proc, 1, expression);
      HalconAPI.StoreI(proc, 2, numAlternatives);
      HalconAPI.StoreI(proc, 3, numCorrections);
      HalconAPI.InitOCT(proc, 0);
      HalconAPI.InitOCT(proc, 1);
      HalconAPI.InitOCT(proc, 2);
      HalconAPI.InitOCT(proc, 3);
      int err1 = HalconAPI.CallProcedure(proc);
      HTuple tuple;
      int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
      int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out confidence);
      int err4 = HalconAPI.LoadS(proc, 2, err3, out word);
      int procResult = HalconAPI.LoadD(proc, 3, err4, out score);
      HalconAPI.PostCall(proc, procResult);
      GC.KeepAlive((object) this);
      GC.KeepAlive((object) character);
      GC.KeepAlive((object) image);
      return tuple;
    }

    /// <summary>
    ///   Classify a related group of characters with an CNN-based OCR classifier.
    ///   Instance represents: Handle of the OCR classifier.
    /// </summary>
    /// <param name="character">Characters to be recognized.</param>
    /// <param name="image">Gray values of the characters.</param>
    /// <param name="expression">Expression describing the allowed word structure.</param>
    /// <param name="numAlternatives">Number of classes per character considered for the internal word correction. Default: 3</param>
    /// <param name="numCorrections">Maximum number of corrected characters. Default: 2</param>
    /// <param name="confidence">Confidence of the class of the characters.</param>
    /// <param name="word">Word text after classification and correction.</param>
    /// <param name="score">Measure of similarity between corrected word and uncorrected classification results.</param>
    /// <returns>Result of classifying the characters with the CNN.</returns>
    public string DoOcrWordCnn(
      HRegion character,
      HImage image,
      string expression,
      int numAlternatives,
      int numCorrections,
      out double confidence,
      out string word,
      out double score)
    {
      IntPtr proc = HalconAPI.PreCall(2058);
      this.Store(proc, 0);
      HalconAPI.Store(proc, 1, (HObjectBase) character);
      HalconAPI.Store(proc, 2, (HObjectBase) image);
      HalconAPI.StoreS(proc, 1, expression);
      HalconAPI.StoreI(proc, 2, numAlternatives);
      HalconAPI.StoreI(proc, 3, numCorrections);
      HalconAPI.InitOCT(proc, 0);
      HalconAPI.InitOCT(proc, 1);
      HalconAPI.InitOCT(proc, 2);
      HalconAPI.InitOCT(proc, 3);
      int err1 = HalconAPI.CallProcedure(proc);
      string stringValue;
      int err2 = HalconAPI.LoadS(proc, 0, err1, out stringValue);
      int err3 = HalconAPI.LoadD(proc, 1, err2, out confidence);
      int err4 = HalconAPI.LoadS(proc, 2, err3, out word);
      int procResult = HalconAPI.LoadD(proc, 3, err4, out score);
      HalconAPI.PostCall(proc, procResult);
      GC.KeepAlive((object) this);
      GC.KeepAlive((object) character);
      GC.KeepAlive((object) image);
      return stringValue;
    }

    /// <summary>
    ///   Return the parameters of a CNN-based OCR classifier.
    ///   Instance represents: Handle of the OCR classifier.
    /// </summary>
    /// <param name="genParamName">A tuple of generic parameter names. Default: "characters"</param>
    /// <returns>A tuple of generic parameter values.</returns>
    public HTuple GetParamsOcrClassCnn(HTuple genParamName)
    {
      IntPtr proc = HalconAPI.PreCall(2072);
      this.Store(proc, 0);
      HalconAPI.Store(proc, 1, genParamName);
      HalconAPI.InitOCT(proc, 0);
      int err = HalconAPI.CallProcedure(proc);
      HalconAPI.UnpinTuple(genParamName);
      HTuple tuple;
      int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
      HalconAPI.PostCall(proc, procResult);
      GC.KeepAlive((object) this);
      return tuple;
    }

    /// <summary>
    ///   Return the parameters of a CNN-based OCR classifier.
    ///   Instance represents: Handle of the OCR classifier.
    /// </summary>
    /// <param name="genParamName">A tuple of generic parameter names. Default: "characters"</param>
    /// <returns>A tuple of generic parameter values.</returns>
    public HTuple GetParamsOcrClassCnn(string genParamName)
    {
      IntPtr proc = HalconAPI.PreCall(2072);
      this.Store(proc, 0);
      HalconAPI.StoreS(proc, 1, genParamName);
      HalconAPI.InitOCT(proc, 0);
      int err = HalconAPI.CallProcedure(proc);
      HTuple tuple;
      int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
      HalconAPI.PostCall(proc, procResult);
      GC.KeepAlive((object) this);
      return tuple;
    }

    /// <summary>
    ///   Get the names of the parameters that can be used in get_params_ocr_class_cnn for a given CNN-based OCR classifier.
    ///   Instance represents: Handle of OCR classifier.
    /// </summary>
    /// <returns>Names of the generic parameters.</returns>
    public HTuple QueryParamsOcrClassCnn()
    {
      IntPtr proc = HalconAPI.PreCall(2081);
      this.Store(proc, 0);
      HalconAPI.InitOCT(proc, 0);
      int err = HalconAPI.CallProcedure(proc);
      HTuple tuple;
      int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
      HalconAPI.PostCall(proc, procResult);
      GC.KeepAlive((object) this);
      return tuple;
    }

    /// <summary>
    ///   Read an CNN-based OCR classifier from a file.
    ///   Modified instance represents: Handle of the OCR classifier.
    /// </summary>
    /// <param name="fileName">File name. Default: "Universal_Rej.occ"</param>
    public void ReadOcrClassCnn(string fileName)
    {
      this.Dispose();
      IntPtr proc = HalconAPI.PreCall(2082);
      HalconAPI.StoreS(proc, 0, fileName);
      HalconAPI.InitOCT(proc, 0);
      int err = HalconAPI.CallProcedure(proc);
      int procResult = this.Load(proc, 0, err);
      HalconAPI.PostCall(proc, procResult);
      GC.KeepAlive((object) this);
    }

    /// <summary>
    ///   Serialize a CNN-based OCR classifier
    ///   Instance represents: Handle of the OCR classifier.
    /// </summary>
    /// <returns>Handle of the serialized item.</returns>
    public HSerializedItem SerializeOcrClassCnn()
    {
      IntPtr proc = HalconAPI.PreCall(2093);
      this.Store(proc, 0);
      HalconAPI.InitOCT(proc, 0);
      int err = HalconAPI.CallProcedure(proc);
      HSerializedItem hserializedItem;
      int procResult = HSerializedItem.LoadNew(proc, 0, err, out hserializedItem);
      HalconAPI.PostCall(proc, procResult);
      GC.KeepAlive((object) this);
      return hserializedItem;
    }

    protected override void ClearHandleResource()
    {
      IntPtr proc = HalconAPI.PreCall(2046);
      this.Store(proc, 0);
      int procResult = HalconAPI.CallProcedure(proc);
      HalconAPI.PostCall(proc, procResult);
      GC.KeepAlive((object) this);
    }
  }
}
