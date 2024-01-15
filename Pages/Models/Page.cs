using static System.Collections.Specialized.BitVector32;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Pages.Models
{
    public class Page
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string PageName { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedDate { get; set; }

        public List<Section> Sections { get; set; }
    }
}
