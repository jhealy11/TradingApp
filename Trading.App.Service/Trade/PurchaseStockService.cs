using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trading.App.Core.Trade.Service;
using Trading.App.Core.Trade.Repository;

namespace Trading.App.Service.Trade
{
    public sealed class PurchaseStockService : IPurchaseStockService
    {
        //private readonly IStockValidator _stockValidator;
        private readonly IPurchaseStockRepository _purchaseStockRepository;

        public PurchaseStockService(IPurchaseStockRepository purchaseStockRepository /*, IStockValidator stockValidator*/)
        {
            _purchaseStockRepository = purchaseStockRepository;
            //_stockValidator = stockValidator;
        }

        public void PurchaseStock(Core.Trade.Trade trade)
        {
            throw new NotImplementedException();
        }
    }
}
