using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace quiz
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }

       public User() { }

        public void HistoryWinShow()
        {
            try {
            Task task = new Task();
            task.Name = this.Login + "Win";
            task.ShowTask();
            }

            catch(Exception exp)

            {
                Console.WriteLine("У вас еще нет побед. \nДля продолжения нажмите enter");
            }
           
        }

        public void UserLoad(string _Login, string _Password)

        {
            
                var listUser = from word in XDocument.Load(Path.Combine(Environment.CurrentDirectory, "User.xml")).Descendants("User")

                               select new User
                               {

                                   Login = word.Element("Login").Value.ToString(),
                                   Password = word.Element("Password").Value.ToString()

                               };

                int flag = 0;
                foreach (var item in listUser)
                {
                    if (item.Login == _Login && item.Password == _Password)
                    {
                        Login = _Login;
                        Password = _Password;
                        flag = 1;
                    }

                }
                if (flag != 1)
                {
                    Console.WriteLine("Неправильный логин или пароль!");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine($"Профиль {Login} загружен");
                    Console.WriteLine();
                }

            
            
        }

        public void User_entry(string _Login, string _Password)
        {
            Login = _Login;
            Password = _Password;

            try
            { 

            var xmlDoc = XDocument.Load(Path.Combine(Environment.CurrentDirectory, "User.xml"));

            xmlDoc.Element("User").Add(new XElement(("User"),
                             new XElement("Login", this.Login),
                           new XElement("Password", this.Password)));

            xmlDoc.Save(Path.Combine(Environment.CurrentDirectory, "User.xml"));
            Console.WriteLine($"Пользователь: {this.Login} Пароль: {this.Password} \nБыл добавлен в каталог");
            Console.WriteLine();
            }

            catch(Exception exp)

            {
                var xmlDoc = new XDocument(new XDeclaration("1.0", "utf=16", "yes"),
                new XElement("User"));
                xmlDoc.Root.Add(new XElement("Login", this.Login),
                               new XElement("Password", this.Password));
                xmlDoc.Save(Path.Combine(Environment.CurrentDirectory, "User.xml"));
            }
        }
        public void HistoryWinEntry(Task other)
        {
            other.Name = this.Login+"Win";
            other.Task_entry();
        }
        public void Game()
        {
            Task task = new Task();
            task.ShowTask();
            Console.WriteLine("Выберете заданиe, введите его номер");
            string Id = Console.ReadLine();
            try
            { 
            task.LoadTask(Id);
           
            char[] maska=new char[task.CorrectAnswer.Length];
            int temp = 0;
            for (int i = 0; i < task.CorrectAnswer.Length; i++)
            {
                maska[i] = '#';
                temp++;
            }
            char letter;
            int error = 5;
            int flagError = 0;
            Console.Clear();
            while (temp != 0 && error!=0)
            {                               
                flagError = 0;
                Console.WriteLine("Используйте кириллицу-нижний регистр");
                Console.WriteLine($"Задание:");
                Console.WriteLine(task.Question);
                Console.WriteLine();
                Console.WriteLine($"Вы можете ошибиться {error} раз");
                Console.WriteLine();
                Console.Write("Загаданное слово: ");
                Console.WriteLine(maska);
                Console.WriteLine("Введите букву");
                Console.WriteLine();
                letter=Convert.ToChar(Console.ReadLine());
                Console.WriteLine();               
                               
                for (int i = 0; i < task.CorrectAnswer.Length; i++)
                {
                    if (task.CorrectAnswer[i] == letter)
                    {
                        maska[i] = letter;
                        temp--;
                        flagError = 1;
                       
                    }
                   
                }
                if (flagError == 0)
                {
                    error--;
                }
                Console.Clear();

                string str = new string(maska);
                if(str == task.CorrectAnswer)
                {
                    Console.WriteLine("Это правильный ответ");
                    HistoryWinEntry(task);
                }
                else
                {
                    Console.WriteLine("Вы ошиблись");
                }               
            }
                if (error == 0)
                {
                    Console.WriteLine("Вы проиграли");
                }
                else
                {
                    Console.WriteLine("Вы победили");
                }
               
            }

             catch (Exception exp)

            {
                Console.WriteLine(exp);
            }

        }
    

        public override string ToString()
             {
                return $"Логин:{Login} \nПароль:{Password} ";
             }
    
    }
}
