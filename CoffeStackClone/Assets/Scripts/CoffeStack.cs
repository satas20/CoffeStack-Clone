using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;


public class CoffeStack : MonoBehaviour
{
    public int i = -1;
    public int totalMoney;
    public TMP_Text PriceText;
    public TMP_Text TotalPriceText;
    public float movementDelay;
    public static CoffeStack instance;
    public List<GameObject> cups = new List<GameObject>();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TotalPriceText.text= totalMoney.ToString() + "$";
        PriceText.text = calculatePrice().ToString() + "$";
        if (Input.GetMouseButton(0))
        {
            moveListElements();
        }
        if (Input.GetMouseButtonUp(0))
        {
            MoveOrgin();
        }
    }
    public void StackCup(GameObject other , int index){
        other.transform.parent = transform;
        Vector3 newPos = cups[index].transform.localPosition;
        newPos.z += 1;
        other.transform.localPosition = newPos;
        cups.Add(other);
        StartCoroutine(scaleEffect());
    }
    public void UnStackCup(int index)
    {
        for(int i = cups.Count-1; i >= index; i--){
            if (i == 0) {
                gameObject.transform.DOMoveZ(transform.position.z-5,0.5f);

                return;
            }
            cups[i].GetComponent<BoxCollider>().isTrigger = true;
            cups[i].tag = "Cup";
            Destroy(cups[i].GetComponent<Collision>());
            Destroy(cups[i].GetComponent<Rigidbody>());


            Vector3 newPos = cups[i].transform.position;
            cups[i].transform.parent = null;
            newPos.z += Random.Range(15,20);
            newPos.x += Random.Range(-4,4);
            newPos.x= Mathf.Clamp(newPos.x, -7, 7);

            cups[i].transform.DOMove(newPos,0.2f);
            cups[i].transform.DOScale(new Vector3(1, 1, 1), 0.1f);
            cups.Remove(cups[i]);
        }
    }
    public void SellCup(GameObject cup)
    {
        cup.tag = "Cup";
        Destroy(cup.GetComponent<Collision>());
        Destroy(cup.GetComponent<Rigidbody>());
        cups.Remove(cup);
        totalMoney += cup.GetComponent<CupScript>().price;
        
    }
    public IEnumerator scaleEffect()
    {
        for (int i = cups.Count-1; i > 0; i--){
            int index = i;
            Vector3 scale = new Vector3(1, 1, 1);
            scale *= 1.5f;

            cups[index].transform.DOScale(scale, 0.1f).OnComplete(() =>
             cups[index].transform.DOScale(new Vector3(1, 1, 1), 0.1f));
            yield return new WaitForSeconds(0.05f);
        }
    }
    public void FinalStage()
    {
        Vector3 enPos = cups[0].transform.position;
        gameObject.GetComponent<Movement>().swipeSpeed = 0;

        enPos.x = 0;
        cups[0].transform.DOMoveX(0, 1);
    }
    public void EndGame(){

        Vector3 enPos = cups[0].transform.position;
        Destroy(gameObject.GetComponent<Movement>());

        enPos.y += totalMoney*2;
        cups[0].transform.DOMove(enPos,10);
    }
    private int calculatePrice(){
        int price = 0;
        foreach(GameObject cup in cups){
            if (cup.GetComponent<CupScript>() !=null) {
                price += cup.GetComponent<CupScript>().price;
            }
         
        }
        return price;

    }
    private void moveListElements(){
        
        for(int i = 1; i < cups.Count; i++){
            Vector3 pos = cups[i].transform.localPosition;
            pos.x = cups[i - 1].transform.localPosition.x;
            cups[i].transform.DOLocalMove(pos, movementDelay);
        }
    }
    private void MoveOrgin(){
        for (int i = 1; i < cups.Count; i++)
        {
            Vector3 pos = cups[i].transform.localPosition;
            pos.x = cups[0].transform.localPosition.x;
            cups[i].transform.DOLocalMove(pos, 0.7f);
        }
    }
}
