using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class FlyingEnemy : MonoBehaviour
{

    [SerializeField] GameObject parent = default;
    private GameObject[] childs = default;
    private Vector2 going = default;
    // Start is called before the first frame update
    void Start()
    {
        childs = parent.GetComponentsInChildren<GameObject>();
        Debug.Log(childs.Length);
        going = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        if (new Vector2(transform.position.x, transform.position.y).Equals(going))
        {

            if (childs.Length > 0)
            {
                going = new Vector2(childs[0].gameObject.transform.position.x, childs[0].gameObject.transform.position.y);
               childs.s
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
