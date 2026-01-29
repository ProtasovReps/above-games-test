using System;
using Interface;

namespace UrlParts
{
    public struct File : IUrlPart<int>
    {
        private const int MinNumber = 1;
        
        public File(int number)
        {
            if (number < MinNumber)
            {
                throw new ArgumentOutOfRangeException(
                    $"{nameof(number)} = {number}\n{nameof(MinNumber)} = {MinNumber}");
            }

            Path = number;
        }
        
        public int Path { get; } 
    }
}