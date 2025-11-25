namespace SalesFileAnalyzer
{
    class SalesLineItem
    {
        public string ProductName { get; set; }
        public DateOnly DateOfSale { get; set; }
        public double SalesAmount { get; set; }

        public SalesLineItem()
        {
            
        }

        public override string ToString()
        {
            return $"{ProductName}, {DateOfSale.ToString().Replace("-", "/")}, {SalesAmount:00.00}";
        }
    }
}