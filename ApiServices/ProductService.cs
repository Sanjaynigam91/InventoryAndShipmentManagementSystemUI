using InventoryManagementSystemUI.Common;
using InventoryManagementSystemUI.Model;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net.Security;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;

namespace InventoryManagementSystemUI.ApiServices
{
    public class ProductService
    {
        private readonly HttpClient httpClient;
        private string apiUrl = "";
        /// <summary>
        /// Constructor of Product Service
        /// </summary>
        public ProductService()
        {
            httpClient = new HttpClient();
            apiUrl = string.Empty;
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(
            (sender, certificate, chain, sslPolicyErrors) => true);
        }
        /// <summary>
        /// GET: Get all products
        /// </summary>
        /// <returns></returns>
        public async Task<ProductApiResponse> GetProductsAsync()
        {
            try
            {
                apiUrl = CommonCode.baseUrl + CommonCode.GetAllProducts;
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProductApiResponse>(responseBody);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        /// <summary>
        /// POST: Create a new product
        /// </summary>
        /// <param name="productRequest"></param>
        /// <returns></returns>
        public async Task<APIResponseModel> CreateProductAsync(ProductRequest productRequest)
        {
            try
            {
                apiUrl = CommonCode.baseUrl + CommonCode.AddNewProduct;
                string json = JsonConvert.SerializeObject(productRequest);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<APIResponseModel>(responseBody);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
        /// <summary>
        /// PUT: Update a product
        /// </summary>
        /// <param name="productRequest"></param>
        /// <returns></returns>
        public async Task<APIResponseModel> UpdateProductAsync(ProductRequest productRequest)
        {
            try
            {
                apiUrl = CommonCode.baseUrl + CommonCode.UpdateProduct;
                string json = JsonConvert.SerializeObject(productRequest);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PutAsync(apiUrl, content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<APIResponseModel>(responseBody);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }

        }
        /// <summary>
        /// DELETE: Delete a product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<APIResponseModel> DeleteProductAsync(int productId)
        {
            try
            {
                apiUrl = CommonCode.baseUrl + CommonCode.DeleteProduct + "?productId";
                HttpResponseMessage response = await httpClient.DeleteAsync($"{apiUrl}={productId}");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<APIResponseModel>(responseBody);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }

        }
        /// <summary>
        /// Get product details by productId
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<ProductModel> GetProductById(int productId)
        {
            try
            {
                apiUrl = CommonCode.baseUrl + CommonCode.GetProductById + "?productId";
                HttpResponseMessage response = await httpClient.GetAsync($"{apiUrl}={productId}");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProductModel>(responseBody);
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message}", ex);
            }

        }
        /// <summary>
        /// POST: Assign to shipment API
        /// </summary>
        /// <param name="shipmentRequest"></param>
        /// <returns></returns>
        public async Task<APIResponseModel> ProductAssignToShipment(ShipmentRequest shipmentRequest)
        {
            try
            {
                apiUrl = CommonCode.baseUrl + CommonCode.AssignToShipment;
                string json = JsonConvert.SerializeObject(shipmentRequest);
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<APIResponseModel>(responseBody);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }

        }
        /// <summary>
        /// GET: Get all Shipments History
        /// </summary>
        /// <returns></returns>
        public async Task<ProductShipmentResponse> GetShipmentsAsync()
        {
            try
            {
                apiUrl = CommonCode.baseUrl + CommonCode.GetAllShipments;
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProductShipmentResponse>(responseBody);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
