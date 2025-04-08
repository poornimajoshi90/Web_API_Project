using E_com.Model;
using E_com.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_com.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComController : ControllerBase
    {
        private IComServices _comServices;
         
        public ComController(IComServices comServices)
        {
            _comServices = comServices;
        }

        [HttpPost("AddUser")]
       
        public IActionResult AddUser([FromBody] User addnewuser)
        {
            var result = _comServices.AddUser(addnewuser);
            return Ok(result);
        }

        [HttpPut("EditUser")]
        public IActionResult EditUser([FromBody] User req)
        {
            var result = _comServices.EditUser(req);
            return Ok(result);
        }

        [HttpDelete("DeleteUser")]
        public IActionResult DeleteUser([FromBody] User req)
        {
            var result = _comServices.DeleteUser(req);
            return Ok(result);
        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct([FromBody] Products addnewproduct)
        {
            var result = _comServices.AddProduct(addnewproduct);
            return Ok(result);
        }

        [HttpPut("EditProduct")]
        public IActionResult EditProduct([FromBody] Products products)
        {
            var result = _comServices.EditProduct(products);
            return Ok(result);
        }

        [HttpDelete("DeleteProduct")]
         public IActionResult DeleteProduct([FromBody] Products delete)
        {
            var result = _comServices.DeleteProduct(delete);
            return Ok(result);
        }

        [HttpGet("GetProduct")]
        public IActionResult GetProduct()
        {
            var result = _comServices.GetProduct();
            return Ok(result);

        }

        [HttpGet("GetProductByUser")]
        public IActionResult GetProductByUser(int userid)
        {
            var result = _comServices.GetProductByUser(userid);
            return Ok(result);
        }

        
    }
}
