using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Belomestnov
{
    class Files
    {
        private String name;
        private double size;        // Размер в байтах
        private string mimeType;

        public Files(FileInfo fi)
        {
            name = fi.Name;
            size = fi.Length;
            mimeType = GetContentType(fi.Name);
        }
        public string get_mimeType()
        {
            return mimeType;
        }
        public double get_size()
        {
            return size;
        }
        public String get_name()
        {
            return name;
        }

        // Получить mimeType
        public string GetContentType(string fname)
        {
            string extension = Path.GetExtension(fname).ToLowerInvariant();
            if (extension.Length > 0 && MIMEAssistant.get_dict().ContainsKey(extension.Remove(0, 1)))
            {
                return MIMEAssistant.get_dict()[extension.Remove(0, 1)];
            }
            return "unknown/unknown";
        }
    }
}
