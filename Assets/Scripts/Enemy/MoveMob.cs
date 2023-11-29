using UnityEngine;



    public abstract class MoveMob : MonoBehaviour
    {
        public float moveSpeed = 15f;
        public Rigidbody rb;
        
        protected virtual void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        protected virtual void FixedUpdate()
        {
            if (GetTarget() != null)
            {
                Vector3 direction = GetTarget().position - transform.position;
                transform.rotation = Quaternion.LookRotation(direction);
                Vector3 directionMove = (GetTarget().position - transform.position).normalized;
                rb.MovePosition(transform.position + directionMove * moveSpeed * Time.deltaTime);
            }
        }

        protected abstract Transform GetTarget();

    }
