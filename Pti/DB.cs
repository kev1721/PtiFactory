using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;
using System.Data;

namespace Pti
{
    public class DB
    {
        public List<Korpus> GetKorpuses()
        {
            List <Korpus> lst_korpus = new List<Korpus>();

            string cmdTxt = "Select * from [parameters]";
            if (conn.State == System.Data.ConnectionState.Open)
            {
                OleDbCommand myCmd = new OleDbCommand(cmdTxt,conn);
                using (OleDbDataReader dr = myCmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        DateTime dt;
                        int lnk_t1, lnk_t2, lnk_vn, lnk_vl;
                        int t1_up, t1_dn, t2_up, t2_dn, vn_up, vn_dn;
                        string name, path;
                        Int16 pk;

                        pk = (Int16)dr["pk"];
                        if (dr["date_begin"] == DBNull.Value)
                            dt = DateTime.Parse("01.01.1900");
                        else
                            dt = (DateTime)dr["date_begin"];

                        name = (string)dr["name_korpus"];
                        path = (string)dr["path_file"];
                        int.TryParse((string)dr["lnk_t1"], out lnk_t1);
                        int.TryParse((string)dr["lnk_t2"], out lnk_t2);
                        int.TryParse((string)dr["lnk_vn"], out lnk_vn);
                        int.TryParse((string)dr["lnk_vl"], out lnk_vl);

                        int.TryParse((string)dr["t1_up"], out t1_up);
                        int.TryParse((string)dr["t1_dn"], out t1_dn);
                        int.TryParse((string)dr["t2_up"], out t2_up);
                        int.TryParse((string)dr["t2_dn"], out t2_dn);
                        int.TryParse((string)dr["vn_up"], out vn_up);
                        int.TryParse((string)dr["vn_dn"], out vn_dn);

                        bool i5 = (bool)dr["enabled"];
                        bool i6 = (bool)dr["sounded"];

                        lst_korpus.Add(new Korpus(
                            pk,
                            name,
                            path,
                            lnk_t1,
                            lnk_t2,
                            lnk_vn,
                            lnk_vl,
                            t1_up,
                            t1_dn,
                            t2_up,
                            t2_dn,
                            vn_up,
                            vn_dn,
                            i5,
                            i6,
                            dt)
                            );

                    }
                }
            }
            return lst_korpus;
        }
        
        public OleDbConnection conn;

        public bool ConnectToParameters()
        {
            string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\TMP\parameters.mdb";
            conn = new OleDbConnection(connStr);
            try
            {
                conn.Open();
                return true;
            }
            catch { }
            return false;
        }

        public bool UpdateRowParameters(int ID, string name, string lnk_t1, string lnk_t2, string lnk_vn, string lnk_vl,
                        string t1_up, string t1_dn, string t2_up, string t2_dn, string vn_up, string vn_dn, string path,
                        DateTime dtBegin,bool krpOn)
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    conn.Open();
                }
                catch { return false; }
            }
/*            string insertSQL = "UPDATE [parameters] "+
                                "SET name_korpus = @name," +
                                   " t1_up = @t1_up, "+
                                   " t1_dn = @t1_dn, "+
                                   " t2_up = @t2_up, "+
                                   " t2_dn = @t2_dn, "+
                                   " vn_up = @vn_up, "+
                                   " vn_dn = @vn_dn, "+
//                                   " enabled = @krpOn, " +
                                   " date_begin = @date_begin "+
                                   " WHERE pk = @ID ";
*/
                        string updateSQL = "UPDATE [parameters] "+
                                "SET name_korpus = @name," +
                                   " lnk_t1 = @lnk_t1, "+
                                   " lnk_t2 = @lnk_t2, " +
                                   " lnk_vn = @lnk_vn, " +
                                   " lnk_vl = @lnk_vl, " +
                                   
                                   " t1_up = @t1_up, "+
                                   " t1_dn = @t1_dn, "+
                                   " t2_up = @t2_up, "+
                                   " t2_dn = @t2_dn, "+
                                   " vn_up = @vn_up, "+
                                   " vn_dn = @vn_dn, "+
                                   " path_file = @path, "+
