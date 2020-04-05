using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public int tileSize = 32;

    public Slider mainSlider;

    private Stomach stomach;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        stomach = FindObjectOfType<Stomach>();
        if (stomach != null)
        {
            mainSlider.value = stomach.Hunger;
        }
    }

}
