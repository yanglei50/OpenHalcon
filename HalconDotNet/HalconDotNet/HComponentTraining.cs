// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HComponentTraining
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a training result for the component-based matching.</summary>
    [Serializable]
    public class HComponentTraining : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HComponentTraining()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HComponentTraining(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HComponentTraining obj)
        {
            obj = new HComponentTraining(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HComponentTraining[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HComponentTraining[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HComponentTraining(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Train components and relations for the component-based matching.
        ///   Modified instance represents: Handle of the training result.
        /// </summary>
        /// <param name="modelImage">Input image from which the shape models of the initial components should be created.</param>
        /// <param name="initialComponents">Contour regions or enclosing regions of the initial components.</param>
        /// <param name="trainingImages">Training images that are used for training the model components.</param>
        /// <param name="modelComponents">Contour regions of rigid model components.</param>
        /// <param name="contrastLow">Lower hysteresis threshold for the contrast of the initial components in the image. Default: "auto"</param>
        /// <param name="contrastHigh">Upper hysteresis threshold for the contrast of the initial components in the image. Default: "auto"</param>
        /// <param name="minSize">Minimum size of connected contour regions. Default: "auto"</param>
        /// <param name="minScore">Minimum score of the instances of the initial components to be found. Default: 0.5</param>
        /// <param name="searchRowTol">Search tolerance in row direction. Default: -1</param>
        /// <param name="searchColumnTol">Search tolerance in column direction. Default: -1</param>
        /// <param name="searchAngleTol">Angle search tolerance. Default: -1</param>
        /// <param name="trainingEmphasis">Decision whether the training emphasis should lie on a fast computation or on a high robustness. Default: "speed"</param>
        /// <param name="ambiguityCriterion">Criterion for solving ambiguous matches of the initial components in the training images. Default: "rigidity"</param>
        /// <param name="maxContourOverlap">Maximum contour overlap of the found initial components in a training image. Default: 0.2</param>
        /// <param name="clusterThreshold">Threshold for clustering the initial components. Default: 0.5</param>
        public HComponentTraining(
          HImage modelImage,
          HRegion initialComponents,
          HImage trainingImages,
          out HRegion modelComponents,
          HTuple contrastLow,
          HTuple contrastHigh,
          HTuple minSize,
          HTuple minScore,
          HTuple searchRowTol,
          HTuple searchColumnTol,
          HTuple searchAngleTol,
          string trainingEmphasis,
          string ambiguityCriterion,
          double maxContourOverlap,
          double clusterThreshold)
        {
            IntPtr proc = HalconAPI.PreCall(1017);
            HalconAPI.Store(proc, 1, (HObjectBase)modelImage);
            HalconAPI.Store(proc, 2, (HObjectBase)initialComponents);
            HalconAPI.Store(proc, 3, (HObjectBase)trainingImages);
            HalconAPI.Store(proc, 0, contrastLow);
            HalconAPI.Store(proc, 1, contrastHigh);
            HalconAPI.Store(proc, 2, minSize);
            HalconAPI.Store(proc, 3, minScore);
            HalconAPI.Store(proc, 4, searchRowTol);
            HalconAPI.Store(proc, 5, searchColumnTol);
            HalconAPI.Store(proc, 6, searchAngleTol);
            HalconAPI.StoreS(proc, 7, trainingEmphasis);
            HalconAPI.StoreS(proc, 8, ambiguityCriterion);
            HalconAPI.StoreD(proc, 9, maxContourOverlap);
            HalconAPI.StoreD(proc, 10, clusterThreshold);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(contrastLow);
            HalconAPI.UnpinTuple(contrastHigh);
            HalconAPI.UnpinTuple(minSize);
            HalconAPI.UnpinTuple(minScore);
            HalconAPI.UnpinTuple(searchRowTol);
            HalconAPI.UnpinTuple(searchColumnTol);
            HalconAPI.UnpinTuple(searchAngleTol);
            int err2 = this.Load(proc, 0, err1);
            int procResult = HRegion.LoadNew(proc, 1, err2, out modelComponents);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)modelImage);
            GC.KeepAlive((object)initialComponents);
            GC.KeepAlive((object)trainingImages);
        }

        /// <summary>
        ///   Train components and relations for the component-based matching.
        ///   Modified instance represents: Handle of the training result.
        /// </summary>
        /// <param name="modelImage">Input image from which the shape models of the initial components should be created.</param>
        /// <param name="initialComponents">Contour regions or enclosing regions of the initial components.</param>
        /// <param name="trainingImages">Training images that are used for training the model components.</param>
        /// <param name="modelComponents">Contour regions of rigid model components.</param>
        /// <param name="contrastLow">Lower hysteresis threshold for the contrast of the initial components in the image. Default: "auto"</param>
        /// <param name="contrastHigh">Upper hysteresis threshold for the contrast of the initial components in the image. Default: "auto"</param>
        /// <param name="minSize">Minimum size of connected contour regions. Default: "auto"</param>
        /// <param name="minScore">Minimum score of the instances of the initial components to be found. Default: 0.5</param>
        /// <param name="searchRowTol">Search tolerance in row direction. Default: -1</param>
        /// <param name="searchColumnTol">Search tolerance in column direction. Default: -1</param>
        /// <param name="searchAngleTol">Angle search tolerance. Default: -1</param>
        /// <param name="trainingEmphasis">Decision whether the training emphasis should lie on a fast computation or on a high robustness. Default: "speed"</param>
        /// <param name="ambiguityCriterion">Criterion for solving ambiguous matches of the initial components in the training images. Default: "rigidity"</param>
        /// <param name="maxContourOverlap">Maximum contour overlap of the found initial components in a training image. Default: 0.2</param>
        /// <param name="clusterThreshold">Threshold for clustering the initial components. Default: 0.5</param>
        public HComponentTraining(
          HImage modelImage,
          HRegion initialComponents,
          HImage trainingImages,
          out HRegion modelComponents,
          int contrastLow,
          int contrastHigh,
          int minSize,
          double minScore,
          int searchRowTol,
          int searchColumnTol,
          double searchAngleTol,
          string trainingEmphasis,
          string ambiguityCriterion,
          double maxContourOverlap,
          double clusterThreshold)
        {
            IntPtr proc = HalconAPI.PreCall(1017);
            HalconAPI.Store(proc, 1, (HObjectBase)modelImage);
            HalconAPI.Store(proc, 2, (HObjectBase)initialComponents);
            HalconAPI.Store(proc, 3, (HObjectBase)trainingImages);
            HalconAPI.StoreI(proc, 0, contrastLow);
            HalconAPI.StoreI(proc, 1, contrastHigh);
            HalconAPI.StoreI(proc, 2, minSize);
            HalconAPI.StoreD(proc, 3, minScore);
            HalconAPI.StoreI(proc, 4, searchRowTol);
            HalconAPI.StoreI(proc, 5, searchColumnTol);
            HalconAPI.StoreD(proc, 6, searchAngleTol);
            HalconAPI.StoreS(proc, 7, trainingEmphasis);
            HalconAPI.StoreS(proc, 8, ambiguityCriterion);
            HalconAPI.StoreD(proc, 9, maxContourOverlap);
            HalconAPI.StoreD(proc, 10, clusterThreshold);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = this.Load(proc, 0, err1);
            int procResult = HRegion.LoadNew(proc, 1, err2, out modelComponents);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)modelImage);
            GC.KeepAlive((object)initialComponents);
            GC.KeepAlive((object)trainingImages);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeTrainingComponents();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HComponentTraining(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeTrainingComponents(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeTrainingComponents().Serialize(stream);
        }

        public static HComponentTraining Deserialize(Stream stream)
        {
            HComponentTraining hcomponentTraining = new HComponentTraining();
            hcomponentTraining.DeserializeTrainingComponents(HSerializedItem.Deserialize(stream));
            return hcomponentTraining;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HComponentTraining Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeTrainingComponents();
            HComponentTraining hcomponentTraining = new HComponentTraining();
            hcomponentTraining.DeserializeTrainingComponents(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hcomponentTraining;
        }

        /// <summary>
        ///   Prepare a component model for matching based on trained components.
        ///   Instance represents: Handle of the training result.
        /// </summary>
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
        /// <returns>Handle of the component model.</returns>
        public HComponentModel CreateTrainedComponentModel(
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
            this.Store(proc, 0);
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
            HComponentModel hcomponentModel;
            int err2 = HComponentModel.LoadNew(proc, 0, err1, out hcomponentModel);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out rootRanking);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hcomponentModel;
        }

        /// <summary>
        ///   Prepare a component model for matching based on trained components.
        ///   Instance represents: Handle of the training result.
        /// </summary>
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
        /// <returns>Handle of the component model.</returns>
        public HComponentModel CreateTrainedComponentModel(
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
            this.Store(proc, 0);
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
            HComponentModel hcomponentModel;
            int err2 = HComponentModel.LoadNew(proc, 0, err1, out hcomponentModel);
            int procResult = HalconAPI.LoadI(proc, 1, err2, out rootRanking);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hcomponentModel;
        }

        /// <summary>
        ///   Return the relations between the model components that are contained in a training result.
        ///   Instance represents: Handle of the training result.
        /// </summary>
        /// <param name="referenceComponent">Index of reference component.</param>
        /// <param name="image">Image for which the component relations are to be returned. Default: "model_image"</param>
        /// <param name="row">Row coordinate of the center of the rectangle representing the relation.</param>
        /// <param name="column">Column index of the center of the rectangle representing the relation.</param>
        /// <param name="phi">Orientation of the rectangle representing the relation (radians).</param>
        /// <param name="length1">First radius (half length) of the rectangle representing the relation.</param>
        /// <param name="length2">Second radius (half width) of the rectangle representing the relation.</param>
        /// <param name="angleStart">Smallest relative orientation angle.</param>
        /// <param name="angleExtent">Extent of the relative orientation angles.</param>
        /// <returns>Region representation of the relations.</returns>
        public HRegion GetComponentRelations(
          int referenceComponent,
          HTuple image,
          out HTuple row,
          out HTuple column,
          out HTuple phi,
          out HTuple length1,
          out HTuple length2,
          out HTuple angleStart,
          out HTuple angleExtent)
        {
            IntPtr proc = HalconAPI.PreCall(1008);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, referenceComponent);
            HalconAPI.Store(proc, 2, image);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            HalconAPI.InitOCT(proc, 6);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(image);
            HRegion hregion;
            int err2 = HRegion.LoadNew(proc, 1, err1, out hregion);
            int err3 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err2, out row);
            int err4 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err3, out column);
            int err5 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err4, out phi);
            int err6 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err5, out length1);
            int err7 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err6, out length2);
            int err8 = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, err7, out angleStart);
            int procResult = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, err8, out angleExtent);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Return the relations between the model components that are contained in a training result.
        ///   Instance represents: Handle of the training result.
        /// </summary>
        /// <param name="referenceComponent">Index of reference component.</param>
        /// <param name="image">Image for which the component relations are to be returned. Default: "model_image"</param>
        /// <param name="row">Row coordinate of the center of the rectangle representing the relation.</param>
        /// <param name="column">Column index of the center of the rectangle representing the relation.</param>
        /// <param name="phi">Orientation of the rectangle representing the relation (radians).</param>
        /// <param name="length1">First radius (half length) of the rectangle representing the relation.</param>
        /// <param name="length2">Second radius (half width) of the rectangle representing the relation.</param>
        /// <param name="angleStart">Smallest relative orientation angle.</param>
        /// <param name="angleExtent">Extent of the relative orientation angles.</param>
        /// <returns>Region representation of the relations.</returns>
        public HRegion GetComponentRelations(
          int referenceComponent,
          string image,
          out double row,
          out double column,
          out double phi,
          out double length1,
          out double length2,
          out double angleStart,
          out double angleExtent)
        {
            IntPtr proc = HalconAPI.PreCall(1008);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, referenceComponent);
            HalconAPI.StoreS(proc, 2, image);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            HalconAPI.InitOCT(proc, 6);
            int err1 = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int err2 = HRegion.LoadNew(proc, 1, err1, out hregion);
            int err3 = HalconAPI.LoadD(proc, 0, err2, out row);
            int err4 = HalconAPI.LoadD(proc, 1, err3, out column);
            int err5 = HalconAPI.LoadD(proc, 2, err4, out phi);
            int err6 = HalconAPI.LoadD(proc, 3, err5, out length1);
            int err7 = HalconAPI.LoadD(proc, 4, err6, out length2);
            int err8 = HalconAPI.LoadD(proc, 5, err7, out angleStart);
            int procResult = HalconAPI.LoadD(proc, 6, err8, out angleExtent);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Return the initial or model components in a certain image.
        ///   Instance represents: Handle of the training result.
        /// </summary>
        /// <param name="components">Type of returned components or index of an initial component. Default: "model_components"</param>
        /// <param name="image">Image for which the components are to be returned. Default: "model_image"</param>
        /// <param name="markOrientation">Mark the orientation of the components. Default: "false"</param>
        /// <param name="row">Row coordinate of the found instances of all initial components or model components.</param>
        /// <param name="column">Column coordinate of the found instances of all initial components or model components.</param>
        /// <param name="angle">Rotation angle of the found instances of all components.</param>
        /// <param name="score">Score of the found instances of all components.</param>
        /// <returns>Contour regions of the initial components or of the model components.</returns>
        public HRegion GetTrainingComponents(
          HTuple components,
          HTuple image,
          string markOrientation,
          out HTuple row,
          out HTuple column,
          out HTuple angle,
          out HTuple score)
        {
            IntPtr proc = HalconAPI.PreCall(1009);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, components);
            HalconAPI.Store(proc, 2, image);
            HalconAPI.StoreS(proc, 3, markOrientation);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(components);
            HalconAPI.UnpinTuple(image);
            HRegion hregion;
            int err2 = HRegion.LoadNew(proc, 1, err1, out hregion);
            int err3 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err2, out row);
            int err4 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err3, out column);
            int err5 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err4, out angle);
            int procResult = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err5, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Return the initial or model components in a certain image.
        ///   Instance represents: Handle of the training result.
        /// </summary>
        /// <param name="components">Type of returned components or index of an initial component. Default: "model_components"</param>
        /// <param name="image">Image for which the components are to be returned. Default: "model_image"</param>
        /// <param name="markOrientation">Mark the orientation of the components. Default: "false"</param>
        /// <param name="row">Row coordinate of the found instances of all initial components or model components.</param>
        /// <param name="column">Column coordinate of the found instances of all initial components or model components.</param>
        /// <param name="angle">Rotation angle of the found instances of all components.</param>
        /// <param name="score">Score of the found instances of all components.</param>
        /// <returns>Contour regions of the initial components or of the model components.</returns>
        public HRegion GetTrainingComponents(
          string components,
          string image,
          string markOrientation,
          out double row,
          out double column,
          out double angle,
          out double score)
        {
            IntPtr proc = HalconAPI.PreCall(1009);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, components);
            HalconAPI.StoreS(proc, 2, image);
            HalconAPI.StoreS(proc, 3, markOrientation);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int err2 = HRegion.LoadNew(proc, 1, err1, out hregion);
            int err3 = HalconAPI.LoadD(proc, 0, err2, out row);
            int err4 = HalconAPI.LoadD(proc, 1, err3, out column);
            int err5 = HalconAPI.LoadD(proc, 2, err4, out angle);
            int procResult = HalconAPI.LoadD(proc, 3, err5, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Modify the relations within a training result.
        ///   Instance represents: Handle of the training result.
        /// </summary>
        /// <param name="referenceComponent">Model component(s) relative to which the movement(s) should be modified. Default: "all"</param>
        /// <param name="toleranceComponent">Model component(s) of which the relative movement(s) should be modified. Default: "all"</param>
        /// <param name="positionTolerance">Change of the position relation in pixels.</param>
        /// <param name="angleTolerance">Change of the orientation relation in radians.</param>
        public void ModifyComponentRelations(
          HTuple referenceComponent,
          HTuple toleranceComponent,
          HTuple positionTolerance,
          HTuple angleTolerance)
        {
            IntPtr proc = HalconAPI.PreCall(1010);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, referenceComponent);
            HalconAPI.Store(proc, 2, toleranceComponent);
            HalconAPI.Store(proc, 3, positionTolerance);
            HalconAPI.Store(proc, 4, angleTolerance);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(referenceComponent);
            HalconAPI.UnpinTuple(toleranceComponent);
            HalconAPI.UnpinTuple(positionTolerance);
            HalconAPI.UnpinTuple(angleTolerance);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Modify the relations within a training result.
        ///   Instance represents: Handle of the training result.
        /// </summary>
        /// <param name="referenceComponent">Model component(s) relative to which the movement(s) should be modified. Default: "all"</param>
        /// <param name="toleranceComponent">Model component(s) of which the relative movement(s) should be modified. Default: "all"</param>
        /// <param name="positionTolerance">Change of the position relation in pixels.</param>
        /// <param name="angleTolerance">Change of the orientation relation in radians.</param>
        public void ModifyComponentRelations(
          string referenceComponent,
          string toleranceComponent,
          double positionTolerance,
          double angleTolerance)
        {
            IntPtr proc = HalconAPI.PreCall(1010);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, referenceComponent);
            HalconAPI.StoreS(proc, 2, toleranceComponent);
            HalconAPI.StoreD(proc, 3, positionTolerance);
            HalconAPI.StoreD(proc, 4, angleTolerance);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Deserialize a component training result.
        ///   Modified instance represents: Handle of the training result.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeTrainingComponents(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1011);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize a component training result.
        ///   Instance represents: Handle of the training result.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeTrainingComponents()
        {
            IntPtr proc = HalconAPI.PreCall(1012);
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
        ///   Read a component training result from a file.
        ///   Modified instance represents: Handle of the training result.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void ReadTrainingComponents(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1013);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write a component training result to a file.
        ///   Instance represents: Handle of the training result.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void WriteTrainingComponents(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1014);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Adopt new parameters that are used to create the model components into the training result.
        ///   Instance represents: Handle of the training result.
        /// </summary>
        /// <param name="trainingImages">Training images that were used for training the model components.</param>
        /// <param name="ambiguityCriterion">Criterion for solving the ambiguities. Default: "rigidity"</param>
        /// <param name="maxContourOverlap">Maximum contour overlap of the found initial components. Default: 0.2</param>
        /// <param name="clusterThreshold">Threshold for clustering the initial components. Default: 0.5</param>
        /// <returns>Contour regions of rigid model components.</returns>
        public HRegion ClusterModelComponents(
          HImage trainingImages,
          string ambiguityCriterion,
          double maxContourOverlap,
          double clusterThreshold)
        {
            IntPtr proc = HalconAPI.PreCall(1015);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)trainingImages);
            HalconAPI.StoreS(proc, 1, ambiguityCriterion);
            HalconAPI.StoreD(proc, 2, maxContourOverlap);
            HalconAPI.StoreD(proc, 3, clusterThreshold);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)trainingImages);
            return hregion;
        }

        /// <summary>
        ///   Inspect the rigid model components obtained from the training.
        ///   Instance represents: Handle of the training result.
        /// </summary>
        /// <param name="ambiguityCriterion">Criterion for solving the ambiguities. Default: "rigidity"</param>
        /// <param name="maxContourOverlap">Maximum contour overlap of the found initial components. Default: 0.2</param>
        /// <param name="clusterThreshold">Threshold for clustering the initial components. Default: 0.5</param>
        /// <returns>Contour regions of rigid model components.</returns>
        public HRegion InspectClusteredComponents(
          string ambiguityCriterion,
          double maxContourOverlap,
          double clusterThreshold)
        {
            IntPtr proc = HalconAPI.PreCall(1016);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, ambiguityCriterion);
            HalconAPI.StoreD(proc, 2, maxContourOverlap);
            HalconAPI.StoreD(proc, 3, clusterThreshold);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hregion;
        }

        /// <summary>
        ///   Train components and relations for the component-based matching.
        ///   Modified instance represents: Handle of the training result.
        /// </summary>
        /// <param name="modelImage">Input image from which the shape models of the initial components should be created.</param>
        /// <param name="initialComponents">Contour regions or enclosing regions of the initial components.</param>
        /// <param name="trainingImages">Training images that are used for training the model components.</param>
        /// <param name="contrastLow">Lower hysteresis threshold for the contrast of the initial components in the image. Default: "auto"</param>
        /// <param name="contrastHigh">Upper hysteresis threshold for the contrast of the initial components in the image. Default: "auto"</param>
        /// <param name="minSize">Minimum size of connected contour regions. Default: "auto"</param>
        /// <param name="minScore">Minimum score of the instances of the initial components to be found. Default: 0.5</param>
        /// <param name="searchRowTol">Search tolerance in row direction. Default: -1</param>
        /// <param name="searchColumnTol">Search tolerance in column direction. Default: -1</param>
        /// <param name="searchAngleTol">Angle search tolerance. Default: -1</param>
        /// <param name="trainingEmphasis">Decision whether the training emphasis should lie on a fast computation or on a high robustness. Default: "speed"</param>
        /// <param name="ambiguityCriterion">Criterion for solving ambiguous matches of the initial components in the training images. Default: "rigidity"</param>
        /// <param name="maxContourOverlap">Maximum contour overlap of the found initial components in a training image. Default: 0.2</param>
        /// <param name="clusterThreshold">Threshold for clustering the initial components. Default: 0.5</param>
        /// <returns>Contour regions of rigid model components.</returns>
        public HRegion TrainModelComponents(
          HImage modelImage,
          HRegion initialComponents,
          HImage trainingImages,
          HTuple contrastLow,
          HTuple contrastHigh,
          HTuple minSize,
          HTuple minScore,
          HTuple searchRowTol,
          HTuple searchColumnTol,
          HTuple searchAngleTol,
          string trainingEmphasis,
          string ambiguityCriterion,
          double maxContourOverlap,
          double clusterThreshold)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1017);
            HalconAPI.Store(proc, 1, (HObjectBase)modelImage);
            HalconAPI.Store(proc, 2, (HObjectBase)initialComponents);
            HalconAPI.Store(proc, 3, (HObjectBase)trainingImages);
            HalconAPI.Store(proc, 0, contrastLow);
            HalconAPI.Store(proc, 1, contrastHigh);
            HalconAPI.Store(proc, 2, minSize);
            HalconAPI.Store(proc, 3, minScore);
            HalconAPI.Store(proc, 4, searchRowTol);
            HalconAPI.Store(proc, 5, searchColumnTol);
            HalconAPI.Store(proc, 6, searchAngleTol);
            HalconAPI.StoreS(proc, 7, trainingEmphasis);
            HalconAPI.StoreS(proc, 8, ambiguityCriterion);
            HalconAPI.StoreD(proc, 9, maxContourOverlap);
            HalconAPI.StoreD(proc, 10, clusterThreshold);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(contrastLow);
            HalconAPI.UnpinTuple(contrastHigh);
            HalconAPI.UnpinTuple(minSize);
            HalconAPI.UnpinTuple(minScore);
            HalconAPI.UnpinTuple(searchRowTol);
            HalconAPI.UnpinTuple(searchColumnTol);
            HalconAPI.UnpinTuple(searchAngleTol);
            int err2 = this.Load(proc, 0, err1);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err2, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)modelImage);
            GC.KeepAlive((object)initialComponents);
            GC.KeepAlive((object)trainingImages);
            return hregion;
        }

        /// <summary>
        ///   Train components and relations for the component-based matching.
        ///   Modified instance represents: Handle of the training result.
        /// </summary>
        /// <param name="modelImage">Input image from which the shape models of the initial components should be created.</param>
        /// <param name="initialComponents">Contour regions or enclosing regions of the initial components.</param>
        /// <param name="trainingImages">Training images that are used for training the model components.</param>
        /// <param name="contrastLow">Lower hysteresis threshold for the contrast of the initial components in the image. Default: "auto"</param>
        /// <param name="contrastHigh">Upper hysteresis threshold for the contrast of the initial components in the image. Default: "auto"</param>
        /// <param name="minSize">Minimum size of connected contour regions. Default: "auto"</param>
        /// <param name="minScore">Minimum score of the instances of the initial components to be found. Default: 0.5</param>
        /// <param name="searchRowTol">Search tolerance in row direction. Default: -1</param>
        /// <param name="searchColumnTol">Search tolerance in column direction. Default: -1</param>
        /// <param name="searchAngleTol">Angle search tolerance. Default: -1</param>
        /// <param name="trainingEmphasis">Decision whether the training emphasis should lie on a fast computation or on a high robustness. Default: "speed"</param>
        /// <param name="ambiguityCriterion">Criterion for solving ambiguous matches of the initial components in the training images. Default: "rigidity"</param>
        /// <param name="maxContourOverlap">Maximum contour overlap of the found initial components in a training image. Default: 0.2</param>
        /// <param name="clusterThreshold">Threshold for clustering the initial components. Default: 0.5</param>
        /// <returns>Contour regions of rigid model components.</returns>
        public HRegion TrainModelComponents(
          HImage modelImage,
          HRegion initialComponents,
          HImage trainingImages,
          int contrastLow,
          int contrastHigh,
          int minSize,
          double minScore,
          int searchRowTol,
          int searchColumnTol,
          double searchAngleTol,
          string trainingEmphasis,
          string ambiguityCriterion,
          double maxContourOverlap,
          double clusterThreshold)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1017);
            HalconAPI.Store(proc, 1, (HObjectBase)modelImage);
            HalconAPI.Store(proc, 2, (HObjectBase)initialComponents);
            HalconAPI.Store(proc, 3, (HObjectBase)trainingImages);
            HalconAPI.StoreI(proc, 0, contrastLow);
            HalconAPI.StoreI(proc, 1, contrastHigh);
            HalconAPI.StoreI(proc, 2, minSize);
            HalconAPI.StoreD(proc, 3, minScore);
            HalconAPI.StoreI(proc, 4, searchRowTol);
            HalconAPI.StoreI(proc, 5, searchColumnTol);
            HalconAPI.StoreD(proc, 6, searchAngleTol);
            HalconAPI.StoreS(proc, 7, trainingEmphasis);
            HalconAPI.StoreS(proc, 8, ambiguityCriterion);
            HalconAPI.StoreD(proc, 9, maxContourOverlap);
            HalconAPI.StoreD(proc, 10, clusterThreshold);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = this.Load(proc, 0, err1);
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err2, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)modelImage);
            GC.KeepAlive((object)initialComponents);
            GC.KeepAlive((object)trainingImages);
            return hregion;
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(1007);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
