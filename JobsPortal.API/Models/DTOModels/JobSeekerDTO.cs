using JobsPortal.API.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobsPortal.API.Models.DTOModels
{
    public class JobSeekerDTO
    {
        public int Id { get; set; }
        public UserDTO JobSeekerUser { get; set; }
        [Required]
        public string Qualification { get; set; }
        [Required]
        public string Experience { get; set; }
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public Nullable<DateTime> DateOfBirth { get; set; }
        [Required]
        public JobRole DesiredRole { get; set; }
        public ResumeDTO? Resume { get; set; }
        public List<JobApplicationDTO>? JobApplications { get; set; }

    }
}
