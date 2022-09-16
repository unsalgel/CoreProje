using Core_Proje_Api.DAL.ApiContext;
using Core_Proje_Api.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Runtime.Intrinsics.Arm;

namespace Core_Proje_Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        Context c = new Context();
        [HttpGet]
        public IActionResult CategoryList()
        {
      
            return Ok(c.Categories.ToList());
       }
        [HttpGet("{id}")]
        public IActionResult CategoryGet(int id)
        {
            var value = c.Categories.Find(id);
            if (value==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(value);
            }
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
             
            c.Add(p);
            c.SaveChanges();
            return Created("",p);
        }
        [HttpDelete]
        public IActionResult CategoryDelete(int id)
        {
            var value = c.Categories.Find(id);
            if(value==null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(value);
                c.SaveChanges();
                return NoContent(); 
            }
           
        }
        [HttpPut]
        public IActionResult CategoryUpdate(Category p)
        {
            var value = c.Categories.Find(p.CategoryID);
            if (value==null)
            {
                return NotFound();
            }
            else
            {
                value.CategoryName=p.CategoryName;
                c.Update(value);
                c.SaveChanges();
                return NoContent();
            }
     
        }
    }
}
