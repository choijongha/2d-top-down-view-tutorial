using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class monsterHPbar : MonoBehaviour
{
    private Canvas canvas;
    private Camera uiCamera;
    private RectTransform rectParent;
    private RectTransform rectHP;
    private EnemyController enemyScript;

    public Vector2 offset = new Vector2(0,-0.6f);
    public Transform enemyTr;
    private Slider monsterHP;
    private void Awake()
    {
        canvas = GetComponentInParent<Canvas>();
        uiCamera = canvas.worldCamera;
        rectParent = canvas.GetComponent<RectTransform>();
        rectHP = this.gameObject.GetComponent<RectTransform>();
        enemyScript = GetComponentInParent<EnemyController>();
        monsterHP = GetComponent<Slider>();
    }
    private void Start()
    {
        rectHP.position = Camera.main.WorldToScreenPoint(enemyScript.transform.position + (Vector3)offset);
        monsterHP.maxValue = enemyScript.maxHealth;
        
    }
    private void LateUpdate()
    {
        monsterHP.value = enemyScript.currentHealth;
    }
    private void Update()
    {
        rectHP.position = Camera.main.WorldToScreenPoint(enemyScript.transform.position + (Vector3)offset);
    }
}
