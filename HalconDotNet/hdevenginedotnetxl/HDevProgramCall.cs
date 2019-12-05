// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HDevProgramCall
// Assembly: hdevenginedotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 1BC5D9BA-5A99-483F-ACA6-A4C6BCF4A886
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\hdevenginedotnetxl.dll

using System;

namespace HalconDotNet
{
    /// <summary>Manages an execution instance for an HDevelop program</summary>
    public class HDevProgramCall : IDisposable
    {
        private IntPtr call = IntPtr.Zero;
        private HDevProgram program;

        /// <summary>Creates a program call for the specified program</summary>
        public HDevProgramCall(HDevProgram program)
        {
            HDevProgramCall.HCkE(EngineAPI.CreateProgramCall(program.Handle, out this.call));
            GC.KeepAlive((object)this);
            this.program = program;
        }

        /// <summary>Returns true if this class has not yet been disposed</summary>
        public bool IsInitialized()
        {
            return this.call != IntPtr.Zero;
        }

        /// <summary>Gets the program associated with this program call</summary>
        public HDevProgram GetProgram()
        {
            return this.program;
        }

        /// <summary>Executes the program</summary>
        public void Execute()
        {
            HDevProgramCall.HCkE(EngineAPI.ExecuteProgramCall(this.call));
            GC.KeepAlive((object)this);
        }

        /// <summary>Stops execution on first line of program.</summary>
        /// <remarks>
        ///   This is intended for debugging purposes when you wish to step
        ///   through a specific program call. It only has an effect when a
        ///   debug server is running and it will only stop once.
        /// </remarks>
        public void SetWaitForDebugConnection(bool wait_once)
        {
            HDevProgramCall.HCkE(EngineAPI.SetWaitForDebugConnectionProgramCall(this.call, wait_once));
            GC.KeepAlive((object)this);
        }

        /// <summary>Resets the program execution</summary>
        public void Reset()
        {
            HDevProgramCall.HCkE(EngineAPI.ResetProgramCall(this.call));
            GC.KeepAlive((object)this);
        }

        /// <summary>Gets the value of a control variable (in main)</summary>
        public HTuple GetCtrlVarTuple(int index)
        {
            IntPtr tuple;
            HDevProgramCall.HCkE(EngineAPI.GetCtrlVarTuple(this.call, index, out tuple));
            GC.KeepAlive((object)this);
            return HalconAPI.LoadTuple(tuple);
        }

        /// <summary>Gets the values of a control vector variable
        /// (in main)</summary>
        public HTupleVector GetCtrlVarVector(int index)
        {
            IntPtr vector;
            HDevProgramCall.HCkE(EngineAPI.GetCtrlVarVector(this.call, index, out vector));
            GC.KeepAlive((object)this);
            return EngineAPI.GetAndDestroyTupleVector(vector);
        }

        /// <summary>Gets the value of a control variable (in main)</summary>
        public HTuple GetCtrlVarTuple(string name)
        {
            IntPtr tuple;
            HDevProgramCall.HCkE(EngineAPI.GetCtrlVarTuple(this.call, name, out tuple));
            GC.KeepAlive((object)this);
            return HalconAPI.LoadTuple(tuple);
        }

        /// <summary>Gets the values of a control vector variable
        /// (in main)</summary>
        public HTupleVector GetCtrlVarVector(string name)
        {
            IntPtr vector;
            HDevProgramCall.HCkE(EngineAPI.GetCtrlVarVector(this.call, name, out vector));
            GC.KeepAlive((object)this);
            return EngineAPI.GetAndDestroyTupleVector(vector);
        }

        /// <summary>Gets the object of an iconic variable (in main)</summary>
        public HObject GetIconicVarObject(int index)
        {
            IntPtr key;
            HDevProgramCall.HCkE(EngineAPI.GetIconicVarObject(this.call, index, out key));
            GC.KeepAlive((object)this);
            return new HObject(key);
        }

        /// <summary>Gets the values of an iconic vector variable
        /// (in main)</summary>
        public HObjectVector GetIconicVarVector(int index)
        {
            IntPtr vector;
            HDevProgramCall.HCkE(EngineAPI.GetIconicVarVector(this.call, index, out vector));
            GC.KeepAlive((object)this);
            return EngineAPI.GetAndDestroyObjectVector(vector);
        }

