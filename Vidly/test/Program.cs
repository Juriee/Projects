using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
   public  class Program
    {
      public static void Main(string[] args)
        {
            var hui =Guid.NewGuid();
            Console.WriteLine(hui.ToString()) ;
            Console.Read();
        }

    }
}
