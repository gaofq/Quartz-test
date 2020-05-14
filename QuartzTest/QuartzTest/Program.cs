using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DispatcherManager.Init().GetAwaiter().GetResult();//异步调用方式
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            Console.Read();
        }
    }
}
