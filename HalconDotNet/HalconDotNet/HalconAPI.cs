// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HalconAPI
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;

namespace HalconDotNet
{
    /// <summary>
    ///   This class manages all communication with the HALCON library
    /// </summary>
    //[SuppressUnmanagedCodeSecurity]
    public class HalconAPI
    {
        /// <summary>True when running on a 64-bit platform.</summary>
        public static readonly bool isPlatform64 = IntPtr.Size > 4;
        /// <summary>True when running on a Windows platform.</summary>
        public static readonly bool isWindows = HalconAPI.testWindows();
        //private const string HalconDLL = "halconxl";
        private const CallingConvention HalconCall = CallingConvention.Cdecl;
        internal const int H_MSG_OK = 2;
        internal const int H_MSG_TRUE = 2;
        internal const int H_MSG_FALSE = 3;
        internal const int H_MSG_VOID = 4;
        internal const int H_MSG_FAIL = 5;

        private HalconAPI()
        {
        }

        private static bool testWindows()
        {
            int platform = (int)Environment.OSVersion.Platform;
            if (platform != 4)
                return platform != 128;
            return false;
        }

        /// <summary>
        ///   Setting DoLicenseError(false) disables the license error dialog and
        ///   application termination. Instead, an exception is raised.
        /// </summary>
        //[DllImport("halconxl", EntryPoint = "HLIDoLicenseError", CallingConvention = CallingConvention.Cdecl)]
        public static void DoLicenseError(bool state)
        {
        }

    
        /// <summary>
        ///   Setting HLIUseSpinLock(false) before calling the first operator
        ///   will cause HALCON to use mutex synchronization instead of spin locks.
        ///   This is usually less efficient but may prevent problems if a large
        ///   number of threads with differing priorities is used.
        /// </summary>
        //[DllImport("halconxl", EntryPoint = "HLIUseSpinLock", CallingConvention = CallingConvention.Cdecl)]
        public static void UseSpinLock(bool state)
        {
        }

        /// <summary>
        ///   Setting HLIStartUpThreadPool(false) before calling the first
        ///   operator will disable the thread pool of HALCON
        /// </summary>
        //[DllImport("halconxl", EntryPoint = "HLIStartUpThreadPool", CallingConvention = CallingConvention.Cdecl)]
        public static void StartUpThreadPool(bool state)
        {
        }

        /// <summary>
        ///   Aborts a draw_* operator as a right-click would (Windows only)
        /// </summary>
        //[DllImport("halconxl", EntryPoint = "HLICancelDraw", CallingConvention = CallingConvention.Cdecl)]
        public static void CancelDraw()
        {
        }

        /// <summary>
        ///   Returns whereas HALCON character encoding is set to UTF8 or locale.
        /// </summary>
        //[DllImport("halconxl", EntryPoint = "HLIIsUTF8Encoding", CallingConvention = CallingConvention.Cdecl)]
        private static bool IsUTF8Encoding()
        {
            if (Encoding.Default == Encoding.UTF8) return true ;
            else return false;
        }

        //[DllImport("halconxl", CallingConvention = CallingConvention.Cdecl)]
        private static int HLIGetSerializedSize(IntPtr ptr, out ulong size)
        {
            size = 1024l;
            return 1024;
        }

        internal static int GetSerializedSize(byte[] header, out ulong size)
        {
            GCHandle gcHandle = GCHandle.Alloc((object)header, GCHandleType.Pinned);
            int serializedSize = HalconAPI.HLIGetSerializedSize(gcHandle.AddrOfPinnedObject(), out size);
            gcHandle.Free();
            return serializedSize;
        }

        //[DllImport("halconxl", EntryPoint = "HLILock", CallingConvention = CallingConvention.Cdecl)]
        internal static void Lock() {}

        //[DllImport("halconxl", EntryPoint = "HLIUnlock", CallingConvention = CallingConvention.Cdecl)]
        internal static void Unlock()
        {
        }

        //[DllImport("halconxl", CallingConvention = CallingConvention.Cdecl)]
        internal static int HXCreateHThreadContext(out IntPtr context)
        {
            context = new IntPtr(1024);
            return 1;
        }

