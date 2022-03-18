using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LevelDesign : MonoBehaviour
{
    [SerializeField] int maxLevel;
    [SerializeField] int currentLevel;
    [SerializeField] int[] expToLevelUp;
    [SerializeField] int baseExp;
    [SerializeField] int currentExp;
    [SerializeField] TextMeshProUGUI text;
    private void Start()
    {
        text.text = "Level : " + currentLevel;
        expToLevelUp = new int[maxLevel];
        expToLevelUp[0] = baseExp;
        for(int i = 0; i<expToLevelUp.Length; i++)
        {
            if (i > 0)
            {
                expToLevelUp[i] = Mathf.FloorToInt(expToLevelUp[i - 1] * 1.05f);
            }
            
        }
    }
}
