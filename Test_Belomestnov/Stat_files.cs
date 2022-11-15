using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Belomestnov
{
    class Stat_files
    {
        private int count_all;
        private static readonly Dictionary<string, int> TypeDictionary = new Dictionary<string, int>();
        private static readonly Dictionary<string, double> SizeDictionary = new Dictionary<string, double>();

        public Stat_files()
        {
            count_all = 0;
        }
        public Dictionary<string, int> get_stat_dict()
        {
            return TypeDictionary;
        }
        public Dictionary<string, double> get_stat_size()
        {
            return SizeDictionary;
        }
        public void edit_count_all(int x)
        {
            count_all = count_all + x;
        }
    }
}
