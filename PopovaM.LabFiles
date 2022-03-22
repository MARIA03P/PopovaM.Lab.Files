using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
namespace M_Task1
{
    class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime DateEmployment { get; set; }
        public int Sales { get; set; }

        static bool ContainsSymbol(string line, char[] symbols)
        {
            bool result = false;
            foreach (var symbol in symbols)
            {
                if (line.Contains(symbol))
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
    }
}



