using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowMoney : MonoBehaviour
{
    Text moneyNum;

    void Start()
    {
        moneyNum = GetComponent<Text>();
    }

    void Update()
    {
        moneyNum.text = GameManager.manager.money.ToString();
    }
}
