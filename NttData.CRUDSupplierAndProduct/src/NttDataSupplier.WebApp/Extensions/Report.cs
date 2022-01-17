using ClosedXML.Excel;
using NttDataSupplier.Domain.Interfaces.Services;
using System;
using System.IO;
using System.Threading.Tasks;

namespace NttDataSupplier.WebApp.Extensions
{
    public class Report
    {
        private readonly ISupplierService _supplierService;

        private string SpreadsheetTemplate = Path.Combine(Directory.GetCurrentDirectory(), "Extensions/ReportBase.xlsx");
        private string GenerationDirectory = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ReportSheets_Temp/");

        public Report(ISupplierService supplierService)
        {
            _supplierService = supplierService;
        }

        public async Task<string> GeneratorReport()
        {
            string name = Guid.NewGuid() + $"_{DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss")}.xlsx";
            string path = GenerationDirectory + name;

            File.Copy(SpreadsheetTemplate, path);

            using (var workbook = new XLWorkbook(path))
            {
                var worksheet = workbook.Worksheets.Worksheet("Sheet1");

                int i = 0;
                foreach (var supplier in await _supplierService.ToListAndProduct())
                {
                    if (i == 0)
                    {
                        worksheet.Cell("A" + (1 + i)).Value =
                            "Id";
                        worksheet.Cell("B" + (1 + i)).Value =
                            "Nome Fantasia";
                        worksheet.Cell("C" + (1 + i)).Value =
                            "Produto";
                        worksheet.Cell("D" + (1 + i)).Value =
                            "Qtde Estoque";
                        worksheet.Cell("E" + (1 + i)).Value =
                            "Valor Venda";
                        worksheet.Cell("F" + (1 + i)).Value =
                            "Valor Compra";
                    }

                    worksheet.Cell("A" + (2 + i)).Value =
                                               supplier.Id;
                    worksheet.Cell("B" + (2 + i)).Value =
                        supplier.FantasyName;

                    int x = i;
                    foreach (var product in supplier.Products)
                    {
                        if (x > i)
                        {
                            worksheet.Cell("A" + (2 + x)).Value =
                               supplier.Id;
                            worksheet.Cell("B" + (2 + x)).Value =
                                supplier.FantasyName;
                        }

                        worksheet.Cell("C" + (2 + x)).Value =
                            product.Name;
                        worksheet.Cell("D" + (2 + x)).Value =
                            product.QuantityStock;
                        worksheet.Cell("E" + (2 + x)).Value =
                            product.PriceSales;
                        worksheet.Cell("F" + (2 + x)).Value =
                            product.PricePurchase;

                        x++;
                    }



                    if (i == x)
                        i++;
                    else
                        i = x;

                }

                workbook.Save();
                return Path.Combine("/ReportSheets_Temp/", name);
            }
        }
    }
}
