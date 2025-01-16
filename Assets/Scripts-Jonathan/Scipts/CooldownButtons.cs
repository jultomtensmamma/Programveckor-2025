using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CooldownButtons : MonoBehaviour
{
    public Button actionButton;       
    public TextMeshPro cooldownText;         
    public float cooldownTime = 5f;   

    private float cooldownTimer = 0f; 
    private bool isCooldown = false;  

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.E) && !isCooldown)
        {
            OnButtonPressed();
        }
         
        

        if (isCooldown)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0f)
            {
                ResetButton();
            }
            else
            {
                
                cooldownText.text = Mathf.Ceil(cooldownTimer).ToString() + "s";
            }
        }
    }

    void OnButtonPressed()
    {
        actionButton.interactable = false;
        isCooldown = true;
        cooldownTimer = cooldownTime;

        
        Debug.Log("Button action performed!");
    }

    void ResetButton()
    {
        
        isCooldown = false;
        actionButton.interactable = true;
        cooldownText.text = "Press E";
    }
}
