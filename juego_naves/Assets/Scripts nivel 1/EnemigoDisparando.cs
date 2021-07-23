using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoDisparando : MonoBehaviour
{
    public GameObject Bala_enemiga;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("FireEnemyBullet", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FireEnemyBullet()
    {
        GameObject playerShip = GameObject.Find ("Player1");

        if(playerShip != null)
        {
            GameObject bala = (GameObject)Instantiate(Bala_enemiga);

            bala.transform.position = transform.position;

            Vector2 direction = playerShip.transform.position - bala.transform.position;

            bala.GetComponent<Bala_enemiga>().SetDirection(direction);

        }
    }
}
