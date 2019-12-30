using System.Windows.Forms;
using ICSharpCode.TextEditor.Actions;
using ICSharpCode.TextEditor.UserControls;

namespace ICSharpCode.TextEditor.Src.Actions
{
    class GoToLineNumberAction : AbstractEditAction
    {
        private readonly GotoForm _gotoForm;

        public GoToLineNumberAction()
        {
            _gotoForm = new GotoForm();
        }

        public override void Execute(TextArea textArea)
        {
            _gotoForm.FirstLineNumber = 1;
            _gotoForm.LastLineNumber = textArea.Document.TotalNumberOfLines;
            _gotoForm.SelectedLineNumber = textArea.Caret.Line + 1;

            if (DialogResult.OK == _gotoForm.ShowDialogEx() && _gotoForm.SelectedLineNumber > 0)
            {
                textArea.Caret.Position = new TextLocation(0, _gotoForm.SelectedLineNumber - 1);
            }
        }
    }
}