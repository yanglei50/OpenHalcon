// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HDevProcedureCall
// Assembly: hdevenginedotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 1BC5D9BA-5A99-483F-ACA6-A4C6BCF4A886
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\hdevenginedotnetxl.dll

using System;

namespace HalconDotNet
{
    /// <summary>Manages an execution instance for a local or external procedure</summary>
    public class HDevProcedureCall : IDisposable
    {
        private IntPtr call = IntPtr.Zero;
        private HDevProcedure procedure;

        /// <summary>Creates a procedure call for the specified procedure</summary>
        public HDevProcedureCall(HDevProcedure procedure)
        {
            HDevProcedureCall.HCkE(EngineAPI.CreateProcedureCall(procedure.Handle, out this.call));
            GC.KeepAlive((object)this);
            this.procedure = procedure;
        }

        /// <summary>Returns true if this class has not yet been disposed</summary>
        public bool IsInitialized()
        {
            return this.call != IntPtr.Zero;
        }

        /// <summary>Gets the procedure associated with this procedure call</summary>
        public HDevProcedure GetProcedure()
        {
            return this.procedure;
        }

        /// <summary>Executes the procedure</summary>
        public void Execute()
        {
            HDevProcedureCall.HCkE(EngineAPI.ExecuteProcedureCall(this.call));
            GC.KeepAlive((object)this);
        }

        /// <summary>Stops execution on first line of procedure.</summary>
        /// <remarks>
        ///   This is intended for debugging purposes when you wish to step
        ///   through a specific procedure call. It only has an effect when a
        ///   debug server is running and it will only stop once.
        /// </remarks>
        public void SetWaitForDebugConnection(bool wait_once)
        {
            HDevProcedureCall.HCkE(EngineAPI.SetWaitForDebugConnectionProcedureCall(this.call, wait_once));
            GC.KeepAlive((object)this);
        }

        /// <summary>Sets input control parameter for procedure call</summary>
        public void SetInputCtrlParamTuple(int index, HTuple tuple)
        {
            IntPtr tuple1;
            HDevProcedureCall.HCkE(HalconAPI.CreateTuple(out tuple1));
            HalconAPI.StoreTuple(tuple1, tuple);
            HDevProcedureCall.HCkE(EngineAPI.SetInputCtrlParamTuple(this.call, index, tuple1));
            GC.KeepAlive((object)this);
            HDevProcedureCall.HCkE(HalconAPI.DestroyTuple(tuple1));
        }

        /// <summary>Sets input control parameter for procedure call</summary>
        public void SetInputCtrlParamTuple(string name, HTuple tuple)
        {
            IntPtr tuple1;
            HDevProcedureCall.HCkE(HalconAPI.CreateTuple(out tuple1));
            HalconAPI.StoreTuple(tuple1, tuple);
            HDevProcedureCall.HCkE(EngineAPI.SetInputCtrlParamTuple(this.call, name, tuple1));
            GC.KeepAlive((object)this);
            HDevProcedureCall.HCkE(HalconAPI.DestroyTuple(tuple1));
        }

        /// <summary>Sets input control parameter for procedure call</summary>
        public void SetInputCtrlParamVector(int index, HTupleVector vector)
        {
            IntPtr vectorHandle;
            HDevProcedureCall.HCkE(EngineAPI.CreateTupleVector(vector, out vectorHandle));
            HDevProcedureCall.HCkE(EngineAPI.SetInputCtrlParamVector(this.call, index, vectorHandle));
            GC.KeepAlive((object)this);
            HDevProcedureCall.HCkE(EngineAPI.DestroyTupleVector(vectorHandle));
        }

        /// <summary>Sets input control parameter for procedure call</summary>
        public void SetInputCtrlParamVector(string name, HTupleVector vector)
        {
            IntPtr vectorHandle;
            HDevProcedureCall.HCkE(EngineAPI.CreateTupleVector(vector, out vectorHandle));
            HDevProcedureCall.HCkE(EngineAPI.SetInputCtrlParamVector(this.call, name, vectorHandle));
            GC.KeepAlive((object)this);
            HDevProcedureCall.HCkE(EngineAPI.DestroyTupleVector(vectorHandle));
        }

