using Application.Common.Mapping;
using AutoMapper;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Produits.Dtos
{
    public class ProduitDto : IMapForm<Produit>
    {
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Prix { get; set; }
        public bool EnStock { get; set; }
        public int Quantite { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Produit, ProduitDto>();
        }
    }
}