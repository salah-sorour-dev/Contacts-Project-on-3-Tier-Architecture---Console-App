using System;
using System.Data;
using ContactBusinessLayer;

namespace ContactConsolApp
{
    internal class Program
    {

        static void testFindContact(int ID)
        {
            clsContact Contact1 = clsContact.Find(ID);

            if (Contact1 != null)
            {
                Console.WriteLine("Contact ID: " + Contact1.ID);
                Console.WriteLine("First Name: " + Contact1.FirstName);
                Console.WriteLine("Last Name: " + Contact1.LastName);
                Console.WriteLine("Email: " + Contact1.Email);
                Console.WriteLine("Phone: " + Contact1.Phone);
                Console.WriteLine("Address: " + Contact1.Address);
                Console.WriteLine("Date of Birth: " + Contact1.DateOfBirth.ToShortDateString());
                Console.WriteLine("Image Path: " + Contact1.ImagePath);
                Console.WriteLine("Country ID: " + Contact1.CountryID);
            }
            else
            {
                Console.WriteLine("Contact [" + ID + "] not found!");
            }

        }

        static void Main(string[] args)
        {
            testFindContact(8);
        }
    }
}
