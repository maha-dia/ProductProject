using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VennDevTest.Entities;
using VennDevTest.Infrastructure;

namespace VennDevTest.Controllers
{
    public class ProduitsController : Controller
    {
        private readonly IProduitRepository _produitRepository;
        public ProduitsController(IProduitRepository produitRepository)
        {
            _produitRepository = produitRepository;
        }
        

        public IActionResult GetAllProduits()
        {
            var produitItems = _produitRepository.GetAllProduits();
            return View("Produits",produitItems);
        }
        
        public ActionResult<Produit> GetPoduitById(Guid id)
        {
            var item = _produitRepository.GetProduitById(id);
            return Ok(item);
        }
        public IActionResult AddProduit()
        {
            Produit p = new Produit();
            return View("AddProduit", p);
        }
        public IActionResult SaveProduit(Produit? p)
        {
            var produit = _produitRepository.AddProduit(p);
            //_produitRepository.SaveChange();
            return RedirectToAction("Produits");
            
        }


    }
}
