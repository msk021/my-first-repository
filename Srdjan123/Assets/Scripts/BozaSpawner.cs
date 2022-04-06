using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BozaSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> obstaclePatterns;
    [SerializeField] float timeBtwSpawn;
    [SerializeField] float currentTimeBtwSpawn;
    [SerializeField] float timeDecreaser;
    [SerializeField] float minimalTime;

    private void Start()
    {
        currentTimeBtwSpawn = timeBtwSpawn; //current time stavljamo da bude kao ovaj timebtw, jer current nismo postavili vrednost, vidi u inspektoru kako se ponasa current
        print($"BozaSpawner: start time between spawn is {currentTimeBtwSpawn}");
    }
    private void Update()
    {
        CheckAndSpawn();
    }
    public void CheckAndSpawn()
    {
        if (currentTimeBtwSpawn > 0) //ako je current veci od 0, oduzimamo vreme
        {
            currentTimeBtwSpawn -= Time.deltaTime;
        }
        else //ako current nije veci od 0 onda se desi ovo
        {
            GameObject instantiatedObject = Instantiate(obstaclePatterns[Random.Range(0, obstaclePatterns.Count)]);
            //sve unutar zagrade ovde predstavlja samo gameobject na random poziciji iz liste   obstaclePatterns[random int]
            //nisam ga zakacio za parenta jer nema potrebe u ovom slucaju, pa mi ne treba ni quaternion
            //nisam morao da stavim ovaj instantiatedObject = Instantiate() ali mi je lakse da bih mogao da ga stavim print

            print($"BozaSpawner: {instantiatedObject.name} is spawned at {instantiatedObject.transform.position}");
            // $"" dolar stavis da bi varijable mogao da ubacujes u tekst sa {varijabla} , inace bi morao da pises kao ovo dole
            print("BozaSpawner: " + instantiatedObject.name + " is spawned at " + instantiatedObject.transform.position);
            
            if (timeBtwSpawn > minimalTime) //ako je vreme izmedju spawnovanja vece od minimalnog
            {
                timeBtwSpawn -= timeDecreaser; //oduzimas decreaser od timebtwspawn
                print($"BozaSpawner: {timeBtwSpawn} is new timeBtwSpawn");
            }
            currentTimeBtwSpawn = timeBtwSpawn; //trenutno vreme stavljas da bude timeBtwSpawn, tj kao resetujes ga jer je doslo do 0
                                                //al ga ne resetujes na pocetno nego si od pocetnog vec oduzeo decreaser znaci na smanjeno ga stavljas
            print($"BozaSpawner: current time is resetted and now is {currentTimeBtwSpawn}");
        }
    }
}
