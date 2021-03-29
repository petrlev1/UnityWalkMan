using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour

{

    public bool Active;
    public GameObject Obj1;
    public GameObject Obj2;
    public GameObject Mesh;

    void Start()
    {

        StartCoroutine(EnemyAppearance());

        if (this.name == "Enemy1(Clone)")
        {

            this.transform.position = new Vector3(Random.Range(-15f, 15f), 3, Random.Range(-15f, 15f));

        }

    }

    // Update is called once per frame
    void Update()
    {

        //Преследование объекта
        if (Active == true) {

        transform.LookAt(Obj1.transform);
        transform.Translate(new Vector3(0, 0, 3 * Time.deltaTime));

        } else
        {
            this.transform.position += this.transform.TransformDirection(Vector3.back) * (15 * Time.deltaTime);
        }


        //Удаление объектов
        if (this.transform.position.y < -100 && this.name == "Enemy1(Clone)")
        {

            //Debug.Log ( "qq" );
            Destroy(gameObject);

        }




    }



    private void OnCollisionEnter(Collision collname)
    {

        if ( (collname.gameObject.name == "GunPula" || collname.gameObject.name == "GunPula(Clone)") && this.name == "Enemy1(Clone)")
        {

            Mesh.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            this.GetComponent<Rigidbody>().useGravity = true;
            Active = false;
            Obj2.GetComponent<Animator>().speed = 5;

        }

    }



    IEnumerator EnemyAppearance()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(GameObject.Find("Enemy1"), this.transform.position, transform.rotation);
    }

}
