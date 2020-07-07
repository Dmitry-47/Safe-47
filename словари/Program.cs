using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace dictionary
{
    class Program
    {
        public static void Translation(string _Word)
        {
            try { 
            var listWord = from word in XDocument.Load(Path.Combine(Environment.CurrentDirectory, "Dictionary.xml")).Descendants("Word")

                           select new Word
                           {

                               RusWord = word.Element("RusWord").Value.ToString(),
                               EngWord = word.Element("EngWord").Value.ToString()

                           };


            foreach (var item in listWord)
            {
                if (item.RusWord == _Word)
                {
                    Console.WriteLine(item.EngWord);
                }
                else if (item.EngWord == _Word)
                {
                    Console.WriteLine(item.RusWord);
                }
            }
            }
            catch (Exception exp)
            {
                Console.WriteLine("Такого слова нет в каталоге");
            }
        }
        public static void DeleteWord(string _otherWord, string _language)
        {
            try
            {
                var xmlDoc = XDocument.Load(Path.Combine(Environment.CurrentDirectory, "Dictionary.xml"));
                if (_language == "Rus")
                    xmlDoc.Element("Word").Elements("Word").Where(x => x.Element("RusWord").Value == _otherWord).FirstOrDefault().Remove();
                else if (_language == "Eng")
                    xmlDoc.Element("Word").Elements("Word").Where(x => x.Element("EngWord").Value == _otherWord).FirstOrDefault().Remove();
                xmlDoc.Save(Path.Combine(Environment.CurrentDirectory, "Dictionary.xml"));
                Console.WriteLine($"{_otherWord} было удалено");
            }
            catch (Exception exp)
            {
                Console.WriteLine($"{exp}\nТакого слова нет в словаре или неправильно указан язык!!\nдля продолжения нажмите enter");
            }

        }
        public static void ChangeTranslation(string _otherWord, string _Translation, string _language)
        {
            try
            {
                var xmlDoc = XDocument.Load(Path.Combine(Environment.CurrentDirectory, "Dictionary.xml"));
                if (_language == "Rus")
                    xmlDoc.Element("Word").Elements("Word").Where(x => x.Element("RusWord").Value == _otherWord).FirstOrDefault().SetElementValue("RusWord", _Translation);
                else if (_language == "Eng")
                    xmlDoc.Element("Word").Elements("Word").Where(x => x.Element("EngWord").Value == _otherWord).FirstOrDefault().SetElementValue("EngWord", _Translation);
                xmlDoc.Save(Path.Combine(Environment.CurrentDirectory, "Dictionary.xml"));
            }
            catch (Exception exp)
            {
                Console.WriteLine($"{exp}\nТакого слова нет в словаре или неправильно указан язык!!\nдля продолжения нажмите enter");
            }

        }


        static void Main(string[] args)
        {
            int caseSwitch = 0;
            string Word;
            string Word2;
            string language;
            while (caseSwitch != 5)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine($"введите: \n1 для перевода \n2 для удаления слова из словаря \n3 для добавления слова в словарь " +
                    $"\n4 для изьенения уже существующего перевода \n5 для выхода");
                Console.WriteLine();
                try
                { 
                caseSwitch = Convert.ToInt32(Console.ReadLine());                    
                }
                catch (Exception exp)
                {
                    Console.WriteLine($"{exp}\nДля взаимодействия с меню нажмите клавишу 1, 2, 3, 4 или 5 затем enter\nНажмите enter для продолжения");
                    Console.ReadKey();
                }

                switch (caseSwitch)
                {
                    case 1:
                        Console.Write("Введите слово: ");
                        Word = Console.ReadLine();
                        Console.Write("Перевод: ");
                        Translation(Word);
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.WriteLine("Введите слово: ");
                        Word = Console.ReadLine();
                        Console.WriteLine("Выберете язык в формате Rus или Eng: ");
                        language = Console.ReadLine();
                        DeleteWord(Word, language);
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.WriteLine("Введите слово(Rus): ");
                        Word = Console.ReadLine();
                        Console.WriteLine("Введите перевод(Eng): ");
                        language = Console.ReadLine();
                        Word NewWord = new Word(Word, language);
                        NewWord.Word_entry();
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.WriteLine("Введите слово: ");
                        Word = Console.ReadLine();
                        Console.WriteLine("Выберете язык в формате Rus или Eng: ");
                        language = Console.ReadLine();
                        Console.WriteLine("Введите новый перевод: ");
                        Word2 = Console.ReadLine();
                        ChangeTranslation(Word, Word2, language);
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Bye");
                        break;

                }
                              
            }
        }
    }
}
