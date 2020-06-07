using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Atribut1
{
   
    [WayValidation]
   public class Point
    {
        public  int _X { get; set; }
        public  int _Y { get; set; }

        public Point()
        {
            _X = 0;
            _Y = 0;
        }

        public Point(int X, int Y)
        {
            _X = X;
            _Y = Y;
            
        }

      public void SetFilePoint(Point anyPoint, string puth)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(Point));
            using (Stream fStream = File.Create(puth))
            {
                xmlFormat.Serialize(fStream, anyPoint);
            }
        }

        //public Point SetFilePoint(string puth)
        //{
        //    Point new_point = new Point();
        //    XmlSerializer xmlFormat = new XmlSerializer(typeof(Point));
        //    using (Stream fStream = File.OpenRead(puth))
        //    {
        //        new_point = (Point)xmlFormat.Deserialize(fStream);
        //    }
        //    Console.WriteLine(new_point);
        //    return new_point;
        //}



        public override string ToString()
        {
            return $"X={_X}  Y={_Y}"; 
        }
    }
}
