// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HTupleElementsInt32
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

namespace HalconDotNet
{
    internal class HTupleElementsInt32 : HTupleElementsImplementation
    {
        internal HTupleElementsInt32(HTupleInt32 source, int index)
          : base((HTupleImplementation)source, index)
        {
        }

        internal HTupleElementsInt32(HTupleInt32 source, int[] indices)
          : base((HTupleImplementation)source, indices)
        {
        }

        public override int[] getI()
        {
            if (this.indices == null)
                return (int[])null;
            int[] numArray = new int[this.indices.Length];
            for (int index = 0; index < this.indices.Length; ++index)
                numArray[index] = this.source.IArr[this.indices[index]];
            return numArray;
        }

        public override void setI(int[] i)
        {
            if (i == null)
                return;
            if (i.Length <= 1)
            {
                for (int index = 0; index < i.Length; ++index)
                    this.source.IArr[this.indices[index]] = i[0];
            }
            else
            {
                if (i.Length != this.indices.Length)
                    throw new HTupleAccessException(this.source, "Input parameter 2 ('Value') must have one element or the same number of elements as parameter 1 ('Index')");
                for (int index = 0; index < i.Length; ++index)
                    this.source.IArr[this.indices[index]] = i[index];
            }
        }

        public override long[] getL()
        {
            if (this.indices == null)
                return (long[])null;
            long[] numArray = new long[this.indices.Length];
            for (int index = 0; index < this.indices.Length; ++index)
                numArray[index] = (long)this.source.IArr[this.indices[index]];
            return numArray;
        }

        public override void setL(long[] l)
        {
            if (l == null)
                return;
            if (l.Length <= 1)
            {
                for (int index = 0; index < l.Length; ++index)
                    this.source.IArr[this.indices[index]] = (int)l[0];
            }
            else
            {
                if (l.Length != this.indices.Length)
                    throw new HTupleAccessException(this.source, "Input parameter 2 ('Value') must have one element or the same number of elements as parameter 1 ('Index')");
                for (int index = 0; index < l.Length; ++index)
                    this.source.IArr[this.indices[index]] = (int)l[index];
            }
        }

        public override double[] getD()
        {
            if (this.indices == null)
                return (double[])null;
            double[] numArray = new double[this.indices.Length];
            for (int index = 0; index < this.indices.Length; ++index)
                numArray[index] = (double)this.source.IArr[this.indices[index]];
            return numArray;
        }

        public override object[] getO()
        {
            if (this.indices == null)
                return (object[])null;
            object[] objArray = new object[this.indices.Length];
            for (int index = 0; index < this.indices.Length; ++index)
                objArray[index] = (object)this.source.IArr[this.indices[index]];
            return objArray;
        }

        public override HTupleType getType()
        {
            return HTupleType.INTEGER;
        }
    }
}