        //[DllImport("halconxl", CallingConvention = CallingConvention.Cdecl)]
        internal static int HXClearHThreadContext(IntPtr context)
        {
            return 1;
        }

        //[DllImport("halconxl", CallingConvention = CallingConvention.Cdecl)]
        internal static int HXCreateHThread(IntPtr contextHandle, out IntPtr threadHandle)
        {
            threadHandle = new IntPtr();
            return 1;
        }

        //[DllImport("halconxl", CallingConvention = CallingConvention.Cdecl)]
        internal static int HXClearHThread(IntPtr threadHandle)
        {
            return 1;
        }

        //[DllImport("halconxl", CallingConvention = CallingConvention.Cdecl)]
        internal static int HXExitHThread(IntPtr threadHandle)
        {
            return 1;
        }

        //[DllImport("halconxl", CallingConvention = CallingConvention.Cdecl)]
        internal static int HXStartHThreadDotNet(
          IntPtr threadHandle,
          HalconAPI.HDevThreadInternalCallback proc,
          IntPtr data,
          out IntPtr threadId)
        {
            threadId = new IntPtr();
            return 1;
        }

        //[DllImport("halconxl", CallingConvention = CallingConvention.Cdecl)]
        internal static int HXPrepareDirectCall(IntPtr threadHandle)
        {
            return 1;
        }

        //[DllImport("halconxl", CallingConvention = CallingConvention.Cdecl)]
        internal static int HXJoinHThread(IntPtr threadId)
        {
            return 1;
        }

        //[DllImport("halconxl", CallingConvention = CallingConvention.Cdecl)]
        internal static int HXThreadLockLocalVar(IntPtr threadHandle, out IntPtr referenceCount)
        {
            referenceCount = new IntPtr();
            return 1;
        }

        //[DllImport("halconxl", CallingConvention = CallingConvention.Cdecl)]
        internal static int HXThreadUnlockLocalVar(IntPtr threadHandle)
        {
            return 1;
        }

        //[DllImport("halconxl", CallingConvention = CallingConvention.Cdecl)]
        internal static int HXThreadLockGlobalVar(IntPtr threadHandle)
        {
            return 1;
        }

        //[DllImport("halconxl", CallingConvention = CallingConvention.Cdecl)]
        internal static int HXThreadUnlockGlobalVar(IntPtr threadHandle)
        {
            return 1;
        }

