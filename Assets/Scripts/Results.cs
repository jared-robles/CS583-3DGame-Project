using UnityEngine;
using TMPro;
using System.Collections;

public class Results : MonoBehaviour
{
    [Header("Inscribed")]
    // References to the animator and color gradient presets
    public Animator animator;
    public TMP_ColorGradient holeInOneCG;
    public TMP_ColorGradient birdieCG;
    public TMP_ColorGradient parCG;
    public TMP_ColorGradient bogeyCG;

    // Store the number of strokes and par count
    private int _strokes;
    private int _par;
    private bool _inHole; // Store ball score status

    private BallController _ball; // Reference to BallController script
    private Course _course; // Reference to Course script
    private TextMeshProUGUI _txt; // Reference to the text component

    void Start()
    {
        _ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallController>(); // BallController script
        _course = Camera.main.GetComponent<Course>(); // Course script from the main camera
        _txt = GetComponent<TextMeshProUGUI>(); // This object's TMPro component
    }

    void Update()
    {
        // Check if the ball is in the hole
        _inHole = _ball.GetGoalStatus();
        if (_inHole)
        {
            DetermineResult(); // Determine the result based on stroke count and par
        }

        // Set the animator to play the result text animation when scored
        animator.SetBool("scored", _inHole);
    }

    void DetermineResult()
    {
        // Get stroke and par counts from the ball
        _strokes = _ball.GetStrokeCount();
        _par = _course.GetParCount();

        // Compare number of strokes to the current par
        // Set the respective text and color gradient to its result
        if (_strokes <= 1) // Hole in one
        {
            _txt.colorGradientPreset = holeInOneCG;
            _txt.text = "Hole in One";
        }
        else if (_strokes < _par && _strokes > 1) // Birdie
        {
            _txt.colorGradientPreset = birdieCG;
            _txt.text = "Birdie";
        }
        else if (_strokes == _par) // Par
        {
            _txt.colorGradientPreset = parCG;
            _txt.text = "Par";
        }
        else // Bogey
        {
            _txt.colorGradientPreset = bogeyCG;
            _txt.text = "Bogey";
        }
    }
}
