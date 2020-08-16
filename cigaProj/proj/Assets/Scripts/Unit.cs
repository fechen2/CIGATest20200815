//--------------------------------------------------------------------
// 文件名	:   Unit
// 内  容	:   
// 说  明	:   
// 创建日期	:   #CREATIONDATE#
// 创建人	:	#SMARTDEVELOPERS#
// 版权所有	:   
//--------------------------------------------------------------------

using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace GameLogic.Lua
{
	public enum TaskType
	{
		None,
		Move,
		Attack,
		Skill,
	}

	public enum UnitType
	{
		None,
		Original,
		Clone,
	}

	public class Unit : MonoBehaviour
	{
		public Button refButton;
		public int index;

		public UnitType unitType = UnitType.Original;

		public Vector2Int curPos { get; private set; }

		public bool isMoving { get; private set; }

		private int m_index = 0;

		private System.Action m_action;

		public float speed = 5;

		public CampType campType;

		public string uniqueId { get; set; }

		private Renderer m_renderer;

		//private object m_taskParam;
		//private TaskType m_taskType;
		private bool m_isCompeteSetTask;
		public bool isCompleteTask { get { return !m_isCompeteSetTask; } }

		private Color m_originalColor;

		public int ability = 3;

		public bool selected { get; private set; }

		private Queue<Task> m_taskQueues;
		public Queue<Task> taskQueues 
		{ 
			get 
			{
				if (unitType != UnitType.Clone)
				{
					return m_taskQueues;
				}
				return parentUnit.m_taskQueues;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		public Unit parentUnit { get; set; }



		private List<Unit> m_childrenUnits = new List<Unit>();

		public List<Unit> childrenUnits 
		{ 
			get
			{
				if (unitType != UnitType.Clone)
				{
					return m_childrenUnits;
				}
				return parentUnit.childrenUnits;
			}
		}

		public void AddChild(Unit unit)
		{
			childrenUnits.Add(unit);
		}

		public void Init(Vector2Int pos)
		{
			m_taskQueues = new Queue<Task>(3);
			curPos = pos;
			m_renderer = GetComponent<Renderer>();
			m_originalColor = m_renderer.material.color;
		}

		public bool PushTask(Task task)
		{
			if (unitType != UnitType.Clone)
			{
				if (!m_isCompeteSetTask)
				{
					m_taskQueues.Enqueue(task);

					task.index = m_taskQueues.Count;
					task.ShowSimulation();

					if (m_taskQueues.Count >= ability)
					{
						m_isCompeteSetTask = true;
						return m_isCompeteSetTask;
					}
				}
				return false;
			}
			else
			{
				if (parentUnit != null)
					return parentUnit.PushTask(task);
				else
					return true;
			}
		}

		public void Selected()
		{
			if (!m_isCompeteSetTask)
			{
				selected = true;
				m_renderer.material.DOColor(Color.yellow, 0.5f).SetLoops(-1, LoopType.Yoyo);
				ShowGrid(ability);
			}
		}

		public void UnSelected()
		{
			if (!m_isCompeteSetTask)
			{
				selected = false;
				m_renderer.material.DOKill();
				m_renderer.material.color = m_originalColor;
				HideGrid(ability);
			}
		}

		//public void SetTask(TaskType taskType,object param)
		//{
		//	//m_taskType = taskType;
		//	//m_taskParam = param;

		//	gameObject.SetColor(Color.green);
		//	m_isCompeteSetTask = true;
		//}

		public void Play(System.Action action)
		{
			if (m_taskQueues.Count > 0)
			{
				Task task = m_taskQueues.Dequeue();
				task.Play(() =>
				{
					Play(action);
				});
			}
			else
			{
				//m_taskType = TaskType.None;
				curPos = transform.position.ToVector2Int();
				m_isCompeteSetTask = false;
				gameObject.SetColor(m_originalColor);
				action?.Invoke();
				//Debug.LogError("Task Queue Finished.");
			}
		}

		public void ShowGrid(int ability)
		{
			Map.Instance.ShowGrid(this);
		}

		public void HideGrid(int ability)
		{
			Map.Instance.HideGrid(this);
		}
	}
}