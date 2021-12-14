using Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Buyer
{
    public class Buyers : Entity
    {
        public Buyers()
        {
            Phone = new List<PhoneNumber>();
            Emails = new List<Email>();
        }
        public bool SetBuyerName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName)) return false;

            if (string.IsNullOrWhiteSpace(lastName)) Name = new Name(firstName, "");

            Name = new Name(firstName, lastName);

            return true;
        }
        public bool SetPhoneNumber(string phoneNumber, int type)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber)) return false;

            if (Phone == null) return false;

            Phone.Add(new PhoneNumber(phoneNumber, (PhoneType)type));
            return true;
        }
        public bool SetAddress(string street, string city, string state, string country,
            string zipCode, string number)
        {
            Address = new Address(street, city, state, country, zipCode, number);
            return true;
        }
        public bool SetEmail(string emailAddress)
        {
            if (string.IsNullOrWhiteSpace(emailAddress)) return false;

            if (Emails == null) return false;

            Emails.Add(new Email()
            {
                EmailAddress = emailAddress,
            });

            return true;
        }
        public Name Name { get; private set; }
        public List<PhoneNumber>? Phone { get; private set; }
        public Address? Address { get; private set; }
        public List<Email>? Emails { get; private set; }

    }
}
