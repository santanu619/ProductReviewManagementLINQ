using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
        }
    }
}
