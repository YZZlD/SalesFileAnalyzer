namespace SalesFileAnalyzer
{
    class SalesParsing
    {
        public List<SalesLineItem> ReadSalesData(string filePath)
        {
            List<SalesLineItem> sales = new List<SalesLineItem>();

            using(StreamReader sr = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), $"input\\{filePath}")))
            {
                string line = "";
                while((line = sr.ReadLine()) != null)
                {
                    string[] lineData = line.Split(',');
                    SalesLineItem item = new SalesLineItem(){ProductName = lineData[0], DateOfSale = DateOnly.Parse(lineData[1]), SalesAmount = double.Parse(lineData[2])};
                    sales.Add(item);
                }
            }

            return sales;
        }

        public void DisplayTotalSalesByProduct(List<SalesLineItem> items)
        {
            
        }

        public void DisplayTotalSalesByMonth(List<SalesLineItem> items)
        {
            
        }

        public void WriteSalesData(List<SalesLineItem> items)
        {
            
        }
    }
}