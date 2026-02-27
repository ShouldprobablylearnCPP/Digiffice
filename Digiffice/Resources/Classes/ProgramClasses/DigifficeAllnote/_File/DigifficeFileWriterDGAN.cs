using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Digiffice.Resources.Classes.ProgramClasses.DigifficeAllpad;

namespace Digiffice.Resources.Classes.ProgramClasses.DigifficeAllnote._File
{
    public class DigifficeFileWriterDGAN
    {
        // Write DGAN file method
        public void WriteDGANFile(DigifficeAllnoteEditorFile file, string filePath)
        {
            using (FileStream fs = File.Create(filePath))
            {
                using (BrotliStream brotli = new BrotliStream(fs, CompressionMode.Compress))
                using (StreamWriter writer = new StreamWriter(brotli, Encoding.UTF8))
                {
                    // Step 1: Write (HEADER) - File name
                    writer.WriteLine("(HEADER)");
                    writer.WriteLine("NAME: \"" + file.fileName + "\"");
                    writer.WriteLine("");

                    // Step 2: Write (STRUCTURE) - includes Chapter groups, Chapters, Pages, and SubPages. This section must only define the properties of each element and their relationships, but not the contents.
                    // Note: The order is: / = Chapter Group, // = Chapter, /// = Page, //// = SubPage
                    writer.WriteLine("(STRUCTURE)");

                    // Write Structure for Chapter groups
                    foreach (DigifficeAllnoteEditorFile.ChapterGroup chapterGroup in file.ChapterGroups)
                    {
                        writer.WriteLine("");
                        writer.WriteLine("/");
                        writer.WriteLine("|NAME: \"" + chapterGroup.chapterGroupName + "\"");
                        writer.WriteLine("|NUM: " + chapterGroup.chapterGroupNum);

                        // Define string to add to line for chapter group chapters
                        string chapterGroupChapterNumbers = "[";

                        // Get number of each chapter in the chapter group
                        foreach (DigifficeAllnoteEditorFile.Chapter chapter in chapterGroup.groupChapters)
                        {
                            chapterGroupChapterNumbers += chapter.chapterNum;
                            if (chapterGroup.groupChapters.IndexOf(chapter) != chapterGroup.groupChapters.Count - 1)
                            {
                                chapterGroupChapterNumbers += ", ";
                            }
                        }
                        chapterGroupChapterNumbers += "]";
                        writer.WriteLine("|GROUPCHAPTERS: " + chapterGroupChapterNumbers);
                        writer.WriteLine("\\");
                    }

                    // Write Structure for Chapters
                    foreach (DigifficeAllnoteEditorFile.Chapter chapter in file.chapters)
                    {
                        writer.WriteLine("");
                        writer.WriteLine("//");
                        writer.WriteLine("|NAME: \"" + chapter.chapterName + "\"");
                        writer.WriteLine("|NUM: " + chapter.chapterNum);

                        // If chapter has parent chapter group, write parent chapter group number
                        if (chapter.parentChapterGroup != null)
                        {
                            writer.WriteLine("|PARENTGROUP: " + (file.ChapterGroups.IndexOf(chapter.parentChapterGroup) + 1));
                        }
                        else
                        {
                            writer.WriteLine("|PARENTGROUP: -1");
                        }

                        // Define string to add to line for chapter pages
                        string chapterPageNumbers = "[";

                        // Get number of each page in the chapter
                        foreach (DigifficeAllnoteEditorFile.Page page in chapter.chapterPages)
                        {
                            chapterPageNumbers += page.pageNum;
                            if (chapter.chapterPages.IndexOf(page) != chapter.chapterPages.Count - 1)
                            {
                                chapterPageNumbers += ", ";
                            }
                        }
                        chapterPageNumbers += "]";
                        writer.WriteLine("|CHAPTERPAGES: " + chapterPageNumbers);

                        // Add Chapter col information
                        string chapterColor = "[";
                        chapterColor += chapter.chapterCol.R + ", " + chapter.chapterCol.G + ", " + chapter.chapterCol.B;
                        chapterColor += "]";
                        writer.WriteLine("|RGBCOL: " + chapterColor);
                        writer.WriteLine("\\\\");
                    }

                    // Write Structure for Pages
                    foreach (DigifficeAllnoteEditorFile.Page page in file.filePages)
                    {
                        writer.WriteLine("");
                        writer.WriteLine("///");
                        writer.WriteLine("|NAME: \"" + page.pageTitle + "\"");
                        writer.WriteLine("|PAGESIZE: [" + page.pageSize.X + ", " + page.pageSize.Y + "]");
                        writer.WriteLine("|CREATEDDATETIME: " + page.CreatedDateTime);
                        writer.WriteLine("|NUM: " + page.pageNum);
                        // If page has parent chapter, write parent chapter number
                        if (page.parentChapter != null)
                        {
                            writer.WriteLine("|PARENTCHAPTER: " + (file.chapters.IndexOf(page.parentChapter) + 1));
                        }
                        else
                        {
                            writer.WriteLine("|PARENTCHAPTER: -1");
                        }
                        // Define string to add to line for page subpages
                        string pageSubPageNumbers = "[";
                        // Get number of each subpage in the page
                        foreach (DigifficeAllnoteEditorFile.SubPage subPage in file.fileSubPages)
                        {
                            if (subPage.parentPage == page)
                            {
                                pageSubPageNumbers += file.fileSubPages.IndexOf(subPage) + 1;
                                if (file.fileSubPages.IndexOf(subPage) != file.fileSubPages.Count - 1)
                                {
                                    pageSubPageNumbers += ", ";
                                }
                            }
                        }
                        pageSubPageNumbers += "]";
                        writer.WriteLine("|PAGESUBPAGES: " + pageSubPageNumbers);
                        writer.WriteLine("\\\\\\");
                    }

                    // Write Structure for SubPages
                    foreach (DigifficeAllnoteEditorFile.SubPage subPage in file.fileSubPages)
                    {
                        writer.WriteLine("");
                        writer.WriteLine("////");
                        writer.WriteLine("|NAME: \"" + subPage.subPageTitle + "\"");
                        writer.WriteLine("|PAGESIZE: [" + subPage.subPageSize.X + ", " + subPage.subPageSize.Y + "]");
                        writer.WriteLine("|CREATEDDATETIME: " + subPage.CreatedDateTime);
                        writer.WriteLine("|NUM: " + subPage.subPageNum);
                        // If subpage has parent page, write parent page number
                        if (subPage.parentPage != null)
                        {
                            writer.WriteLine("|PARENTPAGE: " + (file.filePages.IndexOf(subPage.parentPage) + 1));
                        }
                        else
                        {
                            writer.WriteLine("|PARENTPAGE: -1");
                        }
                        writer.WriteLine("\\\\\\\\");
                    }

                    // Step 3: Write (ELEMENTS) - Includes elements found in pages and subpages

                    writer.WriteLine("");
                    writer.WriteLine("(ELEMENTS)");
                    foreach (DigifficeAllnoteEditorFile.Page page in file.filePages)
                    {
                        // Write elements from page
                        foreach (Panel pnl in page.pageElements.OfType<Panel>())
                        {
                            if (pnl.Tag is not null and (object)"NewPnl_RTB")
                            {
                                RichTextBox rtb = pnl.Controls.OfType<RichTextBox>().FirstOrDefault();
                                if (rtb == null)
                                {
                                    throw new Exception("Intended rtb Panel does not contain a RichTextBox.");
                                }
                                writer.WriteLine("/RICHTEXTBOX");
                                writer.WriteLine("|PARENTPAGENUM: " + page.pageNum);
                                writer.WriteLine("|PARENTPAGENUM: -1"); // RTB is not in subpage, set to -1
                                writer.WriteLine("|PAGEPOS: " + pnl.Location);
                                writer.WriteLine("|SIZE: " + pnl.Size);
                                MessageBox.Show("Saving compressed rtf...");
                                writer.WriteLine("|RTF: " + rtb.Rtf);
                                writer.WriteLine("\\");
                                writer.WriteLine("");
                            }
                        }

                        // Write elements from subpage(s)
                    }
                }

                fs.Close();
            }
        }
    }
}
