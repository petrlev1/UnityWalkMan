using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    
	public GameObject GunController;
	public GameObject GunBody;
	public GameObject GunAim;
	public GameObject PulaPos;
	public GameObject GunPula;
     public float speed;
	 public float FireDist = 400;
	 private bool Fire;
	 public bool FireAutomate = true;
	 //public float FireAutomateDist = 400f;
	
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
		//ЛУЧ
	//сюда запишется инфо о пересечении луча, если оно будет
    RaycastHit hit;
    //сам луч, начинается от позиции этого объекта и направлен в сторону цели
    Ray ray = new Ray(GunBody.transform.position, GunAim.transform.position - GunBody.transform.position);
    //пускаем луч
    Physics.Raycast(ray, out hit);
	//просто для наглядности рисуем луч в окне Scene
	if (hit.collider != null){
	Debug.DrawLine(ray.origin, hit.point,Color.red);
	}
	
	//GunPula.transform.localPosition  = new Vector3( 0, 0, 10 );
	
	//Debug.Log( (GunPula.transform.position - PulaTarget.position).sqrMagnitude );
	
	//this.transform.InverseTransformPoint(GunPula.transform.position);
	//GunPula.transform.LookAt( GunPula.transform.position + this.transform.up );
	
	GunPula.transform.rotation = GunController.transform.rotation;
	//GunPula.transform.position = GunController.transform.TransformDirection (Vector3.fwd);
	
	//Debug.Log ( GunPula.transform.rotation );
	
    float speed2 = speed * Time.deltaTime;
	
	//GunPula.transform.position = new Vector3( 0, 0, GunPula.transform.position.z + step );
	
	
	if ( Input.GetMouseButtonDown(0) || Input.GetKeyDown("e") ) {
		
		this.GetComponent<Gun>().Fire = true;
		//StartCoroutine(FireOff());
		
		//Instantiate(GameObject.Find("GunPula"), GunPula.transform.position, transform.rotation); //Гильзы
	
	}
	
	//Функция автомата
	if ( FireAutomate == true ) {
		
	FireAutomateFunc();
	
	}
	
	
	if ( this.GetComponent<Gun>().Fire == true && (this.transform.position - GunPula.transform.position).sqrMagnitude < FireDist ) {
		
		GunPula.transform.position += transform.TransformDirection (Vector3.fwd) * speed2;
		
		if ( (this.transform.position - GunPula.transform.position).sqrMagnitude > FireDist ) {
	
	    Instantiate(GameObject.Find("GunPula"), GunPula.transform.position, transform.rotation);
		this.GetComponent<Gun>().Fire = false;
	
	    }
	
	//GunPula.transform.position = Vector3.MoveTowards(GunPula.transform.position, GunAim.transform.position, step );
	//GunPula.transform.position = new Vector3( GunPula.transform.localPosition.x, 1, GunPula.transform.localPosition.z + step );
	//GunPula.transform.position += transform.TransformDirection (Vector3.fwd) * speed2;
	
	//Instantiate(GameObject.Find("GunPula"), GunPula.transform.position, transform.rotation); //След от пули
	
	//Debug.Log ( (this.transform.position - GunPula.transform.position).sqrMagnitude );
	
	
	}
	
	//GunPula.transform.position += transform.TransformDirection (Vector3.fwd) * speed2;
	
	
	
	//Debug.Log ("FireAutomate");

	else {
		
		GunPula.transform.position = PulaPos.transform.position;
		
	}
	
	
	
	foreach(GameObject Pules in GameObject.FindGameObjectsWithTag("GunPules"))
    {
    if( Pules.name == "GunPula(Clone)" )
    {
        Pules.GetComponent<Rigidbody>().useGravity = true;
    }
    }
	
        
    }
	
	
	void FireAutomateFunc() {
		
		if ( Input.GetMouseButton(0) || Input.GetKey("e") ) {
		
		this.GetComponent<Gun>().Fire = true;
		//StartCoroutine(FireAutomateOff());
	
	} else {
		this.GetComponent<Gun>().Fire = false;
	}
		
	}
	
	
	/* IEnumerator FireOff()
    {

        yield return new WaitForSeconds( FireDist );
		this.GetComponent<Gun>().Fire = false;
		//this.GetComponent<Gun>().FireAutomate = false;
		//Instantiate(GameObject.Find("GunPula"), GunPula.transform.position, transform.rotation);
		
		
		//GunPula.transform.localPosition = new Vector3( 0,0,0.476f );

    } */

	
}
