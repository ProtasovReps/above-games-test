namespace Filtering.Filter
{
    public sealed class OddBlockFilter : BlockFilter
    {
        private const int Devider = 2;
        
        protected override bool IsValid(int ordinalNumber)
        {
            return ordinalNumber % Devider != 0;
        }
    }
}