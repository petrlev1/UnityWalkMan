using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Functions : MonoBehaviour
{
    
	public float timer = 0.0f;
     public int seconds;
     public bool keepTiming = true;
	 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
		//Timer();
        
    }
	
	
	public void Timer()
     {
         // seconds
         timer += Time.deltaTime;
         // turn float seonds to int
         seconds = (int)(timer % 60);
         Debug.Log ( seconds );
     }
 
     public void ResetTimer()
     {
         // seconds
         timer += Time.deltaTime;
         // turn float seonds to int
         seconds = (int)(timer % 60);
         //print(seconds);
 timer = 0.0f;
     }
 
     public void StopTimer()
     {
         if (keepTiming)
         {
             // seconds
             timer += Time.deltaTime;
             // turn float seonds to int
             seconds = (int)(timer % 60);
             print(seconds);
         }
 
         if (seconds > 4)
         {
             // stop and record time
             keepTiming = false;
             print(seconds);
         }
		 
	 }
	 
}
