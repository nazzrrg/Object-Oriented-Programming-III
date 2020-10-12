using System;

using lab1.Core;


namespace lab1
{

    class MainClass
    {
        public static void Main(string[] args)
        {
            IniParser parser = new IniParser();

            Core.Types.Data data = parser.TryParse("input.ini");
            Console.Clear();


            data.Print();

            Console.WriteLine("\nResults:\n");
            Console.WriteLine("LEGACY_XML.ListenTcpPort(int):");
            Console.WriteLine(data.Get<int>("LEGACY_XML", "ListenTcpPort"));
            Console.WriteLine("\nCOMMON.DiskCachePath(string):");
            Console.WriteLine(data.Get<string>("COMMON", "DiskCachePath"));
            Console.WriteLine("\nADC_DEV.BufferLenSeconds(double):");
            Console.WriteLine(data.Get<double>("ADC_DEV", "BufferLenSeconds"));

        }
    }
}
