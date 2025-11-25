namespace SalesFileAnalyzer
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<SalesLineItem> sales = new List<SalesLineItem>();

            SalesParsing sp = new SalesParsing();

            sales = sp.ReadSalesData("Sales.txt");

            Console.WriteLine(String.Join("\n", sales));

            sp.DisplayTotalSalesByProduct(sales);

            sp.DisplayTotalSalesByMonth(sales);
        }
    }
}