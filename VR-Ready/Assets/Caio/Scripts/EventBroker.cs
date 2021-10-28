using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class EventBroker
{
    public static event Action Trigger;

	public static void CallTriggerEvent()
	{
		Trigger?.Invoke();
	}

	public static event Action Grip;

	public static void CallGripEvent()
	{
		Grip?.Invoke();
	}
}