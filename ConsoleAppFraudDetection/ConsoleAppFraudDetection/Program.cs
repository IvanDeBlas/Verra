// See https://aka.ms/new-console-template for more information
using ConsoleAppFraudDetection.Helpers;
using ConsoleAppFraudDetection.Validation;

Console.WriteLine("Hello, World!");

string data = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, @"Data\Orders.txt"));
var inputLines = data.Split("\n").ToList();

List<int> fraudulentOrderIds = FraudDetection.DetectFraudulentOrders(FileHelper.GetOrders(inputLines));

if (fraudulentOrderIds.Any())
    Console.WriteLine(string.Join(",", fraudulentOrderIds));
else
    Console.WriteLine("All data is safe.");
