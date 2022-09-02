using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EmreAydogduoglu.Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;

namespace EmreAydogduoglu.Entities.Concrete
{
    public class Article : EntityBase, IEntity
    {
        [Required(ErrorMessage = "Makale başlığı boş bırakılmamalıdır.")]
        [MaxLength(150)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Makale içeriği boş bırakılmamalıdır.")]
        public string Content { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string? ThumbnailName { get; set; }
        [NotMapped]
        public IFormFile? ThumbnailFile { get; set; }
        [Required(ErrorMessage = "Kategori seçiniz.")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
