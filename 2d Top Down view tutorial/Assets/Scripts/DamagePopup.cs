using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    // Create Damage Popup
    public static DamagePopup Create(Vector3 position, float damageAmount, bool isCritical)
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Transform damagePopupTransform = Instantiate(gameManager.damageText, position, Quaternion.identity);

        DamagePopup damagePopup = damagePopupTransform.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount, isCritical);

        return damagePopup;
    }
    private TextMeshPro textMesh;
    private float disappearTimer;
    private Color textMeshColor;
    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }
    private void Setup(float damageAmount, bool isCritical)
    {
        textMesh.SetText(damageAmount.ToString());
        if (!isCritical)
        {
            textMesh.fontSize = 3;
            textMeshColor = Color.yellow;
        }
        else
        {
            textMesh.fontSize = 5;
            textMeshColor.r = 1;
            textMeshColor.g = 0;
            textMeshColor.b = 0;
            textMeshColor.a = 1;
        }
        textMesh.color = textMeshColor;
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
