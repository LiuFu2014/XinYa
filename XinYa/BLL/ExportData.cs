using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;//Missing(Excel)-->SQLDataToExcel

public class ExportData
{
    static StreamWriter writer = null;

    /// <summary>
    /// ������±�
    /// </summary>
    /// <param name="lv">ListView</param>
    public static void SaveToNotePad(ListView lv)
    {
        #region

        FileStream outputfile = null; // д�ļ�

        SaveFileDialog saveDlg = new SaveFileDialog();
        saveDlg.DefaultExt = "xls";
        saveDlg.Filter = "�ı��ļ�(*.txt)|*.txt|�ı��ļ�(*.ini)|*.ini|�����ļ�(*.*)|*.*";
        saveDlg.Title = "�ļ����Ϊ";

        try
        {
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                outputfile = new FileStream(saveDlg.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                writer = new StreamWriter(outputfile);
                writer.BaseStream.Seek(0, SeekOrigin.End);

                for (int i = 0; i < lv.Items.Count; i++)
                {
                    DoWrite(lv.Columns[0].Text + ":" + lv.Items[i].Text);
                    for (int j = 1; j < lv.Columns.Count; j++)
                    {
                        DoWrite(lv.Columns[j].Text + ":" + lv.Items[i].SubItems[j].Text);
                    }
                    DoWrite("--------");
                }
                writer.Close();
                MessageBox.Show("�ѽ����ݳɹ�������±���" + saveDlg.FileName + " �У�");
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
            outputfile = null;
            writer = null;
            saveDlg.Dispose();
        }

        #endregion
    }

    /// <summary>
    /// ������±�
    /// </summary>
    /// <param name="dv">DataGridView</param>
    public static void SaveToNotePad(DataGridView dv)
    {
        #region

        //if (File.Exists(filepath))
        //{
        //    Response.Write("<script>(confirm('�ļ����ڣ��ǲ���Ҫ�滻��');</script>");
        //}

        FileStream outputfile = null; // д�ļ�

        SaveFileDialog saveDlg = new SaveFileDialog();
        saveDlg.DefaultExt = "xls";
        saveDlg.Filter = "�ı��ļ�(*.txt)|*.txt|�ı��ļ�(*.ini)|*.ini|�����ļ�(*.*)|*.*";
        saveDlg.Title = "�ļ����Ϊ";

        try
        {
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(saveDlg.FileName)) File.Delete(saveDlg.FileName);

                outputfile = new FileStream(saveDlg.FileName, FileMode.Create, FileAccess.Write);//OpenOrCreate
                writer = new StreamWriter(outputfile);
                writer.BaseStream.Seek(0, SeekOrigin.End);

                for (int i = 0; i < dv.RowCount; i++)
                {
                    for (int j = 0; j < dv.Columns.Count; j++)
                    {
                        DoWrite(dv.Columns[j].Name.ToString() + ":" + dv.Rows[i].Cells[j].Value.ToString());
                    }
                    DoWrite("--------");
                }
                writer.Close();
                MessageBox.Show("�ѽ����ݳɹ�������±���" + saveDlg.FileName + " �У�");
            }

        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
            outputfile = null;
            writer = null;
            saveDlg.Dispose();
        }

