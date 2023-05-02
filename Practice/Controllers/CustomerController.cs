using Coravel.Scheduling.Schedule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practice.Interfaces;
using Practice.Models;
using System.Net;

namespace Practice.Controllers
{
    
    public class CustomerController : ControllerBase
    {
        private readonly ICustomer customer;

        public CustomerController(ICustomer customer)
        {
           this.customer = customer;
        }
        [HttpPost("Customer/GetCustomer")]
        public async Task<IActionResult> GetCustomers([FromBody] CommonFilterRequest request)
        {
            try
            {
                var response = await customer.GetCustomers(request);
                return Ok(new { ResponseData = response, ResponseCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost("Customer/CreateCustomer")]
        public async Task<IActionResult> CreateCustomers([FromBody] CustomerRequest request)
        {
            try
            {
                var response = await  customer.CreateCustomer(request);
                return Ok(new { ResponseData = "record added successfully", ResponseCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost("Customer/UpdateCustomer")]
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
        [HttpDelete("Customer/DeleteCustomer")]
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
        [HttpPost("Customer/BulkCreateCustomer")]
        public async Task<IActionResult> BulkCreateCustomer([FromBody] List<CustomerRequest> request)
        {
            try
            {
                var response = await customer.BulkCreateCustomers(request);
                return Ok(new { ResponseData = "record created successfully", ResponseCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet("Customer/GetPopupMessage")]

        public async Task<IActionResult> GetPopupMessage()
        {
            try
            {

                Scheduler obj = new Scheduler(null, null, null);
                obj.Schedule(() =>
                {
                    customer.PopupMessage();
                }).EveryFifteenSeconds();
                return Ok(new { ResponseData = "record created successfully", ResponseCode = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
    }

