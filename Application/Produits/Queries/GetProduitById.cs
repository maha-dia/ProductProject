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

namespace Application.Produits.Queries
{
    public class GetProduitById:IRequest<ProduitDto>
    {
        public Guid Id { get; set; }
        public class Handler : IRequestHandler<GetProduitById, ProduitDto>
        {
            private readonly IProduitRepository _produitRepository;
            private readonly IMapper _mapper;

            public Handler(IProduitRepository produitRepository, IMapper mapper)
            {
                _produitRepository = produitRepository;
                _mapper = mapper;
            }
            public async Task<ProduitDto> Handle(GetProduitById request, CancellationToken cancellationToken)
            {
                var product =await _produitRepository.GetProduitByIdAsync(request.Id, cancellationToken);
                if (product == null)
                {
                    throw new BusinessRuleException($" The'{request.Id}' is not valid.");
                }
                var response = _mapper.Map<ProduitDto>(product);
                return response;
            }
        }
    }
    
}
