using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//���� ������ �������� ������������ Use() � ���� ��������
//� LearnScene2 ���� "All", � ���� ���� ���������(������) SampleScriptList
//� ������ �������� ���� ������, �� ����� Element(����� ������ �� �������� ������ ��������� � ������), ������� ��������� ��� ������, ������� � ���� �������, ����������� �� SimpleScriptBase
//��� ��������� ���� Use(), ��������� ����������� ���� "������������ ��� Use()" (�������� ��� ������������ ����� ����� � ����������� ������� SampleScriptList � ����������)
public class SampleScriptList : SampleScriptBase
{
    public List<SampleScriptBase> listScript = new List<SampleScriptBase>();
    [ContextMenu("������������ ��� Use()")]
    public void Use()
    {
        foreach (var script in listScript)
        {
			//���� �������� ��� ������, ��� ����
			//if (script is SampleScript1 scr)
			//{
			//	scr.Use();
			//}
			//if (script is SampleScript2 scr)
			//{
			//	scr.Use();
			//}
            //� �.�.
			if (script is SampleScript1 scr)
            {
                scr.Use();
            }
        }
    }
    void Start()
    {
        
    }
	private void Update()
	{
		
	}
}
