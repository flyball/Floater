using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GridInputs : MonoBehaviour {

    private InputField xText;
    private InputField yText;
    private string xSize;
    private string ySize;

    public string x
    {
        get
        {
            return this.xSize;
        }
        set
        {
            xSize = value;
        }
    }

    public string y
    {
        get
        {
            return this.ySize;
        }
        set
        {
            ySize = value;
        }
    }



    // Use this for initialization
    void Start () {
        xText = GameObject.Find("XInput").GetComponent<InputField>();
        yText = GameObject.Find("YInput").GetComponent<InputField>();
    }

    public void GetXandY()
    {
        x = xText.text;
        y = yText.text;        
    }
}
