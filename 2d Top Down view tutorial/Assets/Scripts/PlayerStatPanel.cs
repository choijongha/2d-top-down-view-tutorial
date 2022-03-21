using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatPanel : MonoBehaviour
{
    public GameObject playerPanel;
    public Movement playerScript;
    public TextMeshProUGUI Movetext;
    public TMP_InputField MoveInput;
    private void Awake()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
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
    public void ChangeValue()
    {
        Movetext.text = $"Move Speed: {MoveInput.text}";
        playerScript.speed = int.Parse(MoveInput.text);
    }
}