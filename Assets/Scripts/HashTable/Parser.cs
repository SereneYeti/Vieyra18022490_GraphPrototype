using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

namespace Vieyra1802490_ParsingPrototype
{
    class Parser
    {
        public string inputText;
        public string outputText;
        public string inventoryText = "";

        delegate string ParseCommand(string[] parameters);

        #region Items
        public Items chest = new Items();
        public Items oil = new Items();
        public Items chestKey = new Items();
        public Items lamp = new Items();
        public Items matches = new Items();
        public Items table = new Items();
        public HashTable ItemsHashTable = new HashTable();
        bool lampLit = false;
        #endregion
        #region Commands
        Commands lookCommand = new Commands();
        Commands useCommand = new Commands();
        Commands pickupCommand = new Commands();
        Commands commands = new Commands();
        public HashTable commandsHashTable = new HashTable();
        Dictionary<string, ParseCommand> CommandsDict = new Dictionary<string, ParseCommand>();
        #endregion
        #region Inventory
        public HashTable InventoryHashTable = new HashTable();        
        #endregion
        //HashTable Inventory = new HashTable();
        //NOTE NEED TO UPDATE PROTOTYPE TO USE HASH TABLE
        //Dictionary<string, string> Discriptions = new Dictionary<string, string>();
        //Dictionary<string, string> Inventory = new Dictionary<string, string>();


        public Parser()
        {
            inputText = "";
            
        }

        public void Start()
        {
            chest.name = "chest";
            chest.discription = "You see an old weatherworn iron chest.";
            chest.key = 001;
            chest.gameObject = GameObject.FindGameObjectWithTag(chest.name);

            chestKey.name = "key";
            chestKey.discription = "Its a big bronze key";
            chestKey.key = 002;
            chestKey.gameObject = GameObject.FindGameObjectWithTag(chestKey.name);

            lamp.name = "lamp";
            lamp.discription = "An old lamp that could be lit, this could be lit with matches.";
            lamp.key = 003;
            lamp.gameObject = GameObject.FindGameObjectWithTag(lamp.name);

            matches.name = "matches";
            matches.discription = "The matches look old but may just work...";
            matches.key = 004;
            matches.gameObject = GameObject.FindGameObjectWithTag(matches.name);

            table.name = "table";
            table.discription = "You see an old dusty table with a key and lamp on it.";
            table.key = 005;
            table.gameObject = GameObject.FindGameObjectWithTag(table.name);

            oil.name = "oil";
            oil.discription = "You see a bottle of oil for a lamp.";
            oil.key = 006;
            oil.gameObject = GameObject.FindGameObjectWithTag(oil.name);

            lampLit = false;

            ItemsHashTable.insertItem(chest);
            ItemsHashTable.insertItem(chestKey);
            ItemsHashTable.insertItem(lamp);
            ItemsHashTable.insertItem(matches);

            lookCommand.key = 001;
            lookCommand.comName = "look";

            useCommand.key = 002;
            useCommand.comName = "use";

            pickupCommand.key = 003;
            pickupCommand.comName = "pickup";

            commandsHashTable.insertCommand(lookCommand);
            commandsHashTable.insertCommand(useCommand);
            commandsHashTable.insertCommand(pickupCommand);

            Console.WriteLine("Available Commands:\n" + commandsHashTable.DisplayCommands());
            //Console.WriteLine(itemsHashTable.DisplayItems());

            CommandsDict.Add("look", Look);
            CommandsDict.Add("use", Use);
            CommandsDict.Add("pickup", Pickup);

            //Discriptions.Add("chest", "You see an old weatherworn iron chest.");
            //Discriptions.Add("key", "Its a big bronze key.");
            //Discriptions.Add("lamp", "It's providing a dim reddish light.");
        }

        public void Parse()
        {
            string output = "";
            string[] words = GetWords(inputText);
            ParseCommand handler;
            try
            {
                int key = -1;

                if (words[0] == "look")
                {
                   //Console.WriteLine("look");
                    key = 001;
                }
                else if (words[0] == "use")
                {
                    //Console.WriteLine("use");
                    key = 002;
                }
                else if (words[0] == "pickup")
                {
                    //Console.WriteLine("pickup");
                    key = 003;
                }
                

                //Console.WriteLine(words[0]);
                //Console.WriteLine(commandsHashTable.findCommand(key,words[0]));
                
                if (commandsHashTable.findCommand(key,words[0]))
                {
                    //Console.WriteLine(commandsHashTable.searchCommandName(words[0]).comName);
                    CommandsDict.TryGetValue(commandsHashTable.searchCommandName(words[0]).comName, out handler );
                    //Console.WriteLine(handler(words));
                    output += handler(words);
                }
                    
            }
            catch (Exception ex)
            {
                outputText = "Please try again.";
                Debug.Log(ex);
            }


            outputText = output;
        }

        string[] GetWords(string s)
        {
            s = s.Trim().ToLower();
            return s.Split(' ');
        }

