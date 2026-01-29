using System;
using Interface;

namespace UrlParts
{
    public abstract class StringUrlPart : IUrlPart<string>
    {
        protected StringUrlPart(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException(nameof(path));
            }

            Path = path;
        }
        
        public string Path { get; }
    }
}