using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// Controla a pontuação e a aparição de pacotes e clientes no mapa
public class GameControl : MonoBehaviour
{
    [SerializeField]
    public int Score { get; private set; }

    // Armazena referência para os pontos de aparecimentos do mapa.
    [SerializeField]
    private List<SpawnBehaviour> spawnBehaviours;
    private Dictionary<int, Texture2D> packageIcons;
    private Dictionary<int, Texture2D> peopleIcons;


    public UnityEvent<int> ScoreChanged;

    private void Start()
    {
        // Registra as imagens para pacotes
        packageIcons = new Dictionary<int, Texture2D>()
        {
            {1, (Texture2D)Resources.Load("Sprites/Packages/pck001") },
            {2, (Texture2D)Resources.Load("Sprites/Packages/pck002") },
            {3, (Texture2D)Resources.Load("Sprites/Packages/pck003") }
        };

        // Registra as imagens para clientes
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

    // Método que faz aparecer um pacote e um cliente aleatoriamente nos pontos de aparecimentos do mapa
    private void Spawn()
    {
        if (spawnBehaviours != null && spawnBehaviours.Count >= 2)
        {
            // Cria o token do pacote com base no Preset
            var token = CreatePackageToken();
            // Seleciona um ponto de aparecimento aleatório para o pacote
            var packageSpawnIndex = UnityEngine.Random.Range(1, spawnBehaviours.Count);

            // Adiciona o token do pacote como objeto filho do ponto selecionado
            token.transform.SetParent(spawnBehaviours[packageSpawnIndex].gameObject.transform);
            token.transform.position = spawnBehaviours[packageSpawnIndex].gameObject.transform.position;

            // Cria o token do cliente com base no Preset
            var person = CreatePersonToken();
            int customerSpawnIndex = packageSpawnIndex;

            // Seleciona um ponto de aparecimento aleatório para o cliente que seja diferente do pacote.
            while (customerSpawnIndex == packageSpawnIndex)
            {
                customerSpawnIndex = UnityEngine.Random.Range(1, spawnBehaviours.Count);
            }
            // Adiciona o token do cliente como objeto filho do ponto selecionado
            person.transform.SetParent(spawnBehaviours[customerSpawnIndex].gameObject.transform);
            person.transform.position = spawnBehaviours[customerSpawnIndex].gameObject.transform.position;
        }
    }

    // Cria o token do pacote com base no Preset, e atribui uma imagem aleatória de pacote
    private GameObject CreatePackageToken()
    {
        // Obtém o Preset dos recursos e o instancia como um GameObject
        var token = (GameObject)Instantiate(Resources.Load("Prefabs/PackageToken"));
        token.name = token.name + UnityEngine.Random.Range(0, 9999).ToString();
        // A partir de uma textura aleatória de pacote cria uma Sprite e atribui ao token.
        var texture = packageIcons[UnityEngine.Random.Range(1, packageIcons.Count + 1)];
        token.GetComponent<Package>().Sprite = Sprite.Create(
            texture,
            new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
        return token;
    }

    // Cria o token do cliente com base no Preset, e atribui uma imagem aleatória de cliente
    private GameObject CreatePersonToken()
    {
        // Obtém o Preset dos recursos e o instancia como um GameObject
        var token = (GameObject)Instantiate(Resources.Load("Prefabs/RecipientToken"));
        token.name = token.name + UnityEngine.Random.Range(0, 9999).ToString();
        // A partir de uma textura aleatória de cliente cria uma Sprite e atribui ao token.
        var texture = peopleIcons[UnityEngine.Random.Range(1, peopleIcons.Count + 1)];
        token.GetComponent<Customer>().Sprite = Sprite.Create(
            texture,
            new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f), 100.0f);
        return token;
    }

    // Metodo que trata o evento de pacote entregue
    public void PackageDelivered(IPackage package, ICustomer customer)
    {
        // Aumenta a pontuação e Dispara o evento Pontuação Alterada.
        Score += 1;
        ScoreChanged?.Invoke(Score);
        // Remove o token do cliente.
        customer.Remove(1f);
        // Cria novos token de pacote e cliente.
        Spawn();
    }

    // Metodo que trata o evento de pacote coletado
    public void PackageCollected(IPackage package)
    {
        // Remove o token do pacote.
        package.Remove(0.5f);
    }
}
