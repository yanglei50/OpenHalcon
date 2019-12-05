// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HDevProcedure
// Assembly: hdevenginedotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 1BC5D9BA-5A99-483F-ACA6-A4C6BCF4A886
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\hdevenginedotnetxl.dll

using System;

namespace HalconDotNet
{
    /// <summary>Encapsulates a local or external procedure</summary>
    public class HDevProcedure : IDisposable
    {
        private IntPtr procedure = IntPtr.Zero;
        private string name = "";
        private string shortDescription = "";
        private HTuple parNamesIconicInput = new HTuple();
        private HTuple parNamesIconicOutput = new HTuple();
        private HTuple parNamesCtrlInput = new HTuple();
        private HTuple parNamesCtrlOutput = new HTuple();
        private HTuple parDimensionsIconicInput = new HTuple();
        private HTuple parDimensionsIconicOutput = new HTuple();
        private HTuple parDimensionsCtrlInput = new HTuple();
        private HTuple parDimensionsCtrlOutput = new HTuple();
        private bool loaded;

        internal IntPtr Handle
        {
            get
            {
                return this.procedure;
            }
        }

        /// <summary>Creates an empty procedure instance</summary>
        public HDevProcedure()
        {
            HDevProcedure.HCkE(EngineAPI.CreateProcedure(out this.procedure));
            GC.KeepAlive((object)this);
        }

        /// <summary>Loads an external procedure</summary>
        public HDevProcedure(string procedureName)
          : this()
        {
            this.LoadProcedure(procedureName);
        }

        /// <summary>Loads a local procedure</summary>
        public HDevProcedure(string programName, string procedureName)
          : this()
        {
            this.LoadProcedure(programName, procedureName);
        }

        /// <summary>Loads a local procedure</summary>
        public HDevProcedure(HDevProgram program, string procedureName)
          : this()
        {
            this.LoadProcedure(program, procedureName);
        }

        internal void UpdateProcedureInfo()
        {
            EngineAPI.GetProcedureInfo(this.procedure, out this.name, out this.shortDescription, out this.loaded, out this.parNamesIconicInput, out this.parNamesIconicOutput, out this.parNamesCtrlInput, out this.parNamesCtrlOutput, out this.parDimensionsIconicInput, out this.parDimensionsIconicOutput, out this.parDimensionsCtrlInput, out this.parDimensionsCtrlOutput);
            GC.KeepAlive((object)this);
        }

        /// <summary>Loads an external procedure</summary>
        public void LoadProcedure(string procedureName)
        {
            HDevProcedure.HCkE(EngineAPI.LoadProcedure(this.procedure, procedureName));
            GC.KeepAlive((object)this);
            this.UpdateProcedureInfo();
        }

        /// <summary>Loads a local procedure</summary>
        public void LoadProcedure(string programName, string procedureName)
        {
            HDevProcedure.HCkE(EngineAPI.LoadProcedure(this.procedure, programName, procedureName));
            GC.KeepAlive((object)this);
            this.UpdateProcedureInfo();
        }

        /// <summary>Loads a local procedure</summary>
        public void LoadProcedure(HDevProgram program, string procedureName)
        {
            if (program.Handle == IntPtr.Zero)
                HDevEngineException.ThrowGeneric("Uninitialized program while creating a local procedure call");
            HDevProcedure.HCkE(EngineAPI.LoadProcedure(this.procedure, program.Handle, procedureName));
            GC.KeepAlive((object)this);
            this.UpdateProcedureInfo();
        }

        /// <summary>Creates a procedure call for this procedure</summary>
        public HDevProcedureCall CreateCall()
        {
            return new HDevProcedureCall(this);
        }

        /// <summary>Create and execute a procedure call for this procedure</summary>
        public HDevProcedureCall Execute()
        {
            HDevProcedureCall hdevProcedureCall = new HDevProcedureCall(this);
            hdevProcedureCall.Execute();
            return hdevProcedureCall;
        }

        /// <summary>The name of the procedure</summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>The short description of the procedure</summary>
        public string ShortDescription
        {
            get
            {
                return this.shortDescription;
            }
        }

