using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Produits.Commands
{
    public class AddProduitHandlerValidator : AbstractValidator<AddProduitCommand>
    {
        public AddProduitHandlerValidator()
        {
            this.RuleFor(x => x.Nom).NotEmpty().MinimumLength(3)
                .WithMessage("Name length should be at least three character");

        }
    }
}
