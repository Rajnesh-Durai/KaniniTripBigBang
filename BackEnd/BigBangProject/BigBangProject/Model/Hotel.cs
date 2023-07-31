using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigBangProject.Model
{
    public class Hotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? HotelName { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public string? ImageName { get; set; }
        [NotMapped]
        public IFormFile? HotelImage { get; set; }
        [NotMapped]
        public string? ImageSrc { get; set; }
        public int Ratings { get; set; }
        public string? BedType { get; set; }
        public string? Features { get; set; }
        public ICollection<DaySchedule>? DaySchedules { get; set; }
        public ICollection<Meals>? Mealss { get; set; }

    }
}
