namespace OwnGame
{
    using System.Windows.Forms;

    public partial class QuestionForm : Form
    {
        public QuestionForm(string question)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            button1.Text = question;
        }

        private void QuestionForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A:
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    break;
                case Keys.D:
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;                
            }
        }
    }
}
