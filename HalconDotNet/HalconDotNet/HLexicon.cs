// Decompiled with JetBrains decompiler
// Type: HalconDotNet.HLexicon
// Assembly: halcondotnetxl, Version=17.12.0.0, Culture=neutral, PublicKeyToken=4973bed59ddbf2b8
// MVID: 39799324-2494-4A83-8C57-2731D25BAE81
// Assembly location: C:\Program Files\MVTec\HALCON-17.12-Progress\bin\dotnet35\halcondotnetxl.dll

using System;
using System.ComponentModel;

namespace HalconDotNet
{
    /// <summary>Represents an instance of a lexicon.</summary>
    public class HLexicon : HTool
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HLexicon()
          : base(HTool.UNDEF)
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public HLexicon(IntPtr handle)
          : base(handle)
        {
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HLexicon obj)
        {
            obj = new HLexicon(HTool.UNDEF);
            return obj.Load(proc, parIndex, err);
        }

        internal static int LoadNew(IntPtr proc, int parIndex, int err, out HLexicon[] obj)
        {
            HTuple tuple;
            err = HTuple.LoadNew(proc, parIndex, err, out tuple);
            obj = new HLexicon[tuple.Length];
            for (int index = 0; index < tuple.Length; ++index)
                obj[index] = new HLexicon(tuple[index].IP);
            return err;
        }

        /// <summary>
        ///   Create a lexicon from a text file.
        ///   Modified instance represents: Handle of the lexicon.
        /// </summary>
        /// <param name="name">Unique name for the new lexicon. Default: "lex1"</param>
        /// <param name="fileName">Name of a text file containing words for the new lexicon. Default: "words.txt"</param>
        public HLexicon(string name, string fileName)
        {
            IntPtr proc = HalconAPI.PreCall(670);
            HalconAPI.StoreS(proc, 0, name);
            HalconAPI.StoreS(proc, 1, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a lexicon from a tuple of words.
        ///   Modified instance represents: Handle of the lexicon.
        /// </summary>
        /// <param name="name">Unique name for the new lexicon. Default: "lex1"</param>
        /// <param name="words">Word list for the new lexicon. Default: ["word1","word2","word3"]</param>
        public HLexicon(string name, HTuple words)
        {
            IntPtr proc = HalconAPI.PreCall(671);
            HalconAPI.StoreS(proc, 0, name);
            HalconAPI.Store(proc, 1, words);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(words);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Find a similar word in a lexicon.
        ///   Instance represents: Handle of the lexicon.
        /// </summary>
        /// <param name="word">Word to be looked up. Default: "word"</param>
        /// <param name="numCorrections">Difference between the words in edit operations.</param>
        /// <returns>Most similar word found in the lexicon.</returns>
        public string SuggestLexicon(string word, out int numCorrections)
        {
            IntPtr proc = HalconAPI.PreCall(667);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, word);
            HalconAPI.InitOCT(proc, 0);
            HalconAPI.InitOCT(proc, 1);
            int err1 = HalconAPI.CallProcedure(proc);
            string stringValue;
            int err2 = HalconAPI.LoadS(proc, 0, err1, out stringValue);
            int procResult = HalconAPI.LoadI(proc, 1, err2, out numCorrections);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return stringValue;
        }

        /// <summary>
        ///   Check if a word is contained in a lexicon.
        ///   Instance represents: Handle of the lexicon.
        /// </summary>
        /// <param name="word">Word to be looked up. Default: "word"</param>
        /// <returns>Result of the search.</returns>
        public int LookupLexicon(string word)
        {
            IntPtr proc = HalconAPI.PreCall(668);
            this.Store(proc, 0);
            HalconAPI.StoreS(proc, 1, word);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int intValue;
            int procResult = HalconAPI.LoadI(proc, 0, err, out intValue);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return intValue;
        }

        /// <summary>
        ///   Query all words from a lexicon.
        ///   Instance represents: Handle of the lexicon.
        /// </summary>
        /// <returns>List of all words.</returns>
        public HTuple InspectLexicon()
        {
            IntPtr proc = HalconAPI.PreCall(669);
            this.Store(proc, 0);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HTuple tuple;
            int procResult = HTuple.LoadNew(proc, 0, err, out tuple);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
            return tuple;
        }

        /// <summary>
        ///   Create a lexicon from a text file.
        ///   Modified instance represents: Handle of the lexicon.
        /// </summary>
        /// <param name="name">Unique name for the new lexicon. Default: "lex1"</param>
        /// <param name="fileName">Name of a text file containing words for the new lexicon. Default: "words.txt"</param>
        public void ImportLexicon(string name, string fileName)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(670);
            HalconAPI.StoreS(proc, 0, name);
            HalconAPI.StoreS(proc, 1, fileName);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        /// <summary>
        ///   Create a lexicon from a tuple of words.
        ///   Modified instance represents: Handle of the lexicon.
        /// </summary>
        /// <param name="name">Unique name for the new lexicon. Default: "lex1"</param>
        /// <param name="words">Word list for the new lexicon. Default: ["word1","word2","word3"]</param>
        public void CreateLexicon(string name, HTuple words)
        {
            this.Dispose();
            IntPtr proc = HalconAPI.PreCall(671);
            HalconAPI.StoreS(proc, 0, name);
            HalconAPI.Store(proc, 1, words);
            HalconAPI.InitOCT(proc, 0);
            int err = HalconAPI.CallProcedure(proc);
            HalconAPI.UnpinTuple(words);
            int procResult = this.Load(proc, 0, err);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }

        protected override void ClearHandleResource()
        {
            IntPtr proc = HalconAPI.PreCall(666);
            this.Store(proc, 0);
            int procResult = HalconAPI.CallProcedure(proc);
            HalconAPI.PostCall(proc, procResult);
            GC.KeepAlive((object)this);
        }
    }
}
