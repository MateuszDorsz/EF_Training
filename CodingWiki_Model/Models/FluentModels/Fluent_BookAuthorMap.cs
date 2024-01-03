using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki_Model.Models.FluentModels
{
    public class Fluent_BookAuthorMap
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public Fluent_Book Book { get; set; }
        public Fluent_Author Author { get; set; }
    }
}
