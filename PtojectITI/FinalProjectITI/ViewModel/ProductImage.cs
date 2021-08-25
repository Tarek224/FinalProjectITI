using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;
using FinalProjectITI.Models;

namespace FinalProjectITI.ViewModel
{
    public class ProductImage
    {
        
        public int Product_ID { get; set; }
        
        public string Product_Name { get; set; }
        public int? Category_ID { get; set; }
        public string Description { get; set; }
    
        public decimal Product_Price { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }

        public Size Product_Size { get; set; }
        public Color Product_Color { get; set; }
       
        public DateTime Adding_Date { get; set; }
        public int Popularity { get; set; }
        public int Stored_Quantity { get; set; }

        public virtual Category Category { get; set; }
    }
}
