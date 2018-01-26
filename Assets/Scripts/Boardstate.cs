using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Floater
{
	[CreateAssetMenu(fileName="DefaultNew", menuName = "Floater/Board", order = 1)]	
    public class Boardstate : ScriptableObject
    {
		public string BoardName = "";
		public int Width = 16;
		public int Height = 16;
		public Color BoardColor = Color.blue;





    }
}
