using UnityEngine;
using TMPro;

public class ParCounter : MonoBehaviour
{
    private TextMeshProUGUI _parCntr;
    private BallController _ball;
    private int _par;

    void Awake()
    {
        _parCntr = GetComponent<TextMeshProUGUI>();
        _ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallController>();
    }

    public void Update()
    {
        _par = _ball.GetParCount();
        _parCntr.text = _par.ToString("Par: #");
    }
}
