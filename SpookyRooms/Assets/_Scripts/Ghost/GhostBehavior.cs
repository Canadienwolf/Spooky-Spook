using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostBehavior : MonoBehaviour
{
    public enum GhostMode { Chill, Hunt}
    public GhostMode mode;

    public PathsCollection pathCollection;
    public float wanderSpeed = 3;
    public float targetRadius = 0.5f;
    public float lookDistance = 4;
    public float respawnTime = 1;
    public float huntSpeed = 5;
    public float huntLookDistance = 4;

    Path currentPath = new Path();
    Vector2 currentTarget = new Vector2();
    int currentTargetIdx = 1;
    bool canMove;
    bool seesPlayer, didSeePlayer;
    GameObject player;

    float currentSpeed, currentLookDistance;

    private void Start()
    {
        StartPath(Random.Range(0, pathCollection.paths.Count));
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void FixedUpdate()
    {
        if (mode == GhostMode.Chill)
        {
            currentLookDistance = lookDistance;
            currentSpeed = wanderSpeed;
        }
        else
        {
            currentLookDistance = huntLookDistance;
            currentSpeed = huntSpeed;
        }

        if (!canMove && !seesPlayer) return;

        if (player != null)
        {
            RaycastHit _hit;
            if (Physics.Raycast(transform.position, player.transform.position - transform.position, out _hit, currentLookDistance))
            {
                if (_hit.collider.gameObject == player)
                    seesPlayer = true;
                else
                    seesPlayer = false;
            }
            else
            {
                seesPlayer = false;
            }
        }

        if (seesPlayer)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, Time.fixedDeltaTime * currentSpeed);
            didSeePlayer = true;
        }
        else
            Wander();

        if (didSeePlayer && !seesPlayer)
        {
            canMove = false;
            didSeePlayer = false;
            Invoke("NewPath", respawnTime);
        }
    }

    void Wander()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentTarget, Time.fixedDeltaTime * currentSpeed);
        if (Vector2.Distance(transform.position, currentTarget) <= targetRadius)
            UpdateTarget();
    }


    void StartPath(int _idx)
    {
        currentPath = pathCollection.paths[_idx];
        transform.position = currentPath.path[0];
        canMove = true;
        UpdateTarget();
    }

    void NewPath()
    {
        currentTargetIdx = 1;
        currentPath = pathCollection.paths[Random.Range(0, pathCollection.paths.Count)];
        transform.position = currentPath.path[0];
        canMove = true;
        UpdateTarget();
    }

    void UpdateTarget()
    {
        if (currentTargetIdx == 0)
        {
            canMove = false;
            Invoke("NewPath", respawnTime);
        }

        currentTarget = currentPath.path[currentTargetIdx];
        currentTargetIdx++;
        if (currentTargetIdx >= currentPath.path.Count)
            currentTargetIdx = 0;
    }
}
