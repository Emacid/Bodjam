using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        player.layer = 6;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
