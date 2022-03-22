using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace Lab.Files.Ex3
{
    
    class Program{
        static void Main (string[] args)

        {
           
            string path = args[0];
            string absolut_path = Path.Combine(Environment.CurrentDirectory, path);
            string? line;

            List<Person> persons = new List<Person>();

            if (File.Exists(absolut_path))
            {
                if (!Directory.Exists("Task3"))
                {
                    Directory.CreateDirectory("Task3");
                }
                string result_path = Path.Combine(Environment.CurrentDirectory, "Task3", "Result.json");
                StreamWriter writer = new StreamWriter(result_path);
                StreamReader reader = new StreamReader(absolut_path);
                while ((line = reader.ReadLine()) != null)
                {
                    string[] person_string = line.Split(';');
                    Person person = new Person();
                    person.LastName = person_string[0];
                    person.FirstName = person_string[1];
                    person.Patronymic = person_string[2];
                    person.Birthday = DateTime.Parse(person_string[3]);
                    person.DateEmployment = DateTime.Parse(person_string[4]);
                    person.Sales = int.Parse(person_string[5]);
                    persons.Add(person);
                }

                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    WriteIndented = true
                };
                // превращаем список сотрудников в json-объект с помощью класса JsonSerializer.
                string result = JsonSerializer.Serialize(persons, options);
                writer.WriteLine(result);
                writer.Close();
                reader.Close();
                string fileName = Path.Combine(Environment.CurrentDirectory, "Task3", "Test.json");
                StreamWriter PeopleWriter = new StreamWriter(fileName);
                string People_str = SeriaLizeList(persons);
                PeopleWriter.WriteLine(People_str);
                PeopleWriter.Close();
            }
        }
        static string SeriaLizeList(List<Person> people)
        {
            string persons = string.Empty;
            persons += "[";
            for (int i = 0; i < people.Count; i++)
            {
                Person person = people[i];
                persons += person.Serialize();
                if (i != people.Count - 1)
                {
                    persons += ",";
                }
            }
            persons += "]";

            return persons;

        }
    }
}

    

