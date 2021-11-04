using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UMath;

public abstract class InteractableObject : MonoBehaviour
{
    [SerializeField]
    private Interaction interaction;
    [SerializeField]
    private Transform interactionPosition;

    private PossibleOutcome chosenOutcome;
    private bool interacted = false;

    public Interaction Interaction => interaction;
    public PossibleOutcome Outcome => chosenOutcome;
    public Vector3 Position => interactionPosition.position;

    private PossibleOutcome ChoseOutcome()
    {
        int randChoosenOutcome = 0;

        chosenOutcome = new PossibleOutcome();

        int outcomeCount = interaction.possibleOutcomes.Count;
        if (outcomeCount == 0)
        {
            Debug.Log("No outcome ?");
            return chosenOutcome;
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

        return chosenOutcome = interaction.possibleOutcomes[randChoosenOutcome];
    }

    #region public
    public abstract void InteractionAnimation();

    public void GetInteracted()
    {
        if (!interaction.repeatable)
            if (!interacted)
                interacted = true;
            else
                return;

        //choose outcome
        ChoseOutcome();
        //apply it
        GameManager.Instance.Interacted(this);
    }

    #endregion
}
