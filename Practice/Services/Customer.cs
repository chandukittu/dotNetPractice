using Dapper;
using Dapper.Oracle;
using Oracle.ManagedDataAccess.Client;
using Practice.Interfaces;
using Practice.Models;
using System.Data;

namespace Practice.Services
{
    public class Customer : ICustomer
    {
        private readonly IDbConnection _dbConnection;
        private readonly IConfiguration _config;

        public Customer(IDbConnection dbConnection, IConfiguration config)
        {
            this._dbConnection = dbConnection;
            _config = config;
        }
       

        public async Task<int> DeleteCustomer(CustomerRequest request)
        {
            var queryParameters = new OracleDynamicParameters();
            queryParameters.Add(name: "pCustomer_Id", value: request.CustomerId, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);

            var Response = _dbConnection.QueryAsync<int>("Delete_Customer", queryParameters, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();
            return await Task.Run(() => Response);
        }

        public async Task<List<CustomerResponse>> GetCustomers(CommonFilterRequest request)
        {
            var queryParameters = new OracleDynamicParameters();
            queryParameters.Add(name: "page_No", value: request.PageNo, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
            queryParameters.Add(name: "page_Size", value: request.PageSize, dbType: OracleMappingType.Int32, direction: ParameterDirection.Input);
            queryParameters.Add(name: "search_Value", value: request.SearchValue, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);
            queryParameters.Add(name: "sort_Column", value: request.SortColumn, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);
            queryParameters.Add(name: "sort_Order", value: request.SortOrder, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);
            queryParameters.Add(name: "result_Set", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
            //queryParameters.Add(name: "total_Rows", dbType: OracleMappingType.Int32, direction: ParameterDirection.Output);

            var Response = _dbConnection.QueryAsync<CustomerResponse>("Get_Customers", queryParameters, commandType: CommandType.StoredProcedure).Result.ToList();
            return await Task.Run(() => Response);

        }

        public async Task<int> UpdateCustomer(CustomerRequest request)
        {
            var queryParameters = new OracleDynamicParameters();
            queryParameters.Add(name: "pCustomer_Id", value: request.CustomerId, dbType: OracleMappingType.Int64, direction: ParameterDirection.Input);
            queryParameters.Add(name: "pCustomer_Address", value: request.CustomerAddress, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);
            queryParameters.Add(name: "pCustomer_Name", value: request.CustomerName, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);
            queryParameters.Add(name: "pEmail_Id", value: request.EmailId, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);
            queryParameters.Add(name: "pMobile_No", value: request.MobileNo, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);
            var Response = _dbConnection.QueryAsync<int>("Update_Customer", queryParameters, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();
            return await Task.Run(() => Response);
        }
        public async Task<int> CreateCustomer(CustomerRequest request)
        {
            var queryParameters = new OracleDynamicParameters();
            queryParameters.Add(name: "pCustomer_Id", value: request.CustomerId, dbType: OracleMappingType.Int64, direction: ParameterDirection.Input);
            queryParameters.Add(name: "pCustomer_Address", value: request.CustomerAddress, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);
            queryParameters.Add(name: "pCustomer_Name", value: request.CustomerName, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);
            queryParameters.Add(name: "pEmail_Id", value: request.EmailId, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);
            queryParameters.Add(name: "pMobile_No", value: request.MobileNo, dbType: OracleMappingType.NVarchar2, direction: ParameterDirection.Input);
            var Response = _dbConnection.QueryAsync<int>("Create_Customer", queryParameters, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();
            return await Task.Run(() => Response);
        }

        public async Task<int> BulkCreateCustomers(List<CustomerRequest> request)
        {
            var queryParameters = new OracleDynamicParameters();
            queryParameters.Add(name: "customer_list", value: request, direction: ParameterDirection.Input);
            var Response = _dbConnection.QueryAsync<int>("Bulk_Create_Customers", queryParameters, commandType: CommandType.StoredProcedure).Result.FirstOrDefault();
            return await Task.Run(() => Response);
        }

        public string PopupMessage()
        {
            return "Hello Chandu";
        }
    }
}
