using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static UnityEngine.ParticleSystem;

//Это мой скрипт, который двигает объект. Предлагаю скрипты называть так SimpleScript<1,2,3,4> под соответствующий номер расположения
public class SampleScript1 : SampleScriptBase
{
	[SerializeField]
	private Vector3 finishPosition;
	[ContextMenu("Переместить")]
	public void Use()
	{
		StartCoroutine(TimerCor());
	}
	IEnumerator TimerCor()
	{
		while (transform.position.x < finishPosition.x || transform.position.y < finishPosition.y || transform.position.z < finishPosition.z)
		{
			transform.position += finishPosition.normalized * Time.deltaTime;
			yield return new WaitForEndOfFrame();
		}
	}
	public void Start()
	{

	}
	public void Update()
	{

	}
}
