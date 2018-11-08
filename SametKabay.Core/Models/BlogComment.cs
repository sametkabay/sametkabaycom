using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SametKabay.Core.Interface;

namespace SametKabay.Core.Models
{
    public class BlogComment : IBaseEntity
    {
        #region Interface Property

        [Key]
        public int Id { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public DateTime? DeletionDate { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

        [DefaultValue(false)]
        public bool IsActive { get; set; }

        public int? ParentId { get; set; }

        #endregion Interface


        #region Special Property


        [MinLength(4)]
        [MaxLength(1024)]
        public string Text { get; set; }

        #endregion


        #region RELATIONSHIP

        public virtual User CreatorUser { get; set; }

        public User ActivatedUser { get; set; }
        public virtual User ModifierUser { get; set; }
        public virtual User DeleterUser { get; set; }

        public virtual BlogComment Parent { get; set; }

        public ICollection<BlogComment> Children { get; set; }

        #endregion
    }
}
