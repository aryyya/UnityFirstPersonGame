using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    public float speed = 3.0f;
    public float obstacleRange = 5.0f;

    private bool _alive;
    private GameObject _fireball;
    [SerializeField] private GameObject _fireballPrefab;

    void Start()
    {
        _alive = true;
    }

    void Update()
    {
        if (_alive)
        {
            Wander();
        }
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }

    private void Wander()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.SphereCast(ray, 0.75f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerCharacter>())
            {
                if (_fireball == null)
                {
                    _fireball = Instantiate(_fireballPrefab) as GameObject;
                    _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    _fireball.transform.rotation = transform.rotation;
                }
            }
            else if (hit.distance < obstacleRange)
            {
                float angle = Random.Range(-90, +90);
                transform.Rotate(0, angle, 0);
            }
            else
            {
                transform.Translate(0, 0, speed * Time.deltaTime);
            }
        }
    }
}
