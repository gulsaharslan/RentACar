using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Dto.CommentDtos
{
    public class CreateCommentDto
    {
        public string name { get; set; }
        public DateTime createdDate { get; set; }
        public string description { get; set; }
        public string email { get; set; }
        public int blogID { get; set; }

    }
}
