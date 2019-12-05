// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HMatrix
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a matrix.</summary>
    [Serializable]
    public class HMatrix : HTool, ISerializable, ICloneable
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HMatrix()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HMatrix(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HMatrix obj)
        {
            obj = new HMatrix(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HMatrix[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HMatrix[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HMatrix(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Read a matrix from a file.
        ///   Modified instance represents: Matrix handle.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public HMatrix(string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(842);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a matrix.
        ///   Modified instance represents: Matrix handle.
        /// </summary>
        /// <param name="rows">Number of rows of the matrix. Default: 3</param>
        /// <param name="columns">Number of columns of the matrix. Default: 3</param>
        /// <param name="value">Values for initializing the elements of the matrix. Default: 0</param>
        public HMatrix(int rows, int columns, HTuple value)
        {
            IntPtr proc = HalconAPI.PreCall(897);
            HalconAPI.StoreI(proc, 0, rows);
            HalconAPI.StoreI(proc, 1, columns);
            HalconAPI.Store(proc, 2, value);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(value);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a matrix.
        ///   Modified instance represents: Matrix handle.
        /// </summary>
        /// <param name="rows">Number of rows of the matrix. Default: 3</param>
        /// <param name="columns">Number of columns of the matrix. Default: 3</param>
        /// <param name="value">Values for initializing the elements of the matrix. Default: 0</param>
        public HMatrix(int rows, int columns, double value)
        {
            IntPtr proc = HalconAPI.PreCall(897);
            HalconAPI.StoreI(proc, 0, rows);
            HalconAPI.StoreI(proc, 1, columns);
            HalconAPI.StoreD(proc, 2, value);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem hserializedItem = this.SerializeMatrix();
            byte[] numArray = (byte[])hserializedItem;
            hserializedItem.Dispose();
            info.AddValue("data", (object)numArray, typeof(byte[]));
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HMatrix(SerializationInfo info, StreamingContext context)
        {
            HSerializedItem serializedItemHandle = new HSerializedItem((byte[])info.GetValue("data", typeof(byte[])));
            this.DeserializeMatrix(serializedItemHandle);
            serializedItemHandle.Dispose();
        }

        public void Serialize(Stream stream)
        {
            this.SerializeMatrix().Serialize(stream);
        }

        public static HMatrix Deserialize(Stream stream)
        {
            HMatrix hmatrix = new HMatrix();
            hmatrix.DeserializeMatrix(HSerializedItem.Deserialize(stream));
            return hmatrix;
        }

        object ICloneable.Clone()
        {
            return (object)this.Clone();
        }

        public HMatrix Clone()
        {
            HSerializedItem serializedItemHandle = this.SerializeMatrix();
            HMatrix hmatrix = new HMatrix();
            hmatrix.DeserializeMatrix(serializedItemHandle);
            serializedItemHandle.Dispose();
            return hmatrix;
        }

        /// <summary>Negate the matrix</summary>
        public static HMatrix operator -(HMatrix matrix)
        {
            return matrix.ScaleMatrix(-1.0);
        }

        /// <summary>Add two matrices</summary>
        public static HMatrix operator +(HMatrix matrix1, HMatrix matrix2)
        {
            return matrix1.AddMatrix(matrix2);
        }

        /// <summary>Subtract two matrices</summary>
        public static HMatrix operator -(HMatrix matrix1, HMatrix matrix2)
        {
            return matrix1.SubMatrix(matrix2);
        }

        /// <summary>Multiplies two matrices</summary>
        public static HMatrix operator *(HMatrix matrix1, HMatrix matrix2)
        {
            return matrix1.MultMatrix(matrix2, "AB");
        }

        /// <summary>Scale a matrix</summary>
        public static HMatrix operator *(double factor, HMatrix matrix)
        {
            return matrix.ScaleMatrix(factor);
        }

        /// <summary>Scale a matrix</summary>
        public static HMatrix operator *(HMatrix matrix, double factor)
        {
            return matrix.ScaleMatrix(factor);
        }

        /// <summary>Solve linear system matrix2 * x = matrix1</summary>
        public static HMatrix operator /(HMatrix matrix1, HMatrix matrix2)
        {
            return matrix2.SolveMatrix("general", 0.0, matrix1);
        }

        /// <summary>Get all matrix elements</summary>
        public static implicit operator HTuple(HMatrix matrix)
        {
            return matrix.GetFullMatrix();
        }

        /// <summary>Get all matrix elements</summary>
        public double this[int row, int column]
        {
            get
            {
                return this.GetValueMatrix(row, column);
            }
            set
            {
                this.SetValueMatrix(row, column, value);
            }
        }

        /// <summary>Get the number of rows</summary>
        public int NumRows
        {
            get
            {
                int rows;
                int columns;
                this.GetSizeMatrix(out rows, out columns);
                return rows;
            }
        }

        /// <summary>Get the number of columns</summary>
        public int NumColumns
        {
            get
            {
                int rows;
                int columns;
                this.GetSizeMatrix(out rows, out columns);
                return columns;
            }
        }

        /// <summary>
        ///   Deserialize a serialized matrix.
        ///   Modified instance represents: Matrix handle.
        /// </summary>
        /// <param name="serializedItemHandle">Handle of the serialized item.</param>
        public void DeserializeMatrix(HSerializedItem serializedItemHandle)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(840);
            HalconAPI.Store(proc, 0, (HTool)serializedItemHandle);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)serializedItemHandle);
        }

        /// <summary>
        ///   Serialize a matrix.
        ///   Instance represents: Matrix handle.
        /// </summary>
        /// <returns>Handle of the serialized item.</returns>
        public HSerializedItem SerializeMatrix()
        {
            IntPtr proc = HalconAPI.PreCall(841);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HSerializedItem hserializedItem;
            int procResult = HSerializedItem.LoadNew(proc, 0, err, out hserializedItem);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hserializedItem;
        }

        /// <summary>
        ///   Read a matrix from a file.
        ///   Modified instance represents: Matrix handle.
        /// </summary>
        /// <param name="fileName">File name.</param>
        public void ReadMatrix(string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(842);
            HalconAPI.StoreS(proc, 0, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Write a matrix to a file.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="fileFormat">Format of the file. Default: "binary"</param>
        /// <param name="fileName">File name.</param>
        public void WriteMatrix(string fileFormat, string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(843);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, fileFormat);
            HalconAPI.StoreS(proc, 2, fileName);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Perform an orthogonal decomposition of a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="decompositionType">Method of decomposition. Default: "qr"</param>
        /// <param name="outputMatricesType">Type of output matrices. Default: "full"</param>
        /// <param name="computeOrthogonal">Computation of the orthogonal matrix. Default: "true"</param>
        /// <param name="matrixTriangularID">Matrix handle with the triangular part of the decomposed input matrix.</param>
        /// <returns>Matrix handle with the orthogonal part of the decomposed input matrix.</returns>
        public HMatrix OrthogonalDecomposeMatrix(
          string decompositionType,
          string outputMatricesType,
          string computeOrthogonal,
          out HMatrix matrixTriangularID)
        {
            IntPtr proc = HalconAPI.PreCall(844);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, decompositionType);
            HalconAPI.StoreS(proc, 2, outputMatricesType);
            HalconAPI.StoreS(proc, 3, computeOrthogonal);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HMatrix hmatrix;
            int err2 = HMatrix.LoadNew(proc, 0, err1, out hmatrix);
            int procResult = HMatrix.LoadNew(proc, 1, err2, out matrixTriangularID);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hmatrix;
        }

        /// <summary>
        ///   Decompose a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="matrixType">Type of the input matrix. Default: "general"</param>
        /// <param name="matrix2ID">Matrix handle with the output matrix 2.</param>
        /// <returns>Matrix handle with the output matrix 1.</returns>
        public HMatrix DecomposeMatrix(string matrixType, out HMatrix matrix2ID)
        {
            IntPtr proc = HalconAPI.PreCall(845);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, matrixType);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HMatrix hmatrix;
            int err2 = HMatrix.LoadNew(proc, 0, err1, out hmatrix);
            int procResult = HMatrix.LoadNew(proc, 1, err2, out matrix2ID);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hmatrix;
        }

        /// <summary>
        ///   Compute the singular value decomposition of a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="SVDType">Type of computation. Default: "full"</param>
        /// <param name="computeSingularVectors">Computation of singular values. Default: "both"</param>
        /// <param name="matrixSID">Matrix handle with singular values.</param>
        /// <param name="matrixVID">Matrix handle with the right singular vectors.</param>
        /// <returns>Matrix handle with the left singular vectors.</returns>
        public HMatrix SvdMatrix(
          string SVDType,
          string computeSingularVectors,
          out HMatrix matrixSID,
          out HMatrix matrixVID)
        {
            IntPtr proc = HalconAPI.PreCall(846);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, SVDType);
            HalconAPI.StoreS(proc, 2, computeSingularVectors);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            int err1 = HalconAPI.CallProcedure(proc);
            HMatrix hmatrix;
            int err2 = HMatrix.LoadNew(proc, 0, err1, out hmatrix);
            int err3 = HMatrix.LoadNew(proc, 1, err2, out matrixSID);
            int procResult = HMatrix.LoadNew(proc, 2, err3, out matrixVID);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hmatrix;
        }

        /// <summary>
        ///   Compute the generalized eigenvalues and optionally the generalized eigenvectors of general matrices.
        ///   Instance represents: Matrix handle of the input matrix A.
        /// </summary>
        /// <param name="matrixBID">Matrix handle of the input matrix B.</param>
        /// <param name="computeEigenvectors">Computation of the eigenvectors. Default: "none"</param>
        /// <param name="eigenvaluesRealID">Matrix handle with the real parts of the eigenvalues.</param>
        /// <param name="eigenvaluesImagID">Matrix handle with the imaginary parts of the eigenvalues.</param>
        /// <param name="eigenvectorsRealID">Matrix handle with the real parts of the eigenvectors.</param>
        /// <param name="eigenvectorsImagID">Matrix handle with the imaginary parts of the eigenvectors.</param>
        public void GeneralizedEigenvaluesGeneralMatrix(
          HMatrix matrixBID,
          string computeEigenvectors,
          out HMatrix eigenvaluesRealID,
          out HMatrix eigenvaluesImagID,
          out HMatrix eigenvectorsRealID,
          out HMatrix eigenvectorsImagID)
        {
            IntPtr proc = HalconAPI.PreCall(847);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)matrixBID);
            HalconAPI.StoreS(proc, 2, computeEigenvectors);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HMatrix.LoadNew(proc, 0, err1, out eigenvaluesRealID);
            int err3 = HMatrix.LoadNew(proc, 1, err2, out eigenvaluesImagID);
            int err4 = HMatrix.LoadNew(proc, 2, err3, out eigenvectorsRealID);
            int procResult = HMatrix.LoadNew(proc, 3, err4, out eigenvectorsImagID);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)matrixBID);
        }

        /// <summary>
        ///   Compute the generalized eigenvalues and optionally generalized eigenvectors of symmetric input matrices.
        ///   Instance represents: Matrix handle of the symmetric input matrix A.
        /// </summary>
        /// <param name="matrixBID">Matrix handle of the symmetric positive definite input matrix B.</param>
        /// <param name="computeEigenvectors">Computation of the eigenvectors. Default: "false"</param>
        /// <param name="eigenvectorsID">Matrix handle with the eigenvectors.</param>
        /// <returns>Matrix handle with the eigenvalues.</returns>
        public HMatrix GeneralizedEigenvaluesSymmetricMatrix(
          HMatrix matrixBID,
          string computeEigenvectors,
          out HMatrix eigenvectorsID)
        {
            IntPtr proc = HalconAPI.PreCall(848);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)matrixBID);
            HalconAPI.StoreS(proc, 2, computeEigenvectors);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HMatrix hmatrix;
            int err2 = HMatrix.LoadNew(proc, 0, err1, out hmatrix);
            int procResult = HMatrix.LoadNew(proc, 1, err2, out eigenvectorsID);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)matrixBID);
            return hmatrix;
        }

        /// <summary>
        ///   Compute the eigenvalues and optionally the eigenvectors of a general matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="computeEigenvectors">Computation of the eigenvectors. Default: "none"</param>
        /// <param name="eigenvaluesRealID">Matrix handle with the real parts of the eigenvalues.</param>
        /// <param name="eigenvaluesImagID">Matrix handle with the imaginary parts of the eigenvalues.</param>
        /// <param name="eigenvectorsRealID">Matrix handle with the real parts of the eigenvectors.</param>
        /// <param name="eigenvectorsImagID">Matrix handle with the imaginary parts of the eigenvectors.</param>
        public void EigenvaluesGeneralMatrix(
          string computeEigenvectors,
          out HMatrix eigenvaluesRealID,
          out HMatrix eigenvaluesImagID,
          out HMatrix eigenvectorsRealID,
          out HMatrix eigenvectorsImagID)
        {
            IntPtr proc = HalconAPI.PreCall(849);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, computeEigenvectors);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            HalconAPI.InitOCT(proc, 2);
            HalconAPI.InitOCT(proc, 3);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HMatrix.LoadNew(proc, 0, err1, out eigenvaluesRealID);
            int err3 = HMatrix.LoadNew(proc, 1, err2, out eigenvaluesImagID);
            int err4 = HMatrix.LoadNew(proc, 2, err3, out eigenvectorsRealID);
            int procResult = HMatrix.LoadNew(proc, 3, err4, out eigenvectorsImagID);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Compute the eigenvalues and optionally eigenvectors of a symmetric matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="computeEigenvectors">Computation of the eigenvectors. Default: "false"</param>
        /// <param name="eigenvectorsID">Matrix handle with the eigenvectors.</param>
        /// <returns>Matrix handle with the eigenvalues.</returns>
        public HMatrix EigenvaluesSymmetricMatrix(
          string computeEigenvectors,
          out HMatrix eigenvectorsID)
        {
            IntPtr proc = HalconAPI.PreCall(850);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, computeEigenvectors);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            HMatrix hmatrix;
            int err2 = HMatrix.LoadNew(proc, 0, err1, out hmatrix);
            int procResult = HMatrix.LoadNew(proc, 1, err2, out eigenvectorsID);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hmatrix;
        }

        /// <summary>
        ///   Compute the solution of a system of equations.
        ///   Instance represents: Matrix handle of the input matrix of the left hand side.
        /// </summary>
        /// <param name="matrixLHSType">The type of the input matrix of the left hand side. Default: "general"</param>
        /// <param name="epsilon">Type of solving and limitation to set singular values to be 0. Default: 0.0</param>
        /// <param name="matrixRHSID">Matrix handle of the input matrix of right hand side.</param>
        /// <returns>New matrix handle with the solution.</returns>
        public HMatrix SolveMatrix(string matrixLHSType, double epsilon, HMatrix matrixRHSID)
        {
            IntPtr proc = HalconAPI.PreCall(851);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, matrixLHSType);
            HalconAPI.StoreD(proc, 2, epsilon);
            HalconAPI.Store(proc, 3, (HTool)matrixRHSID);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HMatrix hmatrix;
            int procResult = HMatrix.LoadNew(proc, 0, err, out hmatrix);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)matrixRHSID);
            return hmatrix;
        }

        /// <summary>
        ///   Compute the determinant of a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="matrixType">The type of the input matrix. Default: "general"</param>
        /// <returns>Determinant of the input matrix.</returns>
        public double DeterminantMatrix(string matrixType)
        {
            IntPtr proc = HalconAPI.PreCall(852);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, matrixType);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Invert a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="matrixType">The type of the input matrix. Default: "general"</param>
        /// <param name="epsilon">Type of inversion. Default: 0.0</param>
        public void InvertMatrixMod(string matrixType, double epsilon)
        {
            IntPtr proc = HalconAPI.PreCall(853);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, matrixType);
            HalconAPI.StoreD(proc, 2, epsilon);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Invert a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="matrixType">The type of the input matrix. Default: "general"</param>
        /// <param name="epsilon">Type of inversion. Default: 0.0</param>
        /// <returns>Matrix handle with the inverse matrix.</returns>
        public HMatrix InvertMatrix(string matrixType, double epsilon)
        {
            IntPtr proc = HalconAPI.PreCall(854);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, matrixType);
            HalconAPI.StoreD(proc, 2, epsilon);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HMatrix hmatrix;
            int procResult = HMatrix.LoadNew(proc, 0, err, out hmatrix);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hmatrix;
        }

        /// <summary>
        ///   Transpose a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        public void TransposeMatrixMod()
        {
            IntPtr proc = HalconAPI.PreCall(855);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Transpose a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <returns>Matrix handle with the transpose of the input matrix.</returns>
        public HMatrix TransposeMatrix()
        {
            IntPtr proc = HalconAPI.PreCall(856);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HMatrix hmatrix;
            int procResult = HMatrix.LoadNew(proc, 0, err, out hmatrix);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hmatrix;
        }

        /// <summary>
        ///   Returns the elementwise maximum of a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="maxType">Type of maximum determination. Default: "columns"</param>
        /// <returns>Matrix handle with the maximum values of the input matrix.</returns>
        public HMatrix MaxMatrix(string maxType)
        {
            IntPtr proc = HalconAPI.PreCall(857);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, maxType);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HMatrix hmatrix;
            int procResult = HMatrix.LoadNew(proc, 0, err, out hmatrix);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hmatrix;
        }

        /// <summary>
        ///   Returns the elementwise minimum of a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="minType">Type of minimum determination. Default: "columns"</param>
        /// <returns>Matrix handle with the minimum values of the input matrix.</returns>
        public HMatrix MinMatrix(string minType)
        {
            IntPtr proc = HalconAPI.PreCall(858);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, minType);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HMatrix hmatrix;
            int procResult = HMatrix.LoadNew(proc, 0, err, out hmatrix);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hmatrix;
        }

        /// <summary>
        ///   Compute the power functions of a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="matrixType">The type of the input matrix. Default: "general"</param>
        /// <param name="power">The power. Default: 2.0</param>
        public void PowMatrixMod(string matrixType, HTuple power)
        {
            IntPtr proc = HalconAPI.PreCall(859);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, matrixType);
            HalconAPI.Store(proc, 2, power);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(power);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Compute the power functions of a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="matrixType">The type of the input matrix. Default: "general"</param>
        /// <param name="power">The power. Default: 2.0</param>
        public void PowMatrixMod(string matrixType, double power)
        {
            IntPtr proc = HalconAPI.PreCall(859);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, matrixType);
            HalconAPI.StoreD(proc, 2, power);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Compute the power functions of a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="matrixType">The type of the input matrix. Default: "general"</param>
        /// <param name="power">The power. Default: 2.0</param>
        /// <returns>Matrix handle with the raised powered matrix.</returns>
        public HMatrix PowMatrix(string matrixType, HTuple power)
        {
            IntPtr proc = HalconAPI.PreCall(860);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, matrixType);
            HalconAPI.Store(proc, 2, power);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(power);
            HMatrix hmatrix;
            int procResult = HMatrix.LoadNew(proc, 0, err, out hmatrix);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hmatrix;
        }

        /// <summary>
        ///   Compute the power functions of a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="matrixType">The type of the input matrix. Default: "general"</param>
        /// <param name="power">The power. Default: 2.0</param>
        /// <returns>Matrix handle with the raised powered matrix.</returns>
        public HMatrix PowMatrix(string matrixType, double power)
        {
            IntPtr proc = HalconAPI.PreCall(860);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, matrixType);
            HalconAPI.StoreD(proc, 2, power);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HMatrix hmatrix;
            int procResult = HMatrix.LoadNew(proc, 0, err, out hmatrix);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hmatrix;
        }

        /// <summary>
        ///   Compute the power functions of the elements of a matrix.
        ///   Instance represents: Matrix handle of the input matrix of the base.
        /// </summary>
        /// <param name="matrixExpID">Matrix handle of the input matrix with exponents.</param>
        public void PowElementMatrixMod(HMatrix matrixExpID)
        {
            IntPtr proc = HalconAPI.PreCall(861);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)matrixExpID);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)matrixExpID);
        }

        /// <summary>
        ///   Compute the power functions of the elements of a matrix.
        ///   Instance represents: Matrix handle of the input matrix of the base.
        /// </summary>
        /// <param name="matrixExpID">Matrix handle of the input matrix with exponents.</param>
        /// <returns>Matrix handle with the raised power of the input matrix.</returns>
        public HMatrix PowElementMatrix(HMatrix matrixExpID)
        {
            IntPtr proc = HalconAPI.PreCall(862);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)matrixExpID);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HMatrix hmatrix;
            int procResult = HMatrix.LoadNew(proc, 0, err, out hmatrix);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)matrixExpID);
            return hmatrix;
        }

        /// <summary>
        ///   Compute the power functions of the elements of a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="power">The power. Default: 2.0</param>
        public void PowScalarElementMatrixMod(HTuple power)
        {
            IntPtr proc = HalconAPI.PreCall(863);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, power);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(power);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Compute the power functions of the elements of a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="power">The power. Default: 2.0</param>
        public void PowScalarElementMatrixMod(double power)
        {
            IntPtr proc = HalconAPI.PreCall(863);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, power);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Compute the power functions of the elements of a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="power">The power. Default: 2.0</param>
        /// <returns>Matrix handle with the raised power of the input matrix.</returns>
        public HMatrix PowScalarElementMatrix(HTuple power)
        {
            IntPtr proc = HalconAPI.PreCall(864);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, power);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(power);
            HMatrix hmatrix;
            int procResult = HMatrix.LoadNew(proc, 0, err, out hmatrix);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hmatrix;
        }

        /// <summary>
        ///   Compute the power functions of the elements of a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="power">The power. Default: 2.0</param>
        /// <returns>Matrix handle with the raised power of the input matrix.</returns>
        public HMatrix PowScalarElementMatrix(double power)
        {
            IntPtr proc = HalconAPI.PreCall(864);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, power);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HMatrix hmatrix;
            int procResult = HMatrix.LoadNew(proc, 0, err, out hmatrix);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hmatrix;
        }

        /// <summary>
        ///   Compute the square root values of the elements of a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        public void SqrtMatrixMod()
        {
            IntPtr proc = HalconAPI.PreCall(865);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Compute the square root values of the elements of a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <returns>Matrix handle with the square root values of the input matrix.</returns>
        public HMatrix SqrtMatrix()
        {
            IntPtr proc = HalconAPI.PreCall(866);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HMatrix hmatrix;
            int procResult = HMatrix.LoadNew(proc, 0, err, out hmatrix);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hmatrix;
        }

        /// <summary>
        ///   Compute the absolute values of the elements of a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        public void AbsMatrixMod()
        {
            IntPtr proc = HalconAPI.PreCall(867);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Compute the absolute values of the elements of a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <returns>Matrix handle with the absolute values of the input matrix.</returns>
        public HMatrix AbsMatrix()
        {
            IntPtr proc = HalconAPI.PreCall(868);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HMatrix hmatrix;
            int procResult = HMatrix.LoadNew(proc, 0, err, out hmatrix);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hmatrix;
        }

        /// <summary>
        ///   Norm of a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="normType">Type of norm. Default: "2-norm"</param>
        /// <returns>Norm of the input matrix.</returns>
        public double NormMatrix(string normType)
        {
            IntPtr proc = HalconAPI.PreCall(869);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, normType);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Returns the elementwise mean of a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="meanType">Type of mean determination. Default: "columns"</param>
        /// <returns>Matrix handle with the mean values of the input matrix.</returns>
        public HMatrix MeanMatrix(string meanType)
        {
            IntPtr proc = HalconAPI.PreCall(870);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, meanType);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HMatrix hmatrix;
            int procResult = HMatrix.LoadNew(proc, 0, err, out hmatrix);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hmatrix;
        }

        /// <summary>
        ///   Returns the elementwise sum of a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="sumType">Type of summation. Default: "columns"</param>
        /// <returns>Matrix handle with the sum of the input matrix.</returns>
        public HMatrix SumMatrix(string sumType)
        {
            IntPtr proc = HalconAPI.PreCall(871);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, sumType);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HMatrix hmatrix;
            int procResult = HMatrix.LoadNew(proc, 0, err, out hmatrix);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hmatrix;
        }

        /// <summary>
        ///   Divide matrices element-by-element.
        ///   Instance represents: Matrix handle of the input matrix A.
        /// </summary>
        /// <param name="matrixBID">Matrix handle of the input matrix B.</param>
        public void DivElementMatrixMod(HMatrix matrixBID)
        {
            IntPtr proc = HalconAPI.PreCall(872);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)matrixBID);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)matrixBID);
        }

        /// <summary>
        ///   Divide matrices element-by-element.
        ///   Instance represents: Matrix handle of the input matrix A.
        /// </summary>
        /// <param name="matrixBID">Matrix handle of the input matrix B.</param>
        /// <returns>Matrix handle with the divided values of input matrices.</returns>
        public HMatrix DivElementMatrix(HMatrix matrixBID)
        {
            IntPtr proc = HalconAPI.PreCall(873);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)matrixBID);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HMatrix hmatrix;
            int procResult = HMatrix.LoadNew(proc, 0, err, out hmatrix);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)matrixBID);
            return hmatrix;
        }

        /// <summary>
        ///   Multiply matrices element-by-element.
        ///   Instance represents: Matrix handle of the input matrix A.
        /// </summary>
        /// <param name="matrixBID">Matrix handle of the input matrix B.</param>
        public void MultElementMatrixMod(HMatrix matrixBID)
        {
            IntPtr proc = HalconAPI.PreCall(874);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)matrixBID);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)matrixBID);
        }

        /// <summary>
        ///   Multiply matrices element-by-element.
        ///   Instance represents: Matrix handle of the input matrix A.
        /// </summary>
        /// <param name="matrixBID">Matrix handle of the input matrix B.</param>
        /// <returns>Matrix handle with the multiplied values of the input matrices.</returns>
        public HMatrix MultElementMatrix(HMatrix matrixBID)
        {
            IntPtr proc = HalconAPI.PreCall(875);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)matrixBID);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HMatrix hmatrix;
            int procResult = HMatrix.LoadNew(proc, 0, err, out hmatrix);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)matrixBID);
            return hmatrix;
        }

        /// <summary>
        ///   Scale a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="factor">Scale factor. Default: 2.0</param>
        public void ScaleMatrixMod(HTuple factor)
        {
            IntPtr proc = HalconAPI.PreCall(876);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, factor);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(factor);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Scale a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="factor">Scale factor. Default: 2.0</param>
        public void ScaleMatrixMod(double factor)
        {
            IntPtr proc = HalconAPI.PreCall(876);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, factor);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Scale a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="factor">Scale factor. Default: 2.0</param>
        /// <returns>Matrix handle with the scaled elements.</returns>
        public HMatrix ScaleMatrix(HTuple factor)
        {
            IntPtr proc = HalconAPI.PreCall(877);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, factor);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(factor);
            HMatrix hmatrix;
            int procResult = HMatrix.LoadNew(proc, 0, err, out hmatrix);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hmatrix;
        }

        /// <summary>
        ///   Scale a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="factor">Scale factor. Default: 2.0</param>
        /// <returns>Matrix handle with the scaled elements.</returns>
        public HMatrix ScaleMatrix(double factor)
        {
            IntPtr proc = HalconAPI.PreCall(877);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, factor);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HMatrix hmatrix;
            int procResult = HMatrix.LoadNew(proc, 0, err, out hmatrix);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hmatrix;
        }

        /// <summary>
        ///   Subtract two matrices.
        ///   Instance represents: Matrix handle of the input matrix A.
        /// </summary>
        /// <param name="matrixBID">Matrix handle of the input matrix B.</param>
        public void SubMatrixMod(HMatrix matrixBID)
        {
            IntPtr proc = HalconAPI.PreCall(878);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)matrixBID);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)matrixBID);
        }

        /// <summary>
        ///   Subtract two matrices.
        ///   Instance represents: Matrix handle of the input matrix A.
        /// </summary>
        /// <param name="matrixBID">Matrix handle of the input matrix B.</param>
        /// <returns>Matrix handle with the difference of the input matrices.</returns>
        public HMatrix SubMatrix(HMatrix matrixBID)
        {
            IntPtr proc = HalconAPI.PreCall(879);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)matrixBID);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HMatrix hmatrix;
            int procResult = HMatrix.LoadNew(proc, 0, err, out hmatrix);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)matrixBID);
            return hmatrix;
        }

        /// <summary>
        ///   Add two matrices.
        ///   Instance represents: Matrix handle of the input matrix A.
        /// </summary>
        /// <param name="matrixBID">Matrix handle of the input matrix B.</param>
        public void AddMatrixMod(HMatrix matrixBID)
        {
            IntPtr proc = HalconAPI.PreCall(880);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)matrixBID);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)matrixBID);
        }

        /// <summary>
        ///   Add two matrices.
        ///   Instance represents: Matrix handle of the input matrix A.
        /// </summary>
        /// <param name="matrixBID">Matrix handle of the input matrix B.</param>
        /// <returns>Matrix handle with the sum of the input matrices.</returns>
        public HMatrix AddMatrix(HMatrix matrixBID)
        {
            IntPtr proc = HalconAPI.PreCall(881);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)matrixBID);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HMatrix hmatrix;
            int procResult = HMatrix.LoadNew(proc, 0, err, out hmatrix);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)matrixBID);
            return hmatrix;
        }

        /// <summary>
        ///   Multiply two matrices.
        ///   Instance represents: Matrix handle of the input matrix A.
        /// </summary>
        /// <param name="matrixBID">Matrix handle of the input matrix B.</param>
        /// <param name="multType">Type of the input matrices. Default: "AB"</param>
        public void MultMatrixMod(HMatrix matrixBID, string multType)
        {
            IntPtr proc = HalconAPI.PreCall(882);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)matrixBID);
            HalconAPI.StoreS(proc, 2, multType);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)matrixBID);
        }

        /// <summary>
        ///   Multiply two matrices.
        ///   Instance represents: Matrix handle of the input matrix A.
        /// </summary>
        /// <param name="matrixBID">Matrix handle of the input matrix B.</param>
        /// <param name="multType">Type of the input matrices. Default: "AB"</param>
        /// <returns>Matrix handle of the multiplied matrices.</returns>
        public HMatrix MultMatrix(HMatrix matrixBID, string multType)
        {
            IntPtr proc = HalconAPI.PreCall(883);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)matrixBID);
            HalconAPI.StoreS(proc, 2, multType);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HMatrix hmatrix;
            int procResult = HMatrix.LoadNew(proc, 0, err, out hmatrix);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)matrixBID);
            return hmatrix;
        }

        /// <summary>
        ///   Get the size of a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="rows">Number of rows of the matrix.</param>
        /// <param name="columns">Number of columns of the matrix.</param>
        public void GetSizeMatrix(out int rows, out int columns)
        {
            IntPtr proc = HalconAPI.PreCall(884);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            int err2 = HalconAPI.LoadI(proc, 0, err1, out rows);
            int procResult = HalconAPI.LoadI(proc, 1, err2, out columns);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Repeat a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="rows">Number of copies of input matrix in row direction. Default: 2</param>
        /// <param name="columns">Number of copies of input matrix in column direction. Default: 2</param>
        /// <returns>Matrix handle of the repeated copied matrix.</returns>
        public HMatrix RepeatMatrix(int rows, int columns)
        {
            IntPtr proc = HalconAPI.PreCall(885);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, rows);
            HalconAPI.StoreI(proc, 2, columns);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HMatrix hmatrix;
            int procResult = HMatrix.LoadNew(proc, 0, err, out hmatrix);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hmatrix;
        }

        /// <summary>
        ///   Copy a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <returns>Matrix handle of the copied matrix.</returns>
        public HMatrix CopyMatrix()
        {
            IntPtr proc = HalconAPI.PreCall(886);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HMatrix hmatrix;
            int procResult = HMatrix.LoadNew(proc, 0, err, out hmatrix);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hmatrix;
        }

        /// <summary>
        ///   Set the diagonal elements of a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="vectorID">Matrix handle containing the diagonal elements to be set.</param>
        /// <param name="diagonal">Position of the diagonal. Default: 0</param>
        public void SetDiagonalMatrix(HMatrix vectorID, int diagonal)
        {
            IntPtr proc = HalconAPI.PreCall(887);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)vectorID);
            HalconAPI.StoreI(proc, 2, diagonal);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)vectorID);
        }

        /// <summary>
        ///   Get the diagonal elements of a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="diagonal">Number of the desired diagonal. Default: 0</param>
        /// <returns>Matrix handle containing the diagonal elements.</returns>
        public HMatrix GetDiagonalMatrix(int diagonal)
        {
            IntPtr proc = HalconAPI.PreCall(888);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, diagonal);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HMatrix hmatrix;
            int procResult = HMatrix.LoadNew(proc, 0, err, out hmatrix);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hmatrix;
        }

        /// <summary>
        ///   Set a sub-matrix of a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="matrixSubID">Matrix handle of the input sub-matrix.</param>
        /// <param name="row">Upper row position of the sub-matrix in the matrix. Default: 0</param>
        /// <param name="column">Left column position of the sub-matrix in the matrix. Default: 0</param>
        public void SetSubMatrix(HMatrix matrixSubID, int row, int column)
        {
            IntPtr proc = HalconAPI.PreCall(889);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, (HTool)matrixSubID);
            HalconAPI.StoreI(proc, 2, row);
            HalconAPI.StoreI(proc, 3, column);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            GC.KeepAlive((object)matrixSubID);
        }

        /// <summary>
        ///   Get a sub-matrix of a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="row">Upper row position of the sub-matrix in the input matrix. Default: 0</param>
        /// <param name="column">Left column position of the sub-matrix in the input matrix. Default: 0</param>
        /// <param name="rowsSub">Number of rows of the sub-matrix. Default: 1</param>
        /// <param name="columnsSub">Number of columns of the sub-matrix. Default: 1</param>
        /// <returns>Matrix handle of the sub-matrix.</returns>
        public HMatrix GetSubMatrix(int row, int column, int rowsSub, int columnsSub)
        {
            IntPtr proc = HalconAPI.PreCall(890);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, row);
            HalconAPI.StoreI(proc, 2, column);
            HalconAPI.StoreI(proc, 3, rowsSub);
            HalconAPI.StoreI(proc, 4, columnsSub);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HMatrix hmatrix;
            int procResult = HMatrix.LoadNew(proc, 0, err, out hmatrix);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return hmatrix;
        }

        /// <summary>
        ///   Set all values of a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="values">Values to be set.</param>
        public void SetFullMatrix(HTuple values)
        {
            IntPtr proc = HalconAPI.PreCall(891);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, values);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(values);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set all values of a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="values">Values to be set.</param>
        public void SetFullMatrix(double values)
        {
            IntPtr proc = HalconAPI.PreCall(891);
            this.Store(proc, 0);
            HalconAPI.StoreD(proc, 1, values);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Return all values of a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <returns>Values of the matrix elements.</returns>
        public HTuple GetFullMatrix()
        {
            IntPtr proc = HalconAPI.PreCall(892);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Set one or more elements of a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="row">Row numbers of the matrix elements to be modified. Default: 0</param>
        /// <param name="column">Column numbers of the matrix elements to be modified. Default: 0</param>
        /// <param name="value">Values to be set in the indicated matrix elements. Default: 0</param>
        public void SetValueMatrix(HTuple row, HTuple column, HTuple value)
        {
            IntPtr proc = HalconAPI.PreCall(893);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, row);
            HalconAPI.Store(proc, 2, column);
            HalconAPI.Store(proc, 3, value);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HalconAPI.UnpinTuple(value);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Set one or more elements of a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="row">Row numbers of the matrix elements to be modified. Default: 0</param>
        /// <param name="column">Column numbers of the matrix elements to be modified. Default: 0</param>
        /// <param name="value">Values to be set in the indicated matrix elements. Default: 0</param>
        public void SetValueMatrix(int row, int column, double value)
        {
            IntPtr proc = HalconAPI.PreCall(893);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, row);
            HalconAPI.StoreI(proc, 2, column);
            HalconAPI.StoreD(proc, 3, value);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Return one ore more elements of a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="row">Row numbers of matrix elements to be returned. Default: 0</param>
        /// <param name="column">Column numbers of matrix elements to be returned. Default: 0</param>
        /// <returns>Values of indicated matrix elements.</returns>
        public HTuple GetValueMatrix(HTuple row, HTuple column)
        {
            IntPtr proc = HalconAPI.PreCall(894);
            this.Store(proc, 0);
            HalconAPI.Store(proc, 1, row);
            HalconAPI.Store(proc, 2, column);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(row);
            HalconAPI.UnpinTuple(column);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, HTupleType.DOUBLE, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Return one ore more elements of a matrix.
        ///   Instance represents: Matrix handle of the input matrix.
        /// </summary>
        /// <param name="row">Row numbers of matrix elements to be returned. Default: 0</param>
        /// <param name="column">Column numbers of matrix elements to be returned. Default: 0</param>
        /// <returns>Values of indicated matrix elements.</returns>
        public double GetValueMatrix(int row, int column)
        {
            IntPtr proc = HalconAPI.PreCall(894);
            this.Store(proc, 0);
            HalconAPI.StoreI(proc, 1, row);
            HalconAPI.StoreI(proc, 2, column);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            double doubleValue;
            int procResult = HalconAPI.LoadD(proc, 0, err, out doubleValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return doubleValue;
        }

        /// <summary>
        ///   Create a matrix.
        ///   Modified instance represents: Matrix handle.
        /// </summary>
        /// <param name="rows">Number of rows of the matrix. Default: 3</param>
        /// <param name="columns">Number of columns of the matrix. Default: 3</param>
        /// <param name="value">Values for initializing the elements of the matrix. Default: 0</param>
        public void CreateMatrix(int rows, int columns, HTuple value)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(897);
            HalconAPI.StoreI(proc, 0, rows);
            HalconAPI.StoreI(proc, 1, columns);
            HalconAPI.Store(proc, 2, value);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(value);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a matrix.
        ///   Modified instance represents: Matrix handle.
        /// </summary>
        /// <param name="rows">Number of rows of the matrix. Default: 3</param>
        /// <param name="columns">Number of columns of the matrix. Default: 3</param>
        /// <param name="value">Values for initializing the elements of the matrix. Default: 0</param>
        public void CreateMatrix(int rows, int columns, double value)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(897);
            HalconAPI.StoreI(proc, 0, rows);
            HalconAPI.StoreI(proc, 1, columns);
            HalconAPI.StoreD(proc, 2, value);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(896);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
