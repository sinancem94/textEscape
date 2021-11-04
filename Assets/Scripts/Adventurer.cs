using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class Adventurer : MonoBehaviour
{
    [SerializeField]
    public Stats stats;

    //TODO: Delete not comments
    //GameManager i daha sade tutmak adina inventory player da tutulsun
    private Inventory _inventory;
    private TextMeshPro guiText;
    public void SetUp()
    {
        _inventory = GetComponent<Inventory>();
        _inventory.SetUp();

        guiText = GetComponentInChildren<TextMeshPro>();
        guiText.text = "";

        //ilk açılışta sabit değerler. Daha sonra buraya jsondan okunanlar gelmeli
        stats.health = 100;
        stats.mental = 100;

        //luck, perception gibi değerler. Oyun başı verilecek ilk cevaplara göre değişecek.
        stats.luck = 50;
        stats.perception = 50;
    }

    public void Interact(InteractableObject interacted)
    {
        Vector3 actualTarget = interacted.Position;
        actualTarget.y = transform.position.y;

        transform.DOMove(actualTarget, 0.5f).OnComplete(() => 
        {
            interacted.InteractionAnimation();
            ApplyOutcome(interacted.Outcome);
        }
        );
    }

    void ApplyOutcome(PossibleOutcome outcome)
    {
        if (outcome.item != null)
        {
            Debug.Log($"Found Item : {outcome.item.itemName}");
            _inventory.AddItem(outcome.item);
        }
        //if no outcome exist in interaction
        if (outcome.statOutcome == null)
            return;
        
        //Color textColor = guiText.color;
        //textColor.a = 0;
        
        //guiText.color = textColor;
        guiText.text = outcome.statOutcome.sName;

        //textColor.a = 1;
        

        foreach (var statChange in outcome.statOutcome.outcomes)
        {
            switch (statChange.effectedStat)
            {
                case AdventurerStats.Health:
                    stats.health += statChange.theChange;
                    break;
                case AdventurerStats.MentalHealth:
                    stats.mental += statChange.theChange;
                    break;
                case AdventurerStats.Perception:
                    stats.perception += statChange.theChange;
                    break;
                case AdventurerStats.Luck:
                    stats.luck += statChange.theChange;
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

public enum AdventurerStats
{
    Health,
    MentalHealth,
    Perception,
    Luck
}
