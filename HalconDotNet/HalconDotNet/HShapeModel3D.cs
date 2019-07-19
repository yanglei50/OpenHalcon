// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HShapeModel3D
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a 3D shape model for 3D matching.</summary>
    [Serializable]
    public class HShapeModel3D : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HShapeModel3D()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HShapeModel3D(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HShapeModel3D obj)
        {
            obj = new HShapeModel3D(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HShapeModel3D[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HShapeModel3D[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HShapeModel3D(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Read a 3D shape model from a file.
        ///   Modified instance represents: Handle of the 3D shape model.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public HShapeModel3D(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1052);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Prepare a 3D object model for matching.
        ///   Modified instance represents: Handle of the 3D shape model.
        /// </summary>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <param name="camParam">Internal camera parameters.</param>
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
        public HShapeModel3D(
          HObjectModel3D objectModel3D,
          HCamPar camParam,
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
            HalconAPI.Store(proc, 0, (HTool)objectModel3D);
            HalconAPI.Store(proc, 1, (HData)camParam);
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
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D);
        }

        /// <summary>
        ///   Prepare a 3D object model for matching.
        ///   Modified instance represents: Handle of the 3D shape model.
        /// </summary>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <param name="camParam">Internal camera parameters.</param>
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
        public HShapeModel3D(
          HObjectModel3D objectModel3D,
          HCamPar camParam,
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
            HalconAPI.Store(proc, 0, (HTool)objectModel3D);
            HalconAPI.Store(proc, 1, (HData)camParam);
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
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeShapeModel3d();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HShapeModel3D(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeShapeModel3d(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeShapeModel3d().Serialize(stream);
        }

        public static HShapeModel3D Deserialize(Stream stream)
        {
            HShapeModel3D hshapeModel3D = new HShapeModel3D();
            hshapeModel3D.DeserializeShapeModel3d(HSerializedItem.Deserialize(stream));
            return hshapeModel3D;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HShapeModel3D Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeShapeModel3d();
            HShapeModel3D hshapeModel3D = new HShapeModel3D();
            hshapeModel3D.DeserializeShapeModel3d(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hshapeModel3D;
        }

        /// <summary>
        ///   Deserialize a serialized 3D shape model.
        ///   Modified instance represents: Handle of the 3D shape model.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeShapeModel3d(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1050);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize a 3D shape model.
        ///   Instance represents: Handle of the 3D shape model.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeShapeModel3d()
        {
            IntPtr proc = HalconAPI.PreCall(1051);
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
        ///   Read a 3D shape model from a file.
        ///   Modified instance represents: Handle of the 3D shape model.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void ReadShapeModel3d(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1052);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write a 3D shape model to a file.
        ///   Instance represents: Handle of the 3D shape model.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void WriteShapeModel3d(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1053);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Transform a pose that refers to the coordinate system of a 3D object model to a pose that refers to the reference coordinate system of a 3D shape model and vice versa.
        ///   Instance represents: Handle of the 3D shape model.
        /// </summary>
        /// <param name="poseIn">Pose to be transformed in the source system.</param>
        /// <param name="transformation">Direction of the transformation. Default: "ref_to_model"</param>
        /// <returns>Transformed 3D pose in the target system.</returns>
        public HPose TransPoseShapeModel3d(HPose poseIn, string transformation)
        {
            IntPtr proc = HalconAPI.PreCall(1054);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)poseIn);
            HalconAPI.StoreS(proc, 2, transformation);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)poseIn));
            HPose hpose;
            int procResult = HPose.LoadNew(proc, 0, err, out hpose);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hpose;
        }

        /// <summary>
        ///   Project the edges of a 3D shape model into image coordinates.
        ///   Instance represents: Handle of the 3D shape model.
        /// </summary>
        /// <param name="camParam">Internal camera parameters.</param>
        /// <param name="pose">3D pose of the 3D shape model in the world coordinate system.</param>
        /// <param name="hiddenSurfaceRemoval">Remove hidden surfaces? Default: "true"</param>
        /// <param name="minFaceAngle">Smallest face angle for which the edge is displayed Default: 0.523599</param>
        /// <returns>Contour representation of the model view.</returns>
        public HXLDCont ProjectShapeModel3d(
          HCamPar camParam,
          HPose pose,
          string hiddenSurfaceRemoval,
          HTuple minFaceAngle)
        {
            IntPtr proc = HalconAPI.PreCall(1055);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)camParam);
            HalconAPI.Store(proc, 2, (HData)pose);
            HalconAPI.StoreS(proc, 3, hiddenSurfaceRemoval);
            HalconAPI.Store(proc, 4, minFaceAngle);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
            HalconAPI.UnpinTuple((HTuple)((HData)pose));
            HalconAPI.UnpinTuple(minFaceAngle);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Project the edges of a 3D shape model into image coordinates.
        ///   Instance represents: Handle of the 3D shape model.
        /// </summary>
        /// <param name="camParam">Internal camera parameters.</param>
        /// <param name="pose">3D pose of the 3D shape model in the world coordinate system.</param>
        /// <param name="hiddenSurfaceRemoval">Remove hidden surfaces? Default: "true"</param>
        /// <param name="minFaceAngle">Smallest face angle for which the edge is displayed Default: 0.523599</param>
        /// <returns>Contour representation of the model view.</returns>
        public HXLDCont ProjectShapeModel3d(
          HCamPar camParam,
          HPose pose,
          string hiddenSurfaceRemoval,
          double minFaceAngle)
        {
            IntPtr proc = HalconAPI.PreCall(1055);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)camParam);
            HalconAPI.Store(proc, 2, (HData)pose);
            HalconAPI.StoreS(proc, 3, hiddenSurfaceRemoval);
            HalconAPI.StoreD(proc, 4, minFaceAngle);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
            HalconAPI.UnpinTuple((HTuple)((HData)pose));
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Return the contour representation of a 3D shape model view.
        ///   Instance represents: Handle of the 3D shape model.
        /// </summary>
        /// <param name="level">Pyramid level for which the contour representation should be returned. Default: 1</param>
        /// <param name="view">View for which the contour representation should be returned. Default: 1</param>
        /// <param name="viewPose">3D pose of the 3D shape model at the current view.</param>
        /// <returns>Contour representation of the model view.</returns>
        public HXLDCont GetShapeModel3dContours(int level, int view, out HPose viewPose)
        {
            IntPtr proc = HalconAPI.PreCall(1056);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, level);
            HalconAPI.StoreI(proc, 2, view);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            int err1 = HalconAPI.CallProcedure(proc);
            HXLDCont hxldCont;
            int err2 = HXLDCont.LoadNew(proc, 1, err1, out hxldCont);
            int procResult = HPose.LoadNew(proc, 0, err2, out viewPose);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Return the parameters of a 3D shape model.
        ///   Instance represents: Handle of the 3D shape model.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters that are to be queried for the 3D shape model. Default: "num_levels_max"</param>
        /// <returns>Values of the generic parameters.</returns>
        public HTuple GetShapeModel3dParams(HTuple genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(1057);
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
        ///   Return the parameters of a 3D shape model.
        ///   Instance represents: Handle of the 3D shape model.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters that are to be queried for the 3D shape model. Default: "num_levels_max"</param>
        /// <returns>Values of the generic parameters.</returns>
        public HTuple GetShapeModel3dParams(string genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(1057);
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
        ///   Find the best matches of a 3D shape model in an image.
        ///   Instance represents: Handle of the 3D shape model.
        /// </summary>
        /// <param name="image">Input image in which the model should be found.</param>
        /// <param name="minScore">Minimum score of the instances of the model to be found. Default: 0.7</param>
        /// <param name="greediness">"Greediness" of the search heuristic (0: safe but slow; 1: fast but matches may be missed). Default: 0.9</param>
        /// <param name="numLevels">Number of pyramid levels used in the matching (and lowest pyramid level to use if $|NumLevels| = 2$). Default: 0</param>
        /// <param name="genParamName">Names of (optional) parameters for controlling the behavior of the operator. Default: []</param>
        /// <param name="genParamValue">Values of the optional generic parameters. Default: []</param>
        /// <param name="covPose">6 standard deviations or 36 covariances of the pose parameters.</param>
        /// <param name="score">Score of the found instances of the 3D shape model.</param>
        /// <returns>3D pose of the 3D shape model.</returns>
        public HPose[] FindShapeModel3d(
          HImage image,
          double minScore,
          double greediness,
          HTuple numLevels,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple covPose,
          out HTuple score)
        {
            IntPtr proc = HalconAPI.PreCall(1058);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreD(proc, 1, minScore);
            HalconAPI.StoreD(proc, 2, greediness);
            HalconAPI.Store(proc, 3, numLevels);
            HalconAPI.Store(proc, 4, genParamName);
            HalconAPI.Store(proc, 5, genParamValue);
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
        ///   Prepare a 3D object model for matching.
        ///   Modified instance represents: Handle of the 3D shape model.
        /// </summary>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <param name="camParam">Internal camera parameters.</param>
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
        public void CreateShapeModel3d(
          HObjectModel3D objectModel3D,
          HCamPar camParam,
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
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1059);
            HalconAPI.Store(proc, 0, (HTool)objectModel3D);
            HalconAPI.Store(proc, 1, (HData)camParam);
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
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D);
        }

        /// <summary>
        ///   Prepare a 3D object model for matching.
        ///   Modified instance represents: Handle of the 3D shape model.
        /// </summary>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <param name="camParam">Internal camera parameters.</param>
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
        public void CreateShapeModel3d(
          HObjectModel3D objectModel3D,
          HCamPar camParam,
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
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1059);
            HalconAPI.Store(proc, 0, (HTool)objectModel3D);
            HalconAPI.Store(proc, 1, (HData)camParam);
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
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(1049);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
