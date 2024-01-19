using Pages.DTOs.SectionsDto;

namespace Pages.Services.Interfaces
{
    public interface ISectionService
    {
        Task<int> AddNewSection(NewSectionDto newSection,int ?id);
        Task<int> EditSection(EditSectionDto sectionDto,int ? id);
        Task<EditSectionDto> GetSectionById(int id);
        Task<int> DeleteSection(int id);
    }
}
