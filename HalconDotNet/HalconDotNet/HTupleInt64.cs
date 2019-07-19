// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HTupleInt64
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace HalconDotNet
{
    public class HTupleInt64 : HTupleImplementation
    {
        protected long[] l;

        protected override Array CreateArray(int size)
        {
            return (Array)new long[size];
        }

        protected override void NotifyArrayUpdate()
        {
            this.l = (long[])this.data;
        }

        internal override void PinTuple()
        {
            Monitor.Enter((object)this);
            if (this.pinCount == 0)
                this.pinHandle = GCHandle.Alloc((object)this.l, GCHandleType.Pinned);
            ++this.pinCount;
            Monitor.Exit((object)this);
        }

        public HTupleInt64(long l)
        {
            this.SetArray((Array)new long[1] { l }, false);
        }

        public HTupleInt64(long[] l, bool copy)
        {
            this.SetArray((Array)l, copy);
        }

        public override HTupleElements GetElement(int index, HTuple parent)
        {
            return new HTupleElements(parent, this, index);
        }

        public override HTupleElements GetElements(int[] indices, HTuple parent)
        {
            if (indices == null || indices.Length == 0)
                return new HTupleElements();
            return new HTupleElements(parent, this, indices);
        }

        public override void SetElements(int[] indices, HTupleElements elements)
        {
            if (indices == null || indices.Length == 0)
                return;
            long[] larr = elements.LArr;
            if (larr.Length == indices.Length)
            {
                for (int index = 0; index < indices.Length; ++index)
                    this.l[indices[index]] = larr[index];
            }
            else
            {
                if (larr.Length != 1)
                    throw new HTupleAccessException((HTupleImplementation)this, "Input parameter 2 ('Value') must have one element or the same number of elements as parameter 1 ('Index')");
                for (int index = 0; index < indices.Length; ++index)
                    this.l[indices[index]] = larr[0];
            }
        }

        public override long[] LArr
        {
            get
            {
                return this.l;
            }
            set
            {
                this.SetArray((Array)value, false);
            }
        }

        public override HTupleType Type
        {
            get
            {
                return HTupleType.LONG;
            }
        }

        public override int[] ToIArr()
        {
            int[] numArray = new int[this.iLength];
            for (int index = 0; index < this.iLength; ++index)
                numArray[index] = (int)this.l[index];
            return numArray;
        }

        public override long[] ToLArr()
        {
            return (long[])this.ToArray(this.typeL);
        }

        public override double[] ToDArr()
        {
            return (double[])this.ToArray(this.typeD);
        }

        public override float[] ToFArr()
        {
            return (float[])this.ToArray(this.typeF);
        }

        public override IntPtr[] ToIPArr()
        {
            if (!HalconAPI.isPlatform64)
                base.ToIPArr();
            IntPtr[] numArray = new IntPtr[this.iLength];
            for (int index = 0; index < this.iLength; ++index)
                numArray[index] = new IntPtr(this.l[index]);
            return numArray;
        }

        public override void Store(IntPtr proc, int parIndex)
        {
            IntPtr tuple;
            HalconAPI.HCkP(proc, HalconAPI.GetInputTuple(proc, parIndex, out tuple));
            this.StoreData(proc, tuple);
        }

        protected override void StoreData(IntPtr proc, IntPtr tuple)
        {
            this.PinTuple();
            if (!HalconAPI.isPlatform64)
            {
                HalconAPI.HCkP(proc, HalconAPI.CreateElements(tuple, this.Length));
                for (int index = 0; index < this.Length; ++index)
                    HalconAPI.SetL(tuple, index, this.l[index]);
            }
            else
                HalconAPI.SetLArrPtr(tuple, this.l, this.iLength);
        }

        public static int Load(IntPtr tuple, out HTupleInt64 data)
        {
            int length;
            HalconAPI.GetTupleLength(tuple, out length);
            long[] numArray = new long[length];
            int larr = HalconAPI.GetLArr(tuple, numArray);
            data = new HTupleInt64(numArray, false);
            return larr;
        }
    }
}
