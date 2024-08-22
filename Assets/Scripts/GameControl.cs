using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameControl : MonoBehaviour
{
    [SerializeField]
    public int Score { get; private set; }

    [SerializeField]
    private List<SpawnBehaviour> spawnBehaviours;
    private Dictionary<int, Texture2D> packageIcons;
    private Dictionary<int, Texture2D> peopleIcons;


    public UnityEvent<int> ScoreChanged;

    private void Start()
    {
        packageIcons = new Dictionary<int, Texture2D>()
        {
            {1, (Texture2D)Resources.Load("Sprites/Packages/pck001") },
            {2, (Texture2D)Resources.Load("Sprites/Packages/pck002") },
            {3, (Texture2D)Resources.Load("Sprites/Packages/pck003") }
        };

        peopleIcons = new Dictionary<int, Texture2D>()
        {
            {1, (Texture2D)Resources.Load("Sprites/People/p001") },
            {2, (Texture2D)Resources.Load("Sprites/People/p002") },
            {3, (Texture2D)Resources.Load("Sprites/People/p003") },
            {4, (Texture2D)Resources.Load("Sprites/People/p004") },
            {5, (Texture2D)Resources.Load("Sprites/People/p005") },
            {6, (Texture2D)Resources.Load("Sprites/People/p006") },
            {7, (Texture2D)Resources.Load("Sprites/People/p006") },
            {8, (Texture2D)Resources.Load("Sprites/People/p007") },
            {9, (Texture2D)Resources.Load("Sprites/People/p008") },
            {10, (Texture2D)Resources.Load("Sprites/People/p010") }
        };

        Spawn();
    }

    private void Spawn()
    {
        if (spawnBehaviours != null && spawnBehaviours.Count >= 2)
        {
            var token = CreatePackageToken();
            var packageSpawnIndex = UnityEngine.Random.Range(1, spawnBehaviours.Count);

            token.transform.SetParent(spawnBehaviours[packageSpawnIndex].gameObject.transform);
            token.transform.position = spawnBehaviours[packageSpawnIndex].gameObject.transform.position;

            var person = CreatePersonToken();
            int customerSpawnIndex = packageSpawnIndex;
            while (customerSpawnIndex == packageSpawnIndex)
            {
                customerSpawnIndex = UnityEngine.Random.Range(1, spawnBehaviours.Count);
            }
            person.transform.SetParent(spawnBehaviours[customerSpawnIndex].gameObject.transform);
            person.transform.position = spawnBehaviours[customerSpawnIndex].gameObject.transform.position;
        }
    }

    private GameObject CreatePackageToken()
    {
        var token = (GameObject)Instantiate(Resources.Load("Prefabs/PackageToken"));
        token.name = token.name + UnityEngine.Random.Range(0, 9999).ToString();
        var texture = packageIcons[UnityEngine.Random.Range(1, packageIcons.Count + 1)];
        token.GetComponent<Package>().Sprite = Sprite.Create(
            texture,
            new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
        return token;
    }

    private GameObject CreatePersonToken()
    {
        var token = (GameObject)Instantiate(Resources.Load("Prefabs/RecipientToken"));
        token.name = token.name + UnityEngine.Random.Range(0, 9999).ToString();
        var texture = peopleIcons[UnityEngine.Random.Range(1, peopleIcons.Count + 1)];
        token.GetComponent<Customer>().Sprite = Sprite.Create(
            texture,
            new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
        return token;
    }

    public void PackageDelivered(IPackage package, ICustomer customer)
    {
        Score += 1;
        ScoreChanged?.Invoke(Score);
        customer.Remove(1f);
        Spawn();
    }

    public void PackageCollected(IPackage package)
    {
        package.Remove(0.5f);
    }
}
