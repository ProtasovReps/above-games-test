using System.Text;
using UrlParts;
using UrlParts.Formats;
using UrlParts.Urls;

namespace Source.Scripts
{
    public class UrlBuilder
    {
        private readonly StringBuilder _stringBuilder = new ();

        private Url _url;
        private File _file;
        private Format _format;

        public UrlBuilder SetUrl(Url url)
        {
            _url = url;
            return this;
        }

        public UrlBuilder SetFile(ref File file)
        {
            _file = file;
            return this;
        }

        public UrlBuilder SetFormat(Format format)
        {
            _format = format;
            return this;
        }
        
        public string Build()
        {
            _stringBuilder.Append(_url.Path);
            _stringBuilder.Append(_file.Path);
            _stringBuilder.Append(_format.Path);

            string path = _stringBuilder.ToString();

            _stringBuilder.Clear();
            return path;
        }
    }
}