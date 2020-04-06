using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private float interactDistance = 0.3f;
    private float interactOffsetY = 0.1f;

    public bool HasInteractable() {
        Collider2D[] interactables = FindInteractables();

        return interactables.Length > 0;
    }

    public void Interact() {
        Collider2D interactable = FindAnyInteractable();

        if (interactable != null) {
            interactable.gameObject.SendMessage("Interact", this.gameObject, SendMessageOptions.DontRequireReceiver);
        }
    }

    public void StopInteract() {
        Collider2D interactable = FindAnyInteractable();

        if (interactable != null) {
            interactable.gameObject.SendMessage("StopInteract", this.gameObject, SendMessageOptions.DontRequireReceiver);
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
}
