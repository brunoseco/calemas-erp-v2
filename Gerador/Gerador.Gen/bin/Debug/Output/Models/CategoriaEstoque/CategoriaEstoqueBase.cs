using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace calemaserp.ui.Core.Data.Model
{
    public class CategoriaEstoqueBase : DomainBase
    {
        public CategoriaEstoqueBase()
        {

        }

        public int CategoriaEstoqueId { get; set; } 
        public string Nome { get; set; } 


    }
}