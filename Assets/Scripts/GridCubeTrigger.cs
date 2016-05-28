using UnityEngine;
using System.Collections;

public class GridCubeTrigger : MonoBehaviour {
    
    
    void OnTriggerExit(Collider other)
    {
        Renderer rend =  gameObject.GetComponent<Renderer>();
        rend.materials[0].color = new Color(Random.Range(0.0f, 1.01f), Random.Range(0.0f, 1.01f),
            Random.Range(0.0f, 1.01f), 1.0f);       
        
    } 
}
