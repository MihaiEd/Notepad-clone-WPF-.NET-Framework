using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace NotepadV2__.Models
{
    public class DocumentModel : ObservableObject
    {
        private string _text;
        private string _filePath;
        private string _fileName;
        private bool _isSaved;
  
       
      

       
       
        public string Text
        {
            get { return _text;  }
            set { OnPropertyChanged(ref _text, value); } 

        }

        public string FilePath
        {
            get { return _filePath; }
            set { OnPropertyChanged(ref _filePath, value); } 
        }

        public string FileName
        {
            get { return _fileName; }
            set { OnPropertyChanged(ref _fileName, value); } 
        }

        public bool isEmpty
        {
            get
            {
                if (string.IsNullOrEmpty(FileName) || string.IsNullOrEmpty(FilePath))
                    return true;
                return false;
            }
        }

        public bool IsSaved
        {   
            get { return _isSaved; }
            set { OnPropertyChanged(ref _isSaved, value); }
        }
    }
}
