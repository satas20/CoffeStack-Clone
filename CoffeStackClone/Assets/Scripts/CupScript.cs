using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupScript : MonoBehaviour
{
    public GameObject CupWCoffe;
    public GameObject Cup;
    public GameObject CupSup;
    public GameObject CupCap;
    public bool isCoffe;
    public bool isCap;
    public bool isSup;
    public int price = 1;
    // Start is called before the first frame update
  
    // Update is called once per frame
    void Update()
    {
        if (isCap){
            CupCap.SetActive(true);

        }
        if (isCoffe)
        {
            Cup.SetActive(false);
            CupWCoffe.SetActive(true);
         

        }
        if (isSup){
            Cup.SetActive(false);
            CupWCoffe.SetActive(false);
            CupSup.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coffe")){
            isCoffe = true;
            price += 2;
        }
        if (other.CompareTag("Cap"))
        {
            isCap = true;
            price += 2;
        }
        if (other.CompareTag("Sup"))
        {
            isSup = true;
            price = 8;
        }
    }
}
