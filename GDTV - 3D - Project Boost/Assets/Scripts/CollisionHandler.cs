using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    private string RELOAD_LEVEL = "ReloadLevel";
    private string LOAD_NEXT_LEVEL = "LoadNextLevel";    

    [SerializeField] private float loadDelay = 2f;
    [SerializeField] private AudioClip crashSFX;
    [SerializeField] private AudioClip successSFX;
    
    [SerializeField] private ParticleSystem finishParticles;
    [SerializeField] private ParticleSystem crashParticles;

    private AudioSource audioSource;
    private bool isTransitioning = false;

    private void Awake() {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision) {

        if(!isTransitioning) {
            string tag = collision.gameObject.tag;
            switch (tag) {
                case "Friendly":
                    Debug.Log("A friendly bump.");
                    break;
                case "Finish":
                    Debug.Log("You've made it");
                    StartSuccessSequence();                
                    break;
                default:
                    Debug.Log("Boom goes the rocket");
                    StartCrashSequence();
                    break;
            }
        }
    }

    private void StartSuccessSequence() {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(successSFX);
        finishParticles.Play();
        GetComponent<Movement>().enabled = false;        
        Invoke(LOAD_NEXT_LEVEL, loadDelay);
    }

    private void StartCrashSequence() {
        isTransitioning = true;
        audioSource.Stop();
        audioSource.PlayOneShot(crashSFX, .1f);
        crashParticles.Play();
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
