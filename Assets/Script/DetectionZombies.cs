using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionZombies : MonoBehaviour
{
    public bool detected = false;
    public GameObject Range;
    public float rangeMax;
    public float rangeMin;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    private void Update()
    {
        
        //Change la port�e de d�tection des zombies si le joueur court ou non
        if (player.GetComponent<Deplacement1>().sprint)
        {
            Range.GetComponent<CircleCollider2D>().radius = rangeMax;
        }
        else
        {
            Range.GetComponent<CircleCollider2D>().radius = rangeMin;
        }
    }
    //V�rifie si le joueur est a port�e
    //Cela permettra de savoir si les zombies se baladent al�atoirement ou non
    private void OnTriggerEnter2D(Collider2D collision_in)
    {

        

        if (collision_in.CompareTag("Player")&& player.GetComponent<Deplacement1>().sprint)
        {//Penser � rajouter un syst�me permettant de v�rifier qu'il n'y a pas d'obstacle entre les zombies et le joueur
            detected = true; 
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")&& player.GetComponent<Deplacement1>().sprint)
        {
            detected = false;
        }
    }
}
