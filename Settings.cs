using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] Slider speed;
    [SerializeField] Slider jump;
    [SerializeField] Slider maxHP;
    [SerializeField] Player circle;
    [SerializeField] hp health;
    public GameObject s, j, hp;
    private TMPro.TMP_Text stext, jtext, hptext;
    public bool open = false;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(open);
        speed.value = circle.speed;
        maxHP.value = health.maxHealth;

        stext = s.GetComponent<TMPro.TMP_Text>();
        jtext = j.GetComponent<TMPro.TMP_Text>();
        hptext = hp.GetComponent<TMPro.TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {

        circle.setSpeed(speed.value);
        health.setMaxHealth(maxHP.value);

        stext.text = "Speed: " + speed.value;
        jtext.text = "Jump: " + jump.value;
        hptext.text = "Health: " + maxHP.value;
    }

    public void openOrClose()
    {
        if (open == false)
        {
            open = true;
        } 
        else 
        {
            open = false; 
        }
        gameObject.SetActive(open);
    }

}
