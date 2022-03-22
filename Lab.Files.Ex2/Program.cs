using System;
using System.Collections.Generic;
using System.IO;


namespace Lab.Files.Ex1
{
    class Person
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime DateEmployment { get; set; }
        public int Sales { get; set; }

        public int rost { get; set; }
    }

    class Program
    {
       
       
        static void Main(string[] args)
        {

            
            string path = args[0];
            string absolut_path = Path.Combine(Environment.CurrentDirectory, path);
            string? line;
            // Контейнер для хранения всех сотрудников
            List<Person> persons = new List<Person>();
            
            if (File.Exists(absolut_path))
            {
                if (!Directory.Exists("Task2"))
                {
                    Directory.CreateDirectory("Task2");
                }
                string result_path = Path.Combine(Environment.CurrentDirectory, "Task2", "Result.txt");
                StreamWriter writer = new StreamWriter(result_path);
                StreamReader reader = new StreamReader(absolut_path);
                while ((line = reader.ReadLine()) != null)
                {
                    
                    string[] person_string = line.Split(';');
                    // Создаём экземпляр класса для хранения сотрудника
                    Person person = new Person();
                    // присваем полям значения согласно считанным данным
                    person.LastName = person_string[0];
                    person.FirstName = person_string[1];
                    person.Patronymic = person_string[2];
                    person.Birthday = DateTime.Parse(person_string[3]);
                    person.DateEmployment = DateTime.Parse(person_string[4]);
                    person.Sales = int.Parse(person_string[5]);
                    person.rost = int.Parse(person_string[6]);
                   
                    persons.Add(person);

                }

                writer.WriteLine($"Общее число сотрудников: {persons.Count}");
                //средний возраст сотрудников
                int avg__birth_count = 0;
                //среднее время работы сотрудника
                int avg_work_count = 0;
                // среднее число продаж
                int avg_sales_count = 0;
                // берём каждого сотрудника и обновляем общую информацию
                foreach (Person item in persons)
                {
                    avg__birth_count += item.Birthday.Year;
                    avg_work_count += DateTime.Now.Year - item.DateEmployment.Year;
                    avg_sales_count += item.Sales;
                }
                
                writer.WriteLine($"Средний возраст сотрудников: {avg__birth_count / persons.Count}");
                writer.WriteLine($"Среднее время работы: {avg_work_count / persons.Count}");
                writer.WriteLine($"Среднее число продаж: {avg_sales_count / persons.Count}");
                writer.Close();
                reader.Close();
            }
        }
    }
}




