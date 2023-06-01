namespace JobberApi.Models
{
    public class VacancyModel
    {
        public string title { get; set; }
        public string location { get; set; }
        public string snippet { get; set; }
        public string salary { get; set; }
        public string source { get; set; }
        public string type { get; set; }
        public string link { get; set; }
        public string company { get; set; }
        public DateTime updated { get; set; }
        public long id { get; set; }
    }
}
