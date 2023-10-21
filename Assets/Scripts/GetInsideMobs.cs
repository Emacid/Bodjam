using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TarodevController;
using UnityEngine.UI;

public class GetInsideMobs : MonoBehaviour
{
    public GameObject player;
    private CharacterController2D characterController2D;
    public CinemachineVirtualCamera VirtualCamera;
    public PlayerController ghostController;
    private Animator animator;
    public TimerScript timerScript;
    public Text text;
    public ParticleSystem explodeParticle;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        characterController2D = GetComponent<CharacterController2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        Debug.Log("deneme");
        // CharacterController2D bile�enini etkinle�tir veya devre d��� b�rak
        timerScript.enabled = !timerScript.enabled;
        
        characterController2D.enabled = !characterController2D.enabled;
        VirtualCamera.Follow = this.transform;
        ghostController.enabled = false;
        StartCoroutine(GetBackToCharacter());

    }

    public IEnumerator GetBackToCharacter() 
    {
        yield return new WaitForSeconds(10);
        timerScript.enabled = !timerScript.enabled;
        text.text = "";
        VirtualCamera.Follow = player.transform;
        characterController2D.enabled = false;
        ghostController.enabled = true;
        explodeParticle.Play();
        spriteRenderer.enabled = false;
        StartCoroutine(DestroyDelayed());
        //Destroy(gameObject);

    }
    IEnumerator DestroyDelayed() 
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
    
}