using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    GenericCreature playerCreatureScript;
    Image healthImage;


    // Start is called before the first frame update
    void Start()
    {
        playerCreatureScript = GameController.gameController.player.GetComponent<GenericCreature>();
        healthImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        healthImage.fillAmount = playerCreatureScript.currentHealth / playerCreatureScript.maxHealth;
    }
}
