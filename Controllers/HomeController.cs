using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using ProductListProject.Models;
using System.Collections.Generic;

namespace ProductListProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly string _connectionString;

        public HomeController(IConfiguration configuration)
        {
            // Lấy chuỗi kết nối từ appsettings.json
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public IActionResult Index()
        {
            List<Product> productList = new List<Product>();

            // Kết nối DB SQL Server và lấy dữ liệu
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    string sql = "SELECT Id, Name, Price FROM Product";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Product product = new Product
                                {
                                    Id = reader.GetInt32(0),
                                    Name = reader.GetString(1),
                                    Price = reader.GetDecimal(2)
                                };
                                productList.Add(product);
                            }
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {
                // Bắt lỗi kết nối để view có thể hiển thị danh sách rỗng kèm theo cảnh báo (nếu có)
                ViewBag.ErrorMessage = "Lỗi kết nối CSDL: " + ex.Message;
            }

            // Trả danh sách sản phẩm về View
            return View(productList);
        }
    }
}
