// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HTupleVoid
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;

namespace HalconDotNet
{
    internal class HTupleVoid : HTupleImplementation
    {
        public static HTupleVoid EMPTY = new HTupleVoid();

        protected override Array CreateArray(int size)
        {
            return (Array)new int[0];
        }

        private HTupleVoid()
        {
            this.SetArray((Array)null, false);
        }

        public override void AssertSize(int index)
        {
            throw new HTupleAccessException((HTupleImplementation)this);
        }

        public override HTupleType Type
        {
            get
            {
                return HTupleType.EMPTY;
            }
        }

        public override int[] ToIArr()
        {
            return new int[0];
        }

        public override long[] ToLArr()
        {
            return new long[0];
        }

        public override double[] ToDArr()
        {
            return new double[0];
        }

        public override float[] ToFArr()
        {
            return new float[0];
        }

        public override IntPtr[] ToIPArr()
        {
            return new IntPtr[0];
        }

        protected override void StoreData(IntPtr proc, IntPtr tuple)
        {
        }
    }
}