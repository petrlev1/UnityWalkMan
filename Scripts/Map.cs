using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    
	public GameObject Bridge;
	public GameObject Player;
	public Vector3 BridgePosition;
	bool GroundOn = true;
	
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
		
		
		if ( Input.GetKeyDown(KeyCode.Space) && GroundOn == true ) {
			
			//NewGrounPosition = new Vector3( Random.Range( -10f, 10f), 0.1f, Random.Range( -10f, 10f) );
			
			//Позиционирование моста
			BridgePosition = new Vector3( Player.transform.position.x, Bridge.transform.position.y, Player.transform.position.z );
			Instantiate(Bridge, BridgePosition, transform.rotation);
			
			//Позиционирование лестницы
			//Instantiate(Plane, Player.transform.position, transform.rotation);
			
			GroundOn = false;
			
		} else {
			GroundOn = true;
		}
		
		/* if ( Input.GetKeyUp(KeyCode.W) ) {
			GroundOn = true;
		} */
        
    }
}
