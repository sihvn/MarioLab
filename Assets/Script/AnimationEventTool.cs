using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEventTool : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityEvent use;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TriggerEvent()
    {

        use.Invoke(); // safe to invoke even without callbacks

    }
}
