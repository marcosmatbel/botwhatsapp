using OfficeOpenXml;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoIt;

namespace Whatsapp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnEnviar.Enabled = false;
            btnexport.Enabled = false;
            btnCancelar.Enabled = false;
            btn_SendMedia.Enabled = this.chkVideo.Checked;
            btn_SendDocuments.Enabled = this.chkDocuments.Checked;
            btnEnviar.ImageIndex = 1;
            btnCancelar.ImageIndex = 2;
        }
        
        IWebDriver driver;
        Thread threadObj;
        private bool sendfiles = false;
        private int xpos = 0, ypos = 0;

        private void KillWebDriver()
        {
            try
            {
                driver.Quit();
            }
            catch(Exception ex) { }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ypos = this.Height - 70;
            timer1.Start();
            var MachineName = System.Environment.MachineName;
            if (MachineName.ToString().IndexOf("KLE") == -1)
            {
                //MessageBox.Show("LICENCIADO PARA USO EXCLUSIVO KLEFFMANN BR", "OBRIGADO POR RESPEITAR ISTO!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //this.btnopenfile.Enabled = false;
                //return;
            }
            KillWebDriver();
            dg.Columns.Add("TELEFONE", "TELEFONE");
            dg.Columns.Add("RETORNO", "RETORNO" );
            dg.Columns.Add("DATA", "DATA");
            dg.Columns[2].Width = 180;
            //dg.Rows.Add("1234", "ENVIADO", DateTime.Now);
            
        }

        private bool CheckLoggedIn()
        {
            try
            {
                return driver.FindElement(By.ClassName("_3RWII")).Displayed;

            }
            catch (Exception ex)
            {
                //MessageBox.Show(e.Message);
                return false;
            }
        }

        private void checkalert()
        {
            try
            {
                var alert = driver.SwitchTo().Alert();
                if(alert != null)
                {
                    alert.Accept();
                }
               
            }
            catch(Exception ex)
            {

            }
        }

        private bool SendMessage(string telefone, string message)
        {
            try
            {
                checkalert();
                //Thread.Sleep(5000);
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                driver.Navigate().GoToUrl("https://wa.me/" + telefone);
                Thread.Sleep(1000);
                driver.FindElement(By.XPath("//*[@id='action-button']")).Click();
                Thread.Sleep(20000);
                checkalert();
                

                var input_box = driver.FindElement(By.XPath("//*[@id='main']/footer/div[1]/div[2]/div/div[2]"));
                if(input_box != null)
                {
                    if (chkVideo.Checked)
                    {
                        try
                        {
                            SendAttachment();
                            sendfiles = true;
                        }
                        catch (Exception e)
                        {
                            sendfiles = false;
                        }
                    }
                    if (chkDocuments.Checked)
                    {
                        try
                        {
                            SendDocuments();
                            sendfiles = true;
                        }
                        catch (Exception e)
                        {
                            sendfiles = false;
                        }
                    }
                }
                input_box.SendKeys(message);
                Thread.Sleep(3000);
                input_box.SendKeys(OpenQA.Selenium.Keys.Enter);
                Thread.Sleep(5000);
                return true;
            }
            catch (Exception ex)
            {
                Thread.Sleep(5000);
                return false;
            }


        }

        private void btnopenfile_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Selecionar Arquivo Excel";
            openFileDialog1.Filter = "Excel Files|*.xlsx";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.ReadOnlyChecked = true;
            openFileDialog1.ShowReadOnly = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txtfilename.Text = openFileDialog1.FileName;
                btnEnviar.Enabled = true;
            }
            

        }

        private void btnexport_Click(object sender, EventArgs e)
        {
            try
            {
                folderBrowserDialog1.Description = "SELECIONE AONDE DESEJA SALVAR O ARQUIVO";
                ExcelPackage package = new ExcelPackage();
                var worksheet = package.Workbook.Worksheets.Add("RETORNO MENSAGENS ENVIADAS");
                worksheet.TabColor = System.Drawing.Color.Black;
                worksheet.Cells[1, 1].Value = "TELEFONE";
                worksheet.Cells[1, 2].Value = "RETORNO";
                int i = 2;
                foreach (DataGridViewRow row in dg.Rows)
                {
                    worksheet.Cells[i, 1].Value = row.Cells["TELEFONE"].Value;
                    worksheet.Cells[i, 2].Value = row.Cells["RETORNO"].Value;
                    worksheet.Cells[i, 3].Value = row.Cells["DATA"].Value;
                    i++;
                }
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    var filename = folderBrowserDialog1.SelectedPath + "/RETORNO_WHATSAPP_" + DateTime.Now.ToShortDateString().Replace("/", "").Replace(" ", "") + "_" + DateTime.Now.ToLongTimeString().Replace(":", "") + ".xlsx";
                    FileStream fs = new FileStream(filename, FileMode.Create);
                    package.SaveAs(fs);
                    fs.Close();
                    package.Dispose();
                    if(MessageBox.Show("ARQUIVO SALVO COM SUCESSO\nDESEJA ABRIR O ARQUIVO?","ARQUIVO SALVO",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
                    {
                        FileInfo fi = new FileInfo(filename);
                        if (fi.Exists)
                        {
                            System.Diagnostics.Process.Start(filename);
                        }
                        else { /*file doesn't exist*/ }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("OCORREU UM ERRO\n" + ex.Message+"\nAVISE O RESPONSÁVEL", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            

        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            dg.Rows.Clear();
            btnexport.Enabled = true;
            if (LogginWhatsApp())
            {
                btnCancelar.Enabled = true;
                //ThreadPool.QueueUserWorkItem(new WaitCallback(o => SendWhatsapp()));
                threadObj = new Thread(() => SendWhatsapp());
                threadObj.Start();
                //SendWhatsapp();
            }
        }

        private bool LogginWhatsApp()
        {
            bool logged=false;
            try
            {
                if (txtfilename.Text.Length > 0)
                    using (var package = new ExcelPackage(openFileDialog1.OpenFile()))
                    {
                        driver = new ChromeDriver();
                        driver.Navigate().GoToUrl("https://web.whatsapp.com");
                        while (true)
                        {
                            //Console.WriteLine("Login to WhatsApp Web and Press Enter");
                            //Console.ReadLine();
                            if (CheckLoggedIn())
                            {
                                logged = true;
                                break;
                            }
                                
                        }
                    }
                return logged;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        private void SendWhatsapp()
        {
            if (txtfilename.Text.Length > 0)
                using (var package = new ExcelPackage(openFileDialog1.OpenFile()))
                {
                    var workSheet = package.Workbook.Worksheets.First(); // ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                    for (int i = 2; i <= workSheet.Dimension.End.Row; i++)
                    {
                        var telefone = "55" + workSheet.Cells[i, 1].Value.ToString().Trim().TrimEnd().TrimStart().Replace("-", "").Replace(" ", "").Replace("55", "");
                        var mensagem = workSheet.Cells[i, 2].Value.ToString().Trim().TrimEnd().TrimStart();
                        var issent = SendMessage(telefone, mensagem);
                        this.Invoke(new MethodInvoker(delegate ()
                        {
                            dg.Rows.Add(telefone, (issent?"ENVIADO" : "ERRO AO ENVIAR"),DateTime.Now.ToShortDateString() +" "+DateTime.Now.AddMilliseconds(900).ToShortTimeString());
                        })); 
                    }
                    driver.Quit();
                }
        }

        private void SendAttachment()
        {
            if (txtMedia.Text.Length > 0)
            {
                var clipButton = driver.FindElement(By.XPath("//*[@id='main']/header/div[3]/div/div[2]/div/span"));
                clipButton.Click();
                Thread.Sleep(2000);

                var mediaButton = driver.FindElement(By.XPath("//*[@id='main']/header/div[3]/div/div[2]/span/div/div/ul/li[1]/button"));
                mediaButton.Click();
                Thread.Sleep(4000);

                var image_path = txtMedia.Text.TrimStart().TrimEnd();
                AutoIt.AutoItX.ControlFocus("Abrir", "Abrir", "Edit1");
                AutoIt.AutoItX.ControlSetText("Abrir", "Abrir", "Edit1", (image_path));
                AutoIt.AutoItX.ControlClick("Abrir", "Abrir", "Button1");
                Thread.Sleep(4000);

                //var whatsapp_send_button = driver.FindElement(By.XPath("//*[@id='app']/div/div/div[2]/div[2]/span/div/span/div/div/div[2]/span[2]/div/div/span"));
                var whatsapp_send_button = driver.FindElement(By.CssSelector("span[data-icon='send-light']"));
                whatsapp_send_button.Click();
            }
        }

        private void SendDocuments()
        {
            if (txtMedia.Text.Length > 0)
            {
                var clipButton = driver.FindElement(By.XPath("//*[@id='main']/header/div[3]/div/div[2]/div/span"));
                clipButton.Click();
                Thread.Sleep(2000);

                var mediaButton = driver.FindElement(By.XPath("//*[@id='main']/header/div[3]/div/div[2]/span/div/div/ul/li[3]/button"));
                mediaButton.Click();
                Thread.Sleep(4000);

                var image_path = txtDocuments.Text.TrimStart().TrimEnd();
                AutoIt.AutoItX.ControlFocus("Abrir", "Abrir", "Edit1");
                AutoIt.AutoItX.ControlSetText("Abrir", "Abrir", "Edit1", (image_path));
                AutoIt.AutoItX.ControlClick("Abrir", "Abrir", "Button1");
                Thread.Sleep(4000);

                //var whatsapp_send_button = driver.FindElement(By.XPath("//*[@id='app']/div/div/div[2]/div[2]/span/div/span/div/div/div[2]/span[2]/div/div/span"));
                var whatsapp_send_button = driver.FindElement(By.CssSelector("span[data-icon='send-light']"));
                whatsapp_send_button.Click();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            threadObj.Abort();
            
            MessageBox.Show("PROCESSO CANCELADO");
        }

        private void txtfilename_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            KillWebDriver();
        }

        private void Btn_SendMedia_Click(object sender, EventArgs e)
        {
            openFileDialog2.Title = "Selecionar Arquivo";
            openFileDialog2.Filter = "Media files (*.jpg; *.jpeg; *.jpe; *.png) | *.jpg; *.jpeg; *.jpe; *.png | Video Files(*.avi; *.3GP) | *.avi; *.3GP";
            openFileDialog2.CheckFileExists = true;
            openFileDialog2.CheckPathExists = true;
            openFileDialog2.FilterIndex = 2;
            openFileDialog2.ReadOnlyChecked = true;
            openFileDialog2.ShowReadOnly = true;

            if (openFileDialog2.ShowDialog() == DialogResult.OK)
            {
                var size = new FileInfo(openFileDialog2.FileName).Length;
                if(size > (16 * 125000))
                {
                    MessageBox.Show("TAMANHO EXCEDIDO, MAXIMO PERMITIDO 16MB", "OPS... ALGO DEU ERRADO!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                txtMedia.Text = openFileDialog2.FileName;
                //btnEnviar.Enabled = true;
            }
        }

        private void ChkVideo_CheckedChanged(object sender, EventArgs e)
        {
            btn_SendMedia.Enabled = this.chkVideo.Checked;
        }

        private void ChkDocuments_CheckedChanged(object sender, EventArgs e)
        {
            btn_SendDocuments.Enabled = this.chkDocuments.Checked;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (xpos == 0)
            {
                this.creditos.Location = new System.Drawing.Point(this.Width, ypos);
                xpos = this.Width;
            }
            else
            {
                this.creditos.Location = new System.Drawing.Point(xpos, ypos);
                xpos -= 2;
            }
        }

        private void Btn_SendDocuments_Click(object sender, EventArgs e)
        {
            openFileDialog3.Title = "Selecionar Arquivo";
            openFileDialog3.Filter = "documentos files (*.doc; *.docx; *.xls; *.xlsx; *.pptx; *.ppt; *.pdf) | *.doc; *.docx; *.xls; *.xlsx; *.pptx; *.ppt; *.pdf";
            openFileDialog3.CheckFileExists = true;
            openFileDialog3.CheckPathExists = true;
            openFileDialog3.FilterIndex = 2;
            openFileDialog3.ReadOnlyChecked = true;
            openFileDialog3.ShowReadOnly = true;

            if (openFileDialog3.ShowDialog() == DialogResult.OK)
            {
                var size = new FileInfo(openFileDialog3.FileName).Length;
                if (size > (16 * 125000))
                {
                    MessageBox.Show("TAMANHO EXCEDIDO, MAXIMO PERMITIDO 16MB", "OPS... ALGO DEU ERRADO!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                txtDocuments.Text = openFileDialog3.FileName;
            }
        }
    }
}
