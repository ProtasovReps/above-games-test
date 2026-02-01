namespace Filtering.Filter
{
    public sealed class AllBlockFilter : BlockFilter
    {
        protected override bool IsValid(int ordinalNumber)
        {
            return true;
        }
    }
}