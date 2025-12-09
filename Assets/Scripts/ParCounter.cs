using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    private TextMeshProUGUI _counter;

    void Awake()
    {
        _counter = GetComponent<TextMeshProUGUI>();
    }

    public void UpdatePar(int par)
    {
        _counter.text = par.ToString("Par: #");
    }
}
