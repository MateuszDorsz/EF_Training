
using System.ComponentModel.DataAnnotations;

namespace CodingWiki_Model.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public double Price { get; set; }
    }
}
