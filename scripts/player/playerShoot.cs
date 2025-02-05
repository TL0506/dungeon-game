using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject ballPrefab;

    [SerializeField]
    private float ballSpeed;

    [SerializeField]
    private Transform ballOffset;

    [SerializeField]
    private float timeBetweenShots;

    private bool fireContinuously;
    private bool fireSingle;
    private float lastFireTime;

    void Update()
    {
        if (fireContinuously || fireSingle)
        {
            float timeSinceLastFire = Time.time - lastFireTime;

            if (timeSinceLastFire >= timeBetweenShots)
            {
                FireBall();

                lastFireTime = Time.time;
                fireSingle = false;
            }
        }
    }

    private void FireBall ()
    {
        GameObject ball = Instantiate(ballPrefab, ballOffset.position, transform.rotation);
        Rigidbody2D rigidbody = ball.GetComponent<Rigidbody2D>();

        rigidbody.velocity = ballSpeed * transform.up;
    }

    private void OnFire(InputValue inputValue)
    {
        fireContinuously = inputValue.isPressed;

        if (inputValue.isPressed)
        {
            fireSingle = true;
        }
    }
}
