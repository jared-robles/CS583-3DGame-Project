using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class Results : MonoBehaviour
{
    [Header("Inscribed")]
    public Animator animator;
    public Animator mmButtonAnimator;
    public Animator csButtonAnimator;
    public TMP_ColorGradient holeInOneCG;
    public TMP_ColorGradient birdieCG;
    public TMP_ColorGradient parCG;
    public TMP_ColorGradient bogeyCG;

    public GameObject holeInOneFX;
    public GameObject birdieFX;
    public GameObject parFX;

    private int _strokes;
    private int _par;
    private bool _inHole;
    private bool _played;

    private BallController _ball; 
    private Course _course;
    private TextMeshProUGUI _txt;

    void Start()
    {
        _ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<BallController>(); 
        _course = Camera.main.GetComponent<Course>(); 
        _txt = GetComponent<TextMeshProUGUI>(); 
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
        mmButtonAnimator.SetBool("scored", _inHole);
        csButtonAnimator.SetBool("scored", _inHole);
    }

    void DetermineResult()
    {
        // Get stroke and par counts from the ball
        _strokes = _ball.GetStrokeCount();
        _par = _course.GetParCount();

        // Compare number of strokes to the current par
        // Set the respective text and color gradient to its result
        if (_strokes <= 1)
        {
            _txt.colorGradientPreset = holeInOneCG;
            _txt.text = "Hole in One";
            if (!_played)
            {
                Instantiate(holeInOneFX);
                GameObject.FindGameObjectWithTag("FxTemporaire").transform.position = _ball.gameObject.transform.position;
                _played = true;
            }
        }
        else if (_strokes < _par && _strokes > 1)
        {
            _txt.colorGradientPreset = birdieCG;
            _txt.text = "Birdie";
            if (!_played)
            {
                Instantiate(birdieFX);
                GameObject.FindGameObjectWithTag("FxTemporaire").transform.position = _ball.gameObject.transform.position;
                _played = true;
            }
        }
        else if (_strokes == _par) 
        {
            _txt.colorGradientPreset = parCG;
            _txt.text = "Par";
            if (!_played) 
            {
                Instantiate(parFX);
                GameObject.FindGameObjectWithTag("FxTemporaire").transform.position = _ball.gameObject.transform.position;
                _played = true;
            }
        }
        else
        {
            _txt.colorGradientPreset = bogeyCG;
            _txt.text = "Bogey";
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void CourseSelect()
    {
        SceneManager.LoadScene("CourseSelection");
    }
}
