using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Asp.Net_Core_WebApi_Frank.Models;
using Asp.Net_Core_WebApi_Frank.Models.Repository;
using Asp.Net_Core_WebApi_Frank.Models.DataManager;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Asp.Net_Core_WebApi_Frank.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly DatabaseContext _context;
        private readonly IDataRepository<Category> _dataRepository;

        //public CategoryController(DatabaseContext context)
        //{
        //    this._context = context;

        //    if (0 == this._context.Categories.Count())
        //    {
        //        this._context.Categories.Add(new Category { CategoryName = "First Category" });
        //        this._context.SaveChanges();
        //    }

        //}

        public CategoryController(IDataRepository<Category> dataRepository)
        {
            this._dataRepository = dataRepository;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAsync()
        {
            Task <IEnumerable<Category>> Categories = _dataRepository.GetAll();

            return Ok(Categories);

            //return await this._context.Categories.Include(x => x.Products).ToListAsync();

            //this._context.ChangeTracker.LazyLoadingEnabled = false;
            //var Category = this._context.Categories.ToList();
      
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> GetAsync(int id)
        {
            this._context.ChangeTracker.LazyLoadingEnabled = false;
            var CategoryItem = await this._context.Categories.FindAsync(id);

            if (null == CategoryItem)
            {
                return NotFound();
            }

            //return CategoryItem;
            //this._context.ChangeTracker.LazyLoadingEnabled = false;
            this._context.Entry(CategoryItem).Collection(p => p.Products).Load();

            return CategoryItem;

        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<Category>> Post([FromBody]Category item)
        {
            this._context.Categories.Add(item);
            await this._context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAsync), new { id = item.CategoryID }, item);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody]Category item)
        {
            if (id != item.CategoryID)
            {
                return BadRequest();
            }

            this._context.Entry(item).State = EntityState.Modified;
            await this._context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var CategoryItem = await this._context.Categories.FindAsync(id);

            if (null == CategoryItem)
            {
                return NotFound();
            }

            this._context.Categories.Remove(CategoryItem);
            await this._context.SaveChangesAsync();

            return NoContent();
        }
    }
}
