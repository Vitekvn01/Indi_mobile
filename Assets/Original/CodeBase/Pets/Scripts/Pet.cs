using Assets.Original.CodeBase.GatchaSysteam;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using Zenject;

public class Pet : MonoBehaviour
{
    [SerializeField] private ItemQuality itemQuality;
    [SerializeField] private Route route;
    [SerializeField] private float petSpeed;

    private int currentPoint = 0;

    private float standartSpeed;

    private Pet collisionPet;

    private bool startTimer;
    private float timer;

    private void Start()
    {
        standartSpeed = petSpeed;
    }

    public void SetQuality(ItemQuality quality)
    {
        itemQuality = quality;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.TryGetComponent<Pet>(out collisionPet))
        {
            if(collisionPet.getSpeed() == collisionPet.getStandartSpeed())
            {
                petSpeed -= 1;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //petSpeed = standartSpeed;
        startTimer = true;
    }

    public float getSpeed()
    {
        return petSpeed;
    }

    public float getStandartSpeed()
    {
        return standartSpeed;
    }

    private void Update()
    {
        timerCollision();
        moveProcess();
    }

    private void timerCollision()
    {
        if (startTimer)
        {
            timer += Time.deltaTime;

            if (timer > 2)
            {
                timer = 0;
                startTimer = false;
                petSpeed = standartSpeed;
            }
        }
    }

    private void moveProcess()
    {
        if (transform.position == route.getPoint(currentPoint).position)
        {
            if (currentPoint < route.checkCountPoints() - 1)
            {
                currentPoint++;
            }
            else
            {
                currentPoint = 0;
            }

        }

        transform.position = Vector3.MoveTowards(transform.position,route.getPoint(currentPoint).position, petSpeed * Time.deltaTime);
        transform.LookAt(route.getPoint(currentPoint).position);
    }
}
