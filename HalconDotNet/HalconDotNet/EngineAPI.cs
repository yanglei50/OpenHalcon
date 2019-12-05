// Decompiled with JetBrains decompiler
// Type: HalconDotNet.EngineAPI
// Assembly: hdevenginedotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 1BC5D9BA-5A99-483F-ACA6-A4C6BCF4A886
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\hdevenginedotnetxl.dll

using System;
using System.Runtime.InteropServices;
using System.Security;

namespace HalconDotNet
{
    /// <summary>Communication with hdevengine.dll</summary>
    [SuppressUnmanagedCodeSecurity]
    public class EngineAPI
    {
        private const string EngineDLL = "hdevenginecppxl";
        private const CallingConvention EngineCall = CallingConvention.Cdecl;
        internal const int H_MSG_OK = 2;
        internal const int H_MSG_TRUE = 2;
        internal const int H_MSG_FALSE = 3;
        internal const int H_MSG_VOID = 4;
        internal const int H_MSG_FAIL = 5;

        [DllImport("hdevenginecppxl", EntryPoint = "HCenCreateEngine", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CreateEngine(out IntPtr engine);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenDestroyEngine", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DestroyEngine(IntPtr engine);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenSetEngineAttribute", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetEngineAttribute(IntPtr engine, string name, IntPtr tuple);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetEngineAttribute", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetEngineAttribute(IntPtr engine, string name, IntPtr tuple);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenStartDebugServer", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int StartDebugServer(IntPtr engine);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenStopDebugServer", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int StopDebugServer(IntPtr engine);

        [DllImport("hdevenginecppxl", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int HCenSetProcedurePath(IntPtr engine, IntPtr path);

        internal static int SetProcedurePath(IntPtr engine, string path)
        {
            IntPtr hglobalUtf8Encoding = HalconAPI.ToHGlobalUtf8Encoding(path);
            int num = EngineAPI.HCenSetProcedurePath(engine, hglobalUtf8Encoding);
            Marshal.FreeHGlobal(hglobalUtf8Encoding);
            return num;
        }

        [DllImport("hdevenginecppxl", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int HCenAddProcedurePath(IntPtr engine, IntPtr path);

        internal static int AddProcedurePath(IntPtr engine, string path)
        {
            IntPtr hglobalUtf8Encoding = HalconAPI.ToHGlobalUtf8Encoding(path);
            int num = EngineAPI.HCenAddProcedurePath(engine, hglobalUtf8Encoding);
            Marshal.FreeHGlobal(hglobalUtf8Encoding);
            return num;
        }

        [DllImport("hdevenginecppxl", EntryPoint = "HCenSetHDevOperatorImpl", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetHDevOperatorImpl(IntPtr engine, IntPtr implementation);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetProcedureNames", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetProcedureNames(IntPtr engine, IntPtr tuple);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetLoadedProcedureNames", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetLoadedProcedureNames(IntPtr engine, IntPtr tuple);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenUnloadProcedure", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int UnloadProcedure(IntPtr engine, string name);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenUnloadAllProcedures", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int UnloadAllProcedures(IntPtr engine);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetGlobalIconicVarNames", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetGlobalIconicVarNames(IntPtr engine, IntPtr tuple);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetGlobalCtrlVarNames", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetGlobalCtrlVarNames(IntPtr engine, IntPtr tuple);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetGlobalCtrlVarDimension", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetGlobalCtrlVarDimension(
          IntPtr engine,
          string name,
          out int dimension);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetGlobalIconicVarDimension", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetGlobalIconicVarDimension(
          IntPtr engine,
          string name,
          out int dimension);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetGlobalCtrlVarTuple", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetGlobalCtrlVarTuple(IntPtr engine, string name, IntPtr tuple);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetGlobalCtrlVarVector", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetGlobalCtrlVarVector(
          IntPtr engine,
          string name,
          out IntPtr vector);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetGlobalIconicVarObject", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetGlobalIconicVarObject(IntPtr engine, string name, out IntPtr key);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetGlobalIconicVarVector", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetGlobalIconicVarVector(
          IntPtr engine,
          string name,
          out IntPtr vector);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenSetGlobalCtrlVarTuple", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetGlobalCtrlVarTuple(IntPtr engine, string name, IntPtr tuple);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenSetGlobalCtrlVarVector", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetGlobalCtrlVarVector(IntPtr engine, string name, IntPtr vector);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenSetGlobalIconicVarObject", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetGlobalIconicVarObject(IntPtr engine, string name, IntPtr key);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenSetGlobalIconicVarVector", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetGlobalIconicVarVector(IntPtr engine, string name, IntPtr vector);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenCreateProgram", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CreateProgram(out IntPtr program);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenDestroyProgram", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DestroyProgram(IntPtr program);

        [DllImport("hdevenginecppxl", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int HCenLoadProgram(IntPtr program, IntPtr fileName);

        internal static int LoadProgram(IntPtr program, string fileName)
        {
            IntPtr hglobalUtf8Encoding = HalconAPI.ToHGlobalUtf8Encoding(fileName);
            int num = EngineAPI.HCenLoadProgram(program, hglobalUtf8Encoding);
            Marshal.FreeHGlobal(hglobalUtf8Encoding);
            return num;
        }

        [DllImport("hdevenginecppxl", CallingConvention = CallingConvention.Cdecl)]
        private static extern int HCenGetProgramInfo(
          IntPtr program,
          out IntPtr name,
          out bool loaded,
          IntPtr varNamesIconic,
          IntPtr varNamesCtrl,
          IntPtr varDimsIconic,
          IntPtr varDimsCtrl);

        internal static void GetProgramInfo(
          IntPtr program,
          out string name,
          out bool loaded,
          out HTuple varNamesIconic,
          out HTuple varNamesCtrl,
          out HTuple varDimsIconic,
          out HTuple varDimsCtrl)
        {
            IntPtr tuple1;
            EngineAPI.HCkE(HalconAPI.CreateTuple(out tuple1));
            IntPtr tuple2;
            EngineAPI.HCkE(HalconAPI.CreateTuple(out tuple2));
            IntPtr tuple3;
            EngineAPI.HCkE(HalconAPI.CreateTuple(out tuple3));
            IntPtr tuple4;
            EngineAPI.HCkE(HalconAPI.CreateTuple(out tuple4));
            IntPtr name1;
            EngineAPI.HCkE(EngineAPI.HCenGetProgramInfo(program, out name1, out loaded, tuple1, tuple2, tuple3, tuple4));
            name = Marshal.PtrToStringAnsi(name1);
            varNamesIconic = HalconAPI.LoadTuple(tuple1);
            varNamesCtrl = HalconAPI.LoadTuple(tuple2);
            varDimsIconic = HalconAPI.LoadTuple(tuple3);
            varDimsCtrl = HalconAPI.LoadTuple(tuple4);
            EngineAPI.HCkE(HalconAPI.DestroyTuple(tuple1));
            EngineAPI.HCkE(HalconAPI.DestroyTuple(tuple2));
            EngineAPI.HCkE(HalconAPI.DestroyTuple(tuple3));
            EngineAPI.HCkE(HalconAPI.DestroyTuple(tuple4));
        }

        //public int CreateTupleVector(HTupleVector vector, out IntPtr vectorHandle)
        //{
        //    throw new NotImplementedException();
        //}

        [DllImport("hdevenginecppxl", EntryPoint = "HCenProgGetUsedProcedureNames", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetUsedProcedureNamesForProgram(IntPtr program, IntPtr tuple);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenProgGetLocalProcedureNames", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetLocalProcedureNames(IntPtr program, IntPtr tuple);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenProgCompileUsedProcedures", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CompileUsedProceduresForProgram(IntPtr program, out bool ret);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenCreateProgramCall", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CreateProgramCall(IntPtr program, out IntPtr call);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenDestroyProgramCall", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DestroyProgramCall(IntPtr call);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenExecuteProgramCall", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ExecuteProgramCall(IntPtr call);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenSetWaitForDebugConnectionProgramCall", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetWaitForDebugConnectionProgramCall(IntPtr call, bool wait_once);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenResetProgramCall", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ResetProgramCall(IntPtr call);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetCtrlVarTupleIndex", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetCtrlVarTuple(IntPtr call, int index, out IntPtr tuple);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetCtrlVarVectorIndex", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetCtrlVarVector(IntPtr call, int index, out IntPtr vector);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetCtrlVarTupleName", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetCtrlVarTuple(IntPtr call, string name, out IntPtr tuple);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetCtrlVarVectorName", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetCtrlVarVector(IntPtr call, string name, out IntPtr vector);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetIconicVarObjectIndex", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetIconicVarObject(IntPtr call, int index, out IntPtr key);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetIconicVarVectorIndex", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetIconicVarVector(IntPtr call, int index, out IntPtr vector);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetIconicVarObjectName", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetIconicVarObject(IntPtr call, string name, out IntPtr key);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetIconicVarVectorName", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetIconicVarVector(IntPtr call, string name, out IntPtr vector);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenCreateProcedure", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CreateProcedure(out IntPtr procedure);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenDestroyProcedure", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DestroyProcedure(IntPtr procedure);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenLoadProcedure", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int LoadProcedure(IntPtr procedure, string procedureName);

        [DllImport("hdevenginecppxl", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int HCenLoadProcedureProgramName(
          IntPtr procedure,
          IntPtr programName,
          string procedureName);

        internal static int LoadProcedure(IntPtr procedure, string programName, string procedureName)
        {
            IntPtr hglobalUtf8Encoding = HalconAPI.ToHGlobalUtf8Encoding(programName);
            int num = EngineAPI.HCenLoadProcedureProgramName(procedure, hglobalUtf8Encoding, procedureName);
            Marshal.FreeHGlobal(hglobalUtf8Encoding);
            return num;
        }

        [DllImport("hdevenginecppxl", EntryPoint = "HCenLoadProcedureProgram", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int LoadProcedure(
          IntPtr procedure,
          IntPtr program,
          string procedureName);

        [DllImport("hdevenginecppxl", CallingConvention = CallingConvention.Cdecl)]
        private static extern int HCenGetProcedureInfo(
          IntPtr procedure,
          out IntPtr name,
          out IntPtr shortDescription,
          out bool loaded,
          IntPtr parNamesIconicInput,
          IntPtr parNamesIconicOutput,
          IntPtr parNamesCtrlInput,
          IntPtr parNamesCtrlOutput,
          IntPtr parDimsIconicInput,
          IntPtr parDimsIconicOutput,
          IntPtr parDimsCtrlInput,
          IntPtr parDimsCtrlOutput);

        internal static void GetProcedureInfo(
          IntPtr procedure,
          out string name,
          out string shortDescription,
          out bool loaded,
          out HTuple parNamesIconicInput,
          out HTuple parNamesIconicOutput,
          out HTuple parNamesCtrlInput,
          out HTuple parNamesCtrlOutput,
          out HTuple parDimsIconicInput,
          out HTuple parDimsIconicOutput,
          out HTuple parDimsCtrlInput,
          out HTuple parDimsCtrlOutput)
        {
            IntPtr tuple1;
            EngineAPI.HCkE(HalconAPI.CreateTuple(out tuple1));
            IntPtr tuple2;
            EngineAPI.HCkE(HalconAPI.CreateTuple(out tuple2));
            IntPtr tuple3;
            EngineAPI.HCkE(HalconAPI.CreateTuple(out tuple3));
            IntPtr tuple4;
            EngineAPI.HCkE(HalconAPI.CreateTuple(out tuple4));
            IntPtr tuple5;
            EngineAPI.HCkE(HalconAPI.CreateTuple(out tuple5));
            IntPtr tuple6;
            EngineAPI.HCkE(HalconAPI.CreateTuple(out tuple6));
            IntPtr tuple7;
            EngineAPI.HCkE(HalconAPI.CreateTuple(out tuple7));
            IntPtr tuple8;
            EngineAPI.HCkE(HalconAPI.CreateTuple(out tuple8));
            IntPtr name1;
            IntPtr shortDescription1;
            EngineAPI.HCkE(EngineAPI.HCenGetProcedureInfo(procedure, out name1, out shortDescription1, out loaded, tuple1, tuple2, tuple3, tuple4, tuple5, tuple6, tuple7, tuple8));
            name = Marshal.PtrToStringAnsi(name1);
            shortDescription = Marshal.PtrToStringAnsi(shortDescription1);
            parNamesIconicInput = HalconAPI.LoadTuple(tuple1);
            parNamesIconicOutput = HalconAPI.LoadTuple(tuple2);
            parNamesCtrlInput = HalconAPI.LoadTuple(tuple3);
            parNamesCtrlOutput = HalconAPI.LoadTuple(tuple4);
            parDimsIconicInput = HalconAPI.LoadTuple(tuple5);
            parDimsIconicOutput = HalconAPI.LoadTuple(tuple6);
            parDimsCtrlInput = HalconAPI.LoadTuple(tuple7);
            parDimsCtrlOutput = HalconAPI.LoadTuple(tuple8);
            EngineAPI.HCkE(HalconAPI.DestroyTuple(tuple1));
            EngineAPI.HCkE(HalconAPI.DestroyTuple(tuple2));
            EngineAPI.HCkE(HalconAPI.DestroyTuple(tuple3));
            EngineAPI.HCkE(HalconAPI.DestroyTuple(tuple4));
            EngineAPI.HCkE(HalconAPI.DestroyTuple(tuple5));
            EngineAPI.HCkE(HalconAPI.DestroyTuple(tuple6));
            EngineAPI.HCkE(HalconAPI.DestroyTuple(tuple7));
            EngineAPI.HCkE(HalconAPI.DestroyTuple(tuple8));
        }

        [DllImport("hdevenginecppxl", EntryPoint = "HCenProcGetUsedProcedureNames", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetUsedProcedureNamesForProcedure(IntPtr procedure, IntPtr tuple);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenProcCompileUsedProcedures", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CompileUsedProceduresForProcedure(IntPtr procedure, out bool ret);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenProcGetInfo", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetProcInfo(IntPtr procedure, string slot, IntPtr tuple);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenProcGetParamInfo", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetParamInfo(
          IntPtr procedure,
          string parName,
          string slot,
          IntPtr tuple);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenProcGetInputIconicParamInfo", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetInputIconicParamInfo(
          IntPtr procedure,
          int parIdx,
          string slot,
          IntPtr tuple);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenProcGetOutputIconicParamInfo", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetOutputIconicParamInfo(
          IntPtr procedure,
          int parIdx,
          string slot,
          IntPtr tuple);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenProcGetInputCtrlParamInfo", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetInputCtrlParamInfo(
          IntPtr procedure,
          int parIdx,
          string slot,
          IntPtr tuple);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenProcGetOutputCtrlParamInfo", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetOutputCtrlParamInfo(
          IntPtr procedure,
          int parIdx,
          string slot,
          IntPtr tuple);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenProcQueryInfo", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int QueryInfo(IntPtr procedure, IntPtr tuple);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenProcQueryParamInfo", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int QueryParamInfo(IntPtr procedure, IntPtr tuple);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenCreateProcedureCall", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CreateProcedureCall(IntPtr program, out IntPtr call);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenDestroyProcedureCall", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DestroyProcedureCall(IntPtr call);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenExecuteProcedureCall", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int ExecuteProcedureCall(IntPtr call);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenSetWaitForDebugConnectionProcedureCall", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetWaitForDebugConnectionProcedureCall(IntPtr call, bool wait_once);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenSetInputCtrlParamTupleIndex", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetInputCtrlParamTuple(IntPtr call, int index, IntPtr tuple);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenSetInputCtrlParamTupleName", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetInputCtrlParamTuple(IntPtr call, string name, IntPtr tuple);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenSetInputCtrlParamVectorIndex", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetInputCtrlParamVector(IntPtr call, int index, IntPtr vector);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenSetInputCtrlParamVectorName", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetInputCtrlParamVector(IntPtr call, string name, IntPtr vector);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenSetInputIconicParamObjectIndex", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetInputIconicParamObject(IntPtr call, int index, IntPtr key);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenSetInputIconicParamObjectName", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetInputIconicParamObject(IntPtr call, string name, IntPtr key);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenSetInputIconicParamVectorIndex", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetInputIconicParamVector(IntPtr call, int index, IntPtr key);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenSetInputIconicParamVectorName", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetInputIconicParamVector(IntPtr call, string name, IntPtr key);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetOutputCtrlParamTupleIndex", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetOutputCtrlParamTuple(IntPtr call, int index, out IntPtr tuple);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetOutputCtrlParamTupleName", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetOutputCtrlParamTuple(IntPtr call, string name, out IntPtr tuple);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetOutputCtrlParamVectorIndex", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetOutputCtrlParamVector(IntPtr call, int index, out IntPtr vector);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetOutputCtrlParamVectorName", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetOutputCtrlParamVector(
          IntPtr call,
          string name,
          out IntPtr vector);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetOutputIconicParamObjectIndex", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetOutputIconicParamObject(IntPtr call, int index, out IntPtr key);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetOutputIconicParamObjectName", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetOutputIconicParamObject(IntPtr call, string name, out IntPtr key);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetOutputIconicParamVectorIndex", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetOutputIconicParamVector(
          IntPtr call,
          int index,
          out IntPtr vector);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetOutputIconicParamVectorName", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetOutputIconicParamVector(
          IntPtr call,
          string name,
          out IntPtr vector);

        internal static int CreateObjectVector(HObjectVector inVector, out IntPtr vectorHandle)
        {
            IntPtr vector_handle;
            EngineAPI.HCkE(EngineAPI.CreateObjectVector(inVector.Dimension, out vector_handle));
            EngineAPI.HCkE(EngineAPI.StoreObjectVector(inVector, vector_handle));
            GC.KeepAlive((object)inVector);
            vectorHandle = vector_handle;
            return 2;
        }

        internal static int StoreObjectVector(HObjectVector inVector, IntPtr vectorHandle)
        {
            int dimension = inVector.Dimension;
            int length = inVector.Length;
            if (dimension == 1)
            {
                for (int index = length - 1; index >= 0; --index)
                    EngineAPI.HCkE(EngineAPI.SetObjectVectorObject(vectorHandle, index, inVector[index].O.Key));
            }
            else
            {
                for (int index = length - 1; index >= 0; --index)
                {
                    IntPtr vectorHandle1;
                    EngineAPI.HCkE(EngineAPI.CreateObjectVector(inVector[index], out vectorHandle1));
                    EngineAPI.HCkE(EngineAPI.SetObjectVectorVector(vectorHandle, index, vectorHandle1));
                    EngineAPI.HCkE(EngineAPI.DestroyObjectVector(vectorHandle1));
                }
            }
            GC.KeepAlive((object)inVector);
            return 2;
        }

        internal static HObjectVector GetAndDestroyObjectVector(IntPtr vectorHandle)
        {
            int dimension;
            EngineAPI.HCkE(EngineAPI.GetObjectVectorDimension(vectorHandle, out dimension));
            HObjectVector outVector = new HObjectVector(dimension);
            EngineAPI.HCkE(EngineAPI.LoadObjectVector(outVector, vectorHandle));
            EngineAPI.HCkE(EngineAPI.DestroyObjectVector(vectorHandle));
            return outVector;
        }

        internal static int LoadObjectVector(HObjectVector outVector, IntPtr vectorHandle)
        {
            int dimension;
            EngineAPI.HCkE(EngineAPI.GetObjectVectorDimension(vectorHandle, out dimension));
            int length;
            EngineAPI.HCkE(EngineAPI.GetObjectVectorLength(vectorHandle, out length));
            if (dimension == 1)
            {
                for (int index = length - 1; index >= 0; --index)
                {
                    IntPtr key;
                    EngineAPI.HCkE(EngineAPI.GetObjectVectorObject(vectorHandle, index, out key));
                    outVector[index].O = new HObject(key, false);
                }
            }
            else
            {
                for (int index = length - 1; index >= 0; --index)
                {
                    IntPtr sub_vector_handle;
                    EngineAPI.HCkE(EngineAPI.GetObjectVectorVector(vectorHandle, index, out sub_vector_handle));
                    EngineAPI.HCkE(EngineAPI.LoadObjectVector(outVector[index], sub_vector_handle));
                    EngineAPI.HCkE(EngineAPI.DestroyObjectVector(sub_vector_handle));
                }
            }
            return 2;
        }

        internal static int CreateTupleVector(HTupleVector inVector, out IntPtr vectorHandle)
        {
            IntPtr vector_handle;
            EngineAPI.HCkE(EngineAPI.CreateTupleVector(inVector.Dimension, out vector_handle));
            EngineAPI.HCkE(EngineAPI.StoreTupleVector(inVector, vector_handle));
            GC.KeepAlive((object)inVector);
            vectorHandle = vector_handle;
            return 2;
        }

        internal static int StoreTupleVector(HTupleVector inVector, IntPtr vectorHandle)
        {
            int dimension = inVector.Dimension;
            int length = inVector.Length;
            if (dimension == 1)
            {
                for (int index = length - 1; index >= 0; --index)
                {
                    IntPtr tuple;
                    EngineAPI.HCkE(HalconAPI.CreateTuple(out tuple));
                    HalconAPI.StoreTuple(tuple, inVector[index].T);
                    EngineAPI.HCkE(EngineAPI.SetTupleVectorTuple(vectorHandle, index, tuple));
                    EngineAPI.HCkE(HalconAPI.DestroyTuple(tuple));
                }
            }
            else
            {
                for (int index = length - 1; index >= 0; --index)
                {
                    IntPtr vectorHandle1;
                    EngineAPI.HCkE(EngineAPI.CreateTupleVector(inVector[index], out vectorHandle1));
                    EngineAPI.HCkE(EngineAPI.SetTupleVectorVector(vectorHandle, index, vectorHandle1));
                    EngineAPI.HCkE(EngineAPI.DestroyTupleVector(vectorHandle1));
                }
            }
            GC.KeepAlive((object)inVector);
            return 2;
        }

        internal static HTupleVector GetAndDestroyTupleVector(IntPtr vectorHandle)
        {
            int dimension;
            EngineAPI.HCkE(EngineAPI.GetTupleVectorDimension(vectorHandle, out dimension));
            HTupleVector outVector = new HTupleVector(dimension);
            EngineAPI.HCkE(EngineAPI.LoadTupleVector(outVector, vectorHandle));
            EngineAPI.HCkE(EngineAPI.DestroyTupleVector(vectorHandle));
            return outVector;
        }

        internal static int LoadTupleVector(HTupleVector outVector, IntPtr vectorHandle)
        {
            int dimension;
            EngineAPI.HCkE(EngineAPI.GetTupleVectorDimension(vectorHandle, out dimension));
            int length;
            EngineAPI.HCkE(EngineAPI.GetTupleVectorLength(vectorHandle, out length));
            if (dimension == 1)
            {
                for (int index = length - 1; index >= 0; --index)
                {
                    IntPtr element_handle;
                    EngineAPI.HCkE(EngineAPI.GetTupleVectorTuple(vectorHandle, index, out element_handle));
                    outVector[index].T = HalconAPI.LoadTuple(element_handle);
                }
            }
            else
            {
                for (int index = length - 1; index >= 0; --index)
                {
                    IntPtr element_handle;
                    EngineAPI.HCkE(EngineAPI.GetTupleVectorVector(vectorHandle, index, out element_handle));
                    EngineAPI.HCkE(EngineAPI.LoadTupleVector(outVector[index], element_handle));
                    EngineAPI.HCkE(EngineAPI.DestroyTupleVector(element_handle));
                }
            }
            return 2;
        }

        [DllImport("hdevenginecppxl", EntryPoint = "HCenCreateTupleVector", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CreateTupleVector(int dimension, out IntPtr vector_handle);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenDestroyTupleVector", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DestroyTupleVector(IntPtr vector_handle);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetTupleVectorDimension", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetTupleVectorDimension(IntPtr vector_handle, out int dimension);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetTupleVectorLength", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetTupleVectorLength(IntPtr vector_handle, out int length);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenSetTupleVectorElementVector", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetTupleVectorVector(
          IntPtr vector_handle,
          int index,
          IntPtr element_handle);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenSetTupleVectorElementTuple", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetTupleVectorTuple(
          IntPtr vector_handle,
          int index,
          IntPtr element_handle);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetTupleVectorElementVector", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetTupleVectorVector(
          IntPtr vector_handle,
          int index,
          out IntPtr element_handle);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetTupleVectorElementTuple", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetTupleVectorTuple(
          IntPtr vector_handle,
          int index,
          out IntPtr element_handle);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenCreateObjectVector", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CreateObjectVector(int dimension, out IntPtr vector_handle);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenDestroyObjectVector", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DestroyObjectVector(IntPtr vector_handle);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetObjectVectorDimension", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetObjectVectorDimension(IntPtr vector_handle, out int dimension);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetObjectVectorLength", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetObjectVectorLength(IntPtr vector_handle, out int length);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenSetObjectVectorElementVector", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetObjectVectorVector(
          IntPtr vector_handle,
          int index,
          IntPtr sub_vector_handle);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenSetObjectVectorElementObject", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int SetObjectVectorObject(IntPtr vector_handle, int index, IntPtr key);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetObjectVectorElementVector", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetObjectVectorVector(
          IntPtr vector_handle,
          int index,
          out IntPtr sub_vector_handle);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenGetObjectVectorElementObject", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int GetObjectVectorObject(
          IntPtr vector_handle,
          int index,
          out IntPtr key);

        internal static void AssertObjectClass(IntPtr key, string assertClass, string procedureName)
        {
            if (!(key != HObjectBase.UNDEF))
                return;
            HObject hobject = new HObject(key);
            HTuple objClass = hobject.GetObjClass();
            hobject.Dispose();
            if (objClass.Length <= 0)
                return;
            string s = objClass.S;
            if (s.StartsWith(assertClass))
                return;
            HDevEngineException.ThrowGeneric("Output object type mismatch (excepted " + assertClass + ", got " + s + ")", procedureName);
        }

        [DllImport("hdevenginecppxl", EntryPoint = "HCenCreateImplementation", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int CreateImplementation(
          out IntPtr implementation,
          DevOpenWindowDelegate delegateDevOpenWindow,
          DevCloseWindowDelegate delegateDevCloseWindow,
          DevSetWindowDelegate delegateDevSetWindow,
          DevGetWindowDelegate delegateDevGetWindow,
          DevSetWindowExtentsDelegate delegateDevSetWindowExtents,
          DevSetPartDelegate delegateDevSetPart,
          DevClearWindowDelegate delegateDevClearWindow,
          DevDisplayDelegate delegateDevDisplay,
          DevDispTextDelegate delegateDevDispText,
          DevSetDrawDelegate delegateDevSetDraw,
          DevSetShapeDelegate delegateDevSetShape,
          DevSetColoredDelegate delegateDevSetColored,
          DevSetColorDelegate delegateDevSetColor,
          DevSetLutDelegate delegateDevSetLut,
          DevSetPaintDelegate delegateDevSetPaint,
          DevSetLineWidthDelegate delegateDevSetLineWidth);

        [DllImport("hdevenginecppxl", EntryPoint = "HCenDestroyImplementation", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int DestroyImplementation(IntPtr implementation);

        [DllImport("hdevenginecppxl", CallingConvention = CallingConvention.Cdecl)]
        internal static extern int HCenGetLastException(
          out int category,
          out IntPtr message,
          out IntPtr procedureName,
          out IntPtr lineText,
          out int lineNumber,
          out IntPtr userData);

        [DllImport("hdevenginecppxl", CallingConvention = CallingConvention.Cdecl)]
        internal static extern void HCenReleaseLastException();

        internal static int GetLastException(
          out int category,
          out string message,
          out string procedureName,
          out string lineText,
          out int lineNumber,
          out HTuple userData)
        {
            IntPtr message1;
            IntPtr procedureName1;
            IntPtr lineText1;
            IntPtr userData1;
            int lastException = EngineAPI.HCenGetLastException(out category, out message1, out procedureName1, out lineText1, out lineNumber, out userData1);
            try
            {
                message = Marshal.PtrToStringAnsi(message1);
                procedureName = Marshal.PtrToStringAnsi(procedureName1);
                lineText = Marshal.PtrToStringAnsi(lineText1);
                userData = HalconAPI.LoadTuple(userData1);
            }
            catch
            {
                message = "Error handling exception";
                procedureName = "";
                lineText = "";
                userData = new HTuple();
            }
            EngineAPI.HCenReleaseLastException();
            return lastException;
        }

        internal static void HCkE(int err)
        {
            if (err != -1 && (err == 2 || err == 2))
                return;
            HDevEngineException.ThrowLastException(err);
        }
        
    }
}
