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

namespace Application.Produits.Queries
{
    public class GetAllProduitQuerie : IRequest<List<ProduitDto>>
    {
    }
    public class Handler : IRequestHandler<GetAllProduitQuerie, List<ProduitDto>>
    {
        private readonly IProduitRepository _produitRepository;
        private readonly IMapper _mapper;

        public Handler(IProduitRepository produitRepository, IMapper mapper)
        {
            _produitRepository = produitRepository;
            _mapper = mapper;
        }

        public async Task<List<ProduitDto>> Handle(GetAllProduitQuerie request, CancellationToken cancellationToken)
        {
            List<ProduitDto> itemList = new List<ProduitDto>();
            var produits = await _produitRepository.GetAllProduitsAsync(cancellationToken);
            if(produits == null)
            {
                return itemList;    
            }
            foreach(var item in produits)
            {
               var itemDto =  _mapper.Map<ProduitDto>(item);
                itemList.Add(itemDto);
                
            }
            
            return itemList;

        }
    }
}