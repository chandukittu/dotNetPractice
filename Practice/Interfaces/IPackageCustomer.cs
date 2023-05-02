using Practice.Models;

namespace Practice.Interfaces
{
    public interface IPackageCustomer
    {
        Task<int> CreateCustomer(CustomerRequest request);
        Task<int> UpdateCustomer(CustomerRequest request);
        Task<int> DeleteCustomer(CustomerRequest request);
        Task<List<CustomerResponse>> GetCustomers();
        Task<int> CreateProduct(ProductRequest request);
        Task<int> DeleteProduct(ProductRequest request);
        Task<List<ProductResponse>> GetProduct();
        Task<int> UpdateProduct(ProductRequest request);
    }
}
