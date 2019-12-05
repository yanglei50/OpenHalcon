// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HSystem
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;

namespace HalconDotNet
{
    /// <summary>Class grouping system information and manipulation related functionality.</summary>
    public class HSystem
    {
        /// <summary>Delaying the execution of the program.</summary>
        /// <param name="seconds">Number of seconds by which the execution of the program will be delayed. Default: 10</param>
        public static void WaitSeconds(double seconds)
        {
            IntPtr proc = HalconAPI.PreCall(315);
            HalconAPI.StoreD(proc, 0, seconds);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Execute a system command.</summary>
        /// <param name="command">Command to be called by the system. Default: "ls"</param>
        public static void SystemCall(string command)
        {
            IntPtr proc = HalconAPI.PreCall(316);
            HalconAPI.StoreS(proc, 0, command);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Set HALCON system parameters.</summary>
        /// <param name="systemParameter">Name of the system parameter to be changed. Default: "init_new_image"</param>
        /// <param name="value">New value of the system parameter. Default: "true"</param>
        public static void SetSystem(HTuple systemParameter, HTuple value)
        {
            IntPtr proc = HalconAPI.PreCall(317);
            HalconAPI.Store(proc, 0, systemParameter);
            HalconAPI.Store(proc, 1, value);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(systemParameter);
            HalconAPI.UnpinTuple(value);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Set HALCON system parameters.</summary>
        /// <param name="systemParameter">Name of the system parameter to be changed. Default: "init_new_image"</param>
        /// <param name="value">New value of the system parameter. Default: "true"</param>
        public static void SetSystem(string systemParameter, string value)
        {
            IntPtr proc = HalconAPI.PreCall(317);
            HalconAPI.StoreS(proc, 0, systemParameter);
            HalconAPI.StoreS(proc, 1, value);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Activating and deactivating of HALCON control modes.</summary>
        /// <param name="check">Desired control mode. Default: "default"</param>
        public static void SetCheck(HTuple check)
        {
            IntPtr proc = HalconAPI.PreCall(318);
            HalconAPI.Store(proc, 0, check);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(check);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Activating and deactivating of HALCON control modes.</summary>
        /// <param name="check">Desired control mode. Default: "default"</param>
        public static void SetCheck(string check)
        {
            IntPtr proc = HalconAPI.PreCall(318);
            HalconAPI.StoreS(proc, 0, check);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Initialization of the HALCON system.</summary>
        /// <param name="defaultImageWidth">Default image width (in pixels). Default: 128</param>
        /// <param name="defaultImageHeight">Default image height (in pixels). Default: 128</param>
        /// <param name="defaultChannels">Usual number of channels. Default: 0</param>
        public static void ResetObjDb(
          int defaultImageWidth,
          int defaultImageHeight,
          int defaultChannels)
        {
            IntPtr proc = HalconAPI.PreCall(319);
            HalconAPI.StoreI(proc, 0, defaultImageWidth);
            HalconAPI.StoreI(proc, 1, defaultImageHeight);
            HalconAPI.StoreI(proc, 2, defaultChannels);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Get current value of HALCON system parameters.</summary>
        /// <param name="query">Desired system parameter. Default: "init_new_image"</param>
        /// <returns>Current value of the system parameter.</returns>
        public static HTuple GetSystem(HTuple query)
        {
            IntPtr proc = HalconAPI.PreCall(320);
            HalconAPI.Store(proc, 0, query);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(query);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Get current value of HALCON system parameters.</summary>
        /// <param name="query">Desired system parameter. Default: "init_new_image"</param>
        /// <returns>Current value of the system parameter.</returns>
        public static HTuple GetSystem(string query)
        {
            IntPtr proc = HalconAPI.PreCall(320);
            HalconAPI.StoreS(proc, 0, query);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>State of the HALCON control modes.</summary>
        /// <returns>Tuplet of the currently activated control modes.</returns>
        public static HTuple GetCheck()
        {
            IntPtr proc = HalconAPI.PreCall(321);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Inquiry after the error text of a HALCON error number.</summary>
        /// <param name="errorCode">HALCON error code.</param>
        /// <returns>Corresponding error message.</returns>
        public static string GetErrorText(int errorCode)
        {
            IntPtr proc = HalconAPI.PreCall(322);
            HalconAPI.StoreI(proc, 0, errorCode);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            string stringValue;
            int procResult = HalconAPI.LoadS(proc, 0, err, out stringValue);
            HalconAPI.PostCall(proc, procResult);
            return stringValue;
        }

        /// <summary>Passed Time.</summary>
        /// <returns>Processtime since the program start.</returns>
        public static double CountSeconds()
        {
            IntPtr proc = HalconAPI.PreCall(323);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            return doubleValue;
        }

        /// <summary>Number of entries in the HALCON database.</summary>
        /// <param name="relationName">Relation of interest of the HALCON database. Default: "object"</param>
        /// <returns>Number of tuples in the relation.</returns>
        public static int CountRelation(string relationName)
        {
            IntPtr proc = HalconAPI.PreCall(324);
            HalconAPI.StoreS(proc, 0, relationName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            return intValue;
        }

        /// <summary>Returns the extended error information for the calling thread's last HALCON error.</summary>
        /// <param name="errorCode">Extended error code.</param>
        /// <param name="errorMessage">Extended error message.</param>
        /// <returns>Operator that set the error code.</returns>
        public static string GetExtendedErrorInfo(out int errorCode, out string errorMessage)
        {
            IntPtr proc = HalconAPI.PreCall(344);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            string stringValue;
            int err2 = HalconAPI.LoadS(proc, 0, err1, out stringValue);
            int err3 = HalconAPI.LoadI(proc, 1, err2, out errorCode);
            int procResult = HalconAPI.LoadS(proc, 2, err3, out errorMessage);
            HalconAPI.PostCall(proc, procResult);
            return stringValue;
        }

        /// <summary>Query of used modules and the module key.</summary>
        /// <param name="moduleKey">Key for license manager.</param>
        /// <returns>Names of used modules.</returns>
        public static HTuple GetModules(out int moduleKey)
        {
            IntPtr proc = HalconAPI.PreCall(345);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HalconAPI.LoadI(proc, 1, err2, out moduleKey);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Inquiring for possible settings of the HALCON debugging tool.</summary>
        /// <param name="values">Corresponding state of the control modes.</param>
        /// <returns>Available control modes (see also set_spy).</returns>
        public static HTuple QuerySpy(out HTuple values)
        {
            IntPtr proc = HalconAPI.PreCall(371);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, err2, out values);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Control of the HALCON Debugging Tools.</summary>
        /// <param name="classVal">Control mode Default: "mode"</param>
        /// <param name="value">State of the control mode to be set. Default: "on"</param>
        public static void SetSpy(string classVal, HTuple value)
        {
            IntPtr proc = HalconAPI.PreCall(372);
            HalconAPI.StoreS(proc, 0, classVal);
            HalconAPI.Store(proc, 1, value);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(value);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Control of the HALCON Debugging Tools.</summary>
        /// <param name="classVal">Control mode Default: "mode"</param>
        /// <param name="value">State of the control mode to be set. Default: "on"</param>
        public static void SetSpy(string classVal, string value)
        {
            IntPtr proc = HalconAPI.PreCall(372);
            HalconAPI.StoreS(proc, 0, classVal);
            HalconAPI.StoreS(proc, 1, value);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Current configuration of the HALCON debugging-tool.</summary>
        /// <param name="classVal">Control mode Default: "mode"</param>
        /// <returns>State of the control mode.</returns>
        public static HTuple GetSpy(string classVal)
        {
            IntPtr proc = HalconAPI.PreCall(373);
            HalconAPI.StoreS(proc, 0, classVal);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Set AOP information for operators.</summary>
        /// <param name="operatorName">Operator to set information to Default: ""</param>
        /// <param name="indexName">Further specific index Default: ""</param>
        /// <param name="indexValue">Further specific address Default: ""</param>
        /// <param name="infoName">Scope of information Default: "max_threads"</param>
        /// <param name="infoValue">AOP information value</param>
        public static void SetAopInfo(
          HTuple operatorName,
          HTuple indexName,
          HTuple indexValue,
          string infoName,
          HTuple infoValue)
        {
            IntPtr proc = HalconAPI.PreCall(566);
            HalconAPI.Store(proc, 0, operatorName);
            HalconAPI.Store(proc, 1, indexName);
            HalconAPI.Store(proc, 2, indexValue);
            HalconAPI.StoreS(proc, 3, infoName);
            HalconAPI.Store(proc, 4, infoValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(operatorName);
            HalconAPI.UnpinTuple(indexName);
            HalconAPI.UnpinTuple(indexValue);
            HalconAPI.UnpinTuple(infoValue);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Set AOP information for operators.</summary>
        /// <param name="operatorName">Operator to set information to Default: ""</param>
        /// <param name="indexName">Further specific index Default: ""</param>
        /// <param name="indexValue">Further specific address Default: ""</param>
        /// <param name="infoName">Scope of information Default: "max_threads"</param>
        /// <param name="infoValue">AOP information value</param>
        public static void SetAopInfo(
          string operatorName,
          string indexName,
          string indexValue,
          string infoName,
          int infoValue)
        {
            IntPtr proc = HalconAPI.PreCall(566);
            HalconAPI.StoreS(proc, 0, operatorName);
            HalconAPI.StoreS(proc, 1, indexName);
            HalconAPI.StoreS(proc, 2, indexValue);
            HalconAPI.StoreS(proc, 3, infoName);
            HalconAPI.StoreI(proc, 4, infoValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Return AOP information for operators. </summary>
        /// <param name="operatorName">Operator to get information for</param>
        /// <param name="indexName">Further index stages Default: ["iconic_type","parameter:0"]</param>
        /// <param name="indexValue">Further index values Default: ["byte",""]</param>
        /// <param name="infoName">Scope of information Default: "max_threads"</param>
        /// <returns>Value of information</returns>
        public static HTuple GetAopInfo(
          HTuple operatorName,
          HTuple indexName,
          HTuple indexValue,
          string infoName)
        {
            IntPtr proc = HalconAPI.PreCall(567);
            HalconAPI.Store(proc, 0, operatorName);
            HalconAPI.Store(proc, 1, indexName);
            HalconAPI.Store(proc, 2, indexValue);
            HalconAPI.StoreS(proc, 3, infoName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(operatorName);
            HalconAPI.UnpinTuple(indexName);
            HalconAPI.UnpinTuple(indexValue);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Return AOP information for operators. </summary>
        /// <param name="operatorName">Operator to get information for</param>
        /// <param name="indexName">Further index stages Default: ["iconic_type","parameter:0"]</param>
        /// <param name="indexValue">Further index values Default: ["byte",""]</param>
        /// <param name="infoName">Scope of information Default: "max_threads"</param>
        /// <returns>Value of information</returns>
        public static string GetAopInfo(
          string operatorName,
          HTuple indexName,
          HTuple indexValue,
          string infoName)
        {
            IntPtr proc = HalconAPI.PreCall(567);
            HalconAPI.StoreS(proc, 0, operatorName);
            HalconAPI.Store(proc, 1, indexName);
            HalconAPI.Store(proc, 2, indexValue);
            HalconAPI.StoreS(proc, 3, infoName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(indexName);
            HalconAPI.UnpinTuple(indexValue);
            string stringValue;
            int procResult = HalconAPI.LoadS(proc, 0, err, out stringValue);
            HalconAPI.PostCall(proc, procResult);
            return stringValue;
        }

        /// <summary>Query indexing structure of AOP information for operators. </summary>
        /// <param name="operatorName">Operator to get information for Default: ""</param>
        /// <param name="indexName">Further specific index Default: ""</param>
        /// <param name="indexValue">Further specific address Default: ""</param>
        /// <param name="value">Values of next index stage</param>
        /// <returns>Name of next index stage</returns>
        public static HTuple QueryAopInfo(
          HTuple operatorName,
          HTuple indexName,
          HTuple indexValue,
          out HTuple value)
        {
            IntPtr proc = HalconAPI.PreCall(568);
            HalconAPI.Store(proc, 0, operatorName);
            HalconAPI.Store(proc, 1, indexName);
            HalconAPI.Store(proc, 2, indexValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(operatorName);
            HalconAPI.UnpinTuple(indexName);
            HalconAPI.UnpinTuple(indexValue);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, err2, out value);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Query indexing structure of AOP information for operators. </summary>
        /// <param name="operatorName">Operator to get information for Default: ""</param>
        /// <param name="indexName">Further specific index Default: ""</param>
        /// <param name="indexValue">Further specific address Default: ""</param>
        /// <param name="value">Values of next index stage</param>
        /// <returns>Name of next index stage</returns>
        public static HTuple QueryAopInfo(
          string operatorName,
          string indexName,
          string indexValue,
          out HTuple value)
        {
            IntPtr proc = HalconAPI.PreCall(568);
            HalconAPI.StoreS(proc, 0, operatorName);
            HalconAPI.StoreS(proc, 1, indexName);
            HalconAPI.StoreS(proc, 2, indexValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, err2, out value);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Check hardware regarding its potential for automatic operator parallelization.</summary>
        /// <param name="operatorName">Operators to check Default: ""</param>
        /// <param name="iconicType">Iconic object types to check Default: ""</param>
        /// <param name="fileName">Knowledge file name Default: ""</param>
        /// <param name="genParamName">Parameter name Default: "none"</param>
        /// <param name="genParamValue">Parameter value Default: "none"</param>
        public static void OptimizeAop(
          HTuple operatorName,
          HTuple iconicType,
          HTuple fileName,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(569);
            HalconAPI.Store(proc, 0, operatorName);
            HalconAPI.Store(proc, 1, iconicType);
            HalconAPI.Store(proc, 2, fileName);
            HalconAPI.Store(proc, 3, genParamName);
            HalconAPI.Store(proc, 4, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(operatorName);
            HalconAPI.UnpinTuple(iconicType);
            HalconAPI.UnpinTuple(fileName);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Check hardware regarding its potential for automatic operator parallelization.</summary>
        /// <param name="operatorName">Operators to check Default: ""</param>
        /// <param name="iconicType">Iconic object types to check Default: ""</param>
        /// <param name="fileName">Knowledge file name Default: ""</param>
        /// <param name="genParamName">Parameter name Default: "none"</param>
        /// <param name="genParamValue">Parameter value Default: "none"</param>
        public static void OptimizeAop(
          string operatorName,
          string iconicType,
          string fileName,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(569);
            HalconAPI.StoreS(proc, 0, operatorName);
            HalconAPI.StoreS(proc, 1, iconicType);
            HalconAPI.StoreS(proc, 2, fileName);
            HalconAPI.Store(proc, 3, genParamName);
            HalconAPI.Store(proc, 4, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Write knowledge about hardware dependent behavior of automatic operator parallelization to file.</summary>
        /// <param name="fileName">Name of knowledge file Default: ""</param>
        /// <param name="genParamName">Parameter name Default: "none"</param>
        /// <param name="genParamValue">Parameter value Default: "none"</param>
        public static void WriteAopKnowledge(
          string fileName,
          HTuple genParamName,
          HTuple genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(570);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.Store(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Write knowledge about hardware dependent behavior of automatic operator parallelization to file.</summary>
        /// <param name="fileName">Name of knowledge file Default: ""</param>
        /// <param name="genParamName">Parameter name Default: "none"</param>
        /// <param name="genParamValue">Parameter value Default: "none"</param>
        public static void WriteAopKnowledge(
          string fileName,
          string genParamName,
          string genParamValue)
        {
            IntPtr proc = HalconAPI.PreCall(570);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.StoreS(proc, 2, genParamValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Load knowledge about hardware dependent behavior of automatic operator parallelization.</summary>
        /// <param name="fileName">Name of knowledge file Default: ""</param>
        /// <param name="genParamName">Parameter name Default: "none"</param>
        /// <param name="genParamValue">Parameter value Default: "none"</param>
        /// <param name="operatorNames">Updated Operators</param>
        /// <returns>Knowledge attributes</returns>
        public static HTuple ReadAopKnowledge(
          string fileName,
          HTuple genParamName,
          HTuple genParamValue,
          out HTuple operatorNames)
        {
            IntPtr proc = HalconAPI.PreCall(571);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.Store(proc, 1, genParamName);
            HalconAPI.Store(proc, 2, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(genParamName);
            HalconAPI.UnpinTuple(genParamValue);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HTuple.LoadNew(proc, 1, err2, out operatorNames);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Load knowledge about hardware dependent behavior of automatic operator parallelization.</summary>
        /// <param name="fileName">Name of knowledge file Default: ""</param>
        /// <param name="genParamName">Parameter name Default: "none"</param>
        /// <param name="genParamValue">Parameter value Default: "none"</param>
        /// <param name="operatorNames">Updated Operators</param>
        /// <returns>Knowledge attributes</returns>
        public static HTuple ReadAopKnowledge(
          string fileName,
          string genParamName,
          string genParamValue,
          out string operatorNames)
        {
            IntPtr proc = HalconAPI.PreCall(571);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.StoreS(proc, 1, genParamName);
            HalconAPI.StoreS(proc, 2, genParamValue);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int err2 = HTuple.LoadNew(proc, 0, err1, out tuple);
            int procResult = HalconAPI.LoadS(proc, 1, err2, out operatorNames);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Specify a window type.</summary>
        /// <param name="windowType">Name of the window type which has to be set. Default: "X-Window"</param>
        public static void SetWindowType(string windowType)
        {
            IntPtr proc = HalconAPI.PreCall(1173);
            HalconAPI.StoreS(proc, 0, windowType);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Get window characteristics.</summary>
        /// <param name="attributeName">Name of the attribute that should be returned.</param>
        /// <returns>Attribute value.</returns>
        public static HTuple GetWindowAttr(string attributeName)
        {
            IntPtr proc = HalconAPI.PreCall(1175);
            HalconAPI.StoreS(proc, 0, attributeName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            return tuple;
        }

        /// <summary>Set window characteristics.</summary>
        /// <param name="attributeName">Name of the attribute that should be modified.</param>
        /// <param name="attributeValue">Value of the attribute that should be set.</param>
        public static void SetWindowAttr(string attributeName, HTuple attributeValue)
        {
            IntPtr proc = HalconAPI.PreCall(1176);
            HalconAPI.StoreS(proc, 0, attributeName);
            HalconAPI.Store(proc, 1, attributeValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(attributeValue);
            HalconAPI.PostCall(proc, procResult);
        }

        /// <summary>Set window characteristics.</summary>
        /// <param name="attributeName">Name of the attribute that should be modified.</param>
        /// <param name="attributeValue">Value of the attribute that should be set.</param>
        public static void SetWindowAttr(string attributeName, string attributeValue)
        {
            IntPtr proc = HalconAPI.PreCall(1176);
            HalconAPI.StoreS(proc, 0, attributeName);
            HalconAPI.StoreS(proc, 1, attributeValue);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
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
    }
}
