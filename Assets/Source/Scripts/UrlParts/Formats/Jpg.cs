namespace UrlParts.Formats
{
    public sealed class Jpg : Format
    {
        private const string Extension = ".jpg";

        public Jpg() 
            : base(Extension)
        {
        }
    }
}