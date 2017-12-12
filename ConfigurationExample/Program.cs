using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigurationExample
{
    class Program
    {
        static void Main(string[] args)
        {
            GetConfigurationValue();
            Console.WriteLine();
            GetConfigurationUsingSection();
            Console.WriteLine();
            GetConfigurationUsingSectionGroup();
            Console.WriteLine();
            GetConfigurationUsingCustomClass();
            Console.ReadKey();
        }

        public static void GetConfigurationValue()
        {
            var title = ConfigurationManager.AppSettings["title"];
            var language = ConfigurationManager.AppSettings["language"];

            Console.WriteLine(string.Format("'{0}' project is created in '{1}' language ", title, language));
        }

        public static void GetConfigurationUsingSection()
        {
            var applicationSettings = ConfigurationManager.GetSection("ApplicationSettings")
               as NameValueCollection;

            if (applicationSettings.Count == 0)
            {
                Console.WriteLine("Application Settings are not defined");
            }
            else
            {
                foreach (var key in applicationSettings.AllKeys)
                {
                    Console.WriteLine(key + " = " + applicationSettings[key]);
                }
            }

        }

        public static void GetConfigurationUsingSectionGroup()
        {
            var PostSetting = ConfigurationManager.GetSection("BlogGroup/PostSetting") as NameValueCollection;
            if (PostSetting.Count == 0)
            {
                Console.WriteLine("Post Settings are not defined");
            }
            else
            {
                foreach (var key in PostSetting.AllKeys)
                {
                    Console.WriteLine(key + " = " + PostSetting[key]);
                }
            }
        }

        public static void GetConfigurationUsingCustomClass()
        {
            var productSettings = ConfigurationManager.GetSection("ProductSettings") as ConfigurationExample.ProductSettings;
            if (productSettings == null)
            {
                Console.WriteLine("Product Settings are not defined");
            }
            else
            {
                var productNumber = productSettings.DellFeatures.ProductNumber;
                var productName = productSettings.DellFeatures.ProductName;
                var color = productSettings.DellFeatures.Color;
                var warranty = productSettings.DellFeatures.Warranty;

                Console.WriteLine("Product Number = " + productNumber);
                Console.WriteLine("Product Name = " + productName);
                Console.WriteLine("Product Color = " + color);
                Console.WriteLine("Product Warranty = " + warranty);
            }
        }
    }
}
