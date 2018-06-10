using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FFS_Action : ScriptableObject {

    public abstract void Act(FFS_StateController controller);
}
