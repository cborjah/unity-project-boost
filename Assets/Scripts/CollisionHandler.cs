using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("This object is friendly.");
                break;

            case "Finish":
                LoadNextLevel();
                break;

            case "Fuel":
                Debug.Log("Ship refueled.");
                break;

            default:
                ReloadLevel();
                break;
        }
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
