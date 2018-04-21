using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PoolInput()
    {
        if(Input.GetMouseButton(0))
        {
            RotateGrid();
        }
    }

    public void RotateGrid()
    {

    }
}
