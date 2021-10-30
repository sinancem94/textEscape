using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Adventurer : MonoBehaviour
{
    [SerializeField]
    public Stats stats;

    public void SetUp()
    {
        //ilk açılışta sabit değerler. Daha sonra buraya jsondan okunanlar gelmeli
        stats.health = 100;
        stats.mental = 100;

        //luck, perception gibi değerler. Oyun başı verilecek ilk cevaplara göre değişecek.
        stats.luck = 50;
        stats.perception = 50;

        
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

                    //diğer statların değişkenleri eklenecek.
            }
        }
    }
}

public struct Stats
{
    public float health;
    public float mental;
    public float perception;
    public float luck;

}
