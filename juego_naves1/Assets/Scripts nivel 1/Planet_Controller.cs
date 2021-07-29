using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet_Controller : MonoBehaviour
{
    public GameObject[] Planets;

    Queue<GameObject> avaiblePlanets = new Queue<GameObject>(); 


    // Start is called before the first frame update
    void Start()
    {
        avaiblePlanets.Enqueue(Planets[0]);
        avaiblePlanets.Enqueue(Planets[1]);
        avaiblePlanets.Enqueue(Planets[2]);

        InvokeRepeating("MovePlanetDown", 0, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MovePlanetDown()
    {
        EnqueuePlanets();

        if (avaiblePlanets.Count == 0)
            return;

        GameObject aPlanet = avaiblePlanets.Dequeue();

        aPlanet.GetComponent<Planetas>().isMoving = true; 

    }

    void EnqueuePlanets()
    {
        foreach (GameObject aPlanet in Planets)
        {
            if((aPlanet.transform.position.y <0) && (!aPlanet.GetComponent<Planetas>().isMoving)){

                aPlanet.GetComponent<Planetas>().ResetPosition();

                avaiblePlanets.Enqueue(aPlanet);

            }
        }    

    }
}
