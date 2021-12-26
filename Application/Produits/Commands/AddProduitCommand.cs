using Application.Common.Mapping;
using Application.IRepositories;
using Application.Produits.Dtos;
using AutoMapper;
using Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Produits.Commands
{
    public class AddProduitCommand : IRequest<ProduitDto>
    {
        public string Nom { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
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
            var produit = new Produit()
            {
                Nom= request.Nom,
                Description=request.Description,
                Image=request.Image,
                EnStock=request.EnStock,
                Prix=request.Prix,
                Quantite=request.Quantite  
            };
            var newProduct =await _produitRepository.AddProduitAsync(produit, cancellationToken);
            await _produitRepository.SaveChangeAsync();
            var result =_mapper.Map<ProduitDto>(newProduct);
            return result;
        }
    }
}
