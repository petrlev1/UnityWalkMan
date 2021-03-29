using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityStandardAssets.Effects;

public class PlayerControl : MonoBehaviour
{

	//Animator m_Animator;
	//bool Walk;

	public GameObject Player;
	public int PlayerHitNum;
	public GameObject Object1;
	public float ClimbDist;
	Vector3 closestPoint;
	public GameObject Smoke;
	public GameObject SmokeFight;

	//ParticleSystem myParticleSystem;
	ParticleSystem.EmissionModule emissionModule;

	//public Vector3 location;

	//public GameObject PlayerHitText;
	//public float movementSpeed = 5f;
	//private ThirdPersonCharacter m_Character;
	//private Vector3 m_Move;
	//public CharacterController controller;

	/* public void OnDrawGizmos()
   {
	   //var collider = GetComponent<Collider>();

	   if (!this.GetComponent<Collider>())
	   {
		   return; // nothing to do without a collider
	   }

	   closestPoint = Object1.GetComponent<Collider>().ClosestPoint(this.transform.position);

	   Gizmos.DrawSphere(Object1.transform.position, 0.1f);
	   Gizmos.DrawWireSphere(closestPoint, 0.1f);
   } */

	private void Awake()
	{
		Smoke.SetActive(false);
		SmokeFight.SetActive(false);
	}

	void Start()
	{

		//controller = GetComponent<CharacterController>();
		//m_Character = GetComponent<ThirdPersonCharacter>();
		//m_Animator = this.gameObject.GetComponent<Animator>();

	}

	// Update is called once per frame
	void Update()
	{

		//Ближайшая точка на коллайдере
		closestPoint = Object1.GetComponent<Collider>().ClosestPoint(this.transform.position);


		//Анимация движений

		if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0)) 
		{
			Player.GetComponent<Animator>().SetBool("Fight", true);
			SmokeFight.SetActive(true);
		}
		else
		{
			Player.GetComponent<Animator>().SetBool("Fight", false);
			SmokeFight.SetActive(false);
		}

		if (Input.GetKey(KeyCode.Space) && (this.transform.position - closestPoint).sqrMagnitude < ClimbDist)
		{

			Player.GetComponent<Animator>().SetBool("Climb", true);
			Player.GetComponent<Animator>().SetBool("Stay", false);
			Player.GetComponent<Animator>().SetBool("Walk", false);
			Player.GetComponent<Animator>().SetBool("Jump", false);

			Smoke.SetActive(false);
			SmokeFight.SetActive(false);

		}
		else if (Input.GetKey(KeyCode.Space))
		{

			Player.GetComponent<Animator>().SetBool("Jump", true);
			Player.GetComponent<Animator>().SetBool("Stay", false);
			Player.GetComponent<Animator>().SetBool("Walk", false);
			Player.GetComponent<Animator>().SetBool("Climb", false);

		}
		else if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))

		{
			Player.GetComponent<Animator>().SetBool("Walk", true);
			Player.GetComponent<Animator>().SetBool("Stay", false);
			Player.GetComponent<Animator>().SetBool("Climb", false);
			Player.GetComponent<Animator>().SetBool("Jump", false);

			Smoke.SetActive(true);
			//Smoke.GetComponent<ParticleSystem>().emission;
			//myParticleSystem = Smoke.GetComponent<ParticleSystem>();
			//Smoke.GetComponent<ParticleSystem>().emission.rate;

		}
		else
		{

			Player.GetComponent<Animator>().SetBool("Stay", true);
			Player.GetComponent<Animator>().SetBool("Walk", false);
			Player.GetComponent<Animator>().SetBool("Climb", false);
			Player.GetComponent<Animator>().SetBool("Jump", false);

			Smoke.SetActive(false);

		}

		/* if ( Input.GetKey(KeyCode.E) )
        {
            Player.GetComponent<Animator>().SetBool("Climb", true);
        } else {

            Player.GetComponent<Animator>().SetBool("Climb", false);
        } */



		//Поворот вместе с камерой
		//this.transform.rotation = Quaternion.Euler( transform.eulerAngles.x, PlayerTargetObj.transform.eulerAngles.y, transform.eulerAngles.z );

		//Debug.Log ( PlayerTargetObj.transform.rotation );
		//Debug.Log ( PlayerTargetObj.transform.eulerAngles.y );

		//m_Move = new Vector3( 0,0,0 );
		//m_Character.Move (m_Move, false, false);
		//m_Character.enabled = false;

		//Object1.ClosestPoint(this);





		//Способность вскарабкиваться на объект

		if (Input.GetKey(KeyCode.Space) && (this.transform.position - closestPoint).sqrMagnitude < ClimbDist)
		{
			this.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
			this.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
			this.GetComponent<Rigidbody>().useGravity = false;
			this.transform.position += this.transform.TransformDirection(Vector3.up) * (2f * Time.deltaTime);
		}
		else
		{
			this.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = true;
			this.GetComponent<UnityStandardAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = true;
			this.GetComponent<Rigidbody>().useGravity = true;
		}






	}

	private void OnCollisionEnter(Collision collname)
	{

		PlayerHitNum = PlayerHitNum + 1;

	}

	private void OnTriggerEnter(Collider collname)
	{

		if (collname.gameObject.name == "WaterProDaytime")
		{
			emissionModule = Smoke.GetComponent<ParticleSystem>().emission;
			emissionModule.rate = 120.0f;
		}

	}

	void OnTriggerExit(Collider collname)
	{

		if (collname.gameObject.name == "WaterProDaytime")
		{
			emissionModule = Smoke.GetComponent<ParticleSystem>().emission;
			emissionModule.rate = 20.0f;
		}
	}

}
