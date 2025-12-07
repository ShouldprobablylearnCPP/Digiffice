using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Digiffice.Resources.Classes.ProgramClasses;
using Digiffice.Resources.Classes.ProgramClasses.DigifficeAllpad;

namespace Digiffice
{

    public partial class DigifficeAllpad : Form
    {
        // Class Variables
        Image xBtnDefault = Properties.Resources.XbtnDefault;
        Image xBtnHover = Properties.Resources.XbtnHover;

        public DigifficeAllpad(nonprotected_AccountData nonprotected_AccountData)
        {
            this.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            DigifficeAllpad_NewFile("NewNotebook");
            InitializeComponent();
        }

        // Exit Button Events
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ExitButton_MouseEnter(object sender, EventArgs e)
        {
            ExitButton.Image = xBtnHover;
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e)
        {
            ExitButton.Image = xBtnDefault;
        }

        // File Events
        private void DigifficeAllpad_NewFile(string fileName)
        {
            Vector2 defaultPageSize_Inches = new Vector2(8.27f, 11.69f);
            DigifficeAllpadEditorFile editorFile = new DigifficeAllpadEditorFile();
            editorFile.fileName = fileName;
            DigifficeAllpad_NewChapter("New chapter", editorFile);
            DigifficeAllpadEditorFile.Chapter? firstChapter = FindChapterByName(editorFile, "New chapter");
            if (firstChapter == null)
            {
                MessageBox.Show("Error creating new notebook: first chapter not found. Closing Digiffice Allpad...");
                this.Close();
            }
#pragma warning disable CS8629 // Nullable value type may be null.
            DigifficeAllpad_NewPage("New page", defaultPageSize_Inches, editorFile, (DigifficeAllpadEditorFile.Chapter)firstChapter);
#pragma warning restore CS8629 // Nullable value type may be null.
        }

        // File Element Events
        private void DigifficeAllpad_NewPage(string pageName, Vector2 Size, DigifficeAllpadEditorFile parentNotebook, DigifficeAllpadEditorFile.Chapter parentChapter)
        {
            DigifficeAllpadEditorFile.Page newPage = new DigifficeAllpadEditorFile.Page();
            newPage.pageSize = Size;
            newPage.pageTitle = pageName;
            newPage.CreatedDateTime = DateTime.Now;
            newPage.pageNum = parentNotebook.filePages.Count + 1;
            newPage.parentChapter = parentChapter;
            parentNotebook.filePages.Add(newPage);
            parentChapter.chapterPages.Add(newPage);
        }

        private void DigifficeAllpad_NewChapter(string chapterName, DigifficeAllpadEditorFile parentNotebook)
        {
            DigifficeAllpadEditorFile.Chapter newChapter = new DigifficeAllpadEditorFile.Chapter();
            newChapter.chapterName = chapterName;
            newChapter.chapterNum = parentNotebook.chapters.Count + 1;
            parentNotebook.chapters.Add(newChapter);
        }

        // Other File Events

        private DigifficeAllpadEditorFile.Chapter? FindChapterByName(DigifficeAllpadEditorFile file, string name)
        {
            foreach (DigifficeAllpadEditorFile.Chapter chapter in file.chapters)
            {
                if (chapter.chapterName == name)
                {
                    return chapter;
                }
            }
            MessageBox.Show("Chapter " + name + " not found in file " + file.fileName);
            return null;
        }
    }
}
