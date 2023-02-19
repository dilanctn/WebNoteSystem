using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NoteApi.DataAccessLayer
{
    public class NotesEntities
    {
        [Key]
        public int ID { get; set; }
        public string Tıtle { get; set; }
        public string Content { get; set; }
    }
}
