using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Net.Sockets;

namespace WindowsFormsApp1
{
    public partial class Main : Form
    {
        private DataSet GetUserById(int x)
        {
            UserService us = new UserService();
            return us.GetUserById(x);
        }
        private DataSet GetCity(int x)
        {
            CityService cs = new CityService();
            return cs.GetCity(x);
        }
        private DataSet GetId(string x)
        {
            CityService cs = new CityService();
            return cs.GetId(x);
        }
        private DataSet HighestUser()
        {
            UserService us = new UserService();
            return us.HighestUser();
        }

        private DataSet GetOrders(int x)
        {
            OrderService os = new OrderService();
            return os.GetOrderById(x);
        }
        private DataSet GetReadyOrders(int x)
        {
            OrderService os = new OrderService();
            return os.GetFinishById(x) ;
        }
        private DataSet GetDebt(int x)
        {
            UserService us = new UserService();
            return us.GetDebt(x);
        }
        private void SetDebt(int id, int debt)
        {
            UserService us = new UserService();
            us.SetDebt(id, debt);
        }
        public Main()
        {
            InitializeComponent();            
        }
        private void Main_Load(object sender, EventArgs e)
        {

        }
        private void UserS_Click(object sender, EventArgs e)
        {
            SaveB.Enabled = false;
            UserSearch userS = new UserSearch();
            if(userS.ShowDialog() == DialogResult.OK)
            {
                Populate(Choose.u);
                Block();
            }
        }
        public void Populate(User u)
        {
            Mname.Text = u.Fname + " " + u.LName;
            Debt.Text = String.Format("₪ {0:n}", u.Debt.ToString());
            Id.Text = u.Id.ToString();
            Fname.Text = u.Fname;
            Lname.Text = u.LName;
            Street.Text = u.Street;
            City.Text = (GetCity(u.City).Tables[0].Rows[0][0].ToString());
            Phone.Text = u.Phone;
            Note.Text = u.Note;
            Discount.Text = u.Discount.ToString();
            Sub.Text = u.Sub;
            IdBox.Text = u.Id.ToString();
            FnameBox.Text = u.Fname;
            LnameBox.Text = u.LName;
            CityBox.Text = (GetCity(u.City).Tables[0].Rows[0][0].ToString());
            StreetBox.Text = u.Street;
            PhoneBox.Text = u.Phone;
            NoteBox.Text = u.Note;
            DisBox.Text = u.Discount.ToString();
            SubBox.Text = u.Sub;
            EmailBox.Text = u.Email;
            DebtBox.Text = String.Format("₪ {0:n}", u.Debt.ToString());
            OrderGrid.AutoGenerateColumns = false;
            OrderGrid.DataSource = GetOrders(u.Id);
            OrderGrid.DataMember = "Orders";
            ReadyGrid.AutoGenerateColumns = false;
            ReadyGrid.DataSource = GetReadyOrders(u.Id);
            ReadyGrid.DataMember = "Orders";
            Calculate();
        }
        private void Block()
        {
            FnameBox.ReadOnly = true;
            LnameBox.ReadOnly = true;
            CityBox.ReadOnly = true;
            StreetBox.ReadOnly = true;
            PhoneBox.ReadOnly = true;
            NoteBox.ReadOnly = true;
            DisBox.ReadOnly = true;
            SubBox.ReadOnly = true;
            EmailBox.ReadOnly = true;
        }
        private void AddUser_Click(object sender, EventArgs e)
        {
            IdBox.Text = (int.Parse(HighestUser().Tables[0].Rows[0][0].ToString())+ 1).ToString();
            Unblock();
            FnameBox.Text = "";
            LnameBox.Text = "";
            CityBox.Text = "";
            StreetBox.Text = "";
            PhoneBox.Text = "";
            NoteBox.Text = "";
            DisBox.Text = "";
            SubBox.Text = "";
            EmailBox.Text = "";
            DebtBox.Text = "";
        }
        public void Unblock()
        {
            
            FnameBox.ReadOnly = false;
            LnameBox.ReadOnly = false;
            CityBox.ReadOnly = false;
            StreetBox.ReadOnly = false;
            PhoneBox.ReadOnly = false;
            NoteBox.ReadOnly = false;
            DisBox.ReadOnly = false;
            SubBox.ReadOnly = false;
            EmailBox.ReadOnly = false;
            SaveB.Enabled = true;
        }

        private void CityBox_DoubleClick(object sender, EventArgs e)
        {
            
            if (CityBox.ReadOnly == false)
            {
                CityForm cityForm = new CityForm();
                if (cityForm.ShowDialog() == DialogResult.OK)
                {
                    UpdateCity(Choose.city);
                }
            }
            
        }
        public void UpdateCity(int x)
        {
            CityBox.Text = (GetCity(x).Tables[0].Rows[0][0].ToString());
        }