        ////[DllImport("halconxl", EntryPoint = "HLICreateProcedure", CallingConvention = CallingConvention.Cdecl)]
        private static int CreateProcedure(int procIndex, out IntPtr proc)
        {
            proc = new IntPtr();
            return 2;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        //[DllImport("halconxl", EntryPoint = "HLICallProcedure", CallingConvention = CallingConvention.Cdecl)]
        public static int CallProcedure(IntPtr proc)
        {
            return 1;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        //[DllImport("halconxl", EntryPoint = "HLIDestroyProcedure", CallingConvention = CallingConvention.Cdecl)]
        public static int DestroyProcedure(IntPtr proc, int procResult)
        {
            return 1;
        }

        //[DllImport("halconxl", CallingConvention = CallingConvention.Cdecl)]
        private static IntPtr HLIGetLogicalName(IntPtr proc)
        {
            return new IntPtr(1);
        }

        internal static string GetLogicalName(IntPtr proc)
        {
            return Marshal.PtrToStringAnsi(HalconAPI.HLIGetLogicalName(proc));
        }

        //[DllImport("halconxl", EntryPoint = "HLILogicalName", CallingConvention = CallingConvention.Cdecl)]
        private static IntPtr HLIGetLogicalName(int procIndex)
        {
            return new IntPtr(1);
        }

        internal static string GetLogicalName(int procIndex)
        {
            return Marshal.PtrToStringAnsi(HalconAPI.HLIGetLogicalName(procIndex));
        }

        //[DllImport("halconxl", EntryPoint = "HLIGetProcIndex", CallingConvention = CallingConvention.Cdecl)]
        private static int GetProcIndex(IntPtr proc)
        {
            return 1;
        }

        //[DllImport("halconxl", CallingConvention = CallingConvention.Cdecl)]
        private static int HLIGetErrorMessage(int err, IntPtr buffer)
        {
            return 1;
        }

        internal static string GetErrorMessage(int err)
        {
            IntPtr num = Marshal.AllocHGlobal(1024);
            HalconAPI.HLIGetErrorMessage(err, num);
            string str = HalconAPI.FromHalconEncoding(num);
            Marshal.FreeHGlobal(num);
            return str;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IntPtr PreCall(int procIndex)
        {
            IntPtr proc = new IntPtr();
            int procedure = HalconAPI.CreateProcedure(procIndex, out proc);
            if (procedure != 2)
                HOperatorException.throwInfo(procedure, "Could not create a new operator instance for id " + (object)procIndex);
            return proc;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void PostCall(IntPtr proc, int procResult)
        {
            //int procIndex = HalconAPI.GetProcIndex(proc);
            //HalconAPI.HLIClearAllIOCT(proc);
            //int err = HalconAPI.DestroyProcedure(proc, procResult);
            //if (procIndex >= 0)
            //{
            //    HOperatorException.throwOperator(err, procIndex);
            //    HOperatorException.throwOperator(procResult, procIndex);
            //}
            //else
            //{
            //    HOperatorException.throwOperator(err, "Unknown");
            //    HOperatorException.throwOperator(procResult, "Unknown");
            //}
        }

        //[DllImport("halconxl", EntryPoint = "HLISetInputObject", CallingConvention = CallingConvention.Cdecl)]
        internal static int SetInputObject(IntPtr proc, int parIndex, IntPtr key)
        {
            return 1;
        }

        //[DllImport("halconxl", EntryPoint = "HLIGetOutputObject", CallingConvention = CallingConvention.Cdecl)]
        internal static int GetOutputObject(IntPtr proc, int parIndex, out IntPtr key)
        {
            key = new IntPtr();
            return 1;
        }

        internal static void ClearObject(IntPtr key)
        {
            IntPtr proc = HalconAPI.PreCall(585);
            HalconAPI.HCkP(proc, HalconAPI.SetInputObject(proc, 1, key));
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        //[DllImport("halconxl", CallingConvention = CallingConvention.Cdecl)]
        private static int HLICopyObject(IntPtr keyIn, out IntPtr keyOut)
        {
            keyOut = new IntPtr();
            return 1;
        }

        internal static IntPtr CopyObject(IntPtr key)
        {
            IntPtr proc = HalconAPI.PreCall(583);
            HalconAPI.HCkP(proc, HalconAPI.SetInputObject(proc, 1, key));
            HalconAPI.StoreI(proc, 0, 1);
            HalconAPI.StoreI(proc, 1, -1);
            int num = HalconAPI.CallProcedure(proc);
            if (!HalconAPI.IsFailure(num))
                num = HalconAPI.GetOutputObject(proc, 1, out key);
            HalconAPI.PostCall(proc, num);
            return key;
        }

        internal static string GetObjClass(IntPtr key)
        {
            HTuple tuple = (HTuple)"object";
            IntPtr proc = HalconAPI.PreCall(594);
            HalconAPI.HCkP(proc, HalconAPI.SetInputObject(proc, 1, key));
            HalconAPI.InitOCT(proc, 0);
            int num = HalconAPI.CallProcedure(proc);
            if (!HalconAPI.IsFailure(num))
                num = HTuple.LoadNew(proc, 0, num, out tuple);
            HalconAPI.PostCall(proc, num);
            if (tuple.Length <= 0)
                return "any";
            return tuple.S;
        }

        internal static void AssertObjectClass(IntPtr key, string assertClass)
        {
            if (!(key != HObjectBase.UNDEF))
                return;
            string objClass = HalconAPI.GetObjClass(key);
            if (!objClass.StartsWith(assertClass) && objClass != "any")
                throw new HalconException("Iconic object type mismatch (expected " + assertClass + ", got " + objClass + ")");
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        //[DllImport("halconxl", EntryPoint = "HLICreateTuple", CallingConvention = CallingConvention.Cdecl)]
        public static int CreateTuple(out IntPtr tuple)
        {
            tuple = new IntPtr();
            return 1;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        //[DllImport("halconxl", EntryPoint = "HLIInitOCT", CallingConvention = CallingConvention.Cdecl)]
        public static int InitOCT(IntPtr proc, int parIndex)
        {
            return 1;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        //[DllImport("halconxl", CallingConvention = CallingConvention.Cdecl)]
        public static int HLIClearAllIOCT(IntPtr proc)
        {
            return 1;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        //[DllImport("halconxl", EntryPoint = "HLIDestroyTuple", CallingConvention = CallingConvention.Cdecl)]
        public static int DestroyTuple(IntPtr tuple)
        {
            return 1;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void StoreTuple(IntPtr tupleHandle, HTuple tuple)
        {
            HTupleType type = tuple.Type == HTupleType.LONG ? HTupleType.INTEGER : tuple.Type;
            HalconAPI.HCkH(HalconAPI.CreateElementsOfType(tupleHandle, tuple.Length, type));
            switch (tuple.Type)
            {
                case HTupleType.INTEGER:
                    HalconAPI.HCkH(HalconAPI.SetIArr(tupleHandle, tuple.IArr));
                    break;
                case HTupleType.DOUBLE:
                    HalconAPI.HCkH(HalconAPI.SetDArr(tupleHandle, tuple.DArr));
                    break;
                case HTupleType.STRING:
                    string[] sarr = tuple.SArr;
                    for (int index = 0; index < tuple.Length; ++index)
                        HalconAPI.HCkH(HalconAPI.SetS(tupleHandle, index, sarr[index]));
                    break;
                case HTupleType.MIXED:
                    object[] oarr = tuple.data.OArr;
                    for (int index = 0; index < tuple.Length; ++index)
                    {
                        switch (HTupleImplementation.GetObjectType(oarr[index]))
                        {
                            case 1:
                                HalconAPI.HCkH(HalconAPI.SetI(tupleHandle, index, (int)oarr[index]));
                                break;
                            case 2:
                                HalconAPI.HCkH(HalconAPI.SetD(tupleHandle, index, (double)oarr[index]));
                                break;
                            case 4:
                                HalconAPI.HCkH(HalconAPI.SetS(tupleHandle, index, (string)oarr[index]));
                                break;
                            case 129:
                                HalconAPI.HCkH(HalconAPI.SetL(tupleHandle, index, (long)oarr[index]));
                                break;
                        }
                    }
                    break;
                case HTupleType.LONG:
                    HalconAPI.HCkH(HalconAPI.SetLArr(tupleHandle, tuple.LArr));
                    break;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static HTuple LoadTuple(IntPtr tupleHandle)
        {
            HTupleImplementation data;
            HTupleImplementation.LoadData(tupleHandle, HTupleType.MIXED, out data);
            return new HTuple(data);
        }

        private static void HCkH(int err)
        {
            if (HalconAPI.IsFailure(err))
                throw new HOperatorException(err);
        }

        //[DllImport("halconxl", EntryPoint = "HLIGetInputTuple", CallingConvention = CallingConvention.Cdecl)]
        internal static int GetInputTuple(IntPtr proc, int parIndex, out IntPtr tuple)
        {
            tuple = new IntPtr();
            return 1;
        }

        //[DllImport("halconxl", EntryPoint = "HLICreateElements", CallingConvention = CallingConvention.Cdecl)]
        internal static int CreateElements(IntPtr tuple, int length)
        {
            return 1;
        }

        //[DllImport("halconxl", EntryPoint = "HLICreateElementsOfType", CallingConvention = CallingConvention.Cdecl)]
        internal static int CreateElementsOfType(IntPtr tuple, int length, HTupleType type)
        {
            return 1;
        }

        internal static int CreateInputTuple(IntPtr proc, int parIndex, int length, out IntPtr tuple)
        {
            int inputTuple = HalconAPI.GetInputTuple(proc, parIndex, out tuple);
            if (!HalconAPI.IsFailure(inputTuple))
                return HalconAPI.CreateElements(tuple, length);
            return inputTuple;
        }

        //[DllImport("halconxl", EntryPoint = "HLIGetOutputTuple", CallingConvention = CallingConvention.Cdecl)]
        internal static int GetOutputTuple(IntPtr proc, int parIndex, out IntPtr tuple)
        {
            tuple = new IntPtr();
            return 1;
        }

        //[DllImport("halconxl", EntryPoint = "HLIGetTupleLength", CallingConvention = CallingConvention.Cdecl)]
        internal static int GetTupleLength(IntPtr tuple, out int length)
        {
            length = 0;
            return 1;
        }

        //[DllImport("halconxl", EntryPoint = "HLIGetTupleTypeScanElem", CallingConvention = CallingConvention.Cdecl)]
        internal static int GetTupleTypeScanElem(IntPtr tuple, out int type)
        {
            type = 0;
            return 1;
        }

        //[DllImport("halconxl", EntryPoint = "HLIGetElementType", CallingConvention = CallingConvention.Cdecl)]
        internal static int GetElementType(IntPtr tuple, int index, out HTupleType type)
        {
            type = (HTupleType) 0;
            return 1;
        }

        //[DllImport("halconxl", EntryPoint = "HLISetI", CallingConvention = CallingConvention.Cdecl)]
        internal static int SetI(IntPtr tuple, int index, int intValue)
        {
            return 1;
        }

        //[DllImport("halconxl", EntryPoint = "HLISetL", CallingConvention = CallingConvention.Cdecl)]
        internal static int SetL(IntPtr tuple, int index, long longValue)
        {
            return 1;
        }

        //[DllImport("halconxl", EntryPoint = "HLISetD", CallingConvention = CallingConvention.Cdecl)]
        internal static int SetD(IntPtr tuple, int index, double doubleValue)
        {
            return 1;
        }

        //[DllImport("halconxl", CallingConvention = CallingConvention.Cdecl)]
        internal static int HLISetS(IntPtr tuple, int index, IntPtr stringValue)
        {
            return 1;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IntPtr ToHalconHGlobalEncoding(string dotnet)
        {
            if (!HalconAPI.IsUTF8Encoding())
                return Marshal.StringToHGlobalAnsi(dotnet);
            return HalconAPI.ToHGlobalUtf8Encoding(dotnet);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static IntPtr ToHGlobalUtf8Encoding(string dotnet)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(dotnet);
            int ofs = Marshal.SizeOf(bytes.GetType().GetElementType()) * bytes.Length;
            IntPtr num = Marshal.AllocHGlobal(ofs + 1);
            Marshal.Copy(bytes, 0, num, bytes.Length);
            Marshal.WriteByte(num, ofs, (byte)0);
            return num;
        }

        internal static int SetS(IntPtr tuple, int index, string dotnet_string)
        {
            IntPtr halconHglobalEncoding = HalconAPI.ToHalconHGlobalEncoding(dotnet_string);
            int num = HalconAPI.HLISetS(tuple, index, halconHglobalEncoding);
            Marshal.FreeHGlobal(halconHglobalEncoding);
            return num;
        }

        internal static int SetIP(IntPtr tuple, int index, IntPtr intPtrValue)
        {
            return !HalconAPI.isPlatform64 ? HalconAPI.SetI(tuple, index, intPtrValue.ToInt32()) : HalconAPI.SetL(tuple, index, intPtrValue.ToInt64());
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void StoreI(IntPtr proc, int parIndex, int intValue)
        {
            IntPtr tuple;
            HalconAPI.HCkP(proc, HalconAPI.CreateInputTuple(proc, parIndex, 1, out tuple));
            HalconAPI.SetI(tuple, 0, intValue);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void StoreL(IntPtr proc, int parIndex, long longValue)
        {
            IntPtr tuple;
            HalconAPI.HCkP(proc, HalconAPI.CreateInputTuple(proc, parIndex, 1, out tuple));
            HalconAPI.SetL(tuple, 0, longValue);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void StoreD(IntPtr proc, int parIndex, double doubleValue)
        {
            IntPtr tuple;
            HalconAPI.HCkP(proc, HalconAPI.CreateInputTuple(proc, parIndex, 1, out tuple));
            HalconAPI.SetD(tuple, 0, doubleValue);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void StoreS(IntPtr proc, int parIndex, string stringValue)
        {
            if (stringValue == null)
                stringValue = "";
            IntPtr tuple;
            HalconAPI.HCkP(proc, HalconAPI.CreateInputTuple(proc, parIndex, 1, out tuple));
            HalconAPI.HCkP(proc, HalconAPI.SetS(tuple, 0, stringValue));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void StoreIP(IntPtr proc, int parIndex, IntPtr intPtrValue)
        {
            IntPtr tuple;
            HalconAPI.HCkP(proc, HalconAPI.CreateInputTuple(proc, parIndex, 1, out tuple));
            HalconAPI.SetIP(tuple, 0, intPtrValue);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void Store(IntPtr proc, int parIndex, HTuple tupleValue)
        {
            if (tupleValue == null)
                tupleValue = new HTuple();
            tupleValue.Store(proc, parIndex);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void Store(IntPtr proc, int parIndex, HObjectBase objectValue)
        {
            if (objectValue == null)
                objectValue = new HObjectBase();
            objectValue.Store(proc, parIndex);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void Store(IntPtr proc, int parIndex, HTool toolValue)
        {
            if (toolValue == null)
                HalconAPI.StoreIP(proc, parIndex, HTool.UNDEF);
            else
                toolValue.Store(proc, parIndex);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void Store(IntPtr proc, int parIndex, HTool[] tools)
        {
            if (tools == null)
                tools = new HTool[0];
            HalconAPI.Store(proc, parIndex, HTool.ConcatArray(tools));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void Store(IntPtr proc, int parIndex, HData data)
        {
            if (data == null)
                data = new HData();
            data.Store(proc, parIndex);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void Store(IntPtr proc, int parIndex, HData[] data)
        {
            if (data == null)
                data = new HData[0];
            HalconAPI.Store(proc, parIndex, HData.ConcatArray(data));
        }

        //[DllImport("halconxl", EntryPoint = "HLISetIArr", CallingConvention = CallingConvention.Cdecl)]
        internal static int SetIArr(IntPtr tuple, int[] intArray)
        {
            return 1;
        }

        //[DllImport("halconxl", EntryPoint = "HLISetIArrPtr", CallingConvention = CallingConvention.Cdecl)]
        internal static int SetIArrPtr(IntPtr tuple, int[] intArray, int length)
        {
            return 1;
        }

        //[DllImport("halconxl", EntryPoint = "HLISetLArr", CallingConvention = CallingConvention.Cdecl)]
        internal static int SetLArr(IntPtr tuple, long[] longArray)
        {
            return 1;
        }

        //[DllImport("halconxl", EntryPoint = "HLISetLArrPtr", CallingConvention = CallingConvention.Cdecl)]
        internal static int SetLArrPtr(IntPtr tuple, long[] longArray, int length)
        {
            return 1;
        }

        //[DllImport("halconxl", EntryPoint = "HLISetDArr", CallingConvention = CallingConvention.Cdecl)]
        internal static int SetDArr(IntPtr tuple, double[] doubleArray)
        {
            return 1;
        }

        //[DllImport("halconxl", EntryPoint = "HLISetDArrPtr", CallingConvention = CallingConvention.Cdecl)]
        internal static int SetDArrPtr(IntPtr tuple, double[] doubleArray, int length)
        {
            return 1;
        }

        //[DllImport("halconxl", EntryPoint = "HLIGetI", CallingConvention = CallingConvention.Cdecl)]
        internal static int GetI(IntPtr tuple, int index, out int intValue)
        {
            intValue = 0;
            return 1;
        }

        //[DllImport("halconxl", EntryPoint = "HLIGetL", CallingConvention = CallingConvention.Cdecl)]
        internal static int GetL(IntPtr tuple, int index, out long longValue)
        {
            longValue = 0;
            return 1;
        }

        //[DllImport("halconxl", EntryPoint = "HLIGetD", CallingConvention = CallingConvention.Cdecl)]
        internal static int GetD(IntPtr tuple, int index, out double doubleValue)
        {
            doubleValue = 0;
            return 1;
        }

        //[DllImport("halconxl", CallingConvention = CallingConvention.Cdecl)]
        private static int HLIGetS(IntPtr tuple, int index, out IntPtr stringPtr)
        {
            stringPtr = new IntPtr();
            return 1;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static string FromHalconEncoding(IntPtr halcon)
        {
            if (!HalconAPI.IsUTF8Encoding())
                return Marshal.PtrToStringAnsi(halcon);
            int ofs = 0;
            while (Marshal.ReadByte(halcon, ofs) != (byte)0)
                ++ofs;
            byte[] numArray = new byte[ofs];
            Marshal.Copy(halcon, numArray, 0, numArray.Length);
            return Encoding.UTF8.GetString(numArray);
        }

        internal static int GetS(IntPtr tuple, int index, out string stringValue)
        {
            stringValue = string.Empty;
            IntPtr stringPtr;
            int s = HalconAPI.HLIGetS(tuple, index, out stringPtr);
            if (s != 2)
                return s;
            stringValue = HalconAPI.FromHalconEncoding(stringPtr);
            if (stringValue != null)
                return 2;
            stringValue = "";
            return 5;
        }

        internal static int GetIP(IntPtr tuple, int index, out IntPtr intPtrValue)
        {
            int num;
            if (HalconAPI.isPlatform64)
            {
                long longValue;
                num = HalconAPI.GetL(tuple, index, out longValue);
                intPtrValue = new IntPtr(longValue);
            }
            else
            {
                int intValue;
                num = HalconAPI.GetI(tuple, index, out intValue);
                intPtrValue = new IntPtr(intValue);
            }
            return num;
        }

        private static int HCkSingle(IntPtr tuple, HTupleType expectedType)
        {
            int length = 0;
            if (tuple != IntPtr.Zero)
                HalconAPI.GetTupleLength(tuple, out length);
            if (length <= 0)
                return 7001;
            HTupleType type;
            HalconAPI.GetElementType(tuple, 0, out type);
            return type != expectedType ? 7002 : 2;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int LoadI(IntPtr proc, int parIndex, int err, out int intValue)
        {
            if (HalconAPI.IsFailure(err))
            {
                intValue = -1;
                return err;
            }
            IntPtr tuple = IntPtr.Zero;
            HalconAPI.GetOutputTuple(proc, parIndex, out tuple);
            err = HalconAPI.HCkSingle(tuple, HTupleType.INTEGER);
            if (err == 2)
                return HalconAPI.GetI(tuple, 0, out intValue);
            err = HalconAPI.HCkSingle(tuple, HTupleType.DOUBLE);
            if (err != 2)
            {
                intValue = -1;
                return err;
            }
            double doubleValue = -1.0;
            err = HalconAPI.GetD(tuple, 0, out doubleValue);
            intValue = (int)doubleValue;
            return err;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int LoadL(IntPtr proc, int parIndex, int err, out long longValue)
        {
            if (HalconAPI.IsFailure(err))
            {
                longValue = -1L;
                return err;
            }
            IntPtr tuple = IntPtr.Zero;
            HalconAPI.GetOutputTuple(proc, parIndex, out tuple);
            err = HalconAPI.HCkSingle(tuple, HTupleType.INTEGER);
            if (err == 2)
                return HalconAPI.GetL(tuple, 0, out longValue);
            err = HalconAPI.HCkSingle(tuple, HTupleType.DOUBLE);
            if (err != 2)
            {
                longValue = -1L;
                return err;
            }
            double doubleValue = -1.0;
            err = HalconAPI.GetD(tuple, 0, out doubleValue);
            longValue = (long)doubleValue;
            return err;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int LoadD(IntPtr proc, int parIndex, int err, out double doubleValue)
        {
            if (HalconAPI.IsFailure(err))
            {
                doubleValue = -1.0;
                return err;
            }
            IntPtr tuple = IntPtr.Zero;
            HalconAPI.GetOutputTuple(proc, parIndex, out tuple);
            err = HalconAPI.HCkSingle(tuple, HTupleType.DOUBLE);
            if (err == 2)
                return HalconAPI.GetD(tuple, 0, out doubleValue);
            err = HalconAPI.HCkSingle(tuple, HTupleType.INTEGER);
            if (err != 2)
            {
                doubleValue = -1.0;
                return err;
            }
            int intValue = -1;
            err = HalconAPI.GetI(tuple, 0, out intValue);
            doubleValue = (double)intValue;
            return err;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int LoadS(IntPtr proc, int parIndex, int err, out string stringValue)
        {
            if (HalconAPI.IsFailure(err))
            {
                stringValue = "";
                return err;
            }
            IntPtr tuple = IntPtr.Zero;
            HalconAPI.GetOutputTuple(proc, parIndex, out tuple);
            err = HalconAPI.HCkSingle(tuple, HTupleType.STRING);
            if (err == 2)
                return HalconAPI.GetS(tuple, 0, out stringValue);
            stringValue = "";
            return err;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int LoadIP(IntPtr proc, int parIndex, int err, out IntPtr intPtrValue)
        {
            if (HalconAPI.IsFailure(err))
            {
                intPtrValue = IntPtr.Zero;
                return err;
            }
            IntPtr tuple;
            HalconAPI.GetOutputTuple(proc, parIndex, out tuple);
            err = HalconAPI.HCkSingle(tuple, HTupleType.INTEGER);
            if (err == 2)
                return HalconAPI.GetIP(tuple, 0, out intPtrValue);
            intPtrValue = IntPtr.Zero;
            return err;
        }

        //[DllImport("halconxl", EntryPoint = "HLIGetIArr", CallingConvention = CallingConvention.Cdecl)]
        internal static int GetIArr(IntPtr tuple, [Out] int[] intArray)
        {
            return 1;
        }

        //[DllImport("halconxl", EntryPoint = "HLIGetLArr", CallingConvention = CallingConvention.Cdecl)]
        internal static int GetLArr(IntPtr tuple, [Out] long[] longArray)
        {
            return 1;
        }

        //[DllImport("halconxl", EntryPoint = "HLIGetDArr", CallingConvention = CallingConvention.Cdecl)]
        internal static int GetDArr(IntPtr tuple, [Out] double[] doubleArray)
        {
            return 1;
        }

        /// <summary>
        /// Unpin the tuple's data, but first check if tuple is null. Notice that
        /// PinTuple happens in HTuple as side effect of store.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void UnpinTuple(HTuple tuple)
        {
            tuple?.UnpinTuple();
        }

        //[DllImport("halconxl", CallingConvention = CallingConvention.Cdecl)]
        internal static int HWindowStackPush(long win_handle)
        {
            return 1;
        }

        //[DllImport("halconxl", CallingConvention = CallingConvention.Cdecl)]
        internal static  int HWindowStackPop(out long win_handle)
        {
            win_handle = 0;
            return 1;
        }

        //[DllImport("halconxl", CallingConvention = CallingConvention.Cdecl)]
        internal static int HWindowStackGetActive(out long win_handle)
        {
            win_handle = 0;
            return 1;
        }

        //[DllImport("halconxl", CallingConvention = CallingConvention.Cdecl)]
        internal static int HWindowStackSetActive(long win_handle)
        {
            return 1;
        }

        //[DllImport("halconxl", CallingConvention = CallingConvention.Cdecl)]
        internal static int HWindowStackIsOpen(out bool is_open)
        {
            is_open = false;
            return 2;
        }

        //[DllImport("halconxl", CallingConvention = CallingConvention.Cdecl)]
        internal static int HWindowStackCloseAll()
        {
            return 1;
        }

        internal static bool IsError(int err)
        {
            return err >= 1000;
        }

        internal static bool IsFailure(int err)
        {
            if (err != 2)
                return err != 2;
            return false;
        }

        internal static void HCkP(IntPtr proc, int err)
        {
            if (!HalconAPI.IsFailure(err))
                return;
            HalconAPI.PostCall(proc, err);
        }

        public delegate int HFramegrabberCallback(IntPtr handle, IntPtr userContext, IntPtr context);

        public delegate void HProgressBarCallback(
          IntPtr id,
          string operatorName,
          double progress,
          string message);

        public delegate void HLowLevelErrorCallback(string err);

        public delegate void HClearProcCallBack(IntPtr ptr);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate IntPtr HDevThreadInternalCallback(IntPtr devThread);
    }
}
