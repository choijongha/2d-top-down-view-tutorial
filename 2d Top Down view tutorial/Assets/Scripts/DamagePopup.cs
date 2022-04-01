using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    // Create Damage Popup
    public static DamagePopup Create(Vector3 position, int damageAmount)
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Transform damagePopupTransform = Instantiate(gameManager.damageText, position, Quaternion.identity);

        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount);

        return damagePopup;
    }
    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textMeshColor;
    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }
    private void Setup(int damageAmount)
    {
        textMesh.SetText(damageAmount.ToString());
        textMeshColor = textMesh.color;
        disappearTimer = 1f;
    }
    private void Update()
    {
        float moveYSpeed = 1f;
        transform.position += new Vector3(0, moveYSpeed) * Time.deltaTime;
      
        disappearTimer -= Time.deltaTime;
        if(disappearTimer < 0)
        {
            float disappearSpeed = 3f;
            textMeshColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textMeshColor;
            if(textMeshColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
