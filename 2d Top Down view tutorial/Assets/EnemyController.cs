using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform target;
    // 따라가는 움직임 속도.
    [SerializeField] float speed = 3f;
    // 돌아가는 움직임 속도.
    [SerializeField] float backSpeed = 10f;
    // 공격하기 위해 따라가는 범위
    [SerializeField] float followRange = 5f;
    // 따라감을 멈추고 공격하는 범위 안.
    [SerializeField] float attackRange = 1.3f;  
    // 적이 되돌아가는 위치.
    [SerializeField] Transform homePos;
    private Animator anim;
    private float initialSpeed;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        target = FindObjectOfType<Movement>().transform;
    }
    private void Start()
    {
        initialSpeed = speed;
    }
    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        if (Vector3.Distance(target.position, transform.position) <= followRange && Vector3.Distance(target.position, transform.position) >= attackRange)
        {
            speed = initialSpeed;
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            anim.SetFloat("MoveX", target.position.x - transform.position.x);
            anim.SetBool("IsMoving", true);
        }
        else if (Vector3.Distance(target.position, transform.position) < attackRange)
        {
            anim.SetBool("IsMoving", false);
            anim.SetTrigger("Attack");
        }
        else
        {
            backHome();
        }                  
    }
    private void backHome()
    {
        anim.SetBool("IsMoving", true);
        anim.SetFloat("MoveX", homePos.position.x - transform.position.x);
        speed = backSpeed;
        transform.position = Vector3.MoveTowards(transform.position, homePos.position, speed*Time.deltaTime);
        
        if(Vector3.Distance(homePos.position,transform.position) == 0)
        {
            anim.SetBool("IsMoving", false);
        }
    }
}
