using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public GameObject Target;
    private TextMeshProUGUI tmpScore;

    // Start is called before the first frame update
    void Start()
    {
        tmpScore = GetComponent<TextMeshProUGUI>();
    }

    public void ScoreChanged(int score)
    {
        tmpScore.text = $"Score: {score}";
    }

    private void Update()
    {
        var LRect = Target.GetComponent<RectTransform>();
        var LMyRect = GetComponent<RectTransform>();
        transform.position = Target.transform.position + new Vector3( (LRect.rect.width / 2) - LMyRect.rect.width, (LRect.rect.height /2) - LMyRect.rect.height, 0);
    }

}
