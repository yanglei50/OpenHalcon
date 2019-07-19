// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HFramegrabber
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;

namespace HalconDotNet
{
    /// <summary>Represents an instance of an image acquisition device.</summary>
    public class HFramegrabber : HTool
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HFramegrabber()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HFramegrabber(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HFramegrabber obj)
        {
            obj = new HFramegrabber(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HFramegrabber[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HFramegrabber[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HFramegrabber(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Open and configure an image acquisition device.
        ///   Modified instance represents: Handle of the opened image acquisition device.
        /// </summary>
        /// <param name="name">HALCON image acquisition interface name, i.e., name of the corresponding DLL (Windows) or shared library (Linux/macOS). Default: "File"</param>
        /// <param name="horizontalResolution">Desired horizontal resolution of image acquisition interface (absolute value or 1 for full resolution, 2 for half resolution, or 4 for quarter resolution). Default: 1</param>
        /// <param name="verticalResolution">Desired vertical resolution of image acquisition interface (absolute value or 1 for full resolution, 2 for half resolution, or 4 for quarter resolution). Default: 1</param>
        /// <param name="imageWidth">Width of desired image part (absolute value or 0 for HorizontalResolution - 2*StartColumn). Default: 0</param>
        /// <param name="imageHeight">Height of desired image part (absolute value or 0 for VerticalResolution - 2*StartRow). Default: 0</param>
        /// <param name="startRow">Line number of upper left corner of desired image part (or border height if ImageHeight = 0). Default: 0</param>
        /// <param name="startColumn">Column number of upper left corner of desired image part (or border width if ImageWidth = 0). Default: 0</param>
        /// <param name="field">Desired half image or full image. Default: "default"</param>
        /// <param name="bitsPerChannel">Number of transferred bits per pixel and image channel (-1: device-specific default value). Default: -1</param>
        /// <param name="colorSpace">Output color format of the grabbed images, typically 'gray' or 'raw' for single-channel or 'rgb' or 'yuv' for three-channel images ('default': device-specific default value). Default: "default"</param>
        /// <param name="generic">Generic parameter with device-specific meaning. Default: -1</param>
        /// <param name="externalTrigger">External triggering. Default: "default"</param>
        /// <param name="cameraType">Type of used camera ('default': device-specific default value). Default: "default"</param>
        /// <param name="device">Device the image acquisition device is connected to ('default': device-specific default value). Default: "default"</param>
        /// <param name="port">Port the image acquisition device is connected to (-1: device-specific default value). Default: -1</param>
        /// <param name="lineIn">Camera input line of multiplexer (-1: device-specific default value). Default: -1</param>
        public HFramegrabber(
          string name,
          int horizontalResolution,
          int verticalResolution,
          int imageWidth,
          int imageHeight,
          int startRow,
          int startColumn,
          string field,
          HTuple bitsPerChannel,
          HTuple colorSpace,
          HTuple generic,
          string externalTrigger,
          HTuple cameraType,
          HTuple device,
          HTuple port,
          HTuple lineIn)
        {
            IntPtr proc = HalconAPI.PreCall(2037);
            HalconAPI.StoreS(proc, 0, name);
            HalconAPI.StoreI(proc, 1, horizontalResolution);
            HalconAPI.StoreI(proc, 2, verticalResolution);
            HalconAPI.StoreI(proc, 3, imageWidth);
            HalconAPI.StoreI(proc, 4, imageHeight);
            HalconAPI.StoreI(proc, 5, startRow);
            HalconAPI.StoreI(proc, 6, startColumn);
            HalconAPI.StoreS(proc, 7, field);
            HalconAPI.Store(proc, 8, bitsPerChannel);
            HalconAPI.Store(proc, 9, colorSpace);
            HalconAPI.Store(proc, 10, generic);
            HalconAPI.StoreS(proc, 11, externalTrigger);
            HalconAPI.Store(proc, 12, cameraType);
            HalconAPI.Store(proc, 13, device);
            HalconAPI.Store(proc, 14, port);
            HalconAPI.Store(proc, 15, lineIn);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(bitsPerChannel);
            HalconAPI.UnpinTuple(colorSpace);
            HalconAPI.UnpinTuple(generic);
            HalconAPI.UnpinTuple(cameraType);
            HalconAPI.UnpinTuple(device);
            HalconAPI.UnpinTuple(port);
            HalconAPI.UnpinTuple(lineIn);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Open and configure an image acquisition device.
        ///   Modified instance represents: Handle of the opened image acquisition device.
        /// </summary>
        /// <param name="name">HALCON image acquisition interface name, i.e., name of the corresponding DLL (Windows) or shared library (Linux/macOS). Default: "File"</param>
        /// <param name="horizontalResolution">Desired horizontal resolution of image acquisition interface (absolute value or 1 for full resolution, 2 for half resolution, or 4 for quarter resolution). Default: 1</param>
        /// <param name="verticalResolution">Desired vertical resolution of image acquisition interface (absolute value or 1 for full resolution, 2 for half resolution, or 4 for quarter resolution). Default: 1</param>
        /// <param name="imageWidth">Width of desired image part (absolute value or 0 for HorizontalResolution - 2*StartColumn). Default: 0</param>
        /// <param name="imageHeight">Height of desired image part (absolute value or 0 for VerticalResolution - 2*StartRow). Default: 0</param>
        /// <param name="startRow">Line number of upper left corner of desired image part (or border height if ImageHeight = 0). Default: 0</param>
        /// <param name="startColumn">Column number of upper left corner of desired image part (or border width if ImageWidth = 0). Default: 0</param>
        /// <param name="field">Desired half image or full image. Default: "default"</param>
        /// <param name="bitsPerChannel">Number of transferred bits per pixel and image channel (-1: device-specific default value). Default: -1</param>
        /// <param name="colorSpace">Output color format of the grabbed images, typically 'gray' or 'raw' for single-channel or 'rgb' or 'yuv' for three-channel images ('default': device-specific default value). Default: "default"</param>
        /// <param name="generic">Generic parameter with device-specific meaning. Default: -1</param>
        /// <param name="externalTrigger">External triggering. Default: "default"</param>
        /// <param name="cameraType">Type of used camera ('default': device-specific default value). Default: "default"</param>
        /// <param name="device">Device the image acquisition device is connected to ('default': device-specific default value). Default: "default"</param>
        /// <param name="port">Port the image acquisition device is connected to (-1: device-specific default value). Default: -1</param>
        /// <param name="lineIn">Camera input line of multiplexer (-1: device-specific default value). Default: -1</param>
        public HFramegrabber(
          string name,
          int horizontalResolution,
          int verticalResolution,
          int imageWidth,
          int imageHeight,
          int startRow,
          int startColumn,
          string field,
          int bitsPerChannel,
          string colorSpace,
          double generic,
          string externalTrigger,
          string cameraType,
          string device,
          int port,
          int lineIn)
        {
            IntPtr proc = HalconAPI.PreCall(2037);
            HalconAPI.StoreS(proc, 0, name);
            HalconAPI.StoreI(proc, 1, horizontalResolution);
            HalconAPI.StoreI(proc, 2, verticalResolution);
            HalconAPI.StoreI(proc, 3, imageWidth);
            HalconAPI.StoreI(proc, 4, imageHeight);
            HalconAPI.StoreI(proc, 5, startRow);
            HalconAPI.StoreI(proc, 6, startColumn);
            HalconAPI.StoreS(proc, 7, field);
            HalconAPI.StoreI(proc, 8, bitsPerChannel);
            HalconAPI.StoreS(proc, 9, colorSpace);
            HalconAPI.StoreD(proc, 10, generic);
            HalconAPI.StoreS(proc, 11, externalTrigger);
            HalconAPI.StoreS(proc, 12, cameraType);
            HalconAPI.StoreS(proc, 13, device);
            HalconAPI.StoreI(proc, 14, port);
            HalconAPI.StoreI(proc, 15, lineIn);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Query specific parameters of an image acquisition device.
        ///   Instance represents: Handle of the acquisition device to be used.
        /// </summary>
        /// <param name="param">Parameter of interest. Default: "revision"</param>
        /// <returns>Parameter value.</returns>
        public HTuple GetFramegrabberParam(HTuple param)
        {
            IntPtr proc = HalconAPI.PreCall(2025);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, param);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(param);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Query specific parameters of an image acquisition device.
        ///   Instance represents: Handle of the acquisition device to be used.
        /// </summary>
        /// <param name="param">Parameter of interest. Default: "revision"</param>
        /// <returns>Parameter value.</returns>
        public HTuple GetFramegrabberParam(string param)
        {
            IntPtr proc = HalconAPI.PreCall(2025);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, param);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Set specific parameters of an image acquistion device.
        ///   Instance represents: Handle of the acquisition device to be used.
        /// </summary>
        /// <param name="param">Parameter name.</param>
        /// <param name="value">Parameter value to be set.</param>
        public void SetFramegrabberParam(HTuple param, HTuple value)
        {
            IntPtr proc = HalconAPI.PreCall(2026);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, param);
            HalconAPI.Store(proc, 2, value);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(param);
            HalconAPI.UnpinTuple(value);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set specific parameters of an image acquistion device.
        ///   Instance represents: Handle of the acquisition device to be used.
        /// </summary>
        /// <param name="param">Parameter name.</param>
        /// <param name="value">Parameter value to be set.</param>
        public void SetFramegrabberParam(string param, string value)
        {
            IntPtr proc = HalconAPI.PreCall(2026);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, param);
            HalconAPI.StoreS(proc, 2, value);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Query callback function of an image acquisition device.
        ///   Instance represents: Handle of the acquisition device to be used.
        /// </summary>
        /// <param name="callbackType">Callback type. Default: "transfer_end"</param>
        /// <param name="userContext">Pointer to user-specific context data.</param>
        /// <returns>Pointer to the callback function.</returns>
        public IntPtr GetFramegrabberCallback(string callbackType, out IntPtr userContext)
        {
            IntPtr proc = HalconAPI.PreCall(2027);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, callbackType);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            IntPtr intPtrValue;
            int err2 = HalconAPI.LoadIP(proc, 0, err1, out intPtrValue);
            int procResult = HalconAPI.LoadIP(proc, 1, err2, out userContext);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intPtrValue;
        }

        /// <summary>
        ///   Register a callback function for an image acquisition device.
        ///   Instance represents: Handle of the acquisition device to be used.
        /// </summary>
        /// <param name="callbackType">Callback type. Default: "transfer_end"</param>
        /// <param name="callbackFunction">Pointer to the callback function to be set.</param>
        /// <param name="userContext">Pointer to user-specific context data.</param>
        public void SetFramegrabberCallback(
          string callbackType,
          IntPtr callbackFunction,
          IntPtr userContext)
        {
            IntPtr proc = HalconAPI.PreCall(2028);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, callbackType);
            HalconAPI.StoreIP(proc, 2, callbackFunction);
            HalconAPI.StoreIP(proc, 3, userContext);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Asynchronous grab of images and preprocessed image data from the specified image acquisition device.
        ///   Instance represents: Handle of the acquisition device to be used.
        /// </summary>
        /// <param name="region">Pre-processed image regions.</param>
        /// <param name="contours">Pre-processed XLD contours.</param>
        /// <param name="maxDelay">Maximum tolerated delay between the start of the asynchronous grab and the delivery of the image [ms]. Default: -1.0</param>
        /// <param name="data">Pre-processed control data.</param>
        /// <returns>Grabbed image data.</returns>
        public HImage GrabDataAsync(
          out HRegion region,
          out HXLDCont contours,
          double maxDelay,
          out HTuple data)
        {
            IntPtr proc = HalconAPI.PreCall(2029);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, maxDelay);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 0);
            int err1 = HalconAPI.CallProcedure(proc);
            HImage himage;
            int err2 = HImage.LoadNew(proc, 1, err1, out himage);
            int err3 = HRegion.LoadNew(proc, 2, err2, out region);
            int err4 = HXLDCont.LoadNew(proc, 3, err3, out contours);
            int procResult = HTuple.LoadNew(proc, 0, err4, out data);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>
        ///   Asynchronous grab of images and preprocessed image data from the specified image acquisition device.
        ///   Instance represents: Handle of the acquisition device to be used.
        /// </summary>
        /// <param name="region">Pre-processed image regions.</param>
        /// <param name="contours">Pre-processed XLD contours.</param>
        /// <param name="maxDelay">Maximum tolerated delay between the start of the asynchronous grab and the delivery of the image [ms]. Default: -1.0</param>
        /// <param name="data">Pre-processed control data.</param>
        /// <returns>Grabbed image data.</returns>
        public HImage GrabDataAsync(
          out HRegion region,
          out HXLDCont contours,
          double maxDelay,
          out string data)
        {
            IntPtr proc = HalconAPI.PreCall(2029);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, maxDelay);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 0);
            int err1 = HalconAPI.CallProcedure(proc);
            HImage himage;
            int err2 = HImage.LoadNew(proc, 1, err1, out himage);
            int err3 = HRegion.LoadNew(proc, 2, err2, out region);
            int err4 = HXLDCont.LoadNew(proc, 3, err3, out contours);
            int procResult = HalconAPI.LoadS(proc, 0, err4, out data);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>
        ///   Synchronous grab of images and preprocessed image data from the specified image acquisition device.
        ///   Instance represents: Handle of the acquisition device to be used.
        /// </summary>
        /// <param name="region">Preprocessed image regions.</param>
        /// <param name="contours">Preprocessed XLD contours.</param>
        /// <param name="data">Preprocessed control data.</param>
        /// <returns>Grabbed image data.</returns>
        public HImage GrabData(out HRegion region, out HXLDCont contours, out HTuple data)
        {
            IntPtr proc = HalconAPI.PreCall(2030);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 0);
            int err1 = HalconAPI.CallProcedure(proc);
            HImage himage;
            int err2 = HImage.LoadNew(proc, 1, err1, out himage);
            int err3 = HRegion.LoadNew(proc, 2, err2, out region);
            int err4 = HXLDCont.LoadNew(proc, 3, err3, out contours);
            int procResult = HTuple.LoadNew(proc, 0, err4, out data);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>
        ///   Synchronous grab of images and preprocessed image data from the specified image acquisition device.
        ///   Instance represents: Handle of the acquisition device to be used.
        /// </summary>
        /// <param name="region">Preprocessed image regions.</param>
        /// <param name="contours">Preprocessed XLD contours.</param>
        /// <param name="data">Preprocessed control data.</param>
        /// <returns>Grabbed image data.</returns>
        public HImage GrabData(out HRegion region, out HXLDCont contours, out string data)
        {
            IntPtr proc = HalconAPI.PreCall(2030);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 0);
            int err1 = HalconAPI.CallProcedure(proc);
            HImage himage;
            int err2 = HImage.LoadNew(proc, 1, err1, out himage);
            int err3 = HRegion.LoadNew(proc, 2, err2, out region);
            int err4 = HXLDCont.LoadNew(proc, 3, err3, out contours);
            int procResult = HalconAPI.LoadS(proc, 0, err4, out data);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>
        ///   Asynchronous grab of an image from the specified image acquisition device.
        ///   Instance represents: Handle of the acquisition device to be used.
        /// </summary>
        /// <param name="maxDelay">Maximum tolerated delay between the start of the asynchronous grab and the delivery of the image [ms]. Default: -1.0</param>
        /// <returns>Grabbed image.</returns>
        public HImage GrabImageAsync(double maxDelay)
        {
            IntPtr proc = HalconAPI.PreCall(2031);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, maxDelay);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>
        ///   Start an asynchronous grab from the specified image acquisition device.
        ///   Instance represents: Handle of the acquisition device to be used.
        /// </summary>
        /// <param name="maxDelay">This parameter is obsolete and has no effect. Default: -1.0</param>
        public void GrabImageStart(double maxDelay)
        {
            IntPtr proc = HalconAPI.PreCall(2032);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, maxDelay);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Synchronous grab of an image from the specified image acquisition device.
        ///   Instance represents: Handle of the acquisition device to be used.
        /// </summary>
        /// <returns>Grabbed image.</returns>
        public HImage GrabImage()
        {
            IntPtr proc = HalconAPI.PreCall(2033);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HImage himage;
            int procResult = HImage.LoadNew(proc, 1, err, out himage);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return himage;
        }

        /// <summary>
        ///   Open and configure an image acquisition device.
        ///   Modified instance represents: Handle of the opened image acquisition device.
        /// </summary>
        /// <param name="name">HALCON image acquisition interface name, i.e., name of the corresponding DLL (Windows) or shared library (Linux/macOS). Default: "File"</param>
        /// <param name="horizontalResolution">Desired horizontal resolution of image acquisition interface (absolute value or 1 for full resolution, 2 for half resolution, or 4 for quarter resolution). Default: 1</param>
        /// <param name="verticalResolution">Desired vertical resolution of image acquisition interface (absolute value or 1 for full resolution, 2 for half resolution, or 4 for quarter resolution). Default: 1</param>
        /// <param name="imageWidth">Width of desired image part (absolute value or 0 for HorizontalResolution - 2*StartColumn). Default: 0</param>
        /// <param name="imageHeight">Height of desired image part (absolute value or 0 for VerticalResolution - 2*StartRow). Default: 0</param>
        /// <param name="startRow">Line number of upper left corner of desired image part (or border height if ImageHeight = 0). Default: 0</param>
        /// <param name="startColumn">Column number of upper left corner of desired image part (or border width if ImageWidth = 0). Default: 0</param>
        /// <param name="field">Desired half image or full image. Default: "default"</param>
        /// <param name="bitsPerChannel">Number of transferred bits per pixel and image channel (-1: device-specific default value). Default: -1</param>
        /// <param name="colorSpace">Output color format of the grabbed images, typically 'gray' or 'raw' for single-channel or 'rgb' or 'yuv' for three-channel images ('default': device-specific default value). Default: "default"</param>
        /// <param name="generic">Generic parameter with device-specific meaning. Default: -1</param>
        /// <param name="externalTrigger">External triggering. Default: "default"</param>
        /// <param name="cameraType">Type of used camera ('default': device-specific default value). Default: "default"</param>
        /// <param name="device">Device the image acquisition device is connected to ('default': device-specific default value). Default: "default"</param>
        /// <param name="port">Port the image acquisition device is connected to (-1: device-specific default value). Default: -1</param>
        /// <param name="lineIn">Camera input line of multiplexer (-1: device-specific default value). Default: -1</param>
        public void OpenFramegrabber(
          string name,
          int horizontalResolution,
          int verticalResolution,
          int imageWidth,
          int imageHeight,
          int startRow,
          int startColumn,
          string field,
          HTuple bitsPerChannel,
          HTuple colorSpace,
          HTuple generic,
          string externalTrigger,
          HTuple cameraType,
          HTuple device,
          HTuple port,
          HTuple lineIn)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(2037);
            HalconAPI.StoreS(proc, 0, name);
            HalconAPI.StoreI(proc, 1, horizontalResolution);
            HalconAPI.StoreI(proc, 2, verticalResolution);
            HalconAPI.StoreI(proc, 3, imageWidth);
            HalconAPI.StoreI(proc, 4, imageHeight);
            HalconAPI.StoreI(proc, 5, startRow);
            HalconAPI.StoreI(proc, 6, startColumn);
            HalconAPI.StoreS(proc, 7, field);
            HalconAPI.Store(proc, 8, bitsPerChannel);
            HalconAPI.Store(proc, 9, colorSpace);
            HalconAPI.Store(proc, 10, generic);
            HalconAPI.StoreS(proc, 11, externalTrigger);
            HalconAPI.Store(proc, 12, cameraType);
            HalconAPI.Store(proc, 13, device);
            HalconAPI.Store(proc, 14, port);
            HalconAPI.Store(proc, 15, lineIn);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(bitsPerChannel);
            HalconAPI.UnpinTuple(colorSpace);
            HalconAPI.UnpinTuple(generic);
            HalconAPI.UnpinTuple(cameraType);
            HalconAPI.UnpinTuple(device);
            HalconAPI.UnpinTuple(port);
            HalconAPI.UnpinTuple(lineIn);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Open and configure an image acquisition device.
        ///   Modified instance represents: Handle of the opened image acquisition device.
        /// </summary>
        /// <param name="name">HALCON image acquisition interface name, i.e., name of the corresponding DLL (Windows) or shared library (Linux/macOS). Default: "File"</param>
        /// <param name="horizontalResolution">Desired horizontal resolution of image acquisition interface (absolute value or 1 for full resolution, 2 for half resolution, or 4 for quarter resolution). Default: 1</param>
        /// <param name="verticalResolution">Desired vertical resolution of image acquisition interface (absolute value or 1 for full resolution, 2 for half resolution, or 4 for quarter resolution). Default: 1</param>
        /// <param name="imageWidth">Width of desired image part (absolute value or 0 for HorizontalResolution - 2*StartColumn). Default: 0</param>
        /// <param name="imageHeight">Height of desired image part (absolute value or 0 for VerticalResolution - 2*StartRow). Default: 0</param>
        /// <param name="startRow">Line number of upper left corner of desired image part (or border height if ImageHeight = 0). Default: 0</param>
        /// <param name="startColumn">Column number of upper left corner of desired image part (or border width if ImageWidth = 0). Default: 0</param>
        /// <param name="field">Desired half image or full image. Default: "default"</param>
        /// <param name="bitsPerChannel">Number of transferred bits per pixel and image channel (-1: device-specific default value). Default: -1</param>
        /// <param name="colorSpace">Output color format of the grabbed images, typically 'gray' or 'raw' for single-channel or 'rgb' or 'yuv' for three-channel images ('default': device-specific default value). Default: "default"</param>
        /// <param name="generic">Generic parameter with device-specific meaning. Default: -1</param>
        /// <param name="externalTrigger">External triggering. Default: "default"</param>
        /// <param name="cameraType">Type of used camera ('default': device-specific default value). Default: "default"</param>
        /// <param name="device">Device the image acquisition device is connected to ('default': device-specific default value). Default: "default"</param>
        /// <param name="port">Port the image acquisition device is connected to (-1: device-specific default value). Default: -1</param>
        /// <param name="lineIn">Camera input line of multiplexer (-1: device-specific default value). Default: -1</param>
        public void OpenFramegrabber(
          string name,
          int horizontalResolution,
          int verticalResolution,
          int imageWidth,
          int imageHeight,
          int startRow,
          int startColumn,
          string field,
          int bitsPerChannel,
          string colorSpace,
          double generic,
          string externalTrigger,
          string cameraType,
          string device,
          int port,
          int lineIn)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(2037);
            HalconAPI.StoreS(proc, 0, name);
            HalconAPI.StoreI(proc, 1, horizontalResolution);
            HalconAPI.StoreI(proc, 2, verticalResolution);
            HalconAPI.StoreI(proc, 3, imageWidth);
            HalconAPI.StoreI(proc, 4, imageHeight);
            HalconAPI.StoreI(proc, 5, startRow);
            HalconAPI.StoreI(proc, 6, startColumn);
            HalconAPI.StoreS(proc, 7, field);
            HalconAPI.StoreI(proc, 8, bitsPerChannel);
            HalconAPI.StoreS(proc, 9, colorSpace);
            HalconAPI.StoreD(proc, 10, generic);
            HalconAPI.StoreS(proc, 11, externalTrigger);
            HalconAPI.StoreS(proc, 12, cameraType);
            HalconAPI.StoreS(proc, 13, device);
            HalconAPI.StoreI(proc, 14, port);
            HalconAPI.StoreI(proc, 15, lineIn);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Query look-up table of the image acquisition device.
        ///   Instance represents: Handle of the acquisition device to be used.
        /// </summary>
        /// <param name="imageRed">Red level of the LUT entries.</param>
        /// <param name="imageGreen">Green level of the LUT entries.</param>
        /// <param name="imageBlue">Blue level of the LUT entries.</param>
        public void GetFramegrabberLut(
          out HTuple imageRed,
          out HTuple imageGreen,
          out HTuple imageBlue)
        {
            IntPtr proc = HalconAPI.PreCall(2038);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err1, out imageRed);
            int err3 = HTuple.LoadNew(proc, 1, HTupleType.INTEGER, err2, out imageGreen);
            int procResult = HTuple.LoadNew(proc, 2, HTupleType.INTEGER, err3, out imageBlue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set look-up table of the image acquisition device.
        ///   Instance represents: Handle of the acquisition device to be used.
        /// </summary>
        /// <param name="imageRed">Red level of the LUT entries.</param>
        /// <param name="imageGreen">Green level of the LUT entries.</param>
        /// <param name="imageBlue">Blue level of the LUT entries.</param>
        public void SetFramegrabberLut(HTuple imageRed, HTuple imageGreen, HTuple imageBlue)
        {
            IntPtr proc = HalconAPI.PreCall(2039);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, imageRed);
            HalconAPI.Store(proc, 2, imageGreen);
            HalconAPI.Store(proc, 3, imageBlue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(imageRed);
            HalconAPI.UnpinTuple(imageGreen);
            HalconAPI.UnpinTuple(imageBlue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(2036);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
