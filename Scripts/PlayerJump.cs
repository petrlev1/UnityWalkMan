using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
   
   //public Vector3 jump;
         public int jumpForce = 200;
     
         private bool isGrounded;
         Rigidbody rb;
		 
         void Start(){
             rb = GetComponent<Rigidbody>();
             //jump = new Vector3(0.0f, 2.0f, 0.0f);
         }
     
         void OnCollisionEnter()
         {
             isGrounded = true;
         }
     
         void Update(){
             if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
     
                 //rb.AddForce(jump * jumpForce, ForceMode.Impulse);
				 rb.AddForce(Vector3.up * jumpForce);
                 isGrounded = false;
             }
         }
		 
		 public void Jump() {
			 if(isGrounded){
			 rb.AddForce(Vector3.up * jumpForce);
			 isGrounded = false;
			 }
		 }
    
}
