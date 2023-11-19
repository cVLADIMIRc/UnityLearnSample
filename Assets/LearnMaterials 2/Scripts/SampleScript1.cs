using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using static UnityEngine.ParticleSystem;

//��� ��� ������, ������� ������� ������. ��������� ������� �������� ��� SimpleScript<1,2,3,4> ��� ��������������� ����� ������������
public class SampleScript1 : SampleScriptBase
{
	[SerializeField]
	private Vector3 finishPosition;
	[ContextMenu("�����������")]
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
