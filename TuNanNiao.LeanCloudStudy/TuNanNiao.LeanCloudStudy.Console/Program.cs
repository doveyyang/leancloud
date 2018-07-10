using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TuNanNiao.LeanCloudStudy.Con.LeanCloud;

namespace TuNanNiao.LeanCloudStudy.Con
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                LeanCloudHelper.InitLeanCloud();
                TestLeanCloud.Show();

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Exception"+ex.Message);
            }
            Console.ReadLine();
        }
    }
}
