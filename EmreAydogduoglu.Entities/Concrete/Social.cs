using System.ComponentModel.DataAnnotations;
using EmreAydogduoglu.Core.Entities.Abstract;

namespace EmreAydogduoglu.Entities.Concrete
{
    public class Social : EntityBase, IEntity
    {
        [Required(ErrorMessage = "Icon class'ı boş bırakılmamalıdır.")]
        public string IconName { get; set; }
        [Required(ErrorMessage = "İletişim linki boş bırakılmamalıdır.")]
        [MaxLength(250)]
        public string Link { get; set; }
    }
}
