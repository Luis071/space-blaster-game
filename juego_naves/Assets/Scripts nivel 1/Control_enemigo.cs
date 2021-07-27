using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_enemigo : MonoBehaviour
{
    public GameObject ExplosionGo;

    float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;

        position = new Vector2 (position.x, position.y - speed * Time.deltaTime);

        transform.position = position;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if(transform.position.y < min.y)
        {
            Destroy(gameObject);

        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        //Detect collision of the enemy ship with the player ship, or with a player's bullet
        if((col.tag == "PlayerShipTag")|| (col.tag == "PlayerBulletTag"))
        {
            PlayExplosion();
            //Destroy this enemy ship
            Destroy(gameObject);
        }
    }

    //Funtion to instatiate an explosion
	void PlayExplosion()
	{
		GameObject explosion = (GameObject)Instantiate (ExplosionGo);

		//set the position of the explosion
		explosion.transform.position =transform.position;
	}
}
