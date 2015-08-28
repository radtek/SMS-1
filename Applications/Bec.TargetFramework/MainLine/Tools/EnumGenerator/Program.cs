using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassificationTypeEnumGenerator generate = new ClassificationTypeEnumGenerator();

            generate.Initialize(@"C:\boo\ClassificationEnum.cs");

            generate.Generate();

            Console.ReadLine();

        }
    }
}
