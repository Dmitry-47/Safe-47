using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace quiz
{
    class Program
    {

        static void Main(string[] args)
        {
            Admin admin = new Admin();
            User user = new User();
            string _Login = null;
            string _Password = null;
            int caseSwitch = 0;
            while (caseSwitch != 5)
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine($"введите: \n1 Администратор-регистрация  \n2 Администратор-войти \n3 Пользователь-регистрация \n4 Пользователь-войти \n5 Для продолжения ");
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
                        Console.WriteLine("Введите логин");
                        _Login = Console.ReadLine();
                        Console.WriteLine("Введите пароль");
                        _Password = Console.ReadLine();
                        admin.AdminStart(_Login, _Password);

                        break;

                    case 2:
                        Console.WriteLine("Введите логин");
                        _Login = Console.ReadLine();
                        Console.WriteLine("Введите пароль");
                        _Password = Console.ReadLine();
                        admin.AdminLoad(_Login, _Password);
                        Console.WriteLine("Нажмите enter");
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.WriteLine("Введите логин");
                        _Login = Console.ReadLine();
                        Console.WriteLine("Введите пароль");
                        _Password = Console.ReadLine();
                        user.User_entry(_Login, _Password);
                        Console.WriteLine("Нажмите enter");
                        Console.ReadKey();
                        break;

                    case 4:
                        Console.WriteLine("Введите логин");
                        _Login = Console.ReadLine();
                        Console.WriteLine("Введите пароль");
                        _Password = Console.ReadLine();
                        user.UserLoad(_Login, _Password);
                        Console.WriteLine("Нажмите enter");
                        Console.ReadKey();
                        break;

                    default:
                        Console.WriteLine("Bye");
                        break;

                }
            }

            if (admin.Login != null)
            {
                int caseSwitchAdmin = 0;
                while (caseSwitchAdmin != 4)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine($"введите: \n1 Добавить задание в каталог  \n2 Удалить задание из каталога \n3 Просмотреть каталог вопросов \n4 Выход");
                    Console.WriteLine();
                    try
                    {
                        caseSwitchAdmin = Convert.ToInt32(Console.ReadLine());
                       
                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine($"{exp}\nДля взаимодействия с меню нажмите клавишу 1, 2, 3, 4 затем enter\nНажмите enter для продолжения");
                        Console.ReadKey();
                    }

                    switch (caseSwitchAdmin)
                    {
                        case 1:
                            Console.WriteLine("Введите Id нового задания");
                            string _Id = Console.ReadLine();
                            Console.WriteLine("Введите условие нового задания");
                            string _Question = Console.ReadLine();
                            Console.WriteLine("Введите ожидаемый ответ для нового задания");
                            string _CorrectAnswer = Console.ReadLine();
                            admin.AdminTaskEntry(_Id, _Question, _CorrectAnswer);
                            Console.WriteLine("Нажмите enter");
                            Console.ReadKey();
                            break;

                        case 2:
                            admin.AdminShowTask();
                            Console.WriteLine("Введите Id задания, которое хотите удалить");
                            _Id = Console.ReadLine();
                            admin.AdminDeleteTask(_Id);
                            Console.WriteLine("Нажмите enter");
                            Console.ReadKey();
                            break;

                        case 3:
                            admin.AdminShowTask();
                            Console.WriteLine("Нажмите enter");
                            Console.ReadKey();
                            break;

                  

                        default:
                            Console.WriteLine("Bye");
                            break;

                    }
                }
            }
            if (user.Login != null)
            {
                int caseSwitchUser = 0;
                while (caseSwitchUser != 3)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine($"введите: \n1 Для старта игры  \n2 Для просмотра истории побед \n3 Выход  ");
                    Console.WriteLine();
                    try
                    {
                        caseSwitchUser = Convert.ToInt32(Console.ReadLine());
                        
                    }
                    catch (Exception exp)
                    {
                        Console.WriteLine($"{exp}\nДля взаимодействия с меню нажмите клавишу 1, 2, 3 затем enter\nНажмите enter для продолжения");
                        Console.ReadKey();
                    }

                    switch (caseSwitchUser)
                    {
                        case 1:
                            user.Game();
                            Console.WriteLine("Нажмите enter");
                            Console.ReadKey();
                            break;

                        case 2:
                            user.HistoryWinShow();
                            Console.WriteLine("Нажмите enter");
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
}
