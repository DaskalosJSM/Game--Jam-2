using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject UIElement;
    public int indice;
 
    void Update()
    {
        if(indice==1)
        {
            UIElement.SetActive(true);
        }
    }
}
