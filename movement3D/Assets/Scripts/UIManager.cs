using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public int indicador;
    public GameObject imagearrow;
    // Start is called before the first frame update
    void Start()
    {
    }
    void Update()
    {
        if (indicador == 1)
        {
            imagearrow.SetActive(true);
        }
    }
}
