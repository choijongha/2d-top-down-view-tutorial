using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator anim;
    [SerializeField] Transform target;
    [SerializeField] float speed = 3f;
    [SerializeField] float backSpeed = 10f;
    [SerializeField] float attackMaxRange;
    [SerializeField] float attackMinRange;
    [SerializeField] Transform homePos;
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
        if (Vector3.Distance(target.position, transform.position) <= attackMaxRange && Vector3.Distance(target.position, transform.position) >= attackMinRange)
        {
            speed = initialSpeed;
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            anim.SetFloat("MoveX", target.position.x - transform.position.x);
            anim.SetBool("IsMoving", true);
        }
        else if (Vector3.Distance(target.position, transform.position) < attackMinRange)
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
