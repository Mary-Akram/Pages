using Microsoft.AspNetCore.Mvc;
using Pages.DTOs.SectionsDto;
using Pages.Services.Interfaces;

namespace Pages.Controllers
{
    public class SectionController : Controller
    {
       private readonly ISectionService service;

        public SectionController(ISectionService _service)
        {
            service = _service;

        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> ViewSection(int id)
        {
            try
            {
                TempData["Secid"] = id;
                var Result =await service.GetSectionById(id);
                return View(Result);

            }catch(Exception ex)
            {
                return View("_CustomError");
            }
        }
        public IActionResult CreateNewSection()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SaveSection(NewSectionDto sectionDto)
        {
            try
            {
                int? id = TempData["id"] as int?;
                var Result=await service.AddNewSection(sectionDto, id);
                return RedirectToAction("ViewDetails", "Pages", new { id = id });
            }
            catch(Exception ex)
            {
                return View("_CustomError");


            }

        }

        [HttpPost]
        public async Task<IActionResult> UpdateSection(EditSectionDto sectionDto)
        {
            try
            {
                int? secid = TempData["Secid"] as int?;
                int? id = TempData["id"] as int?;
                var Result = await service.EditSection(sectionDto, secid);
                if(Result == 0)
                {
                    return View("_CustomError");


                }
                return RedirectToAction("ViewDetails", "Pages", new { id = id });
            }
            catch (Exception ex)
            {
                return View("_CustomError");


            }

        }
        
        public async Task<ActionResult> DeleteSection(int id)
        {
            try
            {
                int? Pageid = TempData["id"] as int?;
                await service.DeleteSection(id);
                return RedirectToAction("ViewDetails", "Pages", new { id = Pageid });
            }
            catch (Exception ex)
            {
                return View("_CustomError");


            }
        }
    }
}
