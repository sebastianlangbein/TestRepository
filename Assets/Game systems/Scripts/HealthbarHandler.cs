using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarHandler : MonoBehaviour
{
    //the maximum amount of health
    public float maxHealth;
    //the current amount of health
    public float currentHealth;
    //the gradient colour of our health bar
    public Gradient healthColour;
    //the reference to our health bar image
    public Image healthBar;
    //the reference to the canvas object
    public Transform canvas;
    //reference to the main camera
    public Camera cam;
    void Start()
    {
        cam = Camera.main;
        maxHealth = 100;
        currentHealth = maxHealth;
    }

    public void SetHealth()
    {
        //change how much the bar is filled based off how much health we have left
        healthBar.fillAmount = Mathf.Clamp01(currentHealth / maxHealth);
        //change the colour according to the amount of health left
        healthBar.color = healthColour.Evaluate(healthBar.fillAmount);
    }

    void Update()
    {
        SetHealth();
        canvas.LookAt(canvas.position + cam.transform.forward);
    }

}
