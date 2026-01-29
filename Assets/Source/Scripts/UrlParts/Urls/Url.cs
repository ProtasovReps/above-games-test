namespace UrlParts.Urls
{
    public abstract class Url : StringUrlPart
    {
        protected Url(string path)
            : base(path)
        {
        }
    }
}