using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private string RELOAD_LEVEL = "ReloadLevel";
    private string LOAD_NEXT_LEVEL = "LoadNextLevel";    

    [SerializeField] private float loadDelay = 2f;

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
                Invoke(LOAD_NEXT_LEVEL, loadDelay);
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    private void StartCrashSequence() {
        // TODO add SFX
        // TODO add Particle System
        GetComponent<Movement>().enabled = false;        
        Invoke(RELOAD_LEVEL, loadDelay);
    }

    private void ReloadLevel() { // has string reference for Invoke
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
    }

    private void LoadNextLevel() { // has string reference for Invoke
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        sceneIndex++;
        SceneManager.LoadScene(sceneIndex % SceneManager.sceneCountInBuildSettings);
    }
}
