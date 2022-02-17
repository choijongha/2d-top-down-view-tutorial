using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private Animator myAnim;
    public float playerMoveSpeed;
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        playerRb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * playerMoveSpeed * Time.deltaTime;

        myAnim.SetFloat("MoveX", playerRb.velocity.x);
        myAnim.SetFloat("MoveY", playerRb.velocity.y);
    }
}
