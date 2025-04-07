using System;
using System.Xml.Schema;
using System.Xml;
using Newtonsoft.Json;
using System.IO;
using System.Text;


/**
 * This template file is created for ASU CSE445 Distributed SW Dev Assignment 4.
 * Please do not modify or delete any existing class/variable/method names. However, you can add more variables and functions.
 * Uploading this file directly will not pass the autograder's compilation check, resulting in a grade of 0.
 * **/


namespace ConsoleApp1
{
    public class Program
    {
        public static string xmlURL = "https://sanskarsri26.github.io/assignment4-445/Hotels.xml";
        public static string xmlErrorURL = "https://sanskarsri26.github.io/assignment4-445/HotelsErrors.xml";
        public static string xsdURL = "https://sanskarsri26.github.io/assignment4-445/Hotels.xsd";

        public static void Main(string[] args)
        {
            string result = Verification(xmlURL, xsdURL);
            Console.WriteLine(result); 

            result = Verification(xmlErrorURL, xsdURL);
            Console.WriteLine(result);

            result = Xml2Json(xmlURL);
            Console.WriteLine(result);
        }

        public static string Verification(string xmlUrl, string xsdUrl)
        {
           try      //try method
            {
                XmlReaderSettings s = new XmlReaderSettings();      //initialising 
                s.Schemas.Add(null, xsdUrl);        //adding to schema
                s.ValidationType = ValidationType.Schema;       // starting validation

                string ee = "No Error";         //storing error message

                s.ValidationEventHandler += (sender, args) =>           //validation event handler
                {
                    ee = args.Message;          //first validation error store
                };

                using (XmlReader reader = XmlReader.Create(xmlUrl, s))      //creating XmlReader with validation
                {
                    while (reader.Read()) 
                    {
                    }
                }

                return ee;
            }
            catch (Exception ex)            // catch method
            {
                return $"Exception: {ex.Message}";      //return if error found
            }
        }

        public static string Xml2Json(string xmlUrl)
        {
            XmlDocument d = new XmlDocument();      // DEFINING  a XmlDocument object
            d.Load(xmlUrl);             //loading it

            return (JsonConvert.SerializeXmlNode(d));       //returning the object d after SerializeXmlNode
        }
    }
}