using Quan_Li_Sach.Model;
using System.Data;
using System.Data.SqlClient;


namespace Quan_Li_Sach.DataBase
{
    class Database
    {
        SqlConnection sql = new SqlConnection(Properties.Settings.Default.Database);
        SqlCommand sqlCommand;

        public void insert(Sach sach)
        {
            sql.Open();
            sqlCommand = new SqlCommand("INSERT INTO [dbo].[Book] ([tenSach], [tacGia], [theLoai], [donGia], [ngayPhatHanh]) VALUES (N'" + sach.tenSach + "', N'" + sach.tacGia + "', N'" + sach.theLoai + "','" + sach.donGia + "','" + sach.ngayPhatHanh + "')", sql);
            sqlCommand.ExecuteNonQuery();
            sql.Close();
        }
        public void delete(int maSach)
        {
            sql.Open();
            sqlCommand = new SqlCommand("DELETE FROM [dbo].[Book] WHERE maSach =" + maSach, sql);
            sqlCommand.ExecuteNonQuery();
            sql.Close();
        }
        public void update(Sach sach)
        {
            sql.Open();
            sqlCommand = new SqlCommand("UPDATE [dbo].[Book] SET[tenSach] = N'" + sach.tenSach + "',[tacGia] = N'" + sach.tacGia + "',[theLoai] = N'" + sach.theLoai + "',[donGia] = N'" + sach.donGia + "',[ngayPhatHanh] = N'" + sach.ngayPhatHanh + "' WHERE maSach =" + sach.maSach, sql);
            sqlCommand.ExecuteNonQuery();
            sql.Close();
        }
        public DataTable select()
        {
            DataTable data = new DataTable();
            sql.Open();
            sqlCommand = new SqlCommand("SELECT [maSach] as 'Mã sách',[tenSach] as 'Tên sách',[tacGia] as 'Tác giả',[theLoai] as 'Thể loại',[donGia] as 'Đơn giá',[ngayPhatHanh] as 'Ngày phát hành' FROM[dbo].[Book]", sql);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCommand);
            dataAdapter.Fill(data);
            sql.Close();
            return data;
        }
        
    }
}