        private void SaveB_Click(object sender, EventArgs e)
        {
            if (int.Parse(IdBox.Text) == int.Parse(HighestUser().Tables[0].Rows[0][0].ToString()) + 1)
            {
                if (!Validation.Digits(DisBox.Text))
                {
                    MessageBox.Show("הקש מספר בתיבת ההנחה!");
                }
                if (DisBox.Text == "")
                {
                    DisBox.Text = "0";
                }
                if (SubBox.Text == "")
                {
                    SubBox.Text = "אין";
                }
                if (NoteBox.Text == "")
                {
                    NoteBox.Text = "אין";
                }
                else
                {
                    User u = new User(FnameBox.Text, LnameBox.Text, StreetBox.Text, int.Parse(GetId(CityBox.Text).Tables[0].Rows[0][0].ToString()), PhoneBox.Text, NoteBox.Text, int.Parse(DisBox.Text), SubBox.Text, EmailBox.Text);
                    UserService us = new UserService();
                    us.InsertUser(u);
                    Block();
                    SaveB.Enabled = false;
                    this.timer1.Start();
                    Bar.Visible = true;
                    System.Threading.Thread.Sleep(3000);
                    DataSet ds = GetUserById(int.Parse(IdBox.Text));
                    User n = new User(int.Parse(ds.Tables[0].Rows[0][0].ToString()), ds.Tables[0].Rows[0][1].ToString(), ds.Tables[0].Rows[0][2].ToString(), ds.Tables[0].Rows[0][3].ToString(),
                    int.Parse(ds.Tables[0].Rows[0][4].ToString()), ds.Tables[0].Rows[0][5].ToString(), ds.Tables[0].Rows[0][6].ToString(), int.Parse(ds.Tables[0].Rows[0][7].ToString()), ds.Tables[0].Rows[0][8].ToString(), ds.Tables[0].Rows[0][9].ToString(), int.Parse(ds.Tables[0].Rows[0][10].ToString()));
                    Populate(n);
                    MessageBox.Show("הלקוח נרשם בהצלחה!");
                    Bar.Visible = false;
                    Bar.Value = 0;
                }
            }
            else
            {
                User u = new User(int.Parse(IdBox.Text), FnameBox.Text, LnameBox.Text, StreetBox.Text, int.Parse(GetId(CityBox.Text).Tables[0].Rows[0][0].ToString()), PhoneBox.Text, NoteBox.Text, int.Parse(DisBox.Text), SubBox.Text, EmailBox.Text, int.Parse(DebtBox.Text.Replace("₪", "")));
                UserService us = new UserService();
                us.UpdatetUser(u);
                Block();
                SaveB.Enabled = false;
                this.timer1.Start();
                Bar.Visible = true;
                System.Threading.Thread.Sleep(3000);
                Populate(u);
                MessageBox.Show("הלקוח התעדכן בהצלחה! ");
                Bar.Visible = false;
                Bar.Value = 0;
            }
        }
        //private void Format()
        //{
        //    for(int i = 0; i < OrderGrid.Rows.Count; i++)
        //    {
        //        OrderGrid.Rows[i].Cells[6].ValueType = typeof(string);
        //        int x = int.Parse(OrderGrid.Rows[i].Cells[6].Value.ToString());
        //        //MessageBox.Show(x.ToString());
        //        OrderGrid.Rows[i].Cells[6].Value = String.Format("₪ {0:n}", x);
        //        //OrderGrid.Rows[i].Cells[6].Value = "hi";
        //    }
        //    for (int i = 0; i < ReadyGrid.Rows.Count; i++)
        //    {
        //        int x = int.Parse(ReadyGrid.Rows[i].Cells[6].Value.ToString());
        //        //MessageBox.Show(x.ToString());
        //        //OrderGrid.Rows[i].Cells[6].Value = String.Format("₪ {0:n}", x);
        //        //ReadyGrid.Rows[i].Cells[6].Value = "hi";
        //    }
        //}
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Bar.Increment(85);
        }

