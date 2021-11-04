using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CapAnimatedInteractable : InteractableObject
{
    [SerializeField]
    private Transform openedCap;

    public override void InteractionAnimation()
    {
        Sequence openSequence = DOTween.Sequence();

        if(Interaction.repeatable)
            openSequence.SetAutoKill(false);

        float animTime = 0.5f;

        openSequence.Append(openedCap.DOLocalMove(openedCap.localPosition + Vector3.back * transform.localScale.z * 0.5f, animTime)).
            Join(openedCap.DOLocalRotate((openedCap.localRotation * Quaternion.Euler(-75f, 0f, 0f)).eulerAngles, animTime)).
            AppendInterval(animTime * 2f).
            OnComplete(() => 
            { 
                if(Interaction.repeatable)
                    ReverseSequence(openSequence); 
            });
    }

    void ReverseSequence(Sequence reversed)
    {
        reversed.SetAutoKill(true);
        reversed.PlayBackwards();
    }
}
