using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TarodevController;

public class GetInsideMobs : MonoBehaviour
{
    private CharacterController2D characterController2D;
    public CinemachineVirtualCamera VirtualCamera;
    public PlayerController ghostController;
    private Animator animator;

    private void Awake()
    {
        characterController2D = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        Debug.Log("deneme");
        // CharacterController2D bileþenini etkinleþtir veya devre dýþý býrak
        //StartCountDown();
        characterController2D.enabled = !characterController2D.enabled;
        VirtualCamera.Follow = this.transform;
        ghostController.enabled = false;

    }
}