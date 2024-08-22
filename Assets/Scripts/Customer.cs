using UnityEngine;

public class Customer : MonoBehaviour, ICustomer
{
    public void Remove(float delayInSeconds)
    {
        Destroy(gameObject, delayInSeconds);
    }

    public Sprite Sprite
    {
        set
        {
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            if (renderer != null)
            {
                renderer.sprite = value;
            }
        }
    }
}
