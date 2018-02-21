using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour {
    GameObject Player;
    public float HP;
    public Slider healthSlider;
    private float DamageTaken;
    private bool takingDamage;
    public bool Blocking;
	// Use this for initialization
	void Start () {
        Player = gameObject.GetComponent<GameObject>();
        HP = 100.0f;
        takingDamage = false;
        Blocking = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (takingDamage)
        {
            if (Blocking)
            {
                DamageTaken = DamageTaken * 0.2f;
            }
            HP -= DamageTaken;
            takingDamage = false;
        }
		healthSlider.value = HP;
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        takingDamage = true;
        GameObject Enemy = collision.gameObject;
        if (Enemy.tag == "Fist")
        {
            DamageTaken = 10.0f;
        }
    }
}
