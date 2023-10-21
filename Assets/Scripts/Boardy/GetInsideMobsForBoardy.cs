using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TarodevController;
using UnityEngine.UI;

public class GetInsideMobsForBoardy : MonoBehaviour
{
    public GameObject player;
    private HoverboardController characterController2D;
    public CinemachineVirtualCamera VirtualCamera;
    public PlayerController ghostController;
    private Animator animator;
    public TimerScript timerScript;
    public Text text;
    public ParticleSystem explodeParticle;
    private SpriteRenderer spriteRenderer;
    public GameObject DroneCanvas;
    public GameObject dontGoDownBro;

    private void Awake()
    {
        characterController2D = GetComponent<HoverboardController>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        Debug.Log("deneme");
        dontGoDownBro.SetActive(true);
        // CharacterController2D bileþenini etkinleþtir veya devre dýþý býrak
        timerScript.enabled = !timerScript.enabled;
        DroneCanvas.SetActive(true);
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
        //explodeParticle.Play();
        //spriteRenderer.enabled = false;
        //StartCoroutine(DestroyDelayed());
        //Destroy(gameObject);

    }
    /*IEnumerator DestroyDelayed()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
    */
}
