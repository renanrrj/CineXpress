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


            if (User.Identity.IsAuthenticated)
            {

                return RedirectToAction("Filme", "Home");




            }

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



            SqlCommand sqlCommand2 = SqlCommand.CreateCommand();
            sqlCommand2.CommandText = $"select * from tb_Funcionario where Email = '{Email}' AND Senha = '{Senha}' ";




            SqlDataReader reader = sqlCommand.ExecuteReader();




            if (await reader.ReadAsync())
            {
                int usuarioId = reader.GetInt32(0);
                string nome = reader.GetString(1);



                List<Claim> DireitosAcesso = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, usuarioId.ToString()),
                    new Claim(ClaimTypes.Name, nome)






                };



                var identity = new ClaimsIdentity(DireitosAcesso, "Identity.Login");
                var userPrincipal = new ClaimsPrincipal(new[] { identity });

                await HttpContext.SignInAsync(userPrincipal,
                    new AuthenticationProperties
                    {
                        IsPersistent = false,
                        ExpiresUtc = DateTime.Now.AddMinutes(5)
                    });


                return RedirectToAction("Index", "Home");






            }
            else
            {
                reader.Close();

                SqlDataReader admin = sqlCommand2.ExecuteReader();

                if (await admin.ReadAsync())
                {
                    int AdminId = admin.GetInt32(0);
                    String nomeAdmin = admin.GetString(1);

                    List<Claim> DireitosAcessoAdmin = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, AdminId.ToString()),
                    new Claim(ClaimTypes.Name, nomeAdmin)
                };



                    var identityAdm = new ClaimsIdentity(DireitosAcessoAdmin, "Identity.Loginadm");
                    var UserAdmin = new ClaimsPrincipal(new[] { identityAdm });

                    await HttpContext.SignInAsync(UserAdmin,
                        new AuthenticationProperties
                        {
                            IsPersistent = false,
                            ExpiresUtc = DateTime.Now.AddMinutes(1)
                        });

                    return RedirectToAction("Funcionario", "Funcionario");
                }
                else
                {

                    return RedirectToAction("Index", "Login");
                }





            }

            
            }
        public async Task<ActionResult> logout()
        {


            if (User.Identity.IsAuthenticated)
            {

                await HttpContext.SignOutAsync();


                return RedirectToAction("index", "Login");
            }
            return RedirectToAction("index", "Login");


        }


    }


  




}