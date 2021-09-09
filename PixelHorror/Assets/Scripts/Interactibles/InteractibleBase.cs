using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public abstract class InteractibleBase : MonoBehaviour
{
    [SerializeField]
    protected bool isInteractible=true;

    [SerializeField]
    private Image iconImage;
    [SerializeField]
    private Sprite spritePrompt;
    [SerializeField]
    private Sprite spriteNearby;

    [SerializeField]
    private string PlayerTag = "Player";

    public bool IsInteractible => isInteractible;

    public abstract void OnBeginInteract();
    public abstract void OnContinueInteract();
    public abstract void OnEndInteract();

    public virtual void Selected()
    {
        Debug.Log("Selected");
        ShowPickupPrompt();
    }

    public virtual void UnSelected()
    {
        Debug.Log("De selected");
        ShowPrompt();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Enter");
        if (collision.CompareTag(PlayerTag))
        {
            ShowPrompt();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Exit");
        if (collision.CompareTag(PlayerTag))
        {
            HidePrompt();
        }
    }

    protected virtual void ShowPickupPrompt()
    {
        iconImage.sprite = spritePrompt;
    }

    protected virtual void ShowPrompt()
    {
        iconImage.enabled = true;
        iconImage.sprite = spriteNearby;
    }

    protected virtual void HidePrompt()
    {
        iconImage.enabled = false;
    }
}
