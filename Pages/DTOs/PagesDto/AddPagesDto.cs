using System.ComponentModel.DataAnnotations;

namespace Pages.DTOs.Pages
{
    public class AddPagesDto
    {
        [Required]
        public string PageName { get; set; }
         
        public string? Description { get; set; }

    }
}
