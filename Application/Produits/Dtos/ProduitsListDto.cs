using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Produits.Dtos
{
    public class ProduitsListDto
    {
        public ProduitsListDto()
        {

        }
        public IList<ProduitDto> Produits { get; set; }
    }
}
