using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bala : MonoBehaviour
{
    public int Anmo;
    public float timeToReload;
    public Rigidbody Shell;
    public Transform FireStart;
    private Transform nCanon;
    private bool Reload = false;
     public Animator anim;
    

    void Start()
    {
        nCanon = FireStart.parent;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            StartCoroutine(Reloading());
        }
        if (Input.GetButtonDown("Fire1") && Anmo > 0 && !Reload)
        {
            Shoot();
            StartCoroutine(Smallreloading());
            if (Anmo == 0)
            {
                StartCoroutine(Reloading());
            }
        }
    }
    public void Shoot()
    {
        anim.SetBool("Throw",true);
        Instantiate(Shell, FireStart.position, nCanon.rotation);
        Anmo--;
    }
    private IEnumerator Reloading()
    {
        yield return new WaitForSeconds(timeToReload);
        Anmo = 5;
        Debug.Log("reloading");
    }
    private IEnumerator Smallreloading()
    {
        yield return new WaitForSeconds(0.7f);
        Reload = false;
    }

}
