// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HTupleString
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;

namespace HalconDotNet
{
    public class HTupleString : HTupleImplementation
    {
        protected string[] s;

        protected override Array CreateArray(int size)
        {
            string[] strArray = new string[size];
            for (int index = 0; index < size; ++index)
                strArray[index] = "";
            return (Array)strArray;
        }

        protected override void NotifyArrayUpdate()
        {
            this.s = (string[])this.data;
        }

        public HTupleString(string s)
        {
            this.SetArray((Array)new string[1] { s }, false);
        }

        public HTupleString(string[] s, bool copy)
        {
            this.SetArray((Array)s, copy);
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
            string[] sarr = elements.SArr;
            if (sarr.Length == indices.Length)
            {
                for (int index = 0; index < indices.Length; ++index)
                    this.s[indices[index]] = sarr[index];
            }
            else
            {
                if (sarr.Length != 1)
                    throw new HTupleAccessException((HTupleImplementation)this, "Input parameter 2 ('Value') must have one element or the same number of elements as parameter 1 ('Index')");
                for (int index = 0; index < indices.Length; ++index)
                    this.s[indices[index]] = sarr[0];
            }
        }

        public override string[] SArr
        {
            get
            {
                return this.s;
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
                return HTupleType.STRING;
            }
        }

        public override string[] ToSArr()
        {
            return (string[])this.ToArray(this.typeS);
        }

        protected override void StoreData(IntPtr proc, IntPtr tuple)
        {
            for (int index = 0; index < this.iLength; ++index)
                HalconAPI.HCkP(proc, HalconAPI.SetS(tuple, index, this.s[index]));
        }

        public static int Load(IntPtr tuple, out HTupleString data)
        {
            int err = 2;
            int length;
            HalconAPI.GetTupleLength(tuple, out length);
            string[] s = new string[length];
            for (int index = 0; index < length; ++index)
            {
                if (!HalconAPI.IsFailure(err))
                    err = HalconAPI.GetS(tuple, index, out s[index]);
            }
            data = new HTupleString(s, false);
            return err;
        }
    }
}
