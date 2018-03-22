using System.IO;
using System.Linq;

namespace ASPNETCOREDEMO.Models
{
    public class PhotoSettings
    {
        public int MaxBytes { get; set; }
        public string[] AcceptedFiles { get; set; }

        public bool IsSupportedFile(string fileName) 
        {
            return AcceptedFiles.Any(s => s == Path.GetExtension(fileName).ToLower());
        }
    }
}