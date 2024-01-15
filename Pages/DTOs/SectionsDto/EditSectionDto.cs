using Pages.DTOs.SectionFileDto;

namespace Pages.DTOs.SectionsDto
{
    public class EditSectionDto
    {
        public int Id { get; set; }
        public string EnglishTitle { get; set; }
        public string ArabicTitle { get; set; }
        public string EnglishDescription { get; set; }
        public string ArabicDescription { get; set; }
        public DateTime?InputDate { get; set; }
        public List<IFormFile> Images { get; set; }
        public List <string> ImagesPath { get; set; }
        
    }
}
