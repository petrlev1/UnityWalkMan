using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    
	public GameObject Enemy1Pula;
	public GameObject Aim;
	
	public float Count = 0.0f;
     public int FireTime;
	 
	 //public int enemyCount = 0;
	
    void Start()
    {
		
		StartCoroutine( EnemyAppearance() );
		
		//enemyCount = 0;
		
		if ( this.name == "Enemy1(Clone)" ) {
			
		this.transform.position = new Vector3( Random.Range( -15f, 15f), 0, Random.Range( -15f, 15f) );
		
		}
        
    }

    // Update is called once per frame
    void Update()
    {
		
		//ЛУЧ
	//сюда запишется инфо о пересечении луча, если оно будет
    RaycastHit hit;
    //сам луч, начинается от позиции этого объекта и направлен в сторону цели
    Ray ray = new Ray(Enemy1Pula.transform.position, Aim.transform.position - transform.position);
    //пускаем луч
    Physics.Raycast(ray, out hit);
	
	//просто для наглядности рисуем луч в окне Scene
	Debug.DrawLine(ray.origin, hit.point,Color.red);
	
	
		
		FireTime = (int)( (Count = Count + Time.deltaTime) % 3 );
		
		/* if ( EnemyAppearanceTime > 2 ) {
			
			if ( enemyCount < 1 ) {
			Instantiate(GameObject.Find("Enemy1"), this.transform.position, transform.rotation);
			}
			
			enemyCount++;
			
		} */
		
		//Aim.transform.position = new Vector3( Aim.transform.localPosition.x,  Random.Range( 0, 1f), Aim.transform.localPosition.z );
		
		//Debug.Log ( Aim.transform.localPosition.y - 3f );
		
		if ( FireTime > 1 ) {
			
		Vector3 FireSpace = new Vector3( Aim.transform.localPosition.x,  Random.Range( Aim.transform.localPosition.y - 3f, Aim.transform.localPosition.y + 3f), Aim.transform.localPosition.z );
		//Vector3 FireSpace = new Vector3( Random.Range( -0.1f, 0.1f),  Random.Range( -0.5f, 2.5f), Random.Range( -0.1f, 0.1f) );
		Enemy1Pula.transform.position = Vector3.MoveTowards( Enemy1Pula.transform.position, FireSpace, Time.deltaTime * 50 );
		
		if ( Enemy1Pula.transform.position == FireSpace ) {
			Count = 0.0f;
			Enemy1Pula.transform.localPosition = new Vector3( 0, 0, -1 );
			//StartCoroutine( EnemyFireTime() );
			//Debug.Log ( this.name );
		}
		
		}
		
		
	
		
		//Debug.Log ( this.name );
		
		if ( this.transform.position.y < -100 && this.name == "Enemy1(Clone)" ) {
			
			//Debug.Log ( "qq" );
			Destroy(gameObject);
			
		}
		
		
		//StartCoroutine( EnemyFireTime() );
		
		
        
    }
	
	private void OnCollisionEnter(Collision collname) {
		
		if ( collname.gameObject.name == "GunPula" ) {
			
		this.GetComponent<Rigidbody>().useGravity = true;
		
		}
		
	}
	
	
	/* IEnumerator EnemyFireTime()
    {
		yield return new WaitForSeconds(0.0f);
		
	} */
	
	
	IEnumerator EnemyAppearance()
    {
		yield return new WaitForSeconds(3.0f);
		Instantiate(GameObject.Find("Enemy1"), this.transform.position, transform.rotation);
	}
	
	
}
