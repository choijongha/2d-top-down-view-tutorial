using UnityEngine;
using AllUnits;

public class EnemyController : Unit
{
    [SerializeField] Transform target;
    // 돌아가는 움직임 속도.
    [SerializeField] float backSpeed = 10f;
    // 공격하기 위해 따라가는 범위
    [SerializeField] float followRange = 5f;
    // 따라감을 멈추고 공격하는 범위 안.
    [SerializeField] float attackRange = 1.3f;  
    // 적이 되돌아가는 위치.
    [SerializeField] Transform homePos;
    
    private float initialSpeed;
    override protected void Awake()
    {
        base.Awake();
        target = FindObjectOfType<Movement>().transform;
    }
    override protected void Start()
    {
        base.Start();
        initialSpeed = speed;
    }
    override protected void Update()
    {
        base.Update();
        Movement();
    }

    private void Movement()
    {
        if (Vector3.Distance(target.position, transform.position) <= followRange && Vector3.Distance(target.position, transform.position) >= attackRange && target.gameObject.activeSelf)
        {
            speed = initialSpeed;
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            unitAnimator.SetFloat("MoveX", target.position.x - transform.position.x);
            unitAnimator.SetBool("IsMoving", true);
        }
        else if (Vector3.Distance(target.position, transform.position) < attackRange && target.gameObject.activeSelf)
        {
            unitAnimator.SetBool("IsMoving", false);
            unitAnimator.SetFloat("MoveX", target.position.x - transform.position.x);
            unitAnimator.SetTrigger("Attack");
            unitAnimator.SetFloat("AttackSpeed", attackSpeed);
        }
        else
        {
            BackHome();
        }                  
    }
    private void BackHome()
    {
        unitAnimator.SetBool("IsMoving", true);
        unitAnimator.SetFloat("MoveX", homePos.position.x - transform.position.x);
        speed = backSpeed;
        transform.position = Vector3.MoveTowards(transform.position, homePos.position, speed*Time.deltaTime);
        
        if(Vector3.Distance(homePos.position,transform.position) == 0)
        {
            unitAnimator.SetBool("IsMoving", false);
        }
    }
    
}
