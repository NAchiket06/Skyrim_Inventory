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
         Misc,
         Potion,
         Food,
         Book,
         Key

    }

    public GameObject obj;
    public float weight;
    public ItemType itemType;
    public float Damage;
    public float health;
    public int value;
    public bool enchanted;
    public Vector3 scale = new Vector3(1,1,1);


}
