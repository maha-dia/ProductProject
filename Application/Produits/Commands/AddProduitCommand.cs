using Application.Common.Mapping;
using Application.IRepositories;
using Application.Produits.Dtos;
using AutoMapper;
using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Http;

namespace Application.Produits.Commands
{
    public class AddProduitCommand : IRequest<ProduitDto>
    {
        public string Nom { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public double Prix { get; set; }
        public bool EnStock { get; set; }
        public int Quantite { get; set; }

    }
    public class Handler : IRequestHandler<AddProduitCommand, ProduitDto>
    {
        private readonly IProduitRepository _produitRepository;
        private readonly IMapper _mapper;

        public Handler(IProduitRepository produitRepository, IMapper mapper)
        {
            _produitRepository = produitRepository;
            _mapper = mapper;
        }
        public async Task<ProduitDto> Handle(AddProduitCommand request, CancellationToken cancellationToken)
        {
            string fileName = UploadedFile(request.Image);
            var produit = new Produit()
            {
                Nom = request.Nom,
                Description = request.Description,
                Image = fileName,
                EnStock = request.EnStock,
                Prix = request.Prix,
                Quantite = request.Quantite
            };
            var newProduct = await _produitRepository.AddProduitAsync(produit, cancellationToken);
            await _produitRepository.SaveChangeAsync();
            var result = _mapper.Map<ProduitDto>(newProduct);
            return result;
        }
        private string UploadedFile(IFormFile image)
        {

            string uniqueFileName = null;

            if (image != null)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Resources");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    image.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}