namespace Core.Entities.User
{
    public class BaseFile
    {
        public System.Guid Id { get; set; }
        public byte[] Data { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public long BaseFieldValueId { get; set; }
        public string InternetMimeType { get; set; }
        public virtual BaseFieldValue BaseFieldValue { get; set; }
    }
}
