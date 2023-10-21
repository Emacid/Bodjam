using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public GameObject bubblePrefab;
    public CinemachineVirtualCamera vcCamera;
    public CinemachineRecomposer recomposer;
    
    void Start()
    {
        
        player.layer = 6;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
        }
    }
}

     