using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_GerenciadorDeConteudo.Controllers
{
    public class PaginasController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Paginas = new Pagina().lista();
            return View();
        }
        public ActionResult Novo()
        {
            return View();
        }
        [HttpPost]
        public void Criar()
        {
           
            DateTime data;
            DateTime.TryParse(Request["data"], out data);
            var pagina = new Pagina();
            pagina.Nome = Request["nome"];
            pagina.Data = data;
            pagina.Conteudo = Request["conteudo"];
            pagina.save();
            TempData.Add("sucesso", "Dados salvos com sucesso!");
           
            Response.Redirect("/paginas");
        }
        public ActionResult Editar(int id)
        {
            var pagina = Pagina.BuscaPorId(id);
            ViewBag.Pagina = pagina;
            return View();
        }
        [HttpPost]
        public void Alterar(int id)
        {
            try
            {
                var pagina = Pagina.BuscaPorId(id);
                DateTime data;
                DateTime.TryParse(Request["data"], out data);
                pagina.Nome = Request["nome"];
                pagina.Data = data;
                pagina.Conteudo = Request["conteudo"];
                pagina.save();

                TempData.Add("sucesso", "Dados Actualizada com sucesso!");

            }
            catch(Exception e)
            {
                TempData.Add("erro",e.Message);
            }
            Response.Redirect("/paginas");
        }
        public void Excluir(int id)
        {
            
            Pagina.Excluir(id);

            Response.Redirect("/paginas");
        }
    }
}