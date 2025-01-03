using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystemUI.Model
{
    public class ProductApiResponse
    {
        public int statusCode { get; set; }
        public bool status { get; set; }
        public string responseMessage { get; set; }
        public List<ProductResponse> data { get; set; }     
    }

    public class ProductResponse
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public int productId { get; set; }
        public string productName { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public DateTime createdDate { get; set; }
        public string createdBy { get; set; }
    }
}