        /// <summary>Sets iconic input object for procedure call</summary>
        public void SetInputIconicParamObject(int index, HObject iconic)
        {
            HDevProcedureCall.HCkE(EngineAPI.SetInputIconicParamObject(this.call, index, iconic.Key));
            GC.KeepAlive((object)iconic);
            GC.KeepAlive((object)this);
        }

        /// <summary>Sets iconic input object for procedure call</summary>
        public void SetInputIconicParamObject(string name, HObject iconic)
        {
            HDevProcedureCall.HCkE(EngineAPI.SetInputIconicParamObject(this.call, name, iconic.Key));
            GC.KeepAlive((object)iconic);
            GC.KeepAlive((object)this);
        }

        /// <summary>Sets input control parameter for procedure call</summary>
        public void SetInputIconicParamVector(int index, HObjectVector vector)
        {
            IntPtr vectorHandle;
            HDevProcedureCall.HCkE(EngineAPI.CreateObjectVector(vector, out vectorHandle));
            HDevProcedureCall.HCkE(EngineAPI.SetInputIconicParamVector(this.call, index, vectorHandle));
            GC.KeepAlive((object)this);
            HDevProcedureCall.HCkE(EngineAPI.DestroyObjectVector(vectorHandle));
        }

        /// <summary>Sets input control parameter for procedure call</summary>
        public void SetInputIconicParamVector(string name, HObjectVector vector)
        {
            IntPtr vectorHandle;
            HDevProcedureCall.HCkE(EngineAPI.CreateObjectVector(vector, out vectorHandle));
            HDevProcedureCall.HCkE(EngineAPI.SetInputIconicParamVector(this.call, name, vectorHandle));
            GC.KeepAlive((object)this);
            HDevProcedureCall.HCkE(EngineAPI.DestroyObjectVector(vectorHandle));
        }

        /// <summary>Gets the value of an output control parameter</summary>
        public HTuple GetOutputCtrlParamTuple(int index)
        {
            IntPtr tuple;
            HDevProcedureCall.HCkE(EngineAPI.GetOutputCtrlParamTuple(this.call, index, out tuple));
            GC.KeepAlive((object)this);
            return HalconAPI.LoadTuple(tuple);
        }

        /// <summary>Gets the value of an output control parameter</summary>
        public HTuple GetOutputCtrlParamTuple(string name)
        {
            IntPtr tuple;
            HDevProcedureCall.HCkE(EngineAPI.GetOutputCtrlParamTuple(this.call, name, out tuple));
            GC.KeepAlive((object)this);
            return HalconAPI.LoadTuple(tuple);
        }

        /// <summary>Gets the value of an output control parameter</summary>
        public HTupleVector GetOutputCtrlParamVector(int index)
        {
            IntPtr vector;
            HDevProcedureCall.HCkE(EngineAPI.GetOutputCtrlParamVector(this.call, index, out vector));
            GC.KeepAlive((object)this);
            return EngineAPI.GetAndDestroyTupleVector(vector);
        }

        /// <summary>Gets the value of an output control parameter</summary>
        public HTupleVector GetOutputCtrlParamVector(string name)
        {
            IntPtr vector;
            HDevProcedureCall.HCkE(EngineAPI.GetOutputCtrlParamVector(this.call, name, out vector));
            GC.KeepAlive((object)this);
            return EngineAPI.GetAndDestroyTupleVector(vector);
        }

        /// <summary>Gets the object of an iconic output parameter</summary>
        public HObject GetOutputIconicParamObject(int index)
        {
            IntPtr key;
            HDevProcedureCall.HCkE(EngineAPI.GetOutputIconicParamObject(this.call, index, out key));
            GC.KeepAlive((object)this);
            return new HObject(key);
        }

