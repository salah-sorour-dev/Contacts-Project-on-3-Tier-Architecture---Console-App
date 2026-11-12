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

        static void testAddNewContact()
        {
            clsContact Contact1 = new clsContact();

            Contact1.FirstName = "Sofian";
            Contact1.LastName = "Sorour";
            Contact1.Email = "S@s.com";
                        Contact1.Phone = "123456789";
            Contact1.Address = "123 Main St";
            Contact1.DateOfBirth = new DateTime(1998, 2, 14, 10, 30, 0);
            Contact1.CountryID = 1;
            Contact1.ImagePath = "";

            if (Contact1.Save())
            {
                Console.WriteLine("Contact [" + Contact1.ID + "] saved successfully!");
            }
            else
            {
                Console.WriteLine("Error saving contact [" + Contact1.ID + "]!");
            }
        }

        static void testUpdateContact(int ID)
        {
            clsContact Contact1 = clsContact.Find(ID);


            if (Contact1 != null)
            {
                Contact1.FirstName = "khalid";
                Contact1.LastName = "salem";
                Contact1.Email = "K@g.com";
                Contact1.Phone = "987654121";
                Contact1.Address = "457 Main St";
                Contact1.DateOfBirth = new DateTime(1999, 5, 20, 15, 45, 0);
                Contact1.CountryID = 1;
                Contact1.ImagePath = "";


                if (Contact1.Save())
                {
                    Console.WriteLine("Contact [" + Contact1.ID + "] updated successfully!");
                }
                else
                {
                    Console.WriteLine("Error updating contact [" + Contact1.ID + "]!");
                }
            }
        }


        static void testDeleteContact(int ID)
        {
            if (clsContact.DeleteContact(ID))
            
                Console.WriteLine("Contact [" + ID + "] deleted successfully!");

            else
                
                Console.WriteLine("Error deleting contact [" + ID + "]!");


        }

        static void ListContacts()
        {
            DataTable dataTable = clsContact.GetAllContacts();

            Console.WriteLine("Contacts Data:");

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["ContactID"]}, {row["FirstName"]}, {row["LastName"]}");
            }
        }

        static void Main(string[] args)
        {
            //testFindContact(8);
            //testAddNewContact();
            //testUpdateContact(2);
            //testDeleteContact(2);
            ListContacts();
        }
    }
}
