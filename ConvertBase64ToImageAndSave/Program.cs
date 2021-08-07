using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using ConvertBase64ToImageAndSave.Models;
using Dapper;
using System.Data.SqlClient;
using System.Threading;

namespace ConvertBase64ToImageAndSave
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-QOLDRIG;database=ELPROCMS;Integrated Security=True;MultipleActiveResultSets=True;");
            string sql = "select * from ProductMaster";

            using (conn)
            {
                conn.Open();
                var ProductMasterList = (List<ProductMaster>)conn.Query<ProductMaster>(sql);
                foreach (ProductMaster c in ProductMasterList)
                {

                    Console.WriteLine(c.ID + "_" + c.ImageName);
                    var response = SaveImage(c.image, c.ImageName);
                    if(response != null)
                    {
                        UpdateImageName(response, c.ID);
                        Console.WriteLine(response);
                    }
                }
                Console.WriteLine("Finised");
                Console.ReadLine();
            }
        }

        public static string SaveImage(string ImgStr, string imageName)
        {
            try
            {
                Thread.Sleep(500);
                string GeneratefileName = null;
                string imgPath = null;
                String path = @"C:\Users\Sagar\Desktop\ProductImages"; //HttpContent.Current.Server.MapPath("~/ImageStorage"); //Path

                //Check if directory exist
                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
                }

                //string imageName = ImgName + ".jpg";
                //imageName =  imageName;



                //set the image path
                if (imageName == "")
                {
                    GeneratefileName = GenerateUniqueID.GetTimeStamps() + "_" + "NameNotFound.Png";
                }
                else
                {
                    GeneratefileName = GenerateUniqueID.GetTimeStamps() + "_" + imageName;
                }
                imgPath = Path.Combine(path, GeneratefileName);

                byte[] imageBytes = Convert.FromBase64String(ImgStr);

                File.WriteAllBytes(imgPath, imageBytes);
                return GeneratefileName;
            }
            catch (Exception ex)
            {
                //return ex.ToString() + "||" + ex.InnerException.ToString();
            }
            return null;
        }
        
        public static void UpdateImageName(string ImageName, Int64 ID)
        {
            string sql = "update ProductMaster set FolderImageName = @ImageName where ID = @ID;";

            using (var connection = new SqlConnection(@"Data Source=DESKTOP-QOLDRIG;database=ELPROCMS;Integrated Security=True;MultipleActiveResultSets=True;"))
            {
                connection.Open();
                var affectedRows = connection.Execute(sql, new { ImageName = ImageName, ID = ID });

                Console.WriteLine(affectedRows);
            }
        }
    }
}
