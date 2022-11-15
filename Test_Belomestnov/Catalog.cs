using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Belomestnov
{
    class Catalog
    {
        private String name;                    // Имя каталога
        private long size;                      // Размер в байтах              
        private List<Catalog> list_catalogs;
        private List<Files> list_files;

        public List<Catalog> get_list_catalogs()
        {
            return list_catalogs;
        }

        public List<Files> get_list_files()
        {
            return list_files;
        }
        public String get_name()
        {
            return name;
        }
        public long get_size()
        {
            return size;
        }

        public Catalog(DirectoryInfo dir)
        {
            name = dir.Name;
            size = get_size_Catalog(dir);
            
            // Создаём список каталогов
            list_catalogs = new List<Catalog>();
            foreach (var item in dir.GetDirectories())
            {
                //DirectoryInfo now_dir = new DirectoryInfo(@item.Name);
                DirectoryInfo now_dir = new DirectoryInfo(@item.FullName);
                Catalog now_cat = new Catalog(now_dir);
                list_catalogs.Add(now_cat);
            }

            // Создаём спискок файлов
            list_files = new List<Files>();
            FileInfo[] fis = dir.GetFiles();
            foreach (FileInfo fi in fis)
            {
                Files now_file = new Files(fi);
                list_files.Add(now_file);
            }
        }
        
        // Получить размер каталога в байтах
        public long get_size_Catalog(DirectoryInfo dir)
        {
            long size = 0;
            // Add file sizes.
            FileInfo[] fis = dir.GetFiles();
            foreach (FileInfo fi in fis)
            {
                size += fi.Length;
            }
            // Add subdirectory sizes.
            DirectoryInfo[] dis = dir.GetDirectories();
            foreach (DirectoryInfo di in dis)
            {
                size += get_size_Catalog(di);
            }
            return size;
        }


        public void make_statistic(Catalog now_catalog, ref Stat_files statistic_files)
        {
            for (int i = 0; i < now_catalog.get_list_catalogs().Count; i++)
            {
                now_catalog.make_statistic(get_list_catalogs()[i], ref statistic_files);
                for(int j = 0; j < now_catalog.get_list_files().Count; j++)
                {
                    // Если значение уже есть - добавялем 1 в количество
                    if (statistic_files.get_stat_dict().ContainsKey(now_catalog.get_list_files()[j].get_mimeType()))
                    {
                        statistic_files.get_stat_dict()[now_catalog.get_list_files()[j].get_mimeType()] += 1;
                        statistic_files.get_stat_size()[now_catalog.get_list_files()[j].get_mimeType()] += now_catalog.get_list_files()[j].get_size();
                    }
                    // Если значения нет в словаре, то добавляем новый элемент
                    else
                    {
                        statistic_files.get_stat_dict().Add(now_catalog.get_list_files()[j].get_mimeType(), 1);
                        statistic_files.get_stat_size().Add(now_catalog.get_list_files()[j].get_mimeType(), now_catalog.get_list_files()[j].get_size());
                    }
                    statistic_files.edit_count_all(1);
                }
            }
        }
    }
}
