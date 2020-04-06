using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Player : MonoBehaviour
{
    public bool debugDistance = true;
    private enum State {
        Movement,
        Interact,
        Inventory,
    }

    private State playerState;
    private Dictionary<State, System.Action> stateFunctions;
    // Start is called before the first frame update
    void Start() {
        playerState = State.Movement;
        initStateFunctions();
    }

    private void initStateFunctions() {
        stateFunctions = new Dictionary<State, System.Action>();
        stateFunctions[State.Movement] = MoveState;
        stateFunctions[State.Interact] = InteractState;
        stateFunctions[State.Inventory] = InventoryState;
    }

    // Update is called once per frame
    void FixedUpdate() {

        stateFunctions[playerState]();

        if (debugDistance)
        {
            Debug.DrawLine(
                transform.position,
                new Vector3(transform.position.x + 0.15f, transform.position.y + 0.15f, 10),
                Color.white
            );
        }

    }

    private void MoveState() {
        bool isActionInput = Input.GetButtonDown("Fire1");
        if (isActionInput) {
            PlayerAction();
        }

        bool isInventoryInput = Input.GetButtonDown("Fire2");
        if (isInventoryInput) {
            OpenInventory();
        }

        GetComponent<PlayerMovement>().Move();
    }

    private void InteractState() {
        GetComponent<PlayerInteraction>().Interact();

        bool isActionInputOff = Input.GetButtonUp("Fire1");
        if (isActionInputOff) {
            GetComponent<PlayerInteraction>().StopInteract();
            playerState = State.Movement;
        }
    }

    private void InventoryState() {
        GetComponent<PlayerMovement>().Stop();

        bool isInventoryInput = Input.GetButtonDown("Fire2");
        if (isInventoryInput) {
            CloseInventory();
        }
    }
    private void PlayerAction() {
        if (GetComponent<PlayerInteraction>().HasInteractable()) {
            playerState = State.Interact;
        }
    }

    private void OpenInventory() {
        Component[] inventories = GetComponents<Inventory>();
        foreach(Inventory inventory in inventories) {
            inventory.OpenInventory();
        }

        playerState = State.Inventory;
    }

    private void CloseInventory() {
        Component[] inventories = GetComponents<Inventory>();
        foreach(Inventory inventory in inventories) {
            inventory.CloseInventory();
        }

        playerState = State.Movement;
    }

    public void CmdInteractionFinished() {
        playerState = State.Movement;
    }

}
