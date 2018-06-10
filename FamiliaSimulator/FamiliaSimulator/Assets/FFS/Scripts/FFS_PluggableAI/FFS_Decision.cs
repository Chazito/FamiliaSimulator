using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FFS_Decision : ScriptableObject {

    public abstract bool Decide(FFS_StateController controller);

}
