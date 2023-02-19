using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Conrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class NotesManager : INotesService
    {
        INotesDal _notesDal;

        public NotesManager(INotesDal notesDal)
        {
            _notesDal = notesDal;
        }

        public Notes GetById(int id)
        {
            return _notesDal.GetById(id);
        }

        public void TDelete(Notes t)
        {
            _notesDal.Delete(t);
        }

        public List<Notes> TGetList()
        {
            return _notesDal.GetList();
        }

        public void TInsert(Notes t)
        {
            _notesDal.Insert(t);
        }

        public void TUpdate(Notes t)
        {
            _notesDal.Update(t);
        }
    }
}
