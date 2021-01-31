using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public Animator anim;
    public LayerMask mask;

    Path currentPath = new Path();
    Vector2 currentTarget = new Vector2();
    int currentTargetIdx = 1;
    bool canMove = true;
    bool seesPlayer, didSeePlayer;
    GameObject player;

    float currentSpeed, currentLookDistance;
    float huntcounter = 0;

    private void OnEnable()
    {
        Ghost.onGhostDied += KillGhost;
        Ghost.onStartedHunt += StartHunt;
        Ghost.onStartedChilling += StartChill;
    }

    private void OnDisable()
    {
        Ghost.onGhostDied -= KillGhost;
        Ghost.onStartedHunt -= StartHunt;
        Ghost.onStartedChilling -= StartChill;
    }

    void KillGhost(float _time)
    {
        canMove = false;
        anim.SetTrigger("Wond");
        Invoke("TowWinScene", _time);
    }

    void StartChill()
    {
        mode = GhostMode.Chill;
    }

    void StartHunt()
    {
        mode = GhostMode.Hunt;
    }

    void ToWinScene()
    {
        SceneManager.LoadScene(3, LoadSceneMode.Single);
    }

    private void Start()
    {
        StartPath(Random.Range(0, pathCollection.paths.Count));
        player = GameObject.FindGameObjectWithTag("Detector");
    }

    void FixedUpdate()
    {
        if (mode == GhostMode.Chill)
        {
            anim.SetBool("Hunting", false);
            currentLookDistance = lookDistance;
            currentSpeed = wanderSpeed;
            huntcounter = 0;
        }
        else
        {
            anim.SetBool("Hunting", true);
            currentLookDistance = huntLookDistance;
            currentSpeed = huntSpeed;
            huntcounter += Time.fixedDeltaTime;

            if (huntcounter <= 30)
            {
                Ghost.Chill();
            }
        }

        if ((!canMove && !seesPlayer) || player == null || pathCollection.paths.Count == 0) { return; }

        if (player != null)
        {
            RaycastHit _hit;
            if (Physics.Raycast(transform.position, player.transform.position - transform.position, out _hit, currentLookDistance, mask))
            {
                Debug.DrawRay(transform.position, (player.transform.position - transform.position).normalized * _hit.distance);
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
            anim.SetTrigger("LostPlayer");
            mode = GhostMode.Chill;
            anim.SetBool("Hunting", false);
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
        if (_idx == 0) return;

        canMove = true;
        currentPath = pathCollection.paths[_idx];
        transform.position = currentPath.path[0];
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
