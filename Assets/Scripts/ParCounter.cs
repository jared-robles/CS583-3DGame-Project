using UnityEngine;
using TMPro;

public class ParCounter : MonoBehaviour
{
    private TextMeshProUGUI _parCntr; // Reference to UI text
    private Course _course; // Reference to Course script
    private int _par;

    void Awake()
    {
        _parCntr = GetComponent<TextMeshProUGUI>();
        _course = Camera.main.GetComponent<Course>(); // Main camera holds the course information
    }

    public void Update()
    {
        // Get the course's par count and display it
        _par = _course.GetParCount();
        _parCntr.text = _par.ToString("Par: #");
    }
}
