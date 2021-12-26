using Application.Exceptions;
using Application.IRepositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Produits.Commands
{
    public class DeleteProductCommand:IRequest<Unit>
    {
        public Guid Id { get; set; }
        public class Handler : IRequestHandler<DeleteProductCommand, Unit>
        {
            private readonly IProduitRepository _produitRepository;
            private readonly IMapper _mapper;

            public Handler(IProduitRepository produitRepository, IMapper mapper)
            {
                _produitRepository = produitRepository;
                _mapper = mapper;
            }
            public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
            {
                var produit = await _produitRepository.GetProduitByIdAsync(request.Id, cancellationToken);
                if (produit == null)
                {
                    throw new BusinessRuleException($" The product with the '{request.Id}' is not existe.");
                }
                _produitRepository.DeleteProduct(produit);
                await _produitRepository.SaveChangeAsync();
                return Unit.Value;
            }
        }
    }
}
