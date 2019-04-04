namespace OwnGame
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;

    public partial class GameForm : Form
    {
        private const string ResourceName = "OwnGame.Resources.Questions.txt";
        private readonly List<GameButton> _gamesButtons = new List<GameButton>();
        private readonly List<Question> _question = new List<Question>();

        private int _sum = 0;

        private void Main_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.Z:
                        Cancel();
                        break;
                    case Keys.R:
                        Restart();
                        break;
                }
            }
        }

        public GameForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            GetQuestionFromTextFile();
        }

        private void ChangeSum(int price)
        {
            _sum += price;
            labelScore.Text = _sum.ToString();
        }

        private void GetQuestionFromTextFile()
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream(ResourceName))
            {
                if (stream != null)
                {
                    using (var sr = new StreamReader(stream))
                    {
                        while (!sr.EndOfStream)
                        {
                            var quest = sr.ReadLine();
                            if (!string.IsNullOrEmpty(quest))
                            {
                                var massiveQuest = quest.Split(new[] {'@'}, 3, StringSplitOptions.RemoveEmptyEntries);
                                if (massiveQuest.Length > 1)
                                {
                                    _question.Add(new Question
                                    {
                                        BtnId = massiveQuest[0],
                                        Text = massiveQuest[1],
                                        CatFormNeed = massiveQuest.Length > 2
                                    });
                                }
                            }
                        }
                    }
                }
            }
        }

        private void gameBtn_Click(object sender, EventArgs e)
        {
            if (sender is Button btn)
            {
                if(btn.Tag != null)
                {
                    var quest = _question.FirstOrDefault(x=>x.BtnId == btn.Tag.ToString());
                    if (!string.IsNullOrEmpty(quest?.Text) && int.TryParse(btn.Text, out var btnPrace))
                    {
                        if (quest.CatFormNeed)
                        {
                            var catFrom = new CatForm();
                            catFrom.ShowDialog();
                        }

                        var questionForm = new QuestionForm(quest.Text);
                        var result = questionForm.ShowDialog() == DialogResult.OK;
                        if (result)
                        {
                            ChangeSum(btnPrace);
                        }
                        else
                        {
                            ChangeSum(btnPrace * -1);
                        }

                        _gamesButtons.Add(new GameButton
                        {
                            Button = btn,
                            Price = btnPrace,
                            Plus = result 
                        });
                        btn.Visible = !btn.Visible;
                    }
                }
            }
        }
        private void btnRestart_Click(object sender, EventArgs e)
        {
            Restart();
        }

        private void Restart()
        {
            foreach (var btn in _gamesButtons)
            {
                btn.Button.Visible = true;
            }

            _sum = 0;
            ChangeSum(0);
            _gamesButtons.Clear();
            _question.Clear();
            GetQuestionFromTextFile();
        }

        private void Cancel()
        {
            if (_gamesButtons.Any())
            {
                var lastBtn = _gamesButtons[_gamesButtons.Count - 1];
                if (lastBtn.Plus)
                {
                    ChangeSum(lastBtn.Price * -1);
                }
                else
                {
                    ChangeSum(lastBtn.Price);
                }

                _gamesButtons.Remove(lastBtn);
                lastBtn.Button.Visible = !lastBtn.Button.Visible;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancel();
        }
    }
}
