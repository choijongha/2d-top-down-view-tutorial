using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Transform target;
    // ���󰡴� ������ �ӵ�.
    [SerializeField] float speed = 3f;
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
