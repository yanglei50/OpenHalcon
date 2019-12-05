// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HDevEngine
// Assembly: hdevenginedotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 1BC5D9BA-5A99-483F-ACA6-A4C6BCF4A886
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\hdevenginedotnetxl.dll

using System;

namespace HalconDotNet
{
    /// <summary>Executes HDevelop programs and procedures at run time</summary>
    /// <remarks>
    ///   The hdevenginecpp.dll is required for using this class.
    /// </remarks>
    public class HDevEngine : IDisposable
    {
        private IntPtr engine = IntPtr.Zero;
        private HDevOperatorWrapper operatorWrapper;

        /// <summary>Creates a new instance of HDevEngine</summary>
        public HDevEngine()
        {
            HDevEngine.HCkE(EngineAPI.CreateEngine(out this.engine));
            GC.KeepAlive((object)this);
        }

        /// <summary>Returns true if this class has not yet been disposed</summary>
        public bool IsInitialized()
        {
            return this.engine != IntPtr.Zero;
        }

        /// <summary>Changes a global setting of the engine</summary>
        /// <param name="name">
        ///   The name of the attribute, e.g. "ignore_invalid_lines"
        ///   or "ignore_unresolved_lines"
        /// </param>
        /// <param name="attributeValue">The new value of the attribute</param>
        public void SetEngineAttribute(string name, HTuple attributeValue)
        {
            IntPtr tuple;
            HDevEngine.HCkE(HalconAPI.CreateTuple(out tuple));
            HalconAPI.StoreTuple(tuple, attributeValue);
            int err = EngineAPI.SetEngineAttribute(this.engine, name, tuple);
            GC.KeepAlive((object)this);
            HalconAPI.DestroyTuple(tuple);
            HDevEngine.HCkE(err);
        }

        /// <summary>Queries a global setting of the engine</summary>
        /// <param name="name">
        ///   The name of the attribute, e.g. "ignore_invalid_lines"
        ///   or "ignore_unresolved_lines"
        /// </param>
        /// <returns>The current value of the attribute</returns>
        public HTuple GetEngineAttribute(string name)
        {
            IntPtr tuple;
            HDevEngine.HCkE(HalconAPI.CreateTuple(out tuple));
            HDevEngine.HCkE(EngineAPI.GetEngineAttribute(this.engine, name, tuple));
            GC.KeepAlive((object)this);
            HTuple htuple = HalconAPI.LoadTuple(tuple);
            HDevEngine.HCkE(HalconAPI.DestroyTuple(tuple));
            return htuple;
        }

        /// <summary>
        ///    Starts the debug server that allows to attach HDevelop as
        ///    as debugger to step through engine code.
        /// </summary>
        /// <remarks>
        ///   With default settings server waits on port 7786 and engine runs
        ///   normally until HDevelop is connected and F9 is pressed to stop
        ///   execution.
        /// </remarks>
        public void StartDebugServer()
        {
            HDevEngine.HCkE(EngineAPI.StartDebugServer(this.engine));
            GC.KeepAlive((object)this);
        }

        /// <summary>Stops the debug server (resuming execution if stopped)</summary>
        public void StopDebugServer()
        {
            HDevEngine.HCkE(EngineAPI.StopDebugServer(this.engine));
            GC.KeepAlive((object)this);
        }

        /// <summary>Sets the path for loading external procedures</summary>
        /// <param name="path">List of directories in the path format of the operating system</param>
        public void SetProcedurePath(string path)
        {
            HDevEngine.HCkE(EngineAPI.SetProcedurePath(this.engine, path));
            GC.KeepAlive((object)this);
        }

        /// <summary>Appends to the path for loading external procedures</summary>
        /// <param name="path">List of directories in the path format of the operating system</param>
        public void AddProcedurePath(string path)
        {
            HDevEngine.HCkE(EngineAPI.AddProcedurePath(this.engine, path));
            GC.KeepAlive((object)this);
        }

        /// <summary>Returns the names of available procedures</summary>
        /// <returns>String tuple containing the procedure names</returns>
        public HTuple GetProcedureNames()
        {
            IntPtr tuple;
            HDevEngine.HCkE(HalconAPI.CreateTuple(out tuple));
            HDevEngine.HCkE(EngineAPI.GetProcedureNames(this.engine, tuple));
            GC.KeepAlive((object)this);
            HTuple htuple = HalconAPI.LoadTuple(tuple);
            HDevEngine.HCkE(HalconAPI.DestroyTuple(tuple));
            return htuple;
        }

