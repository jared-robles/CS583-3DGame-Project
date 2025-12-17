using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class Course : MonoBehaviour
{
    // Dictionary structure to store the par count for each course
    // Each entry's key is the course's scene name in the Assets folder
    // The value is that course's par count.
    private Dictionary<string, int> par =
        new Dictionary<string, int>() {
            {"TestCourse", 3},
            {"Course One", 6},
            {"MovingCourse", 3},
            {"LargeCourse", 12},
            {"RampJumpsCourse", 10},
            {"SplitPathsCourse", 15}
        };

    private int parCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Scene curr = SceneManager.GetActiveScene();
        if (par.TryGetValue(curr.name, out parCount))
        {
            Debug.Log($"Current level: {curr.name}, Par: {parCount}");
        }
        else
        {
            Debug.Log($"Could not find level of scene name {curr.name}");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetParCount()
    {
        return parCount;
    }
}
