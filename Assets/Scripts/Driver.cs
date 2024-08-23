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
        // Move o objeto na dire��o desejada
        breaking = Input.GetButton("X Button");
        float moveValue = GetMoveValue();
        transform.Translate(0, GetMoveValue(), 0);
        float reverseModifier = moveValue < 0 ? -1f : 1f;
        transform.Rotate(0, 0, GetSteerValue() * reverseModifier);
    }

    private float GetMoveValue()
    {
        // Obt�m o valor do Eixo Vertical multiplicando com o valor de velocidade e o deltaTime
        // DELTA TIME: � o tempo de dura��o do �ltimo frame, ele � utilizado
        // para remover a varia��o de taxa de frames dos c�lculos de anima��es.
        return Input.GetAxis("Trigger Shared Axis") * currentSpeed * (breaking ? 0.5f : 1f) * Time.deltaTime;
    }

    private float GetSteerValue()
    {
        return -Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
    }

    // Diminui a velocidade do carro por 32 ao bater em algum obst�culo.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // CancelInvoke: remove quaisquer execu��es da fun��o methodName que tenham sido agendadas por algum m�todo Invoke.
        CancelInvoke(nameof(ResetSpeed));
        SpeedRate = SpeedRate.Slow;
        Debug.Log("Bump!");
        // Invoke: executa a fun��o passada como par�metro methodName ap�s o intervalo em segundos informado no par�metro time.
        Invoke(nameof(ResetSpeed), 3);
    }

    // Aumenta a velocidade do carro por 5s ao atravessar um ponto de speed boost.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Tags: podem ser informadas nos GameObjects para servir como um identificador.
        // CompareTags: indica se a Tag em quest�o est� associada ao objeto.
        if (collision.CompareTag(Tags.Boost))
        {
            // CancelInvoke: remove quaisquer execu��es da fun��o methodName que tenham sido agendadas por algum m�todo Invoke.
            CancelInvoke(nameof(ResetSpeed));
            SpeedRate = SpeedRate.Fast;
            Debug.Log("Boost!");
            // Invoke: executa a fun��o passada como par�metro methodName ap�s o intervalo em segundos informado no par�metro time.
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

