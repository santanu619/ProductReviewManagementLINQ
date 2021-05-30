using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ProductReviewManagementLINQ
{
    class Program
    {
       

        static void Main(string[] args)
        {
            //UC1
            List<ProductReview> ReviewList = new List<ProductReview>();
            
                new ProductReview() { productId = 1, userId = 1, rating = 5, isLike = "Yes", review = "Awesome" };
                new ProductReview() { productId = 1, userId = 2, rating = 3, isLike = "Yes", review = "Awesome" };
                new ProductReview() { productId = 1, userId = 3, rating = 4, isLike = "Yes", review = "Awesome" };
                new ProductReview() { productId = 1, userId = 4, rating = 3, isLike = "Yes", review = "Nice" };
                new ProductReview() { productId = 1, userId = 5, rating = 4, isLike = "Yes", review = "Good" };
                new ProductReview() { productId = 2, userId = 1, rating = 1, isLike = "No", review = "Unsatifactory" };
                new ProductReview() { productId = 2, userId = 2, rating = 3, isLike = "Yes", review = "Good" };
                new ProductReview() { productId = 2, userId = 3, rating = 4, isLike = "Yes", review = "Awesome" };
                new ProductReview() { productId = 2, userId = 4, rating = 3, isLike = "Yes", review = "Nice" };
                new ProductReview() { productId = 2, userId = 5, rating = 4, isLike = "Yes", review = "Good" };
                new ProductReview() { productId = 3, userId = 1, rating = 5, isLike = "Yes", review = "Awesome" };
                new ProductReview() { productId = 3, userId = 2, rating = 3, isLike = "Yes", review = "Awesome" };
                new ProductReview() { productId = 3, userId = 3, rating = 4, isLike = "Yes", review = "Awesome" };
                new ProductReview() { productId = 3, userId = 4, rating = 3, isLike = "Yes", review = "Nice" };
                new ProductReview() { productId = 3, userId = 5, rating = 4, isLike = "Yes", review = "Good" };
                new ProductReview() { productId = 4, userId = 1, rating = 1, isLike = "No", review = "Unsatifactory" };
                new ProductReview() { productId = 4, userId = 2, rating = 2, isLike = "No", review = "Bad" };
                new ProductReview() { productId = 4, userId = 3, rating = 2, isLike = "No", review = "Worst" };
                new ProductReview() { productId = 4, userId = 4, rating = 3, isLike = "No", review = "Not good" };
                new ProductReview() { productId = 4, userId = 5, rating = 2, isLike = "No", review = "Okay" };
                new ProductReview() { productId = 5, userId = 1, rating = 5, isLike = "Yes", review = "Awesome" };
                new ProductReview() { productId = 5, userId = 1, rating = 5, isLike = "Yes", review = "Awesome" };
                new ProductReview() { productId = 5, userId = 1, rating = 5, isLike = "Yes", review = "Awesome" };
                new ProductReview() { productId = 5, userId = 1, rating = 5, isLike = "Yes", review = "Awesome" };
                new ProductReview() { productId = 5, userId = 1, rating = 5, isLike = "Yes", review = "Awesome" };
                new ProductReview() { productId = 9, userId = 1, rating = 5, isLike = "Yes", review = "Does the work" };
            
            //UC2
            ArrayList outputList = new ArrayList();
            var highestRatedRows = (from rec in ReviewList
                                    orderby rec.rating descending
                                    select rec).Take(3);
            foreach (var row in highestRatedRows)
            {
                Console.WriteLine(row.ToString());
                outputList.Add(row.ToString());
            }

            //UC3
            var data = (from rec in ReviewList
                        where rec.rating > 3 && (rec.productId == 1 || rec.productId == 3 || rec.productId == 9)
                      select rec);
            foreach (var row in data)
            {
                Console.WriteLine(row.ToString());
                outputList.Add(row.ToString());
            }

            //UC4
            var records = (from rec in ReviewList
                     group rec by rec.productId into g
                    select new
                           {
                               productId = g.Key,
                               ReviewCount = g.Count()
                           });
            foreach (var row in records)
            {
                Console.WriteLine(row.ToString());
                outputList.Add(row.ToString());
            }

            //UC5
            var element = ReviewList.GroupBy(l => l.productId).Select(l => new { productId = l.Key, Count = l.Count() });
            foreach (var row in element)
            {
                Console.WriteLine(row.productId+"  "+row.Count);
            }
            
            //UC6
            var elements = (from rec in ReviewList
                            select new { rec.productId, rec.review });
            foreach (var row in elements)
            {
                Console.WriteLine("ProductId ="+ row.productId+"   "+ "Review = "+row.review);
            }

            //UC7
            var highestRatedRow = (from rec in ReviewList
                                    orderby rec.rating descending
                                    select rec);
            foreach (var row in highestRatedRows.Skip(5))
            {
                Console.WriteLine(row.ToString());
                outputList.Add(row.ToString());
            }

            //UC8
            DataTable datatable = new DataTable();
            List<ProductReview> Review = new List<ProductReview>();
            datatable.Columns.Add("Product Id", typeof(int));
            datatable.Columns.Add("User Id", typeof(int));
            datatable.Columns.Add("Rating", typeof(double));
            datatable.Columns.Add("Review", typeof(string));
            datatable.Columns.Add("IsLike", typeof(bool));
            foreach (var rec in Review)
            {
                datatable.Rows.Add(rec.productId, rec.userId, rec.rating, rec.review, rec.isLike);
            }

            //UC9
            var dataIslike = from rec in datatable.AsEnumerable()
                             where rec.Field<bool>("IsLike") == true
                             select new
                             {
                                 product = rec.Field<int>("Product Id")
                             };
            foreach (var productid in dataIslike)
            {
                Console.WriteLine(productid);
            }

            //UC10
            var average = from rec in datatable.AsEnumerable()
                             group rec by rec.Field<int>("Product Id") into g
                             select new
                             {
                                 product = g.Key,
                                 averageRating = g.Average(a => a.Field<double>("Rating"))
                             };
            foreach (var rec in average)
            {
                Console.WriteLine("Product Id {0} Average rating {1} ", rec.product, rec.averageRating);
            }

            //UC11
            var niceResult = from record in datatable.AsEnumerable()
                             where record.Field<string>("Review").Contains("nice")
                             select new
                             {
                                 product = record.Field<int>("Product Id")
                             };
            foreach (var productid in niceResult)
            {
                Console.WriteLine(productid);
            }


        }
    }
}
