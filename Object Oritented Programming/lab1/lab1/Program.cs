using System;
using lab1.Core.Types;
using lab1.Core;


namespace lab1
{

    class MainClass
    {
        public static void Main(string[] args)
        {
            try
            {
                iniReader reader = new iniReader();
                IniParser parser = new IniParser();

                Data data = parser.TryParse(reader.ReadFile("input.ini"));

                Console.Clear();

                data.Print();

                Console.WriteLine("\nResults:\n");
                Console.WriteLine("LEGACY_XML ListenTcpPort(int):");
                Console.WriteLine(data.Get<int>("LEGACY_XML", "ListenTcpPort"));
                Console.WriteLine("\nCOMMON DiskCachePath(string):");
                Console.WriteLine(data.Get<string>("COMMON", "DiskCachePath"));
                Console.WriteLine("\nADC_DEV BufferLenSeconds(double):");
                Console.WriteLine(data.Get<double>("ADC_DEV", "BufferLenSeconds"));
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
