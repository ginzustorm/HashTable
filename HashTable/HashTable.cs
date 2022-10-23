using System.Runtime.Serialization;

namespace HashTableProgram
{
    [Serializable]
    [DataContract]
    public class HashTable
    {
        [DataMember]
        const int TABLE_SIZE = 100;
        [DataMember]
        public Cell[] table = new Cell[TABLE_SIZE];

        // Создание события
        public event Action AddElement;
        // Чаще всего используемое
        public event EventHandler SearchElement;

        private static int HashFunc(int key)
        {
            return key % TABLE_SIZE;
        }

        public void Add(Cell cell)
        {
            int currentIndex = HashFunc(cell.data.key);
            Cell currentCell;
            if (table[currentIndex] == null)
            {
                table[currentIndex] = cell;
                // Событие
                AddElement.Invoke();
            }
            else
            {
                currentCell = table[currentIndex];
                while (currentCell.next != null)
                {
                    currentCell = currentCell.next;
                }
                currentCell.next = cell;
                AddElement.Invoke();
            }
        }

        public bool Search(string name)
        {
            int currentIndex = HashFunc(Cell.Data.getKey(name));
            if (table[currentIndex] == null)
            {
                Console.WriteLine("Элемент не найден. ");
                return false;
            } 
            else
            {
                Cell currentCell = table[currentIndex];
                while (currentCell != null)
                {
                    if (currentCell.data.Name.Equals(name))
                    {
                        Console.WriteLine(currentCell.data.Name + "\t" + currentCell.data.category + "\t" + currentCell.data.price);
                        var args = new EventArgs();
                        SearchElement.Invoke(this.table[currentIndex].data.Name, args);
                        return true;
                    }
                    else
                    {
                        currentCell = currentCell.next;
                    }
                }
            }
            return false;
        }

        public void Remove(string name)
        {
            if (Search(name))
            {
                int currentIndex = HashFunc(Cell.Data.getKey(name));
                Cell currentCell = table[currentIndex];
                int i = 0;
                if (currentCell.data.Name.Equals(name))
                {
                    table[currentIndex] = table[currentIndex].next;
                    Console.WriteLine(name + " удален");
                    return;
                }
                else
                {
                    while (!currentCell.next.data.Name.Equals(name))
                    {
                        currentCell = currentCell.next;
                    }
                    if (currentCell.next.next == null)
                    {
                        currentCell.next = null;
                        Console.WriteLine(name + " удален");
                        return;
                    }
                    else
                    {
                        currentCell.next = currentCell.next.next;
                        Console.WriteLine(name + " удален");
                        return;
                    }
                }
            }
        }

        public void PrintHashTable (HashTable hashTable)
        {
            for(int i=0; i<TABLE_SIZE; i++)
            {
                if (hashTable.table[i] == null)
                {
                    Console.WriteLine($"{i}: null");
                }
                else
                {
                    Cell currentCell = hashTable.table[i];
                    Console.Write($"{i}: ");
                    while (currentCell != null)
                    {
                        Console.Write($"[{currentCell.data.Name}, {currentCell.data.category}, {currentCell.data.price}] ");
                        currentCell = currentCell.next;
                    }
                    Console.WriteLine();
                }
            }
        }

        //Для отработки делегатов
        public void PrintCategory(int index)
        {
            Console.WriteLine(table[index].data.category);
        }

        public void PrintPrice(int index)
        {
            Console.WriteLine(table[index].data.price);
        }

        public void PrintName(int index)
        {
            Console.WriteLine(table[index].data.Name);
        }
    }
}
