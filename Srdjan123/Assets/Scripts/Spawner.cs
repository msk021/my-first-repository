using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] obstaclePattern;

    private float timeBtwSpawn; //"trenutno" vreme izmedju spawnovanja, pomalo nepotrebno u ovom slucaju
    public float startTimeBtwSpawn; // koliko ce razmak izmedju spawnovanja biti na pocetku jer se posle menja (objasnjeno dole)
    public float decreaseTime; //oduzima ovoliko od vremena koje si postavio svaki put kad spawnujes, znaci sad je
                               // npr 4 sekunde razmak izmedju spawnovanja, sledeci put ce biti za ovoliko manji
                               // znaci ako je ovo 0.1 sledeci put ce biti 3.9, 3.8, 3.7, ...
    public float minTime; //kada dodje do ovoliko sekundi onda odradi sta treba,
                          //stavljas minimal time da ne bi oduzimao dok dodje do 0 nego si uvek siguran  da ce biti razmak izmedju spawnovanja

    void Update()
    {
        if (timeBtwSpawn <= 0) //ako je vreme isteklo odradi se ovo unutra
        {
            int rand = Random.Range(0, obstaclePattern.Length); //generises random broj od 0 do kolko ima clanova u listi obstaclePatterns
            Instantiate(obstaclePattern[rand], transform.position, Quaternion.identity); //obsPattern[rand/neki broj] znaci izabrao si gameobject koji je na toj poziciji u listi,
                                            // parrent na koji kacis objekat koji spawnujes, u ovom slucaju objekat na koji je skripta zakacena,
                                            // mogao si napisati i this.transform.position, ili this.gameobject.transform.position ako bi ti tako bilo jasnije ali je nepotrebno,
                                            // quaternion identity mi nikad nije bas jasno bilo sta znaci al to je vld da gameobject zadrzi svoju rotaciju koja mu je u prefabu
                                            // jer ga ti kacis na parenta a kad to radis onda pokupi osobine parenta tipa scale i jos neke nz, nmp kad ovako radim uvek samo napisem quat.iden i tjt hahaha
            
            //ovo sa instantiate si mogao i samo gameobject koji oces, bez parenta i quaterniona, vidi u mojoj skripti
            
            timeBtwSpawn = startTimeBtwSpawn; // stavljas da ti je "trenutno" vreme izmedju spawnovanja = "pocetnom"
            if (startTimeBtwSpawn > minTime) //ako je "pocetno" vece od minimalnog
            {
                startTimeBtwSpawn -= decreaseTime; //pocetno umanjujes za decrease time, znaci sledeci put kad se odradi linija 26
                                                   //onda ce "trenutno" timeBtwSpawn biti ovoliko kolko bude ovo sto si upravo umanjio

            }
        }
        else //ako vreme nije isteklo oduzimas vreme dok ne istekne
        {
            timeBtwSpawn -= Time.deltaTime; 
        }        
    }
}
