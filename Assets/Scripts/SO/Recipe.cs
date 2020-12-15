using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipe", order = 0)]
public class Recipe : ScriptableObject
{
    public Item first;
    public Item second;
    public Item third;

    public Item result;

}
