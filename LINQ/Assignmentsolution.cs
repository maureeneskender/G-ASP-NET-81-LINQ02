using System;
using System.Linq;
using static LINQ.DataSources.Source;
namespace LINQ
{
	internal class AssignmentSolution
	{
		public static void Run()
		{
			#region Part_01
			// Question 3

			var sortedProducts = ProductList.OrderBy(p => p.UnitPrice);

			foreach (var product in sortedProducts)
			{
				Console.WriteLine($"{product.ProductName} - {product.UnitPrice}");
			}

			// Question 8
			var sortedByCategory = ProductList
	.OrderBy(p => p.Category)
	.ThenByDescending(p => p.UnitPrice);

			foreach (var product in sortedByCategory)
			{
				Console.WriteLine(
					$"{product.Category} - {product.ProductName} - {product.UnitPrice}"
				);
			}


			// Question 9

			var beverages = ProductList
	.Where(p => p.Category == "Beverages")
	.OrderByDescending(p => p.UnitsInStock);

			foreach (var product in beverages)
			{
				Console.WriteLine(
					$"{product.ProductName} - Stock: {product.UnitsInStock}"
				);
			}

			// Question 12
			string[] arr = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };

			var sortedWords = arr
				.OrderBy(word => word.Length)
				.ThenBy(word => word, StringComparer.OrdinalIgnoreCase);

			foreach (var word in sortedWords)
			{
				Console.WriteLine(word);
			}

			// Question 13
			string[] digits = {
	"One", "Two", "Three", "Four", "Five",
	"Six", "Seven", "Eight", "Nine", "Ten"
};

			var result13 = digits
				.Where(word => word.Length > 1 &&
							   char.ToLowerInvariant(word[1]) == 'i')
				.Reverse();

			foreach (var word in result13)
			{
				Console.WriteLine(word);
			}

			#endregion

			#region Part_02
			// Part 02 - Question 1
			var top3Products = ProductList
				.OrderByDescending(p => p.UnitPrice)
				.Take(3);

			foreach (var product in top3Products)
			{
				Console.WriteLine($"{product.ProductName} - {product.UnitPrice}");
			}

			// Part 02 - Question 2
			var page2Products = ProductList
				.Skip(5)
				.Take(5);

			foreach (var product in page2Products)
			{
				Console.WriteLine(product.ProductName);
			}

			// Part 02 - Question 3
			var productsUnder25 = ProductList
				.OrderBy(p => p.UnitPrice)
				.TakeWhile(p => p.UnitPrice < 25);

			foreach (var product in productsUnder25)
			{
				Console.WriteLine($"{product.ProductName} - {product.UnitPrice}");
			}

			// Part 02 - Question 4
			bool allSeafoodInStock = ProductList
				.Where(p => p.Category == "Seafood")
				.All(p => p.UnitsInStock > 0);

			Console.WriteLine(allSeafoodInStock);

			// Part 02 - Question 5
			int[] ids = { 3, 9, 13, 18 };

			bool contains9 = ids.Contains(9);
			Console.WriteLine(contains9);

			// Part 02 - Question 6
			var groupedProducts = ProductList
				.GroupBy(p => p.Category);

			foreach (var group in groupedProducts)
			{
				Console.WriteLine($"{group.Key} - Count: {group.Count()}");
			}

			// Part 02 - Question 7
			var productNamesByCategory = ProductList
				.GroupBy(p => p.Category)
				.Select(g => new
				{
					Category = g.Key,
					Names = g.Select(p => p.ProductName)
				});

			foreach (var group in productNamesByCategory)
			{
				Console.WriteLine(group.Category);

				foreach (var name in group.Names)
				{
					Console.WriteLine(name);
				}
			}

			// Part 02 - Question 8
			var categoriesMoreThan3 = ProductList
				.GroupBy(p => p.Category)
				.Where(g => g.Count() > 3);

			foreach (var group in categoriesMoreThan3)
			{
				Console.WriteLine($"{group.Key} - {group.Count()}");
			}

