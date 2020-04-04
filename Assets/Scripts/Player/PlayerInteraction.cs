using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private float interactDistance = 0.15f;

    public bool HasInteractable() {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, interactDistance);

        return hitColliders.Length > 1;
    }

    public void Interact() {
        Collider2D interactable = FindAnyCollider();

        if (interactable != null) {
            interactable.gameObject.SendMessage("Interact", this.gameObject, SendMessageOptions.DontRequireReceiver);
        }
    }

    private Collider2D FindAnyCollider() {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, interactDistance);

        if (hitColliders.Length > 1) {
            Collider2D interactable = null;
            int i = 0;

            while (interactable == null || i < hitColliders.Length) {
                if (hitColliders[i].name != "Player") {
                    interactable = hitColliders[i];
                }

                i++;
            }

            return interactable;
        } else {
            return null;
        }
    }
}
