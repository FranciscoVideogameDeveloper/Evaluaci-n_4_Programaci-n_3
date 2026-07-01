using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SistemaDeLista : MonoBehaviour
{
    public List<GameObject> inventario = new List<GameObject>();

    public GameObject itemUno;
    public GameObject itemDos;

    public List<GameObject> listaDeItems = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        if (itemUno != null) listaDeItems.Add(itemUno);
        if (itemDos != null) listaDeItems.Add(itemDos);

        Debug.Log("Items en la lista" + listaDeItems.Count);
    }

    public void RecolectarItem(GameObject itemagarrar)
    {
        if (itemagarrar != null)
        {
            inventario.Add(itemagarrar);
            itemagarrar.SetActive(false);
            itemagarrar.transform.SetParent(this.transform);

            Debug.Log("Item guardado en el inventario: " + itemagarrar +name);
        }       
    }
}
