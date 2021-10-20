using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductReviewManagement_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            //CreateDataTable
            //UC1
            List<ProductReview> list = new List<ProductReview>()
            {
                new ProductReview(){ProductId=1,UserId=1,Review="good",Rating=17,IsLike=true},
                new ProductReview(){ProductId=2,UserId=6,Review="good",Rating=11,IsLike=true},
                new ProductReview(){ProductId=1,UserId=2,Review="bad",Rating=7,IsLike=false},
                new ProductReview(){ProductId=9,UserId=1,Review="good",Rating=19,IsLike=true},
                new ProductReview(){ProductId=1,UserId=2,Review="good",Rating=18,IsLike=true},
                new ProductReview(){ProductId=8,UserId=3,Review="bad",Rating=10,IsLike=false},
                new ProductReview(){ProductId=5,UserId=5,Review="good",Rating=9,IsLike=false},
                new ProductReview(){ProductId=9,UserId=3,Review="good",Rating=7,IsLike=false},
                new ProductReview(){ProductId=4,UserId=5,Review="bad",Rating=19,IsLike=true},
                new ProductReview(){ProductId=3,UserId=6,Review="bad",Rating=10,IsLike=false},
                new ProductReview(){ProductId=5,UserId=7,Review="good",Rating=15,IsLike=true},
                new ProductReview(){ProductId=1,UserId=1,Review="good",Rating=18,IsLike=true},
                new ProductReview(){ProductId=2,UserId=9,Review="good",Rating=16,IsLike=true},
                new ProductReview(){ProductId=9,UserId=3,Review="bad",Rating=10,IsLike=false},
                new ProductReview(){ProductId=8,UserId=4,Review="good",Rating=13,IsLike=true},
                new ProductReview(){ProductId=4,UserId=5,Review="bad",Rating=3,IsLike=false},
                new ProductReview(){ProductId=2,UserId=8,Review="good",Rating=17,IsLike=true},
                new ProductReview(){ProductId=5,UserId=4,Review="bad",Rating=9,IsLike=false},
                new ProductReview(){ProductId=6,UserId=3,Review="good",Rating=14,IsLike=true},
                new ProductReview(){ProductId=1,UserId=7,Review="bad",Rating=2,IsLike=false},
                new ProductReview(){ProductId=4,UserId=9,Review="bad",Rating=1,IsLike=false},
                new ProductReview(){ProductId=8,UserId=8,Review="bad",Rating=3,IsLike=false},
                new ProductReview(){ProductId=9,UserId=3,Review="good",Rating=20,IsLike=true},
                new ProductReview(){ProductId=7,UserId=1,Review="bad",Rating=10,IsLike=false},
                new ProductReview(){ProductId=6,UserId=5,Review="good",Rating=17,IsLike=true},
            };
            Console.WriteLine("Choose operation you want: 1-Display all product review \n 2-Retrieve top three records \n 3-Retrieve records based on rating and productId \n 4-Count of the product id \n 5-Retrieve only ProductId and review \n 6-Skip Top Five Records");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    IterateLoopList(list);
                    break;
                case 2:
                    RetriveTop3Records(list);
                    break;
                case 3:
                    RetriveBasedonProductIdandRating(list);
                    break;
                case 4:
                    CountingID(list);
                    break;
                case 5:
                    ProductIdandReview(list);
                    break;
                case 6:
                    IterateLoopList(list);
                    SkipTopFiveRecords(list);
                    break;
            }
        }

        //UC1 Add 25 values in the list
        public static void IterateLoopList(List<ProductReview> list)
        {
            foreach (ProductReview product in list)
            {
                Console.WriteLine("Product ID:" + product.ProductId + "\t User ID:" + product.UserId + "\t Review:" + product.Review + "\t Rating:" + product.Rating);
            }
        }

        //UC2
        //Retriving Top 3 Records from the List
        public static void RetriveTop3Records(List<ProductReview> list)
        {
            var result = (from product in list orderby product.Rating descending select product).ToList();
            Console.WriteLine("=============================================");
            Console.WriteLine("After Sorting");
            IterateLoopList(result);
            var top3Records = result.Take(3).ToList();
            Console.WriteLine("=============================================");
            Console.WriteLine("Top 3 Records");
            IterateLoopList(top3Records);
        }


        //UC3
        //retrive the record whose Rating is Greater than 3 and Product ID is Either 1 or 4 or 9
        public static void RetriveBasedonProductIdandRating(List<ProductReview> list)
        {
            var data = (list.Where(a => a.Rating > 3 && (a.ProductId == 1 || a.ProductId == 4 || a.ProductId == 9))).ToList();
            Console.WriteLine("The desire Result is :");
            IterateLoopList(data);
        }

        //UC4
        //Counting Each ID present in the List
        public static void CountingID(List<ProductReview> list)
        {
            var data = (list.GroupBy(a => a.ProductId).Select(x => new { ProductId = x.Key, count = x.Count() }));
            Console.WriteLine("Count of Each Product Id is: ");
            foreach (var element in data)
            {
                Console.WriteLine("Product ID: " + element.ProductId + "\t Count: " + element.count);
                Console.WriteLine("========================================================");
            }
        }

        //UC5
        //Retrive only ProductID and Review from the Records
        public static void ProductIdandReview(List<ProductReview> list)
        {
            var p = list.Select(product => new { ProductId = product.ProductId, review = product.Review }).ToList();
            foreach (var element in p)
            {
                Console.WriteLine("Product ID: " + element.ProductId + "\t Review: " + element.review);
                Console.WriteLine("=====================================");
            }
        }
        //Uc6
        public static void SkipTopFiveRecords(List<ProductReview> products)
        {
            Console.WriteLine("\n----------Skip Top Five records in list");
            var res = (from product in products orderby product.Rating descending select product).Skip(5).ToList();
            IterateLoopList(res);
        }
    }
}
