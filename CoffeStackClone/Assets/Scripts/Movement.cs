using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
   
    public float swipeSpeed;
    public float moveSpeed;


    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        transform.position += Vector3.forward * moveSpeed * moveSpeed * Time.deltaTime;
        if (Input.GetMouseButton(0)){
            Move();
        }
    }
    private void Move()
    {
        Vector3 mousepos = Input.mousePosition;
        mousepos.z = cam.transform.localPosition.z;

        Ray ray = cam.ScreenPointToRay(mousepos);
        RaycastHit hit;
        if(Physics.Raycast(ray,out hit , 500)){
            GameObject firstCup = CoffeStack.instance.cups[0];

            Vector3 hitVec = hit.point;
            hitVec.y = firstCup.transform.localPosition.y;
            hitVec.z = firstCup.transform.localPosition.z;

            firstCup.transform.localPosition = Vector3.MoveTowards(firstCup.transform.localPosition, hitVec, Time.deltaTime * swipeSpeed);
        }
    }
}
