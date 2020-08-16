//--------------------------------------------------------------------
// 文件名	:   MainPanel
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
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GameLogic.Lua
{
	public class MainPanel : MonoBehaviour
	{
        public GameObject cameraObj;

        public GameObject leftObject;
		public Button leftButtonA;
		public Button leftButtonB;
		public Button leftButtonC;
        public Button leftClear;

        public GameObject rightObject;
        public Button rightButtonA;
		public Button rightButtonB;
		public Button rightButtonC;
        public Button rightClear;

        public Button playButton;

        public Text systemPromptTxt;

        public GameObject skillWindow;
        public Button skillBtnA;
        public Button skillBtnB;
        //public Button skillBtnC;
        //public Button skillBtnD;

        public GameObject messageObj;
        public Button buttonSure;
        public Button buttonCannel;
        public Text messageTxt;
        private System.Action<bool> m_mssageBoxAction;

        public Text roundText;

        public Text tipText;

        public Button restartGameBtn;

        private Unit m_selectedUnit;

        public static MainPanel Instance;

        /// <summary>
        /// 当前回合数
        /// </summary>
        public int round { get; set; } = 1;
        /// <summary>
        /// 当前回合第几步
        /// </summary>
        public int step { get; set; } = 0;

        private void Start()
        {
            Instance = this;

            leftButtonA.onClick.AddListener(OnClickLeftAButtonAHandler);
			leftButtonB.onClick.AddListener(OnClickLeftBButtonAHandler);
			leftButtonC.onClick.AddListener(OnClickLeftCButtonAHandler);
            leftClear.onClick.AddListener(() =>
            {
                PlayRightCamera();
                tipText.text = "右方请操作!";
                leftObject.SetActive(false);
                rightObject.SetActive(true);
                Map.Instance.Hide();
            });

            rightButtonA.onClick.AddListener(OnClickRightAButtonAHandler);
			rightButtonB.onClick.AddListener(OnClickRightBButtonAHandler);
			rightButtonC.onClick.AddListener(OnClickRightCButtonAHandler);
            rightClear.onClick.AddListener(() =>
            {
                PlayLeftCamera();
                tipText.text = "左方请操作!";
                leftObject.SetActive(true);
                rightObject.SetActive(false);
                Map.Instance.Hide();
            });

            buttonSure.onClick.AddListener(OnClickSureHandler);
            buttonCannel.onClick.AddListener(OnClickCannelHandler);

            playButton.onClick.AddListener(OnClickPlayHandler);

            skillBtnA.onClick.AddListener(OnClickSelectSkillAHandler);
            skillBtnB.onClick.AddListener(OnClickSelectSkillBHandler);
            //skillBtnC.onClick.AddListener(OnClickSelectSkillCHandler);
            //skillBtnD.onClick.AddListener(OnClickSelectSkillDHandler);

            restartGameBtn.onClick.AddListener(OnRestartGameHandler);

            API.GameEvent.Add(GameEvent.SystemTxt, OnRecivedSystemTxtHandler);
            API.GameEvent.Add(GameEvent.ShowSkillWindow,OnRecivedShowWindowHandler);
            API.GameEvent.Add(GameEvent.TASK_EXECUTE_FINISHED, OnRecivedTaskFinished);

            tipText.text = "左方请操作!";
            skillWindow.SetActive(false);
            messageObj.SetActive(false);
            systemPromptTxt.gameObject.SetActive(false);
            leftObject.SetActive(true);
            rightObject.SetActive(false);
        }

        /// <summary>
        /// 重启游戏
        /// </summary>
        private void OnRestartGameHandler()
        {
            SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        }

        /// <summary>
        /// 显示Skill 面板
        /// </summary>
        /// <param name="value"></param>
        private void OnRecivedShowWindowHandler(object value)
        {
            skillWindow.SetActive(true);

            Vector2Int skillPos = (Vector2Int)value;  //技能播放位置
        }

        /// <summary>
        /// 选择技能A
        /// </summary>
        private void OnClickSelectSkillAHandler()
        {
            skillWindow.SetActive(false);
            Debug.Log("OnClickSelectSkillAHandler");

            PlayerBase playerBase = m_selectedUnit.gameObject.GetComponent<PlayerBase>();
            playerBase.BeforePlayNormal();
            m_selectedUnit.PushTask(new SkillTask(playerBase, playerBase.curSkill));
        }

        /// <summary>
        /// 选择技能B
        /// </summary>
        private void OnClickSelectSkillBHandler()
        {
            skillWindow.SetActive(false);
            Debug.Log("OnClickSelectSkillBHandler");

            PlayerBase playerBase = m_selectedUnit.gameObject.GetComponent<PlayerBase>();
            playerBase.BeforePlaySkill1();
            m_selectedUnit.PushTask(new SkillTask(playerBase, playerBase.curSkill));

        }

        private void OnClickSelectSkillCHandler()
        {
            skillWindow.SetActive(false);
            Debug.Log("OnClickSelectSkillCHandler");

            PlayerBase playerBase = m_selectedUnit.gameObject.GetComponent<PlayerBase>();
            playerBase.BeforePlaySkill2();
            m_selectedUnit.PushTask(new SkillTask(playerBase, playerBase.curSkill));
        }
        private void OnClickSelectSkillDHandler()
        {
            skillWindow.SetActive(false);
            Debug.Log("OnClickSelectSkillDHandler");

            PlayerBase playerBase = m_selectedUnit.gameObject.GetComponent<PlayerBase>();
            playerBase.BeforePlaySkill3();
            m_selectedUnit.PushTask(new SkillTask(playerBase, playerBase.curSkill));
        }

        private void OnClickPlayHandler()
        {
            if (step == 3)
            {
                round++;
                step = 0;
            }

            step++;
            roundText.text = string.Format("R:{0} S:{1}", round, step);

            PlayCenterCamera().OnComplete(() =>
            {
                Map.Instance.Play();
            });
        }

        private void PlayLeftCamera()
        {
            cameraObj.transform.DOMove(new Vector3(3.08f, 22.13f, -6.3f), 1);
            cameraObj.transform.DORotate(new Vector3(63.29f, 32.89f, 0f), 1);
        }

        private void PlayRightCamera()
        {
            cameraObj.transform.DOMove(new Vector3(15.29f, 22.38f, -5.39f), 1);
            cameraObj.transform.DORotate(new Vector3(65.00f, -32.89f, 0f), 1);
        }

        private Tweener PlayCenterCamera()
        {
            cameraObj.transform.DOMove(new Vector3(10.0f, 22.13f, -6.3f), 1);
            return cameraObj.transform.DORotate(new Vector3(64.3f, 0.0f, 0f), 1);
        }

        private void OnRecivedTaskFinished(object value)
        {
            PlayCenterCamera();
        }

        public void ShowMessageBox(string txt,System.Action<bool> callback)
        {
            messageObj.SetActive(true);
            messageTxt.text = txt;
            m_mssageBoxAction = callback;
        }

        private void OnClickCannelHandler()
        {
            m_mssageBoxAction?.Invoke(false); 
            messageObj.SetActive(false);
        }

        private void OnClickSureHandler()
        {
            m_mssageBoxAction?.Invoke(true); 
            messageObj.SetActive(false);
        }

        private void OnRecivedSystemTxtHandler(object value)
        {
            systemPromptTxt.gameObject.SetActive(true);
            systemPromptTxt.text = value.ToString();
            Invoke("OnDelayTimeHandler",2);
        }

        private void OnDelayTimeHandler()
        {
            systemPromptTxt.gameObject.SetActive(false);
        }

        private void OnClickRightCButtonAHandler()
        {
            if (m_selectedUnit != null)
            {
                m_selectedUnit.UnSelected();
            }
            m_selectedUnit = Map.Instance.GetUnit(CampType.RIGHT.ToString() + "2");
            m_selectedUnit.Selected();
        }

        private void OnClickRightBButtonAHandler()
        {
            if (m_selectedUnit != null)
            {
                m_selectedUnit.UnSelected();
            }
            m_selectedUnit = Map.Instance.GetUnit(CampType.RIGHT.ToString() + "1");
            m_selectedUnit.Selected();
        }

        private void OnClickRightAButtonAHandler()
        {
            if (m_selectedUnit != null)
            {
                m_selectedUnit.UnSelected();
            }
            m_selectedUnit = Map.Instance.GetUnit(CampType.RIGHT.ToString() + "0");
            m_selectedUnit.Selected();
        }

        private void OnClickLeftCButtonAHandler()
        {
            if (m_selectedUnit != null)
            {
                m_selectedUnit.UnSelected();
            }
            m_selectedUnit = Map.Instance.GetUnit(CampType.LEFT.ToString() + "2");
            m_selectedUnit.Selected();
        }

        private void OnClickLeftBButtonAHandler()
        {
            if (m_selectedUnit != null)
            {
                m_selectedUnit.UnSelected();
            }
            m_selectedUnit = Map.Instance.GetUnit(CampType.LEFT.ToString() + "1");
            m_selectedUnit.Selected();
        }

        private void OnClickLeftAButtonAHandler()
        {
            if (m_selectedUnit != null)
            {
                m_selectedUnit.UnSelected();
            }
            m_selectedUnit = Map.Instance.GetUnit(CampType.LEFT.ToString() + "0");
            m_selectedUnit.Selected();
        }
    }
}