/*
Ingredient.cs
Created date: 2.28.2023
Created by: Jordan partridge
Comment added by: Hyunjin Kim
 */

using UnityEngine;

/// <summary>
/// Script for ingredients
/// </summary>
public class Ingredient : MonoBehaviour
{
    // Name of the ingredient
    public string Name;
    public Ingredient(string name)
    {
        Name = name;
    }
}

