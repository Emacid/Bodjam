using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public GameObject player;
    public float dashDistance = 5f; // Dash mesafesi
    public float dashDuration = 0.2f; // Dash süresi
    private bool isDashing = false;
    private int dashCount = 0;
    private float lastDashTime = -1f;
    private float doubleTapTimeThreshold = 0.5f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        {
            float currentTime = Time.time;
            if (currentTime - lastDashTime <= doubleTapTimeThreshold)
            {
                if (dashCount < 2)
                {
                    Vector3 dashDirection = Input.GetKeyDown(KeyCode.D) ? Vector3.right : Vector3.left;
                    StartCoroutine(PerformDash(dashDirection));
                    dashCount++;
                }
            }
            else
            {
                lastDashTime = currentTime;
                dashCount = 1;
            }
        }
    }

    IEnumerator PerformDash(Vector3 direction)
    {
        isDashing = true;
        float originalX = player.transform.position.x;
        float endX = originalX + dashDistance * direction.x;
        float startTime = Time.time;
        player.layer = 7;

        while (Time.time < startTime + dashDuration)
        {
            float t = (Time.time - startTime) / dashDuration;
            player.transform.position = new Vector3(Mathf.Lerp(originalX, endX, t), player.transform.position.y, player.transform.position.z);
            yield return null;
        }

        isDashing = false;
        StartCoroutine(waitAndSetLayer());
    }

    IEnumerator waitAndSetLayer()
    {
        yield return new WaitForSeconds(.5f);
        player.layer = 6;
    }
}