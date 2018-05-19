using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraPivotGrid;

namespace Q236810 {
    public partial class Form1 : XtraForm {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            myPivotGridControl1.RetrieveFieldsAsync(PivotArea.FilterArea, false, delegate { myPivotGridControl1.FieldsCustomization(); });
        }
    }
}