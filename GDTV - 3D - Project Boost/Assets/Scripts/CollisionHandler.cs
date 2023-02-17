using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        string tag = collision.gameObject.tag;
        switch (tag) {
            case "Friendly":
                Debug.Log("A friendly bump.");
                break;
            case "Fuel":
                Debug.Log("Fuel is pumping engines.");
                Destroy(collision.gameObject);
                break;
            case "Finish":
                Debug.Log("You've made it");
                break;
            default:
                ReloadLevel();
                break;
        }
    }

    private static void ReloadLevel() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
