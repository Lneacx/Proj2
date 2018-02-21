using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenuScript : MonoBehaviour {
    public GameObject EndGameUI;
    public GameObject Player1;
    public GameObject Player2;

    private void Start()
    {
        Player1 = GameObject.Find("Player1");
        Player2 = GameObject.Find("Player2");

    }

    // Update is called once per frame
    void Update () {
		if (Player1.GetComponent<Health>().HP == 0 || Player2.GetComponent<Health>().HP == 0)
        {
            EndGameUI.SetActive(true);
            Time.timeScale = 0f;
        }
	}

    public void returnMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
