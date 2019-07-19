// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HShapeModel
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a shape model for matching.</summary>
    [Serializable]
    public class HShapeModel : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HShapeModel()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HShapeModel(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HShapeModel obj)
        {
            obj = new HShapeModel(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HShapeModel[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HShapeModel[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HShapeModel(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Read a shape model from a file.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public HShapeModel(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(917);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Prepare an anisotropically scaled shape model for matching from XLD contours.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="contours">Input contours that will be used to create the model.</param>
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
        public HShapeModel(
          HXLDCont contours,
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
            HalconAPI.Store(proc, 1, (HObjectBase)contours);
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
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contours);
        }

        /// <summary>
        ///   Prepare an anisotropically scaled shape model for matching from XLD contours.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="contours">Input contours that will be used to create the model.</param>
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
        public HShapeModel(
          HXLDCont contours,
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
            HalconAPI.Store(proc, 1, (HObjectBase)contours);
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
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contours);
        }

        /// <summary>
        ///   Prepare an isotropically scaled shape model for matching from XLD contours.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="contours">Input contours that will be used to create the model.</param>
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
        public HShapeModel(
          HXLDCont contours,
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
            HalconAPI.Store(proc, 1, (HObjectBase)contours);
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
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contours);
        }

        /// <summary>
        ///   Prepare an isotropically scaled shape model for matching from XLD contours.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="contours">Input contours that will be used to create the model.</param>
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
        public HShapeModel(
          HXLDCont contours,
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
            HalconAPI.Store(proc, 1, (HObjectBase)contours);
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
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contours);
        }

        /// <summary>
        ///   Prepare a shape model for matching from XLD contours.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="contours">Input contours that will be used to create the model.</param>
        /// <param name="numLevels">Maximum number of pyramid levels. Default: "auto"</param>
        /// <param name="angleStart">Smallest rotation of the pattern. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="angleStep">Step length of the angles (resolution). Default: "auto"</param>
        /// <param name="optimization">Kind of optimization and optionally method used for generating the model. Default: "auto"</param>
        /// <param name="metric">Match metric. Default: "ignore_local_polarity"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: 5</param>
        public HShapeModel(
          HXLDCont contours,
          HTuple numLevels,
          double angleStart,
          double angleExtent,
          HTuple angleStep,
          HTuple optimization,
          string metric,
          int minContrast)
        {
            IntPtr proc = HalconAPI.PreCall(937);
            HalconAPI.Store(proc, 1, (HObjectBase)contours);
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
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contours);
        }

        /// <summary>
        ///   Prepare a shape model for matching from XLD contours.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="contours">Input contours that will be used to create the model.</param>
        /// <param name="numLevels">Maximum number of pyramid levels. Default: "auto"</param>
        /// <param name="angleStart">Smallest rotation of the pattern. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="angleStep">Step length of the angles (resolution). Default: "auto"</param>
        /// <param name="optimization">Kind of optimization and optionally method used for generating the model. Default: "auto"</param>
        /// <param name="metric">Match metric. Default: "ignore_local_polarity"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: 5</param>
        public HShapeModel(
          HXLDCont contours,
          int numLevels,
          double angleStart,
          double angleExtent,
          double angleStep,
          string optimization,
          string metric,
          int minContrast)
        {
            IntPtr proc = HalconAPI.PreCall(937);
            HalconAPI.Store(proc, 1, (HObjectBase)contours);
            HalconAPI.StoreI(proc, 0, numLevels);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.StoreD(proc, 3, angleStep);
            HalconAPI.StoreS(proc, 4, optimization);
            HalconAPI.StoreS(proc, 5, metric);
            HalconAPI.StoreI(proc, 6, minContrast);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contours);
        }

        /// <summary>
        ///   Prepare an anisotropically scaled shape model for matching.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
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
        /// <param name="metric">Match metric. Default: "use_polarity"</param>
        /// <param name="contrast">Threshold or hysteresis thresholds for the contrast of the object in the template image and optionally minimum size of the object parts. Default: "auto"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: "auto"</param>
        public HShapeModel(
          HImage template,
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
          HTuple contrast,
          HTuple minContrast)
        {
            IntPtr proc = HalconAPI.PreCall(938);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
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
            HalconAPI.Store(proc, 12, contrast);
            HalconAPI.Store(proc, 13, minContrast);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(numLevels);
            HalconAPI.UnpinTuple(angleStep);
            HalconAPI.UnpinTuple(scaleRStep);
            HalconAPI.UnpinTuple(scaleCStep);
            HalconAPI.UnpinTuple(optimization);
            HalconAPI.UnpinTuple(contrast);
            HalconAPI.UnpinTuple(minContrast);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        /// <summary>
        ///   Prepare an anisotropically scaled shape model for matching.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
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
        /// <param name="metric">Match metric. Default: "use_polarity"</param>
        /// <param name="contrast">Threshold or hysteresis thresholds for the contrast of the object in the template image and optionally minimum size of the object parts. Default: "auto"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: "auto"</param>
        public HShapeModel(
          HImage template,
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
          int contrast,
          int minContrast)
        {
            IntPtr proc = HalconAPI.PreCall(938);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
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
            HalconAPI.StoreI(proc, 12, contrast);
            HalconAPI.StoreI(proc, 13, minContrast);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        /// <summary>
        ///   Prepare an isotropically scaled shape model for matching.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
        /// <param name="numLevels">Maximum number of pyramid levels. Default: "auto"</param>
        /// <param name="angleStart">Smallest rotation of the pattern. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="angleStep">Step length of the angles (resolution). Default: "auto"</param>
        /// <param name="scaleMin">Minimum scale of the pattern. Default: 0.9</param>
        /// <param name="scaleMax">Maximum scale of the pattern. Default: 1.1</param>
        /// <param name="scaleStep">Scale step length (resolution). Default: "auto"</param>
        /// <param name="optimization">Kind of optimization and optionally method used for generating the model. Default: "auto"</param>
        /// <param name="metric">Match metric. Default: "use_polarity"</param>
        /// <param name="contrast">Threshold or hysteresis thresholds for the contrast of the object in the template image and optionally minimum size of the object parts. Default: "auto"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: "auto"</param>
        public HShapeModel(
          HImage template,
          HTuple numLevels,
          double angleStart,
          double angleExtent,
          HTuple angleStep,
          double scaleMin,
          double scaleMax,
          HTuple scaleStep,
          HTuple optimization,
          string metric,
          HTuple contrast,
          HTuple minContrast)
        {
            IntPtr proc = HalconAPI.PreCall(939);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
            HalconAPI.Store(proc, 0, numLevels);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.Store(proc, 3, angleStep);
            HalconAPI.StoreD(proc, 4, scaleMin);
            HalconAPI.StoreD(proc, 5, scaleMax);
            HalconAPI.Store(proc, 6, scaleStep);
            HalconAPI.Store(proc, 7, optimization);
            HalconAPI.StoreS(proc, 8, metric);
            HalconAPI.Store(proc, 9, contrast);
            HalconAPI.Store(proc, 10, minContrast);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(numLevels);
            HalconAPI.UnpinTuple(angleStep);
            HalconAPI.UnpinTuple(scaleStep);
            HalconAPI.UnpinTuple(optimization);
            HalconAPI.UnpinTuple(contrast);
            HalconAPI.UnpinTuple(minContrast);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        /// <summary>
        ///   Prepare an isotropically scaled shape model for matching.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
        /// <param name="numLevels">Maximum number of pyramid levels. Default: "auto"</param>
        /// <param name="angleStart">Smallest rotation of the pattern. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="angleStep">Step length of the angles (resolution). Default: "auto"</param>
        /// <param name="scaleMin">Minimum scale of the pattern. Default: 0.9</param>
        /// <param name="scaleMax">Maximum scale of the pattern. Default: 1.1</param>
        /// <param name="scaleStep">Scale step length (resolution). Default: "auto"</param>
        /// <param name="optimization">Kind of optimization and optionally method used for generating the model. Default: "auto"</param>
        /// <param name="metric">Match metric. Default: "use_polarity"</param>
        /// <param name="contrast">Threshold or hysteresis thresholds for the contrast of the object in the template image and optionally minimum size of the object parts. Default: "auto"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: "auto"</param>
        public HShapeModel(
          HImage template,
          int numLevels,
          double angleStart,
          double angleExtent,
          double angleStep,
          double scaleMin,
          double scaleMax,
          double scaleStep,
          string optimization,
          string metric,
          int contrast,
          int minContrast)
        {
            IntPtr proc = HalconAPI.PreCall(939);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
            HalconAPI.StoreI(proc, 0, numLevels);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.StoreD(proc, 3, angleStep);
            HalconAPI.StoreD(proc, 4, scaleMin);
            HalconAPI.StoreD(proc, 5, scaleMax);
            HalconAPI.StoreD(proc, 6, scaleStep);
            HalconAPI.StoreS(proc, 7, optimization);
            HalconAPI.StoreS(proc, 8, metric);
            HalconAPI.StoreI(proc, 9, contrast);
            HalconAPI.StoreI(proc, 10, minContrast);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        /// <summary>
        ///   Prepare a shape model for matching.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
        /// <param name="numLevels">Maximum number of pyramid levels. Default: "auto"</param>
        /// <param name="angleStart">Smallest rotation of the pattern. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="angleStep">Step length of the angles (resolution). Default: "auto"</param>
        /// <param name="optimization">Kind of optimization and optionally method used for generating the model. Default: "auto"</param>
        /// <param name="metric">Match metric. Default: "use_polarity"</param>
        /// <param name="contrast">Threshold or hysteresis thresholds for the contrast of the object in the template image and optionally minimum size of the object parts. Default: "auto"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: "auto"</param>
        public HShapeModel(
          HImage template,
          HTuple numLevels,
          double angleStart,
          double angleExtent,
          HTuple angleStep,
          HTuple optimization,
          string metric,
          HTuple contrast,
          HTuple minContrast)
        {
            IntPtr proc = HalconAPI.PreCall(940);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
            HalconAPI.Store(proc, 0, numLevels);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.Store(proc, 3, angleStep);
            HalconAPI.Store(proc, 4, optimization);
            HalconAPI.StoreS(proc, 5, metric);
            HalconAPI.Store(proc, 6, contrast);
            HalconAPI.Store(proc, 7, minContrast);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(numLevels);
            HalconAPI.UnpinTuple(angleStep);
            HalconAPI.UnpinTuple(optimization);
            HalconAPI.UnpinTuple(contrast);
            HalconAPI.UnpinTuple(minContrast);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        /// <summary>
        ///   Prepare a shape model for matching.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
        /// <param name="numLevels">Maximum number of pyramid levels. Default: "auto"</param>
        /// <param name="angleStart">Smallest rotation of the pattern. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="angleStep">Step length of the angles (resolution). Default: "auto"</param>
        /// <param name="optimization">Kind of optimization and optionally method used for generating the model. Default: "auto"</param>
        /// <param name="metric">Match metric. Default: "use_polarity"</param>
        /// <param name="contrast">Threshold or hysteresis thresholds for the contrast of the object in the template image and optionally minimum size of the object parts. Default: "auto"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: "auto"</param>
        public HShapeModel(
          HImage template,
          int numLevels,
          double angleStart,
          double angleExtent,
          double angleStep,
          string optimization,
          string metric,
          int contrast,
          int minContrast)
        {
            IntPtr proc = HalconAPI.PreCall(940);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
            HalconAPI.StoreI(proc, 0, numLevels);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.StoreD(proc, 3, angleStep);
            HalconAPI.StoreS(proc, 4, optimization);
            HalconAPI.StoreS(proc, 5, metric);
            HalconAPI.StoreI(proc, 6, contrast);
            HalconAPI.StoreI(proc, 7, minContrast);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeShapeModel();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HShapeModel(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeShapeModel(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeShapeModel().Serialize(stream);
        }

        public static HShapeModel Deserialize(Stream stream)
        {
            HShapeModel hshapeModel = new HShapeModel();
            hshapeModel.DeserializeShapeModel(HSerializedItem.Deserialize(stream));
            return hshapeModel;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HShapeModel Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeShapeModel();
            HShapeModel hshapeModel = new HShapeModel();
            hshapeModel.DeserializeShapeModel(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hshapeModel;
        }

        /// <summary>
        ///   Deserialize a serialized shape model.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeShapeModel(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(916);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Read a shape model from a file.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void ReadShapeModel(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(917);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Serialize a shape model.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeShapeModel()
        {
            IntPtr proc = HalconAPI.PreCall(918);
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
        ///   Write a shape model to a file.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void WriteShapeModel(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(919);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Return the contour representation of a shape model.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="level">Pyramid level for which the contour representation should be returned. Default: 1</param>
        /// <returns>Contour representation of the shape model.</returns>
        public HXLDCont GetShapeModelContours(int level)
        {
            IntPtr proc = HalconAPI.PreCall(922);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, level);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Return the parameters of a shape model.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="angleStart">Smallest rotation of the pattern.</param>
        /// <param name="angleExtent">Extent of the rotation angles.</param>
        /// <param name="angleStep">Step length of the angles (resolution).</param>
        /// <param name="scaleMin">Minimum scale of the pattern.</param>
        /// <param name="scaleMax">Maximum scale of the pattern.</param>
        /// <param name="scaleStep">Scale step length (resolution).</param>
        /// <param name="metric">Match metric.</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images.</param>
        /// <returns>Number of pyramid levels.</returns>
        public int GetShapeModelParams(
          out double angleStart,
          out double angleExtent,
          out double angleStep,
          out HTuple scaleMin,
          out HTuple scaleMax,
          out HTuple scaleStep,
          out string metric,
          out int minContrast)
        {
            IntPtr proc = HalconAPI.PreCall(924);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            HalconAPI.InitOCT(proc, 6);
            HalconAPI.InitOCT(proc, 7);
            HalconAPI.InitOCT(proc, 8);
            int err1 = HalconAPI.CallProcedure(proc);
            int intValue;
            int err2 = HalconAPI.LoadI(proc, 0, err1, out intValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out angleStart);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out angleExtent);
            int err5 = HalconAPI.LoadD(proc, 3, err4, out angleStep);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out scaleMin);
            int err7 = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, err6, out scaleMax);
            int err8 = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, err7, out scaleStep);
            int err9 = HalconAPI.LoadS(proc, 7, err8, out metric);
            int procResult = HalconAPI.LoadI(proc, 8, err9, out minContrast);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Return the parameters of a shape model.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="angleStart">Smallest rotation of the pattern.</param>
        /// <param name="angleExtent">Extent of the rotation angles.</param>
        /// <param name="angleStep">Step length of the angles (resolution).</param>
        /// <param name="scaleMin">Minimum scale of the pattern.</param>
        /// <param name="scaleMax">Maximum scale of the pattern.</param>
        /// <param name="scaleStep">Scale step length (resolution).</param>
        /// <param name="metric">Match metric.</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images.</param>
        /// <returns>Number of pyramid levels.</returns>
        public int GetShapeModelParams(
          out double angleStart,
          out double angleExtent,
          out double angleStep,
          out double scaleMin,
          out double scaleMax,
          out double scaleStep,
          out string metric,
          out int minContrast)
        {
            IntPtr proc = HalconAPI.PreCall(924);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            HalconAPI.InitOCT(proc, 6);
            HalconAPI.InitOCT(proc, 7);
            HalconAPI.InitOCT(proc, 8);
            int err1 = HalconAPI.CallProcedure(proc);
            int intValue;
            int err2 = HalconAPI.LoadI(proc, 0, err1, out intValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out angleStart);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out angleExtent);
            int err5 = HalconAPI.LoadD(proc, 3, err4, out angleStep);
            int err6 = HalconAPI.LoadD(proc, 4, err5, out scaleMin);
            int err7 = HalconAPI.LoadD(proc, 5, err6, out scaleMax);
            int err8 = HalconAPI.LoadD(proc, 6, err7, out scaleStep);
            int err9 = HalconAPI.LoadS(proc, 7, err8, out metric);
            int procResult = HalconAPI.LoadI(proc, 8, err9, out minContrast);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Return the origin (reference point) of a shape model.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="row">Row coordinate of the origin of the shape model.</param>
        /// <param name="column">Column coordinate of the origin of the shape model.</param>
        public void GetShapeModelOrigin(out double row, out double column)
        {
            IntPtr proc = HalconAPI.PreCall(925);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out row);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out column);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set the origin (reference point) of a shape model.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="row">Row coordinate of the origin of the shape model.</param>
        /// <param name="column">Column coordinate of the origin of the shape model.</param>
        public void SetShapeModelOrigin(double row, double column)
        {
            IntPtr proc = HalconAPI.PreCall(926);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, row);
            HalconAPI.StoreD(proc, 2, column);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>Find the best matches of multiple anisotropically scaled shape models.</summary>
        /// <param name="image">Input image in which the models should be found.</param>
        /// <param name="modelIDs">Handle of the models.</param>
        /// <param name="angleStart">Smallest rotation of the models. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="scaleRMin">Minimum scale of the models in the row direction. Default: 0.9</param>
        /// <param name="scaleRMax">Maximum scale of the models in the row direction. Default: 1.1</param>
        /// <param name="scaleCMin">Minimum scale of the models in the column direction. Default: 0.9</param>
        /// <param name="scaleCMax">Maximum scale of the models in the column direction. Default: 1.1</param>
        /// <param name="minScore">Minimum score of the instances of the models to be found. Default: 0.5</param>
        /// <param name="numMatches">Number of instances of the models to be found (or 0 for all matches). Default: 1</param>
        /// <param name="maxOverlap">Maximum overlap of the instances of the models to be found. Default: 0.5</param>
        /// <param name="subPixel">Subpixel accuracy if not equal to 'none'. Default: "least_squares"</param>
        /// <param name="numLevels">Number of pyramid levels used in the matching (and lowest pyramid level to use if $|NumLevels| = 2$). Default: 0</param>
        /// <param name="greediness">"Greediness" of the search heuristic (0: safe but slow; 1: fast but matches may be missed). Default: 0.9</param>
        /// <param name="row">Row coordinate of the found instances of the models.</param>
        /// <param name="column">Column coordinate of the found instances of the models.</param>
        /// <param name="angle">Rotation angle of the found instances of the models.</param>
        /// <param name="scaleR">Scale of the found instances of the models in the row direction.</param>
        /// <param name="scaleC">Scale of the found instances of the models in the column direction.</param>
        /// <param name="score">Score of the found instances of the models.</param>
        /// <param name="model">Index of the found instances of the models.</param>
        public static void FindAnisoShapeModels(
          HImage image,
          HShapeModel[] modelIDs,
          HTuple angleStart,
          HTuple angleExtent,
          HTuple scaleRMin,
          HTuple scaleRMax,
          HTuple scaleCMin,
          HTuple scaleCMax,
          HTuple minScore,
          HTuple numMatches,
          HTuple maxOverlap,
          HTuple subPixel,
          HTuple numLevels,
          HTuple greediness,
          out HTuple row,
          out HTuple column,
          out HTuple angle,
          out HTuple scaleR,
          out HTuple scaleC,
          out HTuple score,
          out HTuple model)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])modelIDs);
            IntPtr proc = HalconAPI.PreCall(927);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.Store(proc, 1, angleStart);
            HalconAPI.Store(proc, 2, angleExtent);
            HalconAPI.Store(proc, 3, scaleRMin);
            HalconAPI.Store(proc, 4, scaleRMax);
            HalconAPI.Store(proc, 5, scaleCMin);
            HalconAPI.Store(proc, 6, scaleCMax);
            HalconAPI.Store(proc, 7, minScore);
            HalconAPI.Store(proc, 8, numMatches);
            HalconAPI.Store(proc, 9, maxOverlap);
            HalconAPI.Store(proc, 10, subPixel);
            HalconAPI.Store(proc, 11, numLevels);
            HalconAPI.Store(proc, 12, greediness);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            HalconAPI.InitOCT(proc, 6);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(angleStart);
            HalconAPI.UnpinTuple(angleExtent);
            HalconAPI.UnpinTuple(scaleRMin);
            HalconAPI.UnpinTuple(scaleRMax);
            HalconAPI.UnpinTuple(scaleCMin);
            HalconAPI.UnpinTuple(scaleCMax);
            HalconAPI.UnpinTuple(minScore);
            HalconAPI.UnpinTuple(numMatches);
            HalconAPI.UnpinTuple(maxOverlap);
            HalconAPI.UnpinTuple(subPixel);
            HalconAPI.UnpinTuple(numLevels);
            HalconAPI.UnpinTuple(greediness);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out column);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out angle);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out scaleR);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out scaleC);
            int err7 = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, err6, out score);
            int procResult = HTuple.LoadNew(proc, 6, HTupleType.INTEGER, err7, out model);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)modelIDs);
        }

        /// <summary>
        ///   Find the best matches of multiple anisotropically scaled shape models.
        ///   Instance represents: Handle of the models.
        /// </summary>
        /// <param name="image">Input image in which the models should be found.</param>
        /// <param name="angleStart">Smallest rotation of the models. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="scaleRMin">Minimum scale of the models in the row direction. Default: 0.9</param>
        /// <param name="scaleRMax">Maximum scale of the models in the row direction. Default: 1.1</param>
        /// <param name="scaleCMin">Minimum scale of the models in the column direction. Default: 0.9</param>
        /// <param name="scaleCMax">Maximum scale of the models in the column direction. Default: 1.1</param>
        /// <param name="minScore">Minimum score of the instances of the models to be found. Default: 0.5</param>
        /// <param name="numMatches">Number of instances of the models to be found (or 0 for all matches). Default: 1</param>
        /// <param name="maxOverlap">Maximum overlap of the instances of the models to be found. Default: 0.5</param>
        /// <param name="subPixel">Subpixel accuracy if not equal to 'none'. Default: "least_squares"</param>
        /// <param name="numLevels">Number of pyramid levels used in the matching (and lowest pyramid level to use if $|NumLevels| = 2$). Default: 0</param>
        /// <param name="greediness">"Greediness" of the search heuristic (0: safe but slow; 1: fast but matches may be missed). Default: 0.9</param>
        /// <param name="row">Row coordinate of the found instances of the models.</param>
        /// <param name="column">Column coordinate of the found instances of the models.</param>
        /// <param name="angle">Rotation angle of the found instances of the models.</param>
        /// <param name="scaleR">Scale of the found instances of the models in the row direction.</param>
        /// <param name="scaleC">Scale of the found instances of the models in the column direction.</param>
        /// <param name="score">Score of the found instances of the models.</param>
        /// <param name="model">Index of the found instances of the models.</param>
        public void FindAnisoShapeModels(
          HImage image,
          double angleStart,
          double angleExtent,
          double scaleRMin,
          double scaleRMax,
          double scaleCMin,
          double scaleCMax,
          double minScore,
          int numMatches,
          double maxOverlap,
          string subPixel,
          int numLevels,
          double greediness,
          out HTuple row,
          out HTuple column,
          out HTuple angle,
          out HTuple scaleR,
          out HTuple scaleC,
          out HTuple score,
          out HTuple model)
        {
            IntPtr proc = HalconAPI.PreCall(927);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.StoreD(proc, 3, scaleRMin);
            HalconAPI.StoreD(proc, 4, scaleRMax);
            HalconAPI.StoreD(proc, 5, scaleCMin);
            HalconAPI.StoreD(proc, 6, scaleCMax);
            HalconAPI.StoreD(proc, 7, minScore);
            HalconAPI.StoreI(proc, 8, numMatches);
            HalconAPI.StoreD(proc, 9, maxOverlap);
            HalconAPI.StoreS(proc, 10, subPixel);
            HalconAPI.StoreI(proc, 11, numLevels);
            HalconAPI.StoreD(proc, 12, greediness);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            HalconAPI.InitOCT(proc, 6);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out column);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out angle);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out scaleR);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out scaleC);
            int err7 = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, err6, out score);
            int procResult = HTuple.LoadNew(proc, 6, HTupleType.INTEGER, err7, out model);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>Find the best matches of multiple isotropically scaled shape models.</summary>
        /// <param name="image">Input image in which the models should be found.</param>
        /// <param name="modelIDs">Handle of the models.</param>
        /// <param name="angleStart">Smallest rotation of the models. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.78</param>
        /// <param name="scaleMin">Minimum scale of the models. Default: 0.9</param>
        /// <param name="scaleMax">Maximum scale of the models. Default: 1.1</param>
        /// <param name="minScore">Minimum score of the instances of the models to be found. Default: 0.5</param>
        /// <param name="numMatches">Number of instances of the models to be found (or 0 for all matches). Default: 1</param>
        /// <param name="maxOverlap">Maximum overlap of the instances of the models to be found. Default: 0.5</param>
        /// <param name="subPixel">Subpixel accuracy if not equal to 'none'. Default: "least_squares"</param>
        /// <param name="numLevels">Number of pyramid levels used in the matching (and lowest pyramid level to use if $|NumLevels| = 2$). Default: 0</param>
        /// <param name="greediness">"Greediness" of the search heuristic (0: safe but slow; 1: fast but matches may be missed). Default: 0.9</param>
        /// <param name="row">Row coordinate of the found instances of the models.</param>
        /// <param name="column">Column coordinate of the found instances of the models.</param>
        /// <param name="angle">Rotation angle of the found instances of the models.</param>
        /// <param name="scale">Scale of the found instances of the models.</param>
        /// <param name="score">Score of the found instances of the models.</param>
        /// <param name="model">Index of the found instances of the models.</param>
        public static void FindScaledShapeModels(
          HImage image,
          HShapeModel[] modelIDs,
          HTuple angleStart,
          HTuple angleExtent,
          HTuple scaleMin,
          HTuple scaleMax,
          HTuple minScore,
          HTuple numMatches,
          HTuple maxOverlap,
          HTuple subPixel,
          HTuple numLevels,
          HTuple greediness,
          out HTuple row,
          out HTuple column,
          out HTuple angle,
          out HTuple scale,
          out HTuple score,
          out HTuple model)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])modelIDs);
            IntPtr proc = HalconAPI.PreCall(928);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.Store(proc, 1, angleStart);
            HalconAPI.Store(proc, 2, angleExtent);
            HalconAPI.Store(proc, 3, scaleMin);
            HalconAPI.Store(proc, 4, scaleMax);
            HalconAPI.Store(proc, 5, minScore);
            HalconAPI.Store(proc, 6, numMatches);
            HalconAPI.Store(proc, 7, maxOverlap);
            HalconAPI.Store(proc, 8, subPixel);
            HalconAPI.Store(proc, 9, numLevels);
            HalconAPI.Store(proc, 10, greediness);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(angleStart);
            HalconAPI.UnpinTuple(angleExtent);
            HalconAPI.UnpinTuple(scaleMin);
            HalconAPI.UnpinTuple(scaleMax);
            HalconAPI.UnpinTuple(minScore);
            HalconAPI.UnpinTuple(numMatches);
            HalconAPI.UnpinTuple(maxOverlap);
            HalconAPI.UnpinTuple(subPixel);
            HalconAPI.UnpinTuple(numLevels);
            HalconAPI.UnpinTuple(greediness);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out column);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out angle);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out scale);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out score);
            int procResult = HTuple.LoadNew(proc, 5, HTupleType.INTEGER, err6, out model);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)modelIDs);
        }

        /// <summary>
        ///   Find the best matches of multiple isotropically scaled shape models.
        ///   Instance represents: Handle of the models.
        /// </summary>
        /// <param name="image">Input image in which the models should be found.</param>
        /// <param name="angleStart">Smallest rotation of the models. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.78</param>
        /// <param name="scaleMin">Minimum scale of the models. Default: 0.9</param>
        /// <param name="scaleMax">Maximum scale of the models. Default: 1.1</param>
        /// <param name="minScore">Minimum score of the instances of the models to be found. Default: 0.5</param>
        /// <param name="numMatches">Number of instances of the models to be found (or 0 for all matches). Default: 1</param>
        /// <param name="maxOverlap">Maximum overlap of the instances of the models to be found. Default: 0.5</param>
        /// <param name="subPixel">Subpixel accuracy if not equal to 'none'. Default: "least_squares"</param>
        /// <param name="numLevels">Number of pyramid levels used in the matching (and lowest pyramid level to use if $|NumLevels| = 2$). Default: 0</param>
        /// <param name="greediness">"Greediness" of the search heuristic (0: safe but slow; 1: fast but matches may be missed). Default: 0.9</param>
        /// <param name="row">Row coordinate of the found instances of the models.</param>
        /// <param name="column">Column coordinate of the found instances of the models.</param>
        /// <param name="angle">Rotation angle of the found instances of the models.</param>
        /// <param name="scale">Scale of the found instances of the models.</param>
        /// <param name="score">Score of the found instances of the models.</param>
        /// <param name="model">Index of the found instances of the models.</param>
        public void FindScaledShapeModels(
          HImage image,
          double angleStart,
          double angleExtent,
          double scaleMin,
          double scaleMax,
          double minScore,
          int numMatches,
          double maxOverlap,
          string subPixel,
          int numLevels,
          double greediness,
          out HTuple row,
          out HTuple column,
          out HTuple angle,
          out HTuple scale,
          out HTuple score,
          out HTuple model)
        {
            IntPtr proc = HalconAPI.PreCall(928);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.StoreD(proc, 3, scaleMin);
            HalconAPI.StoreD(proc, 4, scaleMax);
            HalconAPI.StoreD(proc, 5, minScore);
            HalconAPI.StoreI(proc, 6, numMatches);
            HalconAPI.StoreD(proc, 7, maxOverlap);
            HalconAPI.StoreS(proc, 8, subPixel);
            HalconAPI.StoreI(proc, 9, numLevels);
            HalconAPI.StoreD(proc, 10, greediness);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out column);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out angle);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out scale);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out score);
            int procResult = HTuple.LoadNew(proc, 5, HTupleType.INTEGER, err6, out model);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>Find the best matches of multiple shape models.</summary>
        /// <param name="image">Input image in which the models should be found.</param>
        /// <param name="modelIDs">Handle of the models.</param>
        /// <param name="angleStart">Smallest rotation of the models. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="minScore">Minimum score of the instances of the models to be found. Default: 0.5</param>
        /// <param name="numMatches">Number of instances of the models to be found (or 0 for all matches). Default: 1</param>
        /// <param name="maxOverlap">Maximum overlap of the instances of the models to be found. Default: 0.5</param>
        /// <param name="subPixel">Subpixel accuracy if not equal to 'none'. Default: "least_squares"</param>
        /// <param name="numLevels">Number of pyramid levels used in the matching (and lowest pyramid level to use if $|NumLevels| = 2$). Default: 0</param>
        /// <param name="greediness">"Greediness" of the search heuristic (0: safe but slow; 1: fast but matches may be missed). Default: 0.9</param>
        /// <param name="row">Row coordinate of the found instances of the models.</param>
        /// <param name="column">Column coordinate of the found instances of the models.</param>
        /// <param name="angle">Rotation angle of the found instances of the models.</param>
        /// <param name="score">Score of the found instances of the models.</param>
        /// <param name="model">Index of the found instances of the models.</param>
        public static void FindShapeModels(
          HImage image,
          HShapeModel[] modelIDs,
          HTuple angleStart,
          HTuple angleExtent,
          HTuple minScore,
          HTuple numMatches,
          HTuple maxOverlap,
          HTuple subPixel,
          HTuple numLevels,
          HTuple greediness,
          out HTuple row,
          out HTuple column,
          out HTuple angle,
          out HTuple score,
          out HTuple model)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])modelIDs);
            IntPtr proc = HalconAPI.PreCall(929);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.Store(proc, 1, angleStart);
            HalconAPI.Store(proc, 2, angleExtent);
            HalconAPI.Store(proc, 3, minScore);
            HalconAPI.Store(proc, 4, numMatches);
            HalconAPI.Store(proc, 5, maxOverlap);
            HalconAPI.Store(proc, 6, subPixel);
            HalconAPI.Store(proc, 7, numLevels);
            HalconAPI.Store(proc, 8, greediness);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(angleStart);
            HalconAPI.UnpinTuple(angleExtent);
            HalconAPI.UnpinTuple(minScore);
            HalconAPI.UnpinTuple(numMatches);
            HalconAPI.UnpinTuple(maxOverlap);
            HalconAPI.UnpinTuple(subPixel);
            HalconAPI.UnpinTuple(numLevels);
            HalconAPI.UnpinTuple(greediness);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out column);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out angle);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out score);
            int procResult = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, err5, out model);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)modelIDs);
        }

        /// <summary>
        ///   Find the best matches of multiple shape models.
        ///   Instance represents: Handle of the models.
        /// </summary>
        /// <param name="image">Input image in which the models should be found.</param>
        /// <param name="angleStart">Smallest rotation of the models. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="minScore">Minimum score of the instances of the models to be found. Default: 0.5</param>
        /// <param name="numMatches">Number of instances of the models to be found (or 0 for all matches). Default: 1</param>
        /// <param name="maxOverlap">Maximum overlap of the instances of the models to be found. Default: 0.5</param>
        /// <param name="subPixel">Subpixel accuracy if not equal to 'none'. Default: "least_squares"</param>
        /// <param name="numLevels">Number of pyramid levels used in the matching (and lowest pyramid level to use if $|NumLevels| = 2$). Default: 0</param>
        /// <param name="greediness">"Greediness" of the search heuristic (0: safe but slow; 1: fast but matches may be missed). Default: 0.9</param>
        /// <param name="row">Row coordinate of the found instances of the models.</param>
        /// <param name="column">Column coordinate of the found instances of the models.</param>
        /// <param name="angle">Rotation angle of the found instances of the models.</param>
        /// <param name="score">Score of the found instances of the models.</param>
        /// <param name="model">Index of the found instances of the models.</param>
        public void FindShapeModels(
          HImage image,
          double angleStart,
          double angleExtent,
          double minScore,
          int numMatches,
          double maxOverlap,
          string subPixel,
          int numLevels,
          double greediness,
          out HTuple row,
          out HTuple column,
          out HTuple angle,
          out HTuple score,
          out HTuple model)
        {
            IntPtr proc = HalconAPI.PreCall(929);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.StoreD(proc, 3, minScore);
            HalconAPI.StoreI(proc, 4, numMatches);
            HalconAPI.StoreD(proc, 5, maxOverlap);
            HalconAPI.StoreS(proc, 6, subPixel);
            HalconAPI.StoreI(proc, 7, numLevels);
            HalconAPI.StoreD(proc, 8, greediness);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out column);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out angle);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out score);
            int procResult = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, err5, out model);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Find the best matches of an anisotropically scaled shape model in an image.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="image">Input image in which the model should be found.</param>
        /// <param name="angleStart">Smallest rotation of the model. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="scaleRMin">Minimum scale of the model in the row direction. Default: 0.9</param>
        /// <param name="scaleRMax">Maximum scale of the model in the row direction. Default: 1.1</param>
        /// <param name="scaleCMin">Minimum scale of the model in the column direction. Default: 0.9</param>
        /// <param name="scaleCMax">Maximum scale of the model in the column direction. Default: 1.1</param>
        /// <param name="minScore">Minimum score of the instances of the model to be found. Default: 0.5</param>
        /// <param name="numMatches">Number of instances of the model to be found (or 0 for all matches). Default: 1</param>
        /// <param name="maxOverlap">Maximum overlap of the instances of the model to be found. Default: 0.5</param>
        /// <param name="subPixel">Subpixel accuracy if not equal to 'none'. Default: "least_squares"</param>
        /// <param name="numLevels">Number of pyramid levels used in the matching (and lowest pyramid level to use if $|NumLevels| = 2$). Default: 0</param>
        /// <param name="greediness">"Greediness" of the search heuristic (0: safe but slow; 1: fast but matches may be missed). Default: 0.9</param>
        /// <param name="row">Row coordinate of the found instances of the model.</param>
        /// <param name="column">Column coordinate of the found instances of the model.</param>
        /// <param name="angle">Rotation angle of the found instances of the model.</param>
        /// <param name="scaleR">Scale of the found instances of the model in the row direction.</param>
        /// <param name="scaleC">Scale of the found instances of the model in the column direction.</param>
        /// <param name="score">Score of the found instances of the model.</param>
        public void FindAnisoShapeModel(
          HImage image,
          double angleStart,
          double angleExtent,
          double scaleRMin,
          double scaleRMax,
          double scaleCMin,
          double scaleCMax,
          double minScore,
          int numMatches,
          double maxOverlap,
          HTuple subPixel,
          HTuple numLevels,
          double greediness,
          out HTuple row,
          out HTuple column,
          out HTuple angle,
          out HTuple scaleR,
          out HTuple scaleC,
          out HTuple score)
        {
            IntPtr proc = HalconAPI.PreCall(930);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.StoreD(proc, 3, scaleRMin);
            HalconAPI.StoreD(proc, 4, scaleRMax);
            HalconAPI.StoreD(proc, 5, scaleCMin);
            HalconAPI.StoreD(proc, 6, scaleCMax);
            HalconAPI.StoreD(proc, 7, minScore);
            HalconAPI.StoreI(proc, 8, numMatches);
            HalconAPI.StoreD(proc, 9, maxOverlap);
            HalconAPI.Store(proc, 10, subPixel);
            HalconAPI.Store(proc, 11, numLevels);
            HalconAPI.StoreD(proc, 12, greediness);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(subPixel);
            HalconAPI.UnpinTuple(numLevels);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out column);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out angle);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out scaleR);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out scaleC);
            int procResult = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, err6, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Find the best matches of an anisotropically scaled shape model in an image.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="image">Input image in which the model should be found.</param>
        /// <param name="angleStart">Smallest rotation of the model. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="scaleRMin">Minimum scale of the model in the row direction. Default: 0.9</param>
        /// <param name="scaleRMax">Maximum scale of the model in the row direction. Default: 1.1</param>
        /// <param name="scaleCMin">Minimum scale of the model in the column direction. Default: 0.9</param>
        /// <param name="scaleCMax">Maximum scale of the model in the column direction. Default: 1.1</param>
        /// <param name="minScore">Minimum score of the instances of the model to be found. Default: 0.5</param>
        /// <param name="numMatches">Number of instances of the model to be found (or 0 for all matches). Default: 1</param>
        /// <param name="maxOverlap">Maximum overlap of the instances of the model to be found. Default: 0.5</param>
        /// <param name="subPixel">Subpixel accuracy if not equal to 'none'. Default: "least_squares"</param>
        /// <param name="numLevels">Number of pyramid levels used in the matching (and lowest pyramid level to use if $|NumLevels| = 2$). Default: 0</param>
        /// <param name="greediness">"Greediness" of the search heuristic (0: safe but slow; 1: fast but matches may be missed). Default: 0.9</param>
        /// <param name="row">Row coordinate of the found instances of the model.</param>
        /// <param name="column">Column coordinate of the found instances of the model.</param>
        /// <param name="angle">Rotation angle of the found instances of the model.</param>
        /// <param name="scaleR">Scale of the found instances of the model in the row direction.</param>
        /// <param name="scaleC">Scale of the found instances of the model in the column direction.</param>
        /// <param name="score">Score of the found instances of the model.</param>
        public void FindAnisoShapeModel(
          HImage image,
          double angleStart,
          double angleExtent,
          double scaleRMin,
          double scaleRMax,
          double scaleCMin,
          double scaleCMax,
          double minScore,
          int numMatches,
          double maxOverlap,
          string subPixel,
          int numLevels,
          double greediness,
          out HTuple row,
          out HTuple column,
          out HTuple angle,
          out HTuple scaleR,
          out HTuple scaleC,
          out HTuple score)
        {
            IntPtr proc = HalconAPI.PreCall(930);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.StoreD(proc, 3, scaleRMin);
            HalconAPI.StoreD(proc, 4, scaleRMax);
            HalconAPI.StoreD(proc, 5, scaleCMin);
            HalconAPI.StoreD(proc, 6, scaleCMax);
            HalconAPI.StoreD(proc, 7, minScore);
            HalconAPI.StoreI(proc, 8, numMatches);
            HalconAPI.StoreD(proc, 9, maxOverlap);
            HalconAPI.StoreS(proc, 10, subPixel);
            HalconAPI.StoreI(proc, 11, numLevels);
            HalconAPI.StoreD(proc, 12, greediness);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out column);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out angle);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out scaleR);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out scaleC);
            int procResult = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, err6, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Find the best matches of an isotropically scaled shape model in an image.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="image">Input image in which the model should be found.</param>
        /// <param name="angleStart">Smallest rotation of the model. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.78</param>
        /// <param name="scaleMin">Minimum scale of the model. Default: 0.9</param>
        /// <param name="scaleMax">Maximum scale of the model. Default: 1.1</param>
        /// <param name="minScore">Minimum score of the instances of the model to be found. Default: 0.5</param>
        /// <param name="numMatches">Number of instances of the model to be found (or 0 for all matches). Default: 1</param>
        /// <param name="maxOverlap">Maximum overlap of the instances of the model to be found. Default: 0.5</param>
        /// <param name="subPixel">Subpixel accuracy if not equal to 'none'. Default: "least_squares"</param>
        /// <param name="numLevels">Number of pyramid levels used in the matching (and lowest pyramid level to use if $|NumLevels| = 2$). Default: 0</param>
        /// <param name="greediness">"Greediness" of the search heuristic (0: safe but slow; 1: fast but matches may be missed). Default: 0.9</param>
        /// <param name="row">Row coordinate of the found instances of the model.</param>
        /// <param name="column">Column coordinate of the found instances of the model.</param>
        /// <param name="angle">Rotation angle of the found instances of the model.</param>
        /// <param name="scale">Scale of the found instances of the model.</param>
        /// <param name="score">Score of the found instances of the model.</param>
        public void FindScaledShapeModel(
          HImage image,
          double angleStart,
          double angleExtent,
          double scaleMin,
          double scaleMax,
          double minScore,
          int numMatches,
          double maxOverlap,
          HTuple subPixel,
          HTuple numLevels,
          double greediness,
          out HTuple row,
          out HTuple column,
          out HTuple angle,
          out HTuple scale,
          out HTuple score)
        {
            IntPtr proc = HalconAPI.PreCall(931);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.StoreD(proc, 3, scaleMin);
            HalconAPI.StoreD(proc, 4, scaleMax);
            HalconAPI.StoreD(proc, 5, minScore);
            HalconAPI.StoreI(proc, 6, numMatches);
            HalconAPI.StoreD(proc, 7, maxOverlap);
            HalconAPI.Store(proc, 8, subPixel);
            HalconAPI.Store(proc, 9, numLevels);
            HalconAPI.StoreD(proc, 10, greediness);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(subPixel);
            HalconAPI.UnpinTuple(numLevels);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out column);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out angle);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out scale);
            int procResult = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Find the best matches of an isotropically scaled shape model in an image.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="image">Input image in which the model should be found.</param>
        /// <param name="angleStart">Smallest rotation of the model. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.78</param>
        /// <param name="scaleMin">Minimum scale of the model. Default: 0.9</param>
        /// <param name="scaleMax">Maximum scale of the model. Default: 1.1</param>
        /// <param name="minScore">Minimum score of the instances of the model to be found. Default: 0.5</param>
        /// <param name="numMatches">Number of instances of the model to be found (or 0 for all matches). Default: 1</param>
        /// <param name="maxOverlap">Maximum overlap of the instances of the model to be found. Default: 0.5</param>
        /// <param name="subPixel">Subpixel accuracy if not equal to 'none'. Default: "least_squares"</param>
        /// <param name="numLevels">Number of pyramid levels used in the matching (and lowest pyramid level to use if $|NumLevels| = 2$). Default: 0</param>
        /// <param name="greediness">"Greediness" of the search heuristic (0: safe but slow; 1: fast but matches may be missed). Default: 0.9</param>
        /// <param name="row">Row coordinate of the found instances of the model.</param>
        /// <param name="column">Column coordinate of the found instances of the model.</param>
        /// <param name="angle">Rotation angle of the found instances of the model.</param>
        /// <param name="scale">Scale of the found instances of the model.</param>
        /// <param name="score">Score of the found instances of the model.</param>
        public void FindScaledShapeModel(
          HImage image,
          double angleStart,
          double angleExtent,
          double scaleMin,
          double scaleMax,
          double minScore,
          int numMatches,
          double maxOverlap,
          string subPixel,
          int numLevels,
          double greediness,
          out HTuple row,
          out HTuple column,
          out HTuple angle,
          out HTuple scale,
          out HTuple score)
        {
            IntPtr proc = HalconAPI.PreCall(931);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.StoreD(proc, 3, scaleMin);
            HalconAPI.StoreD(proc, 4, scaleMax);
            HalconAPI.StoreD(proc, 5, minScore);
            HalconAPI.StoreI(proc, 6, numMatches);
            HalconAPI.StoreD(proc, 7, maxOverlap);
            HalconAPI.StoreS(proc, 8, subPixel);
            HalconAPI.StoreI(proc, 9, numLevels);
            HalconAPI.StoreD(proc, 10, greediness);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out column);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out angle);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out scale);
            int procResult = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Find the best matches of a shape model in an image.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="image">Input image in which the model should be found.</param>
        /// <param name="angleStart">Smallest rotation of the model. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="minScore">Minimum score of the instances of the model to be found. Default: 0.5</param>
        /// <param name="numMatches">Number of instances of the model to be found (or 0 for all matches). Default: 1</param>
        /// <param name="maxOverlap">Maximum overlap of the instances of the model to be found. Default: 0.5</param>
        /// <param name="subPixel">Subpixel accuracy if not equal to 'none'. Default: "least_squares"</param>
        /// <param name="numLevels">Number of pyramid levels used in the matching (and lowest pyramid level to use if $|NumLevels| = 2$). Default: 0</param>
        /// <param name="greediness">"Greediness" of the search heuristic (0: safe but slow; 1: fast but matches may be missed). Default: 0.9</param>
        /// <param name="row">Row coordinate of the found instances of the model.</param>
        /// <param name="column">Column coordinate of the found instances of the model.</param>
        /// <param name="angle">Rotation angle of the found instances of the model.</param>
        /// <param name="score">Score of the found instances of the model.</param>
        public void FindShapeModel(
          HImage image,
          double angleStart,
          double angleExtent,
          double minScore,
          int numMatches,
          double maxOverlap,
          HTuple subPixel,
          HTuple numLevels,
          double greediness,
          out HTuple row,
          out HTuple column,
          out HTuple angle,
          out HTuple score)
        {
            IntPtr proc = HalconAPI.PreCall(932);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.StoreD(proc, 3, minScore);
            HalconAPI.StoreI(proc, 4, numMatches);
            HalconAPI.StoreD(proc, 5, maxOverlap);
            HalconAPI.Store(proc, 6, subPixel);
            HalconAPI.Store(proc, 7, numLevels);
            HalconAPI.StoreD(proc, 8, greediness);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(subPixel);
            HalconAPI.UnpinTuple(numLevels);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out column);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out angle);
            int procResult = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Find the best matches of a shape model in an image.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="image">Input image in which the model should be found.</param>
        /// <param name="angleStart">Smallest rotation of the model. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="minScore">Minimum score of the instances of the model to be found. Default: 0.5</param>
        /// <param name="numMatches">Number of instances of the model to be found (or 0 for all matches). Default: 1</param>
        /// <param name="maxOverlap">Maximum overlap of the instances of the model to be found. Default: 0.5</param>
        /// <param name="subPixel">Subpixel accuracy if not equal to 'none'. Default: "least_squares"</param>
        /// <param name="numLevels">Number of pyramid levels used in the matching (and lowest pyramid level to use if $|NumLevels| = 2$). Default: 0</param>
        /// <param name="greediness">"Greediness" of the search heuristic (0: safe but slow; 1: fast but matches may be missed). Default: 0.9</param>
        /// <param name="row">Row coordinate of the found instances of the model.</param>
        /// <param name="column">Column coordinate of the found instances of the model.</param>
        /// <param name="angle">Rotation angle of the found instances of the model.</param>
        /// <param name="score">Score of the found instances of the model.</param>
        public void FindShapeModel(
          HImage image,
          double angleStart,
          double angleExtent,
          double minScore,
          int numMatches,
          double maxOverlap,
          string subPixel,
          int numLevels,
          double greediness,
          out HTuple row,
          out HTuple column,
          out HTuple angle,
          out HTuple score)
        {
            IntPtr proc = HalconAPI.PreCall(932);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.StoreD(proc, 3, minScore);
            HalconAPI.StoreI(proc, 4, numMatches);
            HalconAPI.StoreD(proc, 5, maxOverlap);
            HalconAPI.StoreS(proc, 6, subPixel);
            HalconAPI.StoreI(proc, 7, numLevels);
            HalconAPI.StoreD(proc, 8, greediness);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out column);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out angle);
            int procResult = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Set the metric of a shape model that was created from XLD contours.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="image">Input image used for the determination of the polarity.</param>
        /// <param name="homMat2D">Transformation matrix.</param>
        /// <param name="metric">Match metric. Default: "use_polarity"</param>
        public void SetShapeModelMetric(HImage image, HHomMat2D homMat2D, string metric)
        {
            IntPtr proc = HalconAPI.PreCall(933);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 1, (HData)homMat2D);
            HalconAPI.StoreS(proc, 2, metric);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)homMat2D));
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Set selected parameters of the shape model.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="genParamName">Parameter names.</param>
        /// <param name="genParamValue">Parameter values.</param>
        public void SetShapeModelParam(HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(934);
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
        ///   Prepare an anisotropically scaled shape model for matching from XLD contours.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="contours">Input contours that will be used to create the model.</param>
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
        public void CreateAnisoShapeModelXld(
          HXLDCont contours,
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
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(935);
            HalconAPI.Store(proc, 1, (HObjectBase)contours);
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
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contours);
        }

        /// <summary>
        ///   Prepare an anisotropically scaled shape model for matching from XLD contours.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="contours">Input contours that will be used to create the model.</param>
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
        public void CreateAnisoShapeModelXld(
          HXLDCont contours,
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
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(935);
            HalconAPI.Store(proc, 1, (HObjectBase)contours);
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
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contours);
        }

        /// <summary>
        ///   Prepare an isotropically scaled shape model for matching from XLD contours.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="contours">Input contours that will be used to create the model.</param>
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
        public void CreateScaledShapeModelXld(
          HXLDCont contours,
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
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(936);
            HalconAPI.Store(proc, 1, (HObjectBase)contours);
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
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contours);
        }

        /// <summary>
        ///   Prepare an isotropically scaled shape model for matching from XLD contours.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="contours">Input contours that will be used to create the model.</param>
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
        public void CreateScaledShapeModelXld(
          HXLDCont contours,
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
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(936);
            HalconAPI.Store(proc, 1, (HObjectBase)contours);
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
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contours);
        }

        /// <summary>
        ///   Prepare a shape model for matching from XLD contours.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="contours">Input contours that will be used to create the model.</param>
        /// <param name="numLevels">Maximum number of pyramid levels. Default: "auto"</param>
        /// <param name="angleStart">Smallest rotation of the pattern. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="angleStep">Step length of the angles (resolution). Default: "auto"</param>
        /// <param name="optimization">Kind of optimization and optionally method used for generating the model. Default: "auto"</param>
        /// <param name="metric">Match metric. Default: "ignore_local_polarity"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: 5</param>
        public void CreateShapeModelXld(
          HXLDCont contours,
          HTuple numLevels,
          double angleStart,
          double angleExtent,
          HTuple angleStep,
          HTuple optimization,
          string metric,
          int minContrast)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(937);
            HalconAPI.Store(proc, 1, (HObjectBase)contours);
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
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contours);
        }

        /// <summary>
        ///   Prepare a shape model for matching from XLD contours.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="contours">Input contours that will be used to create the model.</param>
        /// <param name="numLevels">Maximum number of pyramid levels. Default: "auto"</param>
        /// <param name="angleStart">Smallest rotation of the pattern. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="angleStep">Step length of the angles (resolution). Default: "auto"</param>
        /// <param name="optimization">Kind of optimization and optionally method used for generating the model. Default: "auto"</param>
        /// <param name="metric">Match metric. Default: "ignore_local_polarity"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: 5</param>
        public void CreateShapeModelXld(
          HXLDCont contours,
          int numLevels,
          double angleStart,
          double angleExtent,
          double angleStep,
          string optimization,
          string metric,
          int minContrast)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(937);
            HalconAPI.Store(proc, 1, (HObjectBase)contours);
            HalconAPI.StoreI(proc, 0, numLevels);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.StoreD(proc, 3, angleStep);
            HalconAPI.StoreS(proc, 4, optimization);
            HalconAPI.StoreS(proc, 5, metric);
            HalconAPI.StoreI(proc, 6, minContrast);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contours);
        }

        /// <summary>
        ///   Prepare an anisotropically scaled shape model for matching.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
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
        /// <param name="metric">Match metric. Default: "use_polarity"</param>
        /// <param name="contrast">Threshold or hysteresis thresholds for the contrast of the object in the template image and optionally minimum size of the object parts. Default: "auto"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: "auto"</param>
        public void CreateAnisoShapeModel(
          HImage template,
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
          HTuple contrast,
          HTuple minContrast)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(938);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
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
            HalconAPI.Store(proc, 12, contrast);
            HalconAPI.Store(proc, 13, minContrast);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(numLevels);
            HalconAPI.UnpinTuple(angleStep);
            HalconAPI.UnpinTuple(scaleRStep);
            HalconAPI.UnpinTuple(scaleCStep);
            HalconAPI.UnpinTuple(optimization);
            HalconAPI.UnpinTuple(contrast);
            HalconAPI.UnpinTuple(minContrast);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        /// <summary>
        ///   Prepare an anisotropically scaled shape model for matching.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
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
        /// <param name="metric">Match metric. Default: "use_polarity"</param>
        /// <param name="contrast">Threshold or hysteresis thresholds for the contrast of the object in the template image and optionally minimum size of the object parts. Default: "auto"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: "auto"</param>
        public void CreateAnisoShapeModel(
          HImage template,
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
          int contrast,
          int minContrast)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(938);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
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
            HalconAPI.StoreI(proc, 12, contrast);
            HalconAPI.StoreI(proc, 13, minContrast);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        /// <summary>
        ///   Prepare an isotropically scaled shape model for matching.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
        /// <param name="numLevels">Maximum number of pyramid levels. Default: "auto"</param>
        /// <param name="angleStart">Smallest rotation of the pattern. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="angleStep">Step length of the angles (resolution). Default: "auto"</param>
        /// <param name="scaleMin">Minimum scale of the pattern. Default: 0.9</param>
        /// <param name="scaleMax">Maximum scale of the pattern. Default: 1.1</param>
        /// <param name="scaleStep">Scale step length (resolution). Default: "auto"</param>
        /// <param name="optimization">Kind of optimization and optionally method used for generating the model. Default: "auto"</param>
        /// <param name="metric">Match metric. Default: "use_polarity"</param>
        /// <param name="contrast">Threshold or hysteresis thresholds for the contrast of the object in the template image and optionally minimum size of the object parts. Default: "auto"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: "auto"</param>
        public void CreateScaledShapeModel(
          HImage template,
          HTuple numLevels,
          double angleStart,
          double angleExtent,
          HTuple angleStep,
          double scaleMin,
          double scaleMax,
          HTuple scaleStep,
          HTuple optimization,
          string metric,
          HTuple contrast,
          HTuple minContrast)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(939);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
            HalconAPI.Store(proc, 0, numLevels);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.Store(proc, 3, angleStep);
            HalconAPI.StoreD(proc, 4, scaleMin);
            HalconAPI.StoreD(proc, 5, scaleMax);
            HalconAPI.Store(proc, 6, scaleStep);
            HalconAPI.Store(proc, 7, optimization);
            HalconAPI.StoreS(proc, 8, metric);
            HalconAPI.Store(proc, 9, contrast);
            HalconAPI.Store(proc, 10, minContrast);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(numLevels);
            HalconAPI.UnpinTuple(angleStep);
            HalconAPI.UnpinTuple(scaleStep);
            HalconAPI.UnpinTuple(optimization);
            HalconAPI.UnpinTuple(contrast);
            HalconAPI.UnpinTuple(minContrast);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        /// <summary>
        ///   Prepare an isotropically scaled shape model for matching.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
        /// <param name="numLevels">Maximum number of pyramid levels. Default: "auto"</param>
        /// <param name="angleStart">Smallest rotation of the pattern. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="angleStep">Step length of the angles (resolution). Default: "auto"</param>
        /// <param name="scaleMin">Minimum scale of the pattern. Default: 0.9</param>
        /// <param name="scaleMax">Maximum scale of the pattern. Default: 1.1</param>
        /// <param name="scaleStep">Scale step length (resolution). Default: "auto"</param>
        /// <param name="optimization">Kind of optimization and optionally method used for generating the model. Default: "auto"</param>
        /// <param name="metric">Match metric. Default: "use_polarity"</param>
        /// <param name="contrast">Threshold or hysteresis thresholds for the contrast of the object in the template image and optionally minimum size of the object parts. Default: "auto"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: "auto"</param>
        public void CreateScaledShapeModel(
          HImage template,
          int numLevels,
          double angleStart,
          double angleExtent,
          double angleStep,
          double scaleMin,
          double scaleMax,
          double scaleStep,
          string optimization,
          string metric,
          int contrast,
          int minContrast)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(939);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
            HalconAPI.StoreI(proc, 0, numLevels);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.StoreD(proc, 3, angleStep);
            HalconAPI.StoreD(proc, 4, scaleMin);
            HalconAPI.StoreD(proc, 5, scaleMax);
            HalconAPI.StoreD(proc, 6, scaleStep);
            HalconAPI.StoreS(proc, 7, optimization);
            HalconAPI.StoreS(proc, 8, metric);
            HalconAPI.StoreI(proc, 9, contrast);
            HalconAPI.StoreI(proc, 10, minContrast);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        /// <summary>
        ///   Prepare a shape model for matching.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
        /// <param name="numLevels">Maximum number of pyramid levels. Default: "auto"</param>
        /// <param name="angleStart">Smallest rotation of the pattern. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="angleStep">Step length of the angles (resolution). Default: "auto"</param>
        /// <param name="optimization">Kind of optimization and optionally method used for generating the model. Default: "auto"</param>
        /// <param name="metric">Match metric. Default: "use_polarity"</param>
        /// <param name="contrast">Threshold or hysteresis thresholds for the contrast of the object in the template image and optionally minimum size of the object parts. Default: "auto"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: "auto"</param>
        public void CreateShapeModel(
          HImage template,
          HTuple numLevels,
          double angleStart,
          double angleExtent,
          HTuple angleStep,
          HTuple optimization,
          string metric,
          HTuple contrast,
          HTuple minContrast)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(940);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
            HalconAPI.Store(proc, 0, numLevels);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.Store(proc, 3, angleStep);
            HalconAPI.Store(proc, 4, optimization);
            HalconAPI.StoreS(proc, 5, metric);
            HalconAPI.Store(proc, 6, contrast);
            HalconAPI.Store(proc, 7, minContrast);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(numLevels);
            HalconAPI.UnpinTuple(angleStep);
            HalconAPI.UnpinTuple(optimization);
            HalconAPI.UnpinTuple(contrast);
            HalconAPI.UnpinTuple(minContrast);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        /// <summary>
        ///   Prepare a shape model for matching.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
        /// <param name="numLevels">Maximum number of pyramid levels. Default: "auto"</param>
        /// <param name="angleStart">Smallest rotation of the pattern. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="angleStep">Step length of the angles (resolution). Default: "auto"</param>
        /// <param name="optimization">Kind of optimization and optionally method used for generating the model. Default: "auto"</param>
        /// <param name="metric">Match metric. Default: "use_polarity"</param>
        /// <param name="contrast">Threshold or hysteresis thresholds for the contrast of the object in the template image and optionally minimum size of the object parts. Default: "auto"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: "auto"</param>
        public void CreateShapeModel(
          HImage template,
          int numLevels,
          double angleStart,
          double angleExtent,
          double angleStep,
          string optimization,
          string metric,
          int contrast,
          int minContrast)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(940);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
            HalconAPI.StoreI(proc, 0, numLevels);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.StoreD(proc, 3, angleStep);
            HalconAPI.StoreS(proc, 4, optimization);
            HalconAPI.StoreS(proc, 5, metric);
            HalconAPI.StoreI(proc, 6, contrast);
            HalconAPI.StoreI(proc, 7, minContrast);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(921);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