        /// <summary>Check the load state of the procedure</summary>
        public bool IsLoaded()
        {
            return this.loaded;
        }

        /// <summary>Returns true if this class has not yet been disposed</summary>
        public bool IsInitialized()
        {
            return this.procedure != IntPtr.Zero;
        }

        /// <summary>Gets the names of the iconic input parameters</summary>
        public HTuple GetInputIconicParamNames()
        {
            return this.parNamesIconicInput;
        }

        /// <summary>Gets the names of the iconic output parameters</summary>
        public HTuple GetOutputIconicParamNames()
        {
            return this.parNamesIconicOutput;
        }

        /// <summary>Gets the names of the input control parameters</summary>
        public HTuple GetInputCtrlParamNames()
        {
            return this.parNamesCtrlInput;
        }

        /// <summary>Gets the names of the output control parameters</summary>
        public HTuple GetOutputCtrlParamNames()
        {
            return this.parNamesCtrlOutput;
        }

        /// <summary>Gets the dimensions of the iconic input parameters</summary>
        public HTuple GetInputIconicParamDimensions()
        {
            return this.parDimensionsIconicInput;
        }

        /// <summary>Gets the dimensions of the iconic output parameters</summary>
        public HTuple GetOutputIconicParamDimensions()
        {
            return this.parDimensionsIconicOutput;
        }

        /// <summary>Gets the dimensions of the input control parameters</summary>
        public HTuple GetInputCtrlParamDimensions()
        {
            return this.parDimensionsCtrlInput;
        }

        /// <summary>Gets the dimensions of the output control parameters</summary>
        public HTuple GetOutputCtrlParamDimensions()
        {
            return this.parDimensionsCtrlOutput;
        }

        /// <summary>
        ///   Gets the number of parameters used for iconic input objects.
        ///   Note that parameters are numbered from 1 to count.
        /// </summary>
        public int GetInputIconicParamCount()
        {
            return this.parNamesIconicInput.Length;
        }

        /// <summary>
        ///   Gets the number of parameters used for iconic output objects.
        ///   Note that parameters are numbered from 1 to count.
        /// </summary>
        public int GetOutputIconicParamCount()
        {
            return this.parNamesIconicOutput.Length;
        }

        /// <summary>
        ///   Gets the number of parameters used for input control values.
        ///   Note that parameters are numbered from 1 to count.
        /// </summary>
        public int GetInputCtrlParamCount()
        {
            return this.parNamesCtrlInput.Length;
        }

        /// <summary>
        ///   Gets the number of parameters used for output control values.
        ///   Note that parameters are numbered from 1 to count.
        /// </summary>
        public int GetOutputCtrlParamCount()
        {
            return this.parNamesCtrlOutput.Length;
        }

        /// <summary>Gets the name of a specific iconic input parameter</summary>
        public string GetInputIconicParamName(int index)
        {
            if (index < 1 || index > this.parNamesIconicInput.Length)
                HDevEngineException.ThrowGeneric("Bad index for GetInputIconicParamName");
            return this.parNamesIconicInput.SArr[index - 1];
        }

        /// <summary>Gets the name of a specific iconic output parameter</summary>
        public string GetOutputIconicParamName(int index)
        {
            if (index < 1 || index > this.parNamesIconicOutput.Length)
                HDevEngineException.ThrowGeneric("Bad index for GetOutputIconicParamName");
            return this.parNamesIconicOutput.SArr[index - 1];
        }

        /// <summary>Gets the name of a specific input control parameter</summary>
        public string GetInputCtrlParamName(int index)
        {
            if (index < 1 || index > this.parNamesCtrlInput.Length)
                HDevEngineException.ThrowGeneric("Bad index for GetInputCtrlParamName");
            return this.parNamesCtrlInput.SArr[index - 1];
        }

        /// <summary>Gets the name of a specific output control parameter</summary>
        public string GetOutputCtrlParamName(int index)
        {
            if (index < 1 || index > this.parNamesCtrlOutput.Length)
                HDevEngineException.ThrowGeneric("Bad index for GetOutputCtrlParamName");
            return this.parNamesCtrlOutput.SArr[index - 1];
        }

