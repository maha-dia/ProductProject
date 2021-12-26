using Application.IRepositories;
using Application.Produits.Commands;
using Application.Produits.Queries;
using Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace VennDevTest.Controllers
{
    public class ProduitsController : Controller
    {
        
        private readonly IMediator _mediator;

        public ProduitsController(IMediator meditor)
        {
            this._mediator = meditor;
        }

        /// <summary>
        /// Create new Workspace
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SaveProduit(AddProduitCommand command)
        {
            var result = await this._mediator.Send(command);
            return View("AddProduit", command);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProduits(GetAllProduitQuerie request)
        {
            var result = await this._mediator.Send(request);
            return View("Produits", result);
        }
        //[HttpGet]
        //public IActionResult GetPoduitById(Guid id)
        //{
        //    var item = _produitRepository.GetProduitById(id);
        //    return View("DetailsProduit",item);
        //}
        public IActionResult AddProduit()
        {
            Produit p = new Produit();
            return View("AddProduit", p);
        }
        //[HttpPost]
        //public IActionResult SaveProduit(Produit p)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _produitRepository.AddProduit(p);
        //        _produitRepository.SaveChange();
        //        return RedirectToAction("GetAllProduits");
        //    }
        //    return View("AddProduit", p);
        //}
       
        //public IActionResult DeleteProduct(Guid id)
        //{
        //    var product = _produitRepository.GetProduitById(id);
        //    _produitRepository.DeleteProduct(product);
        //    _produitRepository.SaveChange();
        //    return RedirectToAction("GetAllProduits");
        //}
        //public IActionResult EditForm(Guid id)
        //{
        //    var product = _produitRepository.GetProduitById(id);
        //    return View("EditProduit", product);
        //}
        //public IActionResult EditeProduct(Guid id,Produit product)
        //{
        //    var prod = _produitRepository.GetProduitById(id);
            
            
        //        prod.Description = product.Description;
        //        prod.Nom = product.Nom;
        //        prod.Prix = product.Prix;
        //        prod.Quantite = product.Quantite;
        //        prod.Image = product.Image;
               
        //        _produitRepository.SaveChange();
                
            
        //    return RedirectToAction("GetAllProduits");

        //}



    }
}
