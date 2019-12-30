using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Actions;
using ICSharpCode.TextEditor.Document;
using ICSharpCode.TextEditor.Properties;
using ICSharpCode.TextEditor.Src.Actions;
using ICSharpCode.TextEditor.Src.Document.FoldingStrategy;
using ICSharpCode.TextEditor.Src.Document.HighlightingStrategy.SyntaxModes;
using ICSharpCode.TextEditor.UserControls;

// ReSharper disable once CheckNamespace
namespace ICSharpCode.TextEditor
{
    [ToolboxBitmap("ICSharpCode.TextEditorEx.Resources.TextEditorControl.bmp")]
    [ToolboxItem(true)]
    public class TextEditorControlEx : TextEditorControl
    {
        private bool _contextMenuEnabled;
        private bool _contextMenuShowDefaultIcons;
        private bool _contextMenuShowShortCutKeys;
        private readonly FindAndReplaceForm _findForm = new FindAndReplaceForm();

        public TextEditorControlEx()
        {
            editactions[Keys.Control | Keys.F] = new EditFindAction(_findForm, this);
            editactions[Keys.Control | Keys.H] = new EditReplaceAction(_findForm, this);
            editactions[Keys.F3] = new FindAgainAction(_findForm, this);
            editactions[Keys.F3 | Keys.Shift] = new FindAgainReverseAction(_findForm, this);
            editactions[Keys.Control | Keys.G] = new GoToLineNumberAction();

            // Add additional Syntax highlighting providers
            HighlightingManager.Manager.AddSyntaxModeFileProvider(new ResourceSyntaxModeProviderEx());

            TextChanged += TextChangedEventHandler;
        }

        protected override void OnLoad(EventArgs e)
        {
            if (ContextMenuEnabled)
            {
                //LEI AssignContextMenu(CreateNewContextMenu(ContextMenuShowDefaultIcons, ContextMenuShowShortCutKeys));
            }

            base.OnLoad(e);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            TextChanged -= TextChangedEventHandler;
        }

        private void TextChangedEventHandler(object sender, EventArgs e)
        {
            var editor = sender as TextEditorControlEx;
            if (editor != null)
            {
                bool vScrollBarIsNeeded = editor.Document.TotalNumberOfLines > ActiveTextAreaControl.TextArea.TextView.VisibleLineCount;
                if (ActiveTextAreaControl.VScrollBar.Visible && HideVScrollBarIfPossible && !vScrollBarIsNeeded)
                {
                    ActiveTextAreaControl.ShowScrollBars(Orientation.Vertical, false);
                }
            }
        }

        #region Extended properties
        public string SelectedText
        {
            get
            {
                return ActiveTextAreaControl.SelectionManager.SelectedText;
            }
        }

        public string[] Lines
        {
            get
            {
                return base.Text.Split(new[] { "\r\n" }, StringSplitOptions.None);
            }
        }
        #endregion

        #region Designer Properties
        /// <value>
        /// The current document
        /// </value>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new IDocument Document
        {
            get
            {
                return document;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                if (document != null)
                {
                    document.DocumentChanged -= OnDocumentChanged;
                    document.DocumentChanged -= OnDocumentChangedDoUpdateContextMenu;
                }

                document = value;
                document.UndoStack.TextEditorControl = this;
                document.DocumentChanged += OnDocumentChanged;
                document.DocumentChanged += OnDocumentChangedDoUpdateContextMenu;
            }
        }

        /// <value>
        /// The base font of the text area. No bold or italic fonts
        /// can be used because bold/italic is reserved for highlighting
        /// purposes.
        /// </value>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(typeof(Font), null)]
        [Description("The base font of the text area. No bold or italic fonts can be used because bold/italic is reserved for highlighting purposes.")]
        public override Font Font
        {
            get
            {
                return Document.TextEditorProperties.Font;
            }
            set
            {
                Document.TextEditorProperties.Font = value;
                OptionsChanged();
            }
        }

        [Category("Appearance")]
        [DefaultValue(false)]
        [Description("Hide the vertical ScrollBar if it's not needed. ")]
        public bool HideVScrollBarIfPossible { get; set; }

        private string _foldingStrategy;
        [Category("Appearance")]
        [Description("Set the Folding Strategy. Supported : XML and CSharp.")]
        public string FoldingStrategy
        {
            get
            {
                return _foldingStrategy;
            }
            set
            {
                SetFoldingStrategy(value);
                OptionsChanged();
            }
        }

        private string _syntaxHighlighting;
        [Category("Appearance")]
        [Description("Sets the Syntax Highlighting.")]
        public string SyntaxHighlighting
        {
            get
            {
                return _syntaxHighlighting;
            }
            set
            {
                _syntaxHighlighting = value;
                SetHighlighting(_syntaxHighlighting);
                OptionsChanged();
            }
        }

