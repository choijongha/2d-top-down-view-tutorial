using UnityEngine;
using AllUnits;

public class EnemyController : Unit
{
    [SerializeField] Transform target;
    // ���ư��� ������ �ӵ�.
    [SerializeField] float backSpeed = 10f;
    // �����ϱ� ���� ���󰡴� ����
    [SerializeField] float followRange = 5f;
    // ������ ���߰� �����ϴ� ���� ��.
    [SerializeField] float attackRange = 1.3f;  
    // ���� �ǵ��ư��� ��ġ.
    [SerializeField] Transform homePos;
    private Animator anim;
    private float initialSpeed;
    override protected void Awake()
    {
        base.Awake();
        anim = GetComponent<Animator>();
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
            anim.SetFloat("MoveX", target.position.x - transform.position.x);
            anim.SetBool("IsMoving", true);
        }
        else if (Vector3.Distance(target.position, transform.position) < attackRange && target.gameObject.activeSelf)
        {
            anim.SetBool("IsMoving", false);
            anim.SetFloat("MoveX", target.position.x - transform.position.x);
            anim.SetTrigger("Attack");
        }
        else
        {
            BackHome();
        }                  
    }
    private void BackHome()
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
