using Application.Exceptions;
using Application.IRepositories;
using Application.Produits.Dtos;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Produits.Commands
{
    public class EditProductCommand:IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Prix { get; set; }
        public bool EnStock { get; set; }
        public int Quantite { get; set; }

        public class Handler : IRequestHandler<EditProductCommand, Unit>
        {
            private readonly IProduitRepository _produitRepository;
            private readonly IMapper _mapper;

            public Handler(IProduitRepository produitRepository, IMapper mapper)
            {
                _produitRepository = produitRepository;
                _mapper = mapper;
            }
            public async Task<Unit> Handle(EditProductCommand request, CancellationToken cancellationToken)
            {
                var produit = await _produitRepository.GetProduitByIdAsync(request.Id,cancellationToken);
                if(produit == null)
                {
                    throw new BusinessRuleException($" The product with the '{request.Id}' is not existe.");
                }
                produit.Nom = request.Nom;
                produit.Description = request.Description;
                produit.Image = request.Image;
                produit.EnStock = request.EnStock;
                produit.Prix = request.Prix;
                produit.Quantite = request.Quantite;
                await _produitRepository.SaveChangeAsync();

                return Unit.Value;
            }
        }
    }
}