//                                   " enabled = @krpOn, " +
                                   " date_begin = @date_begin "+
                                   " WHERE pk = @ID ";

            
            using (OleDbCommand command = new OleDbCommand(updateSQL))
            {

                command.Connection = conn;
                command.Parameters.Add("@name", OleDbType.VarChar).Value = name;
                command.Parameters.Add("@lnk_t1", OleDbType.VarChar).Value = lnk_t1;
                command.Parameters.Add("@lnk_t2", OleDbType.VarChar).Value = lnk_t2;
                command.Parameters.Add("@lnk_vn", OleDbType.VarChar).Value = lnk_vn;
                command.Parameters.Add("@lnk_vl", OleDbType.VarChar).Value = lnk_vl;

                command.Parameters.Add("@t1_up", OleDbType.VarChar).Value = t1_up;
                command.Parameters.Add("@t1_dn", OleDbType.VarChar).Value = t1_dn;
                command.Parameters.Add("@t2_up", OleDbType.VarChar).Value = t2_up;
                command.Parameters.Add("@t2_dn", OleDbType.VarChar).Value = t2_dn;
                command.Parameters.Add("@vn_up", OleDbType.VarChar).Value = vn_up;
                command.Parameters.Add("@vn_dn", OleDbType.VarChar).Value = vn_dn;

                command.Parameters.Add("@path", OleDbType.VarChar).Value = path;
/*                if (krpOn)
                    command.Parameters.Add("@krpOn", OleDbType.Boolean).Value = System.Boolean.TrueString;
                else
                    command.Parameters.Add("@krpOn", OleDbType.Boolean).Value = System.Boolean.FalseString;
*/
                command.Parameters.Add("@date_begin", OleDbType.Date).Value = dtBegin.Date;
                command.Parameters.Add("@ID", OleDbType.Integer).Value = ID;

                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно сохранить данные корпуса");
                    return false;
                }
            }

        }

        public bool InsertRowParameters(int ID, string name, string lnk_t1, string lnk_t2, string lnk_vn, string lnk_vl,
                       string t1_up, string t1_dn, string t2_up, string t2_dn, string vn_up, string vn_dn, string path,
                       DateTime dtBegin, bool krpOn)
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    conn.Open();
                }
                catch { return false; }
            }
            Int16 id = -1;

            string selectSQL = "SELECT top 1 * from [parameters] order by pk desc";
            
            using (OleDbCommand commd = new OleDbCommand(selectSQL, conn))
            {
                using (OleDbDataReader dr = commd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        id = (Int16)dr["pk"];
                    }
                }
            }

            id++;
            string insertSQL = "INSERT INTO [parameters] " +
                " (pk, name_korpus, lnk_t1, lnk_t2, lnk_vn, lnk_vl, t1_up, t1_dn, t2_up, t2_dn, vn_up, vn_dn, path_file, date_begin) " +
                " VALUES (@ID, @name, @lnk_t1, @lnk_t2, @lnk_vn, @lnk_vl, @t1_up, @t1_dn, @t2_up, @t2_dn, @vn_up, @vn_dn, @path, @date_begin) ";

            using (OleDbCommand command = new OleDbCommand(insertSQL))
            {

                command.Connection = conn;
                command.Parameters.Add("@ID", OleDbType.Integer).Value = id;
                command.Parameters.Add("@name", OleDbType.VarChar).Value = name;
                command.Parameters.Add("@lnk_t1", OleDbType.VarChar).Value = lnk_t1;
                command.Parameters.Add("@lnk_t2", OleDbType.VarChar).Value = lnk_t2;
                command.Parameters.Add("@lnk_vn", OleDbType.VarChar).Value = lnk_vn;
                command.Parameters.Add("@lnk_vl", OleDbType.VarChar).Value = lnk_vl;

                command.Parameters.Add("@t1_up", OleDbType.VarChar).Value = t1_up;
                command.Parameters.Add("@t1_dn", OleDbType.VarChar).Value = t1_dn;
                command.Parameters.Add("@t2_up", OleDbType.VarChar).Value = t2_up;
                command.Parameters.Add("@t2_dn", OleDbType.VarChar).Value = t2_dn;
                command.Parameters.Add("@vn_up", OleDbType.VarChar).Value = vn_up;
                command.Parameters.Add("@vn_dn", OleDbType.VarChar).Value = vn_dn;

                command.Parameters.Add("@path", OleDbType.VarChar).Value = path;
                /*                if (krpOn)
                                    command.Parameters.Add("@krpOn", OleDbType.Boolean).Value = System.Boolean.TrueString;
                                else
                                    command.Parameters.Add("@krpOn", OleDbType.Boolean).Value = System.Boolean.FalseString;
                */
                command.Parameters.Add("@date_begin", OleDbType.Date).Value = dtBegin.Date;

                try
                {
                        command.ExecuteNonQuery();
                        return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно сохранить данные корпуса");
                    return false;
                }
            }

        }

        public bool DeleteRow(int ID)
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    conn.Open();
                }
                catch { return false; }
            }

            string deleteSQL = "Delete From [parameters] " +
                                  " WHERE pk = @ID ";
            using (OleDbCommand command = new OleDbCommand(deleteSQL))
            {
                command.Connection = conn;
                command.Parameters.Add("@ID", OleDbType.Integer).Value = ID;
                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Невозможно удалить корпус");
                    return false;
                }
            }
            
        }

        public bool UpdateRowEnable(int ID, bool krpOn)
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    conn.Open();
                }
                catch { return false; }
            }
            string updateSQL = "UPDATE [parameters] " +
                    "SET  enabled = @krpOn " +
                       " WHERE pk = @ID ";

            using (OleDbCommand command = new OleDbCommand(updateSQL))
            {
                command.Connection = conn;
                if (krpOn)
                    command.Parameters.Add("@krpOn", OleDbType.Boolean).Value = System.Boolean.TrueString;
                else
                    command.Parameters.Add("@krpOn", OleDbType.Boolean).Value = System.Boolean.FalseString;
               
                command.Parameters.Add("@ID", OleDbType.Integer).Value = ID;

                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        }

        public bool UpdateRowSound(int ID, bool snd)
        {
            if (conn.State != System.Data.ConnectionState.Open)
            {
                try
                {
                    conn.Open();
                }
                catch { return false; }
            }
            string updateSQL = "UPDATE [parameters] " +
                    "SET  sounded = @snd " +
                       " WHERE pk = @ID ";

            using (OleDbCommand command = new OleDbCommand(updateSQL))
            {
                command.Connection = conn;
                if (snd)
                    command.Parameters.Add("@krpOn", OleDbType.Boolean).Value = System.Boolean.TrueString;
                else
                    command.Parameters.Add("@krpOn", OleDbType.Boolean).Value = System.Boolean.FalseString;

                command.Parameters.Add("@ID", OleDbType.Integer).Value = ID;

                try
                {
                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

        }

        public void ConnectToProtocol(Korpus krp)
        {
            string dayNow = DateTime.Now.ToString("MMddyyyy");
            string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + krp.path + dayNow + ".opr";

            if ((krp.connect.ConnectionString.Equals(connStr)) && (krp.connect.State == ConnectionState.Closed))
            {
                try
                {
                    krp.connect.Open();
                    return;
                }
                catch
                { krp.error = 2; return; }
            }

            if ((!krp.connect.ConnectionString.Equals(connStr)) || (krp.connect.State == ConnectionState.Closed))
            {
                if (File.Exists(krp.path + dayNow + ".opr"))
                {
                    try
                    {
                        if (krp.connect.State == ConnectionState.Open)
                            krp.connect.Close();
                        krp.connect.ConnectionString = connStr;
                        krp.connect.Open();
                        krp.error = 0;
                        return;
                    }
                    catch
                    { krp.error = 2; return; }
                }
                else
                    krp.error = 1;
            }
            
        }

        public void GetValue(Korpus krp, int refer, int j)
        {
            System.Threading.ThreadPool.QueueUserWorkItem(
                (o) =>
                {

                    string cmdTxt = "SELECT top " +
                        Global.Count_Values.ToString() + " * " +
                        "FROM protocol " +
                        "WHERE (((protocol.[reference])=@refer) " +
                        "AND ((protocol.[EventTime])<#" +
                        DateTime.Now.ToShortTimeString() + "#)) order by eventtime desc";

                    float[] mas_val = new float[Global.Count_Values];
                    DateTime[] mas_time = new DateTime[Global.Count_Values];

                    if (krp.connect.State != System.Data.ConnectionState.Open)
                    {
                        try
                        {
                            ConnectToProtocol(krp);
                        }
                        catch
                        {
                        }
                    }

                    if (krp.connect.State == System.Data.ConnectionState.Open)
                        using (OleDbCommand myCmd = new OleDbCommand(cmdTxt, krp.connect))
                        {
                            myCmd.Parameters.Add("refer", OleDbType.Integer).Value = refer;

                            using (OleDbDataReader dr = myCmd.ExecuteReader())
                            {
                                int i = 0;

                                while (dr.Read())
                                {
                                    mas_val[i] = (Single)dr["eventvalue"];  //читаем значения из протокола
                                    mas_time[i] = ((DateTime)dr["eventdate"]).Date + ((DateTime)dr["eventtime"]).TimeOfDay;
                                    TimeSpan diff = DateTime.Now - (DateTime)dr["eventtime"];

                                    if ((i == 0) && (diff.Minutes > Global.Timeout_values)) //если время регистрации первого значения больше 15 минут, значит ошибка
                                    {
                                        mas_val[i] = 0;
                                        krp.error = 3;  //датчик не реагирует продолжительное время
                                    }

                                    i++;
                                }
                            }
                        }

                    krp.mas_t1[j] = mas_val;
                    krp.mas_time[j] = mas_time;
                });
        }

        public DataSet GetProtocolPrint(string fullPath)
        {
            string cmdText = "SELECT * FROM [protocol];";
            string dayNow = DateTime.Now.ToString("MMddyyyy");
            string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + fullPath;

            DataSet ds = null;
            OleDbConnection conn_buf = new OleDbConnection(connStr);
                
                    try
                    {
                        conn_buf.Open();
                        using (OleDbCommand myCmd = conn_buf.CreateCommand())
                        {
                            ds = new DataSet();
                            myCmd.CommandText = cmdText;
                            OleDbDataAdapter da = new OleDbDataAdapter();
                            da.SelectCommand = myCmd;
                            da.Fill(ds, "parameters");
                        }
                    }
                    catch (Exception e)
                    { }
            return ds;
        }



        public RefDesc GetDescriptPrint(string fullPath)
        {
            string cmdTxt = "SELECT Distinct(protocol.[Description]),  protocol.[Reference] FROM protocol;";
            string dayNow = DateTime.Now.ToString("MMddyyyy");
            string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + fullPath;


            RefDesc rd = new RefDesc();
            rd.masDesc = new string[4];
            rd.masRef = new int[4];
            using (OleDbConnection conn_buf = new OleDbConnection(connStr))
            {
                try
                {
                    conn_buf.Open();
                    using (OleDbCommand myCmd = conn_buf.CreateCommand())
                    {
                        myCmd.CommandText = cmdTxt;
                        using (OleDbDataReader dr = myCmd.ExecuteReader())
                        {
                            int i = 0;
                            rd.cntRefs = 0;
                            while (dr.Read())
                            {
                                if ((!(dr["Description"] is DBNull)) && (!(dr["Reference"] is DBNull)))
                                {
                                    rd.masDesc[i] = (string)dr["Description"];  //читаем значения из протокола
                                    rd.masRef[i] = (short)dr["Reference"];  //читаем значения из протокола
                                    rd.cntRefs++;
                                    i++;
                                }
                            }
                        }
                    }
                }
                catch (Exception e)
                { }
            }
            return rd;
        }


        public DataSet GetProtocolWarningPrint(string fullPath, Korpus krp, DataSet ds_full)
        {
            string cmdText = "SELECT * FROM [protocol] order by protocol.EventTime;";
            string dayNow = DateTime.Now.ToString("MMddyyyy");
            string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + fullPath;

            DataSet ds = null;
            OleDbConnection conn_buf = new OleDbConnection(connStr);

            try
            {
                conn_buf.Open();
                using (OleDbCommand myCmd = conn_buf.CreateCommand())
                {
                    myCmd.CommandText = cmdText;
                    using (OleDbDataReader dr = myCmd.ExecuteReader())
                    {
                        bool[] alarm = {false,false,false};
                        DateTime[] alarmBegin = {DateTime.MinValue, DateTime.MinValue, DateTime.MinValue};
                        DateTime[] alarmEnd = {DateTime.MinValue, DateTime.MinValue, DateTime.MinValue};
                        
                        DateTime _date = DateTime.MinValue;
                        DateTime _time = DateTime.MinValue;

                        DateTime _dateOld = DateTime.MinValue;
                        DateTime _timeOld = DateTime.MinValue;

                        string _name = "";
                        short _ref = 0;
                        Single _val = 0;


                        object[] row = new object[12];

                        List <object[]> rows = new List<object[]>();

                        while (dr.Read())
                        {
                            if ((!(dr["Description"] is DBNull)) && (!(dr["Reference"] is DBNull)))
                            {
                                _date = (DateTime)dr["EventDate"];
                                _time = (DateTime)dr["EventTime"];
                                
                                if (!_timeOld.TimeOfDay.Equals(_time.TimeOfDay))
                                {

                                    //ds_full.Tables["protocol"].Rows.Add(row);
                                    object[] _rw = new object[12];
                                    for (int n = 0; n < 12; n++)
                                    {
                                        _rw[n] = row[n];
                                    }

                                    rows.Add(_rw);
                                    for (int i = 3; i <= 9; i = i + 3)
                                    {
                                        row[i] = "";
                                        row[i + 1] = 0f; //пустое значение 
                                        row[i + 2] = ""; //пустая длительность
                                    }
                                }

                                _name = krp.name;
                                _ref = (short)dr["Reference"];
                                _val = (Single)dr["EventValue"];

                                row[0] = _date;
                                row[1] = _time;
                                row[2] = _name;

                                for (int i = 0; i < krp.mas_lnk.Length - 1; i++)
                                {
                                    if (_ref == krp.mas_lnk[i])
                                    {
                                        switch (i)
                                        {
                                            case 0:
                                                row[3] = krp.lim_values[0, 0].ToString("D") + " - " + krp.lim_values[0, 1].ToString("D");
                                                row[4] = _val;
                                                break;
                                            case 1:
                                                row[6] = krp.lim_values[1, 0].ToString("D") + " - " + krp.lim_values[1, 1].ToString("D");
                                                row[7] = _val;
                                                break;
                                            case 2:
                                                row[9] = krp.lim_values[2, 0].ToString("D") + " - " + krp.lim_values[2, 1].ToString("D");
                                                row[10] = _val;
                                                break;

                                            default:
                                                break;
                                        }
                                        break;
                                    }
                                }
                                _dateOld = _date;
                                _timeOld = _time;
                                
                            }
                        }


                        //bool isAlarm = false;
                        bool[] isAlarm = new bool[10];
                        isAlarm[3] = false;
                        isAlarm[6] = false;
                        isAlarm[9] = false;

                        bool print = false;

                        for (int i = 0; i < rows.Count; i++)
                        {
                            print = false;

                            for (int j = 3; j <= 9; j = j + 3)
                            {
                                //if ((rows[i][j] == null) || (rows[i][j].Equals("")))
                                //    rows[i][j + 1] = "";
                                int _min = 0;
                                int _max = 0;

                                switch (j)
                                {
                                    case 3:
                                        _min = krp.lim_values[0, 0];
                                        _max = krp.lim_values[0, 1];
                                        break;
                                    case 6:
                                        _min = krp.lim_values[1, 0];
                                        _max = krp.lim_values[1, 1];
                                        break;
                                    case 9:
                                        _min = krp.lim_values[2, 0];
                                        _max = krp.lim_values[2, 1];
                                        break;

                                    default:
                                        break;
                                }

                                //if (j == 3)
                                    if ((rows[i][j] != null) && (!rows[i][j].Equals("")))
                                    {
                                        if ((isAlarm[j]) && (((float)_min < (float)rows[i][j + 1]) && ((float)_max > (float)rows[i][j + 1])))
                                        {
                                            isAlarm[j] = false;
                                            //print = true;
                                        }
                                        else if ((!isAlarm[j]) && (((float)_min >= (float)rows[i][j + 1]) || ((float)_max <= (float)rows[i][j + 1])))
                                        {
                                            isAlarm[j] = true;
                                            print = true;

                                            for (int x = i+1; x < rows.Count; x++)
                                            {
                                                if ((rows[x][j] != null) && (!rows[x][j].Equals("")))
                                                {
                                                    if (((float)_min >= (float)rows[x][j + 1]) || ((float)_max <= (float)rows[x][j + 1]))
                                                    {
                                                        TimeSpan ts = ((DateTime)rows[x][1]).TimeOfDay - ((DateTime)rows[i][1]).TimeOfDay;
                                                        rows[i][j + 2] = ts.Hours.ToString() + "ч. " + ts.Minutes.ToString() + " мин.";
                                                    }
                                                    else
                                                    {
                                                        TimeSpan ts = ((DateTime)rows[x][1]).TimeOfDay - ((DateTime)rows[i][1]).TimeOfDay;
                                                        rows[i][j + 2] = ts.Hours.ToString() + "ч. " + ts.Minutes.ToString() + " мин.";
                                                        break;
                                                    }
                                                   
                                                    //rows[x][j]
                                                }
                                            }
                                        }
                                    }
                                

                            }

                            if (print)
                            //if (isAlarm[3] || isAlarm[6] || isAlarm[9])
                            {
                                ds_full.Tables["protocol"].Rows.Add(rows[i]);
                            }
                            
                            
                        //    ds_full.Tables["protocol"].Rows.Add(rows[i]);
                        }
                        

                    }

                    //ds = new DataSet();
                    //myCmd.CommandText = cmdText;
                    //OleDbDataAdapter da = new OleDbDataAdapter();
                    //da.SelectCommand = myCmd;
                    //da.Fill(ds, "parameters");
                }
            }
            catch (Exception e)
            { }
            return ds;
        }

        public KrpGraph GetProtocolWarningPrintGraph(string fullPath, Korpus krp)
        {
            string cmdText = "";
            string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + fullPath;
            bool isAlarm = false;

            for (int i=0; i < 3; i++)
            {
                if (krp.mas_lnk[i] != -1)
                {
                    switch (i)
                    {
                        case 0:
                            cmdText = " SELECT * FROM [protocol] " +
                                " where (protocol.reference = " + krp.mas_lnk[i].ToString() + ") and (protocol.eventvalue <=" + krp.lim_values[0, 0].ToString() + " or protocol.eventvalue >=" + krp.lim_values[0, 1].ToString()+ ") "+
                                " order by protocol.EventTime;";
                            break;
                        case 1:
                            cmdText = " SELECT * FROM [protocol] " +
                                " where (protocol.reference = " + krp.mas_lnk[i].ToString() + ") and (protocol.eventvalue <=" + krp.lim_values[1, 0].ToString() + " or protocol.eventvalue >=" + krp.lim_values[1, 1].ToString()+ ") "+
                                " order by protocol.EventTime;";
                            
                            break;
                        case 2:
                            cmdText = " SELECT * FROM [protocol] " +
                                " where (protocol.reference = " + krp.mas_lnk[i].ToString() + ") and (protocol.eventvalue <=" + krp.lim_values[2, 0].ToString() + " or protocol.eventvalue >=" + krp.lim_values[2, 1].ToString()+ ") "+
                                " order by protocol.EventTime;";
                            break;
                        default:
                            break;
                    }

                    if ((cmdText.Length > 0) && (findAlarm(cmdText, fullPath) > 0))
                    {
                        isAlarm = true;
                        break;
                    }

                }
            }

            OleDbConnection conn_buf = new OleDbConnection(connStr);
            cmdText = "SELECT * FROM [protocol] order by protocol.EventTime;";

            KrpGraph krpgraph = new KrpGraph();
            krpgraph.name = krp.name;

            if (isAlarm)
            try
            {
                conn_buf.Open();
                using (OleDbCommand myCmd = conn_buf.CreateCommand())
                {
                    myCmd.CommandText = cmdText;
                    using (OleDbDataReader dr = myCmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if ((!(dr["Description"] is DBNull)) && (!(dr["Reference"] is DBNull)))
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    if (krp.mas_lnk[i] == (short)dr["Reference"])
                                    {
                                        switch (i)
                                        {
                                            case 0:
                                                krpgraph.t1_valueX.Add((DateTime)dr["EventTime"]);
                                                krpgraph.t1_valueY.Add((Single)dr["EventValue"]);
                                                krpgraph.t1_descr = (string)dr["Description"];
                                                break;
                                            case 1:
                                                krpgraph.t2_valueX.Add((DateTime)dr["EventTime"]);
                                                krpgraph.t2_valueY.Add((Single)dr["EventValue"]);
                                                krpgraph.t2_descr = (string)dr["Description"];
                                                break;
                                            case 2:
                                                krpgraph.vn_valueX.Add((DateTime)dr["EventTime"]);
                                                krpgraph.vn_valueY.Add((Single)dr["EventValue"]);
                                                krpgraph.vn_descr = (string)dr["Description"];
                                                break;
                                            default:
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                        if (krpgraph.t1_valueX.Count > 0)
                            krpgraph.cntRefs++;
                        if (krpgraph.t2_valueX.Count > 0)
                            krpgraph.cntRefs++;
                        if (krpgraph.vn_valueX.Count > 0)
                            krpgraph.cntRefs++;
                    }
                }
            }
            catch
            {
            }

            return krpgraph;
        }

        private int findAlarm(string cmdText, string fullPath)
        {
            int cntRows = 0;
            string dayNow = DateTime.Now.ToString("MMddyyyy");
            string connStr = @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + fullPath;

            try
            {
                using (OleDbConnection conn_buf = new OleDbConnection(connStr))
                {
                    conn_buf.Open();
                    using (OleDbCommand myCmd = conn_buf.CreateCommand())
                    {
                        DataSet ds = new DataSet();
                        myCmd.CommandText = cmdText;
                        OleDbDataAdapter da = new OleDbDataAdapter();
                        da.SelectCommand = myCmd;
                        da.Fill(ds, "protocol");
                        cntRows = ds.Tables[0].Rows.Count;
                    }
                }
            }
            catch (Exception e)
            { }

            return cntRows;
        }

    }

    public class KrpGraph
    {
        public string name;
        public int cntRefs;
        
        public List<Single> t1_valueY;
        public List<DateTime> t1_valueX;
        public string t1_descr;

        public List<Single> t2_valueY;
        public List<DateTime> t2_valueX;
        public string t2_descr;

        public List<Single> vn_valueY;
        public List<DateTime> vn_valueX;
        public string vn_descr;

        public KrpGraph()
        {
            name = "";
            cntRefs = 0;
            t1_descr = "";
            t2_descr = "";
            vn_descr = "";

            t1_valueY = new List<Single>();
            t1_valueX = new List<DateTime>();

            t2_valueY = new List<Single>();
            t2_valueX = new List<DateTime>();

            vn_valueY = new List<Single>();
            vn_valueX = new List<DateTime>();
        }
    }

    public struct RefDesc
    {
        public string[] masDesc;
        public int[] masRef;
        public int cntRefs;
    }
}
