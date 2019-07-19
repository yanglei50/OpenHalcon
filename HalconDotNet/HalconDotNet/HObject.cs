using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HalconDotNet
{
    /// <summary>Represents an instance of an iconic object(-array). Base class for images, regions and XLDs</summary>
    [Serializable]
    public class HObject : HObjectBase, ISerializable, ICloneable
    {
        /// <summary>Create an uninitialized iconic object</summary>
        public HObject()
          : base(HObjectBase.UNDEF, false)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HObject(IntPtr key)
          : this(key, true)
        {
            this.AssertObjectClass();
            GC.KeepAlive((object)this);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HObject(IntPtr key, bool copy)
          : base(key, copy)
        {
            this.AssertObjectClass();
            GC.KeepAlive((object)this);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HObject(HObject obj)
          : base((HObjectBase)obj)
        {
            this.AssertObjectClass();
            GC.KeepAlive((object)this);
        }

        private void AssertObjectClass()
        {
        }

        /// <summary>Returns the iconic object(s) at the specified index</summary>
        public HObject this[HTuple index]
        {
            get
            {
                return this.SelectObj(index);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static int LoadNew(IntPtr proc, int parIndex, int err, out HObject obj)
        {
            obj = new HObject(HObjectBase.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeObject();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HObject(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeObject(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeObject().Serialize(stream);
        }

        public static HObject Deserialize(Stream stream)
        {
            HObject hobject = new HObject();
            hobject.DeserializeObject(HSerializedItem.Deserialize(stream));
            return hobject;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HObject Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeObject();
            HObject hobject = new HObject();
            hobject.DeserializeObject(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hobject;
        }

        /// <summary>
        ///   Calculate the difference of two object tuples.
        ///   Instance represents: Object tuple 1.
        /// </summary>
        /// <param name="objectsSub">Object tuple 2.</param>
        /// <returns>Objects from Objects that are not part of ObjectsSub.</returns>
        public HObject ObjDiff(HObject objectsSub)
        {
            IntPtr proc = HalconAPI.PreCall(573);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objectsSub);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HObject hobject;
            int procResult = HObject.LoadNew(proc, 1, err, out hobject);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectsSub);
            return hobject;
        }

        /// <summary>
        ///   Convert an "integer number" into an iconic object.
        ///   Modified instance represents: Created objects.
        /// </summary>
        /// <param name="surrogateTuple">Tuple of object surrogates.</param>
        public void IntegerToObj(HTuple surrogateTuple)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(581);
            HalconAPI.Store(proc, 0, surrogateTuple);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(surrogateTuple);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Convert an "integer number" into an iconic object.
        ///   Modified instance represents: Created objects.
        /// </summary>
        /// <param name="surrogateTuple">Tuple of object surrogates.</param>
        public void IntegerToObj(IntPtr surrogateTuple)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(581);
            HalconAPI.StoreIP(proc, 0, surrogateTuple);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Convert an iconic object into an "integer number."
        ///   Instance represents: Objects for which the surrogates are to be returned.
        /// </summary>
        /// <param name="index">Starting index of the surrogates to be returned. Default: 1</param>
        /// <param name="number">Number of surrogates to be returned. Default: -1</param>
        /// <returns>Tuple containing the surrogates.</returns>
        public HTuple ObjToInteger(int index, int number)
        {
            IntPtr proc = HalconAPI.PreCall(582);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.StoreI(proc, 1, number);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.INTEGER, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Copy an iconic object in the HALCON database.
        ///   Instance represents: Objects to be copied.
        /// </summary>
        /// <param name="index">Starting index of the objects to be copied. Default: 1</param>
        /// <param name="numObj">Number of objects to be copied or -1. Default: 1</param>
        /// <returns>Copied objects.</returns>
        public HObject CopyObj(int index, int numObj)
        {
            IntPtr proc = HalconAPI.PreCall(583);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.StoreI(proc, 1, numObj);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HObject hobject;
            int procResult = HObject.LoadNew(proc, 1, err, out hobject);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobject;
        }

        /// <summary>
        ///   Concatenate two iconic object tuples.
        ///   Instance represents: Object tuple 1.
        /// </summary>
        /// <param name="objects2">Object tuple 2.</param>
        /// <returns>Concatenated objects.</returns>
        public HObject ConcatObj(HObject objects2)
        {
            IntPtr proc = HalconAPI.PreCall(584);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objects2);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HObject hobject;
            int procResult = HObject.LoadNew(proc, 1, err, out hobject);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objects2);
            return hobject;
        }

        /// <summary>
        ///   Select objects from an object tuple.
        ///   Instance represents: Input objects.
        /// </summary>
        /// <param name="index">Indices of the objects to be selected. Default: 1</param>
        /// <returns>Selected objects.</returns>
        public HObject SelectObj(HTuple index)
        {
            IntPtr proc = HalconAPI.PreCall(587);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HObject hobject;
            int procResult = HObject.LoadNew(proc, 1, err, out hobject);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobject;
        }

        /// <summary>
        ///   Select objects from an object tuple.
        ///   Instance represents: Input objects.
        /// </summary>
        /// <param name="index">Indices of the objects to be selected. Default: 1</param>
        /// <returns>Selected objects.</returns>
        public HObject SelectObj(int index)
        {
            IntPtr proc = HalconAPI.PreCall(587);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HObject hobject;
            int procResult = HObject.LoadNew(proc, 1, err, out hobject);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobject;
        }

        /// <summary>
        ///   Compare iconic objects regarding equality.
        ///   Instance represents: Reference objects.
        /// </summary>
        /// <param name="objects2">Test objects.</param>
        /// <param name="epsilon">Maximum allowed difference between two gray values or  coordinates etc. Default: 0.0</param>
        /// <returns>Boolean result value.</returns>
        public int CompareObj(HObject objects2, HTuple epsilon)
        {
            IntPtr proc = HalconAPI.PreCall(588);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objects2);
            HalconAPI.Store(proc, 0, epsilon);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(epsilon);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objects2);
            return intValue;
        }

        /// <summary>
        ///   Compare iconic objects regarding equality.
        ///   Instance represents: Reference objects.
        /// </summary>
        /// <param name="objects2">Test objects.</param>
        /// <param name="epsilon">Maximum allowed difference between two gray values or  coordinates etc. Default: 0.0</param>
        /// <returns>Boolean result value.</returns>
        public int CompareObj(HObject objects2, double epsilon)
        {
            IntPtr proc = HalconAPI.PreCall(588);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objects2);
            HalconAPI.StoreD(proc, 0, epsilon);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objects2);
            return intValue;
        }

        /// <summary>
        ///   Compare image objects regarding equality.
        ///   Instance represents: Test objects.
        /// </summary>
        /// <param name="objects2">Comparative objects.</param>
        /// <returns>boolean result value.</returns>
        public int TestEqualObj(HObject objects2)
        {
            IntPtr proc = HalconAPI.PreCall(591);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objects2);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objects2);
            return intValue;
        }

        /// <summary>
        ///   Number of objects in a tuple.
        ///   Instance represents: Objects to be examined.
        /// </summary>
        /// <returns>Number of objects in the tuple Objects.</returns>
        public int CountObj()
        {
            IntPtr proc = HalconAPI.PreCall(592);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Informations about the components of an image object.
        ///   Instance represents: Image object to be examined.
        /// </summary>
        /// <param name="request">Required information about object components. Default: "creator"</param>
        /// <param name="channel">Components to be examined (0 for region/XLD). Default: 0</param>
        /// <returns>Requested information.</returns>
        public HTuple GetChannelInfo(string request, HTuple channel)
        {
            IntPtr proc = HalconAPI.PreCall(593);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, request);
            HalconAPI.Store(proc, 1, channel);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(channel);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Informations about the components of an image object.
        ///   Instance represents: Image object to be examined.
        /// </summary>
        /// <param name="request">Required information about object components. Default: "creator"</param>
        /// <param name="channel">Components to be examined (0 for region/XLD). Default: 0</param>
        /// <returns>Requested information.</returns>
        public string GetChannelInfo(string request, int channel)
        {
            IntPtr proc = HalconAPI.PreCall(593);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, request);
            HalconAPI.StoreI(proc, 1, channel);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            string stringValue;
            int procResult = HalconAPI.LoadS(proc, 0, err, out stringValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return stringValue;
        }

        /// <summary>
        ///   Name of the class of an image object.
        ///   Instance represents: Image objects to be examined.
        /// </summary>
        /// <returns>Name of class.</returns>
        public HTuple GetObjClass()
        {
            IntPtr proc = HalconAPI.PreCall(594);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Create an empty object tuple.
        ///   Modified instance represents: No objects.
        /// </summary>
        public void GenEmptyObj()
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(617);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Displays image objects (image, region, XLD).
        ///   Instance represents: Image object to be displayed.
        /// </summary>
        /// <param name="windowHandle">Window handle.</param>
        public void DispObj(HWindow windowHandle)
        {
            IntPtr proc = HalconAPI.PreCall(1276);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, (HTool)windowHandle);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)windowHandle);
        }

        /// <summary>
        ///   Read an iconic object.
        ///   Modified instance represents: Iconic object.
        /// </summary>
        /// <param name="fileName">Name of file.</param>
        public void ReadObject(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1646);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write an iconic object.
        ///   Instance represents: Iconic object.
        /// </summary>
        /// <param name="fileName">Name of file.</param>
        public void WriteObject(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(1647);
            this.Store(proc, 1);
            HalconAPI.StoreS(proc, 0, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Deserialize a serialized iconic object.
        ///   Modified instance represents: Iconic object.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeObject(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(1648);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 1, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize an iconic object.
        ///   Instance represents: Iconic object.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeObject()
        {
            IntPtr proc = HalconAPI.PreCall(1649);
            this.Store(proc, 1);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HSerializedItem hserializedItem;
            int procResult = HSerializedItem.LoadNew(proc, 0, err, out hserializedItem);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hserializedItem;
        }

        /// <summary>
        ///   Insert objects into an iconic object tuple.
        ///   Instance represents: Input object tuple.
        /// </summary>
        /// <param name="objectsInsert">Object tuple to insert.</param>
        /// <param name="index">Index to insert objects.</param>
        /// <returns>Extended object tuple.</returns>
        public HObject InsertObj(HObject objectsInsert, int index)
        {
            IntPtr proc = HalconAPI.PreCall(2121);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objectsInsert);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HObject hobject;
            int procResult = HObject.LoadNew(proc, 1, err, out hobject);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectsInsert);
            return hobject;
        }

        /// <summary>
        ///   Remove objects from an iconic object tuple.
        ///   Instance represents: Input object tuple.
        /// </summary>
        /// <param name="index">Indices of the objects to be removed.</param>
        /// <returns>Remaining object tuple.</returns>
        public HObject RemoveObj(HTuple index)
        {
            IntPtr proc = HalconAPI.PreCall(2124);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HObject hobject;
            int procResult = HObject.LoadNew(proc, 1, err, out hobject);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobject;
        }

        /// <summary>
        ///   Remove objects from an iconic object tuple.
        ///   Instance represents: Input object tuple.
        /// </summary>
        /// <param name="index">Indices of the objects to be removed.</param>
        /// <returns>Remaining object tuple.</returns>
        public HObject RemoveObj(int index)
        {
            IntPtr proc = HalconAPI.PreCall(2124);
            this.Store(proc, 1);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HObject hobject;
            int procResult = HObject.LoadNew(proc, 1, err, out hobject);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hobject;
        }

        /// <summary>
        ///   Replaces one or more elements of an iconic object tuple.
        ///   Instance represents: Iconic Input Object.
        /// </summary>
        /// <param name="objectsReplace">Element(s) to replace.</param>
        /// <param name="index">Index/Indices of elements to be replaced.</param>
        /// <returns>Tuple with replaced elements.</returns>
        public HObject ReplaceObj(HObject objectsReplace, HTuple index)
        {
            IntPtr proc = HalconAPI.PreCall(2125);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objectsReplace);
            HalconAPI.Store(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(index);
            HObject hobject;
            int procResult = HObject.LoadNew(proc, 1, err, out hobject);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectsReplace);
            return hobject;
        }

        /// <summary>
        ///   Replaces one or more elements of an iconic object tuple.
        ///   Instance represents: Iconic Input Object.
        /// </summary>
        /// <param name="objectsReplace">Element(s) to replace.</param>
        /// <param name="index">Index/Indices of elements to be replaced.</param>
        /// <returns>Tuple with replaced elements.</returns>
        public HObject ReplaceObj(HObject objectsReplace, int index)
        {
            IntPtr proc = HalconAPI.PreCall(2125);
            this.Store(proc, 1);
            HalconAPI.Store(proc, 2, (HObjectBase)objectsReplace);
            HalconAPI.StoreI(proc, 0, index);
            HalconAPI.InitOCT(proc, 1);
            int err = HalconAPI.CallProcedure(proc);
            HObject hobject;
            int procResult = HObject.LoadNew(proc, 1, err, out hobject);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)objectsReplace);
            return hobject;
        }
    }
}
