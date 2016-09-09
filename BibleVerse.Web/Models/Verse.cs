using System;
using System.Collections.Generic;

namespace BibleVerse.Web.Models
{
    public partial class Verse
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string Body { get; set; }
        public string Verse1 { get; set; }
        public virtual Category Category { get; set; }
    }
}
