using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalconDotNet
{
    /// <summary>
    /// This class wraps an object implementing IHDevOperators, registers
    ///               internal delegates with the HDevEngine and calls the appropriate
    ///               interface methods at callback time (including conversion of
    ///               parameters and transformation of exceptions to return codes).
    /// 
    /// </summary>
    internal class HDevOperatorWrapper
    {
        private IntPtr implHandle = IntPtr.Zero;
        private IHDevOperators implementation;
        private DevOpenWindowDelegate delegateDevOpenWindow;
        private DevCloseWindowDelegate delegateDevCloseWindow;
        private DevSetWindowDelegate delegateDevSetWindow;
        private DevGetWindowDelegate delegateDevGetWindow;
        private DevSetWindowExtentsDelegate delegateDevSetWindowExtents;
        private DevSetPartDelegate delegateDevSetPart;
        private DevClearWindowDelegate delegateDevClearWindow;
        private DevDisplayDelegate delegateDevDisplay;
        private DevDispTextDelegate delegateDevDispText;
        private DevSetDrawDelegate delegateDevSetDraw;
        private DevSetShapeDelegate delegateDevSetShape;
        private DevSetColoredDelegate delegateDevSetColored;
        private DevSetColorDelegate delegateDevSetColor;
        private DevSetLutDelegate delegateDevSetLut;
        private DevSetPaintDelegate delegateDevSetPaint;
        private DevSetLineWidthDelegate delegateDevSetLineWidth;

        public IntPtr ImplementationHandle
        {
            get
            {
                return this.implHandle;
            }
        }

        public HDevOperatorWrapper(HDevEngine engine, IHDevOperators implementation)
        {
            this.implementation = implementation;
            this.delegateDevOpenWindow = new DevOpenWindowDelegate(this.DevOpenWindow);
            this.delegateDevCloseWindow = new DevCloseWindowDelegate(this.DevCloseWindow);
            this.delegateDevSetWindow = new DevSetWindowDelegate(this.DevSetWindow);
            this.delegateDevGetWindow = new DevGetWindowDelegate(this.DevGetWindow);
            this.delegateDevSetWindowExtents = new DevSetWindowExtentsDelegate(this.DevSetWindowExtents);
            this.delegateDevSetPart = new DevSetPartDelegate(this.DevSetPart);
            this.delegateDevClearWindow = new DevClearWindowDelegate(this.DevClearWindow);
            this.delegateDevDisplay = new DevDisplayDelegate(this.DevDisplay);
            this.delegateDevDispText = new DevDispTextDelegate(this.DevDispText);
            this.delegateDevSetDraw = new DevSetDrawDelegate(this.DevSetDraw);
            this.delegateDevSetShape = new DevSetShapeDelegate(this.DevSetShape);
            this.delegateDevSetColored = new DevSetColoredDelegate(this.DevSetColored);
            this.delegateDevSetColor = new DevSetColorDelegate(this.DevSetColor);
            this.delegateDevSetLut = new DevSetLutDelegate(this.DevSetLut);
            this.delegateDevSetPaint = new DevSetPaintDelegate(this.DevSetPaint);
            this.delegateDevSetLineWidth = new DevSetLineWidthDelegate(this.DevSetLineWidth);
            EngineAPI.HCkE(EngineAPI.CreateImplementation(out this.implHandle, this.delegateDevOpenWindow, this.delegateDevCloseWindow, this.delegateDevSetWindow, this.delegateDevGetWindow, this.delegateDevSetWindowExtents, this.delegateDevSetPart, this.delegateDevClearWindow, this.delegateDevDisplay, this.delegateDevDispText, this.delegateDevSetDraw, this.delegateDevSetShape, this.delegateDevSetColored, this.delegateDevSetColor, this.delegateDevSetLut, this.delegateDevSetPaint, this.delegateDevSetLineWidth));
            GC.KeepAlive((object)this);
        }

        ~HDevOperatorWrapper()
        {
            try
            {
                if (!(this.implHandle != IntPtr.Zero))
                    return;
                EngineAPI.DestroyImplementation(this.implHandle);
                GC.KeepAlive((object)this);
            }
            catch (Exception ex)
            {
            }
            finally
            {
                // ISSUE: explicit finalizer call
        
                //Finalize();
            }
        }

        private static HTuple LoadTuple(IntPtr tupleHandle)
        {
            return HalconAPI.LoadTuple(tupleHandle);
        }

        private static int ToHalconError(Exception e)
        {
            if (e is HOperatorException)
                return ((HalconException)e).GetErrorCode();
            if (e is HDevEngineException)
                return ((HDevEngineException)e).HalconError;
            return 5;
        }

        private int DevOpenWindow(IntPtr row, IntPtr column, IntPtr width, IntPtr height, IntPtr background, IntPtr windowID)
        {
            try
            {
                HTuple windowHandle;
                this.implementation.DevOpenWindow(HDevOperatorWrapper.LoadTuple(row), HDevOperatorWrapper.LoadTuple(column), HDevOperatorWrapper.LoadTuple(width), HDevOperatorWrapper.LoadTuple(height), HDevOperatorWrapper.LoadTuple(background), out windowHandle);
                HalconAPI.StoreTuple(windowID, windowHandle);
            }
            catch (Exception ex)
            {
                return HDevOperatorWrapper.ToHalconError(ex);
            }
            return 2;
        }

        private int DevCloseWindow()
        {
            try
            {
                this.implementation.DevCloseWindow();
            }
            catch (Exception ex)
            {
                return HDevOperatorWrapper.ToHalconError(ex);
            }
            return 2;
        }

        private int DevSetWindow(IntPtr windowID)
        {
            try
            {
                this.implementation.DevSetWindow(HDevOperatorWrapper.LoadTuple(windowID));
            }
            catch (Exception ex)
            {
                return HDevOperatorWrapper.ToHalconError(ex);
            }
            return 2;
        }

        private int DevGetWindow(IntPtr windowID)
        {
            try
            {
                HTuple windowHandle;
                this.implementation.DevGetWindow(out windowHandle);
                HalconAPI.StoreTuple(windowID, windowHandle);
            }
            catch (Exception ex)
            {
                return HDevOperatorWrapper.ToHalconError(ex);
            }
            return 2;
        }

        private int DevSetWindowExtents(IntPtr row, IntPtr column, IntPtr width, IntPtr height)
        {
            try
            {
                this.implementation.DevSetWindowExtents(HDevOperatorWrapper.LoadTuple(row), HDevOperatorWrapper.LoadTuple(column), HDevOperatorWrapper.LoadTuple(width), HDevOperatorWrapper.LoadTuple(height));
            }
            catch (Exception ex)
            {
                return HDevOperatorWrapper.ToHalconError(ex);
            }
            return 2;
        }

        private int DevSetPart(IntPtr row, IntPtr column, IntPtr width, IntPtr height)
        {
            try
            {
                this.implementation.DevSetPart(HDevOperatorWrapper.LoadTuple(row), HDevOperatorWrapper.LoadTuple(column), HDevOperatorWrapper.LoadTuple(width), HDevOperatorWrapper.LoadTuple(height));
            }
            catch (Exception ex)
            {
                return HDevOperatorWrapper.ToHalconError(ex);
            }
            return 2;
        }

        private int DevClearWindow()
        {
            try
            {
                this.implementation.DevClearWindow();
            }
            catch (Exception ex)
            {
                return HDevOperatorWrapper.ToHalconError(ex);
            }
            return 2;
        }

        private int DevDisplay(IntPtr key)
        {
            HObject objectVal = (HObject)null;
            try
            {
                objectVal = new HObject(key);
                this.implementation.DevDisplay(objectVal);
                objectVal.Dispose();
            }
            catch (Exception ex)
            {
                if (objectVal != null)
                    objectVal.Dispose();
                return HDevOperatorWrapper.ToHalconError(ex);
            }
            return 2;
        }

        private int DevDispText(IntPtr text, IntPtr coordSystem, IntPtr row, IntPtr column, IntPtr color, IntPtr genParamNames, IntPtr genParamValues)
        {
            try
            {
                this.implementation.DevDispText(HDevOperatorWrapper.LoadTuple(text), HDevOperatorWrapper.LoadTuple(coordSystem), HDevOperatorWrapper.LoadTuple(row), HDevOperatorWrapper.LoadTuple(column), HDevOperatorWrapper.LoadTuple(color), HDevOperatorWrapper.LoadTuple(genParamNames), HDevOperatorWrapper.LoadTuple(genParamValues));
            }
            catch (Exception ex)
            {
                return HDevOperatorWrapper.ToHalconError(ex);
            }
            return 2;
        }

        private int DevSetDraw(IntPtr draw)
        {
            try
            {
                this.implementation.DevSetDraw(HDevOperatorWrapper.LoadTuple(draw));
            }
            catch (Exception ex)
            {
                return HDevOperatorWrapper.ToHalconError(ex);
            }
            return 2;
        }

        private int DevSetShape(IntPtr shape)
        {
            try
            {
                this.implementation.DevSetShape(HDevOperatorWrapper.LoadTuple(shape));
            }
            catch (Exception ex)
            {
                return HDevOperatorWrapper.ToHalconError(ex);
            }
            return 2;
        }

        private int DevSetColored(IntPtr colored)
        {
            try
            {
                this.implementation.DevSetColored(HDevOperatorWrapper.LoadTuple(colored));
            }
            catch (Exception ex)
            {
                return HDevOperatorWrapper.ToHalconError(ex);
            }
            return 2;
        }

        private int DevSetColor(IntPtr color)
        {
            try
            {
                this.implementation.DevSetColor(HDevOperatorWrapper.LoadTuple(color));
            }
            catch (Exception ex)
            {
                return HDevOperatorWrapper.ToHalconError(ex);
            }
            return 2;
        }

        private int DevSetLut(IntPtr lut)
        {
            try
            {
                this.implementation.DevSetLut(HDevOperatorWrapper.LoadTuple(lut));
            }
            catch (Exception ex)
            {
                return HDevOperatorWrapper.ToHalconError(ex);
            }
            return 2;
        }

        private int DevSetPaint(IntPtr paint)
        {
            try
            {
                this.implementation.DevSetPaint(HDevOperatorWrapper.LoadTuple(paint));
            }
            catch (Exception ex)
            {
                return HDevOperatorWrapper.ToHalconError(ex);
            }
            return 2;
        }

        private int DevSetLineWidth(IntPtr width)
        {
            try
            {
                this.implementation.DevSetLineWidth(HDevOperatorWrapper.LoadTuple(width));
            }
            catch (Exception ex)
            {
                return HDevOperatorWrapper.ToHalconError(ex);
            }
            return 2;
        }
    }
}
