namespace UrlParts.Urls
{
    public sealed class TextureUrl : Url
    {
        private const string ImagePath = "https://data.ikppbb.com/test-task-unity-data/pics/";

        public TextureUrl()
            : base(ImagePath)
        {
        }
    }
}