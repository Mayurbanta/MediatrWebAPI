// See https://aka.ms/new-console-template for more information
using VS2022Demo;

Console.WriteLine("Hello, World!");

List<MyClass> list = new List<MyClass>();
list.Add(new MyClass { FirstName = "A", LastName = "B"});
list.Add(new MyClass { FirstName = "C", LastName = "D" });

Console.Read();

class MyClass
{
    public string FirstName { get; set; }
    public string LastName { get; set; } = string.Empty;

}