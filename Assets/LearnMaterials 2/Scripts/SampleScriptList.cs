using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Этот скрипт позволит активировать Use() у всех объектов
//В LearnScene2 есть "All", у него есть компонент(скрипт) SampleScriptList
//В список добавьте свой объект, на место Element(можно просто из иерархии мышкой перенести в список), который реализует ваш скрипт, который в свою очередь, наследуется от SimpleScriptBase
//Для активации всех Use(), добавлено контекстное меню "Активировать все Use()" (жмакаете три вертикальные точки рядом с компонентом скрипта SampleScriptList в инспекторе)
public class SampleScriptList : SampleScriptBase
{
    public List<SampleScriptBase> listScript = new List<SampleScriptBase>();
    [ContextMenu("Активировать все Use()")]
    public void Use()
    {
        foreach (var script in listScript)
        {
			//Сюда добавьте ваш скрипт, как ниже
			//if (script is SampleScript1 scr)
			//{
			//	scr.Use();
			//}
			//if (script is SampleScript2 scr)
			//{
			//	scr.Use();
			//}
            //И т.д.
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
