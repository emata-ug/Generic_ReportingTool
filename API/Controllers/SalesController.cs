using Database;
using Domain.Sales;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly SalesDbContext _dbContext;

        public SalesController(SalesDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("list-sales")]
        public ActionResult<List<Sale>> GetSales()
        {
            var sales = _dbContext.Sales.ToList();

            return StatusCode((int)HttpStatusCode.OK, sales);
        }

        [HttpPost("upload-sales")]
        public ActionResult<List<Sale>> UploadSales(IFormFile fileUpload)
        {
            // upload file to temp location
            string tempFilePath = Path.GetTempFileName();

            using (var fileStream = System.IO.File.Create(tempFilePath))
            {
                fileUpload.CopyTo(fileStream);
            }

            //Read all entries  
            string allText = System.IO.File.ReadAllText(tempFilePath);
            var rows = allText.Split('\n');

            // sales entries to save to database
            var sales = new List<Sale>();

            //spliting row after new line  
            for (int i = 0; i < rows.Length; i++)
            {
                if (i == 0) continue;

                if (i == rows.Length - 1) continue;

                string row = rows[i];

                if (string.IsNullOrEmpty(row)) continue;

                var cells = row.Split(',');

                var parsedOrderDate = DateTime.Parse(cells[5]);
                var parsedShipDate = DateTime.Parse(cells[7]);
                var parsedUnitsSold = int.Parse(cells[8]);
                var parsedUnitCost = decimal.Parse(cells[9]);
                var parsedTotalRevenue = decimal.Parse(cells[10]);
                var parsedTotalCost = decimal.Parse(cells[11]);
                var parsedTotalProfit = decimal.Parse(cells[12]);

                sales.Add(
                    new Sale
                    {
                        Region = cells[0],
                        Country = cells[1],
                        ItemType = cells[2],
                        Channel = cells[3],
                        OrderPriority = cells[4],
                        OrderDate = parsedOrderDate,
                        OrderId = cells[6],
                        ShipDate = parsedShipDate,
                        UnitsSold = parsedUnitsSold,
                        UnitCost = parsedUnitCost,
                        TotalRevenue = parsedTotalRevenue,
                        TotalCost = parsedTotalCost,
                        TotalProfit = parsedTotalProfit
                    });
            }

            _dbContext.Sales.AddRange(sales);

            _dbContext.SaveChanges();

            return StatusCode((int)HttpStatusCode.OK);
        }        
    }    
}
