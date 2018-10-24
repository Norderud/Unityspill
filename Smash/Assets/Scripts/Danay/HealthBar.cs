using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    public CharacterSpawner chars;
    public Image p1health, p2health;

	// Update is called once per frame
	void Update () {
        p1health.fillAmount = (float) chars.p1.GetComponent<Stats>().health / 100;
        p2health.fillAmount = (float) chars.p2.GetComponent<Stats>().health / 100;
    }
}
