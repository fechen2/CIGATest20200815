//--------------------------------------------------------------------
// 文件名	:   Map
// 内  容	:   
// 说  明	:   
// 创建日期	:   #CREATIONDATE#
// 创建人	:	#SMARTDEVELOPERS#
// 版权所有	:   
//--------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

namespace GameLogic.Lua
{
	public enum CampType
	{
		LEFT,
		RIGHT,
	}

	class Tile
	{
		public GameObject gameObject;
		public Vector2Int position;
	}

	public class Map : MonoBehaviour
	{
		public Camera mainCamera;

		public Vector2Int sceneSize = new Vector2Int(20,10);

		public GameObject greyBox;

		public GameObject blackBox;

		public GameObject bluePlayerPrefab;

		public GameObject redPlayerPrefab;

		private Grid2D<Tile> m_grid;

		private DungeonPathfinder2D m_aStar;

		private GameObject m_angent;

		private Move m_move;

		public Dictionary<string , Unit> m_units;

		//public UnityEngine.AI.NavMeshSurface navMeshSurface;

		//private NavMeshAgent m_navMeshAgent;

		//private void OnGUI()
		//      {
		//	if (GUILayout.Button("Generater"))
		//	{
		//		m_grid = new Grid2D<CellType>(sceneSize, Vector2Int.zero);

		//		m_aStar = new DungeonPathfinder2D(sceneSize);

		//		Generater();

		//		GeneraterRole();
		//	}
		//      }

		public static Map Instance;

        private void Awake()
        {
			Instance = this;
        }

		private void Start()
		{
			Vector2Int[] blueCamps = new Vector2Int[] { new Vector2Int(1, 7), new Vector2Int(1, 5), new Vector2Int(1, 3) };
			Vector2Int[] redCamps = new Vector2Int[] { new Vector2Int(18, 7), new Vector2Int(18, 5), new Vector2Int(18, 3) };

			Show(sceneSize, blueCamps, redCamps);
		}

		public Unit GetUnit(string key)
		{
			if (m_units.TryGetValue(key, out Unit unit))
			{
				return unit;
			}
			return null;
		}

		public void Show(Vector2Int mapSize , Vector2Int[] blueCamp , Vector2Int[] redCamp)
		{
			m_units = new Dictionary<string, Unit>();
			m_grid = new Grid2D<Tile>(mapSize, Vector2Int.zero);

			m_aStar = new DungeonPathfinder2D(mapSize);

			Generater();

			GeneraterRole(blueCamp, redCamp);
		}

		public void Play()
		{
			foreach (var item in m_units)
			{
				item.Value.Play();
			}
		}

		public int GetIndex(Vector2Int pos)
		{
			return pos.x + (sceneSize.x * pos.y);
		}

		/// <summary>
		/// 生成角色
		/// </summary>
		private void GeneraterRole(Vector2Int[] blueCamps, Vector2Int[] redCamps)
		{
			for (int i = 0; i < blueCamps.Length; i++)
			{
				m_angent = GameObject.Instantiate(bluePlayerPrefab);
				m_angent.transform.position = blueCamps[i].ToVector3(1.5f);
				Unit unit = m_angent.GetComponent<Unit>();
				unit.Init(blueCamps[i]);
				unit.index = GetIndex(blueCamps[i]);
				unit.campType = CampType.LEFT;
				unit.uniqueId = (CampType.LEFT.ToString() + i.ToString());
				m_units.Add(unit.uniqueId, unit);
			}

			for (int i = 0; i < redCamps.Length; i++)
			{
				m_angent = GameObject.Instantiate(redPlayerPrefab);
				m_angent.transform.position = redCamps[i].ToVector3(1.5f);
				Unit unit = m_angent.GetComponent<Unit>();
				unit.Init(redCamps[i]);
				unit.index = GetIndex(redCamps[i]);
				unit.campType = CampType.RIGHT;
				unit.uniqueId = (CampType.RIGHT.ToString() + i.ToString());
				m_units.Add(unit.uniqueId, unit);
			}

			//Vector2Int center = new Vector2Int(Mathf.RoundToInt(vector3.x), Mathf.RoundToInt(vector3.z));
			//Vector2Int range = new Vector2Int(3, 3);
			//RectInt rectInt = new RectInt(center, range);
			////rectInt.SetMinMax(center - range, center + range);


		}

		public Vector2Int[] Find(Vector2Int start, Vector2Int end)
		{
			List<Vector2Int> vector2Ints = m_aStar.FindPath(start, end, OnCalculatePathCostHandler);
			return vector2Ints.ToArray();
		}

		public void HideGrid(Unit unit)
		{
			Vector2Int[] vector2s = GetIndexs(unit.curPos, new Vector2Int(unit.ability, unit.ability), 3);
			foreach (var item in vector2s)
			{
				SetBoxColor(item, UnityEngine.Color.clear);
			}
		}

		private bool CheckMove(Unit unit,Vector2Int target)
		{
			Vector2Int[] vector2s = GetIndexs(unit.curPos, new Vector2Int(unit.ability, unit.ability), unit.ability);

			for (int i = 0; i < vector2s.Length; i++)
			{
				if (vector2s[i] == target)
				{
					return true;
				}
			}
			return false;
		}

		public void ShowGrid(Unit unit)
		{
			ShowGrid(unit.curPos, unit.ability);
		}

		public void ShowGrid(Vector2Int center, int ability)
		{
			Vector2Int[] vector2s = GetIndexs(center, new Vector2Int(ability, ability), ability);
			foreach (var item in vector2s)
			{
				SetBoxColor(item, UnityEngine.Color.yellow);
			}
		}

