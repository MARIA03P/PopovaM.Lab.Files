using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.Files.Ex3
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime DateEmployment { get; set; }
        public int Sales { get; set; }

        public string Serialize() {
            string person = string.Empty;
            person += "{";
            string firstname = $"\"{nameof(FirstName)}\" : \"{FirstName}\""; 
            string lastname = $"\"{nameof(LastName)}\" : \"{LastName}\"";
            string patronomic = $"\"{nameof(Patronymic)}\" : \"{Patronymic}\"";
            string birthday = $"\"{nameof(Birthday)}\" : \"{this.Birthday.ToString()}\"";
            string dateEmployment = $"\"{nameof(DateEmployment)}\" : \"{this.DateEmployment}\"";
            string sales = $"\"{nameof(Sales)}\" : \"{this.Sales}\"";
            person += firstname;
            person += ",";
            person += lastname;
            person += ",";
            person += patronomic;
            person += ",";
            person += birthday;
            person += ",";
            person += dateEmployment;
            person += ",";
            person += sales;
            person += "}";
            return person;
           
        }
    }
}
