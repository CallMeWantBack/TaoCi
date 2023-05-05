/************************************************************
  Copyright (C), 2018, EDONG AI. Co., Ltd.
  FileName: QuestionManager.cs
  Author:李荣彩       Version :1.0          Date: 2019-8-6
  Description:NeedInput
************************************************************/
using System.Collections.Generic;
using UnityEngine;



/// <summary>
/// 正确选项
/// </summary>
public enum Option
{
    None,
    A,
    B,
    C,
    D,
    E,
    F
}

namespace PicklePro
{
    /// <summary>
    /// QuestionManager
    /// </summary>
    public class QuestionManager
    {

        private static QuestionManager _instance;

        public static QuestionManager GetInstance()
        {
            return _instance ?? (_instance = new QuestionManager());
        }

        private int _questionIndex;
        public int QuestionIndex
        {
            get
            {
                return _questionIndex;
            }

            set
            {
                _questionIndex = value;
            }
        }

        public List<ChooseQuestion> chooseQuestionList;

        public List<ChooseQuestionGroup> chooseQuestionGroupList;

        private QuestionManager()
        {
            _questionIndex = 0;
            chooseQuestionList = new List<ChooseQuestion>();
            chooseQuestionGroupList = new List<ChooseQuestionGroup>();
        }


    }

    /// <summary>
    /// 选择题组
    /// </summary>
    public class ChooseQuestionGroup
    {
        private int _index;
        /// <summary>
        /// 问题序号
        /// </summary>
        public int Index
        {
            get
            {
                return _index;
            }

            set
            {
                _index = value;
            }
        }

        private string _tottleTittle;
        /// <summary>
        /// 总标题
        /// </summary>
        public string TottleTittle
        {
            get
            {
                return _tottleTittle;
            }

            set
            {
                _tottleTittle = value;
            }
        }

        private GameObject _currentPanel;
        /// <summary>
        /// 选择题面板
        /// </summary>
        public GameObject CurrentPanel
        {
            get
            {
                return _currentPanel;
            }

            set
            {
                _currentPanel = value;
            }
        }

        /// <summary>
        /// 选择题面板所含有的任何组件
        /// </summary>
        public Component CurrentPanelCP { get; private set; }

        /// <summary>
        /// 选择题目列表
        /// </summary>
        public readonly List<ChooseQuestion> chooseQuestionList;


        private ChooseQuestionGroup()
        {
            _index = 0;
            _tottleTittle = "";
            _currentPanel = new GameObject();
            CurrentPanelCP = new Component();
        }

        /// <summary>
        /// 选择题组
        /// </summary>
        /// <param name="index">序号</param>
        /// <param name="tottleTittle">大标题</param>
        /// <param name="currentPanel">当前题目面板</param>
        /// <param name="_chooseQuestionList"></param>
        public ChooseQuestionGroup(int index, string tottleTittle, GameObject currentPanel, List<ChooseQuestion> _chooseQuestionList)
        {
            this._index = index;
            this._tottleTittle = tottleTittle;
            this._currentPanel = currentPanel;
            chooseQuestionList = _chooseQuestionList;
        }

        /// <summary>
        /// 选择题组
        /// </summary>
        /// <param name="index"></param>
        /// <param name="tottleTittle"></param>
        /// <param name="currentPanelCp"></param>
        /// <param name="_chooseQuestionList"></param>
        public ChooseQuestionGroup(int index, string tottleTittle, Component currentPanelCp, List<ChooseQuestion> _chooseQuestionList)
        {
            this._index = index;
            this._tottleTittle = tottleTittle;
            CurrentPanelCP = currentPanelCp;
            chooseQuestionList = _chooseQuestionList;
        }
    }

    /// <summary>
    /// 单个选择题
    /// </summary>
    public class ChooseQuestion
    {
        private int _index;


        /// <summary>
        /// 问题序号
        /// </summary>
        public int Index
        {
            get
            {
                return _index;
            }

            set
            {
                _index = value;
            }
        }

        /// <summary>
        /// 问题或标题
        /// </summary>
        public string Tittle { get; private set; }

        /// <summary>
        /// 选项描述
        /// </summary>
        public List<string> OptionsDescription { get; private set; }

        /// <summary>
        /// 分值
        /// </summary>
        public float Value { get; private set; }

        /// <summary>
        /// 正确答案
        /// </summary>
        public Option Result { get; private set; }


        private ChooseQuestion()
        {
            _index = 0;
            Tittle = "";
            OptionsDescription = new List<string>();
            Value = 0;
            Result = Option.None;
        }

        /// <summary>
        /// 选择题题目
        /// </summary>
        /// <param name="index">序号</param>
        /// <param name="tittle">标题（若有标题和详细描述，用‘|’隔开；例如：标题|描述）</param>
        /// <param name="options">选项详情</param>
        /// <param name="value">分值</param>
        /// <param name="result">答案</param>
        public ChooseQuestion(int index, string tittle, List<string> options, float value, Option result)
        {
            this._index = index;
            this.Tittle = tittle;
            this.OptionsDescription = options;
            this.Value = value;
            this.Result = result;
        }

    }
}