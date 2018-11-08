using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SametKabay.Application.BlogPostServices.Dto;
using SametKabay.Application.Extensions;
using SametKabay.Core.Models;
using SametKabay.Core.Repositories.BlogPost;
using Serilog;

namespace SametKabay.Application.BlogPostServices
{
    public class BlogPostAppService : IBlogPostAppService
    {
        private readonly IBlogPostRepository _blogPostRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public BlogPostAppService(IBlogPostRepository blogPostRepository, IMapper mapper, ILogger logger)
        {
            _blogPostRepository = blogPostRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public List<BlogPostGetAllOutputModel> GetAll(PagedAndSortedInputDto input)
        {
            var model = _blogPostRepository.GetAll()
                .Include(p => p.Tags)
                .Include(p => p.PostCategory).ThenInclude(p => p.Category)
                .Include(p => p.CreatorUser)
                .WhereIsDeleted(false)
                .WhereIsActive(true)
                .Select(p => new BlogPostGetAllOutputModel
                {
                    Id = p.Id,
                    CreationDate = p.CreationDate,
                    Title = p.Title,
                    SafeTitle = p.SafeTitle,
                    Detail = p.Detail,
                    PictureUrl = p.PictureUrl,
                    Categories = p.PostCategory
                        .Where(c => c.Category.IsActive & !c.Category.IsDeleted)
                        .Select(c => new Category
                        {
                            Id = c.Category.Id,
                            SafeName = c.Category.SafeName,
                            Name = c.Category.Name,
                            PictureUrl = c.Category.PictureUrl
                        }).ToList(),
                    CreatorUser = new CreatorUser
                    {
                        Id = p.CreatorUser.Id,
                        UserName = p.CreatorUser.UserName,
                        Name = p.CreatorUser.Name,
                        Surname = p.CreatorUser.Surname,
                        PictureUrl = p.CreatorUser.PictureUrl
                    },
                    Tags = p.Tags
                        .Where(t => !t.IsDeleted)
                        .Select(t => new Tag
                        {
                            Text = t.Text
                        }).ToList(),
                })
                .ApplyCategoryFilter(input.Categories)
                .ApplyTagFilter(input.Tags)
                .OrderByFilter(input.Sorting)
                .Skip((input.PageNumber - 1) * input.PageSize)
                .Take(input.PageSize)
                .ToList();

            //var outputModel = _mapper.Map<List<BlogPostGetAllOutputModel>>(model);
            _logger.Information("GetAllBlogPost{0}", model); //TODO:Refactored
            return model;
        }

        public BlogPostOutputModel GetById(int id, int userId)
        {
            var model = _blogPostRepository.GetAll()
                .Include(p => p.Tags)
                .Include(p => p.PostCategory).ThenInclude(p => p.Category)
                .Include(p => p.CreatorUser)
                .Include(p => p.Comments)
                .WhereIsDeleted(false)
                .WhereIsActive(true)
                .Where(p => p.Id == id)
                .Select(p => new BlogPostOutputModel
                {
                    Id = p.Id,
                    CreationDate = p.CreationDate,
                    Title = p.Title,
                    SafeTitle = p.SafeTitle,
                    Detail = p.Detail,
                    PictureUrl = p.PictureUrl,
                    Categories = p.PostCategory
                        .Where(category => category.Category.IsDeleted == false)
                        .Select(category => new Category
                        {
                            Id = category.Category.Id,
                            SafeName = category.Category.SafeName,
                            Name = category.Category.Name,
                            PictureUrl = category.Category.PictureUrl
                        }).ToList(),
                    CreatorUser = new CreatorUser
                    {
                        Id = p.CreatorUser.Id,
                        UserName = p.CreatorUser.UserName,
                        Name = p.CreatorUser.Name,
                        Surname = p.CreatorUser.Surname,
                        PictureUrl = p.CreatorUser.PictureUrl

                    },
                    Tags = p.Tags
                        .Where(tag => tag.IsDeleted == false)
                        .Select(tag => new Tag
                        {
                            Text = tag.Text
                        }).ToList(),
                    Comments = p.Comments
                        .Where(comment => comment.IsDeleted == false && comment.ParentId == null && comment.IsActive)
                        .Select(comment => new Comment
                        {
                            Id = comment.Id,
                            CreationDate = comment.CreationDate,
                            IsOwnComment = IsEqual(userId, comment.CreatorUser.Id),
                            Text = comment.Text,
                            CreatorUser = new CreatorUser
                            {
                                Id = comment.CreatorUser.Id,
                                UserName = comment.CreatorUser.UserName,
                                Name = comment.CreatorUser.Name,
                                Surname = comment.CreatorUser.Surname,
                                PictureUrl = comment.CreatorUser.PictureUrl
                            },
                            Children = comment.Children
                                .Where(child => child.IsDeleted == false && comment.IsActive)
                                .Select(child => new Comment
                                {
                                    Id = child.Id,
                                    CreationDate = child.CreationDate,
                                    IsOwnComment = IsEqual(userId,child.CreatorUser.Id),
                                    Text = child.Text,
                                    CreatorUser = new CreatorUser
                                    {
                                        Id = child.CreatorUser.Id,
                                        UserName = child.CreatorUser.UserName,
                                        Name = child.CreatorUser.Name,
                                        Surname = child.CreatorUser.Surname,
                                        PictureUrl = child.CreatorUser.PictureUrl
                                    },
                                }).ToList(),
                        }).ToList(),
                }).FirstOrDefault();
            //var outputModel = _mapper.Map<BlogPostOutputModel>(model);
            _logger.Information("GetAllBlogPost{0}", model); //TODO:Refactored
            return model;
        }

        public BlogPostOutputModel GetByTitle(string safeTitle, int userId)
        {
            var model = _blogPostRepository.GetAll()
                .Include(p => p.Tags)
                .Include(p => p.PostCategory).ThenInclude(p => p.Category)
                .Include(p => p.CreatorUser)
                .Include(p => p.Comments)
                .WhereIsDeleted(false)
                .WhereIsActive(true)
                .Where(p => p.SafeTitle == safeTitle)
                .Select(p => new BlogPostOutputModel
                {
                    Id = p.Id,
                    CreationDate = p.CreationDate,
                    Title = p.Title,
                    SafeTitle = p.SafeTitle,
                    Detail = p.Detail,
                    PictureUrl = p.PictureUrl,
                    Categories = p.PostCategory
                        .Where(category => category.Category.IsDeleted == false)
                        .Select(category => new Category
                        {
                            Id = category.Category.Id,
                            SafeName = category.Category.SafeName,
                            Name = category.Category.Name,
                            PictureUrl = category.Category.PictureUrl
                        }).ToList(),
                    CreatorUser = new CreatorUser
                    {
                        Id = p.CreatorUser.Id,
                        UserName = p.CreatorUser.UserName,
                        Name = p.CreatorUser.Name,
                        Surname = p.CreatorUser.Surname,
                        PictureUrl = p.CreatorUser.PictureUrl

                    },
                    Tags = p.Tags
                        .Where(tag => tag.IsDeleted == false)
                        .Select(tag => new Tag
                        {
                            Text = tag.Text
                        }).ToList(),
                    Comments = p.Comments
                        .Where(comment => comment.IsDeleted == false && comment.ParentId == null && comment.IsActive)
                        .Select(comment => new Comment
                        {
                            Id = comment.Id,
                            CreationDate = comment.CreationDate,
                            IsOwnComment = IsEqual(userId, comment.CreatorUser.Id),
                            Text = comment.Text,
                            CreatorUser = new CreatorUser
                            {
                                Id = comment.CreatorUser.Id,
                                UserName = comment.CreatorUser.UserName,
                                Name = comment.CreatorUser.Name,
                                Surname = comment.CreatorUser.Surname,
                                PictureUrl = comment.CreatorUser.PictureUrl
                            },
                            Children = comment.Children
                                .Where(child => child.IsDeleted == false && comment.IsActive)
                                .Select(child => new Comment
                                {
                                    Id = child.Id,
                                    CreationDate = child.CreationDate,
                                    IsOwnComment = IsEqual(userId, child.CreatorUser.Id),
                                    Text = child.Text,
                                    CreatorUser = new CreatorUser
                                    {
                                        Id = child.CreatorUser.Id,
                                        UserName = child.CreatorUser.UserName,
                                        Name = child.CreatorUser.Name,
                                        Surname = child.CreatorUser.Surname,
                                        PictureUrl = child.CreatorUser.PictureUrl
                                    },
                                }).ToList(),
                        }).ToList(),
                }).FirstOrDefault();
            //var outputModel = _mapper.Map<BlogPostOutputModel>(model);
            _logger.Information("GetAllBlogPost{0}", model); //TODO:Refactored
            return model;
        }

        public List<BlogPostPreviewOutputModel> Random(int count)
        {
            if (count > 20)
                count = 20;

            var model = _blogPostRepository.GetAll()
                .Where(p => p.IsDeleted == false && p.IsActive)
                .OrderBy(p => Guid.NewGuid()).Take(count)
                .Select(p => new BlogPostPreviewOutputModel
                {
                    Id = p.Id,
                    Title = p.Title,
                    SafeTitle = p.SafeTitle,
                    PictureUrl = p.PictureUrl,
                    CreationDate = p.CreationDate
                }).ToList();
            return model;
        }

        public void InsertBlogPost(BlogPostInputModel input)
        {
            var model = _mapper.Map<BlogPost>(input);
            _blogPostRepository.Insert(model);
        }


        private bool IsEqual(int userId, int commentUserId)
        {
            if (userId == 0) return false;
            return userId == commentUserId;
        }
    }

}
