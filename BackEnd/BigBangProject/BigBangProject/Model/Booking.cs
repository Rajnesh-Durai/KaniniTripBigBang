using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigBangProject.Model
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? UserEmail { get; set; }
        [ForeignKey("Package")]
        public int PackageId { get; set; }
        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime EndDate { get; set; }
        public int TotalCount { get; set; }
        public int TotalPrice { get; set; }
        public int? PersonLimit { get; set; }
        public ICollection<Transaction>? Transactions { get; set; }

    }
}