			// Part 02 - Question 9
			var customersByCountry =
				from customer in CustomerList
				group customer by customer.Country into countryGroup
				select new
				{
					Country = countryGroup.Key,
					Count = countryGroup.Count(),
					TotalOrderValue = countryGroup
						.SelectMany(c => c.Orders)
						.Sum(o => o.Total)
				};

			foreach (var group in customersByCountry)
			{
				Console.WriteLine(
					$"{group.Country} - Count: {group.Count} - Total: {group.TotalOrderValue}"
				);
			}

			// Part 02 - Question 10
			var totalStock = ProductList.Sum(p => p.UnitsInStock);
			Console.WriteLine($"Total Stock: {totalStock}");

			// Part 02 - Question 11
			var cheapestPrice = ProductList.Min(p => p.UnitPrice);
			var expensivePrice = ProductList.Max(p => p.UnitPrice);

			Console.WriteLine($"Cheapest: {cheapestPrice}");
			Console.WriteLine($"Most Expensive: {expensivePrice}");

			// Part 02 - Question 12
			var distinctCategories = ProductList
				.Select(p => p.Category)
				.Distinct();

			foreach (var category in distinctCategories)
			{
				Console.WriteLine(category);
			}

			// Part 02 - Question 13
			int[] setA = { 1, 3, 5, 7, 9, 11, 13 };
			int[] setB = { 3, 6, 9, 12, 15, 13 };

			var differentIds = setA.Except(setB);

			foreach (var id in differentIds)
			{
				Console.WriteLine(id);
			}

			// Part 02 - Question 14
			string[] list1 = { "Germany", "France", "UK", "Spain" };
			string[] list2 = { "france", "SPAIN", "Italy" };

			var differentCountries = list1
				.Except(list2, StringComparer.OrdinalIgnoreCase);

			foreach (var country in differentCountries)
			{
				Console.WriteLine(country);
			}

			// Part 02 - Question 15
			var productDictionary = ProductList
				.ToDictionary(p => p.ProductID);

			if (productDictionary.TryGetValue(18, out var product18))
			{
				Console.WriteLine($"{product18.ProductName} - {product18.UnitPrice}");
			}

			// Part 02 - Question 16
			var firstProductOver50 = ProductList
				.First(p => p.UnitPrice > 50);

			Console.WriteLine(
				$"{firstProductOver50.ProductName} - {firstProductOver50.UnitPrice}"
			);

			// Part 02 - Question 17
			var firstProductOver500 = ProductList
				.FirstOrDefault(p => p.UnitPrice > 500);

			if (firstProductOver500 == null)
			{
				Console.WriteLine("No product found");
			}
			else
			{
				Console.WriteLine(firstProductOver500.ProductName);
			}

			// Part 02 - Question 18
			var multiplicationTable = Enumerable
				.Range(1, 10)
				.Select(n => $"7 x {n} = {7 * n}");

			foreach (var item in multiplicationTable)
			{
				Console.WriteLine(item);
			}

			// Part 02 - Question 19
			var evenNumbers = Enumerable
				.Range(1, 30)
				.Where(n => n % 2 == 0);

			foreach (var number in evenNumbers)
			{
				Console.WriteLine(number);
			}

			// Part 02 - Question 20
			var first3ProductNames = ProductList
				.Take(3)
				.Select(p => p.ProductName);

			var first3CompanyNames = CustomerList
				.Take(3)
				.Select(c => c.CompanyName);

			var combinedNames = first3ProductNames.Concat(first3CompanyNames);

			foreach (var name in combinedNames)
			{
				Console.WriteLine(name);
			}

			// Part 02 - Question 21
			var productCustomerPairs = ProductList
				.Zip(
					CustomerList,
					(p, c) => $"{p.ProductName} sold to {c.CompanyName}"
				);

			foreach (var pair in productCustomerPairs)
			{
				Console.WriteLine(pair);
			}


			#endregion
		}
	}
}