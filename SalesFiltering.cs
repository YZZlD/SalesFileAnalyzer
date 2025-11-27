namespace SalesFileAnalyzer
{
    public static class SalesFiltering
    {
        public static List<SalesLineItem> FilterList(List<SalesLineItem> salesList, string[] productNames)
        {
            var query = from entry in salesList where productNames.Contains(entry.ProductName) select entry;
            return query.ToList<SalesLineItem>();
        }
    }
}