using Microsoft.EntityFrameworkCore;
using Pages.Data;
using Pages.DTOs.Pages;
using Pages.DTOs.PagesDto;
using Pages.DTOs.SectionsDto;
using Pages.Models;
using Pages.Services.Interfaces;

namespace Pages.Services.Implementation
{
    public class PagesService : IPagesService
    {
        private readonly PagesUDDbContext context;

        public PagesService(PagesUDDbContext _context) 
        {
           context = _context;
        }

        public async Task<int> AddNewPage(AddPagesDto addPage)
        {
            //Add New Page will contain Name and Desc
            var newPage = new Page()
            {
                CreatedDate = DateTime.Now,
                Description = addPage.Description,
                PageName = addPage.PageName

            };
            context.Pages.Add(newPage);
            await context.SaveChangesAsync();
            return newPage.Id;
            
        }

        public async Task<int> DeletePage(int id)
        {
            var Page=context.Pages.Where(p => p.Id==id).FirstOrDefault();
            context.Pages.Remove(Page);
            var result=await context.SaveChangesAsync();
            return result;
        }

        public async Task<List<PagesDto>> GetPages()
        {
            //Tables will contain PageName and created Time
            var allPages = await context.Pages.ToListAsync(); 

            var listOfPages = allPages.Select(x => new PagesDto
            {
                Id = x.Id,
                Name = x.PageName,
                CreatedDate = x.CreatedDate
            }).ToList();

            return listOfPages;
        }

        public async Task<PageDetailsDto> ViewDetail(int id)
        {//Add New Section and Table od sections
         var pageInfo = await context.Pages
                .Include(p => p.Sections) 
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
            if (pageInfo == null)
            {
                return null;
            }

            var PageDetail = new PageDetailsDto
            {
                Id = pageInfo.Id,
                Name= pageInfo.PageName,
                Description = pageInfo.Description, 
                Sections = pageInfo.Sections.Select(s => new AllSectionDto
                {     
                   Id=s.Id, 
                  Name=s.EnglishName,
                   Description=s.EnglishDescription
                  
                }).ToList()
            };

            return PageDetail;

        }
    }
}
