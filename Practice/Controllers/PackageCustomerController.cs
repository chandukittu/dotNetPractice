using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.Interfaces;
using Practice.Models;
using System.Net;

namespace Practice.Controllers
{

    public class PackageCustomerController : ControllerBase
    {
        private readonly IPackageCustomer customer;

        public PackageCustomerController(IPackageCustomer customer)
        {
            this.customer = customer;
        }
        [HttpGet("PCustomer/PGetCustomer")]
        public async Task<IActionResult> GetCustomers()
        {
            try
            {
                var response = await customer.GetCustomers();
                return Ok(new { ResponseData = response, ResponseCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost("PCustomer/PCreateCustomer")]
        public async Task<IActionResult> CreateCustomers([FromBody] CustomerRequest request)
        {
            try
            {
                var response = await customer.CreateCustomer(request);
                return Ok(new { ResponseData = "record added successfully", ResponseCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost("PCustomer/PUpdateCustomer")]
        public async Task<IActionResult> UpdateCustomers([FromBody] CustomerRequest request)
        {
            try
            {
                var response = await customer.UpdateCustomer(request);
                return Ok(new { ResponseData = "record updated successfully", ResponseCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpDelete("PCustomer/PDeleteCustomer")]
        public async Task<IActionResult> DeleteCustomers([FromBody] CustomerRequest request)
        {
            try
            {
                var response = await customer.DeleteCustomer(request);
                return Ok(new { ResponseData = "record deleted successfully", ResponseCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        //JSON 
        [HttpGet("Product/GetProducts")]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var response = await customer.GetProduct();
                return Ok(new { ResponseData = response, ResponseCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost("Product/CreateProduct")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductRequest request)
        {
            try
            {
                var response = await customer.CreateProduct(request);
                return Ok(new { ResponseData = "record added successfully", ResponseCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost("Product/UpdateProduct")]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductRequest request)
        {
            try
            {
                var response = await customer.UpdateProduct(request);
                return Ok(new { ResponseData = "record updated successfully", ResponseCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpDelete("Product/DeleteProduct")]
        public async Task<IActionResult> DeleteProduct([FromBody] ProductRequest request)
        {
            try
            {
                var response = await customer.DeleteProduct(request);
                return Ok(new { ResponseData = "record deleted successfully", ResponseCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }


    }
}
    