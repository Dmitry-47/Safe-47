using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Log1._1
{

    public class Loger
    {
        public string path = "log.xml";
        public DateTime dateTime;
        public string messageType { get; set; }
        public string nameUser { get; set; }
        public string Message { get; set; }

        public Loger()
        {

        }
        public  Loger(string _messageType, string _Message)
        {
            dateTime = DateTime.Now;
            messageType = _messageType;
            nameUser = "User";
            Message = _Message;
        }
        public void Start_program()
        {
            Loger StartProgram = new Loger("Системное сообщение", "Старт программы");

            var xmlDoc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("Log"));
            xmlDoc.Root.Add(new XElement(("Start_Program"),
                           new XElement("Date_Time", StartProgram.dateTime),
                           new XElement("Message_Type", StartProgram.messageType),
                           new XElement("Name_User", StartProgram.nameUser),
                           new XElement("Message", StartProgram.Message)));
            xmlDoc.Save(Path.Combine(Environment.CurrentDirectory, StartProgram.path));
        }
        public void Exception()
        {
            Loger ExceptionProgram = new Loger("Системное сообщение", "Ошибка");

            Log_entry(ExceptionProgram);

        }
        public void Info()
        {
            Loger ExceptionProgram = new Loger("Информационное сообщение", " ");

            Log_entry(ExceptionProgram);

        }

        public void Warning()
        {
            Loger ExceptionProgram = new Loger("Предупреждение", "Предкпреждение");

            Log_entry(ExceptionProgram);

        }



        public void Log_entry(Loger other)
        {
            Confi confi = new Confi();
            confi.ThinkConfiXml();


            var xmlDoc = XDocument.Load(Path.Combine(Environment.CurrentDirectory, other.path));

            if (confi.dateTimeFlag == "Y")
            { 
            xmlDoc.Element("Log").Add(new XElement(("New_Event"),
                           new XElement("Date_Time", other.dateTime)));
            }

            if (confi.messageTypeFlag == "Y")
            {
                xmlDoc.Element("Log").Add(new XElement(("New_Event"),
            new XElement("Message_Type", other.messageType)));
            }

            if (confi.nameUserFlag == "Y")
            {
                xmlDoc.Element("Log").Add(new XElement(("New_Event"),
                           new XElement("Name_User", other.nameUser)));
            }


            if (confi.messageFlag == "Y")
            {
                xmlDoc.Element("Log").Add(new XElement(("New_Event"),
                           new XElement("Message", other.Message)));
            }
            xmlDoc.Save(Path.Combine(Environment.CurrentDirectory, other.path));
        }


    }
}
