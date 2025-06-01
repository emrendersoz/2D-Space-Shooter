using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    public float destroyT=1f;
    public float speed = 5f;
    public bool canMove=true;
    public float maxX=20f, minX=3f;    
    float rotZ;
    public Transform firePoint, firePoint2, firePoint3, firePoint4;
    public GameObject beamPrefab;
    public float beamForce;
    public float rotationSpeed;
    public bool ClockwiseRotation,canFire;
    public float health=1700f;
    private void Start()
    {
        canFire=true;
     
        StartCoroutine(Shooting());
        
    }
    private void Update()
    {
        Rotate();
        BossMove();
    }

    void BossMove(){
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp;
           
        }
      transform.position=new Vector3(Mathf.Clamp(transform.position.x,minX,maxX),transform.position.y,transform.position.z);
        
    }  
    void Rotate()
    {
        if (!ClockwiseRotation)
        {
            rotZ += Time.deltaTime * rotationSpeed;
        }
        else
        {
            rotZ += -Time.deltaTime * rotationSpeed;
        }
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);
    }
    IEnumerator Shooting(){
        while(canFire){
            yield return new WaitForSeconds(.5f);
            Shoot();

        }
         
    }
    
    void Shoot()
    {
        GameObject beam1=Instantiate(beamPrefab, firePoint.position, firePoint.rotation);
        GameObject beam2=Instantiate(beamPrefab, firePoint2.position, firePoint.rotation);
        GameObject beam3=Instantiate(beamPrefab, firePoint3.position, firePoint.rotation);
        GameObject beam4=Instantiate(beamPrefab, firePoint4.position, firePoint.rotation);
        
        Rigidbody2D rb1=beam1.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2=beam2.GetComponent<Rigidbody2D>();
        Rigidbody2D rb3=beam3.GetComponent<Rigidbody2D>();
        Rigidbody2D rb4=beam4.GetComponent<Rigidbody2D>();
        
        rb1.AddForce(firePoint.up*beamForce, ForceMode2D.Impulse);
        rb2.AddForce(-firePoint2.up*beamForce, ForceMode2D.Impulse);
        rb3.AddForce(firePoint3.right*beamForce, ForceMode2D.Impulse);
        rb4.AddForce(-firePoint4.right*beamForce, ForceMode2D.Impulse);
        Destroy(beam1,destroyT);
        Destroy(beam2,destroyT);
        Destroy(beam3,destroyT);
        Destroy(beam4,destroyT);

    }
    
    
        private void OnTriggerEnter2D(Collider2D other) {
            if(other.tag=="Bullet"){
                health-=34;
            }
            else if(other.tag=="YellowBullet"){
                health-=170;
            }
            if(health<=0){
                Score.scoreValue+=10;
                Destroy(gameObject);
            }
        }
    
}
