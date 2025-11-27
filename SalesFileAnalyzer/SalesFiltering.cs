namespace SalesFileAnalyzer
{
    public static class SalesFiltering
    {
        public static List<SalesLineItem> FilterList(List<SalesLineItem> salesList, string[] productNames)
        {
            var query = from entry in salesList where productNames.Contains(entry.ProductName.ToLower()) select entry;
            List<SalesLineItem> filteredList = query.ToList<SalesLineItem>();

            try
            {
                if(filteredList.Count == 0) 
                {
                    throw new Exception("No provided product names found. Please provide valid product names.");
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(-1);
            }

            return filteredList;
        }
    }
}