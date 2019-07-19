// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HTupleElementsDouble
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

namespace HalconDotNet
{
    internal class HTupleElementsDouble : HTupleElementsImplementation
    {
        internal HTupleElementsDouble(HTupleDouble source, int index)
          : base((HTupleImplementation)source, index)
        {
        }

        internal HTupleElementsDouble(HTupleDouble source, int[] indices)
          : base((HTupleImplementation)source, indices)
        {
        }

        public override double[] getD()
        {
            if (this.indices == null)
                return (double[])null;
            double[] numArray = new double[this.indices.Length];
            for (int index = 0; index < this.indices.Length; ++index)
                numArray[index] = this.source.DArr[this.indices[index]];
            return numArray;
        }

        public override void setD(double[] d)
        {
            if (d == null)
                return;
            if (d.Length <= 1)
            {
                for (int index = 0; index < d.Length; ++index)
                    this.source.DArr[this.indices[index]] = d[0];
            }
            else
            {
                if (d.Length != this.indices.Length)
                    throw new HTupleAccessException(this.source, "Input parameter 2 ('Value') must have one element or the same number of elements as parameter 1 ('Index')");
                for (int index = 0; index < d.Length; ++index)
                    this.source.DArr[this.indices[index]] = d[index];
            }
        }

        public override object[] getO()
        {
            if (this.indices == null)
                return (object[])null;
            object[] objArray = new object[this.indices.Length];
            for (int index = 0; index < this.indices.Length; ++index)
                objArray[index] = (object)this.source.DArr[this.indices[index]];
            return objArray;
        }

        public override HTupleType getType()
        {
            return HTupleType.DOUBLE;
        }
    }
}