        [Category("Behavior")]
        [DefaultValue(false)]
        [Description("If true document is readonly.")]
        [Browsable(true)]
        public new bool IsReadOnly
        {
            get
            {
                return Document.ReadOnly;
            }
            set
            {
                Document.ReadOnly = value;
                OptionsChanged();
            }
        }

        [DefaultValue(false)]
        [Category("Appearance")]
        [Description("Show default Icons in ContextMenu")]
        [Browsable(true)]
        public bool ContextMenuShowDefaultIcons
        {
            get
            {
                return _contextMenuShowDefaultIcons & _contextMenuEnabled;
            }

            set
            {
                _contextMenuShowDefaultIcons = _contextMenuEnabled & value;
            }
        }

        [DefaultValue(false)]
        [Category("Appearance")]
        [Description("Show shortcut keys in ContextMenu")]
        [Browsable(true)]
        public bool ContextMenuShowShortCutKeys
        {
            get
            {
                return _contextMenuShowShortCutKeys & _contextMenuEnabled;
            }

            set
            {
                _contextMenuShowShortCutKeys = _contextMenuEnabled & value;
            }
        }

        [DefaultValue(false)]
        [Category("Appearance")]
        [Description("Enable a ContextMenu")]
        [Browsable(true)]
        public bool ContextMenuEnabled
        {
            get
            {
                return _contextMenuEnabled;
            }

            set
            {
                _contextMenuEnabled = value;
            }
        }
        #endregion

        /// <summary>
        /// Sets the text and refreshes the control.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="updateFoldings">if set to <c>true</c> [update foldings].</param>
        public void SetTextAndRefresh(string text, bool updateFoldings = false)
        {
            ResetText();
            Text = text;

            if (updateFoldings && Document.TextEditorProperties.EnableFolding)
            {
                Document.FoldingManager.UpdateFoldings(null, null);
            }

            Refresh();
        }

        /// <summary>
        /// Sets the folding strategy. Currently only XML is supported.
        /// </summary>
        /// <param name="foldingStrategy">The foldingStrategy.</param>
        public void SetFoldingStrategy(string foldingStrategy)
        {
            if (foldingStrategy == null)
            {
                throw new ArgumentNullException("foldingStrategy");
            }

            if (!Document.TextEditorProperties.EnableFolding)
            {
                return;
            }

            switch (foldingStrategy)
            {
                case "XML":
                    _foldingStrategy = foldingStrategy;
                    Document.FoldingManager.FoldingStrategy = new XmlFoldingStrategy();
                    break;

                case "CSharp":
                    _foldingStrategy = foldingStrategy;
                    Document.FoldingManager.FoldingStrategy = new CSharpFoldingStrategy();
                    break;

                default:
                    Document.FoldingManager.FoldingStrategy = null;
                    _foldingStrategy = null;
                    break;
            }

            Document.FoldingManager.UpdateFoldings(null, null);
        }

        /// <summary>
        /// Gets the folding errors. Currently only XML is supported.
        /// </summary>
        /// <returns>List of errors, else empty list</returns>
        public List<string> GetFoldingErrors()
        {
            if (_foldingStrategy == "XML")
            {
                var foldingStrategy = Document.FoldingManager.FoldingStrategy as IFoldingStrategyEx;
                if (foldingStrategy != null)
                {
                    return foldingStrategy.GetFoldingErrors();
                }
            }

            return new List<string>();
        }

        #region ContextMenu Commands implementations
        private bool CanUndo()
        {
            return Document.UndoStack.CanUndo;
        }

        private bool CanRedo()
        {
            return Document.UndoStack.CanRedo;
        }

        private bool CanCopy()
        {
            return ActiveTextAreaControl.SelectionManager.HasSomethingSelected;
        }

        private bool CanCut()
        {
            return ActiveTextAreaControl.SelectionManager.HasSomethingSelected;
        }

        private bool CanDelete()
        {
            return ActiveTextAreaControl.SelectionManager.HasSomethingSelected;
        }

        private bool CanPaste()
        {
            return ActiveTextAreaControl.TextArea.ClipboardHandler.EnablePaste;
        }

        private bool CanSelectAll()
        {
            if (Document.TextContent == null)
                return false;

            return !Document.TextContent.Trim().Equals(String.Empty);
        }

        private bool CanFind()
        {
            if (Document.TextContent == null)
                return false;

            return Document.TextContent.Trim().Any();
        }

        private void DoCut()
        {
            new Cut().Execute(ActiveTextAreaControl.TextArea);
            ActiveTextAreaControl.Focus();
        }

        private void DoDelete()
        {
            new Delete().Execute(ActiveTextAreaControl.TextArea);
            ActiveTextAreaControl.Focus();
        }

        private void DoCopy()
        {
            new Copy().Execute(ActiveTextAreaControl.TextArea);
            ActiveTextAreaControl.Focus();
        }

