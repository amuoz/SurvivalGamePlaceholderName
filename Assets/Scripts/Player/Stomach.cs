using UnityEngine;

public class Stomach : MonoBehaviour
{
    private float hunger = 100.0f;

    [SerializeField]
    private float decay = 1f;

    public float Hunger => hunger;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        hunger = Mathf.Clamp(hunger - Time.deltaTime * decay, 0, 100f);
    }

    public void Feed(float foodSize)
    {
        hunger += foodSize;
        if (hunger > 100.0f)
        {
            hunger = 100.0f;
        }
    }
}