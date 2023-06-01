using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson;

namespace JobberApi.Models
{
    public class UserResumeFile
    {
        public long ChatId { get; set; }
        public string fileName { get; set; }
        public BsonBinaryData fileData { get; set; }
        public UserResumeFile(byte[] filebytes)
        {
            fileData = new BsonBinaryData(filebytes);
            fileName = "resume.pdf";
        }
    }
}
