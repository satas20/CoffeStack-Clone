using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cup"){
            if(!CoffeStack.instance.cups.Contains(other.gameObject)){
                other.GetComponent<BoxCollider>().isTrigger = false;
                other.gameObject.tag = "Untagged";
                if (other.gameObject.GetComponent<CupScript>()==null){
                    other.gameObject.AddComponent<CupScript>();
                }
                
                other.gameObject.AddComponent<Collision>();
                other.gameObject.AddComponent<Rigidbody>();
                other.gameObject.GetComponent<Rigidbody>().isKinematic = true;

                CoffeStack.instance.StackCup(other.gameObject, CoffeStack.instance.cups.Count - 1);
            }
        }
        if (other.gameObject.tag == "Collision")
        {
            CoffeStack.instance.UnStackCup(CoffeStack.instance.cups.IndexOf(gameObject));
            //Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "EndGame")
        {
            CoffeStack.instance.EndGame();
        }
        if (other.gameObject.tag == "FinalStage")
        {
            CoffeStack.instance.FinalStage();
        }
        if (other.gameObject.tag == "Sell" && gameObject!=CoffeStack.instance.cups[0])
        {
            CoffeStack.instance.SellCup(gameObject);
            //Destroy(other.gameObject);
        }
    }
}
