using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Image healthbar;

    private Health health;

    private void OnEnable()
    {
        health = new Health(100);
    }

    public void ChangeHealth(float damage)
    {
        health.ChangeHealth(-damage);
    }

    private void Update()
    {
        healthbar.fillAmount = health.GetHealthPercent();
        if (gameObject.name.Equals("Player") && health.GetIsDead()) SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
