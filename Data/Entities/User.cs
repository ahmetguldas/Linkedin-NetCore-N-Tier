using Data.Entities.Common;

namespace Data.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ProfileImage { get; set; }
        public string Title { get; set; }
        public string Sector { get; set; }
        public string Education { get; set; }
        public string Location { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public ICollection<Education> Educations { get; set; }
        public ICollection<Experience> Experiences { get; set; }
        public ICollection<LicenseOfCertification> LicenseOfCertifications { get; set; }



    }
}
