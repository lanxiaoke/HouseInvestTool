using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HouseInvestTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString().Equals("r", StringComparison.OrdinalIgnoreCase))
            {
                txtAll.Focus();
                txtAll.SelectAll();
            }
        }

        private void txtAll_TextChanged(object sender, EventArgs e)
        {
            JS();
        }

        private void txtFlowOut_TextChanged(object sender, EventArgs e)
        {
            JS();
        }

        private void txtFlowIn_TextChanged(object sender, EventArgs e)
        {
            JS();
        }

        private void JS1()
        {
            double all;
            double.TryParse(txtAll.Text.Trim(), out all);
            if (all == 0)
            {
                txtLRL.Text = "0";
                return;
            }
            all = all * 10000;

            double flowOut;
            double.TryParse(textBox4.Text.Trim(), out flowOut);

            double flowIn;
            double.TryParse(txtFlowIn.Text.Trim(), out flowIn);

            txtLRL.Text = ((flowIn - flowOut) * 1200.00 / all).ToString("0.##");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            JS();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            JS();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            JS();
        }

        //等额本息计算公式： ［贷款本金 × 月利率 × （ 1 ＋月利率）＾还款月数］ ÷ ［（ 1 ＋月利率）＾还款月数－ 1 ］  
        private void JS()
        {
            JS2();
            JS1();
            
        }

        private void JS2()
        {
            double all;
            double.TryParse(textBox1.Text.Trim(), out all);
            if (all == 0)
            {
                textBox4.Text = "0";
                return;
            }
            all = all * 10000;

            double lv;
            double.TryParse(textBox2.Text.Trim(), out lv);
            lv = lv / 12;

            int months;
            int.TryParse(textBox3.Text.Trim(), out months);

            months = months * 12;

            var total = (all * lv * Math.Pow(1 + lv, months)) / ((Math.Pow(1 + lv, months)) - 1);

            textBox4.Text = total.ToString("0.##");
        }
    }
}
