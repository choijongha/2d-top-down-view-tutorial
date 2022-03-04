using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    // 따라가는 움직임 속도.
    [SerializeField] protected float speed = 3f;
    [SerializeField] protected float maxHealth = 50f;
    [SerializeField] public float currentHealth;
    [SerializeField] public float damage = 5f;
    [SerializeField] public float damageDelay = 2f;
    private float initialDamageDelay;
    [SerializeField] protected bool isDamage = false;
    
    // Start is called before the first frame update
    virtual protected void Start()
    {
        currentHealth = maxHealth;
        initialDamageDelay = damageDelay;
    }
    virtual protected void Update()
    {
        DamageDelay();
    }
    protected void DamageDelay()
    {
        if (isDamage && damageDelay > 0)
        {
            damageDelay -= Time.deltaTime;
            if (damageDelay <= 0)
            {
                isDamage = false;
                damageDelay = initialDamageDelay;
            }
        }
    }
}
