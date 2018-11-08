using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SametKabay.Core.Models
{
    public class BlogPostCategory
    {

        #region Interface Property

        [Key]
        public int Id { get; set; }


        #endregion Interface


        #region Special Property

        public int PostId { get; set; }

        public int CategoryId { get; set; }

        #endregion


        #region RELATIONSHIP

        public virtual BlogPost Post { get; set; }
        public virtual BlogCategory Category { get; set; }


        #endregion

    }
}
