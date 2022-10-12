using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace pjt_BookStore.Models
{
    public class CategoryImpl : ICategoryReference
    {
        SqlCommand comm;
        SqlConnection conn;

        public CategoryImpl()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["mydb"].ConnectionString);
            comm = new SqlCommand();
        }
        public List<Category> GetAllCategory()
        {
            List<Category> list = new List<Category>();
            comm.CommandText = "select * from  category  where status = 1 order by position;";
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["CategoryId"]);
                string catName = reader["CategoryName"].ToString();
                string catDesc = reader["Description"].ToString();
                string img = reader["Image"].ToString();
                int status = Convert.ToInt32(reader["Status"]);
                int position = Convert.ToInt32(reader["Position"]);
                DateTime createdAt = Convert.ToDateTime(reader["CreatedAt"]);
                list.Add(new Category(id,catName,catDesc,img,status,position,createdAt));
            }
            conn.Close();
            return list;

        }
        public Category GetCategoryByID(int catId)
        {
            Category cat = new Category();
            comm.CommandText = "select * from Category where CategoryId = " + catId;
            comm.Connection = conn;
            conn.Open();
            SqlDataReader reader = comm.ExecuteReader();
            while (reader.Read())
            {
                int id = Convert.ToInt32(reader["CategoryId"]);
                string catName = reader["CategoryName"].ToString();
                string catDesc = reader["Description"].ToString();
                string img = reader["Image"].ToString();
                int status = Convert.ToInt32(reader["CategoryId"]);
                int position = Convert.ToInt32(reader["Position"]);
                DateTime createdAt = Convert.ToDateTime(reader["CreatedAt"]);
                cat = new Category(id, catName, catDesc, img, status, position, createdAt);
               // return cat;
                
            }
            conn.Close();
            //Category cat = new Category(id, catName, catDesc, img, status, position, createdAt);
            return cat;
        }
        public Category AddCategory(Category category)
        {
            comm.CommandText = $"insert into Category values ('{category.CatName}','{category.CatDesc}','{category.Img}',{category.Status},{category.Position},'{category.CreatedAt}')";
       
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
            if (row > 0)
            {
                return category;
            }
            else
            {
                return null;
            }
        
        
        }

        public void DeleteCategory(int catId)
        {
            comm.CommandText = "delete from Category where CategoryId = " + catId;
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }

        public void UpdateCategory(Category category)
        {
            //throw new NotImplementedException();
            comm.CommandText = $"update category set CategoryName = '{category.CatName}',Description='{category.CatDesc}',Image = '{category.Img}',Status = {category.Status},Position={category.Position},CreatedAt='{category.CreatedAt}' where CategoryId = {category.Id}";
            comm.Connection = conn;
            conn.Open();
            int row = comm.ExecuteNonQuery();
            conn.Close();
        }
    }
}