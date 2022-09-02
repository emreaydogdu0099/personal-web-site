using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmreAydogduoglu.Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;

namespace EmreAydogduoglu.Entities.Concrete
{
    public class Person : EntityBase, IEntity
    {
        [Required(ErrorMessage = "İsim alanı boş bırakılmamalıdır.")]
        [MaxLength(25)]
        [RegularExpression(@"^[a-zA-Z\\ıçşöüğİÇŞÖÜĞ ]+$", ErrorMessage = "Lütfen geçerli bir isim giriniz.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyisim alanı boş bırakılmamalıdır.")]
        [MaxLength(30)]
        [RegularExpression(@"^[a-zA-Z\\ıçşöüğİÇŞÖÜĞ]+$", ErrorMessage = "Lütfen geçerli bir soyisim giriniz.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Adres alanı boş bırakılmamalıdır.")]
        [MaxLength(150)]
        public string Address { get; set; }
        [Required(ErrorMessage = "Email alanı boş bırakılmamalıdır.")]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress,ErrorMessage = "Lütfen geçerli bir email adresi giriniz.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Hakkında alanı boş bırakılmamalıdır.")]
        [MaxLength(1000)]
        public string About { get; set; }
        [Required(ErrorMessage = "Ünvan alanı boş bırakılmamalıdır.")]
        [MaxLength(200)]
        public string Title { get; set; }
        public string? ImageName { get; set; }
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public string? CvName { get; set; }
        [NotMapped]
        public IFormFile? CvFile { get; set; }
    }
}
