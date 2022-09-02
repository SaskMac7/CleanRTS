using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldCounter : MonoBehaviour
{
    public Text textGold;
    public int GoldCount;

    void Start()
    {
        textGold = GameObject.Find("Gold").GetComponent<Text>();
    }

    private void Update()
    {
        if(MoveMob.AddOneGold == true)
        {
            AddOneGold();
        }
    }

    public void AddOneGold()
    {
        GoldCount = int.Parse(textGold.text);
        GoldCount += 1;
        textGold.text = GoldCount.ToString();
    }
}
