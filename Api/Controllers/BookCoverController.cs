using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookCoverController : ControllerBase
    {


        // POST api/<BookCoverController>
        [HttpPost]
        public void Post([FromForm] CoverDTO CoverImage)
        {
            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(CoverImage.Image.FileName);
            var newName = guid + extension;
            var path = Path.Combine("wwwroot", "Images", newName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                CoverImage.Image.CopyTo(fileStream);
            }
        }


        public class CoverDTO
        {
            public IFormFile Image { get; set; }
        }
    }
}
