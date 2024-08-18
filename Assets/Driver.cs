using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 165f;
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;    

    float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    void OnCollisionEnter2D(Collider2D other){
        if(other.tag == "Bump"){
            moveSpeed = slowSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Boost"){
            moveSpeed = boostSpeed;
        }

        
    }
}
