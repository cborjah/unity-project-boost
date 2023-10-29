using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 1f;

    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This object is friendly.");
                break;

            case "Finish":
                StartSuccessSequence();
                break;

            case "Fuel":
                Debug.Log("Ship refueled.");
                break;

            default:
                StartCrashSequence();
                break;
        }
    }

    void StartCrashSequence()
    {
        // TODO: Add SFX upon crash
        // TODO: Add particle effect upon crash

        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", levelLoadDelay); // Reload level after 1 second of delay.
    }

    void StartSuccessSequence()
    {
        // TODO: Add SFX upon crash
        // TODO: Add particle effect upon crash

        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", levelLoadDelay);
    }

    void ReloadLevel()
    {
        // SceneManager.LoadScene(0);
        // SceneManager.LoadScene("Sandbox");

        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }
}
