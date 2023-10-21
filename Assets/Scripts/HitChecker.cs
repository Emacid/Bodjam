using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitChecker : MonoBehaviour
{
    public CharacterControllerForBrawler characterControllerForBrawler;
    private BoxCollider2D boxCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (characterControllerForBrawler.hitGroundCheck) 
        {
            boxCollider2D.enabled = true;
            Debug.Log("yok olmasý lazým");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Floor") || collision.gameObject.CompareTag("TvGuy"))
        {
            Destroy(collision.gameObject);
        }
    }


}
