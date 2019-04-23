using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{

    Animator anim;
    public float ammo = 0;
    public float speed;
    public GameObject crossArrow;
    MeshRenderer arrowInCross;
    public GameObject fireArrow;
    Text ammoCount;
    public bool oneInChamber = true;
    bool reloading;
    private void Start()
    {
        ammoCount = GameObject.FindGameObjectWithTag("AmmoText").GetComponent<Text>();
        anim = GetComponent<Animator>();
        arrowInCross = crossArrow.GetComponent<MeshRenderer>();
        ammoCount.text = "1/" + (ammo - 1);
    }


    private void Update()
    {
        if(!oneInChamber && ammo > 0 && !reloading)
        {
            anim.SetTrigger("Reload");
            reloading = true;
        }
    }

    public void ReloadFinished()
    {
        arrowInCross.enabled = true;
        oneInChamber = true;
        reloading = false;
        ammoCount.text = "1/" + (ammo - 1);
    }

    public void Fire(bool shoot)
    {
        if (shoot && oneInChamber)
        {
            arrowInCross.enabled = false;
            GameObject shot = Instantiate(fireArrow, crossArrow.transform.position, crossArrow.transform.rotation);
            shot.GetComponent<Rigidbody>().AddForce(-crossArrow.transform.right * speed);
            shot.GetComponent<Rigidbody>().AddForce(transform.up * 20);
            oneInChamber = false;
            ammo--;
            ammoCount.text = "0/" + ammo;
        }

    }



    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Arrow" && collision.gameObject.GetComponent<ArrowKill>().canKill != true)
        {
            ammo++;
            if(oneInChamber)
            {
                ammoCount.text = "1/" + (ammo - 1);
            }
            else
            {
                ammoCount.text = "0/" + ammo;
            }
            Destroy(collision.gameObject);
        }
    }
}
