using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    
	public GameObject PlayerTargetObj;
	
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
		this.transform.rotation = Quaternion.Euler( transform.eulerAngles.x, PlayerTargetObj.transform.eulerAngles.y, transform.eulerAngles.z );
		
		//Debug.Log ( PlayerTargetObj.transform.rotation );
		//Debug.Log ( PlayerTargetObj.transform.eulerAngles.y );
        
    }
}
