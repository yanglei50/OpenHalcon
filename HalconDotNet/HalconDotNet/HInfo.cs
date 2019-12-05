// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HInfo
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;

namespace HalconDotNet
{
    /// <summary>Class grouping system information related functionality.</summary>
    public class HInfo
    {
        /// <summary>Query slots concerning information with relation to the operator get_operator_info.</summary>
        /// <returns>Slotnames of the operator get_operator_info.</returns>
        public static HTuple QueryOperatorInfo()
        {
            IntPtr proc = HalconAPI.PreCall(1108);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Query slots of the online-information concerning the operator get_param_info.</summary>
        /// <returns>Slotnames for the operator get_param_info.</returns>
        public static HTuple QueryParamInfo()
        {
            IntPtr proc = HalconAPI.PreCall(1109);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Get operators with the given string as a substring of their name.</summary>
        /// <param name="pattern">Substring of the seeked names (empty $ less than = greater than $ all names). Default: "info"</param>
        /// <returns>Detected operator names.</returns>
        public static HTuple GetOperatorName(string pattern)
        {
            IntPtr proc = HalconAPI.PreCall(1110);
            HalconAPI.StoreS(proc, 0, pattern);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Get default data type for the control parameters of a HALCON-operator.</summary>
        /// <param name="operatorName">Name of the operator. Default: "get_param_types"</param>
        /// <param name="outpCtrlParType">Default type of the output control parameters.</param>
        /// <returns>Default type of the input control parameters.</returns>
        public static HTuple GetParamTypes(string operatorName, out HTuple outpCtrlParType)
        {
            IntPtr proc = HalconAPI.PreCall(1111);
            HalconAPI.StoreS(proc, 0, operatorName);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, err2, out outpCtrlParType);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Get number of the different parameter classes of a HALCON-operator.</summary>
        /// <param name="operatorName">Name of the operator. Default: "get_param_num"</param>
        /// <param name="inpObjPar">Number of the input object parameters.</param>
        /// <param name="outpObjPar">Number of the output object parameters.</param>
        /// <param name="inpCtrlPar">Number of the input control parameters.</param>
        /// <param name="outpCtrlPar">Number of the output control parameters.</param>
        /// <param name="type">System operator or user procedure.</param>
        /// <returns>Name of the called C-function.</returns>
        public static string GetParamNum(
          string operatorName,
          out int inpObjPar,
          out int outpObjPar,
          out int inpCtrlPar,
          out int outpCtrlPar,
          out string type)
        {
            IntPtr proc = HalconAPI.PreCall(1112);
            HalconAPI.StoreS(proc, 0, operatorName);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            HalconAPI.InitOCT(proc, 4);
            HalconAPI.InitOCT(proc, 5);
            int err1 = HalconAPI.CallProcedure(proc);
            string stringValue;
            int err2 = HalconAPI.LoadS(proc, 0, err1, out stringValue);
            int err3 = HalconAPI.LoadI(proc, 1, err2, out inpObjPar);
            int err4 = HalconAPI.LoadI(proc, 2, err3, out outpObjPar);
            int err5 = HalconAPI.LoadI(proc, 3, err4, out inpCtrlPar);
            int err6 = HalconAPI.LoadI(proc, 4, err5, out outpCtrlPar);
            int procResult = HalconAPI.LoadS(proc, 5, err6, out type);
            HalconAPI.PostCall(proc, procResult);
            return stringValue;
        }

        /// <summary>Get the names of the parameters of a HALCON-operator.</summary>
        /// <param name="operatorName">Name of the operator. Default: "get_param_names"</param>
        /// <param name="outpObjPar">Names of the output objects.</param>
        /// <param name="inpCtrlPar">Names of the input control parameters.</param>
        /// <param name="outpCtrlPar">Names of the output control parameters.</param>
        /// <returns>Names of the input objects.</returns>
        public static HTuple GetParamNames(
          string operatorName,
          out HTuple outpObjPar,
          out HTuple inpCtrlPar,
          out HTuple outpCtrlPar)
        {
            IntPtr proc = HalconAPI.PreCall(1113);
            HalconAPI.StoreS(proc, 0, operatorName);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int err3 = HTuple.LoadNew(proc, 1, err2, out outpObjPar);
            int err4 = HTuple.LoadNew(proc, 2, err3, out inpCtrlPar);
            int procResult = HTuple.LoadNew(proc, 3, err4, out outpCtrlPar);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Get information concerning a HALCON-operator.</summary>
        /// <param name="operatorName">Name of the operator on which more information is needed. Default: "get_operator_info"</param>
        /// <param name="slot">Desired information. Default: "abstract"</param>
        /// <returns>Information (empty if no information is available)</returns>
        public static HTuple GetOperatorInfo(string operatorName, string slot)
        {
            IntPtr proc = HalconAPI.PreCall(1114);
            HalconAPI.StoreS(proc, 0, operatorName);
            HalconAPI.StoreS(proc, 1, slot);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Get information concerning the operator parameters.</summary>
        /// <param name="operatorName">Name of the operator on whose parameter more information is needed. Default: "get_param_info"</param>
        /// <param name="paramName">Name of the parameter on which more information is needed. Default: "Slot"</param>
        /// <param name="slot">Desired information. Default: "description"</param>
        /// <returns>Information (empty in case there is no information available).</returns>
        public static HTuple GetParamInfo(string operatorName, string paramName, string slot)
        {
            IntPtr proc = HalconAPI.PreCall(1115);
            HalconAPI.StoreS(proc, 0, operatorName);
            HalconAPI.StoreS(proc, 1, paramName);
            HalconAPI.StoreS(proc, 2, slot);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Search names of all operators assigned to one keyword.</summary>
        /// <param name="keyword">Keyword for which corresponding operators are searched. Default: "Information"</param>
        /// <returns>Operators whose slot 'keyword' contains the keyword.</returns>
        public static HTuple SearchOperator(string keyword)
        {
            IntPtr proc = HalconAPI.PreCall(1116);
            HalconAPI.StoreS(proc, 0, keyword);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Get keywords which are assigned to operators.</summary>
        /// <param name="operatorName">Substring in the names of those operators for which keywords are needed. Default: "get_keywords"</param>
        /// <returns>Keywords for the operators.</returns>
        public static HTuple GetKeywords(string operatorName)
        {
            IntPtr proc = HalconAPI.PreCall(1117);
            HalconAPI.StoreS(proc, 0, operatorName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Get information concerning the chapters on operators.</summary>
        /// <param name="chapter">Operator class or subclass of interest. Default: ""</param>
        /// <returns>Operator classes (Chapter = ") or operator subclasses respectively operators.</returns>
        public static HTuple GetChapterInfo(HTuple chapter)
        {
            IntPtr proc = HalconAPI.PreCall(1118);
            HalconAPI.Store(proc, 0, chapter);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(chapter);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Get information concerning the chapters on operators.</summary>
        /// <param name="chapter">Operator class or subclass of interest. Default: ""</param>
        /// <returns>Operator classes (Chapter = ") or operator subclasses respectively operators.</returns>
        public static HTuple GetChapterInfo(string chapter)
        {
            IntPtr proc = HalconAPI.PreCall(1118);
            HalconAPI.StoreS(proc, 0, chapter);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Query all available window types.</summary>
        /// <returns>Names of available window types.</returns>
        public static HTuple QueryWindowType()
        {
            IntPtr proc = HalconAPI.PreCall(1177);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Get the output treatment of an image matrix.</summary>
        /// <param name="windowHandle">Window handle.</param>
        /// <returns>Display mode for images.</returns>
        public static string GetComprise(HWindow windowHandle)
        {
            IntPtr proc = HalconAPI.PreCall(1251);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            string stringValue;
            int procResult = HalconAPI.LoadS(proc, 0, err, out stringValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)windowHandle);
            return stringValue;
        }

        /// <summary>Query the region display modes.</summary>
        /// <returns>region display mode names.</returns>
        public static HTuple QueryShape()
        {
            IntPtr proc = HalconAPI.PreCall(1252);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Query the possible line widths.</summary>
        /// <param name="min">Displayable minimum width.</param>
        /// <param name="max">Displayable maximum width.</param>
        public static void QueryLineWidth(out int min, out int max)
        {
            IntPtr proc = HalconAPI.PreCall(1254);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadI(proc, 0, err1, out min);
            int procResult = HalconAPI.LoadI(proc, 1, err2, out max);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Query the number of colors for color output.</summary>
        /// <returns>Tuple of the possible numbers of colors.</returns>
        public static HTuple QueryColored()
        {
            IntPtr proc = HalconAPI.PreCall(1257);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Query information about the specified image acquisition interface.</summary>
        /// <param name="name">HALCON image acquisition interface name, i.e., name of the corresponding DLL (Windows) or shared library (Linux/macOS). Default: "File"</param>
        /// <param name="query">Name of the chosen query. Default: "info_boards"</param>
        /// <param name="valueList">List of values (according to Query).</param>
        /// <returns>Textual information (according to Query).</returns>
        public static string InfoFramegrabber(string name, string query, out HTuple valueList)
        {
            IntPtr proc = HalconAPI.PreCall(2034);
            HalconAPI.StoreS(proc, 0, name);
            HalconAPI.StoreS(proc, 1, query);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            string stringValue;
            int err2 = HalconAPI.LoadS(proc, 0, err1, out stringValue);
            int procResult = HTuple.LoadNew(proc, 1, err2, out valueList);
            HalconAPI.PostCall(proc, procResult);
            return stringValue;
        }
    }
}
