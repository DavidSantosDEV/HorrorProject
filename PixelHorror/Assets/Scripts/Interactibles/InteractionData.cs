using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Interaction Data",menuName ="Interaction System/Interaction Data")]
public class InteractionData : ScriptableObject
{
    private InteractibleBase interactible;

    public InteractibleBase Interactible
    {
        get => Interactible;
        set
        {
            interactible = value;
            interactible.Selected();
        }
    }

    public void Interact()
    {
        if (interactible.IsInteractible)
        {
            interactible.OnBeginInteract();
        }
    }

    public void ContinueInteract()
    {
        if (interactible)
        {
            if (interactible.IsInteractible)
            {
                interactible.OnContinueInteract();
            }
        }

    }

    public bool IsSameInteractible(InteractibleBase newInteractible)
    {
        return newInteractible == interactible;
    }

    public bool IsEmpty()
    {
        return interactible == null;
    }

    public void ResetData()
    {
        interactible?.UnSelected();
        interactible = null;
    }
}
