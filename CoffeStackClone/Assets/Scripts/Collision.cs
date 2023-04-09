using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
        else if (other.gameObject.tag == "Collision")
        {
            CoffeStack.instance.UnStackCup(CoffeStack.instance.cups.IndexOf(gameObject));
            
            //Destroy(other.gameObject);
        }
        else if(other.gameObject.tag == "EndGame" && gameObject == CoffeStack.instance.cups[0])
        {
            CoffeStack.instance.EndGame();
        }
        else if (other.gameObject.tag == "FinalStage" && gameObject == CoffeStack.instance.cups[0])
        {
            CoffeStack.instance.FinalStage();
        }
        else if (other.gameObject.tag == "Sell" && gameObject!=CoffeStack.instance.cups[0])
        {
            
            gameObject.transform.SetParent(other.transform, true);
            CoffeStack.instance.SellCup(gameObject);
            gameObject.transform.DOMoveY(2, 0.2f);
            gameObject.transform.DOLocalMoveZ(0, 0.2f);
            gameObject.transform.DOMoveX(20,2);
            
            //Destroy(other.gameObject);
        }
        if(other.gameObject.tag == "EndSell" && gameObject != CoffeStack.instance.cups[0]){
            
            other.transform.DOMoveZ(other.transform.position.z + 5, 1);
            gameObject.transform.DOMoveX(20*CoffeStack.instance.i, 2);
            CoffeStack.instance.i *= -1;               
            CoffeStack.instance.SellCup(gameObject);
        }
    }
}
