using Common.Domain.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace superacrm.ui.Core.Data.Model
{
    public class NegocioBase : DomainBase
    {
        public NegocioBase()
        {

        }

        public int NegocioId { get; set; } 
        public string Titulo { get; set; } 
        public int EmpresaId { get; set; } 
        public int AssinaturaId { get; set; } 
        public int? UsuarioId { get; set; } 
        public int? ProprietarioId { get; set; } 
        public decimal? Valor { get; set; } 
        public int? FunilId { get; set; } 
        public int? EtapaAtual { get; set; } 
        public decimal? Probabilidade { get; set; } 
        public DateTime? DataProximaAtividade { get; set; } 
        public DateTime? DataUltimaAtividade { get; set; } 
        public DateTime? DataGanho { get; set; } 
        public DateTime? DataPerda { get; set; } 
        public DateTime? DataFechamentoNegocio { get; set; } 
        public int? MotivoPerdaId { get; set; } 
        public int VisibilidadeId { get; set; } 
        public DateTime? DataFechamentoEsperada { get; set; } 
        public int StatusNegocioId { get; set; } 
        public DateTime DataCriacao { get; set; } 
        public DateTime? DataAtualizacao { get; set; } 


    }
}