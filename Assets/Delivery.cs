using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] bool hasPackage = false;
    [SerializeField] float delay = 1f;
    [SerializeField] Color32 hasPackageColor = new Color32(77,233, 52, 255);
    [SerializeField] Color32 noPackageColor = new Color32(221, 52,233,255);
    [SerializeField] float slowSpeed = 20f;

    SpriteRenderer spriteRenderer;

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("Ayyy I'm drivin'ere!");    
    }

    private void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Package"){
            Debug.Log("Package picked up");
            if(!hasPackage){
                Destroy(other.gameObject, delay);
                hasPackage = true;
                spriteRenderer.color = hasPackageColor;
            }
            
        } 
        
        if(other.tag == "Customer" && hasPackage){
            Debug.Log("Package delivered");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
    
}
