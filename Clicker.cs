using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
{
    #region SigmaCriper
    public float count = 0;
    public float countTwix;
    public float cost = 250;
    public Text countText;
    public Text countTwText;
    public Text costText;
    #endregion

    void Start()
    {
        
    }

    void Awake()
    {
        LoadData();
        UpdateTextCount();
        UpdateTextCountTwix();
        UpdateTextCost();
    }

    #region Clicker
    public void Click()
    {
        count += countTwix;
        UpdateTextCount();
        SaveData();
    }

    public void ClickerTwix()
    {
        if (count >= cost)
        {
            count -= cost;
            cost += 250;
            countTwix += 10;
            UpdateTextCount();
            UpdateTextCountTwix();
            UpdateTextCost();
            SaveData();
        }
        if (countTwix == 6)
        {
            countTwix -= 1;
            UpdateTextCountTwix();
            SaveData();
        }
        
    }

    
    #endregion

    #region UI
    public void UpdateTextCount()
    {
        countText.text = count.ToString();
    }
    public void UpdateTextCountTwix() 
    {
        countTwText.text = countTwix.ToString();
    }
    public void UpdateTextCost()
    {
        costText.text = cost.ToString();
    }
    #endregion

    #region SaveLoad
    public void SaveData()
    {
        PlayerPrefs.SetFloat("count", count);
        PlayerPrefs.SetFloat("countTwix", countTwix);
        PlayerPrefs.SetFloat("cost", cost);
        PlayerPrefs.Save();
    }

    public void LoadData()
    {
        count = PlayerPrefs.GetFloat("count", 0);
        countTwix = PlayerPrefs.GetFloat("countTwix", 1);
        cost = PlayerPrefs.GetFloat("cost", 500);
    }
    #endregion
}
