using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.Integration;
using System.Windows.Media.Imaging;
using Digiffice.Resources.Classes.ProgramClasses.DigifficeAllpad;
using DigifficeWPFControls;

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
                using (BinaryWriter writer = new BinaryWriter(brotli, Encoding.UTF8, leaveOpen: true))
                {
                    // Step 1: Write (HEADER) - File name
                    writer.Write("(HEADER)" + Environment.NewLine);
                    writer.Write("NAME: \"" + file.fileName + "\"" + Environment.NewLine);
                    writer.Write(Environment.NewLine);

                    // Step 2: Write (STRUCTURE) - includes Chapter groups, Chapters, Pages, and SubPages. This section must only define the properties of each element and their relationships, but not the contents.
                    // Note: The order is: / = Chapter Group, // = Chapter, /// = Page, //// = SubPage
                    writer.Write("(STRUCTURE)" + Environment.NewLine);
                    // Write Structure for Chapter groups
                    foreach (DigifficeAllnoteEditorFile.ChapterGroup chapterGroup in file.ChapterGroups)
                    {
                        writer.Write(Environment.NewLine);
                        writer.Write("/");
                        writer.Write("|NAME: \"" + chapterGroup.chapterGroupName + "\"" + Environment.NewLine);
                        writer.Write("|NUM: " + chapterGroup.chapterGroupNum + Environment.NewLine);

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
                        writer.Write("|GROUPCHAPTERS: " + chapterGroupChapterNumbers + Environment.NewLine);
                        writer.Write("\\" + Environment.NewLine);
                    }

                    // Write Structure for Chapters
                    foreach (DigifficeAllnoteEditorFile.Chapter chapter in file.chapters)
                    {
                        writer.Write(Environment.NewLine);
                        writer.Write("//" + Environment.NewLine);
                        writer.Write("|NAME: \"" + chapter.chapterName + "\"" + Environment.NewLine);
                        writer.Write("|NUM: " + chapter.chapterNum + Environment.NewLine);

                        // If chapter has parent chapter group, write parent chapter group number
                        if (chapter.parentChapterGroup != null)
                        {
                            writer.Write("|PARENTGROUP: " + (file.ChapterGroups.IndexOf(chapter.parentChapterGroup) + 1) + Environment.NewLine);
                        }
                        else
                        {
                            writer.Write("|PARENTGROUP: -1" + Environment.NewLine);
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
                        writer.Write("|CHAPTERPAGES: " + chapterPageNumbers + Environment.NewLine);

                        // Add Chapter col information
                        string chapterColor = "[";
                        chapterColor += chapter.chapterCol.R + ", " + chapter.chapterCol.G + ", " + chapter.chapterCol.B;
                        chapterColor += "]";
                        writer.Write("|RGBCOL: " + chapterColor + Environment.NewLine);
                        writer.Write("\\\\" + Environment.NewLine);
                    }

                    // Write Structure for Pages
                    foreach (DigifficeAllnoteEditorFile.Page page in file.filePages)
                    {
                        writer.Write(Environment.NewLine);
                        writer.Write("///" + Environment.NewLine);
                        writer.Write("|NAME: \"" + page.pageTitle + "\"" + Environment.NewLine);
                        writer.Write("|PAGESIZE: [" + page.pageSize.X + ", " + page.pageSize.Y + "]" + Environment.NewLine);
                        writer.Write("|CREATEDDATETIME: " + page.CreatedDateTime + Environment.NewLine);
                        writer.Write("|NUM: " + page.pageNum + Environment.NewLine);
                        // If page has parent chapter, write parent chapter number
                        if (page.parentChapter != null)
                        {
                            writer.Write("|PARENTCHAPTER: " + (file.chapters.IndexOf(page.parentChapter) + 1) + Environment.NewLine);
                        }
                        else
                        {
                            writer.Write("|PARENTCHAPTER: -1" + Environment.NewLine);
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
                        writer.Write("|PAGESUBPAGES: " + pageSubPageNumbers + Environment.NewLine);
                        writer.Write("\\\\\\\\" + Environment.NewLine);
                    }

                    // Write Structure for SubPages
                    foreach (DigifficeAllnoteEditorFile.SubPage subPage in file.fileSubPages)
                    {
                        writer.Write(Environment.NewLine);
                        writer.Write("////" + Environment.NewLine);
                        writer.Write("|NAME: \"" + subPage.subPageTitle + "\"" + Environment.NewLine);
                        writer.Write("|PAGESIZE: [" + subPage.subPageSize.X + ", " + subPage.subPageSize.Y + "]" + Environment.NewLine);
                        writer.Write("|CREATEDDATETIME: " + subPage.CreatedDateTime + Environment.NewLine);
                        writer.Write("|NUM: " + subPage.subPageNum + Environment.NewLine);
                        // If subpage has parent page, write parent page number
                        if (subPage.parentPage != null)
                        {
                            writer.Write("|PARENTPAGE: " + (file.filePages.IndexOf(subPage.parentPage) + 1) + Environment.NewLine);
                        }
                        else
                        {
                            writer.Write("|PARENTPAGE: -1" + Environment.NewLine);
                        }
                        writer.Write("\\\\\\\\" + Environment.NewLine);
                    }

                    // Step 3: Write (ELEMENTS) - Includes elements found in pages and subpages

                    writer.Write(Environment.NewLine);
                    writer.Write("(ELEMENTS)" + Environment.NewLine);
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
                                writer.Write("/RICHTEXTBOX" + Environment.NewLine);
                                writer.Write("|PARENTPAGENUM: " + page.pageNum + Environment.NewLine);
                                writer.Write("|PARENTSUBPAGENUM: -1" + Environment.NewLine); // RTB is not in subpage, set to -1
                                writer.Write("|PAGEPOS: " + pnl.Location + Environment.NewLine);
                                writer.Write("|SIZE: " + pnl.Size + Environment.NewLine);
                                writer.Write("|RTF: " + rtb.Rtf + Environment.NewLine);
                                writer.Write("\\" + Environment.NewLine);
                                writer.Write(Environment.NewLine);
                            }
                        }

                        // Elementhosts
                        foreach (ElementHost item in page.pageElements.OfType<ElementHost>())
                        {
                            // Write based on type of elementhost child control
                            if (item.Child is DraggableSizablePicturebox dsp)
                            {
                                writer.Write("/DRAGGABLESIZABLEPICTUREBOX" + Environment.NewLine);
                                writer.Write("|PARENTPAGENUM: " + page.pageNum + Environment.NewLine);
                                writer.Write("|PARENTSUBPAGENUM: -1" + Environment.NewLine); // DraggableSizablePicturebox is not in subpage, set to -1
                                writer.Write("|PAGEPOS: " + item.Location + Environment.NewLine);
                                writer.Write("|SIZE: " + item.Size + Environment.NewLine);

                                BitmapEncoder encoder = getFormatFromImageSource(dsp);
                                string imgFormat = encoder.GetType().Name.Replace("BitmapEncoder", "").ToUpper();

                                var bitmapSource = dsp.baseImg.Source as BitmapSource;
                                if (bitmapSource != null)
                                {
                                    encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
                                }
                                else
                                {
                                    throw new Exception("Unable to get BitmapSource from DraggableSizablePicturebox image.");
                                }

                                byte[] imgBytes;
                                using (MemoryStream ms = new MemoryStream())
                                {
                                    encoder.Save(ms);
                                    imgBytes = ms.ToArray();
                                }

                                writer.Write("|IMGLEN: " + imgBytes.Length + Environment.NewLine);
                                writer.Write("|IMGFMT: " + imgFormat + Environment.NewLine);
                                writer.Write("|IMGSRC: ".ToCharArray());

                                writer.Flush(); // Ensure all text data is written before writing binary data

                                writer.Write(imgBytes); // Write binary image data directly to the file

                                writer.Flush(); // Ensure all binary data is written

                                writer.Write(Environment.NewLine.ToCharArray());

                                writer.Write("\\" + Environment.NewLine);
                                writer.Write(Environment.NewLine);
                            }
                        }
                    }

                    // Write elements from subpage(s)
                }

                // Close File stream
                fs.Close();
            }
        }

        // Feeder Methods
        public BitmapEncoder getFormatFromImageSource(DraggableSizablePicturebox dsp)
        {
            string ext = dsp.Tag as string;

            if (ext == ".png")
            {
                return new PngBitmapEncoder();
            }
            else if (ext == ".jpg" || ext == ".jpeg")
            {
                return new JpegBitmapEncoder();
            }
            else if (ext == ".bmp")
            {
                return new BmpBitmapEncoder();
            }
            else if (ext == ".gif")
            {
                return new GifBitmapEncoder();
            }
            else if (ext == ".tiff" || ext == ".tif")
            {
                return new TiffBitmapEncoder();
            }
            else if (ext == ".wmp")
            {
                return new WmpBitmapEncoder();
            }

            return new PngBitmapEncoder(); // Default to PNG if format cannot be determined
        }
    }
}
