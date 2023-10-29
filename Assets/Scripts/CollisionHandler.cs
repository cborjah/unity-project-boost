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
                Debug.Log("You landed successfully!");
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
}