        #endregion
    }

    /// <summary>
    /// 11.5,Writed by Fufu
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static bool SaveToTxt(string text)
    {
        FileStream outputfile = null; // д�ļ�

        SaveFileDialog saveDlg = new SaveFileDialog();
        saveDlg.DefaultExt = "xls";
        saveDlg.Filter = "�ı��ļ�(*.txt)|*.txt|�ı��ļ�(*.ini)|*.ini|�����ļ�(*.*)|*.*";
        saveDlg.Title = "�ļ����Ϊ";

        try
        {
            if (saveDlg.ShowDialog() == DialogResult.OK)
            {
                if (File.Exists(saveDlg.FileName)) File.Delete(saveDlg.FileName);

                outputfile = new FileStream(saveDlg.FileName, FileMode.Create, FileAccess.Write);//OpenOrCreate
                writer = new StreamWriter(outputfile);
                writer.BaseStream.Seek(0, SeekOrigin.End);

                writer.Write(text);

                writer.Close();
                //MessageBox.Show("�ѽ����ݳɹ�������±���" + saveDlg.FileName + " �У�");
                return true;
            }
        }
        catch (Exception ex)
        {
            //MessageBox.Show(ex.ToString());
            outputfile = null;
            writer = null;
            saveDlg.Dispose();
            return false;
        }

        return false;
    }

    public static void DoWrite(String line)
    {
        line += "\r\n";			// ���ϻ��з�

        byte[] binfo = new System.Text.UTF8Encoding(true).GetBytes(line);
        char[] info = new System.Text.UTF8Encoding(true).GetChars(binfo);

        writer.Write(info, 0, info.Length);//writer.WriteLine(line);
        writer.Flush();
    }


    /// <summary>
    ///   �Բ���Excel�ؼ��ķ�ʽ��DataGridView���ݵ�����Excel   add   by   sunny   2007/1/18 
    /// </summary > 
    /// <param   name= "GridView " >DataGridView���� </param > 
    /// <param   name= "strExcelFile " >Excel�ļ��� </param > 
    /// <param   name= "strError " >out���������س�����Ϣ </param > 
    /// <returns > 
    ///         -1   ���� 
    ///         0   �ɹ� 
    /// </returns > 
    public static int DataGridViewToExcel(System.Windows.Forms.DataGridView GridView)
    {
        #region

        int nRet = 0;

        SaveFileDialog saveDlg1 = new SaveFileDialog();
        saveDlg1.DefaultExt = "xls";
        saveDlg1.Filter = "Microsoft Office Excel�ļ�(*.xls)|*.xls|�����ļ�(*.*)|*.*";
        saveDlg1.Title = "�ļ����Ϊ";//saveDlg1.FileName
        //saveDlg1.InitialDirectory = Directory.GetCurrentDirectory();   

        //if (saveDlg1.ShowDialog() == DialogResult.Cancel) return nRet;
        if (saveDlg1.ShowDialog() == DialogResult.Cancel) return -1;


        Excel.Application xlApp = new Excel.Application();
        Excel.Workbooks workbooks = xlApp.Workbooks;
        Excel.Workbook workbook = workbooks.Add(Excel.XlWBATemplate.xlWBATWorksheet);
        Excel.Worksheet worksheet = (Excel.Worksheet)workbook.Worksheets[1];//ȡ��sheet1 

        try
        {
            //~~ 
            //   д�ֶ��� 
            for (int i = 0; i < GridView.Columns.Count; i++)
            {
                worksheet.Cells[1, i + 1] = GridView.Columns[i].HeaderText.ToString();
            }

            //   д��¼ 
            for (int i = 0; i < GridView.Rows.Count; i++)
            {
                for (int j = 0; j < GridView.Columns.Count; j++)
                {
                    //Fu_�ҵĺܶ�dgv���涼�Ǹ����࣬�޷���������䵼��
                    //worksheet.Cells[i + 2, j + 1] = GridView.Rows[i].Cells[j].Value.ToString();
                    //Fu_11.5_��д����ȡ��ʽ�����ֵ
                    //worksheet.Cells[i + 2, j + 1] = GridView.Rows[i].Cells[j].EditedFormattedValue == null ? "" : GridView.Rows[i].Cells[j].EditedFormattedValue.ToString();
                    string value = GridView.Rows[i].Cells[j].EditedFormattedValue == null ? "" : GridView.Rows[i].Cells[j].EditedFormattedValue.ToString();
                    if (value.Length>11)
                    {
                        value = "'" + value;
                    }
                    worksheet.Cells[i + 2, j + 1] = value;
                }
            }

            worksheet.Columns.EntireColumn.AutoFit();//�Զ���Ӧÿ�еĿ��   add   by   sunny.li 
            //�������ᱨ��
            //Excel.Range rg = worksheet.get_Range(worksheet.Cells[1, 1], worksheet.Cells[1, GridView.Columns.Count]);
            //Fu_csdn�ϵ�д�� �� Ĥ�ݴ���...
            Excel.Range rg = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, GridView.Columns.Count]];
            rg.Font.Bold = true;
            workbook.Saved = true;
            workbook.SaveCopyAs(saveDlg1.FileName);

            //   �ص��ڴ��еĽ��� 

            // xlApp.Quit();

            nRet = 0;
        }
        catch (Exception ex)
        {
            //strError = ex.ToString();
            //MessageBox.Show(ex.ToString());
            nRet = -1;
        }

        return nRet;
        #endregion
    }


    /// <summary>
    /// ��ȡExcel�ļ��������ݴ洢��DataSet��
    /// </summary>
    /// <param name="opnFileName">��·����Excel�ļ���</param>
    /// <returns>DataSet</returns>
    public static DataSet ExcelToDataSet(string TableName)
    {
        #region

        string strExcel = "";

        OpenFileDialog openDlg1 = new OpenFileDialog();
        openDlg1.DefaultExt = "xls";
        openDlg1.Filter = "Microsoft Office Excel�ļ�(*.xls)|*.xls|�����ļ�(*.*)|*.*";
        openDlg1.Title = "��";
        //saveDlg1.InitialDirectory = Directory.GetCurrentDirectory();   

        if (openDlg1.ShowDialog() == DialogResult.Cancel) return null;

        string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + openDlg1.FileName + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
        OleDbConnection conn = new OleDbConnection(strConn);
        OleDbDataAdapter da = null;
        DataSet ds = new DataSet();

        strExcel = "select * from [sheet1$]";
        //strExcel = string.Format("select * from [{0}$]", "sheet1");


        try
        {
            da = new OleDbDataAdapter(strExcel, strConn);
            da.Fill(ds, TableName);

            //��bcp��������
            //using (System.Data.SqlClient.SqlBulkCopy bcp = new System.Data.SqlClient.SqlBulkCopy(Login.Cn()))
            //{
            //    //bcp.SqlRowsCopied += new System.Data.SqlClient.SqlRowsCopiedEventHandler(bcp_SqlRowsCopied);
            //    bcp.BatchSize = 100;//ÿ�δ��������
            //    bcp.NotifyAfter = 100;//������ʾ������
            //    bcp.DestinationTableName = TableName;//Ŀ���
            //    bcp.WriteToServer(ds.Tables[0]);
            //}

            return ds;
        }
        catch (Exception ex)
        {
            MessageBox.Show("�������" + ex, "������Ϣ");
            return ds;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
        }
        #endregion
    }

    ////������ʾ
    //void bcp_SqlRowsCopied(object sender, System.Data.SqlClient.SqlRowsCopiedEventArgs e)
    //{
    //    this.Text = e.RowsCopied.ToString();
    //    this.Update();
    //}

    /// <summary> 
    /// ֱ�ӵ���Sql�����ݵ�excel --��excel��QueryTable�����������ݵĵ������
    /// </summary> 
    /// <param name="connectionString">�����ַ���</param> 
    /// <param name="sql">��ѯ���</param> 
    /// <param name="fileName">�ļ���</param> 
    /// <param name="sheetName">����</param> 
    /// <returns>���ֵ</returns>
    //public static bool SQLDataToExcel(string connectionString, string sql, string fileName, string sheetName)
    //{
    //    #region
    //    //SQLDataToExcel("Provider=SQLOLEDB.1;sever=localhost;uid=sa;password=123;database=autowarehouse;",
    //    //"select * from tblmaterialno", @"c:\testOle.xls", "tblmaterialno"); 

    //    Excel.Application app = new Excel.ApplicationClass();
    //    Excel.Workbook wb = (Excel.WorkbookClass)app.Workbooks.Add(Missing.Value);
    //    Excel.Worksheet ws = wb.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value) as Excel.Worksheet;
    //    ws.Name = sheetName;

    //    try
    //    {
    //        Excel.QueryTable qt = ws.QueryTables.Add("OLEDB;" + connectionString,
    //            ws.get_Range("A1", Missing.Value), sql);
    //        qt.Refresh(false);//�Ƿ��첽��ѯ 
    //    }
    //    catch (Exception ex)
    //    {
    //        string str = ex.Message;
    //    }
    //    finally
    //    {
    //        wb.Saved = true;
    //        wb.SaveCopyAs(fileName);//���� 
    //        app.Quit();//�رս��� 
    //    }
    //    return true;
    //    #endregion
    //}
}

