// <copyright file="Program.cs" company="NA">
//     All rights reserved.
// </copyright>
namespace Practice
{
    using SQLPractice;

    public class Program
    {
        static void Main(string[] args)
        {
            GetDataUsingSql obj = new GetDataUsingSql();
            obj.ConnectionStr = @"Server=SWAPNIL\SQLEXPRESS;Database=NORTHWIND;Trusted_connection=true";

            var result = obj.GetProducts();

        }
    }
}
