using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FilmSalonSeansUygulamasi
{
    public partial class AnaForm : Form
    {
        private List<Film> filmler = new List<Film>();
        private List<Salon> salonlar = new List<Salon>();
        private List<Seans> seanslar = new List<Seans>();

        public AnaForm()
        {
            InitializeComponent();
        }

        // Film Tabı için event handlers
        private void BtnFilmEkle_Click(object sender, EventArgs e)
        {
            string filmAdi = txtFilmAdi.Text;
            if (string.IsNullOrEmpty(filmAdi))
            {
                MessageBox.Show("Lütfen bir film adı girin.");
                return;
            }

            // Yeni bir Film nesnesi oluştur
            Film yeniFilm = new Film();
            yeniFilm.FilmAdi = filmAdi;

            // Seans saatlerini al ve yeni filme ekle
            foreach (string saat in lstSeansSaatleri.Items)
            {
                yeniFilm.Seanslar.Add(saat);
            }

            // Filmi listeye ekle
            filmler.Add(yeniFilm);

            // Ekleme işlemi tamamlandı mesajı göster
            MessageBox.Show("Film başarıyla eklendi.");

            // Formu temizle
            Temizle();
        }

        private void BtnSeansEkle_Click(object sender, EventArgs e)
        {
            string seansSaat = txtSeansSaat.Text;
if (string.IsNullOrEmpty(seansSaat))
            {
                MessageBox.Show("Lütfen bir seans saati girin.");
                return;
            }

            // Seans saati listbox'a ekle
            lstSeansSaatleri.Items.Add(seansSaat);

            // Textbox'ı temizle
            txtSeansSaat.Clear();
        }

        // Salon Tabı için event handlers
        private void BtnSalonEkle_Click(object sender, EventArgs e)
        {
            string salonAdi = txtSalonAdi.Text;
            if (string.IsNullOrEmpty(salonAdi))
            {
                MessageBox.Show("Lütfen bir salon adı girin.");
                return;
            }

            int koltukKapasitesi;
            if (!int.TryParse(txtKoltukKapasitesi.Text, out koltukKapasitesi) || koltukKapasitesi <= 0)
            {
                MessageBox.Show("Lütfen geçerli bir koltuk kapasitesi girin.");
                return;
            }

            // Yeni bir Salon nesnesi oluştur
            Salon yeniSalon = new Salon();
            yeniSalon.SalonAdi = salonAdi;
            yeniSalon.KoltukKapasitesi = koltukKapasitesi;

            // Salonu listeye ekle
            salonlar.Add(yeniSalon);

            // Ekleme işlemi tamamlandı mesajı göster
            MessageBox.Show("Salon başarıyla eklendi.");

            // Formu temizle
            Temizle();
        }

        // Seans Tabı için event handlers
        private void BtnSeansAra_Click(object sender, EventArgs e)
        {
            DateTime tarihSaat = dtTarihSaat.Value;
// Seansları data grid üzerinde göster
            SeanslariGoster(tarihSaat);
        }

        private void SeanslariGoster(DateTime tarihSaat)
        {
            // Verilen tarihte geçerli seansları bul
            List<Seans> gecerliSeanslar = new List<Seans>();
            foreach (Seans seans in seanslar)
            {
                if (seans.TarihSaat.Date == tarihSaat.Date && seans.TarihSaat.TimeOfDay == tarihSaat.TimeOfDay)
                {
                    gecerliSeanslar.Add(seans);
                }
            }

            // Data grid'i güncelle
            dgvSeanslar.Rows.Clear();
            foreach (Seans seans in gecerliSeanslar)
            {
                dgvSeanslar.Rows.Add(seans.Film.FilmAdi, seans.Salon.SalonAdi, seans.BosKoltukSayisi());
            }
        }

        private void BtnYeniMusteriKaydi_Click(object sender, EventArgs e)
        {
            // Yeni müşteri kaydı formunu aç
            // Burada seçilen seans ve salon bilgileriyle yeni müşteri kaydı oluşturulabilir
            MessageBox.Show("Yeni müşteri kaydı oluşturulacak.");
        }

        private void Temizle()
        {
            txtFilmAdi.Clear();
            txtSeansSaat.Clear();
            lstSeansSaatleri.Items.Clear();
            txtSalonAdi.Clear();
            txtKoltukKapasitesi.Clear();
            dgvSeanslar.Rows.Clear();
        }

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabFilm = new System.Windows.Forms.TabPage();
            this.btnFilmEkle = new System.Windows.Forms.Button();
this.txtSeansSaat = new System.Windows.Forms.TextBox();
            this.lstSeansSaatleri = new System.Windows.Forms.ListBox();
            this.txtFilmAdi = new System.Windows.Forms.TextBox();
            this.lblSeansSaat = new System.Windows.Forms.Label();
            this.lblFilmAdi = new System.Windows.Forms.Label();
            this.tabSalon = new System.Windows.Forms.TabPage();
            this.btnSalonEkle = new System.Windows.Forms.Button();
            this.txtKoltukKapasitesi = new System.Windows.Forms.TextBox();
            this.txtSalonAdi = new System.Windows.Forms.TextBox();
            this.lblKoltukKapasitesi = new System.Windows.Forms.Label();
            this.lblSalonAdi = new System.Windows.Forms.Label();
            this.tabSeans = new System.Windows.Forms.TabPage();
            this.btnYeniMusteriKaydi = new System.Windows.Forms.Button();
            this.dgvSeanslar = new System.Windows.Forms.DataGridView();
            this.btnSeansAra = new System.Windows.Forms.Button();
            this.dtTarihSaat = new System.Windows.Forms.DateTimePicker();
            this.lblTarihSaat = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabFilm.SuspendLayout();
            this.tabSalon.SuspendLayout();
            this.tabSeans.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeanslar)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabFilm);
            this.tabControl.Controls.Add(this.tabSalon);
            this.tabControl.Controls.Add(this.tabSeans);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(776, 426);
            this.tabControl.TabIndex = 0;
            // 
            // tabFilm
            // 
            this.tabFilm.Controls.Add(this.btnFilmEkle);
            this.tabFilm.Controls.Add(this.txtSeansSaat);
            this.tabFilm.Controls.Add(this.lstSeansSaatleri);
            this.tabFilm.Controls.Add(this.txtFilmAdi);
            this.tabFilm.Controls.Add(this.lblSeansSaat);
            this.tabFilm.Controls.Add(this.lblFilmAdi);
            this.tabFilm.Location = new System.Drawing.Point(4, 22);
            this.tabFilm.Name = "tabFilm";
            this.tabFilm.Padding = new System.Windows.Forms.Padding(3);
            this.tabFilm.Size = new System.Drawing.Size(768, 400);
            this.tabFilm.TabIndex = 0;
            this.tabFilm.Text = "Film";
            this.tabFilm.UseVisualStyleBackColor = true;
            // 
            // btnFilmEkle
            // 
            this.btnFilmEkle.Location = new System.Drawing.Point(229, 147);
            this.btnFilmEkle.Name = "btnFilmEkle";
            this.btnFilmEkle.Size = new System.Drawing.Size(75, 23);
            this.btnFilmEkle.TabIndex = 5;
            this.btnFilmEkle.Text = "Ekle";
            this.btnFilmEkle.UseVisualStyleBackColor = true;
            this.btnFilmEkle.Click += new System.EventHandler(this.BtnFilmEkle_Click);
            // 
            // txtSeansSaat
            // 
            this.txtSeansSaat.Location = new System.Drawing.Point(118, 38);
            this.txtSeansSaat.Name = "txtSeansSaat";
            this.txtSeansSaat.Size = new System.Drawing.Size(186, 20);
            this.txtSeansSaat.TabIndex = 4;
            // 
            // lstSeansSaatleri
            // 
            this.lstSeansSaatleri.FormattingEnabled = true;
            this.lstSeansSaatleri.Location = new System.Drawing.Point(118, 64);
            this.lstSeansSaatleri.Name = "lstSeansSaatleri";
            this.lstSeansSaatleri.Size = new System.Drawing.Size(186, 69);
            this.lstSeansSaatleri.TabIndex = 3;
            // 
            // txtFilmAdi
            // 
            this.txtFilmAdi.Location = new System.Drawing.Point(118, 12);
            this.txtFilmAdi.Name = "txtFilmAdi";
            this.txtFilmAdi.Size = new System.Drawing.Size(186, 20);
            this.txtFilmAdi.TabIndex = 2;
            // 
            // lblSeansSaat
            // 
            this.lblSeansSaat.AutoSize = true;
            this.lblSeansSaat.Location = new System.Drawing.Point(27, 41);
            this.lblSeansSaat.Name = "lblSeansSaat";
            this.lblSeansSaat.Size = new System.Drawing.Size(68, 13);
            this.lblSeansSaat.TabIndex = 1;
            this.lblSeansSaat.Text = "Seans Saati:";
            // 
            // lblFilmAdi
            // 
            this.lblFilmAdi.AutoSize = true;
            this.lblFilmAdi.Location = new System.Drawing.Point(27, 15);
            this.lblFilmAdi.Name = "lblFilmAdi";
            this.lblFilmAdi.Size = new System.Drawing.Size(47, 13);
            this.lblFilmAdi.TabIndex = 0;
            this.lblFilmAdi.Text = "Film Adı:";
            // 
            // tabSalon
            // 
            this.tabSalon.Controls.Add(this.btnSalonEkle);
            this.tabSalon.Controls.Add(this.txtKoltukKapasitesi);
            this.tabSalon.Controls.Add(this.txtSalonAdi);
            this.tabSalon.Controls.Add(this.lblKoltukKapasitesi);
            this.tabSalon.Controls.Add(this.lblSalonAdi);
            this.tabSalon.Location = new System.Drawing.Point(4, 22);
            this.tabSalon.Name = "tabSalon";
            this.tabSalon.Padding = new System.Windows.Forms.Padding(3);
            this.tabSalon.Size = new System.Drawing.Size(768, 400);
            this.tabSalon.TabIndex = 1;
            this.tabSalon.Text = "Salon";
            this.tabSalon.UseVisualStyleBackColor = true;
            // 
            // btnSalonEkle
            // 
            this.btnSalonEkle.Location = new System.Drawing.Point(182, 82);
            this.btnSalonEkle.Name = "btnSalonEkle";
            this.btnSalonEkle.Size = new System.Drawing.Size(75, 23);
            this.btnSalonEkle.TabIndex = 4;
            this.btnSalonEkle.Text = "Ekle";
            this.btnSalonEkle.UseVisualStyleBackColor = true;
            this.btnSalonEkle.Click += new System.EventHandler(this.BtnSalonEkle_Click);
            // 
            // txtKoltukKapasitesi
            // 
            this.txtKoltukKapasitesi.Location = new System.Drawing.Point(112, 44);
            this.txtKoltukKapasitesi.Name = "txtKoltukKapasitesi";
            this.txtKoltukKapasitesi.Size = new System.Drawing.Size(145, 20);
            this.txtKoltukKapasitesi.TabIndex = 3;
            // 
            // txtSalonAdi
            // 
            this.txtSalonAdi.Location = new System.Drawing.Point(112, 18);
            this.txtSalonAdi.Name = "txtSalonAdi";
            this.txtSalonAdi.Size = new System.Drawing.Size(145, 20);
            this.txtSalonAdi.TabIndex = 2;
            // 
            // lblKoltukKapasitesi
            // 
            this.lblKoltukKapasitesi.AutoSize = true;
            this.lblKoltukKapasitesi.Location = new System.Drawing.Point(21, 47);
            this.lblKoltukKapasitesi.Name = "lblKoltukKapasitesi";
            this.lblKoltukKapasitesi.Size = new System.Drawing.Size(88, 13);
            this.lblKoltukKapasitesi.TabIndex = 1;
            this.lblKoltukKapasitesi.Text = "Koltuk Kapasitesi:";
            // 
            // lblSalonAdi
            // 
            this.lblSalonAdi.AutoSize = true;
            this.lblSalonAdi.Location = new System.Drawing.Point(21, 21);
            this.lblSalonAdi.Name = "lblSalonAdi";
            this.lblSalonAdi.Size = new System.Drawing.Size(55, 13);
            this.lblSalonAdi.TabIndex = 0;
            this.lblSalonAdi.Text = "Salon Adı:";
            // 
            // tabSeans
            // 
            this.tabSeans.Controls.Add(this.btnYeniMusteriKaydi);
            this.tabSeans.Controls.Add(this.dgvSeanslar);
            this.tabSeans.Controls.Add(this.btnSeansAra);
            this.tabSeans.Controls.Add(this.dtTarihSaat);
            this.tabSeans.Controls.Add(this.lblTarihSaat);
            this.tabSeans.Location = new System.Drawing.Point(4, 22);
            this.tabSeans.Name = "tabSeans";
            this.tabSeans.Padding = new System.Windows.Forms.Padding(3);
            this.tabSeans.Size = new System.Drawing.Size(768, 400);
            this.tabSeans.TabIndex = 2;
            this.tabSeans.Text = "Seans";
            this.tabSeans.UseVisualStyleBackColor = true;
            // 
            // btnYeniMusteriKaydi
            // 
            this.btnYeniMusteriKaydi.Location = new System.Drawing.Point(652, 6);
            this.btnYeniMusteriKaydi.Name = "btnYeniMusteriKaydi";
            this.btnYeniMusteriKaydi.Size = new System.Drawing.Size(110, 23);
            this.btnYeniMusteriKaydi.TabIndex = 4;
            this.btnYeniMusteriKaydi.Text = "Yeni Müşteri Kaydı";
            this.btnYeniMusteriKaydi.UseVisualStyleBackColor = true;
            this.btnYeniMusteriKaydi.Click += new System.EventHandler(this.BtnYeniMusteriKaydi_Click);
            // 
            // dgvSeanslar
            // 
            this.dgvSeanslar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeanslar.Location = new System.Drawing.Point(10, 39);
            this.dgvSeanslar.Name = "dgvSeanslar";
            this.dgvSeanslar.Size = new System.Drawing.Size(752, 355);
            this.dgvSeanslar.TabIndex = 3;
            // 
            // btnSeansAra
            // 
            this.btnSeansAra.Location = new System.Drawing.Point(240, 8);
            this.btnSeansAra.Name = "btnSeansAra";
            this.btnSeansAra.Size = new System.Drawing.Size(75, 23);
            this.btnSeansAra.TabIndex = 2;
            this.btnSeansAra.Text = "Ara";
            this.btnSeansAra.UseVisualStyleBackColor = true;
            this.btnSeansAra.Click += new System.EventHandler(this.BtnSeansAra_Click);
            // 
            // dtTarihSaat
            // 
            this.dtTarihSaat.Location = new System.Drawing.Point(94, 10);
            this.dtTarihSaat.Name = "dtTarihSaat";
            this.dtTarihSaat.Size = new System.Drawing.Size(140, 20);
            this.dtTarihSaat.TabIndex = 1;
            // 
            // lblTarihSaat
            // 
            this.lblTarihSaat.AutoSize = true;
            this.lblTarihSaat.Location = new System.Drawing.Point(7, 12);
            this.lblTarihSaat.Name = "lblTarihSaat";
            this.lblTarihSaat.Size = new System.Drawing.Size(64, 13);
            this.lblTarihSaat.TabIndex = 0;
            this.lblTarihSaat.Text = "Tarih ve Saat:";
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Name = "AnaForm";
            this.Text = "Film Salon Seans Uygulaması";
            this.tabControl.ResumeLayout(false);
            this.tabFilm.ResumeLayout(false);
            this.tabFilm.PerformLayout();
            this.tabSalon.ResumeLayout(false);
            this.tabSalon.PerformLayout();
            this.tabSeans.ResumeLayout(false);
            this.tabSeans.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeanslar)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabFilm;
        private System.Windows.Forms.Button btnFilmEkle;
        private System.Windows.Forms.TextBox txtSeansSaat;
        private System.Windows.Forms.ListBox lstSeansSaatleri;
        private System.Windows.Forms.TextBox txtFilmAdi;
        private System.Windows.Forms.Label lblSeansSaat;
        private System.Windows.Forms.Label lblFilmAdi;
        private System.Windows.Forms.TabPage tabSalon;
        private System.Windows.Forms.Button btnSalonEkle;
        private System.Windows.Forms.TextBox txtKoltukKapasitesi;
        private System.Windows.Forms.TextBox txtSalonAdi;
        private System.Windows.Forms.Label lblKoltukKapasitesi;
        private System.Windows.Forms.Label lblSalonAdi;
        private System.Windows.Forms.TabPage tabSeans;
        private System.Windows.Forms.Button btnYeniMusteriKaydi;
        private System.Windows.Forms.DataGridView dgvSeanslar;
        private System.Windows.Forms.Button btnSeansAra;
        private System.Windows.Forms.DateTimePicker dtTarihSaat;
        private System.Windows.Forms.Label lblTarihSaat;
    }

    public class Film
    {
        public string FilmAdi { get; set; }
        public List<string> Seanslar { get; set; }

        public Film()
        {
            Seanslar = new List<string>();
        }
    }

    public class Salon
    {
        public string SalonAdi { get; set; }
        public int KoltukKapasitesi { get; set; }
    }

    public class Seans
    {
        public Film Film { get; set; }
        public Salon Salon { get; set; }
        public DateTime TarihSaat { get; set; }
        public List<int> DoluKoltuklar { get; set; }

        public Seans()
        {
            DoluKoltuklar = new List<int>();
        }

        public int BosKoltukSayisi()
        {
            return Salon.KoltukKapasitesi - DoluKoltuklar.Count;
        }
    }
}
