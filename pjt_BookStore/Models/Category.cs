using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pjt_BookStore.Models
{
    public class Category
    {
        

        public int Id { get; set; }

        public string CatName { get; set; }

        public string CatDesc { get; set; }

        public string Img { get; set; }

        public int? Status { get; set; }

        public int? Position { get; set; }

        public DateTime? CreatedAt { get; set; }

        public Category()
        {

        }
        public Category(int id, string catName, string catDesc, string img, int status, int position, DateTime? createdAt)
        {
            Id = id;
            CatName = catName;
            CatDesc = catDesc;
            Img = img;
            Status = status;
            Position = position;
            CreatedAt = createdAt;

        }

  
    }
}