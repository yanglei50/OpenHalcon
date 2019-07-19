// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HTupleType
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

namespace HalconDotNet
{
    /// <summary>
    ///   Enumeration of tuple types, as returned by HTuple.Type
    /// </summary>
    public enum HTupleType
    {
        /// <summary>Tuple is represented by an array of System.Int32</summary>
        INTEGER = 1,
        /// <summary>Tuple is represented by an array of System.Double</summary>
        DOUBLE = 2,
        /// <summary>Tuple is represented by an array of strings</summary>
        STRING = 4,
        /// <summary>Tuple is represented by an object array of boxed values.</summary>
        MIXED = 8,
        /// <summary>Tuple is empty</summary>
        EMPTY = 15, // 0x0000000F
        /// <summary>Tuple is represented by an array of System.Int64</summary>
        LONG = 129, // 0x00000081
    }
}