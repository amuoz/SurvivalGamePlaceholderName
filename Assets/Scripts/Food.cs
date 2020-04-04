using UnityEngine;

public class Food : MonoBehaviour
{
    public float size;
    
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D player)
    {
        if(player.name == "Player")
        {
            Stomach belly = player.gameObject.GetComponent<Stomach>();
            belly.Feed(size);
        }
        Destroy(this.gameObject);
    }
}