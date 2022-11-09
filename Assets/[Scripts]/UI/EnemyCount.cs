using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private List<GameObject> enemies;

    // Start is called before the first frame update
    void Start()
    {
        enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
    }

    // Update is called once per frame
    void Update()
    {
        int enemyCount = enemies.Count;

        foreach (GameObject enemy in enemies)
        {
            if (enemy.GetComponent<EnemyBehaviour>().GetIsDead())
            {
                enemyCount--;
                enemies.Remove(enemy);
                break;
            }
        }

        text.text = $"Enemies: {enemyCount}";
    }
}
