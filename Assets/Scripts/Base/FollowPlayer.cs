using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    [SerializeField]
    private Vector3 offset;
    private Transform DefaultTranform;
    [SerializeField]
    private bool follow=true;
    private Vector3 playerposition;
    public bool Follow { get => follow; set => follow = value; }
    

    // Start is called before the first frame update
    void Start()
    {
        DefaultTranform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player && follow)
        {
           
            transform.position = player.position + offset;
        }
    }

    public Vector3 GetPlayerPos()
    {
        return player.position + offset;
    }

}
