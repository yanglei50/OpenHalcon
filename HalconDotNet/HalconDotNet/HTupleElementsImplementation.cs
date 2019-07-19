// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HTupleElementsImplementation
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

namespace HalconDotNet
{
    public class HTupleElementsImplementation
    {
        protected int[] indices;
        protected HTupleImplementation source;

        public HTupleElementsImplementation()
        {
            this.source = (HTupleImplementation)null;
            this.indices = new int[0];
        }

        public HTupleElementsImplementation(HTupleImplementation source, int index)
        {
            this.source = source;
            this.indices = new int[1] { index };
        }

        public HTupleElementsImplementation(HTupleImplementation source, int[] indices)
        {
            this.source = source;
            this.indices = indices;
        }

        public int[] getIndices()
        {
            return this.indices;
        }

        public int[] I
        {
            get
            {
                return this.getI();
            }
            set
            {
                this.source.AssertSize(this.indices);
                this.setI(value);
            }
        }

        public long[] L
        {
            get
            {
                return this.getL();
            }
            set
            {
                this.source.AssertSize(this.indices);
                this.setL(value);
            }
        }

        public double[] D
        {
            get
            {
                return this.getD();
            }
            set
            {
                this.source.AssertSize(this.indices);
                this.setD(value);
            }
        }

        public string[] S
        {
            get
            {
                return this.getS();
            }
            set
            {
                this.source.AssertSize(this.indices);
                this.setS(value);
            }
        }

        public object[] O
        {
            get
            {
                return this.getO();
            }
            set
            {
                this.source.AssertSize(this.indices);
                this.setO(value);
            }
        }

        public HTupleType Type
        {
            get
            {
                return this.getType();
            }
        }

        public int Length
        {
            get
            {
                return this.indices.Length;
            }
        }

        public virtual int[] getI()
        {
            throw new HTupleAccessException(this.source);
        }

        public virtual long[] getL()
        {
            throw new HTupleAccessException(this.source);
        }

        public virtual double[] getD()
        {
            throw new HTupleAccessException(this.source);
        }

        public virtual string[] getS()
        {
            throw new HTupleAccessException(this.source);
        }

        public virtual object[] getO()
        {
            throw new HTupleAccessException(this.source);
        }

        public virtual void setI(int[] i)
        {
            throw new HTupleAccessException(this.source);
        }

        public virtual void setL(long[] l)
        {
            throw new HTupleAccessException(this.source);
        }

        public virtual void setD(double[] d)
        {
            throw new HTupleAccessException(this.source);
        }

        public virtual void setS(string[] s)
        {
            throw new HTupleAccessException(this.source);
        }

        public virtual void setO(object[] o)
        {
            throw new HTupleAccessException(this.source);
        }

        public virtual HTupleType getType()
        {
            if (this.indices.Length == 0)
                return HTupleType.EMPTY;
            throw new HTupleAccessException(this.source);
        }
    }
}
