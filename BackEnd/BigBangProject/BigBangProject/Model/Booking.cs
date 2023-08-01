using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigBangProject.Model
{
    public class Booking
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "User Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? UserEmail { get; set; }

        [Required(ErrorMessage = "PackageId is required.")]
        [ForeignKey("Package")]
        public int PackageId { get; set; }

        [Required(ErrorMessage = "Start Date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Total Count is required.")]
        [Range(1, 20, ErrorMessage = "Total Count must be a positive value.")]
        public int TotalCount { get; set; }

        [Required(ErrorMessage = "Total Price is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Total Price must be a non-negative value.")]
        public int TotalPrice { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public bool? Status { get; set; }

    }
}
