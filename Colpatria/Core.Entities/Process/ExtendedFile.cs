namespace Core.Entities.Process
{
    public class ExtendedFile
    {
        public System.Guid Id { get; set; }
        public byte[] Data { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public long ExtendedFieldValueId { get; set; }
        public string InternetMimeType { get; set; }
        public virtual ExtendedFieldValue ExtendedFieldValue { get; set; }
    }
}
