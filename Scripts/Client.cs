using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestPrototupe.Place
{

    
    public class Client : MonoBehaviour
    {
        public enum clientBehavior { IsWaiting, GoToTable, IsTable }
        
        public clientBehavior _clientBehavior;
        
        public Table table = null;
       
        
        private Vector3 positionClient;


        public Vector3 _positionClient { get { return positionClient; } set { positionClient = value; } }

        private void Awake()
        {
            _clientBehavior = clientBehavior.IsWaiting;
            positionClient = this.transform.position;
        }
        void Update()
        {
            if (table==null) {  return; }
            GoToTable(table);
            
        }
        public void GoToTable(Table table)
        {
            if (this.table == null ) { return; }
            
            this.transform.position = Vector3.MoveTowards(this.transform.position, table.TablePoint, 7f);
            
        }
        public bool ZeroDistanceToTable(Client client, Table pointTable)
        {
            var b = false;
            Vector3  zeroPosition = new Vector3(pointTable.TablePoint.x, pointTable.TablePoint.y, pointTable.TablePoint.z) - new Vector3(client._positionClient.x, client._positionClient.y, client._positionClient.z);
            
            print(zeroPosition);
            if (zeroPosition == Vector3.zero)
            {
                b = true;
            }
            return b;
        }
        public bool ProbabilityClientToMove()
        {

            var yesNo = false;
            int rand = Random.Range(0, 100);
            print(rand);
            if (rand < 45) { yesNo = true; } else yesNo = false;
            return yesNo;
        }
        void OnTriggerEnter(Collider other)
        {
            if ( other.gameObject.tag == "Table" )
            {
                print("я вошел в триггер");
                this._clientBehavior = Client.clientBehavior.IsWaiting;
                this.table._tableBehavior = Table.tableBehavior.IsBusy;
               

            }
            
        }
        void OnTriggerExit(Collider other)
        {
            var table = other.gameObject.GetComponent<Table>();
            if ( other.gameObject.tag == "Table" &&  table._tableBehavior == Table.tableBehavior.IsBusy )
            {
                print("выхожу к другому столу");
                table._tableBehavior = Table.tableBehavior.IsFree;
                
            }
        }
    }
}

