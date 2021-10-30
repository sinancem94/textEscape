using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMath;
using System.Linq;

public class GameManager : Singleton<GameManager>
{
    private UIManager _ui;
    private Adventurer _playerAdventurer;
    private Inventory _inventory;

    List<InteractableObject> _currentInteractables;

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        _ui = FindObjectOfType<UIManager>();
        _playerAdventurer = FindObjectOfType<Adventurer>();
        _currentInteractables = FindObjectsOfType<InteractableObject>().ToList();
        _inventory = FindObjectOfType<Inventory>();

        string text = "deneme texti, biraz uzun olacaktir herhalde yaz yaz yaz yaz yaz";
        _ui.SetUp(text, _currentInteractables);
        _playerAdventurer.SetUp();
        _inventory.SetUp();

    }

    private void LateUpdate()
    {
        _ui.SetStatTexts(_playerAdventurer.stats);
    }

    public void Interacted(PossibleOutcome outcome)
    {
        Debug.Log($"interacted and outcome is {outcome.statOutcome.sName}");
        _playerAdventurer.ApplyOutcome(outcome);
    }
}

public enum AdventurerStats
{
    Health,
    MentalHealth
}
