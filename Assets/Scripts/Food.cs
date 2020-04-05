using UnityEngine;
using UnityEngine.Networking;

public class Food : MonoBehaviour
{
    public float size;
    
    public void CmdInteractionFinished(GameObject other)
    {
        Stomach belly = other.GetComponent<Stomach>();
        
        if (belly != null) {
            belly.Feed(size);
        }

        Destroy(this.gameObject);
    }
}