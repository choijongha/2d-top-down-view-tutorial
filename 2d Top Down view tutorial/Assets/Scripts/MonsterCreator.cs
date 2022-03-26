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

    public void CreateMonster()
    {
        if (hpInput.text != "" && moveInput.text != "" && damageInput.text != "" && attackSpeedInput.text != "")
        {
            Debug.Log(hpInput.text);
            EnemyController clone = Instantiate(monsterFlower,new Vector2(monsters.transform.position.x,Random.Range(-3f,3f)),transform.rotation,monsters.transform).GetComponent<EnemyController>();
            clone.maxHealth = int.Parse(hpInput.text);
            clone.speed = int.Parse(moveInput.text);
            clone.damage = int.Parse(damageInput.text);
            clone.attackSpeed = int.Parse(attackSpeedInput.text);
            clone.attackDelay = clone.attackDelay / clone.attackSpeed;
            Debug.Log("Creator");
        }
            
    }
}
