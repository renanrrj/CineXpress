using CineXpress.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CineXpress.View.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: FuncionarioController
        Context_CineXpress db; // Contexto
        public FuncionarioController() // COntrutor do contexto
        {
            db = new Context_CineXpress();
        }
        public ActionResult Funcionario()
        {
            List<TbFuncionario> oLista = db.TbFuncionario.ToList();
            return View(oLista);
        }

        // GET: FuncionarioController/Details/5
        public ActionResult Detalhes(int id)
        {
            TbFuncionario oCliente = db.TbFuncionario.Find(id);
            return View(oCliente);
        }

        // GET: FuncionarioController/Create
        public ActionResult Criar()
        {
            return View();
        }

        // POST: FuncionarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(TbFuncionario oCat)
        {
            db.TbFuncionario.Add(oCat);
            db.SaveChanges();
            return RedirectToAction("Funcionario");
        }

        // GET: FuncionarioController/Edit/5
        public ActionResult Editar(int id)
        {
            TbFuncionario oCat = db.TbFuncionario.Find(id);
            return View(oCat);
        }

        // POST: FuncionarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, TbFuncionario oCat)
        {
            var oCatBanco = db.TbFuncionario.Find(id);
            oCatBanco.NomeFuncionario = oCat.NomeFuncionario;
            oCatBanco.Email = oCat.Email;
            oCatBanco.Senha = oCat.Senha;
            oCatBanco.Cpf = oCat.Cpf;
            oCatBanco.DataNascimento = oCat.DataNascimento;
            oCatBanco.Celular = oCat.Celular;
            db.Entry(oCatBanco).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Funcionario");
        }

        // GET: FuncionarioController/Delete/5
        public ActionResult Delete(int id)
        {
            TbFuncionario oFuncionario = db.TbFuncionario.Find(id);
            db.Entry(oFuncionario).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction(nameof(Funcionario));
        }

        // POST: FuncionarioController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
