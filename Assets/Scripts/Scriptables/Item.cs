using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable, CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Item", order = 3)]
public class Item : ScriptableObject
{
    [SerializeField, Tooltip("Special name of outcome")]
    public string itemName;
    [SerializeField]
    public GameObject itemObject;
    //[SerializeField, Header("The list of statoutcomes that will occur")]
    //public List<OutcomePair> outcomes;
}