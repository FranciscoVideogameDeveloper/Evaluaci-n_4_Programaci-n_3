using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NPC : MonoBehaviour
{
    void Start()
    {
        PrimerNPC.NPC npc1 = new PrimerNPC.NPC();
        SegundoNPC.NPC npc2 = new SegundoNPC.NPC();

        npc1.Hablar();
        npc2.Hablar();
    }

   // private void OnCollisionEnter(Collision other)
   // {
     //   if (other.gameObject.CompareTag("Player"))
       // { 
         
         
       // }
    //}
}
