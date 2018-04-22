using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private GameManager gameManager;

	// Use this for initialization
	void Start () {

        gameManager = GameManager.Instance;
	}
	
	// Update is called once per frame
	void Update () {
        PoolInput();
	}

    public void PoolInput()
    {
        if(Input.GetMouseButton(0))
        {
            gameManager.PlaceBuilding();
        }
        if(Input.GetMouseButton(0))
        {
            RotateGrid(Input.GetAxis("Mouse X"));
        }
    }

    public void RotateGrid(float mouseX)
    { 
        gameManager.gridController.Rotate(mouseX);
        gameManager.athManager.UpdateRotation();
    }
}
