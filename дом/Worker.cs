using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace House
{
    public class Worker : IWorker
    {
       public string result=null;

        public string Work()
        {
            Team A = new Team();
           
            if (result == null)
              result = A.part_of_the_house_basement();
            
            else if (result == A.part_of_the_house_basement()) 
                result = A.part_of_the_house_walls();
           
            else if (result == A.part_of_the_house_walls())
                result = A.part_of_the_house_roof();
                
                         
            else if (result == A.part_of_the_house_roof())           
                result = A.part_of_the_house_door();
                
            else if (result == A.part_of_the_house_door())
                result = A.part_of_the_house_window();               
                        
            else if (result == A.part_of_the_house_window())
                Console.WriteLine($"Дом построен!! \n {result}");
               
            

            return result;
        }

        public void test_result(Worker A)
        {
            Console.WriteLine("Результаты работы на данный момент: ");
            Console.WriteLine(A.result);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
