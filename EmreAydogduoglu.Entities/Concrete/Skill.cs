using System.ComponentModel.DataAnnotations;
using EmreAydogduoglu.Core.Entities.Abstract;

namespace EmreAydogduoglu.Entities.Concrete
{
    public class Skill : EntityBase, IEntity
    {
        [Required(ErrorMessage = "Beceri İsmi boş bırakılmamalıdır.")]
        [MinLength(1,ErrorMessage = "Beceri İsmi en az 2 karakter olmalıdır.")]
        [MaxLength(100)]
        [RegularExpression(@"^[a-zA-Z0-9\\#. ]+$", ErrorMessage = "Beceri İsmi özel karakterler içermemelidir.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Beceri Puanı boş bırakılmamalıdır.")]
        [Range(0,100,ErrorMessage = "Beceri Puanı 0 ile 100 arasında olmalıdır.")]
        public int Point { get; set; }
    }
}
