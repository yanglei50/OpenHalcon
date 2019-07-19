// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HComponentModel
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a model for the component-based matching.</summary>
    [Serializable]
    public class HComponentModel : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HComponentModel()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HComponentModel(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HComponentModel obj)
        {
            obj = new HComponentModel(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HComponentModel[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HComponentModel[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HComponentModel(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Read a component model from a file.
        ///   Modified instance represents: Handle of the component model.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public HComponentModel(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1002);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Prepare a component model for matching based on explicitly specified components and relations.
        ///   Modified instance represents: Handle of the component model.
        /// </summary>
        /// <param name="modelImage">Input image from which the shape models of the model components should be created.</param>
        /// <param name="componentRegions">Input regions from which the shape models of the model components should be created.</param>
        /// <param name="variationRow">Variation of the model components in row direction.</param>
        /// <param name="variationColumn">Variation of the model components in column direction.</param>
        /// <param name="variationAngle">Angle variation of the model components.</param>
        /// <param name="angleStart">Smallest rotation of the component model. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation of the component model. Default: 0.79</param>
        /// <param name="contrastLowComp">Lower hysteresis threshold for the contrast of the components in the model image. Default: "auto"</param>
        /// <param name="contrastHighComp">Upper hysteresis threshold for the contrast of the components in the model image. Default: "auto"</param>
        /// <param name="minSizeComp">Minimum size of the contour regions in the model. Default: "auto"</param>
        /// <param name="minContrastComp">Minimum contrast of the components in the search images. Default: "auto"</param>
        /// <param name="minScoreComp">Minimum score of the instances of the components to be found. Default: 0.5</param>
        /// <param name="numLevelsComp">Maximum number of pyramid levels for the components. Default: "auto"</param>
        /// <param name="angleStepComp">Step length of the angles (resolution) for the components. Default: "auto"</param>
        /// <param name="optimizationComp">Kind of optimization for the components. Default: "auto"</param>
        /// <param name="metricComp">Match metric used for the components. Default: "use_polarity"</param>
        /// <param name="pregenerationComp">Complete pregeneration of the shape models for the components if equal to 'true'. Default: "false"</param>
        /// <param name="rootRanking">Ranking of the model components expressing the suitability to act as the root component.</param>
        public HComponentModel(
          HImage modelImage,
          HRegion componentRegions,
          HTuple variationRow,
          HTuple variationColumn,
          HTuple variationAngle,
          double angleStart,
          double angleExtent,
          HTuple contrastLowComp,
          HTuple contrastHighComp,
          HTuple minSizeComp,
          HTuple minContrastComp,
          HTuple minScoreComp,
          HTuple numLevelsComp,
          HTuple angleStepComp,
          string optimizationComp,
          HTuple metricComp,
          HTuple pregenerationComp,
          out HTuple rootRanking)
        {
            IntPtr proc = HalconAPI.PreCall(1004);
            HalconAPI.Store(proc, 1, (HObjectBase)modelImage);
            HalconAPI.Store(proc, 2, (HObjectBase)componentRegions);
            HalconAPI.Store(proc, 0, variationRow);
            HalconAPI.Store(proc, 1, variationColumn);
            HalconAPI.Store(proc, 2, variationAngle);
            HalconAPI.StoreD(proc, 3, angleStart);
            HalconAPI.StoreD(proc, 4, angleExtent);
            HalconAPI.Store(proc, 5, contrastLowComp);
            HalconAPI.Store(proc, 6, contrastHighComp);
            HalconAPI.Store(proc, 7, minSizeComp);
            HalconAPI.Store(proc, 8, minContrastComp);
            HalconAPI.Store(proc, 9, minScoreComp);
            HalconAPI.Store(proc, 10, numLevelsComp);
            HalconAPI.Store(proc, 11, angleStepComp);
            HalconAPI.StoreS(proc, 12, optimizationComp);
            HalconAPI.Store(proc, 13, metricComp);
            HalconAPI.Store(proc, 14, pregenerationComp);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(variationRow);
            HalconAPI.UnpinTuple(variationColumn);
            HalconAPI.UnpinTuple(variationAngle);
            HalconAPI.UnpinTuple(contrastLowComp);
            HalconAPI.UnpinTuple(contrastHighComp);
            HalconAPI.UnpinTuple(minSizeComp);
            HalconAPI.UnpinTuple(minContrastComp);
            HalconAPI.UnpinTuple(minScoreComp);
            HalconAPI.UnpinTuple(numLevelsComp);
            HalconAPI.UnpinTuple(angleStepComp);
            HalconAPI.UnpinTuple(metricComp);
            HalconAPI.UnpinTuple(pregenerationComp);
            int err2 = this.Load(proc, 0, err1);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out rootRanking);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)modelImage);
            GC.KeepAlive((object)componentRegions);
        }

        /// <summary>
        ///   Prepare a component model for matching based on explicitly specified components and relations.
        ///   Modified instance represents: Handle of the component model.
        /// </summary>
        /// <param name="modelImage">Input image from which the shape models of the model components should be created.</param>
        /// <param name="componentRegions">Input regions from which the shape models of the model components should be created.</param>
        /// <param name="variationRow">Variation of the model components in row direction.</param>
        /// <param name="variationColumn">Variation of the model components in column direction.</param>
        /// <param name="variationAngle">Angle variation of the model components.</param>
        /// <param name="angleStart">Smallest rotation of the component model. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation of the component model. Default: 0.79</param>
        /// <param name="contrastLowComp">Lower hysteresis threshold for the contrast of the components in the model image. Default: "auto"</param>
        /// <param name="contrastHighComp">Upper hysteresis threshold for the contrast of the components in the model image. Default: "auto"</param>
        /// <param name="minSizeComp">Minimum size of the contour regions in the model. Default: "auto"</param>
        /// <param name="minContrastComp">Minimum contrast of the components in the search images. Default: "auto"</param>
        /// <param name="minScoreComp">Minimum score of the instances of the components to be found. Default: 0.5</param>
        /// <param name="numLevelsComp">Maximum number of pyramid levels for the components. Default: "auto"</param>
        /// <param name="angleStepComp">Step length of the angles (resolution) for the components. Default: "auto"</param>
        /// <param name="optimizationComp">Kind of optimization for the components. Default: "auto"</param>
        /// <param name="metricComp">Match metric used for the components. Default: "use_polarity"</param>
        /// <param name="pregenerationComp">Complete pregeneration of the shape models for the components if equal to 'true'. Default: "false"</param>
        /// <param name="rootRanking">Ranking of the model components expressing the suitability to act as the root component.</param>
        public HComponentModel(
          HImage modelImage,
          HRegion componentRegions,
          int variationRow,
          int variationColumn,
          double variationAngle,
          double angleStart,
          double angleExtent,
          int contrastLowComp,
          int contrastHighComp,
          int minSizeComp,
          int minContrastComp,
          double minScoreComp,
          int numLevelsComp,
          double angleStepComp,
          string optimizationComp,
          string metricComp,
          string pregenerationComp,
          out int rootRanking)
        {
            IntPtr proc = HalconAPI.PreCall(1004);
            HalconAPI.Store(proc, 1, (HObjectBase)modelImage);
            HalconAPI.Store(proc, 2, (HObjectBase)componentRegions);
            HalconAPI.StoreI(proc, 0, variationRow);
            HalconAPI.StoreI(proc, 1, variationColumn);
            HalconAPI.StoreD(proc, 2, variationAngle);
            HalconAPI.StoreD(proc, 3, angleStart);
            HalconAPI.StoreD(proc, 4, angleExtent);
            HalconAPI.StoreI(proc, 5, contrastLowComp);
            HalconAPI.StoreI(proc, 6, contrastHighComp);
            HalconAPI.StoreI(proc, 7, minSizeComp);
            HalconAPI.StoreI(proc, 8, minContrastComp);
            HalconAPI.StoreD(proc, 9, minScoreComp);
            HalconAPI.StoreI(proc, 10, numLevelsComp);
            HalconAPI.StoreD(proc, 11, angleStepComp);
            HalconAPI.StoreS(proc, 12, optimizationComp);
            HalconAPI.StoreS(proc, 13, metricComp);
            HalconAPI.StoreS(proc, 14, pregenerationComp);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = this.Load(proc, 0, err1);
            int procResult = HalconAPI.LoadI(proc, 1, err2, out rootRanking);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)modelImage);
            GC.KeepAlive((object)componentRegions);
        }

        /// <summary>
        ///   Prepare a component model for matching based on trained components.
        ///   Modified instance represents: Handle of the component model.
        /// </summary>
        /// <param name="componentTrainingID">Handle of the training result.</param>
        /// <param name="angleStart">Smallest rotation of the component model. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation of the component model. Default: 0.79</param>
        /// <param name="minContrastComp">Minimum contrast of the components in the search images. Default: "auto"</param>
        /// <param name="minScoreComp">Minimum score of the instances of the components to be found. Default: 0.5</param>
        /// <param name="numLevelsComp">Maximum number of pyramid levels for the components. Default: "auto"</param>
        /// <param name="angleStepComp">Step length of the angles (resolution) for the components. Default: "auto"</param>
        /// <param name="optimizationComp">Kind of optimization for the components. Default: "auto"</param>
        /// <param name="metricComp">Match metric used for the components. Default: "use_polarity"</param>
        /// <param name="pregenerationComp">Complete pregeneration of the shape models for the components if equal to 'true'. Default: "false"</param>
        /// <param name="rootRanking">Ranking of the model components expressing the suitability to act as the root component.</param>
        public HComponentModel(
          HComponentTraining componentTrainingID,
          double angleStart,
          double angleExtent,
          HTuple minContrastComp,
          HTuple minScoreComp,
          HTuple numLevelsComp,
          HTuple angleStepComp,
          string optimizationComp,
          HTuple metricComp,
          HTuple pregenerationComp,
          out HTuple rootRanking)
        {
            IntPtr proc = HalconAPI.PreCall(1005);
            HalconAPI.Store(proc, 0, (HTool)componentTrainingID);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.Store(proc, 3, minContrastComp);
            HalconAPI.Store(proc, 4, minScoreComp);
            HalconAPI.Store(proc, 5, numLevelsComp);
            HalconAPI.Store(proc, 6, angleStepComp);
            HalconAPI.StoreS(proc, 7, optimizationComp);
            HalconAPI.Store(proc, 8, metricComp);
            HalconAPI.Store(proc, 9, pregenerationComp);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(minContrastComp);
            HalconAPI.UnpinTuple(minScoreComp);
            HalconAPI.UnpinTuple(numLevelsComp);
            HalconAPI.UnpinTuple(angleStepComp);
            HalconAPI.UnpinTuple(metricComp);
            HalconAPI.UnpinTuple(pregenerationComp);
            int err2 = this.Load(proc, 0, err1);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out rootRanking);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)componentTrainingID);
        }

        /// <summary>
        ///   Prepare a component model for matching based on trained components.
        ///   Modified instance represents: Handle of the component model.
        /// </summary>
        /// <param name="componentTrainingID">Handle of the training result.</param>
        /// <param name="angleStart">Smallest rotation of the component model. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation of the component model. Default: 0.79</param>
        /// <param name="minContrastComp">Minimum contrast of the components in the search images. Default: "auto"</param>
        /// <param name="minScoreComp">Minimum score of the instances of the components to be found. Default: 0.5</param>
        /// <param name="numLevelsComp">Maximum number of pyramid levels for the components. Default: "auto"</param>
        /// <param name="angleStepComp">Step length of the angles (resolution) for the components. Default: "auto"</param>
        /// <param name="optimizationComp">Kind of optimization for the components. Default: "auto"</param>
        /// <param name="metricComp">Match metric used for the components. Default: "use_polarity"</param>
        /// <param name="pregenerationComp">Complete pregeneration of the shape models for the components if equal to 'true'. Default: "false"</param>
        /// <param name="rootRanking">Ranking of the model components expressing the suitability to act as the root component.</param>
        public HComponentModel(
          HComponentTraining componentTrainingID,
          double angleStart,
          double angleExtent,
          int minContrastComp,
          double minScoreComp,
          int numLevelsComp,
          double angleStepComp,
          string optimizationComp,
          string metricComp,
          string pregenerationComp,
          out int rootRanking)
        {
            IntPtr proc = HalconAPI.PreCall(1005);
            HalconAPI.Store(proc, 0, (HTool)componentTrainingID);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.StoreI(proc, 3, minContrastComp);
            HalconAPI.StoreD(proc, 4, minScoreComp);
            HalconAPI.StoreI(proc, 5, numLevelsComp);
            HalconAPI.StoreD(proc, 6, angleStepComp);
            HalconAPI.StoreS(proc, 7, optimizationComp);
            HalconAPI.StoreS(proc, 8, metricComp);
            HalconAPI.StoreS(proc, 9, pregenerationComp);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = this.Load(proc, 0, err1);
            int procResult = HalconAPI.LoadI(proc, 1, err2, out rootRanking);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)componentTrainingID);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeComponentModel();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HComponentModel(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeComponentModel(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeComponentModel().Serialize(stream);
        }

        public static HComponentModel Deserialize(Stream stream)
        {
            HComponentModel hcomponentModel = new HComponentModel();
            hcomponentModel.DeserializeComponentModel(HSerializedItem.Deserialize(stream));
            return hcomponentModel;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HComponentModel Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeComponentModel();
            HComponentModel hcomponentModel = new HComponentModel();
            hcomponentModel.DeserializeComponentModel(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hcomponentModel;
        }

        /// <summary>
        ///   Return the components of a found instance of a component model.
        ///   Instance represents: Handle of the component model.
        /// </summary>
        /// <param name="modelStart">Start index of each found instance of the component model in the tuples describing the component matches.</param>
        /// <param name="modelEnd">End index of each found instance of the component model to the tuples describing the component matches.</param>
        /// <param name="rowComp">Row coordinate of the found component matches.</param>
        /// <param name="columnComp">Column coordinate of the found component matches.</param>
        /// <param name="angleComp">Rotation angle of the found component matches.</param>
        /// <param name="scoreComp">Score of the found component matches.</param>
        /// <param name="modelComp">Index of the found components.</param>
        /// <param name="modelMatch">Index of the found instance of the component model to be returned.</param>
        /// <param name="markOrientation">Mark the orientation of the components. Default: "false"</param>
        /// <param name="rowCompInst">Row coordinate of all components of the selected model instance.</param>
        /// <param name="columnCompInst">Column coordinate of all components of the selected model instance.</param>
        /// <param name="angleCompInst">Rotation angle of all components of the selected model instance.</param>
        /// <param name="scoreCompInst">Score of all components of the selected model instance.</param>
        /// <returns>Found components of the selected component model instance.</returns>
        public HRegion GetFoundComponentModel(
          HTuple modelStart,
          HTuple modelEnd,
          HTuple rowComp,
          HTuple columnComp,
          HTuple angleComp,
          HTuple scoreComp,
          HTuple modelComp,
          int modelMatch,
          string markOrientation,
          out HTuple rowCompInst,
          out HTuple columnCompInst,
          out HTuple angleCompInst,
          out HTuple scoreCompInst)
        {
            IntPtr proc = HalconAPI.PreCall(994);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, modelStart);
            HalconAPI.Store(proc, 2, modelEnd);
            HalconAPI.Store(proc, 3, rowComp);
            HalconAPI.Store(proc, 4, columnComp);
            HalconAPI.Store(proc, 5, angleComp);
            HalconAPI.Store(proc, 6, scoreComp);
            HalconAPI.Store(proc, 7, modelComp);
            HalconAPI.StoreI(proc, 8, modelMatch);
            HalconAPI.StoreS(proc, 9, markOrientation);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(modelStart);
            HalconAPI.UnpinTuple(modelEnd);
            HalconAPI.UnpinTuple(rowComp);
            HalconAPI.UnpinTuple(columnComp);
            HalconAPI.UnpinTuple(angleComp);
            HalconAPI.UnpinTuple(scoreComp);
            HalconAPI.UnpinTuple(modelComp);
            HRegion hregion;
            int err2 = HRegion.LoadNew(proc, 1, err1, out hregion);
            int err3 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err2, out rowCompInst);
            int err4 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err3, out columnCompInst);
            int err5 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err4, out angleCompInst);
            int procResult = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err5, out scoreCompInst);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Return the components of a found instance of a component model.
        ///   Instance represents: Handle of the component model.
        /// </summary>
        /// <param name="modelStart">Start index of each found instance of the component model in the tuples describing the component matches.</param>
        /// <param name="modelEnd">End index of each found instance of the component model to the tuples describing the component matches.</param>
        /// <param name="rowComp">Row coordinate of the found component matches.</param>
        /// <param name="columnComp">Column coordinate of the found component matches.</param>
        /// <param name="angleComp">Rotation angle of the found component matches.</param>
        /// <param name="scoreComp">Score of the found component matches.</param>
        /// <param name="modelComp">Index of the found components.</param>
        /// <param name="modelMatch">Index of the found instance of the component model to be returned.</param>
        /// <param name="markOrientation">Mark the orientation of the components. Default: "false"</param>
        /// <param name="rowCompInst">Row coordinate of all components of the selected model instance.</param>
        /// <param name="columnCompInst">Column coordinate of all components of the selected model instance.</param>
        /// <param name="angleCompInst">Rotation angle of all components of the selected model instance.</param>
        /// <param name="scoreCompInst">Score of all components of the selected model instance.</param>
        /// <returns>Found components of the selected component model instance.</returns>
        public HRegion GetFoundComponentModel(
          int modelStart,
          int modelEnd,
          double rowComp,
          double columnComp,
          double angleComp,
          double scoreComp,
          int modelComp,
          int modelMatch,
          string markOrientation,
          out double rowCompInst,
          out double columnCompInst,
          out double angleCompInst,
          out double scoreCompInst)
        {
            IntPtr proc = HalconAPI.PreCall(994);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, modelStart);
            HalconAPI.StoreI(proc, 2, modelEnd);
            HalconAPI.StoreD(proc, 3, rowComp);
            HalconAPI.StoreD(proc, 4, columnComp);
            HalconAPI.StoreD(proc, 5, angleComp);
            HalconAPI.StoreD(proc, 6, scoreComp);
            HalconAPI.StoreI(proc, 7, modelComp);
            HalconAPI.StoreI(proc, 8, modelMatch);
            HalconAPI.StoreS(proc, 9, markOrientation);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int err2 = HRegion.LoadNew(proc, 1, err1, out hregion);
            int err3 = HalconAPI.LoadD(proc, 0, err2, out rowCompInst);
            int err4 = HalconAPI.LoadD(proc, 1, err3, out columnCompInst);
            int err5 = HalconAPI.LoadD(proc, 2, err4, out angleCompInst);
            int procResult = HalconAPI.LoadD(proc, 3, err5, out scoreCompInst);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Find the best matches of a component model in an image.
        ///   Instance represents: Handle of the component model.
        /// </summary>
        /// <param name="image">Input image in which the component model should be found.</param>
        /// <param name="rootComponent">Index of the root component.</param>
        /// <param name="angleStartRoot">Smallest rotation of the root component Default: -0.39</param>
        /// <param name="angleExtentRoot">Extent of the rotation of the root component. Default: 0.79</param>
        /// <param name="minScore">Minimum score of the instances of the component model to be found. Default: 0.5</param>
        /// <param name="numMatches">Number of instances of the component model to be found (or 0 for all matches). Default: 1</param>
        /// <param name="maxOverlap">Maximum overlap of the instances of the component models to be found. Default: 0.5</param>
        /// <param name="ifRootNotFound">Behavior if the root component is missing. Default: "stop_search"</param>
        /// <param name="ifComponentNotFound">Behavior if a component is missing. Default: "prune_branch"</param>
        /// <param name="posePrediction">Pose prediction of components that are not found. Default: "none"</param>
        /// <param name="minScoreComp">Minimum score of the instances of the components to be found. Default: 0.5</param>
        /// <param name="subPixelComp">Subpixel accuracy of the component poses if not equal to 'none'. Default: "least_squares"</param>
        /// <param name="numLevelsComp">Number of pyramid levels for the components used in the matching (and lowest pyramid level to use if $|NumLevelsComp| = 2n$). Default: 0</param>
        /// <param name="greedinessComp">"Greediness" of the search heuristic for the components (0: safe but slow; 1: fast but matches may be missed). Default: 0.9</param>
        /// <param name="modelEnd">End index of each found instance of the component model in the tuples describing the component matches.</param>
        /// <param name="score">Score of the found instances of the component model.</param>
        /// <param name="rowComp">Row coordinate of the found component matches.</param>
        /// <param name="columnComp">Column coordinate of the found component matches.</param>
        /// <param name="angleComp">Rotation angle of the found component matches.</param>
        /// <param name="scoreComp">Score of the found component matches.</param>
        /// <param name="modelComp">Index of the found components.</param>
        /// <returns>Start index of each found instance of the component model in the tuples describing the component matches.</returns>
        public HTuple FindComponentModel(
          HImage image,
          HTuple rootComponent,
          HTuple angleStartRoot,
          HTuple angleExtentRoot,
          double minScore,
          int numMatches,
          double maxOverlap,
          string ifRootNotFound,
          string ifComponentNotFound,
          string posePrediction,
          HTuple minScoreComp,
          HTuple subPixelComp,
          HTuple numLevelsComp,
          HTuple greedinessComp,
          out HTuple modelEnd,
          out HTuple score,
          out HTuple rowComp,
          out HTuple columnComp,
          out HTuple angleComp,
          out HTuple scoreComp,
          out HTuple modelComp)
        {
            IntPtr proc = HalconAPI.PreCall(995);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 1, rootComponent);
            HalconAPI.Store(proc, 2, angleStartRoot);
            HalconAPI.Store(proc, 3, angleExtentRoot);
            HalconAPI.StoreD(proc, 4, minScore);
            HalconAPI.StoreI(proc, 5, numMatches);
            HalconAPI.StoreD(proc, 6, maxOverlap);
            HalconAPI.StoreS(proc, 7, ifRootNotFound);
            HalconAPI.StoreS(proc, 8, ifComponentNotFound);
            HalconAPI.StoreS(proc, 9, posePrediction);
            HalconAPI.Store(proc, 10, minScoreComp);
            HalconAPI.Store(proc, 11, subPixelComp);
            HalconAPI.Store(proc, 12, numLevelsComp);
            HalconAPI.Store(proc, 13, greedinessComp);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            HalconAPI.InitOCT(proc, 6);
            HalconAPI.InitOCT(proc, 7);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(rootComponent);
            HalconAPI.UnpinTuple(angleStartRoot);
            HalconAPI.UnpinTuple(angleExtentRoot);
            HalconAPI.UnpinTuple(minScoreComp);
            HalconAPI.UnpinTuple(subPixelComp);
            HalconAPI.UnpinTuple(numLevelsComp);
            HalconAPI.UnpinTuple(greedinessComp);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out modelEnd);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out score);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out rowComp);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out columnComp);
            int err7 = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, err6, out angleComp);
            int err8 = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, err7, out scoreComp);
            int procResult = HTuple.LoadNew(proc, 7, HTupleType.INTEGER, err8, out modelComp);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return tuple;
        }

        /// <summary>
        ///   Find the best matches of a component model in an image.
        ///   Instance represents: Handle of the component model.
        /// </summary>
        /// <param name="image">Input image in which the component model should be found.</param>
        /// <param name="rootComponent">Index of the root component.</param>
        /// <param name="angleStartRoot">Smallest rotation of the root component Default: -0.39</param>
        /// <param name="angleExtentRoot">Extent of the rotation of the root component. Default: 0.79</param>
        /// <param name="minScore">Minimum score of the instances of the component model to be found. Default: 0.5</param>
        /// <param name="numMatches">Number of instances of the component model to be found (or 0 for all matches). Default: 1</param>
        /// <param name="maxOverlap">Maximum overlap of the instances of the component models to be found. Default: 0.5</param>
        /// <param name="ifRootNotFound">Behavior if the root component is missing. Default: "stop_search"</param>
        /// <param name="ifComponentNotFound">Behavior if a component is missing. Default: "prune_branch"</param>
        /// <param name="posePrediction">Pose prediction of components that are not found. Default: "none"</param>
        /// <param name="minScoreComp">Minimum score of the instances of the components to be found. Default: 0.5</param>
        /// <param name="subPixelComp">Subpixel accuracy of the component poses if not equal to 'none'. Default: "least_squares"</param>
        /// <param name="numLevelsComp">Number of pyramid levels for the components used in the matching (and lowest pyramid level to use if $|NumLevelsComp| = 2n$). Default: 0</param>
        /// <param name="greedinessComp">"Greediness" of the search heuristic for the components (0: safe but slow; 1: fast but matches may be missed). Default: 0.9</param>
        /// <param name="modelEnd">End index of each found instance of the component model in the tuples describing the component matches.</param>
        /// <param name="score">Score of the found instances of the component model.</param>
        /// <param name="rowComp">Row coordinate of the found component matches.</param>
        /// <param name="columnComp">Column coordinate of the found component matches.</param>
        /// <param name="angleComp">Rotation angle of the found component matches.</param>
        /// <param name="scoreComp">Score of the found component matches.</param>
        /// <param name="modelComp">Index of the found components.</param>
        /// <returns>Start index of each found instance of the component model in the tuples describing the component matches.</returns>
        public int FindComponentModel(
          HImage image,
          int rootComponent,
          double angleStartRoot,
          double angleExtentRoot,
          double minScore,
          int numMatches,
          double maxOverlap,
          string ifRootNotFound,
          string ifComponentNotFound,
          string posePrediction,
          double minScoreComp,
          string subPixelComp,
          int numLevelsComp,
          double greedinessComp,
          out int modelEnd,
          out double score,
          out double rowComp,
          out double columnComp,
          out double angleComp,
          out double scoreComp,
          out int modelComp)
        {
            IntPtr proc = HalconAPI.PreCall(995);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreI(proc, 1, rootComponent);
            HalconAPI.StoreD(proc, 2, angleStartRoot);
            HalconAPI.StoreD(proc, 3, angleExtentRoot);
            HalconAPI.StoreD(proc, 4, minScore);
            HalconAPI.StoreI(proc, 5, numMatches);
            HalconAPI.StoreD(proc, 6, maxOverlap);
            HalconAPI.StoreS(proc, 7, ifRootNotFound);
            HalconAPI.StoreS(proc, 8, ifComponentNotFound);
            HalconAPI.StoreS(proc, 9, posePrediction);
            HalconAPI.StoreD(proc, 10, minScoreComp);
            HalconAPI.StoreS(proc, 11, subPixelComp);
            HalconAPI.StoreI(proc, 12, numLevelsComp);
            HalconAPI.StoreD(proc, 13, greedinessComp);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            HalconAPI.InitOCT(proc, 6);
            HalconAPI.InitOCT(proc, 7);
            int err1 = HalconAPI.CallProcedure(proc);
            int intValue;
            int err2 = HalconAPI.LoadI(proc, 0, err1, out intValue);
            int err3 = HalconAPI.LoadI(proc, 1, err2, out modelEnd);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out score);
            int err5 = HalconAPI.LoadD(proc, 3, err4, out rowComp);
            int err6 = HalconAPI.LoadD(proc, 4, err5, out columnComp);
            int err7 = HalconAPI.LoadD(proc, 5, err6, out angleComp);
            int err8 = HalconAPI.LoadD(proc, 6, err7, out scoreComp);
            int procResult = HalconAPI.LoadI(proc, 7, err8, out modelComp);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return intValue;
        }

        /// <summary>
        ///   Return the search tree of a component model.
        ///   Instance represents: Handle of the component model.
        /// </summary>
        /// <param name="relations">Relations of components that are connected in the search tree.</param>
        /// <param name="rootComponent">Index of the root component.</param>
        /// <param name="image">Image for which the tree is to be returned. Default: "model_image"</param>
        /// <param name="startNode">Component index of the start node of an arc in the search tree.</param>
        /// <param name="endNode">Component index of the end node of an arc in the search tree.</param>
        /// <param name="row">Row coordinate of the center of the rectangle representing the relation.</param>
        /// <param name="column">Column index of the center of the rectangle representing the relation.</param>
        /// <param name="phi">Orientation of the rectangle representing the relation (radians).</param>
        /// <param name="length1">First radius (half length) of the rectangle representing the relation.</param>
        /// <param name="length2">Second radius (half width) of the rectangle representing the relation.</param>
        /// <param name="angleStart">Smallest relative orientation angle.</param>
        /// <param name="angleExtent">Extent of the relative orientation angle.</param>
        /// <returns>Search tree.</returns>
        public HRegion GetComponentModelTree(
          out HRegion relations,
          HTuple rootComponent,
          HTuple image,
          out HTuple startNode,
          out HTuple endNode,
          out HTuple row,
          out HTuple column,
          out HTuple phi,
          out HTuple length1,
          out HTuple length2,
          out HTuple angleStart,
          out HTuple angleExtent)
        {
            IntPtr proc = HalconAPI.PreCall(998);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, rootComponent);
            HalconAPI.Store(proc, 2, image);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
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
            HalconAPI.UnpinTuple(rootComponent);
            HalconAPI.UnpinTuple(image);
            HRegion hregion;
            int err2 = HRegion.LoadNew(proc, 1, err1, out hregion);
            int err3 = HRegion.LoadNew(proc, 2, err2, out relations);
            int err4 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err3, out startNode);
            int err5 = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err4, out endNode);
            int err6 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err5, out row);
            int err7 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err6, out column);
            int err8 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err7, out phi);
            int err9 = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, err8, out length1);
            int err10 = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, err9, out length2);
            int err11 = HTuple.LoadNew(proc, 7, HTupleType.DOUBLE, err10, out angleStart);
            int procResult = HTuple.LoadNew(proc, 8, HTupleType.DOUBLE, err11, out angleExtent);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Return the search tree of a component model.
        ///   Instance represents: Handle of the component model.
        /// </summary>
        /// <param name="relations">Relations of components that are connected in the search tree.</param>
        /// <param name="rootComponent">Index of the root component.</param>
        /// <param name="image">Image for which the tree is to be returned. Default: "model_image"</param>
        /// <param name="startNode">Component index of the start node of an arc in the search tree.</param>
        /// <param name="endNode">Component index of the end node of an arc in the search tree.</param>
        /// <param name="row">Row coordinate of the center of the rectangle representing the relation.</param>
        /// <param name="column">Column index of the center of the rectangle representing the relation.</param>
        /// <param name="phi">Orientation of the rectangle representing the relation (radians).</param>
        /// <param name="length1">First radius (half length) of the rectangle representing the relation.</param>
        /// <param name="length2">Second radius (half width) of the rectangle representing the relation.</param>
        /// <param name="angleStart">Smallest relative orientation angle.</param>
        /// <param name="angleExtent">Extent of the relative orientation angle.</param>
        /// <returns>Search tree.</returns>
        public HRegion GetComponentModelTree(
          out HRegion relations,
          int rootComponent,
          string image,
          out int startNode,
          out int endNode,
          out double row,
          out double column,
          out double phi,
          out double length1,
          out double length2,
          out double angleStart,
          out double angleExtent)
        {
            IntPtr proc = HalconAPI.PreCall(998);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, rootComponent);
            HalconAPI.StoreS(proc, 2, image);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
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
            HRegion hregion;
            int err2 = HRegion.LoadNew(proc, 1, err1, out hregion);
            int err3 = HRegion.LoadNew(proc, 2, err2, out relations);
            int err4 = HalconAPI.LoadI(proc, 0, err3, out startNode);
            int err5 = HalconAPI.LoadI(proc, 1, err4, out endNode);
            int err6 = HalconAPI.LoadD(proc, 2, err5, out row);
            int err7 = HalconAPI.LoadD(proc, 3, err6, out column);
            int err8 = HalconAPI.LoadD(proc, 4, err7, out phi);
            int err9 = HalconAPI.LoadD(proc, 5, err8, out length1);
            int err10 = HalconAPI.LoadD(proc, 6, err9, out length2);
            int err11 = HalconAPI.LoadD(proc, 7, err10, out angleStart);
            int procResult = HalconAPI.LoadD(proc, 8, err11, out angleExtent);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Return the parameters of a component model.
        ///   Instance represents: Handle of the component model.
        /// </summary>
        /// <param name="rootRanking">Ranking of the model components expressing their suitability to act as root component.</param>
        /// <param name="shapeModelIDs">Handles of the shape models of the individual model components.</param>
        /// <returns>Minimum score of the instances of the components to be found.</returns>
        public HTuple GetComponentModelParams(
          out HTuple rootRanking,
          out HShapeModel[] shapeModelIDs)
        {
            IntPtr proc = HalconAPI.PreCall(999);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out rootRanking);
            int procResult = HShapeModel.LoadNew(proc, 2, err3, out shapeModelIDs);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Return the parameters of a component model.
        ///   Instance represents: Handle of the component model.
        /// </summary>
        /// <param name="rootRanking">Ranking of the model components expressing their suitability to act as root component.</param>
        /// <param name="shapeModelIDs">Handles of the shape models of the individual model components.</param>
        /// <returns>Minimum score of the instances of the components to be found.</returns>
        public double GetComponentModelParams(out int rootRanking, out HShapeModel shapeModelIDs)
        {
            IntPtr proc = HalconAPI.PreCall(999);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadI(proc, 1, err2, out rootRanking);
            int procResult = HShapeModel.LoadNew(proc, 2, err3, out shapeModelIDs);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Deserialize a serialized component model.
        ///   Modified instance represents: Handle of the component model.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeComponentModel(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1000);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize a component model.
        ///   Instance represents: Handle of the component model.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeComponentModel()
        {
            IntPtr proc = HalconAPI.PreCall(1001);
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
        ///   Read a component model from a file.
        ///   Modified instance represents: Handle of the component model.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void ReadComponentModel(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1002);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write a component model to a file.
        ///   Instance represents: Handle of the component model.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void WriteComponentModel(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1003);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Prepare a component model for matching based on explicitly specified components and relations.
        ///   Modified instance represents: Handle of the component model.
        /// </summary>
        /// <param name="modelImage">Input image from which the shape models of the model components should be created.</param>
        /// <param name="componentRegions">Input regions from which the shape models of the model components should be created.</param>
        /// <param name="variationRow">Variation of the model components in row direction.</param>
        /// <param name="variationColumn">Variation of the model components in column direction.</param>
        /// <param name="variationAngle">Angle variation of the model components.</param>
        /// <param name="angleStart">Smallest rotation of the component model. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation of the component model. Default: 0.79</param>
        /// <param name="contrastLowComp">Lower hysteresis threshold for the contrast of the components in the model image. Default: "auto"</param>
        /// <param name="contrastHighComp">Upper hysteresis threshold for the contrast of the components in the model image. Default: "auto"</param>
        /// <param name="minSizeComp">Minimum size of the contour regions in the model. Default: "auto"</param>
        /// <param name="minContrastComp">Minimum contrast of the components in the search images. Default: "auto"</param>
        /// <param name="minScoreComp">Minimum score of the instances of the components to be found. Default: 0.5</param>
        /// <param name="numLevelsComp">Maximum number of pyramid levels for the components. Default: "auto"</param>
        /// <param name="angleStepComp">Step length of the angles (resolution) for the components. Default: "auto"</param>
        /// <param name="optimizationComp">Kind of optimization for the components. Default: "auto"</param>
        /// <param name="metricComp">Match metric used for the components. Default: "use_polarity"</param>
        /// <param name="pregenerationComp">Complete pregeneration of the shape models for the components if equal to 'true'. Default: "false"</param>
        /// <returns>Ranking of the model components expressing the suitability to act as the root component.</returns>
        public HTuple CreateComponentModel(
          HImage modelImage,
          HRegion componentRegions,
          HTuple variationRow,
          HTuple variationColumn,
          HTuple variationAngle,
          double angleStart,
          double angleExtent,
          HTuple contrastLowComp,
          HTuple contrastHighComp,
          HTuple minSizeComp,
          HTuple minContrastComp,
          HTuple minScoreComp,
          HTuple numLevelsComp,
          HTuple angleStepComp,
          string optimizationComp,
          HTuple metricComp,
          HTuple pregenerationComp)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1004);
            HalconAPI.Store(proc, 1, (HObjectBase)modelImage);
            HalconAPI.Store(proc, 2, (HObjectBase)componentRegions);
            HalconAPI.Store(proc, 0, variationRow);
            HalconAPI.Store(proc, 1, variationColumn);
            HalconAPI.Store(proc, 2, variationAngle);
            HalconAPI.StoreD(proc, 3, angleStart);
            HalconAPI.StoreD(proc, 4, angleExtent);
            HalconAPI.Store(proc, 5, contrastLowComp);
            HalconAPI.Store(proc, 6, contrastHighComp);
            HalconAPI.Store(proc, 7, minSizeComp);
            HalconAPI.Store(proc, 8, minContrastComp);
            HalconAPI.Store(proc, 9, minScoreComp);
            HalconAPI.Store(proc, 10, numLevelsComp);
            HalconAPI.Store(proc, 11, angleStepComp);
            HalconAPI.StoreS(proc, 12, optimizationComp);
            HalconAPI.Store(proc, 13, metricComp);
            HalconAPI.Store(proc, 14, pregenerationComp);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(variationRow);
            HalconAPI.UnpinTuple(variationColumn);
            HalconAPI.UnpinTuple(variationAngle);
            HalconAPI.UnpinTuple(contrastLowComp);
            HalconAPI.UnpinTuple(contrastHighComp);
            HalconAPI.UnpinTuple(minSizeComp);
            HalconAPI.UnpinTuple(minContrastComp);
            HalconAPI.UnpinTuple(minScoreComp);
            HalconAPI.UnpinTuple(numLevelsComp);
            HalconAPI.UnpinTuple(angleStepComp);
            HalconAPI.UnpinTuple(metricComp);
            HalconAPI.UnpinTuple(pregenerationComp);
            int err2 = this.Load(proc, 0, err1);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)modelImage);
            GC.KeepAlive((object)componentRegions);
            return tuple;
        }

        /// <summary>
        ///   Prepare a component model for matching based on explicitly specified components and relations.
        ///   Modified instance represents: Handle of the component model.
        /// </summary>
        /// <param name="modelImage">Input image from which the shape models of the model components should be created.</param>
        /// <param name="componentRegions">Input regions from which the shape models of the model components should be created.</param>
        /// <param name="variationRow">Variation of the model components in row direction.</param>
        /// <param name="variationColumn">Variation of the model components in column direction.</param>
        /// <param name="variationAngle">Angle variation of the model components.</param>
        /// <param name="angleStart">Smallest rotation of the component model. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation of the component model. Default: 0.79</param>
        /// <param name="contrastLowComp">Lower hysteresis threshold for the contrast of the components in the model image. Default: "auto"</param>
        /// <param name="contrastHighComp">Upper hysteresis threshold for the contrast of the components in the model image. Default: "auto"</param>
        /// <param name="minSizeComp">Minimum size of the contour regions in the model. Default: "auto"</param>
        /// <param name="minContrastComp">Minimum contrast of the components in the search images. Default: "auto"</param>
        /// <param name="minScoreComp">Minimum score of the instances of the components to be found. Default: 0.5</param>
        /// <param name="numLevelsComp">Maximum number of pyramid levels for the components. Default: "auto"</param>
        /// <param name="angleStepComp">Step length of the angles (resolution) for the components. Default: "auto"</param>
        /// <param name="optimizationComp">Kind of optimization for the components. Default: "auto"</param>
        /// <param name="metricComp">Match metric used for the components. Default: "use_polarity"</param>
        /// <param name="pregenerationComp">Complete pregeneration of the shape models for the components if equal to 'true'. Default: "false"</param>
        /// <returns>Ranking of the model components expressing the suitability to act as the root component.</returns>
        public int CreateComponentModel(
          HImage modelImage,
          HRegion componentRegions,
          int variationRow,
          int variationColumn,
          double variationAngle,
          double angleStart,
          double angleExtent,
          int contrastLowComp,
          int contrastHighComp,
          int minSizeComp,
          int minContrastComp,
          double minScoreComp,
          int numLevelsComp,
          double angleStepComp,
          string optimizationComp,
          string metricComp,
          string pregenerationComp)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1004);
            HalconAPI.Store(proc, 1, (HObjectBase)modelImage);
            HalconAPI.Store(proc, 2, (HObjectBase)componentRegions);
            HalconAPI.StoreI(proc, 0, variationRow);
            HalconAPI.StoreI(proc, 1, variationColumn);
            HalconAPI.StoreD(proc, 2, variationAngle);
            HalconAPI.StoreD(proc, 3, angleStart);
            HalconAPI.StoreD(proc, 4, angleExtent);
            HalconAPI.StoreI(proc, 5, contrastLowComp);
            HalconAPI.StoreI(proc, 6, contrastHighComp);
            HalconAPI.StoreI(proc, 7, minSizeComp);
            HalconAPI.StoreI(proc, 8, minContrastComp);
            HalconAPI.StoreD(proc, 9, minScoreComp);
            HalconAPI.StoreI(proc, 10, numLevelsComp);
            HalconAPI.StoreD(proc, 11, angleStepComp);
            HalconAPI.StoreS(proc, 12, optimizationComp);
            HalconAPI.StoreS(proc, 13, metricComp);
            HalconAPI.StoreS(proc, 14, pregenerationComp);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = this.Load(proc, 0, err1);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 1, err2, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)modelImage);
            GC.KeepAlive((object)componentRegions);
            return intValue;
        }

        /// <summary>
        ///   Prepare a component model for matching based on trained components.
        ///   Modified instance represents: Handle of the component model.
        /// </summary>
        /// <param name="componentTrainingID">Handle of the training result.</param>
        /// <param name="angleStart">Smallest rotation of the component model. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation of the component model. Default: 0.79</param>
        /// <param name="minContrastComp">Minimum contrast of the components in the search images. Default: "auto"</param>
        /// <param name="minScoreComp">Minimum score of the instances of the components to be found. Default: 0.5</param>
        /// <param name="numLevelsComp">Maximum number of pyramid levels for the components. Default: "auto"</param>
        /// <param name="angleStepComp">Step length of the angles (resolution) for the components. Default: "auto"</param>
        /// <param name="optimizationComp">Kind of optimization for the components. Default: "auto"</param>
        /// <param name="metricComp">Match metric used for the components. Default: "use_polarity"</param>
        /// <param name="pregenerationComp">Complete pregeneration of the shape models for the components if equal to 'true'. Default: "false"</param>
        /// <returns>Ranking of the model components expressing the suitability to act as the root component.</returns>
        public HTuple CreateTrainedComponentModel(
          HComponentTraining componentTrainingID,
          double angleStart,
          double angleExtent,
          HTuple minContrastComp,
          HTuple minScoreComp,
          HTuple numLevelsComp,
          HTuple angleStepComp,
          string optimizationComp,
          HTuple metricComp,
          HTuple pregenerationComp)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1005);
            HalconAPI.Store(proc, 0, (HTool)componentTrainingID);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.Store(proc, 3, minContrastComp);
            HalconAPI.Store(proc, 4, minScoreComp);
            HalconAPI.Store(proc, 5, numLevelsComp);
            HalconAPI.Store(proc, 6, angleStepComp);
            HalconAPI.StoreS(proc, 7, optimizationComp);
            HalconAPI.Store(proc, 8, metricComp);
            HalconAPI.Store(proc, 9, pregenerationComp);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(minContrastComp);
            HalconAPI.UnpinTuple(minScoreComp);
            HalconAPI.UnpinTuple(numLevelsComp);
            HalconAPI.UnpinTuple(angleStepComp);
            HalconAPI.UnpinTuple(metricComp);
            HalconAPI.UnpinTuple(pregenerationComp);
            int err2 = this.Load(proc, 0, err1);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)componentTrainingID);
            return tuple;
        }

        /// <summary>
        ///   Prepare a component model for matching based on trained components.
        ///   Modified instance represents: Handle of the component model.
        /// </summary>
        /// <param name="componentTrainingID">Handle of the training result.</param>
        /// <param name="angleStart">Smallest rotation of the component model. Default: -0.39</param>
        /// <param name="angleExtent">Extent of the rotation of the component model. Default: 0.79</param>
        /// <param name="minContrastComp">Minimum contrast of the components in the search images. Default: "auto"</param>
        /// <param name="minScoreComp">Minimum score of the instances of the components to be found. Default: 0.5</param>
        /// <param name="numLevelsComp">Maximum number of pyramid levels for the components. Default: "auto"</param>
        /// <param name="angleStepComp">Step length of the angles (resolution) for the components. Default: "auto"</param>
        /// <param name="optimizationComp">Kind of optimization for the components. Default: "auto"</param>
        /// <param name="metricComp">Match metric used for the components. Default: "use_polarity"</param>
        /// <param name="pregenerationComp">Complete pregeneration of the shape models for the components if equal to 'true'. Default: "false"</param>
        /// <returns>Ranking of the model components expressing the suitability to act as the root component.</returns>
        public int CreateTrainedComponentModel(
          HComponentTraining componentTrainingID,
          double angleStart,
          double angleExtent,
          int minContrastComp,
          double minScoreComp,
          int numLevelsComp,
          double angleStepComp,
          string optimizationComp,
          string metricComp,
          string pregenerationComp)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1005);
            HalconAPI.Store(proc, 0, (HTool)componentTrainingID);
            HalconAPI.StoreD(proc, 1, angleStart);
            HalconAPI.StoreD(proc, 2, angleExtent);
            HalconAPI.StoreI(proc, 3, minContrastComp);
            HalconAPI.StoreD(proc, 4, minScoreComp);
            HalconAPI.StoreI(proc, 5, numLevelsComp);
            HalconAPI.StoreD(proc, 6, angleStepComp);
            HalconAPI.StoreS(proc, 7, optimizationComp);
            HalconAPI.StoreS(proc, 8, metricComp);
            HalconAPI.StoreS(proc, 9, pregenerationComp);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = this.Load(proc, 0, err1);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 1, err2, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)componentTrainingID);
            return intValue;
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(997);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
