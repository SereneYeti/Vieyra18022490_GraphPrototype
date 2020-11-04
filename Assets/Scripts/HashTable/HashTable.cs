using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Vieyra1802490_ParsingPrototype
{
    class HashTable
    {
        int SIZE = 20;

        Items[] hashItemsArray;
        Items dummyItem;

        Commands[] hashCommandsArray;
        Commands dummyCommand;

        Items[] hashInventoryArray;
        Items dummyInventory;

        public HashTable()
        {
            hashItemsArray = new Items[SIZE];
            dummyItem = null;

            hashCommandsArray = new Commands[SIZE];
            dummyCommand = null;

            hashInventoryArray = new Items[SIZE];
            dummyInventory = null;

        }

        public int hashCode(int key)
        {
            return key % SIZE;
        }

        public Items searchItem(int key)
        {
            //get the hash
            int hashIndex = hashCode(key);

            //move in array until an empty
            while (hashItemsArray[hashIndex] != null)
            {

                if (hashItemsArray[hashIndex].key == key)
                {
                    return hashItemsArray[hashIndex];
                }

                //go to next cell
                ++hashIndex;

                //wrap around the table
                hashIndex %= SIZE;
            }

            return null;
        }

        public Commands searchCommand(int key)
        {
            //get the hash
            int hashIndex = hashCode(key);

            //move in array until an empty
            while (hashCommandsArray[hashIndex] != null)
            {

                if (hashCommandsArray[hashIndex].key == key)
                {
                    return hashCommandsArray[hashIndex];
                }

                //go to next cell
                ++hashIndex;

                //wrap around the table
                hashIndex %= SIZE;
            }

            return null;
        }

        public bool findCommand(int key,string name)
        {           
            //get the hash
            int hashIndex = hashCode(key);
            
            //move in array until an empty
            while (hashCommandsArray[hashIndex] != null)
            {
                //Console.WriteLine(hashIndex);
                //Console.WriteLine(hashCommandsArray[hashIndex].key);
                //Console.WriteLine(key);
                if (hashCommandsArray[hashIndex].key == key)
                {
                    return true;
                }

                //go to next cell
                ++hashIndex;

                //wrap around the table
                hashIndex %= SIZE;
            }

            return false;
        }

        public bool findItem(string name)
        {
            int key;

            if (name.ToLower() == "chest")
            {
                key = 001;
            }
            else if (name.ToLower() == "key")
            {
                key = 002;
            }
            else if (name.ToLower() == "lamp")
            {
                key = 003;
            }
            else if (name.ToLower() == "matches")
            {
                key = 004;
            }
            else if (name.ToLower() == "table")
            {
                key = 005;
            }           
            else if (name.ToLower() == "oil")
            {
                key = 006;
            }
            else
            {
                return false;
            }
            //get the hash
            int hashIndex = hashCode(key);

            //move in array until an empty
            while (hashItemsArray[hashIndex] != null)
            {

                if (hashItemsArray[hashIndex].key == key)
                {
                    return true;
                }

                //go to next cell
                ++hashIndex;

                //wrap around the table
                hashIndex %= SIZE;
            }

            return false;
        }

        public Items searchItemName(string name)
        {            
            int key;

            if (name.ToLower() == "chest")
            {
                key = 001;
            }
            else if (name.ToLower() == "key")
            {
                key = 002;
            }
            else if (name.ToLower() == "lamp")
            {
                key = 003;
            }
            else if (name.ToLower() == "matches")
            {
                key = 004;
            }
            else if (name.ToLower() == "table")
            {
                key = 005;
            }
            else if (name.ToLower() == "oil")
            {
                key = 006;
            }
            else
            {
                return null;
            }

            //get the hash
            int hashIndex = hashCode(key);

            //move in array until an empty
            while (hashItemsArray[hashIndex] != null)
            {

                if (hashItemsArray[hashIndex].name == name)
                {
                    return hashItemsArray[hashIndex];
                }

                //go to next cell
                ++hashIndex;

                //wrap around the table
                hashIndex %= SIZE;
            }

            return null;
        }

        public void insertItem(Items Item)
        {
            Items item = new Items();
            item = Item;

            //get the hash 
            int hashIndex = hashCode(Item.key);

            //move in array until an empty or deleted cell
            while (hashItemsArray[hashIndex] != null && hashItemsArray[hashIndex].key != -1)
            {
                //go to next cell
                ++hashIndex;

                //wrap around the table
                hashIndex %= SIZE;
            }

            hashItemsArray[hashIndex] = item;
        }

        public void insertItemInInventory(Items Item)
        {
            Items item = new Items();
            item = Item;

            //get the hash 
            int hashIndex = hashCode(Item.key);

            //move in array until an empty or deleted cell
            while (hashInventoryArray[hashIndex] != null && hashInventoryArray[hashIndex].key != -1)
            {
                //go to next cell
                ++hashIndex;

                //wrap around the table
                hashIndex %= SIZE;
            }

            hashInventoryArray[hashIndex] = item;
        }

        public Items searchItemNameInInventory(string name)
        {
            int key;

            if (name.ToLower() == "chest")
            {
                key = 001;
            }
            else if (name.ToLower() == "key")
            {
                key = 002;
            }
            else if (name.ToLower() == "lamp")
            {
                key = 003;
            }
            else if (name.ToLower() == "matches")
            {
                key = 004;
            }
            else if (name.ToLower() == "table")
            {
                key = 005;
            }
            else if (name.ToLower() == "oil")
            {
                key = 006;
            }
            else
            {
                return null;
            }

            //get the hash
            int hashIndex = hashCode(key);

            //move in array until an empty
            while (hashInventoryArray[hashIndex] != null)
            {

                if (hashInventoryArray[hashIndex].name == name)
                {
                    return hashInventoryArray[hashIndex];
                }

                //go to next cell
                ++hashIndex;

                //wrap around the table
                hashIndex %= SIZE;
            }

            return null;
        }

        public Items deleteItemInInventory(Items item)
        {
            int key = item.key;

            //get the hash 
            int hashIndex = hashCode(key);

            //move in array until an empty 
            while (hashInventoryArray[hashIndex] != null)
            {

                if (hashInventoryArray[hashIndex].key == key)
                {
                    Items temp = hashInventoryArray[hashIndex];

                    //assign a dummy item at deleted position
                    hashInventoryArray[hashIndex] = dummyItem;
                    return temp;
                }

                //go to next cell
                ++hashIndex;

                //wrap around the table
                hashIndex %= SIZE;
            }

            return null;
        }

        public Items deleteItem(Items item) 
        {
            int key = item.key;

            //get the hash 
            int hashIndex = hashCode(key);

            //move in array until an empty 
            while (hashItemsArray[hashIndex] != null)
            {

                if (hashItemsArray[hashIndex].key == key)
                {
                    Items temp = hashItemsArray[hashIndex]; 
			        
                    //assign a dummy item at deleted position
                    hashItemsArray[hashIndex] = dummyItem; 
                    return temp;
                } 
		        
                //go to next cell
                ++hashIndex;
		
                //wrap around the table
                hashIndex %= SIZE;
            }

            return null;        
        }

        public Items deleteItemByName(string name)
        {
            int key;


            if (name.ToLower() == "chest")
            {
                key = 001;
            }
            else if (name.ToLower() == "key")
            {
                key = 002;
            }
            else if (name.ToLower() == "lamp")
            {
                key = 003;
            }
            else if (name.ToLower() == "matches")
            {
                key = 004;
            }
            else if (name.ToLower() == "table")
            {
                key = 005;
            }
            else if (name.ToLower() == "oil")
            {
                key = 006;
            }
            else
            {
                return null;
            }
            //get the hash 
            int hashIndex = hashCode(key);

            //move in array until an empty 
            while (hashItemsArray[hashIndex] != null)
            {

                if (hashItemsArray[hashIndex].key == key)
                {
                    Items temp = hashItemsArray[hashIndex];

                    //assign a dummy item at deleted position
                    hashItemsArray[hashIndex] = dummyItem;
                    return temp;
                }

                //go to next cell
                ++hashIndex;

                //wrap around the table
                hashIndex %= SIZE;
            }

            return null;
        }

        public string DisplayItems()
        {
            string output = "";

            for(int i = 0; i < SIZE; i++)
            {
                if(hashItemsArray[i] != null)
                {
                    output += hashItemsArray[i].ToString() + "\n";
                }
            }

            return output;
        }

        public string DisplayCommands()
        {
            string output = "";

            for (int i = 0; i < SIZE; i++)
            {
                if (hashCommandsArray[i] != null)
                {
                    output += hashCommandsArray[i].comName + "\n";
                }
            }

            return output;
        }

        public Commands searchCommandName(string name)
        {
            int key;

            if (name.ToLower() == "look")
            {
                key = 001;
            }
            else if (name.ToLower() == "use")
            {
                key = 002;
            }
            else if (name.ToLower() == "pickup")
            {
                key = 003;
            }           
            else
            {
                return null;
            }

            //get the hash
            int hashIndex = hashCode(key);

            //move in array until an empty
            while (hashCommandsArray[hashIndex] != null)
            {

                if (hashCommandsArray[hashIndex].key == key)
                {
                    return hashCommandsArray[hashIndex];
                }

                //go to next cell
                ++hashIndex;

                //wrap around the table
                hashIndex %= SIZE;
            }

            return null;
        }

        public void insertCommand(Commands Command)
        {
            Commands command = new Commands();
            command = Command;

            //get the hash 
            int hashIndex = hashCode(Command.key);

            //move in array until an empty or deleted cell
            while (hashCommandsArray[hashIndex] != null && hashCommandsArray[hashIndex].key != -1)
            {
                //go to next cell
                ++hashIndex;

                //wrap around the table
                hashIndex %= SIZE;
            }

            hashCommandsArray[hashIndex] = command;
        }

        public Commands deleteCommand(Commands Command)
        {
            int key = Command.key;

            //get the hash 
            int hashIndex = hashCode(key);

            //move in array until an empty 
            while (hashCommandsArray[hashIndex] != null)
            {

                if (hashCommandsArray[hashIndex].key == key)
                {
                    Commands temp = hashCommandsArray[hashIndex];

                    //assign a dummy item at deleted position
                    hashCommandsArray[hashIndex] = dummyCommand;
                    return temp;
                }

                //go to next cell
                ++hashIndex;

                //wrap around the table
                hashIndex %= SIZE;
            }

            return null;
        }
    }
}
