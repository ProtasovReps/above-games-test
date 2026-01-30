namespace Filtering.Filter
{
    public class AllBlockFilter : BlockFilter
    {
        protected override bool IsValid(int ordinalNumber)
        {
            return true;
        }
    }
}