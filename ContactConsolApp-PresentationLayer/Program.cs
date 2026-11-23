using System;
using System.Data;
using ContactBusinessLayer;


namespace ContactConsolApp
{
    public class Program
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

            Contact1.FirstName = "salah eddine";
            Contact1.LastName = "Sorour";
            Contact1.Email = "Ss@s.com";
            Contact1.Phone = "123456789";
            Contact1.Address = "123 Main St";
            Contact1.DateOfBirth = new DateTime(2001, 2, 14, 10, 30, 0);
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


        static void testIsContactExist(int ID)
        {
            if (clsContact.IsContactExist(ID))
                Console.WriteLine("Yes, Contact is there.");
            else
                Console.WriteLine("No, Contact is not there.");
        }


        static void testFindCountryByID(int ID)
        {
            clsCountry country = clsCountry.Find(ID); 

            if (country != null)
            {
                Console.WriteLine("Country ID: " + country.ID);
                Console.WriteLine("Country Name: " + country.Name);
            }
            else
            {
                Console.WriteLine("Country [" + ID + "] not found!");
            }
        }

        static void testFindCountryByName(string name)
        {
            clsCountry country = clsCountry.Find(name); 
            if (country != null)
            {
                Console.WriteLine("Country ID: " + country.ID);
                Console.WriteLine("Country Name: " + country.Name);
            }
            else
            {
                Console.WriteLine("Country [" + name + "] not found!");
            }
        }



        static void testIsCountryExistByID(int ID)
        {
            if (clsCountry.IsCountryExist(ID))

                Console.WriteLine("Yes, Country is there.");

            else

                Console.WriteLine("No, Country is not there.");

        }

        static void testIsCountryExistByName(string Name)
        {
            if (clsCountry.IsCountryExist(Name))

                Console.WriteLine("Yes, Country is there.");

            else

                Console.WriteLine("No, Country is not there.");
        }


        static void testAddNewCountry()
        {
            clsCountry country1 = new clsCountry();
            country1.Name = "Morocco";
            if (country1.Save())
            {
                Console.WriteLine("Country [" + country1.ID + "] saved successfully!");
            }
            else
            {
                Console.WriteLine("Error saving country [" + country1.ID + "]!");
            }
        }


        static void testUpdateCountry(int ID)
        {
            clsCountry country1 = clsCountry.Find(ID);

            if (country1 != null)
            {
                //Update what ever info you want

                country1.Name = "Saudi Arabia";
                country1.Code = "111";
                country1.Phone = "324";

                if (country1.Save())
                {
                    Console.WriteLine("Country Updated Successfully.");
                }
            }

            else
            {
                Console.WriteLine("Country is you want to update is not found.");

            }
        }


        static void ListCountries()
        {
            DataTable dataTable = clsCountry.GetAllCountries();

            Console.WriteLine("Countries Data :");

            foreach (DataRow row in dataTable.Rows)
            {
                Console.WriteLine($"{row["CountryID"]}, {row["CountryName"]}, {row["Code"]}, {row["Phone"]}");
            }


        }









        static void Main(string[] args)
        {
            //testFindContact(1);
            //testAddNewContact();
            //testUpdateContact(2);
            //testDeleteContact(10);
            //ListContacts();
            //testIsContactExist(1);
            //testIsContactExist(100);


            //testFindCountryByID(1);
            //testFindCountryByName("Morocco");
            //testIsCountryExistByID(1);
            //testIsCountryExistByName("Canada");
            //testAddNewCountry();
            testUpdateCountry(1);

            //ListCountries();
        }
    }
}
