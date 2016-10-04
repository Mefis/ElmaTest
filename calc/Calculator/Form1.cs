using Calc;
using HistorySaving;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Calculator
{
    public partial class Form1 : Form
    {
        private Helper Calc { get; set; }

        private HistoryTxt HistoryAction { get; set; } 

        private string ActiveOperation { get; set; }

        public Form1()
        {
            InitializeComponent();
            Calc = new Helper();
            HistoryAction = new HistoryTxt();

            rtbHistory.Text = HistoryAction.Load();

            var methods = Calc.GetType().GetMethods(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);

            var count = 0;
            this.panel1.SuspendLayout();
            foreach ( var m in methods)
            {
                CreateRadioButton(m.Name, count++);
            }
            this.panel1.ResumeLayout();
        }

        private void CreateRadioButton(string Name, int index)
        {
            var rbBtn = new RadioButton();

            this.panel1.Controls.Add(rbBtn);

            rbBtn.AutoSize = true;
            rbBtn.Location = new System.Drawing.Point(12, 26 + index * 18);
            rbBtn.Name = "rbBtn" + index.ToString();
            rbBtn.Size = new System.Drawing.Size(53, 17);
            rbBtn.TabIndex = 5;
            rbBtn.TabStop = true;
            rbBtn.Tag = Name;
            rbBtn.Text = Name;
            rbBtn.UseVisualStyleBackColor = true;
            rbBtn.CheckedChanged += new System.EventHandler(this.radio_CheckedChanged);
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;
            txtX.BackColor = SystemColors.Window;
            txtY.BackColor = SystemColors.Window;

            if (ActiveOperation == null)
            {
                rtbHistory.Text += string.Format("Choose operation type\n");
                HistoryAction.Save(rtbHistory.Text);
                return;
            }

            if (!int.TryParse(txtX.Text, out x))
            {
                if (!int.TryParse(txtY.Text, out y))
                {
                    rtbHistory.Text += string.Format("x and y are unparsable\n");
                    txtX.BackColor = Color.Red;
                    txtY.BackColor = Color.Red;
                    HistoryAction.Save(rtbHistory.Text);
                    return;
                }
                else
                {
                    rtbHistory.Text += string.Format("x is unparsable\n");
                    txtX.BackColor = Color.Red;
                    HistoryAction.Save(rtbHistory.Text);
                    return;
                }
            }

            if (!int.TryParse(txtY.Text, out y))
            {
                rtbHistory.Text += string.Format("y is unparsable\n");
                txtY.BackColor = Color.Red;
                HistoryAction.Save(rtbHistory.Text);
                return;
            }

            var calcType = Calc.GetType();
            var method = Calc.GetType().GetMethod(ActiveOperation);

            var result = method.Invoke(Calc, new object[] { x, y });

            lblResult.Text = result.ToString();

            rtbHistory.Text += string.Format("{0} {1} {2} = {3}{4}", x, ActiveOperation, y, result, Environment.NewLine);
            HistoryAction.Save(rtbHistory.Text);
        }

        private void radio_CheckedChanged(object sender, EventArgs e)
        {
            var rb = sender as RadioButton;
            if (rb == null)
            {
                return;
            }
            ActiveOperation = rb.Tag.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            rtbHistory.Text = null;
            HistoryAction.Save(rtbHistory.Text);
        }
    }
}
