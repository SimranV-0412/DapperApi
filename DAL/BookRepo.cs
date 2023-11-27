using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using WebApiUsingDapper.DAL.Interface;
using WebApiUsingDapper.Models;

namespace WebApiUsingDapper.DAL
{
    public class BookRepo:IBook
    {
        private readonly string _connectionString;
        private readonly IConfiguration _config;

        public BookRepo(IConfiguration configuration)
        {
            _config = configuration;
            _connectionString = _config.GetConnectionString("Con");
        }
        public async Task<IEnumerable<BookStore>> GetAllBookDetail()
        {
            IEnumerable<BookStore> obj = null;
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    var procedure = "Get_books";
                    obj = await connection.QueryAsync<BookStore>(procedure, null, commandType: CommandType.StoredProcedure);
                }
                return obj.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
