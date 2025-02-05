using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For Image component

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject ballPrefab;
    [SerializeField]
    private float ballSpeed = 5;
    [SerializeField]
    private Image spImage; // Reference to the SP Image
    [SerializeField]
    private float maxSP = 100f; // Maximum SP
    [SerializeField]
    private float spUsagePerShot = 20f; // SP cost per shot
    [SerializeField]
    private float spRegenRate = 5f; // SP regeneration per second
    [SerializeField]
    private float regenDelay = 1f; // Delay before SP regeneration starts

    private float currentSP;
    private float timePassed;
    private bool canRegenerate = true; // Flag to allow regeneration

    AudioManager audioManager;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // Initialize SP to the maximum value
        currentSP = maxSP;
        UpdateSPImage();
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;

        // Shooting logic
        if (Input.GetMouseButton(1) && timePassed > 0.2f && currentSP >= spUsagePerShot)
        {
            Shoot();
        }

        // Regenerate SP over time
        if (canRegenerate && currentSP < maxSP)
        {
            currentSP += spRegenRate * Time.deltaTime;
            currentSP = Mathf.Clamp(currentSP, 0, maxSP); // Clamp SP within valid range
            UpdateSPImage();
        }
    }

    private void Shoot()
    {
        audioManager.PlaySFX(audioManager.iceball);
        GameObject ball = Instantiate(ballPrefab, transform.position + new Vector3(0.3f, 0f, 0f), transform.rotation);
        Rigidbody2D rigidbody = ball.GetComponent<Rigidbody2D>();
        rigidbody.velocity = ballSpeed * transform.right;

        // Deduct SP for the shot
        currentSP -= spUsagePerShot;
        UpdateSPImage();

        // Prevent regeneration temporarily
        canRegenerate = false;
        Invoke(nameof(EnableRegen), regenDelay);

        timePassed = 0; // Reset the cooldown timer
    }

    private void UpdateSPImage()
    {
        // Update the fill amount of the image based on current SP
        spImage.fillAmount = currentSP / maxSP;
    }

    private void EnableRegen()
    {
        canRegenerate = true; // Re-enable SP regeneration
    }
}