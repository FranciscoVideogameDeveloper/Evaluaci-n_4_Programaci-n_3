using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTypeOfPlayer : MonoBehaviour 
{
    public Paladin paladin;
    public Mago mago;
    public Luchador luchador;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Alfombra"))
        {
            luchador.Vida();
        }
    }
}