        private void DoPaste()
        {
            new Paste().Execute(ActiveTextAreaControl.TextArea);
            ActiveTextAreaControl.Focus();
        }

        private void DoSelectAll()
        {
            new SelectWholeDocument().Execute(ActiveTextAreaControl.TextArea);
            ActiveTextAreaControl.Focus();
        }

        public void DoToggleFoldings()
        {
            new ToggleAllFoldings().Execute(ActiveTextAreaControl.TextArea);
        }

        private void DoFind()
        {
            new EditFindAction(_findForm, this).Execute(ActiveTextAreaControl.TextArea);
        }
        #endregion

        #region ContextMenu Initialization


        private ContextMenuStrip CreateNewContextMenu(bool showImages, bool showKeys)
        {
            var mnu = new ContextMenuStripEx();
            mnu.AddToolStripMenuItem("&Undo",
                showImages ? Resources.sc_undo : null,
                (sender, e) => Undo(),
                showKeys ? Keys.Control | Keys.Z : Keys.None,
                CanUndo
            );

            mnu.AddToolStripMenuItem("&Redo",
               showImages ? Resources.sc_redo : null,
               (sender, e) => Redo(),
               showKeys ? Keys.Control | Keys.Y : Keys.None,
               CanRedo
            );

            mnu.AddToolStripSeparator();

            mnu.AddToolStripMenuItem("&Cut",
                showImages ? Resources.cut : null,
                (sender, e) => DoCut(),
                showKeys ? Keys.Control | Keys.X : Keys.None,
                CanCut
            );

            mnu.AddToolStripMenuItem("Cop&y",
                showImages ? Resources.sc_copy : null,
                (sender, e) => DoCopy(),
                showKeys ? Keys.Control | Keys.C : Keys.None,
                CanCopy
            );

            mnu.AddToolStripMenuItem("&Paste",
                showImages ? Resources.sc_paste : null,
                (sender, e) => DoPaste(),
                showKeys ? Keys.Control | Keys.V : Keys.None,
                CanPaste
            );

            mnu.AddToolStripSeparator();

            mnu.AddToolStripMenuItem("&Delete",
                showImages ? Resources.sc_cancel : null,
                (sender, e) => DoDelete(),
                showKeys ? Keys.Delete : Keys.None,
                CanDelete
            );

            mnu.AddToolStripMenuItem("&Select All",
                showImages ? Resources.sc_selectall : null,
                (sender, e) => DoSelectAll(),
                showKeys ? Keys.Control | Keys.A : Keys.None,
                CanSelectAll
            );

            mnu.AddToolStripMenuItem("&Find",
                showImages ? Resources.sc_searchdialog : null,
                (sender, e) => DoFind(),
                showKeys ? Keys.Control | Keys.F : Keys.None,
                CanFind
            );

            return mnu;
        }

        private void AssignContextMenu(ContextMenuStrip mnu)
        {
            if (ActiveTextAreaControl.ContextMenuStrip != null)
            {
                ActiveTextAreaControl.ContextMenuStrip.Dispose();
                ActiveTextAreaControl.ContextMenuStrip = null;
            }

            ActiveTextAreaControl.ContextMenuStrip = mnu;
        }
        #endregion

        #region ContextMenu Methods
        public void SelectText(int start, int length)
        {
            var textLength = Document.TextLength;
            if (textLength < (start + length))
            {
                length = (textLength - 1) - start;
            }
            ActiveTextAreaControl.Caret.Position = Document.OffsetToPosition(start + length);
            ActiveTextAreaControl.SelectionManager.ClearSelection();
            ActiveTextAreaControl.SelectionManager.SetSelection(new DefaultSelection(Document, Document.OffsetToPosition(start), Document.OffsetToPosition(start + length)));
            Refresh();
        }

        private void OnDocumentChangedDoUpdateContextMenu(object sender, DocumentEventArgs e)
        {
            bool isVisible = (Document.TotalNumberOfLines > ActiveTextAreaControl.TextArea.TextView.VisibleLineCount);
            ActiveTextAreaControl.VScrollBar.Visible = isVisible;
        }
        #endregion
    }

    public static class TextAreaControlExtensions
    {
        /// <summary>
        /// Extension method to show a scrollbar.
        /// </summary>
        /// <param name="textAreaControl">The text area control.</param>
        /// <param name="orientation">The orientation.</param>
        /// <param name="isVisible">if set to <c>true</c> [is visible].</param>
        public static void ShowScrollBars(this TextAreaControl textAreaControl, Orientation orientation, bool isVisible)
        {
            if (orientation == Orientation.Vertical)
            {
                textAreaControl.VScrollBar.Visible = isVisible;
            }
            else
            {
                textAreaControl.HScrollBar.Visible = isVisible;
            }
        }
    }
}