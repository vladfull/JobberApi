using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JobberApi.Models
{
    [BsonIgnoreExtraElements]
    public class UserData
    {
        
        public long ChatId { get; set; }
        public string UserName { get; set; }
        public string UserProffesion { get; set; }
        public string UserSalary { get; set; }
        public string UserJobLocation { get; set; }
        //public UserResumeFile UserResumeFile { get; set; }
        //public UserData(byte[] filebytes) 
        //{
        //    UserResumeFile = new UserResumeFile(filebytes);
        //}
    }
}
