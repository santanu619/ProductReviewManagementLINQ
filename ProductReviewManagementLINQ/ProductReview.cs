using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace ProductReviewManagementLINQ
{
    public class ProductReview
    {
        public int productId { get; set; }
        public int userId { get; set; }
        public int rating { get; set; }
        public string review { get; set; }
        public string isLike { get; set; }

        public override string ToString()
        {
            return productId.ToString() + "," + userId.ToString() + "," + rating.ToString() + "," + review + "," + isLike;
        }
    }

}