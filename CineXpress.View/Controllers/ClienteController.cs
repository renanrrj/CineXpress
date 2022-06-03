using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CineXpress.Model;
using Microsoft.EntityFrameworkCore;

namespace CineXpress.View.Controllers
{
    public class ClienteController : Controller
    {
        // GET: ClienteController
        Context_CineXpress db; // Contexto
        public ClienteController() // COntrutor do contexto
        {
            db = new Context_CineXpress();
        }

        public ActionResult Cliente()
        {
            List<TbCliente> oLista = db.TbCliente.ToList();
            return View(oLista);
        }

        // GET: ClienteController/Details/5
        public ActionResult Detalhes(int id)
        {
            TbCliente oCliente = db.TbCliente.Find(id);
            return View(oCliente);
        }

        // GET: ClienteController/Create--------------------------------------------------------        CREATE
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TbCliente oCat) // Salvando e Adicionando ao Banco
        {
            db.TbCliente.Add(oCat);
            db.SaveChanges();
            return RedirectToAction("Cliente");
        }

        // GET: ClienteController/Edit/5-------------------------------------------------------     EDITAR
        public ActionResult Editar(int id)
        {
            TbCliente oCat = db.TbCliente.Find(id);
            return View(oCat);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, TbCliente oCat)
        {
            var oCatBanco = db.TbCliente.Find(id);
            oCatBanco.NomeCadastro = oCat.NomeCadastro;
            oCatBanco.Email = oCat.Email;
            oCatBanco.Senha = oCat.Senha;
            oCatBanco.Cpf = oCat.Cpf;
            oCatBanco.DataNascimento = oCat.DataNascimento;
            oCatBanco.Celular = oCat.Celular;
            db.Entry(oCatBanco).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Cliente");
        }

        // GET: ClienteController/Delete/5----------------------------------------------         DELETE
        public ActionResult Delete(int id)
        {
            TbCliente oCliente = db.TbCliente.Find(id);
            db.Entry(oCliente).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction(nameof(Cliente));
        }

        // POST: ClienteController/Delete/5
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
