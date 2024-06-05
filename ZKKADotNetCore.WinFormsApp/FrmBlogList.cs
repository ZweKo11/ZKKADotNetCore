using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZKKADotNetCore.Shared;
using ZKKADotNetCore.WinFormsApp.Models;
using ZKKADotNetCore.WinFormsApp.Queries;

namespace ZKKADotNetCore.WinFormsApp
{
    public partial class FrmBlogList : Form
    {
        private readonly DapperService _dapperService;
        public FrmBlogList()
        {
            InitializeComponent();
            dgvData.AutoGenerateColumns = false;
            _dapperService = new DapperService(ConnectionStrings.sqlConnectionStringBuilder.ConnectionString);
        }

        private void FrmBlogList_Load(object sender, EventArgs e)
        {
            BlogList();
        }

        private void BlogList()
        {
            List<BlogModel> lst = _dapperService.Query<BlogModel>(BlogQuery.BlogList);
            dgvData.DataSource = lst;
        }

        private void dgvData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //int columnIndex = e.ColumnIndex;
            //int rowIndex = e.RowIndex;

            if (e.RowIndex == -1) return;

            #region If Case

            var blogId = Convert.ToInt32(dgvData.Rows[e.RowIndex].Cells["colId"].Value);

            if (e.ColumnIndex == (int)EnumControlType.Edit)
            {
                FrmBlog frm = new FrmBlog(blogId);
                frm.ShowDialog();

                BlogList();
            }
            else if(e.ColumnIndex == (int)EnumControlType.Delete)
            {
                var dialogResult = MessageBox.Show("Are you sure to delete?","",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult != DialogResult.Yes) return;

                DeleteBlog(blogId);
            }

            #endregion


            #region Switch Case

            int index = e.ColumnIndex;
            EnumControlType enumControlType = (EnumControlType)index;
            switch (enumControlType)
            {
                case EnumControlType.Edit:
                    FrmBlog frm = new FrmBlog(blogId);
                    frm.ShowDialog();

                    BlogList();
                    break;
                case EnumControlType.Delete:
                    var dialogResult = MessageBox.Show("Are you sure to delete?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult != DialogResult.Yes) return;

                    DeleteBlog(blogId);
                    break;
                case EnumControlType.None:
                default:
                    MessageBox.Show("Something was wrong!");
                    break;
            }
            #endregion
        }

        private void DeleteBlog(int id)
        {
            string query = @"Delete From  [dbo].[Tbl_BLog] Where BlogId = @BlogId";

            int result = _dapperService.Execute(query, new { BlogId = id });
            string message = result > 0 ? "Deleting is successful." : "Deleting Failed.";
            MessageBox.Show(message);

            BlogList();
        }
    }
}
