using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palmer_PhoneBook
{
    class Contact
    {
        public int Person_ID;
        public string Firstname;
        public string Lastname;
        public string Address;
        public string City;
        public string State;
        public string Zipcode;
        public string CellPhone;
        public string WorkPhone;
        public string Notes;

        public Contact()
        {

        }

        public Contact(int id, string fname, string lname)
        {
            Person_ID = id;
            Firstname = fname;
            Lastname = lname;
        }

        public int personId { get => this.Person_ID; set { this.Person_ID = value; } }
        public string firstName { get => this.Firstname; set { this.Firstname = value; } }
        public string lastName { get => this.Lastname; set { this.Lastname = value; } }
        public string address { get => this.Address; set { this.Address = value; } }
        public string city { get => this.City; set { this.City = value; } }
        public string state { get => this.State; set { this.State = value; } }
        public string zipCode { get => this.Zipcode; set { this.Zipcode = value; } }
        public string cellPhone { get => this.CellPhone; set { this.CellPhone = value; } }
        public string workPhone { get => this.WorkPhone; set { this.WorkPhone = value; } }
        public string notes { get => this.Notes; set { this.Notes = value; } }

        public void SetContact(int id, string fname, string lname, string addrs, string city, string state, string zip, string cell, string work)
        {
            this.Person_ID = id;
            this.Firstname = fname;
            this.Lastname = lname;
            this.Address = addrs;
            this.City = city;
            this.State = state;
            this.Zipcode = zip;
            this.CellPhone = cell;
            this.WorkPhone = work;
        }
        public void SetContact(int id, string fname, string lname, string cell, string work)
        {
            this.Person_ID = id;
            this.Firstname = fname;
            this.Lastname = lname;
            this.CellPhone = cell;
            this.WorkPhone = work;
        }

        public void SetAddress(string addrs, string city, string state, string zip)
        {
            this.Address = addrs;
            this.City = city;
            this.State = state;
            this.Zipcode = zip;
        }
        public void SetPhones(string cell, string work)
        {
            this.CellPhone = cell;
            this.WorkPhone = work;
        }
    }

}
