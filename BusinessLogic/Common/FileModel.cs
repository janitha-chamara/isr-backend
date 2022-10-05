namespace Infrastructure.Core.Models.Common
{
    public class FileModel
    {
        public string FileName { get; set; }

        public byte[] FileContents { get; set; }

        public string MimeType { get; set; }
    }
}
