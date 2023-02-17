using UnityEngine;

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
        }
    }
}
