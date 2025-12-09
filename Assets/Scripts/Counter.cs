using UnityEngine;
using TMPro;

public class ParCounter : MonoBehaviour
{
    private BallController ball;
    private TextMeshProUGUI _counter;

    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallController>();
        _counter = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateStrokes(int strokes)
    {
        _counter.text = strokes.ToString("Strokes: #");
    }

    public void UpdatePar(int par)
    {
        _counter.text = par.ToString("Par: #");
    }
}
