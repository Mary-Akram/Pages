using Pages.DTOs.SectionsDto;
namespace Pages.DTOs.PagesDto
{
    public class PageDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public List<AllSectionDto> Sections { get;set; }

    }
}
