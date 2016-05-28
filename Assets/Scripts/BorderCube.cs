using UnityEngine;
using System.Collections;

public class BorderCube : MonoBehaviour {
    private GridDraw bounds;
    private bool isBusy = false;
    

    void OnTriggerEnter(Collider other)
    {
        bounds = GameObject.Find("GridDraw").GetComponent<GridDraw>();
        //Destroy(other.gameObject);
        StartCoroutine(respawnCube(other));
    }  
    
    private IEnumerator respawnCube(Collider other)
    {
        yield return new WaitForSeconds(.02f);
        Vector3 position = new Vector3(Random.Range(1, bounds.getXDim()), Random.Range(1, bounds.getYDim()), -0.5f);
        other.gameObject.transform.position = position;
    }  
	
}
