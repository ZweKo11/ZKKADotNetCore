using ZKKADotNetCore.Shared;

namespace ZKKADotNetCore.WinFormsAppSqlInjection
{
    public partial class Form1 : Form
    {
        private readonly DapperService _dapperService;
        public Form1()
        {
            InitializeComponent();
            _dapperService = new DapperService(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            //without Sql Parameter
            //string query = $"select * from tbl_UserInfo where email = '{txtEmail.Text.Trim()}' and password = '{txtPassword.Text.Trim()}'";

            //with Sql Parameter
            string query = $"select * from tbl_UserInfo where email = @Email and password = @Password";
            var model = _dapperService.QueryFirstOrDefault<UserModel>(query, new
            {
                Email = txtEmail.Text.Trim(),
                Password = txtPassword.Text.Trim()
            });

            if (model is null)
            {
                MessageBox.Show("User doesn't exist!");
                return;
            }
            MessageBox.Show("Is Admin : " + model.Email);

            }
        }
}

public class UserModel 
{
    public string Email { get; set; }
    public string password { get; set; }
}

