using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitTree : MonoBehaviour
{
    private int fruits = 50;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeFruit()
    {
        if (fruits > 0) fruits--;
    }

    public int GetFruitLeft() { return fruits; }
}
