using System.ComponentModel.DataAnnotations;

namespace Pages.Models
{
    public class Section
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string EnglishName { get; set; }
        public string? ArabicName { get; set; }
        public string ?EnglishDescription { get; set; }

        public string?ArabicDescription { get; set; }

        public DateTime? Date { get; set; }

        public int PageId { get; set; }
        public Page Page { get; set; }

        public List<SectionFile> Files { get; set; }
    }
}
