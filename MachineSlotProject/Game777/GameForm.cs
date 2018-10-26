using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Game777.Properties;
using Microsoft.VisualStudio.TestTools.UITesting;

namespace Game777
{
    public partial class GameForm : Form
    {
        private const int TimerInterval = 80;
        private const string resourceName = "Game777.Resources.Phrase.txt";
        private readonly Random _rnd = new Random();

        private enum SlotImage
        {
            ПобедительПоЖизни,
            Бар,
            Арбузик,
            Бананчик,
            Лимончело,
            Пипильсин,
            СливаЛиловая,
            Черри,
            _7
        }

        private readonly Dictionary<int, Image> _slotImages = new Dictionary<int, Image>
        {
            {(int)SlotImage.ПобедительПоЖизни, Resources.ПобедительПоЖизни},
            {(int)SlotImage.Бар, Resources.Бар},
            {(int)SlotImage.Арбузик, Resources.Арбузик},
            {(int)SlotImage.Бананчик, Resources.Бананчик},
            {(int)SlotImage.Лимончело, Resources.Лимончело},
            {(int)SlotImage.Пипильсин, Resources.Пипильсин},
            {(int)SlotImage.СливаЛиловая, Resources.СливаЛиловая},
            {(int)SlotImage.Черри, Resources.Черри},
            {(int)SlotImage._7, Resources._7}
        };

        private readonly int _slotImagesCount;
        private readonly int _phraseCount;
        private readonly double _winMedian;

        public long Balance = 100;
        public int BarabanCount;
        public int CurrentRate;
        public long Gain;

        public GameForm()
        {
            InitializeComponent();
            SetBalance(Balance);
            txtResult.Text = "";
            txtResult.Visible = false;
            tResult.Interval = 1500;
            _slotImagesCount = _slotImages.Count - 1;
            _winMedian = _slotImages.Count/2.0;
            _phraseCount = GetLineNumberFromTextFile();//Resources.Phrase.Length;
            ChangeGame(cbFirstSlot);
            ChangeGame(cbSecondSlot);
            ChangeGame(cbThirdSlot);
        }

        public List<TimerSetting> Timers { get; } = new List<TimerSetting>();

        private void SetBalance(long newBalance)
        {
            lblBalance.Text = $"Баланс: {newBalance}$";
        }

        private void OpenAddMoneyForm()
        {
            var formAddMoney = new AddMoneyForm();
            if (formAddMoney.ShowDialog() == DialogResult.OK)
            {
                var amount = int.Parse(formAddMoney.txtAmount.Text);
                Balance += amount;
                SetBalance(Balance);
            }
        }

        public void SetSlotImage(PictureBox pb, int index)
        {
            pb.Image = _slotImages[index];
        }

        private int GetKeyBySlotImages(SlotImage image)
        {
            return (int)image;
        }

