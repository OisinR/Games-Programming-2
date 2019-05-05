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
    MeshRenderer arrowInCross;
    public GameObject fireArrow;
    Text ammoCount;
    public bool oneInChamber = true;
    bool reloading;
    public bool dead;
    private void Start()
    {
        speaker = GetComponent<AudioSource>();
        ammoCount = GameObject.FindGameObjectWithTag("AmmoText").GetComponent<Text>();
        anim = GetComponent<Animator>();
        arrowInCross = crossArrow.GetComponent<MeshRenderer>();
        ammoCount.text = "Bolts: 1/" + (ammo - 1);
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
            GameObject shot = Instantiate(fireArrow, crossArrow.transform.position, crossArrow.transform.rotation);
            shot.GetComponent<Rigidbody>().AddForce(-crossArrow.transform.right * speed);
            shot.GetComponent<Rigidbody>().AddForce(transform.up * 20);
            oneInChamber = false;
            ammo--;
            ammoCount.text = "Bolts: 0/" + ammo;
        }

    }



    private void OnTriggerEnter(Collider collision)
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
