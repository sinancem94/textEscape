using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable, CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Stat changing outcome", order = 2)]
public class StatOutcome : ScriptableObject
{
    [SerializeField,Tooltip("Special name of outcome")]
    public string sName;
    [SerializeField,Header("The list of statoutcomes that will occur")]
    public List<StatOutcomePair> outcomes;
}

[Serializable]
public struct StatOutcomePair
{
    [Tooltip("The effected stat")]
    public AdventurerStats effectedStat;
    
    [Tooltip("The change in value"),Range(-100,100)]
    public int theChange;
}