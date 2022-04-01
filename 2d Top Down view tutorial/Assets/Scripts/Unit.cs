using System;
using TMPro;
using UnityEngine;

namespace AllUnits
{
    public class Unit : MonoBehaviour
    {
        // �÷��̾�� �� ������ �������� ����� ����
        [SerializeField] internal float speed = 3f;
        [SerializeField] internal float maxHealth = 50f;
        [SerializeField] internal float currentHealth;
        [SerializeField] internal float damage = 5f;
        [SerializeField] internal float damageDelay = 2f;
        [SerializeField] internal float attackSpeed = 1f;
        [SerializeField] internal float attackDelay = 1f;
        // ���� ����
        protected bool isDamage = false;
        protected bool isAttackDelay = false;       
        public bool isDead = false;
        protected Animator unitAnimator;
        // ������ ���� ���¿� ���̴� ����
        [SerializeField] protected float damageFlashInterval = 0f;
        [SerializeField] protected float damageBound = 0f;
        private float initialDamageDelay;
        private float initialDamageFlashInterval;
        internal float initialAttackDelay;
        // ���� ����
        protected SpriteRenderer spriteRenderer;
        protected Rigidbody2D rb;
        // ��Ÿ ����
        internal float defaultAttackDelay;
        public int exp; 
        virtual protected void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            rb = GetComponent<Rigidbody2D>();
            unitAnimator = GetComponent<Animator>();
        }
        virtual protected void Start()
        {
            currentHealth = maxHealth;
            initialDamageDelay = damageDelay;
            initialDamageFlashInterval = damageFlashInterval;
            initialAttackDelay = attackDelay;
            defaultAttackDelay = initialAttackDelay;
        }
        virtual protected void Update()
        {
            DamageDelay();
            AttackDelay();
            AttackTotalSpeed();
        }
        virtual protected void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "HitBox" && !isDead)
            {
                // ���� �÷��̾� ����
                if (collision.GetComponentInParent<EnemyController>() && !isDamage)
                {
                    // ���� ���� ��
                    float hitdamageEnemy = collision.GetComponentInParent<EnemyController>().damage;
                    isDamage = true;
                    currentHealth -= hitdamageEnemy;
                    // �״´ٸ�
                    if (currentHealth <= 0)
                    {
                        isDead = true;
                        gameObject.SetActive(false);
                    }
                // �÷��̾ �� ����    
                }else if (collision.GetComponentInParent<Movement>())
                {
                    // ���� ���� ��
                    Movement hitdamagePlayer = collision.GetComponentInParent<Movement>();
                    currentHealth -= hitdamagePlayer.damage;
                    unitAnimator.SetTrigger("Hurt");
                    // �״´ٸ�
                    if (currentHealth <= 0)
                    {
                        isDead = true;
                        unitAnimator.SetBool("Died", true);
                        hitdamagePlayer.levelDesign.currentExp += exp;
                        Destroy(gameObject, 1f);
                    }
                }
            }
        }
        // ������ �԰� ���� �ð�
        protected void DamageDelay()
        {
            if (isDamage && damageDelay > 0)
            {
                damageDelay -= Time.deltaTime;
                DamageDelayAction();
                if (damageDelay <= 0)
                {
                    isDamage = false;
                    damageDelay = initialDamageDelay;
                    damageFlashInterval = initialDamageFlashInterval;
                    spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
                }
            }
        }
        // ���� �ð� ǥ��
        protected void DamageDelayAction()
        {
            var flashView = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
            var flashHide = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0f);
            if (damageDelay < initialDamageDelay - damageFlashInterval)
            {
                damageFlashInterval += initialDamageFlashInterval;
                
                if (spriteRenderer.color == flashView)
                {
                    spriteRenderer.color = flashHide; 
                } else if (spriteRenderer.color == flashHide)
                {
                    spriteRenderer.color = flashView;
                }
            }
            else if (damageDelay > initialDamageDelay * 0.99f)
            {
                spriteRenderer.color = flashHide;
            }
        }
        // ���� ���� �� ���� ���� ��Ÿ��
        protected void AttackDelay()
        {
            if (isAttackDelay)
            {
                attackDelay -= Time.deltaTime;
                unitAnimator.SetBool("IsIdle", true);
                if (attackDelay <= 0)
                {
                    isAttackDelay = false;
                    attackDelay = initialAttackDelay;
                }
            }
        }
        public void AttackTotalSpeed()
        {
            initialAttackDelay = defaultAttackDelay / attackSpeed;
        }
    }
    
}