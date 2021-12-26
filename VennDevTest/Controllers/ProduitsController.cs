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
        [HttpGet]
        public async Task<IActionResult> GetPoduitById(Guid id)
        {
            var item = await this._mediator.Send(new GetProduitById() { Id = id});
            return View("DetailsProduit", item);
        }
        public IActionResult AddProduit()
        {
            AddProduitCommand p = new AddProduitCommand();
            return View("AddProduit", p);
        }


        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            
            await this._mediator.Send(new DeleteProductCommand() { Id = id });
            return RedirectToAction("GetAllProduits");
        }
        public async Task<IActionResult> EditForm(Guid id)
        {
            var item = await this._mediator.Send(new GetProduitById() { Id = id });
            return View("EditProduit", item);
        }
        public async Task<IActionResult> EditeProduct(EditProductCommand command)
        {
            await this._mediator.Send(command);
            return RedirectToAction("GetAllProduits");
        }



    }
}
