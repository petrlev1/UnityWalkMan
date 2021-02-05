using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvMain : MonoBehaviour
{
    
	public GameObject Player;
	public GameObject TextPlayerHit;
	public GameObject TextPlayerWins;
	public GameObject Enemy;
	//public int EnemyDistroyNum;
	
    void Start()
    {
		
		//TextPlayerHit.GetComponent<Text>().text = gameObject.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
		
		TextPlayerHit.GetComponent<Text>().text = "Жизни: " + Player.GetComponent<PlayerControl>().PlayerHitNum.ToString();
		TextPlayerWins.GetComponent<Text>().text = "Попаданий: " + Enemy.GetComponent<Enemy1>().EnemyDistroysNum.ToString();
		//Debug.Log ( Enemy.GetComponent<Enemy1>().EnemyDistroysNum );
        
    }
}
