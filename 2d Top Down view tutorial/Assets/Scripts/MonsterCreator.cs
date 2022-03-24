using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using AllUnits;

public class MonsterCreator : MonoBehaviour
{
    public GameObject monsterPanel;
    public TextMeshProUGUI movetext;
    public TextMeshProUGUI hptext;
    public TextMeshProUGUI damagetext;
    public TextMeshProUGUI attackSpeedtext;
    public TMP_InputField moveInput;
    public TMP_InputField hpInput;
    public TMP_InputField damageInput;
    public TMP_InputField attackSpeedInput;
    public GameObject monsterFlower;
    public GameObject monsters;

    public void MonsterPanelOpenClose()
    {
        if (monsterPanel.activeSelf == false)
        {
            monsterPanel.SetActive(true);
        }
        else
        {
            monsterPanel.SetActive(false);
        }
    }
    public int ChangeHpValue()
    {
        return int.Parse(hpInput.text);
    }
    public int ChangeMoveValue()
    {
        return int.Parse(moveInput.text);
    }
    public int ChangeDamageValue()
    {
        return int.Parse(damageInput.text);
    }
    public int ChangeAttackSpeedValue()
    {
        return int.Parse(attackSpeedInput.text);
    }

    public void CreateMonster()
    {
        EnemyController clone = Instantiate(monsterFlower, monsters.transform).GetComponent<EnemyController>();
        clone.maxHealth = ChangeHpValue();
        clone.speed = ChangeMoveValue();
        clone.damage = ChangeDamageValue();
        clone.attackSpeed = ChangeAttackSpeedValue();
        clone.attackDelay = clone.attackDelay / clone.attackSpeed;
        Debug.Log("Creator");
    }
}
