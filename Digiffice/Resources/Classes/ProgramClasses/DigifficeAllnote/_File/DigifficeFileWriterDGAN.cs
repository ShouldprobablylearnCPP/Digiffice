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
                        writer.Write("\\\\\\" + Environment.NewLine);
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
                        foreach (DigifficeAllnoteElements.ElementHeader eHeader in page.pageElements)
                        {
                            switch (eHeader.elementType)
                            {
                                case DigifficeAllnoteElements.ElementTypes.RTB:
                                    // Write RTB element
                                    DigifficeAllnoteElements.RTBElement rtbElement = (DigifficeAllnoteElements.RTBElement)eHeader.element;
                                    writer.Write("/RICHTEXTBOX" + Environment.NewLine);
                                    writer.Write("|PARENTPAGENUM: " + page.pageNum + Environment.NewLine);
                                    writer.Write("|PARENTSUBPAGENUM: -1" + Environment.NewLine); // RTB is not in subpage, set to -1
                                    writer.Write("|PAGEPOS: " + rtbElement.location + Environment.NewLine);
                                    writer.Write("|SIZE: " + rtbElement.pnlSize + Environment.NewLine);
                                    writer.Write("|RTF: " + rtbElement.rtf + Environment.NewLine);
                                    writer.Write("\\" + Environment.NewLine);
                                    writer.Write(Environment.NewLine);
                                    break;

                                case DigifficeAllnoteElements.ElementTypes.DraggableSizablePictureBox:
                                    // Write DraggableSizablePicturebox element
                                    DigifficeAllnoteElements.DraggableSizablePictureBoxElement dspElement = (DigifficeAllnoteElements.DraggableSizablePictureBoxElement)eHeader.element;
                                    writer.Write("/DRAGGABLESIZABLEPICTUREBOX" + Environment.NewLine);
                                    writer.Write("|PARENTPAGENUM: " + page.pageNum + Environment.NewLine);
                                    writer.Write("|PARENTSUBPAGENUM: -1" + Environment.NewLine); // DraggableSizablePicturebox is not in subpage, set to -1
                                    writer.Write("|PAGEPOS: " + dspElement.location + Environment.NewLine);
                                    writer.Write("|SIZE: " + dspElement.size + Environment.NewLine);
                                    BitmapEncoder encoder = getFormatFromElementFmt(dspElement.fmt);
                                    string imgFormat = encoder.GetType().Name.Replace("BitmapEncoder", "").ToUpper().Trim();
                                    var bitmapSource = dspElement.image as BitmapSource;
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

                                    writer.Write("|IMGFMT: " + imgFormat + Environment.NewLine);
                                    writer.Write("|IMGSRC: " + Environment.NewLine);

                                    writer.Write(imgBytes.Length);
                                    writer.Write(imgBytes); // Write binary image data directly to the file

                                    writer.Write(Environment.NewLine);

                                    writer.Write("\\" + Environment.NewLine);
                                    writer.Write(Environment.NewLine);
                                    break;
                            }
                        }
                    }

                    // Write elements from subpage(s)
                    foreach (DigifficeAllnoteEditorFile.SubPage subPage in file.fileSubPages)
                    {
                        foreach (DigifficeAllnoteElements.ElementHeader eHeader in subPage.subPageElements)
                        {
                            switch (eHeader.elementType)
                            {
                                case DigifficeAllnoteElements.ElementTypes.RTB:
                                    // Write RTB element
                                    DigifficeAllnoteElements.RTBElement rtbElement = (DigifficeAllnoteElements.RTBElement)eHeader.element;
                                    writer.Write("/RICHTEXTBOX" + Environment.NewLine);
                                    writer.Write("|PARENTPAGENUM: -1" + Environment.NewLine); // RTB is in subpage, set parent page num to -1
                                    writer.Write("|PARENTSUBPAGENUM: " + subPage.subPageNum + Environment.NewLine);
                                    writer.Write("|PAGEPOS: " + rtbElement.location + Environment.NewLine);
                                    writer.Write("|SIZE: " + rtbElement.pnlSize + Environment.NewLine);
                                    writer.Write("|RTF: " + rtbElement.rtf + Environment.NewLine);
                                    writer.Write("\\" + Environment.NewLine);
                                    writer.Write(Environment.NewLine);
                                    break;

                                case DigifficeAllnoteElements.ElementTypes.DraggableSizablePictureBox:
                                    // Write DraggableSizablePicturebox element
                                    DigifficeAllnoteElements.DraggableSizablePictureBoxElement dspElement = (DigifficeAllnoteElements.DraggableSizablePictureBoxElement)eHeader.element;
                                    writer.Write("/DRAGGABLESIZABLEPICTUREBOX" + Environment.NewLine);
                                    writer.Write("|PARENTPAGENUM: -1" + Environment.NewLine); // DraggableSizablePicturebox is in subpage, set parent page num to -1
                                    writer.Write("|PARENTSUBPAGENUM: " + subPage.subPageNum + Environment.NewLine);
                                    writer.Write("|PAGEPOS: " + dspElement.location + Environment.NewLine);
                                    writer.Write("|SIZE: " + dspElement.size + Environment.NewLine);
                                    BitmapEncoder encoder = getFormatFromElementFmt(dspElement.fmt);
                                    string imgFormat = encoder.GetType().Name.Replace("BitmapEncoder", "").ToUpper().Trim();
                                    var bitmapSource = dspElement.image as BitmapSource;
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

                                    writer.Write("|IMGFMT: " + imgFormat + Environment.NewLine);
                                    writer.Write("|IMGSRC: " + Environment.NewLine);
                                    writer.Write(imgBytes.Length);
                                    writer.Write(imgBytes); // Write binary image data directly to the file
                                    writer.Write(Environment.NewLine);
                                    writer.Write("\\" + Environment.NewLine);
                                    writer.Write(Environment.NewLine);
                                    break;
                            }
                        }
                    }

                    // Step 4: Write (EOF) to indicate end of file
                    writer.Write("(EOF)");

                }

                // Close File stream
                fs.Close();
            }
        }

        // Feeder Methods
        public BitmapEncoder getFormatFromElementFmt(string fmt)
        {
            string ext = fmt;

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
