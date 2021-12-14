using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Value_Objects
{
    public class PhoneNumber
    {
        public PhoneNumber()
        {

        }
        public PhoneNumber(string number, PhoneType phoneType)
        {
            Number = number;
            this.phoneType = phoneType;
        }

        [Phone]
        public string Number { get; set; }

        public PhoneType phoneType { get; set; }
    }
    public enum PhoneType
    {
        Fixo = 1,
        Celular = 2,
        Empresarial = 3,
    }
}
