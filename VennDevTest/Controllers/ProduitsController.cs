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
        [HttpGet]
        public IActionResult GetPoduitById(Guid id)
        {
            var item = _produitRepository.GetProduitById(id);
            return View("DetailsProduit",item);
        }
        public IActionResult AddProduit()
        {
            Produit p = new Produit();
            return View("AddProduit", p);
        }
        [HttpPost]
        public IActionResult SaveProduit(Produit p)
        {
            if (ModelState.IsValid)
            {
                _produitRepository.AddProduit(p);
                _produitRepository.SaveChange();
                return RedirectToAction("GetAllProduits");
            }
            return View("AddProduit", p);
        }
       
        public IActionResult DeleteProduct(Guid id)
        {
            var product = _produitRepository.GetProduitById(id);
            _produitRepository.DeleteProduct(product);
            _produitRepository.SaveChange();
            return RedirectToAction("GetAllProduits");
        }
        public IActionResult EditForm(Guid id)
        {
            var product = _produitRepository.GetProduitById(id);
            return View("EditProduit", product);
        }
        public IActionResult EditeProduct(Produit product)
        {
            
            _produitRepository.EditeProduct(product);
            _produitRepository.SaveChange();
            return RedirectToAction("GetAllProduits");
        }



    }
}
