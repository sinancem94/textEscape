using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private RectTransform interactablesText;
    [SerializeField]
    private Text mainText;

    [SerializeField]
    private Text healthStat;
    [SerializeField]
    private Text mentalStat;

    public void SetUp(string description, List<InteractableObject> interactables)
    {
        mainText.text = description;

        Button interactableButton = Resources.Load<Button>("UI/InteractionChooseButton");

        foreach (var interactableObje in interactables)
        {
            Button currButton = Button.Instantiate(interactableButton, interactablesText.transform);
            currButton.GetComponentInChildren<Text>().text = interactableObje.Interaction.interactionDescription;

            currButton.onClick.AddListener(interactableObje.GetInteracted);// += interactableObje.GetInteracted;
        }
    }

    public void SetStatTexts(Stats stats)
    {
        healthStat.text = $"health : {stats.health.ToString()}";
        mentalStat.text = $"mental : {stats.mental.ToString()}";
    }
}
