using UnityEngine;
using TMPro;

public class StrokeCounter : MonoBehaviour
{
    private TextMeshProUGUI _strokeCntr;

    void Awake()
    {
        _strokeCntr = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateStrokes(int strokes)
    {
        _strokeCntr.text = strokes.ToString("Strokes: #");
    }
}
