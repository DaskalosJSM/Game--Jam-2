using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootanimation : MonoBehaviour
{
    public GameObject BowString;
    public GameObject Hand;
    public GameObject foreArm;
    public GameObject arrowcharge;
    [SerializeField] bool isAiming;
    public Vector3 foreamrOffset;
    public float offsetX;
    public float offsetY;
    public float offsetZ;

    void Update()
    {
        if (isAiming == false)
        {
            arrowcharge.SetActive(false);
            foreamrOffset = new Vector3(foreArm.transform.position.x + offsetX,
            foreArm.transform.position.y + offsetY,
            foreArm.transform.position.z + offsetZ);

            BowString.transform.position = foreamrOffset;
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            isAiming = false;
            foreamrOffset = new Vector3(foreArm.transform.position.x + offsetX,
            foreArm.transform.position.y + offsetY,
            foreArm.transform.position.z + offsetZ);

            BowString.transform.position = foreamrOffset;
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            isAiming = true;
            arrowcharge.SetActive(true);
            BowString.transform.position = Hand.transform.position;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            BowString.transform.position = foreamrOffset;
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {
            foreamrOffset = new Vector3(foreArm.transform.position.x + offsetX,
            foreArm.transform.position.y + offsetY,
            foreArm.transform.position.z + offsetZ);

            BowString.transform.position = foreamrOffset;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            foreamrOffset = new Vector3(foreArm.transform.position.x + offsetX,
           foreArm.transform.position.y + offsetY,
           foreArm.transform.position.z + offsetZ);

            BowString.transform.position = foreamrOffset;
        }


    }
}
