using ClosedXML.Excel;
using JourneyJoy.BLL.Abstract;
using JourneyJoy.DTO.DestinationDtos;
using JourneyJoy.DTO.ServiceResponseDtos;
using OfficeOpenXml;

namespace JourneyJoy.BLL.Concrete
{
    public class ExcelManager : IExcelService
    {
        public ApiResponseDto<byte[]> CreateExcelReport(List<ResultDestinationDto> destinations)
        {
            try
            {
                using var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Destinations");

                // Add headers
                var headers = new[] { "City", "Accommodation Duration", "Price", "Capacity" };
                for (int col = 0; col < headers.Length; col++)
                {
                    worksheet.Cell(1, col + 1).Value = headers[col];
                }

                // Add data
                for (int row = 0; row < destinations.Count; row++)
                {
                    var destination = destinations[row];
                    worksheet.Cell(row + 2, 1).Value = destination.City;
                    worksheet.Cell(row + 2, 2).Value = $"{destination.Day} Day {destination.Night} Night";
                    worksheet.Cell(row + 2, 3).Value = destination.Price;
                    worksheet.Cell(row + 2, 4).Value = destination.Capacity;
                }

                using var stream = new MemoryStream();
                workbook.SaveAs(stream);

                return new ApiResponseDto<byte[]>(stream.ToArray(), true, 200, "Excel report created successfully");
            }
            catch (Exception ex)
            {
                return new ApiResponseDto<byte[]>(null, false, 500, $"Error creating Excel report: {ex.Message}");
            }
        }


        public byte[] StaticExcelList<T>(List<T> list) where T : class
        {
            // with EPPlus .. 
            using var excelPackage = new ExcelPackage();
            var worksheet = excelPackage.Workbook.Worksheets.Add("Page1");

            // Add headers
            var headers = new[] { "Destination", "Guide", "Quota" };
            worksheet.Cells[1, 1].Value = headers[0];
            worksheet.Cells[1, 2].Value = headers[1];
            worksheet.Cells[1, 3].Value = headers[2];

            // Add data
            var data = new[] { new[] { "Italy Trip", "Ali YILDIZ", "40" }, new[] { "Paris Tour", "Ayse SAKA", "30" } };
            for (int row = 0; row < data.Length; row++)
            {
                for (int col = 0; col < data[row].Length; col++)
                {
                    worksheet.Cells[row + 2, col + 1].Value = data[row][col];
                }
            }

            var stream = new MemoryStream();
            excelPackage.SaveAs(stream);

            return stream.ToArray();
        }
    }
}
