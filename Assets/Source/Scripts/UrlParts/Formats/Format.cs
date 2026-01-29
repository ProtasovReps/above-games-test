namespace UrlParts.Formats
{
    public abstract class Format : StringUrlPart
    {
        protected Format(string type)
            : base(type)
        {
        }
    }
}