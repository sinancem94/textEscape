using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMath;
using System.Linq;

public class GameManager : Singleton<GameManager>
{
    private UIManager _ui;
    private Adventurer _playerAdventurer;

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

        string text = $"Demo scene \n " +
            $"{_currentInteractables.Count} secenek var.";
        _ui.SetUp(text, _currentInteractables);
        _playerAdventurer.SetUp();

    }

    private void LateUpdate()
    {
        _ui.SetStatTexts(_playerAdventurer.stats);
    }

    public void Interacted(InteractableObject interactedObje)
    {
        //Debug.Log($"interacted and stat outcome is {interactedObje.Outcome.statOutcome.sName}");

        if (interactedObje.Interaction.repeatable == false)
            _currentInteractables.Remove(interactedObje);

        _playerAdventurer.Interact(interactedObje);

        if (interactedObje.Outcome.item)
            _ui.AddItem(interactedObje.Outcome.item);

        _ui.SetInteractableList(_currentInteractables);
    }
}


