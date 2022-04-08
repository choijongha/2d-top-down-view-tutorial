using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatPanel : MonoBehaviour
{
    public GameObject playerPanel;
    public Movement playerScript;
    public LevelDesign levelDesign;
    public TextMeshProUGUI movetext;
    public TextMeshProUGUI hptext;
    public TextMeshProUGUI damagetext;
    public TextMeshProUGUI attackSpeedtext;
    public TMP_InputField moveInput;
    public TMP_InputField hpInput;
    public TMP_InputField damageInput;
    public TMP_InputField attackSpeedInput;
    public TextMeshProUGUI levelUpMoveText;
    public TextMeshProUGUI levelUpHpText;
    public TextMeshProUGUI levelUpDamageText;
    public TextMeshProUGUI levelUpAttackSpeedText;

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

        Upstats();
    }
    private void Update()
    {
        Upstats();
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
        if(moveInput.text != "")
        {
            movetext.text = $"Move Speed: {moveInput.text}";
            playerScript.speed = int.Parse(moveInput.text) + levelDesign.levelUpMove;
            levelDesign.initialMove = int.Parse(moveInput.text);
        }
    }
    public void ChangeHpValue()
    {
        if (hpInput.text != "")
        {
            hptext.text = $"Hp : {hpInput.text}";
            playerScript.maxHealth = int.Parse(hpInput.text) + levelDesign.levelUpMaxHealth;
            levelDesign.initialMaxHealth = int.Parse(hpInput.text);
        }
    }
    public void ChangeDamageValue()
    {
        if (damageInput.text != "")
        {
            damagetext.text = $"Damage : {damageInput.text}";
            playerScript.damage = int.Parse(damageInput.text) + levelDesign.levelUpDamageUp;
            levelDesign.initialDamageUp = int.Parse(damageInput.text);
        }
    }
    public void ChangeASpeedValue()
    {
        if (attackSpeedInput.text != "")
        {
            attackSpeedtext.text = $"A/Speed: {attackSpeedInput.text}";
            playerScript.attackSpeed = int.Parse(attackSpeedInput.text) + levelDesign.levelUpAttackSpeed;
            levelDesign.initialAttackSpeed = int.Parse(attackSpeedInput.text);
        }  
    }
    public void HPFull()
    {
        if(playerScript.currentHealth != playerScript.maxHealth)
        {
            playerScript.currentHealth = playerScript.maxHealth;
        }
    }
    private void Upstats()
    {
        levelUpMoveText.text = $"+{levelDesign.levelUpMove}";
        levelUpHpText.text = $"+{levelDesign.levelUpMaxHealth}";
        levelUpDamageText.text = $"+{levelDesign.levelUpDamageUp}";
        levelUpAttackSpeedText.text = $"+{levelDesign.levelUpAttackSpeed}";
    }
}