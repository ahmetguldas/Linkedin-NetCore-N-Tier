
using Data.Entities;

namespace Business.IServices
{
    public interface IEducationService
    {
        void AddEducation(Education education);
        void UpdateEducation(Education education);
        void DeleteEducation(int id);
        Education GetEducationById(int id);
        List<Education> GetAllEducation();
        void UpdateEducationImage(string ImageUrl, int id);
    }
}
