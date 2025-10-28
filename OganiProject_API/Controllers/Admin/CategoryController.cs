using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Dtos.Admin.CategoryDtos;
using Service.Services.IService;

namespace OganiProject_API.Controllers.Admin
{

    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CategoryCreateDto request)
        {
            await _categoryService.CreateAsync(request);

            return CreatedAtAction(nameof(Create), "Created success");
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromForm] CategoryEditDto request)
        {
            await _categoryService.EditAsync(id, request);

            return Ok();
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryService.GetAllAsync());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            await _categoryService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            return Ok(await _categoryService.GetByIdAsync(id));
        }


        //[HttpGet]
        //public async Task<IActionResult> GetCategoryProductCounts()
        //{
        //    var categoryCounts = await _categoryService.GetCategoryProductCountsAsync();
        //    return Ok(categoryCounts);
        //}
    }
}
