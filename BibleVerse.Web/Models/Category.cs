using System;
using System.Collections.Generic;

namespace BibleVerse.Web.Models
{
    public partial class Category
    {
        public Category()
        {
            this.Verses = new List<Verse>();
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Verse> Verses { get; set; }
    }
}
