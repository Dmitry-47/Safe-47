using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Log1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Loger a = new Loger();
            a.Start_program();
            a.Exception();
            a.Warning();
            Confi d = new Confi();
            d.ThinkConfiXml();
            Console.WriteLine(d);

        //    var c = from confi in XDocument.Load(Path.Combine(Environment.CurrentDirectory, "Confi.xml")).Descendants("Confi") 


        //            select new Confi
        //            {
                       
        //                dateTimeFlag = confi.Element("dateTimeFlag").Value.ToString(),
        //                messageTypeFlag = confi.Element("messageTypeFlag").Value.ToString(),
        //                nameUserFlag = confi.Element("nameUserFlag").Value.ToString(),
        //                messageFlag = confi.Element("messageFlag").Value.ToString()
        //            };           
            
        //    foreach (var item in c)
        //    {
        //        d.dateTimeFlag = item.dateTimeFlag;
        //        d.messageTypeFlag = item.messageTypeFlag;
        //        d.nameUserFlag = item.nameUserFlag;
        //        d.messageFlag = item.messageFlag;
        //        break;
        //    }
        //    Console.WriteLine(d);
        }
    }
}
