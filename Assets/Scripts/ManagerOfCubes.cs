using UnityEngine;
using System.Collections;

using Floater;

public class ManagerOfCubes : MonoBehaviour {
    private IGrid draw;
    private IMenu menu;    
    
    private bool placing = false;    
    private Camera mainCam;
    private GameObject[] cubes;
    private GameObject moverParent;

	// Use this for initialization
	void Start () {        
        draw = GameObject.Find("GridDraw").GetComponent<IGrid>();
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        menu = GameObject.Find("Menu").GetComponent<IMenu>();        
	}

    void Update()
    {       
            

    }
    
    private IEnumerator instantiateCubes(int xRange, int yRange)
    {
        yield return new WaitForSeconds(1.0f);
        if(moverParent != null)
        {
            DestroyImmediate(moverParent);
        }

        moverParent = Instantiate(Resources.Load("Prefabs/MoverParent")) as GameObject;

        Vector3 position = new Vector3(Random.Range(1, xRange), Random.Range(1, yRange), -0.5f);
        GameObject mover1 = Instantiate(Resources.Load("Prefabs/A"), position, Quaternion.identity) as GameObject;
        mover1.transform.SetParent(moverParent.transform);

        Vector3 position2 = new Vector3(Random.Range(1, xRange), Random.Range(1, yRange), -0.5f);
        GameObject mover2 = Instantiate(Resources.Load("Prefabs/A"), position2, Quaternion.identity) as GameObject;
        mover2.transform.SetParent(moverParent.transform);

        placing = false;

    }    

    private IEnumerator zoomCamera(int xRange, int yRange)
    {
        //Get Camera FOV in radians
        float fov = (mainCam.fieldOfView/2.0f) * (Mathf.PI/180.0f);
        //get "opposite" for trig 
        float opposite = xRange / 2.0f;
        //calculate h, how far away the camera needs to be
        float h = -1.75f * (opposite / Mathf.Sin(fov));
        //move camera x and y
        mainCam.transform.position = new Vector3(2.5f * menu.getWidth() * opposite, yRange/2.0f);

        while (mainCam.transform.position.z > h)
        {
            mainCam.transform.Translate(new Vector3(0,0,-1.0f) * .5f);
            yield return null;
        }
        
    }
    
    public interface IGrid
    {        
        void drawGrid();
        int getXDim();
        int getYDim();
    }

    public interface IMenu
    {
        float getWidth();

    }    
    
    public void Draw()
    {
        draw.drawGrid();
    }

    public void placeCubes()
    {
        if (!placing)
        {
            StartCoroutine(instantiateCubes(draw.getXDim(), draw.getYDim()));
            placing = true;
        }        
    }

    public void placeCamera()
    {
        StartCoroutine(zoomCamera(draw.getXDim(), draw.getYDim()));
    }    
}
