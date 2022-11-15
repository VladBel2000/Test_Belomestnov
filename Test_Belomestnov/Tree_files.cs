using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Belomestnov
{
    class Tree_files
    {
        private Catalog head;
        private Stat_files statistic_files;

        public Tree_files(Catalog now_catalog)
        {
            head = now_catalog;
            statistic_files = new Stat_files();
        }

        public Catalog get_head()
        {
            return head;
        }
        public void genetare_statics()
        {
            head.make_statistic(head, ref statistic_files);
        }
        public void export_html()
        {
            using (FileStream fs = new FileStream("rez.html", FileMode.Create))
            {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {
                    Catalog now_catalog = head;
                    w.WriteLine("<H1> Корневой каталог:" + head.get_name() + " - Размер (в байтах):" + head.get_size() + "</H1>");
                    export_catalog(now_catalog);
                    void export_catalog (Catalog now_catalog)
                    {
                        // Печатаем все файлы данного каталога
                        for (int i = 0; i < now_catalog.get_list_files().Count; i++)
                        {
                            w.WriteLine("<H2> Файл:" + now_catalog.get_list_files()[i].get_name() +
                                        " - Размер (в байтах):" + now_catalog.get_list_files()[i].get_size() +
                                            " - MimeType:" + now_catalog.get_list_files()[i].get_mimeType() +
                                            "</H2>");
                        }
                        for (int i = 0; i < now_catalog.get_list_catalogs().Count; i++)
                        {
                            w.WriteLine("<H2> Каталог:" + now_catalog.get_list_catalogs()[i].get_name() + " - Размер (в байтах):" + now_catalog.get_list_catalogs()[i].get_size() + "</H2>");
                            export_catalog(now_catalog.get_list_catalogs()[i]);
                        }
                    }
                }
            }
        }

    }
}
