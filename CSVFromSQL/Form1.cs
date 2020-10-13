using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Google;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Tesseract;

namespace CSVFromSQL
{
    public partial class Form1 : Form
    {
        private string _connectionString;
        public Form1()
        {
            InitializeComponent();
        }

        private string GetConnectionStringFromAppConfig()
        {
            string _result = "";

            Configuration roamingConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            configFileMap.ExeConfigFilename = roamingConfig.FilePath;

            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
            ConnectionStringsSection connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");

            _result = connectionStringsSection.ConnectionStrings["DBConnectionString"]?.ConnectionString;

            return _result;
        }

        private void grpCommandType_Enter(object sender, EventArgs e)
        {

        }

        private void refreshControls()
        {
            if (rdStoredProcedure.Checked)
            {
                pnlStoredProcedure.Visible = true;
                pnlSQLStatement.Visible = false;
            }
            if (rdSqlStatement.Checked)
            {
                pnlSQLStatement.Visible = true;
                pnlStoredProcedure.Visible = false;
            }
        }

        private void rdStoredProcedure_CheckedChanged(object sender, EventArgs e)
        {
            refreshControls();
        }

        private void rdSqlStatement_CheckedChanged(object sender, EventArgs e)
        {
            refreshControls();
        }

        private string ReadTextFromImage()
        {
            string result = "";
            var imageConverter = new BitmapToPixConverter();
            Pix image = imageConverter.Convert(new Bitmap(@"E:\CompanyID.JPG"));
            TesseractEngine ocr = new TesseractEngine(@"E:\tessdata", "eng");
            var ocrResult = ocr.Process(image,region: Rect.Empty);
            result = ocrResult.GetText();
            //MessageBox.Show(ocrResult.GetText());
            

            return result;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            rdStoredProcedure.Checked = false;
            rdSqlStatement.Checked = true;
            _connectionString = GetConnectionStringFromAppConfig();
            txtFilename.Text = ReadTextFromImage();
            refreshControls();
        }

        private void ExecuteCommand()
        {
            
            DataTable dt = new DataTable();
            if (rdSqlStatement.Checked)
            {
                var commandText = txtSQLCommandText.Text;
                if (commandText.Contains("update ") || commandText.Contains("delete ") || commandText.Contains("alter "))
                {
                    MessageBox.Show("Only Select statements please.");
                }
                else if (commandText.Contains("select "))
                {
                    using (System.Data.SqlClient.SqlConnection conn = new System.Data.SqlClient.SqlConnection(this._connectionString))
                    {
                        conn.Open();
                        using (var transaction = conn.BeginTransaction("SQLFetchOnlyTransaction"))
                        using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand())
                        {
                            cmd.CommandTimeout = 0;
                            cmd.CommandText = commandText;
                            cmd.Connection = conn;
                            cmd.Transaction = transaction;
                            cmd.CommandType = CommandType.Text;
                            System.Data.SqlClient.SqlDataAdapter adapter = new System.Data.SqlClient.SqlDataAdapter(cmd);
                            adapter.Fill(dt);
                            transaction.Rollback("SQLFetchOnlyTransaction");
                            transaction.Dispose();
                            cmd.Dispose();
                        }
                        conn.Close();
                    }
                }
            }
            else if (rdStoredProcedure.Checked)
            {

            }
            if (WriteDataTableToCSV(dt, $"{txtFileLocation.Text}\\{txtFilename.Text}.csv"))
            {
                MessageBox.Show("Successfully exported results");
            }
            else
            {
                MessageBox.Show("Failed to write to file");
            }
        }
        private bool WriteDataTableToCSV(DataTable dt, string filename)
        {
            bool result = false;
            string projectID = "gocery-1098";
            //Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", @"‪C:\certs\gocery-1098-1b746097984e.json");
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "e:\\gcpkeys.json");
            //var credential = GoogleCredential.FromFile(@"‪‪E:/gocery-1098-c95031a7e4cb.p12");
            //var credential = GoogleCredential.GetApplicationDefault();
            StorageClient storageClient = StorageClient.Create();
            string bucketName = "ftt_testbucket";

            ///
            try
            {
                storageClient.CreateBucket(projectID, bucketName);
            }
            catch(GoogleApiException e)
            when(e.Error.Code==409)
            {
                MessageBox.Show(e.Error.Message);
            }

            ///

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (StreamWriter writer = new StreamWriter(memoryStream))
                {
                    try
                    {
                        IEnumerable<String> headers = dt.Columns.OfType<DataColumn>().Select(c => String.Concat("\"",c.ColumnName,"\""));
                        writer.WriteLine(String.Join(",", headers));

                        IEnumerable<String> row = null;
                        foreach (DataRow curRow in dt.Rows)
                        {
                            row = curRow.ItemArray.Select(o => o?.ToString() ?? String.Empty);
                            writer.WriteLine(String.Join(",", row));
                        }
                        writer.Flush();
                        File.WriteAllBytes(filename, memoryStream.ToArray());
                        result = true;
                    }
                    catch(Exception e)
                    {
                        result = false;
                    }
                }                
            }
            if(result)
            {
                using (var f = File.OpenRead(filename))
                {
                    var objectName = Path.GetFileName(filename);
                    storageClient.UploadObject(bucketName, objectName, null, f);
                    MessageBox.Show("Uploaded");
                }
            }
            return result;
        }
        private void btnExecute_Click(object sender, EventArgs e)
        {
            //if(string.IsNullOrEmpty(txtDelimiter.Text))
            //{
            //    MessageBox.Show("You did not provide a delimeter. A Comma will be used.");
            //    txtDelimiter.Text = ",";
            //}
            //if(string.IsNullOrEmpty(txtFilename.Text))
            //{
            //    MessageBox.Show("Please provide filename.");
            //    return;
            //}
            //if(string.IsNullOrEmpty(txtFileLocation.Text))
            //{
            //    MessageBox.Show("Please provide file location.");
            //    return;
            //}
            ExecuteCommand();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog browserDialog = new FolderBrowserDialog();
            if(browserDialog.ShowDialog()==DialogResult.OK)
            {
                this.txtFileLocation.Text = browserDialog.SelectedPath;
            }            
        }
    }
}
