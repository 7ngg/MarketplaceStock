using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockDataLayer.Models
{
    public class OrderProduct
    {
        #region OrderId
        public int OrderId { get; set; }
        public Order Order { get; set; }
        #endregion

        #region ProductId
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
        #endregion
    }
}
