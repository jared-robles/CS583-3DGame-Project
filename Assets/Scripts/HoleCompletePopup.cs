using UnityEngine;
using UnityEngine.SceneManagement;

public class HoleCompletePopup : MonoBehaviour
{
    public void GoToCourseSelect()
    {
        SceneManager.LoadScene("CourseSelection");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
