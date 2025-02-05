using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathscene : MonoBehaviour
{
    public int health = 100;

    void Update()
    {
        if (health <= 0)
        {
            TriggerGameOver();
        }
    }

    void TriggerGameOver()
    {
        SceneManager.LoadScene("DeathScene");
    }
}
