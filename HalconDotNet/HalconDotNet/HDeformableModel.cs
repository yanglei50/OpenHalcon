// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HDeformableModel
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a deformable model for matching.</summary>
    [Serializable]
    public class HDeformableModel : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HDeformableModel()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HDeformableModel(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HDeformableModel obj)
        {
            obj = new HDeformableModel(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HDeformableModel[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HDeformableModel[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HDeformableModel(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Read a deformable model from a file.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public HDeformableModel(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(965);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Prepare a deformable model for planar calibrated matching from XLD contours.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="contours">Input contours that will be used to create the model.</param>
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
        public HDeformableModel(
          HXLDCont contours,
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
            HalconAPI.Store(proc, 1, (HObjectBase)contours);
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
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contours);
        }

        /// <summary>
        ///   Prepare a deformable model for planar calibrated matching from XLD contours.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="contours">Input contours that will be used to create the model.</param>
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
        public HDeformableModel(
          HXLDCont contours,
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
            HalconAPI.Store(proc, 1, (HObjectBase)contours);
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
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contours);
        }

        /// <summary>
        ///   Prepare a deformable model for planar uncalibrated matching from XLD contours.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="contours">Input contours that will be used to create the model.</param>
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
        public HDeformableModel(
          HXLDCont contours,
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
            HalconAPI.Store(proc, 1, (HObjectBase)contours);
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
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contours);
        }

        /// <summary>
        ///   Prepare a deformable model for planar uncalibrated matching from XLD contours.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="contours">Input contours that will be used to create the model.</param>
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
        public HDeformableModel(
          HXLDCont contours,
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
            HalconAPI.Store(proc, 1, (HObjectBase)contours);
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
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contours);
        }

        /// <summary>
        ///   Create a deformable model for calibrated perspective matching.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
        /// <param name="camParam">The parameters of the internal orientation of the camera.</param>
        /// <param name="referencePose">The reference pose of the object in the reference image.</param>
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
        /// <param name="optimization">Kind of optimization used for generating the model. Default: "none"</param>
        /// <param name="metric">Match metric. Default: "use_polarity"</param>
        /// <param name="contrast">Thresholds or hysteresis thresholds for the contrast of the object in the template image. Default: "auto"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: "auto"</param>
        /// <param name="genParamName">The parameter names. Default: []</param>
        /// <param name="genParamValue">Values of the parameters. Default: []</param>
        public HDeformableModel(
          HImage template,
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
          HTuple contrast,
          HTuple minContrast,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(979);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
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
            HalconAPI.Store(proc, 14, contrast);
            HalconAPI.Store(proc, 15, minContrast);
            HalconAPI.Store(proc, 16, genParamName);
            HalconAPI.Store(proc, 17, genParamValue);
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
            HalconAPI.UnpinTuple(contrast);
            HalconAPI.UnpinTuple(minContrast);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        /// <summary>
        ///   Create a deformable model for calibrated perspective matching.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
        /// <param name="camParam">The parameters of the internal orientation of the camera.</param>
        /// <param name="referencePose">The reference pose of the object in the reference image.</param>
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
        /// <param name="optimization">Kind of optimization used for generating the model. Default: "none"</param>
        /// <param name="metric">Match metric. Default: "use_polarity"</param>
        /// <param name="contrast">Thresholds or hysteresis thresholds for the contrast of the object in the template image. Default: "auto"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: "auto"</param>
        /// <param name="genParamName">The parameter names. Default: []</param>
        /// <param name="genParamValue">Values of the parameters. Default: []</param>
        public HDeformableModel(
          HImage template,
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
          HTuple contrast,
          int minContrast,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(979);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
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
            HalconAPI.Store(proc, 14, contrast);
            HalconAPI.StoreI(proc, 15, minContrast);
            HalconAPI.Store(proc, 16, genParamName);
            HalconAPI.Store(proc, 17, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
            HalconAPI.UnpinTuple((HTuple)((HData)referencePose));
            HalconAPI.UnpinTuple(angleStart);
            HalconAPI.UnpinTuple(angleExtent);
            HalconAPI.UnpinTuple(scaleRMax);
            HalconAPI.UnpinTuple(scaleCMax);
            HalconAPI.UnpinTuple(contrast);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        /// <summary>
        ///   Creates a deformable model for uncalibrated, perspective matching.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
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
        /// <param name="optimization">Kind of optimization used for generating the model. Default: "none"</param>
        /// <param name="metric">Match metric. Default: "use_polarity"</param>
        /// <param name="contrast">Thresholds or hysteresis thresholds for the contrast of the object in the template image. Default: "auto"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: "auto"</param>
        /// <param name="genParamName">The generic parameter names. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameter. Default: []</param>
        public HDeformableModel(
          HImage template,
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
          HTuple contrast,
          HTuple minContrast,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(980);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
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
            HalconAPI.Store(proc, 12, contrast);
            HalconAPI.Store(proc, 13, minContrast);
            HalconAPI.Store(proc, 14, genParamName);
            HalconAPI.Store(proc, 15, genParamValue);
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
            HalconAPI.UnpinTuple(contrast);
            HalconAPI.UnpinTuple(minContrast);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        /// <summary>
        ///   Creates a deformable model for uncalibrated, perspective matching.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
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
        /// <param name="optimization">Kind of optimization used for generating the model. Default: "none"</param>
        /// <param name="metric">Match metric. Default: "use_polarity"</param>
        /// <param name="contrast">Thresholds or hysteresis thresholds for the contrast of the object in the template image. Default: "auto"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: "auto"</param>
        /// <param name="genParamName">The generic parameter names. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameter. Default: []</param>
        public HDeformableModel(
          HImage template,
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
          HTuple contrast,
          int minContrast,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(980);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
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
            HalconAPI.Store(proc, 12, contrast);
            HalconAPI.StoreI(proc, 13, minContrast);
            HalconAPI.Store(proc, 14, genParamName);
            HalconAPI.Store(proc, 15, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(angleStart);
            HalconAPI.UnpinTuple(angleExtent);
            HalconAPI.UnpinTuple(scaleRMax);
            HalconAPI.UnpinTuple(scaleCMax);
            HalconAPI.UnpinTuple(contrast);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeDeformableModel();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HDeformableModel(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeDeformableModel(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeDeformableModel().Serialize(stream);
        }

        public static HDeformableModel Deserialize(Stream stream)
        {
            HDeformableModel hdeformableModel = new HDeformableModel();
            hdeformableModel.DeserializeDeformableModel(HSerializedItem.Deserialize(stream));
            return hdeformableModel;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HDeformableModel Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeDeformableModel();
            HDeformableModel hdeformableModel = new HDeformableModel();
            hdeformableModel.DeserializeDeformableModel(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hdeformableModel;
        }

        /// <summary>
        ///   Return the origin (reference point) of a deformable model.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="row">Row coordinate of the origin of the deformable model.</param>
        /// <param name="column">Column coordinate of the origin of the deformable model.</param>
        public void GetDeformableModelOrigin(out double row, out double column)
        {
            IntPtr proc = HalconAPI.PreCall(957);
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
        ///   Set the origin (reference point) of a deformable model.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="row">Row coordinate of the origin of the deformable model.</param>
        /// <param name="column">Column coordinate of the origin of the deformable model.</param>
        public void SetDeformableModelOrigin(double row, double column)
        {
            IntPtr proc = HalconAPI.PreCall(958);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, row);
            HalconAPI.StoreD(proc, 2, column);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set selected parameters of the deformable model.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="genParamName">Parameter names.</param>
        /// <param name="genParamValue">Parameter values.</param>
        public void SetDeformableModelParam(HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(959);
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
        ///   Return the parameters of a deformable model.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters that are to be queried for the deformable model. Default: "angle_start"</param>
        /// <returns>Values of the generic parameters.</returns>
        public HTuple GetDeformableModelParams(HTuple genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(960);
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
        ///   Return the parameters of a deformable model.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters that are to be queried for the deformable model. Default: "angle_start"</param>
        /// <returns>Values of the generic parameters.</returns>
        public HTuple GetDeformableModelParams(string genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(960);
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
        ///   Return the contour representation of a deformable model.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="level">Pyramid level for which the contour representation should be returned. Default: 1</param>
        /// <returns>Contour representation of the deformable model.</returns>
        public HXLDCont GetDeformableModelContours(int level)
        {
            IntPtr proc = HalconAPI.PreCall(961);
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
        ///   Deserialize a deformable model.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeDeformableModel(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(963);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize a deformable model.
        ///   Instance represents: Handle of a model to be saved.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeDeformableModel()
        {
            IntPtr proc = HalconAPI.PreCall(964);
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
        ///   Read a deformable model from a file.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void ReadDeformableModel(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(965);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write a deformable model to a file.
        ///   Instance represents: Handle of a model to be saved.
        /// </summary>
        /// <param name="fileName">The path and filename of the model to be saved.</param>
        public void WriteDeformableModel(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(966);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Find the best matches of a local deformable model in an image.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="image">Input image in which the model should be found.</param>
        /// <param name="vectorField">Vector field of the rectification transformation.</param>
        /// <param name="deformedContours">Contours of the found instances of the model.</param>
        /// <param name="angleStart">Smallest rotation of the model. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.79</param>
        /// <param name="scaleRMin">Minimum scale of the model in row direction. Default: 1.0</param>
        /// <param name="scaleRMax">Maximum scale of the model in row direction. Default: 1.0</param>
        /// <param name="scaleCMin">Minimum scale of the model in column direction. Default: 1.0</param>
        /// <param name="scaleCMax">Maximum scale of the model in column direction. Default: 1.0</param>
        /// <param name="minScore">Minumum score of the instances of the model to be found. Default: 0.5</param>
        /// <param name="numMatches">Number of instances of the model to be found (or 0 for all matches). Default: 1</param>
        /// <param name="maxOverlap">Maximum overlap of the instances of the model to be found. Default: 1.0</param>
        /// <param name="numLevels">Number of pyramid levels used in the matching. Default: 0</param>
        /// <param name="greediness">"Greediness" of the search heuristic (0: safe but slow; 1: fast but matches may be missed). Default: 0.9</param>
        /// <param name="resultType">Switch for requested iconic result. Default: []</param>
        /// <param name="genParamName">The general parameter names. Default: []</param>
        /// <param name="genParamValue">Values of the general parameters. Default: []</param>
        /// <param name="score">Scores of the found instances of the model.</param>
        /// <param name="row">Row coordinates of the found instances of the model.</param>
        /// <param name="column">Column coordinates of the found instances of the model.</param>
        /// <returns>Rectified image of the found model.</returns>
        public HImage FindLocalDeformableModel(
          HImage image,
          out HImage vectorField,
          out HXLDCont deformedContours,
          double angleStart,
          double angleExtent,
          double scaleRMin,
          double scaleRMax,
          double scaleCMin,
          double scaleCMax,
          double minScore,
          int numMatches,
          double maxOverlap,
          int numLevels,
          double greediness,
          HTuple resultType,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple score,
          out HTuple row,
          out HTuple column)
        {
            IntPtr proc = HalconAPI.PreCall(969);
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
            HalconAPI.StoreI(proc, 10, numLevels);
            HalconAPI.StoreD(proc, 11, greediness);
            HalconAPI.Store(proc, 12, resultType);
            HalconAPI.Store(proc, 13, genParamName);
            HalconAPI.Store(proc, 14, genParamValue);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(resultType);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HImage himage;
            int err2 = HImage.LoadNew(proc, 1, err1, out himage);
            int err3 = HImage.LoadNew(proc, 2, err2, out vectorField);
            int err4 = HXLDCont.LoadNew(proc, 3, err3, out deformedContours);
            int err5 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err4, out score);
            int err6 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err5, out row);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err6, out column);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return himage;
        }

        /// <summary>
        ///   Find the best matches of a calibrated deformable model in an image and return their 3D pose.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="image">Input image in which the model should be found.</param>
        /// <param name="angleStart">Smallest rotation of the model. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.78</param>
        /// <param name="scaleRMin">Minimum scale of the model in row direction. Default: 1.0</param>
        /// <param name="scaleRMax">Maximum scale of the model in row direction. Default: 1.0</param>
        /// <param name="scaleCMin">Minimum scale of the model in column direction. Default: 1.0</param>
        /// <param name="scaleCMax">Maximum scale of the model in column direction. Default: 1.0</param>
        /// <param name="minScore">Minimum score of the instances of the model to be found. Default: 0.5</param>
        /// <param name="numMatches">Number of instances of the model to be found (or 0 for all matches). Default: 1</param>
        /// <param name="maxOverlap">Maximum overlap of the instances of the model to be found. Default: 1.0</param>
        /// <param name="numLevels">Number of pyramid levels used in the matching (and lowest pyramid level to use if $|NumLevels| = 2$). Default: 0</param>
        /// <param name="greediness">"Greediness" of the search heuristic (0: safe but slow; 1: fast but matches may be missed). Default: 0.9</param>
        /// <param name="genParamName">The general parameter names. Default: []</param>
        /// <param name="genParamValue">Values of the general parameters. Default: []</param>
        /// <param name="covPose">6 standard deviations or 36 covariances of the pose parameters.</param>
        /// <param name="score">Score of the found instances of the model.</param>
        /// <returns>Pose of the object.</returns>
        public HPose[] FindPlanarCalibDeformableModel(
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
          HTuple numLevels,
          double greediness,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple covPose,
          out HTuple score)
        {
            IntPtr proc = HalconAPI.PreCall(970);
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
            HalconAPI.Store(proc, 10, numLevels);
            HalconAPI.StoreD(proc, 11, greediness);
            HalconAPI.Store(proc, 12, genParamName);
            HalconAPI.Store(proc, 13, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(numLevels);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out covPose);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out score);
            HalconAPI.PostCall(proc, procResult);
            HPose[] hposeArray = HPose.SplitArray(tuple);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return hposeArray;
        }

        /// <summary>
        ///   Find the best matches of a calibrated deformable model in an image and return their 3D pose.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="image">Input image in which the model should be found.</param>
        /// <param name="angleStart">Smallest rotation of the model. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.78</param>
        /// <param name="scaleRMin">Minimum scale of the model in row direction. Default: 1.0</param>
        /// <param name="scaleRMax">Maximum scale of the model in row direction. Default: 1.0</param>
        /// <param name="scaleCMin">Minimum scale of the model in column direction. Default: 1.0</param>
        /// <param name="scaleCMax">Maximum scale of the model in column direction. Default: 1.0</param>
        /// <param name="minScore">Minimum score of the instances of the model to be found. Default: 0.5</param>
        /// <param name="numMatches">Number of instances of the model to be found (or 0 for all matches). Default: 1</param>
        /// <param name="maxOverlap">Maximum overlap of the instances of the model to be found. Default: 1.0</param>
        /// <param name="numLevels">Number of pyramid levels used in the matching (and lowest pyramid level to use if $|NumLevels| = 2$). Default: 0</param>
        /// <param name="greediness">"Greediness" of the search heuristic (0: safe but slow; 1: fast but matches may be missed). Default: 0.9</param>
        /// <param name="genParamName">The general parameter names. Default: []</param>
        /// <param name="genParamValue">Values of the general parameters. Default: []</param>
        /// <param name="covPose">6 standard deviations or 36 covariances of the pose parameters.</param>
        /// <param name="score">Score of the found instances of the model.</param>
        /// <returns>Pose of the object.</returns>
        public HPose FindPlanarCalibDeformableModel(
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
          int numLevels,
          double greediness,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple covPose,
          out HTuple score)
        {
            IntPtr proc = HalconAPI.PreCall(970);
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
            HalconAPI.StoreI(proc, 10, numLevels);
            HalconAPI.StoreD(proc, 11, greediness);
            HalconAPI.Store(proc, 12, genParamName);
            HalconAPI.Store(proc, 13, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HPose hpose;
            int err2 = HPose.LoadNew(proc, 0, err1, out hpose);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out covPose);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return hpose;
        }

        /// <summary>
        ///   Find the best matches of a planar projective invariant deformable model in an image.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="image">Input image in which the model should be found.</param>
        /// <param name="angleStart">Smallest rotation of the model. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.78</param>
        /// <param name="scaleRMin">Minimum scale of the model in row direction. Default: 1.0</param>
        /// <param name="scaleRMax">Maximum scale of the model in row direction. Default: 1.0</param>
        /// <param name="scaleCMin">Minimum scale of the model in column direction. Default: 1.0</param>
        /// <param name="scaleCMax">Maximum scale of the model in column direction. Default: 1.0</param>
        /// <param name="minScore">Minimum score of the instances of the model to be found. Default: 0.5</param>
        /// <param name="numMatches">Number of instances of the model to be found (or 0 for all matches). Default: 1</param>
        /// <param name="maxOverlap">Maximum overlap of the instances of the model to be found. Default: 1.0</param>
        /// <param name="numLevels">Number of pyramid levels used in the matching (and lowest pyramid level to use if $|NumLevels| = 2$). Default: 0</param>
        /// <param name="greediness">"Greediness" of the search heuristic (0: safe but slow; 1: fast but matches may be missed). Default: 0.9</param>
        /// <param name="genParamName">The general parameter names. Default: []</param>
        /// <param name="genParamValue">Values of the general parameters. Default: []</param>
        /// <param name="score">Score of the found instances of the model.</param>
        /// <returns>Homographies between model and found instances.</returns>
        public HHomMat2D[] FindPlanarUncalibDeformableModel(
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
          HTuple numLevels,
          double greediness,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple score)
        {
            IntPtr proc = HalconAPI.PreCall(971);
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
            HalconAPI.Store(proc, 10, numLevels);
            HalconAPI.StoreD(proc, 11, greediness);
            HalconAPI.Store(proc, 12, genParamName);
            HalconAPI.Store(proc, 13, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(numLevels);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out score);
            HalconAPI.PostCall(proc, procResult);
            HHomMat2D[] hhomMat2DArray = HHomMat2D.SplitArray(tuple);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return hhomMat2DArray;
        }

        /// <summary>
        ///   Find the best matches of a planar projective invariant deformable model in an image.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="image">Input image in which the model should be found.</param>
        /// <param name="angleStart">Smallest rotation of the model. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation angles. Default: 0.78</param>
        /// <param name="scaleRMin">Minimum scale of the model in row direction. Default: 1.0</param>
        /// <param name="scaleRMax">Maximum scale of the model in row direction. Default: 1.0</param>
        /// <param name="scaleCMin">Minimum scale of the model in column direction. Default: 1.0</param>
        /// <param name="scaleCMax">Maximum scale of the model in column direction. Default: 1.0</param>
        /// <param name="minScore">Minimum score of the instances of the model to be found. Default: 0.5</param>
        /// <param name="numMatches">Number of instances of the model to be found (or 0 for all matches). Default: 1</param>
        /// <param name="maxOverlap">Maximum overlap of the instances of the model to be found. Default: 1.0</param>
        /// <param name="numLevels">Number of pyramid levels used in the matching (and lowest pyramid level to use if $|NumLevels| = 2$). Default: 0</param>
        /// <param name="greediness">"Greediness" of the search heuristic (0: safe but slow; 1: fast but matches may be missed). Default: 0.9</param>
        /// <param name="genParamName">The general parameter names. Default: []</param>
        /// <param name="genParamValue">Values of the general parameters. Default: []</param>
        /// <param name="score">Score of the found instances of the model.</param>
        /// <returns>Homographies between model and found instances.</returns>
        public HHomMat2D FindPlanarUncalibDeformableModel(
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
          int numLevels,
          double greediness,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple score)
        {
            IntPtr proc = HalconAPI.PreCall(971);
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
            HalconAPI.StoreI(proc, 10, numLevels);
            HalconAPI.StoreD(proc, 11, greediness);
            HalconAPI.Store(proc, 12, genParamName);
            HalconAPI.Store(proc, 13, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HHomMat2D hhomMat2D;
            int err2 = HHomMat2D.LoadNew(proc, 0, err1, out hhomMat2D);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return hhomMat2D;
        }

        /// <summary>
        ///   Set the metric of a local deformable model that was created from XLD contours.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="image">Input image used for the determination of the polarity.</param>
        /// <param name="vectorField">Vector field of the local deformation.</param>
        /// <param name="metric">Match metric. Default: "use_polarity"</param>
        public void SetLocalDeformableModelMetric(HImage image, HImage vectorField, string metric)
        {
            IntPtr proc = HalconAPI.PreCall(972);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 2, (HObjectBase)vectorField);
            HalconAPI.StoreS(proc, 1, metric);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)vectorField);
        }

        /// <summary>
        ///   Set the metric of a planar calibrated deformable model that was created from XLD contours.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="image">Input image used for the determination of the polarity.</param>
        /// <param name="pose">Pose of the model in the image.</param>
        /// <param name="metric">Match metric. Default: "use_polarity"</param>
        public void SetPlanarCalibDeformableModelMetric(HImage image, HPose pose, string metric)
        {
            IntPtr proc = HalconAPI.PreCall(973);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 1, (HData)pose);
            HalconAPI.StoreS(proc, 2, metric);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)pose));
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
        }

        /// <summary>
        ///   Set the metric of a planar uncalibrated deformable model that was created from XLD contours.
        ///   Instance represents: Handle of the model.
        /// </summary>
        /// <param name="image">Input image used for the determination of the polarity.</param>
        /// <param name="homMat2D">Transformation matrix.</param>
        /// <param name="metric">Match metric. Default: "use_polarity"</param>
        public void SetPlanarUncalibDeformableModelMetric(
          HImage image,
          HHomMat2D homMat2D,
          string metric)
        {
            IntPtr proc = HalconAPI.PreCall(974);
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
        ///   Prepare a deformable model for local deformable matching from XLD contours.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="contours">Input contours that will be used to create the model.</param>
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
        public void CreateLocalDeformableModelXld(
          HXLDCont contours,
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
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(975);
            HalconAPI.Store(proc, 1, (HObjectBase)contours);
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
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contours);
        }

        /// <summary>
        ///   Prepare a deformable model for local deformable matching from XLD contours.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="contours">Input contours that will be used to create the model.</param>
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
        public void CreateLocalDeformableModelXld(
          HXLDCont contours,
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
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(975);
            HalconAPI.Store(proc, 1, (HObjectBase)contours);
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
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contours);
        }

        /// <summary>
        ///   Prepare a deformable model for planar calibrated matching from XLD contours.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="contours">Input contours that will be used to create the model.</param>
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
        public void CreatePlanarCalibDeformableModelXld(
          HXLDCont contours,
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
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(976);
            HalconAPI.Store(proc, 1, (HObjectBase)contours);
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
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contours);
        }

        /// <summary>
        ///   Prepare a deformable model for planar calibrated matching from XLD contours.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="contours">Input contours that will be used to create the model.</param>
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
        public void CreatePlanarCalibDeformableModelXld(
          HXLDCont contours,
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
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(976);
            HalconAPI.Store(proc, 1, (HObjectBase)contours);
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
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contours);
        }

        /// <summary>
        ///   Prepare a deformable model for planar uncalibrated matching from XLD contours.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="contours">Input contours that will be used to create the model.</param>
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
        public void CreatePlanarUncalibDeformableModelXld(
          HXLDCont contours,
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
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(977);
            HalconAPI.Store(proc, 1, (HObjectBase)contours);
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
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contours);
        }

        /// <summary>
        ///   Prepare a deformable model for planar uncalibrated matching from XLD contours.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="contours">Input contours that will be used to create the model.</param>
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
        public void CreatePlanarUncalibDeformableModelXld(
          HXLDCont contours,
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
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(977);
            HalconAPI.Store(proc, 1, (HObjectBase)contours);
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
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contours);
        }

        /// <summary>
        ///   Creates a deformable model for local, deformable matching.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
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
        /// <param name="optimization">Kind of optimization used for generating the model. Default: "none"</param>
        /// <param name="metric">Match metric. Default: "use_polarity"</param>
        /// <param name="contrast">Thresholds or hysteresis thresholds for the contrast of the object in the template image. Default: "auto"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: "auto"</param>
        /// <param name="genParamName">The generic parameter names. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        public void CreateLocalDeformableModel(
          HImage template,
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
          HTuple contrast,
          HTuple minContrast,
          HTuple genParamName,
          HTuple genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(978);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
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
            HalconAPI.Store(proc, 12, contrast);
            HalconAPI.Store(proc, 13, minContrast);
            HalconAPI.Store(proc, 14, genParamName);
            HalconAPI.Store(proc, 15, genParamValue);
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
            HalconAPI.UnpinTuple(contrast);
            HalconAPI.UnpinTuple(minContrast);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        /// <summary>
        ///   Creates a deformable model for local, deformable matching.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
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
        /// <param name="optimization">Kind of optimization used for generating the model. Default: "none"</param>
        /// <param name="metric">Match metric. Default: "use_polarity"</param>
        /// <param name="contrast">Thresholds or hysteresis thresholds for the contrast of the object in the template image. Default: "auto"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: "auto"</param>
        /// <param name="genParamName">The generic parameter names. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        public void CreateLocalDeformableModel(
          HImage template,
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
          HTuple contrast,
          int minContrast,
          HTuple genParamName,
          HTuple genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(978);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
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
            HalconAPI.Store(proc, 12, contrast);
            HalconAPI.StoreI(proc, 13, minContrast);
            HalconAPI.Store(proc, 14, genParamName);
            HalconAPI.Store(proc, 15, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(angleStart);
            HalconAPI.UnpinTuple(angleExtent);
            HalconAPI.UnpinTuple(scaleRMax);
            HalconAPI.UnpinTuple(scaleCMax);
            HalconAPI.UnpinTuple(contrast);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        /// <summary>
        ///   Create a deformable model for calibrated perspective matching.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
        /// <param name="camParam">The parameters of the internal orientation of the camera.</param>
        /// <param name="referencePose">The reference pose of the object in the reference image.</param>
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
        /// <param name="optimization">Kind of optimization used for generating the model. Default: "none"</param>
        /// <param name="metric">Match metric. Default: "use_polarity"</param>
        /// <param name="contrast">Thresholds or hysteresis thresholds for the contrast of the object in the template image. Default: "auto"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: "auto"</param>
        /// <param name="genParamName">The parameter names. Default: []</param>
        /// <param name="genParamValue">Values of the parameters. Default: []</param>
        public void CreatePlanarCalibDeformableModel(
          HImage template,
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
          HTuple contrast,
          HTuple minContrast,
          HTuple genParamName,
          HTuple genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(979);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
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
            HalconAPI.Store(proc, 14, contrast);
            HalconAPI.Store(proc, 15, minContrast);
            HalconAPI.Store(proc, 16, genParamName);
            HalconAPI.Store(proc, 17, genParamValue);
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
            HalconAPI.UnpinTuple(contrast);
            HalconAPI.UnpinTuple(minContrast);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        /// <summary>
        ///   Create a deformable model for calibrated perspective matching.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
        /// <param name="camParam">The parameters of the internal orientation of the camera.</param>
        /// <param name="referencePose">The reference pose of the object in the reference image.</param>
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
        /// <param name="optimization">Kind of optimization used for generating the model. Default: "none"</param>
        /// <param name="metric">Match metric. Default: "use_polarity"</param>
        /// <param name="contrast">Thresholds or hysteresis thresholds for the contrast of the object in the template image. Default: "auto"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: "auto"</param>
        /// <param name="genParamName">The parameter names. Default: []</param>
        /// <param name="genParamValue">Values of the parameters. Default: []</param>
        public void CreatePlanarCalibDeformableModel(
          HImage template,
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
          HTuple contrast,
          int minContrast,
          HTuple genParamName,
          HTuple genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(979);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
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
            HalconAPI.Store(proc, 14, contrast);
            HalconAPI.StoreI(proc, 15, minContrast);
            HalconAPI.Store(proc, 16, genParamName);
            HalconAPI.Store(proc, 17, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
            HalconAPI.UnpinTuple((HTuple)((HData)referencePose));
            HalconAPI.UnpinTuple(angleStart);
            HalconAPI.UnpinTuple(angleExtent);
            HalconAPI.UnpinTuple(scaleRMax);
            HalconAPI.UnpinTuple(scaleCMax);
            HalconAPI.UnpinTuple(contrast);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        /// <summary>
        ///   Creates a deformable model for uncalibrated, perspective matching.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
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
        /// <param name="optimization">Kind of optimization used for generating the model. Default: "none"</param>
        /// <param name="metric">Match metric. Default: "use_polarity"</param>
        /// <param name="contrast">Thresholds or hysteresis thresholds for the contrast of the object in the template image. Default: "auto"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: "auto"</param>
        /// <param name="genParamName">The generic parameter names. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameter. Default: []</param>
        public void CreatePlanarUncalibDeformableModel(
          HImage template,
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
          HTuple contrast,
          HTuple minContrast,
          HTuple genParamName,
          HTuple genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(980);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
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
            HalconAPI.Store(proc, 12, contrast);
            HalconAPI.Store(proc, 13, minContrast);
            HalconAPI.Store(proc, 14, genParamName);
            HalconAPI.Store(proc, 15, genParamValue);
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
            HalconAPI.UnpinTuple(contrast);
            HalconAPI.UnpinTuple(minContrast);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        /// <summary>
        ///   Creates a deformable model for uncalibrated, perspective matching.
        ///   Modified instance represents: Handle of the model.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
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
        /// <param name="optimization">Kind of optimization used for generating the model. Default: "none"</param>
        /// <param name="metric">Match metric. Default: "use_polarity"</param>
        /// <param name="contrast">Thresholds or hysteresis thresholds for the contrast of the object in the template image. Default: "auto"</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: "auto"</param>
        /// <param name="genParamName">The generic parameter names. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameter. Default: []</param>
        public void CreatePlanarUncalibDeformableModel(
          HImage template,
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
          HTuple contrast,
          int minContrast,
          HTuple genParamName,
          HTuple genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(980);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
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
            HalconAPI.Store(proc, 12, contrast);
            HalconAPI.StoreI(proc, 13, minContrast);
            HalconAPI.Store(proc, 14, genParamName);
            HalconAPI.Store(proc, 15, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(angleStart);
            HalconAPI.UnpinTuple(angleExtent);
            HalconAPI.UnpinTuple(scaleRMax);
            HalconAPI.UnpinTuple(scaleCMax);
            HalconAPI.UnpinTuple(contrast);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(968);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
