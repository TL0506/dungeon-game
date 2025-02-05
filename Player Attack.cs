using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private float meleeSpeed;
    private float timeUntilMelee;
    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeUntilMelee <= 0f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                audioManager.PlaySFX(audioManager.swordSwing);
                anim.SetTrigger("slash");
                timeUntilMelee = meleeSpeed;
            }
        } else
        {
            timeUntilMelee -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            BasicEnemy basic = collision.gameObject.GetComponent<BasicEnemy>();
            basic.damage(20 + 20 * (gameObject.GetComponent<Player>().strength - 1));
            Debug.Log("enemy hit");
        }
    }
}
