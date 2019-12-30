// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
// This file is part of CodingEditor.
// Note:	This project is derived from Peter Project
//			(hosted on sourceforge and codeplex)
//
// Copyright (c) 2008-2009, CE Team
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

using System.Collections.Generic;
using ICSharpCode.TextEditor.Document;

namespace ICSharpCode.TextEditor.Src.Document.FoldingStrategy
{
    public class CSharpFoldingStrategy : IFoldingStrategy
    {
        #region Methods

        /// <summary>
        /// Generates the foldings for our document.
        /// </summary>
        /// <param name="document">The current document.</param>
        /// <param name="fileName">The filename of the document.</param>
        /// <param name="parseInformation">Extra parse information, not used in this sample.</param>
        /// <returns>A list of FoldMarkers.</returns>
        public List<FoldMarker> GenerateFoldMarkers(IDocument document, string fileName, object parseInformation)
        {
            var list = new List<FoldMarker>();
            var startLines = new Stack<int>();

            // Create foldmarkers for the whole document, enumerate through every line.
            for (int i = 0; i < document.TotalNumberOfLines; i++)
            {
                var seg = document.GetLineSegment(i);
                int offs, end = document.TextLength;
                char c;
                for (offs = seg.Offset; offs < end && ((c = document.GetCharAt(offs)) == ' ' || c == '\t'); offs++)
                {
                }
                if (offs == end)
                    break;
                int spaceCount = offs - seg.Offset;

                // now offs points to the first non-whitespace char on the line
                if (document.GetCharAt(offs) == '#')
                {
                    string text = document.GetText(offs, seg.Length - spaceCount);
                    if (text.StartsWith("#region"))
                        startLines.Push(i);
                    if (text.StartsWith("#endregion") && startLines.Count > 0)
                    {
                        // Add a new FoldMarker to the list.
                        int start = startLines.Pop();
                        list.Add(new FoldMarker(document, start,
                            document.GetLineSegment(start).Length,
                            i, spaceCount + "#endregion".Length, FoldType.Region, "{...}"));
                    }
                }

                // { }
                if (document.GetCharAt(offs) == '{')
                {
                    int offsetOfClosingBracket = document.FormattingStrategy.SearchBracketForward(document, offs + 1, '{', '}');
                    if (offsetOfClosingBracket > 0)
                    {
                        int length = offsetOfClosingBracket - offs + 1;
                        list.Add(new FoldMarker(document, offs, length, "{...}", false));
                    }
                }

                if (document.GetCharAt(offs) == '/')
                {
                    string text = document.GetText(offs, seg.Length - spaceCount);
                    if (text.StartsWith("/// <summary>"))
                        startLines.Push(i);
                    if ((text.StartsWith("/// <param") || text.StartsWith("/// <returns>") || text.StartsWith("/// </summary>"))
                        && startLines.Count > 0)
                    {
                        // Add a new FoldMarker to the list.
                        int start = startLines.Pop();
                        list.Add(new FoldMarker(document, start,
                            document.GetLineSegment(start).Length,
                            i, spaceCount + "/// </summary>".Length, FoldType.TypeBody, "/// <summary>..."));
                    }

                }
            }

            return list;
        }

        #endregion Methods
    }
}