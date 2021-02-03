using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
	
	//Animator m_Animator;
	//bool Walk;
    
	//public GameObject PlayerTargetObj;
	//public float movementSpeed = 5f;
	
    void Start()
    {
		
		//m_Animator = this.gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
 
		//Анимация
		if ( Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) )
        {
			this.GetComponent<Animator>().SetBool("Stay", false);
            this.GetComponent<Animator>().SetBool("Walk", true);
        } else {

            this.GetComponent<Animator>().SetBool("Stay", true);
			this.GetComponent<Animator>().SetBool("Walk", false);
        }
		
		
		//Поворот вместе с камерой
		//this.transform.rotation = Quaternion.Euler( transform.eulerAngles.x, PlayerTargetObj.transform.eulerAngles.y, transform.eulerAngles.z );
		
		//Debug.Log ( PlayerTargetObj.transform.rotation );
		//Debug.Log ( PlayerTargetObj.transform.eulerAngles.y );
        
    }
}
