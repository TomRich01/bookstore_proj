using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ChildNodes : MonoBehaviour
{
    private BoxCollider boxCollider;
    const float waypointGizmoRadius = 0.3f;


    // Enum for type of node action
    public NodePoints points;
    public enum NodePoints
    {
       startPoint,
       sitPoint,
       buyPoint,
       browsePoint,
       leavePoint,
       cafePoint,
       emptyPoint
    }
    private void OnDrawGizmos()
    {
       // Switch statement for node color
        switch (points)
        {
            case NodePoints.startPoint:
                Gizmos.color = Color.blue;
                break;
            case NodePoints.sitPoint:
                Gizmos.color = Color.white;
                break;
            case NodePoints.buyPoint:
                Gizmos.color = Color.green;
                break;
            case NodePoints.browsePoint:
                Gizmos.color = Color.yellow;
                break;
            case NodePoints.leavePoint:
                Gizmos.color = Color.red;
                break;
            case NodePoints.cafePoint:
                Gizmos.color = Color.magenta;
                break;
            case NodePoints.emptyPoint:
                Gizmos.color = Color.gray;
                break;
            default:
                Gizmos.color = Color.grey;
                break;
        }
        Gizmos.DrawSphere(transform.position, waypointGizmoRadius);

        
    }

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        boxCollider.isTrigger = true;
       // boxCollider.size =  new Vector3(1f, 1f, 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Customer>() && points == NodePoints.startPoint)
        {
            Debug.Log("In Me!");
            // Customer browses store
            other.GetComponent<Customer>().RandomBrowsePoint();
        }


        if (other.GetComponent<Customer>() && points == NodePoints.buyPoint)
        {
            Debug.Log("In Me!");
            // Customer decides to buy in store
            other.GetComponent<Customer>().Buy();
            other.GetComponent<Customer>().hasBought = true;


        }
        if (other.GetComponent<Customer>() && points == NodePoints.browsePoint)
        {
            Debug.Log("In Me!");
            // Customer checks if satisifed with store
            other.GetComponent<Customer>().CheckIfSatisfied();
        }
        if (other.GetComponent<Customer>() && points == NodePoints.leavePoint)
        {
            Debug.Log("In Me!");
            // Customer leaves store
            other.GetComponent<Customer>().Destroy();
        }


    }

}
