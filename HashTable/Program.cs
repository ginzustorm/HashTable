using HashTableProgram;
using System;

HashTable hashTable = new HashTable();

hashTable.Add(new Cell("RTX 2070", "GPU", 38000));
hashTable.Add(new Cell("2070 RTX", "GPU", 39000));
hashTable.Add(new Cell("7020 RTX", "GPU", 40000));
hashTable.Add(new Cell("7002 RTX", "GPU", 40000));

hashTable.PrintHashTable(hashTable);

hashTable.Remove("7020 RTX");
hashTable.PrintHashTable(hashTable);




