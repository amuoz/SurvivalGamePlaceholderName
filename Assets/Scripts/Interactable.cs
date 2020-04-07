using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    private float currentInteractionTime = 0.0f;
    private bool interactingState = false;
    [SerializeField]
    private float interactionTime = 0.0f;
    private GameObject interactingWith = null;

    // Update is called once per frame
    void Update()
    {
        if (interactingState) {
            currentInteractionTime += Time.deltaTime;
            if (currentInteractionTime > interactionTime)
            {
                CompleteInteraction();
            }
        }
    }

    public void Interact(GameObject other)
    {
        interactingState = true;
        interactingWith = other;
    }

    public void StopInteract()
    {
        interactingState = false;
        interactingWith = null;
        currentInteractionTime = 0.0f;
    }

    public float FullInteractionTime() {
        return interactionTime;
    }

    private void CompleteInteraction() {
        ApplyObjectInteraction();
        NotifyInteractionToOther();
        StopInteract();
    }

    private void ApplyObjectInteraction() {
        this.gameObject.SendMessage("CmdInteractionFinished", interactingWith, SendMessageOptions.DontRequireReceiver);
    }

    private void NotifyInteractionToOther() {
        interactingWith.SendMessage("CmdInteractionFinished");
    }
}
