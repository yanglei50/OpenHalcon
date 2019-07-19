// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HHomMat2D
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents a homogeneous 2D transformation matrix.</summary>
    [Serializable]
    public class HHomMat2D : HData, ISerializable, ICloneable
    {
        private const int FIXEDSIZE = 9;

        public HHomMat2D(HTuple tuple)
          : base(tuple)
        {
        }

        internal HHomMat2D(HData data)
          : base(data)
        {
        }

        internal static int LoadNew(
          IntPtr proc,
          int parIndex,
          HTupleType type,
          int err,
          out HHomMat2D obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HHomMat2D(new HData(tuple));
            return err;
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HHomMat2D obj)
        {
            return HHomMat2D.LoadNew(proc, parIndex, HTupleType.MIXED, err, out obj);
        }

        internal static HHomMat2D[] SplitArray(HTuple data)
        {
            int length = data.Length / 9;
            HHomMat2D[] hhomMat2DArray = new HHomMat2D[length];
            for (int index = 0; index < length; ++index)
                hhomMat2DArray[index] = new HHomMat2D(new HData(data.TupleSelectRange((HTuple)(index * 9), (HTuple)((index + 1) * 9 - 1))));
            return hhomMat2DArray;
        }

        /// <summary>
        ///   Generate the homogeneous transformation matrix of the identical 2D transformation.
        ///   Modified instance represents: Transformation matrix.
        /// </summary>
        public HHomMat2D()
        {
            IntPtr proc = HalconAPI.PreCall(288);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeHomMat2d();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HHomMat2D(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeHomMat2d(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeHomMat2d().Serialize(stream);
        }

        public static HHomMat2D Deserialize(Stream stream)
        {
            HHomMat2D hhomMat2D = new HHomMat2D();
            hhomMat2D.DeserializeHomMat2d(HSerializedItem.Deserialize(stream));
            return hhomMat2D;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HHomMat2D Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeHomMat2d();
            HHomMat2D hhomMat2D = new HHomMat2D();
            hhomMat2D.DeserializeHomMat2d(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hhomMat2D;
        }

        /// <summary>
        ///   Read the geo coding from an ARC/INFO world file.
        ///   Modified instance represents: Transformation matrix from image to world coordinates.
        /// </summary>
        /// <param name="fileName">Name of the ARC/INFO world file.</param>
        public void ReadWorldFile(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(22);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Apply a projective transformation to an XLD contour.
        ///   Instance represents: Homogeneous projective transformation matrix.
        /// </summary>
        /// <param name="contours">Input contours.</param>
        /// <returns>Output contours.</returns>
        public HXLDCont ProjectiveTransContourXld(HXLDCont contours)
        {
            IntPtr proc = HalconAPI.PreCall(47);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)contours);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contours);
            return hxldCont;
        }

        /// <summary>
        ///   Apply an arbitrary affine transformation to XLD polygons.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="polygons">Input XLD polygons.</param>
        /// <returns>Transformed XLD polygons.</returns>
        public HXLDPoly AffineTransPolygonXld(HXLDPoly polygons)
        {
            IntPtr proc = HalconAPI.PreCall(48);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)polygons);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HXLDPoly hxldPoly;
            int procResult = HXLDPoly.LoadNew(proc, 1, err, out hxldPoly);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)polygons);
            return hxldPoly;
        }

        /// <summary>
        ///   Apply an arbitrary affine 2D transformation to XLD contours.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="contours">Input XLD contours.</param>
        /// <returns>Transformed XLD contours.</returns>
        public HXLDCont AffineTransContourXld(HXLDCont contours)
        {
            IntPtr proc = HalconAPI.PreCall(49);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)contours);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HXLDCont hxldCont;
            int procResult = HXLDCont.LoadNew(proc, 1, err, out hxldCont);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)contours);
            return hxldCont;
        }

        /// <summary>
        ///   Deserialize a serialized homogeneous 2D transformation matrix.
        ///   Modified instance represents: Transformation matrix.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeHomMat2d(HSerializedItem serializedItemHandle)
        {
            IntPtr proc = HalconAPI.PreCall(235);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize a homogeneous 2D transformation matrix.
        ///   Instance represents: Transformation matrix.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeHomMat2d()
        {
            IntPtr proc = HalconAPI.PreCall(236);
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

        /// <summary>Perform a bundle adjustment of an image mosaic.</summary>
        /// <param name="numImages">Number of different images that are used for the calibration.</param>
        /// <param name="referenceImage">Index of the reference image.</param>
        /// <param name="mappingSource">Indices of the source images of the transformations.</param>
        /// <param name="mappingDest">Indices of the target images of the transformations.</param>
        /// <param name="homMatrices2D">Array of 3x3 projective transformation matrices.</param>
        /// <param name="rows1">Row coordinates of corresponding points in the respective source images.</param>
        /// <param name="cols1">Column coordinates of corresponding points in the respective source images.</param>
        /// <param name="rows2">Row coordinates of corresponding points in the respective destination images.</param>
        /// <param name="cols2">Column coordinates of corresponding points in the respective destination images.</param>
        /// <param name="numCorrespondences">Number of point correspondences in the respective image pair.</param>
        /// <param name="transformation">Transformation class to be used. Default: "projective"</param>
        /// <param name="rows">Row coordinates of the points reconstructed by the bundle adjustment.</param>
        /// <param name="cols">Column coordinates of the points reconstructed by the bundle adjustment.</param>
        /// <param name="error">Average error per reconstructed point.</param>
        /// <returns>Array of 3x3 projective transformation matrices that determine the position of the images in the mosaic.</returns>
        public static HHomMat2D[] BundleAdjustMosaic(
          int numImages,
          int referenceImage,
          HTuple mappingSource,
          HTuple mappingDest,
          HHomMat2D[] homMatrices2D,
          HTuple rows1,
          HTuple cols1,
          HTuple rows2,
          HTuple cols2,
          HTuple numCorrespondences,
          string transformation,
          out HTuple rows,
          out HTuple cols,
          out HTuple error)
        {
            HTuple htuple = HData.ConcatArray((HData[])homMatrices2D);
            IntPtr proc = HalconAPI.PreCall((int)byte.MaxValue);
            HalconAPI.StoreI(proc, 0, numImages);
            HalconAPI.StoreI(proc, 1, referenceImage);
            HalconAPI.Store(proc, 2, mappingSource);
            HalconAPI.Store(proc, 3, mappingDest);
            HalconAPI.Store(proc, 4, htuple);
            HalconAPI.Store(proc, 5, rows1);
            HalconAPI.Store(proc, 6, cols1);
            HalconAPI.Store(proc, 7, rows2);
            HalconAPI.Store(proc, 8, cols2);
            HalconAPI.Store(proc, 9, numCorrespondences);
            HalconAPI.StoreS(proc, 10, transformation);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(mappingSource);
            HalconAPI.UnpinTuple(mappingDest);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(rows1);
            HalconAPI.UnpinTuple(cols1);
            HalconAPI.UnpinTuple(rows2);
            HalconAPI.UnpinTuple(cols2);
            HalconAPI.UnpinTuple(numCorrespondences);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out rows);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out cols);
            int procResult = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out error);
            HalconAPI.PostCall(proc, procResult);
            return HHomMat2D.SplitArray(tuple);
        }

        /// <summary>Perform a bundle adjustment of an image mosaic.</summary>
        /// <param name="numImages">Number of different images that are used for the calibration.</param>
        /// <param name="referenceImage">Index of the reference image.</param>
        /// <param name="mappingSource">Indices of the source images of the transformations.</param>
        /// <param name="mappingDest">Indices of the target images of the transformations.</param>
        /// <param name="homMatrices2D">Array of 3x3 projective transformation matrices.</param>
        /// <param name="rows1">Row coordinates of corresponding points in the respective source images.</param>
        /// <param name="cols1">Column coordinates of corresponding points in the respective source images.</param>
        /// <param name="rows2">Row coordinates of corresponding points in the respective destination images.</param>
        /// <param name="cols2">Column coordinates of corresponding points in the respective destination images.</param>
        /// <param name="numCorrespondences">Number of point correspondences in the respective image pair.</param>
        /// <param name="transformation">Transformation class to be used. Default: "projective"</param>
        /// <param name="rows">Row coordinates of the points reconstructed by the bundle adjustment.</param>
        /// <param name="cols">Column coordinates of the points reconstructed by the bundle adjustment.</param>
        /// <param name="error">Average error per reconstructed point.</param>
        /// <returns>Array of 3x3 projective transformation matrices that determine the position of the images in the mosaic.</returns>
        public static HHomMat2D[] BundleAdjustMosaic(
          int numImages,
          int referenceImage,
          HTuple mappingSource,
          HTuple mappingDest,
          HHomMat2D[] homMatrices2D,
          HTuple rows1,
          HTuple cols1,
          HTuple rows2,
          HTuple cols2,
          HTuple numCorrespondences,
          string transformation,
          out HTuple rows,
          out HTuple cols,
          out double error)
        {
            HTuple htuple = HData.ConcatArray((HData[])homMatrices2D);
            IntPtr proc = HalconAPI.PreCall((int)byte.MaxValue);
            HalconAPI.StoreI(proc, 0, numImages);
            HalconAPI.StoreI(proc, 1, referenceImage);
            HalconAPI.Store(proc, 2, mappingSource);
            HalconAPI.Store(proc, 3, mappingDest);
            HalconAPI.Store(proc, 4, htuple);
            HalconAPI.Store(proc, 5, rows1);
            HalconAPI.Store(proc, 6, cols1);
            HalconAPI.Store(proc, 7, rows2);
            HalconAPI.Store(proc, 8, cols2);
            HalconAPI.Store(proc, 9, numCorrespondences);
            HalconAPI.StoreS(proc, 10, transformation);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(mappingSource);
            HalconAPI.UnpinTuple(mappingDest);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(rows1);
            HalconAPI.UnpinTuple(cols1);
            HalconAPI.UnpinTuple(rows2);
            HalconAPI.UnpinTuple(cols2);
            HalconAPI.UnpinTuple(numCorrespondences);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out rows);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out cols);
            int procResult = HalconAPI.LoadD(proc, 3, err4, out error);
            HalconAPI.PostCall(proc, procResult);
            return HHomMat2D.SplitArray(tuple);
        }

        /// <summary>
        ///   Compute a projective transformation matrix and the radial distortion coefficient between two images by finding correspondences between points based on known approximations of the projective transformation matrix and the radial distortion coefficient.
        ///   Instance represents: Approximation of the homogeneous projective transformation matrix between the two images.
        /// </summary>
        /// <param name="image1">Input image 1.</param>
        /// <param name="image2">Input image 2.</param>
        /// <param name="rows1">Input points in image 1 (row coordinate).</param>
        /// <param name="cols1">Input points in image 1 (column coordinate).</param>
        /// <param name="rows2">Input points in image 2 (row coordinate).</param>
        /// <param name="cols2">Input points in image 2 (column coordinate).</param>
        /// <param name="grayMatchMethod">Gray value match metric. Default: "ncc"</param>
        /// <param name="maskSize">Size of gray value masks. Default: 10</param>
        /// <param name="kappaGuide">Approximation of the radial distortion coefficient in the two images.</param>
        /// <param name="distanceTolerance">Tolerance for the matching search window. Default: 20.0</param>
        /// <param name="matchThreshold">Threshold for gray value matching. Default: 0.7</param>
        /// <param name="estimationMethod">Algorithm for the computation of the projective transformation matrix. Default: "gold_standard"</param>
        /// <param name="distanceThreshold">Threshold for transformation consistency check. Default: 1</param>
        /// <param name="randSeed">Seed for the random number generator. Default: 0</param>
        /// <param name="kappa">Computed radial distortion coefficient.</param>
        /// <param name="error">Root-Mean-Square transformation error.</param>
        /// <param name="points1">Indices of matched input points in image 1.</param>
        /// <param name="points2">Indices of matched input points in image 2.</param>
        /// <returns>Computed homogeneous projective transformation matrix.</returns>
        public HHomMat2D ProjMatchPointsDistortionRansacGuided(
          HImage image1,
          HImage image2,
          HTuple rows1,
          HTuple cols1,
          HTuple rows2,
          HTuple cols2,
          string grayMatchMethod,
          int maskSize,
          double kappaGuide,
          double distanceTolerance,
          HTuple matchThreshold,
          string estimationMethod,
          HTuple distanceThreshold,
          int randSeed,
          out double kappa,
          out double error,
          out HTuple points1,
          out HTuple points2)
        {
            IntPtr proc = HalconAPI.PreCall(256);
            this.Store(proc, 6);
            HalconAPI.Store(proc, 1, (HObjectBase)image1);
            HalconAPI.Store(proc, 2, (HObjectBase)image2);
            HalconAPI.Store(proc, 0, rows1);
            HalconAPI.Store(proc, 1, cols1);
            HalconAPI.Store(proc, 2, rows2);
            HalconAPI.Store(proc, 3, cols2);
            HalconAPI.StoreS(proc, 4, grayMatchMethod);
            HalconAPI.StoreI(proc, 5, maskSize);
            HalconAPI.StoreD(proc, 7, kappaGuide);
            HalconAPI.StoreD(proc, 8, distanceTolerance);
            HalconAPI.Store(proc, 9, matchThreshold);
            HalconAPI.StoreS(proc, 10, estimationMethod);
            HalconAPI.Store(proc, 11, distanceThreshold);
            HalconAPI.StoreI(proc, 12, randSeed);
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
            HalconAPI.UnpinTuple(matchThreshold);
            HalconAPI.UnpinTuple(distanceThreshold);
            HHomMat2D hhomMat2D;
            int err2 = HHomMat2D.LoadNew(proc, 0, err1, out hhomMat2D);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out kappa);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out error);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, err4, out points1);
            int procResult = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, err5, out points2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image1);
            GC.KeepAlive((object)image2);
            return hhomMat2D;
        }

        /// <summary>
        ///   Compute a projective transformation matrix and the radial distortion coefficient between two images by finding correspondences between points based on known approximations of the projective transformation matrix and the radial distortion coefficient.
        ///   Instance represents: Approximation of the homogeneous projective transformation matrix between the two images.
        /// </summary>
        /// <param name="image1">Input image 1.</param>
        /// <param name="image2">Input image 2.</param>
        /// <param name="rows1">Input points in image 1 (row coordinate).</param>
        /// <param name="cols1">Input points in image 1 (column coordinate).</param>
        /// <param name="rows2">Input points in image 2 (row coordinate).</param>
        /// <param name="cols2">Input points in image 2 (column coordinate).</param>
        /// <param name="grayMatchMethod">Gray value match metric. Default: "ncc"</param>
        /// <param name="maskSize">Size of gray value masks. Default: 10</param>
        /// <param name="kappaGuide">Approximation of the radial distortion coefficient in the two images.</param>
        /// <param name="distanceTolerance">Tolerance for the matching search window. Default: 20.0</param>
        /// <param name="matchThreshold">Threshold for gray value matching. Default: 0.7</param>
        /// <param name="estimationMethod">Algorithm for the computation of the projective transformation matrix. Default: "gold_standard"</param>
        /// <param name="distanceThreshold">Threshold for transformation consistency check. Default: 1</param>
        /// <param name="randSeed">Seed for the random number generator. Default: 0</param>
        /// <param name="kappa">Computed radial distortion coefficient.</param>
        /// <param name="error">Root-Mean-Square transformation error.</param>
        /// <param name="points1">Indices of matched input points in image 1.</param>
        /// <param name="points2">Indices of matched input points in image 2.</param>
        /// <returns>Computed homogeneous projective transformation matrix.</returns>
        public HHomMat2D ProjMatchPointsDistortionRansacGuided(
          HImage image1,
          HImage image2,
          HTuple rows1,
          HTuple cols1,
          HTuple rows2,
          HTuple cols2,
          string grayMatchMethod,
          int maskSize,
          double kappaGuide,
          double distanceTolerance,
          int matchThreshold,
          string estimationMethod,
          double distanceThreshold,
          int randSeed,
          out double kappa,
          out double error,
          out HTuple points1,
          out HTuple points2)
        {
            IntPtr proc = HalconAPI.PreCall(256);
            this.Store(proc, 6);
            HalconAPI.Store(proc, 1, (HObjectBase)image1);
            HalconAPI.Store(proc, 2, (HObjectBase)image2);
            HalconAPI.Store(proc, 0, rows1);
            HalconAPI.Store(proc, 1, cols1);
            HalconAPI.Store(proc, 2, rows2);
            HalconAPI.Store(proc, 3, cols2);
            HalconAPI.StoreS(proc, 4, grayMatchMethod);
            HalconAPI.StoreI(proc, 5, maskSize);
            HalconAPI.StoreD(proc, 7, kappaGuide);
            HalconAPI.StoreD(proc, 8, distanceTolerance);
            HalconAPI.StoreI(proc, 9, matchThreshold);
            HalconAPI.StoreS(proc, 10, estimationMethod);
            HalconAPI.StoreD(proc, 11, distanceThreshold);
            HalconAPI.StoreI(proc, 12, randSeed);
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
            HHomMat2D hhomMat2D;
            int err2 = HHomMat2D.LoadNew(proc, 0, err1, out hhomMat2D);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out kappa);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out error);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, err4, out points1);
            int procResult = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, err5, out points2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image1);
            GC.KeepAlive((object)image2);
            return hhomMat2D;
        }

        /// <summary>
        ///   Compute a projective transformation matrix between two images and the radial distortion coefficient by automatically finding correspondences between points.
        ///   Modified instance represents: Computed homogeneous projective transformation matrix.
        /// </summary>
        /// <param name="image1">Input image 1.</param>
        /// <param name="image2">Input image 2.</param>
        /// <param name="rows1">Input points in image 1 (row coordinate).</param>
        /// <param name="cols1">Input points in image 1 (column coordinate).</param>
        /// <param name="rows2">Input points in image 2 (row coordinate).</param>
        /// <param name="cols2">Input points in image 2 (column coordinate).</param>
        /// <param name="grayMatchMethod">Gray value match metric. Default: "ncc"</param>
        /// <param name="maskSize">Size of gray value masks. Default: 10</param>
        /// <param name="rowMove">Average row coordinate offset of corresponding points. Default: 0</param>
        /// <param name="colMove">Average column coordinate offset of corresponding points. Default: 0</param>
        /// <param name="rowTolerance">Half height of matching search window. Default: 200</param>
        /// <param name="colTolerance">Half width of matching search window. Default: 200</param>
        /// <param name="rotation">Estimate of the relative rotation of the second image with respect to the first image. Default: 0.0</param>
        /// <param name="matchThreshold">Threshold for gray value matching. Default: 0.7</param>
        /// <param name="estimationMethod">Algorithm for the computation of the projective transformation matrix. Default: "gold_standard"</param>
        /// <param name="distanceThreshold">Threshold for the transformation consistency check. Default: 1</param>
        /// <param name="randSeed">Seed for the random number generator. Default: 0</param>
        /// <param name="error">Root-Mean-Square transformation error.</param>
        /// <param name="points1">Indices of matched input points in image 1.</param>
        /// <param name="points2">Indices of matched input points in image 2.</param>
        /// <returns>Computed radial distortion coefficient.</returns>
        public double ProjMatchPointsDistortionRansac(
          HImage image1,
          HImage image2,
          HTuple rows1,
          HTuple cols1,
          HTuple rows2,
          HTuple cols2,
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
          out double error,
          out HTuple points1,
          out HTuple points2)
        {
            IntPtr proc = HalconAPI.PreCall(257);
            HalconAPI.Store(proc, 1, (HObjectBase)image1);
            HalconAPI.Store(proc, 2, (HObjectBase)image2);
            HalconAPI.Store(proc, 0, rows1);
            HalconAPI.Store(proc, 1, cols1);
            HalconAPI.Store(proc, 2, rows2);
            HalconAPI.Store(proc, 3, cols2);
            HalconAPI.StoreS(proc, 4, grayMatchMethod);
            HalconAPI.StoreI(proc, 5, maskSize);
            HalconAPI.StoreI(proc, 6, rowMove);
            HalconAPI.StoreI(proc, 7, colMove);
            HalconAPI.StoreI(proc, 8, rowTolerance);
            HalconAPI.StoreI(proc, 9, colTolerance);
            HalconAPI.Store(proc, 10, rotation);
            HalconAPI.Store(proc, 11, matchThreshold);
            HalconAPI.StoreS(proc, 12, estimationMethod);
            HalconAPI.Store(proc, 13, distanceThreshold);
            HalconAPI.StoreI(proc, 14, randSeed);
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
            HalconAPI.UnpinTuple(rotation);
            HalconAPI.UnpinTuple(matchThreshold);
            HalconAPI.UnpinTuple(distanceThreshold);
            int err2 = this.Load(proc, 0, err1);
            double doubleValue;
            int err3 = HalconAPI.LoadD(proc, 1, err2, out doubleValue);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out error);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, err4, out points1);
            int procResult = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, err5, out points2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image1);
            GC.KeepAlive((object)image2);
            return doubleValue;
        }

        /// <summary>
        ///   Compute a projective transformation matrix between two images and the radial distortion coefficient by automatically finding correspondences between points.
        ///   Modified instance represents: Computed homogeneous projective transformation matrix.
        /// </summary>
        /// <param name="image1">Input image 1.</param>
        /// <param name="image2">Input image 2.</param>
        /// <param name="rows1">Input points in image 1 (row coordinate).</param>
        /// <param name="cols1">Input points in image 1 (column coordinate).</param>
        /// <param name="rows2">Input points in image 2 (row coordinate).</param>
        /// <param name="cols2">Input points in image 2 (column coordinate).</param>
        /// <param name="grayMatchMethod">Gray value match metric. Default: "ncc"</param>
        /// <param name="maskSize">Size of gray value masks. Default: 10</param>
        /// <param name="rowMove">Average row coordinate offset of corresponding points. Default: 0</param>
        /// <param name="colMove">Average column coordinate offset of corresponding points. Default: 0</param>
        /// <param name="rowTolerance">Half height of matching search window. Default: 200</param>
        /// <param name="colTolerance">Half width of matching search window. Default: 200</param>
        /// <param name="rotation">Estimate of the relative rotation of the second image with respect to the first image. Default: 0.0</param>
        /// <param name="matchThreshold">Threshold for gray value matching. Default: 0.7</param>
        /// <param name="estimationMethod">Algorithm for the computation of the projective transformation matrix. Default: "gold_standard"</param>
        /// <param name="distanceThreshold">Threshold for the transformation consistency check. Default: 1</param>
        /// <param name="randSeed">Seed for the random number generator. Default: 0</param>
        /// <param name="error">Root-Mean-Square transformation error.</param>
        /// <param name="points1">Indices of matched input points in image 1.</param>
        /// <param name="points2">Indices of matched input points in image 2.</param>
        /// <returns>Computed radial distortion coefficient.</returns>
        public double ProjMatchPointsDistortionRansac(
          HImage image1,
          HImage image2,
          HTuple rows1,
          HTuple cols1,
          HTuple rows2,
          HTuple cols2,
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
            IntPtr proc = HalconAPI.PreCall(257);
            HalconAPI.Store(proc, 1, (HObjectBase)image1);
            HalconAPI.Store(proc, 2, (HObjectBase)image2);
            HalconAPI.Store(proc, 0, rows1);
            HalconAPI.Store(proc, 1, cols1);
            HalconAPI.Store(proc, 2, rows2);
            HalconAPI.Store(proc, 3, cols2);
            HalconAPI.StoreS(proc, 4, grayMatchMethod);
            HalconAPI.StoreI(proc, 5, maskSize);
            HalconAPI.StoreI(proc, 6, rowMove);
            HalconAPI.StoreI(proc, 7, colMove);
            HalconAPI.StoreI(proc, 8, rowTolerance);
            HalconAPI.StoreI(proc, 9, colTolerance);
            HalconAPI.StoreD(proc, 10, rotation);
            HalconAPI.StoreI(proc, 11, matchThreshold);
            HalconAPI.StoreS(proc, 12, estimationMethod);
            HalconAPI.StoreD(proc, 13, distanceThreshold);
            HalconAPI.StoreI(proc, 14, randSeed);
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
            int err2 = this.Load(proc, 0, err1);
            double doubleValue;
            int err3 = HalconAPI.LoadD(proc, 1, err2, out doubleValue);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out error);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, err4, out points1);
            int procResult = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, err5, out points2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image1);
            GC.KeepAlive((object)image2);
            return doubleValue;
        }

        /// <summary>
        ///   Compute a projective transformation matrix between two images by finding correspondences between points based on a known approximation of the projective transformation matrix.
        ///   Instance represents: Approximation of the Homogeneous projective transformation matrix between the two images.
        /// </summary>
        /// <param name="image1">Input image 1.</param>
        /// <param name="image2">Input image 2.</param>
        /// <param name="rows1">Row coordinates of characteristic points in image 1.</param>
        /// <param name="cols1">Column coordinates of characteristic points in image 1.</param>
        /// <param name="rows2">Row coordinates of characteristic points in image 2.</param>
        /// <param name="cols2">Column coordinates of characteristic points in image 2.</param>
        /// <param name="grayMatchMethod">Gray value comparison metric. Default: "ssd"</param>
        /// <param name="maskSize">Size of gray value masks. Default: 10</param>
        /// <param name="distanceTolerance">Tolerance for the matching search window. Default: 20.0</param>
        /// <param name="matchThreshold">Threshold for gray value matching. Default: 10</param>
        /// <param name="estimationMethod">Transformation matrix estimation algorithm. Default: "normalized_dlt"</param>
        /// <param name="distanceThreshold">Threshold for transformation consistency check. Default: 0.2</param>
        /// <param name="randSeed">Seed for the random number generator. Default: 0</param>
        /// <param name="points1">Indices of matched input points in image 1.</param>
        /// <param name="points2">Indices of matched input points in image 2.</param>
        /// <returns>Homogeneous projective transformation matrix.</returns>
        public HHomMat2D ProjMatchPointsRansacGuided(
          HImage image1,
          HImage image2,
          HTuple rows1,
          HTuple cols1,
          HTuple rows2,
          HTuple cols2,
          string grayMatchMethod,
          int maskSize,
          double distanceTolerance,
          HTuple matchThreshold,
          string estimationMethod,
          double distanceThreshold,
          int randSeed,
          out HTuple points1,
          out HTuple points2)
        {
            IntPtr proc = HalconAPI.PreCall(258);
            this.Store(proc, 6);
            HalconAPI.Store(proc, 1, (HObjectBase)image1);
            HalconAPI.Store(proc, 2, (HObjectBase)image2);
            HalconAPI.Store(proc, 0, rows1);
            HalconAPI.Store(proc, 1, cols1);
            HalconAPI.Store(proc, 2, rows2);
            HalconAPI.Store(proc, 3, cols2);
            HalconAPI.StoreS(proc, 4, grayMatchMethod);
            HalconAPI.StoreI(proc, 5, maskSize);
            HalconAPI.StoreD(proc, 7, distanceTolerance);
            HalconAPI.Store(proc, 8, matchThreshold);
            HalconAPI.StoreS(proc, 9, estimationMethod);
            HalconAPI.StoreD(proc, 10, distanceThreshold);
            HalconAPI.StoreI(proc, 11, randSeed);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(rows1);
            HalconAPI.UnpinTuple(cols1);
            HalconAPI.UnpinTuple(rows2);
            HalconAPI.UnpinTuple(cols2);
            HalconAPI.UnpinTuple(matchThreshold);
            HHomMat2D hhomMat2D;
            int err2 = HHomMat2D.LoadNew(proc, 0, err1, out hhomMat2D);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out points1);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, err3, out points2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image1);
            GC.KeepAlive((object)image2);
            return hhomMat2D;
        }

        /// <summary>
        ///   Compute a projective transformation matrix between two images by finding correspondences between points based on a known approximation of the projective transformation matrix.
        ///   Instance represents: Approximation of the Homogeneous projective transformation matrix between the two images.
        /// </summary>
        /// <param name="image1">Input image 1.</param>
        /// <param name="image2">Input image 2.</param>
        /// <param name="rows1">Row coordinates of characteristic points in image 1.</param>
        /// <param name="cols1">Column coordinates of characteristic points in image 1.</param>
        /// <param name="rows2">Row coordinates of characteristic points in image 2.</param>
        /// <param name="cols2">Column coordinates of characteristic points in image 2.</param>
        /// <param name="grayMatchMethod">Gray value comparison metric. Default: "ssd"</param>
        /// <param name="maskSize">Size of gray value masks. Default: 10</param>
        /// <param name="distanceTolerance">Tolerance for the matching search window. Default: 20.0</param>
        /// <param name="matchThreshold">Threshold for gray value matching. Default: 10</param>
        /// <param name="estimationMethod">Transformation matrix estimation algorithm. Default: "normalized_dlt"</param>
        /// <param name="distanceThreshold">Threshold for transformation consistency check. Default: 0.2</param>
        /// <param name="randSeed">Seed for the random number generator. Default: 0</param>
        /// <param name="points1">Indices of matched input points in image 1.</param>
        /// <param name="points2">Indices of matched input points in image 2.</param>
        /// <returns>Homogeneous projective transformation matrix.</returns>
        public HHomMat2D ProjMatchPointsRansacGuided(
          HImage image1,
          HImage image2,
          HTuple rows1,
          HTuple cols1,
          HTuple rows2,
          HTuple cols2,
          string grayMatchMethod,
          int maskSize,
          double distanceTolerance,
          int matchThreshold,
          string estimationMethod,
          double distanceThreshold,
          int randSeed,
          out HTuple points1,
          out HTuple points2)
        {
            IntPtr proc = HalconAPI.PreCall(258);
            this.Store(proc, 6);
            HalconAPI.Store(proc, 1, (HObjectBase)image1);
            HalconAPI.Store(proc, 2, (HObjectBase)image2);
            HalconAPI.Store(proc, 0, rows1);
            HalconAPI.Store(proc, 1, cols1);
            HalconAPI.Store(proc, 2, rows2);
            HalconAPI.Store(proc, 3, cols2);
            HalconAPI.StoreS(proc, 4, grayMatchMethod);
            HalconAPI.StoreI(proc, 5, maskSize);
            HalconAPI.StoreD(proc, 7, distanceTolerance);
            HalconAPI.StoreI(proc, 8, matchThreshold);
            HalconAPI.StoreS(proc, 9, estimationMethod);
            HalconAPI.StoreD(proc, 10, distanceThreshold);
            HalconAPI.StoreI(proc, 11, randSeed);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(rows1);
            HalconAPI.UnpinTuple(cols1);
            HalconAPI.UnpinTuple(rows2);
            HalconAPI.UnpinTuple(cols2);
            HHomMat2D hhomMat2D;
            int err2 = HHomMat2D.LoadNew(proc, 0, err1, out hhomMat2D);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out points1);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, err3, out points2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image1);
            GC.KeepAlive((object)image2);
            return hhomMat2D;
        }

        /// <summary>
        ///   Compute a projective transformation matrix between two images by finding correspondences between points.
        ///   Modified instance represents: Homogeneous projective transformation matrix.
        /// </summary>
        /// <param name="image1">Input image 1.</param>
        /// <param name="image2">Input image 2.</param>
        /// <param name="rows1">Row coordinates of characteristic points in image 1.</param>
        /// <param name="cols1">Column coordinates of characteristic points in image 1.</param>
        /// <param name="rows2">Row coordinates of characteristic points in image 2.</param>
        /// <param name="cols2">Column coordinates of characteristic points in image 2.</param>
        /// <param name="grayMatchMethod">Gray value comparison metric. Default: "ssd"</param>
        /// <param name="maskSize">Size of gray value masks. Default: 10</param>
        /// <param name="rowMove">Average row coordinate shift. Default: 0</param>
        /// <param name="colMove">Average column coordinate shift. Default: 0</param>
        /// <param name="rowTolerance">Half height of matching search window. Default: 256</param>
        /// <param name="colTolerance">Half width of matching search window. Default: 256</param>
        /// <param name="rotation">Range of rotation angles. Default: 0.0</param>
        /// <param name="matchThreshold">Threshold for gray value matching. Default: 10</param>
        /// <param name="estimationMethod">Transformation matrix estimation algorithm. Default: "normalized_dlt"</param>
        /// <param name="distanceThreshold">Threshold for transformation consistency check. Default: 0.2</param>
        /// <param name="randSeed">Seed for the random number generator. Default: 0</param>
        /// <param name="points2">Indices of matched input points in image 2.</param>
        /// <returns>Indices of matched input points in image 1.</returns>
        public HTuple ProjMatchPointsRansac(
          HImage image1,
          HImage image2,
          HTuple rows1,
          HTuple cols1,
          HTuple rows2,
          HTuple cols2,
          string grayMatchMethod,
          int maskSize,
          int rowMove,
          int colMove,
          int rowTolerance,
          int colTolerance,
          HTuple rotation,
          HTuple matchThreshold,
          string estimationMethod,
          double distanceThreshold,
          int randSeed,
          out HTuple points2)
        {
            IntPtr proc = HalconAPI.PreCall(259);
            HalconAPI.Store(proc, 1, (HObjectBase)image1);
            HalconAPI.Store(proc, 2, (HObjectBase)image2);
            HalconAPI.Store(proc, 0, rows1);
            HalconAPI.Store(proc, 1, cols1);
            HalconAPI.Store(proc, 2, rows2);
            HalconAPI.Store(proc, 3, cols2);
            HalconAPI.StoreS(proc, 4, grayMatchMethod);
            HalconAPI.StoreI(proc, 5, maskSize);
            HalconAPI.StoreI(proc, 6, rowMove);
            HalconAPI.StoreI(proc, 7, colMove);
            HalconAPI.StoreI(proc, 8, rowTolerance);
            HalconAPI.StoreI(proc, 9, colTolerance);
            HalconAPI.Store(proc, 10, rotation);
            HalconAPI.Store(proc, 11, matchThreshold);
            HalconAPI.StoreS(proc, 12, estimationMethod);
            HalconAPI.StoreD(proc, 13, distanceThreshold);
            HalconAPI.StoreI(proc, 14, randSeed);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(rows1);
            HalconAPI.UnpinTuple(cols1);
            HalconAPI.UnpinTuple(rows2);
            HalconAPI.UnpinTuple(cols2);
            HalconAPI.UnpinTuple(rotation);
            HalconAPI.UnpinTuple(matchThreshold);
            int err2 = this.Load(proc, 0, err1);
            HTuple tuple;
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out tuple);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, err3, out points2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image1);
            GC.KeepAlive((object)image2);
            return tuple;
        }

        /// <summary>
        ///   Compute a projective transformation matrix between two images by finding correspondences between points.
        ///   Modified instance represents: Homogeneous projective transformation matrix.
        /// </summary>
        /// <param name="image1">Input image 1.</param>
        /// <param name="image2">Input image 2.</param>
        /// <param name="rows1">Row coordinates of characteristic points in image 1.</param>
        /// <param name="cols1">Column coordinates of characteristic points in image 1.</param>
        /// <param name="rows2">Row coordinates of characteristic points in image 2.</param>
        /// <param name="cols2">Column coordinates of characteristic points in image 2.</param>
        /// <param name="grayMatchMethod">Gray value comparison metric. Default: "ssd"</param>
        /// <param name="maskSize">Size of gray value masks. Default: 10</param>
        /// <param name="rowMove">Average row coordinate shift. Default: 0</param>
        /// <param name="colMove">Average column coordinate shift. Default: 0</param>
        /// <param name="rowTolerance">Half height of matching search window. Default: 256</param>
        /// <param name="colTolerance">Half width of matching search window. Default: 256</param>
        /// <param name="rotation">Range of rotation angles. Default: 0.0</param>
        /// <param name="matchThreshold">Threshold for gray value matching. Default: 10</param>
        /// <param name="estimationMethod">Transformation matrix estimation algorithm. Default: "normalized_dlt"</param>
        /// <param name="distanceThreshold">Threshold for transformation consistency check. Default: 0.2</param>
        /// <param name="randSeed">Seed for the random number generator. Default: 0</param>
        /// <param name="points2">Indices of matched input points in image 2.</param>
        /// <returns>Indices of matched input points in image 1.</returns>
        public HTuple ProjMatchPointsRansac(
          HImage image1,
          HImage image2,
          HTuple rows1,
          HTuple cols1,
          HTuple rows2,
          HTuple cols2,
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
          out HTuple points2)
        {
            IntPtr proc = HalconAPI.PreCall(259);
            HalconAPI.Store(proc, 1, (HObjectBase)image1);
            HalconAPI.Store(proc, 2, (HObjectBase)image2);
            HalconAPI.Store(proc, 0, rows1);
            HalconAPI.Store(proc, 1, cols1);
            HalconAPI.Store(proc, 2, rows2);
            HalconAPI.Store(proc, 3, cols2);
            HalconAPI.StoreS(proc, 4, grayMatchMethod);
            HalconAPI.StoreI(proc, 5, maskSize);
            HalconAPI.StoreI(proc, 6, rowMove);
            HalconAPI.StoreI(proc, 7, colMove);
            HalconAPI.StoreI(proc, 8, rowTolerance);
            HalconAPI.StoreI(proc, 9, colTolerance);
            HalconAPI.StoreD(proc, 10, rotation);
            HalconAPI.StoreI(proc, 11, matchThreshold);
            HalconAPI.StoreS(proc, 12, estimationMethod);
            HalconAPI.StoreD(proc, 13, distanceThreshold);
            HalconAPI.StoreI(proc, 14, randSeed);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(rows1);
            HalconAPI.UnpinTuple(cols1);
            HalconAPI.UnpinTuple(rows2);
            HalconAPI.UnpinTuple(cols2);
            int err2 = this.Load(proc, 0, err1);
            HTuple tuple;
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out tuple);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, err3, out points2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image1);
            GC.KeepAlive((object)image2);
            return tuple;
        }

        /// <summary>
        ///   Compute a projective transformation matrix and the radial distortion coefficient using given image point correspondences.
        ///   Modified instance represents: Homogeneous projective transformation matrix.
        /// </summary>
        /// <param name="points1Row">Input points in image 1 (row coordinate).</param>
        /// <param name="points1Col">Input points in image 1 (column coordinate).</param>
        /// <param name="points2Row">Input points in image 2 (row coordinate).</param>
        /// <param name="points2Col">Input points in image 2 (column coordinate).</param>
        /// <param name="covRR1">Row coordinate variance of the points in image 1. Default: []</param>
        /// <param name="covRC1">Covariance of the points in image 1. Default: []</param>
        /// <param name="covCC1">Column coordinate variance of the points in image 1. Default: []</param>
        /// <param name="covRR2">Row coordinate variance of the points in image 2. Default: []</param>
        /// <param name="covRC2">Covariance of the points in image 2. Default: []</param>
        /// <param name="covCC2">Column coordinate variance of the points in image 2. Default: []</param>
        /// <param name="imageWidth">Width of the images from which the points were extracted.</param>
        /// <param name="imageHeight">Height of the images from which the points were extracted.</param>
        /// <param name="method">Estimation algorithm. Default: "gold_standard"</param>
        /// <param name="error">Root-Mean-Square transformation error.</param>
        /// <returns>Computed radial distortion coefficient.</returns>
        public double VectorToProjHomMat2dDistortion(
          HTuple points1Row,
          HTuple points1Col,
          HTuple points2Row,
          HTuple points2Col,
          HTuple covRR1,
          HTuple covRC1,
          HTuple covCC1,
          HTuple covRR2,
          HTuple covRC2,
          HTuple covCC2,
          int imageWidth,
          int imageHeight,
          string method,
          out double error)
        {
            IntPtr proc = HalconAPI.PreCall(260);
            HalconAPI.Store(proc, 0, points1Row);
            HalconAPI.Store(proc, 1, points1Col);
            HalconAPI.Store(proc, 2, points2Row);
            HalconAPI.Store(proc, 3, points2Col);
            HalconAPI.Store(proc, 4, covRR1);
            HalconAPI.Store(proc, 5, covRC1);
            HalconAPI.Store(proc, 6, covCC1);
            HalconAPI.Store(proc, 7, covRR2);
            HalconAPI.Store(proc, 8, covRC2);
            HalconAPI.Store(proc, 9, covCC2);
            HalconAPI.StoreI(proc, 10, imageWidth);
            HalconAPI.StoreI(proc, 11, imageHeight);
            HalconAPI.StoreS(proc, 12, method);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(points1Row);
            HalconAPI.UnpinTuple(points1Col);
            HalconAPI.UnpinTuple(points2Row);
            HalconAPI.UnpinTuple(points2Col);
            HalconAPI.UnpinTuple(covRR1);
            HalconAPI.UnpinTuple(covRC1);
            HalconAPI.UnpinTuple(covCC1);
            HalconAPI.UnpinTuple(covRR2);
            HalconAPI.UnpinTuple(covRC2);
            HalconAPI.UnpinTuple(covCC2);
            int err2 = this.Load(proc, 0, err1);
            double doubleValue;
            int err3 = HalconAPI.LoadD(proc, 1, err2, out doubleValue);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out error);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Compute a homogeneous transformation matrix using given point correspondences.
        ///   Modified instance represents: Homogeneous projective transformation matrix.
        /// </summary>
        /// <param name="px">Input points 1 (x coordinate).</param>
        /// <param name="py">Input points 1 (y coordinate).</param>
        /// <param name="pw">Input points 1 (w coordinate).</param>
        /// <param name="qx">Input points 2 (x coordinate).</param>
        /// <param name="qy">Input points 2 (y coordinate).</param>
        /// <param name="qw">Input points 2 (w coordinate).</param>
        /// <param name="method">Estimation algorithm. Default: "normalized_dlt"</param>
        public void HomVectorToProjHomMat2d(
          HTuple px,
          HTuple py,
          HTuple pw,
          HTuple qx,
          HTuple qy,
          HTuple qw,
          string method)
        {
            IntPtr proc = HalconAPI.PreCall(261);
            HalconAPI.Store(proc, 0, px);
            HalconAPI.Store(proc, 1, py);
            HalconAPI.Store(proc, 2, pw);
            HalconAPI.Store(proc, 3, qx);
            HalconAPI.Store(proc, 4, qy);
            HalconAPI.Store(proc, 5, qw);
            HalconAPI.StoreS(proc, 6, method);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(px);
            HalconAPI.UnpinTuple(py);
            HalconAPI.UnpinTuple(pw);
            HalconAPI.UnpinTuple(qx);
            HalconAPI.UnpinTuple(qy);
            HalconAPI.UnpinTuple(qw);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Compute a projective transformation matrix using given point correspondences.
        ///   Modified instance represents: Homogeneous projective transformation matrix.
        /// </summary>
        /// <param name="px">Input points in image 1 (row coordinate).</param>
        /// <param name="py">Input points in image 1 (column coordinate).</param>
        /// <param name="qx">Input points in image 2 (row coordinate).</param>
        /// <param name="qy">Input points in image 2 (column coordinate).</param>
        /// <param name="method">Estimation algorithm. Default: "normalized_dlt"</param>
        /// <param name="covXX1">Row coordinate variance of the points in image 1. Default: []</param>
        /// <param name="covYY1">Column coordinate variance of the points in image 1. Default: []</param>
        /// <param name="covXY1">Covariance of the points in image 1. Default: []</param>
        /// <param name="covXX2">Row coordinate variance of the points in image 2. Default: []</param>
        /// <param name="covYY2">Column coordinate variance of the points in image 2. Default: []</param>
        /// <param name="covXY2">Covariance of the points in image 2. Default: []</param>
        /// <returns>9x9 covariance matrix of the projective transformation matrix.</returns>
        public HTuple VectorToProjHomMat2d(
          HTuple px,
          HTuple py,
          HTuple qx,
          HTuple qy,
          string method,
          HTuple covXX1,
          HTuple covYY1,
          HTuple covXY1,
          HTuple covXX2,
          HTuple covYY2,
          HTuple covXY2)
        {
            IntPtr proc = HalconAPI.PreCall(262);
            HalconAPI.Store(proc, 0, px);
            HalconAPI.Store(proc, 1, py);
            HalconAPI.Store(proc, 2, qx);
            HalconAPI.Store(proc, 3, qy);
            HalconAPI.StoreS(proc, 4, method);
            HalconAPI.Store(proc, 5, covXX1);
            HalconAPI.Store(proc, 6, covYY1);
            HalconAPI.Store(proc, 7, covXY1);
            HalconAPI.Store(proc, 8, covXX2);
            HalconAPI.Store(proc, 9, covYY2);
            HalconAPI.Store(proc, 10, covXY2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(px);
            HalconAPI.UnpinTuple(py);
            HalconAPI.UnpinTuple(qx);
            HalconAPI.UnpinTuple(qy);
            HalconAPI.UnpinTuple(covXX1);
            HalconAPI.UnpinTuple(covYY1);
            HalconAPI.UnpinTuple(covXY1);
            HalconAPI.UnpinTuple(covXX2);
            HalconAPI.UnpinTuple(covYY2);
            HalconAPI.UnpinTuple(covXY2);
            int err2 = this.Load(proc, 0, err1);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the affine transformation parameters from a homogeneous 2D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="sy">Scaling factor along the y direction.</param>
        /// <param name="phi">Rotation angle.</param>
        /// <param name="theta">Slant angle.</param>
        /// <param name="tx">Translation along the x direction.</param>
        /// <param name="ty">Translation along the y direction.</param>
        /// <returns>Scaling factor along the x direction.</returns>
        public double HomMat2dToAffinePar(
          out double sy,
          out double phi,
          out double theta,
          out double tx,
          out double ty)
        {
            IntPtr proc = HalconAPI.PreCall(263);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out sy);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out phi);
            int err5 = HalconAPI.LoadD(proc, 3, err4, out theta);
            int err6 = HalconAPI.LoadD(proc, 4, err5, out tx);
            int procResult = HalconAPI.LoadD(proc, 5, err6, out ty);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Compute a rigid affine transformation from points and angles.
        ///   Modified instance represents: Output transformation matrix.
        /// </summary>
        /// <param name="row1">Row coordinate of the original point.</param>
        /// <param name="column1">Column coordinate of the original point.</param>
        /// <param name="angle1">Angle of the original point.</param>
        /// <param name="row2">Row coordinate of the transformed point.</param>
        /// <param name="column2">Column coordinate of the transformed point.</param>
        /// <param name="angle2">Angle of the transformed point.</param>
        public void VectorAngleToRigid(
          HTuple row1,
          HTuple column1,
          HTuple angle1,
          HTuple row2,
          HTuple column2,
          HTuple angle2)
        {
            IntPtr proc = HalconAPI.PreCall(264);
            HalconAPI.Store(proc, 0, row1);
            HalconAPI.Store(proc, 1, column1);
            HalconAPI.Store(proc, 2, angle1);
            HalconAPI.Store(proc, 3, row2);
            HalconAPI.Store(proc, 4, column2);
            HalconAPI.Store(proc, 5, angle2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row1);
            HalconAPI.UnpinTuple(column1);
            HalconAPI.UnpinTuple(angle1);
            HalconAPI.UnpinTuple(row2);
            HalconAPI.UnpinTuple(column2);
            HalconAPI.UnpinTuple(angle2);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Compute a rigid affine transformation from points and angles.
        ///   Modified instance represents: Output transformation matrix.
        /// </summary>
        /// <param name="row1">Row coordinate of the original point.</param>
        /// <param name="column1">Column coordinate of the original point.</param>
        /// <param name="angle1">Angle of the original point.</param>
        /// <param name="row2">Row coordinate of the transformed point.</param>
        /// <param name="column2">Column coordinate of the transformed point.</param>
        /// <param name="angle2">Angle of the transformed point.</param>
        public void VectorAngleToRigid(
          double row1,
          double column1,
          double angle1,
          double row2,
          double column2,
          double angle2)
        {
            IntPtr proc = HalconAPI.PreCall(264);
            HalconAPI.StoreD(proc, 0, row1);
            HalconAPI.StoreD(proc, 1, column1);
            HalconAPI.StoreD(proc, 2, angle1);
            HalconAPI.StoreD(proc, 3, row2);
            HalconAPI.StoreD(proc, 4, column2);
            HalconAPI.StoreD(proc, 5, angle2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Approximate an affine transformation from point-to-line correspondences.
        ///   Modified instance represents: Output transformation matrix.
        /// </summary>
        /// <param name="transformationType">Type of the transformation to compute. Default: "rigid"</param>
        /// <param name="px">X coordinates of the original points.</param>
        /// <param name="py">Y coordinates of the original points.</param>
        /// <param name="l1x">X coordinates of the first point on the corresponding line.</param>
        /// <param name="l1y">Y coordinates of the first point on the corresponding line.</param>
        /// <param name="l2x">X coordinates of the second point on the corresponding line.</param>
        /// <param name="l2y">Y coordinates of the second point on the corresponding line.</param>
        public void PointLineToHomMat2d(
          string transformationType,
          HTuple px,
          HTuple py,
          HTuple l1x,
          HTuple l1y,
          HTuple l2x,
          HTuple l2y)
        {
            IntPtr proc = HalconAPI.PreCall(265);
            HalconAPI.StoreS(proc, 0, transformationType);
            HalconAPI.Store(proc, 1, px);
            HalconAPI.Store(proc, 2, py);
            HalconAPI.Store(proc, 3, l1x);
            HalconAPI.Store(proc, 4, l1y);
            HalconAPI.Store(proc, 5, l2x);
            HalconAPI.Store(proc, 6, l2y);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(px);
            HalconAPI.UnpinTuple(py);
            HalconAPI.UnpinTuple(l1x);
            HalconAPI.UnpinTuple(l1y);
            HalconAPI.UnpinTuple(l2x);
            HalconAPI.UnpinTuple(l2y);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Approximate a rigid affine transformation from point correspondences.
        ///   Modified instance represents: Output transformation matrix.
        /// </summary>
        /// <param name="px">X coordinates of the original points.</param>
        /// <param name="py">Y coordinates of the original points.</param>
        /// <param name="qx">X coordinates of the transformed points.</param>
        /// <param name="qy">Y coordinates of the transformed points.</param>
        public void VectorToRigid(HTuple px, HTuple py, HTuple qx, HTuple qy)
        {
            IntPtr proc = HalconAPI.PreCall(266);
            HalconAPI.Store(proc, 0, px);
            HalconAPI.Store(proc, 1, py);
            HalconAPI.Store(proc, 2, qx);
            HalconAPI.Store(proc, 3, qy);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(px);
            HalconAPI.UnpinTuple(py);
            HalconAPI.UnpinTuple(qx);
            HalconAPI.UnpinTuple(qy);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Approximate an similarity transformation from point correspondences.
        ///   Modified instance represents: Output transformation matrix.
        /// </summary>
        /// <param name="px">X coordinates of the original points.</param>
        /// <param name="py">Y coordinates of the original points.</param>
        /// <param name="qx">X coordinates of the transformed points.</param>
        /// <param name="qy">Y coordinates of the transformed points.</param>
        public void VectorToSimilarity(HTuple px, HTuple py, HTuple qx, HTuple qy)
        {
            IntPtr proc = HalconAPI.PreCall(267);
            HalconAPI.Store(proc, 0, px);
            HalconAPI.Store(proc, 1, py);
            HalconAPI.Store(proc, 2, qx);
            HalconAPI.Store(proc, 3, qy);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(px);
            HalconAPI.UnpinTuple(py);
            HalconAPI.UnpinTuple(qx);
            HalconAPI.UnpinTuple(qy);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Approximate an anisotropic similarity transformation from point correspondences.
        ///   Modified instance represents: Output transformation matrix.
        /// </summary>
        /// <param name="px">X coordinates of the original points.</param>
        /// <param name="py">Y coordinates of the original points.</param>
        /// <param name="qx">X coordinates of the transformed points.</param>
        /// <param name="qy">Y coordinates of the transformed points.</param>
        public void VectorToAniso(HTuple px, HTuple py, HTuple qx, HTuple qy)
        {
            IntPtr proc = HalconAPI.PreCall(268);
            HalconAPI.Store(proc, 0, px);
            HalconAPI.Store(proc, 1, py);
            HalconAPI.Store(proc, 2, qx);
            HalconAPI.Store(proc, 3, qy);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(px);
            HalconAPI.UnpinTuple(py);
            HalconAPI.UnpinTuple(qx);
            HalconAPI.UnpinTuple(qy);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Approximate an affine transformation from point correspondences.
        ///   Modified instance represents: Output transformation matrix.
        /// </summary>
        /// <param name="px">X coordinates of the original points.</param>
        /// <param name="py">Y coordinates of the original points.</param>
        /// <param name="qx">X coordinates of the transformed points.</param>
        /// <param name="qy">Y coordinates of the transformed points.</param>
        public void VectorToHomMat2d(HTuple px, HTuple py, HTuple qx, HTuple qy)
        {
            IntPtr proc = HalconAPI.PreCall(269);
            HalconAPI.Store(proc, 0, px);
            HalconAPI.Store(proc, 1, py);
            HalconAPI.Store(proc, 2, qx);
            HalconAPI.Store(proc, 3, qy);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(px);
            HalconAPI.UnpinTuple(py);
            HalconAPI.UnpinTuple(qx);
            HalconAPI.UnpinTuple(qy);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Project pixel coordinates using a homogeneous projective transformation matrix.
        ///   Instance represents: Homogeneous projective transformation matrix.
        /// </summary>
        /// <param name="row">Input pixel(s) (row coordinate). Default: 64</param>
        /// <param name="col">Input pixel(s) (column coordinate). Default: 64</param>
        /// <param name="rowTrans">Output pixel(s) (row coordinate).</param>
        /// <param name="colTrans">Output pixel(s) (column coordinate).</param>
        public void ProjectiveTransPixel(
          HTuple row,
          HTuple col,
          out HTuple rowTrans,
          out HTuple colTrans)
        {
            IntPtr proc = HalconAPI.PreCall(270);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, row);
            HalconAPI.Store(proc, 2, col);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(col);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out rowTrans);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out colTrans);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Project pixel coordinates using a homogeneous projective transformation matrix.
        ///   Instance represents: Homogeneous projective transformation matrix.
        /// </summary>
        /// <param name="row">Input pixel(s) (row coordinate). Default: 64</param>
        /// <param name="col">Input pixel(s) (column coordinate). Default: 64</param>
        /// <param name="rowTrans">Output pixel(s) (row coordinate).</param>
        /// <param name="colTrans">Output pixel(s) (column coordinate).</param>
        public void ProjectiveTransPixel(
          double row,
          double col,
          out double rowTrans,
          out double colTrans)
        {
            IntPtr proc = HalconAPI.PreCall(270);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, row);
            HalconAPI.StoreD(proc, 2, col);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            int err2 = HalconAPI.LoadD(proc, 0, err1, out rowTrans);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out colTrans);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Project a homogeneous 2D point using a projective transformation matrix.
        ///   Instance represents: Homogeneous projective transformation matrix.
        /// </summary>
        /// <param name="px">Input point (x coordinate).</param>
        /// <param name="py">Input point (y coordinate).</param>
        /// <param name="pw">Input point (w coordinate).</param>
        /// <param name="qy">Output point (y coordinate).</param>
        /// <param name="qw">Output point (w coordinate).</param>
        /// <returns>Output point (x coordinate).</returns>
        public HTuple ProjectiveTransPoint2d(
          HTuple px,
          HTuple py,
          HTuple pw,
          out HTuple qy,
          out HTuple qw)
        {
            IntPtr proc = HalconAPI.PreCall(271);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, px);
            HalconAPI.Store(proc, 2, py);
            HalconAPI.Store(proc, 3, pw);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(px);
            HalconAPI.UnpinTuple(py);
            HalconAPI.UnpinTuple(pw);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out qy);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out qw);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Project a homogeneous 2D point using a projective transformation matrix.
        ///   Instance represents: Homogeneous projective transformation matrix.
        /// </summary>
        /// <param name="px">Input point (x coordinate).</param>
        /// <param name="py">Input point (y coordinate).</param>
        /// <param name="pw">Input point (w coordinate).</param>
        /// <param name="qy">Output point (y coordinate).</param>
        /// <param name="qw">Output point (w coordinate).</param>
        /// <returns>Output point (x coordinate).</returns>
        public double ProjectiveTransPoint2d(
          double px,
          double py,
          double pw,
          out double qy,
          out double qw)
        {
            IntPtr proc = HalconAPI.PreCall(271);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, px);
            HalconAPI.StoreD(proc, 2, py);
            HalconAPI.StoreD(proc, 3, pw);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out qy);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out qw);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Apply an arbitrary affine 2D transformation to pixel coordinates.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="row">Input pixel(s) (row coordinate). Default: 64</param>
        /// <param name="col">Input pixel(s) (column coordinate). Default: 64</param>
        /// <param name="rowTrans">Output pixel(s) (row coordinate).</param>
        /// <param name="colTrans">Output pixel(s) (column coordinate).</param>
        public void AffineTransPixel(HTuple row, HTuple col, out HTuple rowTrans, out HTuple colTrans)
        {
            IntPtr proc = HalconAPI.PreCall(272);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, row);
            HalconAPI.Store(proc, 2, col);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(col);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out rowTrans);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out colTrans);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Apply an arbitrary affine 2D transformation to pixel coordinates.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="row">Input pixel(s) (row coordinate). Default: 64</param>
        /// <param name="col">Input pixel(s) (column coordinate). Default: 64</param>
        /// <param name="rowTrans">Output pixel(s) (row coordinate).</param>
        /// <param name="colTrans">Output pixel(s) (column coordinate).</param>
        public void AffineTransPixel(double row, double col, out double rowTrans, out double colTrans)
        {
            IntPtr proc = HalconAPI.PreCall(272);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, row);
            HalconAPI.StoreD(proc, 2, col);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            int err2 = HalconAPI.LoadD(proc, 0, err1, out rowTrans);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out colTrans);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Apply an arbitrary affine 2D transformation to points.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="px">Input point(s) (x or row coordinate). Default: 64</param>
        /// <param name="py">Input point(s) (y or column coordinate). Default: 64</param>
        /// <param name="qy">Output point(s) (y or column coordinate).</param>
        /// <returns>Output point(s) (x or row coordinate).</returns>
        public HTuple AffineTransPoint2d(HTuple px, HTuple py, out HTuple qy)
        {
            IntPtr proc = HalconAPI.PreCall(273);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, px);
            HalconAPI.Store(proc, 2, py);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(px);
            HalconAPI.UnpinTuple(py);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out qy);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Apply an arbitrary affine 2D transformation to points.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="px">Input point(s) (x or row coordinate). Default: 64</param>
        /// <param name="py">Input point(s) (y or column coordinate). Default: 64</param>
        /// <param name="qy">Output point(s) (y or column coordinate).</param>
        /// <returns>Output point(s) (x or row coordinate).</returns>
        public double AffineTransPoint2d(double px, double py, out double qy)
        {
            IntPtr proc = HalconAPI.PreCall(273);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, px);
            HalconAPI.StoreD(proc, 2, py);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out qy);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Compute the determinant of a homogeneous 2D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <returns>Determinant of the input matrix.</returns>
        public double HomMat2dDeterminant()
        {
            IntPtr proc = HalconAPI.PreCall(274);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Transpose a homogeneous 2D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat2D HomMat2dTranspose()
        {
            IntPtr proc = HalconAPI.PreCall(275);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HHomMat2D hhomMat2D;
            int procResult = HHomMat2D.LoadNew(proc, 0, err, out hhomMat2D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat2D;
        }

        /// <summary>
        ///   Invert a homogeneous 2D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat2D HomMat2dInvert()
        {
            IntPtr proc = HalconAPI.PreCall(276);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HHomMat2D hhomMat2D;
            int procResult = HHomMat2D.LoadNew(proc, 0, err, out hhomMat2D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat2D;
        }

        /// <summary>
        ///   Multiply two homogeneous 2D transformation matrices.
        ///   Instance represents: Left input transformation matrix.
        /// </summary>
        /// <param name="homMat2DRight">Right input transformation matrix.</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat2D HomMat2dCompose(HHomMat2D homMat2DRight)
        {
            IntPtr proc = HalconAPI.PreCall(277);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HData)homMat2DRight);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple((HTuple)((HData)homMat2DRight));
            HHomMat2D hhomMat2D;
            int procResult = HHomMat2D.LoadNew(proc, 0, err, out hhomMat2D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat2D;
        }

        /// <summary>
        ///   Add a reflection to a homogeneous 2D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="px">Point that defines the axis (x coordinate). Default: 16</param>
        /// <param name="py">Point that defines the axis (y coordinate). Default: 32</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat2D HomMat2dReflectLocal(HTuple px, HTuple py)
        {
            IntPtr proc = HalconAPI.PreCall(278);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, px);
            HalconAPI.Store(proc, 2, py);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(px);
            HalconAPI.UnpinTuple(py);
            HHomMat2D hhomMat2D;
            int procResult = HHomMat2D.LoadNew(proc, 0, err, out hhomMat2D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat2D;
        }

        /// <summary>
        ///   Add a reflection to a homogeneous 2D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="px">Point that defines the axis (x coordinate). Default: 16</param>
        /// <param name="py">Point that defines the axis (y coordinate). Default: 32</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat2D HomMat2dReflectLocal(double px, double py)
        {
            IntPtr proc = HalconAPI.PreCall(278);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, px);
            HalconAPI.StoreD(proc, 2, py);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HHomMat2D hhomMat2D;
            int procResult = HHomMat2D.LoadNew(proc, 0, err, out hhomMat2D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat2D;
        }

        /// <summary>
        ///   Add a reflection to a homogeneous 2D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="px">First point of the axis (x coordinate). Default: 0</param>
        /// <param name="py">First point of the axis (y coordinate). Default: 0</param>
        /// <param name="qx">Second point of the axis (x coordinate). Default: 16</param>
        /// <param name="qy">Second point of the axis (y coordinate). Default: 32</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat2D HomMat2dReflect(HTuple px, HTuple py, HTuple qx, HTuple qy)
        {
            IntPtr proc = HalconAPI.PreCall(279);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, px);
            HalconAPI.Store(proc, 2, py);
            HalconAPI.Store(proc, 3, qx);
            HalconAPI.Store(proc, 4, qy);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(px);
            HalconAPI.UnpinTuple(py);
            HalconAPI.UnpinTuple(qx);
            HalconAPI.UnpinTuple(qy);
            HHomMat2D hhomMat2D;
            int procResult = HHomMat2D.LoadNew(proc, 0, err, out hhomMat2D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat2D;
        }

        /// <summary>
        ///   Add a reflection to a homogeneous 2D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="px">First point of the axis (x coordinate). Default: 0</param>
        /// <param name="py">First point of the axis (y coordinate). Default: 0</param>
        /// <param name="qx">Second point of the axis (x coordinate). Default: 16</param>
        /// <param name="qy">Second point of the axis (y coordinate). Default: 32</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat2D HomMat2dReflect(double px, double py, double qx, double qy)
        {
            IntPtr proc = HalconAPI.PreCall(279);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, px);
            HalconAPI.StoreD(proc, 2, py);
            HalconAPI.StoreD(proc, 3, qx);
            HalconAPI.StoreD(proc, 4, qy);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HHomMat2D hhomMat2D;
            int procResult = HHomMat2D.LoadNew(proc, 0, err, out hhomMat2D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat2D;
        }

        /// <summary>
        ///   Add a slant to a homogeneous 2D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="theta">Slant angle. Default: 0.78</param>
        /// <param name="axis">Coordinate axis that is slanted. Default: "x"</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat2D HomMat2dSlantLocal(HTuple theta, string axis)
        {
            IntPtr proc = HalconAPI.PreCall(280);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, theta);
            HalconAPI.StoreS(proc, 2, axis);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(theta);
            HHomMat2D hhomMat2D;
            int procResult = HHomMat2D.LoadNew(proc, 0, err, out hhomMat2D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat2D;
        }

        /// <summary>
        ///   Add a slant to a homogeneous 2D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="theta">Slant angle. Default: 0.78</param>
        /// <param name="axis">Coordinate axis that is slanted. Default: "x"</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat2D HomMat2dSlantLocal(double theta, string axis)
        {
            IntPtr proc = HalconAPI.PreCall(280);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, theta);
            HalconAPI.StoreS(proc, 2, axis);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HHomMat2D hhomMat2D;
            int procResult = HHomMat2D.LoadNew(proc, 0, err, out hhomMat2D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat2D;
        }

        /// <summary>
        ///   Add a slant to a homogeneous 2D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="theta">Slant angle. Default: 0.78</param>
        /// <param name="axis">Coordinate axis that is slanted. Default: "x"</param>
        /// <param name="px">Fixed point of the transformation (x coordinate). Default: 0</param>
        /// <param name="py">Fixed point of the transformation (y coordinate). Default: 0</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat2D HomMat2dSlant(HTuple theta, string axis, HTuple px, HTuple py)
        {
            IntPtr proc = HalconAPI.PreCall(281);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, theta);
            HalconAPI.StoreS(proc, 2, axis);
            HalconAPI.Store(proc, 3, px);
            HalconAPI.Store(proc, 4, py);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(theta);
            HalconAPI.UnpinTuple(px);
            HalconAPI.UnpinTuple(py);
            HHomMat2D hhomMat2D;
            int procResult = HHomMat2D.LoadNew(proc, 0, err, out hhomMat2D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat2D;
        }

        /// <summary>
        ///   Add a slant to a homogeneous 2D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="theta">Slant angle. Default: 0.78</param>
        /// <param name="axis">Coordinate axis that is slanted. Default: "x"</param>
        /// <param name="px">Fixed point of the transformation (x coordinate). Default: 0</param>
        /// <param name="py">Fixed point of the transformation (y coordinate). Default: 0</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat2D HomMat2dSlant(double theta, string axis, double px, double py)
        {
            IntPtr proc = HalconAPI.PreCall(281);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, theta);
            HalconAPI.StoreS(proc, 2, axis);
            HalconAPI.StoreD(proc, 3, px);
            HalconAPI.StoreD(proc, 4, py);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HHomMat2D hhomMat2D;
            int procResult = HHomMat2D.LoadNew(proc, 0, err, out hhomMat2D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat2D;
        }

        /// <summary>
        ///   Add a rotation to a homogeneous 2D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="phi">Rotation angle. Default: 0.78</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat2D HomMat2dRotateLocal(HTuple phi)
        {
            IntPtr proc = HalconAPI.PreCall(282);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, phi);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(phi);
            HHomMat2D hhomMat2D;
            int procResult = HHomMat2D.LoadNew(proc, 0, err, out hhomMat2D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat2D;
        }

        /// <summary>
        ///   Add a rotation to a homogeneous 2D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="phi">Rotation angle. Default: 0.78</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat2D HomMat2dRotateLocal(double phi)
        {
            IntPtr proc = HalconAPI.PreCall(282);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, phi);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HHomMat2D hhomMat2D;
            int procResult = HHomMat2D.LoadNew(proc, 0, err, out hhomMat2D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat2D;
        }

        /// <summary>
        ///   Add a rotation to a homogeneous 2D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="phi">Rotation angle. Default: 0.78</param>
        /// <param name="px">Fixed point of the transformation (x coordinate). Default: 0</param>
        /// <param name="py">Fixed point of the transformation (y coordinate). Default: 0</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat2D HomMat2dRotate(HTuple phi, HTuple px, HTuple py)
        {
            IntPtr proc = HalconAPI.PreCall(283);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, phi);
            HalconAPI.Store(proc, 2, px);
            HalconAPI.Store(proc, 3, py);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(phi);
            HalconAPI.UnpinTuple(px);
            HalconAPI.UnpinTuple(py);
            HHomMat2D hhomMat2D;
            int procResult = HHomMat2D.LoadNew(proc, 0, err, out hhomMat2D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat2D;
        }

        /// <summary>
        ///   Add a rotation to a homogeneous 2D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="phi">Rotation angle. Default: 0.78</param>
        /// <param name="px">Fixed point of the transformation (x coordinate). Default: 0</param>
        /// <param name="py">Fixed point of the transformation (y coordinate). Default: 0</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat2D HomMat2dRotate(double phi, double px, double py)
        {
            IntPtr proc = HalconAPI.PreCall(283);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, phi);
            HalconAPI.StoreD(proc, 2, px);
            HalconAPI.StoreD(proc, 3, py);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HHomMat2D hhomMat2D;
            int procResult = HHomMat2D.LoadNew(proc, 0, err, out hhomMat2D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat2D;
        }

        /// <summary>
        ///   Add a scaling to a homogeneous 2D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="sx">Scale factor along the x-axis. Default: 2</param>
        /// <param name="sy">Scale factor along the y-axis. Default: 2</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat2D HomMat2dScaleLocal(HTuple sx, HTuple sy)
        {
            IntPtr proc = HalconAPI.PreCall(284);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, sx);
            HalconAPI.Store(proc, 2, sy);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(sx);
            HalconAPI.UnpinTuple(sy);
            HHomMat2D hhomMat2D;
            int procResult = HHomMat2D.LoadNew(proc, 0, err, out hhomMat2D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat2D;
        }

        /// <summary>
        ///   Add a scaling to a homogeneous 2D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="sx">Scale factor along the x-axis. Default: 2</param>
        /// <param name="sy">Scale factor along the y-axis. Default: 2</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat2D HomMat2dScaleLocal(double sx, double sy)
        {
            IntPtr proc = HalconAPI.PreCall(284);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, sx);
            HalconAPI.StoreD(proc, 2, sy);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HHomMat2D hhomMat2D;
            int procResult = HHomMat2D.LoadNew(proc, 0, err, out hhomMat2D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat2D;
        }

        /// <summary>
        ///   Add a scaling to a homogeneous 2D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="sx">Scale factor along the x-axis. Default: 2</param>
        /// <param name="sy">Scale factor along the y-axis. Default: 2</param>
        /// <param name="px">Fixed point of the transformation (x coordinate). Default: 0</param>
        /// <param name="py">Fixed point of the transformation (y coordinate). Default: 0</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat2D HomMat2dScale(HTuple sx, HTuple sy, HTuple px, HTuple py)
        {
            IntPtr proc = HalconAPI.PreCall(285);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, sx);
            HalconAPI.Store(proc, 2, sy);
            HalconAPI.Store(proc, 3, px);
            HalconAPI.Store(proc, 4, py);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(sx);
            HalconAPI.UnpinTuple(sy);
            HalconAPI.UnpinTuple(px);
            HalconAPI.UnpinTuple(py);
            HHomMat2D hhomMat2D;
            int procResult = HHomMat2D.LoadNew(proc, 0, err, out hhomMat2D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat2D;
        }

        /// <summary>
        ///   Add a scaling to a homogeneous 2D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="sx">Scale factor along the x-axis. Default: 2</param>
        /// <param name="sy">Scale factor along the y-axis. Default: 2</param>
        /// <param name="px">Fixed point of the transformation (x coordinate). Default: 0</param>
        /// <param name="py">Fixed point of the transformation (y coordinate). Default: 0</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat2D HomMat2dScale(double sx, double sy, double px, double py)
        {
            IntPtr proc = HalconAPI.PreCall(285);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, sx);
            HalconAPI.StoreD(proc, 2, sy);
            HalconAPI.StoreD(proc, 3, px);
            HalconAPI.StoreD(proc, 4, py);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HHomMat2D hhomMat2D;
            int procResult = HHomMat2D.LoadNew(proc, 0, err, out hhomMat2D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat2D;
        }

        /// <summary>
        ///   Add a translation to a homogeneous 2D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="tx">Translation along the x-axis. Default: 64</param>
        /// <param name="ty">Translation along the y-axis. Default: 64</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat2D HomMat2dTranslateLocal(HTuple tx, HTuple ty)
        {
            IntPtr proc = HalconAPI.PreCall(286);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, tx);
            HalconAPI.Store(proc, 2, ty);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(tx);
            HalconAPI.UnpinTuple(ty);
            HHomMat2D hhomMat2D;
            int procResult = HHomMat2D.LoadNew(proc, 0, err, out hhomMat2D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat2D;
        }

        /// <summary>
        ///   Add a translation to a homogeneous 2D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="tx">Translation along the x-axis. Default: 64</param>
        /// <param name="ty">Translation along the y-axis. Default: 64</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat2D HomMat2dTranslateLocal(double tx, double ty)
        {
            IntPtr proc = HalconAPI.PreCall(286);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, tx);
            HalconAPI.StoreD(proc, 2, ty);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HHomMat2D hhomMat2D;
            int procResult = HHomMat2D.LoadNew(proc, 0, err, out hhomMat2D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat2D;
        }

        /// <summary>
        ///   Add a translation to a homogeneous 2D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="tx">Translation along the x-axis. Default: 64</param>
        /// <param name="ty">Translation along the y-axis. Default: 64</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat2D HomMat2dTranslate(HTuple tx, HTuple ty)
        {
            IntPtr proc = HalconAPI.PreCall(287);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, tx);
            HalconAPI.Store(proc, 2, ty);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(tx);
            HalconAPI.UnpinTuple(ty);
            HHomMat2D hhomMat2D;
            int procResult = HHomMat2D.LoadNew(proc, 0, err, out hhomMat2D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat2D;
        }

        /// <summary>
        ///   Add a translation to a homogeneous 2D transformation matrix.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="tx">Translation along the x-axis. Default: 64</param>
        /// <param name="ty">Translation along the y-axis. Default: 64</param>
        /// <returns>Output transformation matrix.</returns>
        public HHomMat2D HomMat2dTranslate(double tx, double ty)
        {
            IntPtr proc = HalconAPI.PreCall(287);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, tx);
            HalconAPI.StoreD(proc, 2, ty);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HHomMat2D hhomMat2D;
            int procResult = HHomMat2D.LoadNew(proc, 0, err, out hhomMat2D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat2D;
        }

        /// <summary>
        ///   Generate the homogeneous transformation matrix of the identical 2D transformation.
        ///   Modified instance represents: Transformation matrix.
        /// </summary>
        public void HomMat2dIdentity()
        {
            IntPtr proc = HalconAPI.PreCall(288);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Compute the projective 3d reconstruction of points based on the fundamental matrix.
        ///   Instance represents: Fundamental matrix.
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
        /// <param name="covFMat">9x9 covariance matrix of the fundamental matrix. Default: []</param>
        /// <param name="x">X coordinates of the reconstructed points in projective 3D space.</param>
        /// <param name="y">Y coordinates of the reconstructed points in projective 3D space.</param>
        /// <param name="z">Z coordinates of the reconstructed points in projective 3D space.</param>
        /// <param name="w">W coordinates of the reconstructed points in projective 3D space.</param>
        /// <param name="covXYZW">Covariance matrices of the reconstructed points.</param>
        public void Reconst3dFromFundamentalMatrix(
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
          HTuple covFMat,
          out HTuple x,
          out HTuple y,
          out HTuple z,
          out HTuple w,
          out HTuple covXYZW)
        {
            IntPtr proc = HalconAPI.PreCall(350);
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
            HalconAPI.Store(proc, 11, covFMat);
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
            HalconAPI.UnpinTuple(covRR1);
            HalconAPI.UnpinTuple(covRC1);
            HalconAPI.UnpinTuple(covCC1);
            HalconAPI.UnpinTuple(covRR2);
            HalconAPI.UnpinTuple(covRC2);
            HalconAPI.UnpinTuple(covCC2);
            HalconAPI.UnpinTuple(covFMat);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out x);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out y);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out z);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out w);
            int procResult = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out covXYZW);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Compute the projective 3d reconstruction of points based on the fundamental matrix.
        ///   Instance represents: Fundamental matrix.
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
        /// <param name="covFMat">9x9 covariance matrix of the fundamental matrix. Default: []</param>
        /// <param name="x">X coordinates of the reconstructed points in projective 3D space.</param>
        /// <param name="y">Y coordinates of the reconstructed points in projective 3D space.</param>
        /// <param name="z">Z coordinates of the reconstructed points in projective 3D space.</param>
        /// <param name="w">W coordinates of the reconstructed points in projective 3D space.</param>
        /// <param name="covXYZW">Covariance matrices of the reconstructed points.</param>
        public void Reconst3dFromFundamentalMatrix(
          double rows1,
          double cols1,
          double rows2,
          double cols2,
          double covRR1,
          double covRC1,
          double covCC1,
          double covRR2,
          double covRC2,
          double covCC2,
          HTuple covFMat,
          out double x,
          out double y,
          out double z,
          out double w,
          out double covXYZW)
        {
            IntPtr proc = HalconAPI.PreCall(350);
            this.Store(proc, 10);
            HalconAPI.StoreD(proc, 0, rows1);
            HalconAPI.StoreD(proc, 1, cols1);
            HalconAPI.StoreD(proc, 2, rows2);
            HalconAPI.StoreD(proc, 3, cols2);
            HalconAPI.StoreD(proc, 4, covRR1);
            HalconAPI.StoreD(proc, 5, covRC1);
            HalconAPI.StoreD(proc, 6, covCC1);
            HalconAPI.StoreD(proc, 7, covRR2);
            HalconAPI.StoreD(proc, 8, covRC2);
            HalconAPI.StoreD(proc, 9, covCC2);
            HalconAPI.Store(proc, 11, covFMat);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(covFMat);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out x);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out y);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out z);
            int err5 = HalconAPI.LoadD(proc, 3, err4, out w);
            int procResult = HalconAPI.LoadD(proc, 4, err5, out covXYZW);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Compute the projective rectification of weakly calibrated binocular stereo images.
        ///   Instance represents: Fundamental matrix.
        /// </summary>
        /// <param name="map2">Image coding the rectification of the 2. image.</param>
        /// <param name="covFMat">9x9 covariance matrix of the fundamental matrix. Default: []</param>
        /// <param name="width1">Width of the 1. image. Default: 512</param>
        /// <param name="height1">Height of the 1. image. Default: 512</param>
        /// <param name="width2">Width of the 2. image. Default: 512</param>
        /// <param name="height2">Height of the 2. image. Default: 512</param>
        /// <param name="subSampling">Subsampling factor. Default: 1</param>
        /// <param name="mapping">Type of mapping. Default: "no_map"</param>
        /// <param name="covFMatRect">9x9 covariance matrix of the rectified fundamental matrix.</param>
        /// <param name="h1">Projective transformation of the 1. image.</param>
        /// <param name="h2">Projective transformation of the 2. image.</param>
        /// <returns>Image coding the rectification of the 1. image.</returns>
        public HImage GenBinocularProjRectification(
          out HImage map2,
          HTuple covFMat,
          int width1,
          int height1,
          int width2,
          int height2,
          HTuple subSampling,
          string mapping,
          out HTuple covFMatRect,
          out HHomMat2D h1,
          out HHomMat2D h2)
        {
            IntPtr proc = HalconAPI.PreCall(351);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, covFMat);
            HalconAPI.StoreI(proc, 2, width1);
            HalconAPI.StoreI(proc, 3, height1);
            HalconAPI.StoreI(proc, 4, width2);
            HalconAPI.StoreI(proc, 5, height2);
            HalconAPI.Store(proc, 6, subSampling);
            HalconAPI.StoreS(proc, 7, mapping);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(covFMat);
            HalconAPI.UnpinTuple(subSampling);
            HImage himage;
            int err2 = HImage.LoadNew(proc, 1, err1, out himage);
            int err3 = HImage.LoadNew(proc, 2, err2, out map2);
            int err4 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err3, out covFMatRect);
            int err5 = HHomMat2D.LoadNew(proc, 1, err4, out h1);
            int procResult = HHomMat2D.LoadNew(proc, 2, err5, out h2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>
        ///   Compute the projective rectification of weakly calibrated binocular stereo images.
        ///   Instance represents: Fundamental matrix.
        /// </summary>
        /// <param name="map2">Image coding the rectification of the 2. image.</param>
        /// <param name="covFMat">9x9 covariance matrix of the fundamental matrix. Default: []</param>
        /// <param name="width1">Width of the 1. image. Default: 512</param>
        /// <param name="height1">Height of the 1. image. Default: 512</param>
        /// <param name="width2">Width of the 2. image. Default: 512</param>
        /// <param name="height2">Height of the 2. image. Default: 512</param>
        /// <param name="subSampling">Subsampling factor. Default: 1</param>
        /// <param name="mapping">Type of mapping. Default: "no_map"</param>
        /// <param name="covFMatRect">9x9 covariance matrix of the rectified fundamental matrix.</param>
        /// <param name="h1">Projective transformation of the 1. image.</param>
        /// <param name="h2">Projective transformation of the 2. image.</param>
        /// <returns>Image coding the rectification of the 1. image.</returns>
        public HImage GenBinocularProjRectification(
          out HImage map2,
          HTuple covFMat,
          int width1,
          int height1,
          int width2,
          int height2,
          int subSampling,
          string mapping,
          out HTuple covFMatRect,
          out HHomMat2D h1,
          out HHomMat2D h2)
        {
            IntPtr proc = HalconAPI.PreCall(351);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, covFMat);
            HalconAPI.StoreI(proc, 2, width1);
            HalconAPI.StoreI(proc, 3, height1);
            HalconAPI.StoreI(proc, 4, width2);
            HalconAPI.StoreI(proc, 5, height2);
            HalconAPI.StoreI(proc, 6, subSampling);
            HalconAPI.StoreS(proc, 7, mapping);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(covFMat);
            HImage himage;
            int err2 = HImage.LoadNew(proc, 1, err1, out himage);
            int err3 = HImage.LoadNew(proc, 2, err2, out map2);
            int err4 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err3, out covFMatRect);
            int err5 = HHomMat2D.LoadNew(proc, 1, err4, out h1);
            int procResult = HHomMat2D.LoadNew(proc, 2, err5, out h2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>
        ///   Compute the fundamental matrix and the radial distortion coefficient given a set of image point correspondences and reconstruct 3D points.
        ///   Modified instance represents: Computed fundamental matrix.
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
        /// <param name="imageWidth">Width of the images from which the points were extracted.</param>
        /// <param name="imageHeight">Height of the images from which the points were extracted.</param>
        /// <param name="method">Estimation algorithm. Default: "gold_standard"</param>
        /// <param name="error">Root-Mean-Square epipolar distance error.</param>
        /// <param name="x">X coordinates of the reconstructed points in projective 3D space.</param>
        /// <param name="y">Y coordinates of the reconstructed points in projective 3D space.</param>
        /// <param name="z">Z coordinates of the reconstructed points in projective 3D space.</param>
        /// <param name="w">W coordinates of the reconstructed points in projective 3D space.</param>
        /// <returns>Computed radial distortion coefficient.</returns>
        public double VectorToFundamentalMatrixDistortion(
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
          int imageWidth,
          int imageHeight,
          string method,
          out double error,
          out HTuple x,
          out HTuple y,
          out HTuple z,
          out HTuple w)
        {
            IntPtr proc = HalconAPI.PreCall(352);
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
            HalconAPI.StoreI(proc, 10, imageWidth);
            HalconAPI.StoreI(proc, 11, imageHeight);
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
            int err2 = this.Load(proc, 0, err1);
            double doubleValue;
            int err3 = HalconAPI.LoadD(proc, 1, err2, out doubleValue);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out error);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out x);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out y);
            int err7 = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, err6, out z);
            int procResult = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, err7, out w);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Compute the fundamental matrix from the relative orientation of two cameras.
        ///   Modified instance represents: Computed fundamental matrix.
        /// </summary>
        /// <param name="relPose">Relative orientation of the cameras (3D pose).</param>
        /// <param name="covRelPose">6x6 covariance matrix of relative pose. Default: []</param>
        /// <param name="camPar1">Parameters of the 1. camera.</param>
        /// <param name="camPar2">Parameters of the 2. camera.</param>
        /// <returns>9x9 covariance matrix of the fundamental matrix.</returns>
        public HTuple RelPoseToFundamentalMatrix(
          HPose relPose,
          HTuple covRelPose,
          HCamPar camPar1,
          HCamPar camPar2)
        {
            IntPtr proc = HalconAPI.PreCall(353);
            HalconAPI.Store(proc, 0, (HData)relPose);
            HalconAPI.Store(proc, 1, covRelPose);
            HalconAPI.Store(proc, 2, (HData)camPar1);
            HalconAPI.Store(proc, 3, (HData)camPar2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)relPose));
            HalconAPI.UnpinTuple(covRelPose);
            HalconAPI.UnpinTuple((HTuple)((HData)camPar1));
            HalconAPI.UnpinTuple((HTuple)((HData)camPar2));
            int err2 = this.Load(proc, 0, err1);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the fundamental matrix from an essential matrix.
        ///   Instance represents: Essential matrix.
        /// </summary>
        /// <param name="covEMat">9x9 covariance matrix of the essential matrix. Default: []</param>
        /// <param name="camMat1">Camera matrix of the 1. camera.</param>
        /// <param name="camMat2">Camera matrix of the 2. camera.</param>
        /// <param name="covFMat">9x9 covariance matrix of the fundamental matrix.</param>
        /// <returns>Computed fundamental matrix.</returns>
        public HHomMat2D EssentialToFundamentalMatrix(
          HTuple covEMat,
          HHomMat2D camMat1,
          HHomMat2D camMat2,
          out HTuple covFMat)
        {
            IntPtr proc = HalconAPI.PreCall(354);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, covEMat);
            HalconAPI.Store(proc, 2, (HData)camMat1);
            HalconAPI.Store(proc, 3, (HData)camMat2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HalconAPI.UnpinTuple(covEMat);
            HalconAPI.UnpinTuple((HTuple)((HData)camMat1));
            HalconAPI.UnpinTuple((HTuple)((HData)camMat2));
            HHomMat2D hhomMat2D;
            int err2 = HHomMat2D.LoadNew(proc, 0, err1, out hhomMat2D);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out covFMat);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat2D;
        }

        /// <summary>
        ///   Compute the essential matrix given image point correspondences and known camera matrices and reconstruct 3D points.
        ///   Instance represents: Camera matrix of the 1st camera.
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
        /// <param name="camMat2">Camera matrix of the 2nd camera.</param>
        /// <param name="method">Algorithm for the computation of the essential matrix and for special camera orientations. Default: "normalized_dlt"</param>
        /// <param name="covEMat">9x9 covariance matrix of the essential matrix.</param>
        /// <param name="error">Root-Mean-Square of the epipolar distance error.</param>
        /// <param name="x">X coordinates of the reconstructed 3D points.</param>
        /// <param name="y">Y coordinates of the reconstructed 3D points.</param>
        /// <param name="z">Z coordinates of the reconstructed 3D points.</param>
        /// <param name="covXYZ">Covariance matrices of the reconstructed 3D points.</param>
        /// <returns>Computed essential matrix.</returns>
        public HHomMat2D VectorToEssentialMatrix(
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
          HHomMat2D camMat2,
          string method,
          out HTuple covEMat,
          out HTuple error,
          out HTuple x,
          out HTuple y,
          out HTuple z,
          out HTuple covXYZ)
        {
            IntPtr proc = HalconAPI.PreCall(356);
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
            HalconAPI.Store(proc, 11, (HData)camMat2);
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
            HalconAPI.UnpinTuple((HTuple)((HData)camMat2));
            HHomMat2D hhomMat2D;
            int err2 = HHomMat2D.LoadNew(proc, 0, err1, out hhomMat2D);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out covEMat);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out error);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out x);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out y);
            int err7 = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, err6, out z);
            int procResult = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, err7, out covXYZ);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat2D;
        }

        /// <summary>
        ///   Compute the essential matrix given image point correspondences and known camera matrices and reconstruct 3D points.
        ///   Instance represents: Camera matrix of the 1st camera.
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
        /// <param name="camMat2">Camera matrix of the 2nd camera.</param>
        /// <param name="method">Algorithm for the computation of the essential matrix and for special camera orientations. Default: "normalized_dlt"</param>
        /// <param name="covEMat">9x9 covariance matrix of the essential matrix.</param>
        /// <param name="error">Root-Mean-Square of the epipolar distance error.</param>
        /// <param name="x">X coordinates of the reconstructed 3D points.</param>
        /// <param name="y">Y coordinates of the reconstructed 3D points.</param>
        /// <param name="z">Z coordinates of the reconstructed 3D points.</param>
        /// <param name="covXYZ">Covariance matrices of the reconstructed 3D points.</param>
        /// <returns>Computed essential matrix.</returns>
        public HHomMat2D VectorToEssentialMatrix(
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
          HHomMat2D camMat2,
          string method,
          out HTuple covEMat,
          out double error,
          out HTuple x,
          out HTuple y,
          out HTuple z,
          out HTuple covXYZ)
        {
            IntPtr proc = HalconAPI.PreCall(356);
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
            HalconAPI.Store(proc, 11, (HData)camMat2);
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
            HalconAPI.UnpinTuple((HTuple)((HData)camMat2));
            HHomMat2D hhomMat2D;
            int err2 = HHomMat2D.LoadNew(proc, 0, err1, out hhomMat2D);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out covEMat);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out error);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out x);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out y);
            int err7 = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, err6, out z);
            int procResult = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, err7, out covXYZ);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hhomMat2D;
        }

        /// <summary>
        ///   Compute the fundamental matrix given a set of image point correspondences and reconstruct 3D points.
        ///   Modified instance represents: Computed fundamental matrix.
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
        /// <param name="method">Estimation algorithm. Default: "normalized_dlt"</param>
        /// <param name="error">Root-Mean-Square of the epipolar distance error.</param>
        /// <param name="x">X coordinates of the reconstructed points in projective 3D space.</param>
        /// <param name="y">Y coordinates of the reconstructed points in projective 3D space.</param>
        /// <param name="z">Z coordinates of the reconstructed points in projective 3D space.</param>
        /// <param name="w">W coordinates of the reconstructed points in projective 3D space.</param>
        /// <param name="covXYZW">Covariance matrices of the reconstructed 3D points.</param>
        /// <returns>9x9 covariance matrix of the fundamental matrix.</returns>
        public HTuple VectorToFundamentalMatrix(
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
          string method,
          out double error,
          out HTuple x,
          out HTuple y,
          out HTuple z,
          out HTuple w,
          out HTuple covXYZW)
        {
            IntPtr proc = HalconAPI.PreCall(357);
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
            HalconAPI.StoreS(proc, 10, method);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            HalconAPI.InitOCT(proc, 6);
            HalconAPI.InitOCT(proc, 7);
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
            int err2 = this.Load(proc, 0, err1);
            HTuple tuple;
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out tuple);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out error);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out x);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out y);
            int err7 = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, err6, out z);
            int err8 = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, err7, out w);
            int procResult = HTuple.LoadNew(proc, 7, HTupleType.DOUBLE, err8, out covXYZW);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Compute the fundamental matrix and the radial distortion coefficient for a pair of stereo images by automatically finding correspondences between image points.
        ///   Modified instance represents: Computed fundamental matrix.
        /// </summary>
        /// <param name="image1">Input image 1.</param>
        /// <param name="image2">Input image 2.</param>
        /// <param name="rows1">Input points in image 1 (row coordinate).</param>
        /// <param name="cols1">Input points in image 1 (column coordinate).</param>
        /// <param name="rows2">Input points in image 2 (row coordinate).</param>
        /// <param name="cols2">Input points in image 2 (column coordinate).</param>
        /// <param name="grayMatchMethod">Gray value match metric. Default: "ncc"</param>
        /// <param name="maskSize">Size of gray value masks. Default: 10</param>
        /// <param name="rowMove">Average row coordinate offset of corresponding points. Default: 0</param>
        /// <param name="colMove">Average column coordinate offset of corresponding points. Default: 0</param>
        /// <param name="rowTolerance">Half height of matching search window. Default: 200</param>
        /// <param name="colTolerance">Half width of matching search window. Default: 200</param>
        /// <param name="rotation">Estimate of the relative rotation of the second image with respect to the first image. Default: 0.0</param>
        /// <param name="matchThreshold">Threshold for gray value matching. Default: 0.7</param>
        /// <param name="estimationMethod">Algorithm for the computation of the fundamental matrix and for special camera orientations. Default: "gold_standard"</param>
        /// <param name="distanceThreshold">Maximal deviation of a point from its epipolar line. Default: 1</param>
        /// <param name="randSeed">Seed for the random number generator. Default: 0</param>
        /// <param name="error">Root-Mean-Square epipolar distance error.</param>
        /// <param name="points1">Indices of matched input points in image 1.</param>
        /// <param name="points2">Indices of matched input points in image 2.</param>
        /// <returns>Computed radial distortion coefficient.</returns>
        public double MatchFundamentalMatrixDistortionRansac(
          HImage image1,
          HImage image2,
          HTuple rows1,
          HTuple cols1,
          HTuple rows2,
          HTuple cols2,
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
          out double error,
          out HTuple points1,
          out HTuple points2)
        {
            IntPtr proc = HalconAPI.PreCall(358);
            HalconAPI.Store(proc, 1, (HObjectBase)image1);
            HalconAPI.Store(proc, 2, (HObjectBase)image2);
            HalconAPI.Store(proc, 0, rows1);
            HalconAPI.Store(proc, 1, cols1);
            HalconAPI.Store(proc, 2, rows2);
            HalconAPI.Store(proc, 3, cols2);
            HalconAPI.StoreS(proc, 4, grayMatchMethod);
            HalconAPI.StoreI(proc, 5, maskSize);
            HalconAPI.StoreI(proc, 6, rowMove);
            HalconAPI.StoreI(proc, 7, colMove);
            HalconAPI.StoreI(proc, 8, rowTolerance);
            HalconAPI.StoreI(proc, 9, colTolerance);
            HalconAPI.Store(proc, 10, rotation);
            HalconAPI.Store(proc, 11, matchThreshold);
            HalconAPI.StoreS(proc, 12, estimationMethod);
            HalconAPI.Store(proc, 13, distanceThreshold);
            HalconAPI.StoreI(proc, 14, randSeed);
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
            HalconAPI.UnpinTuple(rotation);
            HalconAPI.UnpinTuple(matchThreshold);
            HalconAPI.UnpinTuple(distanceThreshold);
            int err2 = this.Load(proc, 0, err1);
            double doubleValue;
            int err3 = HalconAPI.LoadD(proc, 1, err2, out doubleValue);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out error);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, err4, out points1);
            int procResult = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, err5, out points2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image1);
            GC.KeepAlive((object)image2);
            return doubleValue;
        }

        /// <summary>
        ///   Compute the fundamental matrix and the radial distortion coefficient for a pair of stereo images by automatically finding correspondences between image points.
        ///   Modified instance represents: Computed fundamental matrix.
        /// </summary>
        /// <param name="image1">Input image 1.</param>
        /// <param name="image2">Input image 2.</param>
        /// <param name="rows1">Input points in image 1 (row coordinate).</param>
        /// <param name="cols1">Input points in image 1 (column coordinate).</param>
        /// <param name="rows2">Input points in image 2 (row coordinate).</param>
        /// <param name="cols2">Input points in image 2 (column coordinate).</param>
        /// <param name="grayMatchMethod">Gray value match metric. Default: "ncc"</param>
        /// <param name="maskSize">Size of gray value masks. Default: 10</param>
        /// <param name="rowMove">Average row coordinate offset of corresponding points. Default: 0</param>
        /// <param name="colMove">Average column coordinate offset of corresponding points. Default: 0</param>
        /// <param name="rowTolerance">Half height of matching search window. Default: 200</param>
        /// <param name="colTolerance">Half width of matching search window. Default: 200</param>
        /// <param name="rotation">Estimate of the relative rotation of the second image with respect to the first image. Default: 0.0</param>
        /// <param name="matchThreshold">Threshold for gray value matching. Default: 0.7</param>
        /// <param name="estimationMethod">Algorithm for the computation of the fundamental matrix and for special camera orientations. Default: "gold_standard"</param>
        /// <param name="distanceThreshold">Maximal deviation of a point from its epipolar line. Default: 1</param>
        /// <param name="randSeed">Seed for the random number generator. Default: 0</param>
        /// <param name="error">Root-Mean-Square epipolar distance error.</param>
        /// <param name="points1">Indices of matched input points in image 1.</param>
        /// <param name="points2">Indices of matched input points in image 2.</param>
        /// <returns>Computed radial distortion coefficient.</returns>
        public double MatchFundamentalMatrixDistortionRansac(
          HImage image1,
          HImage image2,
          HTuple rows1,
          HTuple cols1,
          HTuple rows2,
          HTuple cols2,
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
            IntPtr proc = HalconAPI.PreCall(358);
            HalconAPI.Store(proc, 1, (HObjectBase)image1);
            HalconAPI.Store(proc, 2, (HObjectBase)image2);
            HalconAPI.Store(proc, 0, rows1);
            HalconAPI.Store(proc, 1, cols1);
            HalconAPI.Store(proc, 2, rows2);
            HalconAPI.Store(proc, 3, cols2);
            HalconAPI.StoreS(proc, 4, grayMatchMethod);
            HalconAPI.StoreI(proc, 5, maskSize);
            HalconAPI.StoreI(proc, 6, rowMove);
            HalconAPI.StoreI(proc, 7, colMove);
            HalconAPI.StoreI(proc, 8, rowTolerance);
            HalconAPI.StoreI(proc, 9, colTolerance);
            HalconAPI.StoreD(proc, 10, rotation);
            HalconAPI.StoreI(proc, 11, matchThreshold);
            HalconAPI.StoreS(proc, 12, estimationMethod);
            HalconAPI.StoreD(proc, 13, distanceThreshold);
            HalconAPI.StoreI(proc, 14, randSeed);
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
            int err2 = this.Load(proc, 0, err1);
            double doubleValue;
            int err3 = HalconAPI.LoadD(proc, 1, err2, out doubleValue);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out error);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, err4, out points1);
            int procResult = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, err5, out points2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image1);
            GC.KeepAlive((object)image2);
            return doubleValue;
        }

        /// <summary>
        ///   Compute the essential matrix for a pair of stereo images by automatically finding correspondences between image points.
        ///   Instance represents: Camera matrix of the 1st camera.
        /// </summary>
        /// <param name="image1">Input image 1.</param>
        /// <param name="image2">Input image 2.</param>
        /// <param name="rows1">Row coordinates of characteristic points in image 1.</param>
        /// <param name="cols1">Column coordinates of characteristic points in image 1.</param>
        /// <param name="rows2">Row coordinates of characteristic points in image 2.</param>
        /// <param name="cols2">Column coordinates of characteristic points in image 2.</param>
        /// <param name="camMat2">Camera matrix of the 2nd camera.</param>
        /// <param name="grayMatchMethod">Gray value comparison metric. Default: "ssd"</param>
        /// <param name="maskSize">Size of gray value masks. Default: 10</param>
        /// <param name="rowMove">Average row coordinate shift of corresponding points. Default: 0</param>
        /// <param name="colMove">Average column coordinate shift of corresponding points. Default: 0</param>
        /// <param name="rowTolerance">Half height of matching search window. Default: 200</param>
        /// <param name="colTolerance">Half width of matching search window. Default: 200</param>
        /// <param name="rotation">Estimate of the relative orientation of the right image with respect to the left image. Default: 0.0</param>
        /// <param name="matchThreshold">Threshold for gray value matching. Default: 10</param>
        /// <param name="estimationMethod">Algorithm for the computation of the essential matrix and for special camera orientations. Default: "normalized_dlt"</param>
        /// <param name="distanceThreshold">Maximal deviation of a point from its epipolar line. Default: 1</param>
        /// <param name="randSeed">Seed for the random number generator. Default: 0</param>
        /// <param name="covEMat">9x9 covariance matrix of the essential matrix.</param>
        /// <param name="error">Root-Mean-Square of the epipolar distance error.</param>
        /// <param name="points1">Indices of matched input points in image 1.</param>
        /// <param name="points2">Indices of matched input points in image 2.</param>
        /// <returns>Computed essential matrix.</returns>
        public HHomMat2D MatchEssentialMatrixRansac(
          HImage image1,
          HImage image2,
          HTuple rows1,
          HTuple cols1,
          HTuple rows2,
          HTuple cols2,
          HHomMat2D camMat2,
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
          out HTuple covEMat,
          out HTuple error,
          out HTuple points1,
          out HTuple points2)
        {
            IntPtr proc = HalconAPI.PreCall(360);
            this.Store(proc, 4);
            HalconAPI.Store(proc, 1, (HObjectBase)image1);
            HalconAPI.Store(proc, 2, (HObjectBase)image2);
            HalconAPI.Store(proc, 0, rows1);
            HalconAPI.Store(proc, 1, cols1);
            HalconAPI.Store(proc, 2, rows2);
            HalconAPI.Store(proc, 3, cols2);
            HalconAPI.Store(proc, 5, (HData)camMat2);
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
            HalconAPI.UnpinTuple((HTuple)((HData)camMat2));
            HalconAPI.UnpinTuple(rotation);
            HalconAPI.UnpinTuple(matchThreshold);
            HalconAPI.UnpinTuple(distanceThreshold);
            HHomMat2D hhomMat2D;
            int err2 = HHomMat2D.LoadNew(proc, 0, err1, out hhomMat2D);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out covEMat);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out error);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, err4, out points1);
            int procResult = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, err5, out points2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image1);
            GC.KeepAlive((object)image2);
            return hhomMat2D;
        }

        /// <summary>
        ///   Compute the essential matrix for a pair of stereo images by automatically finding correspondences between image points.
        ///   Instance represents: Camera matrix of the 1st camera.
        /// </summary>
        /// <param name="image1">Input image 1.</param>
        /// <param name="image2">Input image 2.</param>
        /// <param name="rows1">Row coordinates of characteristic points in image 1.</param>
        /// <param name="cols1">Column coordinates of characteristic points in image 1.</param>
        /// <param name="rows2">Row coordinates of characteristic points in image 2.</param>
        /// <param name="cols2">Column coordinates of characteristic points in image 2.</param>
        /// <param name="camMat2">Camera matrix of the 2nd camera.</param>
        /// <param name="grayMatchMethod">Gray value comparison metric. Default: "ssd"</param>
        /// <param name="maskSize">Size of gray value masks. Default: 10</param>
        /// <param name="rowMove">Average row coordinate shift of corresponding points. Default: 0</param>
        /// <param name="colMove">Average column coordinate shift of corresponding points. Default: 0</param>
        /// <param name="rowTolerance">Half height of matching search window. Default: 200</param>
        /// <param name="colTolerance">Half width of matching search window. Default: 200</param>
        /// <param name="rotation">Estimate of the relative orientation of the right image with respect to the left image. Default: 0.0</param>
        /// <param name="matchThreshold">Threshold for gray value matching. Default: 10</param>
        /// <param name="estimationMethod">Algorithm for the computation of the essential matrix and for special camera orientations. Default: "normalized_dlt"</param>
        /// <param name="distanceThreshold">Maximal deviation of a point from its epipolar line. Default: 1</param>
        /// <param name="randSeed">Seed for the random number generator. Default: 0</param>
        /// <param name="covEMat">9x9 covariance matrix of the essential matrix.</param>
        /// <param name="error">Root-Mean-Square of the epipolar distance error.</param>
        /// <param name="points1">Indices of matched input points in image 1.</param>
        /// <param name="points2">Indices of matched input points in image 2.</param>
        /// <returns>Computed essential matrix.</returns>
        public HHomMat2D MatchEssentialMatrixRansac(
          HImage image1,
          HImage image2,
          HTuple rows1,
          HTuple cols1,
          HTuple rows2,
          HTuple cols2,
          HHomMat2D camMat2,
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
          out HTuple covEMat,
          out double error,
          out HTuple points1,
          out HTuple points2)
        {
            IntPtr proc = HalconAPI.PreCall(360);
            this.Store(proc, 4);
            HalconAPI.Store(proc, 1, (HObjectBase)image1);
            HalconAPI.Store(proc, 2, (HObjectBase)image2);
            HalconAPI.Store(proc, 0, rows1);
            HalconAPI.Store(proc, 1, cols1);
            HalconAPI.Store(proc, 2, rows2);
            HalconAPI.Store(proc, 3, cols2);
            HalconAPI.Store(proc, 5, (HData)camMat2);
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
            HalconAPI.UnpinTuple((HTuple)((HData)camMat2));
            HHomMat2D hhomMat2D;
            int err2 = HHomMat2D.LoadNew(proc, 0, err1, out hhomMat2D);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out covEMat);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out error);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, err4, out points1);
            int procResult = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, err5, out points2);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image1);
            GC.KeepAlive((object)image2);
            return hhomMat2D;
        }

        /// <summary>
        ///   Compute the fundamental matrix for a pair of stereo images by automatically finding correspondences between image points.
        ///   Modified instance represents: Computed fundamental matrix.
        /// </summary>
        /// <param name="image1">Input image 1.</param>
        /// <param name="image2">Input image 2.</param>
        /// <param name="rows1">Row coordinates of characteristic points in image 1.</param>
        /// <param name="cols1">Column coordinates of characteristic points in image 1.</param>
        /// <param name="rows2">Row coordinates of characteristic points in image 2.</param>
        /// <param name="cols2">Column coordinates of characteristic points in image 2.</param>
        /// <param name="grayMatchMethod">Gray value comparison metric. Default: "ssd"</param>
        /// <param name="maskSize">Size of gray value masks. Default: 10</param>
        /// <param name="rowMove">Average row coordinate shift of corresponding points. Default: 0</param>
        /// <param name="colMove">Average column coordinate shift of corresponding points. Default: 0</param>
        /// <param name="rowTolerance">Half height of matching search window. Default: 200</param>
        /// <param name="colTolerance">Half width of matching search window. Default: 200</param>
        /// <param name="rotation">Estimate of the relative orientation of the right image with respect to the left image. Default: 0.0</param>
        /// <param name="matchThreshold">Threshold for gray value matching. Default: 10</param>
        /// <param name="estimationMethod">Algorithm for the computation of the fundamental matrix and for special camera orientations. Default: "normalized_dlt"</param>
        /// <param name="distanceThreshold">Maximal deviation of a point from its epipolar line. Default: 1</param>
        /// <param name="randSeed">Seed for the random number generator. Default: 0</param>
        /// <param name="error">Root-Mean-Square of the epipolar distance error.</param>
        /// <param name="points1">Indices of matched input points in image 1.</param>
        /// <param name="points2">Indices of matched input points in image 2.</param>
        /// <returns>9x9 covariance matrix of the fundamental matrix.</returns>
        public HTuple MatchFundamentalMatrixRansac(
          HImage image1,
          HImage image2,
          HTuple rows1,
          HTuple cols1,
          HTuple rows2,
          HTuple cols2,
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
          out double error,
          out HTuple points1,
          out HTuple points2)
        {
            IntPtr proc = HalconAPI.PreCall(361);
            HalconAPI.Store(proc, 1, (HObjectBase)image1);
            HalconAPI.Store(proc, 2, (HObjectBase)image2);
            HalconAPI.Store(proc, 0, rows1);
            HalconAPI.Store(proc, 1, cols1);
            HalconAPI.Store(proc, 2, rows2);
            HalconAPI.Store(proc, 3, cols2);
            HalconAPI.StoreS(proc, 4, grayMatchMethod);
            HalconAPI.StoreI(proc, 5, maskSize);
            HalconAPI.StoreI(proc, 6, rowMove);
            HalconAPI.StoreI(proc, 7, colMove);
            HalconAPI.StoreI(proc, 8, rowTolerance);
            HalconAPI.StoreI(proc, 9, colTolerance);
            HalconAPI.Store(proc, 10, rotation);
            HalconAPI.Store(proc, 11, matchThreshold);
            HalconAPI.StoreS(proc, 12, estimationMethod);
            HalconAPI.Store(proc, 13, distanceThreshold);
            HalconAPI.StoreI(proc, 14, randSeed);
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
            HalconAPI.UnpinTuple(rotation);
            HalconAPI.UnpinTuple(matchThreshold);
            HalconAPI.UnpinTuple(distanceThreshold);
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
        ///   Compute the fundamental matrix for a pair of stereo images by automatically finding correspondences between image points.
        ///   Modified instance represents: Computed fundamental matrix.
        /// </summary>
        /// <param name="image1">Input image 1.</param>
        /// <param name="image2">Input image 2.</param>
        /// <param name="rows1">Row coordinates of characteristic points in image 1.</param>
        /// <param name="cols1">Column coordinates of characteristic points in image 1.</param>
        /// <param name="rows2">Row coordinates of characteristic points in image 2.</param>
        /// <param name="cols2">Column coordinates of characteristic points in image 2.</param>
        /// <param name="grayMatchMethod">Gray value comparison metric. Default: "ssd"</param>
        /// <param name="maskSize">Size of gray value masks. Default: 10</param>
        /// <param name="rowMove">Average row coordinate shift of corresponding points. Default: 0</param>
        /// <param name="colMove">Average column coordinate shift of corresponding points. Default: 0</param>
        /// <param name="rowTolerance">Half height of matching search window. Default: 200</param>
        /// <param name="colTolerance">Half width of matching search window. Default: 200</param>
        /// <param name="rotation">Estimate of the relative orientation of the right image with respect to the left image. Default: 0.0</param>
        /// <param name="matchThreshold">Threshold for gray value matching. Default: 10</param>
        /// <param name="estimationMethod">Algorithm for the computation of the fundamental matrix and for special camera orientations. Default: "normalized_dlt"</param>
        /// <param name="distanceThreshold">Maximal deviation of a point from its epipolar line. Default: 1</param>
        /// <param name="randSeed">Seed for the random number generator. Default: 0</param>
        /// <param name="error">Root-Mean-Square of the epipolar distance error.</param>
        /// <param name="points1">Indices of matched input points in image 1.</param>
        /// <param name="points2">Indices of matched input points in image 2.</param>
        /// <returns>9x9 covariance matrix of the fundamental matrix.</returns>
        public HTuple MatchFundamentalMatrixRansac(
          HImage image1,
          HImage image2,
          HTuple rows1,
          HTuple cols1,
          HTuple rows2,
          HTuple cols2,
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
            IntPtr proc = HalconAPI.PreCall(361);
            HalconAPI.Store(proc, 1, (HObjectBase)image1);
            HalconAPI.Store(proc, 2, (HObjectBase)image2);
            HalconAPI.Store(proc, 0, rows1);
            HalconAPI.Store(proc, 1, cols1);
            HalconAPI.Store(proc, 2, rows2);
            HalconAPI.Store(proc, 3, cols2);
            HalconAPI.StoreS(proc, 4, grayMatchMethod);
            HalconAPI.StoreI(proc, 5, maskSize);
            HalconAPI.StoreI(proc, 6, rowMove);
            HalconAPI.StoreI(proc, 7, colMove);
            HalconAPI.StoreI(proc, 8, rowTolerance);
            HalconAPI.StoreI(proc, 9, colTolerance);
            HalconAPI.StoreD(proc, 10, rotation);
            HalconAPI.StoreI(proc, 11, matchThreshold);
            HalconAPI.StoreS(proc, 12, estimationMethod);
            HalconAPI.StoreD(proc, 13, distanceThreshold);
            HalconAPI.StoreI(proc, 14, randSeed);
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
        ///   Apply a projective transformation to a region.
        ///   Instance represents: Homogeneous projective transformation matrix.
        /// </summary>
        /// <param name="regions">Input regions.</param>
        /// <param name="interpolation">Interpolation method for the transformation. Default: "bilinear"</param>
        /// <returns>Output regions.</returns>
        public HRegion ProjectiveTransRegion(HRegion regions, string interpolation)
        {
            IntPtr proc = HalconAPI.PreCall(487);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)regions);
            HalconAPI.StoreS(proc, 1, interpolation);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)regions);
            return hregion;
        }

        /// <summary>
        ///   Apply an arbitrary affine 2D transformation to regions.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="region">Region(s) to be rotated and scaled.</param>
        /// <param name="interpolate">Should the transformation be done using interpolation? Default: "nearest_neighbor"</param>
        /// <returns>Transformed output region(s).</returns>
        public HRegion AffineTransRegion(HRegion region, string interpolate)
        {
            IntPtr proc = HalconAPI.PreCall(488);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)region);
            HalconAPI.StoreS(proc, 1, interpolate);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HRegion hregion;
            int procResult = HRegion.LoadNew(proc, 1, err, out hregion);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)region);
            return hregion;
        }

        /// <summary>
        ///   Apply a projective transformation to an image and specify the output image size.
        ///   Instance represents: Homogeneous projective transformation matrix.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="interpolation">Interpolation method for the transformation. Default: "bilinear"</param>
        /// <param name="width">Output image width.</param>
        /// <param name="height">Output image height.</param>
        /// <param name="transformDomain">Should the domain of the input image also be transformed? Default: "false"</param>
        /// <returns>Output image.</returns>
        public HImage ProjectiveTransImageSize(
          HImage image,
          string interpolation,
          int width,
          int height,
          string transformDomain)
        {
            IntPtr proc = HalconAPI.PreCall(1620);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreS(proc, 1, interpolation);
            HalconAPI.StoreI(proc, 2, width);
            HalconAPI.StoreI(proc, 3, height);
            HalconAPI.StoreS(proc, 4, transformDomain);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return himage;
        }

        /// <summary>
        ///   Apply a projective transformation to an image.
        ///   Instance represents: Homogeneous projective transformation matrix.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="interpolation">Interpolation method for the transformation. Default: "bilinear"</param>
        /// <param name="adaptImageSize">Adapt the size of the output image automatically? Default: "false"</param>
        /// <param name="transformDomain">Should the domain of the input image also be transformed? Default: "false"</param>
        /// <returns>Output image.</returns>
        public HImage ProjectiveTransImage(
          HImage image,
          string interpolation,
          string adaptImageSize,
          string transformDomain)
        {
            IntPtr proc = HalconAPI.PreCall(1621);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreS(proc, 1, interpolation);
            HalconAPI.StoreS(proc, 2, adaptImageSize);
            HalconAPI.StoreS(proc, 3, transformDomain);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return himage;
        }

        /// <summary>
        ///   Apply an arbitrary affine 2D transformation to an image and specify the output image size.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="interpolation">Type of interpolation. Default: "constant"</param>
        /// <param name="width">Width of the output image. Default: 640</param>
        /// <param name="height">Height of the output image. Default: 480</param>
        /// <returns>Transformed image.</returns>
        public HImage AffineTransImageSize(
          HImage image,
          string interpolation,
          int width,
          int height)
        {
            IntPtr proc = HalconAPI.PreCall(1622);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreS(proc, 1, interpolation);
            HalconAPI.StoreI(proc, 2, width);
            HalconAPI.StoreI(proc, 3, height);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return himage;
        }

        /// <summary>
        ///   Apply an arbitrary affine 2D transformation to images.
        ///   Instance represents: Input transformation matrix.
        /// </summary>
        /// <param name="image">Input image.</param>
        /// <param name="interpolation">Type of interpolation. Default: "constant"</param>
        /// <param name="adaptImageSize">Adaption of size of result image. Default: "false"</param>
        /// <returns>Transformed image.</returns>
        public HImage AffineTransImage(HImage image, string interpolation, string adaptImageSize)
        {
            IntPtr proc = HalconAPI.PreCall(1623);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)image);
            HalconAPI.StoreS(proc, 1, interpolation);
            HalconAPI.StoreS(proc, 2, adaptImageSize);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)image);
            return himage;
        }

        /// <summary>
        ///   Approximate an affine map from a displacement vector field.
        ///   Modified instance represents: Output transformation matrix.
        /// </summary>
        /// <param name="vectorField">Input image.</param>
        public void VectorFieldToHomMat2d(HImage vectorField)
        {
            IntPtr proc = HalconAPI.PreCall(1631);
            HalconAPI.Store(proc, 1, (HObjectBase)vectorField);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)vectorField);
        }

        /// <summary>
        ///   Compute a camera matrix from internal camera parameters.
        ///   Modified instance represents: 3x3 projective camera matrix that corresponds to CameraParam.
        /// </summary>
        /// <param name="cameraParam">Internal camera parameters.</param>
        /// <param name="imageWidth">Width of the images that correspond to CameraMatrix.</param>
        /// <param name="imageHeight">Height of the images that correspond to CameraMatrix.</param>
        public void CamParToCamMat(HCamPar cameraParam, out int imageWidth, out int imageHeight)
        {
            IntPtr proc = HalconAPI.PreCall(1905);
            HalconAPI.Store(proc, 0, (HData)cameraParam);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple((HTuple)((HData)cameraParam));
            int err2 = this.Load(proc, 0, err1);
            int err3 = HalconAPI.LoadI(proc, 1, err2, out imageWidth);
            int procResult = HalconAPI.LoadI(proc, 2, err3, out imageHeight);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Compute the internal camera parameters from a camera matrix.
        ///   Instance represents: 3x3 projective camera matrix that determines the internal camera parameters.
        /// </summary>
        /// <param name="kappa">Kappa.</param>
        /// <param name="imageWidth">Width of the images that correspond to CameraMatrix.</param>
        /// <param name="imageHeight">Height of the images that correspond to CameraMatrix.</param>
        /// <returns>Internal camera parameters.</returns>
        public HCamPar CamMatToCamPar(double kappa, int imageWidth, int imageHeight)
        {
            IntPtr proc = HalconAPI.PreCall(1906);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, kappa);
            HalconAPI.StoreI(proc, 2, imageWidth);
            HalconAPI.StoreI(proc, 3, imageHeight);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            this.UnpinTuple();
            HCamPar hcamPar;
            int procResult = HCamPar.LoadNew(proc, 0, err, out hcamPar);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hcamPar;
        }

        /// <summary>Perform a self-calibration of a stationary projective camera.</summary>
        /// <param name="numImages">Number of different images that are used for the calibration.</param>
        /// <param name="imageWidth">Width of the images from which the points were extracted.</param>
        /// <param name="imageHeight">Height of the images from which the points were extracted.</param>
        /// <param name="referenceImage">Index of the reference image.</param>
        /// <param name="mappingSource">Indices of the source images of the transformations.</param>
        /// <param name="mappingDest">Indices of the target images of the transformations.</param>
        /// <param name="homMatrices2D">Array of 3x3 projective transformation matrices.</param>
        /// <param name="rows1">Row coordinates of corresponding points in the respective source images.</param>
        /// <param name="cols1">Column coordinates of corresponding points in the respective source images.</param>
        /// <param name="rows2">Row coordinates of corresponding points in the respective destination images.</param>
        /// <param name="cols2">Column coordinates of corresponding points in the respective destination images.</param>
        /// <param name="numCorrespondences">Number of point correspondences in the respective image pair.</param>
        /// <param name="estimationMethod">Estimation algorithm for the calibration. Default: "gold_standard"</param>
        /// <param name="cameraModel">Camera model to be used. Default: ["focus","principal_point"]</param>
        /// <param name="fixedCameraParams">Are the camera parameters identical for all images? Default: "true"</param>
        /// <param name="kappa">Radial distortion of the camera.</param>
        /// <param name="rotationMatrices">Array of 3x3 transformation matrices that determine rotation of the camera in the respective image.</param>
        /// <param name="x">X-Component of the direction vector of each point if EstimationMethod $=$ 'gold_standard' is used.</param>
        /// <param name="y">Y-Component of the direction vector of each point if EstimationMethod $=$ 'gold_standard' is used.</param>
        /// <param name="z">Z-Component of the direction vector of each point if EstimationMethod $=$ 'gold_standard' is used.</param>
        /// <param name="error">Average error per reconstructed point if EstimationMethod $=$ 'gold_standard' is used.</param>
        /// <returns>(Array of) 3x3 projective camera matrices that determine the internal camera parameters.</returns>
        public static HHomMat2D[] StationaryCameraSelfCalibration(
          int numImages,
          int imageWidth,
          int imageHeight,
          int referenceImage,
          HTuple mappingSource,
          HTuple mappingDest,
          HHomMat2D[] homMatrices2D,
          HTuple rows1,
          HTuple cols1,
          HTuple rows2,
          HTuple cols2,
          HTuple numCorrespondences,
          string estimationMethod,
          HTuple cameraModel,
          string fixedCameraParams,
          out HTuple kappa,
          out HHomMat2D[] rotationMatrices,
          out HTuple x,
          out HTuple y,
          out HTuple z,
          out HTuple error)
        {
            HTuple htuple = HData.ConcatArray((HData[])homMatrices2D);
            IntPtr proc = HalconAPI.PreCall(1907);
            HalconAPI.StoreI(proc, 0, numImages);
            HalconAPI.StoreI(proc, 1, imageWidth);
            HalconAPI.StoreI(proc, 2, imageHeight);
            HalconAPI.StoreI(proc, 3, referenceImage);
            HalconAPI.Store(proc, 4, mappingSource);
            HalconAPI.Store(proc, 5, mappingDest);
            HalconAPI.Store(proc, 6, htuple);
            HalconAPI.Store(proc, 7, rows1);
            HalconAPI.Store(proc, 8, cols1);
            HalconAPI.Store(proc, 9, rows2);
            HalconAPI.Store(proc, 10, cols2);
            HalconAPI.Store(proc, 11, numCorrespondences);
            HalconAPI.StoreS(proc, 12, estimationMethod);
            HalconAPI.Store(proc, 13, cameraModel);
            HalconAPI.StoreS(proc, 14, fixedCameraParams);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            HalconAPI.InitOCT(proc, 6);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(mappingSource);
            HalconAPI.UnpinTuple(mappingDest);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(rows1);
            HalconAPI.UnpinTuple(cols1);
            HalconAPI.UnpinTuple(rows2);
            HalconAPI.UnpinTuple(cols2);
            HalconAPI.UnpinTuple(numCorrespondences);
            HalconAPI.UnpinTuple(cameraModel);
            HTuple tuple1;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple1);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out kappa);
            HTuple tuple2;
            int err4 = HTuple.LoadNew(proc, 2, err3, out tuple2);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out x);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out y);
            int err7 = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, err6, out z);
            int procResult = HTuple.LoadNew(proc, 6, HTupleType.DOUBLE, err7, out error);
            HalconAPI.PostCall(proc, procResult);
            rotationMatrices = HHomMat2D.SplitArray(tuple2);
            return HHomMat2D.SplitArray(tuple1);
        }

        /// <summary>Perform a self-calibration of a stationary projective camera.</summary>
        /// <param name="numImages">Number of different images that are used for the calibration.</param>
        /// <param name="imageWidth">Width of the images from which the points were extracted.</param>
        /// <param name="imageHeight">Height of the images from which the points were extracted.</param>
        /// <param name="referenceImage">Index of the reference image.</param>
        /// <param name="mappingSource">Indices of the source images of the transformations.</param>
        /// <param name="mappingDest">Indices of the target images of the transformations.</param>
        /// <param name="homMatrices2D">Array of 3x3 projective transformation matrices.</param>
        /// <param name="rows1">Row coordinates of corresponding points in the respective source images.</param>
        /// <param name="cols1">Column coordinates of corresponding points in the respective source images.</param>
        /// <param name="rows2">Row coordinates of corresponding points in the respective destination images.</param>
        /// <param name="cols2">Column coordinates of corresponding points in the respective destination images.</param>
        /// <param name="numCorrespondences">Number of point correspondences in the respective image pair.</param>
        /// <param name="estimationMethod">Estimation algorithm for the calibration. Default: "gold_standard"</param>
        /// <param name="cameraModel">Camera model to be used. Default: ["focus","principal_point"]</param>
        /// <param name="fixedCameraParams">Are the camera parameters identical for all images? Default: "true"</param>
        /// <param name="kappa">Radial distortion of the camera.</param>
        /// <param name="rotationMatrices">Array of 3x3 transformation matrices that determine rotation of the camera in the respective image.</param>
        /// <param name="x">X-Component of the direction vector of each point if EstimationMethod $=$ 'gold_standard' is used.</param>
        /// <param name="y">Y-Component of the direction vector of each point if EstimationMethod $=$ 'gold_standard' is used.</param>
        /// <param name="z">Z-Component of the direction vector of each point if EstimationMethod $=$ 'gold_standard' is used.</param>
        /// <param name="error">Average error per reconstructed point if EstimationMethod $=$ 'gold_standard' is used.</param>
        /// <returns>(Array of) 3x3 projective camera matrices that determine the internal camera parameters.</returns>
        public static HHomMat2D[] StationaryCameraSelfCalibration(
          int numImages,
          int imageWidth,
          int imageHeight,
          int referenceImage,
          HTuple mappingSource,
          HTuple mappingDest,
          HHomMat2D[] homMatrices2D,
          HTuple rows1,
          HTuple cols1,
          HTuple rows2,
          HTuple cols2,
          HTuple numCorrespondences,
          string estimationMethod,
          HTuple cameraModel,
          string fixedCameraParams,
          out double kappa,
          out HHomMat2D[] rotationMatrices,
          out HTuple x,
          out HTuple y,
          out HTuple z,
          out double error)
        {
            HTuple htuple = HData.ConcatArray((HData[])homMatrices2D);
            IntPtr proc = HalconAPI.PreCall(1907);
            HalconAPI.StoreI(proc, 0, numImages);
            HalconAPI.StoreI(proc, 1, imageWidth);
            HalconAPI.StoreI(proc, 2, imageHeight);
            HalconAPI.StoreI(proc, 3, referenceImage);
            HalconAPI.Store(proc, 4, mappingSource);
            HalconAPI.Store(proc, 5, mappingDest);
            HalconAPI.Store(proc, 6, htuple);
            HalconAPI.Store(proc, 7, rows1);
            HalconAPI.Store(proc, 8, cols1);
            HalconAPI.Store(proc, 9, rows2);
            HalconAPI.Store(proc, 10, cols2);
            HalconAPI.Store(proc, 11, numCorrespondences);
            HalconAPI.StoreS(proc, 12, estimationMethod);
            HalconAPI.Store(proc, 13, cameraModel);
            HalconAPI.StoreS(proc, 14, fixedCameraParams);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            HalconAPI.InitOCT(proc, 6);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(mappingSource);
            HalconAPI.UnpinTuple(mappingDest);
            HalconAPI.UnpinTuple(htuple);
            HalconAPI.UnpinTuple(rows1);
            HalconAPI.UnpinTuple(cols1);
            HalconAPI.UnpinTuple(rows2);
            HalconAPI.UnpinTuple(cols2);
            HalconAPI.UnpinTuple(numCorrespondences);
            HalconAPI.UnpinTuple(cameraModel);
            HTuple tuple1;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple1);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out kappa);
            HTuple tuple2;
            int err4 = HTuple.LoadNew(proc, 2, err3, out tuple2);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out x);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.DOUBLE, err5, out y);
            int err7 = HTuple.LoadNew(proc, 5, HTupleType.DOUBLE, err6, out z);
            int procResult = HalconAPI.LoadD(proc, 6, err7, out error);
            HalconAPI.PostCall(proc, procResult);
            rotationMatrices = HHomMat2D.SplitArray(tuple2);
            return HHomMat2D.SplitArray(tuple1);
        }
    }
}
