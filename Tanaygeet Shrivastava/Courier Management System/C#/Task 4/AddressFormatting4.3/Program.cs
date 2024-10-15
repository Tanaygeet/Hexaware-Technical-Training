/* Tanaygeet Shrivastava */

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

// Task 4 question 11

namespace AddressFormatting4._3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Address details
            string street = "1st Lane";
            string city = "Raipur";
            string district = "raipur";
            string state = "madhya Pradesh";
            string zipCode = "460001";

            string formattedAddress = FormatAddress(street, city, district, state, zipCode);

            Console.WriteLine("Formatted Address:");
            Console.WriteLine(formattedAddress);
            Console.ReadKey();  
        }
        
        static string FormatAddress(string street, string city, string district , string state, string zipCode)
        {
            
            string formattedStreet = CapitalizeWords(street);
            string formattedCity = CapitalizeWords(city);
            string formattedDistrict = CapitalizeWords(district);
            string formattedState = CapitalizeWords(state);
            
            string formattedZipCode = FormatZipCode(zipCode);

            return $"{formattedStreet}, {formattedCity}, {formattedDistrict}, {formattedState} {formattedZipCode}";
        }

  
        static string CapitalizeWords(string input)
        {
            // Use TextInfo class to capitalize each word
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            return textInfo.ToTitleCase(input.ToLower());
        }
  
        static string FormatZipCode(string zipCode)
        {
            // Check if the zip code is valid 6 digits)
            if (Regex.IsMatch(zipCode, @"^\d{6}$"))
            {
                return zipCode;
            }
            else
            {
                return "Invalid Zip Code"; 
            }
        }
    }
}
