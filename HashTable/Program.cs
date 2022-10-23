using HashTableProgram;
using System;
using System.Reflection;

public class Program
{
    static void Main()
    {
        HashTable hashTable = new HashTable();
        hashTable.AddElement += HashTable_AddElement;
        hashTable.SearchElement += HashTable_SearchElement;

        hashTable.Add(new Cell("RTX 2070", "GPU", 38000));
        hashTable.Add(new Cell("2070 RTX", "GPU", 39000));
        hashTable.Add(new Cell("7020 RTX", "GPU", 40000));
        hashTable.Add(new Cell("7002 RTX", "GPU", 40000));
        hashTable.Search("RTX 2070");

        hashTable.PrintHashTable(hashTable);

        hashTable.Remove("7020 RTX");
        hashTable.PrintHashTable(hashTable);

        /*tableDelegate myDelegate = hashTable.PrintCategory;
        myDelegate(3);
        myDelegate += hashTable.PrintPrice;
        myDelegate(3);

        tableDelegate myDelegate2 = new tableDelegate(hashTable.PrintCategory);
        myDelegate2.Invoke(3);

        var myDelegate3 = myDelegate2 + myDelegate;
        myDelegate3.Invoke(3);

        //public Action ActionDelegate; - шаблонный делегат без возвращаемого значения и параметров
        //public Action<int> ActionDelegate; - шаблонный делегат без возвращаемого значения, но имеющий параметр(ы)
        //public Predicate<int> ActionDelegate; - шаблонный делегат, возвращающий bool, имеющий параметр(ы)
        //public Func<int, string> ActionDelegate; - int - параметр, последнее - возвращаемое значение. Должен возвращать значение
        
        Type type = typeof(HashTable);

        var properties = type.GetProperties();
        foreach(var prop in properties)
        {
            Console.WriteLine(prop.Name); 
        }
        */
    }

    private static void HashTable_SearchElement(object? sender, EventArgs e)
    {
        if (sender as string == null) { return; }
        Console.WriteLine($"{(string)sender} - искомый элемент (событие обработано)");
    }

    private static void HashTable_AddElement()
    {
        Console.WriteLine("Обработчик события добавления элемента");
    }

    //public delegate void tableDelegate(int i);
}





