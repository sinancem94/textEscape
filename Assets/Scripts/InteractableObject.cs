using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMath;

public class InteractableObject : MonoBehaviour
{
    [SerializeField]
    private Interaction interaction;

    private PossibleOutcome chosenOutcome;

    public Interaction Interaction => interaction; 

    private void ChoseOutcome()
    {
        int randChoosenOutcome = 0;

        int outcomeCount = interaction.possibleOutcomes.Count;
        if (outcomeCount == 0)
        {
            Debug.Log("No outcome ?");
            return;
        }
        else if (outcomeCount > 1)
        {
            int[] outcomeIndexes = new int[outcomeCount];
            int[] outcomeFreq = new int[outcomeCount];
            for (int i = 0; i < outcomeCount; i++)
            {
                outcomeIndexes[i] = i;
                outcomeFreq[i] = interaction.possibleOutcomes[i].possibility;
            }

            randChoosenOutcome = UMath.UMath.ChooseRandomlyWithFrequency(outcomeIndexes, outcomeFreq, outcomeCount);
        }

        chosenOutcome = interaction.possibleOutcomes[randChoosenOutcome];
    }

    public void GetInteracted()
    {
        ChoseOutcome();
        GameManager.Instance.Interacted(chosenOutcome);
    }
}
