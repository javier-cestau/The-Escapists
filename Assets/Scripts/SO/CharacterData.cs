using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Data", menuName = "CharacterData", order = 0)]
public class CharacterData : ScriptableObject
{
    public RuntimeAnimatorController head;
    public RuntimeAnimatorController body;
    public string outfit;
    public string weapon;
    public string characterName;
    public int speed = 30;
    public int strength = 30;
    public int intellect = 30;
    public int health = 15;
    public int endurance = 20;
    public int money = 10;

    public int heat = 0;
    public bool isInmate = true;

    public Item[] inventory;

}
