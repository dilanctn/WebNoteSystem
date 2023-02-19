using EntityLayer.Conrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.FluentValidation
{
    public class NotesValidator : AbstractValidator<Notes>
    {
        public NotesValidator()
        {
            RuleFor(x => x.Tıtle).NotEmpty().WithMessage("Başlık adını boş geçemezsiniz");
            RuleFor(x => x.Tıtle).MinimumLength(3).WithMessage("Başlık adı en az 3 krakter olmalıdır");
            RuleFor(x => x.Content).NotEmpty().WithMessage("Not İçeriğini boş geçemezsiniz");
            RuleFor(x => x.Content).MinimumLength(3).WithMessage("İçerik en az 5 krakter olmalıdır");
        }
    }
}