        /// <summary>Gets the object of an iconic output parameter</summary>
        public HObject GetOutputIconicParamObject(string name)
        {
            IntPtr key;
            HDevProcedureCall.HCkE(EngineAPI.GetOutputIconicParamObject(this.call, name, out key));
            GC.KeepAlive((object)this);
            return new HObject(key);
        }

        /// <summary>Gets the value of an output control parameter</summary>
        public HObjectVector GetOutputIconicParamVector(int index)
        {
            IntPtr vector;
            HDevProcedureCall.HCkE(EngineAPI.GetOutputIconicParamVector(this.call, index, out vector));
            GC.KeepAlive((object)this);
            return EngineAPI.GetAndDestroyObjectVector(vector);
        }

        /// <summary>Gets the value of an output control parameter</summary>
        public HObjectVector GetOutputIconicParamVector(string name)
        {
            IntPtr vector;
            HDevProcedureCall.HCkE(EngineAPI.GetOutputIconicParamVector(this.call, name, out vector));
            GC.KeepAlive((object)this);
            return EngineAPI.GetAndDestroyObjectVector(vector);
        }

        /// <summary>Gets the image of an iconic output parameter</summary>
        public HImage GetOutputIconicParamImage(int index)
        {
            IntPtr key;
            HDevProcedureCall.HCkE(EngineAPI.GetOutputIconicParamObject(this.call, index, out key));
            GC.KeepAlive((object)this);
            EngineAPI.AssertObjectClass(key, "image", "main");
            return new HImage(key);
        }

        /// <summary>Gets the image of an iconic output parameter</summary>
        public HImage GetOutputIconicParamImage(string name)
        {
            IntPtr key;
            HDevProcedureCall.HCkE(EngineAPI.GetOutputIconicParamObject(this.call, name, out key));
            GC.KeepAlive((object)this);
            EngineAPI.AssertObjectClass(key, "image", "main");
            return new HImage(key);
        }

        /// <summary>Gets the region of an iconic output parameter</summary>
        public HRegion GetOutputIconicParamRegion(int index)
        {
            IntPtr key;
            HDevProcedureCall.HCkE(EngineAPI.GetOutputIconicParamObject(this.call, index, out key));
            GC.KeepAlive((object)this);
            EngineAPI.AssertObjectClass(key, "region", "main");
            return new HRegion(key);
        }

        /// <summary>Gets the region of an iconic output parameter</summary>
        public HRegion GetOutputIconicParamRegion(string name)
        {
            IntPtr key;
            HDevProcedureCall.HCkE(EngineAPI.GetOutputIconicParamObject(this.call, name, out key));
            GC.KeepAlive((object)this);
            EngineAPI.AssertObjectClass(key, "region", "main");
            return new HRegion(key);
        }

        /// <summary>Gets the xld contour of an iconic output parameter</summary>
        public HXLD GetOutputIconicParamXld(int index)
        {
            IntPtr key;
            HDevProcedureCall.HCkE(EngineAPI.GetOutputIconicParamObject(this.call, index, out key));
            GC.KeepAlive((object)this);
            EngineAPI.AssertObjectClass(key, "xld", "main");
            return new HXLD(key);
        }

        /// <summary>Gets the xld contour of an iconic output parameter</summary>
        public HXLD GetOutputIconicParamXld(string name)
        {
            IntPtr key;
            HDevProcedureCall.HCkE(EngineAPI.GetOutputIconicParamObject(this.call, name, out key));
            GC.KeepAlive((object)this);
            EngineAPI.AssertObjectClass(key, "xld", "main");
            return new HXLD(key);
        }

        internal static void HCkE(int err)
        {
            EngineAPI.HCkE(err);
        }

        ~HDevProcedureCall()
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
               // base.Finalize();
            }
        }

        void IDisposable.Dispose()
        {
            this.Dispose();
        }

        /// <summary>Releases the resources used by this procedure call</summary>
        public virtual void Dispose()
        {
            if (this.call != IntPtr.Zero)
            {
                EngineAPI.DestroyProcedureCall(this.call);
                this.call = IntPtr.Zero;
            }
            GC.SuppressFinalize((object)this);
            GC.KeepAlive((object)this);
        }
    }
}
