using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    [Header("Panels")]
    public GameObject HowToPlayPanel;

    void Start()
    {
        HowToPlayPanel.SetActive(false);
    }

    // Main Menu

    public void PlayGame() {
        SceneManager.LoadScene("CourseSelection");
    }

    public void QuitGame() {
        Application.Quit();
    }

    // How To Play

    public void OpenHowToPlay()
    {
        HowToPlayPanel.SetActive(true);
    }

    public void CloseHowToPlay()
    {
        HowToPlayPanel.SetActive(false);
    }

}
