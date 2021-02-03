using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    
	//public GameObject GunPulaController;
	//public GameObject GunBody;
	//public GameObject GunAim;
	public GameObject GunPula;
	private GameObject GunPulaClone;
     public float PulaSpeed;
	 public float FireDist = 400;
	 public bool Fire;
	 public bool AutomateMode = true;
	 public bool PaintballMode = true;
	 
	 public GameObject GunGilza;
	 //public GameObject GunGilzaPos;
	 public bool GunGilziMode = true;
	 //public float AutomateModeDist = 400f;
	 
	 AudioSource shot;
	
    void Start()
    {
		
		shot = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    { 
	
	
	if ( Input.GetMouseButtonDown(0) || Input.GetKeyDown("e") ) {
		
		this.GetComponent<Gun>().Fire = true;
		
		shot.Play();
		
		//StartCoroutine(FireOff());
		
		//Instantiate(GameObject.Find("GunPula"), GunPula.transform.position, transform.rotation); //Гильзы
	
	}
	
	if ( Input.GetMouseButtonUp(0) ) {
		
		shot.Stop();
		
	}
	
	//Функция автомата
	if ( AutomateMode == true ) {
		
	if ( Input.GetMouseButton(0) || Input.GetKey("e") ) {
		
		this.GetComponent<Gun>().Fire = true;
	
	} else {
		//this.GetComponent<Gun>().Fire = false;
	}
	
	}
	
	
	if ( this.GetComponent<Gun>().Fire == true && (this.transform.position - GunPula.transform.position).sqrMagnitude < FireDist ) {
		
		GunPula.transform.position += transform.TransformDirection (Vector3.fwd) * (PulaSpeed * Time.deltaTime);
		
		if ( (this.transform.position - GunPula.transform.position).sqrMagnitude > FireDist ) {
	
	    //Пейнтбол режим
		if ( this.GetComponent<Gun>().PaintballMode == true ) {
		Instantiate(GameObject.Find("GunPula"), GunPula.transform.position, transform.rotation);
		}
		
		this.GetComponent<Gun>().Fire = false;
		
		//Гильзы
		if ( this.GetComponent<Gun>().GunGilziMode == true ) {
		//GunGilza.transform.position += transform.TransformDirection (Vector3.right) * (PulaSpeed * Time.deltaTime);
		Instantiate(GameObject.Find("GunGilza"), this.transform.position, transform.rotation);
		}
	
	    }
		
	
	//Debug.Log ( (this.transform.position - GunPula.transform.position).sqrMagnitude );
	
	} else {
		
		//GunPula.transform.position = PulaPos.transform.position;
		GunPula.transform.localPosition = new Vector3( 0, 0, 0.5f );
		GunGilza.transform.localPosition = new Vector3( 0,0,0 );
		
	}
	
	
	
	foreach(GameObject Pules in GameObject.FindGameObjectsWithTag("GunPules"))
	
    {
		
    if( Pules.name == "GunPula(Clone)" || Pules.name == "GunGilza(Clone)" )
    {
		
        Pules.GetComponent<Rigidbody>().useGravity = true;
		Pules.GetComponent<SphereCollider>().enabled = true;
		
		if ( Pules.transform.position.y < -5f ) {
			Destroy(Pules.gameObject);
		}
		
    }
		
    }
	
	
        
    }
	
	
	
	
	
	/* IEnumerator FireOff()
    {

        yield return new WaitForSeconds( FireDist );
		this.GetComponent<Gun>().Fire = false;
		//this.GetComponent<Gun>().AutomateMode = false;
		//Instantiate(GameObject.Find("GunPula"), GunPula.transform.position, transform.rotation);
		
		
		//GunPula.transform.localPosition = new Vector3( 0,0,0.476f );

    } */

	
}
