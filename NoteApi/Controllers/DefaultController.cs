using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoteApi.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        //listeleme
        [HttpGet]
        public IActionResult NotesList()
        {
            using var c = new Context();
            var values = c.Notes.ToList();
            return Ok(values);//istek başarılı ise 200 kodu döndürür
        }

        //ekleme
        [HttpPost]
        public IActionResult NotesAdd(NotesEntities notes)
        {
            using var c = new Context();
            c.Add(notes);
            c.SaveChanges();
            return Ok();
        }

        //veri getirme
        [HttpGet("{id}")]
        public IActionResult NotesGet(int id)
        {
            using var c = new Context();
            var note = c.Notes.Find(id);
            if (note == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(note);
            }
        } 

        //veri silme
        [HttpDelete("{id}")]
        public IActionResult NotesDelete(int id)
        {
            using var c = new Context();
            var note = c.Notes.Find(id);
            if (note==null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(note);
                c.SaveChanges();
                return Ok();
            }
        }

        //veri güncelleme
        [HttpPut]
        public IActionResult NotesUpdate(NotesEntities notes)
        {
            using var c = new Context();
            var note = c.Find<NotesEntities>(notes.ID);
            if (note==null)
            {
                return NotFound();
            }
            else
            {
                note.Content = notes.Content ;
                note.Tıtle = notes.Tıtle;
                c.Update(note);
                c.SaveChanges();
                return Ok();
            }
        }
    }
}
