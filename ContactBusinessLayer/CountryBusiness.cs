using System;
using System.Data;
using ConatctsDataAccessLayer;
using ContactsDataAccessLayer;
using Microsoft.SqlServer.Server;



namespace ContactBusinessLayer
{
    public class clsCountry
    {

        public enum  enMode { AddNew = 0, Update = 1 };
        
        public enMode Mode = enMode.AddNew;

        public int ID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Phone { get; set; }

        public clsCountry()
        {
            this.ID = -1;
            this.Name = "";
            this.Code = "";
            this.Phone = "";

            Mode = enMode.AddNew;
        }

        private clsCountry(int ID, string Name, string Code, string Phone)
        {
            this.ID = ID;
            this.Name = Name;
            this.Code = Code;
            this.Phone = Phone;

            Mode = enMode.Update;

        }

        public static clsCountry Find(int ID)
        {
            string CountryName = "";
            string Code = "";
            string Phone = "";

            if (clsCountryDataAccess.GetCountryInfoByID(ID, ref CountryName, ref Code, ref Phone))
            {
                return new clsCountry(ID, CountryName, Code, Phone);
            }
            else
            {
                return null;
            }
        }


        public static clsCountry Find(string CountryName)
        {
            int CountryID = -1;
            string Code = "";
            string Phone = "";

            if (clsCountryDataAccess.GetCountryInfoByName(ref CountryID, CountryName, ref Code, ref Phone))
            {
                return new clsCountry(CountryID, CountryName, Code, Phone);

            }
            else
            {
                return null;
            }
        }


        public static bool IsCountryExist(int ID)
        {
           return clsCountryDataAccess.IsCountryExist(ID);
        }

        public static bool IsCountryExist(string CountryName)
        {
            return clsCountryDataAccess.IsCountryExist(CountryName);
        }


        private bool _AddNewCountry()
        {
            //call Data Access Layer

            this.ID = clsCountryDataAccess.AddNewCountry(this.Name);
            return (this.ID != -1);
        }

        private bool _UpdateCountry()
        {
            //call Data Access Layer

            return clsCountryDataAccess.UpdateCountry(this.ID, this.Name, this.Code, this.Phone);

        }



        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewCountry())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateCountry();
            }

            return false;
        }


        public static DataTable GetAllCountries()
        {
            return clsCountryDataAccess.GetAllCountries();
        }


    }
}
