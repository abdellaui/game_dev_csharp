using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class FlyingEnemy : MonoBehaviour
{

    public GameObject wayPoints = default;
    [SerializeField] private List<Transform> childs = default;
    private Vector2 going = default;
    private int index = -1;
    // Start is called before the first frame update
    void Start()
    {
        wayPoints = GameObject.FindGameObjectWithTag("WayPoint");
        foreach (Transform child in wayPoints.transform)
        {
            childs.Add(child);
        }
        going = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (new Vector2(transform.position.x, transform.position.y).Equals(going))
        {

            if (childs.Count > 0 && ++index < childs.Count && index >= 0)
            {
                going = new Vector2(childs[index].position.x, childs[index].position.y);
            }
            else
            {   
                Destroy(gameObject);
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
