using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Pages.DTOs.Pages;
using Pages.Services.Interfaces;

namespace Pages.Controllers
{
    public class PagesController : Controller
    {
        private readonly IPagesService service;
        public PagesController(IPagesService _service)
        { 
            this.service = _service;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var allPages = await service.GetPages();

                return View(allPages);
            }catch(Exception ex)
            {
                return null;
            }
        }
        public ActionResult CreateNewPage()
        {
            return View();

        }

        public async Task<ActionResult> ViewDetails(int id)
        {
            var PageDetails=await service.ViewDetail(id);
            TempData["id"] = id;
            return View(PageDetails);
        }

        [HttpPost]
       public async Task<ActionResult> SavePage(AddPagesDto Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("CreateNewPage",Model );
                }

                await service.AddNewPage(Model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