        private void NewItemB_Click(object sender, EventArgs e)
        {
            if(Id.Text == "")
            {
                MessageBox.Show("עלייך לשלןף תיק לקוח!");
            }
            else
            {
                NewItems ni = new NewItems();
                ni.getId(int.Parse(Id.Text));
                ni.getDis(int.Parse(Discount.Text));
                if (ni.ShowDialog() == DialogResult.OK)
                {
                    System.Threading.Thread.Sleep(500);
                    OrderGrid.AutoGenerateColumns = false;
                    OrderGrid.DataSource = GetOrders(int.Parse(Id.Text));
                    OrderGrid.DataMember = "Orders";
                    Calculate();
                }
            }

        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        public void Calculate()
        {
            int total = 0;
            int amount = 0;
            int total2 = 0;
            int amount2 = 0;
            for (int i = 0; i < OrderGrid.Rows.Count; i++)
            {
                total += int.Parse(OrderGrid.Rows[i].Cells[6].Value.ToString().Replace("₪ ", "").Replace(".00", "").Replace(",", ""));
                amount += int.Parse(OrderGrid.Rows[i].Cells[5].Value.ToString());
            }
            for(int i =0; i< ReadyGrid.Rows.Count; i++)
            {
                total2 += int.Parse(ReadyGrid.Rows[i].Cells[6].Value.ToString().Replace("₪ ", "").Replace(".00", "").Replace(",", ""));
                amount2 += int.Parse(ReadyGrid.Rows[i].Cells[5].Value.ToString());
            }
            TotalM.Text = String.Format("₪ {0:n}", total);
            TotalA.Text = amount.ToString();
            TotalM2.Text = String.Format("₪ {0:n}", total2);
            TotalA2.Text = amount2.ToString();
            Debt.Text = String.Format("₪ {0:n}" , GetDebt(int.Parse(Id.Text)).Tables[0].Rows[0][0].ToString());
        }
        private void EditB_Click(object sender, EventArgs e)
        {
            if(CityBox.Text == "")
            {
                MessageBox.Show("עלייך לשלוף תיק לקוח!");
            }
            else
            {
                Unblock();
            }
        }

        private void CancelOrder_Click(object sender, EventArgs e)
        {
            if (Id.Text == "")
            {
                MessageBox.Show("עלייך לשלןף תיק לקוח!");
            }
            else if (OrderGrid.Rows.Count > 0)
            {
                OrderService os = new OrderService();
                os.UpdateStatus(int.Parse(OrderGrid.CurrentRow.Cells[0].Value.ToString()), "בוטל");
                SetDebt(int.Parse(Id.Text), -int.Parse(OrderGrid.CurrentRow.Cells[6].Value.ToString()));
                System.Threading.Thread.Sleep(1000);
                MessageBox.Show("הפריט הוסר בהצלחה");
                OrderGrid.AutoGenerateColumns = false;
                OrderGrid.DataSource = GetOrders(int.Parse(Id.Text));
                OrderGrid.DataMember = "Orders";
                Calculate();
            }
            else
            {
                MessageBox.Show("לא נבחרו הזמנות");
            }
        }
        private void ReadyB_Click(object sender, EventArgs e)
        {
            if (Id.Text == "")
            {
                MessageBox.Show("עלייך לשלןף תיק לקוח!");
            }
            else if (OrderGrid.Rows.Count > 0)
            {
                OrderService os = new OrderService();
                os.UpdateStatus(int.Parse(OrderGrid.CurrentRow.Cells[0].Value.ToString()), "מוכן");
                System.Threading.Thread.Sleep(1000);
                MessageBox.Show("הפריט הועבר בהצלחה");
                OrderGrid.AutoGenerateColumns = false;
                OrderGrid.DataSource = GetOrders(int.Parse(Id.Text));
                OrderGrid.DataMember = "Orders";
                ReadyGrid.AutoGenerateColumns = false;
                ReadyGrid.DataSource = GetReadyOrders(int.Parse(Id.Text));
                ReadyGrid.DataMember = "Orders";
                Calculate();
            }
            else
            {
                MessageBox.Show("לא נבחרו הזמנות");
            }

        }
        
        private void PayDebt_Click(object sender, EventArgs e)
        {
            if(Id.Text == "")
            {
                MessageBox.Show("עלייך לשלוף תיק לקוח!");
            }
            else
            {
                
                PayDebt pd = new PayDebt();
                pd.LoadAmount(int.Parse(Debt.Text.Replace("₪", "")), int.Parse(Id.Text));
                if (pd.ShowDialog() == DialogResult.OK)
                {
                    Calculate();
                }
                    
            }
            
        }

        private void ReadyGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Id.Text == "")
            {
                MessageBox.Show("עלייך לשלןף תיק לקוח!");
            }
            else if (OrderGrid.Rows.Count > 0)
            {
                OrderService os = new OrderService();
                os.UpdateStatus(int.Parse(OrderGrid.CurrentRow.Cells[0].Value.ToString()), "הוחזר");
                System.Threading.Thread.Sleep(1000);
                MessageBox.Show("הפריט הועבר בהצלחה");
                OrderGrid.AutoGenerateColumns = false;
                OrderGrid.DataSource = GetOrders(int.Parse(Id.Text));
                OrderGrid.DataMember = "Orders";
                ReadyGrid.AutoGenerateColumns = false;
                ReadyGrid.DataSource = GetReadyOrders(int.Parse(Id.Text));
                ReadyGrid.DataMember = "Orders";
                Calculate();
            }
            else
            {
                MessageBox.Show("לא נבחרו הזמנות");
            }
        }

        private void OrderGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
