using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : Unit
{
    private Rigidbody2D playerRb;
    private Animator myAnim;
    
    public bool isDead { get; private set; } = false;
    
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }
    
    private void Update()
    {
        DamageDelay(damageDelay);
        
    }
    private void FixedUpdate()
    {
        // Rigidbody2D.velocity
        /*playerRb.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) ;
        myAnim.SetFloat("MoveX", playerRb.velocity.x);
        myAnim.SetFloat("MoveY", playerRb.velocity.y);
        */

        // Transform.position
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        Vector3 moveVector = new Vector2(moveX, moveY);
        playerRb.transform.position += moveVector.normalized * speed *Time.deltaTime;
        myAnim.SetFloat("MoveX", moveX);
        myAnim.SetFloat("MoveY", moveY);
        
        if(Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            myAnim.SetFloat("LastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("LastMoveY", Input.GetAxisRaw("Vertical"));
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy" && OnDamage(false))
        {
            OnDamage(true);
            float enemyAttack = collision.gameObject.GetComponent<EnemyController>().damage;
            currentHealth -= enemyAttack;
            
            if (currentHealth <= 0)
            {
                isDead = true;
                gameObject.SetActive(false);
            }
        }
    }
    
}