        /// <summary>Gets the dimension of a specific
        /// iconic input parameter</summary>
        public int GetInputIconicParamDimension(int index)
        {
            if (index < 1 || index > this.parDimensionsIconicInput.Length)
                HDevEngineException.ThrowGeneric("Bad index for GetInputIconicParamDimension");
            return (int)this.parDimensionsIconicInput[index - 1];
        }

        /// <summary>Gets the dimension of a specific
        /// iconic output parameter</summary>
        public int GetOutputIconicParamDimension(int index)
        {
            if (index < 1 || index > this.parDimensionsIconicOutput.Length)
                HDevEngineException.ThrowGeneric("Bad index for GetOutputIconicParamDimension");
            return (int)this.parDimensionsIconicOutput[index - 1];
        }

        /// <summary>Gets the dimension of a specific
        /// input control parameter</summary>
        public int GetInputCtrlParamDimension(int index)
        {
            if (index < 1 || index > this.parDimensionsCtrlInput.Length)
                HDevEngineException.ThrowGeneric("Bad index for GetInputCtrlParamDimension");
            return (int)this.parDimensionsCtrlInput[index - 1];
        }

        /// <summary>Gets the dimension of a specific
        /// output control parameter</summary>
        public int GetOutputCtrlParamDimension(int index)
        {
            if (index < 1 || index > this.parDimensionsCtrlOutput.Length)
                HDevEngineException.ThrowGeneric("Bad index for GetOutputCtrlParamDimension");
            return (int)this.parDimensionsCtrlOutput[index - 1];
        }

        /// <summary>Returns the names of all refered procedures</summary>
        public HTuple GetUsedProcedureNames()
        {
            IntPtr tuple;
            HDevProcedure.HCkE(HalconAPI.CreateTuple(out tuple));
            HDevProcedure.HCkE(EngineAPI.GetUsedProcedureNamesForProcedure(this.procedure, tuple));
            GC.KeepAlive((object)this);
            HTuple htuple = HalconAPI.LoadTuple(tuple);
            HDevProcedure.HCkE(HalconAPI.DestroyTuple(tuple));
            return htuple;
        }

        /// <summary>Compile all procedures that are used by the program and that
        /// can be compiled with a just-in-time compiler.
        /// The method returns true when all used procedures could be compiled by
        /// the just-in-time compiler.
        /// Procedures that could not be compiled are called normally by the
        /// HDevEngine interpreter.
        /// To check which procedure could not be compiled and what the reason is
        /// for that start HDevelop and check there the compilation states.
        /// </summary>
        public bool CompileUsedProcedures()
        {
            bool ret;
            HDevProcedure.HCkE(EngineAPI.CompileUsedProceduresForProcedure(this.procedure, out ret));
            GC.KeepAlive((object)this);
            return ret;
        }

        /// <summary>Returns the info of the refered procedure docu slot</summary>
        public HTuple GetInfo(string slot)
        {
            IntPtr tuple;
            HDevProcedure.HCkE(HalconAPI.CreateTuple(out tuple));
            HDevProcedure.HCkE(EngineAPI.GetProcInfo(this.procedure, slot, tuple));
            GC.KeepAlive((object)this);
            HTuple htuple = HalconAPI.LoadTuple(tuple);
            HDevProcedure.HCkE(HalconAPI.DestroyTuple(tuple));
            return htuple;
        }

        /// <summary>Returns the info of the refered parameter docu slot</summary>
        public HTuple GetParamInfo(string parName, string slot)
        {
            IntPtr tuple;
            HDevProcedure.HCkE(HalconAPI.CreateTuple(out tuple));
            HDevProcedure.HCkE(EngineAPI.GetParamInfo(this.procedure, parName, slot, tuple));
            GC.KeepAlive((object)this);
            HTuple htuple = HalconAPI.LoadTuple(tuple);
            HDevProcedure.HCkE(HalconAPI.DestroyTuple(tuple));
            return htuple;
        }

