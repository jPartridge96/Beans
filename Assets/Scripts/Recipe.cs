/*
Recipe.cs
Created date: 2.28.2023
Created by: Jordan partridge
Comment added by: Hyunjin Kim
 */

using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Script for recipes
/// </summary>
public class Recipe : MonoBehaviour
{
    // Array for cups
    public string[] cups = {"cup1", "cup2", "cup3"};
    // List for ingredients
    public List<Ingredient> ingredients;
    // Check if iced drink
    public bool isIced;
}

