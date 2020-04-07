using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerInteraction : NetworkBehaviour
{
    private float interactionProgress = 0.0f;
    private float fullInteractionTime = 0.0f;
    private float interactDistance = 0.3f;
    private float interactOffsetY = 0.1f;

    private void Start() {
        fullInteractionTime = 0.0f;
    }

    private void FixedUpdate() {
        if (fullInteractionTime != 0.0f) {
            interactionProgress += Time.deltaTime;
        }
    }

    public bool HasInteractable() {
        Collider2D[] interactables = FindInteractables();

        return interactables.Length > 0;
    }

    [Command]
    public void CmdInteract() {
        Collider2D interactable = FindAnyInteractable();

        if (interactable != null) {
            Interactable intComponent = interactable.gameObject.GetComponent<Interactable>();
            fullInteractionTime = intComponent.FullInteractionTime();
            intComponent.Interact(this.gameObject);
        }
    }

    [Command]
    public void CmdStopInteract() {
        Collider2D interactable = FindAnyInteractable();

        if (interactable != null) {
            CmdInteractionFinished();
            interactable.gameObject.GetComponent<Interactable>().StopInteract();
        }
    }

    public bool IsInteracting() {
        return fullInteractionTime != 0.0f;
    }

    public float GetProgress() {
        if (IsInteracting()) {
            return 100 * interactionProgress / fullInteractionTime;
        } else {
            return 0.0f;
        }
    }

    private Collider2D[] GetInteractableColliders() {
        float x = transform.position.x;
        float y = transform.position.y + interactOffsetY;
        //TODO: usar public static Collider2D[] OverlapCircleAll(Vector2 point, float radius, int layerMask);      
        return Physics2D.OverlapCircleAll(new Vector2(x, y), interactDistance);
    }

    private Collider2D[] FindInteractables() {
        Collider2D[] hitColliders = GetInteractableColliders();
        List<Collider2D> interactables = new List<Collider2D>();

        foreach(Collider2D collider in hitColliders) {
            if (collider.gameObject.GetComponent<Interactable>() != null) {
                interactables.Add(collider);
            }
        }

        return interactables.ToArray();
    }

    private Collider2D FindAnyInteractable() {
        Collider2D[] interactables = FindInteractables();

        if (interactables.Length > 0) {
            Collider2D interactable = null;
            int i = 0;

            while (interactable == null || i < interactables.Length) {
                //TODO: usar layermask
                if (interactables[i].name != this.name) {
                    interactable = interactables[i];
                }

                i++;
            }

            return interactable;
        } else {
            return null;
        }
    }

    private void CmdInteractionFinished() {
        fullInteractionTime = 0.0f;
        interactionProgress = 0.0f;
    }
}
