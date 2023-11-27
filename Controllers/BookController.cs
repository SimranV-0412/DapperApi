using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiUsingDapper.DAL.Interface;
using WebApiUsingDapper.Models;

namespace WebApiUsingDapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public readonly IBook _Book;
        public BookController(IBook Book)
        {
            _Book = Book;
        }

        [HttpGet]
        [Route("GetAllBookDetail")]

        public async Task<IActionResult> GetAllBookDetail()
        {
            IEnumerable<BookStore> obj = null;
            try
            {
                obj = await _Book.GetAllBookDetail();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(obj);
        }
    }
}
