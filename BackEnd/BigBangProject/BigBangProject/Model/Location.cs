using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigBangProject.Model
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string LocationName { get; set; } = string.Empty;
        public string? ImageName { get; set; }
        [NotMapped]
        public IFormFile? LocationImage { get; set; }
        [NotMapped]
        public string? ImageSrc { get; set; }
        public ICollection<Hotel>? Hotels { get; set; }
        public ICollection<Package>? Packages { get; set; }
        public ICollection<SightSeeing>? SightSeeings { get; set; }


    }
}
