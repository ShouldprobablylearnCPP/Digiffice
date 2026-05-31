using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http.Headers;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms.Integration;
using System.Windows.Media.Imaging;
using Digiffice.Resources.Classes.ProgramClasses.DigifficeAllpad;
using DigifficeWPFControls;
using static Digiffice.Resources.Classes.ProgramClasses.DigifficeAllpad.DigifficeAllnoteEditorFile;
using Control = System.Windows.Forms.Control;
using Panel = System.Windows.Forms.Panel;
using RichTextBox = System.Windows.Forms.RichTextBox;

namespace Digiffice.Resources.Classes.ProgramClasses.DigifficeAllnote._File
{
    public class DigifficeFileReaderDGAN
    {
        // Class Variables
        DigifficeAllnoteEditorFile file = new DigifficeAllnoteEditorFile();

        List<DigifficeAllnoteEditorFile.ChapterGroup> chapterGroups = new List<DigifficeAllnoteEditorFile.ChapterGroup>();
        List<DigifficeAllnoteEditorFile.Chapter> chapters = new List<DigifficeAllnoteEditorFile.Chapter>();
        List<DigifficeAllnoteEditorFile.Page> pages = new List<DigifficeAllnoteEditorFile.Page>();
        List<DigifficeAllnoteEditorFile.SubPage> subPages = new List<DigifficeAllnoteEditorFile.SubPage>();

        List<DigifficeAllnoteEditorFile.Chapter> chaptersToAddToChapterGroups = new List<DigifficeAllnoteEditorFile.Chapter>();
        List<DigifficeAllnoteEditorFile.Page> pagesToAddToChapters = new List<DigifficeAllnoteEditorFile.Page>();
        List<DigifficeAllnoteEditorFile.SubPage> subPagesToAddToPages = new List<DigifficeAllnoteEditorFile.SubPage>();

