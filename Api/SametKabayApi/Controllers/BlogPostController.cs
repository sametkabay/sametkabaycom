using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SametKabay.Application;
using SametKabay.Application.BlogPostServices;
using SametKabayApi.Model;

namespace SametKabayApi.Controllers
{
    /// <summary>
    /// BlogPost
    /// </summary>
    [Route("[controller]/[action]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostAppService _blogPostAppService;

        /// <summary>
        /// Repository
        /// </summary>
        /// <param name="blogPostAppService"></param>
        public BlogPostController(IBlogPostAppService blogPostAppService)
        {
            _blogPostAppService = blogPostAppService;
        }

        /// <summary>
        /// Get All by BlogPost
        /// </summary>
        /// <param name="input"></param>
        /// <returns>BlogPosts</returns>
        [HttpGet]
        public IActionResult GetAll([FromQuery]PagedAndSortedInputDto input)
        {
            var entity = _blogPostAppService.GetAll(input);

            return Ok(entity);

        }

        /// <summary>
        /// GetById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetById(int id)
        {
            var token = Request.Headers["Authorization"].ToString();
            TokenValidator validator = new TokenValidator();
            string resultValid = validator.IsValid(token);
            var entity = _blogPostAppService.GetById(id, Convert.ToInt32(resultValid));

            return Ok(entity);

        }

        /// <summary>
        /// GetByTitle
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetByTitle(string title)
        {
            var token = Request.Headers["Authorization"].ToString();
            TokenValidator validator = new TokenValidator();
            string resultValid = validator.IsValid(token);
            var entity = _blogPostAppService.GetByTitle(title, Convert.ToInt32(resultValid));
            return Ok(entity);

        }

        /// <summary>
        /// Random Post
        /// Max Value = 20
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Random(int count)
        {
            var entity = _blogPostAppService.Random(count);

            return Ok(entity);

        }


    }
}