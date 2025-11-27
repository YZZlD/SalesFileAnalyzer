namespace SalesFileAnalyzer
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<SalesLineItem> sales = new List<SalesLineItem>();

            string inputPath;
            string outputPath;

            Console.Write("Enter the input file path: ");
            inputPath = Console.ReadLine();

            Console.Write("Enter the output file path: ");
            outputPath = Console.ReadLine();

            SalesParsing sp = new SalesParsing();

            sales = sp.ReadSalesData(inputPath);

            sp.DisplayTotalSalesByProduct(sales);
            Console.Write("\n\n\n");

            sp.DisplayTotalSalesByMonth(sales);

            List<SalesLineItem> filteredSales = SalesFiltering.FilterList(sales, ["Product1", "Product3", "Product5"]);

            sp.DisplayTotalSalesByProduct(filteredSales);
            Console.Write("\n\n\n");

            sp.DisplayTotalSalesByMonth(filteredSales);
            Console.Write("\n\n\n");
        }
    }
}