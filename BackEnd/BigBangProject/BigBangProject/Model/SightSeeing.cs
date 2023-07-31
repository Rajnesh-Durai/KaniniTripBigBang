using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigBangProject.Model
{
    public class SightSeeing
    {
        [Key] 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public string? SpotName { get;set; }
        public string? ImageName { get; set; }
        [NotMapped]
        public IFormFile? SpotImage { get; set; }
        [NotMapped]
        public string? ImageSrc { get; set; }
        public int? DurationPerHour { get; set; }
        public ICollection<DaySchedule>? DaySchedules { get; set; }

    }
}
