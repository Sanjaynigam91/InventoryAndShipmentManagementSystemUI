using System;
using System.Collections.Generic;

namespace InventoryManagementSystemUI.Model
{
    public class ProductShipmentResponse
    {
        public int statusCode { get; set; }
        public bool status { get; set; }
        public string responseMessage { get; set; }
        public List<ProductShipment> data { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class ProductShipment
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public int shipmentId { get; set; }
        public string shipmentName { get; set; }
        public DateTime shipmentDate { get; set; }
        public int quantity { get; set; }
    }

}
