using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Pages.Data;
using Pages.DTOs.SectionFileDto;
using Pages.DTOs.SectionsDto;
using Pages.Models;
using Pages.Services.Interfaces;

namespace Pages.Services.Implementation
{
    public class SectionService : ISectionService
    {
        private readonly PagesUDDbContext context  ;
        private readonly IWebHostEnvironment hostingEnvironment;
        public SectionService(PagesUDDbContext _context , IWebHostEnvironment _hostingEnvironment) 
        { 
            this.context = _context ;
            this.hostingEnvironment = _hostingEnvironment ;
            
        }
        public async Task<int> AddNewSection(NewSectionDto newSection,int ?id)
        {
            var section = new Section()
            {
                EnglishDescription = newSection.Description,
                EnglishName = newSection.Title,
                PageId = id.Value
            };
            context.Sections.Add(section);
            await context.SaveChangesAsync();
            return section.Id;
           
        }

        public async Task<EditSectionDto> GetSectionById(int id)
        {

            var SectionDetails = context.Sections
              .Include(x => x.Files.Where(f => f.SectionId == id))
              .FirstOrDefault(x => x.Id == id);

            if (SectionDetails== null)
            {
                return null;
            }

            var Details = new EditSectionDto()
            {
                Id = SectionDetails.Id,
                EnglishTitle = SectionDetails.EnglishName,
                ArabicTitle = SectionDetails.ArabicName,
                EnglishDescription = SectionDetails.EnglishDescription,
                ArabicDescription = SectionDetails.ArabicDescription,
                ImagesPath = SectionDetails.Files.Select(x => x.Path).ToList(),
                InputDate=SectionDetails.Date
               
            };

            return Details;
        }



        public async Task<int> EditSection(EditSectionDto sectionDto,int? Id)
        {
            var SectionDetails = context.Sections
              .Include(x => x.Files.Where(f => f.SectionId == Id))
              .FirstOrDefault(x => x.Id == Id);

            if (SectionDetails == null)
            {
                return 0;
            }

            SectionDetails.EnglishName = sectionDto.EnglishTitle;
            SectionDetails.EnglishDescription = sectionDto.EnglishDescription;
            SectionDetails.ArabicDescription=sectionDto.ArabicDescription;
            SectionDetails.ArabicName = sectionDto.ArabicTitle;
            SectionDetails.Date = sectionDto.InputDate;
            

            context.Update(SectionDetails);
            context.SaveChanges();
            List<AddSectionFilesDto> filesDtos= new List<AddSectionFilesDto>();
            var File = new SectionFile();
            foreach (var image in sectionDto.Images)
            {
                if (image != null || image.Length > 0)
                {
                    AddSectionFilesDto SecFile= new AddSectionFilesDto();
                    var ImagePath = @"Images\Info";
                    var uniqueImageName = Guid.NewGuid().ToString() + '_' + image.FileName;
                    string filePath = Path.Combine(hostingEnvironment.WebRootPath, ImagePath, uniqueImageName);
                    image.CopyTo(new FileStream(filePath, FileMode.Create));
                    SecFile.Path = Path.Combine(ImagePath, uniqueImageName);
                    SecFile.ImageFile = image;
                    filesDtos.Add(SecFile);              

                }             

            }

            var NewFiles = filesDtos.Select(x => new SectionFile()
            {
                Path = x.Path,
                SectionId = Id.Value
            }
              ).ToList();         

            context.Files.AddRange(NewFiles);
            context.SaveChanges();

            return 1;


        }
    }
}