        /// <summary>Returns the names of loaded procedures</summary>
        /// <returns>String tuple containing the procedure names</returns>
        public HTuple GetLoadedProcedureNames()
        {
            IntPtr tuple;
            HDevEngine.HCkE(HalconAPI.CreateTuple(out tuple));
            HDevEngine.HCkE(EngineAPI.GetLoadedProcedureNames(this.engine, tuple));
            GC.KeepAlive((object)this);
            HTuple htuple = HalconAPI.LoadTuple(tuple);
            HDevEngine.HCkE(HalconAPI.DestroyTuple(tuple));
            return htuple;
        }

        /// <summary>Unloads a previously loaded procedure</summary>
        /// <param name="name">The name of the procedure to unload</param>
        public void UnloadProcedure(string name)
        {
            HDevEngine.HCkE(EngineAPI.UnloadProcedure(this.engine, name));
            GC.KeepAlive((object)this);
        }

        /// <summary>Unloads all previously loaded procedure</summary>
        public void UnloadAllProcedures()
        {
            HDevEngine.HCkE(EngineAPI.UnloadAllProcedures(this.engine));
            GC.KeepAlive((object)this);
        }

        /// <summary>Returns the names of all global iconic variables</summary>
        public HTuple GetGlobalIconicVarNames()
        {
            IntPtr tuple;
            HDevEngine.HCkE(HalconAPI.CreateTuple(out tuple));
            HDevEngine.HCkE(EngineAPI.GetGlobalIconicVarNames(this.engine, tuple));
            GC.KeepAlive((object)this);
            HTuple htuple = HalconAPI.LoadTuple(tuple);
            HDevEngine.HCkE(HalconAPI.DestroyTuple(tuple));
            return htuple;
        }

        /// <summary>Returns the names of all global control variables</summary>
        public HTuple GetGlobalCtrlVarNames()
        {
            IntPtr tuple;
            HDevEngine.HCkE(HalconAPI.CreateTuple(out tuple));
            HDevEngine.HCkE(EngineAPI.GetGlobalCtrlVarNames(this.engine, tuple));
            GC.KeepAlive((object)this);
            HTuple htuple = HalconAPI.LoadTuple(tuple);
            HDevEngine.HCkE(HalconAPI.DestroyTuple(tuple));
            return htuple;
        }

        /// <summary>Gets the dimension of a global control variable</summary>
        public int GetGlobalIconicVarDimension(string name)
        {
            int dimension;
            HDevEngine.HCkE(EngineAPI.GetGlobalIconicVarDimension(this.engine, name, out dimension));
            GC.KeepAlive((object)this);
            return dimension;
        }

        /// <summary>Gets the dimension of a global control variable</summary>
        public int GetGlobalCtrlVarDimension(string name)
        {
            int dimension;
            HDevEngine.HCkE(EngineAPI.GetGlobalCtrlVarDimension(this.engine, name, out dimension));
            GC.KeepAlive((object)this);
            return dimension;
        }

        /// <summary>Sets the value of a global control variable</summary>
        public void SetGlobalCtrlVarTuple(string name, HTuple tuple)
        {
            IntPtr tuple1;
            HDevEngine.HCkE(HalconAPI.CreateTuple(out tuple1));
            HalconAPI.StoreTuple(tuple1, tuple);
            HDevEngine.HCkE(EngineAPI.SetGlobalCtrlVarTuple(this.engine, name, tuple1));
            GC.KeepAlive((object)this);
            HDevEngine.HCkE(HalconAPI.DestroyTuple(tuple1));
        }

        /// <summary>Sets the value of a global control variable</summary>
        public void SetGlobalCtrlVarVector(string name, HTupleVector vector)
        {
            IntPtr vectorHandle;
            HDevEngine.HCkE(EngineAPI.CreateTupleVector(vector, out vectorHandle));
            HDevEngine.HCkE(EngineAPI.SetGlobalCtrlVarVector(this.engine, name, vectorHandle));
            GC.KeepAlive((object)this);
            HDevEngine.HCkE(EngineAPI.DestroyTupleVector(vectorHandle));
        }

        /// <summary>Sets the value of a global iconic variable</summary>
        public void SetGlobalIconicVarObject(string name, HObject iconic)
        {
            HDevEngine.HCkE(EngineAPI.SetGlobalIconicVarObject(this.engine, name, iconic.Key));
            GC.KeepAlive((object)iconic);
            GC.KeepAlive((object)this);
        }

