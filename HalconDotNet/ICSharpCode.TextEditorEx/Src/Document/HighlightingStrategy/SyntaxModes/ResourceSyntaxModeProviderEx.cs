using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Xml;
using ICSharpCode.TextEditor.Document;

namespace ICSharpCode.TextEditor.Src.Document.HighlightingStrategy.SyntaxModes
{
    public class ResourceSyntaxModeProviderEx : ISyntaxModeFileProvider
    {
        private string ResourcesDir = "ICSharpCode.TextEditorEx.Resources.";

        readonly List<SyntaxMode> _syntaxModes;

        public ICollection<SyntaxMode> SyntaxModes
        {
            get
            {
                return _syntaxModes;
            }
        }

        public ResourceSyntaxModeProviderEx()
        {
            var syntaxModeStream = GetSyntaxModeStream("SyntaxModesEx.xml");

            _syntaxModes = syntaxModeStream != null ? SyntaxMode.GetSyntaxModes(syntaxModeStream) : new List<SyntaxMode>();
        }

        public XmlTextReader GetSyntaxModeFile(SyntaxMode syntaxMode)
        {
            var stream = GetSyntaxModeStream(syntaxMode.FileName);

            return stream != null ? new XmlTextReader(stream) : null;
        }

        public void UpdateSyntaxModeList()
        {
            // resources don't change during runtime
        }

        private Stream GetSyntaxModeStream(string filename)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            //String projectName = Assembly.GetExecutingAssembly().GetName().Name.ToString();
            //ResourcesDir = Assembly.GetExecutingAssembly().GetName().Name.ToString();
            //Stream stmMode = Assembly.GetExecutingAssembly().GetManifestResourceStream(projectName + ".Resources" + "."+ filename);
            Stream stmMode = assembly.GetManifestResourceStream(string.Format("{0}{1}", ResourcesDir, filename));
            return stmMode;
            //return assembly.GetManifestResourceStream(string.Format("{0}{1}", ResourcesDir, filename));
        }
    }
}
