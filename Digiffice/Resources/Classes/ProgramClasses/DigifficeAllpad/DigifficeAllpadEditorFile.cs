using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Digiffice.Resources.Classes.ProgramClasses.DigifficeAllpad
{
    public class DigifficeAllpadEditorFile
    {
        // Header Vars
        public string fileName;
        public List<Page> filePages = new List<Page>();
        public List<Chapter> chapters = new List<Chapter>();
        public struct Page
        {
            public Vector2 pageSize;
            public string pageTitle;
            public DateTime CreatedDateTime;
            public int pageNum;
            List<object> pageElements = new List<object>();
            public Chapter parentChapter;

            public Page()
            {
            }
        }

        public struct SubPage
        {
            public string subPageTitle;
            public List<object> subPageElements = new List<object>();
            public Page parentPage;

            public SubPage()
            {
            }
        }

        public struct Chapter
        {
            public string chapterName;
            public List<Page> chapterPages = new List<Page>();
            public int chapterNum;
            public ChapterGroup parentChapterGroup;

            public Chapter()
            {
            }
        }

        public struct ChapterGroup
        {
            public string chapterGroupName;
            public List<Chapter> groupChapters = new List<Chapter>();
            public int chapterGroupNum;

            public ChapterGroup()
            {
            }
        }
    }
}
