using UnityEngine;
public enum SpeedRate
{
    Slow,
    Standard,
    Fast
}

public class Driver : MonoBehaviour
{

    [SerializeField]
    public float steerSpeed = 200f;
    [SerializeField]
    public float moveSpeed = 10f;
    [SerializeField]
    public float slowSpeed = 5f;
    [SerializeField]
    public float fastSpeed = 20f;

    private float currentSpeed;
    private SpeedRate _speedRate;
    private bool breaking;

    [SerializeField]
    public SpeedRate SpeedRate
    {
        get => _speedRate;
        set
        {
            _speedRate = value;
            SetSpeed();
        }
    }

    private void Awake()
    {
        SpeedRate = SpeedRate.Standard;
    }

    // Update is called once per frame
    void Update()
    {
        // Move o objeto na direção desejada
        breaking = Input.GetButton("X Button");
        float moveValue = GetMoveValue();
        transform.Translate(0, GetMoveValue(), 0);
        float reverseModifier = moveValue < 0 ? -1f : 1f;
        transform.Rotate(0, 0, GetSteerValue() * reverseModifier);
    }

    private float GetMoveValue()
    {
        // Obtém o valor do Eixo Vertical multiplicando com o valor de velocidade e o deltaTime
        // DELTA TIME: é o tempo de duração do último frame, ele é utilizado
        // para remover a variação de taxa de frames dos cálculos de animações.
        return Input.GetAxis("Trigger Shared Axis") * currentSpeed * (breaking ? 0.5f : 1f) * Time.deltaTime;
    }

    private float GetSteerValue()
    {
        return -Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
    }

    // Diminui a velocidade do carro por 32 ao bater em algum obstáculo.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // CancelInvoke: remove quaisquer execuções da função methodName que tenham sido agendadas por algum método Invoke.
        CancelInvoke(nameof(ResetSpeed));
        SpeedRate = SpeedRate.Slow;
        Debug.Log("Bump!");
        // Invoke: executa a função passada como parâmetro methodName após o intervalo em segundos informado no parâmetro time.
        Invoke(nameof(ResetSpeed), 3);
    }

    // Aumenta a velocidade do carro por 5s ao atravessar um ponto de speed boost.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Tags: podem ser informadas nos GameObjects para servir como um identificador.
        // CompareTags: indica se a Tag em questão está associada ao objeto.
        if (collision.CompareTag(Tags.Boost))
        {
            // CancelInvoke: remove quaisquer execuções da função methodName que tenham sido agendadas por algum método Invoke.
            CancelInvoke(nameof(ResetSpeed));
            SpeedRate = SpeedRate.Fast;
            Debug.Log("Boost!");
            // Invoke: executa a função passada como parâmetro methodName após o intervalo em segundos informado no parâmetro time.
            Invoke(nameof(ResetSpeed), 5);
        }
    }

    private void ResetSpeed()
    {
        SpeedRate = SpeedRate.Standard;
    }

    private void SetSpeed()
    {
        currentSpeed = _speedRate == SpeedRate.Standard ? moveSpeed :
                        _speedRate == SpeedRate.Fast ? fastSpeed :
                        slowSpeed;
    }
}

