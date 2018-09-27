using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core.Utilities;
using TowerDefense.Towers.Placement;


public class TowerPlacement : MonoBehaviour {
    public LayerMask hitLayers;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnDrawGizmos()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(camRay.origin, camRay.origin + camRay.direction * 100f);
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        { 
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        
        if (Physics.Raycast(camRay,out hit, 1000f, hitLayers))
        {
            // check if hitting grid
            IPlacementArea placement = hit.collider.GetComponent<IPlacementArea>();
            if(placement != null)
            {
                //Snap position tower to grid element
                transform.position = placement.Snap(hit.point, new IntVector2(1, 1));
            }
        }
        }
    }
}
