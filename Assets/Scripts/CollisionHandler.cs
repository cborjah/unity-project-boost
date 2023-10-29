using UnityEngine;

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
                Debug.Log("You blew up!");
                break;
        }
    }
}
