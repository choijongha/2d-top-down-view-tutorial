using UnityEngine;
using UnityEngine.SceneManagement;

public class hurtPlayer : MonoBehaviour
{
    private bool onReloading = false;
    [SerializeField] float waitToLoad = 2f;
    // Update is called once per frame
    void Update()
    {
        if (onReloading)
        {
            waitToLoad -= Time.deltaTime;
            if(waitToLoad <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }   
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
            if(collision.collider.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            onReloading = true;
        }
    }
}