        private long WinTableLogic()
        {
            long result = 0;
            if (Timers.Exists(x => x.CurrentImageIndex == GetKeyBySlotImages(SlotImage.Бар)))
            {
                // Если на любой позиции выпал слиток, не зависимо от остальных значений, возвращаем текущую ставку.
                result = CurrentRate;
            }
            else if (Timers.Exists(x => x.CurrentImageIndex == GetKeyBySlotImages(SlotImage.ПобедительПоЖизни))
                     && !Timers.Exists(x => x.CurrentImageIndex == GetKeyBySlotImages(SlotImage._7)))
            {
                // Если на любой позиции выпал ПобедительПоЖизни и на других позициях нет 7, то считаем комбо. Результатом будет умножение текущего баланса на комбо. 
                var countCombo =
                    Timers.Count(x => x.CurrentImageIndex == GetKeyBySlotImages(SlotImage.ПобедительПоЖизни));
                if (countCombo > 1)
                {
                    result = Balance * Convert.ToInt64(countCombo - 1);
                }
            }
            else if (Timers.Exists(x => x.CurrentImageIndex == GetKeyBySlotImages(SlotImage._7)))
            {
                // Если на любой позиции выпало число 7, то считаем комбо.
                var countCombo =
                    Timers.Count(x => x.CurrentImageIndex == GetKeyBySlotImages(SlotImage._7));
                if (countCombo == 3)
                {
                    // Если выпало 777.
                    result = CurrentRate*7;
                }
                else if (countCombo == 2)
                {
                    //Если выпало 7-7, 77-, -77
                    if (BarabanCount == 2)
                    {
                        // Если игра с двумя барабанами, то результатом возвращаем текущую ставку умноженную на 3.
                        result = CurrentRate*3;
                    }
                    else if (Timers[1].CurrentImageIndex == GetKeyBySlotImages(SlotImage._7))
                    {
                        // Если игра с тремя барабанами и две семерки выпали рядом, то результатом возвращаем текущую ставку умноженную на 5.
                        result = CurrentRate*5;
                    }
                    else
                    {
                        // Если игра с тремя барабанами и две семерки выпали не рядом, то результатом возвращаем текущую ставку умноженную на 3.
                        result = CurrentRate*3;
                    }
                }
                else
                {
                    // Если выпала одна 7, то результатом возвращаем текущую ставку умноженную на 2.
                    result = CurrentRate*2;
                }
            }
            else
            {
                // Если это на слитки, не победитель и не 7.
                // Считаем выпавшее комбо фруктов.
                var countCombo = Timers.GroupBy(x => x.CurrentImageIndex).Count();
                if (countCombo == 1)
                {
                    // Во всех слотах фрукты совпали или это просто фрукт на одном барабане.
                    if (BarabanCount == 1)
                    {
                        result = 0;
                    }
                    else
                    {
                        result = BarabanCount == 2
                            ? 50
                            : 100;
                    }
                }
                else if (countCombo == 2)
                {
                    // Тут возможен вариант, два фрукта совпали, или два разных фрукта при игре с двумя барабанами.
                    if (BarabanCount == 2)
                    {
                        result = 0;
                    }
                    else if (Timers[0].CurrentImageIndex == Timers[1].CurrentImageIndex
                             || Timers[2].CurrentImageIndex == Timers[1].CurrentImageIndex)
                    {
                        // Фрукты выпали рядом при игре с тремя слотами.
                        result = 40;
                    }
                }
                else
                {
                    result = 0;
                }
            }

            return result;
        }

        private void CalcNewBalance()
        {
            Gain = WinTableLogic();
            Balance += Gain;
        }

        private void ShowResult(long gain)
        {
            Color newColor;
            string newText;
            float newTextSize;

            if (gain != 0)
            {
                newTextSize = 26.0f;
                if (gain > 0)
                {
                    newColor = Color.ForestGreen;
                    newText = $"+{gain}$";
                }
                else
                {
                    newColor = Color.Red;
                    newText = $"{gain}$";
                }
            }
            else
            {
                newColor = Color.Black;
                newTextSize = 10.0f;

                var lineIndex =_rnd.Next(1, _phraseCount);
                newText = GetPhraseFromTextByLineIndex(lineIndex);
            }

            txtResult.Visible = true;
            var font = new Font("Times New Roman", newTextSize);
            txtResult.Font = font;
            txtResult.ForeColor = newColor;
            txtResult.Text = newText;
        }

        private int GetLineNumberFromTextFile()
        {
            int result = 0;
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    using (var sr = new StreamReader(stream))
                    {
                        while (!sr.EndOfStream)
                        {
                            sr.ReadLine();
                            result++;
                        }
                    }
                }
            }

