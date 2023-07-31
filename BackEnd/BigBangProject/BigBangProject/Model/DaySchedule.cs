using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigBangProject.Model
{
    public class DaySchedule
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey("Package")]
        public int PackageId { get; set; }
        [ForeignKey("SightSeeing")]
        public int SightSeeingId { get; set; } 
        [ForeignKey("Hotel")]
        public int HotelId { get; set; } 
        [ForeignKey("Vehicle")]
        public int VehicleId { get; set; } 
        public int Daywise { get; set; }
    }
}