        public string Look(string[] words)
        {
            string output = "";
            string lookAtObject;
            if (words[1] == "at")
            {
                lookAtObject = words[2];
            }
            else
            {
                lookAtObject = words[1];
            }

            try
            {
                //Console.WriteLine(lookAtObject);
                //Console.WriteLine(ItemsHashTable.findItem(lookAtObject));
                //string Description;
                if (ItemsHashTable.findItem(lookAtObject))
                {
                    //Console.WriteLine("Nohere");
                    output += ItemsHashTable.searchItemName(lookAtObject).discription;

                }
                    
            }
            catch (Exception ex)
            {
                outputText = "I dont see that object.";
                Debug.Log(ex);
            }

            outputText = output;
            return outputText;
        }

        public string Use(string[] words)
        {
            string output = "";
            string useObject = words[1];
            string targetObject;

            if (words[2] == "on")
            {
                targetObject = words[3];
            }
            else if((words[2] == "and")&&(words[4] == "on"))
            {
                output = "You can't do that at the same time!";
                return output;
            }            
            else
            {
                targetObject = words[2];
            }

            output += "You use the " + useObject + " on the " + targetObject;

            //Another Dictionary of Use Methods <-- Neater
            //      OR
            //Just add game Code
            try
            {
                //Console.WriteLine("target -" + targetObject + "use - " + useObject);
                if (targetObject == "chest" && useObject == "key"&&lampLit)
                {
                    output = "You opened the chest and retrieved the treasure congratulations!";
                }
                else if (targetObject == "lamp" && useObject == "matches")
                {
                    lampLit = true;
                    //Console.WriteLine("You turn on the lamp and see a large chest resting in the corner.");                
                    output = "You turn on the lamp and see a key on the table for the large chest resting in the corner.";
                }
                else if (targetObject == "lamp" && useObject == "oil")
                {                    
                    //Console.WriteLine("You turn on the lamp and see a large chest resting in the corner.");                
                    output = "You put oil in the lamp, it will now burn for longer.";
                }
            }
            catch (Exception ex)
            {
                outputText = "I can't do that.";
                Debug.Log(ex);
            }

            
            outputText = output;
            return outputText;
        }

        public string Pickup(string[] words)
        {
            string output = "";
            string pickupObject = words[1];

            try
            {
                if (ItemsHashTable.findItem(pickupObject))
                {
                    output += "You add " + pickupObject + " to your inventory.";
                    GameObject.Destroy(GameObject.FindGameObjectWithTag(pickupObject));                    
                    InventoryHashTable.insertItemInInventory(ItemsHashTable.searchItemName(pickupObject));
                    Debug.Log(ItemsHashTable.searchItemName(pickupObject).name);
                    inventoryText += ItemsHashTable.searchItemName(pickupObject).name + ",";
                    ItemsHashTable.deleteItemByName(pickupObject);
                    
                }             
                
            }
            catch (Exception ex)
            {
                outputText = "I can't do that.";
                Debug.Log(ex);
            }

            outputText = output;
            return outputText;
        }

        public string[] RefreshInventory()
        {   //DO STUFF            
            return inventoryText.Split(',');            
        }
    }

    //public class BucketHash
    //{
    //    private const int SIZE = 101;
    //    ArrayList[] data;
    //    public BucketHash()
    //    {
    //        data = new ArrayList[SIZE];
    //        for (int i = 0; i <= SIZE - 1; i++)
    //            data[i] = new ArrayList(4);
    //    }
    //    public int Hash(string items)
    //    {
    //        long tot = 0;

    //        char[] charray;
    //        charray = items.ToString().ToCharArray();
    //        for (int i = 0; i <= items.ToString().Length - 1; i++)
    //        {
    //            tot += 37 * tot + (int)charray[i];
    //        }
    //        tot = tot % data.GetUpperBound(0);
    //        if (tot < 0)
    //            tot += data.GetUpperBound(0);
    //        return (int)tot;
    //    }
    //    public void Insert(string item)
    //    {
    //        int hash_value;
    //        hash_value = Hash(item);
    //        Console.WriteLine("Hash Value: " + hash_value);
    //        Console.WriteLine("Item: " + data[hash_value]);
    //        if (data[hash_value].Contains(item))
    //        {
    //            data[hash_value].Add(item);
    //            Console.WriteLine("Hash Value: " + hash_value);
    //            Console.WriteLine("Item: " + data[1].GetEnumerator().Current.ToString());
    //        }
                
    //    }
    //    public void Remove(string item)
    //    {
    //        int hash_value;
    //        hash_value = Hash(item);
    //        if (data[hash_value].Contains(item))
    //            data[hash_value].Remove(item);
    //    }

    //    public string DisplayItemsInTable()
    //    {
    //        string output = "";
    //        foreach(var i in data)
    //        {
    //            Console.WriteLine(i.ToString());
    //        }
    //        //Console.WriteLine("Help");
    //        return output;
    //    }
    //}

    
}
