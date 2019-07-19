// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HStereoModel
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a stereo model.</summary>
    public class HStereoModel : HTool
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HStereoModel()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HStereoModel(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HStereoModel obj)
        {
            obj = new HStereoModel(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HStereoModel[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HStereoModel[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HStereoModel(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Create a HALCON stereo model.
        ///   Modified instance represents: Handle of the stereo model.
        /// </summary>
        /// <param name="cameraSetupModelID">Handle to the camera setup model.</param>
        /// <param name="method">Reconstruction method. Default: "surface_pairwise"</param>
        /// <param name="genParamName">Name of the model parameter to be set. Default: []</param>
        /// <param name="genParamValue">Value of the model parameter to be set. Default: []</param>
        public HStereoModel(
          HCameraSetupModel cameraSetupModelID,
          string method,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(527);
            HalconAPI.Store(proc, 0, (HTool)cameraSetupModelID);
            HalconAPI.StoreS(proc, 1, method);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)cameraSetupModelID);
        }

        /// <summary>
        ///   Create a HALCON stereo model.
        ///   Modified instance represents: Handle of the stereo model.
        /// </summary>
        /// <param name="cameraSetupModelID">Handle to the camera setup model.</param>
        /// <param name="method">Reconstruction method. Default: "surface_pairwise"</param>
        /// <param name="genParamName">Name of the model parameter to be set. Default: []</param>
        /// <param name="genParamValue">Value of the model parameter to be set. Default: []</param>
        public HStereoModel(
          HCameraSetupModel cameraSetupModelID,
          string method,
          string genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(527);
            HalconAPI.Store(proc, 0, cameraSetupModelID);
            HalconAPI.StoreS(proc, 1, method);
            HalconAPI.StoreS(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)cameraSetupModelID);
        }

        /// <summary>
        ///   Reconstruct 3D points from calibrated multi-view stereo images.
        ///   Instance represents: Handle of the stereo model.
        /// </summary>
        /// <param name="row">Row coordinates of the detected points.</param>
        /// <param name="column">Column coordinates of the detected points.</param>
        /// <param name="covIP">Covariance matrices of the detected points. Default: []</param>
        /// <param name="cameraIdx">Indices of the observing cameras.</param>
        /// <param name="pointIdx">Indices of the observed world points.</param>
        /// <param name="x">X coordinates of the reconstructed 3D points.</param>
        /// <param name="y">Y coordinates of the reconstructed 3D points.</param>
        /// <param name="z">Z coordinates of the reconstructed 3D points.</param>
        /// <param name="covWP">Covariance matrices of the reconstructed 3D points.</param>
        /// <param name="pointIdxOut">Indices of the reconstructed 3D points.</param>
        public void ReconstructPointsStereo(
          HTuple row,
          HTuple column,
          HTuple covIP,
          int cameraIdx,
          int pointIdx,
          out HTuple x,
          out HTuple y,
          out HTuple z,
          out HTuple covWP,
          out HTuple pointIdxOut)
        {
            IntPtr proc = HalconAPI.PreCall(520);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, row);
            HalconAPI.Store(proc, 2, column);
            HalconAPI.Store(proc, 3, covIP);
            HalconAPI.StoreI(proc, 4, cameraIdx);
            HalconAPI.StoreI(proc, 5, pointIdx);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.UnpinTuple(covIP);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err1, out x);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.DOUBLE, err2, out y);
            int err4 = HTuple.LoadNew(proc, 2, HTupleType.DOUBLE, err3, out z);
            int err5 = HTuple.LoadNew(proc, 3, HTupleType.DOUBLE, err4, out covWP);
            int procResult = HTuple.LoadNew(proc, 4, HTupleType.INTEGER, err5, out pointIdxOut);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Reconstruct 3D points from calibrated multi-view stereo images.
        ///   Instance represents: Handle of the stereo model.
        /// </summary>
        /// <param name="row">Row coordinates of the detected points.</param>
        /// <param name="column">Column coordinates of the detected points.</param>
        /// <param name="covIP">Covariance matrices of the detected points. Default: []</param>
        /// <param name="cameraIdx">Indices of the observing cameras.</param>
        /// <param name="pointIdx">Indices of the observed world points.</param>
        /// <param name="x">X coordinates of the reconstructed 3D points.</param>
        /// <param name="y">Y coordinates of the reconstructed 3D points.</param>
        /// <param name="z">Z coordinates of the reconstructed 3D points.</param>
        /// <param name="covWP">Covariance matrices of the reconstructed 3D points.</param>
        /// <param name="pointIdxOut">Indices of the reconstructed 3D points.</param>
        public void ReconstructPointsStereo(
          double row,
          double column,
          HTuple covIP,
          int cameraIdx,
          int pointIdx,
          out double x,
          out double y,
          out double z,
          out double covWP,
          out int pointIdxOut)
        {
            IntPtr proc = HalconAPI.PreCall(520);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, row);
            HalconAPI.StoreD(proc, 2, column);
            HalconAPI.Store(proc, 3, covIP);
            HalconAPI.StoreI(proc, 4, cameraIdx);
            HalconAPI.StoreI(proc, 5, pointIdx);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(covIP);
            int err2 = HalconAPI.LoadD(proc, 0, err1, out x);
            int err3 = HalconAPI.LoadD(proc, 1, err2, out y);
            int err4 = HalconAPI.LoadD(proc, 2, err3, out z);
            int err5 = HalconAPI.LoadD(proc, 3, err4, out covWP);
            int procResult = HalconAPI.LoadI(proc, 4, err5, out pointIdxOut);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Reconstruct surface from calibrated multi-view stereo images.
        ///   Instance represents: Handle of the stereo model.
        /// </summary>
        /// <param name="images">An image array acquired by the camera setup associated with the stereo model.</param>
        /// <returns>Handle to the resulting surface.</returns>
        public HObjectModel3D ReconstructSurfaceStereo(HImage images)
        {
            IntPtr proc = HalconAPI.PreCall(521);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HObjectBase)images);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HObjectModel3D hobjectModel3D;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)images);
            return hobjectModel3D;
        }

        /// <summary>
        ///   Get intermediate iconic results of a stereo reconstruction.
        ///   Instance represents: Handle of the stereo model.
        /// </summary>
        /// <param name="pairIndex">Camera indices of the pair ([From, To]).</param>
        /// <param name="objectName">Name of the iconic result to be returned.</param>
        /// <returns>Iconic result.</returns>
        public HObject GetStereoModelObject(HTuple pairIndex, string objectName)
        {
            IntPtr proc = HalconAPI.PreCall(522);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, pairIndex);
            HalconAPI.StoreS(proc, 2, objectName);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(pairIndex);
            HObject hobject;
            int procResult = HObject.LoadNew(proc, 1, err, out hobject);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobject;
        }

        /// <summary>
        ///   Get intermediate iconic results of a stereo reconstruction.
        ///   Instance represents: Handle of the stereo model.
        /// </summary>
        /// <param name="pairIndex">Camera indices of the pair ([From, To]).</param>
        /// <param name="objectName">Name of the iconic result to be returned.</param>
        /// <returns>Iconic result.</returns>
        public HObject GetStereoModelObject(int pairIndex, string objectName)
        {
            IntPtr proc = HalconAPI.PreCall(522);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, pairIndex);
            HalconAPI.StoreS(proc, 2, objectName);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HObject hobject;
            int procResult = HObject.LoadNew(proc, 1, err, out hobject);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobject;
        }

        /// <summary>
        ///   Return the list of image pairs set in a stereo model.
        ///   Instance represents: Handle of the stereo model.
        /// </summary>
        /// <param name="to">Camera indices for the to cameras in the image pairs.</param>
        /// <returns>Camera indices for the from cameras in the image pairs.</returns>
        public HTuple GetStereoModelImagePairs(out HTuple to)
        {
            IntPtr proc = HalconAPI.PreCall(523);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out to);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Specify image pairs to be used for surface stereo reconstruction.
        ///   Instance represents: Handle of the stereo model.
        /// </summary>
        /// <param name="from">Camera indices for the from cameras in the image pairs.</param>
        /// <param name="to">Camera indices for the to cameras in the  image pairs.</param>
        public void SetStereoModelImagePairs(HTuple from, HTuple to)
        {
            IntPtr proc = HalconAPI.PreCall(524);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, from);
            HalconAPI.Store(proc, 2, to);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(from);
            HalconAPI.UnpinTuple(to);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Get stereo model parameters.
        ///   Instance represents: Handle of the stereo model.
        /// </summary>
        /// <param name="genParamName">Names of the parameters to be set.</param>
        /// <returns>Values of the parameters to be set.</returns>
        public HTuple GetStereoModelParam(HTuple genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(525);
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
        ///   Get stereo model parameters.
        ///   Instance represents: Handle of the stereo model.
        /// </summary>
        /// <param name="genParamName">Names of the parameters to be set.</param>
        /// <returns>Values of the parameters to be set.</returns>
        public HTuple GetStereoModelParam(string genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(525);
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
        ///   Set stereo model parameters.
        ///   Instance represents: Handle of the stereo model.
        /// </summary>
        /// <param name="genParamName">Names of the parameters to be set.</param>
        /// <param name="genParamValue">Values of the parameters to be set.</param>
        public void SetStereoModelParam(HTuple genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(526);
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
        ///   Set stereo model parameters.
        ///   Instance represents: Handle of the stereo model.
        /// </summary>
        /// <param name="genParamName">Names of the parameters to be set.</param>
        /// <param name="genParamValue">Values of the parameters to be set.</param>
        public void SetStereoModelParam(string genParamName, HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(526);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a HALCON stereo model.
        ///   Modified instance represents: Handle of the stereo model.
        /// </summary>
        /// <param name="cameraSetupModelID">Handle to the camera setup model.</param>
        /// <param name="method">Reconstruction method. Default: "surface_pairwise"</param>
        /// <param name="genParamName">Name of the model parameter to be set. Default: []</param>
        /// <param name="genParamValue">Value of the model parameter to be set. Default: []</param>
        public void CreateStereoModel(
          HCameraSetupModel cameraSetupModelID,
          string method,
          HTuple genParamName,
          HTuple genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(527);
            HalconAPI.Store(proc, 0, (HTool)cameraSetupModelID);
            HalconAPI.StoreS(proc, 1, method);
            HalconAPI.Store(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)cameraSetupModelID);
        }

        /// <summary>
        ///   Create a HALCON stereo model.
        ///   Modified instance represents: Handle of the stereo model.
        /// </summary>
        /// <param name="cameraSetupModelID">Handle to the camera setup model.</param>
        /// <param name="method">Reconstruction method. Default: "surface_pairwise"</param>
        /// <param name="genParamName">Name of the model parameter to be set. Default: []</param>
        /// <param name="genParamValue">Value of the model parameter to be set. Default: []</param>
        public void CreateStereoModel(
          HCameraSetupModel cameraSetupModelID,
          string method,
          string genParamName,
          HTuple genParamValue)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(527);
            HalconAPI.Store(proc, 0, (HTool)cameraSetupModelID);
            HalconAPI.StoreS(proc, 1, method);
            HalconAPI.StoreS(proc, 2, genParamName);
            HalconAPI.Store(proc, 3, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamValue);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)cameraSetupModelID);
        }

        /// <summary>
        ///   Get intermediate 3D object model of a stereo reconstruction
        ///   Instance represents: Handle des Stereomodells.
        /// </summary>
        /// <param name="genParamName">Namen der Modellparameter.</param>
        /// <returns>Werte der Modellparameter.</returns>
        public HObjectModel3D GetStereoModelObjectModel3d(HTuple genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(2074);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, genParamName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HObjectModel3D hobjectModel3D;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobjectModel3D;
        }

        /// <summary>
        ///   Get intermediate 3D object model of a stereo reconstruction
        ///   Instance represents: Handle des Stereomodells.
        /// </summary>
        /// <param name="genParamName">Namen der Modellparameter.</param>
        /// <returns>Werte der Modellparameter.</returns>
        public HObjectModel3D GetStereoModelObjectModel3d(string genParamName)
        {
            IntPtr proc = HalconAPI.PreCall(2074);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HObjectModel3D hobjectModel3D;
            int procResult = HObjectModel3D.LoadNew(proc, 0, err, out hobjectModel3D);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobjectModel3D;
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(519);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
