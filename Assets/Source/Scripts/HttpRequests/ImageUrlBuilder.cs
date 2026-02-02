using System.Text;

namespace HTTPRequests
{
    public sealed class ImageUrlBuilder
    {
        private const string Path = "https://data.ikppbb.com/test-task-unity-data/pics/";
        private const string Format = ".jpg";
        
        private readonly StringBuilder _stringBuilder = new ();

        private int _fileNumber;

        public void SetFile(ref File file)
        {
            _fileNumber = file.Number;
        }

        public string Get()
        {
            _stringBuilder.Append(Path);
            _stringBuilder.Append(_fileNumber);
            _stringBuilder.Append(Format);

            string path = _stringBuilder.ToString();

            _stringBuilder.Clear();
            return path;
        }
    }
}