using EasyAutomationFramework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TreinandoWebScraping.Models;

namespace TreinandoWebScraping.Driver
{
    public class WebScraper : Web
    {
        public DataTable GetData(string link)
        {
            if(driver == null)
            {
                StartBrowser();
            }

            var items = new List<Item>();

            Navigate(link);

            var elements = GetValue(TypeElement.Xpath, "/html/body/div[1]/div[3]/div/div[2]/div[1]").element.FindElements(By.ClassName("thumbnail"));  
           
                
            foreach(var element in elements)
            {
              Item item = new Item();
              item.Title = element.FindElement(By.ClassName("title")).GetAttribute("title");
              item.Price = element.FindElement(By.ClassName("price")).Text;
              item.Description = element.FindElement(By.ClassName("description")).Text;

              items.Add(item);
            }

            return Base.ConvertTo(items);
        }
    }
}
