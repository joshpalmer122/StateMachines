using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GBWanderState : State
{


    public GBWanderState(GameBabyStateController stateController) : base(stateController) { }

    float timeLimit;
    float timer;
    public override void CheckTransitions()
    {
        if (stateController.CheckIfInRange("Player"))
        {
            stateController.SetState(new GBChaseState(stateController));
        }
        if (timer > timeLimit)
        {
            if (Random.value < .5)
            {
                stateController.SetState(new GBMakeNavPoints(stateController));
            }
            else
            {
                stateController.SetState(new GBCryState(stateController));
            }
        }

    }
    public override void Act()
    {
        timer += Time.deltaTime;
        if (stateController.destination == null || stateController.ai.DestinationReached())
        {
            stateController.destination = stateController.GetWanderPoint();
            stateController.ai.SetTarget(stateController.destination);
        }
    }
    public override void OnStateEnter()
    {
        timer = 0f;
        timeLimit = 5f;
        stateController.destination = stateController.GetWanderPoint();
        if (stateController.ai.agent != null)
        {
            stateController.ai.agent.speed = .2f;
        }
        stateController.ai.SetTarget(stateController.destination);
        stateController.ChangeColor(Color.cyan);
    }
}