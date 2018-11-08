using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SametKabay.Application.BlogCategoryService;

namespace SametKabayApi.Controllers
{
    /// <summary>
    /// BlogCategory
    /// </summary>
    [Route("[controller]/[action]")]
    [ApiController]
    public class BlogCategoryController : ControllerBase
    {
        private readonly IBlogCategoryAppService _blogCategoryAppService;
        /// <summary>
        /// BlogCategory Ctor
        /// </summary>
        /// <param name="blogCategoryAppService"></param>
        public BlogCategoryController(IBlogCategoryAppService blogCategoryAppService)
        {
            _blogCategoryAppService = blogCategoryAppService;
        }
        /// <summary>
        /// Get All by BlogCategories
        /// </summary>
        /// <returns>BlogPosts</returns>
        [HttpGet]
        public IActionResult GetCategories()
        {
            var entity = _blogCategoryAppService.GetCategories();

            return Ok(entity);

        }
        /// <summary>
        /// GetCategoriesDetail
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetCategoriesDetail(int? id, string name)
        {
            var entity = _blogCategoryAppService.GetCategoriesDetail(id, name);

            return Ok(entity);

        }
    }
}