        /// <summary>Gets the object of an iconic variable (in main)</summary>
        public HObject GetIconicVarObject(string name)
        {
            IntPtr key;
            HDevProgramCall.HCkE(EngineAPI.GetIconicVarObject(this.call, name, out key));
            GC.KeepAlive((object)this);
            return new HObject(key);
        }

        /// <summary>Gets the values of an iconic vector variable
        /// (in main)</summary>
        public HObjectVector GetIconicVarVector(string name)
        {
            IntPtr vector;
            HDevProgramCall.HCkE(EngineAPI.GetIconicVarVector(this.call, name, out vector));
            GC.KeepAlive((object)this);
            return EngineAPI.GetAndDestroyObjectVector(vector);
        }

        /// <summary>Gets the image of an iconic variable (in main)</summary>
        public HImage GetIconicVarImage(int index)
        {
            IntPtr key;
            HDevProgramCall.HCkE(EngineAPI.GetIconicVarObject(this.call, index, out key));
            GC.KeepAlive((object)this);
            EngineAPI.AssertObjectClass(key, "image", "main");
            return new HImage(key);
        }

        /// <summary>Gets the image of an iconic variable (in main)</summary>
        public HImage GetIconicVarImage(string name)
        {
            IntPtr key;
            HDevProgramCall.HCkE(EngineAPI.GetIconicVarObject(this.call, name, out key));
            GC.KeepAlive((object)this);
            EngineAPI.AssertObjectClass(key, "image", "main");
            return new HImage(key);
        }

        /// <summary>Gets the region of an iconic variable (in main)</summary>
        public HRegion GetIconicVarRegion(int index)
        {
            IntPtr key;
            HDevProgramCall.HCkE(EngineAPI.GetIconicVarObject(this.call, index, out key));
            GC.KeepAlive((object)this);
            EngineAPI.AssertObjectClass(key, "region", "main");
            return new HRegion(key);
        }

        /// <summary>Gets the region of an iconic variable (in main)</summary>
        public HRegion GetIconicVarRegion(string name)
        {
            IntPtr key;
            HDevProgramCall.HCkE(EngineAPI.GetIconicVarObject(this.call, name, out key));
            GC.KeepAlive((object)this);
            EngineAPI.AssertObjectClass(key, "region", "main");
            return new HRegion(key);
        }

        /// <summary>Gets the xld contour of an iconic variable (in main)</summary>
        public HXLD GetIconicVarXld(int index)
        {
            IntPtr key;
            HDevProgramCall.HCkE(EngineAPI.GetIconicVarObject(this.call, index, out key));
            GC.KeepAlive((object)this);
            EngineAPI.AssertObjectClass(key, "xld", "main");
            return new HXLD(key);
        }

        /// <summary>Gets the xld contour of an iconic variable (in main)</summary>
        public HXLD GetIconicVarXld(string name)
        {
            IntPtr key;
            HDevProgramCall.HCkE(EngineAPI.GetIconicVarObject(this.call, name, out key));
            GC.KeepAlive((object)this);
            EngineAPI.AssertObjectClass(key, "xld", "main");
            return new HXLD(key);
        }

        internal static void HCkE(int err)
        {
            EngineAPI.HCkE(err);
        }

        ~HDevProgramCall()
        {
            try
            {
                this.Dispose();
            }
            catch (Exception ex)
            {
            }
            finally
            {
                // ISSUE: explicit finalizer call
                base.Finalize();
            }
        }

        void IDisposable.Dispose()
        {
            this.Dispose();
        }

        /// <summary>Releases the resources used by this engine</summary>
        public virtual void Dispose()
        {
            if (this.call != IntPtr.Zero)
            {
                EngineAPI.DestroyProgramCall(this.call);
                this.call = IntPtr.Zero;
            }
            this.program = (HDevProgram)null;
            GC.SuppressFinalize((object)this);
            GC.KeepAlive((object)this);
        }
    }
}
