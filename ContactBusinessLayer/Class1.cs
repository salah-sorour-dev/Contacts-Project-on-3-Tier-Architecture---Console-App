using System;
using System.Data;
using ConatctsDataAccessLayer;

namespace ContactBusinessLayer
{
    public class clsContact
    {

        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ImagePath { get; set; }
        public int CountryID { get; set; }

        public clsContact()
        {
            this.ID = -1;
            this.FirstName = "";
            this.LastName = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.DateOfBirth = DateTime.Now;
            this.ImagePath = "";
            this.CountryID = -1;
            this.ImagePath = "";
            Mode = enMode.AddNew;

        }

        public clsContact(int ID, string FirstName, string LastName, string Email, string Phone, 
            string Address, DateTime DateOfBirth, int CountryID, string ImagePath)
        {
            this.ID = ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.DateOfBirth = DateOfBirth;
            this.CountryID = CountryID;
            this.ImagePath = ImagePath;

            Mode = enMode.Update;
        }

        public static clsContact Find(int ID)
        {
            string FirstName = "", LastName = "", Email = "", Phone = "", Address = "", ImagePath = "";
            DateTime DateOfBirth = DateTime.Now;
            int CountryID = -1;

            if (clsContactDataAccess.GetContactInfoByID(ID, ref FirstName, ref LastName, ref Email, ref Phone, 
                                        ref Address, ref DateOfBirth, ref CountryID, ref ImagePath))
            {
                return new clsContact(ID, FirstName, LastName, Email, Phone, Address, DateOfBirth, CountryID, ImagePath);
            }
            else
            {
                return null;
            }


        }

    }
}
