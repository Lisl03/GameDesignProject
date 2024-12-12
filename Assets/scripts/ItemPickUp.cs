using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour

{
    // diese Variable wird benutzt damit das Spiel weiß ob der Spieler sich in der Nähe des Items befindet
    public GameObject player;
    // diese Variable gibt den maximalen Abstand an, in die der player das item aufheben kann
    public float distance; 
    [Tooltip("must be item1 or item2")]
    // Variable enthält den Namen des Items
    public string ItemName; 
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // berechnet des Abstand zwischen Item und Player
        if (Vector3.Distance(this.transform.position, player.transform.position)<= distance)
        {
            // wenn der Abstand kleiner als distance ist, ist er in range und kann mit q aufgesammelt werden
            Debug.Log("in range");
            if(Input.GetKeyDown("q"))
            {
                // wenn es sich um item1 handelt dann wird dieser aufgesammelt und im Inventar zu true
                if(ItemName == "item1")
                {
                    Inventar.item1 = true;
                
                }
                // wenn es sich um item2 handelt dann wird das Item im Inventar einen mehr
                else if (ItemName == "item2")
                {
                    // wenn das item mehr oder gleich 1 ist wird das Powerup aktiviert
                    Inventar.item2 += 1;
                    Inventar.powerup += 9;
                }
                // geben den aktuellen Stand der beiden Variablen an
                Debug.Log(Inventar.item1);
                Debug.Log(Inventar.item2);
                // durch diese Zeile wird das Spiel Onjekt zerstört nach dem es aufgesammelt wurde
                Destroy(this.gameObject);
        
            
            }
        }
    
    }
}
