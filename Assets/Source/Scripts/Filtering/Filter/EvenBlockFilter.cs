namespace Filtering.Filter
{
    public class EvenBlockFilter : BlockFilter
    {
        private const int Devider = 2;
        
        protected override bool IsValid(int ordinalNumber)
        {
            return ordinalNumber % Devider == 0;
        }
    }
}