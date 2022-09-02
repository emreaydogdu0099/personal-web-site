using System.ComponentModel.DataAnnotations;
using EmreAydogduoglu.Core.Entities.Abstract;

namespace EmreAydogduoglu.Entities.Concrete
{
    public class Category : EntityBase, IEntity
    {
        [Required(ErrorMessage = "Kategori adı boş bırakılmamalıdır.")]
        [MaxLength(50)]
        [MinLength(2,ErrorMessage = "Kategori adı en az 2 karakter olmalıdır.")]
        public string Name { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
