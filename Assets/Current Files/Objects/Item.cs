using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="New Item",menuName="Item")]

public class Item : ScriptableObject
{
    public enum ItemType{
         Apparel,
         Weapon,
         Ingredient,
         Misc
    }

    public GameObject obj;
    public float weight;
    public ItemType itemType;
    public float Damage;
    public float health;
    public bool enchanted;
    public Vector3 scale;

}
