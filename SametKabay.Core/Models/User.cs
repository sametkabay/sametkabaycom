using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SametKabay.Core.Interface;

namespace SametKabay.Core.Models
{
    public class User : IBaseEntity
    {
        #region Interface Property

        [Key]
        public int Id { get; set; }

        public User CreatorUser { get; set; }
        public DateTime CreationDate { get; set; }
        public User ModifierUser { get; set; }
        public DateTime? ModifyDate { get; set; }
        public User DeleterUser { get; set; }
        public DateTime? DeletionDate { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        public User ActivatedUser { get; set; }

        [DefaultValue(false)]
        public bool IsActive { get; set; }

        #endregion Interface


        #region Special Property

        [Required]
        [MinLength(2)]
        [MaxLength(32)]
        [Index("UserName", IsClustered = true, IsUnique = true)]
        public string UserName { get; set; }

        public string PasswordSalt { get; set; }

        public string PasswordHash { get; set; }

        [Url]
        [MaxLength(1024)]
        public string PictureUrl { get; set; }

        [MinLength(2)]
        [MaxLength(32)]
        public string Name { get; set; }

        [MinLength(2)]
        [MaxLength(32)]
        public string Surname { get; set; }

        [MaxLength(512)]
        public string About { get; set; }

        [EmailAddress]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        [DefaultValue(false)]
        public bool IsAdmin { get; set; }

        #endregion


        #region RELATIONSHIP

        public virtual User ActivatingUser { get; set; }
        public ICollection<User> ActivatingUsers { get; set; }

        //public ICollection<BlogPost> CreatingPosts { get; set; }

        //public ICollection<BlogPost> ModifyingPosts { get; set; }

        //public ICollection<BlogPost> DeletingPosts { get; set; }

        #endregion

    }
}
