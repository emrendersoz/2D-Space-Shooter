using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clamp : MonoBehaviour
{
    public float maxY=4f, minY=-4f, maxX=10f, minX=-10f;
    
  private void Update() {
      transform.position=new Vector3(transform.position.x,Mathf.Clamp(transform.position.y,minY,maxY),transform.position.z);
      transform.position=new Vector3(Mathf.Clamp(transform.position.x,minX,maxX),transform.position.y,transform.position.z);
  }
}
