using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class GunLesson : MonoBehaviour
{
    public GameObject GunPula;
    public float PulaSpeed = 200;
    public float FireDist = 400;
    public bool Fire;
    public bool AutomateMode = true;
    public bool PaintballMode = true;
    public GameObject GunGilza;
    public bool GunGilziMode = true;

    AudioSource shot;

    void Start()
    {

        shot = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        if ( Input.GetMouseButtonDown(0) || Input.GetKeyDown("e") )
        {

            this.GetComponent<GunLesson>().Fire = true;

            shot.Play();

        }

        if (Input.GetMouseButtonUp(0) )
        {
            shot.Stop();
        }

        if (this.GetComponent<GunLesson>().Fire == true && (this.transform.position - GunPula.transform.position).sqrMagnitude < FireDist)

        {

            GunPula.transform.position += transform.TransformDirection(Vector3.fwd) * (PulaSpeed * Time.deltaTime);

            if ( (this.transform.position - GunPula.transform.position).sqrMagnitude > FireDist )
            {
                this.GetComponent<GunLesson>().Fire = false;

                //Режим пэйнтбол
                if ( this.GetComponent<GunLesson>().PaintballMode == true )
                {
                    Instantiate(GameObject.Find("GunPula"), GunPula.transform.position, transform.rotation);
                }


                //Гильзы
                if ( this.GetComponent<GunLesson>().GunGilziMode == true )
                {
                    Instantiate(GameObject.Find("GunGilza"), this.transform.position, transform.rotation);
                }


            }

        } else {

            GunPula.transform.localPosition = new Vector3(0, 0.042f, 0.684f);
            GunGilza.transform.localPosition = new Vector3(0, 0, 0);

        }


        //Режим автомата
        if ( AutomateMode == true )
        {
            if ( Input.GetMouseButton(0) || Input.GetKey("e") )
            {
                this.GetComponent<GunLesson>().Fire = true;
            } else
            {
                this.GetComponent<GunLesson>().Fire = false;
            }
        }



        foreach ( GameObject Pules in GameObject.FindGameObjectsWithTag("GunPules") )
        {
            if ( Pules.name == "GunPula(Clone)" || Pules.name == "GunGilza(Clone)" )
            {
                Pules.GetComponent<Rigidbody>().useGravity = true;
                Pules.GetComponent<SphereCollider>().enabled = true;
            }
        }


    }
}
