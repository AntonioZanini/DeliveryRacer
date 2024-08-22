using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    [SerializeField] 
    private GameObject Target;

    private Vector3 originalPosition;

    private void Awake()
    {
        originalPosition = transform.position;
    }

    void LateUpdate()
    {
        transform.position = Target.transform.position + originalPosition;
    }
}
