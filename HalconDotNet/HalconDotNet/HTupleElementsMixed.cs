// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HTupleElementsMixed
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

namespace HalconDotNet
{
    internal class HTupleElementsMixed : HTupleElementsImplementation
    {
        internal HTupleElementsMixed(HTupleMixed source, int index)
          : base((HTupleImplementation)source, index)
        {
        }

        internal HTupleElementsMixed(HTupleMixed source, int[] indices)
          : base((HTupleImplementation)source, indices)
        {
        }

        public override int[] getI()
        {
            if (this.indices == null)
                return (int[])null;
            switch (this.getType())
            {
                case HTupleType.INTEGER:
                    int[] numArray1 = new int[this.indices.Length];
                    for (int index = 0; index < this.indices.Length; ++index)
                        numArray1[index] = (int)this.source.OArr[this.indices[index]];
                    return numArray1;
                case HTupleType.LONG:
                    int[] numArray2 = new int[this.indices.Length];
                    for (int index = 0; index < this.indices.Length; ++index)
                        numArray2[index] = (int)(long)this.source.OArr[this.indices[index]];
                    return numArray2;
                default:
                    throw new HTupleAccessException(this.source, "Mixed tuple does not contain integer " + (this.indices.Length == 1 ? "value at index " + (object)this.indices[0] : "values at given indices"));
            }
        }

        public override long[] getL()
        {
            if (this.indices == null)
                return (long[])null;
            switch (this.getType())
            {
                case HTupleType.INTEGER:
                    long[] numArray1 = new long[this.indices.Length];
                    for (int index = 0; index < this.indices.Length; ++index)
                        numArray1[index] = (long)(int)this.source.OArr[this.indices[index]];
                    return numArray1;
                case HTupleType.LONG:
                    long[] numArray2 = new long[this.indices.Length];
                    for (int index = 0; index < this.indices.Length; ++index)
                        numArray2[index] = (long)this.source.OArr[this.indices[index]];
                    return numArray2;
                default:
                    throw new HTupleAccessException(this.source, "Mixed tuple does not contain integer " + (this.indices.Length == 1 ? "value at index " + (object)this.indices[0] : "values at given indices"));
            }
        }

        public override double[] getD()
        {
            if (this.indices == null)
                return (double[])null;
            switch (this.getType())
            {
                case HTupleType.INTEGER:
                    double[] numArray1 = new double[this.indices.Length];
                    for (int index = 0; index < this.indices.Length; ++index)
                        numArray1[index] = (double)(int)this.source.OArr[this.indices[index]];
                    return numArray1;
                case HTupleType.DOUBLE:
                    double[] numArray2 = new double[this.indices.Length];
                    for (int index = 0; index < this.indices.Length; ++index)
                        numArray2[index] = (double)this.source.OArr[this.indices[index]];
                    return numArray2;
                case HTupleType.LONG:
                    double[] numArray3 = new double[this.indices.Length];
                    for (int index = 0; index < this.indices.Length; ++index)
                        numArray3[index] = (double)(long)this.source.OArr[this.indices[index]];
                    return numArray3;
                default:
                    throw new HTupleAccessException(this.source, "Mixed tuple does not contain numeric " + (this.indices.Length == 1 ? "value at index " + (object)this.indices[0] : "values at given indices"));
            }
        }

        public override string[] getS()
        {
            if (this.indices == null)
                return (string[])null;
            if (this.getType() != HTupleType.STRING)
                throw new HTupleAccessException(this.source, "Mixed tuple does not contain string " + (this.indices.Length == 1 ? "value at index " + (object)this.indices[0] : "values at given indices"));
            string[] strArray = new string[this.indices.Length];
            for (int index = 0; index < this.indices.Length; ++index)
                strArray[index] = (string)this.source.OArr[this.indices[index]];
            return strArray;
        }

        public override object[] getO()
        {
            if (this.indices == null)
                return (object[])null;
            object[] objArray = new object[this.indices.Length];
            for (int index = 0; index < this.indices.Length; ++index)
                objArray[index] = this.source.OArr[this.indices[index]];
            return objArray;
        }

        public override void setI(int[] i)
        {
            if (i == null)
                return;
            if (i.Length <= 1)
            {
                for (int index = 0; index < i.Length; ++index)
                    this.source.OArr[this.indices[index]] = (object)i[0];
            }
            else
            {
                if (i.Length != this.indices.Length)
                    throw new HTupleAccessException(this.source, "Input parameter 2 ('Value') must have one element or the same number of elements as parameter 1 ('Index')");
                for (int index = 0; index < i.Length; ++index)
                    this.source.OArr[this.indices[index]] = (object)i[index];
            }
        }

        public override void setL(long[] l)
        {
            if (l == null)
                return;
            if (l.Length <= 1)
            {
                for (int index = 0; index < l.Length; ++index)
                    this.source.OArr[this.indices[index]] = (object)l[0];
            }
            else
            {
                if (l.Length != this.indices.Length)
                    throw new HTupleAccessException(this.source, "Input parameter 2 ('Value') must have one element or the same number of elements as parameter 1 ('Index')");
                for (int index = 0; index < l.Length; ++index)
                    this.source.OArr[this.indices[index]] = (object)l[index];
            }
        }

        public override void setD(double[] d)
        {
            if (d == null)
                return;
            if (d.Length <= 1)
            {
                for (int index = 0; index < d.Length; ++index)
                    this.source.OArr[this.indices[index]] = (object)d[0];
            }
            else
            {
                if (d.Length != this.indices.Length)
                    throw new HTupleAccessException(this.source, "Input parameter 2 ('Value') must have one element or the same number of elements as parameter 1 ('Index')");
                for (int index = 0; index < d.Length; ++index)
                    this.source.OArr[this.indices[index]] = (object)d[index];
            }
        }

        public override void setS(string[] s)
        {
            if (s == null)
                return;
            if (s.Length <= 1)
            {
                for (int index = 0; index < s.Length; ++index)
                    this.source.OArr[this.indices[index]] = (object)s[0];
            }
            else
            {
                if (s.Length != this.indices.Length)
                    throw new HTupleAccessException(this.source, "Input parameter 2 ('Value') must have one element or the same number of elements as parameter 1 ('Index')");
                for (int index = 0; index < s.Length; ++index)
                    this.source.OArr[this.indices[index]] = (object)s[index];
            }
        }

        public override void setO(object[] o)
        {
            if (o == null)
                return;
            if (o.Length <= 1)
            {
                for (int index = 0; index < o.Length; ++index)
                    this.source.OArr[this.indices[index]] = o[0];
            }
            else
            {
                if (o.Length != this.indices.Length)
                    throw new HTupleAccessException(this.source, "Input parameter 2 ('Value') must have one element or the same number of elements as parameter 1 ('Index')");
                for (int index = 0; index < o.Length; ++index)
                    this.source.OArr[this.indices[index]] = o[index];
            }
        }

        public override HTupleType getType()
        {
            return ((HTupleMixed)this.source).GetElementType(this.indices);
        }
    }
}
