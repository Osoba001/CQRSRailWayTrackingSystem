using RailWayModelLibrary.RailWayEnums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailWayModelLibrary.Entities.Base
{
    public class Person: EntityBase
    {
        public Person()
        {

        }
        public Person(string name, Gender gender, string address, string phoneNo, string email)
        {
            Name = name;
            Gender = gender;
            Address = address;
            PhoneNo = phoneNo;
            Email = email;
        }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool IsLock { get; set; }
        public int NTry { get; set; }
        public DateTime LastLogin { get; set; }

    }
}
