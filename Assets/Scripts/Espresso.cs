/*
Espresso.cs
Created date: 2/28/2023
Created by: Hyunjin Kim

Comment added by: Hyunjin Kim
 */

/*
 
1. randomly pick a menu in Order script (Get the recipe from each item's script)
2. randomly pick a cup in Order script
3. put the cup in an array/list in Order script (So it will be like cup1, coffee, ice, water in the array for example)
4. compare two arrays(the order and recipe that the player made) when serve (Get the recipe from each item's script and compare with THEDRINKTHATUSERMADE script 

Compare OrderList with CurrentDrinkList
- Lose points for missing items
- Lose points for additional items

 */

using UnityEngine;

public class Espresso : Order
{
    public Espresso()
    {

    }
}

