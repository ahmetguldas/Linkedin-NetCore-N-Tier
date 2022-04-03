using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.IServices
{
    public interface ILicenseOfCertificationService
    {
        void AddLicenseOfCertification(LicenseOfCertification licenseOfCertification);
        void UpdateLicenseOfCertification(LicenseOfCertification licenseOfCertification);
        void DeleteLicenseOfCertification(int id);
        LicenseOfCertification GetLicenseOfCertificationById(int id);
        List<LicenseOfCertification> GetAllLicenseOfCertification();
        void UpdateLicenseOfCertificationImage(string ImageUrl, int id);
    }
}
