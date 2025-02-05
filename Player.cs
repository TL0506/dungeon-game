using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float HP = 200f;
    public float maxHP = 200f;
    public float stamina = 50f;
    public float maxStamina = 50f;
    public float strength = 1f;
    public float speed = 1f;
    public float level = 1f;
    public float upgrade;
    private bool exhausted = false;
    public infoboxtext infoBox;

    public Movement move;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stamina <= maxStamina && exhausted == false)
        {
            stamina += 10 * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            infoBox.usePotion();
        }
        if (HP > maxHP) { HP = maxHP; }
    }
    public void damage(float dam)
    {
        infoBox.hp.GetComponent<hp>().ouchie(dam);
    }

    public void heal()
    {

    }
    public void setSpeed(float spd)
    {
        move.setMaxSpeed(spd + 5);
    }
}
