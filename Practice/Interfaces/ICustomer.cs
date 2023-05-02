using Practice.Models;

namespace Practice.Interfaces
{
    public interface ICustomer
    {
          Task<int>   CreateCustomer(CustomerRequest request);
         Task<int> UpdateCustomer(CustomerRequest request);
         Task<int> DeleteCustomer(CustomerRequest request);
         Task<List<CustomerResponse>> GetCustomers(CommonFilterRequest request);
        Task<int> BulkCreateCustomers(List<CustomerRequest> request);
        string PopupMessage();
    }
}
