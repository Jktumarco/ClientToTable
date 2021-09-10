using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TestPrototupe.Place;
using System.Linq;
public class ClientController : MonoBehaviour
{
  

    public List<Transform> clientToPoints = new List<Transform>();
    public List<Vector3> clientPoints = new List<Vector3>();
    


    public List<Client> clientsList;
    public GameObject clientPrefab;
    public bool yesNo;
    TableController _TableController;
 

    Client _Client;
    public bool IsSpace = false;


    private void Awake()
    {
        _Client = FindObjectOfType<Client>();
        _TableController = FindObjectOfType<TableController>();
      
    }
    void Start()
    {

        SpawnClient();
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && IsSpace == false)
        {
            
            for (int i = 0; i < 6; i++)
            {
                ChangePosition();
            }
            IsSpace = true;
            return;
        }

        else if (Input.GetKeyDown(KeyCode.Space))
         {
           
            for (int i = 0; i < 6; i++)
            {
                ChangePosition();
            }

         }


    }

    void SpawnClient()
    {

        foreach (var item in clientPoints)
        {

            GameObject go = Instantiate(clientPrefab, item, Quaternion.identity);
            var client = go.GetComponent<Client>();
            clientsList.Add(client);
        }

    }
     void TransferTableToClient(Client client)
     {
        var fouderFreeTable = FindTable();

        var cl = client;
        cl.table = fouderFreeTable;

       

     }


    void ChangePosition()
    {

        //var clientGoTOTable = clientsList.Find(x => x._clientBehavior == Client.clientBehavior.GoToTable);
        var client = clientsList.Find(x => x._clientBehavior == Client.clientBehavior.IsWaiting);
        


         if (client != null && IsSpace == false)
         {
            client._clientBehavior = Client.clientBehavior.GoToTable;
            TransferTableToClient(client);
         }
        
         
        
        else if (client != null && client.ProbabilityClientToMove() == true)
        {
            client._clientBehavior = Client.clientBehavior.GoToTable;
            TransferTableToClient(client);
        }
        //if (clientGoTOTable != null && IsSpace == true)
        //{
        //    print(clientGoTOTable._clientBehavior);
        //    //client._clientBehavior = Client.clientBehavior.GoToTable;
        //    TransferTableToClient(client);
        //}
        
    }
    

    Table FindTable()
    {
        Table findListFreeTables = _TableController.TablesList.Find(x => x._tableBehavior == Table.tableBehavior.IsFree);

        
        //print("нашел " + findListFreeTables.Count + "свободных столов");
        if (findListFreeTables == null)
        {
            print("нету свободных столов");
            return null;
        }
        if (findListFreeTables._tableBehavior == Table.tableBehavior.IsFree)
        {
            print("выбрал рандомный стол под cс статусом" + findListFreeTables._tableBehavior + " и расположением ");
            findListFreeTables._tableBehavior = Table.tableBehavior.IsSelected;
        }
        

        //var rand = findListFreeTables[Random.Range(0, findListFreeTables.Count)];
        print("выбрал рандомный стол под cс статусом" + findListFreeTables._tableBehavior + " и расположением ");
        findListFreeTables._tableBehavior = Table.tableBehavior.IsSelected;
        return findListFreeTables; 
    }
    private bool ZeroDistanceToTable( Client client, Table pointTable)
    {
        var b = false;
        var zeroPosition = pointTable.TablePoint - client._positionClient;
        if (zeroPosition == Vector3.zero)
        {
            b = true;
        }
        return b;
    }


}










