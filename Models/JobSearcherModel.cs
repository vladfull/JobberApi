namespace JobberApi.Models
{
    public class JobSearcherModel
    {
        public int totalCount { get; set; }
        public List<VacancyModel> jobs { get; set; }
        public JobSearcherModel()
        { jobs = new List<VacancyModel>(); }
    }
}
