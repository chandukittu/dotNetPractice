using Dapper;
using Dapper.Oracle;
using Practice.Interfaces;
using Practice.Models;
using System.Data;

namespace Practice.Services
{
    public class PackageCustomer : IPackageCustomer
    {
        private readonly IDbConnection _dbConnection;
        private readonly IConfiguration _config;
        public PackageCustomer(IDbConnection dbConnection, IConfiguration config)
        {
            this._dbConnection = dbConnection;
            _config = config;
        }
        public async Task<int> CreateCustomer(CustomerRequest request)
        {
            var queryParameters = new OracleDynamicParameters();
            queryParameters.Add(name: "c_id", value: request.CustomerId, dbType: OracleMappingType.Int64, direction: ParameterDirection.Input);
            queryParameters.Add(name: "c_address", value: request.CustomerAddress, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);
            queryParameters.Add(name: "c_name", value: request.CustomerName, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);
            queryParameters.Add(name: "c_email", value: request.EmailId, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);
            queryParameters.Add(name: "c_mobileno", value: request.MobileNo, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);
            var Response = _dbConnection.QueryAsync<int>("customers_package.addCustomer", queryParameters, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();
            return await Task.Run(() => Response);
        }

        public async Task<int> DeleteCustomer(CustomerRequest request)
        {
            var queryParameters = new OracleDynamicParameters();
            queryParameters.Add(name: "c_id", value: request.CustomerId, dbType: OracleMappingType.Int64, direction: ParameterDirection.Input);
            var Response = _dbConnection.QueryAsync<int>("customers_package.deleteCustomer", queryParameters, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();
            return await Task.Run(() => Response);
        }

        public async Task<List<CustomerResponse>> GetCustomers()
        {
            var queryParameters = new OracleDynamicParameters();
            queryParameters.Add(name: "result_Set", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            //queryParameters.Add(name: "total_Rows", dbType: OracleMappingType.Int32, direction: ParameterDirection.Output);
            var Response = _dbConnection.QueryAsync<CustomerResponse>("customers_package.listCustomers", queryParameters, commandType: CommandType.StoredProcedure).Result.ToList();
            return await Task.Run(() => Response);
        }

        public async Task<int> UpdateCustomer(CustomerRequest request)
        {
            var queryParameters = new OracleDynamicParameters();
            queryParameters.Add(name: "c_id", value: request.CustomerId, dbType: OracleMappingType.Int64, direction: ParameterDirection.Input);
            queryParameters.Add(name: "c_address", value: request.CustomerAddress, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);
            queryParameters.Add(name: "c_name", value: request.CustomerName, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);
            queryParameters.Add(name: "c_email", value: request.EmailId, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);
            queryParameters.Add(name: "c_mobileno", value: request.MobileNo, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);
            var Response = _dbConnection.QueryAsync<int>("customers_package.updateCustomer", queryParameters, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();
            return await Task.Run(() => Response);
        }
        public async Task<int> CreateProduct(ProductRequest request)
        {
            var queryParameters = new OracleDynamicParameters();
            queryParameters.Add(name: "p_id", value: request.ProductId, dbType: OracleMappingType.Int64, direction: ParameterDirection.Input);
            queryParameters.Add(name: "p_product_name", value: request.ProductName, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);
            queryParameters.Add(name: "p_attributes", value: request.Attribute, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);
            var Response = _dbConnection.QueryAsync<int>("PRODUCT_PACKAGE.addProduct", queryParameters, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();
            return await Task.Run(() => Response);
        }

        public async Task<int> DeleteProduct(ProductRequest request)
        {
            var queryParameters = new OracleDynamicParameters();
            queryParameters.Add(name: "p_id", value: request.ProductId, dbType: OracleMappingType.Int64, direction: ParameterDirection.Input);
            var Response = _dbConnection.QueryAsync<int>("PRODUCT_PACKAGE.deleteProduct", queryParameters, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();
            return await Task.Run(() => Response);
        }

        public async Task<List<ProductResponse>> GetProduct()
        {
            var queryParameters = new OracleDynamicParameters();
            queryParameters.Add(name: "result_Set", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            //queryParameters.Add(name: "total_Rows", dbType: OracleMappingType.Int32, direction: ParameterDirection.Output);
            var Response = _dbConnection.QueryAsync<ProductResponse>("PRODUCT_PACKAGE.listProducts", queryParameters, commandType: CommandType.StoredProcedure).Result.ToList();
            return await Task.Run(() => Response);
        }

        public async Task<int> UpdateProduct(ProductRequest request)
        {
            var queryParameters = new OracleDynamicParameters();
            queryParameters.Add(name: "p_id", value: request.ProductId, dbType: OracleMappingType.Int64, direction: ParameterDirection.Input);
            queryParameters.Add(name: "p_product_name", value: request.ProductName, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);
            queryParameters.Add(name: "p_attributes", value: request.Attribute, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);
            var Response = _dbConnection.QueryAsync<int>("PRODUCT_PACKAGE.updateProduct", queryParameters, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();
            return await Task.Run(() => Response);
        }
    }
}
