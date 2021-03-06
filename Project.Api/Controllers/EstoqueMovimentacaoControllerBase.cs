using Common.API;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using CalemasERP.Core.Services;
using CalemasERP.Core.Dto;
using CalemasERP.Core.Filters;
using CalemasERP.Core.Data.Repository;
using System;
using System.Threading.Tasks;

namespace CalemasERP.Core.Api.Controllers
{
    public class EstoqueMovimentacaoControllerBase : Controller
    {
        protected readonly EstoqueMovimentacaoService _service;
        protected readonly EstoqueMovimentacaoRepository _rep;
        protected readonly ILogger _logger;

        public EstoqueMovimentacaoControllerBase(EstoqueMovimentacaoService service, EstoqueMovimentacaoRepository rep, ILoggerFactory logger)
        {
            this._service = service;
            this._rep = rep;
            this._logger = logger.CreateLogger<EstoqueMovimentacaoController>();
        }

        #region Principals

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]EstoqueMovimentacaoFilter filters)
        {
            var result = new HttpResult<EstoqueMovimentacaoDto>(this._logger, this._service);
            try
            {
                var searchResult = await this._service.GetByFiltersPaging(filters);
                return result.ReturnCustomResponse(searchResult);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "EstoqueMovimentacao", filters);
            }
        }

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]EstoqueMovimentacaoFilter filters)
		{
			var result = new HttpResult<EstoqueMovimentacaoDto>(this._logger, this._service);
			try
			{
				filters.EstoqueMovimentacaoId = id;
				var returnModel = await this._service.GetById(filters);
				return result.ReturnCustomResponse(returnModel);
			}
			catch (Exception ex)
			{
				return result.ReturnCustomException(ex, "EstoqueMovimentacao", id);
			}
		}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]EstoqueMovimentacaoDtoSave dto)
        {
            var result = new HttpResult<EstoqueMovimentacaoDto>(this._logger, this._service);
            try
            {
                var returnModel = await this._service.Save(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "EstoqueMovimentacao", dto);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody]EstoqueMovimentacaoDtoSave dto)
        {
            var result = new HttpResult<EstoqueMovimentacaoDto>(this._logger, this._service);
            try
            {
                var returnModel = await this._service.SavePartial(dto);
                return result.ReturnCustomResponse(returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "EstoqueMovimentacao", dto);
            }
        }
		
        [HttpDelete]
        public async Task<IActionResult> Delete(EstoqueMovimentacaoDto dto)
        {
            var result = new HttpResult<EstoqueMovimentacaoDto>(this._logger, this._service);
            try
            {
                await this._service.Remove(dto);
                return result.ReturnCustomResponse(dto);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "EstoqueMovimentacao", dto);
            }
        }

        #endregion

		#region Others

        [HttpGet("DataItems")]
        public async Task<IActionResult> DataItems([FromQuery]EstoqueMovimentacaoFilter filters)
        {
            var result = new HttpResult<dynamic>(this._logger, this._service);
            try
            {
                var items = await this._service.GetDataItems(filters);
                return result.ReturnCustomResponse(items);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Assinatura", filters);
            }
        }

        #endregion

    }
}
