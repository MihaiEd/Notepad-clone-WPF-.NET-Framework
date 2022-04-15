using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using NotepadV2__.Models;
namespace NotepadV2__.ViewModels
{
    public class EditViewModels
    {
        public ICommand FormatCommand { get; }
        public ICommand WrapCommand { get; }
        public FormatModels Format { get; set; }
        public DocumentModel Document { get; set; }
        public EditViewModels(DocumentModel document)
        {
            Document = document;
            Format = new FormatModels();
            FormatCommand = new Commands(OpenStyleDialog);
            WrapCommand = new Commands(ToggleWrap);
        }
        private void OpenStyleDialog()
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.DataContext = Format;
            fontDialog.ShowDialog();
        }
        private void ToggleWrap()
        {
            if (Format.Wrap == System.Windows.TextWrapping.Wrap)
                Format.Wrap = System.Windows.TextWrapping.NoWrap;
            else
                Format.Wrap = System.Windows.TextWrapping.Wrap;
        }
    }
}
