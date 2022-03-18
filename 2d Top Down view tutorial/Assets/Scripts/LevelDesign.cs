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
    public int currentExp { get; set; }
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
    private void Update()
    {
        if(expToLevelUp[currentLevel -1] <= currentExp)
        {
            int initialExp = currentExp - expToLevelUp[currentLevel - 1];
            currentLevel++;
            Debug.Log("Level Up");
            text.text = "Level : " + currentLevel;
            currentExp = initialExp;
        }
    }
}
