using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "PluggableAI/State")]
public class FFS_State : ScriptableObject {

    public FFS_Action[] actions;
    public FFS_Transition[] transitions;


    public void UpdateState(FFS_StateController controller)
    {
        DoActions(controller);
        CheckTransitions(controller);
    }
	
    private void DoActions(FFS_StateController controller)
    {
        for(int i = 0; i < actions.Length; i++)
        {
            actions[i].Act(controller);
        }
    }

    private void CheckTransitions(FFS_StateController controller)
    {
        for(int i = 0; i < transitions.Length; i++)
        {
            bool decisionSucceded = transitions[i].decision.Decide(controller);

            if (decisionSucceded)
            {
                controller.TransitionToState(transitions[i].trueState);
            }
            else
            {
                controller.TransitionToState(transitions[i].falseState);
            }
        }
    }
}
