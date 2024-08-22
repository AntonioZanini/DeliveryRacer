using System;
using UnityEngine;

public class Package : MonoBehaviour, IPackage
{
    [field: SerializeField]
    public Color32 PackageColor { get; set; } = new Color32(255, 255, 255, 255);
    [field: SerializeField]
    [field: Range(0, 300)]
    public int TimeLimit { get; set; } = 60;
    [field: SerializeField]
    public bool IsFragile { get; set; }
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

    public ICustomer Recipient { get; set; }

    public void Remove(float delayInSeconds)
    {
        Destroy(gameObject, delayInSeconds);
    }
}
