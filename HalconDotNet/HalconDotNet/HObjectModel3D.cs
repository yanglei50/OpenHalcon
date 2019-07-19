// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HObjectModel3D
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a 3D object model.</summary>
    [Serializable]
    public class HObjectModel3D : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HObjectModel3D(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HObjectModel3D obj)
        {
            obj = new HObjectModel3D(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HObjectModel3D[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HObjectModel3D[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HObjectModel3D(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Create an empty 3D object model.
        ///   Modified instance represents: Handle of the new 3D object model.
        /// </summary>
        public HObjectModel3D()
        {
            IntPtr proc = HalconAPI.PreCall(1065);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a 3D object model that represents a point cloud from a set of 3D points.
        ///   Modified instance represents: Handle of the resulting 3D object model.
        /// </summary>
        /// <param name="x">The x-coordinates of the points in the 3D point cloud.</param>
        /// <param name="y">The y-coordinates of the points in the 3D point cloud.</param>
        /// <param name="z">The z-coordinates of the points in the 3D point cloud.</param>
        public HObjectModel3D(HTuple x, HTuple y, HTuple z)
        {
            IntPtr proc = HalconAPI.PreCall(1069);
            HalconAPI.Store(proc, 0, x);
            HalconAPI.Store(proc, 1, y);
            HalconAPI.Store(proc, 2, z);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(x);
            HalconAPI.UnpinTuple(y);
            HalconAPI.UnpinTuple(z);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a 3D object model that represents a point cloud from a set of 3D points.
        ///   Modified instance represents: Handle of the resulting 3D object model.
        /// </summary>
        /// <param name="x">The x-coordinates of the points in the 3D point cloud.</param>
        /// <param name="y">The y-coordinates of the points in the 3D point cloud.</param>
        /// <param name="z">The z-coordinates of the points in the 3D point cloud.</param>
        public HObjectModel3D(double x, double y, double z)
        {
            IntPtr proc = HalconAPI.PreCall(1069);
            HalconAPI.StoreD(proc, 0, x);
            HalconAPI.StoreD(proc, 1, y);
            HalconAPI.StoreD(proc, 2, z);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Transform 3D points from images to a 3D object model.
        ///   Modified instance represents: Handle of the 3D object model.
        /// </summary>
        /// <param name="x">Image with the X-Coordinates and the ROI of the 3D points.</param>
        /// <param name="y">Image with the Y-Coordinates of the 3D points.</param>
        /// <param name="z">Image with the Z-Coordinates of the 3D points.</param>
        public HObjectModel3D(HImage x, HImage y, HImage z)
        {
            IntPtr proc = HalconAPI.PreCall(1093);
            HalconAPI.Store(proc, 1, (HObjectBase)x);
            HalconAPI.Store(proc, 2, (HObjectBase)y);
            HalconAPI.Store(proc, 3, (HObjectBase)z);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)x);
            GC.KeepAlive((object)y);
            GC.KeepAlive((object)z);
        }

        /// <summary>
        ///   Read a 3D object model from a file.
        ///   Modified instance represents: Handle of the 3D object model.
        /// </summary>
        /// <param name="fileName">Filename of the file to be read.</param>
        /// <param name="scale">Scale of the data in the file. Default: "m"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="status">Status information.</param>
        public HObjectModel3D(
          string fileName,
          HTuple scale,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple status)
        {
            IntPtr proc = HalconAPI.PreCall(1104);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.Store(proc, 1, scale);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(scale);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int err2 = this.Load(proc, 0, err1);
            int procResult = HTuple.LoadNew(proc, 1, err2, out status);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Read a 3D object model from a file.
        ///   Modified instance represents: Handle of the 3D object model.
        /// </summary>
        /// <param name="fileName">Filename of the file to be read.</param>
        /// <param name="scale">Scale of the data in the file. Default: "m"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="status">Status information.</param>
        public HObjectModel3D(
          string fileName,
          string scale,
          string genParamName,
          string genParamValue,
          out string status)
        {
            IntPtr proc = HalconAPI.PreCall(1104);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.StoreS(proc, 1, scale);
            HalconAPI.StoreS(proc, 2, genParamName);
            HalconAPI.StoreS(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = this.Load(proc, 0, err1);
            int procResult = HalconAPI.LoadS(proc, 1, err2, out status);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeObjectModel3d();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HObjectModel3D(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeObjectModel3d(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeObjectModel3d().Serialize(stream);
        }

        public static HObjectModel3D Deserialize(Stream stream)
        {
            HObjectModel3D hobjectModel3D = new HObjectModel3D();
            hobjectModel3D.DeserializeObjectModel3d(HSerializedItem.Deserialize(stream));
            return hobjectModel3D;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HObjectModel3D Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeObjectModel3d();
            HObjectModel3D hobjectModel3D = new HObjectModel3D();
            hobjectModel3D.DeserializeObjectModel3d(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hobjectModel3D;
        }

        /// <summary>
        ///   Get the result of a calibrated measurement performed with the  sheet-of-light technique as a 3D object model.
        ///   Modified instance represents: Handle of the resulting 3D object model.
        /// </summary>
        /// <param name="sheetOfLightModelID">Handle for accessing the sheet-of-light model.</param>
        public void GetSheetOfLightResultObjectModel3d(HSheetOfLightModel sheetOfLightModelID)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(380);
            HalconAPI.Store(proc, 0, (HTool)sheetOfLightModelID);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)sheetOfLightModelID);
        }

        /// <summary>Fit 3D primitives into a set of 3D points.</summary>
        /// <param name="objectModel3D">Handle of the input 3D object model.</param>
        /// <param name="genParamName">Names of the generic parameters.</param>
        /// <param name="genParamValue">Values of the generic parameters.</param>
        /// <returns>Handle of the output 3D object model.</returns>
        public static HObjectModel3D[] FitPrimitivesObjectModel3d(
          HObjectModel3D[] objectModel3D,
          HTuple genParamName,
          HTuple genParamValue)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])objectModel3D);
            IntPtr proc = HalconAPI.PreCall(411);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.Store(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HObjectModel3D[] hobjectModel3DArray;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3DArray);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)objectModel3D);
            return hobjectModel3DArray;
        }

        /// <summary>
        ///   Fit 3D primitives into a set of 3D points.
        ///   Instance represents: Handle of the input 3D object model.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters.</param>
        /// <param name="genParamValue">Values of the generic parameters.</param>
        /// <returns>Handle of the output 3D object model.</returns>
        public HObjectModel3D FitPrimitivesObjectModel3d(
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(411);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HObjectModel3D hobjectModel3D;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobjectModel3D;
        }

        /// <summary>Segment a set of 3D points into sub-sets with similar characteristics.</summary>
        /// <param name="objectModel3D">Handle of the input 3D object model.</param>
        /// <param name="genParamName">Names of the generic parameters.</param>
        /// <param name="genParamValue">Values of the generic parameters.</param>
        /// <returns>Handle of the output 3D object model.</returns>
        public static HObjectModel3D[] SegmentObjectModel3d(
          HObjectModel3D[] objectModel3D,
          HTuple genParamName,
          HTuple genParamValue)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])objectModel3D);
            IntPtr proc = HalconAPI.PreCall(412);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.Store(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HObjectModel3D[] hobjectModel3DArray;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3DArray);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)objectModel3D);
            return hobjectModel3DArray;
        }

        /// <summary>
        ///   Segment a set of 3D points into sub-sets with similar characteristics.
        ///   Instance represents: Handle of the input 3D object model.
        /// </summary>
        /// <param name="genParamName">Names of the generic parameters.</param>
        /// <param name="genParamValue">Values of the generic parameters.</param>
        /// <returns>Handle of the output 3D object model.</returns>
        public HObjectModel3D SegmentObjectModel3d(
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(412);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HObjectModel3D hobjectModel3D;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobjectModel3D;
        }

        /// <summary>Calculate the 3D surface normals of a 3D object model.</summary>
        /// <param name="objectModel3D">Handle of the 3D object model containing 3D point data.</param>
        /// <param name="method">Normals calculation method. Default: "mls"</param>
        /// <param name="genParamName">Names of generic smoothing parameters. Default: []</param>
        /// <param name="genParamValue">Values of generic smoothing parameters. Default: []</param>
        /// <returns>Handle of the 3D object model with calculated 3D normals.</returns>
        public static HObjectModel3D[] SurfaceNormalsObjectModel3d(
          HObjectModel3D[] objectModel3D,
          string method,
          HTuple genParamName,
          HTuple genParamValue)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])objectModel3D);
            IntPtr proc = HalconAPI.PreCall(515);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.StoreS(proc, 1, method);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HObjectModel3D[] hobjectModel3DArray;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3DArray);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)objectModel3D);
            return hobjectModel3DArray;
        }

        /// <summary>
        ///   Calculate the 3D surface normals of a 3D object model.
        ///   Instance represents: Handle of the 3D object model containing 3D point data.
        /// </summary>
        /// <param name="method">Normals calculation method. Default: "mls"</param>
        /// <param name="genParamName">Names of generic smoothing parameters. Default: []</param>
        /// <param name="genParamValue">Values of generic smoothing parameters. Default: []</param>
        /// <returns>Handle of the 3D object model with calculated 3D normals.</returns>
        public HObjectModel3D SurfaceNormalsObjectModel3d(
          string method,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(515);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, method);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HObjectModel3D hobjectModel3D;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobjectModel3D;
        }

        /// <summary>Smooth the 3D points of a 3D object model.</summary>
        /// <param name="objectModel3D">Handle of the 3D object model containing 3D point data.</param>
        /// <param name="method">Smoothing method. Default: "mls"</param>
        /// <param name="genParamName">Names of generic smoothing parameters. Default: []</param>
        /// <param name="genParamValue">Values of generic smoothing parameters. Default: []</param>
        /// <returns>Handle of the 3D object model with the smoothed 3D point data.</returns>
        public static HObjectModel3D[] SmoothObjectModel3d(
          HObjectModel3D[] objectModel3D,
          string method,
          HTuple genParamName,
          HTuple genParamValue)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])objectModel3D);
            IntPtr proc = HalconAPI.PreCall(516);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.StoreS(proc, 1, method);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HObjectModel3D[] hobjectModel3DArray;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3DArray);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)objectModel3D);
            return hobjectModel3DArray;
        }

        /// <summary>
        ///   Smooth the 3D points of a 3D object model.
        ///   Instance represents: Handle of the 3D object model containing 3D point data.
        /// </summary>
        /// <param name="method">Smoothing method. Default: "mls"</param>
        /// <param name="genParamName">Names of generic smoothing parameters. Default: []</param>
        /// <param name="genParamValue">Values of generic smoothing parameters. Default: []</param>
        /// <returns>Handle of the 3D object model with the smoothed 3D point data.</returns>
        public HObjectModel3D SmoothObjectModel3d(
          string method,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(516);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, method);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HObjectModel3D hobjectModel3D;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobjectModel3D;
        }

        /// <summary>Create a surface triangulation for a 3D object model.</summary>
        /// <param name="objectModel3D">Handle of the 3D object model containing 3D point data.</param>
        /// <param name="method">Triangulation method. Default: "greedy"</param>
        /// <param name="genParamName">Names of the generic triangulation parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic triangulation parameters. Default: []</param>
        /// <param name="information">Additional information about the triangulation process.</param>
        /// <returns>Handle of the 3D object model with the triangulated surface.</returns>
        public static HObjectModel3D[] TriangulateObjectModel3d(
          HObjectModel3D[] objectModel3D,
          string method,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple information)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])objectModel3D);
            IntPtr proc = HalconAPI.PreCall(517);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.StoreS(proc, 1, method);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HObjectModel3D[] hobjectModel3DArray;
            int err2 = HObjectModel3D.LoadNew(proc, 0, err1, out hobjectModel3DArray);
            int procResult = HTuple.LoadNew(proc, 1, err2, out information);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)objectModel3D);
            return hobjectModel3DArray;
        }

        /// <summary>
        ///   Create a surface triangulation for a 3D object model.
        ///   Instance represents: Handle of the 3D object model containing 3D point data.
        /// </summary>
        /// <param name="method">Triangulation method. Default: "greedy"</param>
        /// <param name="genParamName">Names of the generic triangulation parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic triangulation parameters. Default: []</param>
        /// <param name="information">Additional information about the triangulation process.</param>
        /// <returns>Handle of the 3D object model with the triangulated surface.</returns>
        public HObjectModel3D TriangulateObjectModel3d(
          string method,
          HTuple genParamName,
          HTuple genParamValue,
          out int information)
        {
            IntPtr proc = HalconAPI.PreCall(517);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, method);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HObjectModel3D hobjectModel3D;
            int err2 = HObjectModel3D.LoadNew(proc, 0, err1, out hobjectModel3D);
            int procResult = HalconAPI.LoadI(proc, 1, err2, out information);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobjectModel3D;
        }

        /// <summary>
        ///   Reconstruct surface from calibrated multi-view stereo images.
        ///   Modified instance represents: Handle to the resulting surface.
        /// </summary>
        /// <param name="images">An image array acquired by the camera setup associated with the stereo model.</param>
        /// <param name="stereoModelID">Handle of the stereo model.</param>
        public void ReconstructSurfaceStereo(HImage images, HStereoModel stereoModelID)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(521);
            HalconAPI.Store(proc, 1, (HObjectBase)images);
            HalconAPI.Store(proc, 0, (HTool)stereoModelID);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)images);
            GC.KeepAlive((object)stereoModelID);
        }

        /// <summary>
        ///   Refine the position and deformation of a deformable surface model in a 3D scene.
        ///   Instance represents: Handle of the 3D object model containing the scene.
        /// </summary>
        /// <param name="deformableSurfaceModel">Handle of the deformable surface model.</param>
        /// <param name="relSamplingDistance">Relative sampling distance of the scene. Default: 0.05</param>
        /// <param name="initialDeformationObjectModel3D">Initial deformation of the 3D object model</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="deformableSurfaceMatchingResult">Handle of the matching result.</param>
        /// <returns>Score of the refined model.</returns>
        public HTuple RefineDeformableSurfaceModel(
          HDeformableSurfaceModel deformableSurfaceModel,
          double relSamplingDistance,
          HObjectModel3D initialDeformationObjectModel3D,
          HTuple genParamName,
          HTuple genParamValue,
          out HDeformableSurfaceMatchingResult[] deformableSurfaceMatchingResult)
        {
            IntPtr proc = HalconAPI.PreCall(1026);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)deformableSurfaceModel);
            HalconAPI.StoreD(proc, 2, relSamplingDistance);
            HalconAPI.Store(proc, 3, (HTool)initialDeformationObjectModel3D);
            HalconAPI.Store(proc, 4, genParamName);
            HalconAPI.Store(proc, 5, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int procResult = HDeformableSurfaceMatchingResult.LoadNew(proc, 1, err2, out deformableSurfaceMatchingResult);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)deformableSurfaceModel);
            GC.KeepAlive((object)initialDeformationObjectModel3D);
            return tuple;
        }

        /// <summary>
        ///   Refine the position and deformation of a deformable surface model in a 3D scene.
        ///   Instance represents: Handle of the 3D object model containing the scene.
        /// </summary>
        /// <param name="deformableSurfaceModel">Handle of the deformable surface model.</param>
        /// <param name="relSamplingDistance">Relative sampling distance of the scene. Default: 0.05</param>
        /// <param name="initialDeformationObjectModel3D">Initial deformation of the 3D object model</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="deformableSurfaceMatchingResult">Handle of the matching result.</param>
        /// <returns>Score of the refined model.</returns>
        public double RefineDeformableSurfaceModel(
          HDeformableSurfaceModel deformableSurfaceModel,
          double relSamplingDistance,
          HObjectModel3D initialDeformationObjectModel3D,
          string genParamName,
          string genParamValue,
          out HDeformableSurfaceMatchingResult deformableSurfaceMatchingResult)
        {
            IntPtr proc = HalconAPI.PreCall(1026);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)deformableSurfaceModel);
            HalconAPI.StoreD(proc, 2, relSamplingDistance);
            HalconAPI.Store(proc, 3, (HTool)initialDeformationObjectModel3D);
            HalconAPI.StoreS(proc, 4, genParamName);
            HalconAPI.StoreS(proc, 5, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int procResult = HDeformableSurfaceMatchingResult.LoadNew(proc, 1, err2, out deformableSurfaceMatchingResult);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)deformableSurfaceModel);
            GC.KeepAlive((object)initialDeformationObjectModel3D);
            return doubleValue;
        }

        /// <summary>
        ///   Find the best match of a deformable surface model in a 3D scene.
        ///   Instance represents: Handle of the 3D object model containing the scene.
        /// </summary>
        /// <param name="deformableSurfaceModel">Handle of the deformable surface model.</param>
        /// <param name="relSamplingDistance">Scene sampling distance relative to the diameter of the surface model. Default: 0.05</param>
        /// <param name="minScore">Minimum score of the returned match. Default: 0</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="deformableSurfaceMatchingResult">Handle of the matching result.</param>
        /// <returns>Score of the found instances of the surface model.</returns>
        public HTuple FindDeformableSurfaceModel(
          HDeformableSurfaceModel deformableSurfaceModel,
          double relSamplingDistance,
          HTuple minScore,
          HTuple genParamName,
          HTuple genParamValue,
          out HDeformableSurfaceMatchingResult[] deformableSurfaceMatchingResult)
        {
            IntPtr proc = HalconAPI.PreCall(1027);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)deformableSurfaceModel);
            HalconAPI.StoreD(proc, 2, relSamplingDistance);
            HalconAPI.Store(proc, 3, minScore);
            HalconAPI.Store(proc, 4, genParamName);
            HalconAPI.Store(proc, 5, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(minScore);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int procResult = HDeformableSurfaceMatchingResult.LoadNew(proc, 1, err2, out deformableSurfaceMatchingResult);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)deformableSurfaceModel);
            return tuple;
        }

        /// <summary>
        ///   Find the best match of a deformable surface model in a 3D scene.
        ///   Instance represents: Handle of the 3D object model containing the scene.
        /// </summary>
        /// <param name="deformableSurfaceModel">Handle of the deformable surface model.</param>
        /// <param name="relSamplingDistance">Scene sampling distance relative to the diameter of the surface model. Default: 0.05</param>
        /// <param name="minScore">Minimum score of the returned match. Default: 0</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="deformableSurfaceMatchingResult">Handle of the matching result.</param>
        /// <returns>Score of the found instances of the surface model.</returns>
        public double FindDeformableSurfaceModel(
          HDeformableSurfaceModel deformableSurfaceModel,
          double relSamplingDistance,
          double minScore,
          HTuple genParamName,
          HTuple genParamValue,
          out HDeformableSurfaceMatchingResult deformableSurfaceMatchingResult)
        {
            IntPtr proc = HalconAPI.PreCall(1027);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)deformableSurfaceModel);
            HalconAPI.StoreD(proc, 2, relSamplingDistance);
            HalconAPI.StoreD(proc, 3, minScore);
            HalconAPI.Store(proc, 4, genParamName);
            HalconAPI.Store(proc, 5, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int procResult = HDeformableSurfaceMatchingResult.LoadNew(proc, 1, err2, out deformableSurfaceMatchingResult);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)deformableSurfaceModel);
            return doubleValue;
        }

        /// <summary>Add a sample deformation to a deformable surface model</summary>
        /// <param name="deformableSurfaceModel">Handle of the deformable surface model.</param>
        /// <param name="objectModel3D">Handle of the deformed 3D object model.</param>
        public static void AddDeformableSurfaceModelSample(
          HDeformableSurfaceModel deformableSurfaceModel,
          HObjectModel3D[] objectModel3D)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])objectModel3D);
            IntPtr proc = HalconAPI.PreCall(1030);
            HalconAPI.Store(proc, 0, (HTool)deformableSurfaceModel);
            HalconAPI.Store(proc, 1, htuple);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)deformableSurfaceModel);
            GC.KeepAlive((object)objectModel3D);
        }

        /// <summary>
        ///   Add a sample deformation to a deformable surface model
        ///   Instance represents: Handle of the deformed 3D object model.
        /// </summary>
        /// <param name="deformableSurfaceModel">Handle of the deformable surface model.</param>
        public void AddDeformableSurfaceModelSample(HDeformableSurfaceModel deformableSurfaceModel)
        {
            IntPtr proc = HalconAPI.PreCall(1030);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)deformableSurfaceModel);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)deformableSurfaceModel);
        }

        /// <summary>
        ///   Create the data structure needed to perform deformable surface-based matching.
        ///   Instance represents: Handle of the 3D object model.
        /// </summary>
        /// <param name="relSamplingDistance">Sampling distance relative to the object's diameter Default: 0.05</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <returns>Handle of the deformable surface model.</returns>
        public HDeformableSurfaceModel CreateDeformableSurfaceModel(
          double relSamplingDistance,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1031);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, relSamplingDistance);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HDeformableSurfaceModel hdeformableSurfaceModel;
            int procResult = HDeformableSurfaceModel.LoadNew(proc, 0, err, out hdeformableSurfaceModel);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hdeformableSurfaceModel;
        }

        /// <summary>
        ///   Create the data structure needed to perform deformable surface-based matching.
        ///   Instance represents: Handle of the 3D object model.
        /// </summary>
        /// <param name="relSamplingDistance">Sampling distance relative to the object's diameter Default: 0.05</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <returns>Handle of the deformable surface model.</returns>
        public HDeformableSurfaceModel CreateDeformableSurfaceModel(
          double relSamplingDistance,
          string genParamName,
          string genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1031);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, relSamplingDistance);
            HalconAPI.StoreS(proc, 2, genParamName);
            HalconAPI.StoreS(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HDeformableSurfaceModel hdeformableSurfaceModel;
            int procResult = HDeformableSurfaceModel.LoadNew(proc, 0, err, out hdeformableSurfaceModel);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hdeformableSurfaceModel;
        }

        /// <summary>
        ///   Refine the pose of a surface model in a 3D scene.
        ///   Instance represents: Handle of the 3D object model containing the scene.
        /// </summary>
        /// <param name="surfaceModelID">Handle of the surface model.</param>
        /// <param name="initialPose">Initial pose of the surface model in the scene.</param>
        /// <param name="minScore">Minimum score of the returned poses. Default: 0</param>
        /// <param name="returnResultHandle">Enable returning a result handle in SurfaceMatchingResultID. Default: "false"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="score">Score of the found instances of the model.</param>
        /// <param name="surfaceMatchingResultID">Handle of the matching result, if enabled in ReturnResultHandle.</param>
        /// <returns>3D pose of the surface model in the scene.</returns>
        public HPose[] RefineSurfaceModelPose(
          HSurfaceModel surfaceModelID,
          HPose[] initialPose,
          HTuple minScore,
          string returnResultHandle,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple score,
          out HSurfaceMatchingResult[] surfaceMatchingResultID)
        {
            HTuple htuple = HData.ConcatArray((HData[])initialPose);
            IntPtr proc = HalconAPI.PreCall(1041);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)surfaceModelID);
            HalconAPI.Store(proc, 2, htuple);
            HalconAPI.Store(proc, 3, minScore);
            HalconAPI.StoreS(proc, 4, returnResultHandle);
            HalconAPI.Store(proc, 5, genParamName);
            HalconAPI.Store(proc, 6, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(minScore);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out score);
            int procResult = HSurfaceMatchingResult.LoadNew(proc, 2, err3, out surfaceMatchingResultID);
            HalconAPI.PostCall(proc, procResult);
            HPose[] hposeArray = HPose.SplitArray(tuple);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)surfaceModelID);
            return hposeArray;
        }

        /// <summary>
        ///   Refine the pose of a surface model in a 3D scene.
        ///   Instance represents: Handle of the 3D object model containing the scene.
        /// </summary>
        /// <param name="surfaceModelID">Handle of the surface model.</param>
        /// <param name="initialPose">Initial pose of the surface model in the scene.</param>
        /// <param name="minScore">Minimum score of the returned poses. Default: 0</param>
        /// <param name="returnResultHandle">Enable returning a result handle in SurfaceMatchingResultID. Default: "false"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="score">Score of the found instances of the model.</param>
        /// <param name="surfaceMatchingResultID">Handle of the matching result, if enabled in ReturnResultHandle.</param>
        /// <returns>3D pose of the surface model in the scene.</returns>
        public HPose RefineSurfaceModelPose(
          HSurfaceModel surfaceModelID,
          HPose initialPose,
          double minScore,
          string returnResultHandle,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple score,
          out HSurfaceMatchingResult surfaceMatchingResultID)
        {
            IntPtr proc = HalconAPI.PreCall(1041);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)surfaceModelID);
            HalconAPI.Store(proc, 2, (HData)initialPose);
            HalconAPI.StoreD(proc, 3, minScore);
            HalconAPI.StoreS(proc, 4, returnResultHandle);
            HalconAPI.Store(proc, 5, genParamName);
            HalconAPI.Store(proc, 6, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)initialPose));
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HPose hpose;
            int err2 = HPose.LoadNew(proc, 0, err1, out hpose);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out score);
            int procResult = HSurfaceMatchingResult.LoadNew(proc, 2, err3, out surfaceMatchingResultID);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)surfaceModelID);
            return hpose;
        }

        /// <summary>
        ///   Find the best matches of a surface model in a 3D scene.
        ///   Instance represents: Handle of the 3D object model containing the scene.
        /// </summary>
        /// <param name="surfaceModelID">Handle of the surface model.</param>
        /// <param name="relSamplingDistance">Scene sampling distance relative to the diameter of the surface model. Default: 0.05</param>
        /// <param name="keyPointFraction">Fraction of sampled scene points used as key points. Default: 0.2</param>
        /// <param name="minScore">Minimum score of the returned poses. Default: 0</param>
        /// <param name="returnResultHandle">Enable returning a result handle in SurfaceMatchingResultID. Default: "false"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="score">Score of the found instances of the surface model.</param>
        /// <param name="surfaceMatchingResultID">Handle of the matching result, if enabled in ReturnResultHandle.</param>
        /// <returns>3D pose of the surface model in the scene.</returns>
        public HPose[] FindSurfaceModel(
          HSurfaceModel surfaceModelID,
          double relSamplingDistance,
          double keyPointFraction,
          HTuple minScore,
          string returnResultHandle,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple score,
          out HSurfaceMatchingResult[] surfaceMatchingResultID)
        {
            IntPtr proc = HalconAPI.PreCall(1042);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)surfaceModelID);
            HalconAPI.StoreD(proc, 2, relSamplingDistance);
            HalconAPI.StoreD(proc, 3, keyPointFraction);
            HalconAPI.Store(proc, 4, minScore);
            HalconAPI.StoreS(proc, 5, returnResultHandle);
            HalconAPI.Store(proc, 6, genParamName);
            HalconAPI.Store(proc, 7, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(minScore);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out score);
            int procResult = HSurfaceMatchingResult.LoadNew(proc, 2, err3, out surfaceMatchingResultID);
            HalconAPI.PostCall(proc, procResult);
            HPose[] hposeArray = HPose.SplitArray(tuple);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)surfaceModelID);
            return hposeArray;
        }

        /// <summary>
        ///   Find the best matches of a surface model in a 3D scene.
        ///   Instance represents: Handle of the 3D object model containing the scene.
        /// </summary>
        /// <param name="surfaceModelID">Handle of the surface model.</param>
        /// <param name="relSamplingDistance">Scene sampling distance relative to the diameter of the surface model. Default: 0.05</param>
        /// <param name="keyPointFraction">Fraction of sampled scene points used as key points. Default: 0.2</param>
        /// <param name="minScore">Minimum score of the returned poses. Default: 0</param>
        /// <param name="returnResultHandle">Enable returning a result handle in SurfaceMatchingResultID. Default: "false"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="score">Score of the found instances of the surface model.</param>
        /// <param name="surfaceMatchingResultID">Handle of the matching result, if enabled in ReturnResultHandle.</param>
        /// <returns>3D pose of the surface model in the scene.</returns>
        public HPose FindSurfaceModel(
          HSurfaceModel surfaceModelID,
          double relSamplingDistance,
          double keyPointFraction,
          double minScore,
          string returnResultHandle,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple score,
          out HSurfaceMatchingResult surfaceMatchingResultID)
        {
            IntPtr proc = HalconAPI.PreCall(1042);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)surfaceModelID);
            HalconAPI.StoreD(proc, 2, relSamplingDistance);
            HalconAPI.StoreD(proc, 3, keyPointFraction);
            HalconAPI.StoreD(proc, 4, minScore);
            HalconAPI.StoreS(proc, 5, returnResultHandle);
            HalconAPI.Store(proc, 6, genParamName);
            HalconAPI.Store(proc, 7, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HPose hpose;
            int err2 = HPose.LoadNew(proc, 0, err1, out hpose);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out score);
            int procResult = HSurfaceMatchingResult.LoadNew(proc, 2, err3, out surfaceMatchingResultID);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)surfaceModelID);
            return hpose;
        }

        /// <summary>
        ///   Create the data structure needed to perform surface-based matching.
        ///   Instance represents: Handle of the 3D object model.
        /// </summary>
        /// <param name="relSamplingDistance">Sampling distance relative to the object's diameter Default: 0.03</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <returns>Handle of the surface model.</returns>
        public HSurfaceModel CreateSurfaceModel(
          double relSamplingDistance,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1044);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, relSamplingDistance);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HSurfaceModel hsurfaceModel;
            int procResult = HSurfaceModel.LoadNew(proc, 0, err, out hsurfaceModel);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hsurfaceModel;
        }

        /// <summary>
        ///   Create the data structure needed to perform surface-based matching.
        ///   Instance represents: Handle of the 3D object model.
        /// </summary>
        /// <param name="relSamplingDistance">Sampling distance relative to the object's diameter Default: 0.03</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <returns>Handle of the surface model.</returns>
        public HSurfaceModel CreateSurfaceModel(
          double relSamplingDistance,
          string genParamName,
          string genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1044);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, relSamplingDistance);
            HalconAPI.StoreS(proc, 2, genParamName);
            HalconAPI.StoreS(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HSurfaceModel hsurfaceModel;
            int procResult = HSurfaceModel.LoadNew(proc, 0, err, out hsurfaceModel);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hsurfaceModel;
        }

        /// <summary>Simplify a triangulated 3D object model.</summary>
        /// <param name="objectModel3D">Handle of the 3D object model that should be simplified.</param>
        /// <param name="method">Method that should be used for simplification. Default: "preserve_point_coordinates"</param>
        /// <param name="amount">Degree of simplification (default: percentage of remaining model points).</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <returns>Handle of the simplified 3D object model.</returns>
        public static HObjectModel3D[] SimplifyObjectModel3d(
          HObjectModel3D[] objectModel3D,
          string method,
          HTuple amount,
          HTuple genParamName,
          HTuple genParamValue)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])objectModel3D);
            IntPtr proc = HalconAPI.PreCall(1060);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.StoreS(proc, 1, method);
            HalconAPI.Store(proc, 2, amount);
            HalconAPI.Store(proc, 3, genParamName);
            HalconAPI.Store(proc, 4, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(amount);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HObjectModel3D[] hobjectModel3DArray;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3DArray);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)objectModel3D);
            return hobjectModel3DArray;
        }

        /// <summary>
        ///   Simplify a triangulated 3D object model.
        ///   Instance represents: Handle of the 3D object model that should be simplified.
        /// </summary>
        /// <param name="method">Method that should be used for simplification. Default: "preserve_point_coordinates"</param>
        /// <param name="amount">Degree of simplification (default: percentage of remaining model points).</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <returns>Handle of the simplified 3D object model.</returns>
        public HObjectModel3D SimplifyObjectModel3d(
          string method,
          double amount,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1060);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, method);
            HalconAPI.StoreD(proc, 2, amount);
            HalconAPI.Store(proc, 3, genParamName);
            HalconAPI.Store(proc, 4, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HObjectModel3D hobjectModel3D;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobjectModel3D;
        }

        /// <summary>
        ///   Compute the distances of the points of one 3D object model to another 3D object model.
        ///   Instance represents: Handle of the source 3D object model.
        /// </summary>
        /// <param name="objectModel3DTo">Handle of the target 3D object model.</param>
        /// <param name="pose">Pose of the source 3D object model in the target 3D object model. Default: []</param>
        /// <param name="maxDistance">Maximum distance of interest. Default: 0</param>
        /// <param name="genParamName">Names of the generic input parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic input parameters. Default: []</param>
        public void DistanceObjectModel3d(
          HObjectModel3D objectModel3DTo,
          HPose pose,
          HTuple maxDistance,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1061);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)objectModel3DTo);
            HalconAPI.Store(proc, 2, (HData)pose);
            HalconAPI.Store(proc, 3, maxDistance);
            HalconAPI.Store(proc, 4, genParamName);
            HalconAPI.Store(proc, 5, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)pose));
            HalconAPI.UnpinTuple(maxDistance);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3DTo);
        }

        /// <summary>
        ///   Compute the distances of the points of one 3D object model to another 3D object model.
        ///   Instance represents: Handle of the source 3D object model.
        /// </summary>
        /// <param name="objectModel3DTo">Handle of the target 3D object model.</param>
        /// <param name="pose">Pose of the source 3D object model in the target 3D object model. Default: []</param>
        /// <param name="maxDistance">Maximum distance of interest. Default: 0</param>
        /// <param name="genParamName">Names of the generic input parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic input parameters. Default: []</param>
        public void DistanceObjectModel3d(
          HObjectModel3D objectModel3DTo,
          HPose pose,
          double maxDistance,
          string genParamName,
          string genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1061);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)objectModel3DTo);
            HalconAPI.Store(proc, 2, (HData)pose);
            HalconAPI.StoreD(proc, 3, maxDistance);
            HalconAPI.StoreS(proc, 4, genParamName);
            HalconAPI.StoreS(proc, 5, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)pose));
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3DTo);
        }

        /// <summary>Combine several 3D object models to a new 3D object model.</summary>
        /// <param name="objectModels3D">Handle of input 3D object models.</param>
        /// <param name="method">Method used for the union. Default: "points_surface"</param>
        /// <returns>Handle of the resulting 3D object model.</returns>
        public static HObjectModel3D UnionObjectModel3d(
          HObjectModel3D[] objectModels3D,
          string method)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])objectModels3D);
            IntPtr proc = HalconAPI.PreCall(1062);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.StoreS(proc, 1, method);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HObjectModel3D hobjectModel3D;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)objectModels3D);
            return hobjectModel3D;
        }

        /// <summary>
        ///   Combine several 3D object models to a new 3D object model.
        ///   Instance represents: Handle of input 3D object models.
        /// </summary>
        /// <param name="method">Method used for the union. Default: "points_surface"</param>
        /// <returns>Handle of the resulting 3D object model.</returns>
        public HObjectModel3D UnionObjectModel3d(string method)
        {
            IntPtr proc = HalconAPI.PreCall(1062);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, method);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HObjectModel3D hobjectModel3D;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobjectModel3D;
        }

        /// <summary>
        ///   Set attributes of a 3D object model.
        ///   Instance represents: Handle of the 3D object model.
        /// </summary>
        /// <param name="attribName">Name of the attributes.</param>
        /// <param name="attachExtAttribTo">Defines where extended attributes are attached to. Default: []</param>
        /// <param name="attribValues">Attribute values.</param>
        public void SetObjectModel3dAttribMod(
          HTuple attribName,
          string attachExtAttribTo,
          HTuple attribValues)
        {
            IntPtr proc = HalconAPI.PreCall(1063);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, attribName);
            HalconAPI.StoreS(proc, 2, attachExtAttribTo);
            HalconAPI.Store(proc, 3, attribValues);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(attribName);
            HalconAPI.UnpinTuple(attribValues);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set attributes of a 3D object model.
        ///   Instance represents: Handle of the 3D object model.
        /// </summary>
        /// <param name="attribName">Name of the attributes.</param>
        /// <param name="attachExtAttribTo">Defines where extended attributes are attached to. Default: []</param>
        /// <param name="attribValues">Attribute values.</param>
        public void SetObjectModel3dAttribMod(
          string attribName,
          string attachExtAttribTo,
          double attribValues)
        {
            IntPtr proc = HalconAPI.PreCall(1063);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, attribName);
            HalconAPI.StoreS(proc, 2, attachExtAttribTo);
            HalconAPI.StoreD(proc, 3, attribValues);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set attributes of a 3D object model.
        ///   Instance represents: Handle of the input 3D object model.
        /// </summary>
        /// <param name="attribName">Name of the attributes.</param>
        /// <param name="attachExtAttribTo">Defines where extended attributes are attached to. Default: []</param>
        /// <param name="attribValues">Attribute values.</param>
        /// <returns>Handle of the resulting 3D object model.</returns>
        public HObjectModel3D SetObjectModel3dAttrib(
          HTuple attribName,
          string attachExtAttribTo,
          HTuple attribValues)
        {
            IntPtr proc = HalconAPI.PreCall(1064);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, attribName);
            HalconAPI.StoreS(proc, 2, attachExtAttribTo);
            HalconAPI.Store(proc, 3, attribValues);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(attribName);
            HalconAPI.UnpinTuple(attribValues);
            HObjectModel3D hobjectModel3D;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobjectModel3D;
        }

        /// <summary>
        ///   Set attributes of a 3D object model.
        ///   Instance represents: Handle of the input 3D object model.
        /// </summary>
        /// <param name="attribName">Name of the attributes.</param>
        /// <param name="attachExtAttribTo">Defines where extended attributes are attached to. Default: []</param>
        /// <param name="attribValues">Attribute values.</param>
        /// <returns>Handle of the resulting 3D object model.</returns>
        public HObjectModel3D SetObjectModel3dAttrib(
          string attribName,
          string attachExtAttribTo,
          double attribValues)
        {
            IntPtr proc = HalconAPI.PreCall(1064);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, attribName);
            HalconAPI.StoreS(proc, 2, attachExtAttribTo);
            HalconAPI.StoreD(proc, 3, attribValues);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HObjectModel3D hobjectModel3D;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobjectModel3D;
        }

        /// <summary>
        ///   Create an empty 3D object model.
        ///   Modified instance represents: Handle of the new 3D object model.
        /// </summary>
        public void GenEmptyObjectModel3d()
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1065);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>Sample a 3D object model.</summary>
        /// <param name="objectModel3D">Handle of the 3D object model to be sampled.</param>
        /// <param name="method">Selects between the different subsampling methods. Default: "fast"</param>
        /// <param name="sampleDistance">Sampling distance. Default: 0.05</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted. Default: []</param>
        /// <returns>Handle of the 3D object model that contains the sampled points.</returns>
        public static HObjectModel3D[] SampleObjectModel3d(
          HObjectModel3D[] objectModel3D,
          string method,
          HTuple sampleDistance,
          HTuple genParamName,
          HTuple genParamValue)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])objectModel3D);
            IntPtr proc = HalconAPI.PreCall(1066);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.StoreS(proc, 1, method);
            HalconAPI.Store(proc, 2, sampleDistance);
            HalconAPI.Store(proc, 3, genParamName);
            HalconAPI.Store(proc, 4, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(sampleDistance);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HObjectModel3D[] hobjectModel3DArray;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3DArray);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)objectModel3D);
            return hobjectModel3DArray;
        }

        /// <summary>
        ///   Sample a 3D object model.
        ///   Instance represents: Handle of the 3D object model to be sampled.
        /// </summary>
        /// <param name="method">Selects between the different subsampling methods. Default: "fast"</param>
        /// <param name="sampleDistance">Sampling distance. Default: 0.05</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted. Default: []</param>
        /// <returns>Handle of the 3D object model that contains the sampled points.</returns>
        public HObjectModel3D SampleObjectModel3d(
          string method,
          double sampleDistance,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1066);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, method);
            HalconAPI.StoreD(proc, 2, sampleDistance);
            HalconAPI.Store(proc, 3, genParamName);
            HalconAPI.Store(proc, 4, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HObjectModel3D hobjectModel3D;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobjectModel3D;
        }

        /// <summary>Improve the relative transformations between 3D object models based on their overlaps.</summary>
        /// <param name="objectModels3D">Handles of several 3D object models.</param>
        /// <param name="homMats3D">Approximate relative transformations between the 3D object models.</param>
        /// <param name="from">Type of interpretation for the transformations. Default: "global"</param>
        /// <param name="to">Target indices of the transformations if From specifies the source indices, otherwise the parameter must be empty. Default: []</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the global 3D object model registration. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the global 3D object model registration. Default: []</param>
        /// <param name="scores">Number of overlapping neighbors for each 3D object model.</param>
        /// <returns>Resulting Transformations.</returns>
        public static HHomMat3D[] RegisterObjectModel3dGlobal(
          HObjectModel3D[] objectModels3D,
          HHomMat3D[] homMats3D,
          HTuple from,
          HTuple to,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple scores)
        {
            HTuple htuple1 = HTool.ConcatArray((HTool[])objectModels3D);
            HTuple htuple2 = HData.ConcatArray((HData[])homMats3D);
            IntPtr proc = HalconAPI.PreCall(1067);
            HalconAPI.Store(proc, 0, htuple1);
            HalconAPI.Store(proc, 1, htuple2);
            HalconAPI.Store(proc, 2, from);
            HalconAPI.Store(proc, 3, to);
            HalconAPI.Store(proc, 4, genParamName);
            HalconAPI.Store(proc, 5, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple1);
            HalconAPI.UnpinTuple(htuple2);
            HalconAPI.UnpinTuple(from);
            HalconAPI.UnpinTuple(to);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out scores);
            HalconAPI.PostCall(proc, procResult);
            HHomMat3D[] hhomMat3DArray = HHomMat3D.SplitArray(tuple);
            GC.KeepAlive((object)objectModels3D);
            return hhomMat3DArray;
        }

        /// <summary>
        ///   Improve the relative transformations between 3D object models based on their overlaps.
        ///   Instance represents: Handles of several 3D object models.
        /// </summary>
        /// <param name="homMats3D">Approximate relative transformations between the 3D object models.</param>
        /// <param name="from">Type of interpretation for the transformations. Default: "global"</param>
        /// <param name="to">Target indices of the transformations if From specifies the source indices, otherwise the parameter must be empty. Default: []</param>
        /// <param name="genParamName">Names of the generic parameters that can be adjusted for the global 3D object model registration. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters that can be adjusted for the global 3D object model registration. Default: []</param>
        /// <param name="scores">Number of overlapping neighbors for each 3D object model.</param>
        /// <returns>Resulting Transformations.</returns>
        public HHomMat3D[] RegisterObjectModel3dGlobal(
          HHomMat3D[] homMats3D,
          string from,
          int to,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple scores)
        {
            HTuple htuple = HData.ConcatArray((HData[])homMats3D);
            IntPtr proc = HalconAPI.PreCall(1067);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, htuple);
            HalconAPI.StoreS(proc, 2, from);
            HalconAPI.StoreI(proc, 3, to);
            HalconAPI.Store(proc, 4, genParamName);
            HalconAPI.Store(proc, 5, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out scores);
            HalconAPI.PostCall(proc, procResult);
            HHomMat3D[] hhomMat3DArray = HHomMat3D.SplitArray(tuple);
            GC.KeepAlive((object)this);
            return hhomMat3DArray;
        }

        /// <summary>
        ///   Search for a transformation between two 3D object models.
        ///   Instance represents: Handle of the first 3D object model.
        /// </summary>
        /// <param name="objectModel3D2">Handle of the second 3D object model.</param>
        /// <param name="method">Method for the registration. Default: "matching"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="score">Overlapping of the two 3D object models.</param>
        /// <returns>Pose to transform ObjectModel3D1 in the reference frame of ObjectModel3D2.</returns>
        public HPose RegisterObjectModel3dPair(
          HObjectModel3D objectModel3D2,
          string method,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple score)
        {
            IntPtr proc = HalconAPI.PreCall(1068);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)objectModel3D2);
            HalconAPI.StoreS(proc, 2, method);
            HalconAPI.Store(proc, 3, genParamName);
            HalconAPI.Store(proc, 4, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HPose hpose;
            int err2 = HPose.LoadNew(proc, 0, err1, out hpose);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D2);
            return hpose;
        }

        /// <summary>
        ///   Search for a transformation between two 3D object models.
        ///   Instance represents: Handle of the first 3D object model.
        /// </summary>
        /// <param name="objectModel3D2">Handle of the second 3D object model.</param>
        /// <param name="method">Method for the registration. Default: "matching"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="score">Overlapping of the two 3D object models.</param>
        /// <returns>Pose to transform ObjectModel3D1 in the reference frame of ObjectModel3D2.</returns>
        public HPose RegisterObjectModel3dPair(
          HObjectModel3D objectModel3D2,
          string method,
          string genParamName,
          double genParamValue,
          out HTuple score)
        {
            IntPtr proc = HalconAPI.PreCall(1068);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)objectModel3D2);
            HalconAPI.StoreS(proc, 2, method);
            HalconAPI.StoreS(proc, 3, genParamName);
            HalconAPI.StoreD(proc, 4, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HPose hpose;
            int err2 = HPose.LoadNew(proc, 0, err1, out hpose);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out score);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectModel3D2);
            return hpose;
        }

        /// <summary>
        ///   Create a 3D object model that represents a point cloud from a set of 3D points.
        ///   Modified instance represents: Handle of the resulting 3D object model.
        /// </summary>
        /// <param name="x">The x-coordinates of the points in the 3D point cloud.</param>
        /// <param name="y">The y-coordinates of the points in the 3D point cloud.</param>
        /// <param name="z">The z-coordinates of the points in the 3D point cloud.</param>
        public void GenObjectModel3dFromPoints(HTuple x, HTuple y, HTuple z)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1069);
            HalconAPI.Store(proc, 0, x);
            HalconAPI.Store(proc, 1, y);
            HalconAPI.Store(proc, 2, z);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(x);
            HalconAPI.UnpinTuple(y);
            HalconAPI.UnpinTuple(z);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a 3D object model that represents a point cloud from a set of 3D points.
        ///   Modified instance represents: Handle of the resulting 3D object model.
        /// </summary>
        /// <param name="x">The x-coordinates of the points in the 3D point cloud.</param>
        /// <param name="y">The y-coordinates of the points in the 3D point cloud.</param>
        /// <param name="z">The z-coordinates of the points in the 3D point cloud.</param>
        public void GenObjectModel3dFromPoints(double x, double y, double z)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1069);
            HalconAPI.StoreD(proc, 0, x);
            HalconAPI.StoreD(proc, 1, y);
            HalconAPI.StoreD(proc, 2, z);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>Create a 3D object model that represents a box.</summary>
        /// <param name="pose">The pose that describes the position and orientation of the box.  The pose has its origin in the center of the box.</param>
        /// <param name="lengthX">The length of the box along the x-axis.</param>
        /// <param name="lengthY">The length of the box along the y-axis.</param>
        /// <param name="lengthZ">The length of the box along the z-axis.</param>
        /// <returns>Handle of the resulting 3D object model.</returns>
        public static HObjectModel3D[] GenBoxObjectModel3d(
          HPose[] pose,
          HTuple lengthX,
          HTuple lengthY,
          HTuple lengthZ)
        {
            HTuple htuple = HData.ConcatArray((HData[])pose);
            IntPtr proc = HalconAPI.PreCall(1070);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.Store(proc, 1, lengthX);
            HalconAPI.Store(proc, 2, lengthY);
            HalconAPI.Store(proc, 3, lengthZ);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(lengthX);
            HalconAPI.UnpinTuple(lengthY);
            HalconAPI.UnpinTuple(lengthZ);
            HObjectModel3D[] hobjectModel3DArray;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3DArray);
            HalconAPI.PostCall(proc, procResult);
            return hobjectModel3DArray;
        }

        /// <summary>
        ///   Create a 3D object model that represents a box.
        ///   Modified instance represents: Handle of the resulting 3D object model.
        /// </summary>
        /// <param name="pose">The pose that describes the position and orientation of the box.  The pose has its origin in the center of the box.</param>
        /// <param name="lengthX">The length of the box along the x-axis.</param>
        /// <param name="lengthY">The length of the box along the y-axis.</param>
        /// <param name="lengthZ">The length of the box along the z-axis.</param>
        public void GenBoxObjectModel3d(HPose pose, double lengthX, double lengthY, double lengthZ)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1070);
            HalconAPI.Store(proc, 0, (HData)pose);
            HalconAPI.StoreD(proc, 1, lengthX);
            HalconAPI.StoreD(proc, 2, lengthY);
            HalconAPI.StoreD(proc, 3, lengthZ);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)pose));
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a 3D object model that represents a plane.
        ///   Modified instance represents: Handle of the resulting 3D object model.
        /// </summary>
        /// <param name="pose">The center and the rotation of the plane.</param>
        /// <param name="XExtent">x coordinates specifying the extent of the plane.</param>
        /// <param name="YExtent">y coordinates specifying the extent of the plane.</param>
        public void GenPlaneObjectModel3d(HPose pose, HTuple XExtent, HTuple YExtent)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1071);
            HalconAPI.Store(proc, 0, (HData)pose);
            HalconAPI.Store(proc, 1, XExtent);
            HalconAPI.Store(proc, 2, YExtent);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)pose));
            HalconAPI.UnpinTuple(XExtent);
            HalconAPI.UnpinTuple(YExtent);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a 3D object model that represents a plane.
        ///   Modified instance represents: Handle of the resulting 3D object model.
        /// </summary>
        /// <param name="pose">The center and the rotation of the plane.</param>
        /// <param name="XExtent">x coordinates specifying the extent of the plane.</param>
        /// <param name="YExtent">y coordinates specifying the extent of the plane.</param>
        public void GenPlaneObjectModel3d(HPose pose, double XExtent, double YExtent)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1071);
            HalconAPI.Store(proc, 0, (HData)pose);
            HalconAPI.StoreD(proc, 1, XExtent);
            HalconAPI.StoreD(proc, 2, YExtent);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)pose));
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>Create a 3D object model that represents a sphere from x,y,z coordinates.</summary>
        /// <param name="x">The x-coordinate of the center point of the sphere.</param>
        /// <param name="y">The y-coordinate of the center point of the sphere.</param>
        /// <param name="z">The z-coordinate of the center point of the sphere.</param>
        /// <param name="radius">The radius of the sphere.</param>
        /// <returns>Handle of the resulting 3D object model.</returns>
        public static HObjectModel3D[] GenSphereObjectModel3dCenter(
          HTuple x,
          HTuple y,
          HTuple z,
          HTuple radius)
        {
            IntPtr proc = HalconAPI.PreCall(1072);
            HalconAPI.Store(proc, 0, x);
            HalconAPI.Store(proc, 1, y);
            HalconAPI.Store(proc, 2, z);
            HalconAPI.Store(proc, 3, radius);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(x);
            HalconAPI.UnpinTuple(y);
            HalconAPI.UnpinTuple(z);
            HalconAPI.UnpinTuple(radius);
            HObjectModel3D[] hobjectModel3DArray;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3DArray);
            HalconAPI.PostCall(proc, procResult);
            return hobjectModel3DArray;
        }

        /// <summary>
        ///   Create a 3D object model that represents a sphere from x,y,z coordinates.
        ///   Modified instance represents: Handle of the resulting 3D object model.
        /// </summary>
        /// <param name="x">The x-coordinate of the center point of the sphere.</param>
        /// <param name="y">The y-coordinate of the center point of the sphere.</param>
        /// <param name="z">The z-coordinate of the center point of the sphere.</param>
        /// <param name="radius">The radius of the sphere.</param>
        public void GenSphereObjectModel3dCenter(double x, double y, double z, double radius)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1072);
            HalconAPI.StoreD(proc, 0, x);
            HalconAPI.StoreD(proc, 1, y);
            HalconAPI.StoreD(proc, 2, z);
            HalconAPI.StoreD(proc, 3, radius);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>Create a 3D object model that represents a sphere.</summary>
        /// <param name="pose">The pose that describes the position of the sphere.</param>
        /// <param name="radius">The radius of the sphere.</param>
        /// <returns>Handle of the resulting 3D object model.</returns>
        public static HObjectModel3D[] GenSphereObjectModel3d(HPose[] pose, HTuple radius)
        {
            HTuple htuple = HData.ConcatArray((HData[])pose);
            IntPtr proc = HalconAPI.PreCall(1073);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.Store(proc, 1, radius);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(radius);
            HObjectModel3D[] hobjectModel3DArray;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3DArray);
            HalconAPI.PostCall(proc, procResult);
            return hobjectModel3DArray;
        }

        /// <summary>
        ///   Create a 3D object model that represents a sphere.
        ///   Modified instance represents: Handle of the resulting 3D object model.
        /// </summary>
        /// <param name="pose">The pose that describes the position of the sphere.</param>
        /// <param name="radius">The radius of the sphere.</param>
        public void GenSphereObjectModel3d(HPose pose, double radius)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1073);
            HalconAPI.Store(proc, 0, (HData)pose);
            HalconAPI.StoreD(proc, 1, radius);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)pose));
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>Create a 3D object model that represents a cylinder.</summary>
        /// <param name="pose">The pose that describes the position and orientation of the cylinder.</param>
        /// <param name="radius">The radius of the cylinder.</param>
        /// <param name="minExtent">The length of the cylinder in negative direction of the rotation axis.</param>
        /// <param name="maxExtent">The length of the cylinder in positive direction of the rotation axis.</param>
        /// <returns>Handle of the resulting 3D object model.</returns>
        public static HObjectModel3D[] GenCylinderObjectModel3d(
          HPose[] pose,
          HTuple radius,
          HTuple minExtent,
          HTuple maxExtent)
        {
            HTuple htuple = HData.ConcatArray((HData[])pose);
            IntPtr proc = HalconAPI.PreCall(1074);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.Store(proc, 1, radius);
            HalconAPI.Store(proc, 2, minExtent);
            HalconAPI.Store(proc, 3, maxExtent);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(radius);
            HalconAPI.UnpinTuple(minExtent);
            HalconAPI.UnpinTuple(maxExtent);
            HObjectModel3D[] hobjectModel3DArray;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3DArray);
            HalconAPI.PostCall(proc, procResult);
            return hobjectModel3DArray;
        }

        /// <summary>
        ///   Create a 3D object model that represents a cylinder.
        ///   Modified instance represents: Handle of the resulting 3D object model.
        /// </summary>
        /// <param name="pose">The pose that describes the position and orientation of the cylinder.</param>
        /// <param name="radius">The radius of the cylinder.</param>
        /// <param name="minExtent">The length of the cylinder in negative direction of the rotation axis.</param>
        /// <param name="maxExtent">The length of the cylinder in positive direction of the rotation axis.</param>
        public void GenCylinderObjectModel3d(
          HPose pose,
          double radius,
          double minExtent,
          double maxExtent)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1074);
            HalconAPI.Store(proc, 0, (HData)pose);
            HalconAPI.StoreD(proc, 1, radius);
            HalconAPI.StoreD(proc, 2, minExtent);
            HalconAPI.StoreD(proc, 3, maxExtent);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)pose));
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>Calculate the smallest bounding box around the points of a 3D object model.</summary>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <param name="type">The method that is used to estimate the smallest box. Default: "oriented"</param>
        /// <param name="length1">The length of the longest side of the box.</param>
        /// <param name="length2">The length of the second longest side of the box.</param>
        /// <param name="length3">The length of the third longest side of the box.</param>
        /// <returns>The pose that describes the position and orientation of the box that is generated. The pose has its origin in the center of the box and is oriented such that the x-axis is aligned with the longest side of the box.</returns>
        public static HPose[] SmallestBoundingBoxObjectModel3d(
          HObjectModel3D[] objectModel3D,
          string type,
          out HTuple length1,
          out HTuple length2,
          out HTuple length3)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])objectModel3D);
            IntPtr proc = HalconAPI.PreCall(1075);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.StoreS(proc, 1, type);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out length1);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out length2);
            int procResult = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out length3);
            HalconAPI.PostCall(proc, procResult);
            HPose[] hposeArray = HPose.SplitArray(tuple);
            GC.KeepAlive((object)objectModel3D);
            return hposeArray;
        }

        /// <summary>
        ///   Calculate the smallest bounding box around the points of a 3D object model.
        ///   Instance represents: Handle of the 3D object model.
        /// </summary>
        /// <param name="type">The method that is used to estimate the smallest box. Default: "oriented"</param>
        /// <param name="length1">The length of the longest side of the box.</param>
        /// <param name="length2">The length of the second longest side of the box.</param>
        /// <param name="length3">The length of the third longest side of the box.</param>
        /// <returns>The pose that describes the position and orientation of the box that is generated. The pose has its origin in the center of the box and is oriented such that the x-axis is aligned with the longest side of the box.</returns>
        public HPose SmallestBoundingBoxObjectModel3d(
          string type,
          out double length1,
          out double length2,
          out double length3)
        {
            IntPtr proc = HalconAPI.PreCall(1075);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, type);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            HPose hpose;
            int err2 = HPose.LoadNew(proc, 0, err1, out hpose);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out length1);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out length2);
            int procResult = HalconAPI.LoadD(proc, 3, err4, out length3);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hpose;
        }

        /// <summary>Calculate the smallest sphere around the points of a 3D object model.</summary>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <param name="radius">The estimated radius of the sphere.</param>
        /// <returns>x-, y-, and z-coordinates describing the center point of the sphere.</returns>
        public static HTuple SmallestSphereObjectModel3d(
          HObjectModel3D[] objectModel3D,
          out HTuple radius)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])objectModel3D);
            IntPtr proc = HalconAPI.PreCall(1076);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out radius);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)objectModel3D);
            return tuple;
        }

        /// <summary>
        ///   Calculate the smallest sphere around the points of a 3D object model.
        ///   Instance represents: Handle of the 3D object model.
        /// </summary>
        /// <param name="radius">The estimated radius of the sphere.</param>
        /// <returns>x-, y-, and z-coordinates describing the center point of the sphere.</returns>
        public HTuple SmallestSphereObjectModel3d(out double radius)
        {
            IntPtr proc = HalconAPI.PreCall(1076);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out radius);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>Intersect a 3D object model with a plane.</summary>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <param name="plane">Pose of the plane. Default: [0,0,0,0,0,0,0]</param>
        /// <returns>Handle of the 3D object model that describes the intersection as a set of lines.</returns>
        public static HObjectModel3D[] IntersectPlaneObjectModel3d(
          HObjectModel3D[] objectModel3D,
          HPose[] plane)
        {
            HTuple htuple1 = HTool.ConcatArray((HTool[])objectModel3D);
            HTuple htuple2 = HData.ConcatArray((HData[])plane);
            IntPtr proc = HalconAPI.PreCall(1077);
            HalconAPI.Store(proc, 0, htuple1);
            HalconAPI.Store(proc, 1, htuple2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple1);
            HalconAPI.UnpinTuple(htuple2);
            HObjectModel3D[] hobjectModel3DArray;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3DArray);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)objectModel3D);
            return hobjectModel3DArray;
        }

        /// <summary>
        ///   Intersect a 3D object model with a plane.
        ///   Instance represents: Handle of the 3D object model.
        /// </summary>
        /// <param name="plane">Pose of the plane. Default: [0,0,0,0,0,0,0]</param>
        /// <returns>Handle of the 3D object model that describes the intersection as a set of lines.</returns>
        public HObjectModel3D IntersectPlaneObjectModel3d(HPose plane)
        {
            IntPtr proc = HalconAPI.PreCall(1077);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)plane);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)plane));
            HObjectModel3D hobjectModel3D;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobjectModel3D;
        }

        /// <summary>Calculate the convex hull of a 3D object model. </summary>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <returns>Handle of the 3D object model that describes the convex hull.</returns>
        public static HObjectModel3D[] ConvexHullObjectModel3d(
          HObjectModel3D[] objectModel3D)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])objectModel3D);
            IntPtr proc = HalconAPI.PreCall(1078);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HObjectModel3D[] hobjectModel3DArray;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3DArray);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)objectModel3D);
            return hobjectModel3DArray;
        }

        /// <summary>
        ///   Calculate the convex hull of a 3D object model.
        ///   Instance represents: Handle of the 3D object model.
        /// </summary>
        /// <returns>Handle of the 3D object model that describes the convex hull.</returns>
        public HObjectModel3D ConvexHullObjectModel3d()
        {
            IntPtr proc = HalconAPI.PreCall(1078);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HObjectModel3D hobjectModel3D;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobjectModel3D;
        }

        /// <summary>Select 3D object models from an array of 3D object models according to global features.</summary>
        /// <param name="objectModel3D">Handles of the available 3D object models to select.</param>
        /// <param name="feature">List of features a test is performed on. Default: "has_triangles"</param>
        /// <param name="operation">Logical operation to combine the features given in Feature. Default: "and"</param>
        /// <param name="minValue">Minimum value for the given feature. Default: 1</param>
        /// <param name="maxValue">Maximum value for the given feature. Default: 1</param>
        /// <returns>A subset of ObjectModel3D fulfilling the given conditions.</returns>
        public static HObjectModel3D[] SelectObjectModel3d(
          HObjectModel3D[] objectModel3D,
          HTuple feature,
          string operation,
          HTuple minValue,
          HTuple maxValue)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])objectModel3D);
            IntPtr proc = HalconAPI.PreCall(1079);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.Store(proc, 1, feature);
            HalconAPI.StoreS(proc, 2, operation);
            HalconAPI.Store(proc, 3, minValue);
            HalconAPI.Store(proc, 4, maxValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(feature);
            HalconAPI.UnpinTuple(minValue);
            HalconAPI.UnpinTuple(maxValue);
            HObjectModel3D[] hobjectModel3DArray;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3DArray);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)objectModel3D);
            return hobjectModel3DArray;
        }

        /// <summary>
        ///   Select 3D object models from an array of 3D object models according to global features.
        ///   Instance represents: Handles of the available 3D object models to select.
        /// </summary>
        /// <param name="feature">List of features a test is performed on. Default: "has_triangles"</param>
        /// <param name="operation">Logical operation to combine the features given in Feature. Default: "and"</param>
        /// <param name="minValue">Minimum value for the given feature. Default: 1</param>
        /// <param name="maxValue">Maximum value for the given feature. Default: 1</param>
        /// <returns>A subset of ObjectModel3D fulfilling the given conditions.</returns>
        public HObjectModel3D SelectObjectModel3d(
          string feature,
          string operation,
          double minValue,
          double maxValue)
        {
            IntPtr proc = HalconAPI.PreCall(1079);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, feature);
            HalconAPI.StoreS(proc, 2, operation);
            HalconAPI.StoreD(proc, 3, minValue);
            HalconAPI.StoreD(proc, 4, maxValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HObjectModel3D hobjectModel3D;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobjectModel3D;
        }

        /// <summary>Calculate the area of all faces of a 3D object model.</summary>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <returns>Calculated area.</returns>
        public static HTuple AreaObjectModel3d(HObjectModel3D[] objectModel3D)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])objectModel3D);
            IntPtr proc = HalconAPI.PreCall(1080);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)objectModel3D);
            return tuple;
        }

        /// <summary>
        ///   Calculate the area of all faces of a 3D object model.
        ///   Instance represents: Handle of the 3D object model.
        /// </summary>
        /// <returns>Calculated area.</returns>
        public double AreaObjectModel3d()
        {
            IntPtr proc = HalconAPI.PreCall(1080);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>Calculate the maximal diameter of a 3D object model.</summary>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <returns>Calculated diameter.</returns>
        public static HTuple MaxDiameterObjectModel3d(HObjectModel3D[] objectModel3D)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])objectModel3D);
            IntPtr proc = HalconAPI.PreCall(1081);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)objectModel3D);
            return tuple;
        }

        /// <summary>
        ///   Calculate the maximal diameter of a 3D object model.
        ///   Instance represents: Handle of the 3D object model.
        /// </summary>
        /// <returns>Calculated diameter.</returns>
        public double MaxDiameterObjectModel3d()
        {
            IntPtr proc = HalconAPI.PreCall(1081);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>Calculates the mean or the central moment of second order for a 3D object model.</summary>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <param name="momentsToCalculate">Moment to calculate. Default: "mean_points"</param>
        /// <returns>Calculated moment.</returns>
        public static HTuple MomentsObjectModel3d(
          HObjectModel3D[] objectModel3D,
          HTuple momentsToCalculate)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])objectModel3D);
            IntPtr proc = HalconAPI.PreCall(1082);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.Store(proc, 1, momentsToCalculate);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(momentsToCalculate);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)objectModel3D);
            return tuple;
        }

        /// <summary>
        ///   Calculates the mean or the central moment of second order for a 3D object model.
        ///   Instance represents: Handle of the 3D object model.
        /// </summary>
        /// <param name="momentsToCalculate">Moment to calculate. Default: "mean_points"</param>
        /// <returns>Calculated moment.</returns>
        public double MomentsObjectModel3d(string momentsToCalculate)
        {
            IntPtr proc = HalconAPI.PreCall(1082);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, momentsToCalculate);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>Calculate the volume of a 3D object model.</summary>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <param name="plane">Pose of the plane. Default: [0,0,0,0,0,0,0]</param>
        /// <param name="mode">Method to combine volumes laying above and below the reference plane. Default: "signed"</param>
        /// <param name="useFaceOrientation">Decides whether the orientation of a face should affect the resulting sign of the underlying volume. Default: "true"</param>
        /// <returns>Absolute value of the calculated volume.</returns>
        public static HTuple VolumeObjectModel3dRelativeToPlane(
          HObjectModel3D[] objectModel3D,
          HPose[] plane,
          HTuple mode,
          HTuple useFaceOrientation)
        {
            HTuple htuple1 = HTool.ConcatArray((HTool[])objectModel3D);
            HTuple htuple2 = HData.ConcatArray((HData[])plane);
            IntPtr proc = HalconAPI.PreCall(1083);
            HalconAPI.Store(proc, 0, htuple1);
            HalconAPI.Store(proc, 1, htuple2);
            HalconAPI.Store(proc, 2, mode);
            HalconAPI.Store(proc, 3, useFaceOrientation);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple1);
            HalconAPI.UnpinTuple(htuple2);
            HalconAPI.UnpinTuple(mode);
            HalconAPI.UnpinTuple(useFaceOrientation);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)objectModel3D);
            return tuple;
        }

        /// <summary>
        ///   Calculate the volume of a 3D object model.
        ///   Instance represents: Handle of the 3D object model.
        /// </summary>
        /// <param name="plane">Pose of the plane. Default: [0,0,0,0,0,0,0]</param>
        /// <param name="mode">Method to combine volumes laying above and below the reference plane. Default: "signed"</param>
        /// <param name="useFaceOrientation">Decides whether the orientation of a face should affect the resulting sign of the underlying volume. Default: "true"</param>
        /// <returns>Absolute value of the calculated volume.</returns>
        public double VolumeObjectModel3dRelativeToPlane(
          HPose plane,
          string mode,
          string useFaceOrientation)
        {
            IntPtr proc = HalconAPI.PreCall(1083);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)plane);
            HalconAPI.StoreS(proc, 2, mode);
            HalconAPI.StoreS(proc, 3, useFaceOrientation);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)plane));
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
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
        ///   Instance represents: Handle of the 3D object model.
        /// </summary>
        /// <param name="region">Region in the image plane.</param>
        /// <param name="camParam">Internal camera parameters.</param>
        /// <param name="pose">3D pose of the world coordinate system in camera coordinates.</param>
        /// <returns>Handle of the reduced 3D object model.</returns>
        public HObjectModel3D ReduceObjectModel3dByView(
          HRegion region,
          HCamPar camParam,
          HPose pose)
        {
            IntPtr proc = HalconAPI.PreCall(1084);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)region);
            HalconAPI.Store(proc, 1, (HData)camParam);
            HalconAPI.Store(proc, 2, (HData)pose);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
            HalconAPI.UnpinTuple((HTuple)((HData)pose));
            HObjectModel3D hobjectModel3D;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)region);
            return hobjectModel3D;
        }

        /// <summary>Determine the connected components of the 3D object model.</summary>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <param name="feature">Attribute used to calculate the connected components. Default: "distance_3d"</param>
        /// <param name="value">Maximum value for the distance between two connected components. Default: 1.0</param>
        /// <returns>Handle of the 3D object models that represent the connected components.</returns>
        public static HObjectModel3D[] ConnectionObjectModel3d(
          HObjectModel3D[] objectModel3D,
          HTuple feature,
          HTuple value)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])objectModel3D);
            IntPtr proc = HalconAPI.PreCall(1085);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.Store(proc, 1, feature);
            HalconAPI.Store(proc, 2, value);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(feature);
            HalconAPI.UnpinTuple(value);
            HObjectModel3D[] hobjectModel3DArray;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3DArray);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)objectModel3D);
            return hobjectModel3DArray;
        }

        /// <summary>
        ///   Determine the connected components of the 3D object model.
        ///   Instance represents: Handle of the 3D object model.
        /// </summary>
        /// <param name="feature">Attribute used to calculate the connected components. Default: "distance_3d"</param>
        /// <param name="value">Maximum value for the distance between two connected components. Default: 1.0</param>
        /// <returns>Handle of the 3D object models that represent the connected components.</returns>
        public HObjectModel3D[] ConnectionObjectModel3d(string feature, double value)
        {
            IntPtr proc = HalconAPI.PreCall(1085);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, feature);
            HalconAPI.StoreD(proc, 2, value);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HObjectModel3D[] hobjectModel3DArray;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3DArray);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobjectModel3DArray;
        }

        /// <summary>Apply a threshold to an attribute of 3D object models.</summary>
        /// <param name="objectModel3D">Handle of the 3D object models.</param>
        /// <param name="attrib">Attributes the threshold is applied to. Default: "point_coord_z"</param>
        /// <param name="minValue">Minimum value for the attributes specified by Attrib. Default: 0.5</param>
        /// <param name="maxValue">Maximum value for the attributes specified by Attrib. Default: 1.0</param>
        /// <returns>Handle of the reduced 3D object models.</returns>
        public static HObjectModel3D[] SelectPointsObjectModel3d(
          HObjectModel3D[] objectModel3D,
          HTuple attrib,
          HTuple minValue,
          HTuple maxValue)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])objectModel3D);
            IntPtr proc = HalconAPI.PreCall(1086);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.Store(proc, 1, attrib);
            HalconAPI.Store(proc, 2, minValue);
            HalconAPI.Store(proc, 3, maxValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(attrib);
            HalconAPI.UnpinTuple(minValue);
            HalconAPI.UnpinTuple(maxValue);
            HObjectModel3D[] hobjectModel3DArray;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3DArray);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)objectModel3D);
            return hobjectModel3DArray;
        }

        /// <summary>
        ///   Apply a threshold to an attribute of 3D object models.
        ///   Instance represents: Handle of the 3D object models.
        /// </summary>
        /// <param name="attrib">Attributes the threshold is applied to. Default: "point_coord_z"</param>
        /// <param name="minValue">Minimum value for the attributes specified by Attrib. Default: 0.5</param>
        /// <param name="maxValue">Maximum value for the attributes specified by Attrib. Default: 1.0</param>
        /// <returns>Handle of the reduced 3D object models.</returns>
        public HObjectModel3D SelectPointsObjectModel3d(
          string attrib,
          double minValue,
          double maxValue)
        {
            IntPtr proc = HalconAPI.PreCall(1086);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, attrib);
            HalconAPI.StoreD(proc, 2, minValue);
            HalconAPI.StoreD(proc, 3, maxValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HObjectModel3D hobjectModel3D;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobjectModel3D;
        }

        /// <summary>Get the depth or the index of a displayed 3D object model.</summary>
        /// <param name="windowHandle">Window handle.</param>
        /// <param name="row">Row coordinates.</param>
        /// <param name="column">Column coordinates.</param>
        /// <param name="information">Information. Default: "depth"</param>
        /// <returns>Indices or the depth of the objects at (Row,Column).</returns>
        public static HTuple GetDispObjectModel3dInfo(
          HWindow windowHandle,
          HTuple row,
          HTuple column,
          HTuple information)
        {
            IntPtr proc = HalconAPI.PreCall(1087);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            HalconAPI.Store(proc, 1, row);
            HalconAPI.Store(proc, 2, column);
            HalconAPI.Store(proc, 3, information);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.UnpinTuple(information);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)windowHandle);
            return tuple;
        }

        /// <summary>Get the depth or the index of a displayed 3D object model.</summary>
        /// <param name="windowHandle">Window handle.</param>
        /// <param name="row">Row coordinates.</param>
        /// <param name="column">Column coordinates.</param>
        /// <param name="information">Information. Default: "depth"</param>
        /// <returns>Indices or the depth of the objects at (Row,Column).</returns>
        public static int GetDispObjectModel3dInfo(
          HWindow windowHandle,
          double row,
          double column,
          string information)
        {
            IntPtr proc = HalconAPI.PreCall(1087);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            HalconAPI.StoreD(proc, 1, row);
            HalconAPI.StoreD(proc, 2, column);
            HalconAPI.StoreS(proc, 3, information);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)windowHandle);
            return intValue;
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
        ///   Instance represents: Handles of the 3D object models.
        /// </summary>
        /// <param name="camParam">Camera parameters of the scene.</param>
        /// <param name="pose">3D poses of the objects.</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <returns>Rendered scene.</returns>
        public HImage RenderObjectModel3d(
          HCamPar camParam,
          HPose pose,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1088);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)camParam);
            HalconAPI.Store(proc, 2, (HData)pose);
            HalconAPI.Store(proc, 3, genParamName);
            HalconAPI.Store(proc, 4, genParamValue);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
            HalconAPI.UnpinTuple((HTuple)((HData)pose));
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
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
        ///   Instance represents: Handles of the 3D object models.
        /// </summary>
        /// <param name="windowHandle">Window handle.</param>
        /// <param name="camParam">Camera parameters of the scene. Default: []</param>
        /// <param name="pose">3D poses of the objects. Default: []</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        public void DispObjectModel3d(
          HWindow windowHandle,
          HCamPar camParam,
          HPose pose,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1089);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            HalconAPI.Store(proc, 2, (HData)camParam);
            HalconAPI.Store(proc, 3, (HData)pose);
            HalconAPI.Store(proc, 4, genParamName);
            HalconAPI.Store(proc, 5, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
            HalconAPI.UnpinTuple((HTuple)((HData)pose));
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)windowHandle);
        }

        /// <summary>
        ///   Copy a 3D object model.
        ///   Instance represents: Handle of the input 3D object model.
        /// </summary>
        /// <param name="attributes">Attributes to be copied. Default: "all"</param>
        /// <returns>Handle of the copied 3D object model.</returns>
        public HObjectModel3D CopyObjectModel3d(HTuple attributes)
        {
            IntPtr proc = HalconAPI.PreCall(1090);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, attributes);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(attributes);
            HObjectModel3D hobjectModel3D;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobjectModel3D;
        }

        /// <summary>
        ///   Copy a 3D object model.
        ///   Instance represents: Handle of the input 3D object model.
        /// </summary>
        /// <param name="attributes">Attributes to be copied. Default: "all"</param>
        /// <returns>Handle of the copied 3D object model.</returns>
        public HObjectModel3D CopyObjectModel3d(string attributes)
        {
            IntPtr proc = HalconAPI.PreCall(1090);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, attributes);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HObjectModel3D hobjectModel3D;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobjectModel3D;
        }

        /// <summary>Prepare a 3D object model for a certain operation.</summary>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <param name="purpose">Purpose of the 3D object model. Default: "shape_based_matching_3d"</param>
        /// <param name="overwriteData">Specify if already existing data should be overwritten. Default: "true"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        public static void PrepareObjectModel3d(
          HObjectModel3D[] objectModel3D,
          string purpose,
          string overwriteData,
          HTuple genParamName,
          HTuple genParamValue)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])objectModel3D);
            IntPtr proc = HalconAPI.PreCall(1091);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.StoreS(proc, 1, purpose);
            HalconAPI.StoreS(proc, 2, overwriteData);
            HalconAPI.Store(proc, 3, genParamName);
            HalconAPI.Store(proc, 4, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)objectModel3D);
        }

        /// <summary>
        ///   Prepare a 3D object model for a certain operation.
        ///   Instance represents: Handle of the 3D object model.
        /// </summary>
        /// <param name="purpose">Purpose of the 3D object model. Default: "shape_based_matching_3d"</param>
        /// <param name="overwriteData">Specify if already existing data should be overwritten. Default: "true"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        public void PrepareObjectModel3d(
          string purpose,
          string overwriteData,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1091);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, purpose);
            HalconAPI.StoreS(proc, 2, overwriteData);
            HalconAPI.Store(proc, 3, genParamName);
            HalconAPI.Store(proc, 4, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Transform 3D points from a 3D object model to images.
        ///   Instance represents: Handle of the 3D object model.
        /// </summary>
        /// <param name="y">Image with the Y-Coordinates of the 3D points.</param>
        /// <param name="z">Image with the Z-Coordinates of the 3D points.</param>
        /// <param name="type">Type of the conversion. Default: "cartesian"</param>
        /// <param name="camParam">Camera parameters.</param>
        /// <param name="pose">Pose of the 3D object model.</param>
        /// <returns>Image with the X-Coordinates of the 3D points.</returns>
        public HImage ObjectModel3dToXyz(
          out HImage y,
          out HImage z,
          string type,
          HCamPar camParam,
          HPose pose)
        {
            IntPtr proc = HalconAPI.PreCall(1092);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, type);
            HalconAPI.Store(proc, 2, (HData)camParam);
            HalconAPI.Store(proc, 3, (HData)pose);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
            HalconAPI.UnpinTuple((HTuple)((HData)pose));
            HImage himage;
            int err2 = HImage.LoadNew(proc, 1, err1, out himage);
            int err3 = HImage.LoadNew(proc, 2, err2, out y);
            int procResult = HImage.LoadNew(proc, 3, err3, out z);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>
        ///   Transform 3D points from images to a 3D object model.
        ///   Modified instance represents: Handle of the 3D object model.
        /// </summary>
        /// <param name="x">Image with the X-Coordinates and the ROI of the 3D points.</param>
        /// <param name="y">Image with the Y-Coordinates of the 3D points.</param>
        /// <param name="z">Image with the Z-Coordinates of the 3D points.</param>
        public void XyzToObjectModel3d(HImage x, HImage y, HImage z)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1093);
            HalconAPI.Store(proc, 1, (HObjectBase)x);
            HalconAPI.Store(proc, 2, (HObjectBase)y);
            HalconAPI.Store(proc, 3, (HObjectBase)z);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)x);
            GC.KeepAlive((object)y);
            GC.KeepAlive((object)z);
        }

        /// <summary>Return attributes of 3D object models.</summary>
        /// <param name="objectModel3D">Handle of the 3D object model.</param>
        /// <param name="genParamName">Names of the generic attributes that are queried for the 3D object model. Default: "num_points"</param>
        /// <returns>Values of the generic parameters.</returns>
        public static HTuple GetObjectModel3dParams(
          HObjectModel3D[] objectModel3D,
          HTuple genParamName)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])objectModel3D);
            IntPtr proc = HalconAPI.PreCall(1094);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.Store(proc, 1, genParamName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(genParamName);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)objectModel3D);
            return tuple;
        }

        /// <summary>
        ///   Return attributes of 3D object models.
        ///   Instance represents: Handle of the 3D object model.
        /// </summary>
        /// <param name="genParamName">Names of the generic attributes that are queried for the 3D object model. Default: "num_points"</param>
        /// <returns>Values of the generic parameters.</returns>
        public HTuple GetObjectModel3dParams(HTuple genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(1094);
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
        ///   Project a 3D object model into image coordinates.
        ///   Instance represents: Handle of the 3D object model.
        /// </summary>
        /// <param name="camParam">Internal camera parameters.</param>
        /// <param name="pose">3D pose of the world coordinate system in camera coordinates.</param>
        /// <param name="genParamName">Name of the generic parameter. Default: []</param>
        /// <param name="genParamValue">Value of the generic parameter. Default: []</param>
        /// <returns>Projected model contours.</returns>
        public HXLDCont ProjectObjectModel3d(
          HCamPar camParam,
          HPose pose,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1095);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)camParam);
            HalconAPI.Store(proc, 2, (HData)pose);
            HalconAPI.Store(proc, 3, genParamName);
            HalconAPI.Store(proc, 4, genParamValue);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)camParam));
            HalconAPI.UnpinTuple((HTuple)((HData)pose));
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hxldCont;
        }

        /// <summary>
        ///   Project a 3D object model into image coordinates.
        ///   Instance represents: Handle of the 3D object model.
        /// </summary>
        /// <param name="camParam">Internal camera parameters.</param>
        /// <param name="pose">3D pose of the world coordinate system in camera coordinates.</param>
        /// <param name="genParamName">Name of the generic parameter. Default: []</param>
        /// <param name="genParamValue">Value of the generic parameter. Default: []</param>
        /// <returns>Projected model contours.</returns>
        public HXLDCont ProjectObjectModel3d(
          HCamPar camParam,
          HPose pose,
          string genParamName,
          string genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1095);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)camParam);
            HalconAPI.Store(proc, 2, (HData)pose);
            HalconAPI.StoreS(proc, 3, genParamName);
            HalconAPI.StoreS(proc, 4, genParamValue);
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

        /// <summary>Apply a rigid 3D transformation to 3D object models.</summary>
        /// <param name="objectModel3D">Handles of the 3D object models.</param>
        /// <param name="pose">Poses.</param>
        /// <returns>Handles of the transformed 3D object models.</returns>
        public static HObjectModel3D[] RigidTransObjectModel3d(
          HObjectModel3D[] objectModel3D,
          HPose[] pose)
        {
            HTuple htuple1 = HTool.ConcatArray((HTool[])objectModel3D);
            HTuple htuple2 = HData.ConcatArray((HData[])pose);
            IntPtr proc = HalconAPI.PreCall(1096);
            HalconAPI.Store(proc, 0, htuple1);
            HalconAPI.Store(proc, 1, htuple2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple1);
            HalconAPI.UnpinTuple(htuple2);
            HObjectModel3D[] hobjectModel3DArray;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3DArray);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)objectModel3D);
            return hobjectModel3DArray;
        }

        /// <summary>
        ///   Apply a rigid 3D transformation to 3D object models.
        ///   Instance represents: Handles of the 3D object models.
        /// </summary>
        /// <param name="pose">Poses.</param>
        /// <returns>Handles of the transformed 3D object models.</returns>
        public HObjectModel3D RigidTransObjectModel3d(HPose pose)
        {
            IntPtr proc = HalconAPI.PreCall(1096);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)pose);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)pose));
            HObjectModel3D hobjectModel3D;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobjectModel3D;
        }

        /// <summary>Apply an arbitrary projective 3D transformation to 3D object models.</summary>
        /// <param name="objectModel3D">Handles of the 3D object models.</param>
        /// <param name="homMat3D">Homogeneous projective transformation matrix.</param>
        /// <returns>Handles of the transformed 3D object models.</returns>
        public static HObjectModel3D[] ProjectiveTransObjectModel3d(
          HObjectModel3D[] objectModel3D,
          HHomMat3D homMat3D)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])objectModel3D);
            IntPtr proc = HalconAPI.PreCall(1097);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.Store(proc, 1, (HData)homMat3D);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple((HTuple)((HData)homMat3D));
            HObjectModel3D[] hobjectModel3DArray;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3DArray);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)objectModel3D);
            return hobjectModel3DArray;
        }

        /// <summary>
        ///   Apply an arbitrary projective 3D transformation to 3D object models.
        ///   Instance represents: Handles of the 3D object models.
        /// </summary>
        /// <param name="homMat3D">Homogeneous projective transformation matrix.</param>
        /// <returns>Handles of the transformed 3D object models.</returns>
        public HObjectModel3D ProjectiveTransObjectModel3d(HHomMat3D homMat3D)
        {
            IntPtr proc = HalconAPI.PreCall(1097);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)homMat3D);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)homMat3D));
            HObjectModel3D hobjectModel3D;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobjectModel3D;
        }

        /// <summary>Apply an arbitrary affine 3D transformation to 3D object models.</summary>
        /// <param name="objectModel3D">Handles of the 3D object models.</param>
        /// <param name="homMat3D">Transformation matrices.</param>
        /// <returns>Handles of the transformed 3D object models.</returns>
        public static HObjectModel3D[] AffineTransObjectModel3d(
          HObjectModel3D[] objectModel3D,
          HHomMat3D[] homMat3D)
        {
            HTuple htuple1 = HTool.ConcatArray((HTool[])objectModel3D);
            HTuple htuple2 = HData.ConcatArray((HData[])homMat3D);
            IntPtr proc = HalconAPI.PreCall(1098);
            HalconAPI.Store(proc, 0, htuple1);
            HalconAPI.Store(proc, 1, htuple2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple1);
            HalconAPI.UnpinTuple(htuple2);
            HObjectModel3D[] hobjectModel3DArray;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3DArray);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)objectModel3D);
            return hobjectModel3DArray;
        }

        /// <summary>
        ///   Apply an arbitrary affine 3D transformation to 3D object models.
        ///   Instance represents: Handles of the 3D object models.
        /// </summary>
        /// <param name="homMat3D">Transformation matrices.</param>
        /// <returns>Handles of the transformed 3D object models.</returns>
        public HObjectModel3D AffineTransObjectModel3d(HHomMat3D homMat3D)
        {
            IntPtr proc = HalconAPI.PreCall(1098);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)homMat3D);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)homMat3D));
            HObjectModel3D hobjectModel3D;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobjectModel3D;
        }

        /// <summary>
        ///   Serialize a 3D object model.
        ///   Instance represents: Handle of the 3D object model.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeObjectModel3d()
        {
            IntPtr proc = HalconAPI.PreCall(1101);
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
        ///   Deserialize a serialized 3D object model.
        ///   Modified instance represents: Handle of the 3D object model.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeObjectModel3d(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1102);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Writes a 3D object model to a file.
        ///   Instance represents: Handle of the 3D object model.
        /// </summary>
        /// <param name="fileType">Type of the file that is written. Default: "om3"</param>
        /// <param name="fileName">Name of the file that is written.</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        public void WriteObjectModel3d(
          string fileType,
          string fileName,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1103);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileType);
            HalconAPI.StoreS(proc, 2, fileName);
            HalconAPI.Store(proc, 3, genParamName);
            HalconAPI.Store(proc, 4, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Writes a 3D object model to a file.
        ///   Instance represents: Handle of the 3D object model.
        /// </summary>
        /// <param name="fileType">Type of the file that is written. Default: "om3"</param>
        /// <param name="fileName">Name of the file that is written.</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        public void WriteObjectModel3d(
          string fileType,
          string fileName,
          string genParamName,
          string genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(1103);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileType);
            HalconAPI.StoreS(proc, 2, fileName);
            HalconAPI.StoreS(proc, 3, genParamName);
            HalconAPI.StoreS(proc, 4, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Read a 3D object model from a file.
        ///   Modified instance represents: Handle of the 3D object model.
        /// </summary>
        /// <param name="fileName">Filename of the file to be read.</param>
        /// <param name="scale">Scale of the data in the file. Default: "m"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <returns>Status information.</returns>
        public HTuple ReadObjectModel3d(
          string fileName,
          HTuple scale,
          HTuple genParamName,
          HTuple genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1104);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.Store(proc, 1, scale);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(scale);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int err2 = this.Load(proc, 0, err1);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 1, err2, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Read a 3D object model from a file.
        ///   Modified instance represents: Handle of the 3D object model.
        /// </summary>
        /// <param name="fileName">Filename of the file to be read.</param>
        /// <param name="scale">Scale of the data in the file. Default: "m"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <returns>Status information.</returns>
        public string ReadObjectModel3d(
          string fileName,
          string scale,
          string genParamName,
          string genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1104);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.StoreS(proc, 1, scale);
            HalconAPI.StoreS(proc, 2, genParamName);
            HalconAPI.StoreS(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = this.Load(proc, 0, err1);
            string stringValue;
            int procResult = HalconAPI.LoadS(proc, 1, err2, out stringValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return stringValue;
        }

        /// <summary>Compute the calibrated scene flow between two stereo image pairs.</summary>
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
        /// <param name="relPoseRect">Pose of the rectified camera 2 in relation to the rectified camera 1.</param>
        /// <returns>Handle of the 3D object model.</returns>
        public static HObjectModel3D[] SceneFlowCalib(
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
          HCamPar camParamRect2,
          HPose relPoseRect)
        {
            IntPtr proc = HalconAPI.PreCall(1481);
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
            HalconAPI.Store(proc, 6, (HData)relPoseRect);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(smoothingFlow);
            HalconAPI.UnpinTuple(smoothingDisparity);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect1));
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect2));
            HalconAPI.UnpinTuple((HTuple)((HData)relPoseRect));
            HObjectModel3D[] hobjectModel3DArray;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3DArray);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)imageRect1T1);
            GC.KeepAlive((object)imageRect2T1);
            GC.KeepAlive((object)imageRect1T2);
            GC.KeepAlive((object)imageRect2T2);
            GC.KeepAlive((object)disparity);
            return hobjectModel3DArray;
        }

        /// <summary>
        ///   Compute the calibrated scene flow between two stereo image pairs.
        ///   Modified instance represents: Handle of the 3D object model.
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
        /// <param name="relPoseRect">Pose of the rectified camera 2 in relation to the rectified camera 1.</param>
        public void SceneFlowCalib(
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
          HCamPar camParamRect2,
          HPose relPoseRect)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1481);
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
            HalconAPI.Store(proc, 6, (HData)relPoseRect);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect1));
            HalconAPI.UnpinTuple((HTuple)((HData)camParamRect2));
            HalconAPI.UnpinTuple((HTuple)((HData)relPoseRect));
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)imageRect1T1);
            GC.KeepAlive((object)imageRect2T1);
            GC.KeepAlive((object)imageRect1T2);
            GC.KeepAlive((object)imageRect2T2);
            GC.KeepAlive((object)disparity);
        }

        /// <summary>
        ///   Find edges in a 3D object model.
        ///   Instance represents: Handle of the 3D object model whose edges should be computed.
        /// </summary>
        /// <param name="minAmplitude">Edge threshold.</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <returns>3D object model containing the edges.</returns>
        public HObjectModel3D EdgesObjectModel3d(
          HTuple minAmplitude,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(2067);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, minAmplitude);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(minAmplitude);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HObjectModel3D hobjectModel3D;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobjectModel3D;
        }

        /// <summary>
        ///   Find edges in a 3D object model.
        ///   Instance represents: Handle of the 3D object model whose edges should be computed.
        /// </summary>
        /// <param name="minAmplitude">Edge threshold.</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <returns>3D object model containing the edges.</returns>
        public HObjectModel3D EdgesObjectModel3d(
          double minAmplitude,
          string genParamName,
          double genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(2067);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, minAmplitude);
            HalconAPI.StoreS(proc, 2, genParamName);
            HalconAPI.StoreD(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HObjectModel3D hobjectModel3D;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobjectModel3D;
        }

        /// <summary>
        ///   Find the best matches of a surface model in a 3D scene and images.
        ///   Instance represents: Handle of the 3D object model containing the scene.
        /// </summary>
        /// <param name="image">Images of the scene.</param>
        /// <param name="surfaceModelID">Handle of the surface model.</param>
        /// <param name="relSamplingDistance">Scene sampling distance relative to the diameter of the surface model. Default: 0.05</param>
        /// <param name="keyPointFraction">Fraction of sampled scene points used as key points. Default: 0.2</param>
        /// <param name="minScore">Minimum score of the returned poses. Default: 0</param>
        /// <param name="returnResultHandle">Enable returning a result handle in SurfaceMatchingResultID. Default: "false"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="score">Score of the found instances of the surface model.</param>
        /// <param name="surfaceMatchingResultID">Handle of the matching result, if enabled in ReturnResultHandle.</param>
        /// <returns>3D pose of the surface model in the scene.</returns>
        public HPose[] FindSurfaceModelImage(
          HImage image,
          HSurfaceModel surfaceModelID,
          double relSamplingDistance,
          double keyPointFraction,
          HTuple minScore,
          string returnResultHandle,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple score,
          out HSurfaceMatchingResult[] surfaceMatchingResultID)
        {
            IntPtr proc = HalconAPI.PreCall(2069);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)surfaceModelID);
            HalconAPI.StoreD(proc, 2, relSamplingDistance);
            HalconAPI.StoreD(proc, 3, keyPointFraction);
            HalconAPI.Store(proc, 4, minScore);
            HalconAPI.StoreS(proc, 5, returnResultHandle);
            HalconAPI.Store(proc, 6, genParamName);
            HalconAPI.Store(proc, 7, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(minScore);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out score);
            int procResult = HSurfaceMatchingResult.LoadNew(proc, 2, err3, out surfaceMatchingResultID);
            HalconAPI.PostCall(proc, procResult);
            HPose[] hposeArray = HPose.SplitArray(tuple);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)surfaceModelID);
            return hposeArray;
        }

        /// <summary>
        ///   Find the best matches of a surface model in a 3D scene and images.
        ///   Instance represents: Handle of the 3D object model containing the scene.
        /// </summary>
        /// <param name="image">Images of the scene.</param>
        /// <param name="surfaceModelID">Handle of the surface model.</param>
        /// <param name="relSamplingDistance">Scene sampling distance relative to the diameter of the surface model. Default: 0.05</param>
        /// <param name="keyPointFraction">Fraction of sampled scene points used as key points. Default: 0.2</param>
        /// <param name="minScore">Minimum score of the returned poses. Default: 0</param>
        /// <param name="returnResultHandle">Enable returning a result handle in SurfaceMatchingResultID. Default: "false"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="score">Score of the found instances of the surface model.</param>
        /// <param name="surfaceMatchingResultID">Handle of the matching result, if enabled in ReturnResultHandle.</param>
        /// <returns>3D pose of the surface model in the scene.</returns>
        public HPose FindSurfaceModelImage(
          HImage image,
          HSurfaceModel surfaceModelID,
          double relSamplingDistance,
          double keyPointFraction,
          double minScore,
          string returnResultHandle,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple score,
          out HSurfaceMatchingResult surfaceMatchingResultID)
        {
            IntPtr proc = HalconAPI.PreCall(2069);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)surfaceModelID);
            HalconAPI.StoreD(proc, 2, relSamplingDistance);
            HalconAPI.StoreD(proc, 3, keyPointFraction);
            HalconAPI.StoreD(proc, 4, minScore);
            HalconAPI.StoreS(proc, 5, returnResultHandle);
            HalconAPI.Store(proc, 6, genParamName);
            HalconAPI.Store(proc, 7, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HPose hpose;
            int err2 = HPose.LoadNew(proc, 0, err1, out hpose);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out score);
            int procResult = HSurfaceMatchingResult.LoadNew(proc, 2, err3, out surfaceMatchingResultID);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)surfaceModelID);
            return hpose;
        }

        /// <summary>
        ///   Refine the pose of a surface model in a 3D scene and in images.
        ///   Instance represents: Handle of the 3D object model containing the scene.
        /// </summary>
        /// <param name="image">Images of the scene.</param>
        /// <param name="surfaceModelID">Handle of the surface model.</param>
        /// <param name="initialPose">Initial pose of the surface model in the scene.</param>
        /// <param name="minScore">Minimum score of the returned poses. Default: 0</param>
        /// <param name="returnResultHandle">Enable returning a result handle in SurfaceMatchingResultID. Default: "false"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="score">Score of the found instances of the model.</param>
        /// <param name="surfaceMatchingResultID">Handle of the matching result, if enabled in ReturnResultHandle.</param>
        /// <returns>3D pose of the surface model in the scene.</returns>
        public HPose[] RefineSurfaceModelPoseImage(
          HImage image,
          HSurfaceModel surfaceModelID,
          HPose[] initialPose,
          HTuple minScore,
          string returnResultHandle,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple score,
          out HSurfaceMatchingResult[] surfaceMatchingResultID)
        {
            HTuple htuple = HData.ConcatArray((HData[])initialPose);
            IntPtr proc = HalconAPI.PreCall(2084);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)surfaceModelID);
            HalconAPI.Store(proc, 2, htuple);
            HalconAPI.Store(proc, 3, minScore);
            HalconAPI.StoreS(proc, 4, returnResultHandle);
            HalconAPI.Store(proc, 5, genParamName);
            HalconAPI.Store(proc, 6, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(minScore);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out score);
            int procResult = HSurfaceMatchingResult.LoadNew(proc, 2, err3, out surfaceMatchingResultID);
            HalconAPI.PostCall(proc, procResult);
            HPose[] hposeArray = HPose.SplitArray(tuple);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)surfaceModelID);
            return hposeArray;
        }

        /// <summary>
        ///   Refine the pose of a surface model in a 3D scene and in images.
        ///   Instance represents: Handle of the 3D object model containing the scene.
        /// </summary>
        /// <param name="image">Images of the scene.</param>
        /// <param name="surfaceModelID">Handle of the surface model.</param>
        /// <param name="initialPose">Initial pose of the surface model in the scene.</param>
        /// <param name="minScore">Minimum score of the returned poses. Default: 0</param>
        /// <param name="returnResultHandle">Enable returning a result handle in SurfaceMatchingResultID. Default: "false"</param>
        /// <param name="genParamName">Names of the generic parameters. Default: []</param>
        /// <param name="genParamValue">Values of the generic parameters. Default: []</param>
        /// <param name="score">Score of the found instances of the model.</param>
        /// <param name="surfaceMatchingResultID">Handle of the matching result, if enabled in ReturnResultHandle.</param>
        /// <returns>3D pose of the surface model in the scene.</returns>
        public HPose RefineSurfaceModelPoseImage(
          HImage image,
          HSurfaceModel surfaceModelID,
          HPose initialPose,
          double minScore,
          string returnResultHandle,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple score,
          out HSurfaceMatchingResult surfaceMatchingResultID)
        {
            IntPtr proc = HalconAPI.PreCall(2084);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.Store(proc, 0, (HTool)surfaceModelID);
            HalconAPI.Store(proc, 2, (HData)initialPose);
            HalconAPI.StoreD(proc, 3, minScore);
            HalconAPI.StoreS(proc, 4, returnResultHandle);
            HalconAPI.Store(proc, 5, genParamName);
            HalconAPI.Store(proc, 6, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)initialPose));
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HPose hpose;
            int err2 = HPose.LoadNew(proc, 0, err1, out hpose);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out score);
            int procResult = HSurfaceMatchingResult.LoadNew(proc, 2, err3, out surfaceMatchingResultID);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            GC.KeepAlive((object)surfaceModelID);
            return hpose;
        }

        /// <summary>Fuse 3D object models into a surface.</summary>
        /// <param name="objectModel3D">Handles of the 3D object models.</param>
        /// <param name="boundingBox">The two opposite bound box corners.</param>
        /// <param name="resolution">Used resolution within the bounding box. Default: 1.0</param>
        /// <param name="surfaceTolerance">Distance of expected noise to surface. Default: 1.0</param>
        /// <param name="minThickness">Minimum thickness of the object in direction  of the surface normal. Default: 1.0</param>
        /// <param name="smoothing">Weight factor for data fidelity. Default: 1.0</param>
        /// <param name="normalDirection">Direction of normals of the input models. Default: "inwards"</param>
        /// <param name="genParamName">Name of the generic parameter. Default: []</param>
        /// <param name="genParamValue">Value of the generic parameter. Default: []</param>
        /// <returns>Handle of the fused 3D object model.</returns>
        public static HObjectModel3D FuseObjectModel3d(
          HObjectModel3D[] objectModel3D,
          HTuple boundingBox,
          HTuple resolution,
          HTuple surfaceTolerance,
          HTuple minThickness,
          HTuple smoothing,
          HTuple normalDirection,
          HTuple genParamName,
          HTuple genParamValue)
        {
            HTuple htuple = HTool.ConcatArray((HTool[])objectModel3D);
            IntPtr proc = HalconAPI.PreCall(2112);
            HalconAPI.Store(proc, 0, htuple);
            HalconAPI.Store(proc, 1, boundingBox);
            HalconAPI.Store(proc, 2, resolution);
            HalconAPI.Store(proc, 3, surfaceTolerance);
            HalconAPI.Store(proc, 4, minThickness);
            HalconAPI.Store(proc, 5, smoothing);
            HalconAPI.Store(proc, 6, normalDirection);
            HalconAPI.Store(proc, 7, genParamName);
            HalconAPI.Store(proc, 8, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(boundingBox);
            HalconAPI.UnpinTuple(resolution);
            HalconAPI.UnpinTuple(surfaceTolerance);
            HalconAPI.UnpinTuple(minThickness);
            HalconAPI.UnpinTuple(smoothing);
            HalconAPI.UnpinTuple(normalDirection);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HObjectModel3D hobjectModel3D;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)objectModel3D);
            return hobjectModel3D;
        }

        /// <summary>
        ///   Fuse 3D object models into a surface.
        ///   Instance represents: Handles of the 3D object models.
        /// </summary>
        /// <param name="boundingBox">The two opposite bound box corners.</param>
        /// <param name="resolution">Used resolution within the bounding box. Default: 1.0</param>
        /// <param name="surfaceTolerance">Distance of expected noise to surface. Default: 1.0</param>
        /// <param name="minThickness">Minimum thickness of the object in direction  of the surface normal. Default: 1.0</param>
        /// <param name="smoothing">Weight factor for data fidelity. Default: 1.0</param>
        /// <param name="normalDirection">Direction of normals of the input models. Default: "inwards"</param>
        /// <param name="genParamName">Name of the generic parameter. Default: []</param>
        /// <param name="genParamValue">Value of the generic parameter. Default: []</param>
        /// <returns>Handle of the fused 3D object model.</returns>
        public HObjectModel3D FuseObjectModel3d(
          HTuple boundingBox,
          double resolution,
          double surfaceTolerance,
          double minThickness,
          double smoothing,
          string normalDirection,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(2112);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, boundingBox);
            HalconAPI.StoreD(proc, 2, resolution);
            HalconAPI.StoreD(proc, 3, surfaceTolerance);
            HalconAPI.StoreD(proc, 4, minThickness);
            HalconAPI.StoreD(proc, 5, smoothing);
            HalconAPI.StoreS(proc, 6, normalDirection);
            HalconAPI.Store(proc, 7, genParamName);
            HalconAPI.Store(proc, 8, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(boundingBox);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HObjectModel3D hobjectModel3D;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobjectModel3D;
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(1100);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
