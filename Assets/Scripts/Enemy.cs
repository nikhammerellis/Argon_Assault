using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;
    [SerializeField] int scorePerHit = 12; //can adjust this for different instances of enemies from the inspector. 

    ScoreBoard scoreBoard;

	// Use this for initialization
	void Start ()
    {
        AddBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void AddBoxCollider()
    {
        //AddNonTriggerBoxCollider(); anything more than the two lines below, and I would extract this out into its own method 
        Collider boxCollider = gameObject.AddComponent<BoxCollider>(); //add a box collider to any object with this Enemy script and make it collidable/destroyable 
        boxCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other) 
    {
        //print("particles collided with enemy "+ gameObject.name); 
        scoreBoard.ScoreHit(scorePerHit);
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
