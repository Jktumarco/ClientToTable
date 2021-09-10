using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestPrototupe.Place;
public class TableController : MonoBehaviour
{
    ClientController ClientContrRef;
    public GameObject TablePrefab;
    public static TableController S;

    public static TableController _tableController { get { return S; } }


    public  List<Table> TablesList;


    void Awake()
    {
        if (S == null) { S = this; }

         ClientContrRef = FindObjectOfType<ClientController>();
    }
    
   
    void Start()
    {
        SpawnTables();
        
    }

    public List<Table> findTables = new List<Table>();
    void SpawnTables()
    {
        var clPoint = ClientContrRef.clientToPoints;
        if(clPoint == null) { Debug.Log("нету ничего в листе ");  }
        else
        {
            
            foreach (var item in clPoint)
            {
                
                Vector3 TempItem = item.transform.position;
                GameObject go = Instantiate(TablePrefab, TempItem, Quaternion.identity);
                var table = go.GetComponent<Table>();
                table.pointTable = item;
                table.transform.SetParent(item);
                TablesList.Add(table);

                
                
                

            }
            
            

        }
            
    }
}
