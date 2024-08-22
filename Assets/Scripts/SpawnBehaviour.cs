using UnityEngine;

public class SpawnBehaviour : MonoBehaviour
{
    void Start()
    {
        GetComponent<SpriteRenderer>().enabled = false;
    }

}
