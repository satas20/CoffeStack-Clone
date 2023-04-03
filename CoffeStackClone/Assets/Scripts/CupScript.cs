using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupScript : MonoBehaviour
{
    public bool isCoffe;
    public bool isCap;
    public bool isSup;
    public int price = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
