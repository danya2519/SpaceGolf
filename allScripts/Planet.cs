using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    [SerializeField] private float force = 1;
    private trigger circle;
    [SerializeField] private bool canMove;

    private void Start()
    {
        circle = GetComponentInChildren<trigger>();
        if(canMove )
        {
            transform.position = new Vector2(Random.Range(-4f, 5f), Random.Range(-4f, 4f));
        }
    }

    private void Update()
    {
        if (circle.objects != null)
        {
            foreach (var obj in circle.objects)
            {
                if(obj.TryGetComponent<Rigidbody2D>(out Rigidbody2D rig))
                {
                    rig.AddForce((transform.position - rig.transform.position).normalized * force * Time.deltaTime, ForceMode2D.Force);
                }
            }
        }
    }

}
