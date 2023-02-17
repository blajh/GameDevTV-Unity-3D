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
                LoadNextLevel();
                break;
            default:
                ReloadLevel();
                break;
        }
    }

    private void ReloadLevel() {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    private void LoadNextLevel() {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        sceneIndex++;
        SceneManager.LoadScene(sceneIndex % SceneManager.sceneCountInBuildSettings);
    }
}
