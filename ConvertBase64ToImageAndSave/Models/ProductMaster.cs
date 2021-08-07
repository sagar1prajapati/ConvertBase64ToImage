using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConvertBase64ToImageAndSave.Models
{
   public class ProductMaster
    {

        public Int64 ID { get; set; }
        public string Name { get; set; }
        public Int64? UnitID { get; set; }
        public Int64? CategoryID { get; set; }
        public Int64? SubCategoryID { get; set; }
        public string ProductType { get; set; }
        public string HSNNo { get; set; }
        public decimal? MRP { get; set; }
        public decimal? Dis { get; set; }
        public decimal? SalePrice { get; set; }
        public int OpeningBal { get; set; }
        public decimal? GST { get; set; }
        public string image { get; set; }
        public bool IsActive { get; set; }
        public string OtherInfo { get; set; }
        public string OtherInfo1 { get; set; }
        public string OtherInfo2 { get; set; }
        public string OtherInfo3 { get; set; }
        public string OtherInfo4 { get; set; }
        public Int64? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public Int64? ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Discription { get; set; }
        public string ImageName { get; set; }
    }
}
