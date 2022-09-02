using System.ComponentModel.DataAnnotations;
using EmreAydogduoglu.Core.Entities.Abstract;

namespace EmreAydogduoglu.Entities.Concrete
{
    public class Education : EntityBase, IEntity
    {
        [Required(ErrorMessage = "Eğitim ismi boş bırakılmamalıdır.")]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Fakülte ismi boş bırakılmamalıdır.")]
        [MaxLength(150)]
        public string FacultyName { get; set; }
        [Required(ErrorMessage = "Bölüm adı boş bırakılmamalıdır.")]
        [MaxLength(150)]
        public string DepartmanName { get; set; }
        [Required(ErrorMessage = "Başlangıç tarihi boş bırakılmamalıdır.")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Bitiş tarihi boş bırakılmamalıdır.")]
        public DateTime FinishDate { get; set; }
    }
}
