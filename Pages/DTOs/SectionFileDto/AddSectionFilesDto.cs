namespace Pages.DTOs.SectionFileDto
{
    public class AddSectionFilesDto
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public IFormFile ImageFile { get; set; } 
        public int SectionId { get; set; }

    }
}