		private Vector2Int[] GetIndexs(Vector2Int center , Vector2Int size , int abiblity)
		{
			List<Vector2Int> vector2s = new List<Vector2Int>();
			for (int i = -size.x; i <= size.x; i++)
			{
				for (int j = -size.y; j <= size.y; j++)
				{
					if (Mathf.Abs(i) + Mathf.Abs(j) <= abiblity)
					{
						vector2s.Add(center + new Vector2Int(i, j));
					}
				}
			}
			return vector2s.ToArray();
		}

        private void Generater()
		{
			for (int i = 0; i < sceneSize.x; i++)
			{
				for (int j = 0; j < sceneSize.y; j++)
				{
					if (0 != (i & 1))//奇
					{
						if (0 != (j & 1))//奇
						{
							DrawGreyBox(i, j);
						}
						else
						{
							DrawBlackBox(i, j);
						}
					}
					else
					{
						if (0 != (j & 1))//奇
						{
							DrawBlackBox(i, j);
						}
						else
						{
							DrawGreyBox(i, j);
						}
					}
				}
			}

			//navMeshSurface.BuildNavMesh();
		}


		private void DrawBlackBox(int x, int y)
		{
		    Vector3 pos = new Vector3(x, 0, y);
			GameObject box = GameObject.Instantiate(blackBox);
			box.transform.position = pos;
			box.transform.SetParent(transform);
			m_grid[x, y] = new Tile() { position = new Vector2Int(x, y), gameObject = box };
		}

		private void DrawGreyBox(int x, int y)
		{
			Vector3 pos = new Vector3(x, 0, y);
			GameObject box = GameObject.Instantiate(greyBox);
			box.transform.position = pos;
			box.transform.SetParent(transform);
			m_grid[x, y] = new Tile() { position = new Vector2Int(x, y), gameObject = box };
		}

        private void Update()
        {
			
            if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
            {
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit raycastHit, 1000, 1 << LayerMask.NameToLayer("Tile")))
                {
                    Vector3 click = raycastHit.point;
                    GameObject gameObject = raycastHit.collider.gameObject;
                    int layer = gameObject.layer;

                    if (LayerMask.LayerToName(layer) == "Tile")
                    {
						Unit selectedUnit = null;
						foreach (var item in m_units)
						{
							if (item.Value.selected)
							{
								selectedUnit = item.Value;
								break;
							}
						}

						if (selectedUnit != null)
						{
							Vector2Int target = click.ToVector2Int();
							if (CheckMove(selectedUnit, target))
							{
								List<Vector2Int> paths = m_aStar.FindPath(selectedUnit.curPos, target, OnCalculatePathCostHandler);

								for (int i = 0; i < paths.Count; i++)
								{
									SetBoxColor(paths[i], UnityEngine.Color.green);
								}

								MainPanel.Instance.ShowMessageBox("确定行走吗?" , (value)=> 
								{
									if (value)
									{
										selectedUnit.UnSelected();
										selectedUnit.SetTask(TaskType.Move, paths.ToArray());
										//selectedUnit.Play();
									}
								});
							}
							else
							{
								API.GameEvent.Send(GameEvent.SystemTxt, "当前路径无法移动");
							}
						}
                    }

                    //else if (LayerMask.LayerToName(layer) == "Unit")
                    //{
                        //Unit unit = gameObject.GetComponent<Unit>();
                        //Vector2Int[] vector2s = Range.GetRange(unit.rangeType);
                        //for (int i = 0; i < vector2s.Length; i++)
                        //{
                        //    if (m_grid.InBounds(vector2s[i]))
                        //    {
                        //        SetBoxColor(vector2s[i], UnityEngine.Color.red);
                        //    }
                        //}
                    //}
                }
            }
        }

        private DungeonPathfinder2D.PathCost OnCalculatePathCostHandler(DungeonPathfinder2D.Node arg1, DungeonPathfinder2D.Node arg2)
        {
			var pathCost = new DungeonPathfinder2D.PathCost
			{
				cost = 1    //heuristic
			};
			pathCost.traversable = true;

			return pathCost;
		}


		private void SetBoxColor(Vector2Int vector2Int, UnityEngine.Color color)
		{
			if (m_grid.InBounds(vector2Int))
			{
				GameObject gameObject = m_grid[vector2Int.x, vector2Int.y].gameObject;
				gameObject.SetColor(color);
			}
		}

		private DungeonPathfinder2D.PathCost OnCalculatePathCostHandler(DungeonPathfinder2D.Node a, DungeonPathfinder2D.Node b, Vector2Int end)
		{
			var pathCost = new DungeonPathfinder2D.PathCost
			{
				cost = 1    //heuristic
			};

			//CellType type = m_grid[b.position];
			//if (type == CellType.Hallway)
			//{
			//	pathCost.cost += 100;
			//}
			//else if (type == CellType.Side)
			//{
			//	pathCost.cost += 50;
			//}
			pathCost.traversable = true;

			return pathCost;
		}
	}
}

public static class Extends
{
	public static Vector2Int ToVector2Int(this Vector3 vector3)
	{
		return new Vector2Int(Mathf.RoundToInt(vector3.x), Mathf.RoundToInt(vector3.z));
	}

	public static Vector3 ToVector3(this Vector2Int vector2Int)
	{
		return new Vector3(vector2Int.x,0,vector2Int.y);
	}
	public static Vector3 ToVector3(this Vector2Int vector2Int,float y)
	{
		return new Vector3(vector2Int.x, y, vector2Int.y);
	}

	public static void SetColor(this GameObject gameObject, Color color)
	{
		Renderer renderer = gameObject.GetComponent<Renderer>();
		renderer.material.color = color;
	}
}