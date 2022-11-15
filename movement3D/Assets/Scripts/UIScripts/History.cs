using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class History : MonoBehaviour
{
    string textValue = "You are a hunting angel who falls from the sky with a thirst for revenge, the war between angels and demons has been unleashed and it will not stop until Asmodeus is defeated. You will face the darkness walking through the corridors of the lost souls, you must be alert of the demons and other dangers that guard each fragment of the sacred arrow. Remember the premise you need to SURVIVE to end evil... GOOD LUCK !!!";
    public Text textElement;
    // Start is called before the first frame update


    void Start()
    {
        StartCoroutine(ContentText());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator ContentText()
     {
         foreach(char caracter in textValue)
         {
             textElement.text = textElement.text + caracter;
             yield return new WaitForSeconds(0.13f);

        }


    } 


}
