using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoPlayFair
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		
		string NhapMaTran = ""; //Chuỗi ma trận nhập vào
		string BangChuCai; //bảng chữ cái
		char[,] MaTranKhoa = new char[5, 5]; //ma trận
		char[,] DiaChiNhiPhan = new char[200, 2]; int DemDiaChi = 0; //địa chỉ từng ký tự trên ma trận theo dạng nhị phân
		char[,] DiaChiNhiPhanKQ = new char[200, 2];//Địa chỉ của kết quả sau khi giải mã hoặc mã hóa
		int[] DiaChiNhiPhanCapDoi = new int[4];//cho những nơi của bộ đôi.
		Random random = new Random();

		public string HamDiaChiNhiPhanKQ()
		{
			string ChuoiDiaChiNhiPhanKQ = "";

			for (int i = 0; i < DemDiaChi; i++)
			{
				ChuoiDiaChiNhiPhanKQ += DiaChiNhiPhanKQ[i, 0].ToString() + DiaChiNhiPhanKQ[i, 1].ToString();
			}

			return ChuoiDiaChiNhiPhanKQ;
		}

		//Playfair mã hóa bộ đôi một cách riêng biệt.

		public void GiaiMa()
		{
			for (int i = 0; i < DemDiaChi; i++)
			{
				//Tìm địa điểm của bộ đôi.
				HamDiaChiNhiPhanCapDoi(DiaChiNhiPhan[i, 0], DiaChiNhiPhan[i, 1]);

				if (DiaChiNhiPhanCapDoi[0] == DiaChiNhiPhanCapDoi[2]) // nếu chúng ở trên cùng một dòng,
				{
					DiaChiNhiPhanKQ[i, 0] = MaTranKhoa[DiaChiNhiPhanCapDoi[0], (DiaChiNhiPhanCapDoi[1] + 4) % 5];
					DiaChiNhiPhanKQ[i, 1] = MaTranKhoa[DiaChiNhiPhanCapDoi[2], (DiaChiNhiPhanCapDoi[3] + 4) % 5];
				}
				else if (DiaChiNhiPhanCapDoi[1] == DiaChiNhiPhanCapDoi[3]) // nếu chúng ở trong cùng một cột,
				{
					DiaChiNhiPhanKQ[i, 0] = MaTranKhoa[(DiaChiNhiPhanCapDoi[0] + 4) % 5, DiaChiNhiPhanCapDoi[1]];
					DiaChiNhiPhanKQ[i, 1] = MaTranKhoa[(DiaChiNhiPhanCapDoi[2] + 4) % 5, DiaChiNhiPhanCapDoi[3]];
				}
				else //Nếu hàng và cột khác nhau,
				{
					DiaChiNhiPhanKQ[i, 0] = MaTranKhoa[DiaChiNhiPhanCapDoi[0], DiaChiNhiPhanCapDoi[3]];
					DiaChiNhiPhanKQ[i, 1] = MaTranKhoa[DiaChiNhiPhanCapDoi[2], DiaChiNhiPhanCapDoi[1]];
				}
			}
		}

		//Playfair mã hóa bộ đôi một cách riêng biệt.
		public void MaHoa()
		{
			for (int i = 0; i < DemDiaChi; i++)
			{
				//Tìm DiaChiNhiPhanCapDoi của bộ đôi.
				HamDiaChiNhiPhanCapDoi(DiaChiNhiPhan[i, 0], DiaChiNhiPhan[i, 1]);

				if (DiaChiNhiPhanCapDoi[0] == DiaChiNhiPhanCapDoi[2]) // aynı satırda iseler,
				{
					DiaChiNhiPhanKQ[i, 0] = MaTranKhoa[DiaChiNhiPhanCapDoi[0], (DiaChiNhiPhanCapDoi[1] + 1) % 5];
					DiaChiNhiPhanKQ[i, 1] = MaTranKhoa[DiaChiNhiPhanCapDoi[2], (DiaChiNhiPhanCapDoi[3] + 1) % 5];
				}
				else if (DiaChiNhiPhanCapDoi[1] == DiaChiNhiPhanCapDoi[3]) // aynı stunda iseler,
				{
					DiaChiNhiPhanKQ[i, 0] = MaTranKhoa[(DiaChiNhiPhanCapDoi[0] + 1) % 5, DiaChiNhiPhanCapDoi[1]];
					DiaChiNhiPhanKQ[i, 1] = MaTranKhoa[(DiaChiNhiPhanCapDoi[2] + 1) % 5, DiaChiNhiPhanCapDoi[3]];
				}
				else //satır ve stunları farklı ise,
				{
					DiaChiNhiPhanKQ[i, 0] = MaTranKhoa[DiaChiNhiPhanCapDoi[0], DiaChiNhiPhanCapDoi[3]];
					DiaChiNhiPhanKQ[i, 1] = MaTranKhoa[DiaChiNhiPhanCapDoi[2], DiaChiNhiPhanCapDoi[1]];
				}
			}
		}

		//Tìm dòng và trình tự của cặp mong muốn trong ma trận
		public void HamDiaChiNhiPhanCapDoi(char ch1, char ch2)
		{
			for (int i = 0; i < 5; i++)
			{
				for (int j = 0; j < 5; j++)
				{
					if (MaTranKhoa[i, j] == ch1)
					{
						DiaChiNhiPhanCapDoi[0] = i;
						DiaChiNhiPhanCapDoi[1] = j; 
					}
					else if (MaTranKhoa[i, j] == ch2)
					{
						DiaChiNhiPhanCapDoi[2] = i;
						DiaChiNhiPhanCapDoi[3] = j;
					}
				}
			}
		}

		//Tạo một chuỗi nhị phân của văn bản đầu vào.
		public void HamDiaChiNhiPhan(string KyTuLoai)
		{
			int j = 0;

			for (int i = 0; i < KyTuLoai.Length;)
			{
				DiaChiNhiPhan[j, 0] = KyTuLoai[i];

				if (i == KyTuLoai.Length - 1)
				{   
					DiaChiNhiPhan[j, 1] = 'w';
					j++;
					break;
				}
				else if (KyTuLoai[i] != KyTuLoai[i + 1])
				{
					DiaChiNhiPhan[j, 1] = KyTuLoai[i + 1];
					i += 2;
				}
				else
				{
					DiaChiNhiPhan[j, 1] = 'x';
					i++;
				}

				j++;
			}

			DemDiaChi = j;
		}

		public void HamNhapMaTran()
		{
			int k = 0;
			int j = 0;
			int index = 0;

			BangChuCai = "abcdefghiklmnopqrstuvwxyz";
			int i = BangChuCai.Length;

			while (i > 0)
			{
				index = random.Next(0, i); 
				MaTranKhoa[k, j] = BangChuCai[index]; 
				BangChuCai = BangChuCai.Remove(index, 1);

				i--;
				j++;

				if (j % 5 == 0)
				{
					k++;
					j = 0;
				}
			}
		}
		
		public void HamMaTranKhoa()
		{
			int j = 0;
			int k = 0;
			int i = NhapMaTran.Length;
			int index1 = 0;

			BangChuCai = "abcdefghiklmnopqrstuvwxyz";
			while (i > 0)
			{
				
				index1 = BangChuCai.IndexOf(NhapMaTran[NhapMaTran.Length - i]);
				if (index1 >= 0)
				{
					string MT = ""+ NhapMaTran[NhapMaTran.Length - i];
					string TD = "i";
					if (MT == "j")
					{
						MaTranKhoa[k, j] = TD[0];
					}
					else
					{
						MaTranKhoa[k, j] = NhapMaTran[NhapMaTran.Length - i];
						
					}
					BangChuCai = BangChuCai.Remove(index1, 1);
					j++;
				}

				i--;

				if (j == 5)
				{
					k++;
					j = 0;
				}
			}

			i = 0;
			
			while (i < BangChuCai.Length)
			{
				MaTranKhoa[k, j] = BangChuCai[i];

				i++;
				j++;

				if (j % 5 == 0)
				{
					k++;
					j = 0;
				}
			}
		}
		
		public void MaTran()
		{
			txtMaTran.Text = "";

			for (int i = 1; i < 6; i++)
			{
				for (int j = 1; j < 6; j++)
				{
					string MT = ""+MaTranKhoa[i - 1, j - 1];
					if (MT == "i" || MT =="j")
					{
						txtMaTran.Text += "i/j\r\t";
					}
					else
					{
						txtMaTran.Text += MaTranKhoa[i - 1, j - 1] + "\r\t";
					}
				}
				txtMaTran.Text += "\r\n\r\n";
			}
		}

		//kiểm tra các ký tự không xác định trong văn bản.
		public string LoaiBoKyTuDB(string KyTuLoai)
		{
			for (int i = KyTuLoai.Length - 1; i >= 0; i--)
			{
				/*if (!(KyTuLoai[i] == '.' || KyTuLoai[i] == ',' ||
					KyTuLoai[i] == ':' || KyTuLoai[i] == ' ' ||
					(KyTuLoai[i] >= 97 && KyTuLoai[i] <= 122) ||
					KyTuLoai[i] == 'ü' || KyTuLoai[i] == 'ö' ||
					KyTuLoai[i] == 'ç' || KyTuLoai[i] == 'ş' ||
					KyTuLoai[i] == 'ğ' || KyTuLoai[i] == 'ı'))
				{
					KyTuLoai = KyTuLoai.Remove(i, 1);
				}*/
				if(KyTuLoai[i]=='j')
				{
					KyTuLoai = "i";
				}
				else
				{
					if (KyTuLoai[i] == ' ')
					{
						//MessageBox.Show("Văn bản đầu vào phải là chữ in thường viết liền không dấu.", "Lỗi nhập dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
						lblLoi.Enabled = true;
						pictureBox2.Show();
						KyTuLoai = KyTuLoai.Remove(i, 1);
					}
					timer1.Start();


				}
			}
			return KyTuLoai;
		}

		private void txtNhapMaTran_TextChanged(object sender, EventArgs e)
		{
			if (txtNhapMaTran.Text == "")
			{
				//txtNhapVanBan.Enabled = false;
				//txtXuatVanBan.Enabled = false;
				NhapMaTran = "";
			}
			else
			{
				//txtNhapVanBan.Enabled = true;
				//txtXuatVanBan.Enabled = true;
				txtNhapMaTran.Text = LoaiBoKyTuDB(txtNhapMaTran.Text);
				txtNhapMaTran.Select(txtNhapMaTran.Text.Length, 0);
				NhapMaTran = txtNhapMaTran.Text;
			}
			HamMaTranKhoa();
			MaTran();
		}

		private void btnRandomKhoa_Click(object sender, EventArgs e)
		{
			HamNhapMaTran();
			MaTran();
		}

		private void txtNhapVanBan_TextChanged(object sender, EventArgs e)
		{
			if (txtNhapVanBan.Text == "")
			{
				btnGiaiMa.Enabled = false;
				btnMaHoa.Enabled = false;
			}
			else
			{
				txtNhapVanBan.Text = LoaiBoKyTuDB(txtNhapVanBan.Text);
				txtNhapVanBan.Select(txtNhapVanBan.Text.Length, 0);
				btnGiaiMa.Enabled = true;
				btnMaHoa.Enabled = true;
			}

			if (txtNhapVanBan.Text.Length < 200)
				lblSokyTu.Text = "(" + (199 - txtNhapVanBan.Text.Length).ToString() + ")";
		}

		private void btnMaHoa_Click(object sender, EventArgs e)
		{
			HamDiaChiNhiPhan(txtNhapVanBan.Text);
			MaHoa();
			txtXuatVanBan.Text = HamDiaChiNhiPhanKQ();
		}

		private void btnGiaiMa_Click(object sender, EventArgs e)
		{
			txtXuatVanBan.Text = "";

			HamDiaChiNhiPhan(txtNhapVanBan.Text);
			GiaiMa();
			txtXuatVanBan.Text = HamDiaChiNhiPhanKQ();
		}

		private void btnDuyChuyen_Click(object sender, EventArgs e)
		{
			txtNhapVanBan.Text = txtXuatVanBan.Text;
            txtXuatVanBan.Text = "";
		}

		private void groupBox1_Enter(object sender, EventArgs e)
		{

		}

		private void Form1_Load(object sender, EventArgs e)
		{
			HamMaTranKhoa();
			MaTran();
			lblLoi.Enabled = false;
			btnGiaiMa.Enabled = false;
			btnMaHoa.Enabled = false;
			pictureBox2.Hide();
		}

		private void pictureBox1_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Chương trình thuộc sở hữu của tài khoản 'turgayozgur' \ntại nguồn https://github.com/turgayozgur/Playfair \nvà được chỉnh sửa bởi Đông Nguyễn kiucvohinh1997@gmail.com", "Thông tin chương trình!", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			pictureBox2.Hide();
			lblLoi.Enabled = false;
		}
	}
}
