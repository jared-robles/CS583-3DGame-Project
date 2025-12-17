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
        SceneManager.LoadScene("");
    }

    public void StartCourse2()
    {
        SceneManager.LoadScene("");
    }

    public void StartCourse3()
    {
        SceneManager.LoadScene("");
    }

    public void StartCourse4()
    {
        SceneManager.LoadScene("");
    }
}
