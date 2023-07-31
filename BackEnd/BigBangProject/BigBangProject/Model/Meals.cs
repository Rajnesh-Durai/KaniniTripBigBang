using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigBangProject.Model
{
    public class Meals
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Hotel")]
        public int HotelId { get; set; }
        public string? FoodDescription { get; set; }
        public string? ImageName { get; set; }
        [NotMapped]
        public IFormFile? MealsImage { get; set; }
        [NotMapped]
        public string? ImageSrc { get; set; }
    }
}
