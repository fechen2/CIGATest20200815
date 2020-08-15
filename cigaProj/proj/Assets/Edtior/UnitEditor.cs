//--------------------------------------------------------------------
// 文件名	:   UnitEditor
// 内  容	:   
// 说  明	:   
// 创建日期	:   #CREATIONDATE#
// 创建人	:	#SMARTDEVELOPERS#
// 版权所有	:   
//--------------------------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace GameLogic.Lua
{
	[CustomEditor(typeof(Unit))]
	public class UnitEditor : Editor
	{
        private Unit m_unit;

        private int m_abiblity = 2;

        private Vector2Int m_targetPos;

        private void OnEnable()
        {
            m_unit = target as Unit;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            m_abiblity = EditorGUILayout.IntField("abiblity", m_abiblity);
            if (GUILayout.Button("Show"))
            {
                m_unit.ShowGrid(m_abiblity);
            }
            if (GUILayout.Button("Hide"))
            {
                m_unit.HideGrid(m_abiblity);
            }

            m_targetPos = EditorGUILayout.Vector2IntField("targetPos", m_targetPos);
            if (GUILayout.Button("Move"))
            {
                //Vector2Int[] vector2Ints = Map.Instance.Find(m_unit.curPos,m_targetPos);
                //m_unit.SetDestination(vector2Ints,()=> {
                //    Debug.LogError("Move End!");
                //});
            }
        }
    }
}