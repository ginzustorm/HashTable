using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HashTableProgram;

public class Cell
{
    public Data data;
    public Cell next;

    public Cell(string name, string category, int price)
    {
        data = new Data(name, category, price);
    }

    public class Data
    {
        public string name { get; set; }
        public int key;
        private List<string> categoryList = new List<string>() { "CPU", "MOTHERBOARD", "RAM", "GPU", "COOLER" };
        public string category;
        public int price;

        public Data(string name, string category, int price)
        {
            if (name == null) throw new ArgumentNullException("Имя товара не может быть равно null", nameof(name));
            if (category == null || !this.categoryList.Contains(category)) throw new Exception("Категория не найдена или равна null");
            if (price < 0 || price == null) throw new Exception("Цена меньше нуля или null");

            this.name = name;
            this.price = price;
            this.category = category;
            this.key = getKey(name);
        }

        public static int getKey(string name)
        {
            int key = 0;
            char[] chName = name.ToCharArray();
            for (int i = 0; i < chName.Length; i++)
            {
                key = key + (chName[i] - '0');
            }
            return key;
        }
    }
}
