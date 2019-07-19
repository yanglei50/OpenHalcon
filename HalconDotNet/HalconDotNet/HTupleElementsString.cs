// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HTupleElementsString
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

namespace HalconDotNet
{
    internal class HTupleElementsString : HTupleElementsImplementation
    {
        internal HTupleElementsString(HTupleString source, int index)
          : base((HTupleImplementation)source, index)
        {
        }

        internal HTupleElementsString(HTupleString source, int[] indices)
          : base((HTupleImplementation)source, indices)
        {
        }

        public override string[] getS()
        {
            if (this.indices == null)
                return (string[])null;
            string[] strArray = new string[this.indices.Length];
            for (int index = 0; index < this.indices.Length; ++index)
                strArray[index] = this.source.SArr[this.indices[index]];
            return strArray;
        }

        public override void setS(string[] s)
        {
            if (s == null)
                return;
            if (s.Length <= 1)
            {
                for (int index = 0; index < s.Length; ++index)
                    this.source.SArr[this.indices[index]] = s[0];
            }
            else
            {
                if (s.Length != this.indices.Length)
                    throw new HTupleAccessException(this.source, "Input parameter 2 ('Value') must have one element or the same number of elements as parameter 1 ('Index')");
                for (int index = 0; index < s.Length; ++index)
                    this.source.SArr[this.indices[index]] = s[index];
            }
        }

        public override object[] getO()
        {
            if (this.indices == null)
                return (object[])null;
            object[] objArray = new object[this.indices.Length];
            for (int index = 0; index < this.indices.Length; ++index)
                objArray[index] = (object)this.source.SArr[this.indices[index]];
            return objArray;
        }

        public override HTupleType getType()
        {
            return HTupleType.STRING;
        }
    }
}
