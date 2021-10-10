using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.StateMachines;
using UnityEngine;

namespace UdemyProject3.StateMachines
{
    public class StateTransition
    {
        IState _from;
        IState _to;
        System.Func<bool> _condition;

        public IState From => _from;
        public IState To => _to;
        public System.Func<bool> Condition => _condition;

        public StateTransition(IState from,IState to, System.Func<bool> condition)
        {
            _from = from;
            _to = to;
            _condition = condition;
        }
    }
}