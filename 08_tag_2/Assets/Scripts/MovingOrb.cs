using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingOrb : MonoBehaviour
{
    public List<Transform> wayPoints = default;
    public GameObject wayPointsParent = default;

    private Vector2 going = default;
    private int index = -1;
    // Start is called before the first frame update
    void Start()
    {
        wayPointsParent = GameObject.FindGameObjectWithTag("WayPoint");
        foreach (Transform child in wayPointsParent.transform)
        {
            wayPoints.Add(child);
        }
        going = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (new Vector2(transform.position.x, transform.position.y).Equals(going))
        {
            index = Random.Range(0, wayPoints.Count-1);
            if (wayPoints.Count > 0 && index < wayPoints.Count && index >= 0)
            {
                going = new Vector2(wayPoints[index].position.x, wayPoints[index].position.y);
            }
        }
        else
        {
            float step = 2f * Time.deltaTime;
            Vector2 pos = Vector2.MoveTowards(transform.position, going, step);
            transform.position = pos;
        }
    }
}
