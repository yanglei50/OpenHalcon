using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;
namespace HalconDotNet
{
    /// <summary>Represents a rigid 3D transformation with 7 parameters (3 for the rotation, 3 for the translation, 1 for the representation type).</summary>
    [Serializable]
    public class HPose : HData, ISerializable, ICloneable
    {
        private const int FIXEDSIZE = 7;

        /// <summary>Create an uninitialized instance.</summary>
        public HPose()
        {
        }

        public HPose(HTuple tuple)
          : base(tuple)
        {
        }

        internal HPose(HData data)
          : base(data)
        {
        }

        internal static int LoadNew(
          IntPtr proc,
          int parIndex,
          HTupleType type,
          int err,
          out HPose obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HPose(new HData(tuple));
            return err;
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HPose obj)
        {
            return HPose.LoadNew(proc, parIndex, HTupleType.MIXED, err, out obj);
        }

        internal static HPose[] SplitArray(HTuple data)
        {
            int length = data.Length / 7;
            HPose[] hposeArray = new HPose[length];
            for (int index = 0; index < length; ++index)
                hposeArray[index] = new HPose(new HData(data.TupleSelectRange((HTuple)(index * 7), (HTuple)((index + 1) * 7 - 1))));
            return hposeArray;
        }

        /// <summary>
        ///   Create a 3D pose.
        ///   Modified instance represents: 3D pose.
        /// </summary>
        /// <param name="transX">Translation along the x-axis (in [m]). Default: 0.1</param>
        /// <param name="transY">Translation along the y-axis (in [m]). Default: 0.1</param>
        /// <param name="transZ">Translation along the z-axis (in [m]). Default: 0.1</param>
        /// <param name="rotX">Rotation around x-axis or x component of the Rodriguez vector (in [°] or without unit). Default: 90.0</param>
        /// <param name="rotY">Rotation around y-axis or y component of the Rodriguez vector (in [°] or without unit). Default: 90.0</param>
        /// <param name="rotZ">Rotation around z-axis or z component of the Rodriguez vector (in [°] or without unit). Default: 90.0</param>
        /// <param name="orderOfTransform">Order of rotation and translation. Default: "Rp+T"</param>
        /// <param name="orderOfRotation">Meaning of the rotation values. Default: "gba"</param>
        /// <param name="viewOfTransform">View of transformation. Default: "point"</param>
        public HPose(
          double transX,
          double transY,
          double transZ,
          double rotX,
          double rotY,
          double rotZ,
          string orderOfTransform,
          string orderOfRotation,
          string viewOfTransform)
        {
            IntPtr proc = HalconAPI.PreCall(1921);
            HalconAPI.StoreD(proc, 0, transX);
            HalconAPI.StoreD(proc, 1, transY);
            HalconAPI.StoreD(proc, 2, transZ);
            HalconAPI.StoreD(proc, 3, rotX);
            HalconAPI.StoreD(proc, 4, rotY);
            HalconAPI.StoreD(proc, 5, rotZ);
            HalconAPI.StoreS(proc, 6, orderOfTransform);
            HalconAPI.StoreS(proc, 7, orderOfRotation);
            HalconAPI.StoreS(proc, 8, viewOfTransform);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializePose();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HPose(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializePose(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializePose().Serialize(stream);
        }

        public static HPose Deserialize(Stream stream)
        {
            HPose hpose = new HPose();
            hpose.DeserializePose(HSerializedItem.Deserialize(stream));
            return hpose;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HPose Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializePose();
            HPose hpose = new HPose();
            hpose.DeserializePose(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hpose;
        }

        /// <summary>Convert to matrix</summary>
        public static implicit operator HHomMat3D(HPose pose)
        {
            return pose.PoseToHomMat3d();
        }

        /// <summary>Compute the average of a set of poses.</summary>
        /// <param name="poses">Set of poses of which the average if computed.</param>
        /// <param name="weights">Empty tuple, or one weight per pose. Default: []</param>
        /// <param name="mode">Averaging mode. Default: "iterative"</param>
        /// <param name="sigmaT">Weight of the translation. Default: "auto"</param>
        /// <param name="sigmaR">Weight of the rotation. Default: "auto"</param>
        /// <param name="quality">Deviation of the mean from the input poses.</param>
        /// <returns>Weighted mean of the poses.</returns>
        public static HPose PoseAverage(
          HPose[] poses,
          HTuple weights,
          string mode,
          HTuple sigmaT,
          HTuple sigmaR,
          out HTuple quality)
        {
            HTuple htuple = HData.ConcatArray((HData[])poses);
            IntPtr proc = HalconAPI.PreCall(221);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.Store(proc, 1, weights);
            HalconAPI.StoreS(proc, 2, mode);
            HalconAPI.Store(proc, 3, sigmaT);
            HalconAPI.Store(proc, 4, sigmaR);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(weights);
            HalconAPI.UnpinTuple(sigmaT);
            HalconAPI.UnpinTuple(sigmaR);
            HPose hpose;
            int err2 = HPose.LoadNew(proc, 0, err1, out hpose);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out quality);
            HalconAPI.PostCall(proc, procResult);
            return hpose;
        }

        /// <summary>Compute the average of a set of poses.</summary>
        /// <param name="poses">Set of poses of which the average if computed.</param>
        /// <param name="weights">Empty tuple, or one weight per pose. Default: []</param>
        /// <param name="mode">Averaging mode. Default: "iterative"</param>
        /// <param name="sigmaT">Weight of the translation. Default: "auto"</param>
        /// <param name="sigmaR">Weight of the rotation. Default: "auto"</param>
        /// <param name="quality">Deviation of the mean from the input poses.</param>
        /// <returns>Weighted mean of the poses.</returns>
        public static HPose PoseAverage(
          HPose[] poses,
          HTuple weights,
          string mode,
          double sigmaT,
          double sigmaR,
          out HTuple quality)
        {
            HTuple htuple = HData.ConcatArray((HData[])poses);
            IntPtr proc = HalconAPI.PreCall(221);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.Store(proc, 1, weights);
            HalconAPI.StoreS(proc, 2, mode);
            HalconAPI.StoreD(proc, 3, sigmaT);
            HalconAPI.StoreD(proc, 4, sigmaR);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(weights);
            HPose hpose;
            int err2 = HPose.LoadNew(proc, 0, err1, out hpose);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out quality);
            HalconAPI.PostCall(proc, procResult);
            return hpose;
        }

        /// <summary>Invert each pose in a tuple of 3D poses.</summary>
        /// <param name="pose">Tuple of 3D poses.</param>
        /// <returns>Tuple of inverted 3D poses.</returns>
        public static HPose[] PoseInvert(HPose[] pose)
        {
            HTuple htuple = HData.ConcatArray((HData[])pose);
            IntPtr proc = HalconAPI.PreCall(227);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return HPose.SplitArray(tuple);
        }

        /// <summary>
        ///   Invert each pose in a tuple of 3D poses.
        ///   Instance represents: Tuple of 3D poses.
        /// </summary>
        /// <returns>Tuple of inverted 3D poses.</returns>
        public HPose PoseInvert()
        {
            IntPtr proc = HalconAPI.PreCall(227);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HPose hpose;
            int procResult = HPose.LoadNew(proc, 0, err, out hpose);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hpose;
        }

        /// <summary>Combine 3D poses given in two tuples.</summary>
        /// <param name="poseLeft">Tuple containing the left poses.</param>
        /// <param name="poseRight">Tuple containing the right poses.</param>
        /// <returns>Tuple containing the returned poses.</returns>
        public static HPose[] PoseCompose(HPose[] poseLeft, HPose[] poseRight)
        {
            HTuple htuple1 = HData.ConcatArray((HData[])poseLeft);
            HTuple htuple2 = HData.ConcatArray((HData[])poseRight);
            IntPtr proc = HalconAPI.PreCall(228);
            HalconAPI.Store(proc, 0, htuple1);
            HalconAPI.Store(proc, 1, htuple2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple1);
            HalconAPI.UnpinTuple(htuple2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return HPose.SplitArray(tuple);
        }

        /// <summary>
        ///   Combine 3D poses given in two tuples.
        ///   Instance represents: Tuple containing the left poses.
        /// </summary>
        /// <param name="poseRight">Tuple containing the right poses.</param>
        /// <returns>Tuple containing the returned poses.</returns>
        public HPose PoseCompose(HPose poseRight)
        {
            IntPtr proc = HalconAPI.PreCall(228);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)poseRight);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)poseRight));
            HPose hpose;
            int procResult = HPose.LoadNew(proc, 0, err, out hpose);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hpose;
        }

        /// <summary>
        ///   Compute the distance values for a rectified stereo image pair using multi-scanline optimization.
        ///   Instance represents: Point transformation from the rectified camera 2 to the rectified camera 1.
        /// </summary>
        /// <param name="imageRect1">Rectified image of camera 1.</param>
        /// <param name="imageRect2">Rectified image of camera 2.</param>
        /// <param name="score">Score of the calculated disparity.</param>
        /// <param name="camParamRect1">Internal camera parameters of the rectified camera 1.</param>
        /// <param name="camParamRect2">Internal camera parameters of the rectified camera 2.</param>
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
          HCamPar camParamRect1,
          HCamPar camParamRect2,
          int minDisparity,
          int maxDisparity,
          int surfaceSmoothing,
          int edgeSmoothing,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(346);
            this.Store(proc, 2);
            HalconAPI.Store(proc, 1, (HObjectBase)imageRect1);
            HalconAPI.Store(proc, 2, (HObjectBase)imageRect2);
            HalconAPI.Store(proc, 0, (HData)camParamRect1);
            HalconAPI.Store(proc, 1, (HData)camParamRect2);
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
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect1));
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect2));
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
        ///   Instance represents: Point transformation from the rectified camera 2 to the rectified camera 1.
        /// </summary>
        /// <param name="imageRect1">Rectified image of camera 1.</param>
        /// <param name="imageRect2">Rectified image of camera 2.</param>
        /// <param name="score">Score of the calculated disparity.</param>
        /// <param name="camParamRect1">Internal camera parameters of the rectified camera 1.</param>
        /// <param name="camParamRect2">Internal camera parameters of the rectified camera 2.</param>
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
          HCamPar camParamRect1,
          HCamPar camParamRect2,
          int minDisparity,
          int maxDisparity,
          int surfaceSmoothing,
          int edgeSmoothing,
          string genParamName,
          string genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(346);
            this.Store(proc, 2);
            HalconAPI.Store(proc, 1, (HObjectBase)imageRect1);
            HalconAPI.Store(proc, 2, (HObjectBase)imageRect2);
            HalconAPI.Store(proc, 0, (HData)camParamRect1);
            HalconAPI.Store(proc, 1, (HData)camParamRect2);
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
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect1));
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect2));
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
        ///   Instance represents: Point transformation from the rectified camera 2 to the rectified camera 1.
        /// </summary>
        /// <param name="imageRect1">Rectified image of camera 1.</param>
        /// <param name="imageRect2">Rectified image of camera 2.</param>
        /// <param name="score">Score of the calculated disparity if CalculateScore is set to 'true'.</param>
        /// <param name="camParamRect1">Internal camera parameters of the rectified camera 1.</param>
        /// <param name="camParamRect2">Internal camera parameters of the rectified camera 2.</param>
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
          HCamPar camParamRect1,
          HCamPar camParamRect2,
          double grayConstancy,
          double gradientConstancy,
          double smoothness,
          double initialGuess,
          string calculateScore,
          HTuple MGParamName,
          HTuple MGParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(348);
            this.Store(proc, 2);
            HalconAPI.Store(proc, 1, (HObjectBase)imageRect1);
            HalconAPI.Store(proc, 2, (HObjectBase)imageRect2);
            HalconAPI.Store(proc, 0, (HData)camParamRect1);
            HalconAPI.Store(proc, 1, (HData)camParamRect2);
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
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect1));
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect2));
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
        ///   Instance represents: Point transformation from the rectified camera 2 to the rectified camera 1.
        /// </summary>
        /// <param name="imageRect1">Rectified image of camera 1.</param>
        /// <param name="imageRect2">Rectified image of camera 2.</param>
        /// <param name="score">Score of the calculated disparity if CalculateScore is set to 'true'.</param>
        /// <param name="camParamRect1">Internal camera parameters of the rectified camera 1.</param>
        /// <param name="camParamRect2">Internal camera parameters of the rectified camera 2.</param>
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
          HCamPar camParamRect1,
          HCamPar camParamRect2,
          double grayConstancy,
          double gradientConstancy,
          double smoothness,
          double initialGuess,
          string calculateScore,
          string MGParamName,
          string MGParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(348);
            this.Store(proc, 2);
            HalconAPI.Store(proc, 1, (HObjectBase)imageRect1);
            HalconAPI.Store(proc, 2, (HObjectBase)imageRect2);
            HalconAPI.Store(proc, 0, (HData)camParamRect1);
            HalconAPI.Store(proc, 1, (HData)camParamRect2);
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
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect1));
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect2));
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
        ///   Instance represents: Relative orientation of the cameras (3D pose).
        /// </summary>
        /// <param name="covRelPose">6x6 covariance matrix of relative pose. Default: []</param>
        /// <param name="camPar1">Parameters of the 1. camera.</param>
        /// <param name="camPar2">Parameters of the 2. camera.</param>
        /// <param name="covFMat">9x9 covariance matrix of the fundamental matrix.</param>
        /// <returns>Computed fundamental matrix.</returns>
        public HHomMat2D RelPoseToFundamentalMatrix(
          HTuple covRelPose,
          HCamPar camPar1,
          HCamPar camPar2,
          out HTuple covFMat)
        {
            IntPtr proc = HalconAPI.PreCall(353);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, covRelPose);
            HalconAPI.Store(proc, 2, (HData)camPar1);
            HalconAPI.Store(proc, 3, (HData)camPar2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(covRelPose);
            HalconAPI.UnpinTuple((HTuple)((HData)camPar1));
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
        ///   Modified instance represents: Computed relative orientation of the cameras (3D pose).
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
        /// <param name="camPar1">Camera parameters of the 1st camera.</param>
        /// <param name="camPar2">Camera parameters of the 2nd camera.</param>
        /// <param name="method">Algorithm for the computation of the relative pose and for special pose types. Default: "normalized_dlt"</param>
        /// <param name="error">Root-Mean-Square of the epipolar distance error.</param>
        /// <param name="x">X coordinates of the reconstructed 3D points.</param>
        /// <param name="y">Y coordinates of the reconstructed 3D points.</param>
        /// <param name="z">Z coordinates of the reconstructed 3D points.</param>
        /// <param name="covXYZ">Covariance matrices of the  reconstructed 3D points.</param>
        /// <returns>6x6 covariance matrix of the relative camera orientation.</returns>
        public HTuple VectorToRelPose(
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
          HCamPar camPar1,
          HCamPar camPar2,
          string method,
          out HTuple error,
          out HTuple x,
          out HTuple y,
          out HTuple z,
          out HTuple covXYZ)
        {
            IntPtr proc = HalconAPI.PreCall(355);
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
            HalconAPI.Store(proc, 10, (HData)camPar1);
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
            HalconAPI.UnpinTuple((HTuple)((HData)camPar1));
            HalconAPI.UnpinTuple((HTuple)((HData)camPar2));
            int err2 = this.Load(proc, 0, err1);
            HTuple tuple;
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out tuple);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out error);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out x);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out y);
            int err7 = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, err6, out z);
            int procResult = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, err7, out covXYZ);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the relative orientation between two cameras given image point correspondences and known camera parameters and reconstruct 3D space points.
        ///   Modified instance represents: Computed relative orientation of the cameras (3D pose).
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
        /// <param name="camPar1">Camera parameters of the 1st camera.</param>
        /// <param name="camPar2">Camera parameters of the 2nd camera.</param>
        /// <param name="method">Algorithm for the computation of the relative pose and for special pose types. Default: "normalized_dlt"</param>
        /// <param name="error">Root-Mean-Square of the epipolar distance error.</param>
        /// <param name="x">X coordinates of the reconstructed 3D points.</param>
        /// <param name="y">Y coordinates of the reconstructed 3D points.</param>
        /// <param name="z">Z coordinates of the reconstructed 3D points.</param>
        /// <param name="covXYZ">Covariance matrices of the  reconstructed 3D points.</param>
        /// <returns>6x6 covariance matrix of the relative camera orientation.</returns>
        public HTuple VectorToRelPose(
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
          HCamPar camPar1,
          HCamPar camPar2,
          string method,
          out double error,
          out HTuple x,
          out HTuple y,
          out HTuple z,
          out HTuple covXYZ)
        {
            IntPtr proc = HalconAPI.PreCall(355);
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
            HalconAPI.Store(proc, 10, (HData)camPar1);
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
            HalconAPI.UnpinTuple((HTuple)((HData)camPar1));
            HalconAPI.UnpinTuple((HTuple)((HData)camPar2));
            int err2 = this.Load(proc, 0, err1);
            HTuple tuple;
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out tuple);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out error);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out x);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out y);
            int err7 = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, err6, out z);
            int procResult = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, err7, out covXYZ);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the relative orientation between two cameras by automatically finding correspondences between image points.
        ///   Modified instance represents: Computed relative orientation of the cameras (3D pose).
        /// </summary>
        /// <param name="image1">Input image 1.</param>
        /// <param name="image2">Input image 2.</param>
        /// <param name="rows1">Row coordinates of characteristic points in image 1.</param>
        /// <param name="cols1">Column coordinates of characteristic points in image 1.</param>
        /// <param name="rows2">Row coordinates of characteristic points in image 2.</param>
        /// <param name="cols2">Column coordinates of characteristic points in image 2.</param>
        /// <param name="camPar1">Parameters of the 1st camera.</param>
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
        /// <param name="error">Root-Mean-Square of the epipolar distance error.</param>
        /// <param name="points1">Indices of matched input points in image 1.</param>
        /// <param name="points2">Indices of matched input points in image 2.</param>
        /// <returns>6x6 covariance matrix of the relative orientation.</returns>
        public HTuple MatchRelPoseRansac(
          HImage image1,
          HImage image2,
          HTuple rows1,
          HTuple cols1,
          HTuple rows2,
          HTuple cols2,
          HCamPar camPar1,
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
          out HTuple error,
          out HTuple points1,
          out HTuple points2)
        {
            IntPtr proc = HalconAPI.PreCall(359);
            HalconAPI.Store(proc, 1, (HObjectBase)image1);
            HalconAPI.Store(proc, 2, (HObjectBase)image2);
            HalconAPI.Store(proc, 0, rows1);
            HalconAPI.Store(proc, 1, cols1);
            HalconAPI.Store(proc, 2, rows2);
            HalconAPI.Store(proc, 3, cols2);
            HalconAPI.Store(proc, 4, (HData)camPar1);
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
            HalconAPI.UnpinTuple(rows1);
            HalconAPI.UnpinTuple(cols1);
            HalconAPI.UnpinTuple(rows2);
            HalconAPI.UnpinTuple(cols2);
            HalconAPI.UnpinTuple((HTuple)((HData)camPar1));
            HalconAPI.UnpinTuple((HTuple)((HData)camPar2));
            HalconAPI.UnpinTuple(rotation);
            HalconAPI.UnpinTuple(matchThreshold);
            HalconAPI.UnpinTuple(distanceThreshold);
            int err2 = this.Load(proc, 0, err1);
            HTuple tuple;
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out tuple);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out error);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, err4, out points1);
            int procResult = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, err5, out points2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image1);
            GC.KeepAlive((object)image2);
            return tuple;
        }

        /// <summary>
        ///   Compute the relative orientation between two cameras by automatically finding correspondences between image points.
        ///   Modified instance represents: Computed relative orientation of the cameras (3D pose).
        /// </summary>
        /// <param name="image1">Input image 1.</param>
        /// <param name="image2">Input image 2.</param>
        /// <param name="rows1">Row coordinates of characteristic points in image 1.</param>
        /// <param name="cols1">Column coordinates of characteristic points in image 1.</param>
        /// <param name="rows2">Row coordinates of characteristic points in image 2.</param>
        /// <param name="cols2">Column coordinates of characteristic points in image 2.</param>
        /// <param name="camPar1">Parameters of the 1st camera.</param>
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
        /// <param name="error">Root-Mean-Square of the epipolar distance error.</param>
        /// <param name="points1">Indices of matched input points in image 1.</param>
        /// <param name="points2">Indices of matched input points in image 2.</param>
        /// <returns>6x6 covariance matrix of the relative orientation.</returns>
        public HTuple MatchRelPoseRansac(
          HImage image1,
          HImage image2,
          HTuple rows1,
          HTuple cols1,
          HTuple rows2,
          HTuple cols2,
          HCamPar camPar1,
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
          out double error,
          out HTuple points1,
          out HTuple points2)
        {
            IntPtr proc = HalconAPI.PreCall(359);
            HalconAPI.Store(proc, 1, (HObjectBase)image1);
            HalconAPI.Store(proc, 2, (HObjectBase)image2);
            HalconAPI.Store(proc, 0, rows1);
            HalconAPI.Store(proc, 1, cols1);
            HalconAPI.Store(proc, 2, rows2);
            HalconAPI.Store(proc, 3, cols2);
            HalconAPI.Store(proc, 4, (HData)camPar1);
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
            HalconAPI.UnpinTuple(rows1);
            HalconAPI.UnpinTuple(cols1);
            HalconAPI.UnpinTuple(rows2);
            HalconAPI.UnpinTuple(cols2);
            HalconAPI.UnpinTuple((HTuple)((HData)camPar1));
            HalconAPI.UnpinTuple((HTuple)((HData)camPar2));
            int err2 = this.Load(proc, 0, err1);
            HTuple tuple;
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out tuple);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out error);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, err4, out points1);
            int procResult = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, err5, out points2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image1);
            GC.KeepAlive((object)image2);
            return tuple;
        }

        /// <summary>
        ///   Compute the distance values for a rectified stereo image pair using correlation techniques.
        ///   Instance represents: Point transformation from the rectified camera 2 to the rectified camera 1.
        /// </summary>
        /// <param name="imageRect1">Rectified image of camera 1.</param>
        /// <param name="imageRect2">Rectified image of camera 2.</param>
        /// <param name="score">Evaluation of a distance value.</param>
        /// <param name="camParamRect1">Internal camera parameters of the rectified camera 1.</param>
        /// <param name="camParamRect2">Internal camera parameters of the rectified camera 2.</param>
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
          HCamPar camParamRect1,
          HCamPar camParamRect2,
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
            this.Store(proc, 2);
            HalconAPI.Store(proc, 1, (HObjectBase)imageRect1);
            HalconAPI.Store(proc, 2, (HObjectBase)imageRect2);
            HalconAPI.Store(proc, 0, (HData)camParamRect1);
            HalconAPI.Store(proc, 1, (HData)camParamRect2);
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
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect1));
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect2));
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
        ///   Instance represents: Point transformation from the rectified camera 2 to the rectified camera 1.
        /// </summary>
        /// <param name="imageRect1">Rectified image of camera 1.</param>
        /// <param name="imageRect2">Rectified image of camera 2.</param>
        /// <param name="score">Evaluation of a distance value.</param>
        /// <param name="camParamRect1">Internal camera parameters of the rectified camera 1.</param>
        /// <param name="camParamRect2">Internal camera parameters of the rectified camera 2.</param>
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
          HCamPar camParamRect1,
          HCamPar camParamRect2,
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
            this.Store(proc, 2);
            HalconAPI.Store(proc, 1, (HObjectBase)imageRect1);
            HalconAPI.Store(proc, 2, (HObjectBase)imageRect2);
            HalconAPI.Store(proc, 0, (HData)camParamRect1);
            HalconAPI.Store(proc, 1, (HData)camParamRect2);
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
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect1));
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect2));
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
        ///   Instance represents: Point transformation from camera 2 to camera 1.
        /// </summary>
        /// <param name="camParam1">Internal parameters of the projective camera 1.</param>
        /// <param name="camParam2">Internal parameters of the projective camera 2.</param>
        /// <param name="row1">Row coordinate of a point in image 1.</param>
        /// <param name="col1">Column coordinate of a point in image 1.</param>
        /// <param name="row2">Row coordinate of the corresponding point in image 2.</param>
        /// <param name="col2">Column coordinate of the corresponding point in image 2.</param>
        /// <param name="x">X coordinate of the 3D point.</param>
        /// <param name="y">Y coordinate of the 3D point.</param>
        /// <param name="z">Z coordinate of the 3D point.</param>
        /// <param name="dist">Distance of the 3D point to the lines of sight.</param>
        public void IntersectLinesOfSight(
          HCamPar camParam1,
          HCamPar camParam2,
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
            this.Store(proc, 2);
            HalconAPI.Store(proc, 0, (HData)camParam1);
            HalconAPI.Store(proc, 1, (HData)camParam2);
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
            HalconAPI.UnpinTuple((HTuple)((HData)camParam1));
            HalconAPI.UnpinTuple((HTuple)((HData)camParam2));
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
        ///   Instance represents: Point transformation from camera 2 to camera 1.
        /// </summary>
        /// <param name="camParam1">Internal parameters of the projective camera 1.</param>
        /// <param name="camParam2">Internal parameters of the projective camera 2.</param>
        /// <param name="row1">Row coordinate of a point in image 1.</param>
        /// <param name="col1">Column coordinate of a point in image 1.</param>
        /// <param name="row2">Row coordinate of the corresponding point in image 2.</param>
        /// <param name="col2">Column coordinate of the corresponding point in image 2.</param>
        /// <param name="x">X coordinate of the 3D point.</param>
        /// <param name="y">Y coordinate of the 3D point.</param>
        /// <param name="z">Z coordinate of the 3D point.</param>
        /// <param name="dist">Distance of the 3D point to the lines of sight.</param>
        public void IntersectLinesOfSight(
          HCamPar camParam1,
          HCamPar camParam2,
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
            this.Store(proc, 2);
            HalconAPI.Store(proc, 0, (HData)camParam1);
            HalconAPI.Store(proc, 1, (HData)camParam2);
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
            HalconAPI.UnpinTuple((HTuple)((HData)camParam1));
            HalconAPI.UnpinTuple((HTuple)((HData)camParam2));
            int err2 = HalconAPI.LoadD(proc, 0, err1, out x);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out y);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out z);
            int procResult = HalconAPI.LoadD(proc, 3, err4, out dist);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Transform a disparity image into 3D points in a rectified stereo system.
        ///   Instance represents: Pose of the rectified camera 2 in relation to the rectified camera 1.
        /// </summary>
        /// <param name="disparity">Disparity image.</param>
        /// <param name="y">Y coordinates of the points in the rectified camera system 1.</param>
        /// <param name="z">Z coordinates of the points in the rectified camera system 1.</param>
        /// <param name="camParamRect1">Internal camera parameters of the rectified camera 1.</param>
        /// <param name="camParamRect2">Internal camera parameters of the rectified camera 2.</param>
        /// <returns>X coordinates of the points in the rectified camera system 1.</returns>
        public HImage DisparityImageToXyz(
          HImage disparity,
          out HImage y,
          out HImage z,
          HCamPar camParamRect1,
          HCamPar camParamRect2)
        {
            IntPtr proc = HalconAPI.PreCall(365);
            this.Store(proc, 2);
            HalconAPI.Store(proc, 1, (HObjectBase)disparity);
            HalconAPI.Store(proc, 0, (HData)camParamRect1);
            HalconAPI.Store(proc, 1, (HData)camParamRect2);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect1));
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect2));
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
        ///   Instance represents: Pose of the rectified camera 2 in relation to the rectified camera 1.
        /// </summary>
        /// <param name="camParamRect1">Rectified internal camera parameters of camera 1.</param>
        /// <param name="camParamRect2">Rectified internal camera parameters of camera 2.</param>
        /// <param name="row1">Row coordinate of a point in the rectified image 1.</param>
        /// <param name="col1">Column coordinate of a point in the rectified image 1.</param>
        /// <param name="disparity">Disparity of the images of the world point.</param>
        /// <param name="x">X coordinate of the 3D point.</param>
        /// <param name="y">Y coordinate of the 3D point.</param>
        /// <param name="z">Z coordinate of the 3D point.</param>
        public void DisparityToPoint3d(
          HCamPar camParamRect1,
          HCamPar camParamRect2,
          HTuple row1,
          HTuple col1,
          HTuple disparity,
          out HTuple x,
          out HTuple y,
          out HTuple z)
        {
            IntPtr proc = HalconAPI.PreCall(366);
            this.Store(proc, 2);
            HalconAPI.Store(proc, 0, (HData)camParamRect1);
            HalconAPI.Store(proc, 1, (HData)camParamRect2);
            HalconAPI.Store(proc, 3, row1);
            HalconAPI.Store(proc, 4, col1);
            HalconAPI.Store(proc, 5, disparity);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect1));
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect2));
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
        ///   Instance represents: Pose of the rectified camera 2 in relation to the rectified camera 1.
        /// </summary>
        /// <param name="camParamRect1">Rectified internal camera parameters of camera 1.</param>
        /// <param name="camParamRect2">Rectified internal camera parameters of camera 2.</param>
        /// <param name="row1">Row coordinate of a point in the rectified image 1.</param>
        /// <param name="col1">Column coordinate of a point in the rectified image 1.</param>
        /// <param name="disparity">Disparity of the images of the world point.</param>
        /// <param name="x">X coordinate of the 3D point.</param>
        /// <param name="y">Y coordinate of the 3D point.</param>
        /// <param name="z">Z coordinate of the 3D point.</param>
        public void DisparityToPoint3d(
          HCamPar camParamRect1,
          HCamPar camParamRect2,
          double row1,
          double col1,
          double disparity,
          out double x,
          out double y,
          out double z)
        {
            IntPtr proc = HalconAPI.PreCall(366);
            this.Store(proc, 2);
            HalconAPI.Store(proc, 0, (HData)camParamRect1);
            HalconAPI.Store(proc, 1, (HData)camParamRect2);
            HalconAPI.StoreD(proc, 3, row1);
            HalconAPI.StoreD(proc, 4, col1);
            HalconAPI.StoreD(proc, 5, disparity);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect1));
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect2));
            int err2 = HalconAPI.LoadD(proc, 0, err1, out x);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out y);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out z);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Transform a disparity value into a distance value in a rectified binocular stereo system.
        ///   Instance represents: Point transformation from the rectified camera 2 to the rectified camera 1.
        /// </summary>
        /// <param name="camParamRect1">Rectified internal camera parameters of camera 1.</param>
        /// <param name="camParamRect2">Rectified internal camera parameters of camera 2.</param>
        /// <param name="disparity">Disparity between the images of the world point.</param>
        /// <returns>Distance of a world point to the rectified camera system.</returns>
        public HTuple DisparityToDistance(
          HCamPar camParamRect1,
          HCamPar camParamRect2,
          HTuple disparity)
        {
            IntPtr proc = HalconAPI.PreCall(367);
            this.Store(proc, 2);
            HalconAPI.Store(proc, 0, (HData)camParamRect1);
            HalconAPI.Store(proc, 1, (HData)camParamRect2);
            HalconAPI.Store(proc, 3, disparity);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect1));
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect2));
            HalconAPI.UnpinTuple(disparity);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Transform a disparity value into a distance value in a rectified binocular stereo system.
        ///   Instance represents: Point transformation from the rectified camera 2 to the rectified camera 1.
        /// </summary>
        /// <param name="camParamRect1">Rectified internal camera parameters of camera 1.</param>
        /// <param name="camParamRect2">Rectified internal camera parameters of camera 2.</param>
        /// <param name="disparity">Disparity between the images of the world point.</param>
        /// <returns>Distance of a world point to the rectified camera system.</returns>
        public double DisparityToDistance(
          HCamPar camParamRect1,
          HCamPar camParamRect2,
          double disparity)
        {
            IntPtr proc = HalconAPI.PreCall(367);
            this.Store(proc, 2);
            HalconAPI.Store(proc, 0, (HData)camParamRect1);
            HalconAPI.Store(proc, 1, (HData)camParamRect2);
            HalconAPI.StoreD(proc, 3, disparity);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect1));
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect2));
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Transfrom a distance value into a disparity in a rectified stereo system.
        ///   Instance represents: Point transformation from the rectified camera 2 to the rectified camera 1.
        /// </summary>
        /// <param name="camParamRect1">Rectified internal camera parameters of camera 1.</param>
        /// <param name="camParamRect2">Rectified internal camera parameters of camera 2.</param>
        /// <param name="distance">Distance of a world point to camera 1.</param>
        /// <returns>Disparity between the images of the point.</returns>
        public HTuple DistanceToDisparity(
          HCamPar camParamRect1,
          HCamPar camParamRect2,
          HTuple distance)
        {
            IntPtr proc = HalconAPI.PreCall(368);
            this.Store(proc, 2);
            HalconAPI.Store(proc, 0, (HData)camParamRect1);
            HalconAPI.Store(proc, 1, (HData)camParamRect2);
            HalconAPI.Store(proc, 3, distance);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect1));
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect2));
            HalconAPI.UnpinTuple(distance);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Transfrom a distance value into a disparity in a rectified stereo system.
        ///   Instance represents: Point transformation from the rectified camera 2 to the rectified camera 1.
        /// </summary>
        /// <param name="camParamRect1">Rectified internal camera parameters of camera 1.</param>
        /// <param name="camParamRect2">Rectified internal camera parameters of camera 2.</param>
        /// <param name="distance">Distance of a world point to camera 1.</param>
        /// <returns>Disparity between the images of the point.</returns>
        public double DistanceToDisparity(
          HCamPar camParamRect1,
          HCamPar camParamRect2,
          double distance)
        {
            IntPtr proc = HalconAPI.PreCall(368);
            this.Store(proc, 2);
            HalconAPI.Store(proc, 0, (HData)camParamRect1);
            HalconAPI.Store(proc, 1, (HData)camParamRect2);
            HalconAPI.StoreD(proc, 3, distance);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect1));
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect2));
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Generate transformation maps that describe the mapping of the images of a binocular camera pair to a common rectified image plane.
        ///   Instance represents: Point transformation from camera 2 to camera 1.
        /// </summary>
        /// <param name="map2">Image containing the mapping data of camera 2.</param>
        /// <param name="camParam1">Internal parameters of camera 1.</param>
        /// <param name="camParam2">Internal parameters of camera 2.</param>
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
          HCamPar camParam1,
          HCamPar camParam2,
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
            this.Store(proc, 2);
            HalconAPI.Store(proc, 0, (HData)camParam1);
            HalconAPI.Store(proc, 1, (HData)camParam2);
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
            HalconAPI.UnpinTuple((HTuple)((HData)camParam1));
            HalconAPI.UnpinTuple((HTuple)((HData)camParam2));
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

        /// <summary>Determine all camera parameters of a binocular stereo system.</summary>
        /// <param name="NX">Ordered Tuple with all X-coordinates of the calibration marks (in meters).</param>
        /// <param name="NY">Ordered Tuple with all Y-coordinates of the calibration marks (in meters).</param>
        /// <param name="NZ">Ordered Tuple with all Z-coordinates of the calibration marks (in meters).</param>
        /// <param name="NRow1">Ordered Tuple with all row-coordinates of the extracted calibration marks of camera 1 (in pixels).</param>
        /// <param name="NCol1">Ordered Tuple with all column-coordinates of the extracted calibration marks of camera 1 (in pixels).</param>
        /// <param name="NRow2">Ordered Tuple with all row-coordinates of the extracted calibration marks of camera 2 (in pixels).</param>
        /// <param name="NCol2">Ordered Tuple with all column-coordinates of the extracted calibration marks of camera 2 (in pixels).</param>
        /// <param name="startCamParam1">Initial values for the internal parameters of camera 1.</param>
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
        public static HCamPar BinocularCalibration(
          HTuple NX,
          HTuple NY,
          HTuple NZ,
          HTuple NRow1,
          HTuple NCol1,
          HTuple NRow2,
          HTuple NCol2,
          HCamPar startCamParam1,
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
            HalconAPI.Store(proc, 0, NX);
            HalconAPI.Store(proc, 1, NY);
            HalconAPI.Store(proc, 2, NZ);
            HalconAPI.Store(proc, 3, NRow1);
            HalconAPI.Store(proc, 4, NCol1);
            HalconAPI.Store(proc, 5, NRow2);
            HalconAPI.Store(proc, 6, NCol2);
            HalconAPI.Store(proc, 7, (HData)startCamParam1);
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
            HalconAPI.UnpinTuple(NX);
            HalconAPI.UnpinTuple(NY);
            HalconAPI.UnpinTuple(NZ);
            HalconAPI.UnpinTuple(NRow1);
            HalconAPI.UnpinTuple(NCol1);
            HalconAPI.UnpinTuple(NRow2);
            HalconAPI.UnpinTuple(NCol2);
            HalconAPI.UnpinTuple((HTuple)((HData)startCamParam1));
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
            return hcamPar;
        }

        /// <summary>
        ///   Determine all camera parameters of a binocular stereo system.
        ///   Instance represents: Ordered tuple with all initial values for the poses of the calibration model in relation to camera 1.
        /// </summary>
        /// <param name="NX">Ordered Tuple with all X-coordinates of the calibration marks (in meters).</param>
        /// <param name="NY">Ordered Tuple with all Y-coordinates of the calibration marks (in meters).</param>
        /// <param name="NZ">Ordered Tuple with all Z-coordinates of the calibration marks (in meters).</param>
        /// <param name="NRow1">Ordered Tuple with all row-coordinates of the extracted calibration marks of camera 1 (in pixels).</param>
        /// <param name="NCol1">Ordered Tuple with all column-coordinates of the extracted calibration marks of camera 1 (in pixels).</param>
        /// <param name="NRow2">Ordered Tuple with all row-coordinates of the extracted calibration marks of camera 2 (in pixels).</param>
        /// <param name="NCol2">Ordered Tuple with all column-coordinates of the extracted calibration marks of camera 2 (in pixels).</param>
        /// <param name="startCamParam1">Initial values for the internal parameters of camera 1.</param>
        /// <param name="startCamParam2">Initial values for the internal parameters of camera 2.</param>
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
          HCamPar startCamParam1,
          HCamPar startCamParam2,
          HPose NStartPose2,
          HTuple estimateParams,
          out HCamPar camParam2,
          out HPose NFinalPose1,
          out HPose NFinalPose2,
          out HPose relPose,
          out double errors)
        {
            IntPtr proc = HalconAPI.PreCall(370);
            this.Store(proc, 9);
            HalconAPI.Store(proc, 0, NX);
            HalconAPI.Store(proc, 1, NY);
            HalconAPI.Store(proc, 2, NZ);
            HalconAPI.Store(proc, 3, NRow1);
            HalconAPI.Store(proc, 4, NCol1);
            HalconAPI.Store(proc, 5, NRow2);
            HalconAPI.Store(proc, 6, NCol2);
            HalconAPI.Store(proc, 7, (HData)startCamParam1);
            HalconAPI.Store(proc, 8, (HData)startCamParam2);
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
            HalconAPI.UnpinTuple((HTuple)((HData)startCamParam1));
            HalconAPI.UnpinTuple((HTuple)((HData)startCamParam2));
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

        /// <summary>Find the best matches of a calibrated descriptor model in an image and return their 3D pose.</summary>
        /// <param name="image">Input image where the model should be found.</param>
        /// <param name="modelID">The handle to the descriptor model.</param>
        /// <param name="detectorParamName">The detector's parameter names. Default: []</param>
        /// <param name="detectorParamValue">Values of the detector's parameters. Default: []</param>
        /// <param name="descriptorParamName">The descriptor's parameter names. Default: []</param>
        /// <param name="descriptorParamValue">Values of the descriptor's parameters. Default: []</param>
        /// <param name="minScore">Minimum score of the instances of the models to be found. Default: 0.2</param>
        /// <param name="numMatches">Maximal number of found instances. Default: 1</param>
        /// <param name="camParam">Camera parameter (inner orientation) obtained from camera calibration.</param>
        /// <param name="scoreType">Score type to be evaluated in Score. Default: "num_points"</param>
        /// <param name="pose">3D pose of the object.</param>
        /// <returns>Score of the found instances according to the ScoreType input.</returns>
        public static HTuple FindCalibDescriptorModel(
          HImage image,
          HDescriptorModel modelID,
          HTuple detectorParamName,
          HTuple detectorParamValue,
          HTuple descriptorParamName,
          HTuple descriptorParamValue,
          HTuple minScore,
          int numMatches,
          HCamPar camParam,
          HTuple scoreType,
          out HPose[] pose)
        {
            IntPtr proc = HalconAPI.PreCall(948);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)modelID);
            HalconAPI.Store(proc, 1, detectorParamName);
            HalconAPI.Store(proc, 2, detectorParamValue);
            HalconAPI.Store(proc, 3, descriptorParamName);
            HalconAPI.Store(proc, 4, descriptorParamValue);
            HalconAPI.Store(proc, 5, minScore);
            HalconAPI.StoreI(proc, 6, numMatches);
            HalconAPI.Store(proc, 7, (HData)camParam);
            HalconAPI.Store(proc, 8, scoreType);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(detectorParamName);
            HalconAPI.UnpinTuple(detectorParamValue);
            HalconAPI.UnpinTuple(descriptorParamName);
            HalconAPI.UnpinTuple(descriptorParamValue);
            HalconAPI.UnpinTuple(minScore);
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
            HalconAPI.UnpinTuple(scoreType);
            HTuple tuple1;
            int err2 = HTuple.LoadNew(proc, 1, err1, out tuple1);
            HTuple tuple2;
            int procResult = HTuple.LoadNew(proc, 0, err2, out tuple2);
            HalconAPI.PostCall(proc, procResult);
            pose = HPose.SplitArray(tuple2);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)modelID);
            return tuple1;
        }

        /// <summary>
        ///   Find the best matches of a calibrated descriptor model in an image and return their 3D pose.
        ///   Modified instance represents: 3D pose of the object.
        /// </summary>
        /// <param name="image">Input image where the model should be found.</param>
        /// <param name="modelID">The handle to the descriptor model.</param>
        /// <param name="detectorParamName">The detector's parameter names. Default: []</param>
        /// <param name="detectorParamValue">Values of the detector's parameters. Default: []</param>
        /// <param name="descriptorParamName">The descriptor's parameter names. Default: []</param>
        /// <param name="descriptorParamValue">Values of the descriptor's parameters. Default: []</param>
        /// <param name="minScore">Minimum score of the instances of the models to be found. Default: 0.2</param>
        /// <param name="numMatches">Maximal number of found instances. Default: 1</param>
        /// <param name="camParam">Camera parameter (inner orientation) obtained from camera calibration.</param>
        /// <param name="scoreType">Score type to be evaluated in Score. Default: "num_points"</param>
        /// <returns>Score of the found instances according to the ScoreType input.</returns>
        public double FindCalibDescriptorModel(
          HImage image,
          HDescriptorModel modelID,
          HTuple detectorParamName,
          HTuple detectorParamValue,
          HTuple descriptorParamName,
          HTuple descriptorParamValue,
          double minScore,
          int numMatches,
          HCamPar camParam,
          string scoreType)
        {
            IntPtr proc = HalconAPI.PreCall(948);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)modelID);
            HalconAPI.Store(proc, 1, detectorParamName);
            HalconAPI.Store(proc, 2, detectorParamValue);
            HalconAPI.Store(proc, 3, descriptorParamName);
            HalconAPI.Store(proc, 4, descriptorParamValue);
            HalconAPI.StoreD(proc, 5, minScore);
            HalconAPI.StoreI(proc, 6, numMatches);
            HalconAPI.Store(proc, 7, (HData)camParam);
            HalconAPI.StoreS(proc, 8, scoreType);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(detectorParamName);
            HalconAPI.UnpinTuple(detectorParamValue);
            HalconAPI.UnpinTuple(descriptorParamName);
            HalconAPI.UnpinTuple(descriptorParamValue);
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
            int err2 = this.Load(proc, 0, err1);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 1, err2, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)modelID);
            return doubleValue;
        }

        /// <summary>
        ///   Create a descriptor model for calibrated perspective matching.
        ///   Instance represents: The reference pose of the object in the reference image.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
        /// <param name="camParam">The parameters of the internal orientation of the camera.</param>
        /// <param name="detectorType">The type of the detector. Default: "lepetit"</param>
        /// <param name="detectorParamName">The detector's parameter names. Default: []</param>
        /// <param name="detectorParamValue">Values of the detector's parameters. Default: []</param>
        /// <param name="descriptorParamName">The descriptor's parameter names. Default: []</param>
        /// <param name="descriptorParamValue">Values of the descriptor's parameters. Default: []</param>
        /// <param name="seed">The seed for the random number generator. Default: 42</param>
        /// <returns>The handle to the descriptor model.</returns>
        public HDescriptorModel CreateCalibDescriptorModel(
          HImage template,
          HCamPar camParam,
          string detectorType,
          HTuple detectorParamName,
          HTuple detectorParamValue,
          HTuple descriptorParamName,
          HTuple descriptorParamValue,
          int seed)
        {
            IntPtr proc = HalconAPI.PreCall(952);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
            HalconAPI.Store(proc, 0, (HData)camParam);
            HalconAPI.StoreS(proc, 2, detectorType);
            HalconAPI.Store(proc, 3, detectorParamName);
            HalconAPI.Store(proc, 4, detectorParamValue);
            HalconAPI.Store(proc, 5, descriptorParamName);
            HalconAPI.Store(proc, 6, descriptorParamValue);
            HalconAPI.StoreI(proc, 7, seed);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
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
        ///   Instance represents: The reference pose of the object.
        /// </summary>
        /// <param name="contours">Input contours that will be used to create the model.</param>
        /// <param name="camParam">The parameters of the internal orientation of the camera.</param>
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
          HCamPar camParam,
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
            this.Store(proc, 1);
            HalconAPI.Store(proc, 1, (HObjectBase)contours);
            HalconAPI.Store(proc, 0, (HData)camParam);
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
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
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
        ///   Instance represents: The reference pose of the object.
        /// </summary>
        /// <param name="contours">Input contours that will be used to create the model.</param>
        /// <param name="camParam">The parameters of the internal orientation of the camera.</param>
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
          HCamPar camParam,
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
            this.Store(proc, 1);
            HalconAPI.Store(proc, 1, (HObjectBase)contours);
            HalconAPI.Store(proc, 0, (HData)camParam);
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
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
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
        ///   Instance represents: The reference pose of the object in the reference image.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
        /// <param name="camParam">The parameters of the internal orientation of the camera.</param>
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
          HCamPar camParam,
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
            this.Store(proc, 1);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
            HalconAPI.Store(proc, 0, (HData)camParam);
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
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
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
        ///   Instance represents: The reference pose of the object in the reference image.
        /// </summary>
        /// <param name="template">Input image whose domain will be used to create the model.</param>
        /// <param name="camParam">The parameters of the internal orientation of the camera.</param>
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
          HCamPar camParam,
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
            this.Store(proc, 1);
            HalconAPI.Store(proc, 1, (HObjectBase)template);
            HalconAPI.Store(proc, 0, (HData)camParam);
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
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
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

        /// <summary>Create a 3D camera pose from camera center and viewing direction.</summary>
        /// <param name="camPosX">X coordinate of the optical center of the camera.</param>
        /// <param name="camPosY">Y coordinate of the optical center of the camera.</param>
        /// <param name="camPosZ">Z coordinate of the optical center of the camera.</param>
        /// <param name="lookAtX">X coordinate of the 3D point to which the camera is directed.</param>
        /// <param name="lookAtY">Y coordinate of the 3D point to which the camera is directed.</param>
        /// <param name="lookAtZ">Z coordinate of the 3D point to which the camera is directed.</param>
        /// <param name="refPlaneNormal">Normal vector of the reference plane (points up). Default: "-y"</param>
        /// <param name="camRoll">Camera roll angle. Default: 0</param>
        /// <returns>3D camera pose.</returns>
        public static HPose[] CreateCamPoseLookAtPoint(
          HTuple camPosX,
          HTuple camPosY,
          HTuple camPosZ,
          HTuple lookAtX,
          HTuple lookAtY,
          HTuple lookAtZ,
          HTuple refPlaneNormal,
          HTuple camRoll)
        {
            IntPtr proc = HalconAPI.PreCall(1045);
            HalconAPI.Store(proc, 0, camPosX);
            HalconAPI.Store(proc, 1, camPosY);
            HalconAPI.Store(proc, 2, camPosZ);
            HalconAPI.Store(proc, 3, lookAtX);
            HalconAPI.Store(proc, 4, lookAtY);
            HalconAPI.Store(proc, 5, lookAtZ);
            HalconAPI.Store(proc, 6, refPlaneNormal);
            HalconAPI.Store(proc, 7, camRoll);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(camPosX);
            HalconAPI.UnpinTuple(camPosY);
            HalconAPI.UnpinTuple(camPosZ);
            HalconAPI.UnpinTuple(lookAtX);
            HalconAPI.UnpinTuple(lookAtY);
            HalconAPI.UnpinTuple(lookAtZ);
            HalconAPI.UnpinTuple(refPlaneNormal);
            HalconAPI.UnpinTuple(camRoll);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return HPose.SplitArray(tuple);
        }

        /// <summary>
        ///   Create a 3D camera pose from camera center and viewing direction.
        ///   Modified instance represents: 3D camera pose.
        /// </summary>
        /// <param name="camPosX">X coordinate of the optical center of the camera.</param>
        /// <param name="camPosY">Y coordinate of the optical center of the camera.</param>
        /// <param name="camPosZ">Z coordinate of the optical center of the camera.</param>
        /// <param name="lookAtX">X coordinate of the 3D point to which the camera is directed.</param>
        /// <param name="lookAtY">Y coordinate of the 3D point to which the camera is directed.</param>
        /// <param name="lookAtZ">Z coordinate of the 3D point to which the camera is directed.</param>
        /// <param name="refPlaneNormal">Normal vector of the reference plane (points up). Default: "-y"</param>
        /// <param name="camRoll">Camera roll angle. Default: 0</param>
        public void CreateCamPoseLookAtPoint(
          double camPosX,
          double camPosY,
          double camPosZ,
          double lookAtX,
          double lookAtY,
          double lookAtZ,
          HTuple refPlaneNormal,
          double camRoll)
        {
            IntPtr proc = HalconAPI.PreCall(1045);
            HalconAPI.StoreD(proc, 0, camPosX);
            HalconAPI.StoreD(proc, 1, camPosY);
            HalconAPI.StoreD(proc, 2, camPosZ);
            HalconAPI.StoreD(proc, 3, lookAtX);
            HalconAPI.StoreD(proc, 4, lookAtY);
            HalconAPI.StoreD(proc, 5, lookAtZ);
            HalconAPI.Store(proc, 6, refPlaneNormal);
            HalconAPI.StoreD(proc, 7, camRoll);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(refPlaneNormal);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Transform a pose that refers to the coordinate system of a 3D object model to a pose that refers to the reference coordinate system of a 3D shape model and vice versa.
        ///   Instance represents: Pose to be transformed in the source system.
        /// </summary>
        /// <param name="shapeModel3DID">Handle of the 3D shape model.</param>
        /// <param name="transformation">Direction of the transformation. Default: "ref_to_model"</param>
        /// <returns>Transformed 3D pose in the target system.</returns>
        public HPose TransPoseShapeModel3d(HShapeModel3D shapeModel3DID, string transformation)
        {
            IntPtr proc = HalconAPI.PreCall(1054);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)shapeModel3DID);
            HalconAPI.StoreS(proc, 2, transformation);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HPose hpose;
            int procResult = HPose.LoadNew(proc, 0, err, out hpose);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)shapeModel3DID);
            return hpose;
        }

        /// <summary>
        ///   Project the edges of a 3D shape model into image coordinates.
        ///   Instance represents: 3D pose of the 3D shape model in the world coordinate system.
        /// </summary>
        /// <param name="shapeModel3DID">Handle of the 3D shape model.</param>
        /// <param name="camParam">Internal camera parameters.</param>
        /// <param name="hiddenSurfaceRemoval">Remove hidden surfaces? Default: "true"</param>
        /// <param name="minFaceAngle">Smallest face angle for which the edge is displayed Default: 0.523599</param>
        /// <returns>Contour representation of the model view.</returns>
        public HXLDCont ProjectShapeModel3d(
          HShapeModel3D shapeModel3DID,
          HCamPar camParam,
          string hiddenSurfaceRemoval,
          HTuple minFaceAngle)
        {
            IntPtr proc = HalconAPI.PreCall(1055);
            this.Store(proc, 2);
            HalconAPI.Store(proc, 0, (HTool)shapeModel3DID);
            HalconAPI.Store(proc, 1, (HData)camParam);
            HalconAPI.StoreS(proc, 3, hiddenSurfaceRemoval);
            HalconAPI.Store(proc, 4, minFaceAngle);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
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
        ///   Instance represents: 3D pose of the 3D shape model in the world coordinate system.
        /// </summary>
        /// <param name="shapeModel3DID">Handle of the 3D shape model.</param>
        /// <param name="camParam">Internal camera parameters.</param>
        /// <param name="hiddenSurfaceRemoval">Remove hidden surfaces? Default: "true"</param>
        /// <param name="minFaceAngle">Smallest face angle for which the edge is displayed Default: 0.523599</param>
        /// <returns>Contour representation of the model view.</returns>
        public HXLDCont ProjectShapeModel3d(
          HShapeModel3D shapeModel3DID,
          HCamPar camParam,
          string hiddenSurfaceRemoval,
          double minFaceAngle)
        {
            IntPtr proc = HalconAPI.PreCall(1055);
            this.Store(proc, 2);
            HalconAPI.Store(proc, 0, (HTool)shapeModel3DID);
            HalconAPI.Store(proc, 1, (HData)camParam);
            HalconAPI.StoreS(proc, 3, hiddenSurfaceRemoval);
            HalconAPI.StoreD(proc, 4, minFaceAngle);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)shapeModel3DID);
            return hxldCont;
        }

        /// <summary>Remove points from a 3D object model by projecting it to a virtual view and removing all points outside of a given region.</summary>
        /// <param name="region">Region in the image plane.</param>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <param name="camParam">Internal camera parameters.</param>
        /// <param name="pose">3D pose of the world coordinate system in camera coordinates.</param>
        /// <returns>Handle of the reduced 3D object model.</returns>
        public static HObjectModel3D[] ReduceObjectModel3dByView(
          HRegion region,
          HObjectModel3D[] objectModel3D,
          HCamPar camParam,
          HPose[] pose)
        {
            HTuple htuple1 = HTool.ConcatArray((HTool[])objectModel3D);
            HTuple htuple2 = HData.ConcatArray((HData[])pose);
            IntPtr proc = HalconAPI.PreCall(1084);
            HalconAPI.Store(proc, 1, (HObjectBase)region);
            HalconAPI.Store(proc, 0, htuple1);
            HalconAPI.Store(proc, 1, (HData)camParam);
            HalconAPI.Store(proc, 2, htuple2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple1);
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
            HalconAPI.UnpinTuple(htuple2);
            HObjectModel3D[] hobjectModel3DArray;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3DArray);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)region);
            GC.KeepAlive((object)objectModel3D);
            return hobjectModel3DArray;
        }

        /// <summary>
        ///   Remove points from a 3D object model by projecting it to a virtual view and removing all points outside of a given region.
        ///   Instance represents: 3D pose of the world coordinate system in camera coordinates.
        /// </summary>
        /// <param name="region">Region in the image plane.</param>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <param name="camParam">Internal camera parameters.</param>
        /// <returns>Handle of the reduced 3D object model.</returns>
        public HObjectModel3D ReduceObjectModel3dByView(
          HRegion region,
          HObjectModel3D objectModel3D,
          HCamPar camParam)
        {
            IntPtr proc = HalconAPI.PreCall(1084);
            this.Store(proc, 2);
            HalconAPI.Store(proc, 1, (HObjectBase)region);
            HalconAPI.Store(proc, 0, (HTool)objectModel3D);
            HalconAPI.Store(proc, 1, (HData)camParam);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
            HObjectModel3D hobjectModel3D;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)region);
            GC.KeepAlive((object)objectModel3D);
            return hobjectModel3D;
        }

        /// <summary>Render 3D object models to get an image.</summary>
        /// <param name="objectModel3D">Handles of the 3D object models.</param>
        /// <param name="camParam">Camera parameters of the scene.</param>
        /// <param name="pose">3D poses of the objects.</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <returns>Rendered scene.</returns>
        public static HImage RenderObjectModel3d(
          HObjectModel3D[] objectModel3D,
          HCamPar camParam,
          HPose[] pose,
          HTuple genParamName,
          HTuple genParamValue)
        {
            HTuple htuple1 = HTool.ConcatArray((HTool[])objectModel3D);
            HTuple htuple2 = HData.ConcatArray((HData[])pose);
            IntPtr proc = HalconAPI.PreCall(1088);
            HalconAPI.Store(proc, 0, htuple1);
            HalconAPI.Store(proc, 1, (HData)camParam);
            HalconAPI.Store(proc, 2, htuple2);
            HalconAPI.Store(proc, 3, genParamName);
            HalconAPI.Store(proc, 4, genParamValue);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple1);
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
            HalconAPI.UnpinTuple(htuple2);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)objectModel3D);
            return himage;
        }

        /// <summary>
        ///   Render 3D object models to get an image.
        ///   Instance represents: 3D poses of the objects.
        /// </summary>
        /// <param name="objectModel3D">Handles of the 3D object models.</param>
        /// <param name="camParam">Camera parameters of the scene.</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <returns>Rendered scene.</returns>
        public HImage RenderObjectModel3d(
          HObjectModel3D objectModel3D,
          HCamPar camParam,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1088);
            this.Store(proc, 2);
            HalconAPI.Store(proc, 0, (HTool)objectModel3D);
            HalconAPI.Store(proc, 1, (HData)camParam);
            HalconAPI.Store(proc, 3, genParamName);
            HalconAPI.Store(proc, 4, genParamValue);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D);
            return himage;
        }

        /// <summary>Display 3D object models.</summary>
        /// <param name="windowHandle">Window handle.</param>
        /// <param name="objectModel3D">Handles of the 3D object models.</param>
        /// <param name="camParam">Camera parameters of the scene. Default: []</param>
        /// <param name="pose">3D poses of the objects. Default: []</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        public static void DispObjectModel3d(
          HWindow windowHandle,
          HObjectModel3D[] objectModel3D,
          HCamPar camParam,
          HPose[] pose,
          HTuple genParamName,
          HTuple genParamValue)
        {
            HTuple htuple1 = HTool.ConcatArray((HTool[])objectModel3D);
            HTuple htuple2 = HData.ConcatArray((HData[])pose);
            IntPtr proc = HalconAPI.PreCall(1089);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            HalconAPI.Store(proc, 1, htuple1);
            HalconAPI.Store(proc, 2, (HData)camParam);
            HalconAPI.Store(proc, 3, htuple2);
            HalconAPI.Store(proc, 4, genParamName);
            HalconAPI.Store(proc, 5, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple1);
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
            HalconAPI.UnpinTuple(htuple2);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)windowHandle);
            GC.KeepAlive((object)objectModel3D);
        }

        /// <summary>
        ///   Display 3D object models.
        ///   Instance represents: 3D poses of the objects.
        /// </summary>
        /// <param name="windowHandle">Window handle.</param>
        /// <param name="objectModel3D">Handles of the 3D object models.</param>
        /// <param name="camParam">Camera parameters of the scene. Default: []</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        public void DispObjectModel3d(
          HWindow windowHandle,
          HObjectModel3D objectModel3D,
          HCamPar camParam,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1089);
            this.Store(proc, 3);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            HalconAPI.Store(proc, 1, (HTool)objectModel3D);
            HalconAPI.Store(proc, 2, (HData)camParam);
            HalconAPI.Store(proc, 4, genParamName);
            HalconAPI.Store(proc, 5, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)windowHandle);
            GC.KeepAlive((object)objectModel3D);
        }

        /// <summary>
        ///   Project a 3D object model into image coordinates.
        ///   Instance represents: 3D pose of the world coordinate system in camera coordinates.
        /// </summary>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <param name="camParam">Internal camera parameters.</param>
        /// <param name="genParamName">Name of the generic parameter. Default: []</param>
        /// <param name="genParamValue">Value of the generic parameter. Default: []</param>
        /// <returns>Projected model contours.</returns>
        public HXLDCont ProjectObjectModel3d(
          HObjectModel3D objectModel3D,
          HCamPar camParam,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1095);
            this.Store(proc, 2);
            HalconAPI.Store(proc, 0, (HTool)objectModel3D);
            HalconAPI.Store(proc, 1, (HData)camParam);
            HalconAPI.Store(proc, 3, genParamName);
            HalconAPI.Store(proc, 4, genParamValue);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
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
        ///   Instance represents: 3D pose of the world coordinate system in camera coordinates.
        /// </summary>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <param name="camParam">Internal camera parameters.</param>
        /// <param name="genParamName">Name of the generic parameter. Default: []</param>
        /// <param name="genParamValue">Value of the generic parameter. Default: []</param>
        /// <returns>Projected model contours.</returns>
        public HXLDCont ProjectObjectModel3d(
          HObjectModel3D objectModel3D,
          HCamPar camParam,
          string genParamName,
          string genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1095);
            this.Store(proc, 2);
            HalconAPI.Store(proc, 0, (HTool)objectModel3D);
            HalconAPI.Store(proc, 1, (HData)camParam);
            HalconAPI.StoreS(proc, 3, genParamName);
            HalconAPI.StoreS(proc, 4, genParamValue);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D);
            return hxldCont;
        }

        /// <summary>
        ///   Compute the calibrated scene flow between two stereo image pairs.
        ///   Instance represents: Pose of the rectified camera 2 in relation to the rectified camera 1.
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
        /// <param name="camParamRect1">Internal camera parameters of the rectified camera 1.</param>
        /// <param name="camParamRect2">Internal camera parameters of the rectified camera 2.</param>
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
          HCamPar camParamRect1,
          HCamPar camParamRect2)
        {
            IntPtr proc = HalconAPI.PreCall(1481);
            this.Store(proc, 6);
            HalconAPI.Store(proc, 1, (HObjectBase)imageRect1T1);
            HalconAPI.Store(proc, 2, (HObjectBase)imageRect2T1);
            HalconAPI.Store(proc, 3, (HObjectBase)imageRect1T2);
            HalconAPI.Store(proc, 4, (HObjectBase)imageRect2T2);
            HalconAPI.Store(proc, 5, (HObjectBase)disparity);
            HalconAPI.Store(proc, 0, smoothingFlow);
            HalconAPI.Store(proc, 1, smoothingDisparity);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.Store(proc, 4, (HData)camParamRect1);
            HalconAPI.Store(proc, 5, (HData)camParamRect2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(smoothingFlow);
            HalconAPI.UnpinTuple(smoothingDisparity);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect1));
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect2));
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
        ///   Instance represents: Pose of the rectified camera 2 in relation to the rectified camera 1.
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
        /// <param name="camParamRect1">Internal camera parameters of the rectified camera 1.</param>
        /// <param name="camParamRect2">Internal camera parameters of the rectified camera 2.</param>
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
          HCamPar camParamRect1,
          HCamPar camParamRect2)
        {
            IntPtr proc = HalconAPI.PreCall(1481);
            this.Store(proc, 6);
            HalconAPI.Store(proc, 1, (HObjectBase)imageRect1T1);
            HalconAPI.Store(proc, 2, (HObjectBase)imageRect2T1);
            HalconAPI.Store(proc, 3, (HObjectBase)imageRect1T2);
            HalconAPI.Store(proc, 4, (HObjectBase)imageRect2T2);
            HalconAPI.Store(proc, 5, (HObjectBase)disparity);
            HalconAPI.StoreD(proc, 0, smoothingFlow);
            HalconAPI.StoreD(proc, 1, smoothingDisparity);
            HalconAPI.StoreS(proc, 2, genParamName);
            HalconAPI.StoreS(proc, 3, genParamValue);
            HalconAPI.Store(proc, 4, (HData)camParamRect1);
            HalconAPI.Store(proc, 5, (HData)camParamRect2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect1));
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect2));
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
        ///   Modified instance represents: Pose.
        /// </summary>
        /// <param name="worldX">X-Component of world coordinates.</param>
        /// <param name="worldY">Y-Component of world coordinates.</param>
        /// <param name="worldZ">Z-Component of world coordinates.</param>
        /// <param name="imageRow">Row-Component of image coordinates.</param>
        /// <param name="imageColumn">Column-Component of image coordinates.</param>
        /// <param name="cameraParam">The inner camera parameters from camera calibration.</param>
        /// <param name="method">Kind of algorithm Default: "iterative"</param>
        /// <param name="qualityType">Type of pose quality to be returned in Quality. Default: "error"</param>
        /// <returns>Pose quality.</returns>
        public HTuple VectorToPose(
          HTuple worldX,
          HTuple worldY,
          HTuple worldZ,
          HTuple imageRow,
          HTuple imageColumn,
          HCamPar cameraParam,
          string method,
          HTuple qualityType)
        {
            IntPtr proc = HalconAPI.PreCall(1902);
            HalconAPI.Store(proc, 0, worldX);
            HalconAPI.Store(proc, 1, worldY);
            HalconAPI.Store(proc, 2, worldZ);
            HalconAPI.Store(proc, 3, imageRow);
            HalconAPI.Store(proc, 4, imageColumn);
            HalconAPI.Store(proc, 5, (HData)cameraParam);
            HalconAPI.StoreS(proc, 6, method);
            HalconAPI.Store(proc, 7, qualityType);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(worldX);
            HalconAPI.UnpinTuple(worldY);
            HalconAPI.UnpinTuple(worldZ);
            HalconAPI.UnpinTuple(imageRow);
            HalconAPI.UnpinTuple(imageColumn);
            HalconAPI.UnpinTuple((HTuple)((HData)cameraParam));
            HalconAPI.UnpinTuple(qualityType);
            int err2 = this.Load(proc, 0, err1);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 1, err2, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute an absolute pose out of point correspondences between world and image coordinates.
        ///   Modified instance represents: Pose.
        /// </summary>
        /// <param name="worldX">X-Component of world coordinates.</param>
        /// <param name="worldY">Y-Component of world coordinates.</param>
        /// <param name="worldZ">Z-Component of world coordinates.</param>
        /// <param name="imageRow">Row-Component of image coordinates.</param>
        /// <param name="imageColumn">Column-Component of image coordinates.</param>
        /// <param name="cameraParam">The inner camera parameters from camera calibration.</param>
        /// <param name="method">Kind of algorithm Default: "iterative"</param>
        /// <param name="qualityType">Type of pose quality to be returned in Quality. Default: "error"</param>
        /// <returns>Pose quality.</returns>
        public double VectorToPose(
          HTuple worldX,
          HTuple worldY,
          HTuple worldZ,
          HTuple imageRow,
          HTuple imageColumn,
          HCamPar cameraParam,
          string method,
          string qualityType)
        {
            IntPtr proc = HalconAPI.PreCall(1902);
            HalconAPI.Store(proc, 0, worldX);
            HalconAPI.Store(proc, 1, worldY);
            HalconAPI.Store(proc, 2, worldZ);
            HalconAPI.Store(proc, 3, imageRow);
            HalconAPI.Store(proc, 4, imageColumn);
            HalconAPI.Store(proc, 5, (HData)cameraParam);
            HalconAPI.StoreS(proc, 6, method);
            HalconAPI.StoreS(proc, 7, qualityType);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(worldX);
            HalconAPI.UnpinTuple(worldY);
            HalconAPI.UnpinTuple(worldZ);
            HalconAPI.UnpinTuple(imageRow);
            HalconAPI.UnpinTuple(imageColumn);
            HalconAPI.UnpinTuple((HTuple)((HData)cameraParam));
            int err2 = this.Load(proc, 0, err1);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 1, err2, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Generate a projection map that describes the mapping between the image plane and a the plane z=0 of a world coordinate system.
        ///   Instance represents: 3D pose of the world coordinate system in camera coordinates.
        /// </summary>
        /// <param name="cameraParam">Internal camera parameters.</param>
        /// <param name="widthIn">Width of the images to be transformed.</param>
        /// <param name="heightIn">Height of the images to be transformed.</param>
        /// <param name="widthMapped">Width of the resulting mapped images in pixels.</param>
        /// <param name="heightMapped">Height of the resulting mapped images in pixels.</param>
        /// <param name="scale">Scale or unit. Default: "m"</param>
        /// <param name="mapType">Type of the mapping. Default: "bilinear"</param>
        /// <returns>Image containing the mapping data.</returns>
        public HImage GenImageToWorldPlaneMap(
          HCamPar cameraParam,
          int widthIn,
          int heightIn,
          int widthMapped,
          int heightMapped,
          HTuple scale,
          string mapType)
        {
            IntPtr proc = HalconAPI.PreCall(1913);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HData)cameraParam);
            HalconAPI.StoreI(proc, 2, widthIn);
            HalconAPI.StoreI(proc, 3, heightIn);
            HalconAPI.StoreI(proc, 4, widthMapped);
            HalconAPI.StoreI(proc, 5, heightMapped);
            HalconAPI.Store(proc, 6, scale);
            HalconAPI.StoreS(proc, 7, mapType);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)cameraParam));
            HalconAPI.UnpinTuple(scale);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>
        ///   Generate a projection map that describes the mapping between the image plane and a the plane z=0 of a world coordinate system.
        ///   Instance represents: 3D pose of the world coordinate system in camera coordinates.
        /// </summary>
        /// <param name="cameraParam">Internal camera parameters.</param>
        /// <param name="widthIn">Width of the images to be transformed.</param>
        /// <param name="heightIn">Height of the images to be transformed.</param>
        /// <param name="widthMapped">Width of the resulting mapped images in pixels.</param>
        /// <param name="heightMapped">Height of the resulting mapped images in pixels.</param>
        /// <param name="scale">Scale or unit. Default: "m"</param>
        /// <param name="mapType">Type of the mapping. Default: "bilinear"</param>
        /// <returns>Image containing the mapping data.</returns>
        public HImage GenImageToWorldPlaneMap(
          HCamPar cameraParam,
          int widthIn,
          int heightIn,
          int widthMapped,
          int heightMapped,
          string scale,
          string mapType)
        {
            IntPtr proc = HalconAPI.PreCall(1913);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HData)cameraParam);
            HalconAPI.StoreI(proc, 2, widthIn);
            HalconAPI.StoreI(proc, 3, heightIn);
            HalconAPI.StoreI(proc, 4, widthMapped);
            HalconAPI.StoreI(proc, 5, heightMapped);
            HalconAPI.StoreS(proc, 6, scale);
            HalconAPI.StoreS(proc, 7, mapType);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)cameraParam));
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>
        ///   Rectify an image by transforming it into the plane z=0 of a world coordinate system.
        ///   Instance represents: 3D pose of the world coordinate system in camera coordinates.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="cameraParam">Internal camera parameters.</param>
        /// <param name="width">Width of the resulting image in pixels.</param>
        /// <param name="height">Height of the resulting image in pixels.</param>
        /// <param name="scale">Scale or unit Default: "m"</param>
        /// <param name="interpolation">Type of interpolation. Default: "bilinear"</param>
        /// <returns>Transformed image.</returns>
        public HImage ImageToWorldPlane(
          HImage image,
          HCamPar cameraParam,
          int width,
          int height,
          HTuple scale,
          string interpolation)
        {
            IntPtr proc = HalconAPI.PreCall(1914);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HData)cameraParam);
            HalconAPI.StoreI(proc, 2, width);
            HalconAPI.StoreI(proc, 3, height);
            HalconAPI.Store(proc, 4, scale);
            HalconAPI.StoreS(proc, 5, interpolation);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)cameraParam));
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
        ///   Instance represents: 3D pose of the world coordinate system in camera coordinates.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="cameraParam">Internal camera parameters.</param>
        /// <param name="width">Width of the resulting image in pixels.</param>
        /// <param name="height">Height of the resulting image in pixels.</param>
        /// <param name="scale">Scale or unit Default: "m"</param>
        /// <param name="interpolation">Type of interpolation. Default: "bilinear"</param>
        /// <returns>Transformed image.</returns>
        public HImage ImageToWorldPlane(
          HImage image,
          HCamPar cameraParam,
          int width,
          int height,
          string scale,
          string interpolation)
        {
            IntPtr proc = HalconAPI.PreCall(1914);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HData)cameraParam);
            HalconAPI.StoreI(proc, 2, width);
            HalconAPI.StoreI(proc, 3, height);
            HalconAPI.StoreS(proc, 4, scale);
            HalconAPI.StoreS(proc, 5, interpolation);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)cameraParam));
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return himage;
        }

        /// <summary>
        ///   Transform an XLD contour into the plane z=0 of a world coordinate system.
        ///   Instance represents: 3D pose of the world coordinate system in camera coordinates.
        /// </summary>
        /// <param name="contours">Input XLD contours to be transformed in image coordinates.</param>
        /// <param name="cameraParam">Internal camera parameters.</param>
        /// <param name="scale">Scale or dimension Default: "m"</param>
        /// <returns>Transformed XLD contours in world coordinates.</returns>
        public HXLDCont ContourToWorldPlaneXld(
          HXLDCont contours,
          HTuple cameraParam,
          HTuple scale)
        {
            IntPtr proc = HalconAPI.PreCall(1915);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 1, (HObjectBase)contours);
            HalconAPI.Store(proc, 0, cameraParam);
            HalconAPI.Store(proc, 2, scale);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(cameraParam);
            HalconAPI.UnpinTuple(scale);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contours);
            return hxldCont;
        }

        /// <summary>
        ///   Transform an XLD contour into the plane z=0 of a world coordinate system.
        ///   Instance represents: 3D pose of the world coordinate system in camera coordinates.
        /// </summary>
        /// <param name="contours">Input XLD contours to be transformed in image coordinates.</param>
        /// <param name="cameraParam">Internal camera parameters.</param>
        /// <param name="scale">Scale or dimension Default: "m"</param>
        /// <returns>Transformed XLD contours in world coordinates.</returns>
        public HXLDCont ContourToWorldPlaneXld(
          HXLDCont contours,
          HTuple cameraParam,
          string scale)
        {
            IntPtr proc = HalconAPI.PreCall(1915);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 1, (HObjectBase)contours);
            HalconAPI.Store(proc, 0, cameraParam);
            HalconAPI.StoreS(proc, 2, scale);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(cameraParam);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contours);
            return hxldCont;
        }

        /// <summary>
        ///   Translate the origin of a 3D pose.
        ///   Instance represents: original 3D pose.
        /// </summary>
        /// <param name="DX">translation of the origin in x-direction. Default: 0</param>
        /// <param name="DY">translation of the origin in y-direction. Default: 0</param>
        /// <param name="DZ">translation of the origin in z-direction. Default: 0</param>
        /// <returns>new 3D pose after applying the translation.</returns>
        public HPose SetOriginPose(double DX, double DY, double DZ)
        {
            IntPtr proc = HalconAPI.PreCall(1917);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, DX);
            HalconAPI.StoreD(proc, 2, DY);
            HalconAPI.StoreD(proc, 3, DZ);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HPose hpose;
            int procResult = HPose.LoadNew(proc, 0, err, out hpose);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hpose;
        }

        /// <summary>Perform a hand-eye calibration.</summary>
        /// <param name="x">Linear list containing all the x coordinates of the calibration points (in the order of the images).</param>
        /// <param name="y">Linear list containing all the y coordinates of the calibration points (in the order of the images).</param>
        /// <param name="z">Linear list containing all the z coordinates of the calibration points (in the order of the images).</param>
        /// <param name="row">Linear list containing all row coordinates of the calibration points (in the order of the images).</param>
        /// <param name="col">Linear list containing all the column coordinates of the calibration points (in the order of the images).</param>
        /// <param name="numPoints">Number of the calibration points for each image.</param>
        /// <param name="robotPoses">Known 3D pose of the robot for each image (moving camera: robot base in robot tool coordinates; stationary camera: robot tool in robot base coordinates).</param>
        /// <param name="cameraParam">Internal camera parameters.</param>
        /// <param name="method">Method of hand-eye calibration. Default: "nonlinear"</param>
        /// <param name="qualityType">Type of quality assessment. Default: "error_pose"</param>
        /// <param name="calibrationPose">Computed 3D pose of the calibration points in robot base coordinates (moving camera) or in robot tool coordinates (stationary camera), respectively.</param>
        /// <param name="quality">Quality assessment of the result.</param>
        /// <returns>Computed relative camera pose: 3D pose of the robot tool (moving camera) or robot base (stationary camera), respectively, in camera coordinates.</returns>
        public static HPose HandEyeCalibration(
          HTuple x,
          HTuple y,
          HTuple z,
          HTuple row,
          HTuple col,
          HTuple numPoints,
          HPose[] robotPoses,
          HCamPar cameraParam,
          string method,
          HTuple qualityType,
          out HPose calibrationPose,
          out HTuple quality)
        {
            HTuple htuple = HData.ConcatArray((HData[])robotPoses);
            IntPtr proc = HalconAPI.PreCall(1918);
            HalconAPI.Store(proc, 0, x);
            HalconAPI.Store(proc, 1, y);
            HalconAPI.Store(proc, 2, z);
            HalconAPI.Store(proc, 3, row);
            HalconAPI.Store(proc, 4, col);
            HalconAPI.Store(proc, 5, numPoints);
            HalconAPI.Store(proc, 6, htuple);
            HalconAPI.Store(proc, 7, (HData)cameraParam);
            HalconAPI.StoreS(proc, 8, method);
            HalconAPI.Store(proc, 9, qualityType);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(x);
            HalconAPI.UnpinTuple(y);
            HalconAPI.UnpinTuple(z);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(col);
            HalconAPI.UnpinTuple(numPoints);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple((HTuple)((HData)cameraParam));
            HalconAPI.UnpinTuple(qualityType);
            HPose hpose;
            int err2 = HPose.LoadNew(proc, 0, err1, out hpose);
            int err3 = HPose.LoadNew(proc, 1, err2, out calibrationPose);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out quality);
            HalconAPI.PostCall(proc, procResult);
            return hpose;
        }

        /// <summary>Perform a hand-eye calibration.</summary>
        /// <param name="x">Linear list containing all the x coordinates of the calibration points (in the order of the images).</param>
        /// <param name="y">Linear list containing all the y coordinates of the calibration points (in the order of the images).</param>
        /// <param name="z">Linear list containing all the z coordinates of the calibration points (in the order of the images).</param>
        /// <param name="row">Linear list containing all row coordinates of the calibration points (in the order of the images).</param>
        /// <param name="col">Linear list containing all the column coordinates of the calibration points (in the order of the images).</param>
        /// <param name="numPoints">Number of the calibration points for each image.</param>
        /// <param name="robotPoses">Known 3D pose of the robot for each image (moving camera: robot base in robot tool coordinates; stationary camera: robot tool in robot base coordinates).</param>
        /// <param name="cameraParam">Internal camera parameters.</param>
        /// <param name="method">Method of hand-eye calibration. Default: "nonlinear"</param>
        /// <param name="qualityType">Type of quality assessment. Default: "error_pose"</param>
        /// <param name="calibrationPose">Computed 3D pose of the calibration points in robot base coordinates (moving camera) or in robot tool coordinates (stationary camera), respectively.</param>
        /// <param name="quality">Quality assessment of the result.</param>
        /// <returns>Computed relative camera pose: 3D pose of the robot tool (moving camera) or robot base (stationary camera), respectively, in camera coordinates.</returns>
        public static HPose HandEyeCalibration(
          HTuple x,
          HTuple y,
          HTuple z,
          HTuple row,
          HTuple col,
          HTuple numPoints,
          HPose[] robotPoses,
          HCamPar cameraParam,
          string method,
          string qualityType,
          out HPose calibrationPose,
          out double quality)
        {
            HTuple htuple = HData.ConcatArray((HData[])robotPoses);
            IntPtr proc = HalconAPI.PreCall(1918);
            HalconAPI.Store(proc, 0, x);
            HalconAPI.Store(proc, 1, y);
            HalconAPI.Store(proc, 2, z);
            HalconAPI.Store(proc, 3, row);
            HalconAPI.Store(proc, 4, col);
            HalconAPI.Store(proc, 5, numPoints);
            HalconAPI.Store(proc, 6, htuple);
            HalconAPI.Store(proc, 7, (HData)cameraParam);
            HalconAPI.StoreS(proc, 8, method);
            HalconAPI.StoreS(proc, 9, qualityType);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(x);
            HalconAPI.UnpinTuple(y);
            HalconAPI.UnpinTuple(z);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(col);
            HalconAPI.UnpinTuple(numPoints);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple((HTuple)((HData)cameraParam));
            HPose hpose;
            int err2 = HPose.LoadNew(proc, 0, err1, out hpose);
            int err3 = HPose.LoadNew(proc, 1, err2, out calibrationPose);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out quality);
            HalconAPI.PostCall(proc, procResult);
            return hpose;
        }

        /// <summary>
        ///   Get the representation type of a 3D pose.
        ///   Instance represents: 3D pose.
        /// </summary>
        /// <param name="orderOfRotation">Meaning of the rotation values.</param>
        /// <param name="viewOfTransform">View of transformation.</param>
        /// <returns>Order of rotation and translation.</returns>
        public string GetPoseType(out string orderOfRotation, out string viewOfTransform)
        {
            IntPtr proc = HalconAPI.PreCall(1919);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            string stringValue;
            int err2 = HalconAPI.LoadS(proc, 0, err1, out stringValue);
            int err3 = HalconAPI.LoadS(proc, 1, err2, out orderOfRotation);
            int procResult = HalconAPI.LoadS(proc, 2, err3, out viewOfTransform);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return stringValue;
        }

        /// <summary>
        ///   Change the representation type of a 3D pose.
        ///   Instance represents: Original 3D pose.
        /// </summary>
        /// <param name="orderOfTransform">Order of rotation and translation. Default: "Rp+T"</param>
        /// <param name="orderOfRotation">Meaning of the rotation values. Default: "gba"</param>
        /// <param name="viewOfTransform">View of transformation. Default: "point"</param>
        /// <returns>3D transformation.</returns>
        public HPose ConvertPoseType(
          string orderOfTransform,
          string orderOfRotation,
          string viewOfTransform)
        {
            IntPtr proc = HalconAPI.PreCall(1920);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, orderOfTransform);
            HalconAPI.StoreS(proc, 2, orderOfRotation);
            HalconAPI.StoreS(proc, 3, viewOfTransform);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HPose hpose;
            int procResult = HPose.LoadNew(proc, 0, err, out hpose);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hpose;
        }

        /// <summary>
        ///   Create a 3D pose.
        ///   Modified instance represents: 3D pose.
        /// </summary>
        /// <param name="transX">Translation along the x-axis (in [m]). Default: 0.1</param>
        /// <param name="transY">Translation along the y-axis (in [m]). Default: 0.1</param>
        /// <param name="transZ">Translation along the z-axis (in [m]). Default: 0.1</param>
        /// <param name="rotX">Rotation around x-axis or x component of the Rodriguez vector (in [°] or without unit). Default: 90.0</param>
        /// <param name="rotY">Rotation around y-axis or y component of the Rodriguez vector (in [°] or without unit). Default: 90.0</param>
        /// <param name="rotZ">Rotation around z-axis or z component of the Rodriguez vector (in [°] or without unit). Default: 90.0</param>
        /// <param name="orderOfTransform">Order of rotation and translation. Default: "Rp+T"</param>
        /// <param name="orderOfRotation">Meaning of the rotation values. Default: "gba"</param>
        /// <param name="viewOfTransform">View of transformation. Default: "point"</param>
        public void CreatePose(
          double transX,
          double transY,
          double transZ,
          double rotX,
          double rotY,
          double rotZ,
          string orderOfTransform,
          string orderOfRotation,
          string viewOfTransform)
        {
            IntPtr proc = HalconAPI.PreCall(1921);
            HalconAPI.StoreD(proc, 0, transX);
            HalconAPI.StoreD(proc, 1, transY);
            HalconAPI.StoreD(proc, 2, transZ);
            HalconAPI.StoreD(proc, 3, rotX);
            HalconAPI.StoreD(proc, 4, rotY);
            HalconAPI.StoreD(proc, 5, rotZ);
            HalconAPI.StoreS(proc, 6, orderOfTransform);
            HalconAPI.StoreS(proc, 7, orderOfRotation);
            HalconAPI.StoreS(proc, 8, viewOfTransform);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Convert internal camera parameters and a 3D pose into a 3x4 projection matrix.
        ///   Instance represents: 3D pose.
        /// </summary>
        /// <param name="cameraParam">Internal camera parameters.</param>
        /// <returns>3x4 projection matrix.</returns>
        public HHomMat3D CamParPoseToHomMat3d(HCamPar cameraParam)
        {
            IntPtr proc = HalconAPI.PreCall(1933);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HData)cameraParam);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)cameraParam));
            HHomMat3D hhomMat3D;
            int procResult = HHomMat3D.LoadNew(proc, 0, err, out hhomMat3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat3D;
        }

        /// <summary>
        ///   Convert a 3D pose into a homogeneous transformation matrix.
        ///   Instance represents: 3D pose.
        /// </summary>
        /// <returns>Equivalent homogeneous transformation matrix.</returns>
        public HHomMat3D PoseToHomMat3d()
        {
            IntPtr proc = HalconAPI.PreCall(1935);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HHomMat3D hhomMat3D;
            int procResult = HHomMat3D.LoadNew(proc, 0, err, out hhomMat3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat3D;
        }

        /// <summary>
        ///   Deserialize a serialized pose.
        ///   Modified instance represents: 3D pose.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializePose(HSerializedItem serializedItemHandle)
        {
            IntPtr proc = HalconAPI.PreCall(1938);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize a pose.
        ///   Instance represents: 3D pose.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializePose()
        {
            IntPtr proc = HalconAPI.PreCall(1939);
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
        ///   Read a 3D pose from a text file.
        ///   Modified instance represents: 3D pose.
        /// </summary>
        /// <param name="poseFile">File name of the external camera parameters. Default: "campose.dat"</param>
        public void ReadPose(string poseFile)
        {
            IntPtr proc = HalconAPI.PreCall(1940);
            HalconAPI.StoreS(proc, 0, poseFile);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write a 3D pose to a text file.
        ///   Instance represents: 3D pose.
        /// </summary>
        /// <param name="poseFile">File name of the external camera parameters. Default: "campose.dat"</param>
        public void WritePose(string poseFile)
        {
            IntPtr proc = HalconAPI.PreCall(1941);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, poseFile);
            int procResult = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Simulate an image with calibration plate.
        ///   Instance represents: External camera parameters (3D pose of the calibration plate in camera coordinates).
        /// </summary>
        /// <param name="calPlateDescr">File name of the calibration plate description. Default: "calplate.cpd"</param>
        /// <param name="cameraParam">Internal camera parameters.</param>
        /// <param name="grayBackground">Gray value of image background. Default: 128</param>
        /// <param name="grayPlate">Gray value of calibration plate. Default: 80</param>
        /// <param name="grayMarks">Gray value of calibration marks. Default: 224</param>
        /// <param name="scaleFac">Scaling factor to reduce oversampling. Default: 1.0</param>
        /// <returns>Simulated calibration image.</returns>
        public HImage SimCaltab(
          string calPlateDescr,
          HCamPar cameraParam,
          int grayBackground,
          int grayPlate,
          int grayMarks,
          double scaleFac)
        {
            IntPtr proc = HalconAPI.PreCall(1944);
            this.Store(proc, 2);
            HalconAPI.StoreS(proc, 0, calPlateDescr);
            HalconAPI.Store(proc, 1, (HData)cameraParam);
            HalconAPI.StoreI(proc, 3, grayBackground);
            HalconAPI.StoreI(proc, 4, grayPlate);
            HalconAPI.StoreI(proc, 5, grayMarks);
            HalconAPI.StoreD(proc, 6, scaleFac);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)cameraParam));
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>Determine all camera parameters by a simultaneous minimization process.</summary>
        /// <param name="NX">Ordered tuple with all x coordinates of the calibration marks (in meters).</param>
        /// <param name="NY">Ordered tuple with all y coordinates of the calibration marks (in meters).</param>
        /// <param name="NZ">Ordered tuple with all z coordinates of the calibration marks (in meters).</param>
        /// <param name="NRow">Ordered tuple with all row coordinates of the extracted calibration marks (in pixels).</param>
        /// <param name="NCol">Ordered tuple with all column coordinates of the extracted calibration marks (in pixels).</param>
        /// <param name="startCamParam">Initial values for the internal camera parameters.</param>
        /// <param name="NStartPose">Ordered tuple with all initial values for the external camera parameters.</param>
        /// <param name="estimateParams">Camera parameters to be estimated. Default: "all"</param>
        /// <param name="NFinalPose">Ordered tuple with all external camera parameters.</param>
        /// <param name="errors">Average error distance in pixels.</param>
        /// <returns>Internal camera parameters.</returns>
        public static HCamPar CameraCalibration(
          HTuple NX,
          HTuple NY,
          HTuple NZ,
          HTuple NRow,
          HTuple NCol,
          HCamPar startCamParam,
          HPose[] NStartPose,
          HTuple estimateParams,
          out HPose[] NFinalPose,
          out HTuple errors)
        {
            HTuple htuple = HData.ConcatArray((HData[])NStartPose);
            IntPtr proc = HalconAPI.PreCall(1946);
            HalconAPI.Store(proc, 0, NX);
            HalconAPI.Store(proc, 1, NY);
            HalconAPI.Store(proc, 2, NZ);
            HalconAPI.Store(proc, 3, NRow);
            HalconAPI.Store(proc, 4, NCol);
            HalconAPI.Store(proc, 5, (HData)startCamParam);
            HalconAPI.Store(proc, 6, htuple);
            HalconAPI.Store(proc, 7, estimateParams);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(NX);
            HalconAPI.UnpinTuple(NY);
            HalconAPI.UnpinTuple(NZ);
            HalconAPI.UnpinTuple(NRow);
            HalconAPI.UnpinTuple(NCol);
            HalconAPI.UnpinTuple((HTuple)((HData)startCamParam));
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(estimateParams);
            HCamPar hcamPar;
            int err2 = HCamPar.LoadNew(proc, 0, err1, out hcamPar);
            HTuple tuple;
            int err3 = HTuple.LoadNew(proc, 1, err2, out tuple);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out errors);
            HalconAPI.PostCall(proc, procResult);
            NFinalPose = HPose.SplitArray(tuple);
            return hcamPar;
        }

        /// <summary>
        ///   Determine all camera parameters by a simultaneous minimization process.
        ///   Instance represents: Ordered tuple with all initial values for the external camera parameters.
        /// </summary>
        /// <param name="NX">Ordered tuple with all x coordinates of the calibration marks (in meters).</param>
        /// <param name="NY">Ordered tuple with all y coordinates of the calibration marks (in meters).</param>
        /// <param name="NZ">Ordered tuple with all z coordinates of the calibration marks (in meters).</param>
        /// <param name="NRow">Ordered tuple with all row coordinates of the extracted calibration marks (in pixels).</param>
        /// <param name="NCol">Ordered tuple with all column coordinates of the extracted calibration marks (in pixels).</param>
        /// <param name="startCamParam">Initial values for the internal camera parameters.</param>
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
          HCamPar startCamParam,
          HTuple estimateParams,
          out HPose NFinalPose,
          out double errors)
        {
            IntPtr proc = HalconAPI.PreCall(1946);
            this.Store(proc, 6);
            HalconAPI.Store(proc, 0, NX);
            HalconAPI.Store(proc, 1, NY);
            HalconAPI.Store(proc, 2, NZ);
            HalconAPI.Store(proc, 3, NRow);
            HalconAPI.Store(proc, 4, NCol);
            HalconAPI.Store(proc, 5, (HData)startCamParam);
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
            HalconAPI.UnpinTuple((HTuple)((HData)startCamParam));
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
        ///   Modified instance represents: Estimation for the external camera parameters.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="calPlateRegion">Region of the calibration plate.</param>
        /// <param name="calPlateDescr">File name of the calibration plate description. Default: "caltab.descr"</param>
        /// <param name="startCamParam">Initial values for the internal camera parameters.</param>
        /// <param name="startThresh">Initial threshold value for contour detection. Default: 128</param>
        /// <param name="deltaThresh">Loop value for successive reduction of StartThresh. Default: 10</param>
        /// <param name="minThresh">Minimum threshold for contour detection. Default: 18</param>
        /// <param name="alpha">Filter parameter for contour detection, see edges_image. Default: 0.9</param>
        /// <param name="minContLength">Minimum length of the contours of the marks. Default: 15.0</param>
        /// <param name="maxDiamMarks">Maximum expected diameter of the marks. Default: 100.0</param>
        /// <param name="CCoord">Tuple with column coordinates of the detected marks.</param>
        /// <returns>Tuple with row coordinates of the detected marks.</returns>
        public HTuple FindMarksAndPose(
          HImage image,
          HRegion calPlateRegion,
          string calPlateDescr,
          HCamPar startCamParam,
          int startThresh,
          int deltaThresh,
          int minThresh,
          double alpha,
          double minContLength,
          double maxDiamMarks,
          out HTuple CCoord)
        {
            IntPtr proc = HalconAPI.PreCall(1947);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 2, (HObjectBase)calPlateRegion);
            HalconAPI.StoreS(proc, 0, calPlateDescr);
            HalconAPI.Store(proc, 1, (HData)startCamParam);
            HalconAPI.StoreI(proc, 2, startThresh);
            HalconAPI.StoreI(proc, 3, deltaThresh);
            HalconAPI.StoreI(proc, 4, minThresh);
            HalconAPI.StoreD(proc, 5, alpha);
            HalconAPI.StoreD(proc, 6, minContLength);
            HalconAPI.StoreD(proc, 7, maxDiamMarks);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)startCamParam));
            int err2 = this.Load(proc, 2, err1);
            HTuple tuple;
            int err3 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err2, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err3, out CCoord);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)calPlateRegion);
            return tuple;
        }

        /// <summary>Define type, parameters, and relative pose of a camera in a camera setup model.</summary>
        /// <param name="cameraSetupModelID">Handle to the camera setup model.</param>
        /// <param name="cameraIdx">Index of the camera in the setup.</param>
        /// <param name="cameraType">Type of the camera. Default: []</param>
        /// <param name="cameraParam">Internal camera parameters.</param>
        /// <param name="cameraPose">Pose of the camera relative to the setup's coordinate system.</param>
        public static void SetCameraSetupCamParam(
          HCameraSetupModel cameraSetupModelID,
          HTuple cameraIdx,
          HTuple cameraType,
          HCamPar cameraParam,
          HTuple cameraPose)
        {
            IntPtr proc = HalconAPI.PreCall(1957);
            HalconAPI.Store(proc, 0, (HTool)cameraSetupModelID);
            HalconAPI.Store(proc, 1, cameraIdx);
            HalconAPI.Store(proc, 2, cameraType);
            HalconAPI.Store(proc, 3, (HData)cameraParam);
            HalconAPI.Store(proc, 4, cameraPose);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(cameraIdx);
            HalconAPI.UnpinTuple(cameraType);
            HalconAPI.UnpinTuple((HTuple)((HData)cameraParam));
            HalconAPI.UnpinTuple(cameraPose);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)cameraSetupModelID);
        }

        /// <summary>Define type, parameters, and relative pose of a camera in a camera setup model.</summary>
        /// <param name="cameraSetupModelID">Handle to the camera setup model.</param>
        /// <param name="cameraIdx">Index of the camera in the setup.</param>
        /// <param name="cameraType">Type of the camera. Default: []</param>
        /// <param name="cameraParam">Internal camera parameters.</param>
        /// <param name="cameraPose">Pose of the camera relative to the setup's coordinate system.</param>
        public static void SetCameraSetupCamParam(
          HCameraSetupModel cameraSetupModelID,
          HTuple cameraIdx,
          string cameraType,
          HCamPar cameraParam,
          HTuple cameraPose)
        {
            IntPtr proc = HalconAPI.PreCall(1957);
            HalconAPI.Store(proc, 0, (HTool)cameraSetupModelID);
            HalconAPI.Store(proc, 1, cameraIdx);
            HalconAPI.StoreS(proc, 2, cameraType);
            HalconAPI.Store(proc, 3, (HData)cameraParam);
            HalconAPI.Store(proc, 4, cameraPose);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(cameraIdx);
            HalconAPI.UnpinTuple((HTuple)((HData)cameraParam));
            HalconAPI.UnpinTuple(cameraPose);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)cameraSetupModelID);
        }
    }
}