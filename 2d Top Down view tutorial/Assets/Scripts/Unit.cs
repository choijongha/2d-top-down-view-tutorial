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
    
    // Start is called before the first frame update
    virtual protected void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected void DamageDelay(float initialDelay)
    {
        if (OnDamage(true))
        {
            damageDelay =- Time.deltaTime;
            if(damageDelay <= 0)
            {
                OnDamage(false);
                damageDelay = initialDelay;                
            }
        }
    }
    protected bool OnDamage(bool onDamage)
    {
        return onDamage;
    }
}
