using System.Collections.Generic;
using ICSharpCode.TextEditor.Document;

namespace ICSharpCode.TextEditor.Src.Document.FoldingStrategy
{
    public interface IFoldingStrategyEx : IFoldingStrategy
    {
        List<string> GetFoldingErrors();
    }
}