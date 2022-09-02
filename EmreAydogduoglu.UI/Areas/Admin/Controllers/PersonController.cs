using EmreAydogduoglu.Business.Abstract;
using EmreAydogduoglu.Entities.Concrete;
using EmreAydogduoglu.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmreAydogduoglu.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class PersonController : Controller
    {
        private readonly IPersonService _personService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PersonController(IPersonService personService, IWebHostEnvironment webHostEnvironment)
        {
            _personService = personService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            PersonViewModel model = new PersonViewModel
            {
                Person = _personService.GetPerson(1)
            };
            return View(model);
        }

        public IActionResult Update(int id=1)
        {
            PersonViewModel model = new PersonViewModel
            {
                Person = _personService.GetPerson(id)
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Person person, IFormFile? file, IFormFile? file2)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file == null)
                {
                    person.ImageName = _personService.GetPerson(1).ImageName;
                }
                else
                {
                    string fileName = "profile";
                    string uploads = Path.Combine(wwwRootPath, @"assets\img\person");
                    string extension = Path.GetExtension(file.FileName);

                    if (person.ImageFile != null)
                    {
                        if (person.ImageName != null)
                        {
                            string oldImage = Path.Combine(wwwRootPath, person.ImageName.TrimStart('\\'));
                            if (System.IO.File.Exists(oldImage))
                            {
                                System.IO.File.Delete(oldImage);
                            }
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }

                    person.ImageName = fileName + extension;
                }
                if (file2 == null)
                {
                    person.CvName = _personService.GetPerson(1).CvName;
                }
                else
                {
                    string file2Name = "cv";
                    string uploads2 = Path.Combine(wwwRootPath, @"assets\cv");
                    string extension2 = Path.GetExtension(file2.FileName);

                    if (person.CvFile != null)
                    {
                        if (person.CvName != null)
                        {
                            string oldCv = Path.Combine(wwwRootPath, person.CvName.TrimStart('\\'));
                            if (System.IO.File.Exists(oldCv))
                            {
                                System.IO.File.Delete(oldCv);
                            }
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads2, file2Name + extension2), FileMode.Create))
                    {
                        file2.CopyTo(fileStreams);
                    }

                    person.CvName = file2Name + extension2;
                }
                _personService.Update(person);
                TempData["success"] = "Kişi bilgileri başarıyla güncellendi.";
                return RedirectToAction("Index", "Person", new { area = "Admin" });
            }
            TempData["success"] = "Bir hata oluştu!";
            return View();
        }
    }
}
