using System;
using System.IO;

namespace Test_Belomestnov
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@Environment.CurrentDirectory);
            Catalog now_catalog = new Catalog(dir);
            Tree_files now_tree = new Tree_files(now_catalog);
            now_tree.genetare_statics();
            now_tree.export_html();

            Console.WriteLine("The export was successful");
            Console.ReadLine();
        }
    }
}
