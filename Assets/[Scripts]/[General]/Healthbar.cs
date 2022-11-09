using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image healthbar;

    private Health health;

    private void OnEnable()
    {
        health = new Health(100);
    }

    private void Update()
    {
        healthbar.fillAmount = health.GetHealthPercent();
    }
}
