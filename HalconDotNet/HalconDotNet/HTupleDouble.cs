// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HTupleDouble
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.Runtime.InteropServices;
using System.Threading;

namespace HalconDotNet
{
    internal class HTupleDouble : HTupleImplementation
    {
        protected double[] d;

        protected override Array CreateArray(int size)
        {
            return (Array)new double[size];
        }

        protected override void NotifyArrayUpdate()
        {
            this.d = (double[])this.data;
        }

        public HTupleDouble(double d)
        {
            this.SetArray((Array)new double[1] { d }, false);
        }

        public HTupleDouble(double[] d, bool copy)
        {
            this.SetArray((Array)d, copy);
        }

        public HTupleDouble(float[] f)
        {
            this.SetArray((Array)f, true);
        }

        internal override void PinTuple()
        {
            Monitor.Enter((object)this);
            if (this.pinCount == 0)
                this.pinHandle = GCHandle.Alloc((object)this.d, GCHandleType.Pinned);
            ++this.pinCount;
            Monitor.Exit((object)this);
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
            double[] darr = elements.DArr;
            if (darr.Length == indices.Length)
            {
                for (int index = 0; index < indices.Length; ++index)
                    this.d[indices[index]] = darr[index];
            }
            else
            {
                if (darr.Length != 1)
                    throw new HTupleAccessException((HTupleImplementation)this, "Input parameter 2 ('Value') must have one element or the same number of elements as parameter 1 ('Index')");
                for (int index = 0; index < indices.Length; ++index)
                    this.d[indices[index]] = darr[0];
            }
        }

        public override double[] DArr
        {
            get
            {
                return this.d;
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
                return HTupleType.DOUBLE;
            }
        }

        public override double[] ToDArr()
        {
            return (double[])this.ToArray(this.typeD);
        }

        public override float[] ToFArr()
        {
            float[] numArray = new float[this.iLength];
            for (int index = 0; index < this.iLength; ++index)
                numArray[index] = (float)this.d[index];
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
            HalconAPI.SetDArrPtr(tuple, this.d, this.iLength);
        }

        public static int Load(IntPtr tuple, out HTupleDouble data)
        {
            int length;
            HalconAPI.GetTupleLength(tuple, out length);
            double[] numArray = new double[length];
            int darr = HalconAPI.GetDArr(tuple, numArray);
            data = new HTupleDouble(numArray, false);
            return darr;
        }
    }
}
