// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HCamPar
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents internal camera parameters.</summary>
    [Serializable]
    public class HCamPar : HData, ISerializable, ICloneable
    {
        /// <summary>Create an uninitialized instance.</summary>
        public HCamPar()
        {
        }

        public HCamPar(HTuple tuple)
          : base(tuple)
        {
        }

        internal HCamPar(HData data)
          : base(data)
        {
        }

        internal static int LoadNew(
          IntPtr proc,
          int parIndex,
          HTupleType type,
          int err,
          out HCamPar obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HCamPar(new HData(tuple));
            return err;
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HCamPar obj)
        {
            return HCamPar.LoadNew(proc, parIndex, HTupleType.MIXED, err, out obj);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeCamPar();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HCamPar(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeCamPar(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeCamPar().Serialize(stream);
        }

        public static HCamPar Deserialize(Stream stream)
        {
            HCamPar hcamPar = new HCamPar();
            hcamPar.DeserializeCamPar(HSerializedItem.Deserialize(stream));
            return hcamPar;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HCamPar Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeCamPar();
            HCamPar hcamPar = new HCamPar();
            hcamPar.DeserializeCamPar(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hcamPar;
        }

        /// <summary>
        ///   Compute the distance values for a rectified stereo image pair using multi-scanline optimization.
        ///   Instance represents: Internal camera parameters of the rectified camera 1.
        /// </summary>
        /// <param name="imageRect1">Rectified image of camera 1.</param>
        /// <param name="imageRect2">Rectified image of camera 2.</param>
        /// <param name="score">Score of the calculated disparity.</param>
        /// <param name="camParamRect2">Internal camera parameters of the rectified camera 2.</param>
        /// <param name="relPoseRect">Point transformation from the rectified camera 2 to the rectified camera 1.</param>
        /// <param name="minDisparity">Minimum of the expected disparities. Default: -30</param>
        /// <param name="maxDisparity">Maximum of the expected disparities. Default: 30</param>
        /// <param name="surfaceSmoothing">Smoothing of surfaces. Default: 50</param>
        /// <param name="edgeSmoothing">Smoothing of edges. Default: 50</param>
        /// <param name="genParamName">Parameter name(s) for the multi-scanline algorithm. Default: []</param>
        /// <param name="genParamValue">Parameter value(s) for the multi-scanline algorithm. Default: []</param>
        /// <returns>Distance image.</returns>
        public HImage BinocularDistanceMs(
          HImage imageRect1,
          HImage imageRect2,
          out HImage score,
          HCamPar camParamRect2,
          HPose relPoseRect,
          int minDisparity,
          int maxDisparity,
          int surfaceSmoothing,
          int edgeSmoothing,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(346);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)imageRect1);
            HalconAPI.Store(proc, 2, (HObjectBase)imageRect2);
            HalconAPI.Store(proc, 1, (HData)camParamRect2);
            HalconAPI.Store(proc, 2, (HData)relPoseRect);
            HalconAPI.StoreI(proc, 3, minDisparity);
            HalconAPI.StoreI(proc, 4, maxDisparity);
            HalconAPI.StoreI(proc, 5, surfaceSmoothing);
            HalconAPI.StoreI(proc, 6, edgeSmoothing);
            HalconAPI.Store(proc, 7, genParamName);
            HalconAPI.Store(proc, 8, genParamValue);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect2));
            HalconAPI.UnpinTuple((HTuple)((HData)relPoseRect));
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HImage himage;
            int err2 = HImage.LoadNew(proc, 1, err1, out himage);
            int procResult = HImage.LoadNew(proc, 2, err2, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)imageRect1);
            GC.KeepAlive((object)imageRect2);
            return himage;
        }

        /// <summary>
        ///   Compute the distance values for a rectified stereo image pair using multi-scanline optimization.
        ///   Instance represents: Internal camera parameters of the rectified camera 1.
        /// </summary>
        /// <param name="imageRect1">Rectified image of camera 1.</param>
        /// <param name="imageRect2">Rectified image of camera 2.</param>
        /// <param name="score">Score of the calculated disparity.</param>
        /// <param name="camParamRect2">Internal camera parameters of the rectified camera 2.</param>
        /// <param name="relPoseRect">Point transformation from the rectified camera 2 to the rectified camera 1.</param>
        /// <param name="minDisparity">Minimum of the expected disparities. Default: -30</param>
        /// <param name="maxDisparity">Maximum of the expected disparities. Default: 30</param>
        /// <param name="surfaceSmoothing">Smoothing of surfaces. Default: 50</param>
        /// <param name="edgeSmoothing">Smoothing of edges. Default: 50</param>
        /// <param name="genParamName">Parameter name(s) for the multi-scanline algorithm. Default: []</param>
        /// <param name="genParamValue">Parameter value(s) for the multi-scanline algorithm. Default: []</param>
        /// <returns>Distance image.</returns>
        public HImage BinocularDistanceMs(
          HImage imageRect1,
          HImage imageRect2,
          out HImage score,
          HCamPar camParamRect2,
          HPose relPoseRect,
          int minDisparity,
          int maxDisparity,
          int surfaceSmoothing,
          int edgeSmoothing,
          string genParamName,
          string genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(346);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)imageRect1);
            HalconAPI.Store(proc, 2, (HObjectBase)imageRect2);
            HalconAPI.Store(proc, 1, (HData)camParamRect2);
            HalconAPI.Store(proc, 2, (HData)relPoseRect);
            HalconAPI.StoreI(proc, 3, minDisparity);
            HalconAPI.StoreI(proc, 4, maxDisparity);
            HalconAPI.StoreI(proc, 5, surfaceSmoothing);
            HalconAPI.StoreI(proc, 6, edgeSmoothing);
            HalconAPI.StoreS(proc, 7, genParamName);
            HalconAPI.StoreS(proc, 8, genParamValue);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect2));
            HalconAPI.UnpinTuple((HTuple)((HData)relPoseRect));
            HImage himage;
            int err2 = HImage.LoadNew(proc, 1, err1, out himage);
            int procResult = HImage.LoadNew(proc, 2, err2, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)imageRect1);
            GC.KeepAlive((object)imageRect2);
            return himage;
        }

        /// <summary>
        ///   Compute the distance values for a rectified stereo image pair using multigrid methods.
        ///   Instance represents: Internal camera parameters of the rectified camera 1.
        /// </summary>
        /// <param name="imageRect1">Rectified image of camera 1.</param>
        /// <param name="imageRect2">Rectified image of camera 2.</param>
        /// <param name="score">Score of the calculated disparity if CalculateScore is set to 'true'.</param>
        /// <param name="camParamRect2">Internal camera parameters of the rectified camera 2.</param>
        /// <param name="relPoseRect">Point transformation from the rectified camera 2 to the rectified camera 1.</param>
        /// <param name="grayConstancy">Weight of the gray value constancy in the data term. Default: 1.0</param>
        /// <param name="gradientConstancy">Weight of the gradient constancy in the data term. Default: 30.0</param>
        /// <param name="smoothness">Weight of the smoothness term in relation to the data term. Default: 5.0</param>
        /// <param name="initialGuess">Initial guess of the disparity. Default: 0.0</param>
        /// <param name="calculateScore">Should the quality measure be returned in Score? Default: "false"</param>
        /// <param name="MGParamName">Parameter name(s) for the multigrid algorithm. Default: "default_parameters"</param>
        /// <param name="MGParamValue">Parameter value(s) for the multigrid algorithm. Default: "fast_accurate"</param>
        /// <returns>Distance image.</returns>
        public HImage BinocularDistanceMg(
          HImage imageRect1,
          HImage imageRect2,
          out HImage score,
          HCamPar camParamRect2,
          HPose relPoseRect,
          double grayConstancy,
          double gradientConstancy,
          double smoothness,
          double initialGuess,
          string calculateScore,
          HTuple MGParamName,
          HTuple MGParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(348);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)imageRect1);
            HalconAPI.Store(proc, 2, (HObjectBase)imageRect2);
            HalconAPI.Store(proc, 1, (HData)camParamRect2);
            HalconAPI.Store(proc, 2, (HData)relPoseRect);
            HalconAPI.StoreD(proc, 3, grayConstancy);
            HalconAPI.StoreD(proc, 4, gradientConstancy);
            HalconAPI.StoreD(proc, 5, smoothness);
            HalconAPI.StoreD(proc, 6, initialGuess);
            HalconAPI.StoreS(proc, 7, calculateScore);
            HalconAPI.Store(proc, 8, MGParamName);
            HalconAPI.Store(proc, 9, MGParamValue);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect2));
            HalconAPI.UnpinTuple((HTuple)((HData)relPoseRect));
            HalconAPI.UnpinTuple(MGParamName);
            HalconAPI.UnpinTuple(MGParamValue);
            HImage himage;
            int err2 = HImage.LoadNew(proc, 1, err1, out himage);
            int procResult = HImage.LoadNew(proc, 2, err2, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)imageRect1);
            GC.KeepAlive((object)imageRect2);
            return himage;
        }

        /// <summary>
        ///   Compute the distance values for a rectified stereo image pair using multigrid methods.
        ///   Instance represents: Internal camera parameters of the rectified camera 1.
        /// </summary>
        /// <param name="imageRect1">Rectified image of camera 1.</param>
        /// <param name="imageRect2">Rectified image of camera 2.</param>
        /// <param name="score">Score of the calculated disparity if CalculateScore is set to 'true'.</param>
        /// <param name="camParamRect2">Internal camera parameters of the rectified camera 2.</param>
        /// <param name="relPoseRect">Point transformation from the rectified camera 2 to the rectified camera 1.</param>
        /// <param name="grayConstancy">Weight of the gray value constancy in the data term. Default: 1.0</param>
        /// <param name="gradientConstancy">Weight of the gradient constancy in the data term. Default: 30.0</param>
        /// <param name="smoothness">Weight of the smoothness term in relation to the data term. Default: 5.0</param>
        /// <param name="initialGuess">Initial guess of the disparity. Default: 0.0</param>
        /// <param name="calculateScore">Should the quality measure be returned in Score? Default: "false"</param>
        /// <param name="MGParamName">Parameter name(s) for the multigrid algorithm. Default: "default_parameters"</param>
        /// <param name="MGParamValue">Parameter value(s) for the multigrid algorithm. Default: "fast_accurate"</param>
        /// <returns>Distance image.</returns>
        public HImage BinocularDistanceMg(
          HImage imageRect1,
          HImage imageRect2,
          out HImage score,
          HCamPar camParamRect2,
          HPose relPoseRect,
          double grayConstancy,
          double gradientConstancy,
          double smoothness,
          double initialGuess,
          string calculateScore,
          string MGParamName,
          string MGParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(348);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)imageRect1);
            HalconAPI.Store(proc, 2, (HObjectBase)imageRect2);
            HalconAPI.Store(proc, 1, (HData)camParamRect2);
            HalconAPI.Store(proc, 2, (HData)relPoseRect);
            HalconAPI.StoreD(proc, 3, grayConstancy);
            HalconAPI.StoreD(proc, 4, gradientConstancy);
            HalconAPI.StoreD(proc, 5, smoothness);
            HalconAPI.StoreD(proc, 6, initialGuess);
            HalconAPI.StoreS(proc, 7, calculateScore);
            HalconAPI.StoreS(proc, 8, MGParamName);
            HalconAPI.StoreS(proc, 9, MGParamValue);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect2));
            HalconAPI.UnpinTuple((HTuple)((HData)relPoseRect));
            HImage himage;
            int err2 = HImage.LoadNew(proc, 1, err1, out himage);
            int procResult = HImage.LoadNew(proc, 2, err2, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)imageRect1);
            GC.KeepAlive((object)imageRect2);
            return himage;
        }

        /// <summary>
        ///   Compute the fundamental matrix from the relative orientation of two cameras.
        ///   Instance represents: Parameters of the 1. camera.
        /// </summary>
        /// <param name="relPose">Relative orientation of the cameras (3D pose).</param>
        /// <param name="covRelPose">6x6 covariance matrix of relative pose. Default: []</param>
        /// <param name="camPar2">Parameters of the 2. camera.</param>
        /// <param name="covFMat">9x9 covariance matrix of the fundamental matrix.</param>
        /// <returns>Computed fundamental matrix.</returns>
        public HHomMat2D RelPoseToFundamentalMatrix(
          HPose relPose,
          HTuple covRelPose,
          HCamPar camPar2,
          out HTuple covFMat)
        {
            IntPtr proc = HalconAPI.PreCall(353);
            this.Store(proc, 2);
            HalconAPI.Store(proc, 0, (HData)relPose);
            HalconAPI.Store(proc, 1, covRelPose);
            HalconAPI.Store(proc, 3, (HData)camPar2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)relPose));
            HalconAPI.UnpinTuple(covRelPose);
            HalconAPI.UnpinTuple((HTuple)((HData)camPar2));
            HHomMat2D hhomMat2D;
            int err2 = HHomMat2D.LoadNew(proc, 0, err1, out hhomMat2D);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out covFMat);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat2D;
        }

        /// <summary>
        ///   Compute the relative orientation between two cameras given image point correspondences and known camera parameters and reconstruct 3D space points.
        ///   Instance represents: Camera parameters of the 1st camera.
        /// </summary>
        /// <param name="rows1">Input points in image 1 (row coordinate).</param>
        /// <param name="cols1">Input points in image 1 (column coordinate).</param>
        /// <param name="rows2">Input points in image 2 (row coordinate).</param>
        /// <param name="cols2">Input points in image 2 (column coordinate).</param>
        /// <param name="covRR1">Row coordinate variance of the points in image 1. Default: []</param>
        /// <param name="covRC1">Covariance of the points in image 1. Default: []</param>
        /// <param name="covCC1">Column coordinate variance of the points in image 1. Default: []</param>
        /// <param name="covRR2">Row coordinate variance of the points in image 2. Default: []</param>
        /// <param name="covRC2">Covariance of the points in image 2. Default: []</param>
        /// <param name="covCC2">Column coordinate variance of the points in image 2. Default: []</param>
        /// <param name="camPar2">Camera parameters of the 2nd camera.</param>
        /// <param name="method">Algorithm for the computation of the relative pose and for special pose types. Default: "normalized_dlt"</param>
        /// <param name="covRelPose">6x6 covariance matrix of the relative camera orientation.</param>
        /// <param name="error">Root-Mean-Square of the epipolar distance error.</param>
        /// <param name="x">X coordinates of the reconstructed 3D points.</param>
        /// <param name="y">Y coordinates of the reconstructed 3D points.</param>
        /// <param name="z">Z coordinates of the reconstructed 3D points.</param>
        /// <param name="covXYZ">Covariance matrices of the  reconstructed 3D points.</param>
        /// <returns>Computed relative orientation of the cameras (3D pose).</returns>
        public HPose VectorToRelPose(
          HTuple rows1,
          HTuple cols1,
          HTuple rows2,
          HTuple cols2,
          HTuple covRR1,
          HTuple covRC1,
          HTuple covCC1,
          HTuple covRR2,
          HTuple covRC2,
          HTuple covCC2,
          HCamPar camPar2,
          string method,
          out HTuple covRelPose,
          out HTuple error,
          out HTuple x,
          out HTuple y,
          out HTuple z,
          out HTuple covXYZ)
        {
            IntPtr proc = HalconAPI.PreCall(355);
            this.Store(proc, 10);
            HalconAPI.Store(proc, 0, rows1);
            HalconAPI.Store(proc, 1, cols1);
            HalconAPI.Store(proc, 2, rows2);
            HalconAPI.Store(proc, 3, cols2);
            HalconAPI.Store(proc, 4, covRR1);
            HalconAPI.Store(proc, 5, covRC1);
            HalconAPI.Store(proc, 6, covCC1);
            HalconAPI.Store(proc, 7, covRR2);
            HalconAPI.Store(proc, 8, covRC2);
            HalconAPI.Store(proc, 9, covCC2);
            HalconAPI.Store(proc, 11, (HData)camPar2);
            HalconAPI.StoreS(proc, 12, method);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            HalconAPI.InitOCT(proc, 6);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(rows1);
            HalconAPI.UnpinTuple(cols1);
            HalconAPI.UnpinTuple(rows2);
            HalconAPI.UnpinTuple(cols2);
            HalconAPI.UnpinTuple(covRR1);
            HalconAPI.UnpinTuple(covRC1);
            HalconAPI.UnpinTuple(covCC1);
            HalconAPI.UnpinTuple(covRR2);
            HalconAPI.UnpinTuple(covRC2);
            HalconAPI.UnpinTuple(covCC2);
            HalconAPI.UnpinTuple((HTuple)((HData)camPar2));
            HPose hpose;
            int err2 = HPose.LoadNew(proc, 0, err1, out hpose);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out covRelPose);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out error);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out x);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out y);
            int err7 = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, err6, out z);
            int procResult = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, err7, out covXYZ);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hpose;
        }

        /// <summary>
        ///   Compute the relative orientation between two cameras given image point correspondences and known camera parameters and reconstruct 3D space points.
        ///   Instance represents: Camera parameters of the 1st camera.
        /// </summary>
        /// <param name="rows1">Input points in image 1 (row coordinate).</param>
        /// <param name="cols1">Input points in image 1 (column coordinate).</param>
        /// <param name="rows2">Input points in image 2 (row coordinate).</param>
        /// <param name="cols2">Input points in image 2 (column coordinate).</param>
        /// <param name="covRR1">Row coordinate variance of the points in image 1. Default: []</param>
        /// <param name="covRC1">Covariance of the points in image 1. Default: []</param>
        /// <param name="covCC1">Column coordinate variance of the points in image 1. Default: []</param>
        /// <param name="covRR2">Row coordinate variance of the points in image 2. Default: []</param>
        /// <param name="covRC2">Covariance of the points in image 2. Default: []</param>
        /// <param name="covCC2">Column coordinate variance of the points in image 2. Default: []</param>
        /// <param name="camPar2">Camera parameters of the 2nd camera.</param>
        /// <param name="method">Algorithm for the computation of the relative pose and for special pose types. Default: "normalized_dlt"</param>
        /// <param name="covRelPose">6x6 covariance matrix of the relative camera orientation.</param>
        /// <param name="error">Root-Mean-Square of the epipolar distance error.</param>
        /// <param name="x">X coordinates of the reconstructed 3D points.</param>
        /// <param name="y">Y coordinates of the reconstructed 3D points.</param>
        /// <param name="z">Z coordinates of the reconstructed 3D points.</param>
        /// <param name="covXYZ">Covariance matrices of the  reconstructed 3D points.</param>
        /// <returns>Computed relative orientation of the cameras (3D pose).</returns>
        public HPose VectorToRelPose(
          HTuple rows1,
          HTuple cols1,
          HTuple rows2,
          HTuple cols2,
          HTuple covRR1,
          HTuple covRC1,
          HTuple covCC1,
          HTuple covRR2,
          HTuple covRC2,
          HTuple covCC2,
          HCamPar camPar2,
          string method,
          out HTuple covRelPose,
          out double error,
          out HTuple x,
          out HTuple y,
          out HTuple z,
          out HTuple covXYZ)
        {
            IntPtr proc = HalconAPI.PreCall(355);
            this.Store(proc, 10);
            HalconAPI.Store(proc, 0, rows1);
            HalconAPI.Store(proc, 1, cols1);
            HalconAPI.Store(proc, 2, rows2);
            HalconAPI.Store(proc, 3, cols2);
            HalconAPI.Store(proc, 4, covRR1);
            HalconAPI.Store(proc, 5, covRC1);
            HalconAPI.Store(proc, 6, covCC1);
            HalconAPI.Store(proc, 7, covRR2);
            HalconAPI.Store(proc, 8, covRC2);
            HalconAPI.Store(proc, 9, covCC2);
            HalconAPI.Store(proc, 11, (HData)camPar2);
            HalconAPI.StoreS(proc, 12, method);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            HalconAPI.InitOCT(proc, 6);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(rows1);
            HalconAPI.UnpinTuple(cols1);
            HalconAPI.UnpinTuple(rows2);
            HalconAPI.UnpinTuple(cols2);
            HalconAPI.UnpinTuple(covRR1);
            HalconAPI.UnpinTuple(covRC1);
            HalconAPI.UnpinTuple(covCC1);
            HalconAPI.UnpinTuple(covRR2);
            HalconAPI.UnpinTuple(covRC2);
            HalconAPI.UnpinTuple(covCC2);
            HalconAPI.UnpinTuple((HTuple)((HData)camPar2));
            HPose hpose;
            int err2 = HPose.LoadNew(proc, 0, err1, out hpose);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out covRelPose);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out error);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out x);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out y);
            int err7 = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, err6, out z);
            int procResult = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, err7, out covXYZ);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hpose;
        }

        /// <summary>
        ///   Compute the relative orientation between two cameras by automatically finding correspondences between image points.
        ///   Instance represents: Parameters of the 1st camera.
        /// </summary>
        /// <param name="image1">Input image 1.</param>
        /// <param name="image2">Input image 2.</param>
        /// <param name="rows1">Row coordinates of characteristic points in image 1.</param>
        /// <param name="cols1">Column coordinates of characteristic points in image 1.</param>
        /// <param name="rows2">Row coordinates of characteristic points in image 2.</param>
        /// <param name="cols2">Column coordinates of characteristic points in image 2.</param>
        /// <param name="camPar2">Parameters of the 2nd camera.</param>
        /// <param name="grayMatchMethod">Gray value comparison metric. Default: "ssd"</param>
        /// <param name="maskSize">Size of gray value masks. Default: 10</param>
        /// <param name="rowMove">Average row coordinate shift of corresponding points. Default: 0</param>
        /// <param name="colMove">Average column coordinate shift of corresponding points. Default: 0</param>
        /// <param name="rowTolerance">Half height of matching search window. Default: 200</param>
        /// <param name="colTolerance">Half width of matching search window. Default: 200</param>
        /// <param name="rotation">Estimate of the relative orientation of the right image with respect to the left image. Default: 0.0</param>
        /// <param name="matchThreshold">Threshold for gray value matching. Default: 10</param>
        /// <param name="estimationMethod">Algorithm for the computation of the relative pose and for special pose types. Default: "normalized_dlt"</param>
        /// <param name="distanceThreshold">Maximal deviation of a point from its epipolar line. Default: 1</param>
        /// <param name="randSeed">Seed for the random number generator. Default: 0</param>
        /// <param name="covRelPose">6x6 covariance matrix of the relative orientation.</param>
        /// <param name="error">Root-Mean-Square of the epipolar distance error.</param>
        /// <param name="points1">Indices of matched input points in image 1.</param>
        /// <param name="points2">Indices of matched input points in image 2.</param>
        /// <returns>Computed relative orientation of the cameras (3D pose).</returns>
        public HPose MatchRelPoseRansac(
          HImage image1,
          HImage image2,
          HTuple rows1,
          HTuple cols1,
          HTuple rows2,
          HTuple cols2,
          HCamPar camPar2,
          string grayMatchMethod,
          int maskSize,
          int rowMove,
          int colMove,
          int rowTolerance,
          int colTolerance,
          HTuple rotation,
          HTuple matchThreshold,
          string estimationMethod,
          HTuple distanceThreshold,
          int randSeed,
          out HTuple covRelPose,
          out HTuple error,
          out HTuple points1,
          out HTuple points2)
        {
            IntPtr proc = HalconAPI.PreCall(359);
            this.Store(proc, 4);
            HalconAPI.Store(proc, 1, (HObjectBase)image1);
            HalconAPI.Store(proc, 2, (HObjectBase)image2);
            HalconAPI.Store(proc, 0, rows1);
            HalconAPI.Store(proc, 1, cols1);
            HalconAPI.Store(proc, 2, rows2);
            HalconAPI.Store(proc, 3, cols2);
            HalconAPI.Store(proc, 5, (HData)camPar2);
            HalconAPI.StoreS(proc, 6, grayMatchMethod);
            HalconAPI.StoreI(proc, 7, maskSize);
            HalconAPI.StoreI(proc, 8, rowMove);
            HalconAPI.StoreI(proc, 9, colMove);
            HalconAPI.StoreI(proc, 10, rowTolerance);
            HalconAPI.StoreI(proc, 11, colTolerance);
            HalconAPI.Store(proc, 12, rotation);
            HalconAPI.Store(proc, 13, matchThreshold);
            HalconAPI.StoreS(proc, 14, estimationMethod);
            HalconAPI.Store(proc, 15, distanceThreshold);
            HalconAPI.StoreI(proc, 16, randSeed);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(rows1);
            HalconAPI.UnpinTuple(cols1);
            HalconAPI.UnpinTuple(rows2);
            HalconAPI.UnpinTuple(cols2);
            HalconAPI.UnpinTuple((HTuple)((HData)camPar2));
            HalconAPI.UnpinTuple(rotation);
            HalconAPI.UnpinTuple(matchThreshold);
            HalconAPI.UnpinTuple(distanceThreshold);
            HPose hpose;
            int err2 = HPose.LoadNew(proc, 0, err1, out hpose);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out covRelPose);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out error);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, err4, out points1);
            int procResult = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, err5, out points2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image1);
            GC.KeepAlive((object)image2);
            return hpose;
        }

        /// <summary>
        ///   Compute the relative orientation between two cameras by automatically finding correspondences between image points.
        ///   Instance represents: Parameters of the 1st camera.
        /// </summary>
        /// <param name="image1">Input image 1.</param>
        /// <param name="image2">Input image 2.</param>
        /// <param name="rows1">Row coordinates of characteristic points in image 1.</param>
        /// <param name="cols1">Column coordinates of characteristic points in image 1.</param>
        /// <param name="rows2">Row coordinates of characteristic points in image 2.</param>
        /// <param name="cols2">Column coordinates of characteristic points in image 2.</param>
        /// <param name="camPar2">Parameters of the 2nd camera.</param>
        /// <param name="grayMatchMethod">Gray value comparison metric. Default: "ssd"</param>
        /// <param name="maskSize">Size of gray value masks. Default: 10</param>
        /// <param name="rowMove">Average row coordinate shift of corresponding points. Default: 0</param>
        /// <param name="colMove">Average column coordinate shift of corresponding points. Default: 0</param>
        /// <param name="rowTolerance">Half height of matching search window. Default: 200</param>
        /// <param name="colTolerance">Half width of matching search window. Default: 200</param>
        /// <param name="rotation">Estimate of the relative orientation of the right image with respect to the left image. Default: 0.0</param>
        /// <param name="matchThreshold">Threshold for gray value matching. Default: 10</param>
        /// <param name="estimationMethod">Algorithm for the computation of the relative pose and for special pose types. Default: "normalized_dlt"</param>
        /// <param name="distanceThreshold">Maximal deviation of a point from its epipolar line. Default: 1</param>
        /// <param name="randSeed">Seed for the random number generator. Default: 0</param>
        /// <param name="covRelPose">6x6 covariance matrix of the relative orientation.</param>
        /// <param name="error">Root-Mean-Square of the epipolar distance error.</param>
        /// <param name="points1">Indices of matched input points in image 1.</param>
        /// <param name="points2">Indices of matched input points in image 2.</param>
        /// <returns>Computed relative orientation of the cameras (3D pose).</returns>
        public HPose MatchRelPoseRansac(
          HImage image1,
          HImage image2,
          HTuple rows1,
          HTuple cols1,
          HTuple rows2,
          HTuple cols2,
          HCamPar camPar2,
          string grayMatchMethod,
          int maskSize,
          int rowMove,
          int colMove,
          int rowTolerance,
          int colTolerance,
          double rotation,
          int matchThreshold,
          string estimationMethod,
          double distanceThreshold,
          int randSeed,
          out HTuple covRelPose,
          out double error,
          out HTuple points1,
          out HTuple points2)
        {
            IntPtr proc = HalconAPI.PreCall(359);
            this.Store(proc, 4);
            HalconAPI.Store(proc, 1, (HObjectBase)image1);
            HalconAPI.Store(proc, 2, (HObjectBase)image2);
            HalconAPI.Store(proc, 0, rows1);
            HalconAPI.Store(proc, 1, cols1);
            HalconAPI.Store(proc, 2, rows2);
            HalconAPI.Store(proc, 3, cols2);
            HalconAPI.Store(proc, 5, (HData)camPar2);
            HalconAPI.StoreS(proc, 6, grayMatchMethod);
            HalconAPI.StoreI(proc, 7, maskSize);
            HalconAPI.StoreI(proc, 8, rowMove);
            HalconAPI.StoreI(proc, 9, colMove);
            HalconAPI.StoreI(proc, 10, rowTolerance);
            HalconAPI.StoreI(proc, 11, colTolerance);
            HalconAPI.StoreD(proc, 12, rotation);
            HalconAPI.StoreI(proc, 13, matchThreshold);
            HalconAPI.StoreS(proc, 14, estimationMethod);
            HalconAPI.StoreD(proc, 15, distanceThreshold);
            HalconAPI.StoreI(proc, 16, randSeed);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(rows1);
            HalconAPI.UnpinTuple(cols1);
            HalconAPI.UnpinTuple(rows2);
            HalconAPI.UnpinTuple(cols2);
            HalconAPI.UnpinTuple((HTuple)((HData)camPar2));
            HPose hpose;
            int err2 = HPose.LoadNew(proc, 0, err1, out hpose);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out covRelPose);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out error);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, err4, out points1);
            int procResult = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, err5, out points2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image1);
            GC.KeepAlive((object)image2);
            return hpose;
        }

        /// <summary>
        ///   Compute the distance values for a rectified stereo image pair using correlation techniques.
        ///   Instance represents: Internal camera parameters of the rectified camera 1.
        /// </summary>
        /// <param name="imageRect1">Rectified image of camera 1.</param>
        /// <param name="imageRect2">Rectified image of camera 2.</param>
        /// <param name="score">Evaluation of a distance value.</param>
        /// <param name="camParamRect2">Internal camera parameters of the rectified camera 2.</param>
        /// <param name="relPoseRect">Point transformation from the rectified camera 2 to the rectified camera 1.</param>
        /// <param name="method">Matching function. Default: "ncc"</param>
        /// <param name="maskWidth">Width of the correlation window. Default: 11</param>
        /// <param name="maskHeight">Height of the correlation window. Default: 11</param>
        /// <param name="textureThresh">Variance threshold of textured image regions. Default: 0.0</param>
        /// <param name="minDisparity">Minimum of the expected disparities. Default: 0</param>
        /// <param name="maxDisparity">Maximum of the expected disparities. Default: 30</param>
        /// <param name="numLevels">Number of pyramid levels. Default: 1</param>
        /// <param name="scoreThresh">Threshold of the correlation function. Default: 0.0</param>
        /// <param name="filter">Downstream filters. Default: "none"</param>
        /// <param name="subDistance">Distance interpolation. Default: "none"</param>
        /// <returns>Distance image.</returns>
        public HImage BinocularDistance(
          HImage imageRect1,
          HImage imageRect2,
          out HImage score,
          HCamPar camParamRect2,
          HPose relPoseRect,
          string method,
          int maskWidth,
          int maskHeight,
          HTuple textureThresh,
          int minDisparity,
          int maxDisparity,
          int numLevels,
          HTuple scoreThresh,
          HTuple filter,
          HTuple subDistance)
        {
            IntPtr proc = HalconAPI.PreCall(362);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)imageRect1);
            HalconAPI.Store(proc, 2, (HObjectBase)imageRect2);
            HalconAPI.Store(proc, 1, (HData)camParamRect2);
            HalconAPI.Store(proc, 2, (HData)relPoseRect);
            HalconAPI.StoreS(proc, 3, method);
            HalconAPI.StoreI(proc, 4, maskWidth);
            HalconAPI.StoreI(proc, 5, maskHeight);
            HalconAPI.Store(proc, 6, textureThresh);
            HalconAPI.StoreI(proc, 7, minDisparity);
            HalconAPI.StoreI(proc, 8, maxDisparity);
            HalconAPI.StoreI(proc, 9, numLevels);
            HalconAPI.Store(proc, 10, scoreThresh);
            HalconAPI.Store(proc, 11, filter);
            HalconAPI.Store(proc, 12, subDistance);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect2));
            HalconAPI.UnpinTuple((HTuple)((HData)relPoseRect));
            HalconAPI.UnpinTuple(textureThresh);
            HalconAPI.UnpinTuple(scoreThresh);
            HalconAPI.UnpinTuple(filter);
            HalconAPI.UnpinTuple(subDistance);
            HImage himage;
            int err2 = HImage.LoadNew(proc, 1, err1, out himage);
            int procResult = HImage.LoadNew(proc, 2, err2, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)imageRect1);
            GC.KeepAlive((object)imageRect2);
            return himage;
        }

        /// <summary>
        ///   Compute the distance values for a rectified stereo image pair using correlation techniques.
        ///   Instance represents: Internal camera parameters of the rectified camera 1.
        /// </summary>
        /// <param name="imageRect1">Rectified image of camera 1.</param>
        /// <param name="imageRect2">Rectified image of camera 2.</param>
        /// <param name="score">Evaluation of a distance value.</param>
        /// <param name="camParamRect2">Internal camera parameters of the rectified camera 2.</param>
        /// <param name="relPoseRect">Point transformation from the rectified camera 2 to the rectified camera 1.</param>
        /// <param name="method">Matching function. Default: "ncc"</param>
        /// <param name="maskWidth">Width of the correlation window. Default: 11</param>
        /// <param name="maskHeight">Height of the correlation window. Default: 11</param>
        /// <param name="textureThresh">Variance threshold of textured image regions. Default: 0.0</param>
        /// <param name="minDisparity">Minimum of the expected disparities. Default: 0</param>
        /// <param name="maxDisparity">Maximum of the expected disparities. Default: 30</param>
        /// <param name="numLevels">Number of pyramid levels. Default: 1</param>
        /// <param name="scoreThresh">Threshold of the correlation function. Default: 0.0</param>
        /// <param name="filter">Downstream filters. Default: "none"</param>
        /// <param name="subDistance">Distance interpolation. Default: "none"</param>
        /// <returns>Distance image.</returns>
        public HImage BinocularDistance(
          HImage imageRect1,
          HImage imageRect2,
          out HImage score,
          HCamPar camParamRect2,
          HPose relPoseRect,
          string method,
          int maskWidth,
          int maskHeight,
          double textureThresh,
          int minDisparity,
          int maxDisparity,
          int numLevels,
          double scoreThresh,
          string filter,
          string subDistance)
        {
            IntPtr proc = HalconAPI.PreCall(362);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)imageRect1);
            HalconAPI.Store(proc, 2, (HObjectBase)imageRect2);
            HalconAPI.Store(proc, 1, (HData)camParamRect2);
            HalconAPI.Store(proc, 2, (HData)relPoseRect);
            HalconAPI.StoreS(proc, 3, method);
            HalconAPI.StoreI(proc, 4, maskWidth);
            HalconAPI.StoreI(proc, 5, maskHeight);
            HalconAPI.StoreD(proc, 6, textureThresh);
            HalconAPI.StoreI(proc, 7, minDisparity);
            HalconAPI.StoreI(proc, 8, maxDisparity);
            HalconAPI.StoreI(proc, 9, numLevels);
            HalconAPI.StoreD(proc, 10, scoreThresh);
            HalconAPI.StoreS(proc, 11, filter);
            HalconAPI.StoreS(proc, 12, subDistance);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect2));
            HalconAPI.UnpinTuple((HTuple)((HData)relPoseRect));
            HImage himage;
            int err2 = HImage.LoadNew(proc, 1, err1, out himage);
            int procResult = HImage.LoadNew(proc, 2, err2, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)imageRect1);
            GC.KeepAlive((object)imageRect2);
            return himage;
        }

        /// <summary>
        ///   Get a 3D point from the intersection of two lines of sight within a binocular camera system.
        ///   Instance represents: Internal parameters of the projective camera 1.
        /// </summary>
        /// <param name="camParam2">Internal parameters of the projective camera 2.</param>
        /// <param name="relPose">Point transformation from camera 2 to camera 1.</param>
        /// <param name="row1">Row coordinate of a point in image 1.</param>
        /// <param name="col1">Column coordinate of a point in image 1.</param>
        /// <param name="row2">Row coordinate of the corresponding point in image 2.</param>
        /// <param name="col2">Column coordinate of the corresponding point in image 2.</param>
        /// <param name="x">X coordinate of the 3D point.</param>
        /// <param name="y">Y coordinate of the 3D point.</param>
        /// <param name="z">Z coordinate of the 3D point.</param>
        /// <param name="dist">Distance of the 3D point to the lines of sight.</param>
        public void IntersectLinesOfSight(
          HCamPar camParam2,
          HPose relPose,
          HTuple row1,
          HTuple col1,
          HTuple row2,
          HTuple col2,
          out HTuple x,
          out HTuple y,
          out HTuple z,
          out HTuple dist)
        {
            IntPtr proc = HalconAPI.PreCall(364);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)camParam2);
            HalconAPI.Store(proc, 2, (HData)relPose);
            HalconAPI.Store(proc, 3, row1);
            HalconAPI.Store(proc, 4, col1);
            HalconAPI.Store(proc, 5, row2);
            HalconAPI.Store(proc, 6, col2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParam2));
            HalconAPI.UnpinTuple((HTuple)((HData)relPose));
            HalconAPI.UnpinTuple(row1);
            HalconAPI.UnpinTuple(col1);
            HalconAPI.UnpinTuple(row2);
            HalconAPI.UnpinTuple(col2);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out x);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out y);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out z);
            int procResult = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out dist);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Get a 3D point from the intersection of two lines of sight within a binocular camera system.
        ///   Instance represents: Internal parameters of the projective camera 1.
        /// </summary>
        /// <param name="camParam2">Internal parameters of the projective camera 2.</param>
        /// <param name="relPose">Point transformation from camera 2 to camera 1.</param>
        /// <param name="row1">Row coordinate of a point in image 1.</param>
        /// <param name="col1">Column coordinate of a point in image 1.</param>
        /// <param name="row2">Row coordinate of the corresponding point in image 2.</param>
        /// <param name="col2">Column coordinate of the corresponding point in image 2.</param>
        /// <param name="x">X coordinate of the 3D point.</param>
        /// <param name="y">Y coordinate of the 3D point.</param>
        /// <param name="z">Z coordinate of the 3D point.</param>
        /// <param name="dist">Distance of the 3D point to the lines of sight.</param>
        public void IntersectLinesOfSight(
          HCamPar camParam2,
          HPose relPose,
          double row1,
          double col1,
          double row2,
          double col2,
          out double x,
          out double y,
          out double z,
          out double dist)
        {
            IntPtr proc = HalconAPI.PreCall(364);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)camParam2);
            HalconAPI.Store(proc, 2, (HData)relPose);
            HalconAPI.StoreD(proc, 3, row1);
            HalconAPI.StoreD(proc, 4, col1);
            HalconAPI.StoreD(proc, 5, row2);
            HalconAPI.StoreD(proc, 6, col2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParam2));
            HalconAPI.UnpinTuple((HTuple)((HData)relPose));
            int err2 = HalconAPI.LoadD(proc, 0, err1, out x);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out y);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out z);
            int procResult = HalconAPI.LoadD(proc, 3, err4, out dist);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Transform a disparity image into 3D points in a rectified stereo system.
        ///   Instance represents: Internal camera parameters of the rectified camera 1.
        /// </summary>
        /// <param name="disparity">Disparity image.</param>
        /// <param name="y">Y coordinates of the points in the rectified camera system 1.</param>
        /// <param name="z">Z coordinates of the points in the rectified camera system 1.</param>
        /// <param name="camParamRect2">Internal camera parameters of the rectified camera 2.</param>
        /// <param name="relPoseRect">Pose of the rectified camera 2 in relation to the rectified camera 1.</param>
        /// <returns>X coordinates of the points in the rectified camera system 1.</returns>
        public HImage DisparityImageToXyz(
          HImage disparity,
          out HImage y,
          out HImage z,
          HCamPar camParamRect2,
          HPose relPoseRect)
        {
            IntPtr proc = HalconAPI.PreCall(365);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)disparity);
            HalconAPI.Store(proc, 1, (HData)camParamRect2);
            HalconAPI.Store(proc, 2, (HData)relPoseRect);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect2));
            HalconAPI.UnpinTuple((HTuple)((HData)relPoseRect));
            HImage himage;
            int err2 = HImage.LoadNew(proc, 1, err1, out himage);
            int err3 = HImage.LoadNew(proc, 2, err2, out y);
            int procResult = HImage.LoadNew(proc, 3, err3, out z);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)disparity);
            return himage;
        }

        /// <summary>
        ///   Transform an image point and its disparity into a 3D point in a rectified stereo system.
        ///   Instance represents: Rectified internal camera parameters of camera 1.
        /// </summary>
        /// <param name="camParamRect2">Rectified internal camera parameters of camera 2.</param>
        /// <param name="relPoseRect">Pose of the rectified camera 2 in relation to the rectified camera 1.</param>
        /// <param name="row1">Row coordinate of a point in the rectified image 1.</param>
        /// <param name="col1">Column coordinate of a point in the rectified image 1.</param>
        /// <param name="disparity">Disparity of the images of the world point.</param>
        /// <param name="x">X coordinate of the 3D point.</param>
        /// <param name="y">Y coordinate of the 3D point.</param>
        /// <param name="z">Z coordinate of the 3D point.</param>
        public void DisparityToPoint3d(
          HCamPar camParamRect2,
          HPose relPoseRect,
          HTuple row1,
          HTuple col1,
          HTuple disparity,
          out HTuple x,
          out HTuple y,
          out HTuple z)
        {
            IntPtr proc = HalconAPI.PreCall(366);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)camParamRect2);
            HalconAPI.Store(proc, 2, (HData)relPoseRect);
            HalconAPI.Store(proc, 3, row1);
            HalconAPI.Store(proc, 4, col1);
            HalconAPI.Store(proc, 5, disparity);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect2));
            HalconAPI.UnpinTuple((HTuple)((HData)relPoseRect));
            HalconAPI.UnpinTuple(row1);
            HalconAPI.UnpinTuple(col1);
            HalconAPI.UnpinTuple(disparity);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out x);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out y);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out z);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Transform an image point and its disparity into a 3D point in a rectified stereo system.
        ///   Instance represents: Rectified internal camera parameters of camera 1.
        /// </summary>
        /// <param name="camParamRect2">Rectified internal camera parameters of camera 2.</param>
        /// <param name="relPoseRect">Pose of the rectified camera 2 in relation to the rectified camera 1.</param>
        /// <param name="row1">Row coordinate of a point in the rectified image 1.</param>
        /// <param name="col1">Column coordinate of a point in the rectified image 1.</param>
        /// <param name="disparity">Disparity of the images of the world point.</param>
        /// <param name="x">X coordinate of the 3D point.</param>
        /// <param name="y">Y coordinate of the 3D point.</param>
        /// <param name="z">Z coordinate of the 3D point.</param>
        public void DisparityToPoint3d(
          HCamPar camParamRect2,
          HPose relPoseRect,
          double row1,
          double col1,
          double disparity,
          out double x,
          out double y,
          out double z)
        {
            IntPtr proc = HalconAPI.PreCall(366);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)camParamRect2);
            HalconAPI.Store(proc, 2, (HData)relPoseRect);
            HalconAPI.StoreD(proc, 3, row1);
            HalconAPI.StoreD(proc, 4, col1);
            HalconAPI.StoreD(proc, 5, disparity);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect2));
            HalconAPI.UnpinTuple((HTuple)((HData)relPoseRect));
            int err2 = HalconAPI.LoadD(proc, 0, err1, out x);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out y);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out z);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Transform a disparity value into a distance value in a rectified binocular stereo system.
        ///   Instance represents: Rectified internal camera parameters of camera 1.
        /// </summary>
        /// <param name="camParamRect2">Rectified internal camera parameters of camera 2.</param>
        /// <param name="relPoseRect">Point transformation from the rectified camera 2 to the rectified camera 1.</param>
        /// <param name="disparity">Disparity between the images of the world point.</param>
        /// <returns>Distance of a world point to the rectified camera system.</returns>
        public HTuple DisparityToDistance(
          HCamPar camParamRect2,
          HPose relPoseRect,
          HTuple disparity)
        {
            IntPtr proc = HalconAPI.PreCall(367);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)camParamRect2);
            HalconAPI.Store(proc, 2, (HData)relPoseRect);
            HalconAPI.Store(proc, 3, disparity);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect2));
            HalconAPI.UnpinTuple((HTuple)((HData)relPoseRect));
            HalconAPI.UnpinTuple(disparity);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Transform a disparity value into a distance value in a rectified binocular stereo system.
        ///   Instance represents: Rectified internal camera parameters of camera 1.
        /// </summary>
        /// <param name="camParamRect2">Rectified internal camera parameters of camera 2.</param>
        /// <param name="relPoseRect">Point transformation from the rectified camera 2 to the rectified camera 1.</param>
        /// <param name="disparity">Disparity between the images of the world point.</param>
        /// <returns>Distance of a world point to the rectified camera system.</returns>
        public double DisparityToDistance(HCamPar camParamRect2, HPose relPoseRect, double disparity)
        {
            IntPtr proc = HalconAPI.PreCall(367);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)camParamRect2);
            HalconAPI.Store(proc, 2, (HData)relPoseRect);
            HalconAPI.StoreD(proc, 3, disparity);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect2));
            HalconAPI.UnpinTuple((HTuple)((HData)relPoseRect));
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Transfrom a distance value into a disparity in a rectified stereo system.
        ///   Instance represents: Rectified internal camera parameters of camera 1.
        /// </summary>
        /// <param name="camParamRect2">Rectified internal camera parameters of camera 2.</param>
        /// <param name="relPoseRect">Point transformation from the rectified camera 2 to the rectified camera 1.</param>
        /// <param name="distance">Distance of a world point to camera 1.</param>
        /// <returns>Disparity between the images of the point.</returns>
        public HTuple DistanceToDisparity(
          HCamPar camParamRect2,
          HPose relPoseRect,
          HTuple distance)
        {
            IntPtr proc = HalconAPI.PreCall(368);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)camParamRect2);
            HalconAPI.Store(proc, 2, (HData)relPoseRect);
            HalconAPI.Store(proc, 3, distance);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect2));
            HalconAPI.UnpinTuple((HTuple)((HData)relPoseRect));
            HalconAPI.UnpinTuple(distance);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Transfrom a distance value into a disparity in a rectified stereo system.
        ///   Instance represents: Rectified internal camera parameters of camera 1.
        /// </summary>
        /// <param name="camParamRect2">Rectified internal camera parameters of camera 2.</param>
        /// <param name="relPoseRect">Point transformation from the rectified camera 2 to the rectified camera 1.</param>
        /// <param name="distance">Distance of a world point to camera 1.</param>
        /// <returns>Disparity between the images of the point.</returns>
        public double DistanceToDisparity(HCamPar camParamRect2, HPose relPoseRect, double distance)
        {
            IntPtr proc = HalconAPI.PreCall(368);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)camParamRect2);
            HalconAPI.Store(proc, 2, (HData)relPoseRect);
            HalconAPI.StoreD(proc, 3, distance);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect2));
            HalconAPI.UnpinTuple((HTuple)((HData)relPoseRect));
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Generate transformation maps that describe the mapping of the images of a binocular camera pair to a common rectified image plane.
        ///   Instance represents: Internal parameters of camera 1.
        /// </summary>
        /// <param name="map2">Image containing the mapping data of camera 2.</param>
        /// <param name="camParam2">Internal parameters of camera 2.</param>
        /// <param name="relPose">Point transformation from camera 2 to camera 1.</param>
        /// <param name="subSampling">Subsampling factor. Default: 1.0</param>
        /// <param name="method">Type of rectification. Default: "geometric"</param>
        /// <param name="mapType">Type of mapping. Default: "bilinear"</param>
        /// <param name="camParamRect1">Rectified internal parameters of camera 1.</param>
        /// <param name="camParamRect2">Rectified internal parameters of camera 2.</param>
        /// <param name="camPoseRect1">Point transformation from the rectified camera 1 to the original camera 1.</param>
        /// <param name="camPoseRect2">Point transformation from the rectified camera 1 to the original camera 1.</param>
        /// <param name="relPoseRect">Point transformation from the rectified camera 2 to the rectified camera 1.</param>
        /// <returns>Image containing the mapping data of camera 1.</returns>
        public HImage GenBinocularRectificationMap(
          out HImage map2,
          HCamPar camParam2,
          HPose relPose,
          double subSampling,
          string method,
          string mapType,
          out HCamPar camParamRect1,
          out HCamPar camParamRect2,
          out HPose camPoseRect1,
          out HPose camPoseRect2,
          out HPose relPoseRect)
        {
            IntPtr proc = HalconAPI.PreCall(369);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)camParam2);
            HalconAPI.Store(proc, 2, (HData)relPose);
            HalconAPI.StoreD(proc, 3, subSampling);
            HalconAPI.StoreS(proc, 4, method);
            HalconAPI.StoreS(proc, 5, mapType);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParam2));
            HalconAPI.UnpinTuple((HTuple)((HData)relPose));
            HImage himage;
            int err2 = HImage.LoadNew(proc, 1, err1, out himage);
            int err3 = HImage.LoadNew(proc, 2, err2, out map2);
            int err4 = HCamPar.LoadNew(proc, 0, err3, out camParamRect1);
            int err5 = HCamPar.LoadNew(proc, 1, err4, out camParamRect2);
            int err6 = HPose.LoadNew(proc, 2, err5, out camPoseRect1);
            int err7 = HPose.LoadNew(proc, 3, err6, out camPoseRect2);
            int procResult = HPose.LoadNew(proc, 4, err7, out relPoseRect);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>
        ///   Determine all camera parameters of a binocular stereo system.
        ///   Instance represents: Initial values for the internal parameters of camera 1.
        /// </summary>
        /// <param name="NX">Ordered Tuple with all X-coordinates of the calibration marks (in meters).</param>
        /// <param name="NY">Ordered Tuple with all Y-coordinates of the calibration marks (in meters).</param>
        /// <param name="NZ">Ordered Tuple with all Z-coordinates of the calibration marks (in meters).</param>
        /// <param name="NRow1">Ordered Tuple with all row-coordinates of the extracted calibration marks of camera 1 (in pixels).</param>
        /// <param name="NCol1">Ordered Tuple with all column-coordinates of the extracted calibration marks of camera 1 (in pixels).</param>
        /// <param name="NRow2">Ordered Tuple with all row-coordinates of the extracted calibration marks of camera 2 (in pixels).</param>
        /// <param name="NCol2">Ordered Tuple with all column-coordinates of the extracted calibration marks of camera 2 (in pixels).</param>
        /// <param name="startCamParam2">Initial values for the internal parameters of camera 2.</param>
        /// <param name="NStartPose1">Ordered tuple with all initial values for the poses of the calibration model in relation to camera 1.</param>
        /// <param name="NStartPose2">Ordered tuple with all initial values for the poses of the calibration model in relation to camera 2.</param>
        /// <param name="estimateParams">Camera parameters to be estimated. Default: "all"</param>
        /// <param name="camParam2">Internal parameters of camera 2.</param>
        /// <param name="NFinalPose1">Ordered tuple with all poses of the calibration model in relation to camera 1.</param>
        /// <param name="NFinalPose2">Ordered tuple with all poses of the calibration model in relation to camera 2.</param>
        /// <param name="relPose">Pose of camera 2 in relation to camera 1.</param>
        /// <param name="errors">Average error distances in pixels.</param>
        /// <returns>Internal parameters of camera 1.</returns>
        public HCamPar BinocularCalibration(
          HTuple NX,
          HTuple NY,
          HTuple NZ,
          HTuple NRow1,
          HTuple NCol1,
          HTuple NRow2,
          HTuple NCol2,
          HCamPar startCamParam2,
          HPose[] NStartPose1,
          HPose[] NStartPose2,
          HTuple estimateParams,
          out HCamPar camParam2,
          out HPose[] NFinalPose1,
          out HPose[] NFinalPose2,
          out HPose relPose,
          out HTuple errors)
        {
            HTuple htuple1 = HData.ConcatArray((HData[])NStartPose1);
            HTuple htuple2 = HData.ConcatArray((HData[])NStartPose2);
            IntPtr proc = HalconAPI.PreCall(370);
            this.Store(proc, 7);
            HalconAPI.Store(proc, 0, NX);
            HalconAPI.Store(proc, 1, NY);
            HalconAPI.Store(proc, 2, NZ);
            HalconAPI.Store(proc, 3, NRow1);
            HalconAPI.Store(proc, 4, NCol1);
            HalconAPI.Store(proc, 5, NRow2);
            HalconAPI.Store(proc, 6, NCol2);
            HalconAPI.Store(proc, 8, (HData)startCamParam2);
            HalconAPI.Store(proc, 9, htuple1);
            HalconAPI.Store(proc, 10, htuple2);
            HalconAPI.Store(proc, 11, estimateParams);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(NX);
            HalconAPI.UnpinTuple(NY);
            HalconAPI.UnpinTuple(NZ);
            HalconAPI.UnpinTuple(NRow1);
            HalconAPI.UnpinTuple(NCol1);
            HalconAPI.UnpinTuple(NRow2);
            HalconAPI.UnpinTuple(NCol2);
            HalconAPI.UnpinTuple((HTuple)((HData)startCamParam2));
            HalconAPI.UnpinTuple(htuple1);
            HalconAPI.UnpinTuple(htuple2);
            HalconAPI.UnpinTuple(estimateParams);
            HCamPar hcamPar;
            int err2 = HCamPar.LoadNew(proc, 0, err1, out hcamPar);
            int err3 = HCamPar.LoadNew(proc, 1, err2, out camParam2);
            HTuple tuple1;
            int err4 = HTuple.LoadNew(proc, 2, err3, out tuple1);
            HTuple tuple2;
            int err5 = HTuple.LoadNew(proc, 3, err4, out tuple2);
            int err6 = HPose.LoadNew(proc, 4, err5, out relPose);
            int procResult = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, err6, out errors);
            HalconAPI.PostCall(proc, procResult);
            NFinalPose1 = HPose.SplitArray(tuple1);
            NFinalPose2 = HPose.SplitArray(tuple2);
            GC.KeepAlive((object)this);
            return hcamPar;
        }

        /// <summary>
        ///   Determine all camera parameters of a binocular stereo system.
        ///   Instance represents: Initial values for the internal parameters of camera 1.
        /// </summary>
        /// <param name="NX">Ordered Tuple with all X-coordinates of the calibration marks (in meters).</param>
        /// <param name="NY">Ordered Tuple with all Y-coordinates of the calibration marks (in meters).</param>
        /// <param name="NZ">Ordered Tuple with all Z-coordinates of the calibration marks (in meters).</param>
        /// <param name="NRow1">Ordered Tuple with all row-coordinates of the extracted calibration marks of camera 1 (in pixels).</param>
        /// <param name="NCol1">Ordered Tuple with all column-coordinates of the extracted calibration marks of camera 1 (in pixels).</param>
        /// <param name="NRow2">Ordered Tuple with all row-coordinates of the extracted calibration marks of camera 2 (in pixels).</param>
        /// <param name="NCol2">Ordered Tuple with all column-coordinates of the extracted calibration marks of camera 2 (in pixels).</param>
        /// <param name="startCamParam2">Initial values for the internal parameters of camera 2.</param>
        /// <param name="NStartPose1">Ordered tuple with all initial values for the poses of the calibration model in relation to camera 1.</param>
        /// <param name="NStartPose2">Ordered tuple with all initial values for the poses of the calibration model in relation to camera 2.</param>
        /// <param name="estimateParams">Camera parameters to be estimated. Default: "all"</param>
        /// <param name="camParam2">Internal parameters of camera 2.</param>
        /// <param name="NFinalPose1">Ordered tuple with all poses of the calibration model in relation to camera 1.</param>
        /// <param name="NFinalPose2">Ordered tuple with all poses of the calibration model in relation to camera 2.</param>
        /// <param name="relPose">Pose of camera 2 in relation to camera 1.</param>
        /// <param name="errors">Average error distances in pixels.</param>
        /// <returns>Internal parameters of camera 1.</returns>
        public HCamPar BinocularCalibration(
          HTuple NX,
          HTuple NY,
          HTuple NZ,
          HTuple NRow1,
          HTuple NCol1,
          HTuple NRow2,
          HTuple NCol2,
          HCamPar startCamParam2,
          HPose NStartPose1,
          HPose NStartPose2,
          HTuple estimateParams,
          out HCamPar camParam2,
          out HPose NFinalPose1,
          out HPose NFinalPose2,
          out HPose relPose,
          out double errors)
        {
            IntPtr proc = HalconAPI.PreCall(370);
            this.Store(proc, 7);
            HalconAPI.Store(proc, 0, NX);
            HalconAPI.Store(proc, 1, NY);
            HalconAPI.Store(proc, 2, NZ);
            HalconAPI.Store(proc, 3, NRow1);
            HalconAPI.Store(proc, 4, NCol1);
            HalconAPI.Store(proc, 5, NRow2);
            HalconAPI.Store(proc, 6, NCol2);
            HalconAPI.Store(proc, 8, (HData)startCamParam2);
            HalconAPI.Store(proc, 9, (HData)NStartPose1);
            HalconAPI.Store(proc, 10, (HData)NStartPose2);
            HalconAPI.Store(proc, 11, estimateParams);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(NX);
            HalconAPI.UnpinTuple(NY);
            HalconAPI.UnpinTuple(NZ);
            HalconAPI.UnpinTuple(NRow1);
            HalconAPI.UnpinTuple(NCol1);
            HalconAPI.UnpinTuple(NRow2);
            HalconAPI.UnpinTuple(NCol2);
            HalconAPI.UnpinTuple((HTuple)((HData)startCamParam2));
            HalconAPI.UnpinTuple((HTuple)((HData)NStartPose1));
            HalconAPI.UnpinTuple((HTuple)((HData)NStartPose2));
            HalconAPI.UnpinTuple(estimateParams);
            HCamPar hcamPar;
            int err2 = HCamPar.LoadNew(proc, 0, err1, out hcamPar);
            int err3 = HCamPar.LoadNew(proc, 1, err2, out camParam2);
            int err4 = HPose.LoadNew(proc, 2, err3, out NFinalPose1);
            int err5 = HPose.LoadNew(proc, 3, err4, out NFinalPose2);
            int err6 = HPose.LoadNew(proc, 4, err5, out relPose);
            int procResult = HalconAPI.LoadD(proc, 5, err6, out errors);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hcamPar;
        }

        /// <summary>
        ///   Find the best matches of a calibrated descriptor model in an image and return their 3D pose.
        ///   Instance represents: Camera parameter (inner orientation) obtained from camera calibration.
        /// </summary>
        /// <param name="image">Input image where the model should be found.</param>
        /// <param name="modelID">The handle to the descriptor model.</param>
        /// <param name="detectorParamName">The detector's parameter names. Default: []</param>
        /// <param name="detectorParamValue">Values of the detector's parameters. Default: []</param>
        /// <param name="descriptorParamName">The descriptor's parameter names. Default: []</param>
        /// <param name="descriptorParamValue">Values of the descriptor's parameters. Default: []</param>
        /// <param name="minScore">Minimum score of the instances of the models to be found. Default: 0.2</param>
        /// <param name="numMatches">Maximal number of found instances. Default: 1</param>
        /// <param name="scoreType">Score type to be evaluated in Score. Default: "num_points"</param>
        /// <param name="score">Score of the found instances according to the ScoreType input.</param>
        /// <returns>3D pose of the object.</returns>
        public HPose[] FindCalibDescriptorModel(
          HImage image,
          HDescriptorModel modelID,
          HTuple detectorParamName,
          HTuple detectorParamValue,
          HTuple descriptorParamName,
          HTuple descriptorParamValue,
          HTuple minScore,
          int numMatches,
          HTuple scoreType,
          out HTuple score)
        {
            IntPtr proc = HalconAPI.PreCall(948);
            this.Store(proc, 7);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)modelID);
            HalconAPI.Store(proc, 1, detectorParamName);
            HalconAPI.Store(proc, 2, detectorParamValue);
            HalconAPI.Store(proc, 3, descriptorParamName);
            HalconAPI.Store(proc, 4, descriptorParamValue);
            HalconAPI.Store(proc, 5, minScore);
            HalconAPI.StoreI(proc, 6, numMatches);
            HalconAPI.Store(proc, 8, scoreType);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(detectorParamName);
            HalconAPI.UnpinTuple(detectorParamValue);
            HalconAPI.UnpinTuple(descriptorParamName);
            HalconAPI.UnpinTuple(descriptorParamValue);
            HalconAPI.UnpinTuple(minScore);
            HalconAPI.UnpinTuple(scoreType);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, err2, out score);
            HalconAPI.PostCall(proc, procResult);
            HPose[] hposeArray = HPose.SplitArray(tuple);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)modelID);
            return hposeArray;
        }

        /// <summary>
        ///   Find the best matches of a calibrated descriptor model in an image and return their 3D pose.
        ///   Instance represents: Camera parameter (inner orientation) obtained from camera calibration.
        /// </summary>
        /// <param name="image">Input image where the model should be found.</param>
        /// <param name="modelID">The handle to the descriptor model.</param>
        /// <param name="detectorParamName">The detector's parameter names. Default: []</param>
        /// <param name="detectorParamValue">Values of the detector's parameters. Default: []</param>
        /// <param name="descriptorParamName">The descriptor's parameter names. Default: []</param>
        /// <param name="descriptorParamValue">Values of the descriptor's parameters. Default: []</param>
        /// <param name="minScore">Minimum score of the instances of the models to be found. Default: 0.2</param>
        /// <param name="numMatches">Maximal number of found instances. Default: 1</param>
        /// <param name="scoreType">Score type to be evaluated in Score. Default: "num_points"</param>
        /// <param name="score">Score of the found instances according to the ScoreType input.</param>
        /// <returns>3D pose of the object.</returns>
        public HPose FindCalibDescriptorModel(
          HImage image,
          HDescriptorModel modelID,
          HTuple detectorParamName,
          HTuple detectorParamValue,
          HTuple descriptorParamName,
          HTuple descriptorParamValue,
          double minScore,
          int numMatches,
          string scoreType,
          out double score)
        {
            IntPtr proc = HalconAPI.PreCall(948);
            this.Store(proc, 7);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)modelID);
            HalconAPI.Store(proc, 1, detectorParamName);
            HalconAPI.Store(proc, 2, detectorParamValue);
            HalconAPI.Store(proc, 3, descriptorParamName);
            HalconAPI.Store(proc, 4, descriptorParamValue);
            HalconAPI.StoreD(proc, 5, minScore);
            HalconAPI.StoreI(proc, 6, numMatches);
            HalconAPI.StoreS(proc, 8, scoreType);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(detectorParamName);
            HalconAPI.UnpinTuple(detectorParamValue);
            HalconAPI.UnpinTuple(descriptorParamName);
            HalconAPI.UnpinTuple(descriptorParamValue);
            HPose hpose;
            int err2 = HPose.LoadNew(proc, 0, err1, out hpose);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)modelID);
            return hpose;
        }

        /// <summary>
        ///   Create a descriptor model for calibrated perspective matching.
        ///   Instance represents: The parameters of the internal orientation of the camera.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
        /// <param name="referencePose">The reference pose of the object in the reference image.</param>
        /// <param name="detectorType">The type of the detector. Default: "lepetit"</param>
        /// <param name="detectorParamName">The detector's parameter names. Default: []</param>
        /// <param name="detectorParamValue">Values of the detector's parameters. Default: []</param>
        /// <param name="descriptorParamName">The descriptor's parameter names. Default: []</param>
        /// <param name="descriptorParamValue">Values of the descriptor's parameters. Default: []</param>
        /// <param name="seed">The seed for the random number generator. Default: 42</param>
        /// <returns>The handle to the descriptor model.</returns>
        public HDescriptorModel CreateCalibDescriptorModel(
          HImage template,
          HPose referencePose,
          string detectorType,
          HTuple detectorParamName,
          HTuple detectorParamValue,
          HTuple descriptorParamName,
          HTuple descriptorParamValue,
          int seed)
        {
            IntPtr proc = HalconAPI.PreCall(952);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
            HalconAPI.Store(proc, 1, (HData)referencePose);
            HalconAPI.StoreS(proc, 2, detectorType);
            HalconAPI.Store(proc, 3, detectorParamName);
            HalconAPI.Store(proc, 4, detectorParamValue);
            HalconAPI.Store(proc, 5, descriptorParamName);
            HalconAPI.Store(proc, 6, descriptorParamValue);
            HalconAPI.StoreI(proc, 7, seed);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)referencePose));
            HalconAPI.UnpinTuple(detectorParamName);
            HalconAPI.UnpinTuple(detectorParamValue);
            HalconAPI.UnpinTuple(descriptorParamName);
            HalconAPI.UnpinTuple(descriptorParamValue);
            HDescriptorModel hdescriptorModel;
            int procResult = HDescriptorModel.LoadNew(proc, 0, err, out hdescriptorModel);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
            return hdescriptorModel;
        }

        /// <summary>
        ///   Prepare a deformable model for planar calibrated matching from XLD contours.
        ///   Instance represents: The parameters of the internal orientation of the camera.
        /// </summary>
        /// <param name="contours">Input contours that will be used to create the model.</param>
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
        /// <returns>Handle of the model.</returns>
        public HDeformableModel CreatePlanarCalibDeformableModelXld(
          HXLDCont contours,
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
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)contours);
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
            this.UnpinTuple();
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
            HDeformableModel hdeformableModel;
            int procResult = HDeformableModel.LoadNew(proc, 0, err, out hdeformableModel);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contours);
            return hdeformableModel;
        }

        /// <summary>
        ///   Prepare a deformable model for planar calibrated matching from XLD contours.
        ///   Instance represents: The parameters of the internal orientation of the camera.
        /// </summary>
        /// <param name="contours">Input contours that will be used to create the model.</param>
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
        /// <returns>Handle of the model.</returns>
        public HDeformableModel CreatePlanarCalibDeformableModelXld(
          HXLDCont contours,
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
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)contours);
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
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)referencePose));
            HalconAPI.UnpinTuple(angleStart);
            HalconAPI.UnpinTuple(angleExtent);
            HalconAPI.UnpinTuple(scaleRMax);
            HalconAPI.UnpinTuple(scaleCMax);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HDeformableModel hdeformableModel;
            int procResult = HDeformableModel.LoadNew(proc, 0, err, out hdeformableModel);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contours);
            return hdeformableModel;
        }

        /// <summary>
        ///   Create a deformable model for calibrated perspective matching.
        ///   Instance represents: The parameters of the internal orientation of the camera.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
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
        /// <returns>Handle of the model.</returns>
        public HDeformableModel CreatePlanarCalibDeformableModel(
          HImage template,
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
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
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
            this.UnpinTuple();
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
            HDeformableModel hdeformableModel;
            int procResult = HDeformableModel.LoadNew(proc, 0, err, out hdeformableModel);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
            return hdeformableModel;
        }

        /// <summary>
        ///   Create a deformable model for calibrated perspective matching.
        ///   Instance represents: The parameters of the internal orientation of the camera.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
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
        /// <returns>Handle of the model.</returns>
        public HDeformableModel CreatePlanarCalibDeformableModel(
          HImage template,
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
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
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
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)referencePose));
            HalconAPI.UnpinTuple(angleStart);
            HalconAPI.UnpinTuple(angleExtent);
            HalconAPI.UnpinTuple(scaleRMax);
            HalconAPI.UnpinTuple(scaleCMax);
            HalconAPI.UnpinTuple(contrast);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HDeformableModel hdeformableModel;
            int procResult = HDeformableModel.LoadNew(proc, 0, err, out hdeformableModel);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)template);
            return hdeformableModel;
        }

        /// <summary>
        ///   Project the edges of a 3D shape model into image coordinates.
        ///   Instance represents: Internal camera parameters.
        /// </summary>
        /// <param name="shapeModel3DID">Handle of the 3D shape model.</param>
        /// <param name="pose">3D pose of the 3D shape model in the world coordinate system.</param>
        /// <param name="hiddenSurfaceRemoval">Remove hidden surfaces? Default: "true"</param>
        /// <param name="minFaceAngle">Smallest face angle for which the edge is displayed Default: 0.523599</param>
        /// <returns>Contour representation of the model view.</returns>
        public HXLDCont ProjectShapeModel3d(
          HShapeModel3D shapeModel3DID,
          HPose pose,
          string hiddenSurfaceRemoval,
          HTuple minFaceAngle)
        {
            IntPtr proc = HalconAPI.PreCall(1055);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)shapeModel3DID);
            HalconAPI.Store(proc, 2, (HData)pose);
            HalconAPI.StoreS(proc, 3, hiddenSurfaceRemoval);
            HalconAPI.Store(proc, 4, minFaceAngle);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)pose));
            HalconAPI.UnpinTuple(minFaceAngle);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)shapeModel3DID);
            return hxldCont;
        }

        /// <summary>
        ///   Project the edges of a 3D shape model into image coordinates.
        ///   Instance represents: Internal camera parameters.
        /// </summary>
        /// <param name="shapeModel3DID">Handle of the 3D shape model.</param>
        /// <param name="pose">3D pose of the 3D shape model in the world coordinate system.</param>
        /// <param name="hiddenSurfaceRemoval">Remove hidden surfaces? Default: "true"</param>
        /// <param name="minFaceAngle">Smallest face angle for which the edge is displayed Default: 0.523599</param>
        /// <returns>Contour representation of the model view.</returns>
        public HXLDCont ProjectShapeModel3d(
          HShapeModel3D shapeModel3DID,
          HPose pose,
          string hiddenSurfaceRemoval,
          double minFaceAngle)
        {
            IntPtr proc = HalconAPI.PreCall(1055);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)shapeModel3DID);
            HalconAPI.Store(proc, 2, (HData)pose);
            HalconAPI.StoreS(proc, 3, hiddenSurfaceRemoval);
            HalconAPI.StoreD(proc, 4, minFaceAngle);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)pose));
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)shapeModel3DID);
            return hxldCont;
        }

        /// <summary>
        ///   Prepare a 3D object model for matching.
        ///   Instance represents: Internal camera parameters.
        /// </summary>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <param name="refRotX">Reference orientation: Rotation around x-axis or x component of the Rodriguez vector (in radians or without unit). Default: 0</param>
        /// <param name="refRotY">Reference orientation: Rotation around y-axis or y component of the Rodriguez vector (in radians or without unit). Default: 0</param>
        /// <param name="refRotZ">Reference orientation: Rotation around z-axis or z component of the Rodriguez vector (in radians or without unit). Default: 0</param>
        /// <param name="orderOfRotation">Meaning of the rotation values of the reference orientation. Default: "gba"</param>
        /// <param name="longitudeMin">Minimum longitude of the model views. Default: -0.35</param>
        /// <param name="longitudeMax">Maximum longitude of the model views. Default: 0.35</param>
        /// <param name="latitudeMin">Minimum latitude of the model views. Default: -0.35</param>
        /// <param name="latitudeMax">Maximum latitude of the model views. Default: 0.35</param>
        /// <param name="camRollMin">Minimum camera roll angle of the model views. Default: -3.1416</param>
        /// <param name="camRollMax">Maximum camera roll angle of the model views. Default: 3.1416</param>
        /// <param name="distMin">Minimum camera-object-distance of the model views. Default: 0.3</param>
        /// <param name="distMax">Maximum camera-object-distance of the model views. Default: 0.4</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: 10</param>
        /// <param name="genParamName">Names of (optional) parameters for controlling the behavior of the operator. Default: []</param>
        /// <param name="genParamValue">Values of the optional generic parameters. Default: []</param>
        /// <returns>Handle of the 3D shape model.</returns>
        public HShapeModel3D CreateShapeModel3d(
          HObjectModel3D objectModel3D,
          double refRotX,
          double refRotY,
          double refRotZ,
          string orderOfRotation,
          double longitudeMin,
          double longitudeMax,
          double latitudeMin,
          double latitudeMax,
          double camRollMin,
          double camRollMax,
          double distMin,
          double distMax,
          int minContrast,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1059);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)objectModel3D);
            HalconAPI.StoreD(proc, 2, refRotX);
            HalconAPI.StoreD(proc, 3, refRotY);
            HalconAPI.StoreD(proc, 4, refRotZ);
            HalconAPI.StoreS(proc, 5, orderOfRotation);
            HalconAPI.StoreD(proc, 6, longitudeMin);
            HalconAPI.StoreD(proc, 7, longitudeMax);
            HalconAPI.StoreD(proc, 8, latitudeMin);
            HalconAPI.StoreD(proc, 9, latitudeMax);
            HalconAPI.StoreD(proc, 10, camRollMin);
            HalconAPI.StoreD(proc, 11, camRollMax);
            HalconAPI.StoreD(proc, 12, distMin);
            HalconAPI.StoreD(proc, 13, distMax);
            HalconAPI.StoreI(proc, 14, minContrast);
            HalconAPI.Store(proc, 15, genParamName);
            HalconAPI.Store(proc, 16, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HShapeModel3D hshapeModel3D;
            int procResult = HShapeModel3D.LoadNew(proc, 0, err, out hshapeModel3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D);
            return hshapeModel3D;
        }

        /// <summary>
        ///   Prepare a 3D object model for matching.
        ///   Instance represents: Internal camera parameters.
        /// </summary>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <param name="refRotX">Reference orientation: Rotation around x-axis or x component of the Rodriguez vector (in radians or without unit). Default: 0</param>
        /// <param name="refRotY">Reference orientation: Rotation around y-axis or y component of the Rodriguez vector (in radians or without unit). Default: 0</param>
        /// <param name="refRotZ">Reference orientation: Rotation around z-axis or z component of the Rodriguez vector (in radians or without unit). Default: 0</param>
        /// <param name="orderOfRotation">Meaning of the rotation values of the reference orientation. Default: "gba"</param>
        /// <param name="longitudeMin">Minimum longitude of the model views. Default: -0.35</param>
        /// <param name="longitudeMax">Maximum longitude of the model views. Default: 0.35</param>
        /// <param name="latitudeMin">Minimum latitude of the model views. Default: -0.35</param>
        /// <param name="latitudeMax">Maximum latitude of the model views. Default: 0.35</param>
        /// <param name="camRollMin">Minimum camera roll angle of the model views. Default: -3.1416</param>
        /// <param name="camRollMax">Maximum camera roll angle of the model views. Default: 3.1416</param>
        /// <param name="distMin">Minimum camera-object-distance of the model views. Default: 0.3</param>
        /// <param name="distMax">Maximum camera-object-distance of the model views. Default: 0.4</param>
        /// <param name="minContrast">Minimum contrast of the objects in the search images. Default: 10</param>
        /// <param name="genParamName">Names of (optional) parameters for controlling the behavior of the operator. Default: []</param>
        /// <param name="genParamValue">Values of the optional generic parameters. Default: []</param>
        /// <returns>Handle of the 3D shape model.</returns>
        public HShapeModel3D CreateShapeModel3d(
          HObjectModel3D objectModel3D,
          double refRotX,
          double refRotY,
          double refRotZ,
          string orderOfRotation,
          double longitudeMin,
          double longitudeMax,
          double latitudeMin,
          double latitudeMax,
          double camRollMin,
          double camRollMax,
          double distMin,
          double distMax,
          int minContrast,
          string genParamName,
          int genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1059);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)objectModel3D);
            HalconAPI.StoreD(proc, 2, refRotX);
            HalconAPI.StoreD(proc, 3, refRotY);
            HalconAPI.StoreD(proc, 4, refRotZ);
            HalconAPI.StoreS(proc, 5, orderOfRotation);
            HalconAPI.StoreD(proc, 6, longitudeMin);
            HalconAPI.StoreD(proc, 7, longitudeMax);
            HalconAPI.StoreD(proc, 8, latitudeMin);
            HalconAPI.StoreD(proc, 9, latitudeMax);
            HalconAPI.StoreD(proc, 10, camRollMin);
            HalconAPI.StoreD(proc, 11, camRollMax);
            HalconAPI.StoreD(proc, 12, distMin);
            HalconAPI.StoreD(proc, 13, distMax);
            HalconAPI.StoreI(proc, 14, minContrast);
            HalconAPI.StoreS(proc, 15, genParamName);
            HalconAPI.StoreI(proc, 16, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HShapeModel3D hshapeModel3D;
            int procResult = HShapeModel3D.LoadNew(proc, 0, err, out hshapeModel3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D);
            return hshapeModel3D;
        }

        /// <summary>
        ///   Remove points from a 3D object model by projecting it to a virtual view and removing all points outside of a given region.
        ///   Instance represents: Internal camera parameters.
        /// </summary>
        /// <param name="region">Region in the image plane.</param>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <param name="pose">3D pose of the world coordinate system in camera coordinates.</param>
        /// <returns>Handle of the reduced 3D object model.</returns>
        public HObjectModel3D[] ReduceObjectModel3dByView(
          HRegion region,
          HObjectModel3D[] objectModel3D,
          HPose[] pose)
        {
            HTuple htuple1 = HTool.ConcatArray((HTool[])objectModel3D);
            HTuple htuple2 = HData.ConcatArray((HData[])pose);
            IntPtr proc = HalconAPI.PreCall(1084);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 1, (HObjectBase)region);
            HalconAPI.Store(proc, 0, htuple1);
            HalconAPI.Store(proc, 2, htuple2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(htuple1);
            HalconAPI.UnpinTuple(htuple2);
            HObjectModel3D[] hobjectModel3DArray;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3DArray);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)region);
            GC.KeepAlive((object)objectModel3D);
            return hobjectModel3DArray;
        }

        /// <summary>
        ///   Remove points from a 3D object model by projecting it to a virtual view and removing all points outside of a given region.
        ///   Instance represents: Internal camera parameters.
        /// </summary>
        /// <param name="region">Region in the image plane.</param>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <param name="pose">3D pose of the world coordinate system in camera coordinates.</param>
        /// <returns>Handle of the reduced 3D object model.</returns>
        public HObjectModel3D ReduceObjectModel3dByView(
          HRegion region,
          HObjectModel3D objectModel3D,
          HPose pose)
        {
            IntPtr proc = HalconAPI.PreCall(1084);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 1, (HObjectBase)region);
            HalconAPI.Store(proc, 0, (HTool)objectModel3D);
            HalconAPI.Store(proc, 2, (HData)pose);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)pose));
            HObjectModel3D hobjectModel3D;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)region);
            GC.KeepAlive((object)objectModel3D);
            return hobjectModel3D;
        }

        /// <summary>
        ///   Render 3D object models to get an image.
        ///   Instance represents: Camera parameters of the scene.
        /// </summary>
        /// <param name="objectModel3D">Handles of the 3D object models.</param>
        /// <param name="pose">3D poses of the objects.</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <returns>Rendered scene.</returns>
        public HImage RenderObjectModel3d(
          HObjectModel3D[] objectModel3D,
          HPose[] pose,
          HTuple genParamName,
          HTuple genParamValue)
        {
            HTuple htuple1 = HTool.ConcatArray((HTool[])objectModel3D);
            HTuple htuple2 = HData.ConcatArray((HData[])pose);
            IntPtr proc = HalconAPI.PreCall(1088);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, htuple1);
            HalconAPI.Store(proc, 2, htuple2);
            HalconAPI.Store(proc, 3, genParamName);
            HalconAPI.Store(proc, 4, genParamValue);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(htuple1);
            HalconAPI.UnpinTuple(htuple2);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D);
            return himage;
        }

        /// <summary>
        ///   Render 3D object models to get an image.
        ///   Instance represents: Camera parameters of the scene.
        /// </summary>
        /// <param name="objectModel3D">Handles of the 3D object models.</param>
        /// <param name="pose">3D poses of the objects.</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <returns>Rendered scene.</returns>
        public HImage RenderObjectModel3d(
          HObjectModel3D objectModel3D,
          HPose pose,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1088);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)objectModel3D);
            HalconAPI.Store(proc, 2, (HData)pose);
            HalconAPI.Store(proc, 3, genParamName);
            HalconAPI.Store(proc, 4, genParamValue);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)pose));
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D);
            return himage;
        }

        /// <summary>
        ///   Display 3D object models.
        ///   Instance represents: Camera parameters of the scene.
        /// </summary>
        /// <param name="windowHandle">Window handle.</param>
        /// <param name="objectModel3D">Handles of the 3D object models.</param>
        /// <param name="pose">3D poses of the objects. Default: []</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        public void DispObjectModel3d(
          HWindow windowHandle,
          HObjectModel3D[] objectModel3D,
          HPose[] pose,
          HTuple genParamName,
          HTuple genParamValue)
        {
            HTuple htuple1 = HTool.ConcatArray((HTool[])objectModel3D);
            HTuple htuple2 = HData.ConcatArray((HData[])pose);
            IntPtr proc = HalconAPI.PreCall(1089);
            this.Store(proc, 2);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            HalconAPI.Store(proc, 1, htuple1);
            HalconAPI.Store(proc, 3, htuple2);
            HalconAPI.Store(proc, 4, genParamName);
            HalconAPI.Store(proc, 5, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(htuple1);
            HalconAPI.UnpinTuple(htuple2);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)windowHandle);
            GC.KeepAlive((object)objectModel3D);
        }

        /// <summary>
        ///   Display 3D object models.
        ///   Instance represents: Camera parameters of the scene.
        /// </summary>
        /// <param name="windowHandle">Window handle.</param>
        /// <param name="objectModel3D">Handles of the 3D object models.</param>
        /// <param name="pose">3D poses of the objects. Default: []</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        public void DispObjectModel3d(
          HWindow windowHandle,
          HObjectModel3D objectModel3D,
          HPose pose,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1089);
            this.Store(proc, 2);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            HalconAPI.Store(proc, 1, (HTool)objectModel3D);
            HalconAPI.Store(proc, 3, (HData)pose);
            HalconAPI.Store(proc, 4, genParamName);
            HalconAPI.Store(proc, 5, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)pose));
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)windowHandle);
            GC.KeepAlive((object)objectModel3D);
        }

        /// <summary>
        ///   Transform 3D points from a 3D object model to images.
        ///   Instance represents: Camera parameters.
        /// </summary>
        /// <param name="y">Image with the Y-Coordinates of the 3D points.</param>
        /// <param name="z">Image with the Z-Coordinates of the 3D points.</param>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <param name="type">Type of the conversion. Default: "cartesian"</param>
        /// <param name="pose">Pose of the 3D object model.</param>
        /// <returns>Image with the X-Coordinates of the 3D points.</returns>
        public HImage ObjectModel3dToXyz(
          out HImage y,
          out HImage z,
          HObjectModel3D objectModel3D,
          string type,
          HPose pose)
        {
            IntPtr proc = HalconAPI.PreCall(1092);
            this.Store(proc, 2);
            HalconAPI.Store(proc, 0, (HTool)objectModel3D);
            HalconAPI.StoreS(proc, 1, type);
            HalconAPI.Store(proc, 3, (HData)pose);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)pose));
            HImage himage;
            int err2 = HImage.LoadNew(proc, 1, err1, out himage);
            int err3 = HImage.LoadNew(proc, 2, err2, out y);
            int procResult = HImage.LoadNew(proc, 3, err3, out z);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D);
            return himage;
        }

        /// <summary>
        ///   Project a 3D object model into image coordinates.
        ///   Instance represents: Internal camera parameters.
        /// </summary>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <param name="pose">3D pose of the world coordinate system in camera coordinates.</param>
        /// <param name="genParamName">Name of the generic parameter. Default: []</param>
        /// <param name="genParamValue">Value of the generic parameter. Default: []</param>
        /// <returns>Projected model contours.</returns>
        public HXLDCont ProjectObjectModel3d(
          HObjectModel3D objectModel3D,
          HPose pose,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1095);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)objectModel3D);
            HalconAPI.Store(proc, 2, (HData)pose);
            HalconAPI.Store(proc, 3, genParamName);
            HalconAPI.Store(proc, 4, genParamValue);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)pose));
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D);
            return hxldCont;
        }

        /// <summary>
        ///   Project a 3D object model into image coordinates.
        ///   Instance represents: Internal camera parameters.
        /// </summary>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <param name="pose">3D pose of the world coordinate system in camera coordinates.</param>
        /// <param name="genParamName">Name of the generic parameter. Default: []</param>
        /// <param name="genParamValue">Value of the generic parameter. Default: []</param>
        /// <returns>Projected model contours.</returns>
        public HXLDCont ProjectObjectModel3d(
          HObjectModel3D objectModel3D,
          HPose pose,
          string genParamName,
          string genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1095);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)objectModel3D);
            HalconAPI.Store(proc, 2, (HData)pose);
            HalconAPI.StoreS(proc, 3, genParamName);
            HalconAPI.StoreS(proc, 4, genParamValue);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)pose));
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D);
            return hxldCont;
        }

        /// <summary>
        ///   Add a camera to a 3D scene.
        ///   Instance represents: Parameters of the new camera.
        /// </summary>
        /// <param name="scene3D">Handle of the 3D scene.</param>
        /// <returns>Index of the new camera in the 3D scene.</returns>
        public int AddScene3dCamera(HScene3D scene3D)
        {
            IntPtr proc = HalconAPI.PreCall(1218);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)scene3D);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)scene3D);
            return intValue;
        }

        /// <summary>
        ///   Compute the calibrated scene flow between two stereo image pairs.
        ///   Instance represents: Internal camera parameters of the rectified camera 1.
        /// </summary>
        /// <param name="imageRect1T1">Input image 1 at time @f$t_{1}$t_1.</param>
        /// <param name="imageRect2T1">Input image 2 at time @f$t_{1}$t_1.</param>
        /// <param name="imageRect1T2">Input image 1 at time @f$t_{2}$t_2.</param>
        /// <param name="imageRect2T2">Input image 2 at time @f$t_{2}$t_2.</param>
        /// <param name="disparity">Disparity between input images 1 and 2 at time @f$t_{1}$t_1.</param>
        /// <param name="smoothingFlow">Weight of the regularization term relative to the data term (derivatives of the optical flow). Default: 40.0</param>
        /// <param name="smoothingDisparity">Weight of the regularization term relative to the data term (derivatives of the disparity change). Default: 40.0</param>
        /// <param name="genParamName">Parameter name(s) for the algorithm. Default: "default_parameters"</param>
        /// <param name="genParamValue">Parameter value(s) for the algorithm. Default: "accurate"</param>
        /// <param name="camParamRect2">Internal camera parameters of the rectified camera 2.</param>
        /// <param name="relPoseRect">Pose of the rectified camera 2 in relation to the rectified camera 1.</param>
        /// <returns>Handle of the 3D object model.</returns>
        public HObjectModel3D[] SceneFlowCalib(
          HImage imageRect1T1,
          HImage imageRect2T1,
          HImage imageRect1T2,
          HImage imageRect2T2,
          HImage disparity,
          HTuple smoothingFlow,
          HTuple smoothingDisparity,
          HTuple genParamName,
          HTuple genParamValue,
          HCamPar camParamRect2,
          HPose relPoseRect)
        {
            IntPtr proc = HalconAPI.PreCall(1481);
            this.Store(proc, 4);
            HalconAPI.Store(proc, 1, (HObjectBase)imageRect1T1);
            HalconAPI.Store(proc, 2, (HObjectBase)imageRect2T1);
            HalconAPI.Store(proc, 3, (HObjectBase)imageRect1T2);
            HalconAPI.Store(proc, 4, (HObjectBase)imageRect2T2);
            HalconAPI.Store(proc, 5, (HObjectBase)disparity);
            HalconAPI.Store(proc, 0, smoothingFlow);
            HalconAPI.Store(proc, 1, smoothingDisparity);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.Store(proc, 5, (HData)camParamRect2);
            HalconAPI.Store(proc, 6, (HData)relPoseRect);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(smoothingFlow);
            HalconAPI.UnpinTuple(smoothingDisparity);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect2));
            HalconAPI.UnpinTuple((HTuple)((HData)relPoseRect));
            HObjectModel3D[] hobjectModel3DArray;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3DArray);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)imageRect1T1);
            GC.KeepAlive((object)imageRect2T1);
            GC.KeepAlive((object)imageRect1T2);
            GC.KeepAlive((object)imageRect2T2);
            GC.KeepAlive((object)disparity);
            return hobjectModel3DArray;
        }

        /// <summary>
        ///   Compute the calibrated scene flow between two stereo image pairs.
        ///   Instance represents: Internal camera parameters of the rectified camera 1.
        /// </summary>
        /// <param name="imageRect1T1">Input image 1 at time @f$t_{1}$t_1.</param>
        /// <param name="imageRect2T1">Input image 2 at time @f$t_{1}$t_1.</param>
        /// <param name="imageRect1T2">Input image 1 at time @f$t_{2}$t_2.</param>
        /// <param name="imageRect2T2">Input image 2 at time @f$t_{2}$t_2.</param>
        /// <param name="disparity">Disparity between input images 1 and 2 at time @f$t_{1}$t_1.</param>
        /// <param name="smoothingFlow">Weight of the regularization term relative to the data term (derivatives of the optical flow). Default: 40.0</param>
        /// <param name="smoothingDisparity">Weight of the regularization term relative to the data term (derivatives of the disparity change). Default: 40.0</param>
        /// <param name="genParamName">Parameter name(s) for the algorithm. Default: "default_parameters"</param>
        /// <param name="genParamValue">Parameter value(s) for the algorithm. Default: "accurate"</param>
        /// <param name="camParamRect2">Internal camera parameters of the rectified camera 2.</param>
        /// <param name="relPoseRect">Pose of the rectified camera 2 in relation to the rectified camera 1.</param>
        /// <returns>Handle of the 3D object model.</returns>
        public HObjectModel3D SceneFlowCalib(
          HImage imageRect1T1,
          HImage imageRect2T1,
          HImage imageRect1T2,
          HImage imageRect2T2,
          HImage disparity,
          double smoothingFlow,
          double smoothingDisparity,
          string genParamName,
          string genParamValue,
          HCamPar camParamRect2,
          HPose relPoseRect)
        {
            IntPtr proc = HalconAPI.PreCall(1481);
            this.Store(proc, 4);
            HalconAPI.Store(proc, 1, (HObjectBase)imageRect1T1);
            HalconAPI.Store(proc, 2, (HObjectBase)imageRect2T1);
            HalconAPI.Store(proc, 3, (HObjectBase)imageRect1T2);
            HalconAPI.Store(proc, 4, (HObjectBase)imageRect2T2);
            HalconAPI.Store(proc, 5, (HObjectBase)disparity);
            HalconAPI.StoreD(proc, 0, smoothingFlow);
            HalconAPI.StoreD(proc, 1, smoothingDisparity);
            HalconAPI.StoreS(proc, 2, genParamName);
            HalconAPI.StoreS(proc, 3, genParamValue);
            HalconAPI.Store(proc, 5, (HData)camParamRect2);
            HalconAPI.Store(proc, 6, (HData)relPoseRect);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect2));
            HalconAPI.UnpinTuple((HTuple)((HData)relPoseRect));
            HObjectModel3D hobjectModel3D;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)imageRect1T1);
            GC.KeepAlive((object)imageRect2T1);
            GC.KeepAlive((object)imageRect1T2);
            GC.KeepAlive((object)imageRect2T2);
            GC.KeepAlive((object)disparity);
            return hobjectModel3D;
        }

        /// <summary>
        ///   Compute an absolute pose out of point correspondences between world and image coordinates.
        ///   Instance represents: The inner camera parameters from camera calibration.
        /// </summary>
        /// <param name="worldX">X-Component of world coordinates.</param>
        /// <param name="worldY">Y-Component of world coordinates.</param>
        /// <param name="worldZ">Z-Component of world coordinates.</param>
        /// <param name="imageRow">Row-Component of image coordinates.</param>
        /// <param name="imageColumn">Column-Component of image coordinates.</param>
        /// <param name="method">Kind of algorithm Default: "iterative"</param>
        /// <param name="qualityType">Type of pose quality to be returned in Quality. Default: "error"</param>
        /// <param name="quality">Pose quality.</param>
        /// <returns>Pose.</returns>
        public HPose VectorToPose(
          HTuple worldX,
          HTuple worldY,
          HTuple worldZ,
          HTuple imageRow,
          HTuple imageColumn,
          string method,
          HTuple qualityType,
          out HTuple quality)
        {
            IntPtr proc = HalconAPI.PreCall(1902);
            this.Store(proc, 5);
            HalconAPI.Store(proc, 0, worldX);
            HalconAPI.Store(proc, 1, worldY);
            HalconAPI.Store(proc, 2, worldZ);
            HalconAPI.Store(proc, 3, imageRow);
            HalconAPI.Store(proc, 4, imageColumn);
            HalconAPI.StoreS(proc, 6, method);
            HalconAPI.Store(proc, 7, qualityType);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(worldX);
            HalconAPI.UnpinTuple(worldY);
            HalconAPI.UnpinTuple(worldZ);
            HalconAPI.UnpinTuple(imageRow);
            HalconAPI.UnpinTuple(imageColumn);
            HalconAPI.UnpinTuple(qualityType);
            HPose hpose;
            int err2 = HPose.LoadNew(proc, 0, err1, out hpose);
            int procResult = HTuple.LoadNew(proc, 1, err2, out quality);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hpose;
        }

        /// <summary>
        ///   Compute an absolute pose out of point correspondences between world and image coordinates.
        ///   Instance represents: The inner camera parameters from camera calibration.
        /// </summary>
        /// <param name="worldX">X-Component of world coordinates.</param>
        /// <param name="worldY">Y-Component of world coordinates.</param>
        /// <param name="worldZ">Z-Component of world coordinates.</param>
        /// <param name="imageRow">Row-Component of image coordinates.</param>
        /// <param name="imageColumn">Column-Component of image coordinates.</param>
        /// <param name="method">Kind of algorithm Default: "iterative"</param>
        /// <param name="qualityType">Type of pose quality to be returned in Quality. Default: "error"</param>
        /// <param name="quality">Pose quality.</param>
        /// <returns>Pose.</returns>
        public HPose VectorToPose(
          HTuple worldX,
          HTuple worldY,
          HTuple worldZ,
          HTuple imageRow,
          HTuple imageColumn,
          string method,
          string qualityType,
          out double quality)
        {
            IntPtr proc = HalconAPI.PreCall(1902);
            this.Store(proc, 5);
            HalconAPI.Store(proc, 0, worldX);
            HalconAPI.Store(proc, 1, worldY);
            HalconAPI.Store(proc, 2, worldZ);
            HalconAPI.Store(proc, 3, imageRow);
            HalconAPI.Store(proc, 4, imageColumn);
            HalconAPI.StoreS(proc, 6, method);
            HalconAPI.StoreS(proc, 7, qualityType);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(worldX);
            HalconAPI.UnpinTuple(worldY);
            HalconAPI.UnpinTuple(worldZ);
            HalconAPI.UnpinTuple(imageRow);
            HalconAPI.UnpinTuple(imageColumn);
            HPose hpose;
            int err2 = HPose.LoadNew(proc, 0, err1, out hpose);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out quality);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hpose;
        }

        /// <summary>
        ///   Calibrate the radial distortion.
        ///   Modified instance represents: Internal camera parameters.
        /// </summary>
        /// <param name="contours">Contours that are available for the calibration.</param>
        /// <param name="width">Width of the images from which the contours were extracted. Default: 640</param>
        /// <param name="height">Height of the images from which the contours were extracted. Default: 480</param>
        /// <param name="inlierThreshold">Threshold for the classification of outliers. Default: 0.05</param>
        /// <param name="randSeed">Seed value for the random number generator. Default: 42</param>
        /// <param name="distortionModel">Determines the distortion model. Default: "division"</param>
        /// <param name="distortionCenter">Determines how the distortion center will be estimated. Default: "variable"</param>
        /// <param name="principalPointVar">Controls the deviation of the distortion center from the image center; larger values allow larger deviations from the image center; 0 switches the penalty term off. Default: 0.0</param>
        /// <returns>Contours that were used for the calibration</returns>
        public HXLDCont RadialDistortionSelfCalibration(
          HXLDCont contours,
          int width,
          int height,
          double inlierThreshold,
          int randSeed,
          string distortionModel,
          string distortionCenter,
          double principalPointVar)
        {
            IntPtr proc = HalconAPI.PreCall(1904);
            HalconAPI.Store(proc, 1, (HObjectBase)contours);
            HalconAPI.StoreI(proc, 0, width);
            HalconAPI.StoreI(proc, 1, height);
            HalconAPI.StoreD(proc, 2, inlierThreshold);
            HalconAPI.StoreI(proc, 3, randSeed);
            HalconAPI.StoreS(proc, 4, distortionModel);
            HalconAPI.StoreS(proc, 5, distortionCenter);
            HalconAPI.StoreD(proc, 6, principalPointVar);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = this.Load(proc, 0, err1);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err2, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contours);
            return hxldCont;
        }

        /// <summary>
        ///   Compute a camera matrix from internal camera parameters.
        ///   Instance represents: Internal camera parameters.
        /// </summary>
        /// <param name="imageWidth">Width of the images that correspond to CameraMatrix.</param>
        /// <param name="imageHeight">Height of the images that correspond to CameraMatrix.</param>
        /// <returns>3x3 projective camera matrix that corresponds to CameraParam.</returns>
        public HHomMat2D CamParToCamMat(out int imageWidth, out int imageHeight)
        {
            IntPtr proc = HalconAPI.PreCall(1905);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HHomMat2D hhomMat2D;
            int err2 = HHomMat2D.LoadNew(proc, 0, err1, out hhomMat2D);
            int err3 = HalconAPI.LoadI(proc, 1, err2, out imageWidth);
            int procResult = HalconAPI.LoadI(proc, 2, err3, out imageHeight);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat2D;
        }

        /// <summary>
        ///   Compute the internal camera parameters from a camera matrix.
        ///   Modified instance represents: Internal camera parameters.
        /// </summary>
        /// <param name="cameraMatrix">3x3 projective camera matrix that determines the internal camera parameters.</param>
        /// <param name="kappa">Kappa.</param>
        /// <param name="imageWidth">Width of the images that correspond to CameraMatrix.</param>
        /// <param name="imageHeight">Height of the images that correspond to CameraMatrix.</param>
        public void CamMatToCamPar(
          HHomMat2D cameraMatrix,
          double kappa,
          int imageWidth,
          int imageHeight)
        {
            IntPtr proc = HalconAPI.PreCall(1906);
            HalconAPI.Store(proc, 0, (HData)cameraMatrix);
            HalconAPI.StoreD(proc, 1, kappa);
            HalconAPI.StoreI(proc, 2, imageWidth);
            HalconAPI.StoreI(proc, 3, imageHeight);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)cameraMatrix));
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Determine the 3D pose of a rectangle from its perspective 2D projection
        ///   Instance represents: Internal camera parameters.
        /// </summary>
        /// <param name="contour">Contour(s) to be examined.</param>
        /// <param name="width">Width of the rectangle in meters.</param>
        /// <param name="height">Height of the rectangle in meters.</param>
        /// <param name="weightingMode">Weighting mode for the optimization phase. Default: "nonweighted"</param>
        /// <param name="clippingFactor">Clipping factor for the elimination of outliers (typical: 1.0 for 'huber' and 3.0 for 'tukey'). Default: 2.0</param>
        /// <param name="covPose">Covariances of the pose values.</param>
        /// <param name="error">Root-mean-square value of the final residual error.</param>
        /// <returns>3D pose of the rectangle.</returns>
        public HPose[] GetRectanglePose(
          HXLD contour,
          HTuple width,
          HTuple height,
          string weightingMode,
          double clippingFactor,
          out HTuple covPose,
          out HTuple error)
        {
            IntPtr proc = HalconAPI.PreCall(1908);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)contour);
            HalconAPI.Store(proc, 1, width);
            HalconAPI.Store(proc, 2, height);
            HalconAPI.StoreS(proc, 3, weightingMode);
            HalconAPI.StoreD(proc, 4, clippingFactor);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(width);
            HalconAPI.UnpinTuple(height);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out covPose);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out error);
            HalconAPI.PostCall(proc, procResult);
            HPose[] hposeArray = HPose.SplitArray(tuple);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contour);
            return hposeArray;
        }

        /// <summary>
        ///   Determine the 3D pose of a rectangle from its perspective 2D projection
        ///   Instance represents: Internal camera parameters.
        /// </summary>
        /// <param name="contour">Contour(s) to be examined.</param>
        /// <param name="width">Width of the rectangle in meters.</param>
        /// <param name="height">Height of the rectangle in meters.</param>
        /// <param name="weightingMode">Weighting mode for the optimization phase. Default: "nonweighted"</param>
        /// <param name="clippingFactor">Clipping factor for the elimination of outliers (typical: 1.0 for 'huber' and 3.0 for 'tukey'). Default: 2.0</param>
        /// <param name="covPose">Covariances of the pose values.</param>
        /// <param name="error">Root-mean-square value of the final residual error.</param>
        /// <returns>3D pose of the rectangle.</returns>
        public HPose GetRectanglePose(
          HXLD contour,
          double width,
          double height,
          string weightingMode,
          double clippingFactor,
          out HTuple covPose,
          out HTuple error)
        {
            IntPtr proc = HalconAPI.PreCall(1908);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)contour);
            HalconAPI.StoreD(proc, 1, width);
            HalconAPI.StoreD(proc, 2, height);
            HalconAPI.StoreS(proc, 3, weightingMode);
            HalconAPI.StoreD(proc, 4, clippingFactor);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HPose hpose;
            int err2 = HPose.LoadNew(proc, 0, err1, out hpose);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out covPose);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out error);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contour);
            return hpose;
        }

        /// <summary>
        ///   Determine the 3D pose of a circle from its perspective 2D projection.
        ///   Instance represents: Internal camera parameters.
        /// </summary>
        /// <param name="contour">Contours to be examined.</param>
        /// <param name="radius">Radius of the circle in object space.</param>
        /// <param name="outputType">Type of output parameters. Default: "pose"</param>
        /// <param name="pose2">3D pose of the second circle.</param>
        /// <returns>3D pose of the first circle.</returns>
        public HTuple GetCirclePose(
          HXLD contour,
          HTuple radius,
          string outputType,
          out HTuple pose2)
        {
            IntPtr proc = HalconAPI.PreCall(1909);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)contour);
            HalconAPI.Store(proc, 1, radius);
            HalconAPI.StoreS(proc, 2, outputType);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(radius);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, err2, out pose2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contour);
            return tuple;
        }

        /// <summary>
        ///   Determine the 3D pose of a circle from its perspective 2D projection.
        ///   Instance represents: Internal camera parameters.
        /// </summary>
        /// <param name="contour">Contours to be examined.</param>
        /// <param name="radius">Radius of the circle in object space.</param>
        /// <param name="outputType">Type of output parameters. Default: "pose"</param>
        /// <param name="pose2">3D pose of the second circle.</param>
        /// <returns>3D pose of the first circle.</returns>
        public HTuple GetCirclePose(
          HXLD contour,
          double radius,
          string outputType,
          out HTuple pose2)
        {
            IntPtr proc = HalconAPI.PreCall(1909);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)contour);
            HalconAPI.StoreD(proc, 1, radius);
            HalconAPI.StoreS(proc, 2, outputType);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, err2, out pose2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contour);
            return tuple;
        }

        /// <summary>
        ///   Generate a projection map that describes the mapping of images corresponding to a changing radial distortion.
        ///   Instance represents: Old camera parameters.
        /// </summary>
        /// <param name="camParamOut">New camera parameters.</param>
        /// <param name="mapType">Type of the mapping. Default: "bilinear"</param>
        /// <returns>Image containing the mapping data.</returns>
        public HImage GenRadialDistortionMap(HCamPar camParamOut, string mapType)
        {
            IntPtr proc = HalconAPI.PreCall(1912);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)camParamOut);
            HalconAPI.StoreS(proc, 2, mapType);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParamOut));
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>
        ///   Generate a projection map that describes the mapping between the image plane and a the plane z=0 of a world coordinate system.
        ///   Instance represents: Internal camera parameters.
        /// </summary>
        /// <param name="worldPose">3D pose of the world coordinate system in camera coordinates.</param>
        /// <param name="widthIn">Width of the images to be transformed.</param>
        /// <param name="heightIn">Height of the images to be transformed.</param>
        /// <param name="widthMapped">Width of the resulting mapped images in pixels.</param>
        /// <param name="heightMapped">Height of the resulting mapped images in pixels.</param>
        /// <param name="scale">Scale or unit. Default: "m"</param>
        /// <param name="mapType">Type of the mapping. Default: "bilinear"</param>
        /// <returns>Image containing the mapping data.</returns>
        public HImage GenImageToWorldPlaneMap(
          HPose worldPose,
          int widthIn,
          int heightIn,
          int widthMapped,
          int heightMapped,
          HTuple scale,
          string mapType)
        {
            IntPtr proc = HalconAPI.PreCall(1913);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)worldPose);
            HalconAPI.StoreI(proc, 2, widthIn);
            HalconAPI.StoreI(proc, 3, heightIn);
            HalconAPI.StoreI(proc, 4, widthMapped);
            HalconAPI.StoreI(proc, 5, heightMapped);
            HalconAPI.Store(proc, 6, scale);
            HalconAPI.StoreS(proc, 7, mapType);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)worldPose));
            HalconAPI.UnpinTuple(scale);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>
        ///   Generate a projection map that describes the mapping between the image plane and a the plane z=0 of a world coordinate system.
        ///   Instance represents: Internal camera parameters.
        /// </summary>
        /// <param name="worldPose">3D pose of the world coordinate system in camera coordinates.</param>
        /// <param name="widthIn">Width of the images to be transformed.</param>
        /// <param name="heightIn">Height of the images to be transformed.</param>
        /// <param name="widthMapped">Width of the resulting mapped images in pixels.</param>
        /// <param name="heightMapped">Height of the resulting mapped images in pixels.</param>
        /// <param name="scale">Scale or unit. Default: "m"</param>
        /// <param name="mapType">Type of the mapping. Default: "bilinear"</param>
        /// <returns>Image containing the mapping data.</returns>
        public HImage GenImageToWorldPlaneMap(
          HPose worldPose,
          int widthIn,
          int heightIn,
          int widthMapped,
          int heightMapped,
          string scale,
          string mapType)
        {
            IntPtr proc = HalconAPI.PreCall(1913);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)worldPose);
            HalconAPI.StoreI(proc, 2, widthIn);
            HalconAPI.StoreI(proc, 3, heightIn);
            HalconAPI.StoreI(proc, 4, widthMapped);
            HalconAPI.StoreI(proc, 5, heightMapped);
            HalconAPI.StoreS(proc, 6, scale);
            HalconAPI.StoreS(proc, 7, mapType);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)worldPose));
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>
        ///   Rectify an image by transforming it into the plane z=0 of a world coordinate system.
        ///   Instance represents: Internal camera parameters.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="worldPose">3D pose of the world coordinate system in camera coordinates.</param>
        /// <param name="width">Width of the resulting image in pixels.</param>
        /// <param name="height">Height of the resulting image in pixels.</param>
        /// <param name="scale">Scale or unit Default: "m"</param>
        /// <param name="interpolation">Type of interpolation. Default: "bilinear"</param>
        /// <returns>Transformed image.</returns>
        public HImage ImageToWorldPlane(
          HImage image,
          HPose worldPose,
          int width,
          int height,
          HTuple scale,
          string interpolation)
        {
            IntPtr proc = HalconAPI.PreCall(1914);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 1, (HData)worldPose);
            HalconAPI.StoreI(proc, 2, width);
            HalconAPI.StoreI(proc, 3, height);
            HalconAPI.Store(proc, 4, scale);
            HalconAPI.StoreS(proc, 5, interpolation);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)worldPose));
            HalconAPI.UnpinTuple(scale);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return himage;
        }

        /// <summary>
        ///   Rectify an image by transforming it into the plane z=0 of a world coordinate system.
        ///   Instance represents: Internal camera parameters.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="worldPose">3D pose of the world coordinate system in camera coordinates.</param>
        /// <param name="width">Width of the resulting image in pixels.</param>
        /// <param name="height">Height of the resulting image in pixels.</param>
        /// <param name="scale">Scale or unit Default: "m"</param>
        /// <param name="interpolation">Type of interpolation. Default: "bilinear"</param>
        /// <returns>Transformed image.</returns>
        public HImage ImageToWorldPlane(
          HImage image,
          HPose worldPose,
          int width,
          int height,
          string scale,
          string interpolation)
        {
            IntPtr proc = HalconAPI.PreCall(1914);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 1, (HData)worldPose);
            HalconAPI.StoreI(proc, 2, width);
            HalconAPI.StoreI(proc, 3, height);
            HalconAPI.StoreS(proc, 4, scale);
            HalconAPI.StoreS(proc, 5, interpolation);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)worldPose));
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return himage;
        }

        /// <summary>
        ///   Transform image points into the plane z=0 of a world coordinate system.
        ///   Instance represents: Internal camera parameters.
        /// </summary>
        /// <param name="worldPose">3D pose of the world coordinate system in camera coordinates.</param>
        /// <param name="rows">Row coordinates of the points to be transformed. Default: 100.0</param>
        /// <param name="cols">Column coordinates of the points to be transformed. Default: 100.0</param>
        /// <param name="scale">Scale or dimension Default: "m"</param>
        /// <param name="x">X coordinates of the points in the world coordinate system.</param>
        /// <param name="y">Y coordinates of the points in the world coordinate system.</param>
        public void ImagePointsToWorldPlane(
          HPose worldPose,
          HTuple rows,
          HTuple cols,
          HTuple scale,
          out HTuple x,
          out HTuple y)
        {
            IntPtr proc = HalconAPI.PreCall(1916);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)worldPose);
            HalconAPI.Store(proc, 2, rows);
            HalconAPI.Store(proc, 3, cols);
            HalconAPI.Store(proc, 4, scale);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)worldPose));
            HalconAPI.UnpinTuple(rows);
            HalconAPI.UnpinTuple(cols);
            HalconAPI.UnpinTuple(scale);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out x);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out y);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Transform image points into the plane z=0 of a world coordinate system.
        ///   Instance represents: Internal camera parameters.
        /// </summary>
        /// <param name="worldPose">3D pose of the world coordinate system in camera coordinates.</param>
        /// <param name="rows">Row coordinates of the points to be transformed. Default: 100.0</param>
        /// <param name="cols">Column coordinates of the points to be transformed. Default: 100.0</param>
        /// <param name="scale">Scale or dimension Default: "m"</param>
        /// <param name="x">X coordinates of the points in the world coordinate system.</param>
        /// <param name="y">Y coordinates of the points in the world coordinate system.</param>
        public void ImagePointsToWorldPlane(
          HPose worldPose,
          HTuple rows,
          HTuple cols,
          string scale,
          out HTuple x,
          out HTuple y)
        {
            IntPtr proc = HalconAPI.PreCall(1916);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)worldPose);
            HalconAPI.Store(proc, 2, rows);
            HalconAPI.Store(proc, 3, cols);
            HalconAPI.StoreS(proc, 4, scale);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)worldPose));
            HalconAPI.UnpinTuple(rows);
            HalconAPI.UnpinTuple(cols);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out x);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out y);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Perform a hand-eye calibration.
        ///   Instance represents: Internal camera parameters.
        /// </summary>
        /// <param name="x">Linear list containing all the x coordinates of the calibration points (in the order of the images).</param>
        /// <param name="y">Linear list containing all the y coordinates of the calibration points (in the order of the images).</param>
        /// <param name="z">Linear list containing all the z coordinates of the calibration points (in the order of the images).</param>
        /// <param name="row">Linear list containing all row coordinates of the calibration points (in the order of the images).</param>
        /// <param name="col">Linear list containing all the column coordinates of the calibration points (in the order of the images).</param>
        /// <param name="numPoints">Number of the calibration points for each image.</param>
        /// <param name="robotPoses">Known 3D pose of the robot for each image (moving camera: robot base in robot tool coordinates; stationary camera: robot tool in robot base coordinates).</param>
        /// <param name="method">Method of hand-eye calibration. Default: "nonlinear"</param>
        /// <param name="qualityType">Type of quality assessment. Default: "error_pose"</param>
        /// <param name="calibrationPose">Computed 3D pose of the calibration points in robot base coordinates (moving camera) or in robot tool coordinates (stationary camera), respectively.</param>
        /// <param name="quality">Quality assessment of the result.</param>
        /// <returns>Computed relative camera pose: 3D pose of the robot tool (moving camera) or robot base (stationary camera), respectively, in camera coordinates.</returns>
        public HPose HandEyeCalibration(
          HTuple x,
          HTuple y,
          HTuple z,
          HTuple row,
          HTuple col,
          HTuple numPoints,
          HPose[] robotPoses,
          string method,
          HTuple qualityType,
          out HPose calibrationPose,
          out HTuple quality)
        {
            HTuple htuple = HData.ConcatArray((HData[])robotPoses);
            IntPtr proc = HalconAPI.PreCall(1918);
            this.Store(proc, 7);
            HalconAPI.Store(proc, 0, x);
            HalconAPI.Store(proc, 1, y);
            HalconAPI.Store(proc, 2, z);
            HalconAPI.Store(proc, 3, row);
            HalconAPI.Store(proc, 4, col);
            HalconAPI.Store(proc, 5, numPoints);
            HalconAPI.Store(proc, 6, htuple);
            HalconAPI.StoreS(proc, 8, method);
            HalconAPI.Store(proc, 9, qualityType);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(x);
            HalconAPI.UnpinTuple(y);
            HalconAPI.UnpinTuple(z);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(col);
            HalconAPI.UnpinTuple(numPoints);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(qualityType);
            HPose hpose;
            int err2 = HPose.LoadNew(proc, 0, err1, out hpose);
            int err3 = HPose.LoadNew(proc, 1, err2, out calibrationPose);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out quality);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hpose;
        }

        /// <summary>
        ///   Perform a hand-eye calibration.
        ///   Instance represents: Internal camera parameters.
        /// </summary>
        /// <param name="x">Linear list containing all the x coordinates of the calibration points (in the order of the images).</param>
        /// <param name="y">Linear list containing all the y coordinates of the calibration points (in the order of the images).</param>
        /// <param name="z">Linear list containing all the z coordinates of the calibration points (in the order of the images).</param>
        /// <param name="row">Linear list containing all row coordinates of the calibration points (in the order of the images).</param>
        /// <param name="col">Linear list containing all the column coordinates of the calibration points (in the order of the images).</param>
        /// <param name="numPoints">Number of the calibration points for each image.</param>
        /// <param name="robotPoses">Known 3D pose of the robot for each image (moving camera: robot base in robot tool coordinates; stationary camera: robot tool in robot base coordinates).</param>
        /// <param name="method">Method of hand-eye calibration. Default: "nonlinear"</param>
        /// <param name="qualityType">Type of quality assessment. Default: "error_pose"</param>
        /// <param name="calibrationPose">Computed 3D pose of the calibration points in robot base coordinates (moving camera) or in robot tool coordinates (stationary camera), respectively.</param>
        /// <param name="quality">Quality assessment of the result.</param>
        /// <returns>Computed relative camera pose: 3D pose of the robot tool (moving camera) or robot base (stationary camera), respectively, in camera coordinates.</returns>
        public HPose HandEyeCalibration(
          HTuple x,
          HTuple y,
          HTuple z,
          HTuple row,
          HTuple col,
          HTuple numPoints,
          HPose[] robotPoses,
          string method,
          string qualityType,
          out HPose calibrationPose,
          out double quality)
        {
            HTuple htuple = HData.ConcatArray((HData[])robotPoses);
            IntPtr proc = HalconAPI.PreCall(1918);
            this.Store(proc, 7);
            HalconAPI.Store(proc, 0, x);
            HalconAPI.Store(proc, 1, y);
            HalconAPI.Store(proc, 2, z);
            HalconAPI.Store(proc, 3, row);
            HalconAPI.Store(proc, 4, col);
            HalconAPI.Store(proc, 5, numPoints);
            HalconAPI.Store(proc, 6, htuple);
            HalconAPI.StoreS(proc, 8, method);
            HalconAPI.StoreS(proc, 9, qualityType);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(x);
            HalconAPI.UnpinTuple(y);
            HalconAPI.UnpinTuple(z);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(col);
            HalconAPI.UnpinTuple(numPoints);
            HalconAPI.UnpinTuple(htuple);
            HPose hpose;
            int err2 = HPose.LoadNew(proc, 0, err1, out hpose);
            int err3 = HPose.LoadNew(proc, 1, err2, out calibrationPose);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out quality);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hpose;
        }

        /// <summary>
        ///   Change the radial distortion of contours.
        ///   Instance represents: Internal camera parameter for Contours.
        /// </summary>
        /// <param name="contours">Original contours.</param>
        /// <param name="camParamOut">Internal camera parameter for ContoursRectified.</param>
        /// <returns>Resulting contours with modified radial distortion.</returns>
        public HXLDCont ChangeRadialDistortionContoursXld(
          HXLDCont contours,
          HCamPar camParamOut)
        {
            IntPtr proc = HalconAPI.PreCall(1922);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)contours);
            HalconAPI.Store(proc, 1, (HData)camParamOut);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParamOut));
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contours);
            return hxldCont;
        }

        /// <summary>
        ///   Change the radial distortion of pixel coordinates.
        ///   Instance represents: The inner camera parameters of the camera used to create the input pixel coordinates.
        /// </summary>
        /// <param name="row">Original row component of pixel coordinates.</param>
        /// <param name="col">Original column component of pixel coordinates.</param>
        /// <param name="camParamOut">The inner camera parameters of a camera.</param>
        /// <param name="rowChanged">Row component of pixel coordinates after changing the radial distortion.</param>
        /// <param name="colChanged">Column component of pixel coordinates after changing the radial distortion.</param>
        public void ChangeRadialDistortionPoints(
          HTuple row,
          HTuple col,
          HCamPar camParamOut,
          out HTuple rowChanged,
          out HTuple colChanged)
        {
            IntPtr proc = HalconAPI.PreCall(1923);
            this.Store(proc, 2);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, col);
            HalconAPI.Store(proc, 3, (HData)camParamOut);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(col);
            HalconAPI.UnpinTuple((HTuple)((HData)camParamOut));
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out rowChanged);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out colChanged);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Change the radial distortion of an image.
        ///   Instance represents: Internal camera parameter for Image.
        /// </summary>
        /// <param name="image">Original image.</param>
        /// <param name="region">Region of interest in ImageRectified.</param>
        /// <param name="camParamOut">Internal camera parameter for Image.</param>
        /// <returns>Resulting image with modified radial distortion.</returns>
        public HImage ChangeRadialDistortionImage(
          HImage image,
          HRegion region,
          HCamPar camParamOut)
        {
            IntPtr proc = HalconAPI.PreCall(1924);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 2, (HObjectBase)region);
            HalconAPI.Store(proc, 1, (HData)camParamOut);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParamOut));
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)region);
            return himage;
        }

        /// <summary>
        ///   Determine new camera parameters in accordance to the specified radial distortion.
        ///   Instance represents: Internal camera parameters (original).
        /// </summary>
        /// <param name="mode">Mode Default: "adaptive"</param>
        /// <param name="distortionCoeffs">Desired radial distortions. Default: 0.0</param>
        /// <returns>Internal camera parameters (modified).</returns>
        public HCamPar ChangeRadialDistortionCamPar(string mode, HTuple distortionCoeffs)
        {
            IntPtr proc = HalconAPI.PreCall(1925);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.Store(proc, 2, distortionCoeffs);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(distortionCoeffs);
            HCamPar hcamPar;
            int procResult = HCamPar.LoadNew(proc, 0, err, out hcamPar);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hcamPar;
        }

        /// <summary>
        ///   Determine new camera parameters in accordance to the specified radial distortion.
        ///   Instance represents: Internal camera parameters (original).
        /// </summary>
        /// <param name="mode">Mode Default: "adaptive"</param>
        /// <param name="distortionCoeffs">Desired radial distortions. Default: 0.0</param>
        /// <returns>Internal camera parameters (modified).</returns>
        public HCamPar ChangeRadialDistortionCamPar(string mode, double distortionCoeffs)
        {
            IntPtr proc = HalconAPI.PreCall(1925);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, mode);
            HalconAPI.StoreD(proc, 2, distortionCoeffs);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HCamPar hcamPar;
            int procResult = HCamPar.LoadNew(proc, 0, err, out hcamPar);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hcamPar;
        }

        /// <summary>
        ///   Compute the line of sight corresponding to a point in the image.
        ///   Instance represents: Internal camera parameters.
        /// </summary>
        /// <param name="row">Row coordinate of the pixel.</param>
        /// <param name="column">Column coordinate of the pixel.</param>
        /// <param name="PX">X coordinate of the first point on the line of sight in the camera coordinate system</param>
        /// <param name="PY">Y coordinate of the first point on the line of sight in the camera coordinate system</param>
        /// <param name="PZ">Z coordinate of the first point on the line of sight in the camera coordinate system</param>
        /// <param name="QX">X coordinate of the second point on the line of sight in the camera coordinate system</param>
        /// <param name="QY">Y coordinate of the second point on the line of sight in the camera coordinate system</param>
        /// <param name="QZ">Z coordinate of the second point on the line of sight in the camera coordinate system</param>
        public void GetLineOfSight(
          HTuple row,
          HTuple column,
          out HTuple PX,
          out HTuple PY,
          out HTuple PZ,
          out HTuple QX,
          out HTuple QY,
          out HTuple QZ)
        {
            IntPtr proc = HalconAPI.PreCall(1929);
            this.Store(proc, 2);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, column);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out PX);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out PY);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out PZ);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out QX);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out QY);
            int procResult = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, err6, out QZ);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Project 3D points into (sub-)pixel image coordinates.
        ///   Instance represents: Internal camera parameters.
        /// </summary>
        /// <param name="x">X coordinates of the 3D points to be projected in the camera coordinate system.</param>
        /// <param name="y">Y coordinates of the 3D points to be projected in the camera coordinate system.</param>
        /// <param name="z">Z coordinates of the 3D points to be projected in the camera coordinate system.</param>
        /// <param name="row">Row coordinates of the projected points (in pixels).</param>
        /// <param name="column">Column coordinates of the projected points (in pixels).</param>
        public void Project3dPoint(HTuple x, HTuple y, HTuple z, out HTuple row, out HTuple column)
        {
            IntPtr proc = HalconAPI.PreCall(1932);
            this.Store(proc, 3);
            HalconAPI.Store(proc, 0, x);
            HalconAPI.Store(proc, 1, y);
            HalconAPI.Store(proc, 2, z);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(x);
            HalconAPI.UnpinTuple(y);
            HalconAPI.UnpinTuple(z);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out column);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Convert internal camera parameters and a 3D pose into a 3x4 projection matrix.
        ///   Instance represents: Internal camera parameters.
        /// </summary>
        /// <param name="pose">3D pose.</param>
        /// <returns>3x4 projection matrix.</returns>
        public HHomMat3D CamParPoseToHomMat3d(HPose pose)
        {
            IntPtr proc = HalconAPI.PreCall(1933);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)pose);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)pose));
            HHomMat3D hhomMat3D;
            int procResult = HHomMat3D.LoadNew(proc, 0, err, out hhomMat3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat3D;
        }

        /// <summary>
        ///   Deserialize the serialized internal camera parameters.
        ///   Modified instance represents: Internal camera parameters.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeCamPar(HSerializedItem serializedItemHandle)
        {
            IntPtr proc = HalconAPI.PreCall(1936);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize the internal camera parameters.
        ///   Instance represents: Internal camera parameters.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeCamPar()
        {
            IntPtr proc = HalconAPI.PreCall(1937);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HSerializedItem hserializedItem;
            int procResult = HSerializedItem.LoadNew(proc, 0, err, out hserializedItem);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hserializedItem;
        }

        /// <summary>
        ///   Read internal camera parameters from a file.
        ///   Modified instance represents: Internal camera parameters.
        /// </summary>
        /// <param name="camParFile">File name of internal camera parameters. Default: "campar.dat"</param>
        public void ReadCamPar(string camParFile)
        {
            IntPtr proc = HalconAPI.PreCall(1942);
            HalconAPI.StoreS(proc, 0, camParFile);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write internal camera parameters into a file.
        ///   Instance represents: Internal camera parameters.
        /// </summary>
        /// <param name="camParFile">File name of internal camera parameters. Default: "campar.dat"</param>
        public void WriteCamPar(string camParFile)
        {
            IntPtr proc = HalconAPI.PreCall(1943);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, camParFile);
            int procResult = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Simulate an image with calibration plate.
        ///   Instance represents: Internal camera parameters.
        /// </summary>
        /// <param name="calPlateDescr">File name of the calibration plate description. Default: "calplate.cpd"</param>
        /// <param name="calPlatePose">External camera parameters (3D pose of the calibration plate in camera coordinates).</param>
        /// <param name="grayBackground">Gray value of image background. Default: 128</param>
        /// <param name="grayPlate">Gray value of calibration plate. Default: 80</param>
        /// <param name="grayMarks">Gray value of calibration marks. Default: 224</param>
        /// <param name="scaleFac">Scaling factor to reduce oversampling. Default: 1.0</param>
        /// <returns>Simulated calibration image.</returns>
        public HImage SimCaltab(
          string calPlateDescr,
          HPose calPlatePose,
          int grayBackground,
          int grayPlate,
          int grayMarks,
          double scaleFac)
        {
            IntPtr proc = HalconAPI.PreCall(1944);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, calPlateDescr);
            HalconAPI.Store(proc, 2, (HData)calPlatePose);
            HalconAPI.StoreI(proc, 3, grayBackground);
            HalconAPI.StoreI(proc, 4, grayPlate);
            HalconAPI.StoreI(proc, 5, grayMarks);
            HalconAPI.StoreD(proc, 6, scaleFac);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)calPlatePose));
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>
        ///   Project and visualize the 3D model of the calibration plate in the image.
        ///   Instance represents: Internal camera parameters.
        /// </summary>
        /// <param name="windowHandle">Window in which the calibration plate should be visualized.</param>
        /// <param name="calPlateDescr">File name of the calibration plate description. Default: "calplate.cpd"</param>
        /// <param name="calPlatePose">External camera parameters (3D pose of the calibration plate in camera coordinates).</param>
        /// <param name="scaleFac">Scaling factor for the visualization. Default: 1.0</param>
        public void DispCaltab(
          HWindow windowHandle,
          string calPlateDescr,
          HPose calPlatePose,
          double scaleFac)
        {
            IntPtr proc = HalconAPI.PreCall(1945);
            this.Store(proc, 2);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            HalconAPI.StoreS(proc, 1, calPlateDescr);
            HalconAPI.Store(proc, 3, (HData)calPlatePose);
            HalconAPI.StoreD(proc, 4, scaleFac);
            int procResult = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)calPlatePose));
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)windowHandle);
        }

        /// <summary>
        ///   Determine all camera parameters by a simultaneous minimization process.
        ///   Instance represents: Initial values for the internal camera parameters.
        /// </summary>
        /// <param name="NX">Ordered tuple with all x coordinates of the calibration marks (in meters).</param>
        /// <param name="NY">Ordered tuple with all y coordinates of the calibration marks (in meters).</param>
        /// <param name="NZ">Ordered tuple with all z coordinates of the calibration marks (in meters).</param>
        /// <param name="NRow">Ordered tuple with all row coordinates of the extracted calibration marks (in pixels).</param>
        /// <param name="NCol">Ordered tuple with all column coordinates of the extracted calibration marks (in pixels).</param>
        /// <param name="NStartPose">Ordered tuple with all initial values for the external camera parameters.</param>
        /// <param name="estimateParams">Camera parameters to be estimated. Default: "all"</param>
        /// <param name="NFinalPose">Ordered tuple with all external camera parameters.</param>
        /// <param name="errors">Average error distance in pixels.</param>
        /// <returns>Internal camera parameters.</returns>
        public HCamPar CameraCalibration(
          HTuple NX,
          HTuple NY,
          HTuple NZ,
          HTuple NRow,
          HTuple NCol,
          HPose[] NStartPose,
          HTuple estimateParams,
          out HPose[] NFinalPose,
          out HTuple errors)
        {
            HTuple htuple = HData.ConcatArray((HData[])NStartPose);
            IntPtr proc = HalconAPI.PreCall(1946);
            this.Store(proc, 5);
            HalconAPI.Store(proc, 0, NX);
            HalconAPI.Store(proc, 1, NY);
            HalconAPI.Store(proc, 2, NZ);
            HalconAPI.Store(proc, 3, NRow);
            HalconAPI.Store(proc, 4, NCol);
            HalconAPI.Store(proc, 6, htuple);
            HalconAPI.Store(proc, 7, estimateParams);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(NX);
            HalconAPI.UnpinTuple(NY);
            HalconAPI.UnpinTuple(NZ);
            HalconAPI.UnpinTuple(NRow);
            HalconAPI.UnpinTuple(NCol);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(estimateParams);
            HCamPar hcamPar;
            int err2 = HCamPar.LoadNew(proc, 0, err1, out hcamPar);
            HTuple tuple;
            int err3 = HTuple.LoadNew(proc, 1, err2, out tuple);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out errors);
            HalconAPI.PostCall(proc, procResult);
            NFinalPose = HPose.SplitArray(tuple);
            GC.KeepAlive((object)this);
            return hcamPar;
        }

        /// <summary>
        ///   Determine all camera parameters by a simultaneous minimization process.
        ///   Instance represents: Initial values for the internal camera parameters.
        /// </summary>
        /// <param name="NX">Ordered tuple with all x coordinates of the calibration marks (in meters).</param>
        /// <param name="NY">Ordered tuple with all y coordinates of the calibration marks (in meters).</param>
        /// <param name="NZ">Ordered tuple with all z coordinates of the calibration marks (in meters).</param>
        /// <param name="NRow">Ordered tuple with all row coordinates of the extracted calibration marks (in pixels).</param>
        /// <param name="NCol">Ordered tuple with all column coordinates of the extracted calibration marks (in pixels).</param>
        /// <param name="NStartPose">Ordered tuple with all initial values for the external camera parameters.</param>
        /// <param name="estimateParams">Camera parameters to be estimated. Default: "all"</param>
        /// <param name="NFinalPose">Ordered tuple with all external camera parameters.</param>
        /// <param name="errors">Average error distance in pixels.</param>
        /// <returns>Internal camera parameters.</returns>
        public HCamPar CameraCalibration(
          HTuple NX,
          HTuple NY,
          HTuple NZ,
          HTuple NRow,
          HTuple NCol,
          HPose NStartPose,
          HTuple estimateParams,
          out HPose NFinalPose,
          out double errors)
        {
            IntPtr proc = HalconAPI.PreCall(1946);
            this.Store(proc, 5);
            HalconAPI.Store(proc, 0, NX);
            HalconAPI.Store(proc, 1, NY);
            HalconAPI.Store(proc, 2, NZ);
            HalconAPI.Store(proc, 3, NRow);
            HalconAPI.Store(proc, 4, NCol);
            HalconAPI.Store(proc, 6, (HData)NStartPose);
            HalconAPI.Store(proc, 7, estimateParams);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(NX);
            HalconAPI.UnpinTuple(NY);
            HalconAPI.UnpinTuple(NZ);
            HalconAPI.UnpinTuple(NRow);
            HalconAPI.UnpinTuple(NCol);
            HalconAPI.UnpinTuple((HTuple)((HData)NStartPose));
            HalconAPI.UnpinTuple(estimateParams);
            HCamPar hcamPar;
            int err2 = HCamPar.LoadNew(proc, 0, err1, out hcamPar);
            int err3 = HPose.LoadNew(proc, 1, err2, out NFinalPose);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out errors);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hcamPar;
        }

        /// <summary>
        ///   Extract rectangularly arranged 2D calibration marks from the image and calculate initial values for the external camera parameters.
        ///   Instance represents: Initial values for the internal camera parameters.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="calPlateRegion">Region of the calibration plate.</param>
        /// <param name="calPlateDescr">File name of the calibration plate description. Default: "caltab.descr"</param>
        /// <param name="startThresh">Initial threshold value for contour detection. Default: 128</param>
        /// <param name="deltaThresh">Loop value for successive reduction of StartThresh. Default: 10</param>
        /// <param name="minThresh">Minimum threshold for contour detection. Default: 18</param>
        /// <param name="alpha">Filter parameter for contour detection, see edges_image. Default: 0.9</param>
        /// <param name="minContLength">Minimum length of the contours of the marks. Default: 15.0</param>
        /// <param name="maxDiamMarks">Maximum expected diameter of the marks. Default: 100.0</param>
        /// <param name="CCoord">Tuple with column coordinates of the detected marks.</param>
        /// <param name="startPose">Estimation for the external camera parameters.</param>
        /// <returns>Tuple with row coordinates of the detected marks.</returns>
        public HTuple FindMarksAndPose(
          HImage image,
          HRegion calPlateRegion,
          string calPlateDescr,
          int startThresh,
          int deltaThresh,
          int minThresh,
          double alpha,
          double minContLength,
          double maxDiamMarks,
          out HTuple CCoord,
          out HPose startPose)
        {
            IntPtr proc = HalconAPI.PreCall(1947);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 2, (HObjectBase)calPlateRegion);
            HalconAPI.StoreS(proc, 0, calPlateDescr);
            HalconAPI.StoreI(proc, 2, startThresh);
            HalconAPI.StoreI(proc, 3, deltaThresh);
            HalconAPI.StoreI(proc, 4, minThresh);
            HalconAPI.StoreD(proc, 5, alpha);
            HalconAPI.StoreD(proc, 6, minContLength);
            HalconAPI.StoreD(proc, 7, maxDiamMarks);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out CCoord);
            int procResult = HPose.LoadNew(proc, 2, err3, out startPose);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)calPlateRegion);
            return tuple;
        }

        /// <summary>
        ///   Define type, parameters, and relative pose of a camera in a camera setup model.
        ///   Instance represents: Internal camera parameters.
        /// </summary>
        /// <param name="cameraSetupModelID">Handle to the camera setup model.</param>
        /// <param name="cameraIdx">Index of the camera in the setup.</param>
        /// <param name="cameraType">Type of the camera. Default: []</param>
        /// <param name="cameraPose">Pose of the camera relative to the setup's coordinate system.</param>
        public void SetCameraSetupCamParam(
          HCameraSetupModel cameraSetupModelID,
          HTuple cameraIdx,
          HTuple cameraType,
          HTuple cameraPose)
        {
            IntPtr proc = HalconAPI.PreCall(1957);
            this.Store(proc, 3);
            HalconAPI.Store(proc, 0, (HTool)cameraSetupModelID);
            HalconAPI.Store(proc, 1, cameraIdx);
            HalconAPI.Store(proc, 2, cameraType);
            HalconAPI.Store(proc, 4, cameraPose);
            int procResult = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(cameraIdx);
            HalconAPI.UnpinTuple(cameraType);
            HalconAPI.UnpinTuple(cameraPose);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)cameraSetupModelID);
        }

        /// <summary>
        ///   Define type, parameters, and relative pose of a camera in a camera setup model.
        ///   Instance represents: Internal camera parameters.
        /// </summary>
        /// <param name="cameraSetupModelID">Handle to the camera setup model.</param>
        /// <param name="cameraIdx">Index of the camera in the setup.</param>
        /// <param name="cameraType">Type of the camera. Default: []</param>
        /// <param name="cameraPose">Pose of the camera relative to the setup's coordinate system.</param>
        public void SetCameraSetupCamParam(
          HCameraSetupModel cameraSetupModelID,
          HTuple cameraIdx,
          string cameraType,
          HTuple cameraPose)
        {
            IntPtr proc = HalconAPI.PreCall(1957);
            this.Store(proc, 3);
            HalconAPI.Store(proc, 0, (HTool)cameraSetupModelID);
            HalconAPI.Store(proc, 1, cameraIdx);
            HalconAPI.StoreS(proc, 2, cameraType);
            HalconAPI.Store(proc, 4, cameraPose);
            int procResult = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(cameraIdx);
            HalconAPI.UnpinTuple(cameraPose);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)cameraSetupModelID);
        }

        /// <summary>
        ///   Set type and initial parameters of a camera in a calibration data model.
        ///   Instance represents: Initial camera internal parameters.
        /// </summary>
        /// <param name="calibDataID">Handle of a calibration data model.</param>
        /// <param name="cameraIdx">Camera index. Default: 0</param>
        /// <param name="cameraType">Type of the camera. Default: []</param>
        public void SetCalibDataCamParam(HCalibData calibDataID, HTuple cameraIdx, HTuple cameraType)
        {
            IntPtr proc = HalconAPI.PreCall(1979);
            this.Store(proc, 3);
            HalconAPI.Store(proc, 0, (HTool)calibDataID);
            HalconAPI.Store(proc, 1, cameraIdx);
            HalconAPI.Store(proc, 2, cameraType);
            int procResult = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(cameraIdx);
            HalconAPI.UnpinTuple(cameraType);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)calibDataID);
        }

        /// <summary>
        ///   Set type and initial parameters of a camera in a calibration data model.
        ///   Instance represents: Initial camera internal parameters.
        /// </summary>
        /// <param name="calibDataID">Handle of a calibration data model.</param>
        /// <param name="cameraIdx">Camera index. Default: 0</param>
        /// <param name="cameraType">Type of the camera. Default: []</param>
        public void SetCalibDataCamParam(HCalibData calibDataID, HTuple cameraIdx, string cameraType)
        {
            IntPtr proc = HalconAPI.PreCall(1979);
            this.Store(proc, 3);
            HalconAPI.Store(proc, 0, (HTool)calibDataID);
            HalconAPI.Store(proc, 1, cameraIdx);
            HalconAPI.StoreS(proc, 2, cameraType);
            int procResult = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(cameraIdx);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)calibDataID);
        }
    }
}
