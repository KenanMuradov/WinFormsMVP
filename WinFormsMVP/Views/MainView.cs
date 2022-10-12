using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsMVP.Views
{
    public partial class MainView : Form, IMainView
    {
        public MainView()
        {
            InitializeComponent();
        }

        public string SearchValue => txtSearch.Text;

        public event EventHandler SearchEvent;
        public event EventHandler AddEvent;
        public event EventHandler UpdateEvent;
        public event EventHandler DeleteEvent;

        public void SetStudentListBindingSource(BindingSource source) => lBoxStudents.DataSource = source;

        private void btnSearch_Click(object sender, EventArgs e) => SearchEvent?.Invoke(sender, e);

        private void bntDelete_Click(object sender, EventArgs e) => DeleteEvent?.Invoke(sender, e);

        private void btnAdd_Click(object sender, EventArgs e) => AddEvent?.Invoke(sender, e);
    }
}
