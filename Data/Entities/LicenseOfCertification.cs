using Data.Entities.Common;

namespace Data.Entities
{
    public class LicenseOfCertification : BaseEntity
    {
        public string Name { get; set; }
        public string IssuingOrganization { get; set; }
        public bool ThisCredentialDoesNotExpire { get; set; }
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string CredentialId { get; set; }
        public string CredentialUrl { get; set; }
        public string LicenseOfCertificationImage { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
