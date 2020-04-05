using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private float interactDistance = 0.15f;

    public bool HasInteractable() {
        Collider2D[] interactables = FindInteractables();

        return interactables.Length > 0;
    }

    public void Interact() {
        Collider2D interactable = FindAnyInteractable();

        Debug.Log("interactable = " + interactable);

        if (interactable != null) {
            interactable.gameObject.SendMessage("Interact", this.gameObject, SendMessageOptions.DontRequireReceiver);
        }
    }

    private Collider2D[] FindInteractables() {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, interactDistance);
        List<Collider2D> interactables = new List<Collider2D>();

        foreach(Collider2D collider in hitColliders) {
            if (collider.gameObject.GetComponent("Interactable") != null) {
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
                if (interactables[i].name != "Player") {
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
