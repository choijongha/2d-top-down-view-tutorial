using UnityEngine;

public class AreaTransitionScript : MonoBehaviour
{
    private MainCameraController camera;
    [SerializeField] Vector2 newMinCameraBoundary;
    [SerializeField] Vector2 newMaxCameraBoundary;
    [SerializeField] Vector2 playerOffset;
    private void Awake()
    {
        camera = Camera.main.GetComponent<MainCameraController>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            camera.minCameraBoundary = newMinCameraBoundary;
            camera.maxCameraBoundary = newMaxCameraBoundary;

            camera.player.position += (Vector3)playerOffset;
        }
    }
}
