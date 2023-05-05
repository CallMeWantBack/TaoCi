using Doozy.Engine.UI;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class AnswerQuestion : MonoBehaviour
    {
        public GameObject QuestionPrefab;
        [Header("题库名")]
        private string QuestionListName;

        public int TopicCount;


        [Header("是否随机")]
        public bool IsRandom;

        [Header("抽取题目的数量")]
        [Range(1, 30)]


        private string[] _perLineData;
        /// <summary>
        /// 创建二维不规则数组，因选项可能3个或4个，所以创建不规则数组
        /// </summary>
        private string[][] _questionsArray;
        /// <summary>
        /// 记录题目是否已经回答
        /// </summary>
        private readonly List<bool> IsAnswer = new List<bool>();
        /// <summary>
        /// 记录选择过的序号
        /// </summary>
        private readonly List<int> SelectAnswerIndex = new List<int>();
        /// <summary>
        /// 记录选择的是否正确
        /// </summary>
        private readonly List<bool> SelectIsRight = new List<bool>();
        /// <summary>
        /// 选择键
        /// </summary>
        public List<Toggle> SelecToggles;
        /// <summary>
        /// 选项
        /// </summary>
        public List<TextMeshProUGUI> SelecAnswer;

        public List<GameObject> QuestionAll = new List<GameObject>();
        public Button CheckButton;

        /// <summary>
        /// 下一题按钮
        /// </summary>
        private Button _nextTopicBtn;
        /// <summary>
        /// 错误提示按钮
        /// </summary>
        private Button _tipsBtn;
        /// <summary>
        /// 正确答案提示
        /// </summary>
        private TextMeshProUGUI _tipCorrectText;
        /// <summary>
        /// 题目序号
        /// </summary>
        private TextMeshProUGUI _quesIndexText;
        /// <summary>
        /// 题目内容
        /// </summary>
        private TextMeshProUGUI _quesContent;
        /// <summary>
        /// 正确率显示
        /// </summary>
        private TextMeshProUGUI _accuracyText;
        /// <summary>
        /// 第几题
        /// </summary>
        private int _quesIndex = 0;
        /// <summary>
        /// 题目总数量
        /// </summary>
        private int _quesCount;
        /// <summary>
        /// 回答正确的数量
        /// </summary>
        private int _rightCount;
        /// <summary>
        /// 已经回答的题目数量
        /// </summary>
        private int _answeredCount;

        public int GradeCount;

        void Start()
        {
            CsvReadQuestions();
            topicbushu();
            CheckButton.onClick.AddListener(Check);
        }

        public void Check()
        {
            foreach (var child in QuestionAll)
            {
                for (int i = 0; i < child.transform.GetChild(0).GetChild(1).childCount; i++)
                {
                    child.transform.GetChild(0).GetChild(1).GetChild(i).GetComponent<Toggle>().interactable = false;
                }
                child.transform.GetChild(1).gameObject.SetActive(true);
            }

            CheckButton.interactable = false;
        }
        /// <summary>
        /// 显示UI
        /// </summary>
        public void topicbushu()
        {
            for (int i = 0; i < _questionsArray.Length; i++)
            {
                int currentcount = i;
                GameObject newQuestion = Instantiate(QuestionPrefab, Vector3.zero, Quaternion.identity, QuestionPrefab.transform.parent);
                newQuestion.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = _questionsArray[i][1];
                List<UIToggle> SelecToggless = new List<UIToggle>();
                List<TextMeshProUGUI> SelecAnswerr = new List<TextMeshProUGUI>();
                for (int m = 0; m < 4; m++)
                {
                    SelecToggless.Add(newQuestion.transform.GetChild(0).GetChild(1).transform.GetChild(m).GetComponent<UIToggle>());
                    SelecAnswerr.Add(SelecToggless[m].transform.GetChild(1).GetComponent<TextMeshProUGUI>());
                }
                for (int k = 0; k < 4; k++)
                    SelecToggless[k].IsOn = false;//开始时所有的选择默认为未选
                int selectCount = _questionsArray[i].Length - 3;//有多少选项  减去3个分别是：序号、题目、正确答案标识
                for (int j = 0; j < selectCount; j++)
                {
                    SelecToggless[j].gameObject.SetActive(true);
                    SelecAnswerr[j].text = _questionsArray[i][j + 2];//设置题目的选项。从第三位开始
                }
                if (selectCount < SelecToggless.Count)//判断选项是否有4个，如果没有则隐藏多余的
                {
                    for (int n = selectCount; n < SelecToggless.Count; n++)
                        SelecToggless[n].gameObject.SetActive(false);
                }
                newQuestion.SetActive(true);
                for (int o = 0; o < 4; o++)
                {
                    int count = o;
                    SelecToggless[o].OnValueChanged.AddListener(delegate (bool isOn)
                    {
                        if (isOn)
                        {
                            bool isRight = false;
                            int selectCountt = 0;
                            for (int l = 0; l < 4; l++)
                            {
                                if (l == count)
                                {
                                    SelecToggless[l].IsOn = true;
                                    int index = _questionsArray[currentcount].Length - 1;//该二位数组的长度，减1获得最后一位的序号

                                    int correctIndex = int.Parse(_questionsArray[currentcount][index]) - 1;//ArrayX[topicIndex][idx]获取到最后一位的正确答案标识，答案序号是0123，所以减1

                                    if (l == correctIndex)
                                    {
                                        newQuestion.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "<color=#00FF61FF>解析    恭喜你，回答正确！";
                                        isRight = true;

                                        GradeCount += 2;
                                    }
                                    else
                                    {

                                        newQuestion.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "<color=#FF0000FF>解析     对不起，回答错误！正确答案为" + JudgeCorrectAnswer2(correctIndex);
                                    }
                                    selectCountt = l;
                                }
                                else
                                    SelecToggless[l].IsOn = false;//单选题
                            }
                            if (IsAnswer[currentcount])
                            {
                                Debug.Log("已经回答");
                            }
                            else
                            {
                                _answeredCount++;
                                if (isRight)
                                    _rightCount++;
                                IsAnswer[_quesIndex] = true;
                                SelectAnswerIndex.Add(selectCountt + 1);
                                SelectIsRight.Add(isRight);
                                //GetScore.text = (int.Parse(GetScore.text)+_rightCount).ToString();
                            }
                        }

                    });
                }
                QuestionAll.Add(newQuestion);
            }
            QuestionPrefab.SetActive(false);
        }

        /// <summary>
        ///  csv读取Resources内的题库
        /// </summary>
        void CsvReadQuestions()
        {
            //csv二进制读取文件
            TextAsset questions = Resources.Load<TextAsset>("UIView_知识考核");

            SaveTopicToArray(questions);
        }
        void SaveTopicToArray(TextAsset questions)
        {
            //读取题库中每行的数据
            _perLineData = questions.text.Split("\r"[0]);

            Read(IsRandom);

            _quesCount = _questionsArray.Length - 1;

            for (int i = 0; i <= _quesCount; i++)
                IsAnswer.Add(false);//根据题目数量添加记录值

            //TopicSet();
        }


        void SaveTopicToArray(string questions)
        {
            //读取题库中每行的数据
            _perLineData = questions.Split("\r"[0]);

            Read(IsRandom);

            _quesCount = _questionsArray.Length - 1;

            for (int i = 0; i <= _quesCount; i++)
                IsAnswer.Add(false);//根据题目数量添加记录值

            TopicSet();
        }
        /// <summary>
        /// 添加、判断数据
        /// </summary>
        /// <param name="isRandom"></param>
        void Read(bool isRandom)
        {
            if (isRandom)
            {
                //确定二位数组的个数
                _questionsArray = new string[TopicCount][];

                List<int> saveRand = new List<int>();
                int randomNum;
                int num = 0;
                //把数据存储到二维数组中
                while (saveRand.Count < TopicCount)
                {
                    randomNum = Random.Range(0, _perLineData.Length);
                    if (!saveRand.Contains(randomNum))
                    {
                        saveRand.Add(randomNum);
                        _questionsArray[num] = _perLineData[randomNum].Split("*"[0]);//题库中，用中文中的*分隔。
                        num++;
                    }
                    else
                        continue;
                }
            }
            else
            {
                //确定二维数组的个数
                _questionsArray = new string[_perLineData.Length][];

                //把数据存储到二维数组中
                for (int i = 0; i < _perLineData.Length; i++)
                    _questionsArray[i] = _perLineData[i].Split("*"[0]);//题库中，用中文中的*分隔。
            }
        }

        /// <summary>
        /// 题目设置
        /// </summary>
        void TopicSet()
        {
            _tipsBtn.gameObject.SetActive(false);//初始隐藏提示按钮，错误时显示
            _tipCorrectText.text = "";
            for (int i = 0; i < 4; i++)
                SelecToggles[i].isOn = false;//开始时所有的选择默认为未选
            _quesIndexText.text = "第" + (_quesIndex + 1) + "题：";
            _quesContent.text = _questionsArray[_quesIndex][1];//题目内容  序号0是题目的序号,序号1是内容。
            int selectCount = _questionsArray[_quesIndex].Length - 3;//有多少选项  减去3个分别是：序号、题目、正确答案标识
            for (int i = 0; i < selectCount; i++)
            {
                SelecToggles[i].gameObject.SetActive(true);
                SelecAnswer[i].text = _questionsArray[_quesIndex][i + 2];//设置题目的选项。从第三位开始
            }
            if (selectCount < SelecToggles.Count)//判断选项是否有4个，如果没有则隐藏多余的
            {
                for (int i = selectCount; i < SelecToggles.Count; i++)
                    SelecToggles[i].gameObject.SetActive(false);
            }
        }

        /// <summary>
        /// 正确答案的选项
        /// </summary>
        /// <returns></returns>
        string JudgeCorrectAnswer()
        {
            int index = _questionsArray[_quesIndex].Length - 1;//该二位数组的长度，减1获得最后一位的序号
            int correctIndex = int.Parse(_questionsArray[_quesIndex][index]);//ArrayX[topicIndex][idx]获取到最后一位的正确答案标识
            string correctNum = "";
            switch (correctIndex)
            {
                case 1:
                    correctNum = "A";
                    break;
                case 2:
                    correctNum = "B";
                    break;
                case 3:
                    correctNum = "C";
                    break;
                case 4:
                    correctNum = "D";
                    break;
            }

            return correctNum;
        }

        string JudgeCorrectAnswer2(int a)
        {
            Debug.Log(a);
            string correctNum = "";
            switch (a)
            {
                case 0:
                    correctNum = "A";
                    break;
                case 1:
                    correctNum = "B";
                    break;
                case 2:
                    correctNum = "C";
                    break;
                case 3:
                    correctNum = "D";
                    break;
            }

            Debug.Log(correctNum);

            return correctNum;
        }
        /// <summary>
        /// 上一题
        /// </summary>
        void BeforeTopic()
        {
            if (_quesIndex > 0)
            {
                _quesIndex--;
                TopicSet();
                if (IsAnswer[_quesIndex])//已经答过题
                {
                    if (SelectIsRight[_quesIndex])//并且回答正确
                    {
                        _tipCorrectText.text = "<color=#00FF61FF>本题已经回答过，且回答正确，请继续答题。</color>";
                        SelecToggles[SelectAnswerIndex[_quesIndex] - 1].isOn = true;
                    }
                    else
                    {
                        SelecToggles[SelectAnswerIndex[_quesIndex] - 1].isOn = true;
                        _tipCorrectText.text = "本题已经回答过，<color=#FF0000FF>回答错误</color>，正确答案为：<color=#00FF81>" + JudgeCorrectAnswer() + "</color>";
                    }

                }
                if (_quesIndex != _quesCount)
                    _nextTopicBtn.gameObject.SetActive(true);
                // if (_quesIndex == 0)
                //     _beforeTopicBtn.gameObject.SetActive(false);
            }
        }
        /// <summary>
        /// 下一题
        /// </summary>
        void NextTopic()
        {
            if (_quesIndex < _quesCount)
            {
                if (_quesIndex >= 0)
                {
                    _quesIndex++;
                    TopicSet();
                    if (IsAnswer[_quesIndex])//已经答过题
                    {
                        if (SelectIsRight[_quesIndex])//并且回答正确
                        {
                            _tipCorrectText.text = "<color=#00FF61FF>本题已经回答过，且回答正确，请继续答题。</color>";
                            SelecToggles[SelectAnswerIndex[_quesIndex - 1]].isOn = true;
                        }
                        else
                        {
                            SelecToggles[SelectAnswerIndex[_quesIndex] - 1].isOn = true;
                            _tipCorrectText.text = "本题已经回答过，<color=#FF0000FF>回答错误</color>，正确答案为：<color=#00FF81>" + JudgeCorrectAnswer() + "</color>";
                        }
                    }
                }
                else
                {
                    if (IsAnswer[_quesIndex])//已经答过题
                    {
                        if (SelectIsRight[_quesIndex])//并且回答正确
                        {
                            _tipCorrectText.text = "<color=green>本题已经回答过，且回答正确，请继续答题。</color>";
                            SelecToggles[SelectAnswerIndex[_quesIndex - 1]].isOn = true;
                        }
                        else
                        {
                            SelecToggles[SelectAnswerIndex[_quesIndex] - 1].isOn = true;
                            _tipCorrectText.text = "本题已经回答过，<color=red>回答错误</color>，正确答案为：<color=#00FF81>" + JudgeCorrectAnswer() + "</color>";
                        }
                    }
                    _quesIndex++;
                    TopicSet();
                }


                if (_quesIndex == _quesCount)
                    _nextTopicBtn.gameObject.SetActive(true);
                // if (_quesIndex != 0)
                //     _beforeTopicBtn.gameObject.SetActive(true);
            }
        }
        /// <summary>
        /// 提示正确答案
        /// </summary>
        void CorrectTip()
        {
            _tipCorrectText.text = "正确答案是：<color=#0077FF>" + JudgeCorrectAnswer() + "</color>";
        }
        /// <summary>
        /// 外部加载读取题库
        /// </summary>
        void StreamingReadQuestions()
        {
            //数据流读取文件

            string questions = Application.streamingAssetsPath + QuestionListName;

            SaveTopicToArray(questions);
        }
        /// <summary>
        /// 选择判断
        /// </summary>
        /// <param name="selectIndex">第几个选项</param>
        void JudgeSelect(int selectIndex)
        {
            Debug.Log(selectIndex);

            bool isRight = false;
            int selectCount = 0;
            for (int i = 0; i < 4; i++)
            {
                if (i == selectIndex)
                {
                    SelecToggles[i].isOn = true;
                    int index = _questionsArray[_quesIndex].Length - 1;//该二位数组的长度，减1获得最后一位的序号
                    int correctIndex = int.Parse(_questionsArray[_quesIndex][index]) - 1;//ArrayX[topicIndex][idx]获取到最后一位的正确答案标识，答案序号是0123，所以减1

                    if (i == correctIndex)
                    {
                        if (!IsAnswer[_quesIndex])
                            _tipCorrectText.text = "<color=#00FF61FF>恭喜你，回答正确！请继续点击确定继续。</color>";
                        isRight = true;

                        _nextTopicBtn.gameObject.SetActive(true);
                    }
                    else
                    {
                        if (!IsAnswer[_quesIndex])
                            _tipCorrectText.text = "<color=#FF0000FF>对不起，回答错误！请查看提示或点击确定继续。</color>";
                        _tipsBtn.gameObject.SetActive(true);
                        _nextTopicBtn.gameObject.SetActive(true);
                    }
                    selectCount = i;
                }
                else
                    SelecToggles[i].isOn = false;//单选题
            }
            if (IsAnswer[_quesIndex])
            {
                Debug.Log("已经回答");
            }
            else
            {
                _answeredCount++;
                if (isRight)
                    _rightCount++;
                IsAnswer[_quesIndex] = true;
                SelectAnswerIndex.Add(selectCount + 1);
                SelectIsRight.Add(isRight);
                _accuracyText.text = "正确率：" + ((float)_rightCount / _answeredCount * 100).ToString("f2") + "%";
            }

        }
    }
}
