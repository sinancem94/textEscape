using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adventurer : MonoBehaviour
{
    [SerializeField]
    public Stats stats;

    public void SetUp()
    {
        stats.health = 100;
        stats.mental = 100;
    }

    public void ApplyOutcome(PossibleOutcome outcome)
    {
        foreach(var statChange in outcome.statOutcome.outcomes)
        {
            switch(statChange.effectedStat)
            {
                case AdventurerStats.Health:
                    stats.health += statChange.theChange;
                    break;
                case AdventurerStats.MentalHealth:
                    stats.mental += statChange.theChange;
                    break;
                default:
                    break;
            }
        }
    }
}

public struct Stats
{
    public float health;
    public float mental;
}
