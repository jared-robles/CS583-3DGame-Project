using UnityEngine;
using UnityEngine.SceneManagement;

//Summary: This class represents a golf hole in a Unity game.
// If a golf ball hits it (maybe through a trigger collider), something should happen to the scene.
// By default, it will reload the current scene.
// Maybe a string variable could be added to specify a different scene to load.
// You can customize the behavior by modifying the OnTriggerEnter method.

public class GolfHole : MonoBehaviour
{

    public string sceneToLoad; // Name of the scene to load when the ball hits the hole

    private void OnTriggerEnter(Collider other) // Called when another collider enters the trigger collider attached to this object
    {
        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
