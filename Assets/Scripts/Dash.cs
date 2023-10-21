using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public GameObject player;
    public float dashDistance = 5f; // Dash mesafesi
    public float dashDuration = 0.2f; // Dash süresi
    private bool isDashing = false;
    private bool canDash = true;
    private float lastDashTime = -1f;
    private float dashCooldown = 2.0f; // Dash kullaným aralýðý
    private KeyCode dashKey = KeyCode.LeftShift;

    void Update()
    {
        if (canDash && ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && Input.GetKeyDown(dashKey)))
        {
            Vector3 dashDirection = Input.GetKey(KeyCode.A) ? Vector3.left : Vector3.right;
            StartCoroutine(PerformDash(dashDirection));
            canDash = false;
            lastDashTime = Time.time;
        }

        if (!canDash && Time.time - lastDashTime >= dashCooldown)
        {
            canDash = true;
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
        player.layer = 6;
    }
}