        /// <summary>Returns the info of the refered parameter docu slot</summary>
        public HTuple GetInputIconicParamInfo(int parIdx, string slot)
        {
            IntPtr tuple;
            HDevProcedure.HCkE(HalconAPI.CreateTuple(out tuple));
            HDevProcedure.HCkE(EngineAPI.GetInputIconicParamInfo(this.procedure, parIdx, slot, tuple));
            GC.KeepAlive((object)this);
            HTuple htuple = HalconAPI.LoadTuple(tuple);
            HDevProcedure.HCkE(HalconAPI.DestroyTuple(tuple));
            return htuple;
        }

        /// <summary>Returns the info of the refered parameter docu slot</summary>
        public HTuple GetOutputIconicParamInfo(int parIdx, string slot)
        {
            IntPtr tuple;
            HDevProcedure.HCkE(HalconAPI.CreateTuple(out tuple));
            HDevProcedure.HCkE(EngineAPI.GetOutputIconicParamInfo(this.procedure, parIdx, slot, tuple));
            GC.KeepAlive((object)this);
            HTuple htuple = HalconAPI.LoadTuple(tuple);
            HDevProcedure.HCkE(HalconAPI.DestroyTuple(tuple));
            return htuple;
        }

        /// <summary>Returns the info of the refered parameter docu slot</summary>
        public HTuple GetInputCtrlParamInfo(int parIdx, string slot)
        {
            IntPtr tuple;
            HDevProcedure.HCkE(HalconAPI.CreateTuple(out tuple));
            HDevProcedure.HCkE(EngineAPI.GetInputCtrlParamInfo(this.procedure, parIdx, slot, tuple));
            GC.KeepAlive((object)this);
            HTuple htuple = HalconAPI.LoadTuple(tuple);
            HDevProcedure.HCkE(HalconAPI.DestroyTuple(tuple));
            return htuple;
        }

        /// <summary>Returns the info of the refered parameter docu slot</summary>
        public HTuple GetOutputCtrlParamInfo(int parIdx, string slot)
        {
            IntPtr tuple;
            HDevProcedure.HCkE(HalconAPI.CreateTuple(out tuple));
            HDevProcedure.HCkE(EngineAPI.GetOutputCtrlParamInfo(this.procedure, parIdx, slot, tuple));
            GC.KeepAlive((object)this);
            HTuple htuple = HalconAPI.LoadTuple(tuple);
            HDevProcedure.HCkE(HalconAPI.DestroyTuple(tuple));
            return htuple;
        }

        /// <summary>Returns all possible slots of the procedure docu</summary>
        public HTuple QueryInfo()
        {
            IntPtr tuple;
            HDevProcedure.HCkE(HalconAPI.CreateTuple(out tuple));
            HDevProcedure.HCkE(EngineAPI.QueryInfo(this.procedure, tuple));
            GC.KeepAlive((object)this);
            HTuple htuple = HalconAPI.LoadTuple(tuple);
            HDevProcedure.HCkE(HalconAPI.DestroyTuple(tuple));
            return htuple;
        }

        /// <summary>Returns all possible slots of the parameter docu</summary>
        public HTuple QueryParamInfo()
        {
            IntPtr tuple;
            HDevProcedure.HCkE(HalconAPI.CreateTuple(out tuple));
            HDevProcedure.HCkE(EngineAPI.QueryParamInfo(this.procedure, tuple));
            GC.KeepAlive((object)this);
            HTuple htuple = HalconAPI.LoadTuple(tuple);
            HDevProcedure.HCkE(HalconAPI.DestroyTuple(tuple));
            return htuple;
        }

        internal static void HCkE(int err)
        {
            EngineAPI.HCkE(err);
        }

        ~HDevProcedure()
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
                //base.Finalize();
            }
        }

        void IDisposable.Dispose()
        {
            this.Dispose();
        }

        /// <summary>Releases the resources used by this engine</summary>
        public virtual void Dispose()
        {
            if (this.procedure != IntPtr.Zero)
            {
                EngineAPI.DestroyProcedure(this.procedure);
                this.procedure = IntPtr.Zero;
                this.loaded = false;
            }
            GC.SuppressFinalize((object)this);
            GC.KeepAlive((object)this);
        }
    }
}
