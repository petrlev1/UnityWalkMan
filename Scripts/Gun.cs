using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    
	//public GameObject GunPulaController;
	//public GameObject GunBody;
	//public GameObject GunAim;
	//public GameObject GunPula;
	public GameObject GunPula2;
	private GameObject GunPulaClone;
	public GameObject TargObj;
	public GameObject TargObj2;
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
	
	
	if ( Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.E) ) {
		
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
		
	if ( Input.GetMouseButton(0) ) {
		
		this.GetComponent<Gun>().Fire = true;
	
	} else {
		//this.GetComponent<Gun>().Fire = false;
	}
	
	}
	
	
	if ( this.GetComponent<Gun>().Fire == true && (this.transform.position - GunPula2.transform.position).sqrMagnitude < FireDist ) {
		
		//GunPula.transform.position += GunPula.transform.TransformDirection (Vector3.fwd) * (PulaSpeed * Time.deltaTime);
		GunPula2.transform.position += GunPula2.transform.TransformDirection (Vector3.fwd) * (PulaSpeed * Time.deltaTime);
		GunPula2.GetComponent<CapsuleCollider>().enabled = true;
		GunPula2.transform.rotation = Quaternion.Euler( TargObj2.transform.eulerAngles.x, TargObj.transform.eulerAngles.y, 100 );

		//GunPula2.GetComponent<Light>().enabled = true;

			/* if ( (this.transform.position - GunPula2.transform.position).sqrMagnitude > FireDist ) {

			//Пейнтбол режим
			if ( this.GetComponent<Gun>().PaintballMode == true ) {
			Instantiate(GameObject.Find("GunPula"), GunPula.transform.position, transform.rotation);
			}


			//Гильзы
			if ( this.GetComponent<Gun>().GunGilziMode == true ) {
			GunGilza.transform.position += transform.TransformDirection (Vector3.right) * (PulaSpeed * Time.deltaTime);
			Instantiate(GameObject.Find("GunGilza"), this.transform.position, transform.rotation);
			}

			} */

			//Debug.Log ( (this.transform.position - GunPula.transform.position).sqrMagnitude );

		} else {
		
		//GunPula.transform.position = PulaPos.transform.position;
		//GunPula.transform.localPosition = new Vector3( 0, 0, 2f );
		this.GetComponent<Gun>().Fire = false;
		GunGilza.transform.localPosition = new Vector3( 0,0,0 );
		GunPula2.transform.position = this.transform.position;
		//GunPula2.transform.rotation = Quaternion.Euler( TargObj2.transform.eulerAngles.x, TargObj.transform.eulerAngles.y, transform.eulerAngles.z );
		GunPula2.transform.rotation = Quaternion.Euler( TargObj2.transform.eulerAngles.x, TargObj.transform.eulerAngles.y, 180 );
		GunPula2.GetComponent<CapsuleCollider>().enabled = false;
			//GunPula2.GetComponent<Light>().enabled = false;

		}
	
	
	/* foreach(GameObject Pules in GameObject.FindGameObjectsWithTag("GunPules")) {
		
    if( Pules.name == "GunPula(Clone)" || Pules.name == "GunGilza(Clone)" )
    {
		
        Pules.GetComponent<Rigidbody>().useGravity = true;
		Pules.GetComponent<SphereCollider>().enabled = true;
		
		if ( Pules.transform.position.y < -5f ) {
			Destroy(Pules.gameObject);
		}
		
    }
		
    } */
	
	
        
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
