using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luchador : Player
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Vida()
    {
        vida = 40;
        Debug.Log("Eres un Luchador, tu vida es de:" + vida);
    }
}
