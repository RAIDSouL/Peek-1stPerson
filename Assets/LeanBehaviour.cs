using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 public class LeanBehaviour : MonoBehaviour {
     
     public Transform _Pivot;
 
     public float speed;
     public float maxAngle;
     public float maxLean;
    //  private bool i = true;
 
     float curAngle = 0f;
    Vector3 kodsad;
     // Use this for initialization
     void Awake () {
        if (_Pivot == null && transform.parent != null) _Pivot = transform.parent;
     }
     
     // Update is called once per frame
     void Update () {
 
         // lean left

         if (Input.GetKey(KeyCode.Q))
         {
            curAngle = Mathf.MoveTowardsAngle(curAngle, maxAngle, speed * Time.deltaTime);
            
            if(curAngle == maxAngle){
                // while(i){
                //     kodsad = transform.position;
                //     continue;
                // }
               transform.localPosition = Vector3.MoveTowards(new Vector3(0f,0.6f,0f),new Vector3(0f,0.6f,0f)-transform.InverseTransformPoint(transform.right),1f);
                // transform.position += transform.right * Time.deltaTime;
            }
         }
         // lean right
         else if (Input.GetKey(KeyCode.E))
         {
            curAngle = Mathf.MoveTowardsAngle(curAngle, -maxAngle, speed * Time.deltaTime);
         }
         // reset lean
         else
         {
            curAngle = Mathf.MoveTowardsAngle(curAngle, 0f, speed * Time.deltaTime);
            transform.localPosition = Vector3.MoveTowards(transform.localPosition,new Vector3(0f,0.6f,0f),1f);
            
         }
        
         _Pivot.transform.localRotation = Quaternion.AngleAxis(curAngle, Vector3.forward);
     }
 
 }