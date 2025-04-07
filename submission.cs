﻿using System;
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
        // These URLs must point to your remotely hosted files.
        public static string xmlURL = "https://sanskarsri26.github.io/assignment4-445/Hotels.xml";
        public static string xmlErrorURL = "https://sanskarsri26.github.io/assignment4-445/HotelsErrors.xml";
        public static string xsdURL = "https://sanskarsri26.github.io/assignment4-445/Hotels.xsd";

        public static void Main(string[] args)
        {
            // 1. Validate the correct XML file against the schema.
            string result = Verification(xmlURL, xsdURL);
            Console.WriteLine(result); // Expected to output "No Error" if valid

            // 2. Validate the erroneous XML file. Expected to show error messages.
            result = Verification(xmlErrorURL, xsdURL);
            Console.WriteLine(result);

            // 3. Convert the correct XML file to JSON.
            result = Xml2Json(xmlURL);
            Console.WriteLine(result);
        }

        public static string Verification(string xmlUrl, string xsdUrl)
        {
           try
            {
                XmlReaderSettings s = new XmlReaderSettings();
                s.Schemas.Add(null, xsdUrl);
                s.ValidationType = ValidationType.Schema; 

                string ee = "No Error";

                s.ValidationEventHandler += (sender, args) =>
                {
                    ee = args.Message;
                };

                using (XmlReader reader = XmlReader.Create(xmlUrl, s))
                {
                    while (reader.Read()) 
                    {
                    }
                }

                return ee;
            }
            catch (Exception ex)
            {
                return $"Exception: {ex.Message}";
            }
        }

        public static string Xml2Json(string xmlUrl)
        {
            XmlDocument d = new XmlDocument();
            d.Load(xmlUrl);

            return (JsonConvert.SerializeXmlNode(d));
        }
    }
}