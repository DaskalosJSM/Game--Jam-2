using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiraCentral : MonoBehaviour
{
public GameObject Cam;
private float canvasWidth;
private float canvasHeight;

public int offsetX;
public int offsetY;

public bool second;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        canvasWidth = Cam.GetComponent<RectTransform>().rect.width;
        canvasHeight = Cam.GetComponent<RectTransform>().rect.height;
        if(second){
        this.transform.position=new Vector3( 3*canvasWidth/4+offsetX,canvasHeight/2+offsetY,0);
        }
        else{
        this.transform.position=new Vector3( canvasWidth/4+offsetX,canvasHeight/2+offsetY,0);

        }
    }
}
