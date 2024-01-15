using Pages.DTOs.Pages;
using Pages.DTOs.PagesDto;
using System.Collections.Generic;

namespace Pages.Services.Interfaces
{
    public interface IPagesService
    {
        Task< List<PagesDto>> GetPages();
        Task<int> AddNewPage(AddPagesDto addPage);
        Task <PageDetailsDto> ViewDetail(int id);
        Task<int> DeletePage(int id);

       //Task <int> EditPage(int id);
    }
}
