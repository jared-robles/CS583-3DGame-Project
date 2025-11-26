using UnityEngine;
using UnityEngine.SceneManagement;

// Summary
// Gives the button features
// As of right now, play button goes straight to TestCourse (Will eventually direct you to a course selection scene)
// Quit button doesn't do anything as of now (Should quit the game later)
// Will create a how to play button and settings button in the future

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene("TestCourse");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
