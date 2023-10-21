using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Throwable : MonoBehaviour
{

    Vector3 throwVector;
    Rigidbody2D rb;
    LineRenderer lineRenderer;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();
        lineRenderer = this.GetComponent<LineRenderer>();
    }

    private void OnMouseDown()
    {
        CalculateThrowVector();
        SetArrow();
    }

    private void OnMouseDrag()
    {
        CalculateThrowVector();
        SetArrow();
    }

    void CalculateThrowVector() 
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 distance = mousePos - this.transform.position;

        throwVector = -distance.normalized*100;
    }

    void SetArrow() 
    {
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, Vector3.zero);
        lineRenderer.SetPosition(1, throwVector.normalized/2);
        lineRenderer.enabled = true;
    }

     void OnMouseUp()
    {
        RemoveArrow();
        Throw();
    }

    void RemoveArrow() 
    {
        lineRenderer.enabled = false;
    }

    public void Throw() 
    {
        rb.AddForce(throwVector);
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }


}
