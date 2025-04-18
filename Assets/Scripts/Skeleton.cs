using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    public Transform homePosition;
    private Animator animator;
    private Transform target; 
    
    [SerializeField]
    private float speed; 

    [SerializeField]
    private float maxRange;

    [SerializeField]
    private float minRange;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, target.position) <= maxRange && Vector3.Distance(transform.position, target.position) >= minRange)
        {
            FollowPlayer();
        }
        else if(Vector3.Distance(target.position, transform.position) >= maxRange){
            ReturnToHome();
        }
       
    }
    public void FollowPlayer()
    {
        animator.SetBool("isMoving", true);
        animator.SetFloat("moveX", (target.position.x - transform.position.x));
        animator.SetFloat("moveY", (target.position.y - transform.position.y));
        
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        
    }

    public void ReturnToHome()
    {
        //animator.SetBool("isMoving", true);
        animator.SetFloat("moveX", (homePosition.position.x - transform.position.x));
        animator.SetFloat("moveY", (homePosition.position.y - transform.position.y));
        
        transform.position = Vector2.MoveTowards(transform.position, homePosition.position, speed * Time.deltaTime);
        
        if (Vector3.Distance(transform.position, homePosition.position) ==0)
        {
            animator.SetBool("isMoving", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("MyWeapon")){
            Vector2 difference = transform.position - other.transform.position;
            transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
        }
    }
}
