using UnityEngine;

public class GridDraw : MonoBehaviour, ManagerOfCubes.IGrid {

    private GameObject gridParent;
    private GridInputs gridInputs;
    private int xDim;
    private int yDim;
    private bool hasParent = false; 
    
    void Start()
    {
        gridInputs = GameObject.Find("GridInputs").GetComponent<GridInputs>();
        
    }

    public void drawGrid()
    {
        xDim = int.Parse(gridInputs.x);
        yDim = int.Parse(gridInputs.y);

        if(gridParent != null)
        {
            DestroyImmediate(gridParent);
            gridParent = GameObject.Find("GridParent");
            draw();
        }
        else
        {
            gridParent = GameObject.Find("GridParent");
            draw();
        }        
    }
    
    private void draw()
    {
        for (int width = 0; width <= xDim + 1; width++)
        {
            for (int height = 0; height <= yDim + 1; height++)
            {
                if (width == 0 || width == yDim + 1)
                {
                    GameObject tmp = Instantiate(Resources.Load("Prefabs/BorderCube"),
                        new Vector3(width, height, 0), Quaternion.identity) as GameObject;
                    tmp.transform.SetParent(gridParent.transform);
                }
                else if (height == 0 || height == xDim + 1)
                {
                    GameObject tmp = Instantiate(Resources.Load("Prefabs/BorderCube"),
                        new Vector3(width, height, 0), Quaternion.identity) as GameObject;
                    tmp.transform.SetParent(gridParent.transform);
                }
                else
                {
                    GameObject tmp = Instantiate(Resources.Load("Prefabs/GridCube"),
                        new Vector3(width, height, 0), Quaternion.identity) as GameObject;
                    tmp.transform.SetParent(gridParent.transform);
                }
            }
        }
    } 
    
    public int getXDim()
    {
        return xDim;
    }
    
    public int getYDim()
    {
        return yDim;
    }  
}
