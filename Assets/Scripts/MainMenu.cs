using UnityEngine;

public class MainMenu : MonoBehaviour, ManagerOfCubes.IMenu {


    private float menuWidth;
    
	// Use this for initialization
	void Start () {
        menuWidth = gameObject.GetComponent<RectTransform>().anchorMax.x -
            gameObject.GetComponent<RectTransform>().anchorMin.x;       
	}

    public float getWidth()
    {
        return menuWidth;
    }
	
}
