// Decompiled with JetBrains decompiler
// Type: HalconDotNet.IHDevOperators
// Assembly: hdevenginedotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 1BC5D9BA-5A99-483F-ACA6-A4C6BCF4A886
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\hdevenginedotnetxl.dll

namespace HalconDotNet
{
    /// <summary>Interface for implementation of HDevelop operators</summary>
    /// <remarks>
    ///   This is intended for use with HDevEngine.SetHDevOperators.
    ///   Note that two implementations are already provided ready-to-use,
    ///   namely HDevOpFixedWindowImpl and HDevOpMultiWindowImpl.
    /// </remarks>
    public interface IHDevOperators
    {
        /// <summary>Open a graphics window.</summary>
        /// <param name="row">Row index of upper left corner. Default: 0</param>
        /// <param name="column">Column index of upper left corner. Default: 0</param>
        /// <param name="width">Width of the window. Default: 256</param>
        /// <param name="height">Height of the window. Default: 256</param>
        /// <param name="background">Color of the background of the new window. Default: "black"</param>
        /// <param name="windowHandle">Window identifier.</param>
        void DevOpenWindow(
          HTuple row,
          HTuple column,
          HTuple width,
          HTuple height,
          HTuple background,
          out HTuple windowHandle);

        /// <summary>Close the active graphics window.</summary>
        void DevCloseWindow();

        /// <summary>Activate a graphics window.</summary>
        /// <param name="windowHandle">Window identifier.</param>
        void DevSetWindow(HTuple windowHandle);

        /// <summary>Return the identifier of the activate graphics window.</summary>
        /// <param name="windowHandle">Window identifier.</param>
        void DevGetWindow(out HTuple windowHandle);

        /// <summary>Change position and size of a graphics window.</summary>
        /// <param name="row">Row index of upper left corner. Default: 0</param>
        /// <param name="column">Column index of upper left corner. Default: 0</param>
        /// <param name="width">Width of the window. Default: 256</param>
        /// <param name="height">Height of the window. Default: 256</param>
        void DevSetWindowExtents(HTuple row, HTuple column, HTuple width, HTuple height);

        /// <summary>Modify the displayed image part.</summary>
        /// <param name="row1">Row of the upper left corner of the chosen image part. Default: 0</param>
        /// <param name="column1">Column of the upper left corner of the chosen image part. Default: 0</param>
        /// <param name="row2">Row of the lower right corner of the chosen image part. Default: 128</param>
        /// <param name="column2">Column of the lower right corner of the chosen image part. Default: 128</param>
        void DevSetPart(HTuple row1, HTuple column1, HTuple row2, HTuple column2);

        /// <summary>Clear the active graphics window.</summary>
        void DevClearWindow();

        /// <summary>Displays image objects in the current graphics window.</summary>
        /// <param name="objectVal">
        ///   Iconic object to be displayed. Attention! This will be disposed
        ///   automatically by HDevEngine/.NET after DevDisplay returns.
        ///   Do not keep a reference!
        /// </param>
        void DevDisplay(HObject objectVal);

        /// <summary>Displays text in the graphics window.</summary>
        /// <param name="text">A tuple of strings containing the text message to be
        /// displayed. Each value of the tuple will be displayed in a single line.</param>
        /// <param name="coordSystem">If set to 'window', the text position is given with respect to
        /// the window coordinate system.If set to 'image', image
        /// coordinates are used (this may be useful in zoomed images).</param>
        /// <param name="row">he row coordinate of the desired text position.</param>
        /// <param name="column">The column coordinate of the desired text position.</param>
        /// <param name="color">A tuple of strings defining the colors of the texts.</param>
        /// <param name="genParamNames">Generic parameter names.</param>
        /// <param name="genParamValues">Generic parameter values.</param>
        void DevDispText(
          HTuple text,
          HTuple coordSystem,
          HTuple row,
          HTuple column,
          HTuple color,
          HTuple genParamNames,
          HTuple genParamValues);

        /// <summary>Define the region fill mode.</summary>
        /// <param name="drawMode">Fill mode for region output. Default: "fill"</param>
        void DevSetDraw(HTuple drawMode);

        /// <summary>Define the region output shape.</summary>
        /// <param name="shape">Region output mode. Default: "original"</param>
        void DevSetShape(HTuple shape);

        /// <summary>Set multiple output colors.</summary>
        /// <param name="numColors">Number of output colors. Default: 6</param>
        void DevSetColored(HTuple numColors);

        /// <summary>Set output color.</summary>
        /// <param name="colorName">Output color names. Default: "white"</param>
        void DevSetColor(HTuple colorName);

        /// <summary>Set "look-up-table" (lut).</summary>
        /// <param name="lutName">Name of look-up-table, values of look-up-table (RGB)  or file name. Default: "default"</param>
        void DevSetLut(HTuple lutName);

        /// <summary>Define the grayvalue output mode.</summary>
        /// <param name="mode">Grayvalue output name. Additional parameters possible. Default: "default"</param>
        void DevSetPaint(HTuple mode);

        /// <summary>Define the line width for region contour output.</summary>
        /// <param name="lineWidth">Line width for region output in contour mode. Default: 1</param>
        void DevSetLineWidth(HTuple lineWidth);
    }
}
