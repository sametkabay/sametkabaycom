using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using SametKabay.Core.Models;

namespace SametKabay.Application.BlogPostServices.Dto
{

    public class BlogPostOutputModel
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Title { get; set; }
        public string SafeTitle { get; set; }
        public string Detail { get; set; }
        public string Text { get; set; }
        public object PictureUrl { get; set; }
        public List<Category> Categories { get; set; }
        public CreatorUser  CreatorUser { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Comment> Comments { get; set; }
    }

    public class CreatorUser
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public object PictureUrl { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SafeName { get; set; }
        public object PictureUrl { get; set; }
    }
    
    public class Tag
    {
        public string Text { get; set; }
    }
    
    public class Comment
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public bool IsOwnComment { get; set; }
        public string Text { get; set; }
        public CreatorUser CreatorUser { get; set; }
        public List<Comment> Children { get; set; }
    }
    
}
