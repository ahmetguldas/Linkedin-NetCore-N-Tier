using Data.Entities;

namespace Business.IServices
{
    public interface IExperienceService
    {
        void AddExperience(Experience experience);
        void UpdateExperience(Experience experience);
        void DeleteExperience(int id);
        Experience GetExperienceById(int id);
        List<Experience> GetAllExperience();
        void UpdateExperienceImage(string ImageUrl, int id);
    }
}
