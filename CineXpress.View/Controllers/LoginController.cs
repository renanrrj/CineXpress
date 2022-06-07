using Microsoft.AspNetCore.Mvc;
using CineXpress.Model;
using Microsoft.Data.SqlClient;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using CineXpress.View.Models;

namespace CineXpress.View.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogarAsync(string Email, string Senha)
        {
            SqlConnection sqlConnection = new("Data Source=DESKTOP-R7MU39T\\SQLEXPRESS;Initial Catalog=CineXpressDB5p;User ID=sa;Password=sa123");
            await sqlConnection.OpenAsync();

            SqlConnection SqlCommand = sqlConnection;

            SqlCommand sqlCommand = SqlCommand.CreateCommand();

             sqlCommand.CommandText = $"select * from tb_Cliente where Email = '{Email}' AND Senha = '{Senha}' ";

             


            SqlDataReader reader = sqlCommand.ExecuteReader();


            if (await reader.ReadAsync())
            {

                return RedirectToAction("index", "Home");
            }
           
              return Json(new { Msg = "Usuario não encontrado! Verifique as credenciais!" });

        }
              
        }

     
     
    }