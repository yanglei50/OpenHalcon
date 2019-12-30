using ICSharpCode.TextEditor.Actions;
using ICSharpCode.TextEditor.UserControls;

namespace ICSharpCode.TextEditor.Src.Actions
{
    abstract class FindAndReplaceFormActions : AbstractEditAction
    {
        protected readonly TextEditorControlEx Control;
        protected readonly FindAndReplaceForm FindForm;

        protected FindAndReplaceFormActions(FindAndReplaceForm findForm, TextEditorControlEx control)
        {
            FindForm = findForm;
            Control = control;
        }
    }

    class FindAgainReverseAction : FindAndReplaceFormActions
    {
        public FindAgainReverseAction(FindAndReplaceForm findForm, TextEditorControlEx control)
            : base(findForm, control)
        {
        }

        public override void Execute(TextArea textArea)
        {
            FindForm.FindNext(true, true, string.Format("Search text «{0}» not found.", FindForm.LookFor));
        }
    }

    class FindAgainAction : FindAndReplaceFormActions
    {
        public FindAgainAction(FindAndReplaceForm findForm, TextEditorControlEx control)
            : base(findForm, control)
        {
        }

        public override void Execute(TextArea textArea)
        {
            FindForm.FindNext(true, false, string.Format("Search text «{0}» not found.", FindForm.LookFor));
        }
    }

    class EditReplaceAction : FindAndReplaceFormActions
    {
        public EditReplaceAction(FindAndReplaceForm findForm, TextEditorControlEx control)
            : base(findForm, control)
        {
        }

        public override void Execute(TextArea textArea)
        {
            FindForm.ShowFor(Control, true);
        }
    }

    class EditFindAction : FindAndReplaceFormActions
    {
        public EditFindAction(FindAndReplaceForm findForm, TextEditorControlEx control)
            : base(findForm, control)
        {
        }

        public override void Execute(TextArea textArea)
        {
            FindForm.ShowFor(Control, false);
        }
    }
}