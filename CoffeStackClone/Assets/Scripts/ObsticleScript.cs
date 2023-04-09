using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObsticleScript : MonoBehaviour
{
    [SerializeField] float time;
    [SerializeField] int obsticleType;

    // Start is called before the first frame update
    void Start()
    {
        if (obsticleType == 1) { DoMoveRight(); }
        if (obsticleType == 2) { DoMoveDown(); }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void DoMoveUp()
    {
        transform.DOMoveY(10, time).OnComplete((DoMoveDown));
    }
    private void DoMoveDown()
    {
        transform.DOMoveY(1.5f, time).OnComplete((DoMoveUp));
    }
    private void DoMoveLeft()
    {
        transform.DOMoveX(-7, time).OnComplete((DoMoveRight));
    }
    private void DoMoveRight()
    {
        transform.DOMoveX(7, time).OnComplete((DoMoveLeft));
    }
}
