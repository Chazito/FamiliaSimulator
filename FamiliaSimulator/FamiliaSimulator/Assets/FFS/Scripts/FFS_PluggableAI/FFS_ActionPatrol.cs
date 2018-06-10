using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PluggableAI/Actions/Patrol")]
public class FFS_ActionPatrol : FFS_Action {
    

    public override void Act(FFS_StateController controller)
    {
        Patrol(controller);
    }

    private void Patrol(FFS_StateController controller)
    {
        float step = controller.enemyStats.speed.GetValue() * Time.deltaTime;
        controller.transformComponent.position = Vector2.MoveTowards(controller.transformComponent.position, controller.waypointList[controller.nextWaypoint].position, step);

        float distanceToPoint = Vector2.Distance(controller.transformComponent.position, controller.waypointList[controller.nextWaypoint].position);
        if(distanceToPoint <= step)
        {
            controller.nextWaypoint = (controller.nextWaypoint + 1) % controller.waypointList.Count;
        }
    }

}
