using EasyAutomationFramework;
using EasyAutomationFramework.Model;
using TreinandoWebScraping.Driver;

// Raspagem de dados com WebScraping 

var web = new WebScraper();
var computers = web.GetData("https://webscraper.io/test-sites/e-commerce/allinone/computers");

Console.WriteLine("Dados dos Computadores");

var laptops = web.GetData("https://webscraper.io/test-sites/e-commerce/allinone/computers/laptops");

Console.WriteLine("Dados dos Laptops");

var tablets = web.GetData("https://webscraper.io/test-sites/e-commerce/allinone/computers/tablets");

Console.WriteLine("Dados dos Taablets");
Console.WriteLine("Gerando Excel");



var paramss = new ParamsDataTable("Dados", @"C:\Users\kaiky\OneDrive\Área de Trabalho\Nova pasta", new List<DataTables>
{
    new DataTables("computers", computers),
    new DataTables("laptops", laptops),
    new DataTables("tablets", tablets),
}) ;

Base.GenerateExcel(paramss);