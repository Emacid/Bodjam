using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CapsuleCollider2D))]

public class HoverboardController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public Camera mainCamera;
    private Animator animator;
    

    private Rigidbody2D rb;
    private CapsuleCollider2D mainCollider;
    private Transform t;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        t = transform;
        rb = GetComponent<Rigidbody2D>();
        mainCollider = GetComponent<CapsuleCollider2D>();
        rb.freezeRotation = true;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        if (mainCamera)
        {
            mainCamera.transform.position = new Vector3(t.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z);
        }
    }

    void Update()
    {
        // Hareket kontrolleri
        float moveDirectionX = Input.GetAxis("Horizontal");
        float moveDirectionY = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveDirectionX, moveDirectionY) * moveSpeed;
        rb.velocity = movement;

        // Kamerayý takip et
        if (mainCamera)
        {
            mainCamera.transform.position = new Vector3(t.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z);
        }
    }
}