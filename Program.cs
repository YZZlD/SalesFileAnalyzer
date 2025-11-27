namespace SalesFileAnalyzer
{
    class Program
    {
        public static void Main(string[] args)
        {
            List<SalesLineItem> sales = new List<SalesLineItem>();
            string[] products;

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

            Console.Write("\n\nEnter search strings seperated by commas: ");
            products = Console.ReadLine().Replace(" ", "").Split(",");

            List<SalesLineItem> filteredSales = SalesFiltering.FilterList(sales, products);

            string salesByProductFiltered = sp.DisplayTotalSalesByProduct(filteredSales, "Total sales by Filtered product:", true);
            Console.Write("\n\n\n");

            string salesByMonthFiltered = sp.DisplayTotalSalesByMonth(filteredSales, "Total sales by Filtered product group by Month: ", true);

            sp.WriteSalesData(products, filteredSales, salesByProductFiltered, salesByMonthFiltered, outputPath);
        }
    }
}