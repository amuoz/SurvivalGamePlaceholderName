using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Mirror;

public class Player : NetworkBehaviour
{

    [SerializeField]
    private bool debugDistance = true;

    private PlayerMovement playerMovement;
    private PlayerInteraction playerInteraction;
    private Component[] inventories;

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

        //Component inizializations
        playerMovement = GetComponent<PlayerMovement>();
        playerInteraction = GetComponent<PlayerInteraction>();
        inventories = GetComponents<Inventory>();
    }

    private void initStateFunctions() {
        stateFunctions = new Dictionary<State, System.Action>();
        stateFunctions[State.Movement] = MoveState;
        stateFunctions[State.Interact] = InteractState;
        stateFunctions[State.Inventory] = InventoryState;
    }

    // Update is called once per frame
    void Update() {
        if (playerState == State.Movement) {
            bool isActionInput = Input.GetButtonDown("Fire1");
            if (isActionInput) {
                PlayerAction();
            }

            bool isInventoryInput = Input.GetButtonDown("Fire2");
            if (isInventoryInput) {
                OpenInventory();
            }
        } else if (playerState == State.Inventory) {
            bool isInventoryInput = Input.GetButtonDown("Fire2");
            if (isInventoryInput) {
                CloseInventory();
            }
        }
    }
    void FixedUpdate() {

        if(hasAuthority)
            stateFunctions[playerState]();

        if (debugDistance) {
            Debug.DrawLine(
                new Vector2(transform.position.x, transform.position.y + 0.1f),
                new Vector2(transform.position.x + 0.3f, transform.position.y + 0.3f),
                Color.white
            );
        }
    }

    private void MoveState() {
        playerMovement.Move();
    }

    private void InteractState() {
        Debug.Log("player interaction: ");
        playerInteraction.Interact();

        bool isActionInputOff = Input.GetButtonUp("Fire1");
        if (isActionInputOff) {
            playerInteraction.StopInteract();
            playerState = State.Movement;
        }
    }

    private void InventoryState() {
        playerMovement.CmdStop();
    }
    private void PlayerAction() {
        
        if (GetComponent<PlayerInteraction>().HasInteractable()) {
            playerState = State.Interact;
        }
    }

    private void OpenInventory() {
        foreach(Inventory inventory in inventories) {
            inventory.OpenInventory();
        }

        playerState = State.Inventory;
    }

    private void CloseInventory() {

        foreach(Inventory inventory in inventories) {
            inventory.CloseInventory();
        }

        playerState = State.Movement;
    }

    public void CmdInteractionFinished() {
        playerState = State.Movement;
    }
}
