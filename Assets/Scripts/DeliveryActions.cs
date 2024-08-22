using UnityEngine;
using UnityEngine.Events;

public class DeliveryActions : MonoBehaviour
{
    private Color32 defaultColor;
    private SpriteRenderer hostRenderer;
    private IPackage CurrentPackage;

    public bool PendingDelivery => CurrentPackage != null;

    public UnityEvent<IPackage> PackageCollected;
    public UnityEvent<IPackage, ICustomer> PackageDelivered;

    private void Awake()
    {
        hostRenderer = GetComponent<SpriteRenderer>();
        defaultColor = hostRenderer.color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Collect(other.GetComponent<IPackage>());
        Deliver(other.GetComponent<Customer>());
    }

    private void Collect(IPackage newPackage)
    {
        if (!PendingDelivery && newPackage != null)
        {
            CurrentPackage = newPackage;
            Debug.Log("package collected!");
            SetColor(CurrentPackage.PackageColor);
            PackageCollected?.Invoke(CurrentPackage);
        }
    }

    private void Deliver(ICustomer customer)
    {
        if (PendingDelivery && customer != null)
        {
            Debug.Log("package delivered!");
            ResetColor();
            PackageDelivered?.Invoke(CurrentPackage, customer);
            CurrentPackage = null;
        }
    }

    private void SetColor(Color32 color)
    {
        hostRenderer.color = color;
    }

    private void ResetColor()
    {
        hostRenderer.color = defaultColor;
    }

}
