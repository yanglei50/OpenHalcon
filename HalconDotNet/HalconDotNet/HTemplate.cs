// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HTemplate
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a template for gray value matching.</summary>
    [Serializable]
    public class HTemplate : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HTemplate()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HTemplate(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HTemplate obj)
        {
            obj = new HTemplate(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HTemplate[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HTemplate[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HTemplate(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Preparing a pattern for template matching with rotation.
        ///   Modified instance represents: Template number.
        /// </summary>
        /// <param name="template">Input image whose domain will be processed for the pattern matching.</param>
        /// <param name="numLevel">Maximal number of pyramid levels. Default: 4</param>
        /// <param name="angleStart">Smallest Rotation of the pattern. Default: -0.39</param>
        /// <param name="angleExtend">Maximum positive Extension of AngleStart. Default: 0.79</param>
        /// <param name="angleStep">Step rate (angle precision) of matching. Default: 0.0982</param>
        /// <param name="optimize">Kind of optimizing. Default: "sort"</param>
        /// <param name="grayValues">Kind of grayvalues. Default: "original"</param>
        public HTemplate(
          HImage template,
          int numLevel,
          double angleStart,
          double angleExtend,
          double angleStep,
          string optimize,
          string grayValues)
        {
            IntPtr proc = HalconAPI.PreCall(1488);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
            HalconAPI.StoreI(proc, 0, numLevel);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtend);
            HalconAPI.StoreD(proc, 3, angleStep);
            HalconAPI.StoreS(proc, 4, optimize);
            HalconAPI.StoreS(proc, 5, grayValues);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        /// <summary>
        ///   Preparing a pattern for template matching.
        ///   Modified instance represents: Template number.
        /// </summary>
        /// <param name="template">Input image whose domain will be processed for the pattern matching.</param>
        /// <param name="firstError">Not yet in use. Default: 255</param>
        /// <param name="numLevel">Maximal number of pyramid levels. Default: 4</param>
        /// <param name="optimize">Kind of optimizing. Default: "sort"</param>
        /// <param name="grayValues">Kind of grayvalues. Default: "original"</param>
        public HTemplate(
          HImage template,
          int firstError,
          int numLevel,
          string optimize,
          string grayValues)
        {
            IntPtr proc = HalconAPI.PreCall(1489);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
            HalconAPI.StoreI(proc, 0, firstError);
            HalconAPI.StoreI(proc, 1, numLevel);
            HalconAPI.StoreS(proc, 2, optimize);
            HalconAPI.StoreS(proc, 3, grayValues);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        /// <summary>
        ///   Reading a template from file.
        ///   Modified instance represents: Template number.
        /// </summary>
        /// <param name="fileName">file name.</param>
        public HTemplate(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1493);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeTemplate();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HTemplate(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeTemplate(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeTemplate().Serialize(stream);
        }

        public static HTemplate Deserialize(Stream stream)
        {
            HTemplate htemplate = new HTemplate();
            htemplate.DeserializeTemplate(HSerializedItem.Deserialize(stream));
            return htemplate;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HTemplate Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeTemplate();
            HTemplate htemplate = new HTemplate();
            htemplate.DeserializeTemplate(serializedItemHandle);
            serializedItemHandle.Dispose();
            return htemplate;
        }

        /// <summary>
        ///   Preparing a pattern for template matching with rotation.
        ///   Modified instance represents: Template number.
        /// </summary>
        /// <param name="template">Input image whose domain will be processed for the pattern matching.</param>
        /// <param name="numLevel">Maximal number of pyramid levels. Default: 4</param>
        /// <param name="angleStart">Smallest Rotation of the pattern. Default: -0.39</param>
        /// <param name="angleExtend">Maximum positive Extension of AngleStart. Default: 0.79</param>
        /// <param name="angleStep">Step rate (angle precision) of matching. Default: 0.0982</param>
        /// <param name="optimize">Kind of optimizing. Default: "sort"</param>
        /// <param name="grayValues">Kind of grayvalues. Default: "original"</param>
        public void CreateTemplateRot(
          HImage template,
          int numLevel,
          double angleStart,
          double angleExtend,
          double angleStep,
          string optimize,
          string grayValues)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1488);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
            HalconAPI.StoreI(proc, 0, numLevel);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtend);
            HalconAPI.StoreD(proc, 3, angleStep);
            HalconAPI.StoreS(proc, 4, optimize);
            HalconAPI.StoreS(proc, 5, grayValues);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        /// <summary>
        ///   Preparing a pattern for template matching.
        ///   Modified instance represents: Template number.
        /// </summary>
        /// <param name="template">Input image whose domain will be processed for the pattern matching.</param>
        /// <param name="firstError">Not yet in use. Default: 255</param>
        /// <param name="numLevel">Maximal number of pyramid levels. Default: 4</param>
        /// <param name="optimize">Kind of optimizing. Default: "sort"</param>
        /// <param name="grayValues">Kind of grayvalues. Default: "original"</param>
        public void CreateTemplate(
          HImage template,
          int firstError,
          int numLevel,
          string optimize,
          string grayValues)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1489);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
            HalconAPI.StoreI(proc, 0, firstError);
            HalconAPI.StoreI(proc, 1, numLevel);
            HalconAPI.StoreS(proc, 2, optimize);
            HalconAPI.StoreS(proc, 3, grayValues);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        /// <summary>
        ///   Serialize a template.
        ///   Instance represents: Handle of the template.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeTemplate()
        {
            IntPtr proc = HalconAPI.PreCall(1490);
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
        ///   Deserialize a serialized template.
        ///   Modified instance represents: Template number.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeTemplate(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1491);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Writing a template to file.
        ///   Instance represents: Template number.
        /// </summary>
        /// <param name="fileName">file name.</param>
        public void WriteTemplate(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1492);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Reading a template from file.
        ///   Modified instance represents: Template number.
        /// </summary>
        /// <param name="fileName">file name.</param>
        public void ReadTemplate(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1493);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Gray value offset for template.
        ///   Instance represents: Template number.
        /// </summary>
        /// <param name="grayOffset">Offset of gray values. Default: 0</param>
        public void SetOffsetTemplate(int grayOffset)
        {
            IntPtr proc = HalconAPI.PreCall(1496);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, grayOffset);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Define reference position for a matching template.
        ///   Instance represents: Template number.
        /// </summary>
        /// <param name="row">Reference position of template (row).</param>
        /// <param name="column">Reference position of template (column).</param>
        public void SetReferenceTemplate(double row, double column)
        {
            IntPtr proc = HalconAPI.PreCall(1497);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, row);
            HalconAPI.StoreD(proc, 2, column);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Adapting a template to the size of an image.
        ///   Instance represents: Template number.
        /// </summary>
        /// <param name="image">Image which determines the size of the later matching.</param>
        public void AdaptTemplate(HImage image)
        {
            IntPtr proc = HalconAPI.PreCall(1498);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Searching all good grayvalue matches in a pyramid.
        ///   Instance represents: Template number.
        /// </summary>
        /// <param name="image">Input image inside of which the pattern has to be found.</param>
        /// <param name="maxError">Maximal average difference of the grayvalues. Default: 30.0</param>
        /// <param name="numLevel">Number of levels in the pyramid. Default: 3</param>
        /// <returns>All points which have an error below a certain threshold.</returns>
        public HRegion FastMatchMg(HImage image, double maxError, HTuple numLevel)
        {
            IntPtr proc = HalconAPI.PreCall(1499);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 1, maxError);
            HalconAPI.Store(proc, 2, numLevel);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(numLevel);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return hregion;
        }

        /// <summary>
        ///   Searching all good grayvalue matches in a pyramid.
        ///   Instance represents: Template number.
        /// </summary>
        /// <param name="image">Input image inside of which the pattern has to be found.</param>
        /// <param name="maxError">Maximal average difference of the grayvalues. Default: 30.0</param>
        /// <param name="numLevel">Number of levels in the pyramid. Default: 3</param>
        /// <returns>All points which have an error below a certain threshold.</returns>
        public HRegion FastMatchMg(HImage image, double maxError, int numLevel)
        {
            IntPtr proc = HalconAPI.PreCall(1499);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 1, maxError);
            HalconAPI.StoreI(proc, 2, numLevel);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return hregion;
        }

        /// <summary>
        ///   Searching the best grayvalue matches in a pre generated pyramid.
        ///   Instance represents: Template number.
        /// </summary>
        /// <param name="imagePyramid">Image pyramid inside of which the pattern has to be found.</param>
        /// <param name="maxError">Maximal average difference of the grayvalues. Default: 30.0</param>
        /// <param name="subPixel">Exactness in subpixels in case of 'true'. Default: "false"</param>
        /// <param name="numLevels">Number of the used resolution levels. Default: 3</param>
        /// <param name="whichLevels">Resolution level up to which the method "best match" is used. Default: "original"</param>
        /// <param name="row">Row position of the best match.</param>
        /// <param name="column">Column position of the best match.</param>
        /// <param name="error">Average divergence of the grayvalues in the best match.</param>
        public void BestMatchPreMg(
          HImage imagePyramid,
          double maxError,
          string subPixel,
          int numLevels,
          HTuple whichLevels,
          out double row,
          out double column,
          out double error)
        {
            IntPtr proc = HalconAPI.PreCall(1500);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)imagePyramid);
            HalconAPI.StoreD(proc, 1, maxError);
            HalconAPI.StoreS(proc, 2, subPixel);
            HalconAPI.StoreI(proc, 3, numLevels);
            HalconAPI.Store(proc, 4, whichLevels);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(whichLevels);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out row);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out column);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out error);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)imagePyramid);
        }

        /// <summary>
        ///   Searching the best grayvalue matches in a pre generated pyramid.
        ///   Instance represents: Template number.
        /// </summary>
        /// <param name="imagePyramid">Image pyramid inside of which the pattern has to be found.</param>
        /// <param name="maxError">Maximal average difference of the grayvalues. Default: 30.0</param>
        /// <param name="subPixel">Exactness in subpixels in case of 'true'. Default: "false"</param>
        /// <param name="numLevels">Number of the used resolution levels. Default: 3</param>
        /// <param name="whichLevels">Resolution level up to which the method "best match" is used. Default: "original"</param>
        /// <param name="row">Row position of the best match.</param>
        /// <param name="column">Column position of the best match.</param>
        /// <param name="error">Average divergence of the grayvalues in the best match.</param>
        public void BestMatchPreMg(
          HImage imagePyramid,
          double maxError,
          string subPixel,
          int numLevels,
          int whichLevels,
          out double row,
          out double column,
          out double error)
        {
            IntPtr proc = HalconAPI.PreCall(1500);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)imagePyramid);
            HalconAPI.StoreD(proc, 1, maxError);
            HalconAPI.StoreS(proc, 2, subPixel);
            HalconAPI.StoreI(proc, 3, numLevels);
            HalconAPI.StoreI(proc, 4, whichLevels);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out row);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out column);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out error);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)imagePyramid);
        }

        /// <summary>
        ///   Searching the best grayvalue matches in a pyramid.
        ///   Instance represents: Template number.
        /// </summary>
        /// <param name="image">Input image inside of which the pattern has to be found.</param>
        /// <param name="maxError">Maximal average difference of the grayvalues. Default: 30.0</param>
        /// <param name="subPixel">Exactness in subpixels in case of 'true'. Default: "false"</param>
        /// <param name="numLevels">Number of the used resolution levels. Default: 4</param>
        /// <param name="whichLevels">Resolution level up to which the method "best match" is used. Default: 2</param>
        /// <param name="row">Row position of the best match.</param>
        /// <param name="column">Column position of the best match.</param>
        /// <param name="error">Average divergence of the grayvalues in the best match.</param>
        public void BestMatchMg(
          HImage image,
          double maxError,
          string subPixel,
          int numLevels,
          HTuple whichLevels,
          out double row,
          out double column,
          out double error)
        {
            IntPtr proc = HalconAPI.PreCall(1501);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 1, maxError);
            HalconAPI.StoreS(proc, 2, subPixel);
            HalconAPI.StoreI(proc, 3, numLevels);
            HalconAPI.Store(proc, 4, whichLevels);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(whichLevels);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out row);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out column);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out error);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Searching the best grayvalue matches in a pyramid.
        ///   Instance represents: Template number.
        /// </summary>
        /// <param name="image">Input image inside of which the pattern has to be found.</param>
        /// <param name="maxError">Maximal average difference of the grayvalues. Default: 30.0</param>
        /// <param name="subPixel">Exactness in subpixels in case of 'true'. Default: "false"</param>
        /// <param name="numLevels">Number of the used resolution levels. Default: 4</param>
        /// <param name="whichLevels">Resolution level up to which the method "best match" is used. Default: 2</param>
        /// <param name="row">Row position of the best match.</param>
        /// <param name="column">Column position of the best match.</param>
        /// <param name="error">Average divergence of the grayvalues in the best match.</param>
        public void BestMatchMg(
          HImage image,
          double maxError,
          string subPixel,
          int numLevels,
          int whichLevels,
          out double row,
          out double column,
          out double error)
        {
            IntPtr proc = HalconAPI.PreCall(1501);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 1, maxError);
            HalconAPI.StoreS(proc, 2, subPixel);
            HalconAPI.StoreI(proc, 3, numLevels);
            HalconAPI.StoreI(proc, 4, whichLevels);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out row);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out column);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out error);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Searching all good matches of a template and an image.
        ///   Instance represents: Template number.
        /// </summary>
        /// <param name="image">Input image inside of which the pattern has to be found.</param>
        /// <param name="maxError">Maximal average difference of the grayvalues. Default: 20.0</param>
        /// <returns>All points whose error lies below a certain threshold.</returns>
        public HRegion FastMatch(HImage image, double maxError)
        {
            IntPtr proc = HalconAPI.PreCall(1502);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 1, maxError);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return hregion;
        }

        /// <summary>
        ///   Searching the best matching of a template and a pyramid with rotation.
        ///   Instance represents: Template number.
        /// </summary>
        /// <param name="image">Input image inside of which the pattern has to be found.</param>
        /// <param name="angleStart">Smallest Rotation of the pattern. Default: -0.39</param>
        /// <param name="angleExtend">Maximum positive Extension of AngleStart. Default: 0.79</param>
        /// <param name="maxError">Maximum average difference of the grayvalues. Default: 40.0</param>
        /// <param name="subPixel">Subpixel accuracy in case of 'true'. Default: "false"</param>
        /// <param name="numLevels">Number of the used resolution levels. Default: 3</param>
        /// <param name="row">Row position of the best match.</param>
        /// <param name="column">Column position of the best match.</param>
        /// <param name="angle">Rotation angle of pattern.</param>
        /// <param name="error">Average divergence of the grayvalues of the best match.</param>
        public void BestMatchRotMg(
          HImage image,
          double angleStart,
          double angleExtend,
          double maxError,
          string subPixel,
          int numLevels,
          out HTuple row,
          out HTuple column,
          out HTuple angle,
          out HTuple error)
        {
            IntPtr proc = HalconAPI.PreCall(1503);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtend);
            HalconAPI.StoreD(proc, 3, maxError);
            HalconAPI.StoreS(proc, 4, subPixel);
            HalconAPI.StoreI(proc, 5, numLevels);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out column);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out angle);
            int procResult = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out error);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Searching the best matching of a template and a pyramid with rotation.
        ///   Instance represents: Template number.
        /// </summary>
        /// <param name="image">Input image inside of which the pattern has to be found.</param>
        /// <param name="angleStart">Smallest Rotation of the pattern. Default: -0.39</param>
        /// <param name="angleExtend">Maximum positive Extension of AngleStart. Default: 0.79</param>
        /// <param name="maxError">Maximum average difference of the grayvalues. Default: 40.0</param>
        /// <param name="subPixel">Subpixel accuracy in case of 'true'. Default: "false"</param>
        /// <param name="numLevels">Number of the used resolution levels. Default: 3</param>
        /// <param name="row">Row position of the best match.</param>
        /// <param name="column">Column position of the best match.</param>
        /// <param name="angle">Rotation angle of pattern.</param>
        /// <param name="error">Average divergence of the grayvalues of the best match.</param>
        public void BestMatchRotMg(
          HImage image,
          double angleStart,
          double angleExtend,
          double maxError,
          string subPixel,
          int numLevels,
          out double row,
          out double column,
          out double angle,
          out double error)
        {
            IntPtr proc = HalconAPI.PreCall(1503);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtend);
            HalconAPI.StoreD(proc, 3, maxError);
            HalconAPI.StoreS(proc, 4, subPixel);
            HalconAPI.StoreI(proc, 5, numLevels);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out row);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out column);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out angle);
            int procResult = HalconAPI.LoadD(proc, 3, err4, out error);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Searching the best matching of a template and an image with rotation.
        ///   Instance represents: Template number.
        /// </summary>
        /// <param name="image">Input image inside of which the pattern has to be found.</param>
        /// <param name="angleStart">Smallest Rotation of the pattern. Default: -0.39</param>
        /// <param name="angleExtend">Maximum positive Extension of AngleStart. Default: 0.79</param>
        /// <param name="maxError">Maximum average difference of the grayvalues. Default: 30.0</param>
        /// <param name="subPixel">Subpixel accuracy in case of 'true'. Default: "false"</param>
        /// <param name="row">Row position of the best match.</param>
        /// <param name="column">Column position of the best match.</param>
        /// <param name="angle">Rotation angle of pattern.</param>
        /// <param name="error">Average divergence of the grayvalues of the best match.</param>
        public void BestMatchRot(
          HImage image,
          double angleStart,
          double angleExtend,
          double maxError,
          string subPixel,
          out HTuple row,
          out HTuple column,
          out HTuple angle,
          out HTuple error)
        {
            IntPtr proc = HalconAPI.PreCall(1504);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtend);
            HalconAPI.StoreD(proc, 3, maxError);
            HalconAPI.StoreS(proc, 4, subPixel);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out column);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out angle);
            int procResult = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out error);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Searching the best matching of a template and an image with rotation.
        ///   Instance represents: Template number.
        /// </summary>
        /// <param name="image">Input image inside of which the pattern has to be found.</param>
        /// <param name="angleStart">Smallest Rotation of the pattern. Default: -0.39</param>
        /// <param name="angleExtend">Maximum positive Extension of AngleStart. Default: 0.79</param>
        /// <param name="maxError">Maximum average difference of the grayvalues. Default: 30.0</param>
        /// <param name="subPixel">Subpixel accuracy in case of 'true'. Default: "false"</param>
        /// <param name="row">Row position of the best match.</param>
        /// <param name="column">Column position of the best match.</param>
        /// <param name="angle">Rotation angle of pattern.</param>
        /// <param name="error">Average divergence of the grayvalues of the best match.</param>
        public void BestMatchRot(
          HImage image,
          double angleStart,
          double angleExtend,
          double maxError,
          string subPixel,
          out double row,
          out double column,
          out double angle,
          out double error)
        {
            IntPtr proc = HalconAPI.PreCall(1504);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtend);
            HalconAPI.StoreD(proc, 3, maxError);
            HalconAPI.StoreS(proc, 4, subPixel);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out row);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out column);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out angle);
            int procResult = HalconAPI.LoadD(proc, 3, err4, out error);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Searching the best matching of a template and an image.
        ///   Instance represents: Template number.
        /// </summary>
        /// <param name="image">Input image inside of which the pattern has to be found.</param>
        /// <param name="maxError">Maximum average difference of the grayvalues. Default: 20.0</param>
        /// <param name="subPixel">Subpixel accuracy in case of 'true'. Default: "false"</param>
        /// <param name="row">Row position of the best match.</param>
        /// <param name="column">Column position of the best match.</param>
        /// <param name="error">Average divergence of the grayvalues of the best match.</param>
        public void BestMatch(
          HImage image,
          double maxError,
          string subPixel,
          out HTuple row,
          out HTuple column,
          out HTuple error)
        {
            IntPtr proc = HalconAPI.PreCall(1505);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 1, maxError);
            HalconAPI.StoreS(proc, 2, subPixel);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out column);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out error);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Searching the best matching of a template and an image.
        ///   Instance represents: Template number.
        /// </summary>
        /// <param name="image">Input image inside of which the pattern has to be found.</param>
        /// <param name="maxError">Maximum average difference of the grayvalues. Default: 20.0</param>
        /// <param name="subPixel">Subpixel accuracy in case of 'true'. Default: "false"</param>
        /// <param name="row">Row position of the best match.</param>
        /// <param name="column">Column position of the best match.</param>
        /// <param name="error">Average divergence of the grayvalues of the best match.</param>
        public void BestMatch(
          HImage image,
          double maxError,
          string subPixel,
          out double row,
          out double column,
          out double error)
        {
            IntPtr proc = HalconAPI.PreCall(1505);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 1, maxError);
            HalconAPI.StoreS(proc, 2, subPixel);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out row);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out column);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out error);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(1495);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
