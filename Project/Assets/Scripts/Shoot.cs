using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : MonoBehaviour
{

    AudioSource speaker;
    public AudioClip shootSound;
    public AudioClip reloadSound;
    Animator anim;
    float ammo = 2;
    public float speed;
    public GameObject crossArrow;
    MeshRenderer arrowInCross;                       //the arrow thats attached to the crossbow
    public GameObject fireArrow;                    //the arrow that fires
    Text ammoCount;
    public bool oneInChamber = true;                //if theres an arrow loaded and ready to fire
    bool reloading;                                 //if reloading then cant fire
    public bool dead;                               //if dead then cant fire



    private void Start()
    {
        speaker = GetComponent<AudioSource>();
        ammoCount = GameObject.FindGameObjectWithTag("AmmoText").GetComponent<Text>();
        anim = GetComponent<Animator>();
        arrowInCross = crossArrow.GetComponent<MeshRenderer>();
        ammoCount.text = "Bolts: 1/" + (ammo - 1);              //tell UI how many bolts you have
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
        ammoCount.text = "Bolts: 1/" + (ammo - 1);
    }

    public void ReloadSound()
    {
        speaker.volume = PlayerPrefs.GetFloat("EffectsVolume");
        speaker.PlayOneShot(reloadSound);

    }

    public void Fire(bool shoot)
    {
        if (shoot && oneInChamber && Time.timeScale !=0 && !dead)
        {
            speaker.volume = PlayerPrefs.GetFloat("EffectsVolume");
            speaker.PlayOneShot(shootSound);
            arrowInCross.enabled = false;
            GameObject shot = Instantiate(fireArrow, crossArrow.transform.position, crossArrow.transform.rotation);         //Instantiate arrow and propell it forward
            shot.GetComponent<Rigidbody>().AddForce(-crossArrow.transform.right * speed);
            shot.GetComponent<Rigidbody>().AddForce(transform.up * 20);
            oneInChamber = false;
            ammo--;
            ammoCount.text = "Bolts: 0/" + ammo;
        }

    }



    private void OnTriggerEnter(Collider collision)                         //if walk over an arrow, pick it up and add it to ammo count
    {
        if(collision.gameObject.tag == "Arrow" && collision.gameObject.GetComponent<ArrowKill>().canKill != true)
        {
            ammo++;
            if(oneInChamber)
            {
                ammoCount.text = "Bolts: 1/" + (ammo - 1);
            }
            else
            {
                ammoCount.text = "Bolts: 0/" + ammo;
            }
            Destroy(collision.gameObject);
        }
    }
}
