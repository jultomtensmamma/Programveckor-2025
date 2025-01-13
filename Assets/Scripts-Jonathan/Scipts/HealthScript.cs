using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    public float health;
    public float maxhealth;
    public Image Healthbar;
    // Start is called before the first frame update
    void Start()
    {
        maxhealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        Healthbar.fillAmount = Mathf.Clamp(health / maxhealth, 0, 1);
    }
}
