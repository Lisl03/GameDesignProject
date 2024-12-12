using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NewBehaviourScript : MonoBehaviour
{
    // Variable bestimmt die Grundgeschwindigkeit des Charakters
    public float speed = 2f;
    // Variable die eine horizontale Bewegung speichert mit Tasten A/D
    private float horizontal; 
    // Variable die eine vertikale Bewegung speichert mit Tasten W/S
    private float vertical;
    // Variable die den Character durch einen Wahrheitswert sprinten lässt, durch bestimmten Trigger
    private bool sprint = false; 
    // Variable die es verhindert, dass der Charakter sich diagonal schneller bewegt
    public float movelimiter = 0.7f; 
    // bezieht sich auf die Physik/ Collision des Charakters
    Rigidbody2D body; 
    // Start is called before the first frame update
    void Start()
    {
        // 
        body = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        // Methoden das dass Spiel weiß das mit WASD oder Pfeiltasten sich der Spieler bewegt. input ist dann sowas wie 1, 0, -1 als Richtungsangabe
        horizontal = Input.GetAxisRaw("Horizontal"); 
        vertical = Input.GetAxisRaw("Vertical"); 
        // wenn shift gedrückt wird dann sprintet der Charakater
        if (Input.GetKey("left shift"))
        {
            sprint = true;
        }
        else 
        // wenn nicht dann sprintet er nicht
        {
            sprint = false;
        }
    }
    
    
     
    void FixedUpdate()
    {
        // diese Methode überprüft ob sich der Charakter diagonal befindet, heißt wenn horizontal gleich 1 ist und vertikal gleich 1 bewegt er sich schneller
        if (horizontal != 0 && vertical != 0)
        {
            // wenn das zu trifft wird der Bewegungwert mit dem Movelimiter multipliziert
            horizontal *= movelimiter;
            vertical *= movelimiter; 
        }
        // wenn der Charakter sprintet wird die Bewegung mit einem Wert multipliziert
        if (sprint)
        {
           body.linearVelocity = new Vector2(horizontal * 2 * speed * Inventar.powerup, vertical * 2 * speed * Inventar.powerup); 

        }
        else 
        {
            body.linearVelocity = new Vector2(horizontal * speed * Inventar.powerup, vertical * speed * Inventar.powerup); 
        }
    }


}