        public DigifficeAllnoteEditorFile ReadDGANFile(string filePath, Digiffice.DigifficeAllnote digifficeAllnoteForm)
        {
            using (FileStream fs = File.OpenRead(filePath))
            using (BrotliStream bs = new BrotliStream(fs, CompressionMode.Decompress))
            using (BinaryReader br = new BinaryReader(bs))
            {
                // Step 1: Read the file header
                string header = br.ReadString();

                if (header.Trim() != "(HEADER)")
                {
                    throw new Exception("Error loading file. File may be corrupted or in an invalid format.");
                }

                // Step 2: Read the header
                string fileNameLine = br.ReadString().Trim();
                if (!fileNameLine.StartsWith("NAME: \""))
                {
                    throw new Exception("Error loading file. File may be corrupted or in an invalid format.");
                }

                string fileName = fileNameLine.Remove(0, 7).TrimEnd('"'); // Remove the "NAME: " prefix and the trailing quote
                file.fileName = fileName;

                string expectedStrucutreLine = string.Empty;

                // Read empty lines after the header
                bool readingEmptyLines = true;
                while (readingEmptyLines)
                {
                    string line = br.ReadString().Trim();
                    if (line != string.Empty)
                    {
                        expectedStrucutreLine = line; // Store the first non-empty line after the header, which should be the (STRUCTURE) header
                        readingEmptyLines = false;
                    }
                }

                // Step 3: Read (STRUCTURE)
                string structureHeader = expectedStrucutreLine;

                if (structureHeader.Trim() != "(STRUCTURE)")
                {
                    MessageBox.Show(structureHeader);
                    throw new Exception("Error loading file. File may be corrupted or in an invalid format.");
                }

                // Step 4: Read the structure
                bool readingStructure = true;

                while (readingStructure)
                {
                    // Read the next line to determine what type of structure element it is
                    string structureLine = br.ReadString().Trim();

                    switch (structureLine)
                    {
                        case "/":
                            bool readingChapterGroup = true;
                            while (readingChapterGroup)
                            {
                                string chapterGroupLine = br.ReadString().Trim();

                                DigifficeAllnoteEditorFile.ChapterGroup chapterGroup = new DigifficeAllnoteEditorFile.ChapterGroup();

                                // End of chapter group is indicated by a single backslash
                                if (chapterGroupLine == "\\")
                                {
                                    // Add to chapter groups
                                    chapterGroups.Add(chapterGroup);
                                    readingChapterGroup = false;
                                    break;
                                }

                                if (chapterGroupLine.StartsWith("|"))
                                {
                                    // Get property

                                    if (chapterGroupLine.Contains("|NAME: \""))
                                    {
                                        string name = chapterGroupLine.Substring(chapterGroupLine.IndexOf("|NAME: \"") + 8).TrimEnd('"');
                                        chapterGroup.chapterGroupName = name;
                                    }

                                    if (chapterGroupLine.Contains("|NUM: "))
                                    {
                                        // Read the number property - catch any exceptions that may occur during parsing
                                        int num;
                                        try
                                        {
                                            string numStr = chapterGroupLine.Substring(chapterGroupLine.IndexOf("|NUM: ") + 6).TrimEnd('"');
                                            num = int.Parse(numStr);
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show($"Error parsing chapter group number: {ex.Message}");
                                            break;
                                        }

                                        chapterGroup.chapterGroupNum = num;
                                    }

                                    if (chapterGroupLine.Contains("|GROUPCHAPTERS: ["))
                                    {
                                        // Add chapters into the chapter group - catch any exceptions that may occur during parsing
                                        string chaptersStr = chapterGroupLine.Substring(chapterGroupLine.IndexOf("|GROUPCHAPTERS: [") + 17); // Don't remove the trailing ']' so we can check for it in the loop

                                        bool readingChapters = true;
                                        while (readingChapters)
                                        {
                                            if (chaptersStr.Contains("]"))
                                            {
                                                chaptersStr = chaptersStr.Replace("]", ""); // Remove the trailing ']' so we can parse the chapter numbers
                                            }
                                            string chapterNumStr = chaptersStr.Split(", ").FirstOrDefault()?.Trim();
                                            if (int.TryParse(chapterNumStr, out int chapterNum))
                                            {
                                                // Add chapter with number to chapters to add, so the corresponding chapter can be fetched later and added to the chapter group
                                                DigifficeAllnoteEditorFile.Chapter chapterToAdd = new DigifficeAllnoteEditorFile.Chapter { chapterNum = chapterNum };
                                                chaptersToAddToChapterGroups.Add(chapterToAdd);
                                            }
                                            // Remove the parsed chapter number and any leading commas for the next iteration
                                            if (chaptersStr.Contains(", "))
                                            {
                                                chaptersStr = chaptersStr.Substring(chaptersStr.IndexOf(", ") + 2).Trim();
                                            }
                                            else
                                            {
                                                chaptersStr = string.Empty; // No more chapters to parse
                                                readingChapters = false;
                                            }
                                        }

                                    }
                                }

                                // Example: Extract chapter group name and other properties
                            }
                            break;

                        case "//":

                            bool readingChapter = true;

                            DigifficeAllnoteEditorFile.Chapter chapter = new DigifficeAllnoteEditorFile.Chapter();

                            while (readingChapter)
                            {
                                string chapterLine = br.ReadString().Trim();
                                if (chapterLine == "\\\\")
                                {
                                    // Add to chapters
                                    chapters.Add(chapter);
                                    readingChapter = false;
                                    break;
                                }

                                if (chapterLine.StartsWith("|"))
                                {
                                    if (chapterLine.Contains("|NAME: \""))
                                    {
                                        string name = chapterLine.Substring(chapterLine.IndexOf("|NAME: \"") + 8).Trim('"');
                                        chapter.chapterName = name;
                                    }

                                    if (chapterLine.Contains("|NUM: "))
                                    {
                                        string numStr = chapterLine.Substring(chapterLine.IndexOf("|NUM: ") + 6).Trim();
                                        if (int.TryParse(numStr, out int num))
                                        {
                                            chapter.chapterNum = num;
                                        }
                                        else
                                        {
                                            MessageBox.Show($"Error parsing chapter number: {numStr}");
                                            break;
                                        }

                                        chapter.chapterNum = num;
                                    }

                                    if (chapterLine.Contains("|PARENTGROUP: "))
                                    {
                                        // Check for -1 which indicates no parent chapter group
                                        string parentGroupNumStr = chapterLine.Substring(chapterLine.IndexOf("|PARENTGROUP: ") + 14).Trim();

                                        if (int.TryParse(parentGroupNumStr, out int parentGroupNum))
                                        {
                                            if (parentGroupNum != -1)
                                            {
                                                // If a Parent chapter group is found, add to the parent group. This will be updated later. If anything goes wrong later, this will still serve as a backup for when the editor processes the file (Data may be lost in that case).

                                                foreach (DigifficeAllnoteEditorFile.ChapterGroup potentialParentChapterGroup in chapterGroups)
                                                {
                                                    if (potentialParentChapterGroup.chapterGroupNum == parentGroupNum)
                                                    {
                                                        potentialParentChapterGroup.groupChapters.Add(chapter);
                                                        chapter.parentChapterGroup = potentialParentChapterGroup;
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    if (chapterLine.Contains("|CHAPTERPAGES: ["))
                                    {
                                        string pagesStr = chapterLine.Substring(chapterLine.IndexOf("|CHAPTERPAGES: [") + 16); // Don't remove the trailing ']' so we can check for it in the loop

                                        bool readingPages = true;
                                        while (readingPages)
                                        {
                                            if (pagesStr.Contains("]"))
                                            {
                                                pagesStr = pagesStr.Replace("]", ""); // Remove the trailing ']' so we can parse the chapter numbers
                                            }
                                            string pageNumStr = pagesStr.Split(", ").FirstOrDefault()?.Trim();
                                            if (int.TryParse(pageNumStr, out int pageNum))
                                            {
                                                // Add page with number to pages to add, so the corresponding page can be fetched later and added to the chapter
                                                DigifficeAllnoteEditorFile.Page pageToAdd = new DigifficeAllnoteEditorFile.Page { pageNum = pageNum };
                                                pagesToAddToChapters.Add(pageToAdd);
                                            }
                                            // Remove the parsed page number and any leading commas for the next iteration
                                            if (pagesStr.Contains(", "))
                                            {
                                                pagesStr = pagesStr.Substring(pagesStr.IndexOf(", ") + 2).Trim();
                                            }
                                            else
                                            {
                                                pagesStr = string.Empty; // No more pages to parse
                                                readingPages = false;
                                            }
                                        }
                                    }

                                    if (chapterLine.Contains("|RGBCOL: ["))
                                    {
                                        string rgbColStr = chapterLine.Substring(chapterLine.IndexOf("|RGBCOL: [") + 10).Trim();


                                        if (rgbColStr.Contains("]"))
                                        {
                                            // Convert the integer to a Color by parsing the RGB values from the integer. Expected format is [R, G, B]
                                            string rgbValuesStr = rgbColStr.Replace("]", "");
                                            string[] rgbValues = rgbValuesStr.Split(',').Select(s => s.Trim()).ToArray();

                                            if (rgbValues.Length != 3)
                                            {
                                                MessageBox.Show($"Error parsing RGB color: {rgbColStr}");
                                                break;
                                            }

                                            if (!int.TryParse(rgbValues[0], out int r) ||
                                                !int.TryParse(rgbValues[1], out int g) ||
                                                !int.TryParse(rgbValues[2], out int b))
                                            {
                                                MessageBox.Show($"Error parsing RGB color: {rgbColStr}");
                                                break;
                                            }

                                            Color chapterColor = Color.FromArgb(255, r, g, b); // Alpha is always 255 (fully opaque) since the color is stored in RGB format
                                            chapter.chapterCol = chapterColor;
                                            continue;
                                        }
                                        else
                                        {
                                            MessageBox.Show($"Error parsing chapter color: {rgbColStr}");
                                            break;
                                        }
                                    }
                                }
                            }
                            break;

                        case "///":

                            bool readingPage = true;

                            DigifficeAllnoteEditorFile.Page page = new DigifficeAllnoteEditorFile.Page();

                            while (readingPage)
                            {
                                string pageLine = br.ReadString().Trim();
                                if (pageLine == "\\\\\\")
                                {
                                    pages.Add(page); // Will be updated when Elements are added. If anything goes wrong, this will still serve as a backup for when the editor processes the file (Data may be lost in that case).
                                    readingPage = false;
                                    break;
                                }

                                if (pageLine.StartsWith("|"))
                                {
                                    if (pageLine.Contains("|NAME: \""))
                                    {
                                        string name = pageLine.Substring(pageLine.IndexOf("|NAME: \"") + 8).Trim('"');
                                        page.pageTitle = name;
                                    }

                                    if (pageLine.Contains("|PAGESIZE: ["))
                                    {
                                        string pageSizeStr = pageLine.Substring(pageLine.IndexOf("|PAGESIZE: [") + 12).Trim();
                                        bool readingPageSize = true;
                                        while (readingPageSize)
                                        {
                                            if (pageSizeStr.Contains("]"))
                                            {
                                                pageSizeStr = pageSizeStr.Replace("]", ""); // Remove the trailing ']' so we can parse the chapter numbers
                                            }

                                            string pageXStr = pageSizeStr.Split(", ").FirstOrDefault()?.Trim();
                                            string pageYStr = pageSizeStr.Split(", ").Skip(1).FirstOrDefault()?.Trim();

                                            if (float.TryParse(pageXStr, out float pageX) && float.TryParse(pageYStr, out float pageY))
                                            {
                                                page.pageSize = new Vector2(pageX, pageY);
                                                readingPageSize = false;
                                            }
                                            else
                                            {
                                                MessageBox.Show($"Error parsing page size: {pageSizeStr}");
                                                break;
                                            }
                                        }
                                    }

                                    if (pageLine.Contains("|CREATEDDATETIME: "))
                                    {
                                        string dateTimeStr = pageLine.Substring(pageLine.IndexOf("|CREATEDDATETIME: ") + 18).Trim();
                                        if (DateTime.TryParse(dateTimeStr, out DateTime createdDateTime))
                                        {
                                            page.CreatedDateTime = createdDateTime;
                                        }
                                        else
                                        {
                                            MessageBox.Show($"Error parsing page created date and time: {dateTimeStr}");
                                            break;
                                        }
                                    }

                                    if (pageLine.Contains("|NUM: "))
                                    {
                                        string numStr = pageLine.Substring(pageLine.IndexOf("|NUM: ") + 6).Trim();
                                        if (int.TryParse(numStr, out int num))
                                        {
                                            page.pageNum = num;
                                        }
                                        else
                                        {
                                            MessageBox.Show($"Error parsing page number: {numStr}");
                                            break;
                                        }
                                        page.pageNum = num;
                                    }

                                    if (pageLine.Contains("|PARENTCHAPTER: "))
                                    {
                                        // Check for -1 which indicates no parent chapter
                                        string parentChapterNumStr = pageLine.Substring(pageLine.IndexOf("|PARENTCHAPTER: ") + 15).Trim();
                                        if (int.TryParse(parentChapterNumStr, out int parentChapterNum))
                                        {
                                            if (parentChapterNum != -1)
                                            {
                                                // If a Parent chapter is found, add to the parent chapter. This will be updated later. If anything goes wrong later, this will still serve as a backup for when the editor processes the file (Data may be lost in that case).

                                                foreach (DigifficeAllnoteEditorFile.Chapter potentialParentChapter in chapters)
                                                {
                                                    if (potentialParentChapter.chapterNum == parentChapterNum)
                                                    {
                                                        potentialParentChapter.chapterPages.Add(page);
                                                        page.parentChapter = potentialParentChapter;
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    if (pageLine.Contains("|PAGESUBPAGES: ["))
                                    {
                                        string subPagesStr = pageLine.Substring(pageLine.IndexOf("|SUBPAGES: [") + 12); // Don't remove the trailing ']' so we can check for it in the loop
                                        bool readingSubPages = true;
                                        while (readingSubPages)
                                        {
                                            if (subPagesStr.Contains("]"))
                                            {
                                                subPagesStr = subPagesStr.Replace("]", ""); // Remove the trailing ']' so we can parse the chapter numbers
                                            }
                                            string subPageNumStr = subPagesStr.Split(", ").FirstOrDefault()?.Trim();
                                            if (int.TryParse(subPageNumStr, out int subPageNum))
                                            {
                                                // Add subpage with number to subpages to add, so the corresponding subpage can be fetched later and added to the page
                                                DigifficeAllnoteEditorFile.SubPage subPageToAdd = new DigifficeAllnoteEditorFile.SubPage { subPageNum = subPageNum };
                                                subPagesToAddToPages.Add(subPageToAdd);
                                            }
                                            // Remove the parsed subpage number and any leading commas for the next iteration
                                            if (subPagesStr.Contains(", "))
                                            {
                                                subPagesStr = subPagesStr.Substring(subPagesStr.IndexOf(", ") + 2).Trim();
                                            }
                                            else
                                            {
                                                subPagesStr = string.Empty; // No more subpages to parse
                                                readingSubPages = false;
                                            }
                                        }
                                    }
                                }
                            }
                            break;

                        case "////":
                            bool readingSubPage = true;

                            DigifficeAllnoteEditorFile.SubPage subPage = new DigifficeAllnoteEditorFile.SubPage();

                            while (readingSubPage)
                            {
                                string subPageLine = br.ReadString().Trim();
                                if (subPageLine == "\\\\\\\\")
                                {
                                    subPages.Add(subPage); // Will be updated when Elements are added. If anything goes wrong, this will still serve as a backup for when the editor processes the file (Data may be lost in that case).
                                    readingSubPage = false;
                                    continue;
                                }

                                if (subPageLine.StartsWith("|"))
                                {
                                    if (subPageLine.Contains("|NAME: \""))
                                    {
                                        string name = subPageLine.Substring(subPageLine.IndexOf("|NAME: \"") + 8).Trim('"');
                                        // Since subpages don't have a unique property like chapter groups and chapters, we can identify them by their page number, which is unique among subpages. So we can add the subpage to the list of subpages to add, and set its page number, so it can be fetched and added to the correct page later.
                                        subPage.subPageTitle = name;
                                    }

                                    if (subPageLine.Contains("|PAGESIZE: ["))
                                    {
                                        string pageSizeStr = subPageLine.Substring(subPageLine.IndexOf("|PAGESIZE: [") + 12).Trim();
                                        bool readingPageSize = true;
                                        while (readingPageSize)
                                        {
                                            if (pageSizeStr.Contains("]"))
                                            {
                                                pageSizeStr = pageSizeStr.Replace("]", ""); // Remove the trailing ']' so we can parse the chapter numbers
                                            }
                                            string pageXStr = pageSizeStr.Split(", ").FirstOrDefault()?.Trim();
                                            string pageYStr = pageSizeStr.Split(", ").Skip(1).FirstOrDefault()?.Trim();
                                            if (float.TryParse(pageXStr, out float pageX) && float.TryParse(pageYStr, out float pageY))
                                            {
                                                subPage.subPageSize = new Vector2(pageX, pageY);
                                                readingPageSize = false;
                                            }
                                            else
                                            {
                                                MessageBox.Show($"Error parsing subpage size: {pageSizeStr}");
                                                break;
                                            }
                                        }
                                    }

                                    if (subPageLine.Contains("|CREATEDDATETIME: "))
                                    {
                                        string dateTimeStr = subPageLine.Substring(subPageLine.IndexOf("|CREATEDDATETIME: ") + 18).Trim();
                                        if (DateTime.TryParse(dateTimeStr, out DateTime createdDateTime))
                                        {
                                            subPage.CreatedDateTime = createdDateTime;
                                        }
                                    }

                                    if (subPageLine.Contains("|NUM: "))
                                    {
                                        string numStr = subPageLine.Substring(subPageLine.IndexOf("|NUM: ") + 6).Trim();
                                        if (int.TryParse(numStr, out int num))
                                        {
                                            subPage.subPageNum = num;
                                        }
                                        else
                                        {
                                            MessageBox.Show($"Error parsing subpage number: {numStr}");
                                            break;
                                        }
                                    }

                                    if (subPageLine.Contains("|PARENTPAGE: "))
                                    {
                                        string parentPageNumStr = subPageLine.Substring(subPageLine.IndexOf("|PARENTPAGE: ") + 13).Trim();
                                        if (int.TryParse(parentPageNumStr, out int parentPageNum))
                                        {
                                            // If a Parent page is found, add to the parent page. This will be updated later. If anything goes wrong later, this will still serve as a backup for when the editor processes the file (Data may be lost in that case).

                                            foreach (DigifficeAllnoteEditorFile.Page potentialParentPage in pages)
                                            {
                                                if (potentialParentPage.pageNum == parentPageNum)
                                                {
                                                    subPage.parentPage = potentialParentPage;
                                                    break;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show($"Error parsing subpage parent page number: {parentPageNumStr}");
                                            break;
                                        }
                                    }
                                }
                            }
                            break;

                        case "(ELEMENTS)":
                            // Note: if for any reason the file contains no (ELEMENTS) section, the script will loop until the end of the stream, triggering an exception. File Writer always includes an (ELEMENTS) section, so this should only happen if the file has been edited, corrupted, or written incorrectly.
                            readingStructure = false; // End of structure section, break out of the loop to move on to reading elements
                            break;
                    }
                }

                // Step 5: Read (ELEMENTS)

                // If this point is reached, the elements header has been found, so no need to check for it.
                bool readingElements = true;

                while (readingElements)
                {
                    string elementLine = br.ReadString().Trim();

                    DigifficeAllnoteEditorFile.Page parentPageForElement = null;
                    DigifficeAllnoteEditorFile.SubPage parentSubPageForElement = null;

                    switch (elementLine)
                    {
                        case "/RICHTEXTBOX":

                            bool readingRichTextBox = true;

                            Panel rtbParentPnl = new Panel();
                            rtbParentPnl.Tag = "NewPnl_RTB";

                            string rtfContent = string.Empty;

                            while (readingRichTextBox)
                            {
                                string richTextBoxLine = br.ReadString().Trim();

                                if (richTextBoxLine == "\\")
                                {
                                    // End of richtextbox element, break out of the loop to move on to the next element

                                    // Make a default Digiffice ALlnote form so we have access to the default rtbpnl function.
                                    // Make a default rtbPnl and plug in our values. Then add to the page/subpage

                                    Panel rtbpnl = digifficeAllnoteForm.DigifficeAllnote_DefaultRTBPnl(new Control(), false);
                                    rtbpnl.Location = rtbParentPnl.Location;
                                    rtbpnl.Size = rtbParentPnl.Size;
                                    RichTextBox rtb = rtbpnl.Controls.OfType<RichTextBox>().FirstOrDefault();
                                    rtb.Size = new Size(rtbParentPnl.Size.Width - 1, rtbParentPnl.Size.Height - 1);

                                    if (rtb != null)
                                    {
                                        rtb.Rtf = rtfContent;
                                    }

                                    if (parentSubPageForElement != null)
                                    {
                                        parentSubPageForElement.subPageElements.Add(rtbpnl);
                                    }
                                    else if (parentPageForElement != null)
                                    {
                                        parentPageForElement.pageElements.Add(rtbpnl);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error: RichTextBox element found with no parent page or subpage.");
                                    }

                                    readingRichTextBox = false;
                                    break;
                                }

                                if (richTextBoxLine.StartsWith("|"))
                                {
                                    if (richTextBoxLine.Contains("|PARENTPAGENUM: "))
                                    {
                                        // Check for -1 which indicates no parent chapter group
                                        string parentPageNumStr = richTextBoxLine.Substring(richTextBoxLine.IndexOf("|PARENTPAGENUM: ") + 16).Trim();

                                        if (int.TryParse(parentPageNumStr, out int parentPageNum))
                                        {
                                            if (parentPageNum != -1)
                                            {
                                                parentPageForElement = pages.FirstOrDefault(p => p.pageNum == parentPageNum);
                                            }
                                        }
                                    }

                                    if (richTextBoxLine.Contains("|PARENTSUBPAGENUM: "))
                                    {
                                        // Check for -1 which indicates no parent chapter group
                                        string parentSubpageNumStr = richTextBoxLine.Substring(richTextBoxLine.IndexOf("|PARENTSUBPAGENUM: ") + 19).Trim();

                                        if (int.TryParse(parentSubpageNumStr, out int parentSubpageNum))
                                        {
                                            if (parentSubpageNum != -1)
                                            {
                                                parentSubPageForElement = subPages.FirstOrDefault(sp => sp.subPageNum == parentSubpageNum);
                                            }
                                        }
                                    }

                                    if (richTextBoxLine.Contains("|PAGEPOS: "))
                                    {
                                        // Expected format: |PAGEPOS: [X, Y]
                                        string pagePosStr = richTextBoxLine.Substring(richTextBoxLine.IndexOf("|PAGEPOS: {") + 11).Trim();

                                        if (pagePosStr.Contains("}"))
                                        {
                                            pagePosStr = pagePosStr.Replace("}", ""); // Remove the trailing ']' so we can parse the position values
                                        }

                                        string pagePosXStr = pagePosStr.Split(",").FirstOrDefault()?.Trim();
                                        string pagePosYStr = pagePosStr.Split(",").Skip(1).FirstOrDefault()?.Trim();
                                        pagePosXStr = pagePosXStr.Replace("X=", "");
                                        pagePosYStr = pagePosYStr.Replace("Y=", "");

                                        if (float.TryParse(pagePosXStr, out float pagePosX) && float.TryParse(pagePosYStr, out float pagePosY))
                                        {
                                            rtbParentPnl.Location = new Point((int)pagePosX, (int)pagePosY);
                                        }
                                    }

                                    if (richTextBoxLine.Contains("|SIZE: "))
                                    {
                                        // Expected format: |SIZE: [Width, Height]
                                        string pageSizeStr = richTextBoxLine.Substring(richTextBoxLine.IndexOf("|SIZE: {") + 8).Trim();
                                        if (pageSizeStr.Contains("}"))
                                        {
                                            pageSizeStr = pageSizeStr.Replace("}", ""); // Remove the trailing ']' so we can parse the size values
                                        }

                                        string pageSizeXStr = pageSizeStr.Split(",").FirstOrDefault()?.Trim();
                                        string pageSizeYStr = pageSizeStr.Split(",").Skip(1).FirstOrDefault()?.Trim();
                                        pageSizeXStr = pageSizeXStr.Replace("Width=", "");
                                        pageSizeYStr = pageSizeYStr.Replace("Height=", "");

                                        if (float.TryParse(pageSizeXStr, out float pageSizeX) && float.TryParse(pageSizeYStr, out float pageSizeY))
                                        {
                                            rtbParentPnl.Size = new Size((int)pageSizeX, (int)pageSizeY);
                                        }
                                    }

                                    if (richTextBoxLine.Contains("|RTF: "))
                                    {
                                        rtfContent = richTextBoxLine.Substring(richTextBoxLine.IndexOf("|RTF: ") + 6).Trim();
                                        // The rest of the line is the rtfContent
                                    }
                                }
                            }
                            break;

                        case "/DRAGGABLESIZABLEPICTUREBOX":
                            bool readingDraggableSizablePictureBox = true;

                            ElementHost draggableSizablePictureBoxHost = new ElementHost();

                            string imgLenStr = string.Empty;
                            string imgFormat = string.Empty;

                            Point imgLocation = Point.Empty;
                            Size imgSize = Size.Empty;

                            while (readingDraggableSizablePictureBox)
                            {
                                string dspLine = br.ReadString().Trim();

                                if (dspLine == "\\")
                                {
                                    if (parentSubPageForElement != null)
                                    {
                                        parentSubPageForElement.subPageElements.Add(draggableSizablePictureBoxHost);
                                    }
                                    else if (parentPageForElement != null)
                                    {
                                        parentPageForElement.pageElements.Add(draggableSizablePictureBoxHost);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Error: DSP element found with no parent page or subpage.");
                                    }

                                    readingDraggableSizablePictureBox = false;
                                    break;
                                }

                                if (dspLine.StartsWith("|"))
                                {
                                    if (dspLine.Contains("|PARENTPAGENUM: "))
                                    {
                                        // Check for -1 which indicates no parent chapter group
                                        string parentPageNumStr = dspLine.Substring(dspLine.IndexOf("|PARENTPAGENUM: ") + 16).Trim();

                                        if (int.TryParse(parentPageNumStr, out int parentPageNum))
                                        {
                                            if (parentPageNum != -1)
                                            {
                                                parentPageForElement = pages.FirstOrDefault(p => p.pageNum == parentPageNum);
                                            }
                                        }
                                    }

                                    if (dspLine.Contains("|PARENTSUBPAGENUM: "))
                                    {
                                        // Check for -1 which indicates no parent chapter group
                                        string parentSubpageNumStr = dspLine.Substring(dspLine.IndexOf("|PARENTSUBPAGENUM: ") + 19).Trim();

                                        if (int.TryParse(parentSubpageNumStr, out int parentSubpageNum))
                                        {
                                            if (parentSubpageNum != -1)
                                            {
                                                parentSubPageForElement = subPages.FirstOrDefault(sp => sp.subPageNum == parentSubpageNum);
                                            }
                                        }
                                    }

                                    if (dspLine.Contains("|PAGEPOS: "))
                                    {
                                        // Expected format: |PAGEPOS: [X, Y]
                                        string pagePosStr = dspLine.Substring(dspLine.IndexOf("|PAGEPOS: {") + 11).Trim();

                                        if (pagePosStr.Contains("}"))
                                        {
                                            pagePosStr = pagePosStr.Replace("}", ""); // Remove the trailing ']' so we can parse the position values
                                        }

                                        string pagePosXStr = pagePosStr.Split(",").FirstOrDefault()?.Trim();
                                        string pagePosYStr = pagePosStr.Split(",").Skip(1).FirstOrDefault()?.Trim();
                                        pagePosXStr = pagePosXStr.Replace("X=", "");
                                        pagePosYStr = pagePosYStr.Replace("Y=", "");

                                        if (float.TryParse(pagePosXStr, out float pagePosX) && float.TryParse(pagePosYStr, out float pagePosY))
                                        {
                                            imgLocation = new Point((int)pagePosX, (int)pagePosY);
                                        }
                                    }

                                    if (dspLine.Contains("|SIZE: "))
                                    {
                                        // Expected format: |SIZE: [Width, Height]
                                        string pageSizeStr = dspLine.Substring(dspLine.IndexOf("|SIZE: {") + 8).Trim();
                                        if (pageSizeStr.Contains("}"))
                                        {
                                            pageSizeStr = pageSizeStr.Replace("}", ""); // Remove the trailing ']' so we can parse the size values
                                        }

                                        string pageSizeXStr = pageSizeStr.Split(",").FirstOrDefault()?.Trim();
                                        string pageSizeYStr = pageSizeStr.Split(",").Skip(1).FirstOrDefault()?.Trim();
                                        pageSizeXStr = pageSizeXStr.Replace("Width=", "");
                                        pageSizeYStr = pageSizeYStr.Replace("Height=", "");

                                        if (float.TryParse(pageSizeXStr, out float pageSizeX) && float.TryParse(pageSizeYStr, out float pageSizeY))
                                        {
                                            imgSize = new Size((int)pageSizeX, (int)pageSizeY);
                                        }
                                    }

                                    if (dspLine.Contains("|IMGFMT: "))
                                    {
                                        imgFormat = dspLine.Substring(dspLine.IndexOf("|IMGFMT: ") + 9).Trim().ToLower();
                                    }

                                    if (dspLine.Contains("|IMGSRC:"))
                                    {
                                        int imgBytesLen = br.ReadInt32();
                                        byte[] imgBytes = br.ReadBytes(imgBytesLen);

                                        using (MemoryStream ms = new MemoryStream(imgBytes))
                                        {
                                            System.Windows.Controls.Image img = new System.Windows.Controls.Image();

                                            BitmapSource bitmapSource = null;
                                            try
                                            {
                                                BitmapImage bitmapImage = new BitmapImage();
                                                bitmapImage.BeginInit();
                                                bitmapImage.CacheOption = BitmapCacheOption.OnLoad; // Ensure the stream can be closed after loading the image
                                                bitmapImage.StreamSource = ms;
                                                bitmapImage.EndInit();
                                                bitmapImage.Freeze(); // Freeze the BitmapImage for cross-thread operations
                                                bitmapSource = bitmapImage;
                                            }
                                            catch (Exception ex)
                                            {
                                                MessageBox.Show($"Error loading image: {ex.Message}");
                                            }

                                            draggableSizablePictureBoxHost = digifficeAllnoteForm.DigifficeAllnote_DefaultDraggableSizablePictureBox(imgFormat, bitmapSource, false);
                                            draggableSizablePictureBoxHost.Location = imgLocation;
                                            draggableSizablePictureBoxHost.Size = imgSize;
                                        }
                                    }
                                }
                            }

                            break;

                        case "(EOF)":
                            readingElements = false; // End of elements section, break out of the loop to finish processing the file
                            break;
                    }
                }
            }

            foreach (DigifficeAllnoteEditorFile.Chapter chapter in chapters)
            {
                DigifficeAllnoteEditorFile.Chapter comparitive = new DigifficeAllnoteEditorFile.Chapter { chapterNum = chapter.chapterNum };

                // Compare chapter num to chapter nums in chaptersToAddToChapterGroups
                if (chaptersToAddToChapterGroups.Contains(comparitive))
                {
                    // Add chapter to the corresponding chapter group
                    foreach (DigifficeAllnoteEditorFile.ChapterGroup chapterGroup in chapterGroups)
                    {
                        if (comparitive.parentChapterGroup == chapterGroup)
                        {
                            chapterGroup.groupChapters.Add(chapter);
                            chapter.parentChapterGroup = chapterGroup;
                            break;
                        }
                    }
                }
            }

            foreach (DigifficeAllnoteEditorFile.Page page in pages)
            {
                DigifficeAllnoteEditorFile.Page comparitive = new DigifficeAllnoteEditorFile.Page { pageNum = page.pageNum };
                // Compare page num to page nums in pagesToAddToChapters
                if (pagesToAddToChapters.Contains(comparitive))
                {
                    // Add page to the corresponding chapter
                    foreach (DigifficeAllnoteEditorFile.Chapter chapter in chapters)
                    {
                        if (comparitive.parentChapter == chapter)
                        {
                            chapter.chapterPages.Add(page);
                            page.parentChapter = chapter;
                            break;
                        }
                    }
                }
            }

            foreach (DigifficeAllnoteEditorFile.SubPage subPage in subPages)
            {
                DigifficeAllnoteEditorFile.SubPage comparitive = new DigifficeAllnoteEditorFile.SubPage { subPageNum = subPage.subPageNum };
                // Compare subpage num to subpage nums in subpagesToAddToPages
                if (subPagesToAddToPages.Contains(comparitive))
                {
                    // Add subpage to the corresponding page
                    foreach (DigifficeAllnoteEditorFile.Page page in pages)
                    {
                        if (comparitive.parentPage == page)
                        {
                            page.pageElements.Add(subPage);
                            subPage.parentPage = page;
                            break;
                        }
                    }
                }
            }

            // Add the parsed chapter groups, chapters, pages, and subpages to the file list
            file.ChapterGroups = chapterGroups;
            file.chapters = chapters;
            file.filePages = pages;
            file.fileSubPages = subPages;

            return file;
        }
    }
}
