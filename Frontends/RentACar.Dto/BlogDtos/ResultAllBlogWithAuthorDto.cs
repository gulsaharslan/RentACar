﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Dto.BlogDtos
{
    public class ResultAllBlogWithAuthorDto
    {
        public int blogID { get; set; }
        public string title { get; set; }
        public string authorName { get; set; }
        public object categoryName { get; set; }
        public int authorID { get; set; }
        public string coverImageUrl { get; set; }
        public DateTime createdDate { get; set; }
        public int categoryID { get; set; }
        public string description { get; set; }
        public string AuthorDescription { get; set; }
        public string AuthorImageUrl { get; set; }

    }
}
