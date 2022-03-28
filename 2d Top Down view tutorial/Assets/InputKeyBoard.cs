using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputKeyBoard : MonoBehaviour
{
    [SerializeField] Image aPanel; 
    [SerializeField] Image sPanel; 
    [SerializeField] Image wPanel; 
    [SerializeField] Image dPanel; 
    [SerializeField] Image spacePanel;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            aPanel.color = Color.black;
        }else if((Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow)))
        {
            aPanel.color = Color.white;
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            sPanel.color = Color.black;
        }
        else if ((Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)))
        {
            sPanel.color = Color.white;
        }
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            wPanel.color = Color.black;
        }
        else if ((Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow)))
        {
            wPanel.color = Color.white;
        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            sPanel.color = Color.black;
        }
        else if ((Input.GetKeyUp(KeyCode.S) || Input.GetKeyUp(KeyCode.DownArrow)))
        {
            sPanel.color = Color.white;
        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            dPanel.color = Color.black;
        }
        else if ((Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow)))
        {
            dPanel.color = Color.white;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spacePanel.color = Color.black;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            spacePanel.color = Color.white;
        }

    }
}
