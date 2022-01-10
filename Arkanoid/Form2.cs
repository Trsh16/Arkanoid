using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arkanoid
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private void Load(object sender, EventArgs e)
        {
            Arkanoid game = new Arkanoid();
            this.SetVisibleCore(false);
            game.Show();
        }
    }
}
