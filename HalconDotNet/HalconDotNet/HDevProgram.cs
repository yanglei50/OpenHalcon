using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalconDotNet
{
    /// <summary>
    /// Encapsulates a loaded HDevelop program
    /// </summary>
    public class HDevProgram : IDisposable
    {
        private IntPtr program = IntPtr.Zero;
        private string name = "";
        private HTuple varNamesIconic = new HTuple();
        private HTuple varNamesCtrl = new HTuple();
        private HTuple varDimsIconic = new HTuple();
        private HTuple varDimsCtrl = new HTuple();
        private bool loaded;

        internal IntPtr Handle
        {
            get
            {
                return this.program;
            }
        }

        /// <summary>
        /// The name of the program
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Creates an empty program instance
        /// </summary>
        public HDevProgram()
        {
            HDevProgram.HCkE(EngineAPI.CreateProgram(out this.program));
            GC.KeepAlive((object)this);
        }

        /// <summary>
        /// Loads an HDevelop program
        /// </summary>
        public HDevProgram(string fileName)
          : this()
        {
            this.LoadProgram(fileName);
        }

        ~HDevProgram()
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

        /// <summary>
        /// Loads an HDevelop script
        /// </summary>
        /// 
        /// <remarks>
        /// You can use this to exceute the program or local procedures.
        /// 
        /// </remarks>
        /// <param name="fileName">Path and file name of the HDevelop script</param>
        public void LoadProgram(string fileName)
        {
            HDevProgram.HCkE(EngineAPI.LoadProgram(this.program, fileName));
            EngineAPI.GetProgramInfo(this.program, out this.name, out this.loaded, out this.varNamesIconic, out this.varNamesCtrl, out this.varDimsIconic, out this.varDimsCtrl);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        /// Creates a program call for this program
        /// </summary>
        public HDevProgramCall CreateCall()
        {
            return new HDevProgramCall(this);
        }

        /// <summary>
        /// Create and execute a program call for this program
        /// </summary>
        public HDevProgramCall Execute()
        {
            HDevProgramCall hdevProgramCall = new HDevProgramCall(this);
            hdevProgramCall.Execute();
            return hdevProgramCall;
        }

        /// <summary>
        /// Check the load state of the program
        /// </summary>
        public bool IsLoaded()
        {
            return this.loaded;
        }

        /// <summary>
        /// Returns true if this class has not yet been disposed
        /// </summary>
        public bool IsInitialized()
        {
            return this.program != IntPtr.Zero;
        }

        /// <summary>
        /// Gets the variable names used for iconic objects
        /// </summary>
        public HTuple GetIconicVarNames()
        {
            return this.varNamesIconic;
        }

        /// <summary>
        /// Gets the variable names used for control values
        /// </summary>
        public HTuple GetCtrlVarNames()
        {
            return this.varNamesCtrl;
        }

        /// <summary>
        /// Gets the variable dimensions used for iconic objects
        /// </summary>
        public HTuple GetIconicVarDimensions()
        {
            return this.varDimsIconic;
        }

        /// <summary>
        /// Gets the variable dimensions used for control values
        /// </summary>
        public HTuple GetCtrlVarDimensions()
        {
            return this.varDimsCtrl;
        }

        /// <summary>
        /// Gets the number of variables used for iconic objects.
        ///               Note that variables are numbered from 1 to count.
        /// 
        /// </summary>
        public int GetIconicVarCount()
        {
            return this.varNamesIconic.Length;
        }

        /// <summary>
        /// Gets the number of variables used for control values.
        ///               Note that variables are numbered from 1 to count.
        /// 
        /// </summary>
        public int GetCtrlVarCount()
        {
            return this.varNamesCtrl.Length;
        }

        /// <summary>
        /// Gets the name of a specific iconic variable
        /// </summary>
        public string GetIconicVarName(int index)
        {
            if (index < 1 || index > this.varNamesIconic.Length)
                HDevEngineException.ThrowGeneric("Bad index for GetIconicVarName");
            return this.varNamesIconic.SArr[index - 1];
        }

        /// <summary>
        /// Gets the name of a specific control variable
        /// </summary>
        public string GetCtrlVarName(int index)
        {
            if (index < 1 || index > this.varNamesCtrl.Length)
                HDevEngineException.ThrowGeneric("Bad index for GetCtrlVarName");
            return this.varNamesCtrl.SArr[index - 1];
        }

        /// <summary>
        /// Gets the dimension of a specific iconic variable
        /// </summary>
        public int GetIconicVarDimension(int index)
        {
            if (index < 1 || index > this.varDimsIconic.Length)
                HDevEngineException.ThrowGeneric("Bad index for GetIconicVarDimension");
            return (int)this.varDimsIconic[index - 1];
        }

        /// <summary>
        /// Gets the dimension of a specific control variable
        /// </summary>
        public int GetCtrlVarDimension(int index)
        {
            if (index < 1 || index > this.varDimsCtrl.Length)
                HDevEngineException.ThrowGeneric("Bad index for GetCtrlVarDimension");
            return (int)this.varDimsCtrl[index - 1];
        }

        /// <summary>
        /// Returns the names of used local and external procedures
        /// </summary>
        public HTuple GetUsedProcedureNames()
        {
            IntPtr tuple;
            HDevProgram.HCkE(HalconAPI.CreateTuple(out tuple));
            HDevProgram.HCkE(EngineAPI.GetUsedProcedureNamesForProgram(this.program, tuple));
            GC.KeepAlive((object)this);
            HTuple htuple = HalconAPI.LoadTuple(tuple);
            HDevProgram.HCkE(HalconAPI.DestroyTuple(tuple));
            return htuple;
        }

        /// <summary>
        /// Compile all procedures that are used by the program and that
        ///             can be compiled with a just-in-time compiler.
        ///             The method returns true when all used procedures could be compiled by
        ///             the just-in-time compiler.
        ///             Procedures that could not be compiled are called normally by the
        ///             HDevEngine interpreter.
        ///             To check which procedure could not be compiled and what the reason is
        ///             for that start HDevelop and check there the compilation states.
        /// 
        /// </summary>
        public bool CompileUsedProcedures()
        {
            bool ret;
            HDevProgram.HCkE(EngineAPI.CompileUsedProceduresForProgram(this.program, out ret));
            GC.KeepAlive((object)this);
            return ret;
        }

        /// <summary>
        /// Returns the names of all local procedures
        /// </summary>
        public HTuple GetLocalProcedureNames()
        {
            IntPtr tuple;
            HDevProgram.HCkE(HalconAPI.CreateTuple(out tuple));
            HDevProgram.HCkE(EngineAPI.GetLocalProcedureNames(this.program, tuple));
            GC.KeepAlive((object)this);
            HTuple htuple = HalconAPI.LoadTuple(tuple);
            HDevProgram.HCkE(HalconAPI.DestroyTuple(tuple));
            return htuple;
        }

        internal static void HCkE(int err)
        {
            EngineAPI.HCkE(err);
        }

        void IDisposable.Dispose()
        {
            this.Dispose();
        }

        /// <summary>
        /// Releases the resources used by this engine
        /// </summary>
        public virtual void Dispose()
        {
            if (this.program != IntPtr.Zero)
            {
                EngineAPI.DestroyProgram(this.program);
                this.program = IntPtr.Zero;
                this.loaded = false;
            }
            GC.SuppressFinalize((object)this);
            GC.KeepAlive((object)this);
        }
    }
}
