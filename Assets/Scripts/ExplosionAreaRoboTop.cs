using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExplosionAreaRoboTop : MonoBehaviour
{
    public ElectricArea electricArea;
    public ParticleSystem explosionParticle;
    public Text text;
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
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("TvGuy"))
        {
            explosionParticle.Play();
            Destroy(collision.gameObject, 0.9f);
        }


        else if (collision.gameObject.CompareTag("Player")) 
        {
            StartCoroutine(electricArea.GameOver());
        }
    }




}
