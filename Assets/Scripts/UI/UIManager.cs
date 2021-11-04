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
    [SerializeField]
    private Text luckStat;
    [SerializeField]
    private Text perceptionStat;
    [SerializeField]
    private Text items;

    public void SetUp(string description, List<InteractableObject> interactables)
    {
        SetDescription(description);
        SetInteractableList(interactables);

        items.text = "";

        /*  Button interactableButton = Resources.Load<Button>("UI/InteractionChooseButton");

          foreach (var interactableObje in interactables)
          {
              Button currButton = Button.Instantiate(interactableButton, interactablesText.transform);
              currButton.GetComponentInChildren<Text>().text = $" --> " + interactableObje.Interaction.interactionDescription;

              currButton.onClick.AddListener(interactableObje.GetInteracted);// += interactableObje.GetInteracted;
          }*/
    }

    public void SetDescription(string description)
    {
        mainText.text = description;
    }

    public void SetInteractableList(List<InteractableObject> interactables)
    {
        foreach(var b in interactablesText.GetComponentsInChildren<Button>())
        {
            Destroy(b.gameObject);
        }

        Button interactableButton = Resources.Load<Button>("UI/InteractionChooseButton");

        foreach (var interactableObje in interactables)
        {
            Button currButton = Button.Instantiate(interactableButton, interactablesText.transform);
            currButton.GetComponentInChildren<Text>().text = $" --> " + interactableObje.Interaction.interactionDescription;

            currButton.onClick.AddListener(interactableObje.GetInteracted);// += interactableObje.GetInteracted;
        }

    }

    public void SetStatTexts(Stats stats)
    {
        healthStat.text = $"Health : {stats.health.ToString()}";
        mentalStat.text = $"Mental : {stats.mental.ToString()}";
        luckStat.text = $"Luck : {stats.luck.ToString()}";
        perceptionStat.text = $"Prcptn : {stats.perception.ToString()}";
    }

    public void AddItem(Item item)
    {
        if (items.text.Length > 0)
            items.text += "\n";
        items.text += $"{item.itemName}";
    }
}
