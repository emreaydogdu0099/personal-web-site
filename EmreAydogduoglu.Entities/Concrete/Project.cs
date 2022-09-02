using System.ComponentModel.DataAnnotations;
using EmreAydogduoglu.Core.Entities.Abstract;

namespace EmreAydogduoglu.Entities.Concrete
{
    public class Project : EntityBase, IEntity
    {
        [Required(ErrorMessage = "Proje adı boş bırakılmamalıdır.")]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Proje açıklaması boş bırakılmamalıdır.")]
        [MaxLength(250)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Proje linki boş bırakılmamalıdır.")]
        [MaxLength(250)]
        public string Link { get; set; }
    }
}