            return result;
        }

        private string GetPhraseFromTextByLineIndex(int line)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var result = "";

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    using (var sr = new StreamReader(stream))
                    {
                        for (var i = 1; i <= line; i++)
                        {
                            sr.ReadLine();
                        }

                        result= sr.ReadLine()?.Replace("(c)", $"{Environment.NewLine}(c)") ?? "";
                    }
                }
            }

            return result;
        }

        private void ResultEventProcessor(object sender, EventArgs myEventArgs)
        {
            SetBalance(Balance);
            btnPlay.Enabled = true;
            cbFirstSlot.Enabled = true;
            cbSecondSlot.Enabled = true;
            cbThirdSlot.Enabled = true;
            menuAddMoney.Enabled = true;
            if (Gain != 0)
            {
                txtResult.Visible = false;
            }
            tResult.Stop();
        }

        private void TimerEventProcessor(object sender, EventArgs myEventArgs)
        {
            var currentTimer = sender as Timer;
            if (currentTimer != null)
            {
                var setting = Timers.FirstOrDefault(x => x.Timer == currentTimer);
                if (setting != null)
                {
                    setting.CurrentImageIndex = Gaussian.GaussianInRange(0, _winMedian, _slotImagesCount);
                    setting.CurrentTick++;
                    SetSlotImage(setting.OutPb, setting.CurrentImageIndex);

                    if (!setting.ContinueTimer)
                    {
                        currentTimer.Stop();
                        if (!tFirstSlot.Enabled
                            && !tSecondSlot.Enabled
                            && !tThridSlot.Enabled
                            && !bwResultCalc.IsBusy)
                        {
                            bwResultCalc.RunWorkerAsync();
                        }
                    }
                }
                else
                {
                    currentTimer.Stop();
                }
            }
        }


        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (Balance - CurrentRate < 0)
            {
                if (MessageBox.Show(
                    "Необходимо пополнить баланс! Хотите пополнить баланс?",
                    "Сообщение",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    OpenAddMoneyForm();
                }
            }
            else
            {
                txtResult.Visible = false;
                cbFirstSlot.Enabled = false;
                cbSecondSlot.Enabled = false;
                cbThirdSlot.Enabled = false;
                menuAddMoney.Enabled = false;
                Balance -= CurrentRate;
                SetBalance(Balance);

                Timers.Clear();
                if (cbFirstSlot.Checked)
                {
                    Timers.Add(new TimerSetting(tFirstSlot, _rnd.Next(15, 25), pbFirstSlot));
                }

                if (cbSecondSlot.Checked)
                {
                    Timers.Add(new TimerSetting(tSecondSlot, _rnd.Next(25, 35), pbSecondSlot));
                }

                if (cbThirdSlot.Checked)
                {
                    Timers.Add(new TimerSetting(tThridSlot, _rnd.Next(35, 45), pbThirdSlot));
                }

                btnPlay.Enabled = false;
            }
        }

        private void bwResultCalc_DoWork(object sender, DoWorkEventArgs e)
        {
            CalcNewBalance();
        }

        private void bwResultCalc_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ShowResult(Gain);
            tResult.Start();
        }

        private void menuAddMoney_Click(object sender, EventArgs e)
        {
            OpenAddMoneyForm();
        }

        private void menuRule_Click(object sender, EventArgs e)
        {
            var ruleForm = new RuleForm();
            ruleForm.Show();
        }

        private void ChangeGame(CheckBox cb)
        {
            if (cb.Checked)
            {
                BarabanCount++;
                CurrentRate += 10;
                cb.BackgroundImage = Resources.glossy_green_icon_button_hi;
            }
            else
            {
                BarabanCount--;
                CurrentRate -= 10;
                cb.BackgroundImage = Resources.glossy_red_icon_button_hi;
            }

            lblRate.Text = $"Текущая ставка: {CurrentRate}$";
            btnPlay.Enabled = BarabanCount != 0;
        }

        private void cbFirstSlot_CheckedChanged(object sender, EventArgs e)
        {
            ChangeGame(cbFirstSlot);
            if (!cbFirstSlot.Checked)
            {
                pbFirstSlot.Image = Resources.Empty;
            }
        }

        private void cbSecondSlot_CheckedChanged(object sender, EventArgs e)
        {
            ChangeGame(cbSecondSlot);
            if (!cbSecondSlot.Checked)
            {
                pbSecondSlot.Image = Resources.Empty;
            }
        }

        private void cbThird_CheckedChanged(object sender, EventArgs e)
        {
            ChangeGame(cbThirdSlot);
            if (!cbThirdSlot.Checked)
            {
                pbThirdSlot.Image = Resources.Empty;
            }
        }

        public class TimerSetting
        {
            private readonly int _limitTick;

            public TimerSetting(Timer timer, int limitTick, PictureBox outBp)
            {
                Timer = timer;
                _limitTick = limitTick;
                OutPb = outBp;
                CurrentTick = 0;
                CurrentImageIndex = 0;
                timer.Interval = TimerInterval;
                timer.Start();
            }

            public Timer Timer { get; }
            public PictureBox OutPb { get; }
            public int CurrentImageIndex { get; set; }
            public int CurrentTick { get; set; }
            public bool ContinueTimer => CurrentTick <= _limitTick;
        }
    }
}