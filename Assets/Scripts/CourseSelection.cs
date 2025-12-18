using UnityEngine;
using UnityEngine.SceneManagement;

public class CourseSelection : MonoBehaviour
{

    public void StartCourseP()
    {
        SceneManager.LoadScene("TestCourse");
    }

    public void StartCourse1()
    {
        SceneManager.LoadScene("Course One");
    }

    public void StartCourse2()
    {
        SceneManager.LoadScene("LargeCourse");
    }

    public void StartCourse3()
    {
        SceneManager.LoadScene("MovingCourse");
    }

    public void StartCourse4()
    {
        SceneManager.LoadScene("RampJumpsCourse");
    }

    public void StartCourse5()
    {
        SceneManager.LoadScene("SplitPathsCourse");
    }

    public void GoBack()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
