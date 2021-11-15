using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{

    [SerializeField] Bomb bombToSpawn;
    [SerializeField] BombSpawner otherBombSpawner;
    [SerializeField] float timeToSpawnBomb;
    float timeLeftTillBombSpawn;
    [SerializeField] bool myBombExists = false;
    [SerializeField] bool bombExists = false;
    // Start is called before the first frame update
    void Start()
    {
        timeLeftTillBombSpawn = timeToSpawnBomb;
    }

    // Update is called once per frame
    void Update()
    {
        checkIfBombExists();
       
       if (!bombExists){
           timeLeftTillBombSpawn -= Time.deltaTime;
        if (timeLeftTillBombSpawn <= 0) {
            SpawnBomb();
            timeLeftTillBombSpawn = timeToSpawnBomb;
            } 
        }
    }

    public void SpawnBomb() {
        //AudioSource.PlayClipAtPoint(cannonSound, transform.position);
        Bomb newProjectile = Instantiate(
            bombToSpawn, transform.position, transform.rotation) as Bomb;
            newProjectile.GetComponent<SpriteRenderer>().sortingLayerName = "Pickupable";
        newProjectile.transform.parent = gameObject.transform;
        newProjectile.bombNotLit();
        myBombExists = true;
        bombExists = true;
        otherBombSpawner.otherSpawnerSpawnedBomb();
        
    }
    private void checkIfBombExists(){
        if (this.transform.childCount < 4){
            myBombExists = false;
        }
        if (!otherBombSpawner.hasBomb() & !myBombExists){
            bombExists = false;
        }

        
    }
    public bool hasBomb(){
        return myBombExists;
    }
    public void otherSpawnerSpawnedBomb(){
        bombExists = true;
    }
}
