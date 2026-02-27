using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Digiffice.Resources.Classes.ProgramClasses.DigifficeAllpad
{
    public class DigifficeAllnoteEditorFile
    {
        // Header Vars
        public string fileName;

        // Structure Vars
        public List<ChapterGroup> ChapterGroups = new List<ChapterGroup>();
        public List<Chapter> chapters = new List<Chapter>();
        public List<Page> filePages = new List<Page>();
        public List<SubPage> fileSubPages = new List<SubPage>();
        public class Page
        {
            public Vector2 pageSize { get; set; }
            public string pageTitle { get; set; }
            public DateTime CreatedDateTime { get; set; } = DateTime.Now;
            public int pageNum { get; set; } = -1;
            public List<object> pageElements { get; set; } = new List<object>();
            public Chapter parentChapter { get; set; }

            public Page()
            {
            }
        }

        public class SubPage
        {
            public Vector2 subPageSize { get; set; }
            public string subPageTitle { get; set; }
            public DateTime CreatedDateTime { get; set; } = DateTime.Now;
            public int subPageNum { get; set; } = -1;
            public List<object> subPageElements { get; set; } = new List<object>();
            public Page parentPage { get; set; }

            public SubPage()
            {
            }
        }

        public class Chapter
        {
            public string chapterName { get; set; }
            public List<Page> chapterPages { get; set; } = new List<Page>();
            public int chapterNum { get; set; } = -1;
            public ChapterGroup? parentChapterGroup { get; set; }
            public Color chapterCol { get; set; }

            public Chapter()
            {
            }
        }

        public class ChapterGroup
        {
            public string chapterGroupName { get; set; }
            public List<Chapter> groupChapters { get; set; } = new List<Chapter>();
            public int chapterGroupNum { get; set; } = -1;

            public ChapterGroup()
            {
            }
        }
    }
}
