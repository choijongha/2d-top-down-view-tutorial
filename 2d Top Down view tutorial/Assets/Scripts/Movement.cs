using UnityEngine;
using AllUnits;
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : Unit
{
    private Animator myAnim;
    private AreaTransitionScript boundaryScript;
    public Vector2 saveMaxPos { get; private set; }
    public Vector2 saveMinPos { get; private set; }
    override protected void Awake()
    {
        base.Awake();
        myAnim = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();
        AttackKey();
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
        rb.transform.position += moveVector.normalized * speed * Time.deltaTime;
        myAnim.SetFloat("MoveX", moveX);
        myAnim.SetFloat("MoveY", moveY);

        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            myAnim.SetFloat("LastMoveX", Input.GetAxisRaw("Horizontal"));
            myAnim.SetFloat("LastMoveY", Input.GetAxisRaw("Vertical"));
        }
    }
    private void AttackKey()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myAnim.SetBool("Attacking", true);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            myAnim.SetBool("Attacking", false);
        }
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
        if (collision.tag == "Boundary")
        {
            boundaryScript = collision.GetComponent<AreaTransitionScript>();
            saveMaxPos = boundaryScript.newMaxCameraBoundary;
            saveMinPos = boundaryScript.newMinCameraBoundary;
        }
    }
}

