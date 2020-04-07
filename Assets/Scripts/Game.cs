using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public int tileSize = 32;

    [SerializeField]
    private Slider mainSlider;
    private GameObject interactionSlider;
    private GameObject interactionPanel;

    // Start is called before the first frame update
    void Start()
    {
        GameObject hud =  GameObject.FindGameObjectWithTag("HUD");
        interactionPanel = hud.transform.Find("InteractionPanel").gameObject;
        interactionSlider = interactionPanel.transform.Find("InteractionSlider").gameObject;
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
        PlayerInteraction interaction = FindObjectOfType<PlayerInteraction>();

        if (interaction != null) {
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
