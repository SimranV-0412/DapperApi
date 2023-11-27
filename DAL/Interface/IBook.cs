using WebApiUsingDapper.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;


namespace WebApiUsingDapper.DAL.Interface
{
    public interface IBook
    {
        public Task<IEnumerable<BookStore>> GetAllBookDetail();
    }
}