        /// <summary>Sets the value of a global iconic variable</summary>
        public void SetGlobalIconicVarVector(string name, HObjectVector vector)
        {
            IntPtr vectorHandle;
            HDevEngine.HCkE(EngineAPI.CreateObjectVector(vector, out vectorHandle));
            HDevEngine.HCkE(EngineAPI.SetGlobalIconicVarVector(this.engine, name, vectorHandle));
            GC.KeepAlive((object)this);
            HDevEngine.HCkE(EngineAPI.DestroyObjectVector(vectorHandle));
        }

        /// <summary>Gets the value of a global control variable</summary>
        public HTuple GetGlobalCtrlVarTuple(string name)
        {
            IntPtr tuple;
            HDevEngine.HCkE(HalconAPI.CreateTuple(out tuple));
            HDevEngine.HCkE(EngineAPI.GetGlobalCtrlVarTuple(this.engine, name, tuple));
            GC.KeepAlive((object)this);
            HTuple htuple = HalconAPI.LoadTuple(tuple);
            HDevEngine.HCkE(HalconAPI.DestroyTuple(tuple));
            return htuple;
        }

        /// <summary>Gets the value of a global control variable</summary>
        public HTupleVector GetGlobalCtrlVarVector(string name)
        {
            IntPtr vector;
            HDevEngine.HCkE(EngineAPI.GetGlobalCtrlVarVector(this.engine, name, out vector));
            GC.KeepAlive((object)this);
            return EngineAPI.GetAndDestroyTupleVector(vector);
        }

        /// <summary>Gets the value of a global iconic variable</summary>
        public HObject GetGlobalIconicVarObject(string name)
        {
            IntPtr key;
            HDevEngine.HCkE(EngineAPI.GetGlobalIconicVarObject(this.engine, name, out key));
            GC.KeepAlive((object)this);
            return new HObject(key, false);
        }

        /// <summary>Gets the value of a global iconic variable</summary>
        public HObjectVector GetGlobalIconicVarVector(string name)
        {
            IntPtr vector;
            HDevEngine.HCkE(EngineAPI.GetGlobalIconicVarVector(this.engine, name, out vector));
            GC.KeepAlive((object)this);
            return EngineAPI.GetAndDestroyObjectVector(vector);
        }

        /// <summary>Gets the value of a global iconic image variable</summary>
        public HImage GetGlobalIconicVarImage(string name)
        {
            IntPtr key;
            HDevEngine.HCkE(EngineAPI.GetGlobalIconicVarObject(this.engine, name, out key));
            GC.KeepAlive((object)this);
            EngineAPI.AssertObjectClass(key, "image", "main");
            return new HImage(key, false);
        }

        /// <summary>Gets the value of a global iconic region variable</summary>
        public HRegion GetGlobalIconicVarRegion(string name)
        {
            IntPtr key;
            HDevEngine.HCkE(EngineAPI.GetGlobalIconicVarObject(this.engine, name, out key));
            GC.KeepAlive((object)this);
            EngineAPI.AssertObjectClass(key, "region", "main");
            return new HRegion(key, false);
        }

        /// <summary>Gets the value of a global iconic XLD variable</summary>
        public HXLD GetGlobalIconicVarXld(string name)
        {
            IntPtr key;
            HDevEngine.HCkE(EngineAPI.GetGlobalIconicVarObject(this.engine, name, out key));
            GC.KeepAlive((object)this);
            EngineAPI.AssertObjectClass(key, "xld", "main");
            return new HXLD(key, false);
        }

        /// <summary>Registers your implementation of visualization operators</summary>
        /// <param name="implementation">
        ///   An object implementing the IHDevOperators interface
        /// </param>
        public void SetHDevOperators(IHDevOperators implementation)
        {
            if (implementation == null)
            {
                HDevEngine.HCkE(EngineAPI.SetHDevOperatorImpl(this.engine, IntPtr.Zero));
                GC.KeepAlive((object)this);
                this.operatorWrapper = (HDevOperatorWrapper)null;
            }
            else
            {
                this.operatorWrapper = new HDevOperatorWrapper(this, implementation);
                HDevEngine.HCkE(EngineAPI.SetHDevOperatorImpl(this.engine, this.operatorWrapper.ImplementationHandle));
                GC.KeepAlive((object)this);
            }
        }

        internal static void HCkE(int err)
        {
            EngineAPI.HCkE(err);
        }

        ~HDevEngine()
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
            if (this.engine != IntPtr.Zero)
            {
                EngineAPI.DestroyEngine(this.engine);
                this.engine = IntPtr.Zero;
            }
            GC.SuppressFinalize((object)this);
            GC.KeepAlive((object)this);
        }
    }
}
