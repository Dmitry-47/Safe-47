using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace quiz
{
    public class Task
    {
        public string Id { get; set; }
        public string Question { get; set; }
        public string CorrectAnswer { get; set; }
        public string Name = "TaskBase";

        public Task()
        {

        }
        public Task(string _Id ,string _Question, string _CorrectAnswer)

        {
            Id = _Id;
            Question = _Question;                                                               
            CorrectAnswer = _CorrectAnswer;
           


        }
       
        public void Task_entry()
        {
            try
                {
                var listTask = from word in XDocument.Load(Path.Combine(Environment.CurrentDirectory, this.Name + ".xml")).Descendants("Task")

                               select new Task
                               {
                                   Id = word.Element("Id").Value.ToString(),
                                   Question = word.Element("Question").Value.ToString(),
                                   CorrectAnswer = word.Element("CorrectAnswer").Value.ToString()

                               };

                int flag = 0;
                foreach (var item in listTask)
                {

                    if (Id == item.Id)
                    {
                        flag = 1;
                    }

                }

                if (flag != 1)
                {
                    var xmlDoc = XDocument.Load(Path.Combine(Environment.CurrentDirectory, this.Name + ".xml"));

                    xmlDoc.Element("Task").Add(new XElement(("Task"),
                                     new XElement("Id", this.Id),
                                   new XElement("Question", this.Question),
                                  new XElement("CorrectAnswer", this.CorrectAnswer)));

                    xmlDoc.Save(Path.Combine(Environment.CurrentDirectory, this.Name + ".xml"));
                }
                else
                {
                    Console.WriteLine($"Задание под номером {this.Id} уже существует и не может быть добавленно");
                    Console.WriteLine();
                }

            }

            catch(Exception exp)

            {
                var xmlDoc = new XDocument(new XDeclaration("1.0", "utf=16", "yes"),
               new XElement("Task"));                                                           //создание каталога заданий

                xmlDoc.Root.Add(new XElement("Id", this.Id),
                               new XElement("Question", this.Question),
                               new XElement("CorrectAnswer", this.CorrectAnswer));
                xmlDoc.Save(Path.Combine(Environment.CurrentDirectory, this.Name + ".xml"));

            }

        }

        public void DeleteTask(string _Id)
        {
            try
            {
                var xmlDoc = XDocument.Load(Path.Combine(Environment.CurrentDirectory, this.Name + ".xml"));
              
                    xmlDoc.Element("Task").Elements("Task").Where(x => x.Element("Id").Value == _Id).FirstOrDefault().Remove();               
                  xmlDoc.Save(Path.Combine(Environment.CurrentDirectory, this.Name + ".xml"));
                 Console.WriteLine($"Задание с Id {_Id} было удалено");
                Console.WriteLine();
            }
            catch (Exception exp)
            {
                Console.WriteLine($"{exp}\nЗадания с таким Id нет в каталоге и оно не может быть удалено\nдля продолжения нажмите enter");
                Console.WriteLine();
            }

        }
        public void ShowTask()
        {
            var listTask = from word in XDocument.Load(Path.Combine(Environment.CurrentDirectory, this.Name + ".xml")).Descendants("Task")

                           select new Task
                           {
                               Id = word.Element("Id").Value.ToString(),
                               Question = word.Element("Question").Value.ToString(),
                               CorrectAnswer = word.Element("CorrectAnswer").Value.ToString()

                           };

            
            foreach (var item in listTask)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
        }
        public void LoadTask(string _Id)
        {
             
            var listTask = from word in XDocument.Load(Path.Combine(Environment.CurrentDirectory, this.Name + ".xml")).Descendants("Task")

                           select new Task
                           {
                               Id = word.Element("Id").Value.ToString(),
                               Question = word.Element("Question").Value.ToString(),
                               CorrectAnswer = word.Element("CorrectAnswer").Value.ToString()

                           };

            int flag = 0;
            
            foreach (var item in listTask)
            {
                if (item.Id == _Id)
                {
                    Id = item.Id;
                    Question = item.Question;
                    CorrectAnswer = item.CorrectAnswer;
                    flag = 1;
                }
                
            }
            
            
            if (flag != 1)
            Console.WriteLine($"Задания с Id {_Id} еще нет в каталоге");
            Console.WriteLine();
            
        }

        public override string ToString()
        {
            return $"Номер вопроса {Id}\nВопрос:{Question} ";
        }
    }
}
