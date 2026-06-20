using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mago : Player
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
        vida = 80;
        Debug.Log("Eres un Mago, tu vida es de:" + vida);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Alfombra"))
        {
            Vida();
        }
    }
}
