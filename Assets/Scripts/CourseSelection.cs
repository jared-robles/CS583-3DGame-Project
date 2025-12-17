using UnityEngine;
using UnityEngine.SceneManagement;

public class CourseSelection : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
}
