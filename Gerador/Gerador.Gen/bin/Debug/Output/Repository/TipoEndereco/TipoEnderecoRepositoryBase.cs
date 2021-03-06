using Common.Orm;
using superacrm.ui.Core.Filters;
using superacrm.ui.Core.Data.Context;
using superacrm.ui.Core.Data.Model;
using System.Linq;
using System.Collections.Generic;

namespace superacrm.ui.Core.Data.Repository
{
    public class TipoEnderecoRepositoryBase : Repository<TipoEndereco>
    {
        public TipoEnderecoRepositoryBase(DbContextCore ctx) : base(ctx)
        {

        }
				
		public virtual IEnumerable<dynamic> GetDataItems(TipoEnderecoFilter filters)
        {
            var querybase = this.GetAll();
            return this.GetAll().Select(_ => new { Id = _.TipoEnderecoId, Name = _.Nome });
        }

        protected IQueryable<TipoEndereco> SimpleFilters(TipoEnderecoFilter filters, IQueryable<TipoEndereco> queryBase)
        {
			var queryFilter = queryBase;
            
            if (filters.TipoEnderecoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.TipoEnderecoId == filters.TipoEnderecoId);
			}
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_ => _.Nome.Contains(filters.Nome));
			}


            return queryFilter;
        }
        
    }
}
