﻿using NotepadV2__.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace NotepadV2__.ViewModels
{
    public class FindViewModel
    {


        public ICommand FindCommand { get; }

        public ICommand ReplaceAllCommand { get; }

       
        public DocumentModel Document { get; set; }
        public FindDialog FindDialog { get; private set; }

        public FindViewModel(DocumentModel document)
        {
            Document = document;
            FindCommand = new Commands(Find);
            ReplaceAllCommand = new Commands(ReplaceAll);
           
        }


        private void Find()
        {

            string word = string.Empty;
            InputDialog inputDialog = new InputDialog("Please enter the word you are looking for: ");
            if (inputDialog.ShowDialog() == true)
            {
                word = inputDialog.Answer;
                TextBox textBox = new TextBox();
                textBox.Text = Document.Text;
                if (Document.Text != null)
                {
                    if (textBox.Text.Contains(word))
                    {
                        Console.WriteLine("Da");

                        var regex = new Regex(word, RegexOptions.IgnoreCase);
                        foreach (Match m in regex.Matches(textBox.Text))
                        {
                            textBox.Text = textBox.Text.Replace(m.ToString(), "*" + m.ToString() + "*");

                        }

                        FindDialog = new FindDialog(textBox);
                        FindDialog.Show();
                    }
                    else
                    {
                        NotFound();
                    }
                }
            }

        }

        private void ReplaceAll()
        {
            string wordToReplace = string.Empty;
            InputDialogReplace inputDialog = new InputDialogReplace("Please enter the word you want to replace: ", "Enter the word you want to replace with:", "", "");
            if (inputDialog.ShowDialog() == true)
            {
                wordToReplace = inputDialog.Answer;
                string wordToBeReplacedWith = inputDialog.Answer2;

                if (Document.Text != null && Document.Text.Contains(wordToReplace))
                {
                    Document.Text = Document.Text.Replace(wordToReplace, wordToBeReplacedWith);
                   
                }
                else
                {
                    NotFound();
                }
            }
        }


        private void NotFound()
        {
            MessageBox.Show(string.Format("The word dosen't exist!"), "Not Found", MessageBoxButton.OK);
        }
    }
}
