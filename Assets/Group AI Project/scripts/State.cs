﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State {

    protected GameBabyStateController stateController;
    //constructor
    public State(GameBabyStateController stateController)
    {
        this.stateController = stateController;
    }
    public abstract void CheckTransitions();

    public abstract void Act();

    public virtual void OnStateEnter() { }

    public virtual void OnStateExit() { }



	
}
