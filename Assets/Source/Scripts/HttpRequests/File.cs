using System;

namespace HTTPRequests
{
    public struct File
    {
        private const int MinNumber = 1;
        
        public File(int number)
        {
            if (number < MinNumber)
            {
                throw new ArgumentOutOfRangeException(
                    $"{nameof(number)} = {number}\n{nameof(MinNumber)} = {MinNumber}");
            }

            Number = number;
        }
        
        public int Number { get; } 
    }
}