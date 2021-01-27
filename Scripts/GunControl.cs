using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
	
    public GameObject GunTarg1;
	
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
		
		//Debug.Log ( "Gun: " + this.transform.rotation.x );
		
		this.transform.rotation = Quaternion.Euler( GunTarg1.transform.localRotation.x * 100, transform.eulerAngles.y, transform.eulerAngles.z );
		
		//this.transform.rotation = Quaternion.Euler(GunTarg1.transform.rotation.x * 100, this.transform.rotation.y, 0);
		//this.transform.rotation.x = Quaternion.Euler(GunTarg1.transform.rotation.x);
		
		//this.transform.rotation.x = TargetObj.transform.rotation.x;
		
		//TargetObj.transform.localRotation;
        
    }
}
