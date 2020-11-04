using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Vieyra1802490_ParsingPrototype
{
    class Commands
    {
        public int key;
        public string comName;

        //    public string Look(string[] words)
        //    {
        //        string output = "";
        //        string lookAtObject;
        //        if (words[1] == "at")
        //        {
        //            lookAtObject = words[2];
        //        }
        //        else
        //        {
        //            lookAtObject = words[1];
        //        }

        //        try
        //        {
        //            //string Description;
        //            if (Items.findItem(lookAtObject))
        //            {
        //                Console.WriteLine("Nohere");
        //                output += Items.searchItemName(lookAtObject).discription;

        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            outputText = "I dont see that object.";
        //        }

        //        outputText = output;
        //        return outputText;
        //    }

        //    public string Use(string[] words)
        //    {
        //        string output = "";
        //        string useObject = words[1];
        //        string targetObject;

        //        if (words[2] == "on")
        //        {
        //            targetObject = words[3];
        //        }
        //        else
        //        {
        //            targetObject = words[2];
        //        }

        //        output += "You use the " + useObject + " on the " + targetObject;

        //        //Another Dictionary of Use Methods <-- Neater
        //        //      OR
        //        //Just add game Code
        //        try
        //        {

        //        }
        //        catch (Exception ex)
        //        {
        //            outputText = "I can't do that.";
        //        }

        //        if (targetObject == "chest" && useObject == "key")
        //        {
        //            Console.WriteLine("You opened the chest.");
        //        }
        //        outputText = output;
        //        return outputText;
        //    }

        //    public string Pickup(string[] words)
        //    {
        //        string output = "";
        //        string pickupObject = words[1];

        //        try
        //        {
        //            if (Items.findItem(pickupObject))
        //            {
        //                output += "You add " + pickupObject + " to your inventory.";
        //                Items.insertItem(Items.searchItemName(pickupObject));
        //                Items.deleteItemByName(pickupObject);

        //            }
        //           // RefreshInventory();
        //        }
        //        catch (Exception ex)
        //        {
        //            outputText = "I can't do that.";
        //        }

        //        outputText = output;
        //        return outputText;
        //    }
        
    }
}
