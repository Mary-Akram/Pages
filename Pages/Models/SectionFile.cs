namespace Pages.Models
{
    public class SectionFile
    {
        public int Id { get; set; }
        public string Path { get; set; }

        public int SectionId { get; set; }
        public Section Section { get; set; }
    }
}
