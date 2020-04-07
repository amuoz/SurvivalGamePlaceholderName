using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class Game : SingletonComponent<Game>
{
    public int tileSize = 32;

    [SerializeField]
    private Slider mainSlider;
    private GameObject interactionSlider;
    private GameObject interactionPanel;
    public PlayerInteraction interaction { get;  set; }


    // Start is called before the first frame update
    void Awake()
    {
        GameObject hud =  GameObject.FindGameObjectWithTag("HUD");
        interactionPanel = hud.transform.Find("InteractionPanel").gameObject;
        interactionSlider = interactionPanel.transform.Find("InteractionSlider").gameObject;
        interactionPanel.SetActive(false);
        interactionSlider.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        UpdateHunger();
        UpdateInteractionProgress();
    }

    private void UpdateHunger() {
        Stomach stomach = FindObjectOfType<Stomach>();

        if (stomach != null)
        {
            mainSlider.value = stomach.Hunger;
        }
    }

    private void UpdateInteractionProgress() {
        
        if (interaction != null && interaction.hasAuthority) {
            
            float progress = interaction.GetProgress();

            if (progress != 0.0f) {
                interactionPanel.SetActive(true);
                interactionSlider.SetActive(true);
                interactionSlider.GetComponent<Slider>().value = progress;
            } else {
                interactionPanel.SetActive(false);
                interactionSlider.SetActive(false);
            }

        } else {
            interactionPanel.SetActive(false);
            interactionSlider.SetActive(false);
        }
    }

}
