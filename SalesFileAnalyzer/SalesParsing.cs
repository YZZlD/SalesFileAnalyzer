namespace SalesFileAnalyzer
{
    class SalesParsing
    {
        public List<SalesLineItem> ReadSalesData(string filePath)
        {
            List<SalesLineItem> sales = new List<SalesLineItem>();

            try
            {
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
            }
            catch(IOException ioe)
            {
                Console.WriteLine($"File at {Path.Combine(Directory.GetCurrentDirectory(), $"input\\{filePath}")} could not be found.");
                Environment.Exit(-1);
            }
            

            return sales;
        }

        public string DisplayTotalSalesByProduct(List<SalesLineItem> sales, string message = "Total sales by Product:", bool returnData = false)
        {
            Dictionary<string, double> salesByProduct = new Dictionary<string, double>();
            string data = "";

            foreach(SalesLineItem sale in sales)
            {
                if(!salesByProduct.ContainsKey(sale.ProductName)) salesByProduct[sale.ProductName] = 0;

                salesByProduct[sale.ProductName] += sale.SalesAmount;
            }

            Console.WriteLine(message);
            foreach(KeyValuePair<string, double> productSalesInformation in SortResult(salesByProduct))
            {
                Console.WriteLine($"{productSalesInformation.Key}: ${productSalesInformation.Value:00.00}");
                if(returnData) data += $"{productSalesInformation.Key}: ${productSalesInformation.Value:00.00};";
            }

            return data;
        }

        public string DisplayTotalSalesByMonth(List<SalesLineItem> sales, string message = "Total sales by Month:", bool returnData = false)
        {
            Dictionary<string, double> salesByMonth = new Dictionary<string, double>();
            Dictionary<string, string> monthConversion = new Dictionary<string, string>
            {
                {"01", "January"},
                {"02", "February"},
                {"03", "March"},
                {"04", "April"},
                {"05", "May"}, 
                {"06", "June"},
                {"07", "July"},
                {"08", "August"},
                {"09", "September"},
                {"10", "October"},
                {"11", "November"},
                {"12", "December"}
            };
            string data = "";

            foreach(SalesLineItem sale in sales)
            {
                string month = monthConversion[sale.DateOfSale.ToString().Split('-')[1]];
                if(!salesByMonth.ContainsKey(month)) salesByMonth[month] = 0;

                salesByMonth[month] += sale.SalesAmount;
            }

            Console.WriteLine(message);
            foreach(KeyValuePair<string, double> productSalesInformation in SortResult(salesByMonth))
            {
                string formattedAmount = productSalesInformation.Value.ToString("0.00");
                for(int i = formattedAmount.Length - 6; i >= 1; i -= 3)
                {
                    formattedAmount = formattedAmount.Insert(i, ",");
                }

                Console.WriteLine($"{productSalesInformation.Key}: ${formattedAmount}");
                if(returnData) data += $"{productSalesInformation.Key}: ${formattedAmount};";
            }

            return data;
        }

        public void WriteSalesData(string[] filterList, List<SalesLineItem> productInformation, string salesByProduct, string salesByMonth, string filePath)
        {

            using(StreamWriter sw = new StreamWriter(Path.Combine(Directory.GetCurrentDirectory(), $"output\\{filePath}")))
            {
                sw.WriteLine($"Filtered product(s): {String.Join(", ", filterList)}");
                
                sw.WriteLine("\n");
                sw.WriteLine("Products Information:");
                foreach(SalesLineItem sale in productInformation)
                {
                    sw.WriteLine(sale);
                }

                sw.WriteLine("\n");
                sw.WriteLine("Total sales by Filtered product: ");
                foreach(string salesProduct in salesByProduct.Split(';'))
                {
                    sw.WriteLine(salesProduct);
                }

                sw.WriteLine("\n");
                sw.WriteLine("Total sales by Filtered product group by Month: ");
                foreach(string salesMonth in salesByMonth.Split(';'))
                {
                    sw.WriteLine(salesMonth);
                }
            }
        }

        private IEnumerable<KeyValuePair<string, double>> SortResult(IEnumerable<KeyValuePair<string, double>> result)
        {
            return from entry in result orderby entry.Value descending select entry;
        }
    }
}