// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HMisc
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;

namespace HalconDotNet
{
    /// <summary>Class grouping methods belonging to no other HALCON class.</summary>
    public class HMisc
    {
        /// <summary>Write a tuple to a file.</summary>
        /// <param name="tuple">Tuple with any kind of data.</param>
        /// <param name="fileName">Name of the file to be written.</param>
        public static void WriteTuple(HTuple tuple, string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(219);
            HalconAPI.Store(proc, 0, tuple);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(tuple);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Write a tuple to a file.</summary>
        /// <param name="tuple">Tuple with any kind of data.</param>
        /// <param name="fileName">Name of the file to be written.</param>
        public static void WriteTuple(double tuple, string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(219);
            HalconAPI.StoreD(proc, 0, tuple);
            HalconAPI.StoreS(proc, 1, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Read a tuple from a file.</summary>
        /// <param name="fileName">Name of the file to be read.</param>
        /// <returns>Tuple with any kind of data.</returns>
        public static HTuple ReadTuple(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(220);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Close all serial devices.</summary>
        public static void CloseAllSerials()
        {
            IntPtr proc = HalconAPI.PreCall(312);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Clear all OCV tools.</summary>
        public static void CloseAllOcvs()
        {
            IntPtr proc = HalconAPI.PreCall(644);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Destroy all OCR classifiers.</summary>
        public static void CloseAllOcrs()
        {
            IntPtr proc = HalconAPI.PreCall(724);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Concat training files.</summary>
        /// <param name="singleFiles">Names of the single training files. Default: ""</param>
        /// <param name="composedFile">Name of the composed training file. Default: "all_characters"</param>
        public static void ConcatOcrTrainf(HTuple singleFiles, string composedFile)
        {
            IntPtr proc = HalconAPI.PreCall(728);
            HalconAPI.Store(proc, 0, singleFiles);
            HalconAPI.StoreS(proc, 1, composedFile);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(singleFiles);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Concat training files.</summary>
        /// <param name="singleFiles">Names of the single training files. Default: ""</param>
        /// <param name="composedFile">Name of the composed training file. Default: "all_characters"</param>
        public static void ConcatOcrTrainf(string singleFiles, string composedFile)
        {
            IntPtr proc = HalconAPI.PreCall(728);
            HalconAPI.StoreS(proc, 0, singleFiles);
            HalconAPI.StoreS(proc, 1, composedFile);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Query which characters are stored in a (protected) training file.</summary>
        /// <param name="trainingFile">Names of the training files. Default: ""</param>
        /// <param name="password">Passwords for protected training files.</param>
        /// <param name="characterCount">Number of characters.</param>
        /// <returns>Names of the read characters.</returns>
        public static HTuple ReadOcrTrainfNamesProtected(
          HTuple trainingFile,
          HTuple password,
          out HTuple characterCount)
        {
            IntPtr proc = HalconAPI.PreCall(731);
            HalconAPI.Store(proc, 0, trainingFile);
            HalconAPI.Store(proc, 1, password);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(trainingFile);
            HalconAPI.UnpinTuple(password);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out characterCount);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Query which characters are stored in a (protected) training file.</summary>
        /// <param name="trainingFile">Names of the training files. Default: ""</param>
        /// <param name="password">Passwords for protected training files.</param>
        /// <param name="characterCount">Number of characters.</param>
        /// <returns>Names of the read characters.</returns>
        public static string ReadOcrTrainfNamesProtected(
          string trainingFile,
          string password,
          out int characterCount)
        {
            IntPtr proc = HalconAPI.PreCall(731);
            HalconAPI.StoreS(proc, 0, trainingFile);
            HalconAPI.StoreS(proc, 1, password);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            string stringValue;
            int err2 = HalconAPI.LoadS(proc, 0, err1, out stringValue);
            int procResult = HalconAPI.LoadI(proc, 1, err2, out characterCount);
            HalconAPI.PostCall(proc, procResult);
            return stringValue;
        }

        /// <summary>Query which characters are stored in a training file.</summary>
        /// <param name="trainingFile">Names of the training files. Default: ""</param>
        /// <param name="characterCount">Number of characters.</param>
        /// <returns>Names of the read characters.</returns>
        public static HTuple ReadOcrTrainfNames(HTuple trainingFile, out HTuple characterCount)
        {
            IntPtr proc = HalconAPI.PreCall(732);
            HalconAPI.Store(proc, 0, trainingFile);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(trainingFile);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out characterCount);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Query which characters are stored in a training file.</summary>
        /// <param name="trainingFile">Names of the training files. Default: ""</param>
        /// <param name="characterCount">Number of characters.</param>
        /// <returns>Names of the read characters.</returns>
        public static string ReadOcrTrainfNames(string trainingFile, out int characterCount)
        {
            IntPtr proc = HalconAPI.PreCall(732);
            HalconAPI.StoreS(proc, 0, trainingFile);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            string stringValue;
            int err2 = HalconAPI.LoadS(proc, 0, err1, out stringValue);
            int procResult = HalconAPI.LoadI(proc, 1, err2, out characterCount);
            HalconAPI.PostCall(proc, procResult);
            return stringValue;
        }

        /// <summary>Delete all measure objects.</summary>
        public static void CloseAllMeasures()
        {
            IntPtr proc = HalconAPI.PreCall(826);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Convert spherical coordinates of a 3D point to Cartesian coordinates.</summary>
        /// <param name="longitude">Longitude of the 3D point.</param>
        /// <param name="latitude">Latitude of the 3D point.</param>
        /// <param name="radius">Radius of the 3D point.</param>
        /// <param name="equatPlaneNormal">Normal vector of the equatorial plane (points to the north pole). Default: "-y"</param>
        /// <param name="zeroMeridian">Coordinate axis in the equatorial plane that points to the zero meridian. Default: "-z"</param>
        /// <param name="x">X coordinate of the 3D point.</param>
        /// <param name="y">Y coordinate of the 3D point.</param>
        /// <param name="z">Z coordinate of the 3D point.</param>
        public static void ConvertPoint3dSpherToCart(
          HTuple longitude,
          HTuple latitude,
          HTuple radius,
          string equatPlaneNormal,
          string zeroMeridian,
          out HTuple x,
          out HTuple y,
          out HTuple z)
        {
            IntPtr proc = HalconAPI.PreCall(1046);
            HalconAPI.Store(proc, 0, longitude);
            HalconAPI.Store(proc, 1, latitude);
            HalconAPI.Store(proc, 2, radius);
            HalconAPI.StoreS(proc, 3, equatPlaneNormal);
            HalconAPI.StoreS(proc, 4, zeroMeridian);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(longitude);
            HalconAPI.UnpinTuple(latitude);
            HalconAPI.UnpinTuple(radius);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out x);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out y);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out z);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Convert spherical coordinates of a 3D point to Cartesian coordinates.</summary>
        /// <param name="longitude">Longitude of the 3D point.</param>
        /// <param name="latitude">Latitude of the 3D point.</param>
        /// <param name="radius">Radius of the 3D point.</param>
        /// <param name="equatPlaneNormal">Normal vector of the equatorial plane (points to the north pole). Default: "-y"</param>
        /// <param name="zeroMeridian">Coordinate axis in the equatorial plane that points to the zero meridian. Default: "-z"</param>
        /// <param name="x">X coordinate of the 3D point.</param>
        /// <param name="y">Y coordinate of the 3D point.</param>
        /// <param name="z">Z coordinate of the 3D point.</param>
        public static void ConvertPoint3dSpherToCart(
          double longitude,
          double latitude,
          double radius,
          string equatPlaneNormal,
          string zeroMeridian,
          out double x,
          out double y,
          out double z)
        {
            IntPtr proc = HalconAPI.PreCall(1046);
            HalconAPI.StoreD(proc, 0, longitude);
            HalconAPI.StoreD(proc, 1, latitude);
            HalconAPI.StoreD(proc, 2, radius);
            HalconAPI.StoreS(proc, 3, equatPlaneNormal);
            HalconAPI.StoreS(proc, 4, zeroMeridian);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out x);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out y);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out z);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Convert Cartesian coordinates of a 3D point to spherical coordinates.</summary>
        /// <param name="x">X coordinate of the 3D point.</param>
        /// <param name="y">Y coordinate of the 3D point.</param>
        /// <param name="z">Z coordinate of the 3D point.</param>
        /// <param name="equatPlaneNormal">Normal vector of the equatorial plane (points to the north pole). Default: "-y"</param>
        /// <param name="zeroMeridian">Coordinate axis in the equatorial plane that points to the zero meridian. Default: "-z"</param>
        /// <param name="latitude">Latitude of the 3D point.</param>
        /// <param name="radius">Radius of the 3D point.</param>
        /// <returns>Longitude of the 3D point.</returns>
        public static HTuple ConvertPoint3dCartToSpher(
          HTuple x,
          HTuple y,
          HTuple z,
          string equatPlaneNormal,
          string zeroMeridian,
          out HTuple latitude,
          out HTuple radius)
        {
            IntPtr proc = HalconAPI.PreCall(1047);
            HalconAPI.Store(proc, 0, x);
            HalconAPI.Store(proc, 1, y);
            HalconAPI.Store(proc, 2, z);
            HalconAPI.StoreS(proc, 3, equatPlaneNormal);
            HalconAPI.StoreS(proc, 4, zeroMeridian);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(x);
            HalconAPI.UnpinTuple(y);
            HalconAPI.UnpinTuple(z);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out latitude);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out radius);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Convert Cartesian coordinates of a 3D point to spherical coordinates.</summary>
        /// <param name="x">X coordinate of the 3D point.</param>
        /// <param name="y">Y coordinate of the 3D point.</param>
        /// <param name="z">Z coordinate of the 3D point.</param>
        /// <param name="equatPlaneNormal">Normal vector of the equatorial plane (points to the north pole). Default: "-y"</param>
        /// <param name="zeroMeridian">Coordinate axis in the equatorial plane that points to the zero meridian. Default: "-z"</param>
        /// <param name="latitude">Latitude of the 3D point.</param>
        /// <param name="radius">Radius of the 3D point.</param>
        /// <returns>Longitude of the 3D point.</returns>
        public static double ConvertPoint3dCartToSpher(
          double x,
          double y,
          double z,
          string equatPlaneNormal,
          string zeroMeridian,
          out double latitude,
          out double radius)
        {
            IntPtr proc = HalconAPI.PreCall(1047);
            HalconAPI.StoreD(proc, 0, x);
            HalconAPI.StoreD(proc, 1, y);
            HalconAPI.StoreD(proc, 2, z);
            HalconAPI.StoreS(proc, 3, equatPlaneNormal);
            HalconAPI.StoreS(proc, 4, zeroMeridian);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int err2 = HalconAPI.LoadD(proc, 0, err1, out doubleValue);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out latitude);
            int procResult = HalconAPI.LoadD(proc, 2, err3, out radius);
            HalconAPI.PostCall(proc, procResult);
            return doubleValue;
        }

        /// <summary>Read the description file of a Kalman filter.</summary>
        /// <param name="fileName">Description file for a Kalman filter. Default: "kalman.init"</param>
        /// <param name="model">The lined up matrices A, C, Q, possibly G and u, and if necessary L stored in row-major order.</param>
        /// <param name="measurement">The matrix R stored in row-major order.</param>
        /// <param name="prediction">The matrix P0@f$P_{0}$ (error covariance matrix of the initial state estimate) stored in row-major order and the initial state estimate x0@f$x_{0}$ lined up.</param>
        /// <returns>The dimensions of the state vector, the measurement vector and the controller vector.</returns>
        public static HTuple ReadKalman(
          string fileName,
          out HTuple model,
          out HTuple measurement,
          out HTuple prediction)
        {
            IntPtr proc = HalconAPI.PreCall(1105);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out model);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out measurement);
            int procResult = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out prediction);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Read an update file of a Kalman filter.</summary>
        /// <param name="fileName">Update file for a Kalman filter. Default: "kalman.updt"</param>
        /// <param name="dimensionIn">The dimensions of the state vector, measurement vector and controller vector. Default: [3,1,0]</param>
        /// <param name="modelIn">The lined up matrices A,C,Q, possibly G and u, and if necessary L which all have been stored in row-major order. Default: [1.0,1.0,0.5,0.0,1.0,1.0,0.0,0.0,1.0,1.0,0.0,0.0,54.3,37.9,48.0,37.9,34.3,42.5,48.0,42.5,43.7]</param>
        /// <param name="measurementIn">The matrix R stored in row-major order. Default: [1,2]</param>
        /// <param name="modelOut">The lined up matrices A,C,Q, possibly G and u, and if necessary L which all have been stored in row-major order.</param>
        /// <param name="measurementOut">The matrix R stored in row-major order.</param>
        /// <returns>The dimensions of the state vector, measurement vector and controller vector.</returns>
        public static HTuple UpdateKalman(
          string fileName,
          HTuple dimensionIn,
          HTuple modelIn,
          HTuple measurementIn,
          out HTuple modelOut,
          out HTuple measurementOut)
        {
            IntPtr proc = HalconAPI.PreCall(1106);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.Store(proc, 1, dimensionIn);
            HalconAPI.Store(proc, 2, modelIn);
            HalconAPI.Store(proc, 3, measurementIn);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(dimensionIn);
            HalconAPI.UnpinTuple(modelIn);
            HalconAPI.UnpinTuple(measurementIn);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out modelOut);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out measurementOut);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Estimate the current state of a system with the help of the Kalman filtering.</summary>
        /// <param name="dimension">The dimensions of the state vector, the measurement and the controller vector. Default: [3,1,0]</param>
        /// <param name="model">The lined up matrices A,C,Q, possibly G and u, and if necessary L which have been stored in row-major order. Default: [1.0,1.0,0.5,0.0,1.0,1.0,0.0,0.0,1.0,1.0,0.0,0.0,54.3,37.9,48.0,37.9,34.3,42.5,48.0,42.5,43.7]</param>
        /// <param name="measurement">The matrix R stored in row-major order and the measurement vector y lined up. Default: [1.2,1.0]</param>
        /// <param name="predictionIn">The matrix P*@f$P$ (the extrapolation-error covariances) stored in row-major order and the extrapolation vector x*@f$x$ lined up. Default: [0.0,0.0,0.0,0.0,180.5,0.0,0.0,0.0,100.0,0.0,100.0,0.0]</param>
        /// <param name="estimate">The matrix P~@f$P$ (the estimation-error covariances) stored in row-major order and the estimated state x~@f$x$ lined up.</param>
        /// <returns>The matrix P* (the extrapolation-error covariances)stored in row-major order and the extrapolation vector x*@f$x$ lined up.</returns>
        public static HTuple FilterKalman(
          HTuple dimension,
          HTuple model,
          HTuple measurement,
          HTuple predictionIn,
          out HTuple estimate)
        {
            IntPtr proc = HalconAPI.PreCall(1107);
            HalconAPI.Store(proc, 0, dimension);
            HalconAPI.Store(proc, 1, model);
            HalconAPI.Store(proc, 2, measurement);
            HalconAPI.Store(proc, 3, predictionIn);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(dimension);
            HalconAPI.UnpinTuple(model);
            HalconAPI.UnpinTuple(measurement);
            HalconAPI.UnpinTuple(predictionIn);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out estimate);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Generate a PostScript file, which describes the rectification grid.</summary>
        /// <param name="width">Width of the checkered pattern in meters (without the two frames). Default: 0.17</param>
        /// <param name="numSquares">Number of squares per row and column. Default: 17</param>
        /// <param name="gridFile">File name of the PostScript file. Default: "rectification_grid.ps"</param>
        public static void CreateRectificationGrid(double width, int numSquares, string gridFile)
        {
            IntPtr proc = HalconAPI.PreCall(1157);
            HalconAPI.StoreD(proc, 0, width);
            HalconAPI.StoreI(proc, 1, numSquares);
            HalconAPI.StoreS(proc, 2, gridFile);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Generate a projection map that describes the mapping between an arbitrarily distorted image and the rectified image.</summary>
        /// <param name="gridSpacing">Distance of the grid points in the rectified image.</param>
        /// <param name="row">Row coordinates of the grid points in the distorted image.</param>
        /// <param name="column">Column coordinates of the grid points in the distorted image.</param>
        /// <param name="gridWidth">Width of the point grid (number of grid points).</param>
        /// <param name="imageWidth">Width of the images to be rectified.</param>
        /// <param name="imageHeight">Height of the images to be rectified.</param>
        /// <param name="mapType">Type of mapping. Default: "bilinear"</param>
        /// <returns>Image containing the mapping data.</returns>
        public static HImage GenArbitraryDistortionMap(
          int gridSpacing,
          HTuple row,
          HTuple column,
          int gridWidth,
          int imageWidth,
          int imageHeight,
          string mapType)
        {
            IntPtr proc = HalconAPI.PreCall(1160);
            HalconAPI.StoreI(proc, 0, gridSpacing);
            HalconAPI.Store(proc, 1, row);
            HalconAPI.Store(proc, 2, column);
            HalconAPI.StoreI(proc, 3, gridWidth);
            HalconAPI.StoreI(proc, 4, imageWidth);
            HalconAPI.StoreI(proc, 5, imageHeight);
            HalconAPI.StoreS(proc, 6, mapType);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            return himage;
        }

        /// <summary>Calculate the projection of a point onto a line.</summary>
        /// <param name="row">Row coordinate of the point.</param>
        /// <param name="column">Column coordinate of the point.</param>
        /// <param name="row1">Row coordinate of the first point on the line.</param>
        /// <param name="column1">Column coordinate of the first point on the line.</param>
        /// <param name="row2">Row coordinate of the second point on the line.</param>
        /// <param name="column2">Column coordinate of the second point on the line.</param>
        /// <param name="rowProj">Row coordinate of the projected point.</param>
        /// <param name="colProj">Column coordinate of the projected point</param>
        public static void ProjectionPl(
          HTuple row,
          HTuple column,
          HTuple row1,
          HTuple column1,
          HTuple row2,
          HTuple column2,
          out HTuple rowProj,
          out HTuple colProj)
        {
            IntPtr proc = HalconAPI.PreCall(1338);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, column);
            HalconAPI.Store(proc, 2, row1);
            HalconAPI.Store(proc, 3, column1);
            HalconAPI.Store(proc, 4, row2);
            HalconAPI.Store(proc, 5, column2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.UnpinTuple(row1);
            HalconAPI.UnpinTuple(column1);
            HalconAPI.UnpinTuple(row2);
            HalconAPI.UnpinTuple(column2);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out rowProj);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out colProj);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Calculate the projection of a point onto a line.</summary>
        /// <param name="row">Row coordinate of the point.</param>
        /// <param name="column">Column coordinate of the point.</param>
        /// <param name="row1">Row coordinate of the first point on the line.</param>
        /// <param name="column1">Column coordinate of the first point on the line.</param>
        /// <param name="row2">Row coordinate of the second point on the line.</param>
        /// <param name="column2">Column coordinate of the second point on the line.</param>
        /// <param name="rowProj">Row coordinate of the projected point.</param>
        /// <param name="colProj">Column coordinate of the projected point</param>
        public static void ProjectionPl(
          double row,
          double column,
          double row1,
          double column1,
          double row2,
          double column2,
          out double rowProj,
          out double colProj)
        {
            IntPtr proc = HalconAPI.PreCall(1338);
            HalconAPI.StoreD(proc, 0, row);
            HalconAPI.StoreD(proc, 1, column);
            HalconAPI.StoreD(proc, 2, row1);
            HalconAPI.StoreD(proc, 3, column1);
            HalconAPI.StoreD(proc, 4, row2);
            HalconAPI.StoreD(proc, 5, column2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out rowProj);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out colProj);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Calculate a point of an ellipse corresponding to a specific angle.</summary>
        /// <param name="angle">Angle corresponding to the resulting point [rad]. Default: 0</param>
        /// <param name="row">Row coordinate of the center of the ellipse.</param>
        /// <param name="column">Column coordinate of the center of the ellipse.</param>
        /// <param name="phi">Orientation of the main axis [rad].</param>
        /// <param name="radius1">Length of the larger half axis.</param>
        /// <param name="radius2">Length of the smaller half axis.</param>
        /// <param name="rowPoint">Row coordinate of the point on the ellipse.</param>
        /// <param name="colPoint">Column coordinates of the point on the ellipse.</param>
        public static void GetPointsEllipse(
          HTuple angle,
          double row,
          double column,
          double phi,
          double radius1,
          double radius2,
          out HTuple rowPoint,
          out HTuple colPoint)
        {
            IntPtr proc = HalconAPI.PreCall(1339);
            HalconAPI.Store(proc, 0, angle);
            HalconAPI.StoreD(proc, 1, row);
            HalconAPI.StoreD(proc, 2, column);
            HalconAPI.StoreD(proc, 3, phi);
            HalconAPI.StoreD(proc, 4, radius1);
            HalconAPI.StoreD(proc, 5, radius2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(angle);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out rowPoint);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out colPoint);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Calculate a point of an ellipse corresponding to a specific angle.</summary>
        /// <param name="angle">Angle corresponding to the resulting point [rad]. Default: 0</param>
        /// <param name="row">Row coordinate of the center of the ellipse.</param>
        /// <param name="column">Column coordinate of the center of the ellipse.</param>
        /// <param name="phi">Orientation of the main axis [rad].</param>
        /// <param name="radius1">Length of the larger half axis.</param>
        /// <param name="radius2">Length of the smaller half axis.</param>
        /// <param name="rowPoint">Row coordinate of the point on the ellipse.</param>
        /// <param name="colPoint">Column coordinates of the point on the ellipse.</param>
        public static void GetPointsEllipse(
          double angle,
          double row,
          double column,
          double phi,
          double radius1,
          double radius2,
          out double rowPoint,
          out double colPoint)
        {
            IntPtr proc = HalconAPI.PreCall(1339);
            HalconAPI.StoreD(proc, 0, angle);
            HalconAPI.StoreD(proc, 1, row);
            HalconAPI.StoreD(proc, 2, column);
            HalconAPI.StoreD(proc, 3, phi);
            HalconAPI.StoreD(proc, 4, radius1);
            HalconAPI.StoreD(proc, 5, radius2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out rowPoint);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out colPoint);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Calculate the intersection point of two lines.</summary>
        /// <param name="rowA1">Row coordinate of the first point of the first line.</param>
        /// <param name="columnA1">Column coordinate of the first point of the first line.</param>
        /// <param name="rowA2">Row coordinate of the second point of the first line.</param>
        /// <param name="columnA2">Column coordinate of the second point of the first line.</param>
        /// <param name="rowB1">Row coordinate of the first point of the second line.</param>
        /// <param name="columnB1">Column coordinate of the first point of the second line.</param>
        /// <param name="rowB2">Row coordinate of the second point of the second line.</param>
        /// <param name="columnB2">Column coordinate of the second point of the second line.</param>
        /// <param name="row">Row coordinate of the intersection point.</param>
        /// <param name="column">Column coordinate of the intersection point.</param>
        /// <param name="isParallel">Are the two lines parallel?</param>
        public static void IntersectionLl(
          HTuple rowA1,
          HTuple columnA1,
          HTuple rowA2,
          HTuple columnA2,
          HTuple rowB1,
          HTuple columnB1,
          HTuple rowB2,
          HTuple columnB2,
          out HTuple row,
          out HTuple column,
          out HTuple isParallel)
        {
            IntPtr proc = HalconAPI.PreCall(1340);
            HalconAPI.Store(proc, 0, rowA1);
            HalconAPI.Store(proc, 1, columnA1);
            HalconAPI.Store(proc, 2, rowA2);
            HalconAPI.Store(proc, 3, columnA2);
            HalconAPI.Store(proc, 4, rowB1);
            HalconAPI.Store(proc, 5, columnB1);
            HalconAPI.Store(proc, 6, rowB2);
            HalconAPI.Store(proc, 7, columnB2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(rowA1);
            HalconAPI.UnpinTuple(columnA1);
            HalconAPI.UnpinTuple(rowA2);
            HalconAPI.UnpinTuple(columnA2);
            HalconAPI.UnpinTuple(rowB1);
            HalconAPI.UnpinTuple(columnB1);
            HalconAPI.UnpinTuple(rowB2);
            HalconAPI.UnpinTuple(columnB2);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out row);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out column);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, err3, out isParallel);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Calculate the intersection point of two lines.</summary>
        /// <param name="rowA1">Row coordinate of the first point of the first line.</param>
        /// <param name="columnA1">Column coordinate of the first point of the first line.</param>
        /// <param name="rowA2">Row coordinate of the second point of the first line.</param>
        /// <param name="columnA2">Column coordinate of the second point of the first line.</param>
        /// <param name="rowB1">Row coordinate of the first point of the second line.</param>
        /// <param name="columnB1">Column coordinate of the first point of the second line.</param>
        /// <param name="rowB2">Row coordinate of the second point of the second line.</param>
        /// <param name="columnB2">Column coordinate of the second point of the second line.</param>
        /// <param name="row">Row coordinate of the intersection point.</param>
        /// <param name="column">Column coordinate of the intersection point.</param>
        /// <param name="isParallel">Are the two lines parallel?</param>
        public static void IntersectionLl(
          double rowA1,
          double columnA1,
          double rowA2,
          double columnA2,
          double rowB1,
          double columnB1,
          double rowB2,
          double columnB2,
          out double row,
          out double column,
          out int isParallel)
        {
            IntPtr proc = HalconAPI.PreCall(1340);
            HalconAPI.StoreD(proc, 0, rowA1);
            HalconAPI.StoreD(proc, 1, columnA1);
            HalconAPI.StoreD(proc, 2, rowA2);
            HalconAPI.StoreD(proc, 3, columnA2);
            HalconAPI.StoreD(proc, 4, rowB1);
            HalconAPI.StoreD(proc, 5, columnB1);
            HalconAPI.StoreD(proc, 6, rowB2);
            HalconAPI.StoreD(proc, 7, columnB2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out row);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out column);
            int procResult = HalconAPI.LoadI(proc, 2, err3, out isParallel);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Calculate the angle between one line and the horizontal axis.</summary>
        /// <param name="row1">Row coordinate the first point of the line.</param>
        /// <param name="column1">Column coordinate of the first point of the line.</param>
        /// <param name="row2">Row coordinate of the second point of the line.</param>
        /// <param name="column2">Column coordinate of the second point of the line.</param>
        /// <returns>Angle between the line and the horizontal axis [rad].</returns>
        public static HTuple AngleLx(HTuple row1, HTuple column1, HTuple row2, HTuple column2)
        {
            IntPtr proc = HalconAPI.PreCall(1370);
            HalconAPI.Store(proc, 0, row1);
            HalconAPI.Store(proc, 1, column1);
            HalconAPI.Store(proc, 2, row2);
            HalconAPI.Store(proc, 3, column2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row1);
            HalconAPI.UnpinTuple(column1);
            HalconAPI.UnpinTuple(row2);
            HalconAPI.UnpinTuple(column2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Calculate the angle between one line and the horizontal axis.</summary>
        /// <param name="row1">Row coordinate the first point of the line.</param>
        /// <param name="column1">Column coordinate of the first point of the line.</param>
        /// <param name="row2">Row coordinate of the second point of the line.</param>
        /// <param name="column2">Column coordinate of the second point of the line.</param>
        /// <returns>Angle between the line and the horizontal axis [rad].</returns>
        public static double AngleLx(double row1, double column1, double row2, double column2)
        {
            IntPtr proc = HalconAPI.PreCall(1370);
            HalconAPI.StoreD(proc, 0, row1);
            HalconAPI.StoreD(proc, 1, column1);
            HalconAPI.StoreD(proc, 2, row2);
            HalconAPI.StoreD(proc, 3, column2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            return doubleValue;
        }

        /// <summary>Calculate the angle between two lines.</summary>
        /// <param name="rowA1">Row coordinate of the first point of the first line.</param>
        /// <param name="columnA1">Column coordinate of the first point of the first line.</param>
        /// <param name="rowA2">Row coordinate of the second point of the first line.</param>
        /// <param name="columnA2">Column coordinate of the second point of the first line.</param>
        /// <param name="rowB1">Row coordinate of the first point of the second line.</param>
        /// <param name="columnB1">Column coordinate of the first point of the second line.</param>
        /// <param name="rowB2">Row coordinate of the second point of the second line.</param>
        /// <param name="columnB2">Column coordinate of the second point of the second line.</param>
        /// <returns>Angle between the lines [rad].</returns>
        public static HTuple AngleLl(
          HTuple rowA1,
          HTuple columnA1,
          HTuple rowA2,
          HTuple columnA2,
          HTuple rowB1,
          HTuple columnB1,
          HTuple rowB2,
          HTuple columnB2)
        {
            IntPtr proc = HalconAPI.PreCall(1371);
            HalconAPI.Store(proc, 0, rowA1);
            HalconAPI.Store(proc, 1, columnA1);
            HalconAPI.Store(proc, 2, rowA2);
            HalconAPI.Store(proc, 3, columnA2);
            HalconAPI.Store(proc, 4, rowB1);
            HalconAPI.Store(proc, 5, columnB1);
            HalconAPI.Store(proc, 6, rowB2);
            HalconAPI.Store(proc, 7, columnB2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(rowA1);
            HalconAPI.UnpinTuple(columnA1);
            HalconAPI.UnpinTuple(rowA2);
            HalconAPI.UnpinTuple(columnA2);
            HalconAPI.UnpinTuple(rowB1);
            HalconAPI.UnpinTuple(columnB1);
            HalconAPI.UnpinTuple(rowB2);
            HalconAPI.UnpinTuple(columnB2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Calculate the angle between two lines.</summary>
        /// <param name="rowA1">Row coordinate of the first point of the first line.</param>
        /// <param name="columnA1">Column coordinate of the first point of the first line.</param>
        /// <param name="rowA2">Row coordinate of the second point of the first line.</param>
        /// <param name="columnA2">Column coordinate of the second point of the first line.</param>
        /// <param name="rowB1">Row coordinate of the first point of the second line.</param>
        /// <param name="columnB1">Column coordinate of the first point of the second line.</param>
        /// <param name="rowB2">Row coordinate of the second point of the second line.</param>
        /// <param name="columnB2">Column coordinate of the second point of the second line.</param>
        /// <returns>Angle between the lines [rad].</returns>
        public static double AngleLl(
          double rowA1,
          double columnA1,
          double rowA2,
          double columnA2,
          double rowB1,
          double columnB1,
          double rowB2,
          double columnB2)
        {
            IntPtr proc = HalconAPI.PreCall(1371);
            HalconAPI.StoreD(proc, 0, rowA1);
            HalconAPI.StoreD(proc, 1, columnA1);
            HalconAPI.StoreD(proc, 2, rowA2);
            HalconAPI.StoreD(proc, 3, columnA2);
            HalconAPI.StoreD(proc, 4, rowB1);
            HalconAPI.StoreD(proc, 5, columnB1);
            HalconAPI.StoreD(proc, 6, rowB2);
            HalconAPI.StoreD(proc, 7, columnB2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            return doubleValue;
        }

        /// <summary>Calculate the distances between a line segment and a line.</summary>
        /// <param name="rowA1">Row coordinate of the first point of the line segment.</param>
        /// <param name="columnA1">Column coordinate of the first point of the line segment.</param>
        /// <param name="rowA2">Row coordinate of the second point of the line segment.</param>
        /// <param name="columnA2">Column coordinate of the second point of the line segment.</param>
        /// <param name="rowB1">Row coordinate of the first point of the line.</param>
        /// <param name="columnB1">Column coordinate of the first point of the line.</param>
        /// <param name="rowB2">Row coordinate of the second point of the line.</param>
        /// <param name="columnB2">Column coordinate of the second point of the line.</param>
        /// <param name="distanceMin">Minimum distance between the line segment and the line.</param>
        /// <param name="distanceMax">Maximum distance between the line segment and the line.</param>
        public static void DistanceSl(
          HTuple rowA1,
          HTuple columnA1,
          HTuple rowA2,
          HTuple columnA2,
          HTuple rowB1,
          HTuple columnB1,
          HTuple rowB2,
          HTuple columnB2,
          out HTuple distanceMin,
          out HTuple distanceMax)
        {
            IntPtr proc = HalconAPI.PreCall(1372);
            HalconAPI.Store(proc, 0, rowA1);
            HalconAPI.Store(proc, 1, columnA1);
            HalconAPI.Store(proc, 2, rowA2);
            HalconAPI.Store(proc, 3, columnA2);
            HalconAPI.Store(proc, 4, rowB1);
            HalconAPI.Store(proc, 5, columnB1);
            HalconAPI.Store(proc, 6, rowB2);
            HalconAPI.Store(proc, 7, columnB2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(rowA1);
            HalconAPI.UnpinTuple(columnA1);
            HalconAPI.UnpinTuple(rowA2);
            HalconAPI.UnpinTuple(columnA2);
            HalconAPI.UnpinTuple(rowB1);
            HalconAPI.UnpinTuple(columnB1);
            HalconAPI.UnpinTuple(rowB2);
            HalconAPI.UnpinTuple(columnB2);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out distanceMin);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out distanceMax);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Calculate the distances between a line segment and a line.</summary>
        /// <param name="rowA1">Row coordinate of the first point of the line segment.</param>
        /// <param name="columnA1">Column coordinate of the first point of the line segment.</param>
        /// <param name="rowA2">Row coordinate of the second point of the line segment.</param>
        /// <param name="columnA2">Column coordinate of the second point of the line segment.</param>
        /// <param name="rowB1">Row coordinate of the first point of the line.</param>
        /// <param name="columnB1">Column coordinate of the first point of the line.</param>
        /// <param name="rowB2">Row coordinate of the second point of the line.</param>
        /// <param name="columnB2">Column coordinate of the second point of the line.</param>
        /// <param name="distanceMin">Minimum distance between the line segment and the line.</param>
        /// <param name="distanceMax">Maximum distance between the line segment and the line.</param>
        public static void DistanceSl(
          double rowA1,
          double columnA1,
          double rowA2,
          double columnA2,
          double rowB1,
          double columnB1,
          double rowB2,
          double columnB2,
          out double distanceMin,
          out double distanceMax)
        {
            IntPtr proc = HalconAPI.PreCall(1372);
            HalconAPI.StoreD(proc, 0, rowA1);
            HalconAPI.StoreD(proc, 1, columnA1);
            HalconAPI.StoreD(proc, 2, rowA2);
            HalconAPI.StoreD(proc, 3, columnA2);
            HalconAPI.StoreD(proc, 4, rowB1);
            HalconAPI.StoreD(proc, 5, columnB1);
            HalconAPI.StoreD(proc, 6, rowB2);
            HalconAPI.StoreD(proc, 7, columnB2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out distanceMin);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out distanceMax);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Calculate the distances between two line segments.</summary>
        /// <param name="rowA1">Row coordinate of the first point of the line segment.</param>
        /// <param name="columnA1">Column coordinate of the first point of the line segment.</param>
        /// <param name="rowA2">Row coordinate of the second point of the line segment.</param>
        /// <param name="columnA2">Column coordinate of the second point of the line segment.</param>
        /// <param name="rowB1">Row coordinate of the first point of the line.</param>
        /// <param name="columnB1">Column of the first point of the line.</param>
        /// <param name="rowB2">Row coordinate of the second point of the line.</param>
        /// <param name="columnB2">Column coordinate of the second point of the line.</param>
        /// <param name="distanceMin">Minimum distance between the line segments.</param>
        /// <param name="distanceMax">Maximum distance between the line segments.</param>
        public static void DistanceSs(
          HTuple rowA1,
          HTuple columnA1,
          HTuple rowA2,
          HTuple columnA2,
          HTuple rowB1,
          HTuple columnB1,
          HTuple rowB2,
          HTuple columnB2,
          out HTuple distanceMin,
          out HTuple distanceMax)
        {
            IntPtr proc = HalconAPI.PreCall(1373);
            HalconAPI.Store(proc, 0, rowA1);
            HalconAPI.Store(proc, 1, columnA1);
            HalconAPI.Store(proc, 2, rowA2);
            HalconAPI.Store(proc, 3, columnA2);
            HalconAPI.Store(proc, 4, rowB1);
            HalconAPI.Store(proc, 5, columnB1);
            HalconAPI.Store(proc, 6, rowB2);
            HalconAPI.Store(proc, 7, columnB2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(rowA1);
            HalconAPI.UnpinTuple(columnA1);
            HalconAPI.UnpinTuple(rowA2);
            HalconAPI.UnpinTuple(columnA2);
            HalconAPI.UnpinTuple(rowB1);
            HalconAPI.UnpinTuple(columnB1);
            HalconAPI.UnpinTuple(rowB2);
            HalconAPI.UnpinTuple(columnB2);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out distanceMin);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out distanceMax);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Calculate the distances between two line segments.</summary>
        /// <param name="rowA1">Row coordinate of the first point of the line segment.</param>
        /// <param name="columnA1">Column coordinate of the first point of the line segment.</param>
        /// <param name="rowA2">Row coordinate of the second point of the line segment.</param>
        /// <param name="columnA2">Column coordinate of the second point of the line segment.</param>
        /// <param name="rowB1">Row coordinate of the first point of the line.</param>
        /// <param name="columnB1">Column of the first point of the line.</param>
        /// <param name="rowB2">Row coordinate of the second point of the line.</param>
        /// <param name="columnB2">Column coordinate of the second point of the line.</param>
        /// <param name="distanceMin">Minimum distance between the line segments.</param>
        /// <param name="distanceMax">Maximum distance between the line segments.</param>
        public static void DistanceSs(
          double rowA1,
          double columnA1,
          double rowA2,
          double columnA2,
          double rowB1,
          double columnB1,
          double rowB2,
          double columnB2,
          out double distanceMin,
          out double distanceMax)
        {
            IntPtr proc = HalconAPI.PreCall(1373);
            HalconAPI.StoreD(proc, 0, rowA1);
            HalconAPI.StoreD(proc, 1, columnA1);
            HalconAPI.StoreD(proc, 2, rowA2);
            HalconAPI.StoreD(proc, 3, columnA2);
            HalconAPI.StoreD(proc, 4, rowB1);
            HalconAPI.StoreD(proc, 5, columnB1);
            HalconAPI.StoreD(proc, 6, rowB2);
            HalconAPI.StoreD(proc, 7, columnB2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out distanceMin);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out distanceMax);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Calculate the distances between a point and a line segment.</summary>
        /// <param name="row">Row coordinate of the first point.</param>
        /// <param name="column">Column coordinate of the first point.</param>
        /// <param name="row1">Row coordinate of the first point of the line segment.</param>
        /// <param name="column1">Column coordinate of the first point of the line segment.</param>
        /// <param name="row2">Row coordinate of the second point of the line segment.</param>
        /// <param name="column2">Column coordinate of the second point of the line segment.</param>
        /// <param name="distanceMin">Minimum distance between the point and the line segment.</param>
        /// <param name="distanceMax">Maximum distance between the point and the line segment.</param>
        public static void DistancePs(
          HTuple row,
          HTuple column,
          HTuple row1,
          HTuple column1,
          HTuple row2,
          HTuple column2,
          out HTuple distanceMin,
          out HTuple distanceMax)
        {
            IntPtr proc = HalconAPI.PreCall(1374);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, column);
            HalconAPI.Store(proc, 2, row1);
            HalconAPI.Store(proc, 3, column1);
            HalconAPI.Store(proc, 4, row2);
            HalconAPI.Store(proc, 5, column2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.UnpinTuple(row1);
            HalconAPI.UnpinTuple(column1);
            HalconAPI.UnpinTuple(row2);
            HalconAPI.UnpinTuple(column2);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out distanceMin);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out distanceMax);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Calculate the distances between a point and a line segment.</summary>
        /// <param name="row">Row coordinate of the first point.</param>
        /// <param name="column">Column coordinate of the first point.</param>
        /// <param name="row1">Row coordinate of the first point of the line segment.</param>
        /// <param name="column1">Column coordinate of the first point of the line segment.</param>
        /// <param name="row2">Row coordinate of the second point of the line segment.</param>
        /// <param name="column2">Column coordinate of the second point of the line segment.</param>
        /// <param name="distanceMin">Minimum distance between the point and the line segment.</param>
        /// <param name="distanceMax">Maximum distance between the point and the line segment.</param>
        public static void DistancePs(
          double row,
          double column,
          double row1,
          double column1,
          double row2,
          double column2,
          out double distanceMin,
          out double distanceMax)
        {
            IntPtr proc = HalconAPI.PreCall(1374);
            HalconAPI.StoreD(proc, 0, row);
            HalconAPI.StoreD(proc, 1, column);
            HalconAPI.StoreD(proc, 2, row1);
            HalconAPI.StoreD(proc, 3, column1);
            HalconAPI.StoreD(proc, 4, row2);
            HalconAPI.StoreD(proc, 5, column2);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out distanceMin);
            int procResult = HalconAPI.LoadD(proc, 1, err2, out distanceMax);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Calculate the distance between one point and one line.</summary>
        /// <param name="row">Row coordinate of the point.</param>
        /// <param name="column">Column of the point.</param>
        /// <param name="row1">Row coordinate of the first point of the line.</param>
        /// <param name="column1">Column coordinate of the first point of the line.</param>
        /// <param name="row2">Row coordinate of the second point of the line.</param>
        /// <param name="column2">Column coordinate of the second point of the line.</param>
        /// <returns>Distance between the points.</returns>
        public static HTuple DistancePl(
          HTuple row,
          HTuple column,
          HTuple row1,
          HTuple column1,
          HTuple row2,
          HTuple column2)
        {
            IntPtr proc = HalconAPI.PreCall(1375);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, column);
            HalconAPI.Store(proc, 2, row1);
            HalconAPI.Store(proc, 3, column1);
            HalconAPI.Store(proc, 4, row2);
            HalconAPI.Store(proc, 5, column2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.UnpinTuple(row1);
            HalconAPI.UnpinTuple(column1);
            HalconAPI.UnpinTuple(row2);
            HalconAPI.UnpinTuple(column2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Calculate the distance between one point and one line.</summary>
        /// <param name="row">Row coordinate of the point.</param>
        /// <param name="column">Column of the point.</param>
        /// <param name="row1">Row coordinate of the first point of the line.</param>
        /// <param name="column1">Column coordinate of the first point of the line.</param>
        /// <param name="row2">Row coordinate of the second point of the line.</param>
        /// <param name="column2">Column coordinate of the second point of the line.</param>
        /// <returns>Distance between the points.</returns>
        public static double DistancePl(
          double row,
          double column,
          double row1,
          double column1,
          double row2,
          double column2)
        {
            IntPtr proc = HalconAPI.PreCall(1375);
            HalconAPI.StoreD(proc, 0, row);
            HalconAPI.StoreD(proc, 1, column);
            HalconAPI.StoreD(proc, 2, row1);
            HalconAPI.StoreD(proc, 3, column1);
            HalconAPI.StoreD(proc, 4, row2);
            HalconAPI.StoreD(proc, 5, column2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            return doubleValue;
        }

        /// <summary>Calculate the distance between two points.</summary>
        /// <param name="row1">Row coordinate of the first point.</param>
        /// <param name="column1">Column coordinate of the first point.</param>
        /// <param name="row2">Row coordinate of the second point.</param>
        /// <param name="column2">Column coordinate of the second point.</param>
        /// <returns>Distance between the points.</returns>
        public static HTuple DistancePp(
          HTuple row1,
          HTuple column1,
          HTuple row2,
          HTuple column2)
        {
            IntPtr proc = HalconAPI.PreCall(1376);
            HalconAPI.Store(proc, 0, row1);
            HalconAPI.Store(proc, 1, column1);
            HalconAPI.Store(proc, 2, row2);
            HalconAPI.Store(proc, 3, column2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row1);
            HalconAPI.UnpinTuple(column1);
            HalconAPI.UnpinTuple(row2);
            HalconAPI.UnpinTuple(column2);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Calculate the distance between two points.</summary>
        /// <param name="row1">Row coordinate of the first point.</param>
        /// <param name="column1">Column coordinate of the first point.</param>
        /// <param name="row2">Row coordinate of the second point.</param>
        /// <param name="column2">Column coordinate of the second point.</param>
        /// <returns>Distance between the points.</returns>
        public static double DistancePp(double row1, double column1, double row2, double column2)
        {
            IntPtr proc = HalconAPI.PreCall(1376);
            HalconAPI.StoreD(proc, 0, row1);
            HalconAPI.StoreD(proc, 1, column1);
            HalconAPI.StoreD(proc, 2, row2);
            HalconAPI.StoreD(proc, 3, column2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            return doubleValue;
        }

        /// <summary>Information on smoothing filter smooth_image.</summary>
        /// <param name="filter">Name of required filter. Default: "deriche2"</param>
        /// <param name="alpha">Filter parameter: small values effect strong smoothing (reversed in case of 'gauss'). Default: 0.5</param>
        /// <param name="coeffs">In case of gauss filter: coefficients of the "positive" half of the 1D impulse answer.</param>
        /// <returns>Width of filter is approx. size x size pixels.</returns>
        public static int InfoSmooth(string filter, double alpha, out HTuple coeffs)
        {
            IntPtr proc = HalconAPI.PreCall(1419);
            HalconAPI.StoreS(proc, 0, filter);
            HalconAPI.StoreD(proc, 1, alpha);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int intValue;
            int err2 = HalconAPI.LoadI(proc, 0, err1, out intValue);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out coeffs);
            HalconAPI.PostCall(proc, procResult);
            return intValue;
        }

        /// <summary>Generate a Gaussian noise distribution.</summary>
        /// <param name="sigma">Standard deviation of the Gaussian noise distribution. Default: 2.0</param>
        /// <returns>Resulting Gaussian noise distribution.</returns>
        public static HTuple GaussDistribution(double sigma)
        {
            IntPtr proc = HalconAPI.PreCall(1443);
            HalconAPI.StoreD(proc, 0, sigma);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Generate a salt-and-pepper noise distribution.</summary>
        /// <param name="percentSalt">Percentage of salt (white noise pixels). Default: 5.0</param>
        /// <param name="percentPepper">Percentage of pepper (black noise pixels). Default: 5.0</param>
        /// <returns>Resulting noise distribution.</returns>
        public static HTuple SpDistribution(HTuple percentSalt, HTuple percentPepper)
        {
            IntPtr proc = HalconAPI.PreCall(1444);
            HalconAPI.Store(proc, 0, percentSalt);
            HalconAPI.Store(proc, 1, percentPepper);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(percentSalt);
            HalconAPI.UnpinTuple(percentPepper);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Generate a salt-and-pepper noise distribution.</summary>
        /// <param name="percentSalt">Percentage of salt (white noise pixels). Default: 5.0</param>
        /// <param name="percentPepper">Percentage of pepper (black noise pixels). Default: 5.0</param>
        /// <returns>Resulting noise distribution.</returns>
        public static HTuple SpDistribution(double percentSalt, double percentPepper)
        {
            IntPtr proc = HalconAPI.PreCall(1444);
            HalconAPI.StoreD(proc, 0, percentSalt);
            HalconAPI.StoreD(proc, 1, percentPepper);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Deserialize FFT speed optimization data.</summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public static void DeserializeFftOptimizationData(HSerializedItem serializedItemHandle)
        {
            IntPtr proc = HalconAPI.PreCall(1535);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>Serialize FFT speed optimization data.</summary>
        /// <returns>Handle of the serialized item.</returns>
        public static HSerializedItem SerializeFftOptimizationData()
        {
            IntPtr proc = HalconAPI.PreCall(1536);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HSerializedItem hserializedItem;
            int procResult = HSerializedItem.LoadNew(proc, 0, err, out hserializedItem);
            HalconAPI.PostCall(proc, procResult);
            return hserializedItem;
        }

        /// <summary>Load FFT speed optimization data from a file.</summary>
        /// <param name="fileName">File name of the optimization data. Default: "fft_opt.dat"</param>
        public static void ReadFftOptimizationData(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1537);
            HalconAPI.StoreS(proc, 0, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Store FFT speed optimization data in a file.</summary>
        /// <param name="fileName">File name of the optimization data. Default: "fft_opt.dat"</param>
        public static void WriteFftOptimizationData(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1538);
            HalconAPI.StoreS(proc, 0, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Optimize the runtime of the real-valued FFT.</summary>
        /// <param name="width">Width of the image for which the runtime should be optimized. Default: 512</param>
        /// <param name="height">Height of the image for which the runtime should be optimized. Default: 512</param>
        /// <param name="mode">Thoroughness of the search for the optimum runtime. Default: "standard"</param>
        public static void OptimizeRftSpeed(int width, int height, string mode)
        {
            IntPtr proc = HalconAPI.PreCall(1539);
            HalconAPI.StoreI(proc, 0, width);
            HalconAPI.StoreI(proc, 1, height);
            HalconAPI.StoreS(proc, 2, mode);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Optimize the runtime of the FFT.</summary>
        /// <param name="width">Width of the image for which the runtime should be optimized. Default: 512</param>
        /// <param name="height">Height of the image for which the runtime should be optimized. Default: 512</param>
        /// <param name="mode">Thoroughness of the search for the optimum runtime. Default: "standard"</param>
        public static void OptimizeFftSpeed(int width, int height, string mode)
        {
            IntPtr proc = HalconAPI.PreCall(1540);
            HalconAPI.StoreI(proc, 0, width);
            HalconAPI.StoreI(proc, 1, height);
            HalconAPI.StoreS(proc, 2, mode);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Estimate the width of a filter in edges_image.</summary>
        /// <param name="filter">Name of the edge operator. Default: "lanser2"</param>
        /// <param name="mode">1D edge filter ('edge') or 1D smoothing filter ('smooth'). Default: "edge"</param>
        /// <param name="alpha">Filter parameter: small values result in strong smoothing, and thus less detail (opposite for 'canny'). Default: 0.5</param>
        /// <param name="coeffs">For Canny filters: Coefficients of the "positive" half of the 1D impulse response.</param>
        /// <returns>Filter width in pixels.</returns>
        public static int InfoEdges(string filter, string mode, double alpha, out HTuple coeffs)
        {
            IntPtr proc = HalconAPI.PreCall(1565);
            HalconAPI.StoreS(proc, 0, filter);
            HalconAPI.StoreS(proc, 1, mode);
            HalconAPI.StoreD(proc, 2, alpha);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int intValue;
            int err2 = HalconAPI.LoadI(proc, 0, err1, out intValue);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out coeffs);
            HalconAPI.PostCall(proc, procResult);
            return intValue;
        }

        /// <summary>Copy a file to a new location.</summary>
        /// <param name="sourceFile">File to be copied.</param>
        /// <param name="destinationFile">Target location.</param>
        public static void CopyFile(string sourceFile, string destinationFile)
        {
            IntPtr proc = HalconAPI.PreCall(1638);
            HalconAPI.StoreS(proc, 0, sourceFile);
            HalconAPI.StoreS(proc, 1, destinationFile);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Set the current working directory.</summary>
        /// <param name="dirName">Name of current working directory to be set.</param>
        public static void SetCurrentDir(string dirName)
        {
            IntPtr proc = HalconAPI.PreCall(1639);
            HalconAPI.StoreS(proc, 0, dirName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Get the current working directory.</summary>
        /// <returns>Name of current working directory.</returns>
        public static string GetCurrentDir()
        {
            IntPtr proc = HalconAPI.PreCall(1640);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            string stringValue;
            int procResult = HalconAPI.LoadS(proc, 0, err, out stringValue);
            HalconAPI.PostCall(proc, procResult);
            return stringValue;
        }

        /// <summary>Delete an empty directory.</summary>
        /// <param name="dirName">Name of directory to be deleted.</param>
        public static void RemoveDir(string dirName)
        {
            IntPtr proc = HalconAPI.PreCall(1641);
            HalconAPI.StoreS(proc, 0, dirName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Make a directory.</summary>
        /// <param name="dirName">Name of directory to be created.</param>
        public static void MakeDir(string dirName)
        {
            IntPtr proc = HalconAPI.PreCall(1642);
            HalconAPI.StoreS(proc, 0, dirName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>List all files in a directory.</summary>
        /// <param name="directory">Name of directory to be listed.</param>
        /// <param name="options">Processing options. Default: "files"</param>
        /// <returns>Found files (and directories).</returns>
        public static HTuple ListFiles(string directory, HTuple options)
        {
            IntPtr proc = HalconAPI.PreCall(1643);
            HalconAPI.StoreS(proc, 0, directory);
            HalconAPI.Store(proc, 1, options);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(options);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>List all files in a directory.</summary>
        /// <param name="directory">Name of directory to be listed.</param>
        /// <param name="options">Processing options. Default: "files"</param>
        /// <returns>Found files (and directories).</returns>
        public static HTuple ListFiles(string directory, string options)
        {
            IntPtr proc = HalconAPI.PreCall(1643);
            HalconAPI.StoreS(proc, 0, directory);
            HalconAPI.StoreS(proc, 1, options);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Delete a file.</summary>
        /// <param name="fileName">File to be deleted.</param>
        public static void DeleteFile(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1644);
            HalconAPI.StoreS(proc, 0, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Check whether file exists.</summary>
        /// <param name="fileName">Name of file to be checked. Default: "/bin/cc"</param>
        /// <returns>boolean number.</returns>
        public static int FileExists(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1645);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            return intValue;
        }

        /// <summary>Close all open files.</summary>
        public static void CloseAllFiles()
        {
            IntPtr proc = HalconAPI.PreCall(1666);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Select the longest input lines.</summary>
        /// <param name="rowBeginIn">Row coordinates of the starting points of the input lines.</param>
        /// <param name="colBeginIn">Column coordinates of the starting points of the input lines.</param>
        /// <param name="rowEndIn">Row coordinates of the ending points of the input lines.</param>
        /// <param name="colEndIn">Column coordinates  of the ending points of the input lines.</param>
        /// <param name="num">(Maximum) desired number of output lines. Default: 10</param>
        /// <param name="rowBeginOut">Row coordinates of the starting points of the output lines.</param>
        /// <param name="colBeginOut">Column coordinates of the starting points of the output lines.</param>
        /// <param name="rowEndOut">Row coordinates of the ending points of the output lines.</param>
        /// <param name="colEndOut">Column coordinates of the ending points of the output lines.</param>
        public static void SelectLinesLongest(
          HTuple rowBeginIn,
          HTuple colBeginIn,
          HTuple rowEndIn,
          HTuple colEndIn,
          int num,
          out HTuple rowBeginOut,
          out HTuple colBeginOut,
          out HTuple rowEndOut,
          out HTuple colEndOut)
        {
            IntPtr proc = HalconAPI.PreCall(1736);
            HalconAPI.Store(proc, 0, rowBeginIn);
            HalconAPI.Store(proc, 1, colBeginIn);
            HalconAPI.Store(proc, 2, rowEndIn);
            HalconAPI.Store(proc, 3, colEndIn);
            HalconAPI.StoreI(proc, 4, num);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(rowBeginIn);
            HalconAPI.UnpinTuple(colBeginIn);
            HalconAPI.UnpinTuple(rowEndIn);
            HalconAPI.UnpinTuple(colEndIn);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out rowBeginOut);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out colBeginOut);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, err3, out rowEndOut);
            int procResult = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, err4, out colEndOut);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Partition lines according to various criteria.</summary>
        /// <param name="rowBeginIn">Row coordinates of the starting points of the input lines.</param>
        /// <param name="colBeginIn">Column coordinates of the starting points of the input lines.</param>
        /// <param name="rowEndIn">Row coordinates of the ending points of the input lines.</param>
        /// <param name="colEndIn">Column coordinates  of the ending points of the input lines.</param>
        /// <param name="feature">Features to be used for selection.</param>
        /// <param name="operation">Desired combination of the features.</param>
        /// <param name="min">Lower limits of the features or 'min'. Default: "min"</param>
        /// <param name="max">Upper limits of the features or 'max'. Default: "max"</param>
        /// <param name="rowBeginOut">Row coordinates of the starting points of the lines fulfilling the conditions.</param>
        /// <param name="colBeginOut">Column coordinates of the starting points of the lines fulfilling the conditions.</param>
        /// <param name="rowEndOut">Row coordinates of the ending points of the lines fulfilling the conditions.</param>
        /// <param name="colEndOut">Column coordinates of the ending points of the lines fulfilling the conditions.</param>
        /// <param name="failRowBOut">Row coordinates of the starting points of the lines not fulfilling the conditions.</param>
        /// <param name="failColBOut">Column coordinates of the starting points of the lines not fulfilling the conditions.</param>
        /// <param name="failRowEOut">Row coordinates of the ending points of the lines not fulfilling the conditions.</param>
        /// <param name="failColEOut">Column coordinates of the ending points of the lines not fulfilling the conditions.</param>
        public static void PartitionLines(
          HTuple rowBeginIn,
          HTuple colBeginIn,
          HTuple rowEndIn,
          HTuple colEndIn,
          HTuple feature,
          string operation,
          HTuple min,
          HTuple max,
          out HTuple rowBeginOut,
          out HTuple colBeginOut,
          out HTuple rowEndOut,
          out HTuple colEndOut,
          out HTuple failRowBOut,
          out HTuple failColBOut,
          out HTuple failRowEOut,
          out HTuple failColEOut)
        {
            IntPtr proc = HalconAPI.PreCall(1737);
            HalconAPI.Store(proc, 0, rowBeginIn);
            HalconAPI.Store(proc, 1, colBeginIn);
            HalconAPI.Store(proc, 2, rowEndIn);
            HalconAPI.Store(proc, 3, colEndIn);
            HalconAPI.Store(proc, 4, feature);
            HalconAPI.StoreS(proc, 5, operation);
            HalconAPI.Store(proc, 6, min);
            HalconAPI.Store(proc, 7, max);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            HalconAPI.InitOCT(proc, 6);
            HalconAPI.InitOCT(proc, 7);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(rowBeginIn);
            HalconAPI.UnpinTuple(colBeginIn);
            HalconAPI.UnpinTuple(rowEndIn);
            HalconAPI.UnpinTuple(colEndIn);
            HalconAPI.UnpinTuple(feature);
            HalconAPI.UnpinTuple(min);
            HalconAPI.UnpinTuple(max);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out rowBeginOut);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out colBeginOut);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, err3, out rowEndOut);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, err4, out colEndOut);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, err5, out failRowBOut);
            int err7 = HTuple.LoadNew(proc, 5, HTupleType.INTEGER, err6, out failColBOut);
            int err8 = HTuple.LoadNew(proc, 6, HTupleType.INTEGER, err7, out failRowEOut);
            int procResult = HTuple.LoadNew(proc, 7, HTupleType.INTEGER, err8, out failColEOut);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Partition lines according to various criteria.</summary>
        /// <param name="rowBeginIn">Row coordinates of the starting points of the input lines.</param>
        /// <param name="colBeginIn">Column coordinates of the starting points of the input lines.</param>
        /// <param name="rowEndIn">Row coordinates of the ending points of the input lines.</param>
        /// <param name="colEndIn">Column coordinates  of the ending points of the input lines.</param>
        /// <param name="feature">Features to be used for selection.</param>
        /// <param name="operation">Desired combination of the features.</param>
        /// <param name="min">Lower limits of the features or 'min'. Default: "min"</param>
        /// <param name="max">Upper limits of the features or 'max'. Default: "max"</param>
        /// <param name="rowBeginOut">Row coordinates of the starting points of the lines fulfilling the conditions.</param>
        /// <param name="colBeginOut">Column coordinates of the starting points of the lines fulfilling the conditions.</param>
        /// <param name="rowEndOut">Row coordinates of the ending points of the lines fulfilling the conditions.</param>
        /// <param name="colEndOut">Column coordinates of the ending points of the lines fulfilling the conditions.</param>
        /// <param name="failRowBOut">Row coordinates of the starting points of the lines not fulfilling the conditions.</param>
        /// <param name="failColBOut">Column coordinates of the starting points of the lines not fulfilling the conditions.</param>
        /// <param name="failRowEOut">Row coordinates of the ending points of the lines not fulfilling the conditions.</param>
        /// <param name="failColEOut">Column coordinates of the ending points of the lines not fulfilling the conditions.</param>
        public static void PartitionLines(
          HTuple rowBeginIn,
          HTuple colBeginIn,
          HTuple rowEndIn,
          HTuple colEndIn,
          string feature,
          string operation,
          string min,
          string max,
          out HTuple rowBeginOut,
          out HTuple colBeginOut,
          out HTuple rowEndOut,
          out HTuple colEndOut,
          out HTuple failRowBOut,
          out HTuple failColBOut,
          out HTuple failRowEOut,
          out HTuple failColEOut)
        {
            IntPtr proc = HalconAPI.PreCall(1737);
            HalconAPI.Store(proc, 0, rowBeginIn);
            HalconAPI.Store(proc, 1, colBeginIn);
            HalconAPI.Store(proc, 2, rowEndIn);
            HalconAPI.Store(proc, 3, colEndIn);
            HalconAPI.StoreS(proc, 4, feature);
            HalconAPI.StoreS(proc, 5, operation);
            HalconAPI.StoreS(proc, 6, min);
            HalconAPI.StoreS(proc, 7, max);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            HalconAPI.InitOCT(proc, 6);
            HalconAPI.InitOCT(proc, 7);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(rowBeginIn);
            HalconAPI.UnpinTuple(colBeginIn);
            HalconAPI.UnpinTuple(rowEndIn);
            HalconAPI.UnpinTuple(colEndIn);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out rowBeginOut);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out colBeginOut);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, err3, out rowEndOut);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, err4, out colEndOut);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, err5, out failRowBOut);
            int err7 = HTuple.LoadNew(proc, 5, HTupleType.INTEGER, err6, out failColBOut);
            int err8 = HTuple.LoadNew(proc, 6, HTupleType.INTEGER, err7, out failRowEOut);
            int procResult = HTuple.LoadNew(proc, 7, HTupleType.INTEGER, err8, out failColEOut);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Select lines according to various criteria.</summary>
        /// <param name="rowBeginIn">Row coordinates of the starting points of the input lines.</param>
        /// <param name="colBeginIn">Column coordinates of the starting points of the input lines.</param>
        /// <param name="rowEndIn">Row coordinates of the ending points of the input lines.</param>
        /// <param name="colEndIn">Column coordinates  of the ending points of the input lines.</param>
        /// <param name="feature">Features to be used for selection. Default: "length"</param>
        /// <param name="operation">Desired combination of the features. Default: "and"</param>
        /// <param name="min">Lower limits of the features or 'min'. Default: "min"</param>
        /// <param name="max">Upper limits of the features or 'max'. Default: "max"</param>
        /// <param name="rowBeginOut">Row coordinates of the starting points of the output lines.</param>
        /// <param name="colBeginOut">Column coordinates of the starting points of the output lines.</param>
        /// <param name="rowEndOut">Row coordinates of the ending points of the output lines.</param>
        /// <param name="colEndOut">Column coordinates of the ending points of the output lines.</param>
        public static void SelectLines(
          HTuple rowBeginIn,
          HTuple colBeginIn,
          HTuple rowEndIn,
          HTuple colEndIn,
          HTuple feature,
          string operation,
          HTuple min,
          HTuple max,
          out HTuple rowBeginOut,
          out HTuple colBeginOut,
          out HTuple rowEndOut,
          out HTuple colEndOut)
        {
            IntPtr proc = HalconAPI.PreCall(1738);
            HalconAPI.Store(proc, 0, rowBeginIn);
            HalconAPI.Store(proc, 1, colBeginIn);
            HalconAPI.Store(proc, 2, rowEndIn);
            HalconAPI.Store(proc, 3, colEndIn);
            HalconAPI.Store(proc, 4, feature);
            HalconAPI.StoreS(proc, 5, operation);
            HalconAPI.Store(proc, 6, min);
            HalconAPI.Store(proc, 7, max);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(rowBeginIn);
            HalconAPI.UnpinTuple(colBeginIn);
            HalconAPI.UnpinTuple(rowEndIn);
            HalconAPI.UnpinTuple(colEndIn);
            HalconAPI.UnpinTuple(feature);
            HalconAPI.UnpinTuple(min);
            HalconAPI.UnpinTuple(max);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out rowBeginOut);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out colBeginOut);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, err3, out rowEndOut);
            int procResult = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, err4, out colEndOut);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Select lines according to various criteria.</summary>
        /// <param name="rowBeginIn">Row coordinates of the starting points of the input lines.</param>
        /// <param name="colBeginIn">Column coordinates of the starting points of the input lines.</param>
        /// <param name="rowEndIn">Row coordinates of the ending points of the input lines.</param>
        /// <param name="colEndIn">Column coordinates  of the ending points of the input lines.</param>
        /// <param name="feature">Features to be used for selection. Default: "length"</param>
        /// <param name="operation">Desired combination of the features. Default: "and"</param>
        /// <param name="min">Lower limits of the features or 'min'. Default: "min"</param>
        /// <param name="max">Upper limits of the features or 'max'. Default: "max"</param>
        /// <param name="rowBeginOut">Row coordinates of the starting points of the output lines.</param>
        /// <param name="colBeginOut">Column coordinates of the starting points of the output lines.</param>
        /// <param name="rowEndOut">Row coordinates of the ending points of the output lines.</param>
        /// <param name="colEndOut">Column coordinates of the ending points of the output lines.</param>
        public static void SelectLines(
          HTuple rowBeginIn,
          HTuple colBeginIn,
          HTuple rowEndIn,
          HTuple colEndIn,
          string feature,
          string operation,
          string min,
          string max,
          out HTuple rowBeginOut,
          out HTuple colBeginOut,
          out HTuple rowEndOut,
          out HTuple colEndOut)
        {
            IntPtr proc = HalconAPI.PreCall(1738);
            HalconAPI.Store(proc, 0, rowBeginIn);
            HalconAPI.Store(proc, 1, colBeginIn);
            HalconAPI.Store(proc, 2, rowEndIn);
            HalconAPI.Store(proc, 3, colEndIn);
            HalconAPI.StoreS(proc, 4, feature);
            HalconAPI.StoreS(proc, 5, operation);
            HalconAPI.StoreS(proc, 6, min);
            HalconAPI.StoreS(proc, 7, max);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(rowBeginIn);
            HalconAPI.UnpinTuple(colBeginIn);
            HalconAPI.UnpinTuple(rowEndIn);
            HalconAPI.UnpinTuple(colEndIn);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out rowBeginOut);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out colBeginOut);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, err3, out rowEndOut);
            int procResult = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, err4, out colEndOut);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Calculate the center of gravity, length, and orientation of a line.</summary>
        /// <param name="rowBegin">Row coordinates of the starting points of the input lines.</param>
        /// <param name="colBegin">Column coordinates of the starting points of the input lines.</param>
        /// <param name="rowEnd">Row coordinates of the ending points of the input lines.</param>
        /// <param name="colEnd">Column coordinates  of the ending points of the input lines.</param>
        /// <param name="rowCenter">Row coordinates of the centers of gravity of the input lines.</param>
        /// <param name="colCenter">Column coordinates of the centers of gravity of the input lines.</param>
        /// <param name="length">Euclidean length of the input lines.</param>
        /// <param name="phi">Orientation of the input lines.</param>
        public static void LinePosition(
          HTuple rowBegin,
          HTuple colBegin,
          HTuple rowEnd,
          HTuple colEnd,
          out HTuple rowCenter,
          out HTuple colCenter,
          out HTuple length,
          out HTuple phi)
        {
            IntPtr proc = HalconAPI.PreCall(1739);
            HalconAPI.Store(proc, 0, rowBegin);
            HalconAPI.Store(proc, 1, colBegin);
            HalconAPI.Store(proc, 2, rowEnd);
            HalconAPI.Store(proc, 3, colEnd);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(rowBegin);
            HalconAPI.UnpinTuple(colBegin);
            HalconAPI.UnpinTuple(rowEnd);
            HalconAPI.UnpinTuple(colEnd);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out rowCenter);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out colCenter);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out length);
            int procResult = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out phi);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Calculate the center of gravity, length, and orientation of a line.</summary>
        /// <param name="rowBegin">Row coordinates of the starting points of the input lines.</param>
        /// <param name="colBegin">Column coordinates of the starting points of the input lines.</param>
        /// <param name="rowEnd">Row coordinates of the ending points of the input lines.</param>
        /// <param name="colEnd">Column coordinates  of the ending points of the input lines.</param>
        /// <param name="rowCenter">Row coordinates of the centers of gravity of the input lines.</param>
        /// <param name="colCenter">Column coordinates of the centers of gravity of the input lines.</param>
        /// <param name="length">Euclidean length of the input lines.</param>
        /// <param name="phi">Orientation of the input lines.</param>
        public static void LinePosition(
          int rowBegin,
          int colBegin,
          int rowEnd,
          int colEnd,
          out double rowCenter,
          out double colCenter,
          out double length,
          out double phi)
        {
            IntPtr proc = HalconAPI.PreCall(1739);
            HalconAPI.StoreI(proc, 0, rowBegin);
            HalconAPI.StoreI(proc, 1, colBegin);
            HalconAPI.StoreI(proc, 2, rowEnd);
            HalconAPI.StoreI(proc, 3, colEnd);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out rowCenter);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out colCenter);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out length);
            int procResult = HalconAPI.LoadD(proc, 3, err4, out phi);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Calculate the orientation of lines.</summary>
        /// <param name="rowBegin">Row coordinates of the starting points of the input lines.</param>
        /// <param name="colBegin">Column coordinates of the starting points of the input lines.</param>
        /// <param name="rowEnd">Row coordinates of the ending points of the input lines.</param>
        /// <param name="colEnd">Column coordinates  of the ending points of the input lines.</param>
        /// <returns>Orientation of the input lines.</returns>
        public static HTuple LineOrientation(
          HTuple rowBegin,
          HTuple colBegin,
          HTuple rowEnd,
          HTuple colEnd)
        {
            IntPtr proc = HalconAPI.PreCall(1740);
            HalconAPI.Store(proc, 0, rowBegin);
            HalconAPI.Store(proc, 1, colBegin);
            HalconAPI.Store(proc, 2, rowEnd);
            HalconAPI.Store(proc, 3, colEnd);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(rowBegin);
            HalconAPI.UnpinTuple(colBegin);
            HalconAPI.UnpinTuple(rowEnd);
            HalconAPI.UnpinTuple(colEnd);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Calculate the orientation of lines.</summary>
        /// <param name="rowBegin">Row coordinates of the starting points of the input lines.</param>
        /// <param name="colBegin">Column coordinates of the starting points of the input lines.</param>
        /// <param name="rowEnd">Row coordinates of the ending points of the input lines.</param>
        /// <param name="colEnd">Column coordinates  of the ending points of the input lines.</param>
        /// <returns>Orientation of the input lines.</returns>
        public static double LineOrientation(
          double rowBegin,
          double colBegin,
          double rowEnd,
          double colEnd)
        {
            IntPtr proc = HalconAPI.PreCall(1740);
            HalconAPI.StoreD(proc, 0, rowBegin);
            HalconAPI.StoreD(proc, 1, colBegin);
            HalconAPI.StoreD(proc, 2, rowEnd);
            HalconAPI.StoreD(proc, 3, colEnd);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            return doubleValue;
        }

        /// <summary>Approximate a contour by arcs and lines.</summary>
        /// <param name="row">Row of the contour. Default: 32</param>
        /// <param name="column">Column of the contour. Default: 32</param>
        /// <param name="arcCenterRow">Row of the center of an arc.</param>
        /// <param name="arcCenterCol">Column of the center of an arc.</param>
        /// <param name="arcAngle">Angle of an arc.</param>
        /// <param name="arcBeginRow">Row of the starting point of an arc.</param>
        /// <param name="arcBeginCol">Column of the starting point of an arc.</param>
        /// <param name="lineBeginRow">Row of the starting point of a line segment.</param>
        /// <param name="lineBeginCol">Column of the starting point of a line segment.</param>
        /// <param name="lineEndRow">Row of the ending point of a line segment.</param>
        /// <param name="lineEndCol">Column of the ending point of a line segment.</param>
        /// <param name="order">Sequence of line (value 0) and arc segments (value 1).</param>
        public static void ApproxChainSimple(
          HTuple row,
          HTuple column,
          out HTuple arcCenterRow,
          out HTuple arcCenterCol,
          out HTuple arcAngle,
          out HTuple arcBeginRow,
          out HTuple arcBeginCol,
          out HTuple lineBeginRow,
          out HTuple lineBeginCol,
          out HTuple lineEndRow,
          out HTuple lineEndCol,
          out HTuple order)
        {
            IntPtr proc = HalconAPI.PreCall(1741);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, column);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            HalconAPI.InitOCT(proc, 6);
            HalconAPI.InitOCT(proc, 7);
            HalconAPI.InitOCT(proc, 8);
            HalconAPI.InitOCT(proc, 9);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out arcCenterRow);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out arcCenterCol);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out arcAngle);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, err4, out arcBeginRow);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, err5, out arcBeginCol);
            int err7 = HTuple.LoadNew(proc, 5, HTupleType.INTEGER, err6, out lineBeginRow);
            int err8 = HTuple.LoadNew(proc, 6, HTupleType.INTEGER, err7, out lineBeginCol);
            int err9 = HTuple.LoadNew(proc, 7, HTupleType.INTEGER, err8, out lineEndRow);
            int err10 = HTuple.LoadNew(proc, 8, HTupleType.INTEGER, err9, out lineEndCol);
            int procResult = HTuple.LoadNew(proc, 9, HTupleType.INTEGER, err10, out order);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Approximate a contour by arcs and lines.</summary>
        /// <param name="row">Row of the contour. Default: 32</param>
        /// <param name="column">Column of the contour. Default: 32</param>
        /// <param name="minWidthCoord">Minimum width of Gauss operator for coordinate smoothing ($ greater than $ 0.4). Default: 0.5</param>
        /// <param name="maxWidthCoord">Maximum width of Gauss operator for coordinate smoothing ($ greater than $ 0.4). Default: 2.4</param>
        /// <param name="threshStart">Minimum threshold value of the curvature for accepting a corner (relative to the largest curvature present). Default: 0.3</param>
        /// <param name="threshEnd">Maximum threshold value of the curvature for accepting a corner (relative to the largest curvature present). Default: 0.9</param>
        /// <param name="threshStep">Step width for threshold increase. Default: 0.2</param>
        /// <param name="minWidthSmooth">Minimum width of Gauss operator for smoothing the curvature function ($ greater than $ 0.4). Default: 0.5</param>
        /// <param name="maxWidthSmooth">Maximum width of Gauss operator for smoothing the curvature function. Default: 2.4</param>
        /// <param name="minWidthCurve">Minimum width of curve area for curvature determination ($ greater than $ 0.4). Default: 2</param>
        /// <param name="maxWidthCurve">Maximum width of curve area for curvature determination. Default: 12</param>
        /// <param name="weight1">Weighting factor for approximation precision. Default: 1.0</param>
        /// <param name="weight2">Weighting factor for large segments. Default: 1.0</param>
        /// <param name="weight3">Weighting factor for small segments. Default: 1.0</param>
        /// <param name="arcCenterRow">Row of the center of an arc.</param>
        /// <param name="arcCenterCol">Column of the center of an arc.</param>
        /// <param name="arcAngle">Angle of an arc.</param>
        /// <param name="arcBeginRow">Row of the starting point of an arc.</param>
        /// <param name="arcBeginCol">Column of the starting point of an arc.</param>
        /// <param name="lineBeginRow">Row of the starting point of a line segment.</param>
        /// <param name="lineBeginCol">Column of the starting point of a line segment.</param>
        /// <param name="lineEndRow">Row of the ending point of a line segment.</param>
        /// <param name="lineEndCol">Column of the ending point of a line segment.</param>
        /// <param name="order">Sequence of line (value 0) and arc segments (value 1).</param>
        public static void ApproxChain(
          HTuple row,
          HTuple column,
          double minWidthCoord,
          double maxWidthCoord,
          double threshStart,
          double threshEnd,
          double threshStep,
          double minWidthSmooth,
          double maxWidthSmooth,
          int minWidthCurve,
          int maxWidthCurve,
          double weight1,
          double weight2,
          double weight3,
          out HTuple arcCenterRow,
          out HTuple arcCenterCol,
          out HTuple arcAngle,
          out HTuple arcBeginRow,
          out HTuple arcBeginCol,
          out HTuple lineBeginRow,
          out HTuple lineBeginCol,
          out HTuple lineEndRow,
          out HTuple lineEndCol,
          out HTuple order)
        {
            IntPtr proc = HalconAPI.PreCall(1742);
            HalconAPI.Store(proc, 0, row);
            HalconAPI.Store(proc, 1, column);
            HalconAPI.StoreD(proc, 2, minWidthCoord);
            HalconAPI.StoreD(proc, 3, maxWidthCoord);
            HalconAPI.StoreD(proc, 4, threshStart);
            HalconAPI.StoreD(proc, 5, threshEnd);
            HalconAPI.StoreD(proc, 6, threshStep);
            HalconAPI.StoreD(proc, 7, minWidthSmooth);
            HalconAPI.StoreD(proc, 8, maxWidthSmooth);
            HalconAPI.StoreI(proc, 9, minWidthCurve);
            HalconAPI.StoreI(proc, 10, maxWidthCurve);
            HalconAPI.StoreD(proc, 11, weight1);
            HalconAPI.StoreD(proc, 12, weight2);
            HalconAPI.StoreD(proc, 13, weight3);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            HalconAPI.InitOCT(proc, 6);
            HalconAPI.InitOCT(proc, 7);
            HalconAPI.InitOCT(proc, 8);
            HalconAPI.InitOCT(proc, 9);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out arcCenterRow);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out arcCenterCol);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out arcAngle);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.INTEGER, err4, out arcBeginRow);
            int err6 = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, err5, out arcBeginCol);
            int err7 = HTuple.LoadNew(proc, 5, HTupleType.INTEGER, err6, out lineBeginRow);
            int err8 = HTuple.LoadNew(proc, 6, HTupleType.INTEGER, err7, out lineBeginCol);
            int err9 = HTuple.LoadNew(proc, 7, HTupleType.INTEGER, err8, out lineEndRow);
            int err10 = HTuple.LoadNew(proc, 8, HTupleType.INTEGER, err9, out lineEndCol);
            int procResult = HTuple.LoadNew(proc, 9, HTupleType.INTEGER, err10, out order);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Destroy all classifiers.</summary>
        public static void CloseAllClassBox()
        {
            IntPtr proc = HalconAPI.PreCall(1900);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Generate a calibration plate description file and a corresponding PostScript file for a calibration plate with rectangularly arranged marks.</summary>
        /// <param name="XNum">Number of marks in x direction. Default: 7</param>
        /// <param name="YNum">Number of marks in y direction. Default: 7</param>
        /// <param name="markDist">Distance of the marks in meters. Default: 0.0125</param>
        /// <param name="diameterRatio">Ratio of the mark diameter to the mark distance. Default: 0.5</param>
        /// <param name="calPlateDescr">File name of the calibration plate description. Default: "caltab.descr"</param>
        /// <param name="calPlatePSFile">File name of the PostScript file. Default: "caltab.ps"</param>
        public static void GenCaltab(
          int XNum,
          int YNum,
          double markDist,
          double diameterRatio,
          string calPlateDescr,
          string calPlatePSFile)
        {
            IntPtr proc = HalconAPI.PreCall(1926);
            HalconAPI.StoreI(proc, 0, XNum);
            HalconAPI.StoreI(proc, 1, YNum);
            HalconAPI.StoreD(proc, 2, markDist);
            HalconAPI.StoreD(proc, 3, diameterRatio);
            HalconAPI.StoreS(proc, 4, calPlateDescr);
            HalconAPI.StoreS(proc, 5, calPlatePSFile);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Generate a calibration plate description file and a corresponding PostScript file for a calibration plate with hexagonally arranged marks.</summary>
        /// <param name="numRows">Number of rows. Default: 27</param>
        /// <param name="marksPerRow">Number of marks per row. Default: 31</param>
        /// <param name="diameter">Diameter of the marks. Default: 0.00258065</param>
        /// <param name="finderRow">Row indices of the finder patterns. Default: [13,6,6,20,20]</param>
        /// <param name="finderColumn">Column indices of the finder patterns. Default: [15,6,24,6,24]</param>
        /// <param name="polarity">Polarity of the marks Default: "light_on_dark"</param>
        /// <param name="calPlateDescr">File name of the calibration plate description. Default: "calplate.cpd"</param>
        /// <param name="calPlatePSFile">File name of the PostScript file. Default: "calplate.ps"</param>
        public static void CreateCaltab(
          int numRows,
          int marksPerRow,
          double diameter,
          HTuple finderRow,
          HTuple finderColumn,
          string polarity,
          string calPlateDescr,
          string calPlatePSFile)
        {
            IntPtr proc = HalconAPI.PreCall(1927);
            HalconAPI.StoreI(proc, 0, numRows);
            HalconAPI.StoreI(proc, 1, marksPerRow);
            HalconAPI.StoreD(proc, 2, diameter);
            HalconAPI.Store(proc, 3, finderRow);
            HalconAPI.Store(proc, 4, finderColumn);
            HalconAPI.StoreS(proc, 5, polarity);
            HalconAPI.StoreS(proc, 6, calPlateDescr);
            HalconAPI.StoreS(proc, 7, calPlatePSFile);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(finderRow);
            HalconAPI.UnpinTuple(finderColumn);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Generate a calibration plate description file and a corresponding PostScript file for a calibration plate with hexagonally arranged marks.</summary>
        /// <param name="numRows">Number of rows. Default: 27</param>
        /// <param name="marksPerRow">Number of marks per row. Default: 31</param>
        /// <param name="diameter">Diameter of the marks. Default: 0.00258065</param>
        /// <param name="finderRow">Row indices of the finder patterns. Default: [13,6,6,20,20]</param>
        /// <param name="finderColumn">Column indices of the finder patterns. Default: [15,6,24,6,24]</param>
        /// <param name="polarity">Polarity of the marks Default: "light_on_dark"</param>
        /// <param name="calPlateDescr">File name of the calibration plate description. Default: "calplate.cpd"</param>
        /// <param name="calPlatePSFile">File name of the PostScript file. Default: "calplate.ps"</param>
        public static void CreateCaltab(
          int numRows,
          int marksPerRow,
          double diameter,
          int finderRow,
          int finderColumn,
          string polarity,
          string calPlateDescr,
          string calPlatePSFile)
        {
            IntPtr proc = HalconAPI.PreCall(1927);
            HalconAPI.StoreI(proc, 0, numRows);
            HalconAPI.StoreI(proc, 1, marksPerRow);
            HalconAPI.StoreD(proc, 2, diameter);
            HalconAPI.StoreI(proc, 3, finderRow);
            HalconAPI.StoreI(proc, 4, finderColumn);
            HalconAPI.StoreS(proc, 5, polarity);
            HalconAPI.StoreS(proc, 6, calPlateDescr);
            HalconAPI.StoreS(proc, 7, calPlatePSFile);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Read the mark center points from the calibration plate description file.</summary>
        /// <param name="calPlateDescr">File name of the calibration plate description. Default: "calplate.cpd"</param>
        /// <param name="x">X coordinates of the mark center points in the coordinate system of the calibration plate.</param>
        /// <param name="y">Y coordinates of the mark center points in the coordinate system of the calibration plate.</param>
        /// <param name="z">Z coordinates of the mark center points in the coordinate system of the calibration plate.</param>
        public static void CaltabPoints(
          string calPlateDescr,
          out HTuple x,
          out HTuple y,
          out HTuple z)
        {
            IntPtr proc = HalconAPI.PreCall(1928);
            HalconAPI.StoreS(proc, 0, calPlateDescr);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out x);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out y);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out z);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Delete all background estimation data sets.</summary>
        public static void CloseAllBgEsti()
        {
            IntPtr proc = HalconAPI.PreCall(2009);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Close all image acquisition devices.</summary>
        public static void CloseAllFramegrabbers()
        {
            IntPtr proc = HalconAPI.PreCall(2035);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }
    }
}
