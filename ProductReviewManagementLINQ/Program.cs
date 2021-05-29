﻿using System;
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



        }
    }
}