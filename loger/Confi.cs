using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Log1._1
{
    public class Confi
    {

        public string path = "Confi.xml";
        public string dateTimeFlag;

        public int Id { get; set; }
        public string messageTypeFlag { get; set; }
        public string nameUserFlag { get; set; }
        public string messageFlag { get; set; }


        public Confi()
        {

            dateTimeFlag = "Y";
            messageTypeFlag = "Y";
            nameUserFlag = "Y";
            messageFlag = "Y";

            //var xmlDoc = new XDocument(new XDeclaration("1.0", "utf-16", "No"),                   //запись  конфигурации в xml
            //   new XElement("Confi.xml"));
            //xmlDoc.Root.Add(new XElement("Confi", new XAttribute("Id", 0),
            //               new XElement("dateTimeFlag", dateTimeFlag),
            //               new XElement("messageTypeFlag", messageTypeFlag),
            //               new XElement("nameUserFlag", nameUserFlag),
            //               new XElement("messageFlag", messageFlag)));
            //xmlDoc.Save(Path.Combine(Environment.CurrentDirectory, "Confi.xml"));
        }

        public void ThinkConfiXml()
        {
            var c = from confi in XDocument.Load(Path.Combine(Environment.CurrentDirectory, "Confi.xml")).Descendants("Confi")

                    select new Confi
                    {

                        dateTimeFlag = confi.Element("dateTimeFlag").Value.ToString(),
                        messageTypeFlag = confi.Element("messageTypeFlag").Value.ToString(),
                        nameUserFlag = confi.Element("nameUserFlag").Value.ToString(),
                        messageFlag = confi.Element("messageFlag").Value.ToString()
                    };


            foreach (var item in c)
            {
                
                this.dateTimeFlag = item.dateTimeFlag;
                this.messageTypeFlag = item.messageTypeFlag;
                this.nameUserFlag = item.nameUserFlag;
                this.messageFlag = item.messageFlag;
                break;
            }
        
    

        }
        public Confi( string _dateTimeFlag, string _messageTypeFlag,  string _nameUserFlag, string _messageFlag)
        {
          
            dateTimeFlag = _dateTimeFlag;
            messageTypeFlag = _messageTypeFlag;
            nameUserFlag = _nameUserFlag;
            messageFlag = _messageFlag;
        }
      
        public override string ToString()
        {
            return $"Текущая конфигурация записи в журнал:\nДата и время- {dateTimeFlag}  \nТип сообщения- {messageTypeFlag} " +
                $" \nИмя пользователя- {nameUserFlag} \nСообщение- {messageFlag}"; 
        }
    }
}
