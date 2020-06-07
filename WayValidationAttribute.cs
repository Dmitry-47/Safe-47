using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Atribut1
{
    [AttributeUsage(AttributeTargets.All)]
    class WayValidationAttribute : Attribute
    {
      public string _nameFile { get; set; } 
      public string path { get; set; }  

       public WayValidationAttribute() { }

        public WayValidationAttribute(string nameFile)
        {
           _nameFile = nameFile;
            path = Path.Combine(Environment.CurrentDirectory, nameFile);
        }
        public bool testPuth(string puth)
        {
            if (this._nameFile ==  puth)
            {
                return true;
            }
            else
                return false;

        }

        public override string ToString()
        {
            return $"{path}"; 
        }
    }
}
