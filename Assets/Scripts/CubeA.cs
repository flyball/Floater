using UnityEngine;
using System.Collections;

public class CubeA : MonoBehaviour {
    private bool isRun = false;	
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("b"))
        {
            startCube();
        }
    }

    private Vector2 RandDirection()
    {
        return new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
    }

    private IEnumerator startStop()
    {        
        while (isRun)
        {
            Vector2 tmp = RandDirection();
            transform.Translate(tmp[0], tmp[1], 0.0f);
            yield return new WaitForSeconds(.05f);
        }        
    }

    public void startCube()
    {
        if (!isRun)
        {
            isRun = true;
            StartCoroutine(startStop());
        }
        else
        {
            isRun = false;
        }
    }
}
