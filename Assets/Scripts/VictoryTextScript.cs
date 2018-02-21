using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryTextScript : MonoBehaviour {
    public Text VictoryText;
    public GameObject Player1;
    public GameObject Player2;

    void Start()
    {
        Player1 = GameObject.Find("Player1");
        Player2 = GameObject.Find("Player2");
    }
    void Update()
    {
        if (Player1.GetComponent<Health>().HP <= 0)
        {
            VictoryText.text = "Player2 Won!";
        } else if (Player2.GetComponent<Health>().HP <= 0)
        {
            VictoryText.text = "Player1 Won!";
        } else
        {
            VictoryText.text = "Draw!";
        }

    }
}
