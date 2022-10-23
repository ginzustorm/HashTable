using System.Runtime.Serialization;

namespace HashTableProgram;

[Serializable]
[DataContract]
public class Cell
{
    [DataMember]
    public Data data;
    public Cell next;

    public Cell() { } // для xml

    public Cell(string name, string category, int price)
    {
        data = new Data(name, category, price);
    }

    [Serializable]
    [DataContract]
    public class Data
    {
        [DataMember]
        public string Name { get; set; }
        public int key;
        private List<string> categoryList = new List<string>() { "CPU", "MOTHERBOARD", "RAM", "GPU", "COOLER" };
        [DataMember]
        public string category;
        [DataMember]
        public int price;

        public Data() { } // для xml

        public Data(string name, string category, int price)
        {
            if (category == null || !this.categoryList.Contains(category)) throw new Exception("Категория не найдена или равна null");
            if (price < 0) throw new Exception("Цена меньше нуля");

            this.Name = name ?? throw new ArgumentNullException("Имя товара не может быть равно null", nameof(name));
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
