using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicEnemy : MonoBehaviour
{
    public float HP = 50;
    public float maxHP = 50;
    public float xpDrop;
    public float strength = 1f;
    public float speed = 1f;
    public float level = 1f;
    public GameObject health;
    private Image bar;
    private Rigidbody2D rb;
    public GameObject player;
    public GameObject potion;
    private float timeUntilMelee;
    [SerializeField] private Animator anim;
    [SerializeField] private float meleeSpeed = 1f;

    private bool onFire;
    private bool frozen;


    // Start is called before the first frame update
    void Start()
    {
        //bar = health.GetComponent<Image>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //bar.fillAmount = HP / maxHP;
        if (timeUntilMelee <= 0f)
        {
            anim.SetTrigger("stab");
            timeUntilMelee = meleeSpeed;
        }
        else
        {
            timeUntilMelee -= Time.deltaTime;
        }
        if (HP <= 0)
        {
            die();
        }
    }
    private void FixedUpdate()
    {
        
    }

    private void die()
    {
        int prob = Random.Range(100, 0);
        if (prob <= 20)
        {
            Instantiate(potion, transform.position, Quaternion.identity);
        }
        Debug.Log(prob);
        Destroy(gameObject);
    }

    private void Rotate()
    {
        Vector2 playerPos = player.transform.position;
        Vector2 pos = transform.position;

        Vector2 distance = playerPos - pos;
        float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
        rb.MoveRotation(Quaternion.Euler(0f, 0f, angle));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.gameObject.GetComponent("Player") != null)
            {
                Player basic = collision.gameObject.GetComponent<Player>();
                basic.damage(20 + 20 * (strength - 1));
                Debug.Log("player hit");
            }
        }
    }
    public void damage(float val)
    {
        HP -= val;
    }
    public void setSpeed(float spd)
    {
        speed = spd;
    }
}
