using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Atribut1
{
    class Program
    {
        static public void GetFilePoint(string puth)
        { 
         WayValidationAttribute Test = new WayValidationAttribute("Test1.xml");
            if (Test.testPuth(puth))
            {
                GetPoint(puth);
            }
            else
                Console.WriteLine("Не верное имя файла");
         }
       static public Point GetPoint(string puth)
        {           
                Point new_point = new Point();
                XmlSerializer xmlFormat = new XmlSerializer(typeof(Point));
                using (Stream fStream = File.OpenRead(puth))
                {
                    new_point = (Point)xmlFormat.Deserialize(fStream);
                }
            Console.WriteLine(new_point);
            return new_point;            
            
        }

       static public void SetFilePoint(Point anyPoint, string puth)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(Point));
            using (Stream fStream = File.Create(puth))
            {
                xmlFormat.Serialize(fStream, anyPoint);
            }
        }

        static void Main(string[] args)
        {
            Point point1 = new Point(1, 4);
            Console.WriteLine(point1);



            var xmlDoc = new XDocument(new XDeclaration("1.0", "utf-8", "no"), new XElement("Paint"));
            xmlDoc.Root.Add(new XElement("paint1"),
                new XElement("_X", point1._X),
                  new XElement("_Y", point1._Y));

            xmlDoc.Save("xmlDoc.xml");
            string nameFile = "xmlDoc.xml";

            var paint = from Paint in XDocument.Load(Path.Combine(Environment.CurrentDirectory, nameFile)).Descendants("Paint")
                        select new Point
                        {
                            _X = (int)Paint.Element("_X"),
                            _Y = (int)Paint.Element("_Y"),
                        };
            foreach (var p in paint)
            {
                Console.WriteLine(p);
            }



            XmlSerializer xmlFormat = new XmlSerializer(typeof(Point));
            using (Stream fStream = File.Create("xmlDoc.xml"))
            {
                xmlFormat.Serialize(fStream, point1);
            }
            WayValidationAttribute ioio = new WayValidationAttribute("xmlDoc.xml");
            Console.WriteLine(ioio.path);

            Point point2 = new Point();
            using (Stream fStream = File.OpenRead(ioio.path))
            {
                point2 = (Point)xmlFormat.Deserialize(fStream);
            }
            Console.WriteLine(point2);

            foreach (var atr in typeof(Point).GetCustomAttributes())
            {
                Console.WriteLine(atr);

            }

            //Point point1 = new Point(3,5);
            //SetFilePoint(point1, "xmlDoc.xml");

            GetFilePoint("Test1.xml");

        }
    }
}
