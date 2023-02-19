using BusinessLayer.Concrete;
using BusinessLayer.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Conrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebNoteSystem.Controllers
{
    public class NotesController : Controller
    {
        NotesManager notesManager = new NotesManager(new EfNotesDal());

        public IActionResult Index()
        {
            var values = notesManager.TGetList();
            return View(values);
        }

        //ekleme
        [HttpGet]
        public IActionResult AddNotes()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNotes(Notes p)
        {
            NotesValidator validationRules = new NotesValidator();
            ValidationResult result = validationRules.Validate(p);
            if (result.IsValid)
            {
                notesManager.TInsert(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        //Silme işlemi için
        public IActionResult DeleteNotes(int id)
        {
            var value = notesManager.GetById(id);
            notesManager.TDelete(value);
            return RedirectToAction("Index");
        }

        //Güncelleme işlemi için

        [HttpGet]
        public IActionResult UpdateNotes(int id)
        {
            var value = notesManager.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateNotes(Notes p)
        {
            notesManager.TUpdate(p);
            return RedirectToAction("Index");
        }

    }
}
