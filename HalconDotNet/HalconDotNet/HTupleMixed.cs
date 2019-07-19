// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HTupleMixed
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;

namespace HalconDotNet
{
    internal class HTupleMixed : HTupleImplementation
    {
        protected object[] o;

        protected override Array CreateArray(int size)
        {
            object[] objArray = new object[size];
            for (int index = 0; index < size; ++index)
                objArray[index] = (object)0;
            return (Array)objArray;
        }

        protected override void NotifyArrayUpdate()
        {
            this.o = (object[])this.data;
        }

        public HTupleMixed(HTupleImplementation data)
          : this(data.ToOArr(), false)
        {
        }

        public HTupleMixed(object o)
          : this(new object[1] { o }, false)
        {
        }

        public HTupleMixed(object[] o, bool copy)
        {
            for (int index = 0; index < o.Length; ++index)
            {
                int objectType = HTupleImplementation.GetObjectType(o[index]);
                if (objectType == 15 || (objectType & 32768) > 0)
                    throw new HTupleAccessException("Encountered invalid data types when creating HTuple");
            }
            this.SetArray((Array)o, copy);
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
            object[] oarr = elements.OArr;
            if (oarr.Length == indices.Length)
            {
                for (int index = 0; index < indices.Length; ++index)
                    this.o[indices[index]] = oarr[index];
            }
            else
            {
                if (oarr.Length != 1)
                    throw new HTupleAccessException((HTupleImplementation)this, "Input parameter 2 ('Value') must have one element or the same number of elements as parameter 1 ('Index')");
                for (int index = 0; index < indices.Length; ++index)
                    this.o[indices[index]] = oarr[0];
            }
        }

        public override object[] OArr
        {
            get
            {
                return this.o;
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
                return HTupleType.MIXED;
            }
        }

        public HTupleType GetElementType(int index)
        {
            return (HTupleType)HTupleImplementation.GetObjectType(this.o[index]);
        }

        public HTupleType GetElementType(int[] indices)
        {
            if (indices == null || indices.Length == 0)
                return HTupleType.EMPTY;
            HTupleType objectType = (HTupleType)HTupleImplementation.GetObjectType(this.o[indices[0]]);
            for (int index = 1; index < indices.Length; ++index)
            {
                if ((HTupleType)HTupleImplementation.GetObjectType(this.o[indices[index]]) != objectType)
                    return HTupleType.MIXED;
            }
            return objectType;
        }

        protected override void StoreData(IntPtr proc, IntPtr tuple)
        {
            for (int index = 0; index < this.iLength; ++index)
            {
                switch (HTupleImplementation.GetObjectType(this.o[index]))
                {
                    case 1:
                        HalconAPI.HCkP(proc, HalconAPI.SetI(tuple, index, (int)this.o[index]));
                        break;
                    case 2:
                        HalconAPI.HCkP(proc, HalconAPI.SetD(tuple, index, (double)this.o[index]));
                        break;
                    case 4:
                        HalconAPI.HCkP(proc, HalconAPI.SetS(tuple, index, (string)this.o[index]));
                        break;
                    case 129:
                        HalconAPI.HCkP(proc, HalconAPI.SetL(tuple, index, (long)this.o[index]));
                        break;
                }
            }
        }

        public static int Load(IntPtr tuple, out HTupleMixed data)
        {
            int err = 2;
            int length;
            HalconAPI.GetTupleLength(tuple, out length);
            object[] o = new object[length];
            for (int index = 0; index < length; ++index)
            {
                if (!HalconAPI.IsFailure(err))
                {
                    HTupleType type;
                    HalconAPI.GetElementType(tuple, index, out type);
                    switch (type)
                    {
                        case HTupleType.INTEGER:
                            if (HalconAPI.isPlatform64)
                            {
                                long longValue;
                                err = HalconAPI.GetL(tuple, index, out longValue);
                                o[index] = (object)longValue;
                                continue;
                            }
                            int intValue;
                            err = HalconAPI.GetI(tuple, index, out intValue);
                            o[index] = (object)intValue;
                            continue;
                        case HTupleType.DOUBLE:
                            double doubleValue;
                            err = HalconAPI.GetD(tuple, index, out doubleValue);
                            o[index] = (object)doubleValue;
                            continue;
                        case HTupleType.STRING:
                            string stringValue;
                            err = HalconAPI.GetS(tuple, index, out stringValue);
                            o[index] = (object)stringValue;
                            continue;
                        default:
                            continue;
                    }
                }
            }
            data = new HTupleMixed(o, false);
            return err;
        }
    }
}
