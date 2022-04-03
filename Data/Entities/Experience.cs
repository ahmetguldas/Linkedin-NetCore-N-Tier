using Data.Entities.Common;

namespace Data.Entities
{
    public class Experience : BaseEntity
    {
        public string Title { get; set; }
        public string EmploymentType { get; set; }
        public string CompanyName { get; set; }
        public string Location { get; set; }
        public bool CurrentlyWorking { get; set; }
        public int MyProperty { get; set; }
        public DateTime StartDate { get; set; }
        public string EndDate { get; set; }
        public string Headline { get; set; }
        public string Industry { get; set; }
        public string Description { get; set; }
        public string MediaUrl { get; set; }
        public User User { get; set; }

        public int UserId { get; set; }



    }
}
