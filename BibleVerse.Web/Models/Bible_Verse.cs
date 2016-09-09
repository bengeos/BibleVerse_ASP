using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BibleVerse.Web.Models
{
    public class Bible_Verse
    {
        public List<Category> Categories { get;set;}
        public List<Verse> Verses { get; set; }

    }
}