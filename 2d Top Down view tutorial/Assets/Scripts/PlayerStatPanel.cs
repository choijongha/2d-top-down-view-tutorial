using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatPanel : MonoBehaviour
{
    public GameObject playerPanel;
    public Movement playerScript;
    public TextMeshProUGUI movetext;
    public TextMeshProUGUI hptext;
    public TextMeshProUGUI damagetext;
    public TextMeshProUGUI attackSpeedtext;
    public TMP_InputField moveInput;
    public TMP_InputField hpInput;
    public TMP_InputField damageInput;
    public TMP_InputField attackSpeedInput;

    private void Awake()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }
    private void Start()
    {
        movetext.text = $"Move Speed: {playerScript.speed}";
        hptext.text = $"Hp : {playerScript.maxHealth}";
        damagetext.text = $"Damage : {playerScript.damage}";
        attackSpeedtext.text = $"A/Speed: {playerScript.attackSpeed}";
    }
    public void PlayerPanelOpenClose()
    {
        if (playerPanel.activeSelf == false)
        {
            playerPanel.SetActive(true);
        }
        else
        {
            playerPanel.SetActive(false);
        }
    }
    public void ChangeMoveValue()
    {
        movetext.text = $"Move Speed: {moveInput.text}";
        playerScript.speed = int.Parse(moveInput.text);
    }
    public void ChangeHpValue()
    {
        hptext.text = $"Hp : {hpInput.text}";
        playerScript.maxHealth = int.Parse(hpInput.text);
    }
    public void ChangeDamageValue()
    {
        damagetext.text = $"Damage : {damageInput.text}";
        playerScript.damage = int.Parse(damageInput.text);
    }
    public void ChangeASpeedValue()
    {
        if(int.Parse(attackSpeedInput.text) != 0)
        {
            attackSpeedtext.text = $"A/Speed: {attackSpeedInput.text}";
            playerScript.attackSpeed = int.Parse(attackSpeedInput.text);
            playerScript.initialAttackDelay = playerScript.defaultAttackDelay / playerScript.attackSpeed;
        }  
    }
    public void HPFull()
    {
        if(playerScript.currentHealth != playerScript.maxHealth)
        {
            playerScript.currentHealth = playerScript.maxHealth;
        }
        
    }
}