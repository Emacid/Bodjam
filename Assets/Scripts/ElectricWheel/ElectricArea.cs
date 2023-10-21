using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ElectricArea : MonoBehaviour
{

    public GameObject deathAnim;
    public Animator animator;
    public Animation finishAnim;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            deathAnim.SetActive(true);
            StartCoroutine(GameOver());
        }
    }

     IEnumerator GameOver() 
    {
        Debug.Log("GameOver Çalýþtý!");
        animator.Play("FadeOut");
        yield return new WaitForSeconds(1.3f);
        SceneManager.LoadScene("SampleScene");

    }

}
