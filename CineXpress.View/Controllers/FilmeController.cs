using CineXpress.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CineXpress.View.Controllers;

namespace CineXpress.View.Controllers
{
    public class FilmeController : Controller
    {
        // GET: FuncionarioController
        Context_CineXpress db; // Contexto
        public FilmeController() // COntrutor do contexto
        {
            db = new Context_CineXpress();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Filme()
        {
            List<TbFilme> oFilme = db.TbFilme.ToList();
            return View(oFilme);
        }

        // GET: FuncionarioController/Details/5
        public ActionResult CarrosDetalhe(int Id)
        {
            TbFilme oFilme = db.TbFilme.Find(Id);
            //List<TbFilme> oFilme = db.TbFilme.ToList();
            return View(oFilme);
        }
        public ActionResult ThorDetalhe(int id)
        {
            TbFilme oFilme = db.TbFilme.Find(id);
            return View(oFilme);
        }
        public ActionResult HotWheelsDetalhe(int id)
        {
            TbFilme oFilme = db.TbFilme.Find(id);
            return View(oFilme);
        }
        public ActionResult VingadoresDetalhe(int id)
        {
            TbFilme oFilme = db.TbFilme.Find(id);
            return View(oFilme);
        }
        public ActionResult BatmanDetalhe(int id)
        {
            TbFilme oFilme = db.TbFilme.Find(id);
            return View(oFilme);
        }
        public ActionResult MaxSteelDetalhe(int id)
        {
            TbFilme oFilme = db.TbFilme.Find(id);
            return View(oFilme);
        }
        // GET: FuncionarioController/Create
        public ActionResult Criar()
        {
            return View();
        }

        // POST: FuncionarioController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(TbFilme oCat)
        {
            db.TbFilme.Add(oCat);
            db.SaveChanges();
            return RedirectToAction("Filme");
        }

        // GET: FuncionarioController/Edit/5
        public ActionResult Editar(int id)
        {
            TbFilme oCat = db.TbFilme.Find(id);
            return View(oCat);
        }

        // POST: FuncionarioController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(int id, TbFilme oCat)
        {
            var oCatBanco = db.TbFilme.Find(id);

            oCatBanco.NomeFilme = oCat.NomeFilme;
            oCatBanco.Classificacao = oCat.Classificacao;
            oCatBanco.Sinopse = oCat.Sinopse;
            oCatBanco.Duracao = oCat.Duracao;

            db.Entry(oCatBanco).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Filme");
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Filme()
        //{
        //    List<TbFilme> oFilme = db.TbFilme.ToList();
        //    return View(oFilme);
        //}

        // GET: FuncionarioController/Delete/5
        public ActionResult Delete(int id)
        {
            TbFilme oFilme = db.TbFilme.Find(id);
            db.Entry(oFilme).State = EntityState.Deleted;
            db.SaveChanges();
            return RedirectToAction(nameof(Filme));
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
