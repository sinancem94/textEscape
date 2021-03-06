using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Interaction", order = 1)]
public class Interaction : ScriptableObject
{
    [TextArea]
    [Tooltip("The description which will appear in game")]
    public string interactionDescription;
    public bool repeatable = false;
    [SerializeField, Tooltip("Add outcome and probability pair")]
    public List<PossibleOutcome> possibleOutcomes;
}

[Serializable]
public struct PossibleOutcome
{
    [Tooltip("% possibility")]
    public int possibility;
    [Tooltip("What stats will change. Can be NULL")]
    public StatOutcome statOutcome;
    [Tooltip("Item to win. Can be NULL")]
    public Item item;
}