using System;
using System.IO;

namespace Lab.Files.Ex1
{
    class Program
    {
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

        static void Main(string[] args)
        {
           string path = args[0];
            // абсолютный путь до файла. Метод Combine в зависимости от OC склеивает строки с правильными разделителями
            string absolut_path = Path.Combine(Environment.CurrentDirectory, path);
            // в данной переменной храним считанные строки
            string? line;
            // количество строк
            int rows_counter = 0;
            //количество слов
            int words_counter = 0;
            string numbers = "0123456789";
            string eng_symbols = "qwertyuiopasdfghjklzxcvbnm";
            string rus_symbols = "йцукенгшщзхъфывапролджэячсмитьбюё";
            
            bool contains_num = false;
            // содержатся английские символы
            bool contains_eng = false;
            // содержатся русские символы
            bool contains_rus = false;
            if (File.Exists(absolut_path))
            {
                // проверяем существование дирректории для выходных данных
                if (!Directory.Exists("Task1"))
                {
                    Directory.CreateDirectory("Task1");
                }
                
                string result_path = Path.Combine(Environment.CurrentDirectory, "Task1", "Result.txt");
                
                StreamWriter writer = new StreamWriter(result_path);
                writer.WriteLine($"Название файла \"{Path.GetFileName(path)}\"");
                writer.WriteLine($"Абсолютный путь к файлу \"{absolut_path}\"");
                writer.WriteLine($"Относительный путь к файлу \"{path}\"");
                
                FileInfo file_info = new FileInfo(absolut_path);
    
                writer.WriteLine($"Время создания \"{file_info.CreationTime.ToString()}\"");
                writer.WriteLine($"Размер файла \"{file_info.Length}\" в байтах");
                
                StreamReader reader = new StreamReader(absolut_path);
                while ((line = reader.ReadLine()) != null)
                {
                    
                    rows_counter++;
                    
                    words_counter += line.Split(' ').Length;
                    
                    if (!contains_eng)
                    {
                        contains_eng = ContainsSymbol(line.ToLower(), eng_symbols.ToCharArray());
                    }
                    if (!contains_rus)
                    {
                        contains_rus = ContainsSymbol(line.ToLower(), rus_symbols.ToCharArray());
                    }
                    if (!contains_num)
                    {
                        contains_num = ContainsSymbol(line.ToLower(), numbers.ToCharArray());
                    }
                }
                writer.WriteLine($"Общее количество строк \"{rows_counter}\"");
                writer.WriteLine($"Общее количество слов \"{words_counter}\"");
                writer.WriteLine($"Присутствуют цифры \"{contains_num}\"");
                writer.WriteLine($"Присутствует кириллица \"{contains_rus}\"");
                writer.WriteLine($"Присутствует латиница \"{contains_eng}\"");
                
                writer.Close();
                reader.Close();
            }
        }

        }
    }

